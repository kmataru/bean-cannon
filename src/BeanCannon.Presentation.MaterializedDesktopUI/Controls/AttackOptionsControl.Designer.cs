namespace BeanCannon.Presentation.MaterializedDesktopUI.Controls
{
	partial class AttackOptionsControl
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
			this.textFieldTimeout = new MaterialSkin.Controls.MaterialSingleLineTextField();
			this.textFieldPort = new MaterialSkin.Controls.MaterialSingleLineTextField();
			this.textFieldThreads = new MaterialSkin.Controls.MaterialSingleLineTextField();
			this.textFieldSocketsPerThread = new MaterialSkin.Controls.MaterialSingleLineTextField();
			this.radioButtonHttpMethodGet = new MaterialSkin.Controls.MaterialRadioButton();
			this.radioButtonHttpMethodPost = new MaterialSkin.Controls.MaterialRadioButton();
			this.radioButtonHttpMethodHead = new MaterialSkin.Controls.MaterialRadioButton();
			this.panelHttpMethod = new System.Windows.Forms.Panel();
			this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.radioButtonAttackMethodIcmp = new MaterialSkin.Controls.MaterialRadioButton();
			this.radioButtonAttackMethodSlowLoic = new MaterialSkin.Controls.MaterialRadioButton();
			this.radioButtonAttackMethodReCoil = new MaterialSkin.Controls.MaterialRadioButton();
			this.radioButtonAttackMethodHttp = new MaterialSkin.Controls.MaterialRadioButton();
			this.radioButtonAttackMethodTcp = new MaterialSkin.Controls.MaterialRadioButton();
			this.radioButtonAttackMethodUdp = new MaterialSkin.Controls.MaterialRadioButton();
			this.panelGenericInputs = new System.Windows.Forms.Panel();
			this.panelRandomness = new System.Windows.Forms.Panel();
			this.checkBoxUseRandomHeaderCommands = new MaterialSkin.Controls.MaterialCheckBox();
			this.checkBoxUseRandomReferer = new MaterialSkin.Controls.MaterialCheckBox();
			this.checkBoxUseRandomUserAgent = new MaterialSkin.Controls.MaterialCheckBox();
			this.checkBoxAppendRandomCharactersToUrl = new MaterialSkin.Controls.MaterialCheckBox();
			this.checkBoxAppendRandomCharactersToMessage = new MaterialSkin.Controls.MaterialCheckBox();
			this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
			this.panel8 = new System.Windows.Forms.Panel();
			this.panel9 = new System.Windows.Forms.Panel();
			this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
			this.panelGenericButtons = new System.Windows.Forms.Panel();
			this.checkBoxWaitForReply = new MaterialSkin.Controls.MaterialCheckBox();
			this.checkBoxUseGzip = new MaterialSkin.Controls.MaterialCheckBox();
			this.panel5 = new System.Windows.Forms.Panel();
			this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
			this.panel11 = new System.Windows.Forms.Panel();
			this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
			this.panelProxy = new System.Windows.Forms.Panel();
			this.radioButtonProxyChained = new MaterialSkin.Controls.MaterialRadioButton();
			this.radioButtonProxyRandom = new MaterialSkin.Controls.MaterialRadioButton();
			this.radioButtonProxyNone = new MaterialSkin.Controls.MaterialRadioButton();
			this.panelHttpMethod.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panelGenericInputs.SuspendLayout();
			this.panelRandomness.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel9.SuspendLayout();
			this.panelGenericButtons.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel11.SuspendLayout();
			this.panelProxy.SuspendLayout();
			this.SuspendLayout();
			// 
			// textFieldTimeout
			// 
			this.textFieldTimeout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textFieldTimeout.Depth = 0;
			this.textFieldTimeout.Hint = "Timeout";
			this.textFieldTimeout.Location = new System.Drawing.Point(0, 0);
			this.textFieldTimeout.MaxLength = 32767;
			this.textFieldTimeout.MouseState = MaterialSkin.MouseState.HOVER;
			this.textFieldTimeout.Name = "textFieldTimeout";
			this.textFieldTimeout.PasswordChar = '\0';
			this.textFieldTimeout.SelectedText = "";
			this.textFieldTimeout.SelectionLength = 0;
			this.textFieldTimeout.SelectionStart = 0;
			this.textFieldTimeout.Size = new System.Drawing.Size(136, 23);
			this.textFieldTimeout.TabIndex = 0;
			this.textFieldTimeout.TabStop = false;
			this.textFieldTimeout.Text = "30";
			this.textFieldTimeout.UseSystemPasswordChar = false;
			// 
			// textFieldPort
			// 
			this.textFieldPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textFieldPort.Depth = 0;
			this.textFieldPort.Hint = "Port";
			this.textFieldPort.Location = new System.Drawing.Point(0, 30);
			this.textFieldPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
			this.textFieldPort.MaxLength = 32767;
			this.textFieldPort.MouseState = MaterialSkin.MouseState.HOVER;
			this.textFieldPort.Name = "textFieldPort";
			this.textFieldPort.PasswordChar = '\0';
			this.textFieldPort.SelectedText = "";
			this.textFieldPort.SelectionLength = 0;
			this.textFieldPort.SelectionStart = 0;
			this.textFieldPort.Size = new System.Drawing.Size(136, 23);
			this.textFieldPort.TabIndex = 1;
			this.textFieldPort.TabStop = false;
			this.textFieldPort.Text = "80";
			this.textFieldPort.UseSystemPasswordChar = false;
			// 
			// textFieldThreads
			// 
			this.textFieldThreads.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textFieldThreads.Depth = 0;
			this.textFieldThreads.Hint = "Threads";
			this.textFieldThreads.Location = new System.Drawing.Point(0, 60);
			this.textFieldThreads.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
			this.textFieldThreads.MaxLength = 32767;
			this.textFieldThreads.MouseState = MaterialSkin.MouseState.HOVER;
			this.textFieldThreads.Name = "textFieldThreads";
			this.textFieldThreads.PasswordChar = '\0';
			this.textFieldThreads.SelectedText = "";
			this.textFieldThreads.SelectionLength = 0;
			this.textFieldThreads.SelectionStart = 0;
			this.textFieldThreads.Size = new System.Drawing.Size(136, 23);
			this.textFieldThreads.TabIndex = 2;
			this.textFieldThreads.TabStop = false;
			this.textFieldThreads.Text = "10";
			this.textFieldThreads.UseSystemPasswordChar = false;
			// 
			// textFieldSocketsPerThread
			// 
			this.textFieldSocketsPerThread.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textFieldSocketsPerThread.Depth = 0;
			this.textFieldSocketsPerThread.Hint = "Sockets / Thread";
			this.textFieldSocketsPerThread.Location = new System.Drawing.Point(0, 90);
			this.textFieldSocketsPerThread.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
			this.textFieldSocketsPerThread.MaxLength = 32767;
			this.textFieldSocketsPerThread.MouseState = MaterialSkin.MouseState.HOVER;
			this.textFieldSocketsPerThread.Name = "textFieldSocketsPerThread";
			this.textFieldSocketsPerThread.PasswordChar = '\0';
			this.textFieldSocketsPerThread.SelectedText = "";
			this.textFieldSocketsPerThread.SelectionLength = 0;
			this.textFieldSocketsPerThread.SelectionStart = 0;
			this.textFieldSocketsPerThread.Size = new System.Drawing.Size(136, 23);
			this.textFieldSocketsPerThread.TabIndex = 3;
			this.textFieldSocketsPerThread.TabStop = false;
			this.textFieldSocketsPerThread.Text = "15";
			this.textFieldSocketsPerThread.UseSystemPasswordChar = false;
			// 
			// radioButtonHttpMethodGet
			// 
			this.radioButtonHttpMethodGet.AutoSize = true;
			this.radioButtonHttpMethodGet.Cursor = System.Windows.Forms.Cursors.Default;
			this.radioButtonHttpMethodGet.Depth = 0;
			this.radioButtonHttpMethodGet.Font = new System.Drawing.Font("Roboto", 10F);
			this.radioButtonHttpMethodGet.Location = new System.Drawing.Point(75, 0);
			this.radioButtonHttpMethodGet.Margin = new System.Windows.Forms.Padding(0);
			this.radioButtonHttpMethodGet.MouseLocation = new System.Drawing.Point(-1, -1);
			this.radioButtonHttpMethodGet.MouseState = MaterialSkin.MouseState.HOVER;
			this.radioButtonHttpMethodGet.Name = "radioButtonHttpMethodGet";
			this.radioButtonHttpMethodGet.Ripple = true;
			this.radioButtonHttpMethodGet.Size = new System.Drawing.Size(54, 30);
			this.radioButtonHttpMethodGet.TabIndex = 10;
			this.radioButtonHttpMethodGet.Text = "GET";
			this.radioButtonHttpMethodGet.UseVisualStyleBackColor = true;
			// 
			// radioButtonHttpMethodPost
			// 
			this.radioButtonHttpMethodPost.AutoSize = true;
			this.radioButtonHttpMethodPost.Cursor = System.Windows.Forms.Cursors.Default;
			this.radioButtonHttpMethodPost.Depth = 0;
			this.radioButtonHttpMethodPost.Font = new System.Drawing.Font("Roboto", 10F);
			this.radioButtonHttpMethodPost.Location = new System.Drawing.Point(139, 0);
			this.radioButtonHttpMethodPost.Margin = new System.Windows.Forms.Padding(0);
			this.radioButtonHttpMethodPost.MouseLocation = new System.Drawing.Point(-1, -1);
			this.radioButtonHttpMethodPost.MouseState = MaterialSkin.MouseState.HOVER;
			this.radioButtonHttpMethodPost.Name = "radioButtonHttpMethodPost";
			this.radioButtonHttpMethodPost.Ripple = true;
			this.radioButtonHttpMethodPost.Size = new System.Drawing.Size(64, 30);
			this.radioButtonHttpMethodPost.TabIndex = 11;
			this.radioButtonHttpMethodPost.Text = "POST";
			this.radioButtonHttpMethodPost.UseVisualStyleBackColor = true;
			// 
			// radioButtonHttpMethodHead
			// 
			this.radioButtonHttpMethodHead.AutoSize = true;
			this.radioButtonHttpMethodHead.Checked = true;
			this.radioButtonHttpMethodHead.Cursor = System.Windows.Forms.Cursors.Default;
			this.radioButtonHttpMethodHead.Depth = 0;
			this.radioButtonHttpMethodHead.Font = new System.Drawing.Font("Roboto", 10F);
			this.radioButtonHttpMethodHead.Location = new System.Drawing.Point(0, 0);
			this.radioButtonHttpMethodHead.Margin = new System.Windows.Forms.Padding(0);
			this.radioButtonHttpMethodHead.MouseLocation = new System.Drawing.Point(-1, -1);
			this.radioButtonHttpMethodHead.MouseState = MaterialSkin.MouseState.HOVER;
			this.radioButtonHttpMethodHead.Name = "radioButtonHttpMethodHead";
			this.radioButtonHttpMethodHead.Ripple = true;
			this.radioButtonHttpMethodHead.Size = new System.Drawing.Size(65, 30);
			this.radioButtonHttpMethodHead.TabIndex = 12;
			this.radioButtonHttpMethodHead.TabStop = true;
			this.radioButtonHttpMethodHead.Text = "HEAD";
			this.radioButtonHttpMethodHead.UseVisualStyleBackColor = true;
			// 
			// panelHttpMethod
			// 
			this.panelHttpMethod.Controls.Add(this.radioButtonHttpMethodHead);
			this.panelHttpMethod.Controls.Add(this.radioButtonHttpMethodGet);
			this.panelHttpMethod.Controls.Add(this.radioButtonHttpMethodPost);
			this.panelHttpMethod.Location = new System.Drawing.Point(114, 0);
			this.panelHttpMethod.Name = "panelHttpMethod";
			this.panelHttpMethod.Size = new System.Drawing.Size(471, 30);
			this.panelHttpMethod.TabIndex = 14;
			// 
			// materialLabel1
			// 
			this.materialLabel1.AutoSize = true;
			this.materialLabel1.Depth = 0;
			this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
			this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.materialLabel1.Location = new System.Drawing.Point(6, 5);
			this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialLabel1.Name = "materialLabel1";
			this.materialLabel1.Size = new System.Drawing.Size(102, 19);
			this.materialLabel1.TabIndex = 15;
			this.materialLabel1.Text = "HTTP method";
			this.materialLabel1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.materialLabel1);
			this.panel2.Controls.Add(this.panelHttpMethod);
			this.panel2.Location = new System.Drawing.Point(3, 46);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(624, 30);
			this.panel2.TabIndex = 16;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.materialLabel2);
			this.panel3.Controls.Add(this.panel4);
			this.panel3.Location = new System.Drawing.Point(3, 10);
			this.panel3.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(624, 30);
			this.panel3.TabIndex = 17;
			// 
			// materialLabel2
			// 
			this.materialLabel2.AutoSize = true;
			this.materialLabel2.Depth = 0;
			this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
			this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.materialLabel2.Location = new System.Drawing.Point(0, 5);
			this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialLabel2.Name = "materialLabel2";
			this.materialLabel2.Size = new System.Drawing.Size(108, 19);
			this.materialLabel2.TabIndex = 15;
			this.materialLabel2.Text = "Attack method";
			this.materialLabel2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.radioButtonAttackMethodIcmp);
			this.panel4.Controls.Add(this.radioButtonAttackMethodSlowLoic);
			this.panel4.Controls.Add(this.radioButtonAttackMethodReCoil);
			this.panel4.Controls.Add(this.radioButtonAttackMethodHttp);
			this.panel4.Controls.Add(this.radioButtonAttackMethodTcp);
			this.panel4.Controls.Add(this.radioButtonAttackMethodUdp);
			this.panel4.Location = new System.Drawing.Point(114, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(471, 30);
			this.panel4.TabIndex = 14;
			// 
			// radioButtonAttackMethodIcmp
			// 
			this.radioButtonAttackMethodIcmp.AutoSize = true;
			this.radioButtonAttackMethodIcmp.Cursor = System.Windows.Forms.Cursors.Default;
			this.radioButtonAttackMethodIcmp.Depth = 0;
			this.radioButtonAttackMethodIcmp.Font = new System.Drawing.Font("Roboto", 10F);
			this.radioButtonAttackMethodIcmp.Location = new System.Drawing.Point(383, 0);
			this.radioButtonAttackMethodIcmp.Margin = new System.Windows.Forms.Padding(0);
			this.radioButtonAttackMethodIcmp.MouseLocation = new System.Drawing.Point(-1, -1);
			this.radioButtonAttackMethodIcmp.MouseState = MaterialSkin.MouseState.HOVER;
			this.radioButtonAttackMethodIcmp.Name = "radioButtonAttackMethodIcmp";
			this.radioButtonAttackMethodIcmp.Ripple = true;
			this.radioButtonAttackMethodIcmp.Size = new System.Drawing.Size(63, 30);
			this.radioButtonAttackMethodIcmp.TabIndex = 16;
			this.radioButtonAttackMethodIcmp.Text = "ICMP";
			this.radioButtonAttackMethodIcmp.UseVisualStyleBackColor = true;
			this.radioButtonAttackMethodIcmp.CheckedChanged += new System.EventHandler(this.materialRadioButtonAttackMethodIcmp_CheckedChanged);
			// 
			// radioButtonAttackMethodSlowLoic
			// 
			this.radioButtonAttackMethodSlowLoic.AutoSize = true;
			this.radioButtonAttackMethodSlowLoic.Cursor = System.Windows.Forms.Cursors.Default;
			this.radioButtonAttackMethodSlowLoic.Depth = 0;
			this.radioButtonAttackMethodSlowLoic.Font = new System.Drawing.Font("Roboto", 10F);
			this.radioButtonAttackMethodSlowLoic.Location = new System.Drawing.Point(284, 0);
			this.radioButtonAttackMethodSlowLoic.Margin = new System.Windows.Forms.Padding(0);
			this.radioButtonAttackMethodSlowLoic.MouseLocation = new System.Drawing.Point(-1, -1);
			this.radioButtonAttackMethodSlowLoic.MouseState = MaterialSkin.MouseState.HOVER;
			this.radioButtonAttackMethodSlowLoic.Name = "radioButtonAttackMethodSlowLoic";
			this.radioButtonAttackMethodSlowLoic.Ripple = true;
			this.radioButtonAttackMethodSlowLoic.Size = new System.Drawing.Size(89, 30);
			this.radioButtonAttackMethodSlowLoic.TabIndex = 15;
			this.radioButtonAttackMethodSlowLoic.Text = "SlowLOIC";
			this.radioButtonAttackMethodSlowLoic.UseVisualStyleBackColor = true;
			this.radioButtonAttackMethodSlowLoic.CheckedChanged += new System.EventHandler(this.materialRadioButtonAttackMethodSlowLoic_CheckedChanged);
			// 
			// radioButtonAttackMethodReCoil
			// 
			this.radioButtonAttackMethodReCoil.AutoSize = true;
			this.radioButtonAttackMethodReCoil.Cursor = System.Windows.Forms.Cursors.Default;
			this.radioButtonAttackMethodReCoil.Depth = 0;
			this.radioButtonAttackMethodReCoil.Font = new System.Drawing.Font("Roboto", 10F);
			this.radioButtonAttackMethodReCoil.Location = new System.Drawing.Point(205, 0);
			this.radioButtonAttackMethodReCoil.Margin = new System.Windows.Forms.Padding(0);
			this.radioButtonAttackMethodReCoil.MouseLocation = new System.Drawing.Point(-1, -1);
			this.radioButtonAttackMethodReCoil.MouseState = MaterialSkin.MouseState.HOVER;
			this.radioButtonAttackMethodReCoil.Name = "radioButtonAttackMethodReCoil";
			this.radioButtonAttackMethodReCoil.Ripple = true;
			this.radioButtonAttackMethodReCoil.Size = new System.Drawing.Size(69, 30);
			this.radioButtonAttackMethodReCoil.TabIndex = 13;
			this.radioButtonAttackMethodReCoil.Text = "ReCoil";
			this.radioButtonAttackMethodReCoil.UseVisualStyleBackColor = true;
			this.radioButtonAttackMethodReCoil.CheckedChanged += new System.EventHandler(this.materialRadioButtonAttackMethodReCoil_CheckedChanged);
			// 
			// radioButtonAttackMethodHttp
			// 
			this.radioButtonAttackMethodHttp.AutoSize = true;
			this.radioButtonAttackMethodHttp.Checked = true;
			this.radioButtonAttackMethodHttp.Cursor = System.Windows.Forms.Cursors.Default;
			this.radioButtonAttackMethodHttp.Depth = 0;
			this.radioButtonAttackMethodHttp.Font = new System.Drawing.Font("Roboto", 10F);
			this.radioButtonAttackMethodHttp.Location = new System.Drawing.Point(0, 0);
			this.radioButtonAttackMethodHttp.Margin = new System.Windows.Forms.Padding(0);
			this.radioButtonAttackMethodHttp.MouseLocation = new System.Drawing.Point(-1, -1);
			this.radioButtonAttackMethodHttp.MouseState = MaterialSkin.MouseState.HOVER;
			this.radioButtonAttackMethodHttp.Name = "radioButtonAttackMethodHttp";
			this.radioButtonAttackMethodHttp.Ripple = true;
			this.radioButtonAttackMethodHttp.Size = new System.Drawing.Size(64, 30);
			this.radioButtonAttackMethodHttp.TabIndex = 12;
			this.radioButtonAttackMethodHttp.TabStop = true;
			this.radioButtonAttackMethodHttp.Text = "HTTP";
			this.radioButtonAttackMethodHttp.UseVisualStyleBackColor = true;
			this.radioButtonAttackMethodHttp.CheckedChanged += new System.EventHandler(this.materialRadioButtonAttackMethodHttp_CheckedChanged);
			// 
			// radioButtonAttackMethodTcp
			// 
			this.radioButtonAttackMethodTcp.AutoSize = true;
			this.radioButtonAttackMethodTcp.Cursor = System.Windows.Forms.Cursors.Default;
			this.radioButtonAttackMethodTcp.Depth = 0;
			this.radioButtonAttackMethodTcp.Font = new System.Drawing.Font("Roboto", 10F);
			this.radioButtonAttackMethodTcp.Location = new System.Drawing.Point(74, 0);
			this.radioButtonAttackMethodTcp.Margin = new System.Windows.Forms.Padding(0);
			this.radioButtonAttackMethodTcp.MouseLocation = new System.Drawing.Point(-1, -1);
			this.radioButtonAttackMethodTcp.MouseState = MaterialSkin.MouseState.HOVER;
			this.radioButtonAttackMethodTcp.Name = "radioButtonAttackMethodTcp";
			this.radioButtonAttackMethodTcp.Ripple = true;
			this.radioButtonAttackMethodTcp.Size = new System.Drawing.Size(55, 30);
			this.radioButtonAttackMethodTcp.TabIndex = 10;
			this.radioButtonAttackMethodTcp.Text = "TCP";
			this.radioButtonAttackMethodTcp.UseVisualStyleBackColor = true;
			this.radioButtonAttackMethodTcp.CheckedChanged += new System.EventHandler(this.materialRadioButtonAttackMethodTcp_CheckedChanged);
			// 
			// radioButtonAttackMethodUdp
			// 
			this.radioButtonAttackMethodUdp.AutoSize = true;
			this.radioButtonAttackMethodUdp.Cursor = System.Windows.Forms.Cursors.Default;
			this.radioButtonAttackMethodUdp.Depth = 0;
			this.radioButtonAttackMethodUdp.Font = new System.Drawing.Font("Roboto", 10F);
			this.radioButtonAttackMethodUdp.Location = new System.Drawing.Point(139, 0);
			this.radioButtonAttackMethodUdp.Margin = new System.Windows.Forms.Padding(0);
			this.radioButtonAttackMethodUdp.MouseLocation = new System.Drawing.Point(-1, -1);
			this.radioButtonAttackMethodUdp.MouseState = MaterialSkin.MouseState.HOVER;
			this.radioButtonAttackMethodUdp.Name = "radioButtonAttackMethodUdp";
			this.radioButtonAttackMethodUdp.Ripple = true;
			this.radioButtonAttackMethodUdp.Size = new System.Drawing.Size(56, 30);
			this.radioButtonAttackMethodUdp.TabIndex = 11;
			this.radioButtonAttackMethodUdp.Text = "UDP";
			this.radioButtonAttackMethodUdp.UseVisualStyleBackColor = true;
			this.radioButtonAttackMethodUdp.CheckedChanged += new System.EventHandler(this.materialRadioButtonAttackMethodUdp_CheckedChanged);
			// 
			// panelGenericInputs
			// 
			this.panelGenericInputs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelGenericInputs.Controls.Add(this.textFieldTimeout);
			this.panelGenericInputs.Controls.Add(this.textFieldPort);
			this.panelGenericInputs.Controls.Add(this.textFieldThreads);
			this.panelGenericInputs.Controls.Add(this.textFieldSocketsPerThread);
			this.panelGenericInputs.Location = new System.Drawing.Point(7, 33);
			this.panelGenericInputs.Margin = new System.Windows.Forms.Padding(7, 10, 7, 3);
			this.panelGenericInputs.MinimumSize = new System.Drawing.Size(125, 140);
			this.panelGenericInputs.Name = "panelGenericInputs";
			this.panelGenericInputs.Size = new System.Drawing.Size(136, 201);
			this.panelGenericInputs.TabIndex = 19;
			// 
			// panelRandomness
			// 
			this.panelRandomness.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelRandomness.Controls.Add(this.checkBoxUseRandomHeaderCommands);
			this.panelRandomness.Controls.Add(this.checkBoxUseRandomReferer);
			this.panelRandomness.Controls.Add(this.checkBoxUseRandomUserAgent);
			this.panelRandomness.Controls.Add(this.checkBoxAppendRandomCharactersToUrl);
			this.panelRandomness.Controls.Add(this.checkBoxAppendRandomCharactersToMessage);
			this.panelRandomness.Location = new System.Drawing.Point(0, 29);
			this.panelRandomness.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
			this.panelRandomness.MinimumSize = new System.Drawing.Size(245, 120);
			this.panelRandomness.Name = "panelRandomness";
			this.panelRandomness.Size = new System.Drawing.Size(245, 205);
			this.panelRandomness.TabIndex = 20;
			// 
			// checkBoxUseRandomHeaderCommands
			// 
			this.checkBoxUseRandomHeaderCommands.AutoSize = true;
			this.checkBoxUseRandomHeaderCommands.Checked = true;
			this.checkBoxUseRandomHeaderCommands.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxUseRandomHeaderCommands.Cursor = System.Windows.Forms.Cursors.Default;
			this.checkBoxUseRandomHeaderCommands.Depth = 0;
			this.checkBoxUseRandomHeaderCommands.Font = new System.Drawing.Font("Roboto", 10F);
			this.checkBoxUseRandomHeaderCommands.Location = new System.Drawing.Point(0, 60);
			this.checkBoxUseRandomHeaderCommands.Margin = new System.Windows.Forms.Padding(0);
			this.checkBoxUseRandomHeaderCommands.MouseLocation = new System.Drawing.Point(-1, -1);
			this.checkBoxUseRandomHeaderCommands.MouseState = MaterialSkin.MouseState.HOVER;
			this.checkBoxUseRandomHeaderCommands.Name = "checkBoxUseRandomHeaderCommands";
			this.checkBoxUseRandomHeaderCommands.Ripple = true;
			this.checkBoxUseRandomHeaderCommands.Size = new System.Drawing.Size(147, 30);
			this.checkBoxUseRandomHeaderCommands.TabIndex = 12;
			this.checkBoxUseRandomHeaderCommands.Text = "Header commands";
			this.checkBoxUseRandomHeaderCommands.UseVisualStyleBackColor = true;
			// 
			// checkBoxUseRandomReferer
			// 
			this.checkBoxUseRandomReferer.AutoSize = true;
			this.checkBoxUseRandomReferer.Checked = true;
			this.checkBoxUseRandomReferer.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxUseRandomReferer.Cursor = System.Windows.Forms.Cursors.Default;
			this.checkBoxUseRandomReferer.Depth = 0;
			this.checkBoxUseRandomReferer.Font = new System.Drawing.Font("Roboto", 10F);
			this.checkBoxUseRandomReferer.Location = new System.Drawing.Point(0, 120);
			this.checkBoxUseRandomReferer.Margin = new System.Windows.Forms.Padding(0);
			this.checkBoxUseRandomReferer.MouseLocation = new System.Drawing.Point(-1, -1);
			this.checkBoxUseRandomReferer.MouseState = MaterialSkin.MouseState.HOVER;
			this.checkBoxUseRandomReferer.Name = "checkBoxUseRandomReferer";
			this.checkBoxUseRandomReferer.Ripple = true;
			this.checkBoxUseRandomReferer.Size = new System.Drawing.Size(75, 30);
			this.checkBoxUseRandomReferer.TabIndex = 11;
			this.checkBoxUseRandomReferer.Text = "Referer";
			this.checkBoxUseRandomReferer.UseVisualStyleBackColor = true;
			// 
			// checkBoxUseRandomUserAgent
			// 
			this.checkBoxUseRandomUserAgent.AutoSize = true;
			this.checkBoxUseRandomUserAgent.Checked = true;
			this.checkBoxUseRandomUserAgent.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxUseRandomUserAgent.Cursor = System.Windows.Forms.Cursors.Default;
			this.checkBoxUseRandomUserAgent.Depth = 0;
			this.checkBoxUseRandomUserAgent.Font = new System.Drawing.Font("Roboto", 10F);
			this.checkBoxUseRandomUserAgent.Location = new System.Drawing.Point(0, 90);
			this.checkBoxUseRandomUserAgent.Margin = new System.Windows.Forms.Padding(0);
			this.checkBoxUseRandomUserAgent.MouseLocation = new System.Drawing.Point(-1, -1);
			this.checkBoxUseRandomUserAgent.MouseState = MaterialSkin.MouseState.HOVER;
			this.checkBoxUseRandomUserAgent.Name = "checkBoxUseRandomUserAgent";
			this.checkBoxUseRandomUserAgent.Ripple = true;
			this.checkBoxUseRandomUserAgent.Size = new System.Drawing.Size(96, 30);
			this.checkBoxUseRandomUserAgent.TabIndex = 10;
			this.checkBoxUseRandomUserAgent.Text = "User agent";
			this.checkBoxUseRandomUserAgent.UseVisualStyleBackColor = true;
			// 
			// checkBoxAppendRandomCharactersToUrl
			// 
			this.checkBoxAppendRandomCharactersToUrl.AutoSize = true;
			this.checkBoxAppendRandomCharactersToUrl.Checked = true;
			this.checkBoxAppendRandomCharactersToUrl.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxAppendRandomCharactersToUrl.Cursor = System.Windows.Forms.Cursors.Default;
			this.checkBoxAppendRandomCharactersToUrl.Depth = 0;
			this.checkBoxAppendRandomCharactersToUrl.Font = new System.Drawing.Font("Roboto", 10F);
			this.checkBoxAppendRandomCharactersToUrl.Location = new System.Drawing.Point(0, 0);
			this.checkBoxAppendRandomCharactersToUrl.Margin = new System.Windows.Forms.Padding(0);
			this.checkBoxAppendRandomCharactersToUrl.MouseLocation = new System.Drawing.Point(-1, -1);
			this.checkBoxAppendRandomCharactersToUrl.MouseState = MaterialSkin.MouseState.HOVER;
			this.checkBoxAppendRandomCharactersToUrl.Name = "checkBoxAppendRandomCharactersToUrl";
			this.checkBoxAppendRandomCharactersToUrl.Ripple = true;
			this.checkBoxAppendRandomCharactersToUrl.Size = new System.Drawing.Size(190, 30);
			this.checkBoxAppendRandomCharactersToUrl.TabIndex = 9;
			this.checkBoxAppendRandomCharactersToUrl.Text = "Append characters to URL";
			this.checkBoxAppendRandomCharactersToUrl.UseVisualStyleBackColor = true;
			// 
			// checkBoxAppendRandomCharactersToMessage
			// 
			this.checkBoxAppendRandomCharactersToMessage.AutoSize = true;
			this.checkBoxAppendRandomCharactersToMessage.Checked = true;
			this.checkBoxAppendRandomCharactersToMessage.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxAppendRandomCharactersToMessage.Cursor = System.Windows.Forms.Cursors.Default;
			this.checkBoxAppendRandomCharactersToMessage.Depth = 0;
			this.checkBoxAppendRandomCharactersToMessage.Font = new System.Drawing.Font("Roboto", 10F);
			this.checkBoxAppendRandomCharactersToMessage.Location = new System.Drawing.Point(0, 30);
			this.checkBoxAppendRandomCharactersToMessage.Margin = new System.Windows.Forms.Padding(0);
			this.checkBoxAppendRandomCharactersToMessage.MouseLocation = new System.Drawing.Point(-1, -1);
			this.checkBoxAppendRandomCharactersToMessage.MouseState = MaterialSkin.MouseState.HOVER;
			this.checkBoxAppendRandomCharactersToMessage.Name = "checkBoxAppendRandomCharactersToMessage";
			this.checkBoxAppendRandomCharactersToMessage.Ripple = true;
			this.checkBoxAppendRandomCharactersToMessage.Size = new System.Drawing.Size(222, 30);
			this.checkBoxAppendRandomCharactersToMessage.TabIndex = 8;
			this.checkBoxAppendRandomCharactersToMessage.Text = "Append characters to message";
			this.checkBoxAppendRandomCharactersToMessage.UseVisualStyleBackColor = true;
			// 
			// materialLabel3
			// 
			this.materialLabel3.AutoSize = true;
			this.materialLabel3.Depth = 0;
			this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
			this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.materialLabel3.Location = new System.Drawing.Point(3, 0);
			this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialLabel3.Name = "materialLabel3";
			this.materialLabel3.Size = new System.Drawing.Size(96, 19);
			this.materialLabel3.TabIndex = 21;
			this.materialLabel3.Text = "Randomness";
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.materialLabel3);
			this.panel8.Controls.Add(this.panelRandomness);
			this.panel8.Location = new System.Drawing.Point(290, 94);
			this.panel8.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
			this.panel8.MinimumSize = new System.Drawing.Size(245, 120);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(245, 234);
			this.panel8.TabIndex = 22;
			// 
			// panel9
			// 
			this.panel9.Controls.Add(this.materialLabel4);
			this.panel9.Controls.Add(this.panelGenericButtons);
			this.panel9.Location = new System.Drawing.Point(159, 94);
			this.panel9.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
			this.panel9.MinimumSize = new System.Drawing.Size(125, 100);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(125, 234);
			this.panel9.TabIndex = 23;
			// 
			// materialLabel4
			// 
			this.materialLabel4.AutoSize = true;
			this.materialLabel4.Depth = 0;
			this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
			this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.materialLabel4.Location = new System.Drawing.Point(3, 0);
			this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialLabel4.Name = "materialLabel4";
			this.materialLabel4.Size = new System.Drawing.Size(60, 19);
			this.materialLabel4.TabIndex = 21;
			this.materialLabel4.Text = "Generic";
			// 
			// panelGenericButtons
			// 
			this.panelGenericButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelGenericButtons.Controls.Add(this.checkBoxWaitForReply);
			this.panelGenericButtons.Controls.Add(this.checkBoxUseGzip);
			this.panelGenericButtons.Location = new System.Drawing.Point(0, 29);
			this.panelGenericButtons.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
			this.panelGenericButtons.MinimumSize = new System.Drawing.Size(125, 100);
			this.panelGenericButtons.Name = "panelGenericButtons";
			this.panelGenericButtons.Size = new System.Drawing.Size(125, 205);
			this.panelGenericButtons.TabIndex = 20;
			// 
			// checkBoxWaitForReply
			// 
			this.checkBoxWaitForReply.AutoSize = true;
			this.checkBoxWaitForReply.Cursor = System.Windows.Forms.Cursors.Default;
			this.checkBoxWaitForReply.Depth = 0;
			this.checkBoxWaitForReply.Font = new System.Drawing.Font("Roboto", 10F);
			this.checkBoxWaitForReply.Location = new System.Drawing.Point(0, 0);
			this.checkBoxWaitForReply.Margin = new System.Windows.Forms.Padding(0);
			this.checkBoxWaitForReply.MouseLocation = new System.Drawing.Point(-1, -1);
			this.checkBoxWaitForReply.MouseState = MaterialSkin.MouseState.HOVER;
			this.checkBoxWaitForReply.Name = "checkBoxWaitForReply";
			this.checkBoxWaitForReply.Ripple = true;
			this.checkBoxWaitForReply.Size = new System.Drawing.Size(112, 30);
			this.checkBoxWaitForReply.TabIndex = 10;
			this.checkBoxWaitForReply.Text = "Wait for reply";
			this.checkBoxWaitForReply.UseVisualStyleBackColor = true;
			// 
			// checkBoxUseGzip
			// 
			this.checkBoxUseGzip.AutoSize = true;
			this.checkBoxUseGzip.Checked = true;
			this.checkBoxUseGzip.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxUseGzip.Cursor = System.Windows.Forms.Cursors.Default;
			this.checkBoxUseGzip.Depth = 0;
			this.checkBoxUseGzip.Font = new System.Drawing.Font("Roboto", 10F);
			this.checkBoxUseGzip.Location = new System.Drawing.Point(1, 30);
			this.checkBoxUseGzip.Margin = new System.Windows.Forms.Padding(0);
			this.checkBoxUseGzip.MouseLocation = new System.Drawing.Point(-1, -1);
			this.checkBoxUseGzip.MouseState = MaterialSkin.MouseState.HOVER;
			this.checkBoxUseGzip.Name = "checkBoxUseGzip";
			this.checkBoxUseGzip.Ripple = true;
			this.checkBoxUseGzip.Size = new System.Drawing.Size(86, 30);
			this.checkBoxUseGzip.TabIndex = 12;
			this.checkBoxUseGzip.Text = "Use GZip";
			this.checkBoxUseGzip.UseVisualStyleBackColor = true;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.materialLabel5);
			this.panel5.Controls.Add(this.panelGenericInputs);
			this.panel5.Location = new System.Drawing.Point(3, 94);
			this.panel5.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(150, 234);
			this.panel5.TabIndex = 24;
			// 
			// materialLabel5
			// 
			this.materialLabel5.AutoSize = true;
			this.materialLabel5.Depth = 0;
			this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
			this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.materialLabel5.Location = new System.Drawing.Point(3, 0);
			this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialLabel5.Name = "materialLabel5";
			this.materialLabel5.Size = new System.Drawing.Size(60, 19);
			this.materialLabel5.TabIndex = 21;
			this.materialLabel5.Text = "Generic";
			// 
			// panel11
			// 
			this.panel11.Controls.Add(this.materialLabel6);
			this.panel11.Controls.Add(this.panelProxy);
			this.panel11.Location = new System.Drawing.Point(541, 94);
			this.panel11.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
			this.panel11.MinimumSize = new System.Drawing.Size(245, 120);
			this.panel11.Name = "panel11";
			this.panel11.Size = new System.Drawing.Size(245, 234);
			this.panel11.TabIndex = 25;
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
			this.materialLabel6.Size = new System.Drawing.Size(46, 19);
			this.materialLabel6.TabIndex = 21;
			this.materialLabel6.Text = "Proxy";
			// 
			// panelProxy
			// 
			this.panelProxy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelProxy.Controls.Add(this.radioButtonProxyChained);
			this.panelProxy.Controls.Add(this.radioButtonProxyRandom);
			this.panelProxy.Controls.Add(this.radioButtonProxyNone);
			this.panelProxy.Location = new System.Drawing.Point(0, 29);
			this.panelProxy.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
			this.panelProxy.MinimumSize = new System.Drawing.Size(245, 120);
			this.panelProxy.Name = "panelProxy";
			this.panelProxy.Size = new System.Drawing.Size(245, 205);
			this.panelProxy.TabIndex = 20;
			// 
			// radioButtonProxyChained
			// 
			this.radioButtonProxyChained.AutoSize = true;
			this.radioButtonProxyChained.Cursor = System.Windows.Forms.Cursors.Default;
			this.radioButtonProxyChained.Depth = 0;
			this.radioButtonProxyChained.Font = new System.Drawing.Font("Roboto", 10F);
			this.radioButtonProxyChained.Location = new System.Drawing.Point(0, 59);
			this.radioButtonProxyChained.Margin = new System.Windows.Forms.Padding(0);
			this.radioButtonProxyChained.MouseLocation = new System.Drawing.Point(-1, -1);
			this.radioButtonProxyChained.MouseState = MaterialSkin.MouseState.HOVER;
			this.radioButtonProxyChained.Name = "radioButtonProxyChained";
			this.radioButtonProxyChained.Ripple = true;
			this.radioButtonProxyChained.Size = new System.Drawing.Size(172, 30);
			this.radioButtonProxyChained.TabIndex = 28;
			this.radioButtonProxyChained.Text = "Chained (experimental)";
			this.radioButtonProxyChained.UseVisualStyleBackColor = true;
			// 
			// radioButtonProxyRandom
			// 
			this.radioButtonProxyRandom.AutoSize = true;
			this.radioButtonProxyRandom.Checked = true;
			this.radioButtonProxyRandom.Cursor = System.Windows.Forms.Cursors.Default;
			this.radioButtonProxyRandom.Depth = 0;
			this.radioButtonProxyRandom.Font = new System.Drawing.Font("Roboto", 10F);
			this.radioButtonProxyRandom.Location = new System.Drawing.Point(0, 29);
			this.radioButtonProxyRandom.Margin = new System.Windows.Forms.Padding(0);
			this.radioButtonProxyRandom.MouseLocation = new System.Drawing.Point(-1, -1);
			this.radioButtonProxyRandom.MouseState = MaterialSkin.MouseState.HOVER;
			this.radioButtonProxyRandom.Name = "radioButtonProxyRandom";
			this.radioButtonProxyRandom.Ripple = true;
			this.radioButtonProxyRandom.Size = new System.Drawing.Size(80, 30);
			this.radioButtonProxyRandom.TabIndex = 27;
			this.radioButtonProxyRandom.TabStop = true;
			this.radioButtonProxyRandom.Text = "Random";
			this.radioButtonProxyRandom.UseVisualStyleBackColor = true;
			// 
			// radioButtonProxyNone
			// 
			this.radioButtonProxyNone.AutoSize = true;
			this.radioButtonProxyNone.Cursor = System.Windows.Forms.Cursors.Default;
			this.radioButtonProxyNone.Depth = 0;
			this.radioButtonProxyNone.Font = new System.Drawing.Font("Roboto", 10F);
			this.radioButtonProxyNone.Location = new System.Drawing.Point(0, -1);
			this.radioButtonProxyNone.Margin = new System.Windows.Forms.Padding(0);
			this.radioButtonProxyNone.MouseLocation = new System.Drawing.Point(-1, -1);
			this.radioButtonProxyNone.MouseState = MaterialSkin.MouseState.HOVER;
			this.radioButtonProxyNone.Name = "radioButtonProxyNone";
			this.radioButtonProxyNone.Ripple = true;
			this.radioButtonProxyNone.Size = new System.Drawing.Size(62, 30);
			this.radioButtonProxyNone.TabIndex = 26;
			this.radioButtonProxyNone.Text = "None";
			this.radioButtonProxyNone.UseVisualStyleBackColor = true;
			// 
			// AttackOptionsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel11);
			this.Controls.Add(this.panel5);
			this.Controls.Add(this.panel9);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Name = "AttackOptionsControl";
			this.Size = new System.Drawing.Size(936, 365);
			this.Load += new System.EventHandler(this.AttackOptionsControl_Load);
			this.panelHttpMethod.ResumeLayout(false);
			this.panelHttpMethod.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panelGenericInputs.ResumeLayout(false);
			this.panelRandomness.ResumeLayout(false);
			this.panelRandomness.PerformLayout();
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			this.panelGenericButtons.ResumeLayout(false);
			this.panelGenericButtons.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel11.ResumeLayout(false);
			this.panel11.PerformLayout();
			this.panelProxy.ResumeLayout(false);
			this.panelProxy.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel panelHttpMethod;
		private MaterialSkin.Controls.MaterialLabel materialLabel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private MaterialSkin.Controls.MaterialLabel materialLabel2;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panelGenericInputs;
		private System.Windows.Forms.Panel panelRandomness;
		private MaterialSkin.Controls.MaterialLabel materialLabel3;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Panel panel9;
		private MaterialSkin.Controls.MaterialLabel materialLabel4;
		private System.Windows.Forms.Panel panelGenericButtons;
		private System.Windows.Forms.Panel panel5;
		private MaterialSkin.Controls.MaterialLabel materialLabel5;
		private System.Windows.Forms.Panel panel11;
		private MaterialSkin.Controls.MaterialLabel materialLabel6;
		private System.Windows.Forms.Panel panelProxy;
		public MaterialSkin.Controls.MaterialSingleLineTextField textFieldTimeout;
		public MaterialSkin.Controls.MaterialSingleLineTextField textFieldPort;
		public MaterialSkin.Controls.MaterialSingleLineTextField textFieldThreads;
		public MaterialSkin.Controls.MaterialSingleLineTextField textFieldSocketsPerThread;
		public MaterialSkin.Controls.MaterialRadioButton radioButtonHttpMethodGet;
		public MaterialSkin.Controls.MaterialRadioButton radioButtonHttpMethodPost;
		public MaterialSkin.Controls.MaterialRadioButton radioButtonHttpMethodHead;
		public MaterialSkin.Controls.MaterialRadioButton radioButtonAttackMethodHttp;
		public MaterialSkin.Controls.MaterialRadioButton radioButtonAttackMethodTcp;
		public MaterialSkin.Controls.MaterialRadioButton radioButtonAttackMethodUdp;
		public MaterialSkin.Controls.MaterialRadioButton radioButtonAttackMethodReCoil;
		public MaterialSkin.Controls.MaterialRadioButton radioButtonAttackMethodIcmp;
		public MaterialSkin.Controls.MaterialRadioButton radioButtonAttackMethodSlowLoic;
		public MaterialSkin.Controls.MaterialCheckBox checkBoxAppendRandomCharactersToUrl;
		public MaterialSkin.Controls.MaterialCheckBox checkBoxAppendRandomCharactersToMessage;
		public MaterialSkin.Controls.MaterialCheckBox checkBoxUseRandomReferer;
		public MaterialSkin.Controls.MaterialCheckBox checkBoxUseRandomUserAgent;
		public MaterialSkin.Controls.MaterialCheckBox checkBoxWaitForReply;
		public MaterialSkin.Controls.MaterialCheckBox checkBoxUseGzip;
		public MaterialSkin.Controls.MaterialRadioButton radioButtonProxyChained;
		public MaterialSkin.Controls.MaterialRadioButton radioButtonProxyRandom;
		public MaterialSkin.Controls.MaterialRadioButton radioButtonProxyNone;
		public MaterialSkin.Controls.MaterialCheckBox checkBoxUseRandomHeaderCommands;
	}
}
