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
			this.listViewPaths = new MaterialSkin.Controls.MaterialListView();
			this.columnHeaderPathAndQuery = ((BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx)(new BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx()));
			this.columnHeaderRequested = ((BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx)(new BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx()));
			this.columnHeaderFailed = ((BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx)(new BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx()));
			this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
			this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
			this.textFieldUrlOrIp = new MaterialSkin.Controls.MaterialSingleLineTextField();
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
			this.listViewPaths.Location = new System.Drawing.Point(10, 106);
			this.listViewPaths.MouseLocation = new System.Drawing.Point(-1, -1);
			this.listViewPaths.MouseState = MaterialSkin.MouseState.OUT;
			this.listViewPaths.Name = "listViewPaths";
			this.listViewPaths.OwnerDraw = true;
			this.listViewPaths.Size = new System.Drawing.Size(690, 225);
			this.listViewPaths.TabIndex = 6;
			this.listViewPaths.UseCompatibleStateImageBehavior = false;
			this.listViewPaths.View = System.Windows.Forms.View.Details;
			// 
			// columnHeaderPathAndQuery
			// 
			this.columnHeaderPathAndQuery.Tag = "";
			this.columnHeaderPathAndQuery.Text = "Path";
			this.columnHeaderPathAndQuery.Weigth = 2;
			this.columnHeaderPathAndQuery.Width = 237;
			// 
			// columnHeaderRequested
			// 
			this.columnHeaderRequested.MaximumWidth = 100;
			this.columnHeaderRequested.Tag = "";
			this.columnHeaderRequested.Text = "Requested";
			this.columnHeaderRequested.Width = 101;
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
			this.materialLabel1.Location = new System.Drawing.Point(10, 58);
			this.materialLabel1.Margin = new System.Windows.Forms.Padding(5, 15, 5, 5);
			this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialLabel1.Name = "materialLabel1";
			this.materialLabel1.Size = new System.Drawing.Size(690, 40);
			this.materialLabel1.TabIndex = 5;
			this.materialLabel1.Text = "No Target";
			this.materialLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// materialRaisedButton1
			// 
			this.materialRaisedButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.materialRaisedButton1.AutoSize = true;
			this.materialRaisedButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.materialRaisedButton1.Depth = 0;
			this.materialRaisedButton1.Icon = null;
			this.materialRaisedButton1.Location = new System.Drawing.Point(622, 9);
			this.materialRaisedButton1.Margin = new System.Windows.Forms.Padding(3, 9, 5, 3);
			this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialRaisedButton1.Name = "materialRaisedButton1";
			this.materialRaisedButton1.Primary = true;
			this.materialRaisedButton1.Size = new System.Drawing.Size(78, 36);
			this.materialRaisedButton1.TabIndex = 4;
			this.materialRaisedButton1.Text = "Lock on";
			this.materialRaisedButton1.UseVisualStyleBackColor = true;
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
			this.textFieldUrlOrIp.Size = new System.Drawing.Size(594, 23);
			this.textFieldUrlOrIp.TabIndex = 0;
			this.textFieldUrlOrIp.TabStop = false;
			this.textFieldUrlOrIp.UseSystemPasswordChar = false;
			// 
			// TargetControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Controls.Add(this.listViewPaths);
			this.Controls.Add(this.materialLabel1);
			this.Controls.Add(this.materialRaisedButton1);
			this.Controls.Add(this.textFieldUrlOrIp);
			this.Name = "TargetControl";
			this.Size = new System.Drawing.Size(705, 334);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
		private MaterialSkin.Controls.MaterialLabel materialLabel1;
		private Components.ColumnHeaderEx columnHeaderPathAndQuery;
		private Components.ColumnHeaderEx columnHeaderRequested;
		private Components.ColumnHeaderEx columnHeaderFailed;
		public MaterialSkin.Controls.MaterialSingleLineTextField textFieldUrlOrIp;
		public MaterialSkin.Controls.MaterialListView listViewPaths;
	}
}
