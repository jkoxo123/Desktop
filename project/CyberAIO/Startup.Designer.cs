// Token: 0x020000F5 RID: 245
public sealed partial class Startup : global::System.Windows.Forms.Form
{
	// Token: 0x060005C7 RID: 1479 RVA: 0x000056A9 File Offset: 0x000038A9
	protected override void Dispose(bool disposing)
	{
		if (disposing && this.icontainer_0 != null)
		{
			this.icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	// Token: 0x060005C8 RID: 1480 RVA: 0x00031694 File Offset: 0x0002F894
	private void InitializeComponent()
	{
		this.icontainer_0 = new global::System.ComponentModel.Container();
		global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Startup));
		this.bunifuElipse_0 = new global::Bunifu.Framework.UI.BunifuElipse(this.icontainer_0);
		base.SuspendLayout();
		this.bunifuElipse_0.ElipseRadius = 10;
		this.bunifuElipse_0.TargetControl = this;
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new global::System.Drawing.Size(910, 583);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
		this.MinimumSize = new global::System.Drawing.Size(652, 322);
		base.Name = "Startup";
		base.Opacity = 0.0;
		base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Loading";
		base.ResumeLayout(false);
	}

	// Token: 0x04000440 RID: 1088
	private global::System.ComponentModel.IContainer icontainer_0;

	// Token: 0x04000441 RID: 1089
	private global::Bunifu.Framework.UI.BunifuElipse bunifuElipse_0;
}
