﻿namespace BeanCannon.Presentation.MaterializedDesktopUI.Controls
{
	partial class WorkersControl
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
			this.listViewWorkers = new BeanCannon.Presentation.MaterializedDesktopUI.Controls.Common.MaterialListViewEx();
			this.columnHeaderName = ((BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx)(new BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx()));
			this.columnHeaderState = ((BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx)(new BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx()));
			this.columnHeaderRequested = ((BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx)(new BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx()));
			this.columnHeaderDownloaded = ((BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx)(new BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx()));
			this.columnHeaderFailed = ((BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx)(new BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx()));
			this.columnHeaderElapsed = ((BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx)(new BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx()));
			this.columnHeaderResponsiveness = ((BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx)(new BeanCannon.Presentation.MaterializedDesktopUI.Components.ColumnHeaderEx()));
			this.SuspendLayout();
			// 
			// listViewWorkers
			// 
			this.listViewWorkers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewWorkers.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listViewWorkers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderState,
            this.columnHeaderRequested,
            this.columnHeaderDownloaded,
            this.columnHeaderFailed,
            this.columnHeaderElapsed,
            this.columnHeaderResponsiveness});
			this.listViewWorkers.Depth = 0;
			this.listViewWorkers.Font = new System.Drawing.Font("Roboto", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.listViewWorkers.FullRowSelect = true;
			this.listViewWorkers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewWorkers.Location = new System.Drawing.Point(3, 3);
			this.listViewWorkers.MouseLocation = new System.Drawing.Point(-1, -1);
			this.listViewWorkers.MouseState = MaterialSkin.MouseState.OUT;
			this.listViewWorkers.Name = "listViewWorkers";
			this.listViewWorkers.OwnerDraw = true;
			this.listViewWorkers.Size = new System.Drawing.Size(998, 290);
			this.listViewWorkers.TabIndex = 0;
			this.listViewWorkers.UseCompatibleStateImageBehavior = false;
			this.listViewWorkers.View = System.Windows.Forms.View.Details;
			// 
			// columnHeaderName
			// 
			this.columnHeaderName.MaximumWidth = 75;
			this.columnHeaderName.Text = "Name";
			this.columnHeaderName.Width = 106;
			// 
			// columnHeaderState
			// 
			this.columnHeaderState.Text = "State";
			this.columnHeaderState.Width = 105;
			// 
			// columnHeaderRequested
			// 
			this.columnHeaderRequested.MaximumWidth = 125;
			this.columnHeaderRequested.Text = "Requested";
			this.columnHeaderRequested.Width = 169;
			// 
			// columnHeaderDownloaded
			// 
			this.columnHeaderDownloaded.MaximumWidth = 125;
			this.columnHeaderDownloaded.Text = "Downloaded";
			this.columnHeaderDownloaded.Width = 204;
			// 
			// columnHeaderFailed
			// 
			this.columnHeaderFailed.MaximumWidth = 125;
			this.columnHeaderFailed.Text = "Failed";
			this.columnHeaderFailed.Width = 112;
			// 
			// columnHeaderElapsed
			// 
			this.columnHeaderElapsed.MaximumWidth = 125;
			this.columnHeaderElapsed.Text = "Elapsed";
			this.columnHeaderElapsed.Width = 130;
			// 
			// columnHeaderResponsiveness
			// 
			this.columnHeaderResponsiveness.Text = "";
			this.columnHeaderResponsiveness.Width = 142;
			// 
			// WorkersControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.listViewWorkers);
			this.Name = "WorkersControl";
			this.Size = new System.Drawing.Size(1004, 296);
			this.ResumeLayout(false);

		}

		#endregion
		private Components.ColumnHeaderEx columnHeaderName;
		private Components.ColumnHeaderEx columnHeaderState;
		private Components.ColumnHeaderEx columnHeaderRequested;
		private Components.ColumnHeaderEx columnHeaderDownloaded;
		private Components.ColumnHeaderEx columnHeaderFailed;
		private Components.ColumnHeaderEx columnHeaderElapsed;
		private Components.ColumnHeaderEx columnHeaderResponsiveness;
		public Common.MaterialListViewEx listViewWorkers;
	}
}
