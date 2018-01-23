using BeanCannon.BusinessLogic.Core.Attacks.Settings.Interfaces;
using System;

namespace BeanCannon.BusinessLogic.Core.Attacks.Settings
{
	public class ReCoilSettings : AttackSettings, IReCoilSettings
	{
		public string Host { get; internal set; }
		public string UrlPath { get; internal set; }
		public bool UseRandomPath { get; internal set; }
		public bool AllowGzip { get; internal set; }
		public bool WaitReply { get; internal set; }

		public int SocketsPerThread;

		public ReCoilSettings(IFactorySettings settings)
		{
			this.Host = String.IsNullOrEmpty(settings.Host) ? settings.Ip : settings.Host; //hopefully they know what they are doing :)
			this.Ip = settings.Ip;
			this.Port = settings.Port;
			this.UrlPath = settings.UrlPath;
			this.SocketsPerThread = settings.SocketsPerThread;
			this.Timeout = settings.Timeout;
			this.Delay = settings.Delay;
			this.UseRandomPath = settings.UseRandomPath;
			this.AllowGzip = settings.AllowGzip;
			this.WaitReply = settings.WaitReply;
		}
	}
}
