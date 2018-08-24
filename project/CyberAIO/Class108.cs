using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using EO.WebBrowser;
using Newtonsoft.Json.Linq;

// Token: 0x020000AD RID: 173
internal static class Class108
{
	// Token: 0x06000441 RID: 1089 RVA: 0x0000498F File Offset: 0x00002B8F
	public static string smethod_0(this ScriptCall scriptCall_0)
	{
		scriptCall_0.WaitOne(5000);
		return scriptCall_0.Result.ToString();
	}

	// Token: 0x06000442 RID: 1090 RVA: 0x000049A8 File Offset: 0x00002BA8
	public static bool smethod_1(this string string_0, string[] string_1, string[] string_2)
	{
		return string_1.All(new Func<string, bool>(string_0.ToLower().Contains)) && !string_2.Any(new Func<string, bool>(string_0.ToString().ToLower().Contains));
	}

	// Token: 0x06000443 RID: 1091 RVA: 0x000211FC File Offset: 0x0001F3FC
	public static async Task<string> smethod_2(this ScriptCall scriptCall_0)
	{
		Class108.Class113 @class = new Class108.Class113();
		@class.scriptCall_0 = scriptCall_0;
		await Task.Run<bool>(new Func<bool>(@class.method_0));
		return @class.scriptCall_0.Result.ToString();
	}

	// Token: 0x06000444 RID: 1092 RVA: 0x000049E4 File Offset: 0x00002BE4
	public static Task smethod_3(this ScriptCall scriptCall_0)
	{
		return Task.Run<bool>(new Func<bool>(new Class108.Class112
		{
			scriptCall_0 = scriptCall_0
		}.method_0));
	}

	// Token: 0x06000445 RID: 1093 RVA: 0x00004A02 File Offset: 0x00002C02
	public static JToken smethod_4(this JToken[] jtoken_0)
	{
		return jtoken_0[MainWindow.random_0.Next(0, jtoken_0.Length - 1)];
	}

	// Token: 0x06000446 RID: 1094 RVA: 0x00004A16 File Offset: 0x00002C16
	public static JToken smethod_5(this IEnumerable<JToken> ienumerable_0)
	{
		if (!ienumerable_0.Any<JToken>())
		{
			return null;
		}
		return ienumerable_0.ToArray<JToken>()[MainWindow.random_0.Next(0, ienumerable_0.Count<JToken>() - 1)];
	}

	// Token: 0x06000447 RID: 1095 RVA: 0x00004A3C File Offset: 0x00002C3C
	public static string smethod_6(this string string_0)
	{
		return Regex.Replace(string_0, "[^\\u0000-\\u007F]+", string.Empty);
	}

	// Token: 0x06000448 RID: 1096 RVA: 0x00004A4E File Offset: 0x00002C4E
	public static string smethod_7(this string string_0, int int_0)
	{
		return new StringBuilder(string_0.Length * int_0).Insert(0, string_0, int_0).ToString();
	}

	// Token: 0x06000449 RID: 1097 RVA: 0x00004A6A File Offset: 0x00002C6A
	public static string smethod_8(this string string_0)
	{
		return HttpUtility.JavaScriptStringEncode(string_0);
	}

	// Token: 0x0600044A RID: 1098 RVA: 0x00004A72 File Offset: 0x00002C72
	public static string smethod_9(this string string_0)
	{
		return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(string_0);
	}

	// Token: 0x0600044B RID: 1099 RVA: 0x00021244 File Offset: 0x0001F444
	public static byte[] smethod_10(this Stream stream_0)
	{
		byte[] array = new byte[stream_0.Length];
		byte[] result;
		using (MemoryStream memoryStream = new MemoryStream())
		{
			for (;;)
			{
				int num = stream_0.Read(array, 0, array.Length);
				if (num <= 0)
				{
					break;
				}
				memoryStream.Write(array, 0, num);
			}
			result = memoryStream.ToArray();
		}
		return result;
	}

	// Token: 0x0600044C RID: 1100 RVA: 0x000212A4 File Offset: 0x0001F4A4
	public static string smethod_11(this string string_0)
	{
		if (string.IsNullOrEmpty(string_0))
		{
			return string_0;
		}
		string oldValue = '\u2028'.ToString();
		string oldValue2 = '\u2029'.ToString();
		return string_0.Replace("\r\n", string.Empty).Replace("\n", string.Empty).Replace("\r", string.Empty).Replace(oldValue, string.Empty).Replace(oldValue2, string.Empty);
	}

	// Token: 0x0600044D RID: 1101 RVA: 0x00004A84 File Offset: 0x00002C84
	public static bool smethod_12(this string string_0)
	{
		return string_0.Any(new Func<char, bool>(char.IsDigit));
	}

	// Token: 0x0600044E RID: 1102 RVA: 0x0002131C File Offset: 0x0001F51C
	public static string smethod_13(this string string_0, bool bool_0)
	{
		string text;
		if (Class130.jobject_0.ContainsKey(string_0))
		{
			text = Class130.jobject_0[string_0]["code"].ToString();
		}
		else
		{
			text = null;
		}
		if (text == "US" && bool_0)
		{
			text = "USA";
		}
		return text;
	}

	// Token: 0x0600044F RID: 1103 RVA: 0x0002136C File Offset: 0x0001F56C
	public static bool smethod_14(this string string_0)
	{
		string_0 = string_0.Trim();
		if ((string_0.StartsWith("{") && string_0.EndsWith("}")) || (string_0.StartsWith("[") && string_0.EndsWith("]")))
		{
			bool result;
			try
			{
				JToken.Parse(string_0);
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}
		return false;
	}

	// Token: 0x06000450 RID: 1104 RVA: 0x000213DC File Offset: 0x0001F5DC
	public static bool smethod_15(this string string_0)
	{
		foreach (char c in string_0)
		{
			if (c < '0' || c > '9')
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06000451 RID: 1105 RVA: 0x00021414 File Offset: 0x0001F614
	public static string smethod_16()
	{
		List<double> list = new List<double>();
		for (double num = 4.5; num < 14.0; num += 0.5)
		{
			list.Add(num);
		}
		return list[MainWindow.random_0.Next(0, list.Count)].ToString();
	}

	// Token: 0x06000452 RID: 1106 RVA: 0x00004A98 File Offset: 0x00002C98
	public static string smethod_17(int int_0)
	{
		return new string(Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", int_0).Select(new Func<string, char>(Class108.Class109.class109_0.method_0)).ToArray<char>());
	}

	// Token: 0x06000453 RID: 1107 RVA: 0x00021474 File Offset: 0x0001F674
	public static JObject smethod_18(this string string_0)
	{
		JObject result;
		try
		{
			result = JObject.Parse(string_0);
		}
		catch
		{
			result = null;
		}
		return result;
	}

	// Token: 0x06000454 RID: 1108 RVA: 0x000214A0 File Offset: 0x0001F6A0
	public static JArray smethod_19(this string string_0)
	{
		JArray result;
		try
		{
			result = JArray.Parse(string_0);
		}
		catch
		{
			result = null;
		}
		return result;
	}

	// Token: 0x06000455 RID: 1109 RVA: 0x000214CC File Offset: 0x0001F6CC
	public static void smethod_20(this Form form_0, Action action_0)
	{
		Class108.Class110 @class = new Class108.Class110();
		@class.action_0 = action_0;
		@class.form_0 = form_0;
		@class.double_0 = 0.0;
		@class.form_0.Opacity = 0.0;
		@class.form_0.Show();
		@class.timer_0 = new System.Windows.Forms.Timer();
		@class.timer_0.Interval = 10;
		@class.timer_0.Tick += @class.method_0;
		@class.timer_0.Start();
	}

	// Token: 0x06000456 RID: 1110 RVA: 0x00021558 File Offset: 0x0001F758
	public static void smethod_21(this Form form_0, Action action_0)
	{
		Class108.Class111 @class = new Class108.Class111();
		@class.form_0 = form_0;
		@class.action_0 = action_0;
		@class.timer_0 = new System.Windows.Forms.Timer();
		@class.timer_0.Interval = 10;
		@class.timer_0.Tick += @class.method_0;
		@class.timer_0.Start();
	}

	// Token: 0x06000457 RID: 1111 RVA: 0x000215B4 File Offset: 0x0001F7B4
	public static bool smethod_22(this JToken jtoken_0)
	{
		return jtoken_0 == null || (jtoken_0.Type == JTokenType.Array && !jtoken_0.HasValues) || (jtoken_0.Type == JTokenType.Object && !jtoken_0.HasValues) || (jtoken_0.Type == JTokenType.String && jtoken_0.ToString() == string.Empty) || jtoken_0.Type == JTokenType.Null;
	}

	// Token: 0x06000458 RID: 1112 RVA: 0x00021610 File Offset: 0x0001F810
	public static Task smethod_23(this CancellationToken cancellationToken_0)
	{
		TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();
		cancellationToken_0.Register(new Action<object>(Class108.Class109.class109_0.method_1), taskCompletionSource);
		return taskCompletionSource.Task;
	}

	// Token: 0x020000AE RID: 174
	[Serializable]
	private sealed class Class109
	{
		// Token: 0x0600045B RID: 1115 RVA: 0x00004ADF File Offset: 0x00002CDF
		internal char method_0(string string_0)
		{
			return string_0[MainWindow.random_0.Next(string_0.Length)];
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x00004AF7 File Offset: 0x00002CF7
		internal void method_1(object object_0)
		{
			((TaskCompletionSource<bool>)object_0).SetResult(true);
		}

		// Token: 0x040001EE RID: 494
		public static readonly Class108.Class109 class109_0 = new Class108.Class109();

		// Token: 0x040001EF RID: 495
		public static Func<string, char> func_0;

		// Token: 0x040001F0 RID: 496
		public static Action<object> action_0;
	}

	// Token: 0x020000AF RID: 175
	private sealed class Class110
	{
		// Token: 0x0600045E RID: 1118 RVA: 0x00021654 File Offset: 0x0001F854
		internal void method_0(object sender, EventArgs e)
		{
			if (this.double_0 < 1.0)
			{
				this.double_0 += 0.05;
				this.form_0.Opacity += 0.05;
				return;
			}
			this.timer_0.Dispose();
			Action action = this.action_0;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x040001F1 RID: 497
		public double double_0;

		// Token: 0x040001F2 RID: 498
		public System.Windows.Forms.Timer timer_0;

		// Token: 0x040001F3 RID: 499
		public Action action_0;

		// Token: 0x040001F4 RID: 500
		public Form form_0;
	}

	// Token: 0x020000B0 RID: 176
	private sealed class Class111
	{
		// Token: 0x06000460 RID: 1120 RVA: 0x000216C0 File Offset: 0x0001F8C0
		internal void method_0(object sender, EventArgs e)
		{
			if (this.form_0.Opacity > 0.0)
			{
				this.form_0.Opacity -= 0.05;
				return;
			}
			this.timer_0.Dispose();
			this.form_0.Hide();
			Action action = this.action_0;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x040001F5 RID: 501
		public Form form_0;

		// Token: 0x040001F6 RID: 502
		public System.Windows.Forms.Timer timer_0;

		// Token: 0x040001F7 RID: 503
		public Action action_0;
	}

	// Token: 0x020000B1 RID: 177
	private sealed class Class112
	{
		// Token: 0x06000462 RID: 1122 RVA: 0x00004B05 File Offset: 0x00002D05
		internal bool method_0()
		{
			return this.scriptCall_0.WaitOne(5000);
		}

		// Token: 0x040001F8 RID: 504
		public ScriptCall scriptCall_0;
	}

	// Token: 0x020000B2 RID: 178
	private sealed class Class113
	{
		// Token: 0x06000464 RID: 1124 RVA: 0x00004B17 File Offset: 0x00002D17
		internal bool method_0()
		{
			return this.scriptCall_0.WaitOne(5000);
		}

		// Token: 0x040001F9 RID: 505
		public ScriptCall scriptCall_0;
	}

	// Token: 0x020000B3 RID: 179
	[StructLayout(LayoutKind.Auto)]
	private struct Struct51 : IAsyncStateMachine
	{
		// Token: 0x06000465 RID: 1125 RVA: 0x00021728 File Offset: 0x0001F928
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			string result;
			try
			{
				TaskAwaiter<bool> taskAwaiter;
				if (num != 0)
				{
					@class = new Class108.Class113();
					@class.scriptCall_0 = scriptCall_0;
					taskAwaiter = Task.Run<bool>(new Func<bool>(@class.method_0)).GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 0;
						TaskAwaiter<bool> taskAwaiter2 = taskAwaiter;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, Class108.Struct51>(ref taskAwaiter, ref this);
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
				result = @class.scriptCall_0.Result.ToString();
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

		// Token: 0x06000466 RID: 1126 RVA: 0x00004B29 File Offset: 0x00002D29
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040001FA RID: 506
		public int int_0;

		// Token: 0x040001FB RID: 507
		public AsyncTaskMethodBuilder<string> asyncTaskMethodBuilder_0;

		// Token: 0x040001FC RID: 508
		public ScriptCall scriptCall_0;

		// Token: 0x040001FD RID: 509
		private Class108.Class113 class113_0;

		// Token: 0x040001FE RID: 510
		private TaskAwaiter<bool> taskAwaiter_0;
	}
}
