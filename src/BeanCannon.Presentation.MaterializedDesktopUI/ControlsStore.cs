using BeanCannon.Presentation.MaterializedDesktopUI.Controls;
using BeanCannon.Presentation.MaterializedDesktopUI.Controls.Common;
using BeanCannon.Presentation.MaterializedDesktopUI.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeanCannon.Presentation.MaterializedDesktopUI
{
	public struct ControlsStore
	{
		public ControlsStore(
			MainForm mainForm,
			ProxySettingsControl proxySettingsControl,
			TargetControl targetControl,
			AttackOptionsControl attackOptionsControl,
			WorkersControl workersControl,
			StatusControl statusControl,
			TabPage tabAttackOptions
			)
		{
			MainForm = mainForm;
			ProxySettingsControl = proxySettingsControl;
			TargetControl = targetControl;
			AttackOptionsControl = attackOptionsControl;
			WorkersControl = workersControl;
			StatusControl = statusControl;
			TabAttackOptions = tabAttackOptions;
		}

		public MainForm MainForm { get; }

		public AttackOptionsControl AttackOptionsControl { get; }

		public ProxySettingsControl ProxySettingsControl { get; }

		public StatusControl StatusControl { get; }

		public TargetControl TargetControl { get; }

		public WorkersControl WorkersControl { get; }

		public TabPage TabAttackOptions { get; }

		public void Register()
		{
			AttackOptionsControl.RegisterControlsStore(this);
			ProxySettingsControl.RegisterControlsStore(this);
			TargetControl.RegisterControlsStore(this);
			WorkersControl.RegisterControlsStore(this);
		}
	}
}
