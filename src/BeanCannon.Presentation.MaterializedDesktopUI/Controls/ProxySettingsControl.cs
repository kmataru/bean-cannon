using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeanCannon.Presentation.MaterializedDesktopUI.Controls
{
	public partial class ProxySettingsControl : UserControl
	{
		public ProxySettingsControl()
		{
			InitializeComponent();

			SeedListView();
			this.listViewProxies.SizeChanged += CommonEvents.MaterialListView_SizeChanged;
		}

		private void SeedListView()
		{
			var data = new[]
			{
				new []{ "255.255.255.255", "60000", "US", "Available" }
			};

			foreach (string[] version in data)
			{
				var item = new ListViewItem(version);
				listViewProxies.Items.Add(item);
			}
		}
	}
}
