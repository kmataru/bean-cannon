using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using BeanCannon.Presentation.MaterializedDesktopUI.Components;
using BeanCannon.Presentation.MaterializedDesktopUI.Controls.Common;

namespace BeanCannon.Presentation.MaterializedDesktopUI.Controls
{
	public partial class WorkersControl : UserControl
	{
		// TODO: Review events.
		public WorkersControl()
		{
			InitializeComponent();

			SeedListView();

			this.listViewWorkers.SizeChanged += CommonEvents.MaterialListView_SizeChanged;
			this.listViewWorkers.LastColumnSizeChanged += MaterialListView1_LastColumnSizeChanged;
			this.listViewWorkers.TopItemChanged += MaterialListView1_TopItemChanged;
		}

		private void MaterialListView1_LastColumnSizeChanged(object sender, LastColumnSizeEventArgs e)
		{
			var listView = sender as MaterialListViewEx;

			int topItemIndex = e.TopItemIndex ?? 0;
			int offset = 0 - topItemIndex;
			var width = e.Width;

			for (int idx = 0; idx < listView.Controls.Count; ++idx)
			{
				var progressBar = listView.Controls[idx] as MaterialProgressBar;

				if (idx < topItemIndex)
				{
					progressBar.Visible = false;
				}
				else
				{
					progressBar.Visible = true;
				}

				progressBar.Location = new Point(
					listView.Location.X + listView.ClientRectangle.Width - width,
					62 + 43 * offset++
					);

				progressBar.Width = width - 15;
			}
		}

		private void MaterialListView1_TopItemChanged(object sender, TopItemIndexEventArgs e)
		{
			var listView = sender as ListView;

			int topItemIndex = e.TopItemIndex ?? 0;
			int offset = 0 - topItemIndex;

			for (int idx = 0; idx < listView.Controls.Count; ++idx)
			{
				var progressBar = listView.Controls[idx] as MaterialProgressBar;

				if (idx < topItemIndex)
				{
					progressBar.Visible = false;
				}
				else
				{
					progressBar.Visible = true;
				}

				progressBar.Location = new Point(
					progressBar.Location.X,
					62 + 43 * offset++
					);
			}
		}

		private void SeedListView()
		{
			for (int idx = 1; idx <= 10; ++idx)
			{
				var item = new ListViewItem(new[] { $"W-0{idx}", "Downloading", "999M", "999M", "999M", "999.99ms" });
				listViewWorkers.Items.Add(item);

				{
					MaterialProgressBar materialProgressBar = new MaterialProgressBar();
					materialProgressBar.Depth = 0;
					materialProgressBar.Location = new Point(834, 64);
					materialProgressBar.MouseState = MaterialSkin.MouseState.HOVER;
					materialProgressBar.Name = $"materialProgressBar{idx}";
					materialProgressBar.Size = new Size(157, 5);
					materialProgressBar.Maximum = 10;
					materialProgressBar.Value = idx;
					//materialProgressBar1.TabIndex = 1;

					listViewWorkers.Controls.Add(materialProgressBar);
				}
			}
		}
	}
}