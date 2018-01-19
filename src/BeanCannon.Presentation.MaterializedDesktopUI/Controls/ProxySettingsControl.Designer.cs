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
			this.materialListViewProxies = new MaterialSkin.Controls.MaterialListView();
			this.columnHeaderIp = ((BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx)(new BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx()));
			this.columnHeaderPort = ((BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx)(new BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx()));
			this.columnHeaderCountryCode = ((BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx)(new BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx()));
			this.columnHeaderStatus = ((BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx)(new BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx()));
			this.SuspendLayout();
			// 
			// materialListViewProxies
			// 
			this.materialListViewProxies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.materialListViewProxies.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.materialListViewProxies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderIp,
            this.columnHeaderPort,
            this.columnHeaderCountryCode,
            this.columnHeaderStatus});
			this.materialListViewProxies.Depth = 0;
			this.materialListViewProxies.Font = new System.Drawing.Font("Roboto", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.materialListViewProxies.FullRowSelect = true;
			this.materialListViewProxies.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.materialListViewProxies.Location = new System.Drawing.Point(3, 3);
			this.materialListViewProxies.MouseLocation = new System.Drawing.Point(-1, -1);
			this.materialListViewProxies.MouseState = MaterialSkin.MouseState.OUT;
			this.materialListViewProxies.Name = "materialListViewProxies";
			this.materialListViewProxies.OwnerDraw = true;
			this.materialListViewProxies.Size = new System.Drawing.Size(874, 431);
			this.materialListViewProxies.TabIndex = 0;
			this.materialListViewProxies.UseCompatibleStateImageBehavior = false;
			this.materialListViewProxies.View = System.Windows.Forms.View.Details;
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
			this.Controls.Add(this.materialListViewProxies);
			this.Name = "ProxySettingsControl";
			this.Size = new System.Drawing.Size(880, 437);
			this.ResumeLayout(false);

		}

		#endregion

		private MaterialSkin.Controls.MaterialListView materialListViewProxies;
		private Components.ColumnHeaderEx columnHeaderIp;
		private Components.ColumnHeaderEx columnHeaderPort;
		private Components.ColumnHeaderEx columnHeaderCountryCode;
		private Components.ColumnHeaderEx columnHeaderStatus;
	}
}
