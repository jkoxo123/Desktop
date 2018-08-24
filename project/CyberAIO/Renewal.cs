using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using EO.WebBrowser;

// Token: 0x0200006C RID: 108
internal sealed partial class Renewal : Form
{
	// Token: 0x060001F0 RID: 496 RVA: 0x000124F8 File Offset: 0x000106F8
	public Renewal(string string_0)
	{
		this.InitializeComponent();
		this.webView_0 = new WebView();
		this.webView_0.Create(base.Handle);
		this.webView_0.BeforeContextMenu += this.method_0;
		this.webView_0.LoadUrlAndWait(string_0);
		this.method_1();
	}

	// Token: 0x060001F1 RID: 497 RVA: 0x000036D3 File Offset: 0x000018D3
	private void method_0(object sender, BeforeContextMenuEventArgs e)
	{
		e.Menu.Items.Clear();
	}

	// Token: 0x060001F2 RID: 498 RVA: 0x00012558 File Offset: 0x00010758
	private async void method_1()
	{
		try
		{
			while (Renewal.form_0 != null && !this.webView_0.GetHtml().Contains("paid-text"))
			{
				TaskAwaiter taskAwaiter = Task.Delay(1000).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter.GetResult();
			}
			MainWindow.webView_0.QueueScriptCall("swal('Success', 'Your license renewal is being processed. Please wait up to 2h.', 'Success')");
		}
		catch
		{
		}
	}

	// Token: 0x060001F3 RID: 499 RVA: 0x00003CA4 File Offset: 0x00001EA4
	protected override void OnFormClosing(FormClosingEventArgs e)
	{
		base.OnFormClosing(e);
		if (e.CloseReason == CloseReason.UserClosing)
		{
			Renewal.form_0 = null;
		}
	}

	// Token: 0x060001F4 RID: 500 RVA: 0x00012594 File Offset: 0x00010794
	public static async void smethod_0(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		if (Renewal.form_0 == null)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary["hosted_button_id"] = "Z8ZSS4MJ7XD72";
			dictionary["cmd"] = "_s-xclick";
			dictionary["on0"] = "License Key";
			dictionary["os0"] = Licenser.class156_0.Key;
			TaskAwaiter<HttpResponseMessage> taskAwaiter = new Class14(null, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36", 10, false, true, null).method_3("https://www.paypal.com/cgi-bin/webscr", dictionary, false).GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<HttpResponseMessage> taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
			}
			Renewal.form_0 = new Renewal(taskAwaiter.GetResult().Headers.Location.ToString());
			Renewal.form_0.Show();
			MainWindow.webView_0.QueueScriptCall("swal('PayPal Opened', 'A PayPal browser has appeared, please complete the payment.', 'success', {timer: 3000})");
		}
		else
		{
			Renewal.form_0.WindowState = FormWindowState.Normal;
			Renewal.form_0.BringToFront();
		}
	}

	// Token: 0x04000149 RID: 329
	public static Form form_0;

	// Token: 0x0400014A RID: 330
	public WebView webView_0;

	// Token: 0x0200006D RID: 109
	[StructLayout(LayoutKind.Auto)]
	private struct Struct36 : IAsyncStateMachine
	{
		// Token: 0x060001F7 RID: 503 RVA: 0x00012650 File Offset: 0x00010850
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Renewal renewal = this;
			try
			{
				try
				{
					TaskAwaiter taskAwaiter3;
					if (num == 0)
					{
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_66;
					}
					IL_2F:
					if (Renewal.form_0 == null || renewal.webView_0.GetHtml().Contains("paid-text"))
					{
						MainWindow.webView_0.QueueScriptCall("swal('Success', 'Your license renewal is being processed. Please wait up to 2h.', 'Success')");
						goto IL_A4;
					}
					taskAwaiter3 = Task.Delay(1000).GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						num2 = 0;
						taskAwaiter2 = taskAwaiter3;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Renewal.Struct36>(ref taskAwaiter3, ref this);
						return;
					}
					IL_66:
					taskAwaiter3.GetResult();
					goto IL_2F;
				}
				catch
				{
				}
				IL_A4:;
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

		// Token: 0x060001F8 RID: 504 RVA: 0x00003CDB File Offset: 0x00001EDB
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400014C RID: 332
		public int int_0;

		// Token: 0x0400014D RID: 333
		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		// Token: 0x0400014E RID: 334
		public Renewal renewal_0;

		// Token: 0x0400014F RID: 335
		private TaskAwaiter taskAwaiter_0;
	}

	// Token: 0x0200006E RID: 110
	[StructLayout(LayoutKind.Auto)]
	private struct Struct37 : IAsyncStateMachine
	{
		// Token: 0x060001F9 RID: 505 RVA: 0x0001274C File Offset: 0x0001094C
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			try
			{
				TaskAwaiter<HttpResponseMessage> taskAwaiter3;
				if (num != 0)
				{
					if (Renewal.form_0 != null)
					{
						Renewal.form_0.WindowState = FormWindowState.Normal;
						Renewal.form_0.BringToFront();
						goto IL_11D;
					}
					Dictionary<string, string> dictionary = new Dictionary<string, string>();
					dictionary["hosted_button_id"] = "Z8ZSS4MJ7XD72";
					dictionary["cmd"] = "_s-xclick";
					dictionary["on0"] = "License Key";
					dictionary["os0"] = Licenser.class156_0.Key;
					taskAwaiter3 = new Class14(null, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36", 10, false, true, null).method_3("https://www.paypal.com/cgi-bin/webscr", dictionary, false).GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						num2 = 0;
						taskAwaiter2 = taskAwaiter3;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Renewal.Struct37>(ref taskAwaiter3, ref this);
						return;
					}
				}
				else
				{
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
					num2 = -1;
				}
				Renewal.form_0 = new Renewal(taskAwaiter3.GetResult().Headers.Location.ToString());
				Renewal.form_0.Show();
				MainWindow.webView_0.QueueScriptCall("swal('PayPal Opened', 'A PayPal browser has appeared, please complete the payment.', 'success', {timer: 3000})");
				IL_11D:;
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

		// Token: 0x060001FA RID: 506 RVA: 0x00003CE9 File Offset: 0x00001EE9
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000150 RID: 336
		public int int_0;

		// Token: 0x04000151 RID: 337
		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		// Token: 0x04000152 RID: 338
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;
	}
}
