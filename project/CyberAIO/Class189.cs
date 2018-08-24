using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using EO.WebBrowser;
using Newtonsoft.Json.Linq;

// Token: 0x0200019C RID: 412
internal sealed class Class189
{
	// Token: 0x0600088E RID: 2190 RVA: 0x0004CAB0 File Offset: 0x0004ACB0
	public static void smethod_0(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		string string_ = MainWindow.webView_0.QueueScriptCall("$('#test-site').val()").smethod_0();
		foreach (JToken jtoken in Class130.jarray_0)
		{
			Class189.smethod_2(jtoken["proxy"].ToString(), jtoken["id"].ToString(), string_);
		}
	}

	// Token: 0x0600088F RID: 2191 RVA: 0x0004CB34 File Offset: 0x0004AD34
	public static void smethod_1(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		string string_ = MainWindow.webView_0.QueueScriptCall("$('#test-site').val()").smethod_0();
		JObject jobject = JObject.Parse(jsextInvokeArgs_0.Arguments.First<object>().ToString());
		Class189.smethod_2(jobject["proxy"].ToString(), jobject["id"].ToString(), string_);
	}

	// Token: 0x06000890 RID: 2192 RVA: 0x0004CB94 File Offset: 0x0004AD94
	public static async void smethod_2(string string_0, string string_1, string string_2)
	{
		string string_3;
		string string_4;
		try
		{
			Class14 @class = new Class14(string_0, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36", 10, false, true, null);
			string a = string_2;
			string text;
			if (!(a == "Shopify"))
			{
				if (!(a == "Supreme"))
				{
					if (!(a == "Mesh"))
					{
						if (!(a == "Footsites"))
						{
							if (!(a == "Off-White"))
							{
								if (!(a == "Lacoste"))
								{
									text = string_2;
									try
									{
										string_2 = new Uri(text).Host;
										goto IL_12F;
									}
									catch
									{
										MainWindow.webView_0.QueueScriptCall(string.Format("updateProxyRow('{0}','Invalid URL',7,'red')", string_1));
										return;
									}
								}
								text = "https://www.lacoste.com/gb/";
							}
							else
							{
								text = "https://www.off---white.com/en/GB";
							}
						}
						else
						{
							text = "https://www.footaction.com/";
							@class.httpClient_0.DefaultRequestHeaders.ExpectContinue = new bool?(false);
							@class.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
						}
					}
					else
					{
						text = "https://prod.jdgroupmesh.cloud/stores/size/products/000987?api_key=3565AE9C56464BB0AD8020F735D1479E";
					}
				}
				else
				{
					text = "http://www.supremenewyork.com/shop/all";
				}
			}
			else
			{
				text = "https://kith.com/collections.json";
			}
			IL_12F:
			MainWindow.webView_0.QueueScriptCall(string.Format("updateProxyRow('{0}','Testing...',7,'orange')", string_1));
			MainWindow.webView_0.QueueScriptCall(string.Format("updateProxyRow('{0}','{1}',6,'#c2c2c2')", string_1, string_2));
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			TaskAwaiter<HttpResponseMessage> taskAwaiter = @class.method_2(text, false).GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<HttpResponseMessage> taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
			}
			HttpResponseMessage result = taskAwaiter.GetResult();
			stopwatch.Stop();
			long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
			if (result.IsSuccessStatusCode)
			{
				string_3 = elapsedMilliseconds.ToString() + "ms";
				string_4 = "#2BB873";
				if (string_2 == "Supreme")
				{
					TaskAwaiter<string> taskAwaiter3 = result.smethod_3().GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						await taskAwaiter3;
						TaskAwaiter<string> taskAwaiter4;
						taskAwaiter3 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<string>);
					}
					string arg = taskAwaiter3.GetResult().Contains("LDN") ? "EU" : "NYC";
					MainWindow.webView_0.QueueScriptCall(string.Format("updateProxyRow('{0}','Supreme {1}', 6, '#c2c2c2')", string_1, arg));
				}
			}
			else if (result.StatusCode == (HttpStatusCode)430)
			{
				string_3 = "Banned";
				string_4 = "Red";
			}
			else if (result.StatusCode == HttpStatusCode.ProxyAuthenticationRequired)
			{
				string_3 = "Authentication error";
				string_4 = "Red";
			}
			else
			{
				string_3 = string.Format("Error ({0})", (int)result.StatusCode);
				string_4 = "Red";
			}
			stopwatch = null;
		}
		catch
		{
			string_3 = "Error";
			string_4 = "Red";
		}
		Class189.smethod_3(string_1, string_4, string_3);
	}

	// Token: 0x06000891 RID: 2193 RVA: 0x00006B7A File Offset: 0x00004D7A
	public static void smethod_3(string string_0, string string_1, string string_2)
	{
		MainWindow.webView_0.QueueScriptCall(string.Format("updateProxyRow('{0}','{1}',7,'{2}')", string_0, string_2, string_1));
	}

	// Token: 0x0200019D RID: 413
	[StructLayout(LayoutKind.Auto)]
	private struct Struct167 : IAsyncStateMachine
	{
		// Token: 0x06000892 RID: 2194 RVA: 0x0004CBE0 File Offset: 0x0004ADE0
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			try
			{
				if (num > 1)
				{
				}
				try
				{
					TaskAwaiter<string> taskAwaiter5;
					TaskAwaiter<HttpResponseMessage> taskAwaiter6;
					if (num != 0)
					{
						if (num == 1)
						{
							taskAwaiter5 = taskAwaiter4;
							taskAwaiter4 = default(TaskAwaiter<string>);
							num2 = -1;
							goto IL_299;
						}
						Class14 @class = new Class14(string_0, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36", 10, false, true, null);
						string a = string_2;
						string uriString;
						if (!(a == "Shopify"))
						{
							if (!(a == "Supreme"))
							{
								if (!(a == "Mesh"))
								{
									if (!(a == "Footsites"))
									{
										if (!(a == "Off-White"))
										{
											if (!(a == "Lacoste"))
											{
												uriString = string_2;
												try
												{
													string_2 = new Uri(uriString).Host;
													goto IL_12F;
												}
												catch
												{
													MainWindow.webView_0.QueueScriptCall(string.Format("updateProxyRow('{0}','Invalid URL',7,'red')", string_1));
													goto IL_39D;
												}
											}
											uriString = "https://www.lacoste.com/gb/";
										}
										else
										{
											uriString = "https://www.off---white.com/en/GB";
										}
									}
									else
									{
										uriString = "https://www.footaction.com/";
										@class.httpClient_0.DefaultRequestHeaders.ExpectContinue = new bool?(false);
										@class.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
									}
								}
								else
								{
									uriString = "https://prod.jdgroupmesh.cloud/stores/size/products/000987?api_key=3565AE9C56464BB0AD8020F735D1479E";
								}
							}
							else
							{
								uriString = "http://www.supremenewyork.com/shop/all";
							}
						}
						else
						{
							uriString = "https://kith.com/collections.json";
						}
						IL_12F:
						MainWindow.webView_0.QueueScriptCall(string.Format("updateProxyRow('{0}','Testing...',7,'orange')", string_1));
						MainWindow.webView_0.QueueScriptCall(string.Format("updateProxyRow('{0}','{1}',6,'#c2c2c2')", string_1, string_2));
						stopwatch = new Stopwatch();
						stopwatch.Start();
						taskAwaiter6 = @class.method_2(uriString, false).GetAwaiter();
						if (!taskAwaiter6.IsCompleted)
						{
							num2 = 0;
							taskAwaiter2 = taskAwaiter6;
							this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class189.Struct167>(ref taskAwaiter6, ref this);
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
					stopwatch.Stop();
					long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
					if (result.IsSuccessStatusCode)
					{
						string_3 = elapsedMilliseconds.ToString() + "ms";
						string_4 = "#2BB873";
						if (!(string_2 == "Supreme"))
						{
							goto IL_349;
						}
						taskAwaiter5 = result.smethod_3().GetAwaiter();
						if (!taskAwaiter5.IsCompleted)
						{
							num2 = 1;
							taskAwaiter4 = taskAwaiter5;
							this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class189.Struct167>(ref taskAwaiter5, ref this);
							return;
						}
					}
					else
					{
						if (result.StatusCode == (HttpStatusCode)430)
						{
							string_3 = "Banned";
							string_4 = "Red";
							goto IL_349;
						}
						if (result.StatusCode == HttpStatusCode.ProxyAuthenticationRequired)
						{
							string_3 = "Authentication error";
							string_4 = "Red";
							goto IL_349;
						}
						string_3 = string.Format("Error ({0})", (int)result.StatusCode);
						string_4 = "Red";
						goto IL_349;
					}
					IL_299:
					string arg = taskAwaiter5.GetResult().Contains("LDN") ? "EU" : "NYC";
					MainWindow.webView_0.QueueScriptCall(string.Format("updateProxyRow('{0}','Supreme {1}', 6, '#c2c2c2')", string_1, arg));
					IL_349:
					stopwatch = null;
				}
				catch
				{
					string_3 = "Error";
					string_4 = "Red";
				}
				Class189.smethod_3(string_1, string_4, string_3);
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncVoidMethodBuilder_0.SetException(exception);
				return;
			}
			IL_39D:
			num2 = -2;
			this.asyncVoidMethodBuilder_0.SetResult();
		}

		// Token: 0x06000893 RID: 2195 RVA: 0x00006B94 File Offset: 0x00004D94
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000771 RID: 1905
		public int int_0;

		// Token: 0x04000772 RID: 1906
		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		// Token: 0x04000773 RID: 1907
		public string string_0;

		// Token: 0x04000774 RID: 1908
		public string string_1;

		// Token: 0x04000775 RID: 1909
		public string string_2;

		// Token: 0x04000776 RID: 1910
		private string string_3;

		// Token: 0x04000777 RID: 1911
		private string string_4;

		// Token: 0x04000778 RID: 1912
		private Stopwatch stopwatch_0;

		// Token: 0x04000779 RID: 1913
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x0400077A RID: 1914
		private TaskAwaiter<string> taskAwaiter_1;
	}
}
