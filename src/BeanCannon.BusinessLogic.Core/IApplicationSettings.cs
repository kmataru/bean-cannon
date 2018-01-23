using BeanCannon.BusinessLogic.Core.Attacks.Settings;
using BeanCannon.BusinessLogic.Core.Attacks.Settings.Interfaces;
using System;

namespace BeanCannon.BusinessLogic.Core
{
	public interface IApplicationSettings :
		IHttpFlooderSettings,
		IIcmpSettings,
		IReCoilSettings,
		ISlowLoicSettings,
		IXxpFlooderSettings
	{
		string Ip { get; }

		int Port { get; }

		TimeSpan Delay { get; }

		TimeSpan Timeout { get; }

		int Threads { get; }

		ProxyConnectionType ProxyConnectionType { get; }
	}
}
