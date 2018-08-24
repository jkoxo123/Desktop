// Token: 0x02000015 RID: 21
internal sealed partial class Licenser : global::System.Windows.Forms.Form
{
	// Token: 0x06000076 RID: 118 RVA: 0x00002FBB File Offset: 0x000011BB
	protected override void Dispose(bool disposing)
	{
		if (disposing && this.icontainer_0 != null)
		{
			this.icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	// Token: 0x06000077 RID: 119 RVA: 0x00008748 File Offset: 0x00006948
	private void InitializeComponent()
	{
		this.icontainer_0 = new global::System.ComponentModel.Container();
		global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Licenser));
		this.bunifuDragControl_0 = new global::Bunifu.Framework.UI.BunifuDragControl(this.icontainer_0);
		this.topPanel = new global::System.Windows.Forms.Panel();
		this.close_btn = new global::System.Windows.Forms.PictureBox();
		this.label1 = new global::System.Windows.Forms.Label();
		this.cyberaio_logo = new global::System.Windows.Forms.PictureBox();
		this.bunifuElipse_0 = new global::Bunifu.Framework.UI.BunifuElipse(this.icontainer_0);
		this.status_label = new global::Bunifu.Framework.UI.BunifuCustomLabel();
		this.key_box = new global::Bunifu.Framework.UI.BunifuMetroTextbox();
		this.activate_btn = new global::Bunifu.Framework.UI.BunifuFlatButton();
		this.topPanel.SuspendLayout();
		((global::System.ComponentModel.ISupportInitialize)this.close_btn).BeginInit();
		((global::System.ComponentModel.ISupportInitialize)this.cyberaio_logo).BeginInit();
		base.SuspendLayout();
		this.bunifuDragControl_0.Fixed = true;
		this.bunifuDragControl_0.Horizontal = true;
		this.bunifuDragControl_0.TargetControl = this.topPanel;
		this.bunifuDragControl_0.Vertical = true;
		this.topPanel.Controls.Add(this.close_btn);
		this.topPanel.Controls.Add(this.label1);
		this.topPanel.Controls.Add(this.cyberaio_logo);
		this.topPanel.Dock = global::System.Windows.Forms.DockStyle.Top;
		this.topPanel.Location = new global::System.Drawing.Point(0, 0);
		this.topPanel.Name = "topPanel";
		this.topPanel.Size = new global::System.Drawing.Size(493, 85);
		this.topPanel.TabIndex = 7;
		this.close_btn.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.close_btn.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("close_btn.Image");
		this.close_btn.Location = new global::System.Drawing.Point(456, 8);
		this.close_btn.Name = "close_btn";
		this.close_btn.Size = new global::System.Drawing.Size(27, 28);
		this.close_btn.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.close_btn.TabIndex = 10;
		this.close_btn.TabStop = false;
		this.close_btn.Click += new global::System.EventHandler(this.close_btn_Click);
		this.label1.AutoSize = true;
		this.label1.BackColor = global::System.Drawing.Color.Transparent;
		this.label1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
		this.label1.ForeColor = global::System.Drawing.Color.White;
		this.label1.Location = new global::System.Drawing.Point(168, 53);
		this.label1.Name = "label1";
		this.label1.Size = new global::System.Drawing.Size(162, 13);
		this.label1.TabIndex = 9;
		this.label1.Text = "ACTIVATE YOUR LICENSE";
		this.cyberaio_logo.Cursor = global::System.Windows.Forms.Cursors.Default;
		this.cyberaio_logo.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cyberaio_logo.Image");
		this.cyberaio_logo.Location = new global::System.Drawing.Point(149, 12);
		this.cyberaio_logo.Name = "cyberaio_logo";
		this.cyberaio_logo.Size = new global::System.Drawing.Size(200, 29);
		this.cyberaio_logo.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.cyberaio_logo.TabIndex = 6;
		this.cyberaio_logo.TabStop = false;
		this.bunifuElipse_0.ElipseRadius = 5;
		this.bunifuElipse_0.TargetControl = this;
		this.status_label.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
		this.status_label.ForeColor = global::System.Drawing.SystemColors.ButtonFace;
		this.status_label.ImageAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
		this.status_label.Location = new global::System.Drawing.Point(2, 190);
		this.status_label.Name = "status_label";
		this.status_label.Size = new global::System.Drawing.Size(491, 22);
		this.status_label.TabIndex = 15;
		this.status_label.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
		this.key_box.BorderColorFocused = global::System.Drawing.Color.White;
		this.key_box.BorderColorIdle = global::System.Drawing.Color.White;
		this.key_box.BorderColorMouseHover = global::System.Drawing.Color.White;
		this.key_box.BorderThickness = 3;
		this.key_box.characterCasing = global::System.Windows.Forms.CharacterCasing.Normal;
		this.key_box.Cursor = global::System.Windows.Forms.Cursors.IBeam;
		this.key_box.Font = new global::System.Drawing.Font("Century Gothic", 9.75f);
		this.key_box.ForeColor = global::System.Drawing.Color.Gray;
		this.key_box.isPassword = false;
		this.key_box.Location = new global::System.Drawing.Point(63, 142);
		this.key_box.Margin = new global::System.Windows.Forms.Padding(4);
		this.key_box.MaxLength = 32767;
		this.key_box.Name = "key_box";
		this.key_box.Size = new global::System.Drawing.Size(370, 44);
		this.key_box.TabIndex = 16;
		this.key_box.Text = "Enter your key here";
		this.key_box.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
		this.key_box.Click += new global::System.EventHandler(this.key_box_Enter);
		this.key_box.Enter += new global::System.EventHandler(this.key_box_Enter);
		this.activate_btn.Active = false;
		this.activate_btn.Activecolor = global::System.Drawing.Color.Transparent;
		this.activate_btn.BackColor = global::System.Drawing.Color.Transparent;
		this.activate_btn.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Stretch;
		this.activate_btn.BorderRadius = 0;
		this.activate_btn.ButtonText = "  ACTIVATE";
		this.activate_btn.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.activate_btn.DisabledColor = global::System.Drawing.Color.Gray;
		this.activate_btn.Font = new global::System.Drawing.Font("Verdana", 12f);
		this.activate_btn.Iconcolor = global::System.Drawing.Color.Transparent;
		this.activate_btn.Iconimage = (global::System.Drawing.Image)componentResourceManager.GetObject("activate_btn.Iconimage");
		this.activate_btn.Iconimage_right = null;
		this.activate_btn.Iconimage_right_Selected = null;
		this.activate_btn.Iconimage_Selected = null;
		this.activate_btn.IconMarginLeft = 0;
		this.activate_btn.IconMarginRight = 0;
		this.activate_btn.IconRightVisible = true;
		this.activate_btn.IconRightZoom = 0.0;
		this.activate_btn.IconVisible = true;
		this.activate_btn.IconZoom = 35.0;
		this.activate_btn.IsTab = false;
		this.activate_btn.Location = new global::System.Drawing.Point(149, 216);
		this.activate_btn.Margin = new global::System.Windows.Forms.Padding(5, 4, 5, 4);
		this.activate_btn.Name = "activate_btn";
		this.activate_btn.Normalcolor = global::System.Drawing.Color.Transparent;
		this.activate_btn.OnHovercolor = global::System.Drawing.Color.Transparent;
		this.activate_btn.OnHoverTextColor = global::System.Drawing.Color.FromArgb(43, 184, 115);
		this.activate_btn.selected = false;
		this.activate_btn.Size = new global::System.Drawing.Size(255, 75);
		this.activate_btn.TabIndex = 17;
		this.activate_btn.Text = "  ACTIVATE";
		this.activate_btn.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
		this.activate_btn.Textcolor = global::System.Drawing.Color.FromArgb(43, 184, 115);
		this.activate_btn.TextFont = new global::System.Drawing.Font("Verdana", 12f);
		this.activate_btn.Click += new global::System.EventHandler(this.activate_btn_Click);
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = global::System.Drawing.Color.FromArgb(35, 34, 40);
		base.ClientSize = new global::System.Drawing.Size(493, 304);
		base.Controls.Add(this.activate_btn);
		base.Controls.Add(this.key_box);
		base.Controls.Add(this.status_label);
		base.Controls.Add(this.topPanel);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
		base.Name = "Licenser";
		base.Opacity = 0.0;
		base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "License";
		this.topPanel.ResumeLayout(false);
		this.topPanel.PerformLayout();
		((global::System.ComponentModel.ISupportInitialize)this.close_btn).EndInit();
		((global::System.ComponentModel.ISupportInitialize)this.cyberaio_logo).EndInit();
		base.ResumeLayout(false);
	}

	// Token: 0x04000031 RID: 49
	private global::System.ComponentModel.IContainer icontainer_0;

	// Token: 0x04000032 RID: 50
	private global::Bunifu.Framework.UI.BunifuDragControl bunifuDragControl_0;

	// Token: 0x04000033 RID: 51
	private global::Bunifu.Framework.UI.BunifuElipse bunifuElipse_0;

	// Token: 0x04000034 RID: 52
	private global::System.Windows.Forms.Panel topPanel;

	// Token: 0x04000035 RID: 53
	private global::System.Windows.Forms.Label label1;

	// Token: 0x04000036 RID: 54
	private global::System.Windows.Forms.PictureBox cyberaio_logo;

	// Token: 0x04000037 RID: 55
	private global::System.Windows.Forms.PictureBox close_btn;

	// Token: 0x04000038 RID: 56
	private global::Bunifu.Framework.UI.BunifuCustomLabel status_label;

	// Token: 0x04000039 RID: 57
	private global::Bunifu.Framework.UI.BunifuMetroTextbox key_box;

	// Token: 0x0400003A RID: 58
	private global::Bunifu.Framework.UI.BunifuFlatButton activate_btn;
}
