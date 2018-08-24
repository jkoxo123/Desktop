using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using EO.WebBrowser;
using Newtonsoft.Json.Linq;

// Token: 0x0200000B RID: 11
internal sealed class Class5
{
	// Token: 0x0600003B RID: 59 RVA: 0x00002D85 File Offset: 0x00000F85
	public static bool smethod_0()
	{
		return File.Exists(Class5.string_0);
	}

	// Token: 0x0600003C RID: 60 RVA: 0x00007AC8 File Offset: 0x00005CC8
	public static async void smethod_1(bool bool_0)
	{
		try
		{
			TaskAwaiter<HttpResponseMessage> taskAwaiter = Licenser.class14_0.method_2(string.Format("http://auth.botsupply.ml/api/key_check?key={1}&update=check", "cybersole.io", Class130.string_3, Assembly.GetEntryAssembly().GetName().Version), false).GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<HttpResponseMessage> taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
			}
			HttpResponseMessage result = taskAwaiter.GetResult();
			result.EnsureSuccessStatusCode();
			TaskAwaiter<JObject> taskAwaiter3 = result.smethod_1().GetAwaiter();
			if (!taskAwaiter3.IsCompleted)
			{
				await taskAwaiter3;
				TaskAwaiter<JObject> taskAwaiter4;
				taskAwaiter3 = taskAwaiter4;
				taskAwaiter4 = default(TaskAwaiter<JObject>);
			}
			JObject result2 = taskAwaiter3.GetResult();
			if (!result2["Update"].smethod_22())
			{
				Class5.jobject_0 = result2;
				MainWindow.webView_0.QueueScriptCall(string.Format("var changes = document.createElement('textarea'); changes.classList.add('form-control-textarea'); changes.style = 'box-shadow: 1px 1px 20px #0e1111'; changes.rows = {0}; changes.disabled = true; changes.innerHTML = '{1}'; swal({{ title: 'Update Available', text: 'Version {2} is available, would you like to download it?', content: changes, icon: 'info', buttons: ['No', 'Yes'], }}).then((update) => {{ if (update) {{ StartUpdate(); }} }});", result2["Update"]["Changes"].ToString().Split(new char[]
				{
					'\n'
				}).Length, result2["Update"]["Changes"].ToString().smethod_8(), result2["Update"]["Version"].ToString()));
			}
			else if ((bool)result2["Available"])
			{
				MainWindow.webView_0.QueueScriptCall("swal({ title: 'License Expired', text: 'An update is available but your license is expired, would you like to renew it?', icon: 'warning', buttons: { cancel: { text: 'No', value: false, visible: true, className: '', closeModal: true, }, confirm: { text: 'Yes', value: true, visible: true, className: '', closeModal: false } } }).then((renew) => { if (renew) { Renew(); } });");
			}
			else if (bool_0)
			{
				MainWindow.webView_0.QueueScriptCall("swal('Up To Date', 'Your are on the latest version!', 'success', {buttons:false, timer: 2000})");
			}
		}
		catch
		{
			MainWindow.webView_0.QueueScriptCall("swal('Error', 'There was an error checking for updates, please try again later.', 'error', {buttons:false, timer: 2000})");
		}
	}

	// Token: 0x0600003D RID: 61 RVA: 0x00007B04 File Offset: 0x00005D04
	public static void smethod_2()
	{
		try
		{
			if (Class5.smethod_0())
			{
				if (!Class116.smethod_5(null))
				{
					Class116.smethod_2();
				}
				else
				{
					using (ZipArchive zipArchive = ZipFile.OpenRead(Class5.string_0))
					{
						foreach (ZipArchiveEntry zipArchiveEntry in zipArchive.Entries)
						{
							string text = Path.Combine(Application.StartupPath, zipArchiveEntry.FullName);
							if (zipArchiveEntry.Name == string.Empty)
							{
								Directory.CreateDirectory(Path.GetDirectoryName(text));
							}
							else
							{
								if (File.Exists(text))
								{
									if (File.Exists(text + ".temp"))
									{
										File.Delete(text + ".temp");
									}
									File.Move(text, text + ".temp");
								}
								else
								{
									File.Create(text + ".temp").Close();
								}
								zipArchiveEntry.ExtractToFile(text, true);
							}
						}
					}
					File.Delete(Class5.string_0);
					Class116.smethod_3();
				}
			}
		}
		catch
		{
		}
	}

	// Token: 0x0600003E RID: 62 RVA: 0x00007C60 File Offset: 0x00005E60
	public static async void smethod_3(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		Class5.Class7 @class = new Class5.Class7();
		@class.object_0 = object_0;
		try
		{
			Class5.Class8 class2 = new Class5.Class8();
			class2.class7_0 = @class;
			class2.notification_0 = Notification.smethod_0("Update Downloading (0%)", "You may continue to use the bot.", (Notification.GEnum0)2, false);
			Notification.bool_0 = true;
			WebClient webClient = new WebClient();
			webClient.DownloadProgressChanged += class2.method_0;
			await webClient.DownloadFileTaskAsync((string)Class5.jobject_0["Update"]["Download"], Class5.string_0);
			Notification.bool_0 = false;
			Notification.smethod_0("Update downloaded", "Restart bot to install", (Notification.GEnum0)0, false);
		}
		catch (WebException)
		{
			Notification.bool_0 = false;
			MainWindow.webView_0.QueueScriptCall("swal('Error while downloading update', 'There was an error downloading the update, please check your connection and try again', 'error')");
		}
		catch
		{
			Notification.bool_0 = false;
			MainWindow.webView_0.QueueScriptCall("swal('Error while extracting update', 'There was an error extracting the update, please close any application that may be using the applications directory and try again', 'error')");
		}
	}

	// Token: 0x0600003F RID: 63 RVA: 0x00002D91 File Offset: 0x00000F91
	public static void smethod_4(object object_0, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs_0, Notification notification_0)
	{
		notification_0.title.Text = string.Format("Update Downloading ({0}%)", downloadProgressChangedEventArgs_0.ProgressPercentage);
	}

	// Token: 0x06000040 RID: 64 RVA: 0x00007C9C File Offset: 0x00005E9C
	public static void smethod_5()
	{
		IEnumerable<string> enumerable = Directory.GetFiles(Application.StartupPath, "*.temp", SearchOption.AllDirectories).Where(new Func<string, bool>(Class5.Class6.class6_0.method_0));
		if (enumerable.Any<string>())
		{
			Class116.smethod_2();
		}
		foreach (string path in enumerable)
		{
			try
			{
				File.Delete(path);
			}
			catch
			{
			}
		}
	}

	// Token: 0x04000013 RID: 19
	public static JObject jobject_0;

	// Token: 0x04000014 RID: 20
	public static readonly string string_0 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CyberAIO\\update.zip");

	// Token: 0x0200000C RID: 12
	[Serializable]
	private sealed class Class6
	{
		// Token: 0x06000043 RID: 67 RVA: 0x00002DBF File Offset: 0x00000FBF
		internal bool method_0(string string_0)
		{
			return string_0.EndsWith(".temp");
		}

		// Token: 0x04000015 RID: 21
		public static readonly Class5.Class6 class6_0 = new Class5.Class6();

		// Token: 0x04000016 RID: 22
		public static Func<string, bool> func_0;
	}

	// Token: 0x0200000D RID: 13
	private sealed class Class7
	{
		// Token: 0x04000017 RID: 23
		public object object_0;
	}

	// Token: 0x0200000E RID: 14
	private sealed class Class8
	{
		// Token: 0x06000046 RID: 70 RVA: 0x00002DCC File Offset: 0x00000FCC
		internal void method_0(object sender, DownloadProgressChangedEventArgs e)
		{
			Class5.smethod_4(this.class7_0.object_0, e, this.notification_0);
		}

		// Token: 0x04000018 RID: 24
		public Notification notification_0;

		// Token: 0x04000019 RID: 25
		public Class5.Class7 class7_0;
	}

	// Token: 0x0200000F RID: 15
	[StructLayout(LayoutKind.Auto)]
	private struct Struct4 : IAsyncStateMachine
	{
		// Token: 0x06000047 RID: 71 RVA: 0x00007D38 File Offset: 0x00005F38
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			try
			{
				Class5.Class7 @class;
				if (num != 0)
				{
					@class = new Class5.Class7();
					@class.object_0 = object_0;
				}
				try
				{
					TaskAwaiter taskAwaiter;
					if (num != 0)
					{
						Class5.Class8 class2 = new Class5.Class8();
						class2.class7_0 = @class;
						class2.notification_0 = Notification.smethod_0("Update Downloading (0%)", "You may continue to use the bot.", (Notification.GEnum0)2, false);
						Notification.bool_0 = true;
						WebClient webClient = new WebClient();
						webClient.DownloadProgressChanged += class2.method_0;
						taskAwaiter = webClient.DownloadFileTaskAsync((string)Class5.jobject_0["Update"]["Download"], Class5.string_0).GetAwaiter();
						if (!taskAwaiter.IsCompleted)
						{
							num2 = 0;
							TaskAwaiter taskAwaiter2 = taskAwaiter;
							this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class5.Struct4>(ref taskAwaiter, ref this);
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
					Notification.bool_0 = false;
					Notification.smethod_0("Update downloaded", "Restart bot to install", (Notification.GEnum0)0, false);
				}
				catch (WebException)
				{
					Notification.bool_0 = false;
					MainWindow.webView_0.QueueScriptCall("swal('Error while downloading update', 'There was an error downloading the update, please check your connection and try again', 'error')");
				}
				catch
				{
					Notification.bool_0 = false;
					MainWindow.webView_0.QueueScriptCall("swal('Error while extracting update', 'There was an error extracting the update, please close any application that may be using the applications directory and try again', 'error')");
				}
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

		// Token: 0x06000048 RID: 72 RVA: 0x00002DE5 File Offset: 0x00000FE5
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400001A RID: 26
		public int int_0;

		// Token: 0x0400001B RID: 27
		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		// Token: 0x0400001C RID: 28
		public object object_0;

		// Token: 0x0400001D RID: 29
		private TaskAwaiter taskAwaiter_0;
	}

	// Token: 0x02000010 RID: 16
	[StructLayout(LayoutKind.Auto)]
	private struct Struct5 : IAsyncStateMachine
	{
		// Token: 0x06000049 RID: 73 RVA: 0x00007EEC File Offset: 0x000060EC
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			try
			{
				try
				{
					TaskAwaiter<JObject> taskAwaiter5;
					TaskAwaiter<HttpResponseMessage> taskAwaiter6;
					if (num != 0)
					{
						if (num == 1)
						{
							taskAwaiter5 = taskAwaiter4;
							taskAwaiter4 = default(TaskAwaiter<JObject>);
							num2 = -1;
							goto IL_F0;
						}
						taskAwaiter6 = Licenser.class14_0.method_2(string.Format("http://auth.botsupply.ml/api/key_check?key={1}&update=check", "cybersole.io", Class130.string_3, Assembly.GetEntryAssembly().GetName().Version), false).GetAwaiter();
						if (!taskAwaiter6.IsCompleted)
						{
							num2 = 0;
							taskAwaiter2 = taskAwaiter6;
							this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class5.Struct5>(ref taskAwaiter6, ref this);
							return;
						}
					}
					else
					{
						taskAwaiter6 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
						num2 = -1;
					}
					HttpResponseMessage result = taskAwaiter6.GetResult();
					result.EnsureSuccessStatusCode();
					taskAwaiter5 = result.smethod_1().GetAwaiter();
					if (!taskAwaiter5.IsCompleted)
					{
						num2 = 1;
						taskAwaiter4 = taskAwaiter5;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class5.Struct5>(ref taskAwaiter5, ref this);
						return;
					}
					IL_F0:
					JObject result2 = taskAwaiter5.GetResult();
					if (!result2["Update"].smethod_22())
					{
						Class5.jobject_0 = result2;
						MainWindow.webView_0.QueueScriptCall(string.Format("var changes = document.createElement('textarea'); changes.classList.add('form-control-textarea'); changes.style = 'box-shadow: 1px 1px 20px #0e1111'; changes.rows = {0}; changes.disabled = true; changes.innerHTML = '{1}'; swal({{ title: 'Update Available', text: 'Version {2} is available, would you like to download it?', content: changes, icon: 'info', buttons: ['No', 'Yes'], }}).then((update) => {{ if (update) {{ StartUpdate(); }} }});", result2["Update"]["Changes"].ToString().Split(new char[]
						{
							'\n'
						}).Length, result2["Update"]["Changes"].ToString().smethod_8(), result2["Update"]["Version"].ToString()));
					}
					else if ((bool)result2["Available"])
					{
						MainWindow.webView_0.QueueScriptCall("swal({ title: 'License Expired', text: 'An update is available but your license is expired, would you like to renew it?', icon: 'warning', buttons: { cancel: { text: 'No', value: false, visible: true, className: '', closeModal: true, }, confirm: { text: 'Yes', value: true, visible: true, className: '', closeModal: false } } }).then((renew) => { if (renew) { Renew(); } });");
					}
					else if (bool_0)
					{
						MainWindow.webView_0.QueueScriptCall("swal('Up To Date', 'Your are on the latest version!', 'success', {buttons:false, timer: 2000})");
					}
				}
				catch
				{
					MainWindow.webView_0.QueueScriptCall("swal('Error', 'There was an error checking for updates, please try again later.', 'error', {buttons:false, timer: 2000})");
				}
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

		// Token: 0x0600004A RID: 74 RVA: 0x00002DF3 File Offset: 0x00000FF3
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400001E RID: 30
		public int int_0;

		// Token: 0x0400001F RID: 31
		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		// Token: 0x04000020 RID: 32
		public bool bool_0;

		// Token: 0x04000021 RID: 33
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000022 RID: 34
		private TaskAwaiter<JObject> taskAwaiter_1;
	}
}
