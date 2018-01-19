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
			this.materialListViewPaths = new MaterialSkin.Controls.MaterialListView();
			this.columnHeaderPathAndQuery = ((BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx)(new BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx()));
			this.columnHeaderRequested = ((BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx)(new BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx()));
			this.columnHeaderFailed = ((BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx)(new BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx()));
			this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
			this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
			this.materialSingleLineTextFieldUrlOrIp = new MaterialSkin.Controls.MaterialSingleLineTextField();
			this.SuspendLayout();
			// 
			// materialListViewPaths
			// 
			this.materialListViewPaths.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.materialListViewPaths.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.materialListViewPaths.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderPathAndQuery,
            this.columnHeaderRequested,
            this.columnHeaderFailed});
			this.materialListViewPaths.Depth = 0;
			this.materialListViewPaths.Font = new System.Drawing.Font("Roboto", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.materialListViewPaths.FullRowSelect = true;
			this.materialListViewPaths.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.materialListViewPaths.Location = new System.Drawing.Point(10, 106);
			this.materialListViewPaths.MouseLocation = new System.Drawing.Point(-1, -1);
			this.materialListViewPaths.MouseState = MaterialSkin.MouseState.OUT;
			this.materialListViewPaths.Name = "materialListViewPaths";
			this.materialListViewPaths.OwnerDraw = true;
			this.materialListViewPaths.Size = new System.Drawing.Size(690, 225);
			this.materialListViewPaths.TabIndex = 6;
			this.materialListViewPaths.UseCompatibleStateImageBehavior = false;
			this.materialListViewPaths.View = System.Windows.Forms.View.Details;
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
			// materialSingleLineTextFieldUrlOrIp
			// 
			this.materialSingleLineTextFieldUrlOrIp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.materialSingleLineTextFieldUrlOrIp.Depth = 0;
			this.materialSingleLineTextFieldUrlOrIp.Hint = "URL or IP address";
			this.materialSingleLineTextFieldUrlOrIp.Location = new System.Drawing.Point(10, 15);
			this.materialSingleLineTextFieldUrlOrIp.Margin = new System.Windows.Forms.Padding(10, 15, 15, 5);
			this.materialSingleLineTextFieldUrlOrIp.MaxLength = 32767;
			this.materialSingleLineTextFieldUrlOrIp.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialSingleLineTextFieldUrlOrIp.Name = "materialSingleLineTextFieldUrlOrIp";
			this.materialSingleLineTextFieldUrlOrIp.PasswordChar = '\0';
			this.materialSingleLineTextFieldUrlOrIp.SelectedText = "";
			this.materialSingleLineTextFieldUrlOrIp.SelectionLength = 0;
			this.materialSingleLineTextFieldUrlOrIp.SelectionStart = 0;
			this.materialSingleLineTextFieldUrlOrIp.Size = new System.Drawing.Size(594, 23);
			this.materialSingleLineTextFieldUrlOrIp.TabIndex = 0;
			this.materialSingleLineTextFieldUrlOrIp.TabStop = false;
			this.materialSingleLineTextFieldUrlOrIp.UseSystemPasswordChar = false;
			// 
			// TargetControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Controls.Add(this.materialListViewPaths);
			this.Controls.Add(this.materialLabel1);
			this.Controls.Add(this.materialRaisedButton1);
			this.Controls.Add(this.materialSingleLineTextFieldUrlOrIp);
			this.Name = "TargetControl";
			this.Size = new System.Drawing.Size(705, 334);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextFieldUrlOrIp;
		private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
		private MaterialSkin.Controls.MaterialLabel materialLabel1;
		private MaterialSkin.Controls.MaterialListView materialListViewPaths;
		private Components.ColumnHeaderEx columnHeaderPathAndQuery;
		private Components.ColumnHeaderEx columnHeaderRequested;
		private Components.ColumnHeaderEx columnHeaderFailed;
	}
}
