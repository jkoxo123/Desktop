using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using EO.Base;
using EO.WebBrowser;
using EO.WebEngine;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;

// Token: 0x0200003C RID: 60
internal sealed partial class MainWindow : Form
{
	// Token: 0x0600012A RID: 298 RVA: 0x0000E4C8 File Offset: 0x0000C6C8
	public MainWindow()
	{
		this.InitializeComponent();
		MainWindow.mainWindow_0 = this;
		BrowserOptions options = new BrowserOptions
		{
			EnableWebSecurity = new bool?(false),
			LoadImages = new bool?(true)
		};
		MainWindow.webView_0.SetOptions(options);
		MainWindow.webView_0.Engine = Engine.Create("CyberAIO");
		MainWindow.webView_0.Create(this.browser_panel.Handle);
		MainWindow.webView_0.BeforeContextMenu += this.method_5;
		MainWindow.webView_0.NewWindow += this.method_0;
		MainWindow.webView_0.RegisterJSExtensionFunction("formDrag", new JSExtInvokeHandler(this.method_8));
		MainWindow.webView_0.RegisterJSExtensionFunction("CloseApplication", new JSExtInvokeHandler(this.method_4));
		MainWindow.webView_0.RegisterJSExtensionFunction("MinimizeApplication", new JSExtInvokeHandler(this.method_6));
		MainWindow.webView_0.RegisterJSExtensionFunction("OpenCaptchaQueue", new JSExtInvokeHandler(MainWindow.smethod_1));
		MainWindow.webView_0.RegisterJSExtensionFunction("CheckForUpdates", new JSExtInvokeHandler(MainWindow.Class28.class28_0.method_0));
		MainWindow.webView_0.RegisterJSExtensionFunction("StartUpdate", new JSExtInvokeHandler(Class5.smethod_3));
		MainWindow.webView_0.RegisterJSExtensionFunction("Renew", new JSExtInvokeHandler(Renewal.smethod_0));
		MainWindow.webView_0.RegisterJSExtensionFunction("ContactSupport", new JSExtInvokeHandler(Class1.smethod_12));
		MainWindow.webView_0.RegisterJSExtensionFunction("ResetKey", new JSExtInvokeHandler(Class1.smethod_13));
		MainWindow.webView_0.RegisterJSExtensionFunction("SaveSettings", new JSExtInvokeHandler(Class1.smethod_11));
		MainWindow.webView_0.RegisterJSExtensionFunction("setProfiles", new JSExtInvokeHandler(Class1.smethod_5));
		MainWindow.webView_0.RegisterJSExtensionFunction("setTasks", new JSExtInvokeHandler(Class1.smethod_6));
		MainWindow.webView_0.RegisterJSExtensionFunction("setProxies", new JSExtInvokeHandler(Class1.smethod_7));
		MainWindow.webView_0.RegisterJSExtensionFunction("ExportAll", new JSExtInvokeHandler(Class1.smethod_14));
		MainWindow.webView_0.RegisterJSExtensionFunction("ImportAll", new JSExtInvokeHandler(Class1.smethod_15));
		MainWindow.webView_0.RegisterJSExtensionFunction("showLogs", new JSExtInvokeHandler(Class1.smethod_4));
		MainWindow.webView_0.RegisterJSExtensionFunction("setMassLink", new JSExtInvokeHandler(Class1.smethod_0));
		MainWindow.webView_0.RegisterJSExtensionFunction("open_file_import", new JSExtInvokeHandler(Class169.smethod_0));
		MainWindow.webView_0.RegisterJSExtensionFunction("open_file_export", new JSExtInvokeHandler(Class169.smethod_1));
		MainWindow.webView_0.RegisterJSExtensionFunction("startTask", new JSExtInvokeHandler(Class26.smethod_0));
		MainWindow.webView_0.RegisterJSExtensionFunction("stopTask", new JSExtInvokeHandler(Class26.smethod_2));
		MainWindow.webView_0.RegisterJSExtensionFunction("testProxy", new JSExtInvokeHandler(Class189.smethod_1));
		MainWindow.webView_0.RegisterJSExtensionFunction("testAllProxies", new JSExtInvokeHandler(Class189.smethod_0));
		this.method_1();
	}

	// Token: 0x0600012C RID: 300 RVA: 0x00003670 File Offset: 0x00001870
	private void method_0(object sender, NewWindowEventArgs e)
	{
		Process.Start(e.TargetUrl);
	}

	// Token: 0x0600012D RID: 301 RVA: 0x0000E7F8 File Offset: 0x0000C9F8
	public async void method_1()
	{
		Class130.jobject_1 = JObject.Parse(Class158.smethod_9());
		MainWindow.webView_0.LoadHtmlAndWait(this.method_3(Class158.smethod_6()));
		this.method_2();
		Class1.smethod_2();
		await Class1.smethod_8();
		await Class1.smethod_9();
		await Class1.smethod_10();
		MainWindow.captchaQueue_0 = new CaptchaQueue(true);
		Class5.smethod_1(false);
		this.smethod_20(new System.Action(MainWindow.Class28.class28_0.method_1));
		bool isAttached = Debugger.IsAttached;
		Licenser.smethod_5();
		Class130.jobject_0 = JObject.Parse(MainWindow.webView_0.QueueScriptCall("JSON.stringify(window.Countries)").smethod_0());
		new Class60().method_0();
		MainWindow.taskCompletionSource_0.TrySetResult(true);
	}

	// Token: 0x0600012E RID: 302 RVA: 0x0000E834 File Offset: 0x0000CA34
	public void method_2()
	{
		if (Screen.PrimaryScreen.WorkingArea.Height < 850)
		{
			Size size = new Size(Screen.PrimaryScreen.WorkingArea.Width - 15, Screen.PrimaryScreen.WorkingArea.Height - 10);
			base.Size = size;
			this.browser_panel.Size = new Size(size.Width - 5, size.Height - 5);
			this.MinimumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width - 25, Screen.PrimaryScreen.WorkingArea.Height - 20);
			MainWindow.webView_0.ZoomFactor = 0.75;
			return;
		}
		Size size2 = new Size(1400, 850);
		base.Size = size2;
		this.browser_panel.Size = new Size(size2.Width - 5, size2.Height - 5);
		this.MinimumSize = new Size(1350, 850);
	}

	// Token: 0x0600012F RID: 303 RVA: 0x0000E950 File Offset: 0x0000CB50
	public string method_3(string string_1)
	{
		HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
		htmlDocument.LoadHtml(string_1);
		string text = string.Empty;
		foreach (KeyValuePair<string, JToken> keyValuePair in Class130.jobject_1)
		{
			text += string.Format("<option value='{0}'>{1}</option>", keyValuePair.Key, keyValuePair.Key);
		}
		string str = "<option></option>";
		foreach (string text2 in MainWindow.string_0)
		{
			str += string.Format("<option value='{0}'>{1}</option>", text2, text2);
		}
		htmlDocument.DocumentNode.SelectSingleNode("//optgroup[@label='Shopify']").InnerHtml = text;
		string innerHtml = str + htmlDocument.DocumentNode.SelectSingleNode("//select[@id='store-dropdown']").InnerHtml;
		htmlDocument.DocumentNode.SelectSingleNode("//select[@id='store-dropdown']").InnerHtml = innerHtml;
		return htmlDocument.DocumentNode.InnerHtml;
	}

	// Token: 0x06000130 RID: 304 RVA: 0x0000EA5C File Offset: 0x0000CC5C
	public static void smethod_0()
	{
		if (MainWindow.taskCompletionSource_0.Task.Status == TaskStatus.WaitingForActivation)
		{
			return;
		}
		MethodInvoker method = new MethodInvoker(MainWindow.Class28.class28_0.method_2);
		MainWindow.mainWindow_0.BeginInvoke(method);
	}

	// Token: 0x06000131 RID: 305 RVA: 0x0000367E File Offset: 0x0000187E
	protected override void OnFormClosing(FormClosingEventArgs e)
	{
		this.method_4(null, null);
		base.OnFormClosing(e);
	}

	// Token: 0x06000132 RID: 306 RVA: 0x0000368F File Offset: 0x0000188F
	public static void smethod_1(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		MainWindow.captchaQueue_0.Show();
		MainWindow.captchaQueue_0.WindowState = FormWindowState.Normal;
		MainWindow.captchaQueue_0.BringToFront();
	}

	// Token: 0x06000133 RID: 307 RVA: 0x000036B0 File Offset: 0x000018B0
	public void method_4(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		MainWindow.captchaQueue_0.method_2();
		MainWindow.mainWindow_0.BeginInvoke(null, null);
		Process.GetCurrentProcess().Kill();
	}

	// Token: 0x06000134 RID: 308 RVA: 0x000036D3 File Offset: 0x000018D3
	private void method_5(object sender, BeforeContextMenuEventArgs e)
	{
		e.Menu.Items.Clear();
	}

	// Token: 0x06000135 RID: 309 RVA: 0x000036E5 File Offset: 0x000018E5
	public static void smethod_2(object sender, ExceptionEventArgs e)
	{
		GClass3.smethod_0(e.ErrorException.Message, "Webview Error");
	}

	// Token: 0x06000136 RID: 310 RVA: 0x000036FD File Offset: 0x000018FD
	public void method_6(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		base.WindowState = FormWindowState.Minimized;
	}

	// Token: 0x06000139 RID: 313
	[DllImport("user32.dll")]
	private static extern IntPtr GetForegroundWindow();

	// Token: 0x0600013A RID: 314 RVA: 0x00003725 File Offset: 0x00001925
	public bool method_7(IntPtr intptr_0)
	{
		return MainWindow.GetForegroundWindow() == intptr_0;
	}

	// Token: 0x0600013B RID: 315 RVA: 0x00003732 File Offset: 0x00001932
	private void method_8(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		if (this.method_7(base.Handle))
		{
			MainWindow.ReleaseCapture();
			MainWindow.SendMessage(base.Handle, 161, 2, 0);
		}
	}

	// Token: 0x0600013C RID: 316
	[DllImport("user32.dll")]
	public static extern int SendMessage(IntPtr intptr_0, int int_0, int int_1, int int_2);

	// Token: 0x0600013D RID: 317
	[DllImport("user32.dll")]
	public static extern bool ReleaseCapture();

	// Token: 0x0600013E RID: 318 RVA: 0x0000ECAC File Offset: 0x0000CEAC
	protected override void WndProc(ref Message m)
	{
		if (m.Msg != 132)
		{
			if (m.Msg == Class133.int_0)
			{
				MainWindow.smethod_0();
			}
			base.WndProc(ref m);
			return;
		}
		int x = (int)(m.LParam.ToInt64() & 65535L);
		int y = (int)((m.LParam.ToInt64() & 4294901760L) >> 16);
		Point point = base.PointToClient(new Point(x, y));
		Size clientSize = base.ClientSize;
		if (point.X >= clientSize.Width - 16 && point.Y >= clientSize.Height - 16 && clientSize.Height >= 16)
		{
			m.Result = (IntPtr)(base.IsMirrored ? 16 : 17);
			return;
		}
		if (point.X <= 16 && point.Y >= clientSize.Height - 16 && clientSize.Height >= 16)
		{
			m.Result = (IntPtr)(base.IsMirrored ? 17 : 16);
			return;
		}
		if (point.X <= 16 && point.Y <= 16 && clientSize.Height >= 16)
		{
			m.Result = (IntPtr)(base.IsMirrored ? 14 : 13);
			return;
		}
		if (point.X >= clientSize.Width - 16 && point.Y <= 16 && clientSize.Height >= 16)
		{
			m.Result = (IntPtr)(base.IsMirrored ? 13 : 14);
			return;
		}
		if (point.Y <= 16 && clientSize.Height >= 16)
		{
			m.Result = (IntPtr)12;
			return;
		}
		if (point.Y >= clientSize.Height - 16 && clientSize.Height >= 16)
		{
			m.Result = (IntPtr)15;
			return;
		}
		if (point.X <= 16 && clientSize.Height >= 16)
		{
			m.Result = (IntPtr)10;
			return;
		}
		if (point.X >= clientSize.Width - 16 && clientSize.Height >= 16)
		{
			m.Result = (IntPtr)11;
		}
	}

	// Token: 0x0600013F RID: 319 RVA: 0x0000375B File Offset: 0x0000195B
	private void method_9()
	{
		base.Hide();
		MainWindow.webView_0.Close(true);
	}

	// Token: 0x040000CA RID: 202
	public static string[] string_0 = new string[]
	{
		"Off-White"
	};

	// Token: 0x040000CB RID: 203
	public static WebView webView_0 = new WebView();

	// Token: 0x040000CC RID: 204
	public static CaptchaQueue captchaQueue_0;

	// Token: 0x040000CD RID: 205
	public static Random random_0 = new Random();

	// Token: 0x040000CE RID: 206
	public static MainWindow mainWindow_0;

	// Token: 0x040000CF RID: 207
	public static TaskCompletionSource<bool> taskCompletionSource_0 = new TaskCompletionSource<bool>();

	// Token: 0x040000D0 RID: 208
	private readonly Timer timer_0 = new Timer();

	// Token: 0x0200003D RID: 61
	[Serializable]
	private sealed class Class28
	{
		// Token: 0x06000142 RID: 322 RVA: 0x0000377A File Offset: 0x0000197A
		internal void method_0(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
		{
			Class5.smethod_1(true);
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00003782 File Offset: 0x00001982
		internal void method_1()
		{
			Startup.smethod_0();
		}

		// Token: 0x06000144 RID: 324 RVA: 0x0000EEDC File Offset: 0x0000D0DC
		internal void method_2()
		{
			if (MainWindow.mainWindow_0.WindowState == FormWindowState.Minimized)
			{
				MainWindow.mainWindow_0.WindowState = FormWindowState.Normal;
				return;
			}
			bool topMost = MainWindow.mainWindow_0.TopMost;
			MainWindow.mainWindow_0.TopMost = true;
			MainWindow.mainWindow_0.TopMost = topMost;
		}

		// Token: 0x040000D6 RID: 214
		public static readonly MainWindow.Class28 class28_0 = new MainWindow.Class28();

		// Token: 0x040000D7 RID: 215
		public static JSExtInvokeHandler jsextInvokeHandler_0;

		// Token: 0x040000D8 RID: 216
		public static System.Action action_0;

		// Token: 0x040000D9 RID: 217
		public static MethodInvoker methodInvoker_0;
	}

	// Token: 0x0200003E RID: 62
	[StructLayout(LayoutKind.Auto)]
	private struct Struct24 : IAsyncStateMachine
	{
		// Token: 0x06000145 RID: 325 RVA: 0x0000EF24 File Offset: 0x0000D124
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			MainWindow mainWindow = this;
			try
			{
				TaskAwaiter taskAwaiter;
				switch (num)
				{
				case 0:
				{
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					num2 = -1;
					break;
				}
				case 1:
				{
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					num2 = -1;
					goto IL_FC;
				}
				case 2:
				{
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					num2 = -1;
					goto IL_156;
				}
				default:
					Class130.jobject_1 = JObject.Parse(Class158.smethod_9());
					MainWindow.webView_0.LoadHtmlAndWait(mainWindow.method_3(Class158.smethod_6()));
					mainWindow.method_2();
					Class1.smethod_2();
					taskAwaiter = Class1.smethod_8().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 0;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, MainWindow.Struct24>(ref taskAwaiter, ref this);
						return;
					}
					break;
				}
				taskAwaiter.GetResult();
				taskAwaiter = Class1.smethod_9().GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					num2 = 1;
					TaskAwaiter taskAwaiter2 = taskAwaiter;
					this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, MainWindow.Struct24>(ref taskAwaiter, ref this);
					return;
				}
				IL_FC:
				taskAwaiter.GetResult();
				taskAwaiter = Class1.smethod_10().GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					num2 = 2;
					TaskAwaiter taskAwaiter2 = taskAwaiter;
					this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, MainWindow.Struct24>(ref taskAwaiter, ref this);
					return;
				}
				IL_156:
				taskAwaiter.GetResult();
				MainWindow.captchaQueue_0 = new CaptchaQueue(true);
				Class5.smethod_1(false);
				mainWindow.smethod_20(new System.Action(MainWindow.Class28.class28_0.method_1));
				bool isAttached = Debugger.IsAttached;
				Licenser.smethod_5();
				Class130.jobject_0 = JObject.Parse(MainWindow.webView_0.QueueScriptCall("JSON.stringify(window.Countries)").smethod_0());
				new Class60().method_0();
				MainWindow.taskCompletionSource_0.TrySetResult(true);
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncVoidMethodBuilder_0.SetException(exception);
				return;
			}
			num2 = -2;
			this.asyncVoidMethodBuilder_0.SetResult();
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00003789 File Offset: 0x00001989
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040000DA RID: 218
		public int int_0;

		// Token: 0x040000DB RID: 219
		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		// Token: 0x040000DC RID: 220
		public MainWindow mainWindow_0;

		// Token: 0x040000DD RID: 221
		private TaskAwaiter taskAwaiter_0;
	}
}
