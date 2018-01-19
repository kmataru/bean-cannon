using MaterialSkin.Controls;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BeanCannon.Presentation.MaterializedDesktopUI.Controls.Common
{
	public class TopItemIndexEventArgs : EventArgs
	{
		public TopItemIndexEventArgs(int? topItemIndex)
		{
			TopItemIndex = topItemIndex;
		}

		public int? TopItemIndex { get; set; }
	}

	public class LastColumnSizeEventArgs : TopItemIndexEventArgs
	{
		public LastColumnSizeEventArgs(int? topItemIndex, int width) : base(topItemIndex)
		{
			Width = width;
		}

		public int Width { get; set; }
	}

	/// <summary>
	/// FROM https://stackoverflow.com/questions/8792097/winforms-listview-topitem-changed-event
	/// </summary>
	public class MaterialListViewEx : MaterialListView
	{
		public delegate void TopItemIndexEventHandler(object sender, TopItemIndexEventArgs e);
		public delegate void LastColumnSizeEventHandler(object sender, LastColumnSizeEventArgs e);

		public event TopItemIndexEventHandler TopItemChanged;
		public event LastColumnSizeEventHandler LastColumnSizeChanged;

		private ListViewItem lastTopItem = null;

		protected virtual void OnTopItemChanged(TopItemIndexEventArgs e)
		{
			TopItemChanged?.Invoke(this, e);
		}

		public virtual void OnLastColumnSizeChanged(LastColumnSizeEventArgs e)
		{
			LastColumnSizeChanged?.Invoke(this, e);
		}

		// READ https://wiki.winehq.org/List_Of_Windows_Messages
		protected override void WndProc(ref Message m)
		{
			// Trap LVN_ENDSCROLL, delivered with a WM_REFLECT + WM_NOTIFY message
			if (m.Msg == 0x204e) // OCM_NOTIFY
			{
				var notify = (NMHDR)Marshal.PtrToStructure(m.LParam, typeof(NMHDR));
				if (notify.code == -181 && (null == this.TopItem || !this.TopItem.Equals(lastTopItem)))
				{
					OnTopItemChanged(new TopItemIndexEventArgs(this.TopItem?.Index));
					lastTopItem = this.TopItem;
				}
			}
			else if (m.Msg == 0x0112) // WM_SYSCOMMAND
			{
				// Check your window state here
				if (m.WParam == new IntPtr(0xF030)) // Maximize event - SC_MAXIMIZE from Winuser.h
				{
					if (null == this.TopItem || !this.TopItem.Equals(lastTopItem))
					{
						OnTopItemChanged(new TopItemIndexEventArgs(this.TopItem?.Index));
						lastTopItem = this.TopItem;
					}
				}
			}

			base.WndProc(ref m);
		}

		private struct NMHDR
		{
			public IntPtr hwndFrom;
			public IntPtr idFrom;
			public int code;
		}
	}
}
