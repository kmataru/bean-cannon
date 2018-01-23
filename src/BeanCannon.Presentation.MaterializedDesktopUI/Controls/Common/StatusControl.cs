using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;
using BeanCannon.BusinessLogic.Core.Models;

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
			{
				var item = new ListViewItem(new[] { "Socks", "0", "0", "0", "0", "0", "0" });
				listViewProxies.Items.Add(item);
			}

			{
				var item = new ListViewItem(new[] { "0", "0", "0", "0", "0", "0", "0" });
				listViewAttacks.Items.Add(item);
			}
		}

		public void UpdateProxies(ProxyTesterState state)
		{
			if (state == null)
			{
				throw new ArgumentNullException(nameof(state));
			}

			ListViewItem item = listViewProxies.Items[0];
			ListViewSubItemCollection subItems = item.SubItems;

			listViewProxies.BeginUpdate();

			subItems[1].Text = state.Total.ToString();
			subItems[2].Text = state.Types.ToString();
			subItems[3].Text = state.Testing.ToString();
			subItems[4].Text = state.Tested.ToString();
			subItems[5].Text = state.Failed.ToString();
			subItems[6].Text = state.Available.ToString();

			listViewProxies.EndUpdate();
		}

		public void UpdateAttacks(AttackState state)
		{
			if (state == null)
			{
				throw new ArgumentNullException(nameof(state));
			}

			ListViewItem item = listViewAttacks.Items[0];
			ListViewSubItemCollection subItems = item.SubItems;

			listViewAttacks.BeginUpdate();

			subItems[0].Text = state.Idle.ToString();
			subItems[1].Text = state.Connecting.ToString();
			subItems[2].Text = state.Requesting.ToString();
			subItems[3].Text = state.Downloading.ToString();
			subItems[4].Text = state.Downloaded.ToString();
			subItems[5].Text = state.Requested.ToString();
			subItems[6].Text = state.Failed.ToString();

			listViewAttacks.EndUpdate();
		}
	}
}
