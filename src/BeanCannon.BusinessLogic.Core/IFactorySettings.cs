using BeanCannon.BusinessLogic.Core.Attacks.Settings;
using BeanCannon.BusinessLogic.Core.Attacks.Settings.Interfaces;
using System;

namespace BeanCannon.BusinessLogic.Core
{
	// TODO: Change to IApplicationSettings
	public interface IFactorySettings :
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
