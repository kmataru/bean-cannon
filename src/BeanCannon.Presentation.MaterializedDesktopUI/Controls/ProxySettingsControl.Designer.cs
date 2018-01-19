namespace BeanCannon.Presentation.MaterializedDesktopUI.Controls
{
	partial class ProxySettingsControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.listViewProxies = new MaterialSkin.Controls.MaterialListView();
			this.columnHeaderIp = ((BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx)(new BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx()));
			this.columnHeaderPort = ((BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx)(new BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx()));
			this.columnHeaderCountryCode = ((BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx)(new BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx()));
			this.columnHeaderStatus = ((BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx)(new BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx()));
			this.SuspendLayout();
			// 
			// listViewProxies
			// 
			this.listViewProxies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewProxies.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listViewProxies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderIp,
            this.columnHeaderPort,
            this.columnHeaderCountryCode,
            this.columnHeaderStatus});
			this.listViewProxies.Depth = 0;
			this.listViewProxies.Font = new System.Drawing.Font("Roboto", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.listViewProxies.FullRowSelect = true;
			this.listViewProxies.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewProxies.Location = new System.Drawing.Point(3, 3);
			this.listViewProxies.MouseLocation = new System.Drawing.Point(-1, -1);
			this.listViewProxies.MouseState = MaterialSkin.MouseState.OUT;
			this.listViewProxies.Name = "listViewProxies";
			this.listViewProxies.OwnerDraw = true;
			this.listViewProxies.Size = new System.Drawing.Size(874, 431);
			this.listViewProxies.TabIndex = 0;
			this.listViewProxies.UseCompatibleStateImageBehavior = false;
			this.listViewProxies.View = System.Windows.Forms.View.Details;
			// 
			// columnHeaderIp
			// 
			this.columnHeaderIp.Text = "Ip";
			this.columnHeaderIp.Weigth = 2;
			// 
			// columnHeaderPort
			// 
			this.columnHeaderPort.Text = "Port";
			this.columnHeaderPort.Width = 95;
			// 
			// columnHeaderCountryCode
			// 
			this.columnHeaderCountryCode.MaximumWidth = 100;
			this.columnHeaderCountryCode.Text = "Country";
			this.columnHeaderCountryCode.Width = 148;
			// 
			// columnHeaderStatus
			// 
			this.columnHeaderStatus.MaximumWidth = 100;
			this.columnHeaderStatus.Text = "Status";
			this.columnHeaderStatus.Width = 124;
			// 
			// ProxySettingsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.listViewProxies);
			this.Name = "ProxySettingsControl";
			this.Size = new System.Drawing.Size(880, 437);
			this.ResumeLayout(false);

		}

		#endregion
		private Components.ColumnHeaderEx columnHeaderIp;
		private Components.ColumnHeaderEx columnHeaderPort;
		private Components.ColumnHeaderEx columnHeaderCountryCode;
		private Components.ColumnHeaderEx columnHeaderStatus;
		public MaterialSkin.Controls.MaterialListView listViewProxies;
	}
}
