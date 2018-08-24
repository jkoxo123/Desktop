using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using EO.WebBrowser;
using Newtonsoft.Json.Linq;

// Token: 0x02000004 RID: 4
internal sealed class Class1
{
	// Token: 0x06000013 RID: 19 RVA: 0x00002C2D File Offset: 0x00000E2D
	public static void smethod_0(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		Class1.smethod_1(jsextInvokeArgs_0.Arguments.First<object>().ToString());
	}

	// Token: 0x06000014 RID: 20 RVA: 0x00006DA0 File Offset: 0x00004FA0
	public static void smethod_1(string string_0)
	{
		Class130.string_0 = string_0;
		JObject jobject = JObject.Parse(MainWindow.webView_0.QueueScriptCall("JSON.stringify(tasks)").smethod_0());
		foreach (KeyValuePair<string, JToken> keyValuePair in jobject)
		{
			if (Class130.jobject_1.ContainsKey(keyValuePair.Value["store"].ToString()) && Class130.string_0.Replace("www.", string.Empty).Contains(new Uri(Class130.jobject_1[keyValuePair.Value["store"].ToString()]["sitemap"].ToString().Replace("www.", string.Empty)).Host))
			{
				MainWindow.webView_0.QueueScriptCall(string.Format("updateTable('{0}','#c2c2c2',{1},2)", Class130.string_0.smethod_8(), keyValuePair.Value["id"].ToString()));
				keyValuePair.Value["keywords"] = Class130.string_0;
			}
		}
		MainWindow.webView_0.QueueScriptCall(string.Format("tasks = JSON.parse('{0}')", jobject.ToString().smethod_8()));
	}

	// Token: 0x06000015 RID: 21 RVA: 0x00006F00 File Offset: 0x00005100
	public static void smethod_2()
	{
		Version version = Assembly.GetEntryAssembly().GetName().Version;
		MainWindow.webView_0.QueueScriptCall(string.Format("$('#keyinput').val('{0}')", Class130.string_3));
		MainWindow.webView_0.QueueScriptCall(string.Format("$('#version-number')[0].innerHTML = '{0}'", version));
		MainWindow.webView_0.QueueScriptCall(string.Format("$('#globaldelay')[0].value = '{0}'", Class130.int_1));
		MainWindow.webView_0.QueueScriptCall(string.Format("$('#monitordelay')[0].value = '{0}'", Class130.int_0));
		MainWindow.webView_0.QueueScriptCall(string.Format("$('#monitordelay')[0].value = '{0}'", Class130.int_0));
		MainWindow.webView_0.QueueScriptCall(string.Format("$('#webhook')[0].value = '{0}'", Class130.string_2.smethod_8()));
		MainWindow.webView_0.QueueScriptCall(string.Format("$('#desktop-notification').prop('checked', {0})", Class130.bool_0.ToString().ToLower()));
		Class1.smethod_3();
	}

	// Token: 0x06000016 RID: 22 RVA: 0x00006FF4 File Offset: 0x000051F4
	public static void smethod_3()
	{
		if (Licenser.class156_0.Renewal.Year > 2027)
		{
			MainWindow.webView_0.QueueScriptCall("$('#license-expiry').text('Expires: Never');$('#renewal-btn').hide();");
			return;
		}
		MainWindow.webView_0.QueueScriptCall(string.Format("$('#license-expiry').text('Expires: {0}')", Licenser.class156_0.Renewal.ToShortDateString()));
	}

	// Token: 0x06000017 RID: 23 RVA: 0x00002C44 File Offset: 0x00000E44
	public static void smethod_4(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		Process.Start(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CyberAIO\\log.txt"));
	}

	// Token: 0x06000018 RID: 24 RVA: 0x00007054 File Offset: 0x00005254
	public static async void smethod_5(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		TaskAwaiter<string> taskAwaiter = MainWindow.webView_0.QueueScriptCall("JSON.stringify(profiles)").smethod_2().GetAwaiter();
		if (!taskAwaiter.IsCompleted)
		{
			await taskAwaiter;
			TaskAwaiter<string> taskAwaiter2;
			taskAwaiter = taskAwaiter2;
			taskAwaiter2 = default(TaskAwaiter<string>);
		}
		Class130.jobject_2 = JObject.Parse(taskAwaiter.GetResult());
		Class130.smethod_1();
	}

	// Token: 0x06000019 RID: 25 RVA: 0x00007088 File Offset: 0x00005288
	public static async void smethod_6(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		TaskAwaiter<string> taskAwaiter = MainWindow.webView_0.QueueScriptCall("JSON.stringify(tasks)").smethod_2().GetAwaiter();
		if (!taskAwaiter.IsCompleted)
		{
			await taskAwaiter;
			TaskAwaiter<string> taskAwaiter2;
			taskAwaiter = taskAwaiter2;
			taskAwaiter2 = default(TaskAwaiter<string>);
		}
		Class130.jobject_3 = JObject.Parse(taskAwaiter.GetResult());
		Class130.smethod_1();
	}

	// Token: 0x0600001A RID: 26 RVA: 0x000070BC File Offset: 0x000052BC
	public static async void smethod_7(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		TaskAwaiter<string> taskAwaiter = MainWindow.webView_0.QueueScriptCall("JSON.stringify(proxies)").smethod_2().GetAwaiter();
		if (!taskAwaiter.IsCompleted)
		{
			await taskAwaiter;
			TaskAwaiter<string> taskAwaiter2;
			taskAwaiter = taskAwaiter2;
			taskAwaiter2 = default(TaskAwaiter<string>);
		}
		Class130.jarray_0 = JArray.Parse(taskAwaiter.GetResult());
		Class130.smethod_1();
	}

	// Token: 0x0600001B RID: 27 RVA: 0x00002C5D File Offset: 0x00000E5D
	public static Task smethod_8()
	{
		return MainWindow.webView_0.QueueScriptCall(string.Format("loadProfiles(\"{0}\")", Class130.jobject_2.ToString().smethod_8())).smethod_3();
	}

	// Token: 0x0600001C RID: 28 RVA: 0x00002C87 File Offset: 0x00000E87
	public static Task smethod_9()
	{
		return MainWindow.webView_0.QueueScriptCall(string.Format("loadTasks('{0}')", Class130.jobject_3.ToString().smethod_8())).smethod_3();
	}

	// Token: 0x0600001D RID: 29 RVA: 0x00002CB1 File Offset: 0x00000EB1
	public static Task smethod_10()
	{
		return MainWindow.webView_0.QueueScriptCall(string.Format("loadProxies('{0}')", Class130.jarray_0.ToString().smethod_8())).smethod_3();
	}

	// Token: 0x0600001E RID: 30 RVA: 0x000070F0 File Offset: 0x000052F0
	public static void smethod_11(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		Class130.int_1 = (int)Convert.ToInt16(MainWindow.webView_0.QueueScriptCall("$('#globaldelay').val()").smethod_0());
		Class130.int_0 = (int)Convert.ToInt16(MainWindow.webView_0.QueueScriptCall("$('#monitordelay').val()").smethod_0());
		Class130.string_2 = MainWindow.webView_0.QueueScriptCall("$('#webhook').val()").smethod_0();
		Class130.bool_0 = (MainWindow.webView_0.QueueScriptCall("$('#desktop-notification').prop('checked').toString()").smethod_0() == "true");
		MainWindow.webView_0.QueueScriptCall("swal('Success', 'Successfully saved settings','success',{timer:1500})");
		Class130.smethod_1();
	}

	// Token: 0x0600001F RID: 31 RVA: 0x00002CDB File Offset: 0x00000EDB
	public static void smethod_12(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		Process.Start("mailto:help@cybersole.io?Subject=Help%20Ticket%20-%20License%20Key:%20" + Class130.string_3);
	}

	// Token: 0x06000020 RID: 32 RVA: 0x0000718C File Offset: 0x0000538C
	public static async void smethod_13(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		MainWindow.webView_0.QueueScriptCall("swal('Resetting key...','Please wait...','info',{buttons:false})");
		TaskAwaiter<bool> taskAwaiter = Licenser.smethod_4().GetAwaiter();
		if (!taskAwaiter.IsCompleted)
		{
			await taskAwaiter;
			TaskAwaiter<bool> taskAwaiter2;
			taskAwaiter = taskAwaiter2;
			taskAwaiter2 = default(TaskAwaiter<bool>);
		}
		if (taskAwaiter.GetResult())
		{
			MainWindow.webView_0.QueueScriptCall("swal('Success','Successfully reset your license key!','success')");
			TaskAwaiter taskAwaiter3 = Task.Delay(1000).GetAwaiter();
			if (!taskAwaiter3.IsCompleted)
			{
				await taskAwaiter3;
				TaskAwaiter taskAwaiter4;
				taskAwaiter3 = taskAwaiter4;
				taskAwaiter4 = default(TaskAwaiter);
			}
			taskAwaiter3.GetResult();
			MainWindow.mainWindow_0.method_4(null, null);
		}
		else
		{
			MainWindow.webView_0.QueueScriptCall("swal('Error','There was an error resetting your key, please try again later...','error')");
		}
	}

	// Token: 0x06000021 RID: 33 RVA: 0x000071C0 File Offset: 0x000053C0
	public static void smethod_14(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.Filter = "CyberAIO Backup|*.json";
		saveFileDialog.Title = "Backup CyberAIO";
		saveFileDialog.FileName = "CyberAIO Backup";
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			JObject jobject = new JObject();
			jobject["tasks"] = Class130.jobject_3;
			jobject["proxies"] = Class130.jarray_0;
			jobject["profiles"] = Class130.jobject_2;
			jobject["settings"] = new JObject();
			jobject["settings"]["global_delay"] = Class130.int_1;
			jobject["settings"]["monitor_delay"] = Class130.int_0;
			jobject["settings"]["webhook"] = Class130.string_2;
			StreamWriter streamWriter = new StreamWriter(saveFileDialog.OpenFile());
			try
			{
				streamWriter.WriteLine(jobject.ToString());
			}
			finally
			{
				((IDisposable)streamWriter).Dispose();
			}
		}
	}

	// Token: 0x06000022 RID: 34 RVA: 0x000072D4 File Offset: 0x000054D4
	public static void smethod_15(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		try
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "CyberAIO Backups|*.json";
			openFileDialog.Title = "Select your backup file";
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				JObject jobject = JObject.Parse(File.ReadAllText(openFileDialog.FileName));
				MainWindow.webView_0.QueueScriptCall("$('#taskbody')[0].innerHTML = ''; stopTask(JSON.stringify(tasks)); tasks = {};").smethod_0();
				MainWindow.webView_0.QueueScriptCall("proxies = []; $('#proxybody')[0].innerHTML = '';").smethod_0();
				MainWindow.webView_0.QueueScriptCall(string.Format("loadTasks('{0}')", jobject["tasks"].ToString().smethod_8()));
				MainWindow.webView_0.QueueScriptCall(string.Format("loadProxies('{0}')", jobject["proxies"].ToString().smethod_8()));
				MainWindow.webView_0.QueueScriptCall(string.Format("loadProfiles('{0}')", jobject["profiles"].ToString().smethod_8()));
				Class130.jarray_0 = (JArray)jobject["proxies"];
				Class130.jobject_2 = (JObject)jobject["profiles"];
				Class130.jobject_3 = (JObject)jobject["tasks"];
				Class130.int_1 = (int)jobject["settings"]["global_delay"];
				Class130.int_0 = (int)jobject["settings"]["monitor_delay"];
				Class130.string_2 = ((jobject["settings"]["webhook"] == null) ? string.Empty : jobject["settings"]["webhook"].ToString());
				Class1.smethod_2();
				MainWindow.webView_0.QueueScriptCall("swal('Success', 'Successfully imported tasks, proxies, profiles and settings!','success',{timer:1500})");
				Class130.smethod_1();
			}
		}
		catch
		{
			MainWindow.webView_0.QueueScriptCall("swal('Error', 'There was an error importing the data!','error',{timer:1500})");
		}
	}

	// Token: 0x02000005 RID: 5
	[StructLayout(LayoutKind.Auto)]
	private struct Struct0 : IAsyncStateMachine
	{
		// Token: 0x06000023 RID: 35 RVA: 0x000074C8 File Offset: 0x000056C8
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			try
			{
				TaskAwaiter taskAwaiter5;
				TaskAwaiter<bool> taskAwaiter6;
				if (num != 0)
				{
					if (num == 1)
					{
						taskAwaiter5 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter);
						num2 = -1;
						goto IL_E1;
					}
					MainWindow.webView_0.QueueScriptCall("swal('Resetting key...','Please wait...','info',{buttons:false})");
					taskAwaiter6 = Licenser.smethod_4().GetAwaiter();
					if (!taskAwaiter6.IsCompleted)
					{
						num2 = 0;
						taskAwaiter2 = taskAwaiter6;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, Class1.Struct0>(ref taskAwaiter6, ref this);
						return;
					}
				}
				else
				{
					taskAwaiter6 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<bool>);
					num2 = -1;
				}
				if (!taskAwaiter6.GetResult())
				{
					MainWindow.webView_0.QueueScriptCall("swal('Error','There was an error resetting your key, please try again later...','error')");
					goto IL_106;
				}
				MainWindow.webView_0.QueueScriptCall("swal('Success','Successfully reset your license key!','success')");
				taskAwaiter5 = Task.Delay(1000).GetAwaiter();
				if (!taskAwaiter5.IsCompleted)
				{
					num2 = 1;
					taskAwaiter4 = taskAwaiter5;
					this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class1.Struct0>(ref taskAwaiter5, ref this);
					return;
				}
				IL_E1:
				taskAwaiter5.GetResult();
				MainWindow.mainWindow_0.method_4(null, null);
				IL_106:;
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

		// Token: 0x06000024 RID: 36 RVA: 0x00002CF2 File Offset: 0x00000EF2
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000005 RID: 5
		public int int_0;

		// Token: 0x04000006 RID: 6
		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		// Token: 0x04000007 RID: 7
		private TaskAwaiter<bool> taskAwaiter_0;

		// Token: 0x04000008 RID: 8
		private TaskAwaiter taskAwaiter_1;
	}

	// Token: 0x02000006 RID: 6
	[StructLayout(LayoutKind.Auto)]
	private struct Struct1 : IAsyncStateMachine
	{
		// Token: 0x06000025 RID: 37 RVA: 0x00007624 File Offset: 0x00005824
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			try
			{
				TaskAwaiter<string> taskAwaiter3;
				if (num != 0)
				{
					taskAwaiter3 = MainWindow.webView_0.QueueScriptCall("JSON.stringify(profiles)").smethod_2().GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						num2 = 0;
						taskAwaiter2 = taskAwaiter3;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class1.Struct1>(ref taskAwaiter3, ref this);
						return;
					}
				}
				else
				{
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<string>);
					num2 = -1;
				}
				Class130.jobject_2 = JObject.Parse(taskAwaiter3.GetResult());
				Class130.smethod_1();
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

		// Token: 0x06000026 RID: 38 RVA: 0x00002D00 File Offset: 0x00000F00
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000009 RID: 9
		public int int_0;

		// Token: 0x0400000A RID: 10
		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		// Token: 0x0400000B RID: 11
		private TaskAwaiter<string> taskAwaiter_0;
	}

	// Token: 0x02000007 RID: 7
	[StructLayout(LayoutKind.Auto)]
	private struct Struct2 : IAsyncStateMachine
	{
		// Token: 0x06000027 RID: 39 RVA: 0x000076EC File Offset: 0x000058EC
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			try
			{
				TaskAwaiter<string> taskAwaiter3;
				if (num != 0)
				{
					taskAwaiter3 = MainWindow.webView_0.QueueScriptCall("JSON.stringify(proxies)").smethod_2().GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						num2 = 0;
						taskAwaiter2 = taskAwaiter3;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class1.Struct2>(ref taskAwaiter3, ref this);
						return;
					}
				}
				else
				{
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<string>);
					num2 = -1;
				}
				Class130.jarray_0 = JArray.Parse(taskAwaiter3.GetResult());
				Class130.smethod_1();
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

		// Token: 0x06000028 RID: 40 RVA: 0x00002D0E File Offset: 0x00000F0E
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400000C RID: 12
		public int int_0;

		// Token: 0x0400000D RID: 13
		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		// Token: 0x0400000E RID: 14
		private TaskAwaiter<string> taskAwaiter_0;
	}

	// Token: 0x02000008 RID: 8
	[StructLayout(LayoutKind.Auto)]
	private struct Struct3 : IAsyncStateMachine
	{
		// Token: 0x06000029 RID: 41 RVA: 0x000077B4 File Offset: 0x000059B4
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			try
			{
				TaskAwaiter<string> taskAwaiter3;
				if (num != 0)
				{
					taskAwaiter3 = MainWindow.webView_0.QueueScriptCall("JSON.stringify(tasks)").smethod_2().GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						num2 = 0;
						taskAwaiter2 = taskAwaiter3;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class1.Struct3>(ref taskAwaiter3, ref this);
						return;
					}
				}
				else
				{
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<string>);
					num2 = -1;
				}
				Class130.jobject_3 = JObject.Parse(taskAwaiter3.GetResult());
				Class130.smethod_1();
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

		// Token: 0x0600002A RID: 42 RVA: 0x00002D1C File Offset: 0x00000F1C
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400000F RID: 15
		public int int_0;

		// Token: 0x04000010 RID: 16
		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		// Token: 0x04000011 RID: 17
		private TaskAwaiter<string> taskAwaiter_0;
	}
}
