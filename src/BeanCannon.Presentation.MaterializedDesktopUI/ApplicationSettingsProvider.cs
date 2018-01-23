using BeanCannon.BusinessLogic.Core;
using BeanCannon.BusinessLogic.Core.Attacks;
using BeanCannon.BusinessLogic.Core.Attacks.Settings;
using System;
using System.Net.Http;
using System.Windows.Forms;

namespace BeanCannon.Presentation.MaterializedDesktopUI
{
	class ApplicationSettingsProvider : IApplicationSettings
	{
		private readonly ControlsStore store;

		private HttpMethod _HttpRequestMethod = HttpMethod.Get;
		private AttackMethod _Protocol = AttackMethod.HTTP;
		private ProxyConnectionType _ProxyConnectionType = ProxyConnectionType.Random;
		private int _Delay = 1,
			_Port = 80,
			_SocketsPerThread = 15,
			_Timeout = 30,
			_Threads = 10;

		public ApplicationSettingsProvider(ControlsStore store)
		{
			this.store = store;

			store.AttackOptionsControl.radioButtonAttackMethodSlowLoic.CheckedChanged += RadioButtonAttackMethod_CheckedChanged;
			store.AttackOptionsControl.radioButtonAttackMethodReCoil.CheckedChanged += RadioButtonAttackMethod_CheckedChanged;
			store.AttackOptionsControl.radioButtonAttackMethodHttp.CheckedChanged += RadioButtonAttackMethod_CheckedChanged;
			store.AttackOptionsControl.radioButtonAttackMethodTcp.CheckedChanged += RadioButtonAttackMethod_CheckedChanged;
			store.AttackOptionsControl.radioButtonAttackMethodUdp.CheckedChanged += RadioButtonAttackMethod_CheckedChanged;
			store.AttackOptionsControl.radioButtonAttackMethodIcmp.CheckedChanged += RadioButtonAttackMethod_CheckedChanged;

			store.AttackOptionsControl.radioButtonHttpMethodHead.CheckedChanged += RadioButtonHttpMethod_CheckedChanged;
			store.AttackOptionsControl.radioButtonHttpMethodGet.CheckedChanged += RadioButtonHttpMethod_CheckedChanged;
			store.AttackOptionsControl.radioButtonHttpMethodPost.CheckedChanged += RadioButtonHttpMethod_CheckedChanged;

			store.AttackOptionsControl.radioButtonProxyNone.CheckedChanged += RadioButtonProxy_CheckedChanged;
			store.AttackOptionsControl.radioButtonProxyRandom.CheckedChanged += RadioButtonProxy_CheckedChanged;
			store.AttackOptionsControl.radioButtonProxyChained.CheckedChanged += RadioButtonProxy_CheckedChanged;

			store.AttackOptionsControl.trackBarDelay.CursorChanged += delegate (object sender, EventArgs e)
			{
				_Delay = (sender as TrackBar).Value;
			};

			store.AttackOptionsControl.textFieldPort.TextChanged += delegate (object sender, EventArgs e)
			{
				int.TryParse((sender as TextBox).Text, out _Port);
			};

			store.AttackOptionsControl.textFieldSocketsPerThread.TextChanged += delegate (object sender, EventArgs e)
			{
				int.TryParse((sender as TextBox).Text, out _SocketsPerThread);
			};

			store.AttackOptionsControl.textFieldTimeout.TextChanged += delegate (object sender, EventArgs e)
			{
				int.TryParse((sender as TextBox).Text, out _Timeout);
			};

			store.AttackOptionsControl.textFieldThreads.TextChanged += delegate (object sender, EventArgs e)
			{
				int.TryParse((sender as TextBox).Text, out _Threads);
			};
		}

		private void RadioButtonAttackMethod_CheckedChanged(object sender, EventArgs e)
		{
			var button = sender as RadioButton;
			if (button.Checked)
			{
				_Protocol = (AttackMethod)button.Tag;
			}
		}

		private void RadioButtonHttpMethod_CheckedChanged(object sender, EventArgs e)
		{
			var button = sender as RadioButton;
			if (button.Checked)
			{
				_HttpRequestMethod = (HttpMethod)button.Tag;
			}
		}

		private void RadioButtonProxy_CheckedChanged(object sender, EventArgs e)
		{
			var button = sender as RadioButton;
			if (button.Checked)
			{
				_ProxyConnectionType = (ProxyConnectionType)button.Tag;
			}
		}

		public AttackMethod Protocol => _Protocol;

		public string StreamData => store.AttackOptionsControl.textFieldMessageStream.Text;

		public string UrlPath
		{
			get
			{
				// Workaround? 'till crawler will be implemented.
				var items = store.TargetControl.listViewPaths.Items;
				var first = items[0];
				if (Uri.TryCreate(first.Text, UriKind.Absolute, out Uri uri))
				{
					return uri.PathAndQuery;
				}

				return "/";
			}
		}

		public string Host
		{
			get
			{
				// Workaround? 'till crawler will be implemented.
				var items = store.TargetControl.listViewPaths.Items;
				var first = items[0];
				if (Uri.TryCreate(first.Text, UriKind.Absolute, out Uri uri))
				{
					return uri.Host;
				}

				return first.Text;
			}
		}

		public string Ip => store.TargetControl.labelTargetIp.Text;

		public int Port => _Port;

		public TimeSpan Delay => _Delay <= 0 ? TimeSpan.FromMilliseconds(1) : TimeSpan.FromSeconds(_Delay);

		public TimeSpan Timeout => _Timeout <= 0 ? TimeSpan.FromSeconds(30) : TimeSpan.FromSeconds(_Timeout);

		public int Threads => _Threads;

		public int SocketsPerThread => _SocketsPerThread;

		public bool UseRandomPath => store.AttackOptionsControl.checkBoxAppendRandomCharactersToUrl.Checked;

		public HttpMethod HttpRequestMethod => _HttpRequestMethod;

		public bool AllowGzip => store.AttackOptionsControl.checkBoxUseGzip.Checked;

		public bool UseRandomMessage => store.AttackOptionsControl.checkBoxAppendRandomCharactersToMessage.Checked;

		public bool UseRandomCommands => store.AttackOptionsControl.checkBoxUseRandomHeaderCommands.Checked;

		public ProxyConnectionType ProxyConnectionType => _ProxyConnectionType;

		public bool WaitReply => store.AttackOptionsControl.checkBoxWaitForReply.Checked;
	}
}
