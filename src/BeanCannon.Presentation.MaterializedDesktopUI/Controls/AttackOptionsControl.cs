using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeanCannon.BusinessLogic.Core.Attacks;

namespace BeanCannon.Presentation.MaterializedDesktopUI.Controls
{
	public partial class AttackOptionsControl : UserControl
	{
		public AttackOptionsControl()
		{
			InitializeComponent();

			new FluentControlActivator(AttackProtocol.HTTP)
				.Disable(radioButtonHttpMethodPost).Check(radioButtonHttpMethodGet)
				.Disable(textFieldSocketsPerThread)
				.Disable(checkBoxAppendRandomCharactersToMessage);

			new FluentControlActivator(AttackProtocol.TCP)
				.Disable(panelHttpMethod).Disable(checkBoxUseGzip)
				.Disable(textFieldSocketsPerThread)
				.Disable(checkBoxAppendRandomCharactersToUrl)
				.Disable(panelProxy);

			new FluentControlActivator(AttackProtocol.UDP)
				.Disable(panelHttpMethod).Disable(checkBoxUseGzip)
				.Disable(textFieldSocketsPerThread)
				.Disable(checkBoxAppendRandomCharactersToUrl)
				.Disable(panelProxy);

			new FluentControlActivator(AttackProtocol.ReCoil)
				.Disable(panelHttpMethod)
				.Disable(checkBoxAppendRandomCharactersToMessage)
				.Disable(panelProxy);

			new FluentControlActivator(AttackProtocol.SlowLOIC)
				.Disable(radioButtonHttpMethodHead).Check(radioButtonHttpMethodPost)
				.Disable(checkBoxWaitForReply)
				.Disable(checkBoxAppendRandomCharactersToMessage)
				.Disable(panelProxy);

			new FluentControlActivator(AttackProtocol.ICMP)
				.Disable(panelHttpMethod)
				.Disable(checkBoxWaitForReply)
				.Disable(checkBoxAppendRandomCharactersToUrl)
				.Disable(panelProxy);

			FluentControlActivator.Activate(AttackProtocol.HTTP);
		}

		private void materialRadioButtonAttackMethodHttp_CheckedChanged(object sender, EventArgs e)
		{
			var button = sender as RadioButton;
			FluentControlActivator.Set(AttackProtocol.HTTP, button.Checked);
		}

		private void materialRadioButtonAttackMethodTcp_CheckedChanged(object sender, EventArgs e)
		{
			var button = sender as RadioButton;
			FluentControlActivator.Set(AttackProtocol.TCP, button.Checked);
		}

		private void materialRadioButtonAttackMethodUdp_CheckedChanged(object sender, EventArgs e)
		{
			var button = sender as RadioButton;
			FluentControlActivator.Set(AttackProtocol.UDP, button.Checked);
		}

		private void materialRadioButtonAttackMethodReCoil_CheckedChanged(object sender, EventArgs e)
		{
			var button = sender as RadioButton;
			FluentControlActivator.Set(AttackProtocol.ReCoil, button.Checked);
		}

		private void materialRadioButtonAttackMethodSlowLoic_CheckedChanged(object sender, EventArgs e)
		{
			var button = sender as RadioButton;
			FluentControlActivator.Set(AttackProtocol.SlowLOIC, button.Checked);
		}

		private void materialRadioButtonAttackMethodIcmp_CheckedChanged(object sender, EventArgs e)
		{
			var button = sender as RadioButton;
			FluentControlActivator.Set(AttackProtocol.ICMP, button.Checked);
		}
	}
}
