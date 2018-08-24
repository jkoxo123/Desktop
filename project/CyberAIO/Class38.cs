using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

// Token: 0x0200004C RID: 76
internal static class Class38
{
	// Token: 0x06000171 RID: 369 RVA: 0x00003893 File Offset: 0x00001A93
	public static void smethod_0(this HttpResponseMessage httpResponseMessage_0)
	{
		if (!httpResponseMessage_0.IsSuccessStatusCode && httpResponseMessage_0.StatusCode != HttpStatusCode.Found)
		{
			httpResponseMessage_0.EnsureSuccessStatusCode();
		}
	}

	// Token: 0x06000172 RID: 370 RVA: 0x0001004C File Offset: 0x0000E24C
	public static async Task<JObject> smethod_1(this HttpResponseMessage httpResponseMessage_0)
	{
		JObject result;
		try
		{
			result = JObject.Parse(await httpResponseMessage_0.Content.ReadAsStringAsync());
		}
		catch
		{
			result = null;
		}
		return result;
	}

	// Token: 0x06000173 RID: 371 RVA: 0x00010094 File Offset: 0x0000E294
	public static async Task<JArray> smethod_2(this HttpResponseMessage httpResponseMessage_0)
	{
		JArray result;
		try
		{
			result = JArray.Parse(await httpResponseMessage_0.Content.ReadAsStringAsync());
		}
		catch
		{
			result = null;
		}
		return result;
	}

	// Token: 0x06000174 RID: 372 RVA: 0x000038B1 File Offset: 0x00001AB1
	public static Task<string> smethod_3(this HttpResponseMessage httpResponseMessage_0)
	{
		return httpResponseMessage_0.Content.ReadAsStringAsync();
	}

	// Token: 0x0200004D RID: 77
	[StructLayout(LayoutKind.Auto)]
	private struct Struct25 : IAsyncStateMachine
	{
		// Token: 0x06000175 RID: 373 RVA: 0x000100DC File Offset: 0x0000E2DC
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			JArray result;
			try
			{
				try
				{
					TaskAwaiter<string> taskAwaiter;
					if (num != 0)
					{
						taskAwaiter = httpResponseMessage_0.Content.ReadAsStringAsync().GetAwaiter();
						if (!taskAwaiter.IsCompleted)
						{
							num2 = 0;
							TaskAwaiter<string> taskAwaiter2 = taskAwaiter;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class38.Struct25>(ref taskAwaiter, ref this);
							return;
						}
					}
					else
					{
						TaskAwaiter<string> taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<string>);
						num2 = -1;
					}
					result = JArray.Parse(taskAwaiter.GetResult());
				}
				catch
				{
					result = null;
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

		// Token: 0x06000176 RID: 374 RVA: 0x000038BE File Offset: 0x00001ABE
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040000F8 RID: 248
		public int int_0;

		// Token: 0x040000F9 RID: 249
		public AsyncTaskMethodBuilder<JArray> asyncTaskMethodBuilder_0;

		// Token: 0x040000FA RID: 250
		public HttpResponseMessage httpResponseMessage_0;

		// Token: 0x040000FB RID: 251
		private TaskAwaiter<string> taskAwaiter_0;
	}

	// Token: 0x0200004E RID: 78
	[StructLayout(LayoutKind.Auto)]
	private struct Struct26 : IAsyncStateMachine
	{
		// Token: 0x06000177 RID: 375 RVA: 0x000101AC File Offset: 0x0000E3AC
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			JObject result;
			try
			{
				try
				{
					TaskAwaiter<string> taskAwaiter;
					if (num != 0)
					{
						taskAwaiter = httpResponseMessage_0.Content.ReadAsStringAsync().GetAwaiter();
						if (!taskAwaiter.IsCompleted)
						{
							num2 = 0;
							TaskAwaiter<string> taskAwaiter2 = taskAwaiter;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class38.Struct26>(ref taskAwaiter, ref this);
							return;
						}
					}
					else
					{
						TaskAwaiter<string> taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<string>);
						num2 = -1;
					}
					result = JObject.Parse(taskAwaiter.GetResult());
				}
				catch
				{
					result = null;
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

		// Token: 0x06000178 RID: 376 RVA: 0x000038CC File Offset: 0x00001ACC
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040000FC RID: 252
		public int int_0;

		// Token: 0x040000FD RID: 253
		public AsyncTaskMethodBuilder<JObject> asyncTaskMethodBuilder_0;

		// Token: 0x040000FE RID: 254
		public HttpResponseMessage httpResponseMessage_0;

		// Token: 0x040000FF RID: 255
		private TaskAwaiter<string> taskAwaiter_0;
	}
}
