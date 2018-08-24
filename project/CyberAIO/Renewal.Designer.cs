// Token: 0x0200006C RID: 108
internal sealed partial class Renewal : global::System.Windows.Forms.Form
{
	// Token: 0x060001F5 RID: 501 RVA: 0x00003CBC File Offset: 0x00001EBC
	protected override void Dispose(bool disposing)
	{
		if (disposing && this.icontainer_0 != null)
		{
			this.icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	// Token: 0x060001F6 RID: 502 RVA: 0x000125C8 File Offset: 0x000107C8
	private void InitializeComponent()
	{
		global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Renewal));
		base.SuspendLayout();
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new global::System.Drawing.Size(620, 615);
		base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
		base.Name = "Renewal";
		this.Text = "Renew License";
		base.ResumeLayout(false);
	}

	// Token: 0x0400014B RID: 331
	private global::System.ComponentModel.IContainer icontainer_0;
}
