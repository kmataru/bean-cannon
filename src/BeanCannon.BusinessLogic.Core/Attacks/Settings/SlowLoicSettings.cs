using BeanCannon.BusinessLogic.Core.Attacks.Settings.Interfaces;
using System;
using System.Net.Http;

namespace BeanCannon.BusinessLogic.Core.Attacks.Settings
{
	public class SlowLoicSettings : AttackSettings, ISlowLoicSettings
	{
		public string Host { get; internal set; }
		public string UrlPath { get; internal set; }
		public bool UseRandomPath { get; internal set; }
		public bool UseRandomCommands { get; internal set; }
		public bool AllowGzip { get; internal set; }
		public int SocketsPerThread { get; internal set; }
		public HttpMethod HttpRequestMethod { get; internal set; }

		public SlowLoicSettings(IApplicationSettings settings)
		{
			this.Host = String.IsNullOrEmpty(settings.Host) ? settings.Ip : settings.Host; //hopefully they know what they are doing :)
			this.Ip = settings.Ip;
			this.Port = settings.Port;
			this.UrlPath = settings.UrlPath;
			this.SocketsPerThread = settings.SocketsPerThread;
			this.Timeout = settings.Timeout;
			this.Delay = settings.Delay;
			this.UseRandomPath = settings.UseRandomPath;
			this.UseRandomCommands = true;
			this.AllowGzip = settings.AllowGzip;
			this.HttpRequestMethod = settings.HttpRequestMethod;
		}
	}
}
