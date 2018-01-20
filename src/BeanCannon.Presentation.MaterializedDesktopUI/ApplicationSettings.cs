using BeanCannon.BusinessLogic.Core;
using BeanCannon.BusinessLogic.Core.Attacks;
using BeanCannon.BusinessLogic.Core.Attacks.Settings;
using System;
using System.Net.Http;

namespace BeanCannon.Presentation.MaterializedDesktopUI
{
	class ApplicationSettings : IFactorySettings
	{
		ControlsStore store;

		internal int _Port, _Delay, _Timeout, _SocketsPerThread;

		public ApplicationSettings(ControlsStore store)
		{
			this.store = store;
		}

		public AttackProtocol Protocol { get; internal set; }

		public string StreamData { get; internal set; }

		public string UrlPath { get; internal set; }

		public string Host { get; internal set; } = String.Empty;

		public string Ip { get; internal set; } = String.Empty;

		public int Port => _Port;

		public TimeSpan Delay => _Delay <= 0 ? TimeSpan.FromMilliseconds(1) : TimeSpan.FromSeconds(_Delay);

		public TimeSpan Timeout => _Timeout <= 0 ? TimeSpan.FromSeconds(30) : TimeSpan.FromSeconds(_Timeout);

		public int SocketsPerThread => _SocketsPerThread;

		public bool UseRandomPath => store.AttackOptionsControl.checkBoxAppendRandomCharactersToUrl.Checked;

		[Obsolete]
		public bool UseGet { get; } = true;

		public HttpMethod HttpRequestMethod
		{
			get
			{
				if (store.AttackOptionsControl.radioButtonHttpMethodHead.Checked)
				{
					return HttpMethod.Head;
				}
				else if (store.AttackOptionsControl.radioButtonHttpMethodGet.Checked)
				{
					return HttpMethod.Get;
				}
				else
				{
					return HttpMethod.Post;
				}
			}
		}

		public bool AllowGzip => store.AttackOptionsControl.checkBoxUseGzip.Checked;

		public bool UseRandomMessage => store.AttackOptionsControl.checkBoxAppendRandomCharactersToMessage.Checked;

		public bool UseRandomCommands => store.AttackOptionsControl.checkBoxUseRandomHeaderCommands.Checked;

		public ProxyConnectionType ProxyConnectionType
		{
			get
			{
				if (store.AttackOptionsControl.radioButtonProxyNone.Checked)
				{
					return ProxyConnectionType.None;
				}
				else if (store.AttackOptionsControl.radioButtonProxyRandom.Checked)
				{
					return ProxyConnectionType.Random;
				}
				else
				{
					return ProxyConnectionType.Chained;
				}
			}
		}

		public bool WaitReply => store.AttackOptionsControl.checkBoxWaitForReply.Checked;
	}
}
