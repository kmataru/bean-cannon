using BeanCannon.Presentation.MaterializedDesktopUI.Controls;
using BeanCannon.Presentation.MaterializedDesktopUI.Controls.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeanCannon.Presentation.MaterializedDesktopUI
{
	public struct ControlsStore
	{
		public ControlsStore(
			ProxySettingsControl proxySettingsControl,
			TargetControl targetControl,
			AttackOptionsControl attackOptionsControl,
			WorkersControl workersControl,
			StatusControl statusControl
			)
		{
			ProxySettingsControl = proxySettingsControl;
			TargetControl = targetControl;
			AttackOptionsControl = attackOptionsControl;
			WorkersControl = workersControl;
			StatusControl = statusControl;
		}

		public ProxySettingsControl ProxySettingsControl { get; }

		public TargetControl TargetControl { get; }

		public AttackOptionsControl AttackOptionsControl { get; }

		public WorkersControl WorkersControl { get; }

		public StatusControl StatusControl { get; }

		public void Register()
		{
			ProxySettingsControl.RegisterControlsStore(this);
		}
	}
}
