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
using BeanCannon.BusinessLogic.Core.Services;
using BeanCannon.BusinessLogic.Core.Models;
using BeanCannon.BusinessLogic.Core.Attacks.Settings;
using System.Net.Http;

namespace BeanCannon.Presentation.MaterializedDesktopUI.Controls
{
	public partial class AttackOptionsControl : UserControl, IBeanControl
	{
		private ControlsStore beanControls;

		public AttackOptionsControl()
		{
			InitializeComponent();
		}

		public void RegisterControlsStore(ControlsStore beanControls)
		{
			this.beanControls = beanControls;
		}

		private void AttackOptionsControl_Load(object sender, EventArgs e)
		{
			if (this.DesignMode)
			{
				return;
			}

			//
			// Set up radio buttons tags
			radioButtonAttackMethodHttp.Tag = AttackProtocol.HTTP;
			radioButtonAttackMethodTcp.Tag = AttackProtocol.TCP;
			radioButtonAttackMethodUdp.Tag = AttackProtocol.UDP;
			radioButtonAttackMethodReCoil.Tag = AttackProtocol.ReCoil;
			radioButtonAttackMethodSlowLoic.Tag = AttackProtocol.SlowLOIC;
			radioButtonAttackMethodIcmp.Tag = AttackProtocol.ICMP;

			radioButtonHttpMethodHead.Tag = HttpMethod.Head;
			radioButtonHttpMethodGet.Tag = HttpMethod.Get;
			radioButtonHttpMethodPost.Tag = HttpMethod.Post;

			radioButtonProxyNone.Tag = ProxyConnectionType.None;
			radioButtonProxyRandom.Tag = ProxyConnectionType.Random;
			radioButtonProxyChained.Tag = ProxyConnectionType.Chained;
			//
			//

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

		private void radioButtonAttackMethod_CheckedChanged(object sender, EventArgs e)
		{
			var button = sender as RadioButton;

			var attackProtocol = (AttackProtocol)button.Tag;
			FluentControlActivator.Set(attackProtocol, button.Checked);
		}

		private void buttonStart_Click(object sender, EventArgs e)
		{
			(sender as Button).Enabled = false;

			var settings = this.beanControls.MainForm.settings;

			if (AttackService.Instance.Status == AttackServiceStatus.Idle)
			{
				timerMain.Stop();
			}

			AttackService.Instance.Attack(settings, true, false, false);

			(sender as Button).Enabled = true;

			if (AttackService.Instance.Status == AttackServiceStatus.InProgress)
			{
				timerMain.Start();
				(sender as Button).Text = "Stop";
			}
			else
			{
				(sender as Button).Text = "Start";
			}
		}

		private void timerMain_Tick(object sender, EventArgs e)
		{
			var settings = this.beanControls.MainForm.settings;
			if (AttackService.Instance.GetStatistics(settings, out AttackState attackState))
			{
				this.beanControls.StatusControl.UpdateAttacks(attackState);
			}
		}
	}
}
