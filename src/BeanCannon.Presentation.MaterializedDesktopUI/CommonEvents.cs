using BeanCannon.Presentation.MaterializedDesktopUI.Components;
using BeanCannon.Presentation.MaterializedDesktopUI.Controls.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeanCannon.Presentation.MaterializedDesktopUI
{
	class CommonEvents
	{
		public static void MaterialListView_SizeChanged(object sender, EventArgs e)
		{
			// Don't allow overlapping of SizeChanged calls
			// TODO: Not a good object to be locked.
			lock (sender)
			{
				ListView listView = sender as ListView;
				if (listView != null)
				{
					var typeTester = listView.Columns.Cast<ColumnHeader>()
						.ToArray()
						.All(w => w is ColumnHeaderEx);

					if (!typeTester)
					{
						throw new InvalidCastException($"Columns specified in the {nameof(ListView)} must be of type {nameof(ColumnHeaderEx)}.");
					}

					float totalColumnWeigth = 0;
					float totalColumnWeigthDelta = 0;
					int columnsCount = listView.Columns.Count;

					int[] computedWidths = new int[columnsCount];

					// Get the sum of all column tags
					for (int idx = 0; idx < columnsCount; idx++)
					{
						totalColumnWeigth += (listView.Columns[idx] as ColumnHeaderEx).Weigth;
					}

					var initialListViewWidth = listView.ClientRectangle.Width;
					var listViewWidth = initialListViewWidth;

					// Calculate the percentage of space each column should 
					// occupy in reference to the other columns and then set the 
					// width of the column to that percentage of the visible space.
					for (int idx = 0; idx < columnsCount; idx++)
					{
						var column = (listView.Columns[idx] as ColumnHeaderEx);

						float colPercentage = (column.Weigth / totalColumnWeigth);
						var width = (int)(colPercentage * listViewWidth);

						if (column.MaximumWidth > 0 && width >= column.MaximumWidth)
						{
							computedWidths[idx] = column.MaximumWidth;
							listViewWidth -= column.MaximumWidth;
							totalColumnWeigthDelta -= column.Weigth;
						}
					}

					totalColumnWeigth += totalColumnWeigthDelta;

					for (int idx = 0; idx < columnsCount; idx++)
					{
						int width;

						var column = (listView.Columns[idx] as ColumnHeaderEx);

						if (computedWidths[idx] > 0)
						{
							width = computedWidths[idx];
						}
						else
						{
							float colPercentage = (column.Weigth / totalColumnWeigth);
							width = (int)(colPercentage * listViewWidth);
							computedWidths[idx] = width;
						}

						listView.Columns[idx].Width = width;

						// Support for MaterialListViewEx
						//*
						if (idx == columnsCount - 1)
						{
							MaterialListViewEx materialListViewEx = listView as MaterialListViewEx;
							if (null != materialListViewEx /*&& null != listView.TopItem*/)
							{
								materialListViewEx.OnLastColumnSizeChanged(new LastColumnSizeEventArgs(listView.TopItem?.Index, width));
							}
						}
						//*/
					}

					/*
					var sum = computedWidths.Sum();
					if (initialListViewWidth != sum)
					{
						listView.Columns[columnsCount - 1].Width += (initialListViewWidth - sum);
					}
					//*/
				}
			}
		}
	}
}
