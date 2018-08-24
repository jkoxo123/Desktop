using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Management;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// Token: 0x02000015 RID: 21
internal sealed partial class Licenser : Form
{
	// Token: 0x0600006A RID: 106 RVA: 0x00002F73 File Offset: 0x00001173
	public Licenser()
	{
		this.InitializeComponent();
		this.smethod_20(new Action(Licenser.Class10.class10_0.method_0));
	}

	// Token: 0x0600006B RID: 107 RVA: 0x00008398 File Offset: 0x00006598
	// Note: this type is marked as 'beforefieldinit'.
	static Licenser()
	{
		string text = null;
		string string_ = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36";
		int int_ = 10;
		bool bool_ = false;
		bool bool_2 = false;
		JObject jobject = new JObject();
		jobject["Token"] = "94112421582745227130";
		Licenser.class14_0 = new Class14(text, string_, int_, bool_, bool_2, jobject);
		Licenser.string_0 = string.Concat(new string[]
		{
			Licenser.smethod_2(),
			" ",
			Licenser.smethod_0(),
			" ",
			Licenser.smethod_1().Trim()
		});
	}

	// Token: 0x0600006C RID: 108 RVA: 0x00002FA6 File Offset: 0x000011A6
	private void close_btn_Click(object sender, EventArgs e)
	{
		Application.Exit();
	}

	// Token: 0x0600006D RID: 109 RVA: 0x00008410 File Offset: 0x00006610
	public static string smethod_0()
	{
		string result;
		try
		{
			string text = null;
			foreach (ManagementBaseObject managementBaseObject in new ManagementClass("win32_processor").GetInstances())
			{
				text = ((ManagementObject)managementBaseObject).Properties["processorID"].Value.ToString();
			}
			if (text == null)
			{
				result = "unknown";
			}
			else
			{
				result = text;
			}
		}
		catch
		{
			result = "unknown";
		}
		return result;
	}

	// Token: 0x0600006E RID: 110 RVA: 0x000084A8 File Offset: 0x000066A8
	public static string smethod_1()
	{
		string result;
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (ManagementBaseObject managementBaseObject in new ManagementObjectSearcher("SELECT * FROM Win32_BIOS").Get())
			{
				ManagementObject managementObject = (ManagementObject)managementBaseObject;
				object value = managementObject["Manufacturer"];
				stringBuilder.Append(Convert.ToString(value));
				stringBuilder.Append(':');
				value = managementObject["SerialNumber"];
				stringBuilder.Append(Convert.ToString(value));
			}
			if (stringBuilder == null)
			{
				result = "unknown";
			}
			else
			{
				result = stringBuilder.ToString();
			}
		}
		catch
		{
			result = "unknown";
		}
		return result;
	}

	// Token: 0x0600006F RID: 111 RVA: 0x0000856C File Offset: 0x0000676C
	public static string smethod_2()
	{
		ManagementObjectCollection instances = new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances();
		string text = string.Empty;
		foreach (ManagementBaseObject managementBaseObject in instances)
		{
			ManagementObject managementObject = (ManagementObject)managementBaseObject;
			if (text == string.Empty && (bool)managementObject["IPEnabled"])
			{
				text = managementObject["MacAddress"].ToString();
			}
			managementObject.Dispose();
		}
		if (text == string.Empty)
		{
			return "unknown";
		}
		return text;
	}

	// Token: 0x06000070 RID: 112 RVA: 0x00008614 File Offset: 0x00006814
	public static async Task smethod_3(string string_1)
	{
		(await Licenser.class14_0.method_2(string.Format("http://auth.botsupply.ml/api/key_check?key={1}&mac={2}", "cybersole.io", string_1, Licenser.string_0), false)).EnsureSuccessStatusCode();
	}

	// Token: 0x06000071 RID: 113 RVA: 0x0000865C File Offset: 0x0000685C
	public static async Task<bool> smethod_4()
	{
		bool result;
		try
		{
			(await Licenser.class14_0.method_2(string.Format("http://auth.botsupply.ml/api/key_check?key={1}&activate=0", "cybersole.io", Class130.string_3), false)).EnsureSuccessStatusCode();
			Class130.string_3 = null;
			Class130.smethod_1();
			result = true;
		}
		catch
		{
			result = false;
		}
		return result;
	}

	// Token: 0x06000072 RID: 114 RVA: 0x0000869C File Offset: 0x0000689C
	public static void smethod_5()
	{
		Licenser.Struct9 @struct;
		@struct.asyncVoidMethodBuilder_0 = AsyncVoidMethodBuilder.Create();
		@struct.int_0 = -1;
		AsyncVoidMethodBuilder asyncVoidMethodBuilder_ = @struct.asyncVoidMethodBuilder_0;
		asyncVoidMethodBuilder_.Start<Licenser.Struct9>(ref @struct);
	}

	// Token: 0x06000073 RID: 115 RVA: 0x000086D0 File Offset: 0x000068D0
	public static Task<GEnum2> smethod_6(string string_1, bool bool_0)
	{
		object[] object_ = new object[]
		{
			string_1,
			bool_0
		};
		return (Task<GEnum2>)Class20.smethod_0().method_179(Class20.smethod_1(), "ARoG\\@:3Sg", object_);
	}

	// Token: 0x06000074 RID: 116 RVA: 0x0000870C File Offset: 0x0000690C
	private async void activate_btn_Click(object sender, EventArgs e)
	{
		this.activate_btn.ButtonText = " Please wait...";
		TaskAwaiter<GEnum2> taskAwaiter = Licenser.smethod_6(this.key_box.Text, true).GetAwaiter();
		if (!taskAwaiter.IsCompleted)
		{
			await taskAwaiter;
			TaskAwaiter<GEnum2> taskAwaiter2;
			taskAwaiter = taskAwaiter2;
			taskAwaiter2 = default(TaskAwaiter<GEnum2>);
		}
		switch (taskAwaiter.GetResult())
		{
		case (GEnum2)0:
			Class130.string_3 = this.key_box.Text;
			Class130.smethod_1();
			this.key_box.BorderColorFocused = Color.Green;
			this.key_box.BorderColorIdle = Color.Green;
			this.key_box.BorderColorMouseHover = Color.Green;
			this.status_label.Text = "Key is valid, thank you for your purchase!";
			this.status_label.ForeColor = Color.Green;
			this.smethod_21(null);
			base.Close();
			Startup.startup_0.method_3(false);
			Startup.startup_0.smethod_20(null);
			break;
		case (GEnum2)1:
			this.key_box.BorderColorFocused = Color.Red;
			this.key_box.BorderColorIdle = Color.Red;
			this.key_box.BorderColorMouseHover = Color.Red;
			this.status_label.Text = "Key is already activated on another computer, please deactivate it first";
			this.status_label.ForeColor = Color.Red;
			break;
		case (GEnum2)2:
			this.key_box.BorderColorFocused = Color.Red;
			this.key_box.BorderColorIdle = Color.Red;
			this.key_box.BorderColorMouseHover = Color.Red;
			this.status_label.Text = "Key is invalid";
			this.status_label.ForeColor = Color.Red;
			break;
		case (GEnum2)3:
			this.key_box.BorderColorFocused = Color.Red;
			this.key_box.BorderColorIdle = Color.Red;
			this.key_box.BorderColorMouseHover = Color.Red;
			this.status_label.Text = "License is expired, please donwgrade by reinstalling.";
			this.status_label.ForeColor = Color.Red;
			break;
		case (GEnum2)4:
			this.key_box.BorderColorFocused = Color.Red;
			this.key_box.BorderColorIdle = Color.Red;
			this.key_box.BorderColorMouseHover = Color.Red;
			this.status_label.Text = "There was an error checking your key, please contact support";
			this.status_label.ForeColor = Color.Red;
			break;
		}
		this.activate_btn.ButtonText = "  ACTIVATE";
	}

	// Token: 0x06000075 RID: 117 RVA: 0x00002FAD File Offset: 0x000011AD
	private void key_box_Enter(object sender, EventArgs e)
	{
		this.key_box.Text = null;
	}

	// Token: 0x0400002E RID: 46
	public static Class156 class156_0;

	// Token: 0x0400002F RID: 47
	public static Class14 class14_0;

	// Token: 0x04000030 RID: 48
	public static string string_0;

	// Token: 0x02000016 RID: 22
	[Serializable]
	private sealed class Class10
	{
		// Token: 0x0600007A RID: 122 RVA: 0x00002FE6 File Offset: 0x000011E6
		internal void method_0()
		{
			Startup.startup_0.smethod_21(null);
		}

		// Token: 0x0400003B RID: 59
		public static readonly Licenser.Class10 class10_0 = new Licenser.Class10();

		// Token: 0x0400003C RID: 60
		public static Action action_0;
	}

	// Token: 0x02000017 RID: 23
	[StructLayout(LayoutKind.Auto)]
	private struct Struct6 : IAsyncStateMachine
	{
		// Token: 0x0600007B RID: 123 RVA: 0x00008FE0 File Offset: 0x000071E0
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			try
			{
				TaskAwaiter<HttpResponseMessage> taskAwaiter;
				if (num != 0)
				{
					taskAwaiter = Licenser.class14_0.method_2(string.Format("http://auth.botsupply.ml/api/key_check?key={1}&mac={2}", "cybersole.io", string_1, Licenser.string_0), false).GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 0;
						TaskAwaiter<HttpResponseMessage> taskAwaiter2 = taskAwaiter;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Licenser.Struct6>(ref taskAwaiter, ref this);
						return;
					}
				}
				else
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
					num2 = -1;
				}
				taskAwaiter.GetResult().EnsureSuccessStatusCode();
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

		// Token: 0x0600007C RID: 124 RVA: 0x00002FF3 File Offset: 0x000011F3
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400003D RID: 61
		public int int_0;

		// Token: 0x0400003E RID: 62
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x0400003F RID: 63
		public string string_0;

		// Token: 0x04000040 RID: 64
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;
	}

	// Token: 0x02000018 RID: 24
	[StructLayout(LayoutKind.Auto)]
	private struct Struct7 : IAsyncStateMachine
	{
		// Token: 0x0600007D RID: 125 RVA: 0x000090B0 File Offset: 0x000072B0
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			GEnum2 result2;
			try
			{
				try
				{
					TaskAwaiter<HttpResponseMessage> awaiter;
					TaskAwaiter<string> awaiter2;
					TaskAwaiter awaiter3;
					switch (num)
					{
					case 0:
						awaiter = this.taskAwaiter_0;
						this.taskAwaiter_0 = default(TaskAwaiter<HttpResponseMessage>);
						this.int_0 = -1;
						break;
					case 1:
						awaiter2 = this.taskAwaiter_1;
						this.taskAwaiter_1 = default(TaskAwaiter<string>);
						this.int_0 = -1;
						goto IL_ED;
					case 2:
						awaiter3 = this.taskAwaiter_2;
						this.taskAwaiter_2 = default(TaskAwaiter);
						this.int_0 = -1;
						goto IL_1CC;
					default:
						awaiter = Licenser.class14_0.method_2(string.Format("http://auth.botsupply.ml/api/key_check?key={1}&mac={2}", "cybersole.io", this.string_0, Licenser.string_0), false).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							this.int_0 = 0;
							this.taskAwaiter_0 = awaiter;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Licenser.Struct7>(ref awaiter, ref this);
							return;
						}
						break;
					}
					HttpResponseMessage result = awaiter.GetResult();
					result.EnsureSuccessStatusCode();
					awaiter2 = result.smethod_3().GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						this.int_0 = 1;
						this.taskAwaiter_1 = awaiter2;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Licenser.Struct7>(ref awaiter2, ref this);
						return;
					}
					IL_ED:
					Licenser.class156_0 = JsonConvert.DeserializeObject<Class156>(awaiter2.GetResult());
					if (!Licenser.class156_0.Valid)
					{
						result2 = (GEnum2)2;
						goto IL_200;
					}
					switch (Licenser.class156_0.Status)
					{
					case -1:
						result2 = (GEnum2)3;
						goto IL_200;
					case 0:
						if (!this.bool_0)
						{
							goto IL_1D3;
						}
						awaiter3 = Licenser.smethod_3(this.string_0).GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							this.int_0 = 2;
							this.taskAwaiter_2 = awaiter3;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Licenser.Struct7>(ref awaiter3, ref this);
							return;
						}
						break;
					case 1:
						result2 = ((Licenser.class156_0.Hwid == Licenser.string_0) ? ((GEnum2)0) : ((GEnum2)1));
						goto IL_200;
					case 2:
						result2 = (GEnum2)0;
						goto IL_200;
					default:
						result2 = (GEnum2)4;
						goto IL_200;
					}
					IL_1CC:
					awaiter3.GetResult();
					IL_1D3:
					result2 = (this.bool_0 ? ((GEnum2)0) : ((GEnum2)1));
				}
				catch
				{
					result2 = (GEnum2)4;
				}
			}
			catch (Exception exception)
			{
				this.int_0 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_200:
			this.int_0 = -2;
			this.asyncTaskMethodBuilder_0.SetResult(result2);
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00003001 File Offset: 0x00001201
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000041 RID: 65
		public int int_0;

		// Token: 0x04000042 RID: 66
		public AsyncTaskMethodBuilder<GEnum2> asyncTaskMethodBuilder_0;

		// Token: 0x04000043 RID: 67
		public string string_0;

		// Token: 0x04000044 RID: 68
		public bool bool_0;

		// Token: 0x04000045 RID: 69
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000046 RID: 70
		private TaskAwaiter<string> taskAwaiter_1;

		// Token: 0x04000047 RID: 71
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x02000019 RID: 25
	[StructLayout(LayoutKind.Auto)]
	private struct Struct8 : IAsyncStateMachine
	{
		// Token: 0x0600007F RID: 127 RVA: 0x00009308 File Offset: 0x00007508
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			bool result;
			try
			{
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter;
					if (num != 0)
					{
						taskAwaiter = Licenser.class14_0.method_2(string.Format("http://auth.botsupply.ml/api/key_check?key={1}&activate=0", "cybersole.io", Class130.string_3), false).GetAwaiter();
						if (!taskAwaiter.IsCompleted)
						{
							num2 = 0;
							TaskAwaiter<HttpResponseMessage> taskAwaiter2 = taskAwaiter;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Licenser.Struct8>(ref taskAwaiter, ref this);
							return;
						}
					}
					else
					{
						TaskAwaiter<HttpResponseMessage> taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
						num2 = -1;
					}
					taskAwaiter.GetResult().EnsureSuccessStatusCode();
					Class130.string_3 = null;
					Class130.smethod_1();
					result = true;
				}
				catch
				{
					result = false;
				}
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult(result);
		}

		// Token: 0x06000080 RID: 128 RVA: 0x0000300F File Offset: 0x0000120F
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000048 RID: 72
		public int int_0;

		// Token: 0x04000049 RID: 73
		public AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder_0;

		// Token: 0x0400004A RID: 74
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;
	}

	// Token: 0x0200001A RID: 26
	[StructLayout(LayoutKind.Auto)]
	private struct Struct9 : IAsyncStateMachine
	{
		// Token: 0x06000081 RID: 129 RVA: 0x000093F4 File Offset: 0x000075F4
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			try
			{
				TaskAwaiter awaiter;
				TaskAwaiter<GEnum2> awaiter2;
				switch (num)
				{
				case 0:
					awaiter = this.taskAwaiter_0;
					this.taskAwaiter_0 = default(TaskAwaiter);
					this.int_0 = -1;
					break;
				case 1:
					awaiter2 = this.taskAwaiter_1;
					this.taskAwaiter_1 = default(TaskAwaiter<GEnum2>);
					this.int_0 = -1;
					goto IL_C3;
				case 2:
					awaiter = this.taskAwaiter_0;
					this.taskAwaiter_0 = default(TaskAwaiter);
					this.int_0 = -1;
					goto IL_163;
				default:
					goto IL_D4;
				}
				IL_94:
				awaiter.GetResult();
				DateTime renewal = Licenser.class156_0.Renewal;
				awaiter2 = Licenser.smethod_6(Class130.string_3, false).GetAwaiter();
				if (!awaiter2.IsCompleted)
				{
					this.int_0 = 1;
					this.taskAwaiter_1 = awaiter2;
					this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<GEnum2>, Licenser.Struct9>(ref awaiter2, ref this);
					return;
				}
				IL_C3:
				GEnum2 result = awaiter2.GetResult();
				if (result != (GEnum2)0 && result != (GEnum2)4)
				{
					this.int_1 = 5;
					this.int_2 = 0;
					goto IL_109;
				}
				IL_D4:
				awaiter = Task.Delay(TimeSpan.FromSeconds(60.0)).GetAwaiter();
				if (!awaiter.IsCompleted)
				{
					this.int_0 = 0;
					this.taskAwaiter_0 = awaiter;
					this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Licenser.Struct9>(ref awaiter, ref this);
					return;
				}
				goto IL_94;
				IL_109:
				if (this.int_1 <= this.int_2)
				{
					Class130.string_3 = null;
					Class130.smethod_1();
					MainWindow.mainWindow_0.method_4(null, null);
					goto IL_D4;
				}
				MainWindow.webView_0.QueueScriptCall("swal('Uh oh!', 'It seems that your key has been deactivated, or is being used on another PC. The bot will close in " + (this.int_1 - this.int_2).ToString() + " seconds.\\n', 'warning',  {buttons:{visible: false}, closeOnClickOutside:false})");
				awaiter = Task.Delay(1000).GetAwaiter();
				if (!awaiter.IsCompleted)
				{
					this.int_0 = 2;
					this.taskAwaiter_0 = awaiter;
					this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Licenser.Struct9>(ref awaiter, ref this);
					return;
				}
				IL_163:
				awaiter.GetResult();
				int num2 = this.int_2;
				this.int_2 = num2 + 1;
				goto IL_109;
			}
			catch (Exception exception)
			{
				this.int_0 = -2;
				this.asyncVoidMethodBuilder_0.SetException(exception);
			}
		}

		// Token: 0x06000082 RID: 130 RVA: 0x0000301D File Offset: 0x0000121D
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400004B RID: 75
		public int int_0;

		// Token: 0x0400004C RID: 76
		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		// Token: 0x0400004D RID: 77
		private TaskAwaiter taskAwaiter_0;

		// Token: 0x0400004E RID: 78
		private TaskAwaiter<GEnum2> taskAwaiter_1;

		// Token: 0x0400004F RID: 79
		private int int_1;

		// Token: 0x04000050 RID: 80
		private int int_2;
	}

	// Token: 0x0200001B RID: 27
	[StructLayout(LayoutKind.Auto)]
	private struct Struct10 : IAsyncStateMachine
	{
		// Token: 0x06000083 RID: 131 RVA: 0x00009614 File Offset: 0x00007814
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Licenser licenser = this;
			try
			{
				TaskAwaiter<GEnum2> taskAwaiter3;
				if (num != 0)
				{
					licenser.activate_btn.ButtonText = " Please wait...";
					taskAwaiter3 = Licenser.smethod_6(licenser.key_box.Text, true).GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						num2 = 0;
						taskAwaiter2 = taskAwaiter3;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<GEnum2>, Licenser.Struct10>(ref taskAwaiter3, ref this);
						return;
					}
				}
				else
				{
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<GEnum2>);
					num2 = -1;
				}
				switch (taskAwaiter3.GetResult())
				{
				case (GEnum2)0:
					Class130.string_3 = licenser.key_box.Text;
					Class130.smethod_1();
					licenser.key_box.BorderColorFocused = Color.Green;
					licenser.key_box.BorderColorIdle = Color.Green;
					licenser.key_box.BorderColorMouseHover = Color.Green;
					licenser.status_label.Text = "Key is valid, thank you for your purchase!";
					licenser.status_label.ForeColor = Color.Green;
					licenser.smethod_21(null);
					licenser.Close();
					Startup.startup_0.method_3(false);
					Startup.startup_0.smethod_20(null);
					break;
				case (GEnum2)1:
					licenser.key_box.BorderColorFocused = Color.Red;
					licenser.key_box.BorderColorIdle = Color.Red;
					licenser.key_box.BorderColorMouseHover = Color.Red;
					licenser.status_label.Text = "Key is already activated on another computer, please deactivate it first";
					licenser.status_label.ForeColor = Color.Red;
					break;
				case (GEnum2)2:
					licenser.key_box.BorderColorFocused = Color.Red;
					licenser.key_box.BorderColorIdle = Color.Red;
					licenser.key_box.BorderColorMouseHover = Color.Red;
					licenser.status_label.Text = "Key is invalid";
					licenser.status_label.ForeColor = Color.Red;
					break;
				case (GEnum2)3:
					licenser.key_box.BorderColorFocused = Color.Red;
					licenser.key_box.BorderColorIdle = Color.Red;
					licenser.key_box.BorderColorMouseHover = Color.Red;
					licenser.status_label.Text = "License is expired, please donwgrade by reinstalling.";
					licenser.status_label.ForeColor = Color.Red;
					break;
				case (GEnum2)4:
					licenser.key_box.BorderColorFocused = Color.Red;
					licenser.key_box.BorderColorIdle = Color.Red;
					licenser.key_box.BorderColorMouseHover = Color.Red;
					licenser.status_label.Text = "There was an error checking your key, please contact support";
					licenser.status_label.ForeColor = Color.Red;
					break;
				}
				licenser.activate_btn.ButtonText = "  ACTIVATE";
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

		// Token: 0x06000084 RID: 132 RVA: 0x0000302B File Offset: 0x0000122B
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000051 RID: 81
		public int int_0;

		// Token: 0x04000052 RID: 82
		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		// Token: 0x04000053 RID: 83
		public Licenser licenser_0;

		// Token: 0x04000054 RID: 84
		private TaskAwaiter<GEnum2> taskAwaiter_0;
	}
}
