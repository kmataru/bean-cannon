using BeanCannon.BusinessLogic.Core.Attacks.Settings.Interfaces;
using System;
using System.Net.Http;

namespace BeanCannon.BusinessLogic.Core.Attacks.Settings
{
	public class HTTPFlooderSettings : AttackSettings, IHttpFlooderSettings
	{
		public string Host { get; internal set; }
		public string UrlPath { get; internal set; }
		public bool WaitReply { get; internal set; }
		public bool UseRandomPath { get; internal set; }
		public bool UseGet { get; internal set; }
		public bool AllowGzip { get; internal set; }
		public HttpMethod HttpRequestMethod { get; internal set; }

		public HTTPFlooderSettings(IApplicationSettings settings)
		{
			this.Host = String.IsNullOrEmpty(settings.Host) ? settings.Ip : settings.Host;
			this.Ip = settings.Ip;
			this.Port = settings.Port;
			this.UrlPath = settings.UrlPath;
			this.WaitReply = settings.WaitReply;
			this.Delay = settings.Delay;
			this.Timeout = settings.Timeout;
			this.UseRandomPath = settings.UseRandomPath;
			this.AllowGzip = settings.AllowGzip;
			this.ProxyConnectionType = settings.ProxyConnectionType;
			this.HttpRequestMethod = settings.HttpRequestMethod;
		}
	}
}
