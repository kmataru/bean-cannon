using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeanCannon.Presentation.MaterializedDesktopUI.Controls.Common
{
	public partial class StatusControl : UserControl
	{
		public StatusControl()
		{
			InitializeComponent();

			SeedListView();

			this.listViewProxies.SizeChanged += CommonEvents.MaterialListView_SizeChanged;
			this.listViewAttacks.SizeChanged += CommonEvents.MaterialListView_SizeChanged;
		}

		private void SeedListView()
		{
			var data = new[]
			{
				new []{ "1", "2", "3", "4", "5", "6", "7" }
			};

			foreach (string[] version in data)
			{
				var item = new ListViewItem(version);
				listViewProxies.Items.Add(item);
			}

			foreach (string[] version in data)
			{
				var item = new ListViewItem(version);
				listViewAttacks.Items.Add(item);
			}
		}
	}
}
