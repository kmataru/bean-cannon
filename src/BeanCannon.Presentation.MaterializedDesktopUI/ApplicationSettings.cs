using BeanCannon.BusinessLogic.Core;
using BeanCannon.BusinessLogic.Core.Attacks;
using BeanCannon.BusinessLogic.Core.Attacks.Settings;
using BeanCannon.Presentation.MaterializedDesktopUI.Forms;
using System;

namespace BeanCannon.Presentation.MaterializedDesktopUI
{
	class ApplicationSettings : IFactorySettings
	{
		MainForm.ControlsStore store;

		internal int _Port, _Delay, _Timeout, _SocketsPerThread;

		public ApplicationSettings(MainForm.ControlsStore store)
		{
			this.store = store;
		}

		public AttackProtocol Protocol { get; internal set; }

		public string StreamData { get; internal set; }
		public string UrlPath { get; internal set; }
		public string Host { get; internal set; } = "";
		public string Ip { get; internal set; } = "";

		public int Port { get { return _Port; } }
		public TimeSpan Delay { get { return _Delay <= 0 ? TimeSpan.FromMilliseconds(1) : TimeSpan.FromSeconds(_Delay); } }
		public TimeSpan Timeout { get { return _Timeout <= 0 ? TimeSpan.FromSeconds(30) : TimeSpan.FromSeconds(_Timeout); } }
		public int SocketsPerThread { get { return _SocketsPerThread; } }

		public bool UseRandomPath { get { return store.checkBoxRandomPath.Checked; } }
		public bool UseGet { get { return store.checkBoxUseGet.Checked; } }
		public bool AllowGzip { get { return store.checkBoxAllowGzip.Checked; } }
		public bool UseRandomMessage { get { return store.checkBoxUseRandomMessage.Checked; } }
		public bool UseRandomCommands { get; } = true;
		public ProxyConnectionType ProxyConnectionType { get { return store.checkBoxUseProxy.Checked ? ProxyConnectionType.Random : ProxyConnectionType.None; } }

		public bool WaitReply { get; internal set; }
	}
}
