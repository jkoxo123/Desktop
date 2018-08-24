using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using EO.WebBrowser;
using Newtonsoft.Json.Linq;

// Token: 0x02000038 RID: 56
internal sealed class Class26
{
	// Token: 0x0600011A RID: 282 RVA: 0x00003584 File Offset: 0x00001784
	public static void smethod_0(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		Class26.smethod_1(JObject.Parse(jsextInvokeArgs_0.Arguments.First<object>().ToString()), null);
	}

	// Token: 0x0600011B RID: 283 RVA: 0x0000D864 File Offset: 0x0000BA64
	public static void smethod_1(JObject jobject_0, string string_0)
	{
		try
		{
			foreach (JToken jtoken in jobject_0.Values())
			{
				if (!Class130.dictionary_0.ContainsKey((int)jtoken["id"]))
				{
					MainWindow.webView_0.QueueScriptCall(string.Format("updateButton({0},true)", jtoken["id"]));
					string text = jtoken["store"].ToString().ToLower();
					uint num = Class79.smethod_0(text);
					Class44 @class;
					if (num <= 2430139328u)
					{
						if (num <= 1369243890u)
						{
							if (num <= 650952027u)
							{
								if (num <= 536391395u)
								{
									if (num != 75628775u)
									{
										if (num != 536391395u)
										{
											goto IL_6E9;
										}
										if (!(text == "net-a-porter us"))
										{
											goto IL_6E9;
										}
										@class = new Class50(jtoken, "am", "us");
									}
									else
									{
										if (!(text == "footpatrol"))
										{
											goto IL_6E9;
										}
										@class = new Class45(jtoken, "footpatrol", "AD60F89E1BB248F388B9FC671851A2B8");
									}
								}
								else if (num != 634394085u)
								{
									if (num != 650952027u)
									{
										goto IL_6E9;
									}
									if (!(text == "footaction"))
									{
										goto IL_6E9;
									}
									@class = new Class51(jtoken, "footaction.com");
								}
								else
								{
									if (!(text == "net-a-porter eu"))
									{
										goto IL_6E9;
									}
									@class = new Class50(jtoken, "intl", "gb");
								}
							}
							else if (num <= 1003079584u)
							{
								if (num != 988777544u)
								{
									if (num != 1003079584u)
									{
										goto IL_6E9;
									}
									if (!(text == "champs sports"))
									{
										goto IL_6E9;
									}
									@class = new Class47(jtoken, "champssports.com");
								}
								else
								{
									if (!(text == "the hip store"))
									{
										goto IL_6E9;
									}
									@class = new Class45(jtoken, "thehipstore", "117860D26D504A5FB26B2FB64CE35FB8");
								}
							}
							else if (num != 1271241200u)
							{
								if (num != 1369243890u)
								{
									goto IL_6E9;
								}
								if (!(text == "supreme eu"))
								{
									goto IL_6E9;
								}
								@class = new Class54(jtoken, "EU");
							}
							else
							{
								if (!(text == "supreme us"))
								{
									goto IL_6E9;
								}
								@class = new Class54(jtoken, "US");
							}
						}
						else if (num <= 2033596121u)
						{
							if (num <= 1613681225u)
							{
								if (num != 1374915048u)
								{
									if (num != 1613681225u)
									{
										goto IL_6E9;
									}
									if (!(text == "footlocker us "))
									{
										goto IL_6E9;
									}
									@class = new Class51(jtoken, "footlocker.com");
								}
								else
								{
									if (!(text == "eastbay"))
									{
										goto IL_6E9;
									}
									@class = new Class47(jtoken, "eastbay.com");
								}
							}
							else if (num != 1819840374u)
							{
								if (num != 2033596121u)
								{
									goto IL_6E9;
								}
								if (!(text == "size?"))
								{
									goto IL_6E9;
								}
								@class = new Class45(jtoken, "size", "3565AE9C56464BB0AD8020F735D1479E");
							}
							else
							{
								if (!(text == "jd sports"))
								{
									goto IL_6E9;
								}
								@class = new Class45(jtoken, "jdsports", "60743806B14F4AF389F582E83A141733");
							}
						}
						else if (num <= 2404272289u)
						{
							if (num != 2191237913u)
							{
								if (num != 2404272289u)
								{
									goto IL_6E9;
								}
								if (!(text == "footaction "))
								{
									goto IL_6E9;
								}
								@class = new Class51(jtoken, "footaction.com");
							}
							else
							{
								if (!(text == "footlocker ca "))
								{
									goto IL_6E9;
								}
								@class = new Class51(jtoken, "footlocker.ca");
							}
						}
						else if (num != 2407667328u)
						{
							if (num != 2414935827u)
							{
								if (num != 2430139328u)
								{
									goto IL_6E9;
								}
								if (!(text == "lacoste nl"))
								{
									goto IL_6E9;
								}
								@class = new Class53(jtoken, "/on/demandware.store/Sites-NL-Site/fr/");
							}
							else
							{
								if (!(text == "lacoste dk"))
								{
									goto IL_6E9;
								}
								@class = new Class53(jtoken, "/on/demandware.store/Sites-DK-Site/fr/");
							}
						}
						else
						{
							if (!(text == "mr porter eu"))
							{
								goto IL_6E9;
							}
							@class = new Class46(jtoken, "intl", "gb");
						}
					}
					else if (num <= 2661617280u)
					{
						if (num <= 2551966898u)
						{
							if (num <= 2500795398u)
							{
								if (num != 2464533209u)
								{
									if (num != 2500795398u)
									{
										goto IL_6E9;
									}
									if (!(text == "lacoste pl"))
									{
										goto IL_6E9;
									}
									@class = new Class53(jtoken, "/on/demandware.store/Sites-PL-Site/fr/");
								}
								else
								{
									if (!(text == "lacoste ch"))
									{
										goto IL_6E9;
									}
									@class = new Class53(jtoken, "/on/demandware.store/Sites-CH-Site/fr/");
								}
							}
							else if (num != 2505773186u)
							{
								if (num != 2551966898u)
								{
									goto IL_6E9;
								}
								if (!(text == "lacoste uk"))
								{
									goto IL_6E9;
								}
								@class = new Class53(jtoken, "/on/demandware.store/Sites-GB-Site/en/");
							}
							else
							{
								if (!(text == "mr porter us"))
								{
									goto IL_6E9;
								}
								@class = new Class46(jtoken, "am", "us");
							}
						}
						else if (num <= 2581976542u)
						{
							if (num != 2563815827u)
							{
								if (num != 2581976542u)
								{
									goto IL_6E9;
								}
								if (!(text == "lacoste ca"))
								{
									goto IL_6E9;
								}
								@class = new Class53(jtoken, "/on/demandware.store/Sites-CA-Site/fr/");
							}
							else
							{
								if (!(text == "lacoste kr"))
								{
									goto IL_6E9;
								}
								@class = new Class53(jtoken, "/on/demandware.store/Sites-KR-Site/fr/");
							}
						}
						else if (num != 2599048351u)
						{
							if (num != 2649822493u)
							{
								if (num != 2661617280u)
								{
									goto IL_6E9;
								}
								if (!(text == "champs sports "))
								{
									goto IL_6E9;
								}
								@class = new Class51(jtoken, "champssports.com");
							}
							else
							{
								if (!(text == "lacoste de"))
								{
									goto IL_6E9;
								}
								@class = new Class53(jtoken, "/on/demandware.store/Sites-DE-Site/fr/");
							}
						}
						else
						{
							if (!(text == "lacoste at"))
							{
								goto IL_6E9;
							}
							@class = new Class53(jtoken, "/on/demandware.store/Sites-AT-Site/fr/");
						}
					}
					else if (num <= 3023372879u)
					{
						if (num <= 2866210327u)
						{
							if (num != 2666305922u)
							{
								if (num != 2866210327u)
								{
									goto IL_6E9;
								}
								if (!(text == "lacoste it"))
								{
									goto IL_6E9;
								}
								@class = new Class53(jtoken, "/on/demandware.store/Sites-IT-Site/fr/");
							}
							else
							{
								if (!(text == "lacoste fr"))
								{
									goto IL_6E9;
								}
								@class = new Class53(jtoken, "/on/demandware.store/Sites-FR-Site/fr/");
							}
						}
						else if (num != 2954629754u)
						{
							if (num != 3023372879u)
							{
								goto IL_6E9;
							}
							if (!(text == "footlocker eu "))
							{
								goto IL_6E9;
							}
							@class = new Class49(jtoken);
						}
						else
						{
							if (!(text == "lacoste us"))
							{
								goto IL_6E9;
							}
							@class = new Class53(jtoken, "/on/demandware.store/Sites-FlagShip-Site/en_US/");
						}
					}
					else if (num <= 3395413464u)
					{
						if (num != 3117874612u)
						{
							if (num != 3395413464u)
							{
								goto IL_6E9;
							}
							if (!(text == "eastbay "))
							{
								goto IL_6E9;
							}
							@class = new Class51(jtoken, "eastbay.com");
						}
						else
						{
							if (!(text == "lacoste ie"))
							{
								goto IL_6E9;
							}
							@class = new Class53(jtoken, "/on/demandware.store/Sites-IE-Site/fr/");
						}
					}
					else if (num != 3491784070u)
					{
						if (num != 3987781139u)
						{
							if (num != 4224345091u)
							{
								goto IL_6E9;
							}
							if (!(text == "footlocker ca"))
							{
								goto IL_6E9;
							}
							@class = new Class47(jtoken, "footlocker.ca");
						}
						else
						{
							if (!(text == "footlocker us"))
							{
								goto IL_6E9;
							}
							@class = new Class47(jtoken, "footlocker.com");
						}
					}
					else
					{
						if (!(text == "off-white"))
						{
							goto IL_6E9;
						}
						@class = new Class48(jtoken);
					}
					IL_6FA:
					if (!@class.bool_1)
					{
						Class130.dictionary_0[(int)jtoken["id"]] = @class;
						@class.vmethod_0();
						continue;
					}
					continue;
					IL_6E9:
					@class = new Class52(jtoken, string_0);
					goto IL_6FA;
				}
			}
		}
		catch
		{
		}
	}

	// Token: 0x0600011C RID: 284 RVA: 0x000035A1 File Offset: 0x000017A1
	public static void smethod_2(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		Class26.smethod_3(JObject.Parse(jsextInvokeArgs_0.Arguments.First<object>().ToString()));
	}

	// Token: 0x0600011D RID: 285 RVA: 0x0000DFE8 File Offset: 0x0000C1E8
	public static async void smethod_3(JObject jobject_0)
	{
		try
		{
			List<Task> list = new List<Task>();
			using (IEnumerator<JToken> enumerator = jobject_0.Values().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					Class26.Class27 @class = new Class26.Class27();
					@class.jtoken_0 = enumerator.Current;
					if (Class130.dictionary_0.ContainsKey((int)@class.jtoken_0["id"]) && !Class130.dictionary_0[(int)@class.jtoken_0["id"]].bool_1)
					{
						list.Add(Task.Run(new Action(@class.method_0)));
						if (list.Count >= 10)
						{
							TaskAwaiter taskAwaiter = Task.WhenAll(list).GetAwaiter();
							if (!taskAwaiter.IsCompleted)
							{
								await taskAwaiter;
								TaskAwaiter taskAwaiter2;
								taskAwaiter = taskAwaiter2;
								taskAwaiter2 = default(TaskAwaiter);
							}
							taskAwaiter.GetResult();
							list.Clear();
						}
					}
				}
			}
			IEnumerator<JToken> enumerator = null;
			list = null;
		}
		catch
		{
		}
	}

	// Token: 0x02000039 RID: 57
	private sealed class Class27
	{
		// Token: 0x0600011F RID: 287 RVA: 0x000035BD File Offset: 0x000017BD
		internal void method_0()
		{
			Class130.dictionary_0[(int)this.jtoken_0["id"]].method_0("Stopped", "red", false, (GEnum1)0);
		}

		// Token: 0x040000C2 RID: 194
		public JToken jtoken_0;
	}

	// Token: 0x0200003A RID: 58
	[StructLayout(LayoutKind.Auto)]
	private struct Struct23 : IAsyncStateMachine
	{
		// Token: 0x06000120 RID: 288 RVA: 0x0000E024 File Offset: 0x0000C224
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			try
			{
				try
				{
					if (num != 0)
					{
						list = new List<Task>();
						enumerator = jobject_0.Values().GetEnumerator();
					}
					try
					{
						TaskAwaiter taskAwaiter3;
						if (num == 0)
						{
							taskAwaiter3 = taskAwaiter2;
							taskAwaiter2 = default(TaskAwaiter);
							int num3 = -1;
							num = -1;
							num2 = num3;
							goto IL_108;
						}
						IL_DC:
						while (enumerator.MoveNext())
						{
							Class26.Class27 @class = new Class26.Class27();
							@class.jtoken_0 = enumerator.Current;
							if (Class130.dictionary_0.ContainsKey((int)@class.jtoken_0["id"]) && !Class130.dictionary_0[(int)@class.jtoken_0["id"]].bool_1)
							{
								list.Add(Task.Run(new Action(@class.method_0)));
								if (list.Count >= 10)
								{
									taskAwaiter3 = Task.WhenAll(list).GetAwaiter();
									if (taskAwaiter3.IsCompleted)
									{
										goto IL_108;
									}
									int num4 = 0;
									num = 0;
									num2 = num4;
									taskAwaiter2 = taskAwaiter3;
									this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class26.Struct23>(ref taskAwaiter3, ref this);
									return;
								}
							}
						}
						goto IL_156;
						IL_108:
						taskAwaiter3.GetResult();
						list.Clear();
						goto IL_DC;
					}
					finally
					{
						if (num < 0 && enumerator != null)
						{
							enumerator.Dispose();
						}
					}
					IL_156:
					enumerator = null;
					list = null;
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
			num2 = -2;
			this.asyncVoidMethodBuilder_0.SetResult();
		}

		// Token: 0x06000121 RID: 289 RVA: 0x000035EF File Offset: 0x000017EF
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040000C3 RID: 195
		public int int_0;

		// Token: 0x040000C4 RID: 196
		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		// Token: 0x040000C5 RID: 197
		public JObject jobject_0;

		// Token: 0x040000C6 RID: 198
		private List<Task> list_0;

		// Token: 0x040000C7 RID: 199
		private IEnumerator<JToken> ienumerator_0;

		// Token: 0x040000C8 RID: 200
		private TaskAwaiter taskAwaiter_0;
	}
}
