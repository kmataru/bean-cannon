using BeanCannon.BusinessLogic.Core.Attacks.Settings.Interfaces;
using System;

namespace BeanCannon.BusinessLogic.Core.Attacks.Settings
{
	public class ICMPSettings : AttackSettings, IIcmpSettings
	{
		public int SocketsPerThread { get; internal set; }
		public bool UseRandomMessage { get; internal set; }

		public ICMPSettings(IFactorySettings settings)
		{
			this.Delay = settings.Delay;

			this.Ip = settings.Ip;
			this.UseRandomMessage = settings.UseRandomMessage;
			this.SocketsPerThread = settings.SocketsPerThread;
		}
	}
}
