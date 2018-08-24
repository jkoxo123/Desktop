// Token: 0x020000E6 RID: 230
internal sealed partial class CaptchaQueue : global::System.Windows.Forms.Form
{
	// Token: 0x06000565 RID: 1381 RVA: 0x000052BE File Offset: 0x000034BE
	protected override void Dispose(bool disposing)
	{
		if (disposing && this.icontainer_0 != null)
		{
			this.icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	// Token: 0x06000566 RID: 1382 RVA: 0x0002E518 File Offset: 0x0002C718
	private void InitializeComponent()
	{
		this.icontainer_0 = new global::System.ComponentModel.Container();
		global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::CaptchaQueue));
		this.addSolverButton = new global::Bunifu.Framework.UI.BunifuThinButton2();
		this.close_btn = new global::System.Windows.Forms.PictureBox();
		this.minimise_btn = new global::System.Windows.Forms.PictureBox();
		this.label1 = new global::System.Windows.Forms.Label();
		this.setProxyButton = new global::Bunifu.Framework.UI.BunifuThinButton2();
		this.reloadCaptcha = new global::System.Windows.Forms.PictureBox();
		this.proxyInput = new global::Bunifu.Framework.UI.BunifuMaterialTextbox();
		this.pictureBox2 = new global::System.Windows.Forms.PictureBox();
		this.clearsession_button = new global::Bunifu.Framework.UI.BunifuThinButton2();
		this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
		this.googlelogin_button = new global::Bunifu.Framework.UI.BunifuThinButton2();
		this.tabPanel = new global::System.Windows.Forms.Panel();
		this.closeButton4 = new global::Bunifu.Framework.UI.BunifuThinButton2();
		this.solverButton4 = new global::Bunifu.Framework.UI.BunifuThinButton2();
		this.solverLine4 = new global::Bunifu.Framework.UI.BunifuCustomLabel();
		this.closeButton3 = new global::Bunifu.Framework.UI.BunifuThinButton2();
		this.solverLine3 = new global::Bunifu.Framework.UI.BunifuCustomLabel();
		this.solverButton3 = new global::Bunifu.Framework.UI.BunifuThinButton2();
		this.closeButton2 = new global::Bunifu.Framework.UI.BunifuThinButton2();
		this.solverLine2 = new global::Bunifu.Framework.UI.BunifuCustomLabel();
		this.solverButton2 = new global::Bunifu.Framework.UI.BunifuThinButton2();
		this.closeButton1 = new global::Bunifu.Framework.UI.BunifuThinButton2();
		this.nextTabButton = new global::Bunifu.Framework.UI.BunifuThinButton2();
		this.solverLine1 = new global::Bunifu.Framework.UI.BunifuCustomLabel();
		this.solverButton1 = new global::Bunifu.Framework.UI.BunifuThinButton2();
		this.browserPanel = new global::System.Windows.Forms.Panel();
		this.proxyLabel = new global::System.Windows.Forms.Label();
		this.bunifuElipse_0 = new global::Bunifu.Framework.UI.BunifuElipse(this.icontainer_0);
		this.top_panel = new global::System.Windows.Forms.Panel();
		this.testBtn = new global::System.Windows.Forms.PictureBox();
		((global::System.ComponentModel.ISupportInitialize)this.close_btn).BeginInit();
		((global::System.ComponentModel.ISupportInitialize)this.minimise_btn).BeginInit();
		((global::System.ComponentModel.ISupportInitialize)this.reloadCaptcha).BeginInit();
		((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
		((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		this.tabPanel.SuspendLayout();
		this.top_panel.SuspendLayout();
		((global::System.ComponentModel.ISupportInitialize)this.testBtn).BeginInit();
		base.SuspendLayout();
		this.addSolverButton.ActiveBorderThickness = 1;
		this.addSolverButton.ActiveCornerRadius = 20;
		this.addSolverButton.ActiveFillColor = global::System.Drawing.Color.Empty;
		this.addSolverButton.ActiveForecolor = global::System.Drawing.Color.Empty;
		this.addSolverButton.ActiveLineColor = global::System.Drawing.Color.Empty;
		this.addSolverButton.BackColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.addSolverButton.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("addSolverButton.BackgroundImage");
		this.addSolverButton.ButtonText = "+";
		this.addSolverButton.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.addSolverButton.Font = new global::System.Drawing.Font("Century Gothic", 18f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
		this.addSolverButton.ForeColor = global::System.Drawing.Color.FromArgb(44, 186, 118);
		this.addSolverButton.IdleBorderThickness = 1;
		this.addSolverButton.IdleCornerRadius = 20;
		this.addSolverButton.IdleFillColor = global::System.Drawing.Color.Empty;
		this.addSolverButton.IdleForecolor = global::System.Drawing.Color.Empty;
		this.addSolverButton.IdleLineColor = global::System.Drawing.Color.Empty;
		this.addSolverButton.Location = new global::System.Drawing.Point(15, 3);
		this.addSolverButton.Margin = new global::System.Windows.Forms.Padding(6, 5, 6, 5);
		this.addSolverButton.Name = "addSolverButton";
		this.addSolverButton.Size = new global::System.Drawing.Size(36, 31);
		this.addSolverButton.TabIndex = 9;
		this.addSolverButton.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
		this.addSolverButton.Click += new global::System.EventHandler(this.addSolverButton_Click);
		this.close_btn.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
		this.close_btn.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.close_btn.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("close_btn.Image");
		this.close_btn.Location = new global::System.Drawing.Point(391, 5);
		this.close_btn.Name = "close_btn";
		this.close_btn.Size = new global::System.Drawing.Size(27, 28);
		this.close_btn.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.close_btn.TabIndex = 7;
		this.close_btn.TabStop = false;
		this.close_btn.Click += new global::System.EventHandler(this.close_btn_Click);
		this.minimise_btn.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
		this.minimise_btn.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.minimise_btn.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("minimise_btn.Image");
		this.minimise_btn.Location = new global::System.Drawing.Point(359, 14);
		this.minimise_btn.Name = "minimise_btn";
		this.minimise_btn.Size = new global::System.Drawing.Size(27, 22);
		this.minimise_btn.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.minimise_btn.TabIndex = 8;
		this.minimise_btn.TabStop = false;
		this.minimise_btn.Click += new global::System.EventHandler(this.minimise_btn_Click);
		this.label1.Anchor = global::System.Windows.Forms.AnchorStyles.Top;
		this.label1.AutoSize = true;
		this.label1.BackColor = global::System.Drawing.Color.Transparent;
		this.label1.Font = new global::System.Drawing.Font("Verdana", 14.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
		this.label1.ForeColor = global::System.Drawing.Color.FromArgb(44, 186, 118);
		this.label1.Location = new global::System.Drawing.Point(108, 8);
		this.label1.Name = "label1";
		this.label1.Size = new global::System.Drawing.Size(190, 23);
		this.label1.TabIndex = 6;
		this.label1.Text = "CAPTCHA QUEUE";
		this.setProxyButton.ActiveBorderThickness = 1;
		this.setProxyButton.ActiveCornerRadius = 20;
		this.setProxyButton.ActiveFillColor = global::System.Drawing.Color.Empty;
		this.setProxyButton.ActiveForecolor = global::System.Drawing.Color.Empty;
		this.setProxyButton.ActiveLineColor = global::System.Drawing.Color.Empty;
		this.setProxyButton.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
		this.setProxyButton.BackColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.setProxyButton.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("setProxyButton.BackgroundImage");
		this.setProxyButton.ButtonText = "✔";
		this.setProxyButton.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.setProxyButton.Font = new global::System.Drawing.Font("Century Gothic", 18f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
		this.setProxyButton.ForeColor = global::System.Drawing.Color.FromArgb(44, 186, 118);
		this.setProxyButton.IdleBorderThickness = 1;
		this.setProxyButton.IdleCornerRadius = 20;
		this.setProxyButton.IdleFillColor = global::System.Drawing.Color.Empty;
		this.setProxyButton.IdleForecolor = global::System.Drawing.Color.Empty;
		this.setProxyButton.IdleLineColor = global::System.Drawing.Color.Empty;
		this.setProxyButton.Location = new global::System.Drawing.Point(394, 643);
		this.setProxyButton.Margin = new global::System.Windows.Forms.Padding(6, 5, 6, 5);
		this.setProxyButton.Name = "setProxyButton";
		this.setProxyButton.Size = new global::System.Drawing.Size(30, 31);
		this.setProxyButton.TabIndex = 10;
		this.setProxyButton.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
		this.setProxyButton.Click += new global::System.EventHandler(this.setProxyButton_Click);
		this.reloadCaptcha.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
		this.reloadCaptcha.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.reloadCaptcha.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("reloadCaptcha.Image");
		this.reloadCaptcha.Location = new global::System.Drawing.Point(365, 696);
		this.reloadCaptcha.Name = "reloadCaptcha";
		this.reloadCaptcha.Size = new global::System.Drawing.Size(27, 28);
		this.reloadCaptcha.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.reloadCaptcha.TabIndex = 15;
		this.reloadCaptcha.TabStop = false;
		this.reloadCaptcha.Click += new global::System.EventHandler(this.reloadCaptcha_Click);
		this.proxyInput.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.proxyInput.AutoCompleteMode = global::System.Windows.Forms.AutoCompleteMode.None;
		this.proxyInput.AutoCompleteSource = global::System.Windows.Forms.AutoCompleteSource.None;
		this.proxyInput.characterCasing = global::System.Windows.Forms.CharacterCasing.Normal;
		this.proxyInput.Cursor = global::System.Windows.Forms.Cursors.IBeam;
		this.proxyInput.Font = new global::System.Drawing.Font("Verdana", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
		this.proxyInput.ForeColor = global::System.Drawing.Color.White;
		this.proxyInput.HintForeColor = global::System.Drawing.Color.Empty;
		this.proxyInput.HintText = string.Empty;
		this.proxyInput.isPassword = false;
		this.proxyInput.LineFocusedColor = global::System.Drawing.Color.DimGray;
		this.proxyInput.LineIdleColor = global::System.Drawing.Color.DimGray;
		this.proxyInput.LineMouseHoverColor = global::System.Drawing.Color.DimGray;
		this.proxyInput.LineThickness = 2;
		this.proxyInput.Location = new global::System.Drawing.Point(79, 643);
		this.proxyInput.Margin = new global::System.Windows.Forms.Padding(4);
		this.proxyInput.MaxLength = 32767;
		this.proxyInput.Name = "proxyInput";
		this.proxyInput.Size = new global::System.Drawing.Size(305, 28);
		this.proxyInput.TabIndex = 12;
		this.proxyInput.Text = "localhost";
		this.proxyInput.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Left;
		this.pictureBox2.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.pictureBox2.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.pictureBox2.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox2.Image");
		this.pictureBox2.Location = new global::System.Drawing.Point(21, 695);
		this.pictureBox2.Name = "pictureBox2";
		this.pictureBox2.Size = new global::System.Drawing.Size(27, 28);
		this.pictureBox2.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pictureBox2.TabIndex = 11;
		this.pictureBox2.TabStop = false;
		this.clearsession_button.ActiveBorderThickness = 1;
		this.clearsession_button.ActiveCornerRadius = 30;
		this.clearsession_button.ActiveFillColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.clearsession_button.ActiveForecolor = global::System.Drawing.Color.FromArgb(225, 29, 65);
		this.clearsession_button.ActiveLineColor = global::System.Drawing.Color.FromArgb(225, 29, 65);
		this.clearsession_button.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.clearsession_button.BackColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.clearsession_button.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("clearsession_button.BackgroundImage");
		this.clearsession_button.ButtonText = "    Clear Cookies";
		this.clearsession_button.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.clearsession_button.Font = new global::System.Drawing.Font("Verdana", 12f);
		this.clearsession_button.ForeColor = global::System.Drawing.Color.FromArgb(44, 186, 118);
		this.clearsession_button.IdleBorderThickness = 1;
		this.clearsession_button.IdleCornerRadius = 30;
		this.clearsession_button.IdleFillColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.clearsession_button.IdleForecolor = global::System.Drawing.Color.FromArgb(225, 29, 65);
		this.clearsession_button.IdleLineColor = global::System.Drawing.Color.FromArgb(225, 29, 65);
		this.clearsession_button.Location = new global::System.Drawing.Point(10, 687);
		this.clearsession_button.Margin = new global::System.Windows.Forms.Padding(5, 4, 5, 4);
		this.clearsession_button.Name = "clearsession_button";
		this.clearsession_button.Size = new global::System.Drawing.Size(172, 44);
		this.clearsession_button.TabIndex = 10;
		this.clearsession_button.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
		this.clearsession_button.Click += new global::System.EventHandler(this.clearsession_button_Click);
		this.pictureBox1.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
		this.pictureBox1.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.pictureBox1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox1.Image");
		this.pictureBox1.Location = new global::System.Drawing.Point(198, 695);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new global::System.Drawing.Size(27, 28);
		this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pictureBox1.TabIndex = 9;
		this.pictureBox1.TabStop = false;
		this.googlelogin_button.ActiveBorderThickness = 1;
		this.googlelogin_button.ActiveCornerRadius = 30;
		this.googlelogin_button.ActiveFillColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.googlelogin_button.ActiveForecolor = global::System.Drawing.Color.FromArgb(44, 186, 118);
		this.googlelogin_button.ActiveLineColor = global::System.Drawing.Color.FromArgb(44, 186, 118);
		this.googlelogin_button.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
		this.googlelogin_button.BackColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.googlelogin_button.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("googlelogin_button.BackgroundImage");
		this.googlelogin_button.ButtonText = "    Google Login";
		this.googlelogin_button.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.googlelogin_button.Font = new global::System.Drawing.Font("Verdana", 12f);
		this.googlelogin_button.ForeColor = global::System.Drawing.Color.FromArgb(44, 186, 118);
		this.googlelogin_button.IdleBorderThickness = 1;
		this.googlelogin_button.IdleCornerRadius = 30;
		this.googlelogin_button.IdleFillColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.googlelogin_button.IdleForecolor = global::System.Drawing.Color.FromArgb(44, 186, 118);
		this.googlelogin_button.IdleLineColor = global::System.Drawing.Color.FromArgb(44, 186, 118);
		this.googlelogin_button.Location = new global::System.Drawing.Point(188, 687);
		this.googlelogin_button.Margin = new global::System.Windows.Forms.Padding(5, 4, 5, 4);
		this.googlelogin_button.Name = "googlelogin_button";
		this.googlelogin_button.Size = new global::System.Drawing.Size(167, 44);
		this.googlelogin_button.TabIndex = 0;
		this.googlelogin_button.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
		this.googlelogin_button.Click += new global::System.EventHandler(this.googlelogin_button_Click);
		this.tabPanel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.tabPanel.Controls.Add(this.closeButton4);
		this.tabPanel.Controls.Add(this.solverButton4);
		this.tabPanel.Controls.Add(this.solverLine4);
		this.tabPanel.Controls.Add(this.closeButton3);
		this.tabPanel.Controls.Add(this.solverLine3);
		this.tabPanel.Controls.Add(this.solverButton3);
		this.tabPanel.Controls.Add(this.closeButton2);
		this.tabPanel.Controls.Add(this.solverLine2);
		this.tabPanel.Controls.Add(this.solverButton2);
		this.tabPanel.Controls.Add(this.closeButton1);
		this.tabPanel.Controls.Add(this.nextTabButton);
		this.tabPanel.Controls.Add(this.solverLine1);
		this.tabPanel.Controls.Add(this.solverButton1);
		this.tabPanel.Location = new global::System.Drawing.Point(0, 53);
		this.tabPanel.Name = "tabPanel";
		this.tabPanel.Size = new global::System.Drawing.Size(439, 42);
		this.tabPanel.TabIndex = 2;
		this.closeButton4.ActiveBorderThickness = 1;
		this.closeButton4.ActiveCornerRadius = 20;
		this.closeButton4.ActiveFillColor = global::System.Drawing.Color.Empty;
		this.closeButton4.ActiveForecolor = global::System.Drawing.Color.Empty;
		this.closeButton4.ActiveLineColor = global::System.Drawing.Color.Empty;
		this.closeButton4.BackColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.closeButton4.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("closeButton4.BackgroundImage");
		this.closeButton4.ButtonText = "x";
		this.closeButton4.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.closeButton4.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
		this.closeButton4.ForeColor = global::System.Drawing.Color.White;
		this.closeButton4.IdleBorderThickness = 1;
		this.closeButton4.IdleCornerRadius = 20;
		this.closeButton4.IdleFillColor = global::System.Drawing.Color.Empty;
		this.closeButton4.IdleForecolor = global::System.Drawing.Color.Empty;
		this.closeButton4.IdleLineColor = global::System.Drawing.Color.Empty;
		this.closeButton4.Location = new global::System.Drawing.Point(388, 7);
		this.closeButton4.Margin = new global::System.Windows.Forms.Padding(4, 4, 4, 4);
		this.closeButton4.Name = "closeButton4";
		this.closeButton4.Size = new global::System.Drawing.Size(17, 21);
		this.closeButton4.TabIndex = 19;
		this.closeButton4.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
		this.closeButton4.Click += new global::System.EventHandler(this.closeButton1_Click);
		this.solverButton4.ActiveBorderThickness = 1;
		this.solverButton4.ActiveCornerRadius = 20;
		this.solverButton4.ActiveFillColor = global::System.Drawing.Color.Transparent;
		this.solverButton4.ActiveForecolor = global::System.Drawing.Color.White;
		this.solverButton4.ActiveLineColor = global::System.Drawing.Color.Transparent;
		this.solverButton4.BackColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.solverButton4.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("solverButton4.BackgroundImage");
		this.solverButton4.ButtonText = "Solver 4";
		this.solverButton4.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.solverButton4.Font = new global::System.Drawing.Font("Century Gothic", 10f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
		this.solverButton4.ForeColor = global::System.Drawing.Color.SeaGreen;
		this.solverButton4.IdleBorderThickness = 1;
		this.solverButton4.IdleCornerRadius = 20;
		this.solverButton4.IdleFillColor = global::System.Drawing.Color.Transparent;
		this.solverButton4.IdleForecolor = global::System.Drawing.Color.White;
		this.solverButton4.IdleLineColor = global::System.Drawing.Color.Transparent;
		this.solverButton4.Location = new global::System.Drawing.Point(321, 16);
		this.solverButton4.Margin = new global::System.Windows.Forms.Padding(4, 4, 4, 4);
		this.solverButton4.Name = "solverButton4";
		this.solverButton4.Size = new global::System.Drawing.Size(75, 17);
		this.solverButton4.TabIndex = 18;
		this.solverButton4.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
		this.solverButton4.Click += new global::System.EventHandler(this.solverButton1_Click);
		this.solverLine4.BackColor = global::System.Drawing.Color.SeaGreen;
		this.solverLine4.ForeColor = global::System.Drawing.Color.Coral;
		this.solverLine4.Location = new global::System.Drawing.Point(321, 37);
		this.solverLine4.Name = "solverLine4";
		this.solverLine4.Size = new global::System.Drawing.Size(75, 3);
		this.solverLine4.TabIndex = 17;
		this.closeButton3.ActiveBorderThickness = 1;
		this.closeButton3.ActiveCornerRadius = 20;
		this.closeButton3.ActiveFillColor = global::System.Drawing.Color.Empty;
		this.closeButton3.ActiveForecolor = global::System.Drawing.Color.Empty;
		this.closeButton3.ActiveLineColor = global::System.Drawing.Color.Empty;
		this.closeButton3.BackColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.closeButton3.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("closeButton3.BackgroundImage");
		this.closeButton3.ButtonText = "x";
		this.closeButton3.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.closeButton3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
		this.closeButton3.ForeColor = global::System.Drawing.Color.White;
		this.closeButton3.IdleBorderThickness = 1;
		this.closeButton3.IdleCornerRadius = 20;
		this.closeButton3.IdleFillColor = global::System.Drawing.Color.Empty;
		this.closeButton3.IdleForecolor = global::System.Drawing.Color.Empty;
		this.closeButton3.IdleLineColor = global::System.Drawing.Color.Empty;
		this.closeButton3.Location = new global::System.Drawing.Point(283, 7);
		this.closeButton3.Margin = new global::System.Windows.Forms.Padding(4, 4, 4, 4);
		this.closeButton3.Name = "closeButton3";
		this.closeButton3.Size = new global::System.Drawing.Size(17, 21);
		this.closeButton3.TabIndex = 16;
		this.closeButton3.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
		this.closeButton3.Click += new global::System.EventHandler(this.closeButton1_Click);
		this.solverLine3.BackColor = global::System.Drawing.Color.SeaGreen;
		this.solverLine3.ForeColor = global::System.Drawing.Color.Coral;
		this.solverLine3.Location = new global::System.Drawing.Point(217, 37);
		this.solverLine3.Name = "solverLine3";
		this.solverLine3.Size = new global::System.Drawing.Size(75, 3);
		this.solverLine3.TabIndex = 14;
		this.solverButton3.ActiveBorderThickness = 1;
		this.solverButton3.ActiveCornerRadius = 20;
		this.solverButton3.ActiveFillColor = global::System.Drawing.Color.Transparent;
		this.solverButton3.ActiveForecolor = global::System.Drawing.Color.White;
		this.solverButton3.ActiveLineColor = global::System.Drawing.Color.Transparent;
		this.solverButton3.BackColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.solverButton3.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("solverButton3.BackgroundImage");
		this.solverButton3.ButtonText = "Solver 3";
		this.solverButton3.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.solverButton3.Font = new global::System.Drawing.Font("Century Gothic", 10f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
		this.solverButton3.ForeColor = global::System.Drawing.Color.SeaGreen;
		this.solverButton3.IdleBorderThickness = 1;
		this.solverButton3.IdleCornerRadius = 20;
		this.solverButton3.IdleFillColor = global::System.Drawing.Color.Transparent;
		this.solverButton3.IdleForecolor = global::System.Drawing.Color.White;
		this.solverButton3.IdleLineColor = global::System.Drawing.Color.Transparent;
		this.solverButton3.Location = new global::System.Drawing.Point(217, 16);
		this.solverButton3.Margin = new global::System.Windows.Forms.Padding(4, 4, 4, 4);
		this.solverButton3.Name = "solverButton3";
		this.solverButton3.Size = new global::System.Drawing.Size(75, 17);
		this.solverButton3.TabIndex = 15;
		this.solverButton3.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
		this.solverButton3.Click += new global::System.EventHandler(this.solverButton1_Click);
		this.closeButton2.ActiveBorderThickness = 1;
		this.closeButton2.ActiveCornerRadius = 20;
		this.closeButton2.ActiveFillColor = global::System.Drawing.Color.Empty;
		this.closeButton2.ActiveForecolor = global::System.Drawing.Color.Empty;
		this.closeButton2.ActiveLineColor = global::System.Drawing.Color.Empty;
		this.closeButton2.BackColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.closeButton2.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("closeButton2.BackgroundImage");
		this.closeButton2.ButtonText = "x";
		this.closeButton2.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.closeButton2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
		this.closeButton2.ForeColor = global::System.Drawing.Color.White;
		this.closeButton2.IdleBorderThickness = 1;
		this.closeButton2.IdleCornerRadius = 20;
		this.closeButton2.IdleFillColor = global::System.Drawing.Color.Empty;
		this.closeButton2.IdleForecolor = global::System.Drawing.Color.Empty;
		this.closeButton2.IdleLineColor = global::System.Drawing.Color.Empty;
		this.closeButton2.Location = new global::System.Drawing.Point(182, 7);
		this.closeButton2.Margin = new global::System.Windows.Forms.Padding(4, 4, 4, 4);
		this.closeButton2.Name = "closeButton2";
		this.closeButton2.Size = new global::System.Drawing.Size(17, 21);
		this.closeButton2.TabIndex = 13;
		this.closeButton2.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
		this.closeButton2.Click += new global::System.EventHandler(this.closeButton1_Click);
		this.solverLine2.BackColor = global::System.Drawing.Color.SeaGreen;
		this.solverLine2.ForeColor = global::System.Drawing.Color.Coral;
		this.solverLine2.Location = new global::System.Drawing.Point(116, 37);
		this.solverLine2.Name = "solverLine2";
		this.solverLine2.Size = new global::System.Drawing.Size(75, 3);
		this.solverLine2.TabIndex = 11;
		this.solverButton2.ActiveBorderThickness = 1;
		this.solverButton2.ActiveCornerRadius = 20;
		this.solverButton2.ActiveFillColor = global::System.Drawing.Color.Transparent;
		this.solverButton2.ActiveForecolor = global::System.Drawing.Color.White;
		this.solverButton2.ActiveLineColor = global::System.Drawing.Color.Transparent;
		this.solverButton2.BackColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.solverButton2.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("solverButton2.BackgroundImage");
		this.solverButton2.ButtonText = "Solver 2";
		this.solverButton2.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.solverButton2.Font = new global::System.Drawing.Font("Century Gothic", 10f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
		this.solverButton2.ForeColor = global::System.Drawing.Color.SeaGreen;
		this.solverButton2.IdleBorderThickness = 1;
		this.solverButton2.IdleCornerRadius = 20;
		this.solverButton2.IdleFillColor = global::System.Drawing.Color.Transparent;
		this.solverButton2.IdleForecolor = global::System.Drawing.Color.White;
		this.solverButton2.IdleLineColor = global::System.Drawing.Color.Transparent;
		this.solverButton2.Location = new global::System.Drawing.Point(116, 16);
		this.solverButton2.Margin = new global::System.Windows.Forms.Padding(4, 4, 4, 4);
		this.solverButton2.Name = "solverButton2";
		this.solverButton2.Size = new global::System.Drawing.Size(75, 17);
		this.solverButton2.TabIndex = 12;
		this.solverButton2.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
		this.solverButton2.Click += new global::System.EventHandler(this.solverButton1_Click);
		this.closeButton1.ActiveBorderThickness = 1;
		this.closeButton1.ActiveCornerRadius = 20;
		this.closeButton1.ActiveFillColor = global::System.Drawing.Color.Empty;
		this.closeButton1.ActiveForecolor = global::System.Drawing.Color.Empty;
		this.closeButton1.ActiveLineColor = global::System.Drawing.Color.Empty;
		this.closeButton1.BackColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.closeButton1.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("closeButton1.BackgroundImage");
		this.closeButton1.ButtonText = "x";
		this.closeButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.closeButton1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
		this.closeButton1.ForeColor = global::System.Drawing.Color.White;
		this.closeButton1.IdleBorderThickness = 1;
		this.closeButton1.IdleCornerRadius = 20;
		this.closeButton1.IdleFillColor = global::System.Drawing.Color.Empty;
		this.closeButton1.IdleForecolor = global::System.Drawing.Color.Empty;
		this.closeButton1.IdleLineColor = global::System.Drawing.Color.Empty;
		this.closeButton1.Location = new global::System.Drawing.Point(78, 7);
		this.closeButton1.Margin = new global::System.Windows.Forms.Padding(4, 4, 4, 4);
		this.closeButton1.Name = "closeButton1";
		this.closeButton1.Size = new global::System.Drawing.Size(17, 21);
		this.closeButton1.TabIndex = 10;
		this.closeButton1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
		this.closeButton1.Click += new global::System.EventHandler(this.closeButton1_Click);
		this.nextTabButton.ActiveBorderThickness = 1;
		this.nextTabButton.ActiveCornerRadius = 20;
		this.nextTabButton.ActiveFillColor = global::System.Drawing.Color.Empty;
		this.nextTabButton.ActiveForecolor = global::System.Drawing.Color.Empty;
		this.nextTabButton.ActiveLineColor = global::System.Drawing.Color.Empty;
		this.nextTabButton.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
		this.nextTabButton.BackColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.nextTabButton.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("nextTabButton.BackgroundImage");
		this.nextTabButton.ButtonText = ">";
		this.nextTabButton.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.nextTabButton.Font = new global::System.Drawing.Font("Century Gothic", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
		this.nextTabButton.ForeColor = global::System.Drawing.Color.FromArgb(44, 186, 118);
		this.nextTabButton.IdleBorderThickness = 1;
		this.nextTabButton.IdleCornerRadius = 20;
		this.nextTabButton.IdleFillColor = global::System.Drawing.Color.Empty;
		this.nextTabButton.IdleForecolor = global::System.Drawing.Color.Empty;
		this.nextTabButton.IdleLineColor = global::System.Drawing.Color.Empty;
		this.nextTabButton.Location = new global::System.Drawing.Point(408, 11);
		this.nextTabButton.Margin = new global::System.Windows.Forms.Padding(5);
		this.nextTabButton.Name = "nextTabButton";
		this.nextTabButton.Size = new global::System.Drawing.Size(33, 29);
		this.nextTabButton.TabIndex = 0;
		this.nextTabButton.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
		this.nextTabButton.Click += new global::System.EventHandler(this.nextTabButton_Click);
		this.solverLine1.BackColor = global::System.Drawing.Color.SeaGreen;
		this.solverLine1.ForeColor = global::System.Drawing.Color.Coral;
		this.solverLine1.Location = new global::System.Drawing.Point(12, 37);
		this.solverLine1.Name = "solverLine1";
		this.solverLine1.Size = new global::System.Drawing.Size(75, 3);
		this.solverLine1.TabIndex = 1;
		this.solverButton1.ActiveBorderThickness = 1;
		this.solverButton1.ActiveCornerRadius = 20;
		this.solverButton1.ActiveFillColor = global::System.Drawing.Color.Transparent;
		this.solverButton1.ActiveForecolor = global::System.Drawing.Color.White;
		this.solverButton1.ActiveLineColor = global::System.Drawing.Color.Transparent;
		this.solverButton1.BackColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.solverButton1.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("solverButton1.BackgroundImage");
		this.solverButton1.ButtonText = "Solver 1";
		this.solverButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.solverButton1.Font = new global::System.Drawing.Font("Century Gothic", 10f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
		this.solverButton1.ForeColor = global::System.Drawing.Color.SeaGreen;
		this.solverButton1.IdleBorderThickness = 1;
		this.solverButton1.IdleCornerRadius = 20;
		this.solverButton1.IdleFillColor = global::System.Drawing.Color.Transparent;
		this.solverButton1.IdleForecolor = global::System.Drawing.Color.White;
		this.solverButton1.IdleLineColor = global::System.Drawing.Color.Transparent;
		this.solverButton1.Location = new global::System.Drawing.Point(12, 16);
		this.solverButton1.Margin = new global::System.Windows.Forms.Padding(4, 4, 4, 4);
		this.solverButton1.Name = "solverButton1";
		this.solverButton1.Size = new global::System.Drawing.Size(75, 17);
		this.solverButton1.TabIndex = 2;
		this.solverButton1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
		this.solverButton1.Click += new global::System.EventHandler(this.solverButton1_Click);
		this.browserPanel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.browserPanel.AutoSizeMode = global::System.Windows.Forms.AutoSizeMode.GrowAndShrink;
		this.browserPanel.Location = new global::System.Drawing.Point(0, 95);
		this.browserPanel.Name = "browserPanel";
		this.browserPanel.Size = new global::System.Drawing.Size(439, 531);
		this.browserPanel.TabIndex = 3;
		this.proxyLabel.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.proxyLabel.AutoSize = true;
		this.proxyLabel.BackColor = global::System.Drawing.Color.Transparent;
		this.proxyLabel.Cursor = global::System.Windows.Forms.Cursors.Cross;
		this.proxyLabel.Font = new global::System.Drawing.Font("Verdana", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
		this.proxyLabel.ForeColor = global::System.Drawing.Color.White;
		this.proxyLabel.Location = new global::System.Drawing.Point(18, 650);
		this.proxyLabel.Name = "proxyLabel";
		this.proxyLabel.Size = new global::System.Drawing.Size(54, 17);
		this.proxyLabel.TabIndex = 10;
		this.proxyLabel.Text = "Proxy:";
		this.bunifuElipse_0.ElipseRadius = 7;
		this.bunifuElipse_0.TargetControl = this;
		this.top_panel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.top_panel.BackColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.top_panel.Controls.Add(this.addSolverButton);
		this.top_panel.Controls.Add(this.close_btn);
		this.top_panel.Controls.Add(this.minimise_btn);
		this.top_panel.Controls.Add(this.label1);
		this.top_panel.ForeColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		this.top_panel.Location = new global::System.Drawing.Point(9, 12);
		this.top_panel.Name = "top_panel";
		this.top_panel.Size = new global::System.Drawing.Size(419, 41);
		this.top_panel.TabIndex = 1;
		this.top_panel.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.top_panel_MouseMove);
		this.testBtn.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
		this.testBtn.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.testBtn.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("testBtn.Image");
		this.testBtn.Location = new global::System.Drawing.Point(403, 696);
		this.testBtn.Name = "testBtn";
		this.testBtn.Size = new global::System.Drawing.Size(27, 28);
		this.testBtn.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.testBtn.TabIndex = 16;
		this.testBtn.TabStop = false;
		this.testBtn.Click += new global::System.EventHandler(this.testBtn_Click);
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = global::System.Drawing.Color.FromArgb(25, 23, 26);
		base.ClientSize = new global::System.Drawing.Size(439, 744);
		base.Controls.Add(this.testBtn);
		base.Controls.Add(this.proxyLabel);
		base.Controls.Add(this.setProxyButton);
		base.Controls.Add(this.browserPanel);
		base.Controls.Add(this.reloadCaptcha);
		base.Controls.Add(this.tabPanel);
		base.Controls.Add(this.proxyInput);
		base.Controls.Add(this.pictureBox2);
		base.Controls.Add(this.clearsession_button);
		base.Controls.Add(this.top_panel);
		base.Controls.Add(this.pictureBox1);
		base.Controls.Add(this.googlelogin_button);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
		this.MinimumSize = new global::System.Drawing.Size(439, 200);
		base.Name = "CaptchaQueue";
		this.Text = "CaptchaQueue";
		((global::System.ComponentModel.ISupportInitialize)this.close_btn).EndInit();
		((global::System.ComponentModel.ISupportInitialize)this.minimise_btn).EndInit();
		((global::System.ComponentModel.ISupportInitialize)this.reloadCaptcha).EndInit();
		((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
		((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		this.tabPanel.ResumeLayout(false);
		this.top_panel.ResumeLayout(false);
		this.top_panel.PerformLayout();
		((global::System.ComponentModel.ISupportInitialize)this.testBtn).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x040003E0 RID: 992
	private global::System.ComponentModel.IContainer icontainer_0;

	// Token: 0x040003E1 RID: 993
	private global::System.Windows.Forms.PictureBox close_btn;

	// Token: 0x040003E2 RID: 994
	private global::System.Windows.Forms.PictureBox minimise_btn;

	// Token: 0x040003E3 RID: 995
	private global::System.Windows.Forms.Label label1;

	// Token: 0x040003E4 RID: 996
	private global::System.Windows.Forms.PictureBox pictureBox2;

	// Token: 0x040003E5 RID: 997
	private global::Bunifu.Framework.UI.BunifuThinButton2 clearsession_button;

	// Token: 0x040003E6 RID: 998
	private global::System.Windows.Forms.PictureBox pictureBox1;

	// Token: 0x040003E7 RID: 999
	private global::Bunifu.Framework.UI.BunifuThinButton2 googlelogin_button;

	// Token: 0x040003E8 RID: 1000
	private global::Bunifu.Framework.UI.BunifuMaterialTextbox proxyInput;

	// Token: 0x040003E9 RID: 1001
	private global::System.Windows.Forms.Panel browserPanel;

	// Token: 0x040003EA RID: 1002
	private global::System.Windows.Forms.Panel tabPanel;

	// Token: 0x040003EB RID: 1003
	private global::Bunifu.Framework.UI.BunifuThinButton2 solverButton1;

	// Token: 0x040003EC RID: 1004
	private global::Bunifu.Framework.UI.BunifuCustomLabel solverLine1;

	// Token: 0x040003ED RID: 1005
	private global::Bunifu.Framework.UI.BunifuThinButton2 nextTabButton;

	// Token: 0x040003EE RID: 1006
	private global::Bunifu.Framework.UI.BunifuThinButton2 addSolverButton;

	// Token: 0x040003EF RID: 1007
	private global::System.Windows.Forms.PictureBox reloadCaptcha;

	// Token: 0x040003F0 RID: 1008
	private global::Bunifu.Framework.UI.BunifuThinButton2 closeButton1;

	// Token: 0x040003F1 RID: 1009
	private global::Bunifu.Framework.UI.BunifuThinButton2 closeButton4;

	// Token: 0x040003F2 RID: 1010
	private global::Bunifu.Framework.UI.BunifuThinButton2 solverButton4;

	// Token: 0x040003F3 RID: 1011
	private global::Bunifu.Framework.UI.BunifuCustomLabel solverLine4;

	// Token: 0x040003F4 RID: 1012
	private global::Bunifu.Framework.UI.BunifuThinButton2 closeButton3;

	// Token: 0x040003F5 RID: 1013
	private global::Bunifu.Framework.UI.BunifuCustomLabel solverLine3;

	// Token: 0x040003F6 RID: 1014
	private global::Bunifu.Framework.UI.BunifuThinButton2 solverButton3;

	// Token: 0x040003F7 RID: 1015
	private global::Bunifu.Framework.UI.BunifuThinButton2 closeButton2;

	// Token: 0x040003F8 RID: 1016
	private global::Bunifu.Framework.UI.BunifuCustomLabel solverLine2;

	// Token: 0x040003F9 RID: 1017
	private global::Bunifu.Framework.UI.BunifuThinButton2 solverButton2;

	// Token: 0x040003FA RID: 1018
	private global::Bunifu.Framework.UI.BunifuThinButton2 setProxyButton;

	// Token: 0x040003FB RID: 1019
	private global::System.Windows.Forms.Label proxyLabel;

	// Token: 0x040003FC RID: 1020
	private global::Bunifu.Framework.UI.BunifuElipse bunifuElipse_0;

	// Token: 0x040003FD RID: 1021
	public global::System.Windows.Forms.Panel top_panel;

	// Token: 0x040003FE RID: 1022
	private global::System.Windows.Forms.PictureBox testBtn;
}
