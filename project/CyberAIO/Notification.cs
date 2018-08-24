using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

// Token: 0x02000044 RID: 68
public sealed partial class Notification : Form
{
	// Token: 0x06000157 RID: 343 RVA: 0x0000F568 File Offset: 0x0000D768
	public Notification()
	{
		this.InitializeComponent();
		Notification.notification_0 = this;
		base.TopMost = true;
		Rectangle workingArea = Screen.GetWorkingArea(this);
		base.Location = new Point(workingArea.Right - base.Size.Width - 10, workingArea.Bottom - base.Size.Height - 10);
		base.Hide();
	}

	// Token: 0x06000159 RID: 345 RVA: 0x0000F5D8 File Offset: 0x0000D7D8
	public static Notification smethod_0(string string_1, string string_2, Notification.GEnum0 genum0_0, bool bool_1)
	{
		Notification.Class34 @class = new Notification.Class34();
		@class.genum0_0 = genum0_0;
		@class.string_0 = string_1;
		@class.string_1 = string_2;
		if (Notification.bool_0)
		{
			return null;
		}
		string string_3 = Class108.smethod_17(10);
		Notification.string_0 = string_3;
		Notification.notification_0.Show();
		Notification.smethod_3(new Action(@class.method_0));
		if (bool_1)
		{
			Notification.smethod_1(string_3);
		}
		return Notification.notification_0;
	}

	// Token: 0x0600015A RID: 346 RVA: 0x0000F644 File Offset: 0x0000D844
	public static void smethod_1(string string_1)
	{
		Notification.Class36 @class = new Notification.Class36();
		@class.string_0 = string_1;
		@class.timer_0 = new Timer
		{
			Interval = 3000
		};
		@class.timer_0.Tick += @class.method_0;
		@class.timer_0.Start();
	}

	// Token: 0x0600015B RID: 347 RVA: 0x0000F698 File Offset: 0x0000D898
	public static Timer smethod_2()
	{
		Notification.Class35 @class = new Notification.Class35();
		@class.double_0 = 0.0;
		Notification.notification_0.Opacity = 0.0;
		Notification.timer_0.Stop();
		Notification.timer_0 = new Timer
		{
			Interval = 10
		};
		Notification.timer_0.Tick += @class.method_0;
		Notification.timer_0.Start();
		return Notification.timer_0;
	}

	// Token: 0x0600015C RID: 348 RVA: 0x0000F710 File Offset: 0x0000D910
	public static Timer smethod_3(Action action_0)
	{
		Notification.Class33 @class = new Notification.Class33();
		@class.action_0 = action_0;
		Notification.timer_1.Stop();
		Notification.timer_1 = new Timer
		{
			Interval = 10
		};
		Notification.timer_1.Tick += @class.method_0;
		Notification.timer_1.Start();
		return Notification.timer_1;
	}

	// Token: 0x0600015D RID: 349 RVA: 0x000037FC File Offset: 0x000019FC
	private void close_btn_Click(object sender, EventArgs e)
	{
		Notification.smethod_3(new Action(this.method_0));
	}

	// Token: 0x06000160 RID: 352 RVA: 0x0000382F File Offset: 0x00001A2F
	private void method_0()
	{
		base.Hide();
	}

	// Token: 0x040000E2 RID: 226
	private static Notification notification_0;

	// Token: 0x040000E3 RID: 227
	public static bool bool_0 = false;

	// Token: 0x040000E4 RID: 228
	public static string string_0;

	// Token: 0x040000E5 RID: 229
	public static Timer timer_0 = new Timer();

	// Token: 0x040000E6 RID: 230
	public static Timer timer_1 = new Timer();

	// Token: 0x02000045 RID: 69
	[Serializable]
	private sealed class Class32
	{
		// Token: 0x06000163 RID: 355 RVA: 0x00003843 File Offset: 0x00001A43
		internal void method_0()
		{
			Notification.notification_0.Hide();
		}

		// Token: 0x040000EE RID: 238
		public static readonly Notification.Class32 class32_0 = new Notification.Class32();

		// Token: 0x040000EF RID: 239
		public static Action action_0;
	}

	// Token: 0x02000046 RID: 70
	private sealed class Class33
	{
		// Token: 0x06000165 RID: 357 RVA: 0x0000FBEC File Offset: 0x0000DDEC
		internal void method_0(object sender, EventArgs e)
		{
			if (Notification.notification_0.Opacity <= 0.0)
			{
				Action action = this.action_0;
				if (action != null)
				{
					action();
				}
				Notification.timer_1.Dispose();
				return;
			}
			Notification.notification_0.Opacity -= 0.05;
		}

		// Token: 0x040000F0 RID: 240
		public Action action_0;
	}

	// Token: 0x02000047 RID: 71
	private sealed class Class34
	{
		// Token: 0x06000167 RID: 359 RVA: 0x0000FC44 File Offset: 0x0000DE44
		internal void method_0()
		{
			switch (this.genum0_0)
			{
			case (Notification.GEnum0)0:
				Notification.notification_0.success_logo.Image = Class158.smethod_12();
				break;
			case (Notification.GEnum0)1:
				Notification.notification_0.success_logo.Image = Class158.smethod_10();
				break;
			case (Notification.GEnum0)2:
				Notification.notification_0.success_logo.Image = Class158.smethod_5();
				break;
			case (Notification.GEnum0)3:
				Notification.notification_0.success_logo.Image = Class158.smethod_7();
				break;
			default:
				return;
			}
			Notification.notification_0.title.Text = this.string_0;
			Notification.notification_0.description.Text = this.string_1;
			Notification.smethod_2();
		}

		// Token: 0x040000F1 RID: 241
		public Notification.GEnum0 genum0_0;

		// Token: 0x040000F2 RID: 242
		public string string_0;

		// Token: 0x040000F3 RID: 243
		public string string_1;
	}

	// Token: 0x02000048 RID: 72
	private sealed class Class35
	{
		// Token: 0x06000169 RID: 361 RVA: 0x0000FCF8 File Offset: 0x0000DEF8
		internal void method_0(object sender, EventArgs e)
		{
			if (this.double_0 < 1.0)
			{
				Notification.notification_0.Opacity += 0.05;
				this.double_0 += 0.05;
				return;
			}
			Notification.timer_0.Dispose();
		}

		// Token: 0x040000F4 RID: 244
		public double double_0;
	}

	// Token: 0x02000049 RID: 73
	private sealed class Class36
	{
		// Token: 0x0600016B RID: 363 RVA: 0x0000FD54 File Offset: 0x0000DF54
		internal void method_0(object sender, EventArgs e)
		{
			if (Notification.string_0 == this.string_0 && !Notification.notification_0.ClientRectangle.Contains(Notification.notification_0.PointToClient(Control.MousePosition)))
			{
				Notification.smethod_3(new Action(Notification.Class32.class32_0.method_0));
				return;
			}
			if (Notification.string_0 != this.string_0)
			{
				this.timer_0.Dispose();
			}
		}

		// Token: 0x040000F5 RID: 245
		public string string_0;

		// Token: 0x040000F6 RID: 246
		public Timer timer_0;
	}

	// Token: 0x0200004A RID: 74
	public enum GEnum0
	{

	}
}
