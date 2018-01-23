using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeanCannon.Presentation.MaterializedDesktopUI.Controls
{
	partial class AttackOptionsControl
	{
		// TODO: Experimental. Use FluentValidators
		private void textFieldTimeout_Validating(object sender, CancelEventArgs e)
		{
			var textBox = (sender as TextBox);

			bool timeoutParseValid;

			// Name is required
			if (
				String.IsNullOrEmpty(textBox.Text.Trim()) ||
				((timeoutParseValid = int.TryParse(textBox.Text, out int timeout)) && timeout <= 0) ||
				!timeoutParseValid
				)
			{
				e.Cancel = true;
				return;
			}
		}
	}
}
