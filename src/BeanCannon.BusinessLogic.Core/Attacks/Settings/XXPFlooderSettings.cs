using BeanCannon.BusinessLogic.Core.Attacks.Settings.Interfaces;
using System;

namespace BeanCannon.BusinessLogic.Core.Attacks.Settings
{
	public class XXPFlooderSettings : AttackSettings, IXxpFlooderSettings
	{
		public AttackMethod Protocol { get; internal set; }
		public bool WaitReply { get; internal set; }
		public string StreamData { get; internal set; }
		public bool UseRandomMessage { get; internal set; }

		public XXPFlooderSettings(IApplicationSettings settings)
		{
			this.Ip = settings.Ip;
			this.Port = settings.Port;
			this.Protocol = settings.Protocol;
			this.WaitReply = settings.WaitReply;
			this.StreamData = settings.StreamData;
			this.UseRandomMessage = settings.UseRandomMessage;

			this.Delay = settings.Delay;
		}
	}
}
