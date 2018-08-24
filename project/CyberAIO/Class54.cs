using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;

// Token: 0x02000183 RID: 387
internal sealed class Class54 : Class44
{
	// Token: 0x06000834 RID: 2100 RVA: 0x00049E1C File Offset: 0x0004801C
	public Class54(JToken jtoken_2, string string_18)
	{
		try
		{
			this.jtoken_0 = jtoken_2;
			this.string_11 = ((string)jtoken_2["keywords"]).Replace(" ", string.Empty).ToLower().Split(new char[]
			{
				','
			}).Where(new Func<string, bool>(Class54.Class177.class177_0.method_0)).ToArray<string>();
			this.string_10 = ((string)jtoken_2["keywords"]).Replace(" ", string.Empty).ToLower().Split(new char[]
			{
				','
			}).Where(new Func<string, bool>(Class54.Class177.class177_0.method_1)).ToArray<string>().Select(new Func<string, string>(Class54.Class177.class177_0.method_2)).ToArray<string>();
			this.string_16 = ((string)jtoken_2["supreme"]["color"]).Replace(" ", string.Empty).Split(new char[]
			{
				','
			});
			this.bool_3 = ((bool)jtoken_2["supreme"]["random"] || jtoken_2["supreme"]["color"].ToString() == "False");
			this.string_8 = (string)jtoken_2["supreme"]["category"];
			if (!base.method_2(out this.jtoken_1))
			{
				base.method_0("Profile error", "red", true, (GEnum1)0);
			}
			else
			{
				if (!((string)jtoken_2["size"] == "OneSize") && !((string)jtoken_2["size"] == "Random"))
				{
					this.string_0 = (string)jtoken_2["size"];
				}
				else
				{
					this.bool_4 = true;
				}
				this.string_12 = string_18;
				this.class14_0 = new Class14(base.method_3(), "Mozilla/5.0 (iPhone; CPU iPhone OS 9_1 like Mac OS X) AppleWebKit/601.1.46 (KHTML, like Gecko) Version/9.0 Mobile/13B143 Safari/601.1", 10, false, false, null);
			}
		}
		catch
		{
			base.method_0("Task error", "red", true, (GEnum1)0);
		}
	}

	// Token: 0x06000835 RID: 2101 RVA: 0x0004A0CC File Offset: 0x000482CC
	public override async void vmethod_0()
	{
		try
		{
			this.method_19();
			await base.method_11();
			await this.method_16();
			await this.method_17();
			await this.method_18();
			await this.method_19();
			this.method_20();
			await this.method_22();
		}
		catch
		{
		}
		base.method_0("Stopped", "red", true, (GEnum1)0);
	}

	// Token: 0x06000836 RID: 2102 RVA: 0x0004A108 File Offset: 0x00048308
	public async Task method_15()
	{
		this.class14_0 = new Class14(base.method_3(), "Mozilla/5.0 (iPhone; CPU iPhone OS 9_1 like Mac OS X) AppleWebKit/601.1.46 (KHTML, like Gecko) Version/9.0 Mobile/13B143 Safari/601.1", 10, false, false, null);
		await Task.Delay(Class130.int_0);
		await this.method_17();
		await this.method_18();
		await this.method_22();
	}

	// Token: 0x06000837 RID: 2103 RVA: 0x0004A150 File Offset: 0x00048350
	public async Task method_16()
	{
		base.method_5("Waiting for product", "#c2c2c2", true, false);
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				foreach (JToken jtoken in ((IEnumerable<JToken>)((await(await this.class14_0.method_2("https://www.supremenewyork.com/shop.json", false)).smethod_1())["products_and_categories"][this.string_8] ?? new JObject())))
				{
					string @object = jtoken["name"].ToString().ToLower().smethod_6();
					if (this.string_11.All(new Func<string, bool>(@object.Contains)) && !this.string_10.Any(new Func<string, bool>(@object.Contains)))
					{
						this.string_9 = "https://www.supremenewyork.com/shop/" + jtoken["id"];
						base.method_7(jtoken["name"].ToString(), "#c2c2c2");
						base.method_5("Found product: " + jtoken["name"], "#c2c2c2", true, false);
						return;
					}
				}
				await base.method_14(Class130.int_0);
				goto IL_2C0;
			}
			catch
			{
				num = 1;
				goto IL_2C0;
			}
			IL_28B:
			TaskAwaiter taskAwaiter = base.method_14(Class130.int_0).GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter);
			}
			taskAwaiter.GetResult();
			continue;
			IL_2C0:
			if (num == 1)
			{
				goto IL_28B;
			}
		}
	}

	// Token: 0x06000838 RID: 2104 RVA: 0x0004A198 File Offset: 0x00048398
	public async Task method_17()
	{
		base.method_5("Collecting product data", "#c2c2c2", true, false);
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				JToken source = (await(await this.class14_0.method_2(this.string_9 + ".json", false)).smethod_1())["styles"];
				JToken jtoken;
				if (this.bool_3)
				{
					jtoken = source.Where(new Func<JToken, bool>(Class54.Class177.class177_0.method_3)).smethod_5();
					if (jtoken == null)
					{
						goto IL_308;
					}
					this.string_1 = jtoken["name"].ToString();
					this.string_2 = jtoken["image_url_hi"].ToString();
				}
				else
				{
					jtoken = source.FirstOrDefault(new Func<JToken, bool>(this.method_23));
					if (jtoken == null)
					{
						base.method_0("Color unavailable", "red", true, (GEnum1)0);
					}
					this.string_1 = jtoken["name"].ToString();
					this.string_2 = jtoken["image_url_hi"].ToString();
				}
				if (this.bool_4)
				{
					JToken jtoken2 = jtoken["sizes"].Where(new Func<JToken, bool>(Class54.Class177.class177_0.method_5)).smethod_5();
					if (jtoken2 != null)
					{
						this.string_14 = jtoken2["id"].ToString();
						this.string_15 = jtoken["id"].ToString();
						base.method_6(jtoken2["name"].ToString());
						break;
					}
				}
				else
				{
					JToken jtoken3 = jtoken["sizes"].FirstOrDefault(new Func<JToken, bool>(this.method_24));
					if (jtoken3 == null)
					{
						base.method_0("Size unavailable", "red", true, (GEnum1)0);
					}
					else if ((int)jtoken3["stock_level"] > 0)
					{
						this.string_14 = jtoken3["id"].ToString();
						this.string_15 = jtoken["id"].ToString();
						break;
					}
				}
				IL_308:
				base.method_5("Waiting for restock", "#c2c2c2", true, false);
				await base.method_14(Class130.int_1);
				goto IL_3DF;
			}
			catch
			{
				num = 1;
				goto IL_3DF;
			}
			IL_386:
			base.method_5("Error collecting data", "#c2c2c2", true, false);
			TaskAwaiter taskAwaiter = base.method_14(Class130.int_1).GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter);
			}
			taskAwaiter.GetResult();
			base.method_5("Collecting product data", "#c2c2c2", true, false);
			continue;
			IL_3DF:
			if (num == 1)
			{
				goto IL_386;
			}
		}
	}

	// Token: 0x06000839 RID: 2105 RVA: 0x0004A1E0 File Offset: 0x000483E0
	public async Task method_18()
	{
		base.method_5("Adding to cart", "#c2c2c2", true, false);
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary["style"] = this.string_15;
				dictionary["size"] = this.string_14;
				dictionary["st"] = this.string_15;
				dictionary["s"] = this.string_14;
				JArray jarray = await(await this.class14_0.method_3(this.string_9 + "/add.json", dictionary, false)).smethod_2();
				if (jarray.Count == 0 || !(bool)jarray[0]["in_stock"])
				{
					base.method_5("Waiting for restock", "#c2c2c2", true, false);
					await base.method_14(Class130.int_0);
					await this.method_17();
					continue;
				}
				if ((bool)jarray[0]["in_stock"])
				{
					base.method_5("Successfully carted", "#c2c2c2", true, false);
					this.stopwatch_0.Restart();
					break;
				}
				throw new Exception();
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error adding to cart", "#c2c2c2", true, false);
				TaskAwaiter taskAwaiter = base.method_14(Class130.int_1).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter.GetResult();
				base.method_5("Adding to cart", "#c2c2c2", true, false);
			}
		}
	}

	// Token: 0x0600083A RID: 2106 RVA: 0x0004A228 File Offset: 0x00048428
	public async Task method_19()
	{
		try
		{
			base.method_5("Checking for store credit", "#c2c2c2", true, false);
			TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class14_0.method_2(string.Format("https://www.supremenewyork.com/store_credits/verify?email={0}", this.jtoken_1["payment"]["email"]), false).GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<HttpResponseMessage> taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
			}
			HttpResponseMessage result = taskAwaiter.GetResult();
			if (result.StatusCode == HttpStatusCode.NotFound)
			{
				base.method_5("No store credit found", "#c2c2c2", true, false);
			}
			else
			{
				HtmlDocument htmlDocument = new HtmlDocument();
				HtmlDocument htmlDocument2 = htmlDocument;
				TaskAwaiter<string> taskAwaiter3 = result.smethod_3().GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<string> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<string>);
				}
				htmlDocument2.LoadHtml(taskAwaiter3.GetResult());
				htmlDocument2 = null;
				this.string_17 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='store_credit']").Attributes["value"].Value;
				base.method_5("Using store credits", "#c2c2c2", true, false);
				htmlDocument = null;
			}
		}
		catch
		{
		}
	}

	// Token: 0x0600083B RID: 2107 RVA: 0x0004A270 File Offset: 0x00048470
	public void method_20()
	{
		if (this.string_17 != null)
		{
			this.dictionary_0["store_credit_id"] = this.string_17;
		}
		this.dictionary_0["order[billing_name]"] = (string)this.jtoken_1["billing"]["first_name"] + " " + (string)this.jtoken_1["billing"]["last_name"];
		this.dictionary_0["order[email]"] = (string)this.jtoken_1["payment"]["email"];
		this.dictionary_0["order[tel]"] = (string)this.jtoken_1["payment"]["phone"];
		this.dictionary_0["order[billing_address]"] = (string)this.jtoken_1["billing"]["addr1"];
		this.dictionary_0["order[billing_address_2]"] = (string)this.jtoken_1["billing"]["addr2"];
		this.dictionary_0["order[billing_city]"] = (string)this.jtoken_1["billing"]["city"];
		this.dictionary_0["order[billing_zip]"] = (string)this.jtoken_1["billing"]["zip"];
		this.dictionary_0["order[billing_country]"] = Class43.smethod_0((string)this.jtoken_1["billing"]["country"], true);
		this.dictionary_0["order[billing_state]"] = Class43.smethod_1((string)this.jtoken_1["billing"]["country"], (string)this.jtoken_1["billing"]["state"]);
		this.dictionary_0["order[terms]"] = "1";
		this.dictionary_0[(this.string_12 == "EU") ? "credit_card[cnb]" : "credit_card[nlb]"] = ((string)this.jtoken_1["payment"]["card"]["number"]).Replace(" ", string.Empty);
		this.dictionary_0["credit_card[month]"] = (string)this.jtoken_1["payment"]["card"]["exp_month"];
		this.dictionary_0["credit_card[year]"] = (string)this.jtoken_1["payment"]["card"]["exp_year"];
		this.dictionary_0[(this.string_12 == "EU") ? "credit_card[vval]" : "credit_card[rvv]"] = (string)this.jtoken_1["payment"]["card"]["cvv"];
	}

	// Token: 0x0600083C RID: 2108 RVA: 0x0004A5D0 File Offset: 0x000487D0
	public async Task<bool> method_21()
	{
		bool result;
		if (this.stopwatch_0.ElapsedMilliseconds <= 115000L && this.dictionary_0.ContainsKey("g-recaptcha-response"))
		{
			result = false;
		}
		else
		{
			this.stopwatch_0.Reset();
			base.method_5("Waiting for captcha token", "turquoise", true, false);
			this.string_7 = await CaptchaQueue.smethod_0(this.string_13, "https://www.supremenewyork.com/checkout", (string)this.jtoken_0["id"], this.cancellationTokenSource_0.Token);
			this.stopwatch_0.Start();
			this.dictionary_0["g-recaptcha-response"] = this.string_7;
			result = true;
		}
		return result;
	}

	// Token: 0x0600083D RID: 2109 RVA: 0x0004A618 File Offset: 0x00048818
	public async Task method_22()
	{
		CookieCollection cookies = this.class14_0.cookieContainer_0.GetCookies(new Uri("https://www.supremenewyork.com"));
		while (!this.bool_1)
		{
			bool flag = false;
			int num = 0;
			TaskAwaiter taskAwaiter3;
			TaskAwaiter taskAwaiter4;
			try
			{
				base.method_5("Checking out...", "orange", true, false);
				HttpResponseMessage httpResponseMessage = await this.class14_0.method_3("https://www.supremenewyork.com/checkout.json", this.dictionary_0, false);
				httpResponseMessage.EnsureSuccessStatusCode();
				JObject jobject = await httpResponseMessage.smethod_1();
				if (jobject["status"].ToString() == "queued")
				{
					flag = true;
					base.method_5("Processing payment...", "orange", true, false);
					string arg = jobject["slug"].ToString();
					httpResponseMessage = await this.class14_0.method_2(string.Format("https://www.supremenewyork.com/checkout/{0}/status.json", arg), false);
					TaskAwaiter<JObject> taskAwaiter;
					TaskAwaiter<JObject> taskAwaiter2;
					for (;;)
					{
						taskAwaiter = httpResponseMessage.smethod_1().GetAwaiter();
						if (!taskAwaiter.IsCompleted)
						{
							await taskAwaiter;
							taskAwaiter = taskAwaiter2;
							taskAwaiter2 = default(TaskAwaiter<JObject>);
						}
						if (!(taskAwaiter.GetResult()["status"].ToString() == "queued"))
						{
							break;
						}
						taskAwaiter3 = base.method_14(300).GetAwaiter();
						if (!taskAwaiter3.IsCompleted)
						{
							await taskAwaiter3;
							taskAwaiter3 = taskAwaiter4;
							taskAwaiter4 = default(TaskAwaiter);
						}
						taskAwaiter3.GetResult();
						TaskAwaiter<HttpResponseMessage> taskAwaiter5 = this.class14_0.method_2(string.Format("https://www.supremenewyork.com/checkout/{0}/status.json", arg), false).GetAwaiter();
						if (!taskAwaiter5.IsCompleted)
						{
							await taskAwaiter5;
							TaskAwaiter<HttpResponseMessage> taskAwaiter6;
							taskAwaiter5 = taskAwaiter6;
							taskAwaiter6 = default(TaskAwaiter<HttpResponseMessage>);
						}
						httpResponseMessage = taskAwaiter5.GetResult();
					}
					taskAwaiter = httpResponseMessage.smethod_1().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						await taskAwaiter;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<JObject>);
					}
					jobject = taskAwaiter.GetResult();
					arg = null;
				}
				if (jobject["status"].ToString() == "paid")
				{
					this.string_3 = jobject["id"].ToString();
					base.method_0("Successfully checked out", "green", true, (GEnum1)6);
					break;
				}
				if (jobject["status"].ToString() == "dup")
				{
					base.method_0("Billing used", "red", true, (GEnum1)0);
				}
				else
				{
					if (jobject["status"].ToString() == "outOfStock")
					{
						taskAwaiter3 = this.method_15().GetAwaiter();
						if (!taskAwaiter3.IsCompleted)
						{
							await taskAwaiter3;
							taskAwaiter3 = taskAwaiter4;
							taskAwaiter4 = default(TaskAwaiter);
						}
						taskAwaiter3.GetResult();
						break;
					}
					if (jobject["status"].ToString() == "failed" && jobject.ContainsKey("avs"))
					{
						base.method_0("Invalid billing", "red", true, (GEnum1)0);
					}
					else if (jobject["status"].ToString() == "failed" && jobject.ContainsKey("cvv"))
					{
						base.method_0("Invalid CVV", "red", true, (GEnum1)0);
					}
					else if (!(jobject["status"].ToString() == "blocked_country") && !(jobject["status"].ToString() == "canada") && !jobject.ToString().Contains("country is required"))
					{
						if (flag)
						{
							base.method_0("Card declined", "red", true, (GEnum1)5);
						}
						else
						{
							base.method_5("Card Declined (Violation), retrying", "red", true, false);
							TaskAwaiter<bool> taskAwaiter7 = this.method_21().GetAwaiter();
							if (!taskAwaiter7.IsCompleted)
							{
								await taskAwaiter7;
								TaskAwaiter<bool> taskAwaiter8;
								taskAwaiter7 = taskAwaiter8;
								taskAwaiter8 = default(TaskAwaiter<bool>);
							}
							if (!taskAwaiter7.GetResult())
							{
								await base.method_14(Class130.int_1);
							}
							if (httpResponseMessage.StatusCode != HttpStatusCode.Found)
							{
								this.class14_0.cookieContainer_0.Add(cookies);
							}
							else
							{
								await this.method_15();
							}
						}
					}
					else
					{
						base.method_0("Unsupported country", "red", true, (GEnum1)0);
					}
				}
				httpResponseMessage = null;
				goto IL_7FC;
			}
			catch
			{
				num = 1;
				goto IL_7FC;
			}
			IL_7AE:
			base.method_5("Error checking out", "#c2c2c2", true, false);
			taskAwaiter3 = base.method_14(Class130.int_1).GetAwaiter();
			if (!taskAwaiter3.IsCompleted)
			{
				await taskAwaiter3;
				taskAwaiter3 = taskAwaiter4;
				taskAwaiter4 = default(TaskAwaiter);
			}
			taskAwaiter3.GetResult();
			continue;
			IL_7FC:
			if (num == 1)
			{
				goto IL_7AE;
			}
		}
	}

	// Token: 0x0600083E RID: 2110 RVA: 0x0004A660 File Offset: 0x00048860
	private bool method_23(JToken jtoken_2)
	{
		Class54.Class178 @class = new Class54.Class178();
		@class.jtoken_0 = jtoken_2;
		return this.string_16.Any(new Func<string, bool>(@class.method_0)) || this.string_16.Any(new Func<string, bool>(@class.jtoken_0["image_url"].ToString().Contains));
	}

	// Token: 0x0600083F RID: 2111 RVA: 0x000069A3 File Offset: 0x00004BA3
	private bool method_24(JToken jtoken_2)
	{
		return Class43.smethod_2(this.string_0, jtoken_2["name"].ToString().smethod_6().ToLower());
	}

	// Token: 0x04000722 RID: 1826
	private readonly Stopwatch stopwatch_0 = new Stopwatch();

	// Token: 0x04000723 RID: 1827
	private string string_7;

	// Token: 0x04000724 RID: 1828
	private readonly string string_8;

	// Token: 0x04000725 RID: 1829
	private Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();

	// Token: 0x04000726 RID: 1830
	private string string_9;

	// Token: 0x04000727 RID: 1831
	private readonly string[] string_10;

	// Token: 0x04000728 RID: 1832
	private readonly string[] string_11;

	// Token: 0x04000729 RID: 1833
	private readonly bool bool_3;

	// Token: 0x0400072A RID: 1834
	private readonly bool bool_4;

	// Token: 0x0400072B RID: 1835
	private readonly string string_12 = "EU";

	// Token: 0x0400072C RID: 1836
	private readonly string string_13 = "6LeWwRkUAAAAAOBsau7KpuC9AV-6J8mhw4AjC3Xz";

	// Token: 0x0400072D RID: 1837
	private string string_14;

	// Token: 0x0400072E RID: 1838
	private string string_15;

	// Token: 0x0400072F RID: 1839
	private string[] string_16;

	// Token: 0x04000730 RID: 1840
	private string string_17;

	// Token: 0x02000184 RID: 388
	[Serializable]
	private sealed class Class177
	{
		// Token: 0x06000842 RID: 2114 RVA: 0x00006324 File Offset: 0x00004524
		internal bool method_0(string string_0)
		{
			return string_0[0] != '-';
		}

		// Token: 0x06000843 RID: 2115 RVA: 0x00006334 File Offset: 0x00004534
		internal bool method_1(string string_0)
		{
			return string_0[0] == '-';
		}

		// Token: 0x06000844 RID: 2116 RVA: 0x00006341 File Offset: 0x00004541
		internal string method_2(string string_0)
		{
			return string_0.Replace("-", string.Empty);
		}

		// Token: 0x06000845 RID: 2117 RVA: 0x000069D6 File Offset: 0x00004BD6
		internal bool method_3(JToken jtoken_0)
		{
			return jtoken_0["sizes"].Where(new Func<JToken, bool>(Class54.Class177.class177_0.method_4)).ToArray<JToken>().Length != 0;
		}

		// Token: 0x06000846 RID: 2118 RVA: 0x00006A10 File Offset: 0x00004C10
		internal bool method_4(JToken jtoken_0)
		{
			return (int)jtoken_0["stock_level"] > 0;
		}

		// Token: 0x06000847 RID: 2119 RVA: 0x00006A10 File Offset: 0x00004C10
		internal bool method_5(JToken jtoken_0)
		{
			return (int)jtoken_0["stock_level"] > 0;
		}

		// Token: 0x04000731 RID: 1841
		public static readonly Class54.Class177 class177_0 = new Class54.Class177();

		// Token: 0x04000732 RID: 1842
		public static Func<string, bool> func_0;

		// Token: 0x04000733 RID: 1843
		public static Func<string, bool> func_1;

		// Token: 0x04000734 RID: 1844
		public static Func<string, string> func_2;

		// Token: 0x04000735 RID: 1845
		public static Func<JToken, bool> func_3;

		// Token: 0x04000736 RID: 1846
		public static Func<JToken, bool> func_4;

		// Token: 0x04000737 RID: 1847
		public static Func<JToken, bool> func_5;
	}

	// Token: 0x02000185 RID: 389
	[StructLayout(LayoutKind.Auto)]
	private struct Struct159 : IAsyncStateMachine
	{
		// Token: 0x06000848 RID: 2120 RVA: 0x0004A6C0 File Offset: 0x000488C0
		void IAsyncStateMachine.MoveNext()
		{
			int num3;
			int num2 = num3;
			Class54 @class = this;
			try
			{
				TaskAwaiter taskAwaiter9;
				if (num2 > 10)
				{
					if (num2 != 11)
					{
						cookies = @class.class14_0.cookieContainer_0.GetCookies(new Uri("https://www.supremenewyork.com"));
						goto IL_7E1;
					}
					taskAwaiter9 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter);
					int num4 = -1;
					num2 = -1;
					num3 = num4;
					goto IL_7DA;
				}
				IL_5E:
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter10;
					TaskAwaiter<JObject> taskAwaiter11;
					TaskAwaiter<bool> taskAwaiter12;
					switch (num2)
					{
					case 0:
					{
						taskAwaiter10 = taskAwaiter6;
						taskAwaiter6 = default(TaskAwaiter<HttpResponseMessage>);
						int num5 = -1;
						num2 = -1;
						num3 = num5;
						break;
					}
					case 1:
					{
						taskAwaiter11 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<JObject>);
						int num6 = -1;
						num2 = -1;
						num3 = num6;
						goto IL_184;
					}
					case 2:
					{
						taskAwaiter10 = taskAwaiter6;
						taskAwaiter6 = default(TaskAwaiter<HttpResponseMessage>);
						int num7 = -1;
						num2 = -1;
						num3 = num7;
						goto IL_247;
					}
					case 3:
					{
						taskAwaiter9 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter);
						int num8 = -1;
						num2 = -1;
						num3 = num8;
						goto IL_2D9;
					}
					case 4:
					{
						taskAwaiter10 = taskAwaiter6;
						taskAwaiter6 = default(TaskAwaiter<HttpResponseMessage>);
						int num9 = -1;
						num2 = -1;
						num3 = num9;
						goto IL_30F;
					}
					case 5:
					{
						taskAwaiter11 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<JObject>);
						int num10 = -1;
						num2 = -1;
						num3 = num10;
						goto IL_33E;
					}
					case 6:
					{
						taskAwaiter11 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<JObject>);
						int num11 = -1;
						num2 = -1;
						num3 = num11;
						goto IL_42D;
					}
					case 7:
					{
						taskAwaiter9 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter);
						int num12 = -1;
						num2 = -1;
						num3 = num12;
						goto IL_680;
					}
					case 8:
					{
						taskAwaiter12 = taskAwaiter8;
						taskAwaiter8 = default(TaskAwaiter<bool>);
						int num13 = -1;
						num2 = -1;
						num3 = num13;
						goto IL_6A9;
					}
					case 9:
					{
						taskAwaiter9 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter);
						int num14 = -1;
						num2 = -1;
						num3 = num14;
						goto IL_70D;
					}
					case 10:
					{
						taskAwaiter9 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter);
						int num15 = -1;
						num2 = -1;
						num3 = num15;
						goto IL_794;
					}
					default:
						@class.method_5("Checking out...", "orange", true, false);
						taskAwaiter10 = @class.class14_0.method_3("https://www.supremenewyork.com/checkout.json", @class.dictionary_0, false).GetAwaiter();
						if (!taskAwaiter10.IsCompleted)
						{
							int num16 = 0;
							num2 = 0;
							num3 = num16;
							taskAwaiter6 = taskAwaiter10;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class54.Struct159>(ref taskAwaiter10, ref this);
							return;
						}
						break;
					}
					HttpResponseMessage result = taskAwaiter10.GetResult();
					httpResponseMessage = result;
					httpResponseMessage.EnsureSuccessStatusCode();
					taskAwaiter11 = httpResponseMessage.smethod_1().GetAwaiter();
					if (!taskAwaiter11.IsCompleted)
					{
						int num17 = 1;
						num2 = 1;
						num3 = num17;
						taskAwaiter2 = taskAwaiter11;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class54.Struct159>(ref taskAwaiter11, ref this);
						return;
					}
					IL_184:
					JObject result2 = taskAwaiter11.GetResult();
					if (!(result2["status"].ToString() == "queued"))
					{
						goto IL_43C;
					}
					flag = true;
					@class.method_5("Processing payment...", "orange", true, false);
					arg = result2["slug"].ToString();
					taskAwaiter10 = @class.class14_0.method_2(string.Format("https://www.supremenewyork.com/checkout/{0}/status.json", arg), false).GetAwaiter();
					if (!taskAwaiter10.IsCompleted)
					{
						int num18 = 2;
						num2 = 2;
						num3 = num18;
						taskAwaiter6 = taskAwaiter10;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class54.Struct159>(ref taskAwaiter10, ref this);
						return;
					}
					IL_247:
					result = taskAwaiter10.GetResult();
					httpResponseMessage = result;
					goto IL_320;
					IL_2D9:
					taskAwaiter9.GetResult();
					taskAwaiter10 = @class.class14_0.method_2(string.Format("https://www.supremenewyork.com/checkout/{0}/status.json", arg), false).GetAwaiter();
					if (!taskAwaiter10.IsCompleted)
					{
						int num19 = 4;
						num2 = 4;
						num3 = num19;
						taskAwaiter6 = taskAwaiter10;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class54.Struct159>(ref taskAwaiter10, ref this);
						return;
					}
					IL_30F:
					result = taskAwaiter10.GetResult();
					httpResponseMessage = result;
					IL_320:
					taskAwaiter11 = httpResponseMessage.smethod_1().GetAwaiter();
					if (!taskAwaiter11.IsCompleted)
					{
						int num20 = 5;
						num2 = 5;
						num3 = num20;
						taskAwaiter2 = taskAwaiter11;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class54.Struct159>(ref taskAwaiter11, ref this);
						return;
					}
					IL_33E:
					if (!(taskAwaiter11.GetResult()["status"].ToString() == "queued"))
					{
						taskAwaiter11 = httpResponseMessage.smethod_1().GetAwaiter();
						if (!taskAwaiter11.IsCompleted)
						{
							int num21 = 6;
							num2 = 6;
							num3 = num21;
							taskAwaiter2 = taskAwaiter11;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class54.Struct159>(ref taskAwaiter11, ref this);
							return;
						}
					}
					else
					{
						taskAwaiter9 = @class.method_14(300).GetAwaiter();
						if (taskAwaiter9.IsCompleted)
						{
							goto IL_2D9;
						}
						int num22 = 3;
						num2 = 3;
						num3 = num22;
						taskAwaiter4 = taskAwaiter9;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class54.Struct159>(ref taskAwaiter9, ref this);
						return;
					}
					IL_42D:
					result2 = taskAwaiter11.GetResult();
					arg = null;
					IL_43C:
					if (result2["status"].ToString() == "paid")
					{
						@class.string_3 = result2["id"].ToString();
						@class.method_0("Successfully checked out", "green", true, (GEnum1)6);
						goto IL_848;
					}
					if (result2["status"].ToString() == "dup")
					{
						@class.method_0("Billing used", "red", true, (GEnum1)0);
						goto IL_79B;
					}
					if (result2["status"].ToString() == "outOfStock")
					{
						taskAwaiter9 = @class.method_15().GetAwaiter();
						if (!taskAwaiter9.IsCompleted)
						{
							int num23 = 7;
							num2 = 7;
							num3 = num23;
							taskAwaiter4 = taskAwaiter9;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class54.Struct159>(ref taskAwaiter9, ref this);
							return;
						}
					}
					else
					{
						if (result2["status"].ToString() == "failed" && result2.ContainsKey("avs"))
						{
							@class.method_0("Invalid billing", "red", true, (GEnum1)0);
							goto IL_79B;
						}
						if (result2["status"].ToString() == "failed" && result2.ContainsKey("cvv"))
						{
							@class.method_0("Invalid CVV", "red", true, (GEnum1)0);
							goto IL_79B;
						}
						if (result2["status"].ToString() == "blocked_country" || result2["status"].ToString() == "canada" || result2.ToString().Contains("country is required"))
						{
							@class.method_0("Unsupported country", "red", true, (GEnum1)0);
							goto IL_79B;
						}
						if (flag)
						{
							@class.method_0("Card declined", "red", true, (GEnum1)5);
							goto IL_79B;
						}
						@class.method_5("Card Declined (Violation), retrying", "red", true, false);
						taskAwaiter12 = @class.method_21().GetAwaiter();
						if (!taskAwaiter12.IsCompleted)
						{
							int num24 = 8;
							num2 = 8;
							num3 = num24;
							taskAwaiter8 = taskAwaiter12;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, Class54.Struct159>(ref taskAwaiter12, ref this);
							return;
						}
						goto IL_6A9;
					}
					IL_680:
					taskAwaiter9.GetResult();
					goto IL_848;
					IL_6A9:
					if (taskAwaiter12.GetResult())
					{
						goto IL_714;
					}
					taskAwaiter9 = @class.method_14(Class130.int_1).GetAwaiter();
					if (!taskAwaiter9.IsCompleted)
					{
						int num25 = 9;
						num2 = 9;
						num3 = num25;
						taskAwaiter4 = taskAwaiter9;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class54.Struct159>(ref taskAwaiter9, ref this);
						return;
					}
					IL_70D:
					taskAwaiter9.GetResult();
					IL_714:
					if (httpResponseMessage.StatusCode != HttpStatusCode.Found)
					{
						@class.class14_0.cookieContainer_0.Add(cookies);
						goto IL_79B;
					}
					taskAwaiter9 = @class.method_15().GetAwaiter();
					if (!taskAwaiter9.IsCompleted)
					{
						int num26 = 10;
						num2 = 10;
						num3 = num26;
						taskAwaiter4 = taskAwaiter9;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class54.Struct159>(ref taskAwaiter9, ref this);
						return;
					}
					IL_794:
					taskAwaiter9.GetResult();
					IL_79B:
					httpResponseMessage = null;
					goto IL_7FC;
				}
				catch
				{
					num = 1;
					goto IL_7FC;
				}
				IL_7AE:
				@class.method_5("Error checking out", "#c2c2c2", true, false);
				taskAwaiter9 = @class.method_14(Class130.int_1).GetAwaiter();
				if (taskAwaiter9.IsCompleted)
				{
					goto IL_7DA;
				}
				int num27 = 11;
				num2 = 11;
				num3 = num27;
				taskAwaiter4 = taskAwaiter9;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class54.Struct159>(ref taskAwaiter9, ref this);
				return;
				IL_7FC:
				int num28 = num;
				if (num28 == 1)
				{
					goto IL_7AE;
				}
				goto IL_7E1;
				IL_7DA:
				taskAwaiter9.GetResult();
				IL_7E1:
				if (!@class.bool_1)
				{
					flag = false;
					num = 0;
					goto IL_5E;
				}
			}
			catch (Exception exception)
			{
				num3 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_848:
			num3 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000849 RID: 2121 RVA: 0x00006A25 File Offset: 0x00004C25
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000738 RID: 1848
		public int int_0;

		// Token: 0x04000739 RID: 1849
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x0400073A RID: 1850
		public Class54 class54_0;

		// Token: 0x0400073B RID: 1851
		private CookieCollection cookieCollection_0;

		// Token: 0x0400073C RID: 1852
		private bool bool_0;

		// Token: 0x0400073D RID: 1853
		private int int_1;

		// Token: 0x0400073E RID: 1854
		private HttpResponseMessage httpResponseMessage_0;

		// Token: 0x0400073F RID: 1855
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000740 RID: 1856
		private TaskAwaiter<JObject> taskAwaiter_1;

		// Token: 0x04000741 RID: 1857
		private string string_0;

		// Token: 0x04000742 RID: 1858
		private TaskAwaiter taskAwaiter_2;

		// Token: 0x04000743 RID: 1859
		private TaskAwaiter<bool> taskAwaiter_3;
	}

	// Token: 0x02000186 RID: 390
	private sealed class Class178
	{
		// Token: 0x0600084B RID: 2123 RVA: 0x0004AF5C File Offset: 0x0004915C
		internal bool method_0(string string_0)
		{
			return string_0.ToLower().Split(new char[]
			{
				'+'
			}).All(new Func<string, bool>(this.jtoken_0["name"].ToString().ToLower().smethod_6().Contains));
		}

		// Token: 0x04000744 RID: 1860
		public JToken jtoken_0;
	}

	// Token: 0x02000187 RID: 391
	[StructLayout(LayoutKind.Auto)]
	private struct Struct160 : IAsyncStateMachine
	{
		// Token: 0x0600084C RID: 2124 RVA: 0x0004AFB0 File Offset: 0x000491B0
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class54 @class = this;
			try
			{
				TaskAwaiter taskAwaiter;
				switch (num)
				{
				case 0:
				{
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					num2 = -1;
					break;
				}
				case 1:
				{
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					num2 = -1;
					goto IL_F2;
				}
				case 2:
				{
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					num2 = -1;
					goto IL_14D;
				}
				case 3:
				{
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					num2 = -1;
					goto IL_1A5;
				}
				default:
					@class.class14_0 = new Class14(@class.method_3(), "Mozilla/5.0 (iPhone; CPU iPhone OS 9_1 like Mac OS X) AppleWebKit/601.1.46 (KHTML, like Gecko) Version/9.0 Mobile/13B143 Safari/601.1", 10, false, false, null);
					taskAwaiter = Task.Delay(Class130.int_0).GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 0;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class54.Struct160>(ref taskAwaiter, ref this);
						return;
					}
					break;
				}
				taskAwaiter.GetResult();
				taskAwaiter = @class.method_17().GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					num2 = 1;
					TaskAwaiter taskAwaiter2 = taskAwaiter;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class54.Struct160>(ref taskAwaiter, ref this);
					return;
				}
				IL_F2:
				taskAwaiter.GetResult();
				taskAwaiter = @class.method_18().GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					num2 = 2;
					TaskAwaiter taskAwaiter2 = taskAwaiter;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class54.Struct160>(ref taskAwaiter, ref this);
					return;
				}
				IL_14D:
				taskAwaiter.GetResult();
				taskAwaiter = @class.method_22().GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					num2 = 3;
					TaskAwaiter taskAwaiter2 = taskAwaiter;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class54.Struct160>(ref taskAwaiter, ref this);
					return;
				}
				IL_1A5:
				taskAwaiter.GetResult();
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

		// Token: 0x0600084D RID: 2125 RVA: 0x00006A33 File Offset: 0x00004C33
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000745 RID: 1861
		public int int_0;

		// Token: 0x04000746 RID: 1862
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000747 RID: 1863
		public Class54 class54_0;

		// Token: 0x04000748 RID: 1864
		private TaskAwaiter taskAwaiter_0;
	}

	// Token: 0x02000188 RID: 392
	[StructLayout(LayoutKind.Auto)]
	private struct Struct161 : IAsyncStateMachine
	{
		// Token: 0x0600084E RID: 2126 RVA: 0x0004B1B4 File Offset: 0x000493B4
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class54 @class = this;
			try
			{
				TaskAwaiter taskAwaiter3;
				if (num > 3)
				{
					if (num != 4)
					{
						@class.method_5("Adding to cart", "#c2c2c2", true, false);
						goto IL_30D;
					}
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					int num3 = -1;
					num = -1;
					num2 = num3;
					goto IL_2EA;
				}
				IL_4E:
				int num12;
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter4;
					TaskAwaiter<JArray> taskAwaiter6;
					switch (num)
					{
					case 0:
					{
						TaskAwaiter<HttpResponseMessage> taskAwaiter5;
						taskAwaiter4 = taskAwaiter5;
						taskAwaiter5 = default(TaskAwaiter<HttpResponseMessage>);
						int num4 = -1;
						num = -1;
						num2 = num4;
						break;
					}
					case 1:
					{
						TaskAwaiter<JArray> taskAwaiter7;
						taskAwaiter6 = taskAwaiter7;
						taskAwaiter7 = default(TaskAwaiter<JArray>);
						int num5 = -1;
						num = -1;
						num2 = num5;
						goto IL_17C;
					}
					case 2:
					{
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num6 = -1;
						num = -1;
						num2 = num6;
						goto IL_24F;
					}
					case 3:
					{
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num7 = -1;
						num = -1;
						num2 = num7;
						goto IL_2AA;
					}
					default:
					{
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary["style"] = @class.string_15;
						dictionary["size"] = @class.string_14;
						dictionary["st"] = @class.string_15;
						dictionary["s"] = @class.string_14;
						Dictionary<string, string> dictionary_ = dictionary;
						taskAwaiter4 = @class.class14_0.method_3(@class.string_9 + "/add.json", dictionary_, false).GetAwaiter();
						if (!taskAwaiter4.IsCompleted)
						{
							int num8 = 0;
							num = 0;
							num2 = num8;
							TaskAwaiter<HttpResponseMessage> taskAwaiter5 = taskAwaiter4;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class54.Struct161>(ref taskAwaiter4, ref this);
							return;
						}
						break;
					}
					}
					taskAwaiter6 = taskAwaiter4.GetResult().smethod_2().GetAwaiter();
					if (!taskAwaiter6.IsCompleted)
					{
						int num9 = 1;
						num = 1;
						num2 = num9;
						TaskAwaiter<JArray> taskAwaiter7 = taskAwaiter6;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JArray>, Class54.Struct161>(ref taskAwaiter6, ref this);
						return;
					}
					IL_17C:
					JArray result = taskAwaiter6.GetResult();
					if (result.Count != 0 && (bool)result[0]["in_stock"])
					{
						if ((bool)result[0]["in_stock"])
						{
							@class.method_5("Successfully carted", "#c2c2c2", true, false);
							@class.stopwatch_0.Restart();
							goto IL_352;
						}
						throw new Exception();
					}
					else
					{
						@class.method_5("Waiting for restock", "#c2c2c2", true, false);
						taskAwaiter3 = @class.method_14(Class130.int_0).GetAwaiter();
						if (!taskAwaiter3.IsCompleted)
						{
							int num10 = 2;
							num = 2;
							num2 = num10;
							taskAwaiter2 = taskAwaiter3;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class54.Struct161>(ref taskAwaiter3, ref this);
							return;
						}
					}
					IL_24F:
					taskAwaiter3.GetResult();
					taskAwaiter3 = @class.method_17().GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						int num11 = 3;
						num = 3;
						num2 = num11;
						taskAwaiter2 = taskAwaiter3;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class54.Struct161>(ref taskAwaiter3, ref this);
						return;
					}
					IL_2AA:
					taskAwaiter3.GetResult();
					goto IL_30D;
				}
				catch
				{
					num12 = 1;
				}
				if (num12 != 1)
				{
					goto IL_30D;
				}
				@class.method_5("Error adding to cart", "#c2c2c2", true, false);
				taskAwaiter3 = @class.method_14(Class130.int_1).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					int num13 = 4;
					num = 4;
					num2 = num13;
					taskAwaiter2 = taskAwaiter3;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class54.Struct161>(ref taskAwaiter3, ref this);
					return;
				}
				IL_2EA:
				taskAwaiter3.GetResult();
				@class.method_5("Adding to cart", "#c2c2c2", true, false);
				IL_30D:
				if (!@class.bool_1)
				{
					num12 = 0;
					goto IL_4E;
				}
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_352:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x0600084F RID: 2127 RVA: 0x00006A41 File Offset: 0x00004C41
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000749 RID: 1865
		public int int_0;

		// Token: 0x0400074A RID: 1866
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x0400074B RID: 1867
		public Class54 class54_0;

		// Token: 0x0400074C RID: 1868
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x0400074D RID: 1869
		private TaskAwaiter<JArray> taskAwaiter_1;

		// Token: 0x0400074E RID: 1870
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x02000189 RID: 393
	[StructLayout(LayoutKind.Auto)]
	private struct Struct162 : IAsyncStateMachine
	{
		// Token: 0x06000850 RID: 2128 RVA: 0x0004B55C File Offset: 0x0004975C
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class54 @class = this;
			try
			{
				try
				{
					TaskAwaiter taskAwaiter;
					switch (num)
					{
					case 0:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						break;
					}
					case 1:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_E2;
					}
					case 2:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_13D;
					}
					case 3:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_198;
					}
					case 4:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_1F3;
					}
					case 5:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_251;
					}
					default:
						@class.method_19();
						taskAwaiter = @class.method_11().GetAwaiter();
						if (!taskAwaiter.IsCompleted)
						{
							num2 = 0;
							TaskAwaiter taskAwaiter2 = taskAwaiter;
							this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class54.Struct162>(ref taskAwaiter, ref this);
							return;
						}
						break;
					}
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_16().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 1;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class54.Struct162>(ref taskAwaiter, ref this);
						return;
					}
					IL_E2:
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_17().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 2;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class54.Struct162>(ref taskAwaiter, ref this);
						return;
					}
					IL_13D:
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_18().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 3;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class54.Struct162>(ref taskAwaiter, ref this);
						return;
					}
					IL_198:
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_19().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 4;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class54.Struct162>(ref taskAwaiter, ref this);
						return;
					}
					IL_1F3:
					taskAwaiter.GetResult();
					@class.method_20();
					taskAwaiter = @class.method_22().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 5;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class54.Struct162>(ref taskAwaiter, ref this);
						return;
					}
					IL_251:
					taskAwaiter.GetResult();
				}
				catch
				{
				}
				@class.method_0("Stopped", "red", true, (GEnum1)0);
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

		// Token: 0x06000851 RID: 2129 RVA: 0x00006A4F File Offset: 0x00004C4F
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400074F RID: 1871
		public int int_0;

		// Token: 0x04000750 RID: 1872
		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		// Token: 0x04000751 RID: 1873
		public Class54 class54_0;

		// Token: 0x04000752 RID: 1874
		private TaskAwaiter taskAwaiter_0;
	}

	// Token: 0x0200018A RID: 394
	[StructLayout(LayoutKind.Auto)]
	private struct Struct163 : IAsyncStateMachine
	{
		// Token: 0x06000852 RID: 2130 RVA: 0x0004B838 File Offset: 0x00049A38
		void IAsyncStateMachine.MoveNext()
		{
			int num3;
			int num2 = num3;
			Class54 @class = this;
			try
			{
				TaskAwaiter taskAwaiter3;
				if (num2 > 2)
				{
					if (num2 != 3)
					{
						@class.method_5("Collecting product data", "#c2c2c2", true, false);
						goto IL_3CB;
					}
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					int num4 = -1;
					num2 = -1;
					num3 = num4;
					goto IL_3B2;
				}
				IL_4E:
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter4;
					TaskAwaiter<JObject> taskAwaiter6;
					switch (num2)
					{
					case 0:
					{
						TaskAwaiter<HttpResponseMessage> taskAwaiter5;
						taskAwaiter4 = taskAwaiter5;
						taskAwaiter5 = default(TaskAwaiter<HttpResponseMessage>);
						int num5 = -1;
						num2 = -1;
						num3 = num5;
						break;
					}
					case 1:
					{
						TaskAwaiter<JObject> taskAwaiter7;
						taskAwaiter6 = taskAwaiter7;
						taskAwaiter7 = default(TaskAwaiter<JObject>);
						int num6 = -1;
						num2 = -1;
						num3 = num6;
						goto IL_12B;
					}
					case 2:
					{
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num7 = -1;
						num2 = -1;
						num3 = num7;
						goto IL_373;
					}
					default:
						taskAwaiter4 = @class.class14_0.method_2(@class.string_9 + ".json", false).GetAwaiter();
						if (!taskAwaiter4.IsCompleted)
						{
							int num8 = 0;
							num2 = 0;
							num3 = num8;
							TaskAwaiter<HttpResponseMessage> taskAwaiter5 = taskAwaiter4;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class54.Struct163>(ref taskAwaiter4, ref this);
							return;
						}
						break;
					}
					taskAwaiter6 = taskAwaiter4.GetResult().smethod_1().GetAwaiter();
					if (!taskAwaiter6.IsCompleted)
					{
						int num9 = 1;
						num2 = 1;
						num3 = num9;
						TaskAwaiter<JObject> taskAwaiter7 = taskAwaiter6;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class54.Struct163>(ref taskAwaiter6, ref this);
						return;
					}
					IL_12B:
					JToken source = taskAwaiter6.GetResult()["styles"];
					JToken jtoken;
					if (@class.bool_3)
					{
						jtoken = source.Where(new Func<JToken, bool>(Class54.Class177.class177_0.method_3)).smethod_5();
						if (jtoken == null)
						{
							goto IL_308;
						}
						@class.string_1 = jtoken["name"].ToString();
						@class.string_2 = jtoken["image_url_hi"].ToString();
					}
					else
					{
						jtoken = source.FirstOrDefault(new Func<JToken, bool>(@class.method_23));
						if (jtoken == null)
						{
							@class.method_0("Color unavailable", "red", true, (GEnum1)0);
						}
						@class.string_1 = jtoken["name"].ToString();
						@class.string_2 = jtoken["image_url_hi"].ToString();
					}
					if (@class.bool_4)
					{
						JToken jtoken2 = jtoken["sizes"].Where(new Func<JToken, bool>(Class54.Class177.class177_0.method_5)).smethod_5();
						if (jtoken2 != null)
						{
							@class.string_14 = jtoken2["id"].ToString();
							@class.string_15 = jtoken["id"].ToString();
							@class.method_6(jtoken2["name"].ToString());
							goto IL_429;
						}
					}
					else
					{
						JToken jtoken3 = jtoken["sizes"].FirstOrDefault(new Func<JToken, bool>(@class.method_24));
						if (jtoken3 == null)
						{
							@class.method_0("Size unavailable", "red", true, (GEnum1)0);
						}
						else if ((int)jtoken3["stock_level"] > 0)
						{
							@class.string_14 = jtoken3["id"].ToString();
							@class.string_15 = jtoken["id"].ToString();
							goto IL_429;
						}
					}
					IL_308:
					@class.method_5("Waiting for restock", "#c2c2c2", true, false);
					taskAwaiter3 = @class.method_14(Class130.int_1).GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						int num10 = 2;
						num2 = 2;
						num3 = num10;
						taskAwaiter2 = taskAwaiter3;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class54.Struct163>(ref taskAwaiter3, ref this);
						return;
					}
					IL_373:
					taskAwaiter3.GetResult();
					goto IL_3DF;
				}
				catch
				{
					num = 1;
					goto IL_3DF;
				}
				IL_386:
				@class.method_5("Error collecting data", "#c2c2c2", true, false);
				taskAwaiter3 = @class.method_14(Class130.int_1).GetAwaiter();
				if (taskAwaiter3.IsCompleted)
				{
					goto IL_3B2;
				}
				int num11 = 3;
				num2 = 3;
				num3 = num11;
				taskAwaiter2 = taskAwaiter3;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class54.Struct163>(ref taskAwaiter3, ref this);
				return;
				IL_3DF:
				int num12 = num;
				if (num12 == 1)
				{
					goto IL_386;
				}
				goto IL_3CB;
				IL_3B2:
				taskAwaiter3.GetResult();
				@class.method_5("Collecting product data", "#c2c2c2", true, false);
				IL_3CB:
				if (!@class.bool_1)
				{
					num = 0;
					goto IL_4E;
				}
			}
			catch (Exception exception)
			{
				num3 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_429:
			num3 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000853 RID: 2131 RVA: 0x00006A5D File Offset: 0x00004C5D
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000753 RID: 1875
		public int int_0;

		// Token: 0x04000754 RID: 1876
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000755 RID: 1877
		public Class54 class54_0;

		// Token: 0x04000756 RID: 1878
		private int int_1;

		// Token: 0x04000757 RID: 1879
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000758 RID: 1880
		private TaskAwaiter<JObject> taskAwaiter_1;

		// Token: 0x04000759 RID: 1881
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x0200018B RID: 395
	[StructLayout(LayoutKind.Auto)]
	private struct Struct164 : IAsyncStateMachine
	{
		// Token: 0x06000854 RID: 2132 RVA: 0x0004BCB8 File Offset: 0x00049EB8
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class54 @class = this;
			try
			{
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
							goto IL_147;
						}
						@class.method_5("Checking for store credit", "#c2c2c2", true, false);
						taskAwaiter6 = @class.class14_0.method_2(string.Format("https://www.supremenewyork.com/store_credits/verify?email={0}", @class.jtoken_1["payment"]["email"]), false).GetAwaiter();
						if (!taskAwaiter6.IsCompleted)
						{
							num2 = 0;
							taskAwaiter2 = taskAwaiter6;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class54.Struct164>(ref taskAwaiter6, ref this);
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
					if (result.StatusCode == HttpStatusCode.NotFound)
					{
						@class.method_5("No store credit found", "#c2c2c2", true, false);
						goto IL_1CC;
					}
					htmlDocument = new HtmlDocument();
					htmlDocument2 = htmlDocument;
					taskAwaiter5 = result.smethod_3().GetAwaiter();
					if (!taskAwaiter5.IsCompleted)
					{
						num2 = 1;
						taskAwaiter4 = taskAwaiter5;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class54.Struct164>(ref taskAwaiter5, ref this);
						return;
					}
					IL_147:
					string result2 = taskAwaiter5.GetResult();
					htmlDocument2.LoadHtml(result2);
					htmlDocument2 = null;
					@class.string_17 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='store_credit']").Attributes["value"].Value;
					@class.method_5("Using store credits", "#c2c2c2", true, false);
					htmlDocument = null;
				}
				catch
				{
				}
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_1CC:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000855 RID: 2133 RVA: 0x00006A6B File Offset: 0x00004C6B
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400075A RID: 1882
		public int int_0;

		// Token: 0x0400075B RID: 1883
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x0400075C RID: 1884
		public Class54 class54_0;

		// Token: 0x0400075D RID: 1885
		private HtmlDocument htmlDocument_0;

		// Token: 0x0400075E RID: 1886
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x0400075F RID: 1887
		private HtmlDocument htmlDocument_1;

		// Token: 0x04000760 RID: 1888
		private TaskAwaiter<string> taskAwaiter_1;
	}

	// Token: 0x0200018C RID: 396
	[StructLayout(LayoutKind.Auto)]
	private struct Struct165 : IAsyncStateMachine
	{
		// Token: 0x06000856 RID: 2134 RVA: 0x0004BED8 File Offset: 0x0004A0D8
		void IAsyncStateMachine.MoveNext()
		{
			int num3;
			int num2 = num3;
			Class54 @class = this;
			try
			{
				TaskAwaiter taskAwaiter3;
				if (num2 > 2)
				{
					if (num2 != 3)
					{
						@class.method_5("Waiting for product", "#c2c2c2", true, false);
						goto IL_2AC;
					}
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					int num4 = -1;
					num2 = -1;
					num3 = num4;
					goto IL_2A5;
				}
				IL_4E:
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter4;
					TaskAwaiter<JObject> taskAwaiter6;
					switch (num2)
					{
					case 0:
					{
						TaskAwaiter<HttpResponseMessage> taskAwaiter5;
						taskAwaiter4 = taskAwaiter5;
						taskAwaiter5 = default(TaskAwaiter<HttpResponseMessage>);
						int num5 = -1;
						num2 = -1;
						num3 = num5;
						break;
					}
					case 1:
					{
						TaskAwaiter<JObject> taskAwaiter7;
						taskAwaiter6 = taskAwaiter7;
						taskAwaiter7 = default(TaskAwaiter<JObject>);
						int num6 = -1;
						num2 = -1;
						num3 = num6;
						goto IL_120;
					}
					case 2:
					{
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num7 = -1;
						num2 = -1;
						num3 = num7;
						goto IL_278;
					}
					default:
						taskAwaiter4 = @class.class14_0.method_2("https://www.supremenewyork.com/shop.json", false).GetAwaiter();
						if (!taskAwaiter4.IsCompleted)
						{
							int num8 = 0;
							num2 = 0;
							num3 = num8;
							TaskAwaiter<HttpResponseMessage> taskAwaiter5 = taskAwaiter4;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class54.Struct165>(ref taskAwaiter4, ref this);
							return;
						}
						break;
					}
					taskAwaiter6 = taskAwaiter4.GetResult().smethod_1().GetAwaiter();
					if (!taskAwaiter6.IsCompleted)
					{
						int num9 = 1;
						num2 = 1;
						num3 = num9;
						TaskAwaiter<JObject> taskAwaiter7 = taskAwaiter6;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class54.Struct165>(ref taskAwaiter6, ref this);
						return;
					}
					IL_120:
					IEnumerator<JToken> enumerator = ((IEnumerable<JToken>)(taskAwaiter6.GetResult()["products_and_categories"][@class.string_8] ?? new JObject())).GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							JToken jtoken = enumerator.Current;
							string @object = jtoken["name"].ToString().ToLower().smethod_6();
							if (@class.string_11.All(new Func<string, bool>(@object.Contains)) && !@class.string_10.Any(new Func<string, bool>(@object.Contains)))
							{
								@class.string_9 = "https://www.supremenewyork.com/shop/" + jtoken["id"];
								@class.method_7(jtoken["name"].ToString(), "#c2c2c2");
								@class.method_5("Found product: " + jtoken["name"], "#c2c2c2", true, false);
								goto IL_30A;
							}
						}
					}
					finally
					{
						if (num2 < 0 && enumerator != null)
						{
							enumerator.Dispose();
						}
					}
					taskAwaiter3 = @class.method_14(Class130.int_0).GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						int num10 = 2;
						num2 = 2;
						num3 = num10;
						taskAwaiter2 = taskAwaiter3;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class54.Struct165>(ref taskAwaiter3, ref this);
						return;
					}
					IL_278:
					taskAwaiter3.GetResult();
					goto IL_2C0;
				}
				catch
				{
					num = 1;
					goto IL_2C0;
				}
				IL_28B:
				taskAwaiter3 = @class.method_14(Class130.int_0).GetAwaiter();
				if (taskAwaiter3.IsCompleted)
				{
					goto IL_2A5;
				}
				int num11 = 3;
				num2 = 3;
				num3 = num11;
				taskAwaiter2 = taskAwaiter3;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class54.Struct165>(ref taskAwaiter3, ref this);
				return;
				IL_2C0:
				int num12 = num;
				if (num12 == 1)
				{
					goto IL_28B;
				}
				goto IL_2AC;
				IL_2A5:
				taskAwaiter3.GetResult();
				IL_2AC:
				if (!@class.bool_1)
				{
					num = 0;
					goto IL_4E;
				}
			}
			catch (Exception exception)
			{
				num3 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_30A:
			num3 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000857 RID: 2135 RVA: 0x00006A79 File Offset: 0x00004C79
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000761 RID: 1889
		public int int_0;

		// Token: 0x04000762 RID: 1890
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000763 RID: 1891
		public Class54 class54_0;

		// Token: 0x04000764 RID: 1892
		private int int_1;

		// Token: 0x04000765 RID: 1893
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000766 RID: 1894
		private TaskAwaiter<JObject> taskAwaiter_1;

		// Token: 0x04000767 RID: 1895
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x0200018D RID: 397
	[StructLayout(LayoutKind.Auto)]
	private struct Struct166 : IAsyncStateMachine
	{
		// Token: 0x06000858 RID: 2136 RVA: 0x0004C250 File Offset: 0x0004A450
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class54 @class = this;
			bool result;
			try
			{
				TaskAwaiter<string> taskAwaiter;
				if (num != 0)
				{
					if (@class.stopwatch_0.ElapsedMilliseconds <= 115000L && @class.dictionary_0.ContainsKey("g-recaptcha-response"))
					{
						result = false;
						goto IL_12A;
					}
					@class.stopwatch_0.Reset();
					@class.method_5("Waiting for captcha token", "turquoise", true, false);
					taskAwaiter = CaptchaQueue.smethod_0(@class.string_13, "https://www.supremenewyork.com/checkout", (string)@class.jtoken_0["id"], @class.cancellationTokenSource_0.Token).GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 0;
						TaskAwaiter<string> taskAwaiter2 = taskAwaiter;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class54.Struct166>(ref taskAwaiter, ref this);
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
				string result2 = taskAwaiter.GetResult();
				@class.string_7 = result2;
				@class.stopwatch_0.Start();
				@class.dictionary_0["g-recaptcha-response"] = @class.string_7;
				result = true;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_12A:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult(result);
		}

		// Token: 0x06000859 RID: 2137 RVA: 0x00006A87 File Offset: 0x00004C87
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000768 RID: 1896
		public int int_0;

		// Token: 0x04000769 RID: 1897
		public AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder_0;

		// Token: 0x0400076A RID: 1898
		public Class54 class54_0;

		// Token: 0x0400076B RID: 1899
		private TaskAwaiter<string> taskAwaiter_0;
	}
}
