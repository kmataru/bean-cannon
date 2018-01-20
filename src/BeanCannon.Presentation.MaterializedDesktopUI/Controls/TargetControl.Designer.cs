namespace BeanCannon.Presentation.MaterializedDesktopUI.Controls
{
	partial class TargetControl
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
			this.components = new System.ComponentModel.Container();
			this.listViewPaths = new MaterialSkin.Controls.MaterialListView();
			this.columnHeaderPathAndQuery = ((BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx)(new BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx()));
			this.columnHeaderRequested = ((BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx)(new BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx()));
			this.columnHeaderFailed = ((BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx)(new BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx()));
			this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
			this.buttonLockOn = new MaterialSkin.Controls.MaterialRaisedButton();
			this.textFieldUrlOrIp = new MaterialSkin.Controls.MaterialSingleLineTextField();
			this.timerTextFieldUrlOrIp = new System.Windows.Forms.Timer(this.components);
			this.checkBoxEnableCrawler = new MaterialSkin.Controls.MaterialCheckBox();
			this.panelCrawler = new System.Windows.Forms.Panel();
			this.panelCrawler.SuspendLayout();
			this.SuspendLayout();
			// 
			// listViewPaths
			// 
			this.listViewPaths.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewPaths.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listViewPaths.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderPathAndQuery,
            this.columnHeaderRequested,
            this.columnHeaderFailed});
			this.listViewPaths.Depth = 0;
			this.listViewPaths.Font = new System.Drawing.Font("Roboto", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.listViewPaths.FullRowSelect = true;
			this.listViewPaths.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewPaths.Location = new System.Drawing.Point(0, 33);
			this.listViewPaths.MouseLocation = new System.Drawing.Point(-1, -1);
			this.listViewPaths.MouseState = MaterialSkin.MouseState.OUT;
			this.listViewPaths.Name = "listViewPaths";
			this.listViewPaths.OwnerDraw = true;
			this.listViewPaths.Size = new System.Drawing.Size(744, 218);
			this.listViewPaths.TabIndex = 6;
			this.listViewPaths.UseCompatibleStateImageBehavior = false;
			this.listViewPaths.View = System.Windows.Forms.View.Details;
			// 
			// columnHeaderPathAndQuery
			// 
			this.columnHeaderPathAndQuery.Tag = "";
			this.columnHeaderPathAndQuery.Text = "Path";
			this.columnHeaderPathAndQuery.Weigth = 2;
			this.columnHeaderPathAndQuery.Width = 118;
			// 
			// columnHeaderRequested
			// 
			this.columnHeaderRequested.MaximumWidth = 100;
			this.columnHeaderRequested.Tag = "";
			this.columnHeaderRequested.Text = "Requested";
			this.columnHeaderRequested.Width = 187;
			// 
			// columnHeaderFailed
			// 
			this.columnHeaderFailed.MaximumWidth = 100;
			this.columnHeaderFailed.Tag = "1,100";
			this.columnHeaderFailed.Text = "Failed";
			this.columnHeaderFailed.Width = 101;
			// 
			// materialLabel1
			// 
			this.materialLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.materialLabel1.Depth = 0;
			this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
			this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.materialLabel1.Location = new System.Drawing.Point(10, 48);
			this.materialLabel1.Margin = new System.Windows.Forms.Padding(5);
			this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialLabel1.Name = "materialLabel1";
			this.materialLabel1.Size = new System.Drawing.Size(735, 40);
			this.materialLabel1.TabIndex = 5;
			this.materialLabel1.Text = "No Target";
			this.materialLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// buttonLockOn
			// 
			this.buttonLockOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonLockOn.AutoSize = true;
			this.buttonLockOn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.buttonLockOn.Depth = 0;
			this.buttonLockOn.Icon = null;
			this.buttonLockOn.Location = new System.Drawing.Point(667, 9);
			this.buttonLockOn.Margin = new System.Windows.Forms.Padding(3, 9, 5, 3);
			this.buttonLockOn.MouseState = MaterialSkin.MouseState.HOVER;
			this.buttonLockOn.Name = "buttonLockOn";
			this.buttonLockOn.Primary = true;
			this.buttonLockOn.Size = new System.Drawing.Size(78, 36);
			this.buttonLockOn.TabIndex = 4;
			this.buttonLockOn.Text = "Lock on";
			this.buttonLockOn.UseVisualStyleBackColor = true;
			this.buttonLockOn.Click += new System.EventHandler(this.buttonLockOn_Click);
			// 
			// textFieldUrlOrIp
			// 
			this.textFieldUrlOrIp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textFieldUrlOrIp.Depth = 0;
			this.textFieldUrlOrIp.Hint = "URL or IP address";
			this.textFieldUrlOrIp.Location = new System.Drawing.Point(10, 15);
			this.textFieldUrlOrIp.Margin = new System.Windows.Forms.Padding(10, 15, 15, 5);
			this.textFieldUrlOrIp.MaxLength = 32767;
			this.textFieldUrlOrIp.MouseState = MaterialSkin.MouseState.HOVER;
			this.textFieldUrlOrIp.Name = "textFieldUrlOrIp";
			this.textFieldUrlOrIp.PasswordChar = '\0';
			this.textFieldUrlOrIp.SelectedText = "";
			this.textFieldUrlOrIp.SelectionLength = 0;
			this.textFieldUrlOrIp.SelectionStart = 0;
			this.textFieldUrlOrIp.Size = new System.Drawing.Size(639, 23);
			this.textFieldUrlOrIp.TabIndex = 0;
			this.textFieldUrlOrIp.TabStop = false;
			this.textFieldUrlOrIp.UseSystemPasswordChar = false;
			this.textFieldUrlOrIp.TextChanged += new System.EventHandler(this.textFieldUrlOrIp_TextChanged);
			// 
			// timerTextFieldUrlOrIp
			// 
			this.timerTextFieldUrlOrIp.Interval = 750;
			this.timerTextFieldUrlOrIp.Tick += new System.EventHandler(this.timerTextFieldUrlOrIp_Tick);
			// 
			// checkBoxEnableCrawler
			// 
			this.checkBoxEnableCrawler.AutoSize = true;
			this.checkBoxEnableCrawler.Cursor = System.Windows.Forms.Cursors.Default;
			this.checkBoxEnableCrawler.Depth = 0;
			this.checkBoxEnableCrawler.Enabled = false;
			this.checkBoxEnableCrawler.Font = new System.Drawing.Font("Roboto", 10F);
			this.checkBoxEnableCrawler.Location = new System.Drawing.Point(0, 0);
			this.checkBoxEnableCrawler.Margin = new System.Windows.Forms.Padding(0);
			this.checkBoxEnableCrawler.MouseLocation = new System.Drawing.Point(-1, -1);
			this.checkBoxEnableCrawler.MouseState = MaterialSkin.MouseState.HOVER;
			this.checkBoxEnableCrawler.Name = "checkBoxEnableCrawler";
			this.checkBoxEnableCrawler.Ripple = true;
			this.checkBoxEnableCrawler.Size = new System.Drawing.Size(120, 30);
			this.checkBoxEnableCrawler.TabIndex = 10;
			this.checkBoxEnableCrawler.Text = "Enable crawler";
			this.checkBoxEnableCrawler.UseVisualStyleBackColor = true;
			this.checkBoxEnableCrawler.CheckedChanged += new System.EventHandler(this.checkBoxEnableCrawler_CheckedChanged);
			// 
			// panelCrawler
			// 
			this.panelCrawler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelCrawler.Controls.Add(this.checkBoxEnableCrawler);
			this.panelCrawler.Controls.Add(this.listViewPaths);
			this.panelCrawler.Enabled = false;
			this.panelCrawler.Location = new System.Drawing.Point(3, 96);
			this.panelCrawler.Name = "panelCrawler";
			this.panelCrawler.Size = new System.Drawing.Size(744, 251);
			this.panelCrawler.TabIndex = 11;
			// 
			// TargetControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Controls.Add(this.panelCrawler);
			this.Controls.Add(this.materialLabel1);
			this.Controls.Add(this.buttonLockOn);
			this.Controls.Add(this.textFieldUrlOrIp);
			this.Name = "TargetControl";
			this.Size = new System.Drawing.Size(750, 350);
			this.panelCrawler.ResumeLayout(false);
			this.panelCrawler.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private MaterialSkin.Controls.MaterialRaisedButton buttonLockOn;
		private MaterialSkin.Controls.MaterialLabel materialLabel1;
		private Components.ColumnHeaderEx columnHeaderPathAndQuery;
		private Components.ColumnHeaderEx columnHeaderRequested;
		private Components.ColumnHeaderEx columnHeaderFailed;
		public MaterialSkin.Controls.MaterialSingleLineTextField textFieldUrlOrIp;
		public MaterialSkin.Controls.MaterialListView listViewPaths;
		private System.Windows.Forms.Timer timerTextFieldUrlOrIp;
		public MaterialSkin.Controls.MaterialCheckBox checkBoxEnableCrawler;
		private System.Windows.Forms.Panel panelCrawler;
	}
}
