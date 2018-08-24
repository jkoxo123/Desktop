using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using WebSocketSharp;

// Token: 0x02000071 RID: 113
internal sealed class Class60
{
	// Token: 0x0600020C RID: 524 RVA: 0x00003D97 File Offset: 0x00001F97
	public Class60()
	{
		Class60.webSocket_0 = new WebSocket(string.Format("wss://{0}/api/license/{1}/connect?token={2}", "cybersole.io", Class130.string_3, "94112421582745227130"), Array.Empty<string>());
	}

	// Token: 0x0600020D RID: 525 RVA: 0x00003DC7 File Offset: 0x00001FC7
	public void method_0()
	{
		Class60.webSocket_0.OnMessage += this.method_2;
		Class60.webSocket_0.ConnectAsync();
		this.method_1();
	}

	// Token: 0x0600020E RID: 526 RVA: 0x00003DEF File Offset: 0x00001FEF
	public static void smethod_0(JObject jobject_0)
	{
		jobject_0["license"] = Class130.string_3;
		Class60.webSocket_0.SendAsync(jobject_0.ToString(), null);
	}

	// Token: 0x0600020F RID: 527 RVA: 0x00012AFC File Offset: 0x00010CFC
	private void method_1()
	{
		Class60.Struct38 @struct;
		@struct.asyncVoidMethodBuilder_0 = AsyncVoidMethodBuilder.Create();
		@struct.int_0 = -1;
		AsyncVoidMethodBuilder asyncVoidMethodBuilder_ = @struct.asyncVoidMethodBuilder_0;
		asyncVoidMethodBuilder_.Start<Class60.Struct38>(ref @struct);
	}

	// Token: 0x06000210 RID: 528 RVA: 0x00012B30 File Offset: 0x00010D30
	private void method_2(object sender, MessageEventArgs e)
	{
		try
		{
			JObject jobject = JObject.Parse(e.Data);
			MainWindow.smethod_0();
			if (jobject.ContainsKey("quicktask"))
			{
				Class170.smethod_0(jobject["quicktask"].ToString(), (string)jobject["id"]);
			}
			if (jobject.ContainsKey("stop"))
			{
				Class170.smethod_1(jobject["stop"].ToString());
			}
			if (jobject.ContainsKey("stopall"))
			{
				Class26.smethod_3(Class130.jobject_3);
			}
			if (jobject.ContainsKey("startall"))
			{
				Class26.smethod_1(Class130.jobject_3, null);
			}
			if (jobject.ContainsKey("linkchange"))
			{
				Class1.smethod_1(jobject["linkchange"].ToString());
			}
			if (jobject.ContainsKey("message"))
			{
				MainWindow.webView_0.QueueScriptCall(string.Format("swal('Message', '{0}', 'info')", jobject["message"].ToString().smethod_8()));
			}
			if (jobject.ContainsKey("reset"))
			{
				Class130.string_3 = null;
				Class130.smethod_1();
				MainWindow.mainWindow_0.method_4(null, null);
			}
			if (jobject.ContainsKey("close"))
			{
				MainWindow.mainWindow_0.method_4(null, null);
			}
		}
		catch
		{
		}
	}

	// Token: 0x04000156 RID: 342
	private static WebSocket webSocket_0;

	// Token: 0x02000072 RID: 114
	[StructLayout(LayoutKind.Auto)]
	private struct Struct38 : IAsyncStateMachine
	{
		// Token: 0x06000211 RID: 529 RVA: 0x00012C88 File Offset: 0x00010E88
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = this.taskAwaiter_0;
					this.taskAwaiter_0 = default(TaskAwaiter);
					this.int_0 = -1;
					goto IL_68;
				}
				IL_28:
				if (Class60.webSocket_0.ReadyState == 3)
				{
					GClass3.smethod_0("Connection to server lost, attempting to reconnect...", "Websocket");
					Class60.webSocket_0.ConnectAsync();
				}
				awaiter = Task.Delay(10000).GetAwaiter();
				if (!awaiter.IsCompleted)
				{
					this.int_0 = 0;
					this.taskAwaiter_0 = awaiter;
					this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class60.Struct38>(ref awaiter, ref this);
					return;
				}
				IL_68:
				awaiter.GetResult();
				goto IL_28;
			}
			catch (Exception exception)
			{
				this.int_0 = -2;
				this.asyncVoidMethodBuilder_0.SetException(exception);
			}
		}

		// Token: 0x06000212 RID: 530 RVA: 0x00003E17 File Offset: 0x00002017
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000157 RID: 343
		public int int_0;

		// Token: 0x04000158 RID: 344
		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		// Token: 0x04000159 RID: 345
		private TaskAwaiter taskAwaiter_0;
	}
}
