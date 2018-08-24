using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

// Token: 0x0200005D RID: 93
internal abstract class Class44
{
	// Token: 0x060001D0 RID: 464
	public abstract void vmethod_0();

	// Token: 0x060001D1 RID: 465 RVA: 0x00011430 File Offset: 0x0000F630
	public async void method_0(string string_7, string string_8, bool bool_3, GEnum1 genum1_0)
	{
		try
		{
			this.bool_1 = true;
			if (bool_3 && !this.bool_2)
			{
				this.bool_2 = bool_3;
				this.method_5(string_7, string_8, true, true);
				if (genum1_0 != (GEnum1)5)
				{
					if (genum1_0 == (GEnum1)6)
					{
						this.method_1();
						TaskAwaiter taskAwaiter = this.method_8(true).GetAwaiter();
						if (!taskAwaiter.IsCompleted)
						{
							await taskAwaiter;
							TaskAwaiter taskAwaiter2;
							taskAwaiter = taskAwaiter2;
							taskAwaiter2 = default(TaskAwaiter);
						}
						taskAwaiter.GetResult();
					}
				}
				else
				{
					TaskAwaiter taskAwaiter = this.method_8(false).GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						await taskAwaiter;
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
					}
					taskAwaiter.GetResult();
				}
				if (this.class14_0 != null)
				{
					this.class14_0.httpClient_0.Dispose();
				}
				this.cancellationTokenSource_0.Dispose();
				Class130.dictionary_0.Remove((int)this.jtoken_0["id"]);
				MainWindow.webView_0.QueueScriptCall(string.Format("updateButton({0},false)", this.jtoken_0["id"]));
			}
			else if (!bool_3)
			{
				this.bool_2 = bool_3;
				this.method_5("Stopping...", "orange", true, true);
				this.cancellationTokenSource_0.Cancel();
				this.class14_0.httpClient_0.CancelPendingRequests();
			}
		}
		catch
		{
		}
	}

	// Token: 0x060001D2 RID: 466 RVA: 0x0001148C File Offset: 0x0000F68C
	private void method_1()
	{
		if ((bool)this.jtoken_1["one_checkout"])
		{
			foreach (KeyValuePair<int, Class44> keyValuePair in Class130.dictionary_0)
			{
				if (keyValuePair.Value.bool_1)
				{
					break;
				}
				if ((string)keyValuePair.Value.jtoken_0["profile"] == (string)this.jtoken_0["profile"] && keyValuePair.Value.jtoken_0["product"].ToString() == this.jtoken_0["product"].ToString())
				{
					keyValuePair.Value.method_0("Billing used", "red", true, (GEnum1)0);
				}
			}
		}
	}

	// Token: 0x060001D3 RID: 467 RVA: 0x00011594 File Offset: 0x0000F794
	public bool method_2(out JToken jtoken_2)
	{
		bool result;
		try
		{
			jtoken_2 = Class130.jobject_2[(string)this.jtoken_0["profile"]];
			this.jtoken_1 = jtoken_2;
			result = (jtoken_2 != null);
		}
		catch
		{
			jtoken_2 = null;
			result = false;
		}
		return result;
	}

	// Token: 0x060001D4 RID: 468 RVA: 0x000115EC File Offset: 0x0000F7EC
	public string method_3()
	{
		string result;
		try
		{
			if (this.jtoken_0["proxy"].ToString() != "False")
			{
				result = this.jtoken_0["proxy"].ToString();
			}
			else
			{
				short num = Convert.ToInt16(MainWindow.webView_0.QueueScriptCall(string.Format("$('#row{0}').index()", this.jtoken_0["id"])).smethod_0());
				JArray jarray_ = Class130.jarray_0;
				if ((int)num > jarray_.Count<JToken>() - 1)
				{
					MainWindow.webView_0.QueueScriptCall(string.Format("updateTable('none','#c2c2c2',{0},6)", this.jtoken_0["id"]));
					result = null;
				}
				else
				{
					string text = jarray_[(int)num]["proxy"].ToString();
					MainWindow.webView_0.QueueScriptCall(string.Format("updateTable('{0}','#c2c2c2',{1},6)", text, this.jtoken_0["id"]));
					result = text;
				}
			}
		}
		catch
		{
			MainWindow.webView_0.QueueScriptCall(string.Format("updateTable('none','#c2c2c2',{0},6)", this.jtoken_0["id"]));
			result = null;
		}
		return result;
	}

	// Token: 0x060001D5 RID: 469 RVA: 0x00003B9A File Offset: 0x00001D9A
	public void method_4(string string_7)
	{
		MainWindow.webView_0.QueueScriptCall(string.Format("updateTable('{0}','#c2c2c2',{1},1)", string_7, this.jtoken_0["id"]));
		this.jtoken_0["store"] = string_7;
	}

	// Token: 0x060001D6 RID: 470 RVA: 0x0001171C File Offset: 0x0000F91C
	public void method_5(string string_7, string string_8, bool bool_3, bool bool_4)
	{
		if ((!this.bool_1 || bool_4) && string_7 != this.string_6)
		{
			this.string_6 = string_7;
			if (string_7.ToLower().Contains("error"))
			{
				string_8 = "red";
			}
			MainWindow.webView_0.QueueScriptCall(string.Format("updateTable('{0}','{1}',{2},7)", string_7.smethod_8(), string_8, this.jtoken_0["id"]));
			if (bool_3)
			{
				GClass3.smethod_0(string_7, "Task " + this.jtoken_0["id"]);
			}
			if (this.string_5 != null)
			{
				JObject jobject = new JObject();
				string propertyName = "quicktask";
				JObject jobject2 = new JObject();
				jobject2["id"] = this.string_5;
				jobject2["status"] = string_7;
				jobject2["color"] = string_8;
				jobject[propertyName] = jobject2;
				Class60.smethod_0(jobject);
			}
		}
	}

	// Token: 0x060001D7 RID: 471 RVA: 0x00003BD8 File Offset: 0x00001DD8
	public void method_6(string string_7)
	{
		MainWindow.webView_0.QueueScriptCall(string.Format("updateTable('{0}','#c2c2c2',{1},3)", string_7.smethod_8(), this.jtoken_0["id"]));
		this.string_0 = string_7;
	}

	// Token: 0x060001D8 RID: 472 RVA: 0x00011818 File Offset: 0x0000FA18
	public void method_7(string string_7, string string_8)
	{
		this.jtoken_0["product"] = string_7;
		MainWindow.webView_0.QueueScriptCall(string.Format("updateTable('{0}','{1}',{2},2)", string_7.smethod_8(), string_8, this.jtoken_0["id"]));
	}

	// Token: 0x060001D9 RID: 473 RVA: 0x00011868 File Offset: 0x0000FA68
	private Task method_8(bool bool_3)
	{
		Class44.Class55 @class = new Class44.Class55();
		@class.bool_0 = bool_3;
		@class.class44_0 = this;
		Task result;
		try
		{
			Class44.soundPlayer_0.Play();
			if (Class130.bool_0)
			{
				MethodInvoker method = new MethodInvoker(@class.method_0);
				MainWindow.mainWindow_0.Invoke(method);
			}
			result = Task.WhenAny(new Task[]
			{
				Task.WhenAll(new Task[]
				{
					this.method_10(@class.bool_0),
					this.method_9(@class.bool_0)
				}),
				Task.Delay(3000)
			});
		}
		catch
		{
			result = Task.CompletedTask;
		}
		return result;
	}

	// Token: 0x060001DA RID: 474 RVA: 0x00011914 File Offset: 0x0000FB14
	public Task method_9(bool bool_3)
	{
		Task result;
		try
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary["Store"] = this.jtoken_0["store"].ToString();
			dictionary["Product"] = this.jtoken_0["product"].ToString();
			dictionary["Size"] = this.string_0;
			dictionary["Profile"] = this.jtoken_0["profile"].ToString();
			dictionary["Order"] = this.string_3;
			dictionary["Tracking"] = this.string_4;
			dictionary["User"] = Licenser.class156_0.User;
			dictionary["License"] = Licenser.class156_0.Key;
			dictionary["Discord"] = Licenser.class156_0.Discord;
			dictionary["Success"] = bool_3.ToString();
			dictionary["QuickTask"] = (this.string_5 != null).ToString();
			dictionary["Timestamp"] = DateTime.UtcNow.ToString();
			Dictionary<string, string> dictionary_ = dictionary;
			result = this.class14_0.method_3(string.Format("https://{0}/api/success", "cybersole.io"), dictionary_, false);
		}
		catch
		{
			result = Task.CompletedTask;
		}
		return result;
	}

	// Token: 0x060001DB RID: 475 RVA: 0x00011A84 File Offset: 0x0000FC84
	public Task method_10(bool bool_3)
	{
		try
		{
			if (Class130.string_2.Contains("https://discordapp.com/api/webhooks/") || Class130.string_2.Contains("https://hooks.slack.com/services/"))
			{
				JObject jobject = new JObject(new JProperty("attachments", new JObject()));
				jobject["username"] = "CyberAIO";
				jobject["icon_url"] = "https://cdn.discordapp.com/attachments/422926053745623040/437275593571172362/logo.png";
				JObject jobject2 = new JObject();
				jobject2["title"] = (bool_3 ? "You checked out!" : "Your card was Declined!");
				jobject2["text"] = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture);
				jobject2["color"] = (bool_3 ? "#32CD32" : "#FF0000");
				if (this.string_2 != null)
				{
					jobject2["thumb_url"] = (this.string_2.Contains("http") ? this.string_2.Replace("\\/", "/") : ("http:" + this.string_2.Replace("\\/", "/")));
				}
				jobject2["footer"] = "CyberAIO Success Logger";
				JArray jarray = new JArray();
				JObject jobject3 = new JObject();
				jobject3["title"] = "Product";
				jobject3["value"] = this.jtoken_0["product"].ToString();
				jobject3["short"] = false;
				jarray.Add(jobject3);
				jobject3 = new JObject();
				jobject3["title"] = "Store";
				jobject3["value"] = this.jtoken_0["store"].ToString();
				jobject3["short"] = true;
				jarray.Add(jobject3);
				jobject3 = new JObject();
				jobject3["title"] = "Size";
				jobject3["value"] = this.string_0;
				jobject3["short"] = true;
				jarray.Add(jobject3);
				if (this.jtoken_0["store"].ToString().Contains("Supreme"))
				{
					jobject3 = new JObject();
					jobject3["title"] = "Color";
					jobject3["value"] = this.string_1;
					jobject3["short"] = true;
					jarray.Add(jobject3);
					jobject3 = new JObject();
					jobject3["title"] = "Category";
					jobject3["value"] = this.jtoken_0["supreme"]["category"].ToString();
					jobject3["short"] = false;
					jarray.Add(jobject3);
				}
				jobject3 = new JObject();
				jobject3["title"] = "Profile";
				jobject3["value"] = this.jtoken_0["profile"].ToString();
				jobject3["short"] = true;
				jarray.Add(jobject3);
				if (this.string_3 != null)
				{
					jobject3 = new JObject();
					jobject3["title"] = "Order #";
					jobject3["value"] = ((this.string_4 != null) ? string.Format("<{0}|{1}>", this.string_4, this.string_3) : this.string_3);
					jobject3["short"] = true;
					jarray.Add(jobject3);
				}
				jobject2["fields"] = jarray;
				jobject["attachments"] = new JArray(jobject2);
				return this.class14_0.method_4(Class130.string_2.Contains("discord") ? (Class130.string_2.Replace("/slack", string.Empty) + "/slack") : Class130.string_2, jobject, false);
			}
		}
		catch
		{
		}
		return Task.CompletedTask;
	}

	// Token: 0x060001DC RID: 476 RVA: 0x00011EFC File Offset: 0x000100FC
	public Task method_11()
	{
		string text = (string)this.jtoken_0["afk"];
		if (text != "False")
		{
			DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(Convert.ToDouble(text));
			if (dateTime > DateTime.UtcNow)
			{
				return this.method_12(dateTime, "Waiting", true);
			}
		}
		return Task.CompletedTask;
	}

	// Token: 0x060001DD RID: 477 RVA: 0x00011F6C File Offset: 0x0001016C
	public async Task method_12(DateTime dateTime_0, string string_7, bool bool_3)
	{
		DateTime dateTime = bool_3 ? DateTime.UtcNow : DateTime.Now;
		while (dateTime_0 > dateTime && !this.bool_1)
		{
			this.method_5(string.Format("{0} {1}", string_7, dateTime_0.Subtract(dateTime).ToString("d\\d\\ hh\\:mm\\:ss")), "#c2c2c2", false, false);
			TaskAwaiter taskAwaiter = Task.Delay(1000).GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter);
			}
			taskAwaiter.GetResult();
			dateTime = (bool_3 ? DateTime.UtcNow : DateTime.Now);
		}
	}

	// Token: 0x060001DE RID: 478 RVA: 0x00011FCC File Offset: 0x000101CC
	public Task method_13(TimeSpan timeSpan_0, string string_7)
	{
		DateTime dateTime_ = DateTime.Now.Add(timeSpan_0);
		return this.method_12(dateTime_, "Waiting", false);
	}

	// Token: 0x060001DF RID: 479 RVA: 0x00003C0C File Offset: 0x00001E0C
	public Task method_14(int int_0)
	{
		if (this.bool_1)
		{
			int_0 = 0;
		}
		return Task.Delay(TimeSpan.FromMilliseconds((double)int_0), this.cancellationTokenSource_0.Token);
	}

	// Token: 0x0400011F RID: 287
	public Class14 class14_0;

	// Token: 0x04000120 RID: 288
	public JToken jtoken_0;

	// Token: 0x04000121 RID: 289
	public JToken jtoken_1;

	// Token: 0x04000122 RID: 290
	public string string_0;

	// Token: 0x04000123 RID: 291
	public bool bool_0;

	// Token: 0x04000124 RID: 292
	public static SoundPlayer soundPlayer_0 = new SoundPlayer(Class158.smethod_11());

	// Token: 0x04000125 RID: 293
	public string string_1;

	// Token: 0x04000126 RID: 294
	public string string_2;

	// Token: 0x04000127 RID: 295
	public bool bool_1;

	// Token: 0x04000128 RID: 296
	public string string_3;

	// Token: 0x04000129 RID: 297
	public string string_4;

	// Token: 0x0400012A RID: 298
	public string string_5;

	// Token: 0x0400012B RID: 299
	public bool bool_2;

	// Token: 0x0400012C RID: 300
	public CancellationTokenSource cancellationTokenSource_0 = new CancellationTokenSource();

	// Token: 0x0400012D RID: 301
	public string string_6;

	// Token: 0x0200005E RID: 94
	private sealed class Class55
	{
		// Token: 0x060001E1 RID: 481 RVA: 0x00011FF8 File Offset: 0x000101F8
		internal void method_0()
		{
			Notification.smethod_0(this.bool_0 ? "Successfully Checked Out" : "Card Declined", this.class44_0.jtoken_0["product"].ToString(), this.bool_0 ? ((Notification.GEnum0)0) : ((Notification.GEnum0)1), true);
		}

		// Token: 0x0400012E RID: 302
		public bool bool_0;

		// Token: 0x0400012F RID: 303
		public Class44 class44_0;
	}

	// Token: 0x0200005F RID: 95
	[StructLayout(LayoutKind.Auto)]
	private struct Struct28 : IAsyncStateMachine
	{
		// Token: 0x060001E2 RID: 482 RVA: 0x00012048 File Offset: 0x00010248
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class44 @class = this;
			try
			{
				try
				{
					TaskAwaiter taskAwaiter3;
					if (num != 0)
					{
						if (num != 1)
						{
							@class.bool_1 = true;
							if (bool_3 && !@class.bool_2)
							{
								@class.bool_2 = bool_3;
								@class.method_5(string_7, string_8, true, true);
								GEnum1 genum = genum1_0;
								if (genum != (GEnum1)5)
								{
									if (genum != (GEnum1)6)
									{
										goto IL_17B;
									}
									@class.method_1();
									taskAwaiter3 = @class.method_8(true).GetAwaiter();
									if (!taskAwaiter3.IsCompleted)
									{
										num2 = 1;
										taskAwaiter2 = taskAwaiter3;
										this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class44.Struct28>(ref taskAwaiter3, ref this);
										return;
									}
								}
								else
								{
									taskAwaiter3 = @class.method_8(false).GetAwaiter();
									if (!taskAwaiter3.IsCompleted)
									{
										num2 = 0;
										taskAwaiter2 = taskAwaiter3;
										this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class44.Struct28>(ref taskAwaiter3, ref this);
										return;
									}
									goto IL_174;
								}
							}
							else
							{
								if (!bool_3)
								{
									@class.bool_2 = bool_3;
									@class.method_5("Stopping...", "orange", true, true);
									@class.cancellationTokenSource_0.Cancel();
									@class.class14_0.httpClient_0.CancelPendingRequests();
									goto IL_1E3;
								}
								goto IL_1E3;
							}
						}
						else
						{
							taskAwaiter3 = taskAwaiter2;
							taskAwaiter2 = default(TaskAwaiter);
							num2 = -1;
						}
						taskAwaiter3.GetResult();
						goto IL_17B;
					}
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					num2 = -1;
					IL_174:
					taskAwaiter3.GetResult();
					IL_17B:
					if (@class.class14_0 != null)
					{
						@class.class14_0.httpClient_0.Dispose();
					}
					@class.cancellationTokenSource_0.Dispose();
					Class130.dictionary_0.Remove((int)@class.jtoken_0["id"]);
					MainWindow.webView_0.QueueScriptCall(string.Format("updateButton({0},false)", @class.jtoken_0["id"]));
					IL_1E3:;
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

		// Token: 0x060001E3 RID: 483 RVA: 0x00003C30 File Offset: 0x00001E30
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000130 RID: 304
		public int int_0;

		// Token: 0x04000131 RID: 305
		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		// Token: 0x04000132 RID: 306
		public Class44 class44_0;

		// Token: 0x04000133 RID: 307
		public bool bool_0;

		// Token: 0x04000134 RID: 308
		public string string_0;

		// Token: 0x04000135 RID: 309
		public string string_1;

		// Token: 0x04000136 RID: 310
		public GEnum1 genum1_0;

		// Token: 0x04000137 RID: 311
		private TaskAwaiter taskAwaiter_0;
	}

	// Token: 0x02000060 RID: 96
	[StructLayout(LayoutKind.Auto)]
	private struct Struct29 : IAsyncStateMachine
	{
		// Token: 0x060001E4 RID: 484 RVA: 0x000122A0 File Offset: 0x000104A0
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class44 @class = this;
			try
			{
				TaskAwaiter taskAwaiter3;
				if (num == 0)
				{
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					num2 = -1;
					goto IL_C1;
				}
				DateTime dateTime = bool_3 ? DateTime.UtcNow : DateTime.Now;
				IL_4C:
				if (!(dateTime_0 > dateTime) || @class.bool_1)
				{
					goto IL_110;
				}
				@class.method_5(string.Format("{0} {1}", string_7, dateTime_0.Subtract(dateTime).ToString("d\\d\\ hh\\:mm\\:ss")), "#c2c2c2", false, false);
				taskAwaiter3 = Task.Delay(1000).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					num2 = 0;
					taskAwaiter2 = taskAwaiter3;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class44.Struct29>(ref taskAwaiter3, ref this);
					return;
				}
				IL_C1:
				taskAwaiter3.GetResult();
				dateTime = (bool_3 ? DateTime.UtcNow : DateTime.Now);
				goto IL_4C;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_110:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x00003C3E File Offset: 0x00001E3E
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000138 RID: 312
		public int int_0;

		// Token: 0x04000139 RID: 313
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x0400013A RID: 314
		public bool bool_0;

		// Token: 0x0400013B RID: 315
		public Class44 class44_0;

		// Token: 0x0400013C RID: 316
		public string string_0;

		// Token: 0x0400013D RID: 317
		public DateTime dateTime_0;

		// Token: 0x0400013E RID: 318
		private TaskAwaiter taskAwaiter_0;
	}
}
