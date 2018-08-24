using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using EO.Base;
using EO.WebBrowser;

// Token: 0x020000F5 RID: 245
public sealed partial class Startup : Form
{
	// Token: 0x060005C0 RID: 1472 RVA: 0x00031464 File Offset: 0x0002F664
	public Startup(bool bool_0 = true)
	{
		Startup.startup_0 = this;
		Class130.smethod_0();
		new Notification();
		this.method_3(bool_0);
		this.InitializeComponent();
		Application.EnableVisualStyles();
		base.Size = new Size(600, 400);
		EO.WebBrowser.Runtime.AddLicense("Y80M66Xm+8+4iVmXpLHLn1mXwPIP41nr/QEQvFu807/u56vm8fbNn6/c9gQU7qe0psLjrWmZpMDpjEOXpLHLu2jY8P0a9neEjrHLn1mz8wMP5KvA8vcan53Y+PbooWqos8LkrmuntcjNn6zs5tYj76Lp6QTs83aZtcLasHKmtsHct1uX+vYd8qLm8s7NsHCZpMDpjEOXpLHLu6zg6/8M867p6c/42KPf0sDs0WzAvf/v6Y/kuf//qmzIwc7nrqzg6/8M867p6c+4iXWm8PoO5Kfq6c+4iXXj7fQQ7azcwp61n1mXpM0X6Jzc8gQQyJ21t+PcsG2rtsTixnGttMPcr3yzs/0U4p7l9/b043eEjrHLn1mz8PoO5Kfq6fbp06LkpNUM6Kfr8//nrqXg5/YZ8p7cwp61n1mXpA==");
		EO.Base.Runtime.Exception += MainWindow.smethod_2;
		EO.Base.Runtime.InitWorkerProcessExecutable(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CyberAIO\\engine.exe"));
		this.webView_0 = new WebView();
		this.webView_0.Create(base.Handle);
		this.webView_0.LoadHtmlAndWait(Class158.smethod_8());
		this.smethod_20(new System.Action(Startup.Class135.class135_0.method_0));
	}

	// Token: 0x060005C2 RID: 1474 RVA: 0x00031534 File Offset: 0x0002F734
	public static async void smethod_0()
	{
		Startup.startup_0.smethod_21(new System.Action(Startup.Class135.class135_0.method_1));
		await Startup.taskCompletionSource_1.Task;
		Startup.startup_0.webView_0.Dispose();
	}

	// Token: 0x060005C3 RID: 1475 RVA: 0x00031568 File Offset: 0x0002F768
	public async Task method_0()
	{
		await Startup.taskCompletionSource_0.Task;
		this.webView_0.LoadHtml(Class158.smethod_8());
	}

	// Token: 0x060005C4 RID: 1476 RVA: 0x000315B0 File Offset: 0x0002F7B0
	public async Task method_1(string string_1, string string_2)
	{
		await Startup.taskCompletionSource_0.Task;
		this.webView_0.QueueScriptCall(string.Format("document.getElementById('message').innerHTML= '{0}'; document.getElementById('message').style.opacity='1'; document.getElementById('message').style.color = '{1}'", string_1.ToUpper(), string_2));
	}

	// Token: 0x060005C5 RID: 1477 RVA: 0x00031608 File Offset: 0x0002F808
	public async Task method_2()
	{
		if (Startup.taskCompletionSource_0.Task.Status != TaskStatus.WaitingForActivation)
		{
			this.webView_0.QueueScriptCall("document.getElementById('message').style.opacity='0'");
			await Task.Delay(200);
		}
	}

	// Token: 0x060005C6 RID: 1478 RVA: 0x00031650 File Offset: 0x0002F850
	public async void method_3(bool bool_0)
	{
		for (;;)
		{
			int num = 0;
			TaskAwaiter taskAwaiter4;
			try
			{
				GEnum2 genum = (GEnum2)5;
				if (Class130.string_3 != null && Class130.string_3.Length > 5)
				{
					if (bool_0)
					{
						Task<GEnum2> task = Task.Run<GEnum2>(new Func<Task<GEnum2>>(Startup.Class135.class135_0.method_2));
						TaskAwaiter<Task> taskAwaiter = Task.WhenAny(new Task[]
						{
							task,
							this.method_1("Authenticating license", "white")
						}).GetAwaiter();
						if (!taskAwaiter.IsCompleted)
						{
							await taskAwaiter;
							TaskAwaiter<Task> taskAwaiter2;
							taskAwaiter = taskAwaiter2;
							taskAwaiter2 = default(TaskAwaiter<Task>);
						}
						taskAwaiter.GetResult();
						genum = await task;
						task = null;
					}
					else
					{
						TaskAwaiter taskAwaiter3 = this.method_1("Authenticating license", "white").GetAwaiter();
						if (!taskAwaiter3.IsCompleted)
						{
							await taskAwaiter3;
							taskAwaiter3 = taskAwaiter4;
							taskAwaiter4 = default(TaskAwaiter);
						}
						taskAwaiter3.GetResult();
						genum = (GEnum2)0;
					}
				}
				else
				{
					TaskAwaiter taskAwaiter3 = this.method_1("Starting", "white").GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						await taskAwaiter3;
						taskAwaiter3 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter);
					}
					taskAwaiter3.GetResult();
				}
				GEnum2 genum2 = genum;
				if (genum2 == (GEnum2)0)
				{
					await this.method_2();
					await this.method_1(string.Format("Welcome back {0}", (Licenser.class156_0.User != null) ? Licenser.class156_0.User.Split(new char[]
					{
						'#'
					})[0] : string.Empty), "white");
					new MainWindow();
					break;
				}
				if (genum2 != (GEnum2)4)
				{
					TaskAwaiter<bool> taskAwaiter5 = Startup.taskCompletionSource_0.Task.GetAwaiter();
					if (!taskAwaiter5.IsCompleted)
					{
						await taskAwaiter5;
						TaskAwaiter<bool> taskAwaiter6;
						taskAwaiter5 = taskAwaiter6;
						taskAwaiter6 = default(TaskAwaiter<bool>);
					}
					taskAwaiter5.GetResult();
					new Licenser();
					break;
				}
				for (int i = 10; i > 0; i--)
				{
					TaskAwaiter taskAwaiter3 = this.method_1(string.Format("Retrying in {0} seconds", i), "white").GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						await taskAwaiter3;
						taskAwaiter3 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter);
					}
					taskAwaiter3.GetResult();
					taskAwaiter3 = Task.Delay(1000).GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						await taskAwaiter3;
						taskAwaiter3 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter);
					}
					taskAwaiter3.GetResult();
				}
				continue;
			}
			catch
			{
				num = 1;
			}
			if (num != 1)
			{
				break;
			}
			for (int i = 10; i > 0; i--)
			{
				TaskAwaiter taskAwaiter3 = this.method_1(string.Format("Retrying in {0} seconds", i), "white").GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter);
				}
				taskAwaiter3.GetResult();
				taskAwaiter3 = Task.Delay(1000).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter);
				}
				taskAwaiter3.GetResult();
			}
		}
	}

	// Token: 0x04000439 RID: 1081
	public static Startup startup_0;

	// Token: 0x0400043A RID: 1082
	public WebView webView_0;

	// Token: 0x0400043B RID: 1083
	public static string string_0 = string.Empty;

	// Token: 0x0400043C RID: 1084
	private static Timer timer_0 = new Timer();

	// Token: 0x0400043D RID: 1085
	private static Timer timer_1 = new Timer();

	// Token: 0x0400043E RID: 1086
	public static TaskCompletionSource<bool> taskCompletionSource_0 = new TaskCompletionSource<bool>();

	// Token: 0x0400043F RID: 1087
	public static TaskCompletionSource<bool> taskCompletionSource_1 = new TaskCompletionSource<bool>();

	// Token: 0x020000F6 RID: 246
	[Serializable]
	private sealed class Class135
	{
		// Token: 0x060005CB RID: 1483 RVA: 0x000056D4 File Offset: 0x000038D4
		internal void method_0()
		{
			Startup.taskCompletionSource_0.TrySetResult(true);
		}

		// Token: 0x060005CC RID: 1484 RVA: 0x000056E2 File Offset: 0x000038E2
		internal void method_1()
		{
			Startup.taskCompletionSource_1.TrySetResult(true);
		}

		// Token: 0x060005CD RID: 1485 RVA: 0x000056F0 File Offset: 0x000038F0
		internal Task<GEnum2> method_2()
		{
			return Licenser.smethod_6(Class130.string_3, true);
		}

		// Token: 0x04000442 RID: 1090
		public static readonly Startup.Class135 class135_0 = new Startup.Class135();

		// Token: 0x04000443 RID: 1091
		public static System.Action action_0;

		// Token: 0x04000444 RID: 1092
		public static System.Action action_1;

		// Token: 0x04000445 RID: 1093
		public static Func<Task<GEnum2>> func_0;
	}

	// Token: 0x020000F7 RID: 247
	[StructLayout(LayoutKind.Auto)]
	private struct Struct82 : IAsyncStateMachine
	{
		// Token: 0x060005CE RID: 1486 RVA: 0x00031784 File Offset: 0x0002F984
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			try
			{
				TaskAwaiter<bool> taskAwaiter;
				if (num != 0)
				{
					Startup.startup_0.smethod_21(new System.Action(Startup.Class135.class135_0.method_1));
					taskAwaiter = Startup.taskCompletionSource_1.Task.GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 0;
						TaskAwaiter<bool> taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, Startup.Struct82>(ref taskAwaiter, ref this);
						return;
					}
				}
				else
				{
					TaskAwaiter<bool> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<bool>);
					num2 = -1;
				}
				taskAwaiter.GetResult();
				Startup.startup_0.webView_0.Dispose();
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

		// Token: 0x060005CF RID: 1487 RVA: 0x000056FD File Offset: 0x000038FD
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000446 RID: 1094
		public int int_0;

		// Token: 0x04000447 RID: 1095
		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		// Token: 0x04000448 RID: 1096
		private TaskAwaiter<bool> taskAwaiter_0;
	}

	// Token: 0x020000F8 RID: 248
	[StructLayout(LayoutKind.Auto)]
	private struct Struct83 : IAsyncStateMachine
	{
		// Token: 0x060005D0 RID: 1488 RVA: 0x0003186C File Offset: 0x0002FA6C
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Startup startup = this;
			try
			{
				TaskAwaiter taskAwaiter;
				if (num != 0)
				{
					if (Startup.taskCompletionSource_0.Task.Status == TaskStatus.WaitingForActivation)
					{
						goto IL_90;
					}
					startup.webView_0.QueueScriptCall("document.getElementById('message').style.opacity='0'");
					taskAwaiter = Task.Delay(200).GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 0;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Startup.Struct83>(ref taskAwaiter, ref this);
						return;
					}
				}
				else
				{
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					num2 = -1;
				}
				taskAwaiter.GetResult();
				IL_90:;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060005D1 RID: 1489 RVA: 0x0000570B File Offset: 0x0000390B
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000449 RID: 1097
		public int int_0;

		// Token: 0x0400044A RID: 1098
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x0400044B RID: 1099
		public Startup startup_0;

		// Token: 0x0400044C RID: 1100
		private TaskAwaiter taskAwaiter_0;
	}

	// Token: 0x020000F9 RID: 249
	[StructLayout(LayoutKind.Auto)]
	private struct Struct84 : IAsyncStateMachine
	{
		// Token: 0x060005D2 RID: 1490 RVA: 0x00031948 File Offset: 0x0002FB48
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Startup startup = this;
			try
			{
				TaskAwaiter<bool> taskAwaiter;
				if (num != 0)
				{
					taskAwaiter = Startup.taskCompletionSource_0.Task.GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 0;
						TaskAwaiter<bool> taskAwaiter2 = taskAwaiter;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, Startup.Struct84>(ref taskAwaiter, ref this);
						return;
					}
				}
				else
				{
					TaskAwaiter<bool> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<bool>);
					num2 = -1;
				}
				taskAwaiter.GetResult();
				startup.webView_0.QueueScriptCall(string.Format("document.getElementById('message').innerHTML= '{0}'; document.getElementById('message').style.opacity='1'; document.getElementById('message').style.color = '{1}'", string_1.ToUpper(), string_2));
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060005D3 RID: 1491 RVA: 0x00005719 File Offset: 0x00003919
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400044D RID: 1101
		public int int_0;

		// Token: 0x0400044E RID: 1102
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x0400044F RID: 1103
		public Startup startup_0;

		// Token: 0x04000450 RID: 1104
		public string string_0;

		// Token: 0x04000451 RID: 1105
		public string string_1;

		// Token: 0x04000452 RID: 1106
		private TaskAwaiter<bool> taskAwaiter_0;
	}

	// Token: 0x020000FA RID: 250
	[StructLayout(LayoutKind.Auto)]
	private struct Struct85 : IAsyncStateMachine
	{
		// Token: 0x060005D4 RID: 1492 RVA: 0x00031A28 File Offset: 0x0002FC28
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Startup startup = this;
			try
			{
				TaskAwaiter<bool> taskAwaiter;
				if (num != 0)
				{
					taskAwaiter = Startup.taskCompletionSource_0.Task.GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 0;
						TaskAwaiter<bool> taskAwaiter2 = taskAwaiter;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, Startup.Struct85>(ref taskAwaiter, ref this);
						return;
					}
				}
				else
				{
					TaskAwaiter<bool> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<bool>);
					num2 = -1;
				}
				taskAwaiter.GetResult();
				startup.webView_0.LoadHtml(Class158.smethod_8());
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060005D5 RID: 1493 RVA: 0x00005727 File Offset: 0x00003927
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000453 RID: 1107
		public int int_0;

		// Token: 0x04000454 RID: 1108
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000455 RID: 1109
		public Startup startup_0;

		// Token: 0x04000456 RID: 1110
		private TaskAwaiter<bool> taskAwaiter_0;
	}

	// Token: 0x020000FB RID: 251
	[StructLayout(LayoutKind.Auto)]
	private struct Struct86 : IAsyncStateMachine
	{
		// Token: 0x060005D6 RID: 1494 RVA: 0x00031AF0 File Offset: 0x0002FCF0
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Startup startup = this;
			try
			{
				TaskAwaiter taskAwaiter10;
				int num21;
				int num22;
				switch (num)
				{
				case 0:
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
				case 8:
					IL_5E8:
					try
					{
						TaskAwaiter<Task> taskAwaiter7;
						TaskAwaiter<GEnum2> taskAwaiter8;
						TaskAwaiter<bool> taskAwaiter11;
						switch (num)
						{
						case 0:
						{
							taskAwaiter7 = taskAwaiter2;
							taskAwaiter2 = default(TaskAwaiter<Task>);
							int num3 = -1;
							num = -1;
							num2 = num3;
							break;
						}
						case 1:
						{
							TaskAwaiter<GEnum2> taskAwaiter9;
							taskAwaiter8 = taskAwaiter9;
							taskAwaiter9 = default(TaskAwaiter<GEnum2>);
							int num4 = -1;
							num = -1;
							num2 = num4;
							goto IL_290;
						}
						case 2:
						{
							taskAwaiter10 = taskAwaiter4;
							taskAwaiter4 = default(TaskAwaiter);
							int num5 = -1;
							num = -1;
							num2 = num5;
							goto IL_2C4;
						}
						case 3:
						{
							taskAwaiter10 = taskAwaiter4;
							taskAwaiter4 = default(TaskAwaiter);
							int num6 = -1;
							num = -1;
							num2 = num6;
							goto IL_2F0;
						}
						case 4:
						{
							taskAwaiter10 = taskAwaiter4;
							taskAwaiter4 = default(TaskAwaiter);
							int num7 = -1;
							num = -1;
							num2 = num7;
							goto IL_3A7;
						}
						case 5:
						{
							taskAwaiter10 = taskAwaiter4;
							taskAwaiter4 = default(TaskAwaiter);
							int num8 = -1;
							num = -1;
							num2 = num8;
							goto IL_440;
						}
						case 6:
						{
							taskAwaiter10 = taskAwaiter4;
							taskAwaiter4 = default(TaskAwaiter);
							int num9 = -1;
							num = -1;
							num2 = num9;
							goto IL_4C6;
						}
						case 7:
						{
							taskAwaiter10 = taskAwaiter4;
							taskAwaiter4 = default(TaskAwaiter);
							int num10 = -1;
							num = -1;
							num2 = num10;
							goto IL_4E6;
						}
						case 8:
						{
							taskAwaiter11 = taskAwaiter6;
							taskAwaiter6 = default(TaskAwaiter<bool>);
							int num11 = -1;
							num = -1;
							num2 = num11;
							goto IL_569;
						}
						default:
							genum = (GEnum2)5;
							if (Class130.string_3 != null && Class130.string_3.Length > 5)
							{
								if (bool_0)
								{
									task = Task.Run<GEnum2>(new Func<Task<GEnum2>>(Startup.Class135.class135_0.method_2));
									taskAwaiter7 = Task.WhenAny(new Task[]
									{
										task,
										startup.method_1("Authenticating license", "white")
									}).GetAwaiter();
									if (!taskAwaiter7.IsCompleted)
									{
										int num12 = 0;
										num = 0;
										num2 = num12;
										taskAwaiter2 = taskAwaiter7;
										this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<Task>, Startup.Struct86>(ref taskAwaiter7, ref this);
										return;
									}
								}
								else
								{
									taskAwaiter10 = startup.method_1("Authenticating license", "white").GetAwaiter();
									if (!taskAwaiter10.IsCompleted)
									{
										int num13 = 2;
										num = 2;
										num2 = num13;
										taskAwaiter4 = taskAwaiter10;
										this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Startup.Struct86>(ref taskAwaiter10, ref this);
										return;
									}
									goto IL_2C4;
								}
							}
							else
							{
								taskAwaiter10 = startup.method_1("Starting", "white").GetAwaiter();
								if (!taskAwaiter10.IsCompleted)
								{
									int num14 = 3;
									num = 3;
									num2 = num14;
									taskAwaiter4 = taskAwaiter10;
									this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Startup.Struct86>(ref taskAwaiter10, ref this);
									return;
								}
								goto IL_2F0;
							}
							break;
						}
						taskAwaiter7.GetResult();
						taskAwaiter8 = task.GetAwaiter();
						if (!taskAwaiter8.IsCompleted)
						{
							int num15 = 1;
							num = 1;
							num2 = num15;
							TaskAwaiter<GEnum2> taskAwaiter9 = taskAwaiter8;
							this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<GEnum2>, Startup.Struct86>(ref taskAwaiter8, ref this);
							return;
						}
						IL_290:
						GEnum2 genum2 = taskAwaiter8.GetResult();
						genum = genum2;
						task = null;
						goto IL_2F7;
						IL_2C4:
						taskAwaiter10.GetResult();
						genum = (GEnum2)0;
						goto IL_2F7;
						IL_2F0:
						taskAwaiter10.GetResult();
						IL_2F7:
						genum2 = genum;
						if (genum2 != (GEnum2)0)
						{
							if (genum2 == (GEnum2)4)
							{
								i = 10;
								goto IL_48E;
							}
							taskAwaiter11 = Startup.taskCompletionSource_0.Task.GetAwaiter();
							if (!taskAwaiter11.IsCompleted)
							{
								int num16 = 8;
								num = 8;
								num2 = num16;
								taskAwaiter6 = taskAwaiter11;
								this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, Startup.Struct86>(ref taskAwaiter11, ref this);
								return;
							}
							goto IL_569;
						}
						else
						{
							taskAwaiter10 = startup.method_2().GetAwaiter();
							if (!taskAwaiter10.IsCompleted)
							{
								int num17 = 4;
								num = 4;
								num2 = num17;
								taskAwaiter4 = taskAwaiter10;
								this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Startup.Struct86>(ref taskAwaiter10, ref this);
								return;
							}
						}
						IL_3A7:
						taskAwaiter10.GetResult();
						taskAwaiter10 = startup.method_1(string.Format("Welcome back {0}", (Licenser.class156_0.User != null) ? Licenser.class156_0.User.Split(new char[]
						{
							'#'
						})[0] : string.Empty), "white").GetAwaiter();
						if (!taskAwaiter10.IsCompleted)
						{
							int num18 = 5;
							num = 5;
							num2 = num18;
							taskAwaiter4 = taskAwaiter10;
							this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Startup.Struct86>(ref taskAwaiter10, ref this);
							return;
						}
						IL_440:
						taskAwaiter10.GetResult();
						new MainWindow();
						goto IL_64D;
						IL_48E:
						if (i <= 0)
						{
							goto IL_A4;
						}
						taskAwaiter10 = startup.method_1(string.Format("Retrying in {0} seconds", i), "white").GetAwaiter();
						if (!taskAwaiter10.IsCompleted)
						{
							int num19 = 6;
							num = 6;
							num2 = num19;
							taskAwaiter4 = taskAwaiter10;
							this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Startup.Struct86>(ref taskAwaiter10, ref this);
							return;
						}
						IL_4C6:
						taskAwaiter10.GetResult();
						taskAwaiter10 = Task.Delay(1000).GetAwaiter();
						if (!taskAwaiter10.IsCompleted)
						{
							int num20 = 7;
							num = 7;
							num2 = num20;
							taskAwaiter4 = taskAwaiter10;
							this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Startup.Struct86>(ref taskAwaiter10, ref this);
							return;
						}
						IL_4E6:
						taskAwaiter10.GetResult();
						num21 = i;
						i = num21 - 1;
						goto IL_48E;
						IL_569:
						taskAwaiter11.GetResult();
						new Licenser();
						goto IL_64D;
					}
					catch
					{
						num22 = 1;
					}
					if (num22 == 1)
					{
						i = 10;
						goto IL_98;
					}
					goto IL_64D;
				case 9:
				{
					taskAwaiter10 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter);
					int num23 = -1;
					num = -1;
					num2 = num23;
					goto IL_5C3;
				}
				case 10:
				{
					taskAwaiter10 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter);
					int num24 = -1;
					num = -1;
					num2 = num24;
					break;
				}
				default:
					goto IL_A4;
				}
				IL_7F:
				taskAwaiter10.GetResult();
				num21 = i;
				i = num21 - 1;
				IL_98:
				if (i > 0)
				{
					taskAwaiter10 = startup.method_1(string.Format("Retrying in {0} seconds", i), "white").GetAwaiter();
					if (taskAwaiter10.IsCompleted)
					{
						goto IL_5C3;
					}
					int num25 = 9;
					num = 9;
					num2 = num25;
					taskAwaiter4 = taskAwaiter10;
					this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Startup.Struct86>(ref taskAwaiter10, ref this);
					return;
				}
				IL_A4:
				num22 = 0;
				goto IL_5E8;
				IL_5C3:
				taskAwaiter10.GetResult();
				taskAwaiter10 = Task.Delay(1000).GetAwaiter();
				if (!taskAwaiter10.IsCompleted)
				{
					int num26 = 10;
					num = 10;
					num2 = num26;
					taskAwaiter4 = taskAwaiter10;
					this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Startup.Struct86>(ref taskAwaiter10, ref this);
					return;
				}
				goto IL_7F;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncVoidMethodBuilder_0.SetException(exception);
				return;
			}
			IL_64D:
			num2 = -2;
			this.asyncVoidMethodBuilder_0.SetResult();
		}

		// Token: 0x060005D7 RID: 1495 RVA: 0x00005735 File Offset: 0x00003935
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000457 RID: 1111
		public int int_0;

		// Token: 0x04000458 RID: 1112
		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		// Token: 0x04000459 RID: 1113
		public bool bool_0;

		// Token: 0x0400045A RID: 1114
		public Startup startup_0;

		// Token: 0x0400045B RID: 1115
		private GEnum2 genum2_0;

		// Token: 0x0400045C RID: 1116
		private Task<GEnum2> task_0;

		// Token: 0x0400045D RID: 1117
		private TaskAwaiter<Task> taskAwaiter_0;

		// Token: 0x0400045E RID: 1118
		private TaskAwaiter<GEnum2> taskAwaiter_1;

		// Token: 0x0400045F RID: 1119
		private TaskAwaiter taskAwaiter_2;

		// Token: 0x04000460 RID: 1120
		private int int_1;

		// Token: 0x04000461 RID: 1121
		private TaskAwaiter<bool> taskAwaiter_3;
	}
}
