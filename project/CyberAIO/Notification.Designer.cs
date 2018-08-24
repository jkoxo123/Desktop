// Token: 0x02000044 RID: 68
public sealed partial class Notification : global::System.Windows.Forms.Form
{
	// Token: 0x0600015E RID: 350 RVA: 0x00003810 File Offset: 0x00001A10
	protected override void Dispose(bool disposing)
	{
		if (disposing && this.icontainer_0 != null)
		{
			this.icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	// Token: 0x0600015F RID: 351 RVA: 0x0000F76C File Offset: 0x0000D96C
	private void InitializeComponent()
	{
		this.icontainer_0 = new global::System.ComponentModel.Container();
		global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Notification));
		this.bunifuElipse_0 = new global::Bunifu.Framework.UI.BunifuElipse(this.icontainer_0);
		this.success_logo = new global::System.Windows.Forms.PictureBox();
		this.title = new global::Bunifu.Framework.UI.BunifuCustomLabel();
		this.description = new global::Bunifu.Framework.UI.BunifuCustomLabel();
		this.close_btn = new global::System.Windows.Forms.PictureBox();
		this.container = new global::System.Windows.Forms.Panel();
		((global::System.ComponentModel.ISupportInitialize)this.success_logo).BeginInit();
		((global::System.ComponentModel.ISupportInitialize)this.close_btn).BeginInit();
		this.container.SuspendLayout();
		base.SuspendLayout();
		this.bunifuElipse_0.ElipseRadius = 20;
		this.bunifuElipse_0.TargetControl = this;
		this.success_logo.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("success_logo.Image");
		this.success_logo.Location = new global::System.Drawing.Point(2, 2);
		this.success_logo.Name = "success_logo";
		this.success_logo.Size = new global::System.Drawing.Size(87, 66);
		this.success_logo.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.success_logo.TabIndex = 0;
		this.success_logo.TabStop = false;
		this.title.AutoSize = true;
		this.title.Font = new global::System.Drawing.Font("Arial", 15f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
		this.title.ForeColor = global::System.Drawing.Color.White;
		this.title.Location = new global::System.Drawing.Point(94, 10);
		this.title.Name = "title";
		this.title.Size = new global::System.Drawing.Size(266, 24);
		this.title.TabIndex = 1;
		this.title.Text = "Successfully Checked Out!";
		this.description.AutoEllipsis = true;
		this.description.AutoSize = true;
		this.description.Font = new global::System.Drawing.Font("Arial", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
		this.description.ForeColor = global::System.Drawing.Color.FromArgb(194, 194, 194);
		this.description.Location = new global::System.Drawing.Point(96, 42);
		this.description.Name = "description";
		this.description.Size = new global::System.Drawing.Size(134, 16);
		this.description.TabIndex = 2;
		this.description.Text = "Yeezy Boost 350 V2";
		this.close_btn.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.close_btn.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("close_btn.Image");
		this.close_btn.Location = new global::System.Drawing.Point(380, 4);
		this.close_btn.Name = "close_btn";
		this.close_btn.Size = new global::System.Drawing.Size(19, 22);
		this.close_btn.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.close_btn.TabIndex = 3;
		this.close_btn.TabStop = false;
		this.close_btn.Click += new global::System.EventHandler(this.close_btn_Click);
		this.container.Controls.Add(this.success_logo);
		this.container.Controls.Add(this.title);
		this.container.Controls.Add(this.description);
		this.container.Location = new global::System.Drawing.Point(12, 14);
		this.container.Name = "container";
		this.container.Size = new global::System.Drawing.Size(363, 69);
		this.container.TabIndex = 4;
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = global::System.Drawing.Color.FromArgb(22, 21, 26);
		base.ClientSize = new global::System.Drawing.Size(406, 98);
		base.Controls.Add(this.container);
		base.Controls.Add(this.close_btn);
		this.ForeColor = global::System.Drawing.Color.FromArgb(22, 21, 26);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
		base.Name = "Notification";
		base.Opacity = 0.0;
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		this.Text = "Notification";
		((global::System.ComponentModel.ISupportInitialize)this.success_logo).EndInit();
		((global::System.ComponentModel.ISupportInitialize)this.close_btn).EndInit();
		this.container.ResumeLayout(false);
		this.container.PerformLayout();
		base.ResumeLayout(false);
	}

	// Token: 0x040000E7 RID: 231
	private global::System.ComponentModel.IContainer icontainer_0;

	// Token: 0x040000E8 RID: 232
	private global::Bunifu.Framework.UI.BunifuElipse bunifuElipse_0;

	// Token: 0x040000E9 RID: 233
	private global::System.Windows.Forms.PictureBox success_logo;

	// Token: 0x040000EA RID: 234
	private global::System.Windows.Forms.PictureBox close_btn;

	// Token: 0x040000EB RID: 235
	private global::System.Windows.Forms.Panel container;

	// Token: 0x040000EC RID: 236
	public global::Bunifu.Framework.UI.BunifuCustomLabel title;

	// Token: 0x040000ED RID: 237
	public global::Bunifu.Framework.UI.BunifuCustomLabel description;
}
