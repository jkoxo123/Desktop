// Token: 0x0200003C RID: 60
internal sealed partial class MainWindow : global::System.Windows.Forms.Form
{
	// Token: 0x06000137 RID: 311 RVA: 0x00003706 File Offset: 0x00001906
	protected override void Dispose(bool disposing)
	{
		if (disposing && this.icontainer_0 != null)
		{
			this.icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	// Token: 0x06000138 RID: 312 RVA: 0x0000EAA8 File Offset: 0x0000CCA8
	private void InitializeComponent()
	{
		this.icontainer_0 = new global::System.ComponentModel.Container();
		global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::MainWindow));
		this.resisze_button = new global::System.Windows.Forms.Label();
		this.browser_panel = new global::System.Windows.Forms.Panel();
		this.bunifuElipse_0 = new global::Bunifu.Framework.UI.BunifuElipse(this.icontainer_0);
		this.bunifuFormFadeTransition_0 = new global::Bunifu.Framework.UI.BunifuFormFadeTransition(this.icontainer_0);
		base.SuspendLayout();
		this.resisze_button.Location = new global::System.Drawing.Point(0, 0);
		this.resisze_button.Name = "resisze_button";
		this.resisze_button.Size = new global::System.Drawing.Size(100, 23);
		this.resisze_button.TabIndex = 2;
		this.browser_panel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.browser_panel.Location = new global::System.Drawing.Point(1, -1);
		this.browser_panel.Name = "browser_panel";
		this.browser_panel.Size = new global::System.Drawing.Size(1296, 734);
		this.browser_panel.TabIndex = 1;
		this.bunifuElipse_0.ElipseRadius = 20;
		this.bunifuElipse_0.TargetControl = this;
		this.bunifuFormFadeTransition_0.Delay = 3;
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = global::System.Drawing.Color.FromArgb(22, 21, 26);
		base.ClientSize = new global::System.Drawing.Size(1214, 612);
		base.Controls.Add(this.browser_panel);
		base.Controls.Add(this.resisze_button);
		this.DoubleBuffered = true;
		this.ForeColor = global::System.Drawing.Color.FromArgb(22, 21, 26);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
		this.MinimumSize = new global::System.Drawing.Size(412, 252);
		base.Name = "MainWindow";
		base.Opacity = 0.0;
		base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "CyberAIO";
		base.ResumeLayout(false);
	}

	// Token: 0x040000D1 RID: 209
	private global::System.ComponentModel.IContainer icontainer_0;

	// Token: 0x040000D2 RID: 210
	private global::System.Windows.Forms.Label resisze_button;

	// Token: 0x040000D3 RID: 211
	private global::System.Windows.Forms.Panel browser_panel;

	// Token: 0x040000D4 RID: 212
	private global::Bunifu.Framework.UI.BunifuElipse bunifuElipse_0;

	// Token: 0x040000D5 RID: 213
	private global::Bunifu.Framework.UI.BunifuFormFadeTransition bunifuFormFadeTransition_0;
}
