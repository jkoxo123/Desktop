using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Newtonsoft.Json.Linq;

// Token: 0x02000165 RID: 357
internal static class Class170
{
	// Token: 0x060007C8 RID: 1992 RVA: 0x00045DD0 File Offset: 0x00043FD0
	public static async void smethod_0(string string_0, string string_1)
	{
		try
		{
			TaskAwaiter<bool> taskAwaiter = MainWindow.taskCompletionSource_0.Task.GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<bool> taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter<bool>);
			}
			taskAwaiter.GetResult();
			string text = null;
			string text2;
			if (string_0.StartsWith("http"))
			{
				Class170.Class172 @class = new Class170.Class172();
				@class.uri_0 = new Uri(string_0);
				text = string.Format("{0}://{1}", @class.uri_0.Scheme, @class.uri_0.Authority);
				JProperty jproperty = Class130.jobject_1.Properties().Where(new Func<JProperty, bool>(@class.method_0)).FirstOrDefault<JProperty>();
				text2 = ((jproperty != null) ? jproperty.Name : null);
			}
			else
			{
				List<string> list = string_0.Split(new char[]
				{
					':'
				}).ToList<string>();
				text2 = list[0].Replace('_', ' ');
				list.RemoveAt(0);
				string_0 = string.Join(":", list);
			}
			JToken jtoken = Class130.jobject_2.Values().Where(new Func<JToken, bool>(Class170.Class171.class171_0.method_0)).FirstOrDefault<JToken>();
			if (jtoken == null)
			{
				MainWindow.webView_0.QueueScriptCall("swal('No favourite profile set', 'You need to set a favourite profile in the billing tab to use the quick task feauture!', 'warning')");
			}
			else
			{
				JObject jobject = new JObject();
				jobject["keywords"] = string_0;
				jobject["store"] = (text2 ?? "Custom");
				jobject["custom_url"] = (text ?? null);
				jobject["login"] = false;
				jobject["size"] = "Random";
				jobject["profile"] = jtoken["name"];
				jobject["proxy"] = false;
				jobject["afk"] = false;
				string propertyName = "supreme";
				JObject jobject2 = new JObject();
				jobject2["category"] = "new";
				jobject2["color"] = string.Empty;
				jobject2["random"] = true;
				jobject[propertyName] = jobject2;
				jobject["bank_transfer"] = false;
				string text3 = MainWindow.webView_0.QueueScriptCall(string.Format("addTasks([JSON.parse('{0}')])", jobject.ToString().smethod_8())).smethod_0();
				TaskAwaiter<string> taskAwaiter3 = MainWindow.webView_0.QueueScriptCall("JSON.stringify(tasks)").smethod_2().GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<string> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<string>);
				}
				Class130.jobject_3 = JObject.Parse(taskAwaiter3.GetResult());
				if (string_1 != null)
				{
					Class170.dictionary_0[string_1] = text3;
				}
				JObject jobject3 = new JObject();
				jobject3[text3] = Class130.jobject_3[text3];
				Class26.smethod_1(jobject3, string_1);
				text3 = null;
			}
		}
		catch
		{
		}
	}

	// Token: 0x060007C9 RID: 1993 RVA: 0x00045E14 File Offset: 0x00044014
	public static void smethod_1(string string_0)
	{
		string text = Class170.dictionary_0.ContainsKey(string_0) ? Class170.dictionary_0[string_0] : string_0;
		JObject jobject = new JObject();
		string propertyName = text;
		jobject[propertyName] = Class130.jobject_3[text];
		Class26.smethod_3(jobject);
	}

	// Token: 0x04000695 RID: 1685
	public static Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();

	// Token: 0x02000166 RID: 358
	[Serializable]
	private sealed class Class171
	{
		// Token: 0x060007CC RID: 1996 RVA: 0x00006627 File Offset: 0x00004827
		internal bool method_0(JToken jtoken_0)
		{
			return jtoken_0["favourite"] != null && (bool)jtoken_0["favourite"];
		}

		// Token: 0x04000696 RID: 1686
		public static readonly Class170.Class171 class171_0 = new Class170.Class171();

		// Token: 0x04000697 RID: 1687
		public static Func<JToken, bool> func_0;
	}

	// Token: 0x02000167 RID: 359
	private sealed class Class172
	{
		// Token: 0x060007CE RID: 1998 RVA: 0x00006648 File Offset: 0x00004848
		internal bool method_0(JProperty jproperty_0)
		{
			return jproperty_0.Value["sitemap"] != null && jproperty_0.Value["sitemap"].ToString().Contains(this.uri_0.Host);
		}

		// Token: 0x04000698 RID: 1688
		public Uri uri_0;
	}

	// Token: 0x02000168 RID: 360
	[StructLayout(LayoutKind.Auto)]
	private struct Struct143 : IAsyncStateMachine
	{
		// Token: 0x060007CF RID: 1999 RVA: 0x00045E5C File Offset: 0x0004405C
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			try
			{
				try
				{
					TaskAwaiter<string> taskAwaiter5;
					TaskAwaiter<bool> taskAwaiter6;
					if (num != 0)
					{
						if (num == 1)
						{
							taskAwaiter5 = taskAwaiter4;
							taskAwaiter4 = default(TaskAwaiter<string>);
							num2 = -1;
							goto IL_31F;
						}
						taskAwaiter6 = MainWindow.taskCompletionSource_0.Task.GetAwaiter();
						if (!taskAwaiter6.IsCompleted)
						{
							num2 = 0;
							taskAwaiter2 = taskAwaiter6;
							this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, Class170.Struct143>(ref taskAwaiter6, ref this);
							return;
						}
					}
					else
					{
						taskAwaiter6 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<bool>);
						num2 = -1;
					}
					taskAwaiter6.GetResult();
					string text4 = null;
					string text5;
					if (string_0.StartsWith("http"))
					{
						Class170.Class172 @class = new Class170.Class172();
						@class.uri_0 = new Uri(string_0);
						text4 = string.Format("{0}://{1}", @class.uri_0.Scheme, @class.uri_0.Authority);
						JProperty jproperty = Class130.jobject_1.Properties().Where(new Func<JProperty, bool>(@class.method_0)).FirstOrDefault<JProperty>();
						text5 = ((jproperty != null) ? jproperty.Name : null);
					}
					else
					{
						List<string> list = string_0.Split(new char[]
						{
							':'
						}).ToList<string>();
						text5 = list[0].Replace('_', ' ');
						list.RemoveAt(0);
						string_0 = string.Join(":", list);
					}
					JToken jtoken = Class130.jobject_2.Values().Where(new Func<JToken, bool>(Class170.Class171.class171_0.method_0)).FirstOrDefault<JToken>();
					if (jtoken == null)
					{
						MainWindow.webView_0.QueueScriptCall("swal('No favourite profile set', 'You need to set a favourite profile in the billing tab to use the quick task feauture!', 'warning')");
						goto IL_3A5;
					}
					JObject jobject = new JObject();
					jobject["keywords"] = string_0;
					jobject["store"] = (text5 ?? "Custom");
					jobject["custom_url"] = (text4 ?? null);
					jobject["login"] = false;
					jobject["size"] = "Random";
					jobject["profile"] = jtoken["name"];
					jobject["proxy"] = false;
					jobject["afk"] = false;
					string propertyName = "supreme";
					JObject jobject2 = new JObject();
					jobject2["category"] = "new";
					jobject2["color"] = string.Empty;
					jobject2["random"] = true;
					jobject[propertyName] = jobject2;
					jobject["bank_transfer"] = false;
					JObject jobject3 = jobject;
					text3 = MainWindow.webView_0.QueueScriptCall(string.Format("addTasks([JSON.parse('{0}')])", jobject3.ToString().smethod_8())).smethod_0();
					taskAwaiter5 = MainWindow.webView_0.QueueScriptCall("JSON.stringify(tasks)").smethod_2().GetAwaiter();
					if (!taskAwaiter5.IsCompleted)
					{
						num2 = 1;
						taskAwaiter4 = taskAwaiter5;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class170.Struct143>(ref taskAwaiter5, ref this);
						return;
					}
					IL_31F:
					Class130.jobject_3 = JObject.Parse(taskAwaiter5.GetResult());
					if (string_1 != null)
					{
						Class170.dictionary_0[string_1] = text3;
					}
					JObject jobject4 = new JObject();
					string propertyName2 = text3;
					jobject4[propertyName2] = Class130.jobject_3[text3];
					Class26.smethod_1(jobject4, string_1);
					text3 = null;
				}
				catch
				{
				}
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncVoidMethodBuilder_0.SetException(exception);
				return;
			}
			IL_3A5:
			num2 = -2;
			this.asyncVoidMethodBuilder_0.SetResult();
		}

		// Token: 0x060007D0 RID: 2000 RVA: 0x00006683 File Offset: 0x00004883
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000699 RID: 1689
		public int int_0;

		// Token: 0x0400069A RID: 1690
		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		// Token: 0x0400069B RID: 1691
		public string string_0;

		// Token: 0x0400069C RID: 1692
		public string string_1;

		// Token: 0x0400069D RID: 1693
		private string string_2;

		// Token: 0x0400069E RID: 1694
		private TaskAwaiter<bool> taskAwaiter_0;

		// Token: 0x0400069F RID: 1695
		private TaskAwaiter<string> taskAwaiter_1;
	}
}
