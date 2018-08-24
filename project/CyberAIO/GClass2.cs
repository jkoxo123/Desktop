using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

// Token: 0x02000050 RID: 80
public sealed class GClass2
{
	// Token: 0x0600017D RID: 381 RVA: 0x0001027C File Offset: 0x0000E47C
	public static async Task smethod_0(GClass4 gclass4_0, string string_0, JObject jobject_0)
	{
		int num = 0;
		while ((int)DateTime.Now.Subtract(gclass4_0.dateTime_0).TotalMilliseconds < Class130.int_0 + 1000)
		{
			JToken jtoken = (Class130.jarray_0.Count > 0) ? Class130.jarray_0[num] : null;
			try
			{
				using (Class14 @class = new Class14((string)((jtoken != null) ? jtoken["proxy"] : null), "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36", 10, true, false, jobject_0))
				{
					gclass4_0.task_1 = @class.method_2(string_0, true);
					await gclass4_0.task_1;
				}
				Class14 @class = null;
				goto IL_19D;
			}
			catch
			{
				goto IL_19D;
			}
			goto IL_11D;
			IL_124:
			TaskAwaiter taskAwaiter = Task.Delay(Class130.int_0).GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter);
			}
			taskAwaiter.GetResult();
			continue;
			IL_11D:
			num = 0;
			goto IL_124;
			IL_19D:
			num++;
			if (num >= Class130.jarray_0.Count)
			{
				goto IL_11D;
			}
			goto IL_124;
		}
	}

	// Token: 0x0600017E RID: 382 RVA: 0x000102D4 File Offset: 0x0000E4D4
	public static Task<HttpResponseMessage> smethod_1(string string_0, JObject jobject_0, bool bool_0)
	{
		if (GClass2.concurrentDictionary_0.ContainsKey(string_0))
		{
			if (GClass2.concurrentDictionary_0[string_0].task_0.Status == TaskStatus.WaitingForActivation)
			{
				GClass2.concurrentDictionary_0[string_0].dateTime_0 = DateTime.Now;
				goto IL_8B;
			}
		}
		if (bool_0)
		{
			GClass3.smethod_0("Starting monitor for: " + new Uri(string_0).Authority, "Monitor");
		}
		GClass4 gclass = new GClass4();
		GClass2.concurrentDictionary_0[string_0] = gclass;
		GClass2.concurrentDictionary_0[string_0].task_0 = GClass2.smethod_0(gclass, string_0, jobject_0);
		IL_8B:
		return GClass2.concurrentDictionary_0[string_0].task_1;
	}

	// Token: 0x04000100 RID: 256
	public static ConcurrentDictionary<string, GClass4> concurrentDictionary_0 = new ConcurrentDictionary<string, GClass4>();

	// Token: 0x02000051 RID: 81
	[StructLayout(LayoutKind.Auto)]
	private struct Struct27 : IAsyncStateMachine
	{
		// Token: 0x0600017F RID: 383 RVA: 0x0001037C File Offset: 0x0000E57C
		void IAsyncStateMachine.MoveNext()
		{
			int num3;
			int num2 = num3;
			try
			{
				TaskAwaiter taskAwaiter3;
				if (num2 != 0)
				{
					if (num2 != 1)
					{
						num = 0;
						goto IL_147;
					}
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					int num4 = -1;
					num2 = -1;
					num3 = num4;
					goto IL_140;
				}
				IL_3B:
				try
				{
					if (num2 != 0)
					{
						JToken jtoken;
						@class = new Class14((string)((jtoken != null) ? jtoken["proxy"] : null), "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36", 10, true, false, jobject_0);
					}
					try
					{
						TaskAwaiter<HttpResponseMessage> taskAwaiter4;
						if (num2 != 0)
						{
							gclass4_0.task_1 = @class.method_2(string_0, true);
							taskAwaiter4 = gclass4_0.task_1.GetAwaiter();
							if (!taskAwaiter4.IsCompleted)
							{
								int num5 = 0;
								num2 = 0;
								num3 = num5;
								TaskAwaiter<HttpResponseMessage> taskAwaiter5 = taskAwaiter4;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, GClass2.Struct27>(ref taskAwaiter4, ref this);
								return;
							}
						}
						else
						{
							TaskAwaiter<HttpResponseMessage> taskAwaiter5;
							taskAwaiter4 = taskAwaiter5;
							taskAwaiter5 = default(TaskAwaiter<HttpResponseMessage>);
							int num6 = -1;
							num2 = -1;
							num3 = num6;
						}
						taskAwaiter4.GetResult();
					}
					finally
					{
						if (num2 < 0 && @class != null)
						{
							((IDisposable)@class).Dispose();
						}
					}
					@class = null;
					goto IL_19D;
				}
				catch
				{
					goto IL_19D;
				}
				IL_11D:
				num = 0;
				IL_124:
				taskAwaiter3 = Task.Delay(Class130.int_0).GetAwaiter();
				if (taskAwaiter3.IsCompleted)
				{
					goto IL_140;
				}
				int num7 = 1;
				num2 = 1;
				num3 = num7;
				taskAwaiter2 = taskAwaiter3;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, GClass2.Struct27>(ref taskAwaiter3, ref this);
				return;
				IL_19D:
				int num8 = num;
				num = num8 + 1;
				if (num >= Class130.jarray_0.Count)
				{
					goto IL_11D;
				}
				goto IL_124;
				IL_140:
				taskAwaiter3.GetResult();
				IL_147:
				if ((int)DateTime.Now.Subtract(gclass4_0.dateTime_0).TotalMilliseconds < Class130.int_0 + 1000)
				{
					JToken jtoken = (Class130.jarray_0.Count > 0) ? Class130.jarray_0[num] : null;
					goto IL_3B;
				}
			}
			catch (Exception exception)
			{
				num3 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			num3 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000180 RID: 384 RVA: 0x000038E6 File Offset: 0x00001AE6
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000101 RID: 257
		public int int_0;

		// Token: 0x04000102 RID: 258
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000103 RID: 259
		public JObject jobject_0;

		// Token: 0x04000104 RID: 260
		public GClass4 gclass4_0;

		// Token: 0x04000105 RID: 261
		public string string_0;

		// Token: 0x04000106 RID: 262
		private int int_1;

		// Token: 0x04000107 RID: 263
		private Class14 class14_0;

		// Token: 0x04000108 RID: 264
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000109 RID: 265
		private TaskAwaiter taskAwaiter_1;
	}
}
