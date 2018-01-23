using System.ComponentModel;
using System.Windows.Forms;

namespace BeanCannon.Presentation.MaterializedDesktopUI.Components
{
	public class ColumnHeaderEx : ColumnHeader
	{
		private int _weight = 1;
		private int _minimumWidth = 50;
		private int _maximumWidth = 0;

		[DefaultValue(1)]
		public int Weight { get => _weight; set => _weight = value; }

		[DefaultValue(50)]
		public int MinimumWidth { get => _minimumWidth; set => _minimumWidth = value; }

		[DefaultValue(0)]
		public int MaximumWidth { get => _maximumWidth; set => _maximumWidth = value; }
	}
}
