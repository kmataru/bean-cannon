using System;
using System.Windows.Forms;
using BeanCannon.Presentation.MaterializedDesktopUI.Controls;
using BeanCannon.Presentation.MaterializedDesktopUI.Controls.Common;
using MaterialSkin;
using MaterialSkin.Controls;

namespace BeanCannon.Presentation.MaterializedDesktopUI.Forms
{
	public partial class MainForm : MaterialForm
	{
		private readonly MaterialSkinManager materialSkinManager;
		private readonly ControlsStore BeanControls;

		public MainForm()
		{
			InitializeComponent();

			BeanControls = new ControlsStore(
				this.proxySettingsControl,
				this.targetControl,
				this.attackOptionsControl,
				this.workersControl,
				this.statusControl
				);

			// Initialize MaterialSkinManager
			materialSkinManager = MaterialSkinManager.Instance;
			materialSkinManager.AddFormToManage(this);
			materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
			materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
		}

		private void ButtonChangeTheme_Click(object sender, EventArgs e)
		{
			materialSkinManager.Theme = materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? MaterialSkinManager.Themes.LIGHT : MaterialSkinManager.Themes.DARK;
		}

		private int colorSchemeIndex;
		private void ButtonChangeColorScheme_Click(object sender, EventArgs e)
		{
			colorSchemeIndex++;
			if (colorSchemeIndex > 2) colorSchemeIndex = 0;

			// These are just example color schemes
			switch (colorSchemeIndex)
			{
				case 0:
					materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
					break;
				case 1:
					materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink200, TextShade.WHITE);
					break;
				case 2:
					materialSkinManager.ColorScheme = new ColorScheme(Primary.Green600, Primary.Green700, Primary.Green200, Accent.Red100, TextShade.WHITE);
					break;
			}
		}

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
		}
	}
}
