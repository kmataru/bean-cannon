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
using static System.Windows.Forms.ListViewItem;
using Loic.BusinessLogic.Core.Attacks.Settings;
using BeanCannon.BusinessLogic.Core;
using BeanCannon.BusinessLogic.Core.Attacks;

namespace BeanCannon.Presentation.MaterializedDesktopUI.Controls
{
	public partial class WorkersControl : UserControl
	{
		private const string TimeFormat = "{0,6:#,##0.00}";

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

		[Obsolete]
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

					listViewWorkers.Controls.Add(materialProgressBar);
				}
			}
		}

		public void AddOrUpdateToListViewContent(IFlooder flooder)
		{
			if (flooder.State.ManagedThreadId == 0)
			{
				return;
			}

			ListViewSubItemCollection currentSubItems;

			ListViewItem currentListViewItem = listViewWorkers.Items.Cast<ListViewItem>()
				.FirstOrDefault(w => w.Text == $"W-{flooder.State.ManagedThreadId}");

			var listViewItemExists = null != currentListViewItem;

			listViewWorkers.BeginUpdate();

			if (!listViewItemExists)
			{
				var item = new ListViewItem($"W-{flooder.State.ManagedThreadId}");
				var data = new[] {
					String.Empty,
					String.Empty,
					String.Empty,
					String.Empty,
					String.Empty
				};

				item.SubItems.AddRange(data);
				listViewWorkers.Items.Add(item);

				{
					MaterialProgressBar progressBar = new MaterialProgressBar();
					progressBar.Depth = 0;
					progressBar.Location = new Point(834, 64);
					progressBar.MouseState = MaterialSkin.MouseState.HOVER;
					progressBar.Size = new Size(157, 5);
					progressBar.Maximum = 100;
					progressBar.Value = 0;

					listViewWorkers.Controls.Add(progressBar);
				}

				currentSubItems = item.SubItems;
			}
			else
			{
				currentSubItems = currentListViewItem.SubItems;
			}

			var currentIndex = listViewWorkers.Items.IndexOf(currentListViewItem);
			var currentProgressBar = (listViewWorkers.Controls[currentIndex] as ProgressBar);

			UpdateWorkerData(currentSubItems, currentProgressBar, flooder);

			listViewWorkers.EndUpdate();
		}

		private void UpdateWorkerData(ListViewSubItemCollection subItems, ProgressBar responsivenessProgressBar, IFlooder flooder)
		{
			const int StatusIndex = 1;
			const int RequestedIndex = 2;
			const int DownloadedIndex = 3;
			const int FailedIndex = 4;
			const int ResponsivenessIndex = 5;

			var elapsed = flooder.Clock.Elapsed;
			var totalMilliseconds = elapsed.TotalMilliseconds;
			var totalSeconds = elapsed.TotalSeconds;

			//
			// Generic
			/*
			if (flooder.State.ManagedThreadId > 0)
			{
				this.Enabled = true;
			}
			else
			{
				this.Enabled = false;
			}
			*/
			//

			//
			// Worker Thread Id
			/*
			if (flooder.State.ManagedThreadId > 0)
			{
				this.labelWorkerName.Text = $"W-{flooder.State.ManagedThreadId}";
			}
			else
			{
				this.labelWorkerName.Text = $"N/A";
			}
			*/
			//

			//
			// Time Progress
			//if (flooder.State.ManagedThreadId > 0)
			{
				responsivenessProgressBar.Maximum = (int)flooder.Settings.Timeout.TotalSeconds;
				if (totalSeconds > responsivenessProgressBar.Maximum)
				{
					responsivenessProgressBar.Value = responsivenessProgressBar.Maximum;
				}
				else
				{
					responsivenessProgressBar.Value = (int)totalSeconds;
				}
			}
			/*
			else
			{
				this.progressBarWorkerResponsiveness.Maximum = 1;
				this.progressBarWorkerResponsiveness.Value = 0;
			}
			*/
			//

			//
			// Responsiveness
			//if (flooder.State.ManagedThreadId > 0)
			{
				String responsiveness = null;

				if (totalMilliseconds < 1000)
				{
					responsiveness = String.Format($"{TimeFormat} ms", totalMilliseconds);
				}
				else
				{
					if (totalSeconds < 1000)
					{
						responsiveness = String.Format($"{TimeFormat} s", totalSeconds);
					}
					else
					{
						var totalMinutes = elapsed.TotalMinutes;
						responsiveness = String.Format($"{TimeFormat} m", totalMinutes);
					}
				}

				subItems[ResponsivenessIndex].Text = responsiveness;
			}
			/*
			else
			{
				subItems[ResponsivenessIndex].Text = String.Empty;
			}
			*/
			//

			//
			// State
			//if (flooder.State.ManagedThreadId > 0)
			{
				subItems[StatusIndex].Text = flooder.State.Status.ToString();
				subItems[RequestedIndex].Text = Format.Size(flooder.State.Requested).ToString();
				subItems[DownloadedIndex].Text = Format.Size(flooder.State.Downloaded).ToString();
				subItems[FailedIndex].Text = Format.Size(flooder.State.Failed).ToString();
			}
			//
		}
	}
}