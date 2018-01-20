using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeanCannon.BusinessLogic.Core.Services;
using System.Net.Sockets;
using BeanCannon.BusinessLogic.Core.Extensions;

namespace BeanCannon.Presentation.MaterializedDesktopUI.Controls
{
	public partial class ProxySettingsControl : UserControl
	{
		private ControlsStore beanControls;

		public ProxySettingsControl()
		{
			InitializeComponent();

			this.listViewProxies.SizeChanged += CommonEvents.MaterialListView_SizeChanged;
		}

		private void ProxySettingsControl_Load(object sender, EventArgs e)
		{
			if (this.DesignMode)
			{
				return;
			}

			ProxyTester.Instance.RunAsync();

			timerMain.Start();
		}

		public void RegisterControlsStore(ControlsStore beanControls)
		{
			this.beanControls = beanControls;
		}

		private void timerMain_Tick(object sender, EventArgs e)
		{
			var proxyTester = ProxyTester.Instance;

			UpdateListViewContent();

			this.beanControls.StatusControl.UpdateProxies(proxyTester.state);

			if (proxyTester.state.Done)
			{
				(sender as Timer).Stop();
			}
		}

		private void UpdateListViewContent()
		{
			var proxyTester = ProxyTester.Instance;

			var availableProxies =
				proxyTester.GetAvailableProxies(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp, false);

			listViewProxies.BeginUpdate();

			for (int idx = 0; idx < availableProxies.Length; ++idx)
			{
				var availableProxy = availableProxies[idx];

				var listViewItemExists = listViewProxies.Items.Cast<ListViewItem>()
					.Any(w => w.Text == availableProxy.Ip && w.SubItems[1].Text == availableProxy.Port.ToString());

				if (!listViewItemExists)
				{
					var responseTime = availableProxy.GetTestedProxyResponseTime(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

					var item = new ListViewItem(availableProxy.Ip);
					var data = new[] {
						availableProxy.Port.ToString(),
						availableProxy.CountryCode,
						responseTime.ToString("0.000 s"),
						"Available"
					};

					item.SubItems.AddRange(data);
					listViewProxies.Items.Add(item);
				}
			}

			listViewProxies.EndUpdate();
		}
	}
}
