namespace BeanCannon.Presentation.MaterializedDesktopUI.Controls.Common
{
	partial class StatusControl
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
			this.columnHeaderProxySocketType = ((BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx)(new BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx()));
			this.columnHeaderProxyTotal = ((BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx)(new BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx()));
			this.columnHeaderProxyTypes = ((BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx)(new BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx()));
			this.columnHeaderProxyTesting = ((BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx)(new BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx()));
			this.columnHeaderProxyTested = ((BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx)(new BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx()));
			this.columnHeaderProxyFailed = ((BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx)(new BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx()));
			this.columnHeaderProxyAvailable = ((BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx)(new BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx()));
			this.listViewAttacks = new MaterialSkin.Controls.MaterialListView();
			this.columnHeaderAttackIdle = ((BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx)(new BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx()));
			this.columnHeaderAttackConnecting = ((BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx)(new BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx()));
			this.columnHeaderAttackRequesting = ((BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx)(new BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx()));
			this.columnHeaderAttackDownloading = ((BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx)(new BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx()));
			this.columnHeaderAttackDownloaded = ((BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx)(new BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx()));
			this.columnHeaderAttackRequested = ((BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx)(new BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx()));
			this.columnHeaderAttackFailed = ((BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx)(new BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx()));
			this.panel11 = new System.Windows.Forms.Panel();
			this.labelProxyTesterStatus = new MaterialSkin.Controls.MaterialLabel();
			this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
			this.panel12 = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.labelAttackStatus = new MaterialSkin.Controls.MaterialLabel();
			this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel11.SuspendLayout();
			this.panel12.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// listViewProxies
			// 
			this.listViewProxies.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listViewProxies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderProxySocketType,
            this.columnHeaderProxyTotal,
            this.columnHeaderProxyTypes,
            this.columnHeaderProxyTesting,
            this.columnHeaderProxyTested,
            this.columnHeaderProxyFailed,
            this.columnHeaderProxyAvailable});
			this.listViewProxies.Depth = 0;
			this.listViewProxies.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewProxies.Font = new System.Drawing.Font("Roboto", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.listViewProxies.FullRowSelect = true;
			this.listViewProxies.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewProxies.Location = new System.Drawing.Point(0, 0);
			this.listViewProxies.MouseLocation = new System.Drawing.Point(-1, -1);
			this.listViewProxies.MouseState = MaterialSkin.MouseState.OUT;
			this.listViewProxies.Name = "listViewProxies";
			this.listViewProxies.OwnerDraw = true;
			this.listViewProxies.Scrollable = false;
			this.listViewProxies.Size = new System.Drawing.Size(1110, 95);
			this.listViewProxies.TabIndex = 0;
			this.listViewProxies.UseCompatibleStateImageBehavior = false;
			this.listViewProxies.View = System.Windows.Forms.View.Details;
			// 
			// columnHeaderProxySocketType
			// 
			this.columnHeaderProxySocketType.Text = "Type";
			this.columnHeaderProxySocketType.Width = 83;
			// 
			// columnHeaderProxyTotal
			// 
			this.columnHeaderProxyTotal.Text = "Total";
			this.columnHeaderProxyTotal.Width = 86;
			// 
			// columnHeaderProxyTypes
			// 
			this.columnHeaderProxyTypes.Text = "Types";
			this.columnHeaderProxyTypes.Width = 105;
			// 
			// columnHeaderProxyTesting
			// 
			this.columnHeaderProxyTesting.Text = "Testing";
			this.columnHeaderProxyTesting.Width = 121;
			// 
			// columnHeaderProxyTested
			// 
			this.columnHeaderProxyTested.Text = "Tested";
			this.columnHeaderProxyTested.Width = 114;
			// 
			// columnHeaderProxyFailed
			// 
			this.columnHeaderProxyFailed.Text = "Failed";
			this.columnHeaderProxyFailed.Width = 101;
			// 
			// columnHeaderProxyAvailable
			// 
			this.columnHeaderProxyAvailable.Text = "Available";
			this.columnHeaderProxyAvailable.Width = 151;
			// 
			// listViewAttacks
			// 
			this.listViewAttacks.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listViewAttacks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderAttackIdle,
            this.columnHeaderAttackConnecting,
            this.columnHeaderAttackRequesting,
            this.columnHeaderAttackDownloading,
            this.columnHeaderAttackDownloaded,
            this.columnHeaderAttackRequested,
            this.columnHeaderAttackFailed});
			this.listViewAttacks.Depth = 0;
			this.listViewAttacks.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewAttacks.Font = new System.Drawing.Font("Roboto", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.listViewAttacks.FullRowSelect = true;
			this.listViewAttacks.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewAttacks.Location = new System.Drawing.Point(0, 0);
			this.listViewAttacks.MouseLocation = new System.Drawing.Point(-1, -1);
			this.listViewAttacks.MouseState = MaterialSkin.MouseState.OUT;
			this.listViewAttacks.Name = "listViewAttacks";
			this.listViewAttacks.OwnerDraw = true;
			this.listViewAttacks.Scrollable = false;
			this.listViewAttacks.Size = new System.Drawing.Size(1110, 95);
			this.listViewAttacks.TabIndex = 1;
			this.listViewAttacks.UseCompatibleStateImageBehavior = false;
			this.listViewAttacks.View = System.Windows.Forms.View.Details;
			// 
			// columnHeaderAttackIdle
			// 
			this.columnHeaderAttackIdle.Text = "Idle";
			this.columnHeaderAttackIdle.Width = 73;
			// 
			// columnHeaderAttackConnecting
			// 
			this.columnHeaderAttackConnecting.Text = "Connecting";
			this.columnHeaderAttackConnecting.Width = 184;
			// 
			// columnHeaderAttackRequesting
			// 
			this.columnHeaderAttackRequesting.Text = "Requesting";
			this.columnHeaderAttackRequesting.Width = 186;
			// 
			// columnHeaderAttackDownloading
			// 
			this.columnHeaderAttackDownloading.Text = "Downloading";
			this.columnHeaderAttackDownloading.Width = 204;
			// 
			// columnHeaderAttackDownloaded
			// 
			this.columnHeaderAttackDownloaded.Text = "Downloaded";
			this.columnHeaderAttackDownloaded.Width = 193;
			// 
			// columnHeaderAttackRequested
			// 
			this.columnHeaderAttackRequested.Text = "Requested";
			this.columnHeaderAttackRequested.Width = 168;
			// 
			// columnHeaderAttackFailed
			// 
			this.columnHeaderAttackFailed.Text = "Failed";
			this.columnHeaderAttackFailed.Width = 99;
			// 
			// panel11
			// 
			this.panel11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel11.Controls.Add(this.labelProxyTesterStatus);
			this.panel11.Controls.Add(this.materialLabel6);
			this.panel11.Controls.Add(this.panel12);
			this.panel11.Location = new System.Drawing.Point(3, 5);
			this.panel11.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
			this.panel11.Name = "panel11";
			this.panel11.Size = new System.Drawing.Size(1110, 114);
			this.panel11.TabIndex = 26;
			// 
			// labelProxyTesterStatus
			// 
			this.labelProxyTesterStatus.AutoSize = true;
			this.labelProxyTesterStatus.Depth = 0;
			this.labelProxyTesterStatus.Font = new System.Drawing.Font("Roboto", 11F);
			this.labelProxyTesterStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.labelProxyTesterStatus.Location = new System.Drawing.Point(114, 0);
			this.labelProxyTesterStatus.MouseState = MaterialSkin.MouseState.HOVER;
			this.labelProxyTesterStatus.Name = "labelProxyTesterStatus";
			this.labelProxyTesterStatus.Size = new System.Drawing.Size(49, 19);
			this.labelProxyTesterStatus.TabIndex = 22;
			this.labelProxyTesterStatus.Text = "          ";
			// 
			// materialLabel6
			// 
			this.materialLabel6.AutoSize = true;
			this.materialLabel6.Depth = 0;
			this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
			this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.materialLabel6.Location = new System.Drawing.Point(3, 0);
			this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialLabel6.Name = "materialLabel6";
			this.materialLabel6.Size = new System.Drawing.Size(105, 19);
			this.materialLabel6.TabIndex = 21;
			this.materialLabel6.Text = "Proxies status";
			// 
			// panel12
			// 
			this.panel12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel12.Controls.Add(this.listViewProxies);
			this.panel12.Location = new System.Drawing.Point(0, 19);
			this.panel12.Margin = new System.Windows.Forms.Padding(0);
			this.panel12.Name = "panel12";
			this.panel12.Size = new System.Drawing.Size(1110, 95);
			this.panel12.TabIndex = 20;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.labelAttackStatus);
			this.panel1.Controls.Add(this.materialLabel1);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Location = new System.Drawing.Point(3, 122);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1110, 114);
			this.panel1.TabIndex = 27;
			// 
			// labelAttackStatus
			// 
			this.labelAttackStatus.AutoSize = true;
			this.labelAttackStatus.Depth = 0;
			this.labelAttackStatus.Font = new System.Drawing.Font("Roboto", 11F);
			this.labelAttackStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.labelAttackStatus.Location = new System.Drawing.Point(114, 0);
			this.labelAttackStatus.MouseState = MaterialSkin.MouseState.HOVER;
			this.labelAttackStatus.Name = "labelAttackStatus";
			this.labelAttackStatus.Size = new System.Drawing.Size(49, 19);
			this.labelAttackStatus.TabIndex = 22;
			this.labelAttackStatus.Text = "          ";
			// 
			// materialLabel1
			// 
			this.materialLabel1.AutoSize = true;
			this.materialLabel1.Depth = 0;
			this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
			this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.materialLabel1.Location = new System.Drawing.Point(3, 0);
			this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialLabel1.Name = "materialLabel1";
			this.materialLabel1.Size = new System.Drawing.Size(99, 19);
			this.materialLabel1.TabIndex = 21;
			this.materialLabel1.Text = "Attack status";
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.Controls.Add(this.listViewAttacks);
			this.panel2.Location = new System.Drawing.Point(0, 19);
			this.panel2.Margin = new System.Windows.Forms.Padding(0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1110, 95);
			this.panel2.TabIndex = 20;
			// 
			// StatusControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel11);
			this.MinimumSize = new System.Drawing.Size(425, 172);
			this.Name = "StatusControl";
			this.Size = new System.Drawing.Size(1116, 236);
			this.panel11.ResumeLayout(false);
			this.panel11.PerformLayout();
			this.panel12.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private Components.ColumnHeaderEx columnHeaderProxySocketType;
		private Components.ColumnHeaderEx columnHeaderProxyTotal;
		private Components.ColumnHeaderEx columnHeaderProxyTypes;
		private Components.ColumnHeaderEx columnHeaderProxyTesting;
		private Components.ColumnHeaderEx columnHeaderProxyTested;
		private Components.ColumnHeaderEx columnHeaderProxyFailed;
		private Components.ColumnHeaderEx columnHeaderProxyAvailable;
		private Components.ColumnHeaderEx columnHeaderAttackIdle;
		private Components.ColumnHeaderEx columnHeaderAttackConnecting;
		private Components.ColumnHeaderEx columnHeaderAttackRequesting;
		private Components.ColumnHeaderEx columnHeaderAttackDownloading;
		private Components.ColumnHeaderEx columnHeaderAttackDownloaded;
		private Components.ColumnHeaderEx columnHeaderAttackRequested;
		private Components.ColumnHeaderEx columnHeaderAttackFailed;
		private System.Windows.Forms.Panel panel11;
		private MaterialSkin.Controls.MaterialLabel materialLabel6;
		private System.Windows.Forms.Panel panel12;
		private System.Windows.Forms.Panel panel1;
		private MaterialSkin.Controls.MaterialLabel materialLabel1;
		private System.Windows.Forms.Panel panel2;
		public MaterialSkin.Controls.MaterialListView listViewProxies;
		public MaterialSkin.Controls.MaterialListView listViewAttacks;
		internal MaterialSkin.Controls.MaterialLabel labelProxyTesterStatus;
		internal MaterialSkin.Controls.MaterialLabel labelAttackStatus;
	}
}
