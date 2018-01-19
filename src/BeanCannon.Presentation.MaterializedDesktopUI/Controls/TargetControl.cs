using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeanCannon.Presentation.MaterializedDesktopUI.Components;

namespace BeanCannon.Presentation.MaterializedDesktopUI.Controls
{
	public partial class TargetControl : UserControl
	{
		public TargetControl()
		{
			InitializeComponent();

			//this.BackColor = Color.White;
			this.Load += Page1Component_Load;

			// Add dummy data to the listview
			seedListView();

			this.listViewPaths.SizeChanged += CommonEvents.MaterialListView_SizeChanged;
		}

		private void Page1Component_Load(object sender, EventArgs e)
		{
			this.BackColor = Parent.BackColor;
		}

		private void seedListView()
		{
			//Define
			var data = new[]
			{
				new []{ "/path/1", "666", "0" },
				new []{ "/path/2", "666", "7" },
				new []{ "/path/3", "666", "3" },
				new []{ "/path/4", "666", "7" },
				new []{ "/path/5", "666", "6" },
				new []{ "/path/6", "666", "5" }
			};

			//Add
			foreach (string[] version in data)
			{
				var item = new ListViewItem(version);
				listViewPaths.Items.Add(item);
			}

			//materialListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
			//materialListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
		}
	}
}
