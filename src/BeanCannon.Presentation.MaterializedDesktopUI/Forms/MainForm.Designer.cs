using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace BeanCannon.Presentation.MaterializedDesktopUI.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.materialFlatButton2 = new MaterialSkin.Controls.MaterialFlatButton();
			this.materialFlatButton1 = new MaterialSkin.Controls.MaterialFlatButton();
			this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
			this.materialButtonChangeTheme = new MaterialSkin.Controls.MaterialRaisedButton();
			this.materialTabSelectorMain = new MaterialSkin.Controls.MaterialTabSelector();
			this.materialTabControlMain = new MaterialSkin.Controls.MaterialTabControl();
			this.tabPageProxySettings = new System.Windows.Forms.TabPage();
			this.proxySettingsControl = new BeanCannon.Presentation.MaterializedDesktopUI.Controls.ProxySettingsControl();
			this.tabPageTargetAndCrawler = new System.Windows.Forms.TabPage();
			this.targetControl = new BeanCannon.Presentation.MaterializedDesktopUI.Controls.TargetControl();
			this.attackOptionsControl = new System.Windows.Forms.TabPage();
			this.attackOptionsControl1 = new BeanCannon.Presentation.MaterializedDesktopUI.Controls.AttackOptionsControl();
			this.tabPageWorkers = new System.Windows.Forms.TabPage();
			this.workersControl = new BeanCannon.Presentation.MaterializedDesktopUI.Controls.WorkersControl();
			this.tabPageAbout = new System.Windows.Forms.TabPage();
			this.aboutControl = new BeanCannon.Presentation.MaterializedDesktopUI.Controls.AboutControl();
			this.materialRaisedButtonChangeColorScheme = new MaterialSkin.Controls.MaterialRaisedButton();
			this.materialContextMenuStrip1 = new MaterialSkin.Controls.MaterialContextMenuStrip();
			this.item1ToolStripMenuItem = new MaterialSkin.Controls.MaterialToolStripMenuItem();
			this.subItem1ToolStripMenuItem = new MaterialSkin.Controls.MaterialToolStripMenuItem();
			this.subItem2ToolStripMenuItem = new MaterialSkin.Controls.MaterialToolStripMenuItem();
			this.disabledItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.item2ToolStripMenuItem = new MaterialSkin.Controls.MaterialToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.item3ToolStripMenuItem = new MaterialSkin.Controls.MaterialToolStripMenuItem();
			this.materialFlatButton3 = new MaterialSkin.Controls.MaterialFlatButton();
			this.panel1 = new System.Windows.Forms.Panel();
			this.statusControl = new BeanCannon.Presentation.MaterializedDesktopUI.Controls.Common.StatusControl();
			this.materialTabControlMain.SuspendLayout();
			this.tabPageProxySettings.SuspendLayout();
			this.tabPageTargetAndCrawler.SuspendLayout();
			this.attackOptionsControl.SuspendLayout();
			this.tabPageWorkers.SuspendLayout();
			this.tabPageAbout.SuspendLayout();
			this.materialContextMenuStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// materialFlatButton2
			// 
			this.materialFlatButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.materialFlatButton2.AutoSize = true;
			this.materialFlatButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.materialFlatButton2.Depth = 0;
			this.materialFlatButton2.Icon = null;
			this.materialFlatButton2.Location = new System.Drawing.Point(770, 657);
			this.materialFlatButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.materialFlatButton2.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialFlatButton2.Name = "materialFlatButton2";
			this.materialFlatButton2.Primary = false;
			this.materialFlatButton2.Size = new System.Drawing.Size(100, 36);
			this.materialFlatButton2.TabIndex = 13;
			this.materialFlatButton2.Text = "Secondary";
			this.materialFlatButton2.UseVisualStyleBackColor = true;
			// 
			// materialFlatButton1
			// 
			this.materialFlatButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.materialFlatButton1.AutoSize = true;
			this.materialFlatButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.materialFlatButton1.Depth = 0;
			this.materialFlatButton1.Icon = null;
			this.materialFlatButton1.Location = new System.Drawing.Point(870, 657);
			this.materialFlatButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.materialFlatButton1.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialFlatButton1.Name = "materialFlatButton1";
			this.materialFlatButton1.Primary = true;
			this.materialFlatButton1.Size = new System.Drawing.Size(80, 36);
			this.materialFlatButton1.TabIndex = 1;
			this.materialFlatButton1.Text = "Primary";
			this.materialFlatButton1.UseVisualStyleBackColor = true;
			// 
			// materialDivider1
			// 
			this.materialDivider1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.materialDivider1.Depth = 0;
			this.materialDivider1.Location = new System.Drawing.Point(0, 650);
			this.materialDivider1.Margin = new System.Windows.Forms.Padding(0);
			this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialDivider1.Name = "materialDivider1";
			this.materialDivider1.Size = new System.Drawing.Size(968, 1);
			this.materialDivider1.TabIndex = 16;
			this.materialDivider1.Text = "materialDivider1";
			// 
			// materialButtonChangeTheme
			// 
			this.materialButtonChangeTheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.materialButtonChangeTheme.AutoSize = true;
			this.materialButtonChangeTheme.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.materialButtonChangeTheme.Depth = 0;
			this.materialButtonChangeTheme.Icon = null;
			this.materialButtonChangeTheme.Location = new System.Drawing.Point(14, 657);
			this.materialButtonChangeTheme.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialButtonChangeTheme.Name = "materialButtonChangeTheme";
			this.materialButtonChangeTheme.Primary = true;
			this.materialButtonChangeTheme.Size = new System.Drawing.Size(125, 36);
			this.materialButtonChangeTheme.TabIndex = 0;
			this.materialButtonChangeTheme.Text = "Change Theme";
			this.materialButtonChangeTheme.UseVisualStyleBackColor = true;
			this.materialButtonChangeTheme.Click += new System.EventHandler(this.materialButton1_Click);
			// 
			// materialTabSelectorMain
			// 
			this.materialTabSelectorMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.materialTabSelectorMain.BaseTabControl = this.materialTabControlMain;
			this.materialTabSelectorMain.Depth = 0;
			this.materialTabSelectorMain.Location = new System.Drawing.Point(0, 64);
			this.materialTabSelectorMain.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialTabSelectorMain.Name = "materialTabSelectorMain";
			this.materialTabSelectorMain.Size = new System.Drawing.Size(968, 48);
			this.materialTabSelectorMain.TabIndex = 17;
			this.materialTabSelectorMain.Text = "materialTabSelector1";
			// 
			// materialTabControlMain
			// 
			this.materialTabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.materialTabControlMain.Controls.Add(this.tabPageProxySettings);
			this.materialTabControlMain.Controls.Add(this.tabPageTargetAndCrawler);
			this.materialTabControlMain.Controls.Add(this.attackOptionsControl);
			this.materialTabControlMain.Controls.Add(this.tabPageWorkers);
			this.materialTabControlMain.Controls.Add(this.tabPageAbout);
			this.materialTabControlMain.Depth = 0;
			this.materialTabControlMain.Location = new System.Drawing.Point(14, 111);
			this.materialTabControlMain.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialTabControlMain.Name = "materialTabControlMain";
			this.materialTabControlMain.SelectedIndex = 0;
			this.materialTabControlMain.Size = new System.Drawing.Size(934, 299);
			this.materialTabControlMain.TabIndex = 18;
			// 
			// tabPageProxySettings
			// 
			this.tabPageProxySettings.Controls.Add(this.proxySettingsControl);
			this.tabPageProxySettings.Location = new System.Drawing.Point(4, 22);
			this.tabPageProxySettings.Name = "tabPageProxySettings";
			this.tabPageProxySettings.Size = new System.Drawing.Size(926, 273);
			this.tabPageProxySettings.TabIndex = 6;
			this.tabPageProxySettings.Text = "Proxy";
			this.tabPageProxySettings.UseVisualStyleBackColor = true;
			// 
			// proxySettingsControl
			// 
			this.proxySettingsControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.proxySettingsControl.Location = new System.Drawing.Point(0, 0);
			this.proxySettingsControl.Name = "proxySettingsControl";
			this.proxySettingsControl.Size = new System.Drawing.Size(926, 273);
			this.proxySettingsControl.TabIndex = 0;
			// 
			// tabPageTargetAndCrawler
			// 
			this.tabPageTargetAndCrawler.Controls.Add(this.targetControl);
			this.tabPageTargetAndCrawler.Location = new System.Drawing.Point(4, 22);
			this.tabPageTargetAndCrawler.Name = "tabPageTargetAndCrawler";
			this.tabPageTargetAndCrawler.Size = new System.Drawing.Size(926, 273);
			this.tabPageTargetAndCrawler.TabIndex = 5;
			this.tabPageTargetAndCrawler.Text = "Target and Crawler";
			this.tabPageTargetAndCrawler.UseVisualStyleBackColor = true;
			// 
			// targetControl
			// 
			this.targetControl.BackColor = System.Drawing.Color.Transparent;
			this.targetControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.targetControl.Location = new System.Drawing.Point(0, 0);
			this.targetControl.Name = "targetControl";
			this.targetControl.Size = new System.Drawing.Size(926, 273);
			this.targetControl.TabIndex = 0;
			// 
			// attackOptionsControl
			// 
			this.attackOptionsControl.Controls.Add(this.attackOptionsControl1);
			this.attackOptionsControl.Location = new System.Drawing.Point(4, 22);
			this.attackOptionsControl.Name = "attackOptionsControl";
			this.attackOptionsControl.Size = new System.Drawing.Size(926, 273);
			this.attackOptionsControl.TabIndex = 7;
			this.attackOptionsControl.Text = "Attack options";
			this.attackOptionsControl.UseVisualStyleBackColor = true;
			// 
			// attackOptionsControl1
			// 
			this.attackOptionsControl1.Location = new System.Drawing.Point(3, 3);
			this.attackOptionsControl1.Name = "attackOptionsControl1";
			this.attackOptionsControl1.Size = new System.Drawing.Size(744, 413);
			this.attackOptionsControl1.TabIndex = 0;
			// 
			// tabPageWorkers
			// 
			this.tabPageWorkers.Controls.Add(this.workersControl);
			this.tabPageWorkers.Location = new System.Drawing.Point(4, 22);
			this.tabPageWorkers.Name = "tabPageWorkers";
			this.tabPageWorkers.Size = new System.Drawing.Size(926, 273);
			this.tabPageWorkers.TabIndex = 8;
			this.tabPageWorkers.Text = "Workers";
			this.tabPageWorkers.UseVisualStyleBackColor = true;
			// 
			// workersControl
			// 
			this.workersControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.workersControl.Location = new System.Drawing.Point(0, 0);
			this.workersControl.Name = "workersControl";
			this.workersControl.Size = new System.Drawing.Size(926, 273);
			this.workersControl.TabIndex = 0;
			// 
			// tabPageAbout
			// 
			this.tabPageAbout.Controls.Add(this.aboutControl);
			this.tabPageAbout.Location = new System.Drawing.Point(4, 22);
			this.tabPageAbout.Name = "tabPageAbout";
			this.tabPageAbout.Size = new System.Drawing.Size(926, 273);
			this.tabPageAbout.TabIndex = 9;
			this.tabPageAbout.Text = "About";
			this.tabPageAbout.UseVisualStyleBackColor = true;
			// 
			// aboutControl
			// 
			this.aboutControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.aboutControl.Location = new System.Drawing.Point(0, 0);
			this.aboutControl.Name = "aboutControl";
			this.aboutControl.Size = new System.Drawing.Size(926, 273);
			this.aboutControl.TabIndex = 0;
			// 
			// materialRaisedButtonChangeColorScheme
			// 
			this.materialRaisedButtonChangeColorScheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.materialRaisedButtonChangeColorScheme.AutoSize = true;
			this.materialRaisedButtonChangeColorScheme.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.materialRaisedButtonChangeColorScheme.Depth = 0;
			this.materialRaisedButtonChangeColorScheme.Icon = null;
			this.materialRaisedButtonChangeColorScheme.Location = new System.Drawing.Point(145, 657);
			this.materialRaisedButtonChangeColorScheme.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialRaisedButtonChangeColorScheme.Name = "materialRaisedButtonChangeColorScheme";
			this.materialRaisedButtonChangeColorScheme.Primary = true;
			this.materialRaisedButtonChangeColorScheme.Size = new System.Drawing.Size(181, 36);
			this.materialRaisedButtonChangeColorScheme.TabIndex = 21;
			this.materialRaisedButtonChangeColorScheme.Text = "Change color scheme";
			this.materialRaisedButtonChangeColorScheme.UseVisualStyleBackColor = true;
			this.materialRaisedButtonChangeColorScheme.Click += new System.EventHandler(this.materialRaisedButton1_Click);
			// 
			// materialContextMenuStrip1
			// 
			this.materialContextMenuStrip1.BackColor = System.Drawing.Color.White;
			this.materialContextMenuStrip1.Depth = 0;
			this.materialContextMenuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.materialContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.item1ToolStripMenuItem,
            this.disabledItemToolStripMenuItem,
            this.item2ToolStripMenuItem,
            this.toolStripSeparator1,
            this.item3ToolStripMenuItem});
			this.materialContextMenuStrip1.Margin = new System.Windows.Forms.Padding(16, 8, 16, 8);
			this.materialContextMenuStrip1.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialContextMenuStrip1.Name = "materialContextMenuStrip1";
			this.materialContextMenuStrip1.Size = new System.Drawing.Size(166, 130);
			// 
			// item1ToolStripMenuItem
			// 
			this.item1ToolStripMenuItem.AutoSize = false;
			this.item1ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subItem1ToolStripMenuItem,
            this.subItem2ToolStripMenuItem});
			this.item1ToolStripMenuItem.Name = "item1ToolStripMenuItem";
			this.item1ToolStripMenuItem.Size = new System.Drawing.Size(170, 30);
			this.item1ToolStripMenuItem.Text = "Item 1";
			// 
			// subItem1ToolStripMenuItem
			// 
			this.subItem1ToolStripMenuItem.AutoSize = false;
			this.subItem1ToolStripMenuItem.Name = "subItem1ToolStripMenuItem";
			this.subItem1ToolStripMenuItem.Size = new System.Drawing.Size(152, 30);
			this.subItem1ToolStripMenuItem.Text = "SubItem 1";
			// 
			// subItem2ToolStripMenuItem
			// 
			this.subItem2ToolStripMenuItem.AutoSize = false;
			this.subItem2ToolStripMenuItem.Name = "subItem2ToolStripMenuItem";
			this.subItem2ToolStripMenuItem.Size = new System.Drawing.Size(152, 30);
			this.subItem2ToolStripMenuItem.Text = "SubItem 2";
			// 
			// disabledItemToolStripMenuItem
			// 
			this.disabledItemToolStripMenuItem.AutoSize = false;
			this.disabledItemToolStripMenuItem.Enabled = false;
			this.disabledItemToolStripMenuItem.Name = "disabledItemToolStripMenuItem";
			this.disabledItemToolStripMenuItem.Size = new System.Drawing.Size(170, 30);
			this.disabledItemToolStripMenuItem.Text = "Disabled item";
			// 
			// item2ToolStripMenuItem
			// 
			this.item2ToolStripMenuItem.AutoSize = false;
			this.item2ToolStripMenuItem.Name = "item2ToolStripMenuItem";
			this.item2ToolStripMenuItem.Size = new System.Drawing.Size(170, 30);
			this.item2ToolStripMenuItem.Text = "Item 2";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(162, 6);
			// 
			// item3ToolStripMenuItem
			// 
			this.item3ToolStripMenuItem.AutoSize = false;
			this.item3ToolStripMenuItem.Name = "item3ToolStripMenuItem";
			this.item3ToolStripMenuItem.Size = new System.Drawing.Size(170, 30);
			this.item3ToolStripMenuItem.Text = "Item 3";
			// 
			// materialFlatButton3
			// 
			this.materialFlatButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.materialFlatButton3.AutoSize = true;
			this.materialFlatButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.materialFlatButton3.Depth = 0;
			this.materialFlatButton3.Enabled = false;
			this.materialFlatButton3.Icon = null;
			this.materialFlatButton3.Location = new System.Drawing.Point(686, 657);
			this.materialFlatButton3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.materialFlatButton3.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialFlatButton3.Name = "materialFlatButton3";
			this.materialFlatButton3.Primary = false;
			this.materialFlatButton3.Size = new System.Drawing.Size(84, 36);
			this.materialFlatButton3.TabIndex = 19;
			this.materialFlatButton3.Text = "DISABLED";
			this.materialFlatButton3.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.statusControl);
			this.panel1.Location = new System.Drawing.Point(14, 416);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(934, 231);
			this.panel1.TabIndex = 23;
			// 
			// statusControl
			// 
			this.statusControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.statusControl.Location = new System.Drawing.Point(0, 0);
			this.statusControl.MinimumSize = new System.Drawing.Size(425, 172);
			this.statusControl.Name = "statusControl";
			this.statusControl.Size = new System.Drawing.Size(934, 231);
			this.statusControl.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(960, 700);
			this.ContextMenuStrip = this.materialContextMenuStrip1;
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.materialRaisedButtonChangeColorScheme);
			this.Controls.Add(this.materialFlatButton3);
			this.Controls.Add(this.materialFlatButton2);
			this.Controls.Add(this.materialTabSelectorMain);
			this.Controls.Add(this.materialButtonChangeTheme);
			this.Controls.Add(this.materialTabControlMain);
			this.Controls.Add(this.materialDivider1);
			this.Controls.Add(this.materialFlatButton1);
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(800, 600);
			this.Name = "MainForm";
			this.Text = "Planetarium Destruction with an Improvised Bean Cannon";
			this.materialTabControlMain.ResumeLayout(false);
			this.tabPageProxySettings.ResumeLayout(false);
			this.tabPageTargetAndCrawler.ResumeLayout(false);
			this.attackOptionsControl.ResumeLayout(false);
			this.tabPageWorkers.ResumeLayout(false);
			this.tabPageAbout.ResumeLayout(false);
			this.materialContextMenuStrip1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton materialButtonChangeTheme;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton1;
        private MaterialFlatButton materialFlatButton2;
        private MaterialDivider materialDivider1;
        private MaterialTabSelector materialTabSelectorMain;
        private MaterialTabControl materialTabControlMain;
        private MaterialContextMenuStrip materialContextMenuStrip1;
        private MaterialSkin.Controls.MaterialToolStripMenuItem item1ToolStripMenuItem;
        private MaterialSkin.Controls.MaterialToolStripMenuItem subItem1ToolStripMenuItem;
        private MaterialSkin.Controls.MaterialToolStripMenuItem subItem2ToolStripMenuItem;
        private MaterialSkin.Controls.MaterialToolStripMenuItem item2ToolStripMenuItem;
        private MaterialSkin.Controls.MaterialToolStripMenuItem item3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem disabledItemToolStripMenuItem;
		private MaterialRaisedButton materialRaisedButtonChangeColorScheme;
        private MaterialFlatButton materialFlatButton3;
		private TabPage tabPageTargetAndCrawler;
		private Controls.TargetControl targetControl;
		private TabPage tabPageProxySettings;
		private Controls.ProxySettingsControl proxySettingsControl;
		private TabPage attackOptionsControl;
		private Controls.AttackOptionsControl attackOptionsControl1;
		private Panel panel1;
		private Controls.Common.StatusControl statusControl;
		private TabPage tabPageWorkers;
		private Controls.WorkersControl workersControl;
		private TabPage tabPageAbout;
		private Controls.AboutControl aboutControl;
	}
}