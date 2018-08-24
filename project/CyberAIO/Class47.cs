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

// Token: 0x020000C2 RID: 194
internal sealed class Class47 : Class44
{
	// Token: 0x060004B9 RID: 1209 RVA: 0x00022E64 File Offset: 0x00021064
	public Class47(JToken jtoken_2, string string_18)
	{
		try
		{
			this.jtoken_0 = jtoken_2;
			this.string_7 = (string)jtoken_2["keywords"];
			this.string_9 = string_18;
			if (!((string)jtoken_2["size"] == "Random") && !((string)jtoken_2["size"] == "OneSize"))
			{
				this.string_0 = (string)jtoken_2["size"];
			}
			else
			{
				this.string_0 = Class108.smethod_16();
				base.method_6(this.string_0);
			}
			this.string_0 = Class43.smethod_4(this.string_0);
			if (!this.string_0.Contains(".5") && this.string_0.Replace(".", string.Empty).smethod_15())
			{
				this.string_0 += ".0";
			}
			if (this.string_0.Length == 3)
			{
				this.string_0 = "0" + this.string_0;
			}
			if (!base.method_2(out this.jtoken_1))
			{
				base.method_0("Profile error", "red", true, (GEnum1)0);
			}
			else
			{
				this.string_16 = base.method_3();
				this.class14_0 = new Class14(this.string_16, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36", 10, false, false, null);
				this.class14_0.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("Origin", string.Format("https://www.{0}", string_18));
				this.class14_0.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("Referer", string.Format("https://www.{0}", string_18));
				this.class14_0.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "*/*");
				this.class14_0.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("Connection", "keep-alive");
				this.class14_0.httpClient_0.DefaultRequestHeaders.ExpectContinue = new bool?(false);
				this.string_17 = Class47.smethod_0(32);
			}
		}
		catch
		{
			base.method_0("Task error", "red", true, (GEnum1)0);
		}
	}

	// Token: 0x060004BA RID: 1210 RVA: 0x000230B0 File Offset: 0x000212B0
	public override async void vmethod_0()
	{
		try
		{
			await base.method_11();
			await this.method_20();
			await base.method_13(TimeSpan.FromMilliseconds((double)this.int_0), "Waiting");
			await this.method_21();
			await this.method_22();
			await this.method_23();
			await this.method_24();
			await this.method_25();
			await this.method_27();
		}
		catch
		{
		}
		base.method_0("Stopped", "red", true, (GEnum1)0);
	}

	// Token: 0x060004BB RID: 1211 RVA: 0x000230EC File Offset: 0x000212EC
	public async Task method_15()
	{
		await this.method_21();
		await this.method_22();
		await this.method_23();
		await this.method_24();
		await this.method_25();
		await this.method_26();
		await this.method_27();
	}

	// Token: 0x060004BC RID: 1212 RVA: 0x00004EAB File Offset: 0x000030AB
	public static string smethod_0(int int_1)
	{
		return new string(Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", int_1).Select(new Func<string, char>(Class47.Class122.class122_0.method_0)).ToArray<char>());
	}

	// Token: 0x060004BD RID: 1213 RVA: 0x00023134 File Offset: 0x00021334
	public string method_16(string string_18)
	{
		switch (string_18[0])
		{
		case '3':
			return "amex";
		case '4':
			return "visa";
		case '5':
			return "mc";
		default:
			return "mc";
		}
	}

	// Token: 0x060004BE RID: 1214 RVA: 0x00023178 File Offset: 0x00021378
	public async Task<bool> method_17(HttpResponseMessage httpResponseMessage_0)
	{
		string text = await httpResponseMessage_0.smethod_3();
		bool result;
		if (text.Contains("CART_WAIT"))
		{
			TaskAwaiter taskAwaiter = this.method_22().GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter);
			}
			taskAwaiter.GetResult();
			result = true;
		}
		else if (httpResponseMessage_0.StatusCode == HttpStatusCode.Found && httpResponseMessage_0.Headers.Location.ToString() == "https://www.footlocker.eu/")
		{
			base.method_0("US proxy required", "red", true, (GEnum1)0);
			result = false;
		}
		else if (text.Contains("SESSION_EXPIRED"))
		{
			TaskAwaiter taskAwaiter = base.method_14(1000).GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter);
			}
			taskAwaiter.GetResult();
			if (this.cookieCollection_0 != null)
			{
				this.class14_0.cookieContainer_0.Add(this.cookieCollection_0);
			}
			result = true;
		}
		else if (text.Contains("CART_EMPTY"))
		{
			TaskAwaiter taskAwaiter = this.method_15().GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter);
			}
			taskAwaiter.GetResult();
			result = true;
		}
		else if (httpResponseMessage_0.StatusCode == HttpStatusCode.Forbidden)
		{
			base.method_5("Banned, retrying", "red", true, false);
			TaskAwaiter taskAwaiter = base.method_14(Class130.int_1).GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter);
			}
			taskAwaiter.GetResult();
			result = true;
		}
		else
		{
			result = false;
		}
		return result;
	}

	// Token: 0x060004BF RID: 1215 RVA: 0x000231C8 File Offset: 0x000213C8
	public async Task method_18()
	{
		base.method_5("Getting request key", "#c2c2c2", true, false);
		Cookie cookie = new Cookie("requestKey", string.Empty);
		cookie.Expired = true;
		this.class14_0.cookieContainer_0.Add(new Uri(string.Format("https://www.{0}/", this.string_9)), cookie);
		for (;;)
		{
			int num = 0;
			try
			{
				base.method_5("Getting request key", "#c2c2c2", true, false);
				TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class14_0.method_2(string.Format("https://www.{0}/session/", this.string_9), false).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter<HttpResponseMessage> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
				}
				TaskAwaiter<JObject> taskAwaiter3 = taskAwaiter.GetResult().smethod_1().GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<JObject> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<JObject>);
				}
				JObject result = taskAwaiter3.GetResult();
				this.string_10 = result["data"]["RequestKey"].ToString();
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error getting request key", "#c2c2c2", true, false);
				TaskAwaiter taskAwaiter5 = base.method_14(Class130.int_1).GetAwaiter();
				if (!taskAwaiter5.IsCompleted)
				{
					await taskAwaiter5;
					TaskAwaiter taskAwaiter6;
					taskAwaiter5 = taskAwaiter6;
					taskAwaiter6 = default(TaskAwaiter);
				}
				taskAwaiter5.GetResult();
			}
		}
	}

	// Token: 0x060004C0 RID: 1216 RVA: 0x00023210 File Offset: 0x00021410
	public void method_19()
	{
		if ((string)this.jtoken_0["size"] == "Random")
		{
			this.string_0 = Class108.smethod_16();
			base.method_6(this.string_0);
			if (!this.string_0.Contains(".5"))
			{
				this.string_0 += ".0";
			}
			if (this.string_0.Length == 3)
			{
				this.string_0 = "0" + this.string_0;
			}
		}
	}

	// Token: 0x060004C1 RID: 1217 RVA: 0x000232A4 File Offset: 0x000214A4
	public async Task method_20()
	{
		HtmlDocument htmlDocument = new HtmlDocument();
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Collecting data", "#c2c2c2", true, false);
				HttpResponseMessage httpResponseMessage = await this.class14_0.method_2(this.string_7, false);
				TaskAwaiter<bool> taskAwaiter = this.method_17(httpResponseMessage).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter<bool> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<bool>);
				}
				if (taskAwaiter.GetResult())
				{
					continue;
				}
				httpResponseMessage.EnsureSuccessStatusCode();
				string text = await httpResponseMessage.smethod_3();
				htmlDocument.LoadHtml(text);
				this.string_10 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='requestKey']").Attributes["value"].Value;
				this.string_8 = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='sku']").Attributes["value"].Value;
				if (!this.string_7.Contains(this.string_8))
				{
					base.method_0("Product pulled", "red", true, (GEnum1)0);
				}
				if (text.Contains("var cm_isLaunchSku = 'Y';") && this.string_9 != "footaction.com")
				{
					this.int_0 = Convert.ToInt32(text.Split(new string[]
					{
						"var productLaunchTimeUntil = "
					}, StringSplitOptions.None)[1].Split(new char[]
					{
						';'
					})[0]) - 1;
				}
				else if (this.string_9 == "footaction.com" && !text.Contains("id=\"addToWishlist\""))
				{
					this.int_0 = Convert.ToInt32(text.Split(new string[]
					{
						"var timeToHL = "
					}, StringSplitOptions.None)[1].Split(new char[]
					{
						';'
					})[0]) - 1;
				}
				httpResponseMessage = null;
				goto IL_352;
			}
			catch
			{
				num = 1;
				goto IL_352;
			}
			IL_307:
			base.method_5("Error collecting data", "#c2c2c2", true, false);
			TaskAwaiter taskAwaiter3 = base.method_14(Class130.int_1).GetAwaiter();
			if (!taskAwaiter3.IsCompleted)
			{
				await taskAwaiter3;
				TaskAwaiter taskAwaiter4;
				taskAwaiter3 = taskAwaiter4;
				taskAwaiter4 = default(TaskAwaiter);
			}
			taskAwaiter3.GetResult();
			continue;
			IL_352:
			if (num == 1)
			{
				goto IL_307;
			}
			try
			{
				if (!(this.string_9 == "champssports.com") && !(this.string_9 == "footlocker.ca"))
				{
					base.method_7(htmlDocument.DocumentNode.SelectSingleNode("//input[@id='model_name']").Attributes["value"].Value, "#c2c2c2");
				}
				else
				{
					base.method_7(htmlDocument.DocumentNode.SelectSingleNode("//*[@id='model_name']").InnerText, "#c2c2c2");
				}
			}
			catch
			{
			}
			return;
		}
	}

	// Token: 0x060004C2 RID: 1218 RVA: 0x000232EC File Offset: 0x000214EC
	public async Task method_21()
	{
		int num = 1;
		base.method_5("Adding to cart", "#c2c2c2", true, false);
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary["storeCostOfGoods"] = "0.00";
		dictionary["requestKey"] = this.string_10;
		dictionary["sku"] = this.string_8;
		dictionary["qty"] = "1";
		dictionary["size"] = this.string_0;
		dictionary["quantity"] = "1";
		dictionary["inlineAddToCart"] = "1";
		for (;;)
		{
			int num2 = 0;
			try
			{
				if (num == 1)
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class14_0.method_3(string.Format("https://www.{0}/index.cfm?uri=add2cart&fragment=true", this.string_9), dictionary, false).GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						await taskAwaiter;
						TaskAwaiter<HttpResponseMessage> taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
					}
					HttpResponseMessage result = taskAwaiter.GetResult();
					TaskAwaiter<bool> taskAwaiter3 = this.method_17(result).GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						await taskAwaiter3;
						TaskAwaiter<bool> taskAwaiter4;
						taskAwaiter3 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<bool>);
					}
					if (taskAwaiter3.GetResult())
					{
						continue;
					}
					result.EnsureSuccessStatusCode();
					string text = await result.smethod_3();
					if (text.ToLower().Contains("out of stock") || text.Contains("Due to high demand"))
					{
						base.method_5("Waiting for restock", "#c2c2c2", true, false);
						await base.method_14(Class130.int_0);
						this.method_19();
						num++;
						continue;
					}
					TaskAwaiter<JObject> taskAwaiter5 = result.smethod_1().GetAwaiter();
					if (!taskAwaiter5.IsCompleted)
					{
						await taskAwaiter5;
						TaskAwaiter<JObject> taskAwaiter6;
						taskAwaiter5 = taskAwaiter6;
						taskAwaiter6 = default(TaskAwaiter<JObject>);
					}
					JObject result2 = taskAwaiter5.GetResult();
					if ((bool)result2["success"])
					{
						this.string_10 = result2["nextRequestKey"].ToString();
						base.method_5("Successfully carted", "#c2c2c2", true, false);
						break;
					}
				}
				else if (num == 2)
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class14_0.method_2(string.Format("https://www.{0}/pdp/gateway?requestKey={1}&action=add&qty=1&quantity=1&sku={2}&size={3}&fulfillmentType=SHIP_TO_HOME&storeNumber=0&_=1509399855629", new object[]
					{
						this.string_9,
						this.string_10,
						this.string_8,
						this.string_0
					}), false).GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						await taskAwaiter;
						TaskAwaiter<HttpResponseMessage> taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
					}
					HttpResponseMessage result = taskAwaiter.GetResult();
					TaskAwaiter<bool> taskAwaiter3 = this.method_17(result).GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						await taskAwaiter3;
						TaskAwaiter<bool> taskAwaiter4;
						taskAwaiter3 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<bool>);
					}
					if (taskAwaiter3.GetResult())
					{
						continue;
					}
					result.EnsureSuccessStatusCode();
					string text2 = await result.smethod_3();
					if (text2.Contains("Item Out Of Stock") || text2.Contains("Due to high demand"))
					{
						base.method_5("Waiting for restock", "#c2c2c2", true, false);
						await base.method_14(Class130.int_0);
						this.method_19();
						num++;
						continue;
					}
					TaskAwaiter<JObject> taskAwaiter5 = result.smethod_1().GetAwaiter();
					if (!taskAwaiter5.IsCompleted)
					{
						await taskAwaiter5;
						TaskAwaiter<JObject> taskAwaiter6;
						taskAwaiter5 = taskAwaiter6;
						taskAwaiter6 = default(TaskAwaiter<JObject>);
					}
					JObject result3 = taskAwaiter5.GetResult();
					if ((bool)result3["success"])
					{
						this.string_10 = result3["data"]["RequestKey"].ToString();
						base.method_5("Successfully carted", "#c2c2c2", true, false);
						break;
					}
				}
				else
				{
					if (num != 3)
					{
						num = 1;
						continue;
					}
					TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class14_0.method_3(string.Format("https://www.{0}/catalog/miniAddToCart.cfm", this.string_9), dictionary, false).GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						await taskAwaiter;
						TaskAwaiter<HttpResponseMessage> taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
					}
					HttpResponseMessage result = taskAwaiter.GetResult();
					TaskAwaiter<bool> taskAwaiter3 = this.method_17(result).GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						await taskAwaiter3;
						TaskAwaiter<bool> taskAwaiter4;
						taskAwaiter3 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<bool>);
					}
					if (taskAwaiter3.GetResult())
					{
						continue;
					}
					result.EnsureSuccessStatusCode();
					string text3 = await result.smethod_3();
					if (text3.ToLower().Contains("out of stock") || text3.Contains("Due to high demand"))
					{
						base.method_5("Waiting for restock", "#c2c2c2", true, false);
						await base.method_14(Class130.int_0);
						this.method_19();
						num++;
						continue;
					}
					if (text3.Contains("1 item in cart"))
					{
						this.string_10 = text3.Split(new string[]
						{
							"var requestKey =\""
						}, StringSplitOptions.None)[1].Split(new char[]
						{
							'"'
						})[0];
						base.method_5("Successfully carted", "#c2c2c2", true, false);
						break;
					}
				}
				throw new Exception();
			}
			catch
			{
				num2 = 1;
			}
			if (num2 == 1)
			{
				base.method_5("Error adding to cart", "#c2c2c2", true, false);
				TaskAwaiter taskAwaiter7 = base.method_14(Class130.int_1).GetAwaiter();
				if (!taskAwaiter7.IsCompleted)
				{
					await taskAwaiter7;
					TaskAwaiter taskAwaiter8;
					taskAwaiter7 = taskAwaiter8;
					taskAwaiter8 = default(TaskAwaiter);
				}
				taskAwaiter7.GetResult();
				this.method_19();
				num++;
				base.method_5("Adding to cart", "#c2c2c2", true, false);
			}
		}
	}

	// Token: 0x060004C3 RID: 1219 RVA: 0x00023334 File Offset: 0x00021534
	public async Task method_22()
	{
		while (!this.bool_1)
		{
			int num = 0;
			TaskAwaiter taskAwaiter2;
			try
			{
				base.method_5("Checking inventory", "#c2c2c2", true, false);
				JObject jobject = await(await this.class14_0.method_2(string.Format("https://www.{0}/pdp/gateway?requestKey={1}&action=checkout&_=1521900315214", this.string_9, this.string_10), false)).smethod_1();
				while (Convert.ToInt16(jobject["data"]["queue"]["checkoutTimeSecondsUntil"].ToString()) > 0)
				{
					base.method_5("In checkout queue", "#c2c2c2", true, false);
					TaskAwaiter taskAwaiter = base.method_14((int)(Convert.ToInt16(jobject["data"]["checkoutTimeSecondsUntil"].ToString()) * 1000)).GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						await taskAwaiter;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
					}
					taskAwaiter.GetResult();
				}
				if (jobject["data"]["inventory"]["outOfStockLines"].Any<JToken>())
				{
					base.method_5("Out of stock, restarting", "#c2c2c2", true, false);
					TaskAwaiter taskAwaiter = base.method_14(Class130.int_1).GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						await taskAwaiter;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
					}
					taskAwaiter.GetResult();
					await this.method_15();
					break;
				}
				if (object.Equals(false, (bool)jobject["data"]["state"]["inventoryCheckFail"]))
				{
					break;
				}
				throw new Exception();
			}
			catch (ArgumentException)
			{
				break;
			}
			catch (FormatException)
			{
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error checking inventory", "#c2c2c2", true, false);
				TaskAwaiter taskAwaiter = base.method_14(Class130.int_1).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter.GetResult();
				continue;
			}
		}
	}

	// Token: 0x060004C4 RID: 1220 RVA: 0x0002337C File Offset: 0x0002157C
	public async Task method_23()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Collecting checkout data", "#c2c2c2", true, false);
				HttpResponseMessage httpResponseMessage = await this.class14_0.method_2(string.Format("https://www.{0}/checkout/?uri=checkout/", this.string_9), false);
				TaskAwaiter<bool> taskAwaiter = this.method_17(httpResponseMessage).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter<bool> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<bool>);
				}
				if (taskAwaiter.GetResult())
				{
					continue;
				}
				httpResponseMessage.EnsureSuccessStatusCode();
				HtmlDocument htmlDocument = new HtmlDocument();
				HtmlDocument htmlDocument2 = htmlDocument;
				htmlDocument2.LoadHtml(await httpResponseMessage.smethod_3());
				htmlDocument2 = null;
				this.string_11 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='hbg']").Attributes["value"].Value;
				this.string_10 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='requestKey']").Attributes["value"].Value;
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error collecting checkout data", "#c2c2c2", true, false);
				TaskAwaiter taskAwaiter3 = base.method_14(Class130.int_1).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter);
				}
				taskAwaiter3.GetResult();
			}
		}
	}

	// Token: 0x060004C5 RID: 1221 RVA: 0x000233C4 File Offset: 0x000215C4
	public async Task method_24()
	{
		this.cookieCollection_0 = this.class14_0.cookieContainer_0.GetCookies(new Uri(string.Format("https://www.{0}", this.string_9)));
		for (;;)
		{
			int num = 0;
			try
			{
				base.method_5("Submitting shipping data", "#c2c2c2", true, false);
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				string value = "{\"maxVisitedPane\":\"billAddressPane\",\"billMyAddressBookIndex\":\"-1\",\"addressNeedsVerification\":true,\"billFirstName\":\"\",\"billLastName\":\"\",\"billAddress1\":\"\",\"billAddress2\":\"\",\"billCity\":\"\",\"billState\":\"\",\"billProvince\":\"\",\"billPostalCode\":\"\",\"billHomePhone\":\"\",\"billMobilePhone\":\"\",\"billCountry\":\"US\",\"billEmailAddress\":\"\",\"billConfirmEmail\":\"\",\"billAddrIsPhysical\":true,\"billSubscribePhone\":false,\"billAbbreviatedAddress\":false,\"shipUpdateDefaultAddress\":false,\"VIPNumber\":\"\",\"accountBillAddress\":{\"billMyAddressBookIndex\":-1},\"selectedBillAddress\":{},\"billMyAddressBook\":[],\"updateBillingForBML\":false}";
				dictionary["requestKey"] = this.string_10;
				dictionary["hbg"] = this.string_11;
				dictionary["addressBookEnabled"] = "true";
				dictionary["billAddressType"] = "new";
				dictionary["billAddressInputType"] = "single";
				dictionary["billCountry"] = Class43.smethod_0((string)this.jtoken_1["billing"]["country"], false);
				dictionary["billMyAddressBookIndex"] = "-1";
				dictionary["billFirstName"] = (string)this.jtoken_1["billing"]["first_name"];
				dictionary["billLastName"] = (string)this.jtoken_1["billing"]["last_name"];
				dictionary["billAddress1"] = (string)this.jtoken_1["billing"]["addr1"];
				dictionary["billAddress2"] = (string)this.jtoken_1["billing"]["addr2"];
				dictionary["billPostalCode"] = (string)this.jtoken_1["billing"]["zip"];
				dictionary["billCity"] = (string)this.jtoken_1["billing"]["city"];
				dictionary["billState"] = Class43.smethod_1((string)this.jtoken_1["billing"]["country"], (string)this.jtoken_1["billing"]["state"]);
				dictionary["billProvince"] = Class43.smethod_1((string)this.jtoken_1["billing"]["country"], (string)this.jtoken_1["billing"]["state"]);
				dictionary["billHomePhone"] = (string)this.jtoken_1["payment"]["phone"];
				dictionary["billEmailAddress"] = (string)this.jtoken_1["payment"]["email"];
				dictionary["billConfirmEmail"] = (string)this.jtoken_1["payment"]["email"];
				dictionary["shipAddressType"] = "different";
				dictionary["shipAddressInputType"] = "single";
				dictionary["shipCountry"] = Class43.smethod_0((string)this.jtoken_1["delivery"]["country"], false);
				dictionary["shipMyAddressBookIndex"] = "-2";
				dictionary["shipToStore"] = "false";
				dictionary["shipFirstName"] = (string)this.jtoken_1["delivery"]["first_name"];
				dictionary["shipLastName"] = (string)this.jtoken_1["delivery"]["last_name"];
				dictionary["shipAddress1"] = (string)this.jtoken_1["delivery"]["addr1"];
				dictionary["shipAddress2"] = (string)this.jtoken_1["delivery"]["addr2"];
				dictionary["shipPostalCode"] = (string)this.jtoken_1["delivery"]["zip"];
				dictionary["shipCity"] = (string)this.jtoken_1["delivery"]["city"];
				dictionary["shipState"] = Class43.smethod_1((string)this.jtoken_1["delivery"]["country"], (string)this.jtoken_1["delivery"]["state"]);
				dictionary["shipProvince"] = Class43.smethod_1((string)this.jtoken_1["delivery"]["country"], (string)this.jtoken_1["delivery"]["state"]);
				dictionary["shipHomePhone"] = (string)this.jtoken_1["payment"]["phone"];
				dictionary["verifiedCheckoutData"] = value;
				HttpResponseMessage httpResponseMessage = await this.class14_0.method_3(string.Format("https://www.{0}/checkout/eventGateway?method=validateShipPane", this.string_9), dictionary, false);
				TaskAwaiter<bool> taskAwaiter = this.method_17(httpResponseMessage).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter<bool> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<bool>);
				}
				if (taskAwaiter.GetResult())
				{
					continue;
				}
				httpResponseMessage.EnsureSuccessStatusCode();
				string text = await httpResponseMessage.smethod_3();
				JObject jobject = JObject.Parse(text.Substring(2, text.Length - 2));
				if (jobject["RESPONSEERROR"].ToString() != "False")
				{
					throw new Exception();
				}
				if (text.Contains("One or more items cannot be shipped to the destination"))
				{
					base.method_0("Shipping restriction", "red", true, (GEnum1)0);
				}
				this.string_10 = jobject["REQUESTKEY"].ToString();
				this.string_11 = jobject["hbg"].ToString();
				if (this.string_9 == "footlocker.ca")
				{
					this.string_14 = jobject["SHIPMETHODPANE"]["SELECTEDMETHODNAMESFS"].ToString();
					this.string_15 = jobject["SHIPMETHODPANE"]["SELECTEDMETHODCODESFS"].ToString();
				}
				else if (jobject["SHIPMETHODPANE"]["VALIDMETHODS"].Any<JToken>())
				{
					this.string_14 = jobject["SHIPMETHODPANE"]["VALIDMETHODS"][0]["SHIPPINGMETHODNAME"].ToString();
					this.string_15 = jobject["SHIPMETHODPANE"]["VALIDMETHODS"][0]["SHIPMETHODCODE"].ToString();
				}
				else
				{
					this.string_14 = jobject["SHIPMETHODPANE"]["SELECTEDMETHODCODESFS"].ToString();
					this.string_15 = jobject["SHIPMETHODPANE"]["SELECTEDMETHODNAMESFS"].ToString();
				}
				this.string_13 = jobject["SHIPPANE"]["SHIPHASH"].ToString();
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error submitting shipping data", "#c2c2c2", true, false);
				TaskAwaiter taskAwaiter3 = base.method_14(Class130.int_1).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter);
				}
				taskAwaiter3.GetResult();
			}
		}
	}

	// Token: 0x060004C6 RID: 1222 RVA: 0x0002340C File Offset: 0x0002160C
	public async Task method_25()
	{
		this.cookieCollection_0 = this.class14_0.cookieContainer_0.GetCookies(new Uri(string.Format("https://www.{0}", this.string_9)));
		for (;;)
		{
			int num = 0;
			try
			{
				base.method_5("Submitting shipping method", "#c2c2c2", true, false);
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary["verifiedCheckoutData"] = string.Format("{{\"maxVisitedPane\":\"shipMethodPane\",\"billMyAddressBookIndex\":\"-1\",\"addressNeedsVerification\":false,\"billFirstName\":\"{0}\",\"billLastName\":\"{1}\",\"billAddress1\":\"{2}\",\"billAddress2\":\"{3}\",\"billCity\":\"{4}\",\"billState\":\"{5}\",\"billProvince\":\"{6}\",\"billPostalCode\":\"{7}\",\"billHomePhone\":\"{8}\",\"billMobilePhone\":\"\",\"billCountry\":\"{9}\",\"billEmailAddress\":\"{10}\",\"billConfirmEmail\":\"{11}\",\"billAddrIsPhysical\":true,\"billSubscribePhone\":false,\"billAbbreviatedAddress\":false,\"shipUpdateDefaultAddress\":false,\"VIPNumber\":\"\",\"accountBillAddress\":{{\"billMyAddressBookIndex\":-1}},\"selectedBillAddress\":{{}},\"billMyAddressBook\":[],\"updateBillingForBML\":false,\"shipMyAddressBookIndex\":-1,\"useBillingAsShipping\":false,\"shipFirstName\":\"{12}\",\"shipLastName\":\"{13}\",\"shipAddress1\":\"{14}\",\"shipAddress2\":\"{15}\",\"shipCity\":\"{16}\",\"shipState\":\"{17}\",\"shipProvince\":\"{18}\",\"shipPostalCode\":\"{19}\",\"shipHomePhone\":\"{20}\",\"shipMobilePhone\":\"\",\"shipCountry\":\"{21}\",\"shipHash\":\"{22}\",\"shipMultiple\":false,\"isShipToStoreEligibleCheckout\":false,\"shipToStore\":false,\"isMultipleAddressEligible\":false,\"shipAbbreviatedAddress\":false,\"selectedStore\":{{}},\"accountShipAddress\":{{\"shipMyAddressBookIndex\":-1}},\"selectedShipAddress\":{{}},\"shipMyAddressBook\":[],\"shipMethodCode\":\"{23}\",\"shipMethodName\":\"{24}\",\"shipMethodPrice\":\"$42.00\",\"shipDeliveryEstimate\":\"\",\"shipMethodCodeSDD\":\"\",\"shipMethodNameSDD\":\"\",\"shipMethodPriceSDD\":\"$0.00\",\"shipDeliveryEstimateSDD\":\"\",\"shipMethodCodeS2S\":\"\",\"shipMethodNameS2S\":\"\",\"shipMethodPriceS2S\":\"$0.00\",\"shipDeliveryEstimateS2S\":\"\",\"shipMethodCodeSFS\":\"\",\"shipMethodNameSFS\":\"\",\"shipMethodPriceSFS\":\"$0.00\",\"shipDeliveryEstimateSFS\":\"\",\"homeDeliveryPrice\":\"$42.00\",\"overallHomeDeliveryPrice\":\"$42.00\",\"aggregatedDeliveryPrice\":\"$42.00\",\"aggregatedDeliveryLabel\":\"\",\"showGiftBoxOption\":false,\"addGiftBox\":false,\"giftBoxPrice\":\"$3.99\",\"useGiftReceipt\":false,\"showGiftOptions\":false,\"loyaltyMessageText\":false,\"showLoyaltyRenewalMessage\":false,\"pickupPersonFirstName\":\"\",\"pickupPersonLastName\":\"\"}}", new object[]
				{
					(string)this.jtoken_1["billing"]["first_name"],
					(string)this.jtoken_1["billing"]["last_name"],
					(string)this.jtoken_1["billing"]["addr1"],
					(string)this.jtoken_1["billing"]["addr2"],
					(string)this.jtoken_1["billing"]["city"],
					Class43.smethod_1((string)this.jtoken_1["billing"]["country"], (string)this.jtoken_1["billing"]["state"]),
					Class43.smethod_1((string)this.jtoken_1["billing"]["country"], (string)this.jtoken_1["billing"]["state"]),
					(string)this.jtoken_1["billing"]["zip"],
					(string)this.jtoken_1["payment"]["phone"],
					Class43.smethod_0((string)this.jtoken_1["billing"]["country"], false),
					(string)this.jtoken_1["payment"]["email"],
					(string)this.jtoken_1["payment"]["email"],
					(string)this.jtoken_1["delivery"]["first_name"],
					(string)this.jtoken_1["delivery"]["last_name"],
					(string)this.jtoken_1["delivery"]["addr1"],
					(string)this.jtoken_1["delivery"]["addr2"],
					(string)this.jtoken_1["delivery"]["city"],
					Class43.smethod_1((string)this.jtoken_1["delivery"]["country"], (string)this.jtoken_1["delivery"]["state"]),
					Class43.smethod_1((string)this.jtoken_1["delivery"]["country"], (string)this.jtoken_1["delivery"]["state"]),
					(string)this.jtoken_1["delivery"]["zip"],
					(string)this.jtoken_1["payment"]["phone"],
					Class43.smethod_0((string)this.jtoken_1["delivery"]["country"], false),
					this.string_13,
					this.string_15,
					this.string_14
				});
				dictionary["requestKey"] = this.string_10;
				dictionary["hbg"] = this.string_11;
				dictionary["addressBookEnabled"] = "true";
				dictionary["billAddressType"] = "new";
				dictionary["billAddressInputType"] = "single";
				dictionary["billCountry"] = Class43.smethod_0((string)this.jtoken_1["billing"]["country"], false);
				dictionary["billMyAddressBookIndex"] = "-1";
				dictionary["billFirstName"] = (string)this.jtoken_1["billing"]["first_name"];
				dictionary["billLastName"] = (string)this.jtoken_1["billing"]["last_name"];
				dictionary["billAddress1"] = (string)this.jtoken_1["billing"]["addr1"];
				dictionary["billAddress2"] = (string)this.jtoken_1["billing"]["addr2"];
				dictionary["billPostalCode"] = (string)this.jtoken_1["billing"]["zip"];
				dictionary["billCity"] = (string)this.jtoken_1["billing"]["city"];
				dictionary["billState"] = Class43.smethod_1((string)this.jtoken_1["billing"]["country"], (string)this.jtoken_1["billing"]["state"]);
				dictionary["billProvince"] = Class43.smethod_1((string)this.jtoken_1["billing"]["country"], (string)this.jtoken_1["billing"]["state"]);
				dictionary["billHomePhone"] = (string)this.jtoken_1["payment"]["phone"];
				dictionary["billEmailAddress"] = (string)this.jtoken_1["payment"]["email"];
				dictionary["billConfirmEmail"] = (string)this.jtoken_1["payment"]["email"];
				dictionary["shipAddressType"] = "different";
				dictionary["shipAddressInputType"] = "single";
				dictionary["shipCountry"] = Class43.smethod_0((string)this.jtoken_1["delivery"]["country"], false);
				dictionary["shipMyAddressBookIndex"] = "-2";
				dictionary["shipToStore"] = "false";
				dictionary["shipFirstName"] = (string)this.jtoken_1["delivery"]["first_name"];
				dictionary["shipLastName"] = (string)this.jtoken_1["delivery"]["last_name"];
				dictionary["shipAddress1"] = (string)this.jtoken_1["delivery"]["addr1"];
				dictionary["shipAddress2"] = (string)this.jtoken_1["delivery"]["addr2"];
				dictionary["shipPostalCode"] = (string)this.jtoken_1["delivery"]["zip"];
				dictionary["shipCity"] = (string)this.jtoken_1["delivery"]["city"];
				dictionary["shipState"] = Class43.smethod_1((string)this.jtoken_1["delivery"]["country"], (string)this.jtoken_1["delivery"]["state"]);
				dictionary["shipProvince"] = Class43.smethod_1((string)this.jtoken_1["delivery"]["country"], (string)this.jtoken_1["delivery"]["state"]);
				dictionary["shipHomePhone"] = (string)this.jtoken_1["payment"]["phone"];
				dictionary["shipMethodCode"] = this.string_15;
				HttpResponseMessage httpResponseMessage = await this.class14_0.method_3(string.Format("https://www.{0}/checkout/eventGateway?method=validateShipMethodPane", this.string_9), dictionary, false);
				TaskAwaiter<bool> taskAwaiter = this.method_17(httpResponseMessage).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter<bool> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<bool>);
				}
				if (taskAwaiter.GetResult())
				{
					continue;
				}
				httpResponseMessage.EnsureSuccessStatusCode();
				string text = await httpResponseMessage.smethod_3();
				JObject jobject = JObject.Parse(text.Substring(2, text.Length - 2));
				if (jobject["RESPONSEERROR"].ToString() != "False")
				{
					throw new Exception();
				}
				this.string_10 = jobject["REQUESTKEY"].ToString();
				this.string_11 = jobject["hbg"].ToString();
				this.string_12 = jobject["PAYMENTMETHODPANE"]["LGR"].ToString();
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error submitting delivery", "#c2c2c2", true, false);
				TaskAwaiter taskAwaiter3 = base.method_14(Class130.int_1).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter);
				}
				taskAwaiter3.GetResult();
			}
		}
	}

	// Token: 0x060004C7 RID: 1223 RVA: 0x00023454 File Offset: 0x00021654
	public async Task method_26()
	{
		this.cookieCollection_0 = this.class14_0.cookieContainer_0.GetCookies(new Uri(string.Format("https://www.{0}", this.string_9)));
		for (;;)
		{
			int num = 0;
			try
			{
				base.method_5("Submitting payment", "#c2c2c2", true, false);
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary["verifiedCheckoutData"] = string.Concat(new string[]
				{
					string.Format("{{\"maxVisitedPane\":\"promoCodePane\",\"updateBillingForBML\":false,\"billMyAddressBookIndex\":\"-1\",\"addressNeedsVerification\":false,\"billFirstName\":\"{0}\",\"billLastName\":\"{1}\",", (string)this.jtoken_1["billing"]["first_name"], (string)this.jtoken_1["billing"]["last_name"]),
					string.Format("\"billAddress1\":\"{0}\",\"billAddress2\":\"{1}\",\"billCity\":\"{2}\",\"billState\":\"{3}\",\"billProvince\":\"{4}\",\"billPostalCode\":\"{5}\",\"billHomePhone\":\"{6}\",\"billMobilePhone\":\"\",\"billCountry\":\"{7}\",", new object[]
					{
						(string)this.jtoken_1["billing"]["addr1"],
						(string)this.jtoken_1["billing"]["addr2"],
						(string)this.jtoken_1["billing"]["city"],
						Class43.smethod_1((string)this.jtoken_1["billing"]["country"], (string)this.jtoken_1["billing"]["state"]),
						Class43.smethod_1((string)this.jtoken_1["billing"]["country"], (string)this.jtoken_1["billing"]["state"]),
						(string)this.jtoken_1["billing"]["zip"],
						(string)this.jtoken_1["payment"]["phone"],
						Class43.smethod_0((string)this.jtoken_1["billing"]["country"], false)
					}),
					string.Format("\"billEmailAddress\":\"{0}\",\"billConfirmEmail\":\"{1}\",\"billAddrIsPhysical\":true,\"billSubscribePhone\":false,\"billAbbreviatedAddress\":false,\"shipUpdateDefaultAddress\":false,\"VIPNumber\":\"\",", (string)this.jtoken_1["payment"]["email"], (string)this.jtoken_1["payment"]["email"]),
					string.Format("\"accountBillAddress\":{{\"billMyAddressBookIndex\":-1}},\"selectedBillAddress\":{{}},\"billMyAddressBook\":[],\"shipMyAddressBookIndex\":-2,\"shipContactID\":\"\",\"shipFirstName\":\"{0}\",\"shipLastName\":\"{1}\",\"shipAddress1\":\"{2}\",", (string)this.jtoken_1["delivery"]["first_name"], (string)this.jtoken_1["delivery"]["last_name"], (string)this.jtoken_1["delivery"]["addr1"]),
					string.Format("\"shipAddress2\":\"{0}\",\"shipCity\":\"{1}\",\"shipState\":\"{2}\",\"shipProvince\":\"{3}\",\"shipPostalCode\":\"{4}\",\"shipHomePhone\":\"{5}\",\"shipMobilePhone\":\"\",\"shipCountry\":\"{6}\",\"shipToStore\":false,", new object[]
					{
						(string)this.jtoken_1["delivery"]["addr2"],
						(string)this.jtoken_1["delivery"]["city"],
						Class43.smethod_1((string)this.jtoken_1["delivery"]["country"], (string)this.jtoken_1["delivery"]["state"]),
						Class43.smethod_1((string)this.jtoken_1["delivery"]["country"], (string)this.jtoken_1["delivery"]["state"]),
						(string)this.jtoken_1["delivery"]["zip"],
						(string)this.jtoken_1["payment"]["phone"],
						Class43.smethod_0((string)this.jtoken_1["delivery"]["country"], false)
					}),
					string.Format("\"shipHash\":\"{0}\",\"shipMultiple\":false,\"isShipToStoreEligibleCheckout\":true,\"isMultipleAddressEligible\":false,\"shipAbbreviatedAddress\":false,\"selectedStore\":{{}},", this.string_13),
					string.Format("\"accountShipAddress\":{{\"shipMyAddressBookIndex\":-1}},\"selectedShipAddress\":{{}},\"shipMyAddressBook\":[],\"shipMethodCode\":\"{0}\",\"shipMethodName\":\"{1}\",\"shipMethodPrice\":\"$0.00\",", this.string_15, this.string_14),
					"\"shipDeliveryEstimate\":\"\",\"shipMethodCodeSDD\":\"\",\"shipMethodNameSDD\":\"\",\"shipMethodPriceSDD\":\"$0.00\",\"shipDeliveryEstimateSDD\":\"\",\"shipMethodCodeS2S\":\"\",\"shipMethodNameS2S\":\"\",\"shipMethodPriceS2S\":\"$0.00\",\"shipDeliveryEstimateS2S\":\"\",\"shipMethodCodeSFS\":\"\",\"shipMethodNameSFS\":\"\",\"shipMethodPriceSFS\":\"$0.00\",\"shipDeliveryEstimateSFS\":\"\",\"homeDeliveryPrice\":\"$0.00\",\"overallHomeDeliveryPrice\":\"$0.00\",\"aggregatedDeliveryPrice\":\"FREE\",\"aggregatedDeliveryLabel\":\"\",\"showGiftBoxOption\":true,\"addGiftBox\":false,\"giftBoxPrice\":\"$3.99\",\"useGiftReceipt\":false,\"showGiftOptions\":true,\"loyaltyMessageText\":false,\"showLoyaltyRenewalMessage\":false,\"pickupPersonFirstName\":\"\",\"pickupPersonLastName\":\"\",\"preferredLanguage\":\"\",\"advanceToConfirm\":false,\"payType\":\"NO_PAYMENT_METHOD\",\"payPalToken\":\"\",\"payPalInContext\":true,\"payPalMerchantId\":\"\",\"payPalStage\":\"\",\"payPalPaymentAllowed\":true,\"payMethodPaneExpireMonth\":\"\",\"payMethodPaneExpireYear\":\"\",\"payMethodPaneCardNumber\":\"\",\"payMethodPaneCardType\":\"\",\"payMethodPaneLastFour\":\"\",\"payMethodPanePurchaseOrder\":\"\",\"payMethodPanePurchaseOrderNewCustomer\":\"\",\"payMethodPaneCVV\":\"\",\"creditcardPaymentAllowed\":true,\"billMeLaterStage\":\"\",\"BMLPaymentAllowed\":true,\"displayBMLPromotion\":false,\"POPaymentAllowed\":false,\"promoType\":\"\",\"promoCode\":\"\",\"sourceCode\":\"INETSRC\",\"sourceCodeDescription\":\"\",\"sourceCodeCartDisplayText\":\"\",\"GIFTCARDCODE1\":\"\",\"GIFTCARDPIN1\":\"\",\"GIFTCARDUSED1\":\"\",\"GIFTCARDCODE2\":\"\",\"GIFTCARDPIN2\":\"\",\"GIFTCARDUSED2\":\"\",\"GIFTCARDCODE3\":\"\",\"GIFTCARDPIN3\":\"\",\"GIFTCARDUSED3\":\"\",\"GIFTCARDCODE4\":\"\",\"GIFTCARDPIN4\":\"\",",
					string.Format("\"GIFTCARDUSED4\":\"\",\"GIFTCARDCODE5\":\"\",\"GIFTCARDPIN5\":\"\",\"GIFTCARDUSED5\":\"\",\"rewardBarCode\":\"\",\"giftCardsEmpty\":true,\"sourceCodesEmpty\":true,\"ContingencyQueue\":\"\",\"lgr\":\"{0}\",\"displayEmailOptIn\":false,", this.string_12),
					"\"billSubscribeEmail\":false,\"billReceiveNewsletter\":false,\"billFavoriteTeams\":false,\"paypalEmailAddress\":\"\",\"displaySheerIdIframe\":true,\"displayCmsEntry\":\"\",\"payMethodPaneUserGotStoredCC\":false,\"payMethodPaneHasStoredCC\":false,\"payMethodPaneUsedStoredCC\":false,\"payMethodPaneSavedNewCC\":false,\"selectedCreditCard\":{\"payMethodPaneHasCVV\":true},\"payMethodPaneHasCVV\":true}"
				});
				dictionary["requestKey"] = this.string_10;
				dictionary["hbg"] = this.string_11;
				dictionary["bb_device_id"] = this.string_17;
				dictionary["addressBookEnabled"] = "true";
				dictionary["loginHeaderEmailAddress"] = string.Empty;
				dictionary["loginHeaderPassword"] = string.Empty;
				dictionary["loginPaneNewEmailAddress"] = string.Empty;
				dictionary["loginPaneConfirmNewEmailAddress"] = string.Empty;
				dictionary["loginPaneEmailAddress"] = string.Empty;
				dictionary["loginPanePassword"] = string.Empty;
				dictionary["billAddressType"] = "new";
				dictionary["billAddressInputType"] = "single";
				dictionary["billAPOFPOCountry"] = Class43.smethod_0((string)this.jtoken_1["billing"]["country"], false);
				dictionary["billCountry"] = Class43.smethod_0((string)this.jtoken_1["billing"]["country"], false);
				dictionary["billMyAddressBookIndex"] = "-1";
				dictionary["billFirstName"] = (string)this.jtoken_1["billing"]["first_name"];
				dictionary["billLastName"] = (string)this.jtoken_1["billing"]["last_name"];
				dictionary["billAddress1"] = (string)this.jtoken_1["billing"]["addr1"];
				dictionary["billAddress2"] = (string)this.jtoken_1["billing"]["addr2"];
				dictionary["billPostalCode"] = (string)this.jtoken_1["billing"]["zip"];
				dictionary["billCity"] = (string)this.jtoken_1["billing"]["city"];
				dictionary["billAPOFPORegion"] = string.Empty;
				dictionary["billState"] = Class43.smethod_1((string)this.jtoken_1["billing"]["country"], (string)this.jtoken_1["billing"]["state"]);
				dictionary["billProvince"] = string.Empty;
				dictionary["billAPOFPOState"] = string.Empty;
				dictionary["billAPOFPOPostalCode"] = string.Empty;
				dictionary["billHomePhone"] = (string)this.jtoken_1["payment"]["phone"];
				dictionary["billEmailAddress"] = (string)this.jtoken_1["payment"]["email"];
				dictionary["billConfirmEmail"] = (string)this.jtoken_1["payment"]["email"];
				dictionary["shipAddressType"] = "new";
				dictionary["shipAddressInputType"] = "single";
				dictionary["shipAPOFPOCountry"] = Class43.smethod_0((string)this.jtoken_1["delivery"]["country"], false);
				dictionary["shipCountry"] = Class43.smethod_0((string)this.jtoken_1["delivery"]["country"], false);
				dictionary["shipMyAddressBookIndex"] = "-1";
				dictionary["shipToStore"] = "false";
				dictionary["shipFirstName"] = (string)this.jtoken_1["delivery"]["first_name"];
				dictionary["shipLastName"] = (string)this.jtoken_1["delivery"]["last_name"];
				dictionary["shipAddress1"] = (string)this.jtoken_1["delivery"]["addr1"];
				dictionary["shipAddress2"] = (string)this.jtoken_1["delivery"]["addr2"];
				dictionary["shipPostalCode"] = (string)this.jtoken_1["delivery"]["zip"];
				dictionary["shipCity"] = (string)this.jtoken_1["delivery"]["city"];
				dictionary["shipAPOFPORegion"] = string.Empty;
				dictionary["shipState"] = Class43.smethod_1((string)this.jtoken_1["delivery"]["country"], (string)this.jtoken_1["delivery"]["state"]);
				dictionary["shipProvince"] = string.Empty;
				dictionary["shipAPOFPOState"] = string.Empty;
				dictionary["shipAPOFPOPostalCode"] = string.Empty;
				dictionary["shipHomePhone"] = (string)this.jtoken_1["payment"]["phone"];
				dictionary["shipMethodCodeS2S"] = string.Empty;
				dictionary["shipMethodCode"] = this.string_15;
				dictionary["storePickupInputPostalCode"] = string.Empty;
				dictionary["promoType"] = string.Empty;
				dictionary["CPCOrSourceCode"] = string.Empty;
				dictionary["payMethodPanePayType"] = "CC";
				dictionary["payMethodPanestoredCCCardNumber"] = "CC";
				dictionary["CardNumber"] = ((string)this.jtoken_1["payment"]["card"]["number"]).Replace(" ", string.Empty);
				dictionary["CardExpireDateMM"] = (string)this.jtoken_1["payment"]["card"]["exp_month"];
				dictionary["CardExpireDateYY"] = (string)this.jtoken_1["payment"]["card"]["exp_year"];
				dictionary["CardCCV"] = (string)this.jtoken_1["payment"]["card"]["cvv"];
				dictionary["payMethodPaneStoredType"] = string.Empty;
				dictionary["payMethodPaneConfirmCardNumber"] = string.Empty;
				dictionary["payMethodPaneStoredCCExpireMonth"] = string.Empty;
				dictionary["payMethodPaneStoredCCExpireYear"] = string.Empty;
				dictionary["payMethodPaneCardType"] = this.method_16(((string)this.jtoken_1["payment"]["card"]["number"]).Replace(" ", string.Empty));
				dictionary["payMethodPaneCardNumber"] = ((string)this.jtoken_1["payment"]["card"]["number"]).Replace(" ", string.Empty);
				dictionary["payMethodPaneExpireMonth"] = (string)this.jtoken_1["payment"]["card"]["exp_month"];
				dictionary["payMethodPaneExpireYear"] = this.jtoken_1["payment"]["card"]["exp_year"].ToString()[2].ToString() + this.jtoken_1["payment"]["card"]["exp_year"].ToString()[3].ToString();
				dictionary["payMethodPaneCVV"] = (string)this.jtoken_1["payment"]["card"]["cvv"];
				dictionary["payMethodPaneStoredCCCVV"] = string.Empty;
				dictionary["shipProvince"] = Class43.smethod_1((string)this.jtoken_1["delivery"]["country"], (string)this.jtoken_1["delivery"]["state"]);
				dictionary["billProvince"] = Class43.smethod_1((string)this.jtoken_1["billing"]["country"], (string)this.jtoken_1["billing"]["state"]);
				HttpResponseMessage httpResponseMessage = await this.class14_0.method_3(string.Format("https://www.{0}/checkout/eventGateway?method=validatePaymentMethodPane", this.string_9), dictionary, false);
				TaskAwaiter<bool> taskAwaiter = this.method_17(httpResponseMessage).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter<bool> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<bool>);
				}
				if (taskAwaiter.GetResult())
				{
					continue;
				}
				httpResponseMessage.EnsureSuccessStatusCode();
				string text = await httpResponseMessage.smethod_3();
				JObject jobject = JObject.Parse(text.Substring(2, text.Length - 2));
				if (jobject["RESPONSEERROR"].ToString() != "False")
				{
					throw new Exception();
				}
				this.string_10 = jobject["REQUESTKEY"].ToString();
				this.string_11 = jobject["hbg"].ToString();
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error submitting payment, retrying", "#c2c2c2", true, false);
				TaskAwaiter taskAwaiter3 = base.method_14(Class130.int_1).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter);
				}
				taskAwaiter3.GetResult();
			}
		}
	}

	// Token: 0x060004C8 RID: 1224 RVA: 0x0002349C File Offset: 0x0002169C
	public async Task method_27()
	{
		this.cookieCollection_0 = this.class14_0.cookieContainer_0.GetCookies(new Uri(string.Format("https://www.{0}", this.string_9)));
		for (;;)
		{
			int num = 0;
			try
			{
				base.method_5("Submitting order", "orange", true, false);
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary["verifiedCheckoutData"] = string.Concat(new string[]
				{
					string.Format("{{\"maxVisitedPane\":\"orderReviewPane\",\"updateBillingForBML\":false,\"billMyAddressBookIndex\":\"-1\",\"addressNeedsVerification\":false,\"billFirstName\":\"{0}\",\"billLastName\":\"{1}\",", (string)this.jtoken_1["billing"]["first_name"], (string)this.jtoken_1["billing"]["last_name"]),
					string.Format("\"billAddress1\":\"{0}\",\"billAddress2\":\"{1}\",\"billCity\":\"{2}\",\"billState\":\"{3}\",\"billProvince\":\"{4}\",\"billPostalCode\":\"{5}\",\"billHomePhone\":\"{6}\",\"billMobilePhone\":\"\",\"billCountry\":\"{7}\",", new object[]
					{
						(string)this.jtoken_1["billing"]["addr1"],
						(string)this.jtoken_1["billing"]["addr2"],
						(string)this.jtoken_1["billing"]["city"],
						Class43.smethod_1((string)this.jtoken_1["billing"]["country"], (string)this.jtoken_1["billing"]["state"]),
						Class43.smethod_1((string)this.jtoken_1["billing"]["country"], (string)this.jtoken_1["billing"]["state"]),
						(string)this.jtoken_1["billing"]["zip"],
						(string)this.jtoken_1["payment"]["phone"],
						Class43.smethod_0((string)this.jtoken_1["billing"]["country"], false)
					}),
					string.Format("\"billEmailAddress\":\"{0}\",\"billConfirmEmail\":\"{1}\",\"billAddrIsPhysical\":true,\"billSubscribePhone\":false,\"billAbbreviatedAddress\":false,\"shipUpdateDefaultAddress\":false,\"VIPNumber\":\"\",", (string)this.jtoken_1["payment"]["email"], (string)this.jtoken_1["payment"]["email"]),
					string.Format("\"accountBillAddress\":{{\"billMyAddressBookIndex\":-1}},\"selectedBillAddress\":{{}},\"billMyAddressBook\":[],\"shipMyAddressBookIndex\":-2,\"shipContactID\":\"\",\"shipFirstName\":\"{0}\",\"shipLastName\":\"{1}\",\"shipAddress1\":\"{2}\",", (string)this.jtoken_1["delivery"]["first_name"], (string)this.jtoken_1["delivery"]["last_name"], (string)this.jtoken_1["delivery"]["addr1"]),
					string.Format("\"shipAddress2\":\"{0}\",\"shipCity\":\"{1}\",\"shipState\":\"{2}\",\"shipProvince\":\"{3}\",\"shipPostalCode\":\"{4}\",\"shipHomePhone\":\"{5}\",\"shipMobilePhone\":\"\",\"shipCountry\":\"{6}\",\"shipToStore\":false,", new object[]
					{
						(string)this.jtoken_1["delivery"]["addr2"],
						(string)this.jtoken_1["delivery"]["city"],
						Class43.smethod_1((string)this.jtoken_1["delivery"]["country"], (string)this.jtoken_1["delivery"]["state"]),
						Class43.smethod_1((string)this.jtoken_1["delivery"]["country"], (string)this.jtoken_1["delivery"]["state"]),
						(string)this.jtoken_1["delivery"]["zip"],
						(string)this.jtoken_1["payment"]["phone"],
						Class43.smethod_0((string)this.jtoken_1["delivery"]["country"], false)
					}),
					string.Format("\"shipHash\":\"{0}\",\"shipMultiple\":false,\"isShipToStoreEligibleCheckout\":true,\"isMultipleAddressEligible\":false,\"shipAbbreviatedAddress\":false,\"selectedStore\":{{}},", this.string_13),
					string.Format("\"accountShipAddress\":{{\"shipMyAddressBookIndex\":-1}},\"selectedShipAddress\":{{}},\"shipMyAddressBook\":[],\"shipMethodCode\":\"{0}\",\"shipMethodName\":\"{1}\",\"shipMethodPrice\":\"$0.00\",\"shipDeliveryEstimate\":\"\",", this.string_15, this.string_14),
					"\"shipMethodCodeSDD\":\"\",\"shipMethodNameSDD\":\"\",\"shipMethodPriceSDD\":\"$0.00\",\"shipDeliveryEstimateSDD\":\"\",\"shipMethodCodeS2S\":\"\",\"shipMethodNameS2S\":\"\",\"shipMethodPriceS2S\":\"$0.00\",\"shipDeliveryEstimateS2S\":\"\",\"shipMethodCodeSFS\":\"\",\"shipMethodNameSFS\":\"\",\"shipMethodPriceSFS\":\"$0.00\",\"shipDeliveryEstimateSFS\":\"\",\"homeDeliveryPrice\":\"$0.00\",\"overallHomeDeliveryPrice\":\"$0.00\",\"aggregatedDeliveryPrice\":\"FREE\",\"aggregatedDeliveryLabel\":\"\",\"showGiftBoxOption\":true,\"addGiftBox\":false,\"giftBoxPrice\":\"$3.99\",\"useGiftReceipt\":false,\"showGiftOptions\":true,\"loyaltyMessageText\":false,\"showLoyaltyRenewalMessage\":false,\"pickupPersonFirstName\":\"\",\"pickupPersonLastName\":\"\",\"preferredLanguage\":\"\",\"advanceToConfirm\":false,\"payType\":\"CREDIT_CARD\",\"payPalToken\":\"\",\"payPalInContext\":true,\"payPalMerchantId\":\"\",",
					string.Format("\"payPalStage\":\"\",\"payPalPaymentAllowed\":true,\"payMethodPaneExpireMonth\":{0},\"payMethodPaneExpireYear\":{1},\"payMethodPaneCardNumber\":\"{2}\",\"payMethodPaneCardType\":\"{3}\",\"payMethodPaneLastFour\":\"1111\",", new object[]
					{
						(string)this.jtoken_1["payment"]["card"]["exp_month"],
						this.jtoken_1["payment"]["card"]["exp_year"].ToString()[2].ToString() + this.jtoken_1["payment"]["card"]["exp_year"].ToString()[3].ToString(),
						((string)this.jtoken_1["payment"]["card"]["number"]).Replace(" ", string.Empty),
						this.method_16(((string)this.jtoken_1["payment"]["card"]["number"]).Replace(" ", string.Empty))
					}),
					string.Format("\"payMethodPanePayMethodName\":\"Visa\",\"payMethodPanePurchaseOrder\":\"\",\"payMethodPanePurchaseOrderNewCustomer\":\"\",\"payMethodPaneCVV\":\"{0}\",\"creditcardPaymentAllowed\":true,\"billMeLaterStage\":\"\",", (string)this.jtoken_1["payment"]["card"]["cvv"]),
					"\"BMLPaymentAllowed\":true,\"displayBMLPromotion\":false,\"POPaymentAllowed\":false,\"promoType\":\"\",\"promoCode\":\"\",\"sourceCode\":\"INETSRC\",\"sourceCodeDescription\":\"\",\"sourceCodeCartDisplayText\":\"\",\"GIFTCARDCODE1\":\"\",\"GIFTCARDPIN1\":\"\",\"GIFTCARDUSED1\":\"\",\"GIFTCARDCODE2\":\"\",\"GIFTCARDPIN2\":\"\",\"GIFTCARDUSED2\":\"\",\"GIFTCARDCODE3\":\"\",\"GIFTCARDPIN3\":\"\",\"GIFTCARDUSED3\":\"\",\"GIFTCARDCODE4\":\"\",\"GIFTCARDPIN4\":\"\",\"GIFTCARDUSED4\":\"\",\"GIFTCARDCODE5\":\"\",\"GIFTCARDPIN5\":\"\",\"GIFTCARDUSED5\":\"\",\"rewardBarCode\":\"\",\"giftCardsEmpty\":true,\"sourceCodesEmpty\":true,\"emptyCart\":false,\"ContingencyQueue\":\"\",",
					string.Format("\"lgr\":\"{0}\",\"displayEmailOptIn\":false,\"billSubscribeEmail\":false,\"billReceiveNewsletter\":false,\"billFavoriteTeams\":false,\"paypalEmailAddress\":\"\",\"displaySheerIdIframe\":true,\"displayCmsEntry\":\"\",", this.string_12),
					"\"payMethodPaneUserGotStoredCC\":false,\"payMethodPaneHasStoredCC\":false,\"payMethodPaneUsedStoredCC\":false,\"payMethodPaneSavedNewCC\":false,\"selectedCreditCard\":{},\"payMethodPaneHasCVV\":true,\"payMethodPaneCVVAF\":\"0\"}"
				});
				dictionary["requestKey"] = this.string_10;
				dictionary["hbg"] = this.string_11;
				dictionary["bb_device_id"] = Class47.smethod_0(16);
				dictionary["requestKey"] = this.string_10;
				dictionary["hbg"] = this.string_11;
				dictionary["bb_device_id"] = this.string_17;
				dictionary["addressBookEnabled"] = "true";
				dictionary["loginHeaderEmailAddress"] = string.Empty;
				dictionary["loginHeaderPassword"] = string.Empty;
				dictionary["loginPaneNewEmailAddress"] = string.Empty;
				dictionary["loginPaneConfirmNewEmailAddress"] = string.Empty;
				dictionary["loginPaneEmailAddress"] = string.Empty;
				dictionary["loginPanePassword"] = string.Empty;
				dictionary["billAddressType"] = "new";
				dictionary["billAddressInputType"] = "single";
				dictionary["billAPOFPOCountry"] = Class43.smethod_0((string)this.jtoken_1["billing"]["country"], false);
				dictionary["billCountry"] = Class43.smethod_0((string)this.jtoken_1["billing"]["country"], false);
				dictionary["billMyAddressBookIndex"] = "-1";
				dictionary["billFirstName"] = (string)this.jtoken_1["billing"]["first_name"];
				dictionary["billLastName"] = (string)this.jtoken_1["billing"]["last_name"];
				dictionary["billAddress1"] = (string)this.jtoken_1["billing"]["addr1"];
				dictionary["billAddress2"] = (string)this.jtoken_1["billing"]["addr2"];
				dictionary["billPostalCode"] = (string)this.jtoken_1["billing"]["zip"];
				dictionary["billCity"] = (string)this.jtoken_1["billing"]["city"];
				dictionary["billAPOFPORegion"] = string.Empty;
				dictionary["billState"] = Class43.smethod_1((string)this.jtoken_1["billing"]["country"], (string)this.jtoken_1["billing"]["state"]);
				dictionary["billProvince"] = string.Empty;
				dictionary["billAPOFPOState"] = string.Empty;
				dictionary["billAPOFPOPostalCode"] = string.Empty;
				dictionary["billHomePhone"] = (string)this.jtoken_1["payment"]["phone"];
				dictionary["billEmailAddress"] = (string)this.jtoken_1["payment"]["email"];
				dictionary["billConfirmEmail"] = (string)this.jtoken_1["payment"]["email"];
				dictionary["shipAddressType"] = "new";
				dictionary["shipAddressInputType"] = "single";
				dictionary["shipAPOFPOCountry"] = Class43.smethod_0((string)this.jtoken_1["delivery"]["country"], false);
				dictionary["shipCountry"] = Class43.smethod_0((string)this.jtoken_1["delivery"]["country"], false);
				dictionary["shipMyAddressBookIndex"] = "-1";
				dictionary["shipToStore"] = "false";
				dictionary["shipFirstName"] = (string)this.jtoken_1["delivery"]["first_name"];
				dictionary["shipLastName"] = (string)this.jtoken_1["delivery"]["last_name"];
				dictionary["shipAddress1"] = (string)this.jtoken_1["delivery"]["addr1"];
				dictionary["shipAddress2"] = (string)this.jtoken_1["delivery"]["addr2"];
				dictionary["shipPostalCode"] = (string)this.jtoken_1["delivery"]["zip"];
				dictionary["shipCity"] = (string)this.jtoken_1["delivery"]["city"];
				dictionary["shipAPOFPORegion"] = string.Empty;
				dictionary["shipState"] = Class43.smethod_1((string)this.jtoken_1["delivery"]["country"], (string)this.jtoken_1["delivery"]["state"]);
				dictionary["shipProvince"] = string.Empty;
				dictionary["shipAPOFPOState"] = string.Empty;
				dictionary["shipAPOFPOPostalCode"] = string.Empty;
				dictionary["shipHomePhone"] = (string)this.jtoken_1["payment"]["phone"];
				dictionary["shipMethodCodeS2S"] = string.Empty;
				dictionary["shipMethodCode"] = this.string_15;
				dictionary["storePickupInputPostalCode"] = string.Empty;
				dictionary["promoType"] = string.Empty;
				dictionary["CPCOrSourceCode"] = string.Empty;
				dictionary["payMethodPanePayType"] = "CC";
				dictionary["payMethodPanestoredCCCardNumber"] = "CC";
				dictionary["CardNumber"] = ((string)this.jtoken_1["payment"]["card"]["number"]).Replace(" ", string.Empty);
				dictionary["CardExpireDateMM"] = (string)this.jtoken_1["payment"]["card"]["exp_month"];
				dictionary["CardExpireDateYY"] = (string)this.jtoken_1["payment"]["card"]["exp_year"];
				dictionary["CardCCV"] = (string)this.jtoken_1["payment"]["card"]["cvv"];
				dictionary["payMethodPaneStoredType"] = string.Empty;
				dictionary["payMethodPaneConfirmCardNumber"] = string.Empty;
				dictionary["payMethodPaneStoredCCExpireMonth"] = string.Empty;
				dictionary["payMethodPaneStoredCCExpireYear"] = string.Empty;
				dictionary["payMethodPaneCardType"] = this.method_16(((string)this.jtoken_1["payment"]["card"]["number"]).Replace(" ", string.Empty));
				dictionary["payMethodPaneCardNumber"] = ((string)this.jtoken_1["payment"]["card"]["number"]).Replace(" ", string.Empty);
				dictionary["payMethodPaneExpireMonth"] = (string)this.jtoken_1["payment"]["card"]["exp_month"];
				dictionary["payMethodPaneExpireYear"] = this.jtoken_1["payment"]["card"]["exp_year"].ToString()[2].ToString() + this.jtoken_1["payment"]["card"]["exp_year"].ToString()[3].ToString();
				dictionary["payMethodPaneCVV"] = (string)this.jtoken_1["payment"]["card"]["cvv"];
				dictionary["payMethodPaneStoredCCCVV"] = string.Empty;
				dictionary["shipProvince"] = Class43.smethod_1((string)this.jtoken_1["delivery"]["country"], (string)this.jtoken_1["delivery"]["state"]);
				dictionary["billProvince"] = Class43.smethod_1((string)this.jtoken_1["billing"]["country"], (string)this.jtoken_1["billing"]["state"]);
				HttpResponseMessage httpResponseMessage = await this.class14_0.method_3(string.Format("https://www.{0}/checkout/eventGateway?method=validateReviewPane", this.string_9), dictionary, false);
				TaskAwaiter<bool> taskAwaiter = this.method_17(httpResponseMessage).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter<bool> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<bool>);
				}
				if (taskAwaiter.GetResult())
				{
					continue;
				}
				httpResponseMessage.EnsureSuccessStatusCode();
				string text = await httpResponseMessage.smethod_3();
				JObject jobject = JObject.Parse(text.Substring(2, text.Length - 2));
				if (!text.Contains("order.credit.auth.error"))
				{
					if (text.Contains("order.ledger.synchronization.error"))
					{
						base.method_0("Payment error", "red", true, (GEnum1)0);
					}
					else if ((bool)jobject["ORDERREVIEWPANE"]["ORDERSUBMITTED"])
					{
						base.method_0("Successfully checked out", "green", true, (GEnum1)6);
					}
					throw new Exception();
				}
				base.method_0("Card Declined", "red", true, (GEnum1)5);
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error submitting order", "#c2c2c2", true, false);
				TaskAwaiter taskAwaiter3 = base.method_14(Class130.int_1).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter);
				}
				taskAwaiter3.GetResult();
			}
		}
	}

	// Token: 0x040002F5 RID: 757
	private int int_0;

	// Token: 0x040002F6 RID: 758
	private string string_7;

	// Token: 0x040002F7 RID: 759
	private string string_8;

	// Token: 0x040002F8 RID: 760
	private string string_9;

	// Token: 0x040002F9 RID: 761
	private string string_10;

	// Token: 0x040002FA RID: 762
	private string string_11;

	// Token: 0x040002FB RID: 763
	private string string_12;

	// Token: 0x040002FC RID: 764
	private string string_13;

	// Token: 0x040002FD RID: 765
	private string string_14;

	// Token: 0x040002FE RID: 766
	private string string_15;

	// Token: 0x040002FF RID: 767
	private string string_16;

	// Token: 0x04000300 RID: 768
	private string string_17;

	// Token: 0x04000301 RID: 769
	private CookieCollection cookieCollection_0;

	// Token: 0x020000C3 RID: 195
	[Serializable]
	private sealed class Class122
	{
		// Token: 0x060004CB RID: 1227 RVA: 0x00004ADF File Offset: 0x00002CDF
		internal char method_0(string string_0)
		{
			return string_0[MainWindow.random_0.Next(string_0.Length)];
		}

		// Token: 0x04000302 RID: 770
		public static readonly Class47.Class122 class122_0 = new Class47.Class122();

		// Token: 0x04000303 RID: 771
		public static Func<string, char> func_0;
	}

	// Token: 0x020000C4 RID: 196
	[StructLayout(LayoutKind.Auto)]
	private struct Struct53 : IAsyncStateMachine
	{
		// Token: 0x060004CC RID: 1228 RVA: 0x000234E4 File Offset: 0x000216E4
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class47 @class = this;
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
					goto IL_DF;
				}
				case 2:
				{
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					num2 = -1;
					goto IL_13A;
				}
				case 3:
				{
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					num2 = -1;
					goto IL_195;
				}
				case 4:
				{
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					num2 = -1;
					goto IL_1F0;
				}
				case 5:
				{
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					num2 = -1;
					goto IL_24B;
				}
				case 6:
				{
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					num2 = -1;
					goto IL_2A3;
				}
				default:
					taskAwaiter = @class.method_21().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 0;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class47.Struct53>(ref taskAwaiter, ref this);
						return;
					}
					break;
				}
				taskAwaiter.GetResult();
				taskAwaiter = @class.method_22().GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					num2 = 1;
					TaskAwaiter taskAwaiter2 = taskAwaiter;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class47.Struct53>(ref taskAwaiter, ref this);
					return;
				}
				IL_DF:
				taskAwaiter.GetResult();
				taskAwaiter = @class.method_23().GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					num2 = 2;
					TaskAwaiter taskAwaiter2 = taskAwaiter;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class47.Struct53>(ref taskAwaiter, ref this);
					return;
				}
				IL_13A:
				taskAwaiter.GetResult();
				taskAwaiter = @class.method_24().GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					num2 = 3;
					TaskAwaiter taskAwaiter2 = taskAwaiter;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class47.Struct53>(ref taskAwaiter, ref this);
					return;
				}
				IL_195:
				taskAwaiter.GetResult();
				taskAwaiter = @class.method_25().GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					num2 = 4;
					TaskAwaiter taskAwaiter2 = taskAwaiter;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class47.Struct53>(ref taskAwaiter, ref this);
					return;
				}
				IL_1F0:
				taskAwaiter.GetResult();
				taskAwaiter = @class.method_26().GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					num2 = 5;
					TaskAwaiter taskAwaiter2 = taskAwaiter;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class47.Struct53>(ref taskAwaiter, ref this);
					return;
				}
				IL_24B:
				taskAwaiter.GetResult();
				taskAwaiter = @class.method_27().GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					num2 = 6;
					TaskAwaiter taskAwaiter2 = taskAwaiter;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class47.Struct53>(ref taskAwaiter, ref this);
					return;
				}
				IL_2A3:
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

		// Token: 0x060004CD RID: 1229 RVA: 0x00004EF2 File Offset: 0x000030F2
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000304 RID: 772
		public int int_0;

		// Token: 0x04000305 RID: 773
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000306 RID: 774
		public Class47 class47_0;

		// Token: 0x04000307 RID: 775
		private TaskAwaiter taskAwaiter_0;
	}

	// Token: 0x020000C5 RID: 197
	[StructLayout(LayoutKind.Auto)]
	private struct Struct54 : IAsyncStateMachine
	{
		// Token: 0x060004CE RID: 1230 RVA: 0x000237E4 File Offset: 0x000219E4
		void IAsyncStateMachine.MoveNext()
		{
			int num3;
			int num2 = num3;
			Class47 @class = this;
			try
			{
				TaskAwaiter taskAwaiter9;
				if (num2 > 13)
				{
					if (num2 != 14)
					{
						num = 1;
						@class.method_5("Adding to cart", "#c2c2c2", true, false);
						dictionary = new Dictionary<string, string>();
						dictionary["storeCostOfGoods"] = "0.00";
						dictionary["requestKey"] = @class.string_10;
						dictionary["sku"] = @class.string_8;
						dictionary["qty"] = "1";
						dictionary["size"] = @class.string_0;
						dictionary["quantity"] = "1";
						dictionary["inlineAddToCart"] = "1";
						goto IL_9D9;
					}
					taskAwaiter9 = taskAwaiter8;
					taskAwaiter8 = default(TaskAwaiter);
					int num4 = -1;
					num2 = -1;
					num3 = num4;
					goto IL_9A8;
				}
				IL_FE:
				int num26;
				int num34;
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter10;
					TaskAwaiter<bool> taskAwaiter11;
					TaskAwaiter<string> taskAwaiter12;
					TaskAwaiter<JObject> taskAwaiter14;
					switch (num2)
					{
					case 0:
					{
						taskAwaiter10 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
						int num5 = -1;
						num2 = -1;
						num3 = num5;
						break;
					}
					case 1:
					{
						taskAwaiter11 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<bool>);
						int num6 = -1;
						num2 = -1;
						num3 = num6;
						goto IL_313;
					}
					case 2:
					{
						TaskAwaiter<string> taskAwaiter13;
						taskAwaiter12 = taskAwaiter13;
						taskAwaiter13 = default(TaskAwaiter<string>);
						int num7 = -1;
						num2 = -1;
						num3 = num7;
						goto IL_389;
					}
					case 3:
					{
						taskAwaiter9 = taskAwaiter8;
						taskAwaiter8 = default(TaskAwaiter);
						int num8 = -1;
						num2 = -1;
						num3 = num8;
						goto IL_460;
					}
					case 4:
					{
						taskAwaiter14 = taskAwaiter6;
						taskAwaiter6 = default(TaskAwaiter<JObject>);
						int num9 = -1;
						num2 = -1;
						num3 = num9;
						goto IL_4A1;
					}
					case 5:
					{
						taskAwaiter10 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
						int num10 = -1;
						num2 = -1;
						num3 = num10;
						goto IL_50A;
					}
					case 6:
					{
						taskAwaiter11 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<bool>);
						int num11 = -1;
						num2 = -1;
						num3 = num11;
						goto IL_578;
					}
					case 7:
					{
						TaskAwaiter<string> taskAwaiter13;
						taskAwaiter12 = taskAwaiter13;
						taskAwaiter13 = default(TaskAwaiter<string>);
						int num12 = -1;
						num2 = -1;
						num3 = num12;
						goto IL_5EE;
					}
					case 8:
					{
						taskAwaiter9 = taskAwaiter8;
						taskAwaiter8 = default(TaskAwaiter);
						int num13 = -1;
						num2 = -1;
						num3 = num13;
						goto IL_6C2;
					}
					case 9:
					{
						taskAwaiter14 = taskAwaiter6;
						taskAwaiter6 = default(TaskAwaiter<JObject>);
						int num14 = -1;
						num2 = -1;
						num3 = num14;
						goto IL_703;
					}
					case 10:
					{
						taskAwaiter10 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
						int num15 = -1;
						num2 = -1;
						num3 = num15;
						goto IL_776;
					}
					case 11:
					{
						taskAwaiter11 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<bool>);
						int num16 = -1;
						num2 = -1;
						num3 = num16;
						goto IL_7E6;
					}
					case 12:
					{
						TaskAwaiter<string> taskAwaiter13;
						taskAwaiter12 = taskAwaiter13;
						taskAwaiter13 = default(TaskAwaiter<string>);
						int num17 = -1;
						num2 = -1;
						num3 = num17;
						goto IL_85E;
					}
					case 13:
					{
						taskAwaiter9 = taskAwaiter8;
						taskAwaiter8 = default(TaskAwaiter);
						int num18 = -1;
						num2 = -1;
						num3 = num18;
						goto IL_950;
					}
					default:
						if (num == 1)
						{
							taskAwaiter10 = @class.class14_0.method_3(string.Format("https://www.{0}/index.cfm?uri=add2cart&fragment=true", @class.string_9), dictionary, false).GetAwaiter();
							if (!taskAwaiter10.IsCompleted)
							{
								int num19 = 0;
								num2 = 0;
								num3 = num19;
								taskAwaiter2 = taskAwaiter10;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class47.Struct54>(ref taskAwaiter10, ref this);
								return;
							}
						}
						else if (num == 2)
						{
							taskAwaiter10 = @class.class14_0.method_2(string.Format("https://www.{0}/pdp/gateway?requestKey={1}&action=add&qty=1&quantity=1&sku={2}&size={3}&fulfillmentType=SHIP_TO_HOME&storeNumber=0&_=1509399855629", new object[]
							{
								@class.string_9,
								@class.string_10,
								@class.string_8,
								@class.string_0
							}), false).GetAwaiter();
							if (!taskAwaiter10.IsCompleted)
							{
								int num20 = 5;
								num2 = 5;
								num3 = num20;
								taskAwaiter2 = taskAwaiter10;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class47.Struct54>(ref taskAwaiter10, ref this);
								return;
							}
							goto IL_50A;
						}
						else
						{
							if (num != 3)
							{
								num = 1;
								goto IL_9D9;
							}
							taskAwaiter10 = @class.class14_0.method_3(string.Format("https://www.{0}/catalog/miniAddToCart.cfm", @class.string_9), dictionary, false).GetAwaiter();
							if (!taskAwaiter10.IsCompleted)
							{
								int num21 = 10;
								num2 = 10;
								num3 = num21;
								taskAwaiter2 = taskAwaiter10;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class47.Struct54>(ref taskAwaiter10, ref this);
								return;
							}
							goto IL_776;
						}
						break;
					}
					HttpResponseMessage result2 = taskAwaiter10.GetResult();
					result = result2;
					taskAwaiter11 = @class.method_17(result).GetAwaiter();
					if (!taskAwaiter11.IsCompleted)
					{
						int num22 = 1;
						num2 = 1;
						num3 = num22;
						taskAwaiter4 = taskAwaiter11;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, Class47.Struct54>(ref taskAwaiter11, ref this);
						return;
					}
					IL_313:
					if (taskAwaiter11.GetResult())
					{
						goto IL_9D9;
					}
					result.EnsureSuccessStatusCode();
					taskAwaiter12 = result.smethod_3().GetAwaiter();
					if (!taskAwaiter12.IsCompleted)
					{
						int num23 = 2;
						num2 = 2;
						num3 = num23;
						TaskAwaiter<string> taskAwaiter13 = taskAwaiter12;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class47.Struct54>(ref taskAwaiter12, ref this);
						return;
					}
					IL_389:
					string result3 = taskAwaiter12.GetResult();
					if (!result3.ToLower().Contains("out of stock") && !result3.Contains("Due to high demand"))
					{
						taskAwaiter14 = result.smethod_1().GetAwaiter();
						if (!taskAwaiter14.IsCompleted)
						{
							int num24 = 4;
							num2 = 4;
							num3 = num24;
							taskAwaiter6 = taskAwaiter14;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class47.Struct54>(ref taskAwaiter14, ref this);
							return;
						}
						goto IL_4A1;
					}
					else
					{
						@class.method_5("Waiting for restock", "#c2c2c2", true, false);
						taskAwaiter9 = @class.method_14(Class130.int_0).GetAwaiter();
						if (!taskAwaiter9.IsCompleted)
						{
							int num25 = 3;
							num2 = 3;
							num3 = num25;
							taskAwaiter8 = taskAwaiter9;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class47.Struct54>(ref taskAwaiter9, ref this);
							return;
						}
					}
					IL_460:
					taskAwaiter9.GetResult();
					@class.method_19();
					num26 = num;
					num = num26 + 1;
					goto IL_9D9;
					IL_4A1:
					JObject result4 = taskAwaiter14.GetResult();
					if ((bool)result4["success"])
					{
						@class.string_10 = result4["nextRequestKey"].ToString();
						@class.method_5("Successfully carted", "#c2c2c2", true, false);
						goto IL_A1C;
					}
					goto IL_8DD;
					IL_50A:
					result2 = taskAwaiter10.GetResult();
					result = result2;
					taskAwaiter11 = @class.method_17(result).GetAwaiter();
					if (!taskAwaiter11.IsCompleted)
					{
						int num27 = 6;
						num2 = 6;
						num3 = num27;
						taskAwaiter4 = taskAwaiter11;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, Class47.Struct54>(ref taskAwaiter11, ref this);
						return;
					}
					IL_578:
					if (taskAwaiter11.GetResult())
					{
						goto IL_9D9;
					}
					result.EnsureSuccessStatusCode();
					taskAwaiter12 = result.smethod_3().GetAwaiter();
					if (!taskAwaiter12.IsCompleted)
					{
						int num28 = 7;
						num2 = 7;
						num3 = num28;
						TaskAwaiter<string> taskAwaiter13 = taskAwaiter12;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class47.Struct54>(ref taskAwaiter12, ref this);
						return;
					}
					IL_5EE:
					string result5 = taskAwaiter12.GetResult();
					if (!result5.Contains("Item Out Of Stock") && !result5.Contains("Due to high demand"))
					{
						taskAwaiter14 = result.smethod_1().GetAwaiter();
						if (!taskAwaiter14.IsCompleted)
						{
							int num29 = 9;
							num2 = 9;
							num3 = num29;
							taskAwaiter6 = taskAwaiter14;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class47.Struct54>(ref taskAwaiter14, ref this);
							return;
						}
						goto IL_703;
					}
					else
					{
						@class.method_5("Waiting for restock", "#c2c2c2", true, false);
						taskAwaiter9 = @class.method_14(Class130.int_0).GetAwaiter();
						if (!taskAwaiter9.IsCompleted)
						{
							int num30 = 8;
							num2 = 8;
							num3 = num30;
							taskAwaiter8 = taskAwaiter9;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class47.Struct54>(ref taskAwaiter9, ref this);
							return;
						}
					}
					IL_6C2:
					taskAwaiter9.GetResult();
					@class.method_19();
					num26 = num;
					num = num26 + 1;
					goto IL_9D9;
					IL_703:
					JObject result6 = taskAwaiter14.GetResult();
					if ((bool)result6["success"])
					{
						@class.string_10 = result6["data"]["RequestKey"].ToString();
						@class.method_5("Successfully carted", "#c2c2c2", true, false);
						goto IL_A1C;
					}
					goto IL_8DD;
					IL_776:
					result2 = taskAwaiter10.GetResult();
					result = result2;
					taskAwaiter11 = @class.method_17(result).GetAwaiter();
					if (!taskAwaiter11.IsCompleted)
					{
						int num31 = 11;
						num2 = 11;
						num3 = num31;
						taskAwaiter4 = taskAwaiter11;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, Class47.Struct54>(ref taskAwaiter11, ref this);
						return;
					}
					IL_7E6:
					if (taskAwaiter11.GetResult())
					{
						goto IL_9D9;
					}
					result.EnsureSuccessStatusCode();
					taskAwaiter12 = result.smethod_3().GetAwaiter();
					if (!taskAwaiter12.IsCompleted)
					{
						int num32 = 12;
						num2 = 12;
						num3 = num32;
						TaskAwaiter<string> taskAwaiter13 = taskAwaiter12;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class47.Struct54>(ref taskAwaiter12, ref this);
						return;
					}
					IL_85E:
					string result7 = taskAwaiter12.GetResult();
					if (!result7.ToLower().Contains("out of stock") && !result7.Contains("Due to high demand"))
					{
						if (result7.Contains("1 item in cart"))
						{
							@class.string_10 = result7.Split(new string[]
							{
								"var requestKey =\""
							}, StringSplitOptions.None)[1].Split(new char[]
							{
								'"'
							})[0];
							@class.method_5("Successfully carted", "#c2c2c2", true, false);
							goto IL_A1C;
						}
					}
					else
					{
						@class.method_5("Waiting for restock", "#c2c2c2", true, false);
						taskAwaiter9 = @class.method_14(Class130.int_0).GetAwaiter();
						if (!taskAwaiter9.IsCompleted)
						{
							int num33 = 13;
							num2 = 13;
							num3 = num33;
							taskAwaiter8 = taskAwaiter9;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class47.Struct54>(ref taskAwaiter9, ref this);
							return;
						}
						goto IL_950;
					}
					IL_8DD:
					throw new Exception();
					IL_950:
					taskAwaiter9.GetResult();
					@class.method_19();
					num26 = num;
					num = num26 + 1;
					goto IL_9D9;
				}
				catch
				{
					num34 = 1;
				}
				if (num34 != 1)
				{
					goto IL_9D9;
				}
				@class.method_5("Error adding to cart", "#c2c2c2", true, false);
				taskAwaiter9 = @class.method_14(Class130.int_1).GetAwaiter();
				if (!taskAwaiter9.IsCompleted)
				{
					int num35 = 14;
					num2 = 14;
					num3 = num35;
					taskAwaiter8 = taskAwaiter9;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class47.Struct54>(ref taskAwaiter9, ref this);
					return;
				}
				IL_9A8:
				taskAwaiter9.GetResult();
				@class.method_19();
				num26 = num;
				num = num26 + 1;
				@class.method_5("Adding to cart", "#c2c2c2", true, false);
				IL_9D9:
				num34 = 0;
				goto IL_FE;
			}
			catch (Exception exception)
			{
				num3 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_A1C:
			num3 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060004CF RID: 1231 RVA: 0x00004F00 File Offset: 0x00003100
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000308 RID: 776
		public int int_0;

		// Token: 0x04000309 RID: 777
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x0400030A RID: 778
		public Class47 class47_0;

		// Token: 0x0400030B RID: 779
		private int int_1;

		// Token: 0x0400030C RID: 780
		private Dictionary<string, string> dictionary_0;

		// Token: 0x0400030D RID: 781
		private HttpResponseMessage httpResponseMessage_0;

		// Token: 0x0400030E RID: 782
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x0400030F RID: 783
		private TaskAwaiter<bool> taskAwaiter_1;

		// Token: 0x04000310 RID: 784
		private TaskAwaiter<string> taskAwaiter_2;

		// Token: 0x04000311 RID: 785
		private TaskAwaiter taskAwaiter_3;

		// Token: 0x04000312 RID: 786
		private TaskAwaiter<JObject> taskAwaiter_4;
	}

	// Token: 0x020000C6 RID: 198
	[StructLayout(LayoutKind.Auto)]
	private struct Struct55 : IAsyncStateMachine
	{
		// Token: 0x060004D0 RID: 1232 RVA: 0x00024254 File Offset: 0x00022454
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class47 @class = this;
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
						goto IL_E7;
					}
					case 2:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_153;
					}
					case 3:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_1AE;
					}
					case 4:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_209;
					}
					case 5:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_264;
					}
					case 6:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_2BF;
					}
					case 7:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_31A;
					}
					case 8:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_372;
					}
					default:
						taskAwaiter = @class.method_11().GetAwaiter();
						if (!taskAwaiter.IsCompleted)
						{
							num2 = 0;
							TaskAwaiter taskAwaiter2 = taskAwaiter;
							this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class47.Struct55>(ref taskAwaiter, ref this);
							return;
						}
						break;
					}
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_20().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 1;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class47.Struct55>(ref taskAwaiter, ref this);
						return;
					}
					IL_E7:
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_13(TimeSpan.FromMilliseconds((double)@class.int_0), "Waiting").GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 2;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class47.Struct55>(ref taskAwaiter, ref this);
						return;
					}
					IL_153:
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_21().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 3;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class47.Struct55>(ref taskAwaiter, ref this);
						return;
					}
					IL_1AE:
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_22().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 4;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class47.Struct55>(ref taskAwaiter, ref this);
						return;
					}
					IL_209:
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_23().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 5;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class47.Struct55>(ref taskAwaiter, ref this);
						return;
					}
					IL_264:
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_24().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 6;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class47.Struct55>(ref taskAwaiter, ref this);
						return;
					}
					IL_2BF:
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_25().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 7;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class47.Struct55>(ref taskAwaiter, ref this);
						return;
					}
					IL_31A:
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_27().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 8;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class47.Struct55>(ref taskAwaiter, ref this);
						return;
					}
					IL_372:
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

		// Token: 0x060004D1 RID: 1233 RVA: 0x00004F0E File Offset: 0x0000310E
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000313 RID: 787
		public int int_0;

		// Token: 0x04000314 RID: 788
		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		// Token: 0x04000315 RID: 789
		public Class47 class47_0;

		// Token: 0x04000316 RID: 790
		private TaskAwaiter taskAwaiter_0;
	}

	// Token: 0x020000C7 RID: 199
	[StructLayout(LayoutKind.Auto)]
	private struct Struct56 : IAsyncStateMachine
	{
		// Token: 0x060004D2 RID: 1234 RVA: 0x00024654 File Offset: 0x00022854
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class47 @class = this;
			try
			{
				if (num <= 4)
				{
					goto IL_3BB;
				}
				if (num != 5)
				{
					goto IL_3B1;
				}
				TaskAwaiter taskAwaiter3 = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_3AA:
				taskAwaiter3.GetResult();
				IL_3B1:
				if (@class.bool_1)
				{
					goto IL_3FC;
				}
				int num4 = 0;
				IL_3BB:
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter4;
					TaskAwaiter<JObject> taskAwaiter6;
					switch (num)
					{
					case 0:
					{
						TaskAwaiter<HttpResponseMessage> taskAwaiter5;
						taskAwaiter4 = taskAwaiter5;
						taskAwaiter5 = default(TaskAwaiter<HttpResponseMessage>);
						int num5 = -1;
						num = -1;
						num2 = num5;
						break;
					}
					case 1:
					{
						TaskAwaiter<JObject> taskAwaiter7;
						taskAwaiter6 = taskAwaiter7;
						taskAwaiter7 = default(TaskAwaiter<JObject>);
						int num6 = -1;
						num = -1;
						num2 = num6;
						goto IL_13B;
					}
					case 2:
					{
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num7 = -1;
						num = -1;
						num2 = num7;
						goto IL_1F4;
					}
					case 3:
					{
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num8 = -1;
						num = -1;
						num2 = num8;
						goto IL_302;
					}
					case 4:
					{
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num9 = -1;
						num = -1;
						num2 = num9;
						goto IL_35D;
					}
					default:
						@class.method_5("Checking inventory", "#c2c2c2", true, false);
						taskAwaiter4 = @class.class14_0.method_2(string.Format("https://www.{0}/pdp/gateway?requestKey={1}&action=checkout&_=1521900315214", @class.string_9, @class.string_10), false).GetAwaiter();
						if (!taskAwaiter4.IsCompleted)
						{
							int num10 = 0;
							num = 0;
							num2 = num10;
							TaskAwaiter<HttpResponseMessage> taskAwaiter5 = taskAwaiter4;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class47.Struct56>(ref taskAwaiter4, ref this);
							return;
						}
						break;
					}
					taskAwaiter6 = taskAwaiter4.GetResult().smethod_1().GetAwaiter();
					if (!taskAwaiter6.IsCompleted)
					{
						int num11 = 1;
						num = 1;
						num2 = num11;
						TaskAwaiter<JObject> taskAwaiter7 = taskAwaiter6;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class47.Struct56>(ref taskAwaiter6, ref this);
						return;
					}
					IL_13B:
					JObject result = taskAwaiter6.GetResult();
					jobject = result;
					IL_16F:
					if (Convert.ToInt16(jobject["data"]["queue"]["checkoutTimeSecondsUntil"].ToString()) > 0)
					{
						@class.method_5("In checkout queue", "#c2c2c2", true, false);
						taskAwaiter3 = @class.method_14((int)(Convert.ToInt16(jobject["data"]["checkoutTimeSecondsUntil"].ToString()) * 1000)).GetAwaiter();
						if (!taskAwaiter3.IsCompleted)
						{
							int num12 = 2;
							num = 2;
							num2 = num12;
							taskAwaiter2 = taskAwaiter3;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class47.Struct56>(ref taskAwaiter3, ref this);
							return;
						}
					}
					else if (jobject["data"]["inventory"]["outOfStockLines"].Any<JToken>())
					{
						@class.method_5("Out of stock, restarting", "#c2c2c2", true, false);
						taskAwaiter3 = @class.method_14(Class130.int_1).GetAwaiter();
						if (!taskAwaiter3.IsCompleted)
						{
							int num13 = 3;
							num = 3;
							num2 = num13;
							taskAwaiter2 = taskAwaiter3;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class47.Struct56>(ref taskAwaiter3, ref this);
							return;
						}
						goto IL_302;
					}
					else
					{
						if (object.Equals(false, (bool)jobject["data"]["state"]["inventoryCheckFail"]))
						{
							goto IL_3FC;
						}
						throw new Exception();
					}
					IL_1F4:
					taskAwaiter3.GetResult();
					goto IL_16F;
					IL_302:
					taskAwaiter3.GetResult();
					taskAwaiter3 = @class.method_15().GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						int num14 = 4;
						num = 4;
						num2 = num14;
						taskAwaiter2 = taskAwaiter3;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class47.Struct56>(ref taskAwaiter3, ref this);
						return;
					}
					IL_35D:
					taskAwaiter3.GetResult();
					goto IL_3FC;
				}
				catch (ArgumentException)
				{
					goto IL_3FC;
				}
				catch (FormatException)
				{
					goto IL_3FC;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_3B1;
				}
				@class.method_5("Error checking inventory", "#c2c2c2", true, false);
				taskAwaiter3 = @class.method_14(Class130.int_1).GetAwaiter();
				if (taskAwaiter3.IsCompleted)
				{
					goto IL_3AA;
				}
				int num15 = 5;
				num = 5;
				num2 = num15;
				taskAwaiter2 = taskAwaiter3;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class47.Struct56>(ref taskAwaiter3, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_3FC:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x00004F1C File Offset: 0x0000311C
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000317 RID: 791
		public int int_0;

		// Token: 0x04000318 RID: 792
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000319 RID: 793
		public Class47 class47_0;

		// Token: 0x0400031A RID: 794
		private JObject jobject_0;

		// Token: 0x0400031B RID: 795
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x0400031C RID: 796
		private TaskAwaiter<JObject> taskAwaiter_1;

		// Token: 0x0400031D RID: 797
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x020000C8 RID: 200
	[StructLayout(LayoutKind.Auto)]
	private struct Struct57 : IAsyncStateMachine
	{
		// Token: 0x060004D4 RID: 1236 RVA: 0x00024AD4 File Offset: 0x00022CD4
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class47 @class = this;
			try
			{
				TaskAwaiter taskAwaiter5;
				if (num > 2)
				{
					if (num != 3)
					{
						@class.cookieCollection_0 = @class.class14_0.cookieContainer_0.GetCookies(new Uri(string.Format("https://www.{0}", @class.string_9)));
						goto IL_11CA;
					}
					taskAwaiter5 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter);
					int num3 = -1;
					num = -1;
					num2 = num3;
					goto IL_11C3;
				}
				IL_68:
				int num10;
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter6;
					TaskAwaiter<bool> taskAwaiter8;
					TaskAwaiter<string> taskAwaiter9;
					switch (num)
					{
					case 0:
					{
						TaskAwaiter<HttpResponseMessage> taskAwaiter7;
						taskAwaiter6 = taskAwaiter7;
						taskAwaiter7 = default(TaskAwaiter<HttpResponseMessage>);
						int num4 = -1;
						num = -1;
						num2 = num4;
						break;
					}
					case 1:
					{
						taskAwaiter8 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<bool>);
						int num5 = -1;
						num = -1;
						num2 = num5;
						goto IL_107D;
					}
					case 2:
					{
						TaskAwaiter<string> taskAwaiter10;
						taskAwaiter9 = taskAwaiter10;
						taskAwaiter10 = default(TaskAwaiter<string>);
						int num6 = -1;
						num = -1;
						num2 = num6;
						goto IL_10F3;
					}
					default:
					{
						@class.method_5("Submitting order", "orange", true, false);
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary["verifiedCheckoutData"] = string.Concat(new string[]
						{
							string.Format("{{\"maxVisitedPane\":\"orderReviewPane\",\"updateBillingForBML\":false,\"billMyAddressBookIndex\":\"-1\",\"addressNeedsVerification\":false,\"billFirstName\":\"{0}\",\"billLastName\":\"{1}\",", (string)@class.jtoken_1["billing"]["first_name"], (string)@class.jtoken_1["billing"]["last_name"]),
							string.Format("\"billAddress1\":\"{0}\",\"billAddress2\":\"{1}\",\"billCity\":\"{2}\",\"billState\":\"{3}\",\"billProvince\":\"{4}\",\"billPostalCode\":\"{5}\",\"billHomePhone\":\"{6}\",\"billMobilePhone\":\"\",\"billCountry\":\"{7}\",", new object[]
							{
								(string)@class.jtoken_1["billing"]["addr1"],
								(string)@class.jtoken_1["billing"]["addr2"],
								(string)@class.jtoken_1["billing"]["city"],
								Class43.smethod_1((string)@class.jtoken_1["billing"]["country"], (string)@class.jtoken_1["billing"]["state"]),
								Class43.smethod_1((string)@class.jtoken_1["billing"]["country"], (string)@class.jtoken_1["billing"]["state"]),
								(string)@class.jtoken_1["billing"]["zip"],
								(string)@class.jtoken_1["payment"]["phone"],
								Class43.smethod_0((string)@class.jtoken_1["billing"]["country"], false)
							}),
							string.Format("\"billEmailAddress\":\"{0}\",\"billConfirmEmail\":\"{1}\",\"billAddrIsPhysical\":true,\"billSubscribePhone\":false,\"billAbbreviatedAddress\":false,\"shipUpdateDefaultAddress\":false,\"VIPNumber\":\"\",", (string)@class.jtoken_1["payment"]["email"], (string)@class.jtoken_1["payment"]["email"]),
							string.Format("\"accountBillAddress\":{{\"billMyAddressBookIndex\":-1}},\"selectedBillAddress\":{{}},\"billMyAddressBook\":[],\"shipMyAddressBookIndex\":-2,\"shipContactID\":\"\",\"shipFirstName\":\"{0}\",\"shipLastName\":\"{1}\",\"shipAddress1\":\"{2}\",", (string)@class.jtoken_1["delivery"]["first_name"], (string)@class.jtoken_1["delivery"]["last_name"], (string)@class.jtoken_1["delivery"]["addr1"]),
							string.Format("\"shipAddress2\":\"{0}\",\"shipCity\":\"{1}\",\"shipState\":\"{2}\",\"shipProvince\":\"{3}\",\"shipPostalCode\":\"{4}\",\"shipHomePhone\":\"{5}\",\"shipMobilePhone\":\"\",\"shipCountry\":\"{6}\",\"shipToStore\":false,", new object[]
							{
								(string)@class.jtoken_1["delivery"]["addr2"],
								(string)@class.jtoken_1["delivery"]["city"],
								Class43.smethod_1((string)@class.jtoken_1["delivery"]["country"], (string)@class.jtoken_1["delivery"]["state"]),
								Class43.smethod_1((string)@class.jtoken_1["delivery"]["country"], (string)@class.jtoken_1["delivery"]["state"]),
								(string)@class.jtoken_1["delivery"]["zip"],
								(string)@class.jtoken_1["payment"]["phone"],
								Class43.smethod_0((string)@class.jtoken_1["delivery"]["country"], false)
							}),
							string.Format("\"shipHash\":\"{0}\",\"shipMultiple\":false,\"isShipToStoreEligibleCheckout\":true,\"isMultipleAddressEligible\":false,\"shipAbbreviatedAddress\":false,\"selectedStore\":{{}},", @class.string_13),
							string.Format("\"accountShipAddress\":{{\"shipMyAddressBookIndex\":-1}},\"selectedShipAddress\":{{}},\"shipMyAddressBook\":[],\"shipMethodCode\":\"{0}\",\"shipMethodName\":\"{1}\",\"shipMethodPrice\":\"$0.00\",\"shipDeliveryEstimate\":\"\",", @class.string_15, @class.string_14),
							"\"shipMethodCodeSDD\":\"\",\"shipMethodNameSDD\":\"\",\"shipMethodPriceSDD\":\"$0.00\",\"shipDeliveryEstimateSDD\":\"\",\"shipMethodCodeS2S\":\"\",\"shipMethodNameS2S\":\"\",\"shipMethodPriceS2S\":\"$0.00\",\"shipDeliveryEstimateS2S\":\"\",\"shipMethodCodeSFS\":\"\",\"shipMethodNameSFS\":\"\",\"shipMethodPriceSFS\":\"$0.00\",\"shipDeliveryEstimateSFS\":\"\",\"homeDeliveryPrice\":\"$0.00\",\"overallHomeDeliveryPrice\":\"$0.00\",\"aggregatedDeliveryPrice\":\"FREE\",\"aggregatedDeliveryLabel\":\"\",\"showGiftBoxOption\":true,\"addGiftBox\":false,\"giftBoxPrice\":\"$3.99\",\"useGiftReceipt\":false,\"showGiftOptions\":true,\"loyaltyMessageText\":false,\"showLoyaltyRenewalMessage\":false,\"pickupPersonFirstName\":\"\",\"pickupPersonLastName\":\"\",\"preferredLanguage\":\"\",\"advanceToConfirm\":false,\"payType\":\"CREDIT_CARD\",\"payPalToken\":\"\",\"payPalInContext\":true,\"payPalMerchantId\":\"\",",
							string.Format("\"payPalStage\":\"\",\"payPalPaymentAllowed\":true,\"payMethodPaneExpireMonth\":{0},\"payMethodPaneExpireYear\":{1},\"payMethodPaneCardNumber\":\"{2}\",\"payMethodPaneCardType\":\"{3}\",\"payMethodPaneLastFour\":\"1111\",", new object[]
							{
								(string)@class.jtoken_1["payment"]["card"]["exp_month"],
								@class.jtoken_1["payment"]["card"]["exp_year"].ToString()[2].ToString() + @class.jtoken_1["payment"]["card"]["exp_year"].ToString()[3].ToString(),
								((string)@class.jtoken_1["payment"]["card"]["number"]).Replace(" ", string.Empty),
								@class.method_16(((string)@class.jtoken_1["payment"]["card"]["number"]).Replace(" ", string.Empty))
							}),
							string.Format("\"payMethodPanePayMethodName\":\"Visa\",\"payMethodPanePurchaseOrder\":\"\",\"payMethodPanePurchaseOrderNewCustomer\":\"\",\"payMethodPaneCVV\":\"{0}\",\"creditcardPaymentAllowed\":true,\"billMeLaterStage\":\"\",", (string)@class.jtoken_1["payment"]["card"]["cvv"]),
							"\"BMLPaymentAllowed\":true,\"displayBMLPromotion\":false,\"POPaymentAllowed\":false,\"promoType\":\"\",\"promoCode\":\"\",\"sourceCode\":\"INETSRC\",\"sourceCodeDescription\":\"\",\"sourceCodeCartDisplayText\":\"\",\"GIFTCARDCODE1\":\"\",\"GIFTCARDPIN1\":\"\",\"GIFTCARDUSED1\":\"\",\"GIFTCARDCODE2\":\"\",\"GIFTCARDPIN2\":\"\",\"GIFTCARDUSED2\":\"\",\"GIFTCARDCODE3\":\"\",\"GIFTCARDPIN3\":\"\",\"GIFTCARDUSED3\":\"\",\"GIFTCARDCODE4\":\"\",\"GIFTCARDPIN4\":\"\",\"GIFTCARDUSED4\":\"\",\"GIFTCARDCODE5\":\"\",\"GIFTCARDPIN5\":\"\",\"GIFTCARDUSED5\":\"\",\"rewardBarCode\":\"\",\"giftCardsEmpty\":true,\"sourceCodesEmpty\":true,\"emptyCart\":false,\"ContingencyQueue\":\"\",",
							string.Format("\"lgr\":\"{0}\",\"displayEmailOptIn\":false,\"billSubscribeEmail\":false,\"billReceiveNewsletter\":false,\"billFavoriteTeams\":false,\"paypalEmailAddress\":\"\",\"displaySheerIdIframe\":true,\"displayCmsEntry\":\"\",", @class.string_12),
							"\"payMethodPaneUserGotStoredCC\":false,\"payMethodPaneHasStoredCC\":false,\"payMethodPaneUsedStoredCC\":false,\"payMethodPaneSavedNewCC\":false,\"selectedCreditCard\":{},\"payMethodPaneHasCVV\":true,\"payMethodPaneCVVAF\":\"0\"}"
						});
						dictionary["requestKey"] = @class.string_10;
						dictionary["hbg"] = @class.string_11;
						dictionary["bb_device_id"] = Class47.smethod_0(16);
						dictionary["requestKey"] = @class.string_10;
						dictionary["hbg"] = @class.string_11;
						dictionary["bb_device_id"] = @class.string_17;
						dictionary["addressBookEnabled"] = "true";
						dictionary["loginHeaderEmailAddress"] = string.Empty;
						dictionary["loginHeaderPassword"] = string.Empty;
						dictionary["loginPaneNewEmailAddress"] = string.Empty;
						dictionary["loginPaneConfirmNewEmailAddress"] = string.Empty;
						dictionary["loginPaneEmailAddress"] = string.Empty;
						dictionary["loginPanePassword"] = string.Empty;
						dictionary["billAddressType"] = "new";
						dictionary["billAddressInputType"] = "single";
						dictionary["billAPOFPOCountry"] = Class43.smethod_0((string)@class.jtoken_1["billing"]["country"], false);
						dictionary["billCountry"] = Class43.smethod_0((string)@class.jtoken_1["billing"]["country"], false);
						dictionary["billMyAddressBookIndex"] = "-1";
						dictionary["billFirstName"] = (string)@class.jtoken_1["billing"]["first_name"];
						dictionary["billLastName"] = (string)@class.jtoken_1["billing"]["last_name"];
						dictionary["billAddress1"] = (string)@class.jtoken_1["billing"]["addr1"];
						dictionary["billAddress2"] = (string)@class.jtoken_1["billing"]["addr2"];
						dictionary["billPostalCode"] = (string)@class.jtoken_1["billing"]["zip"];
						dictionary["billCity"] = (string)@class.jtoken_1["billing"]["city"];
						dictionary["billAPOFPORegion"] = string.Empty;
						dictionary["billState"] = Class43.smethod_1((string)@class.jtoken_1["billing"]["country"], (string)@class.jtoken_1["billing"]["state"]);
						dictionary["billProvince"] = string.Empty;
						dictionary["billAPOFPOState"] = string.Empty;
						dictionary["billAPOFPOPostalCode"] = string.Empty;
						dictionary["billHomePhone"] = (string)@class.jtoken_1["payment"]["phone"];
						dictionary["billEmailAddress"] = (string)@class.jtoken_1["payment"]["email"];
						dictionary["billConfirmEmail"] = (string)@class.jtoken_1["payment"]["email"];
						dictionary["shipAddressType"] = "new";
						dictionary["shipAddressInputType"] = "single";
						dictionary["shipAPOFPOCountry"] = Class43.smethod_0((string)@class.jtoken_1["delivery"]["country"], false);
						dictionary["shipCountry"] = Class43.smethod_0((string)@class.jtoken_1["delivery"]["country"], false);
						dictionary["shipMyAddressBookIndex"] = "-1";
						dictionary["shipToStore"] = "false";
						dictionary["shipFirstName"] = (string)@class.jtoken_1["delivery"]["first_name"];
						dictionary["shipLastName"] = (string)@class.jtoken_1["delivery"]["last_name"];
						dictionary["shipAddress1"] = (string)@class.jtoken_1["delivery"]["addr1"];
						dictionary["shipAddress2"] = (string)@class.jtoken_1["delivery"]["addr2"];
						dictionary["shipPostalCode"] = (string)@class.jtoken_1["delivery"]["zip"];
						dictionary["shipCity"] = (string)@class.jtoken_1["delivery"]["city"];
						dictionary["shipAPOFPORegion"] = string.Empty;
						dictionary["shipState"] = Class43.smethod_1((string)@class.jtoken_1["delivery"]["country"], (string)@class.jtoken_1["delivery"]["state"]);
						dictionary["shipProvince"] = string.Empty;
						dictionary["shipAPOFPOState"] = string.Empty;
						dictionary["shipAPOFPOPostalCode"] = string.Empty;
						dictionary["shipHomePhone"] = (string)@class.jtoken_1["payment"]["phone"];
						dictionary["shipMethodCodeS2S"] = string.Empty;
						dictionary["shipMethodCode"] = @class.string_15;
						dictionary["storePickupInputPostalCode"] = string.Empty;
						dictionary["promoType"] = string.Empty;
						dictionary["CPCOrSourceCode"] = string.Empty;
						dictionary["payMethodPanePayType"] = "CC";
						dictionary["payMethodPanestoredCCCardNumber"] = "CC";
						dictionary["CardNumber"] = ((string)@class.jtoken_1["payment"]["card"]["number"]).Replace(" ", string.Empty);
						dictionary["CardExpireDateMM"] = (string)@class.jtoken_1["payment"]["card"]["exp_month"];
						dictionary["CardExpireDateYY"] = (string)@class.jtoken_1["payment"]["card"]["exp_year"];
						dictionary["CardCCV"] = (string)@class.jtoken_1["payment"]["card"]["cvv"];
						dictionary["payMethodPaneStoredType"] = string.Empty;
						dictionary["payMethodPaneConfirmCardNumber"] = string.Empty;
						dictionary["payMethodPaneStoredCCExpireMonth"] = string.Empty;
						dictionary["payMethodPaneStoredCCExpireYear"] = string.Empty;
						dictionary["payMethodPaneCardType"] = @class.method_16(((string)@class.jtoken_1["payment"]["card"]["number"]).Replace(" ", string.Empty));
						dictionary["payMethodPaneCardNumber"] = ((string)@class.jtoken_1["payment"]["card"]["number"]).Replace(" ", string.Empty);
						dictionary["payMethodPaneExpireMonth"] = (string)@class.jtoken_1["payment"]["card"]["exp_month"];
						dictionary["payMethodPaneExpireYear"] = @class.jtoken_1["payment"]["card"]["exp_year"].ToString()[2].ToString() + @class.jtoken_1["payment"]["card"]["exp_year"].ToString()[3].ToString();
						dictionary["payMethodPaneCVV"] = (string)@class.jtoken_1["payment"]["card"]["cvv"];
						dictionary["payMethodPaneStoredCCCVV"] = string.Empty;
						dictionary["shipProvince"] = Class43.smethod_1((string)@class.jtoken_1["delivery"]["country"], (string)@class.jtoken_1["delivery"]["state"]);
						dictionary["billProvince"] = Class43.smethod_1((string)@class.jtoken_1["billing"]["country"], (string)@class.jtoken_1["billing"]["state"]);
						taskAwaiter6 = @class.class14_0.method_3(string.Format("https://www.{0}/checkout/eventGateway?method=validateReviewPane", @class.string_9), dictionary, false).GetAwaiter();
						if (!taskAwaiter6.IsCompleted)
						{
							int num7 = 0;
							num = 0;
							num2 = num7;
							TaskAwaiter<HttpResponseMessage> taskAwaiter7 = taskAwaiter6;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class47.Struct57>(ref taskAwaiter6, ref this);
							return;
						}
						break;
					}
					}
					HttpResponseMessage result = taskAwaiter6.GetResult();
					httpResponseMessage = result;
					taskAwaiter8 = @class.method_17(httpResponseMessage).GetAwaiter();
					if (!taskAwaiter8.IsCompleted)
					{
						int num8 = 1;
						num = 1;
						num2 = num8;
						taskAwaiter2 = taskAwaiter8;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, Class47.Struct57>(ref taskAwaiter8, ref this);
						return;
					}
					IL_107D:
					if (taskAwaiter8.GetResult())
					{
						goto IL_11CA;
					}
					httpResponseMessage.EnsureSuccessStatusCode();
					taskAwaiter9 = httpResponseMessage.smethod_3().GetAwaiter();
					if (!taskAwaiter9.IsCompleted)
					{
						int num9 = 2;
						num = 2;
						num2 = num9;
						TaskAwaiter<string> taskAwaiter10 = taskAwaiter9;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class47.Struct57>(ref taskAwaiter9, ref this);
						return;
					}
					IL_10F3:
					string result2 = taskAwaiter9.GetResult();
					JObject jobject = JObject.Parse(result2.Substring(2, result2.Length - 2));
					if (!result2.Contains("order.credit.auth.error"))
					{
						if (result2.Contains("order.ledger.synchronization.error"))
						{
							@class.method_0("Payment error", "red", true, (GEnum1)0);
						}
						else if ((bool)jobject["ORDERREVIEWPANE"]["ORDERSUBMITTED"])
						{
							@class.method_0("Successfully checked out", "green", true, (GEnum1)6);
						}
						throw new Exception();
					}
					@class.method_0("Card Declined", "red", true, (GEnum1)5);
					goto IL_120C;
				}
				catch
				{
					num10 = 1;
				}
				if (num10 != 1)
				{
					goto IL_11CA;
				}
				@class.method_5("Error submitting order", "#c2c2c2", true, false);
				taskAwaiter5 = @class.method_14(Class130.int_1).GetAwaiter();
				if (!taskAwaiter5.IsCompleted)
				{
					int num11 = 3;
					num = 3;
					num2 = num11;
					taskAwaiter4 = taskAwaiter5;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class47.Struct57>(ref taskAwaiter5, ref this);
					return;
				}
				IL_11C3:
				taskAwaiter5.GetResult();
				IL_11CA:
				num10 = 0;
				goto IL_68;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_120C:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060004D5 RID: 1237 RVA: 0x00004F2A File Offset: 0x0000312A
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400031E RID: 798
		public int int_0;

		// Token: 0x0400031F RID: 799
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000320 RID: 800
		public Class47 class47_0;

		// Token: 0x04000321 RID: 801
		private HttpResponseMessage httpResponseMessage_0;

		// Token: 0x04000322 RID: 802
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000323 RID: 803
		private TaskAwaiter<bool> taskAwaiter_1;

		// Token: 0x04000324 RID: 804
		private TaskAwaiter<string> taskAwaiter_2;

		// Token: 0x04000325 RID: 805
		private TaskAwaiter taskAwaiter_3;
	}

	// Token: 0x020000C9 RID: 201
	[StructLayout(LayoutKind.Auto)]
	private struct Struct58 : IAsyncStateMachine
	{
		// Token: 0x060004D6 RID: 1238 RVA: 0x00025D34 File Offset: 0x00023F34
		void IAsyncStateMachine.MoveNext()
		{
			int num3;
			int num2 = num3;
			Class47 @class = this;
			try
			{
				TaskAwaiter taskAwaiter5;
				if (num2 > 2)
				{
					if (num2 != 3)
					{
						htmlDocument = new HtmlDocument();
						goto IL_33B;
					}
					taskAwaiter5 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter);
					int num4 = -1;
					num2 = -1;
					num3 = num4;
					goto IL_334;
				}
				IL_48:
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter6;
					TaskAwaiter<bool> taskAwaiter8;
					TaskAwaiter<string> taskAwaiter9;
					switch (num2)
					{
					case 0:
					{
						TaskAwaiter<HttpResponseMessage> taskAwaiter7;
						taskAwaiter6 = taskAwaiter7;
						taskAwaiter7 = default(TaskAwaiter<HttpResponseMessage>);
						int num5 = -1;
						num2 = -1;
						num3 = num5;
						break;
					}
					case 1:
					{
						taskAwaiter8 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<bool>);
						int num6 = -1;
						num2 = -1;
						num3 = num6;
						goto IL_13B;
					}
					case 2:
					{
						TaskAwaiter<string> taskAwaiter10;
						taskAwaiter9 = taskAwaiter10;
						taskAwaiter10 = default(TaskAwaiter<string>);
						int num7 = -1;
						num2 = -1;
						num3 = num7;
						goto IL_1B1;
					}
					default:
						@class.method_5("Collecting data", "#c2c2c2", true, false);
						taskAwaiter6 = @class.class14_0.method_2(@class.string_7, false).GetAwaiter();
						if (!taskAwaiter6.IsCompleted)
						{
							int num8 = 0;
							num2 = 0;
							num3 = num8;
							TaskAwaiter<HttpResponseMessage> taskAwaiter7 = taskAwaiter6;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class47.Struct58>(ref taskAwaiter6, ref this);
							return;
						}
						break;
					}
					HttpResponseMessage result = taskAwaiter6.GetResult();
					httpResponseMessage = result;
					taskAwaiter8 = @class.method_17(httpResponseMessage).GetAwaiter();
					if (!taskAwaiter8.IsCompleted)
					{
						int num9 = 1;
						num2 = 1;
						num3 = num9;
						taskAwaiter2 = taskAwaiter8;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, Class47.Struct58>(ref taskAwaiter8, ref this);
						return;
					}
					IL_13B:
					if (taskAwaiter8.GetResult())
					{
						goto IL_33B;
					}
					httpResponseMessage.EnsureSuccessStatusCode();
					taskAwaiter9 = httpResponseMessage.smethod_3().GetAwaiter();
					if (!taskAwaiter9.IsCompleted)
					{
						int num10 = 2;
						num2 = 2;
						num3 = num10;
						TaskAwaiter<string> taskAwaiter10 = taskAwaiter9;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class47.Struct58>(ref taskAwaiter9, ref this);
						return;
					}
					IL_1B1:
					string result2 = taskAwaiter9.GetResult();
					htmlDocument.LoadHtml(result2);
					@class.string_10 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='requestKey']").Attributes["value"].Value;
					@class.string_8 = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='sku']").Attributes["value"].Value;
					if (!@class.string_7.Contains(@class.string_8))
					{
						@class.method_0("Product pulled", "red", true, (GEnum1)0);
					}
					if (result2.Contains("var cm_isLaunchSku = 'Y';") && @class.string_9 != "footaction.com")
					{
						@class.int_0 = Convert.ToInt32(result2.Split(new string[]
						{
							"var productLaunchTimeUntil = "
						}, StringSplitOptions.None)[1].Split(new char[]
						{
							';'
						})[0]) - 1;
					}
					else if (@class.string_9 == "footaction.com" && !result2.Contains("id=\"addToWishlist\""))
					{
						@class.int_0 = Convert.ToInt32(result2.Split(new string[]
						{
							"var timeToHL = "
						}, StringSplitOptions.None)[1].Split(new char[]
						{
							';'
						})[0]) - 1;
					}
					httpResponseMessage = null;
					goto IL_352;
				}
				catch
				{
					num = 1;
					goto IL_352;
				}
				IL_307:
				@class.method_5("Error collecting data", "#c2c2c2", true, false);
				taskAwaiter5 = @class.method_14(Class130.int_1).GetAwaiter();
				if (taskAwaiter5.IsCompleted)
				{
					goto IL_334;
				}
				int num11 = 3;
				num2 = 3;
				num3 = num11;
				taskAwaiter4 = taskAwaiter5;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class47.Struct58>(ref taskAwaiter5, ref this);
				return;
				IL_352:
				int num12 = num;
				if (num12 == 1)
				{
					goto IL_307;
				}
				try
				{
					if (!(@class.string_9 == "champssports.com") && !(@class.string_9 == "footlocker.ca"))
					{
						@class.method_7(htmlDocument.DocumentNode.SelectSingleNode("//input[@id='model_name']").Attributes["value"].Value, "#c2c2c2");
					}
					else
					{
						@class.method_7(htmlDocument.DocumentNode.SelectSingleNode("//*[@id='model_name']").InnerText, "#c2c2c2");
					}
				}
				catch
				{
				}
				goto IL_427;
				IL_334:
				taskAwaiter5.GetResult();
				IL_33B:
				if (!@class.bool_1)
				{
					num = 0;
					goto IL_48;
				}
			}
			catch (Exception exception)
			{
				num3 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_427:
			num3 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060004D7 RID: 1239 RVA: 0x00004F38 File Offset: 0x00003138
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000326 RID: 806
		public int int_0;

		// Token: 0x04000327 RID: 807
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000328 RID: 808
		public Class47 class47_0;

		// Token: 0x04000329 RID: 809
		private HtmlDocument htmlDocument_0;

		// Token: 0x0400032A RID: 810
		private int int_1;

		// Token: 0x0400032B RID: 811
		private HttpResponseMessage httpResponseMessage_0;

		// Token: 0x0400032C RID: 812
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x0400032D RID: 813
		private TaskAwaiter<bool> taskAwaiter_1;

		// Token: 0x0400032E RID: 814
		private TaskAwaiter<string> taskAwaiter_2;

		// Token: 0x0400032F RID: 815
		private TaskAwaiter taskAwaiter_3;
	}

	// Token: 0x020000CA RID: 202
	[StructLayout(LayoutKind.Auto)]
	private struct Struct59 : IAsyncStateMachine
	{
		// Token: 0x060004D8 RID: 1240 RVA: 0x000261C8 File Offset: 0x000243C8
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class47 @class = this;
			try
			{
				TaskAwaiter taskAwaiter5;
				if (num > 2)
				{
					if (num != 3)
					{
						@class.cookieCollection_0 = @class.class14_0.cookieContainer_0.GetCookies(new Uri(string.Format("https://www.{0}", @class.string_9)));
						goto IL_8E4;
					}
					taskAwaiter5 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter);
					int num3 = -1;
					num = -1;
					num2 = num3;
					goto IL_8DD;
				}
				IL_68:
				int num10;
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter6;
					TaskAwaiter<bool> taskAwaiter8;
					TaskAwaiter<string> taskAwaiter9;
					switch (num)
					{
					case 0:
					{
						TaskAwaiter<HttpResponseMessage> taskAwaiter7;
						taskAwaiter6 = taskAwaiter7;
						taskAwaiter7 = default(TaskAwaiter<HttpResponseMessage>);
						int num4 = -1;
						num = -1;
						num2 = num4;
						break;
					}
					case 1:
					{
						taskAwaiter8 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<bool>);
						int num5 = -1;
						num = -1;
						num2 = num5;
						goto IL_65D;
					}
					case 2:
					{
						TaskAwaiter<string> taskAwaiter10;
						taskAwaiter9 = taskAwaiter10;
						taskAwaiter10 = default(TaskAwaiter<string>);
						int num6 = -1;
						num = -1;
						num2 = num6;
						goto IL_6D3;
					}
					default:
					{
						@class.method_5("Submitting shipping data", "#c2c2c2", true, false);
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						string value = "{\"maxVisitedPane\":\"billAddressPane\",\"billMyAddressBookIndex\":\"-1\",\"addressNeedsVerification\":true,\"billFirstName\":\"\",\"billLastName\":\"\",\"billAddress1\":\"\",\"billAddress2\":\"\",\"billCity\":\"\",\"billState\":\"\",\"billProvince\":\"\",\"billPostalCode\":\"\",\"billHomePhone\":\"\",\"billMobilePhone\":\"\",\"billCountry\":\"US\",\"billEmailAddress\":\"\",\"billConfirmEmail\":\"\",\"billAddrIsPhysical\":true,\"billSubscribePhone\":false,\"billAbbreviatedAddress\":false,\"shipUpdateDefaultAddress\":false,\"VIPNumber\":\"\",\"accountBillAddress\":{\"billMyAddressBookIndex\":-1},\"selectedBillAddress\":{},\"billMyAddressBook\":[],\"updateBillingForBML\":false}";
						dictionary["requestKey"] = @class.string_10;
						dictionary["hbg"] = @class.string_11;
						dictionary["addressBookEnabled"] = "true";
						dictionary["billAddressType"] = "new";
						dictionary["billAddressInputType"] = "single";
						dictionary["billCountry"] = Class43.smethod_0((string)@class.jtoken_1["billing"]["country"], false);
						dictionary["billMyAddressBookIndex"] = "-1";
						dictionary["billFirstName"] = (string)@class.jtoken_1["billing"]["first_name"];
						dictionary["billLastName"] = (string)@class.jtoken_1["billing"]["last_name"];
						dictionary["billAddress1"] = (string)@class.jtoken_1["billing"]["addr1"];
						dictionary["billAddress2"] = (string)@class.jtoken_1["billing"]["addr2"];
						dictionary["billPostalCode"] = (string)@class.jtoken_1["billing"]["zip"];
						dictionary["billCity"] = (string)@class.jtoken_1["billing"]["city"];
						dictionary["billState"] = Class43.smethod_1((string)@class.jtoken_1["billing"]["country"], (string)@class.jtoken_1["billing"]["state"]);
						dictionary["billProvince"] = Class43.smethod_1((string)@class.jtoken_1["billing"]["country"], (string)@class.jtoken_1["billing"]["state"]);
						dictionary["billHomePhone"] = (string)@class.jtoken_1["payment"]["phone"];
						dictionary["billEmailAddress"] = (string)@class.jtoken_1["payment"]["email"];
						dictionary["billConfirmEmail"] = (string)@class.jtoken_1["payment"]["email"];
						dictionary["shipAddressType"] = "different";
						dictionary["shipAddressInputType"] = "single";
						dictionary["shipCountry"] = Class43.smethod_0((string)@class.jtoken_1["delivery"]["country"], false);
						dictionary["shipMyAddressBookIndex"] = "-2";
						dictionary["shipToStore"] = "false";
						dictionary["shipFirstName"] = (string)@class.jtoken_1["delivery"]["first_name"];
						dictionary["shipLastName"] = (string)@class.jtoken_1["delivery"]["last_name"];
						dictionary["shipAddress1"] = (string)@class.jtoken_1["delivery"]["addr1"];
						dictionary["shipAddress2"] = (string)@class.jtoken_1["delivery"]["addr2"];
						dictionary["shipPostalCode"] = (string)@class.jtoken_1["delivery"]["zip"];
						dictionary["shipCity"] = (string)@class.jtoken_1["delivery"]["city"];
						dictionary["shipState"] = Class43.smethod_1((string)@class.jtoken_1["delivery"]["country"], (string)@class.jtoken_1["delivery"]["state"]);
						dictionary["shipProvince"] = Class43.smethod_1((string)@class.jtoken_1["delivery"]["country"], (string)@class.jtoken_1["delivery"]["state"]);
						dictionary["shipHomePhone"] = (string)@class.jtoken_1["payment"]["phone"];
						dictionary["verifiedCheckoutData"] = value;
						taskAwaiter6 = @class.class14_0.method_3(string.Format("https://www.{0}/checkout/eventGateway?method=validateShipPane", @class.string_9), dictionary, false).GetAwaiter();
						if (!taskAwaiter6.IsCompleted)
						{
							int num7 = 0;
							num = 0;
							num2 = num7;
							TaskAwaiter<HttpResponseMessage> taskAwaiter7 = taskAwaiter6;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class47.Struct59>(ref taskAwaiter6, ref this);
							return;
						}
						break;
					}
					}
					HttpResponseMessage result = taskAwaiter6.GetResult();
					httpResponseMessage = result;
					taskAwaiter8 = @class.method_17(httpResponseMessage).GetAwaiter();
					if (!taskAwaiter8.IsCompleted)
					{
						int num8 = 1;
						num = 1;
						num2 = num8;
						taskAwaiter2 = taskAwaiter8;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, Class47.Struct59>(ref taskAwaiter8, ref this);
						return;
					}
					IL_65D:
					if (taskAwaiter8.GetResult())
					{
						goto IL_8E4;
					}
					httpResponseMessage.EnsureSuccessStatusCode();
					taskAwaiter9 = httpResponseMessage.smethod_3().GetAwaiter();
					if (!taskAwaiter9.IsCompleted)
					{
						int num9 = 2;
						num = 2;
						num2 = num9;
						TaskAwaiter<string> taskAwaiter10 = taskAwaiter9;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class47.Struct59>(ref taskAwaiter9, ref this);
						return;
					}
					IL_6D3:
					string result2 = taskAwaiter9.GetResult();
					JObject jobject = JObject.Parse(result2.Substring(2, result2.Length - 2));
					if (jobject["RESPONSEERROR"].ToString() != "False")
					{
						throw new Exception();
					}
					if (result2.Contains("One or more items cannot be shipped to the destination"))
					{
						@class.method_0("Shipping restriction", "red", true, (GEnum1)0);
					}
					@class.string_10 = jobject["REQUESTKEY"].ToString();
					@class.string_11 = jobject["hbg"].ToString();
					if (@class.string_9 == "footlocker.ca")
					{
						@class.string_14 = jobject["SHIPMETHODPANE"]["SELECTEDMETHODNAMESFS"].ToString();
						@class.string_15 = jobject["SHIPMETHODPANE"]["SELECTEDMETHODCODESFS"].ToString();
					}
					else if (jobject["SHIPMETHODPANE"]["VALIDMETHODS"].Any<JToken>())
					{
						@class.string_14 = jobject["SHIPMETHODPANE"]["VALIDMETHODS"][0]["SHIPPINGMETHODNAME"].ToString();
						@class.string_15 = jobject["SHIPMETHODPANE"]["VALIDMETHODS"][0]["SHIPMETHODCODE"].ToString();
					}
					else
					{
						@class.string_14 = jobject["SHIPMETHODPANE"]["SELECTEDMETHODCODESFS"].ToString();
						@class.string_15 = jobject["SHIPMETHODPANE"]["SELECTEDMETHODNAMESFS"].ToString();
					}
					@class.string_13 = jobject["SHIPPANE"]["SHIPHASH"].ToString();
					goto IL_926;
				}
				catch
				{
					num10 = 1;
				}
				if (num10 != 1)
				{
					goto IL_8E4;
				}
				@class.method_5("Error submitting shipping data", "#c2c2c2", true, false);
				taskAwaiter5 = @class.method_14(Class130.int_1).GetAwaiter();
				if (!taskAwaiter5.IsCompleted)
				{
					int num11 = 3;
					num = 3;
					num2 = num11;
					taskAwaiter4 = taskAwaiter5;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class47.Struct59>(ref taskAwaiter5, ref this);
					return;
				}
				IL_8DD:
				taskAwaiter5.GetResult();
				IL_8E4:
				num10 = 0;
				goto IL_68;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_926:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x00004F46 File Offset: 0x00003146
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000330 RID: 816
		public int int_0;

		// Token: 0x04000331 RID: 817
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000332 RID: 818
		public Class47 class47_0;

		// Token: 0x04000333 RID: 819
		private HttpResponseMessage httpResponseMessage_0;

		// Token: 0x04000334 RID: 820
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000335 RID: 821
		private TaskAwaiter<bool> taskAwaiter_1;

		// Token: 0x04000336 RID: 822
		private TaskAwaiter<string> taskAwaiter_2;

		// Token: 0x04000337 RID: 823
		private TaskAwaiter taskAwaiter_3;
	}

	// Token: 0x020000CB RID: 203
	[StructLayout(LayoutKind.Auto)]
	private struct Struct60 : IAsyncStateMachine
	{
		// Token: 0x060004DA RID: 1242 RVA: 0x00026B44 File Offset: 0x00024D44
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class47 @class = this;
			try
			{
				TaskAwaiter taskAwaiter5;
				if (num > 2)
				{
					if (num != 3)
					{
						goto IL_28D;
					}
					taskAwaiter5 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter);
					int num3 = -1;
					num = -1;
					num2 = num3;
					goto IL_27D;
				}
				IL_3D:
				int num10;
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter6;
					TaskAwaiter<bool> taskAwaiter8;
					TaskAwaiter<string> taskAwaiter9;
					switch (num)
					{
					case 0:
					{
						TaskAwaiter<HttpResponseMessage> taskAwaiter7;
						taskAwaiter6 = taskAwaiter7;
						taskAwaiter7 = default(TaskAwaiter<HttpResponseMessage>);
						int num4 = -1;
						num = -1;
						num2 = num4;
						break;
					}
					case 1:
					{
						taskAwaiter8 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<bool>);
						int num5 = -1;
						num = -1;
						num2 = num5;
						goto IL_13A;
					}
					case 2:
					{
						TaskAwaiter<string> taskAwaiter10;
						taskAwaiter9 = taskAwaiter10;
						taskAwaiter10 = default(TaskAwaiter<string>);
						int num6 = -1;
						num = -1;
						num2 = num6;
						goto IL_1C7;
					}
					default:
						@class.method_5("Collecting checkout data", "#c2c2c2", true, false);
						taskAwaiter6 = @class.class14_0.method_2(string.Format("https://www.{0}/checkout/?uri=checkout/", @class.string_9), false).GetAwaiter();
						if (!taskAwaiter6.IsCompleted)
						{
							int num7 = 0;
							num = 0;
							num2 = num7;
							TaskAwaiter<HttpResponseMessage> taskAwaiter7 = taskAwaiter6;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class47.Struct60>(ref taskAwaiter6, ref this);
							return;
						}
						break;
					}
					HttpResponseMessage result = taskAwaiter6.GetResult();
					httpResponseMessage = result;
					taskAwaiter8 = @class.method_17(httpResponseMessage).GetAwaiter();
					if (!taskAwaiter8.IsCompleted)
					{
						int num8 = 1;
						num = 1;
						num2 = num8;
						taskAwaiter2 = taskAwaiter8;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, Class47.Struct60>(ref taskAwaiter8, ref this);
						return;
					}
					IL_13A:
					if (taskAwaiter8.GetResult())
					{
						goto IL_28D;
					}
					httpResponseMessage.EnsureSuccessStatusCode();
					htmlDocument = new HtmlDocument();
					htmlDocument2 = htmlDocument;
					taskAwaiter9 = httpResponseMessage.smethod_3().GetAwaiter();
					if (!taskAwaiter9.IsCompleted)
					{
						int num9 = 2;
						num = 2;
						num2 = num9;
						TaskAwaiter<string> taskAwaiter10 = taskAwaiter9;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class47.Struct60>(ref taskAwaiter9, ref this);
						return;
					}
					IL_1C7:
					string result2 = taskAwaiter9.GetResult();
					htmlDocument2.LoadHtml(result2);
					htmlDocument2 = null;
					@class.string_11 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='hbg']").Attributes["value"].Value;
					@class.string_10 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='requestKey']").Attributes["value"].Value;
					goto IL_2D3;
				}
				catch
				{
					num10 = 1;
				}
				if (num10 != 1)
				{
					goto IL_28D;
				}
				@class.method_5("Error collecting checkout data", "#c2c2c2", true, false);
				taskAwaiter5 = @class.method_14(Class130.int_1).GetAwaiter();
				if (!taskAwaiter5.IsCompleted)
				{
					int num11 = 3;
					num = 3;
					num2 = num11;
					taskAwaiter4 = taskAwaiter5;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class47.Struct60>(ref taskAwaiter5, ref this);
					return;
				}
				IL_27D:
				taskAwaiter5.GetResult();
				IL_28D:
				if (!@class.bool_1)
				{
					num10 = 0;
					goto IL_3D;
				}
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_2D3:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x00004F54 File Offset: 0x00003154
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000338 RID: 824
		public int int_0;

		// Token: 0x04000339 RID: 825
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x0400033A RID: 826
		public Class47 class47_0;

		// Token: 0x0400033B RID: 827
		private HttpResponseMessage httpResponseMessage_0;

		// Token: 0x0400033C RID: 828
		private HtmlDocument htmlDocument_0;

		// Token: 0x0400033D RID: 829
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x0400033E RID: 830
		private TaskAwaiter<bool> taskAwaiter_1;

		// Token: 0x0400033F RID: 831
		private HtmlDocument htmlDocument_1;

		// Token: 0x04000340 RID: 832
		private TaskAwaiter<string> taskAwaiter_2;

		// Token: 0x04000341 RID: 833
		private TaskAwaiter taskAwaiter_3;
	}

	// Token: 0x020000CC RID: 204
	[StructLayout(LayoutKind.Auto)]
	private struct Struct61 : IAsyncStateMachine
	{
		// Token: 0x060004DC RID: 1244 RVA: 0x00026E6C File Offset: 0x0002506C
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class47 @class = this;
			try
			{
				TaskAwaiter taskAwaiter5;
				if (num > 2)
				{
					if (num != 3)
					{
						@class.cookieCollection_0 = @class.class14_0.cookieContainer_0.GetCookies(new Uri(string.Format("https://www.{0}", @class.string_9)));
						goto IL_FFD;
					}
					taskAwaiter5 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter);
					int num3 = -1;
					num = -1;
					num2 = num3;
					goto IL_FF6;
				}
				IL_68:
				int num10;
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter6;
					TaskAwaiter<bool> taskAwaiter8;
					TaskAwaiter<string> taskAwaiter9;
					switch (num)
					{
					case 0:
					{
						TaskAwaiter<HttpResponseMessage> taskAwaiter7;
						taskAwaiter6 = taskAwaiter7;
						taskAwaiter7 = default(TaskAwaiter<HttpResponseMessage>);
						int num4 = -1;
						num = -1;
						num2 = num4;
						break;
					}
					case 1:
					{
						taskAwaiter8 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<bool>);
						int num5 = -1;
						num = -1;
						num2 = num5;
						goto IL_ED5;
					}
					case 2:
					{
						TaskAwaiter<string> taskAwaiter10;
						taskAwaiter9 = taskAwaiter10;
						taskAwaiter10 = default(TaskAwaiter<string>);
						int num6 = -1;
						num = -1;
						num2 = num6;
						goto IL_F4B;
					}
					default:
					{
						@class.method_5("Submitting payment", "#c2c2c2", true, false);
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary["verifiedCheckoutData"] = string.Concat(new string[]
						{
							string.Format("{{\"maxVisitedPane\":\"promoCodePane\",\"updateBillingForBML\":false,\"billMyAddressBookIndex\":\"-1\",\"addressNeedsVerification\":false,\"billFirstName\":\"{0}\",\"billLastName\":\"{1}\",", (string)@class.jtoken_1["billing"]["first_name"], (string)@class.jtoken_1["billing"]["last_name"]),
							string.Format("\"billAddress1\":\"{0}\",\"billAddress2\":\"{1}\",\"billCity\":\"{2}\",\"billState\":\"{3}\",\"billProvince\":\"{4}\",\"billPostalCode\":\"{5}\",\"billHomePhone\":\"{6}\",\"billMobilePhone\":\"\",\"billCountry\":\"{7}\",", new object[]
							{
								(string)@class.jtoken_1["billing"]["addr1"],
								(string)@class.jtoken_1["billing"]["addr2"],
								(string)@class.jtoken_1["billing"]["city"],
								Class43.smethod_1((string)@class.jtoken_1["billing"]["country"], (string)@class.jtoken_1["billing"]["state"]),
								Class43.smethod_1((string)@class.jtoken_1["billing"]["country"], (string)@class.jtoken_1["billing"]["state"]),
								(string)@class.jtoken_1["billing"]["zip"],
								(string)@class.jtoken_1["payment"]["phone"],
								Class43.smethod_0((string)@class.jtoken_1["billing"]["country"], false)
							}),
							string.Format("\"billEmailAddress\":\"{0}\",\"billConfirmEmail\":\"{1}\",\"billAddrIsPhysical\":true,\"billSubscribePhone\":false,\"billAbbreviatedAddress\":false,\"shipUpdateDefaultAddress\":false,\"VIPNumber\":\"\",", (string)@class.jtoken_1["payment"]["email"], (string)@class.jtoken_1["payment"]["email"]),
							string.Format("\"accountBillAddress\":{{\"billMyAddressBookIndex\":-1}},\"selectedBillAddress\":{{}},\"billMyAddressBook\":[],\"shipMyAddressBookIndex\":-2,\"shipContactID\":\"\",\"shipFirstName\":\"{0}\",\"shipLastName\":\"{1}\",\"shipAddress1\":\"{2}\",", (string)@class.jtoken_1["delivery"]["first_name"], (string)@class.jtoken_1["delivery"]["last_name"], (string)@class.jtoken_1["delivery"]["addr1"]),
							string.Format("\"shipAddress2\":\"{0}\",\"shipCity\":\"{1}\",\"shipState\":\"{2}\",\"shipProvince\":\"{3}\",\"shipPostalCode\":\"{4}\",\"shipHomePhone\":\"{5}\",\"shipMobilePhone\":\"\",\"shipCountry\":\"{6}\",\"shipToStore\":false,", new object[]
							{
								(string)@class.jtoken_1["delivery"]["addr2"],
								(string)@class.jtoken_1["delivery"]["city"],
								Class43.smethod_1((string)@class.jtoken_1["delivery"]["country"], (string)@class.jtoken_1["delivery"]["state"]),
								Class43.smethod_1((string)@class.jtoken_1["delivery"]["country"], (string)@class.jtoken_1["delivery"]["state"]),
								(string)@class.jtoken_1["delivery"]["zip"],
								(string)@class.jtoken_1["payment"]["phone"],
								Class43.smethod_0((string)@class.jtoken_1["delivery"]["country"], false)
							}),
							string.Format("\"shipHash\":\"{0}\",\"shipMultiple\":false,\"isShipToStoreEligibleCheckout\":true,\"isMultipleAddressEligible\":false,\"shipAbbreviatedAddress\":false,\"selectedStore\":{{}},", @class.string_13),
							string.Format("\"accountShipAddress\":{{\"shipMyAddressBookIndex\":-1}},\"selectedShipAddress\":{{}},\"shipMyAddressBook\":[],\"shipMethodCode\":\"{0}\",\"shipMethodName\":\"{1}\",\"shipMethodPrice\":\"$0.00\",", @class.string_15, @class.string_14),
							"\"shipDeliveryEstimate\":\"\",\"shipMethodCodeSDD\":\"\",\"shipMethodNameSDD\":\"\",\"shipMethodPriceSDD\":\"$0.00\",\"shipDeliveryEstimateSDD\":\"\",\"shipMethodCodeS2S\":\"\",\"shipMethodNameS2S\":\"\",\"shipMethodPriceS2S\":\"$0.00\",\"shipDeliveryEstimateS2S\":\"\",\"shipMethodCodeSFS\":\"\",\"shipMethodNameSFS\":\"\",\"shipMethodPriceSFS\":\"$0.00\",\"shipDeliveryEstimateSFS\":\"\",\"homeDeliveryPrice\":\"$0.00\",\"overallHomeDeliveryPrice\":\"$0.00\",\"aggregatedDeliveryPrice\":\"FREE\",\"aggregatedDeliveryLabel\":\"\",\"showGiftBoxOption\":true,\"addGiftBox\":false,\"giftBoxPrice\":\"$3.99\",\"useGiftReceipt\":false,\"showGiftOptions\":true,\"loyaltyMessageText\":false,\"showLoyaltyRenewalMessage\":false,\"pickupPersonFirstName\":\"\",\"pickupPersonLastName\":\"\",\"preferredLanguage\":\"\",\"advanceToConfirm\":false,\"payType\":\"NO_PAYMENT_METHOD\",\"payPalToken\":\"\",\"payPalInContext\":true,\"payPalMerchantId\":\"\",\"payPalStage\":\"\",\"payPalPaymentAllowed\":true,\"payMethodPaneExpireMonth\":\"\",\"payMethodPaneExpireYear\":\"\",\"payMethodPaneCardNumber\":\"\",\"payMethodPaneCardType\":\"\",\"payMethodPaneLastFour\":\"\",\"payMethodPanePurchaseOrder\":\"\",\"payMethodPanePurchaseOrderNewCustomer\":\"\",\"payMethodPaneCVV\":\"\",\"creditcardPaymentAllowed\":true,\"billMeLaterStage\":\"\",\"BMLPaymentAllowed\":true,\"displayBMLPromotion\":false,\"POPaymentAllowed\":false,\"promoType\":\"\",\"promoCode\":\"\",\"sourceCode\":\"INETSRC\",\"sourceCodeDescription\":\"\",\"sourceCodeCartDisplayText\":\"\",\"GIFTCARDCODE1\":\"\",\"GIFTCARDPIN1\":\"\",\"GIFTCARDUSED1\":\"\",\"GIFTCARDCODE2\":\"\",\"GIFTCARDPIN2\":\"\",\"GIFTCARDUSED2\":\"\",\"GIFTCARDCODE3\":\"\",\"GIFTCARDPIN3\":\"\",\"GIFTCARDUSED3\":\"\",\"GIFTCARDCODE4\":\"\",\"GIFTCARDPIN4\":\"\",",
							string.Format("\"GIFTCARDUSED4\":\"\",\"GIFTCARDCODE5\":\"\",\"GIFTCARDPIN5\":\"\",\"GIFTCARDUSED5\":\"\",\"rewardBarCode\":\"\",\"giftCardsEmpty\":true,\"sourceCodesEmpty\":true,\"ContingencyQueue\":\"\",\"lgr\":\"{0}\",\"displayEmailOptIn\":false,", @class.string_12),
							"\"billSubscribeEmail\":false,\"billReceiveNewsletter\":false,\"billFavoriteTeams\":false,\"paypalEmailAddress\":\"\",\"displaySheerIdIframe\":true,\"displayCmsEntry\":\"\",\"payMethodPaneUserGotStoredCC\":false,\"payMethodPaneHasStoredCC\":false,\"payMethodPaneUsedStoredCC\":false,\"payMethodPaneSavedNewCC\":false,\"selectedCreditCard\":{\"payMethodPaneHasCVV\":true},\"payMethodPaneHasCVV\":true}"
						});
						dictionary["requestKey"] = @class.string_10;
						dictionary["hbg"] = @class.string_11;
						dictionary["bb_device_id"] = @class.string_17;
						dictionary["addressBookEnabled"] = "true";
						dictionary["loginHeaderEmailAddress"] = string.Empty;
						dictionary["loginHeaderPassword"] = string.Empty;
						dictionary["loginPaneNewEmailAddress"] = string.Empty;
						dictionary["loginPaneConfirmNewEmailAddress"] = string.Empty;
						dictionary["loginPaneEmailAddress"] = string.Empty;
						dictionary["loginPanePassword"] = string.Empty;
						dictionary["billAddressType"] = "new";
						dictionary["billAddressInputType"] = "single";
						dictionary["billAPOFPOCountry"] = Class43.smethod_0((string)@class.jtoken_1["billing"]["country"], false);
						dictionary["billCountry"] = Class43.smethod_0((string)@class.jtoken_1["billing"]["country"], false);
						dictionary["billMyAddressBookIndex"] = "-1";
						dictionary["billFirstName"] = (string)@class.jtoken_1["billing"]["first_name"];
						dictionary["billLastName"] = (string)@class.jtoken_1["billing"]["last_name"];
						dictionary["billAddress1"] = (string)@class.jtoken_1["billing"]["addr1"];
						dictionary["billAddress2"] = (string)@class.jtoken_1["billing"]["addr2"];
						dictionary["billPostalCode"] = (string)@class.jtoken_1["billing"]["zip"];
						dictionary["billCity"] = (string)@class.jtoken_1["billing"]["city"];
						dictionary["billAPOFPORegion"] = string.Empty;
						dictionary["billState"] = Class43.smethod_1((string)@class.jtoken_1["billing"]["country"], (string)@class.jtoken_1["billing"]["state"]);
						dictionary["billProvince"] = string.Empty;
						dictionary["billAPOFPOState"] = string.Empty;
						dictionary["billAPOFPOPostalCode"] = string.Empty;
						dictionary["billHomePhone"] = (string)@class.jtoken_1["payment"]["phone"];
						dictionary["billEmailAddress"] = (string)@class.jtoken_1["payment"]["email"];
						dictionary["billConfirmEmail"] = (string)@class.jtoken_1["payment"]["email"];
						dictionary["shipAddressType"] = "new";
						dictionary["shipAddressInputType"] = "single";
						dictionary["shipAPOFPOCountry"] = Class43.smethod_0((string)@class.jtoken_1["delivery"]["country"], false);
						dictionary["shipCountry"] = Class43.smethod_0((string)@class.jtoken_1["delivery"]["country"], false);
						dictionary["shipMyAddressBookIndex"] = "-1";
						dictionary["shipToStore"] = "false";
						dictionary["shipFirstName"] = (string)@class.jtoken_1["delivery"]["first_name"];
						dictionary["shipLastName"] = (string)@class.jtoken_1["delivery"]["last_name"];
						dictionary["shipAddress1"] = (string)@class.jtoken_1["delivery"]["addr1"];
						dictionary["shipAddress2"] = (string)@class.jtoken_1["delivery"]["addr2"];
						dictionary["shipPostalCode"] = (string)@class.jtoken_1["delivery"]["zip"];
						dictionary["shipCity"] = (string)@class.jtoken_1["delivery"]["city"];
						dictionary["shipAPOFPORegion"] = string.Empty;
						dictionary["shipState"] = Class43.smethod_1((string)@class.jtoken_1["delivery"]["country"], (string)@class.jtoken_1["delivery"]["state"]);
						dictionary["shipProvince"] = string.Empty;
						dictionary["shipAPOFPOState"] = string.Empty;
						dictionary["shipAPOFPOPostalCode"] = string.Empty;
						dictionary["shipHomePhone"] = (string)@class.jtoken_1["payment"]["phone"];
						dictionary["shipMethodCodeS2S"] = string.Empty;
						dictionary["shipMethodCode"] = @class.string_15;
						dictionary["storePickupInputPostalCode"] = string.Empty;
						dictionary["promoType"] = string.Empty;
						dictionary["CPCOrSourceCode"] = string.Empty;
						dictionary["payMethodPanePayType"] = "CC";
						dictionary["payMethodPanestoredCCCardNumber"] = "CC";
						dictionary["CardNumber"] = ((string)@class.jtoken_1["payment"]["card"]["number"]).Replace(" ", string.Empty);
						dictionary["CardExpireDateMM"] = (string)@class.jtoken_1["payment"]["card"]["exp_month"];
						dictionary["CardExpireDateYY"] = (string)@class.jtoken_1["payment"]["card"]["exp_year"];
						dictionary["CardCCV"] = (string)@class.jtoken_1["payment"]["card"]["cvv"];
						dictionary["payMethodPaneStoredType"] = string.Empty;
						dictionary["payMethodPaneConfirmCardNumber"] = string.Empty;
						dictionary["payMethodPaneStoredCCExpireMonth"] = string.Empty;
						dictionary["payMethodPaneStoredCCExpireYear"] = string.Empty;
						dictionary["payMethodPaneCardType"] = @class.method_16(((string)@class.jtoken_1["payment"]["card"]["number"]).Replace(" ", string.Empty));
						dictionary["payMethodPaneCardNumber"] = ((string)@class.jtoken_1["payment"]["card"]["number"]).Replace(" ", string.Empty);
						dictionary["payMethodPaneExpireMonth"] = (string)@class.jtoken_1["payment"]["card"]["exp_month"];
						dictionary["payMethodPaneExpireYear"] = @class.jtoken_1["payment"]["card"]["exp_year"].ToString()[2].ToString() + @class.jtoken_1["payment"]["card"]["exp_year"].ToString()[3].ToString();
						dictionary["payMethodPaneCVV"] = (string)@class.jtoken_1["payment"]["card"]["cvv"];
						dictionary["payMethodPaneStoredCCCVV"] = string.Empty;
						dictionary["shipProvince"] = Class43.smethod_1((string)@class.jtoken_1["delivery"]["country"], (string)@class.jtoken_1["delivery"]["state"]);
						dictionary["billProvince"] = Class43.smethod_1((string)@class.jtoken_1["billing"]["country"], (string)@class.jtoken_1["billing"]["state"]);
						taskAwaiter6 = @class.class14_0.method_3(string.Format("https://www.{0}/checkout/eventGateway?method=validatePaymentMethodPane", @class.string_9), dictionary, false).GetAwaiter();
						if (!taskAwaiter6.IsCompleted)
						{
							int num7 = 0;
							num = 0;
							num2 = num7;
							TaskAwaiter<HttpResponseMessage> taskAwaiter7 = taskAwaiter6;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class47.Struct61>(ref taskAwaiter6, ref this);
							return;
						}
						break;
					}
					}
					HttpResponseMessage result = taskAwaiter6.GetResult();
					httpResponseMessage = result;
					taskAwaiter8 = @class.method_17(httpResponseMessage).GetAwaiter();
					if (!taskAwaiter8.IsCompleted)
					{
						int num8 = 1;
						num = 1;
						num2 = num8;
						taskAwaiter2 = taskAwaiter8;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, Class47.Struct61>(ref taskAwaiter8, ref this);
						return;
					}
					IL_ED5:
					if (taskAwaiter8.GetResult())
					{
						goto IL_FFD;
					}
					httpResponseMessage.EnsureSuccessStatusCode();
					taskAwaiter9 = httpResponseMessage.smethod_3().GetAwaiter();
					if (!taskAwaiter9.IsCompleted)
					{
						int num9 = 2;
						num = 2;
						num2 = num9;
						TaskAwaiter<string> taskAwaiter10 = taskAwaiter9;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class47.Struct61>(ref taskAwaiter9, ref this);
						return;
					}
					IL_F4B:
					string result2 = taskAwaiter9.GetResult();
					JObject jobject = JObject.Parse(result2.Substring(2, result2.Length - 2));
					if (jobject["RESPONSEERROR"].ToString() != "False")
					{
						throw new Exception();
					}
					@class.string_10 = jobject["REQUESTKEY"].ToString();
					@class.string_11 = jobject["hbg"].ToString();
					goto IL_103F;
				}
				catch
				{
					num10 = 1;
				}
				if (num10 != 1)
				{
					goto IL_FFD;
				}
				@class.method_5("Error submitting payment, retrying", "#c2c2c2", true, false);
				taskAwaiter5 = @class.method_14(Class130.int_1).GetAwaiter();
				if (!taskAwaiter5.IsCompleted)
				{
					int num11 = 3;
					num = 3;
					num2 = num11;
					taskAwaiter4 = taskAwaiter5;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class47.Struct61>(ref taskAwaiter5, ref this);
					return;
				}
				IL_FF6:
				taskAwaiter5.GetResult();
				IL_FFD:
				num10 = 0;
				goto IL_68;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_103F:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x00004F62 File Offset: 0x00003162
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000342 RID: 834
		public int int_0;

		// Token: 0x04000343 RID: 835
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000344 RID: 836
		public Class47 class47_0;

		// Token: 0x04000345 RID: 837
		private HttpResponseMessage httpResponseMessage_0;

		// Token: 0x04000346 RID: 838
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000347 RID: 839
		private TaskAwaiter<bool> taskAwaiter_1;

		// Token: 0x04000348 RID: 840
		private TaskAwaiter<string> taskAwaiter_2;

		// Token: 0x04000349 RID: 841
		private TaskAwaiter taskAwaiter_3;
	}

	// Token: 0x020000CD RID: 205
	[StructLayout(LayoutKind.Auto)]
	private struct Struct62 : IAsyncStateMachine
	{
		// Token: 0x060004DE RID: 1246 RVA: 0x00027F00 File Offset: 0x00026100
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class47 @class = this;
			try
			{
				if (num <= 1)
				{
					goto IL_1E2;
				}
				if (num != 2)
				{
					@class.method_5("Getting request key", "#c2c2c2", true, false);
					Cookie cookie = new Cookie("requestKey", string.Empty);
					cookie.Expired = true;
					@class.class14_0.cookieContainer_0.Add(new Uri(string.Format("https://www.{0}/", @class.string_9)), cookie);
					goto IL_1E0;
				}
				TaskAwaiter taskAwaiter7 = taskAwaiter6;
				taskAwaiter6 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_1D9:
				taskAwaiter7.GetResult();
				IL_1E0:
				int num4 = 0;
				IL_1E2:
				try
				{
					TaskAwaiter<JObject> taskAwaiter8;
					TaskAwaiter<HttpResponseMessage> taskAwaiter9;
					if (num != 0)
					{
						if (num == 1)
						{
							taskAwaiter8 = taskAwaiter4;
							taskAwaiter4 = default(TaskAwaiter<JObject>);
							int num5 = -1;
							num = -1;
							num2 = num5;
							goto IL_177;
						}
						@class.method_5("Getting request key", "#c2c2c2", true, false);
						taskAwaiter9 = @class.class14_0.method_2(string.Format("https://www.{0}/session/", @class.string_9), false).GetAwaiter();
						if (!taskAwaiter9.IsCompleted)
						{
							int num6 = 0;
							num = 0;
							num2 = num6;
							taskAwaiter2 = taskAwaiter9;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class47.Struct62>(ref taskAwaiter9, ref this);
							return;
						}
					}
					else
					{
						taskAwaiter9 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
						int num7 = -1;
						num = -1;
						num2 = num7;
					}
					taskAwaiter8 = taskAwaiter9.GetResult().smethod_1().GetAwaiter();
					if (!taskAwaiter8.IsCompleted)
					{
						int num8 = 1;
						num = 1;
						num2 = num8;
						taskAwaiter4 = taskAwaiter8;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class47.Struct62>(ref taskAwaiter8, ref this);
						return;
					}
					IL_177:
					JObject result = taskAwaiter8.GetResult();
					@class.string_10 = result["data"]["RequestKey"].ToString();
					goto IL_222;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_1E0;
				}
				@class.method_5("Error getting request key", "#c2c2c2", true, false);
				taskAwaiter7 = @class.method_14(Class130.int_1).GetAwaiter();
				if (taskAwaiter7.IsCompleted)
				{
					goto IL_1D9;
				}
				int num9 = 2;
				num = 2;
				num2 = num9;
				taskAwaiter6 = taskAwaiter7;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class47.Struct62>(ref taskAwaiter7, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_222:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x00004F70 File Offset: 0x00003170
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400034A RID: 842
		public int int_0;

		// Token: 0x0400034B RID: 843
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x0400034C RID: 844
		public Class47 class47_0;

		// Token: 0x0400034D RID: 845
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x0400034E RID: 846
		private TaskAwaiter<JObject> taskAwaiter_1;

		// Token: 0x0400034F RID: 847
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x020000CE RID: 206
	[StructLayout(LayoutKind.Auto)]
	private struct Struct63 : IAsyncStateMachine
	{
		// Token: 0x060004E0 RID: 1248 RVA: 0x00028178 File Offset: 0x00026378
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class47 @class = this;
			try
			{
				TaskAwaiter taskAwaiter5;
				if (num > 2)
				{
					if (num != 3)
					{
						@class.cookieCollection_0 = @class.class14_0.cookieContainer_0.GetCookies(new Uri(string.Format("https://www.{0}", @class.string_9)));
						goto IL_B71;
					}
					taskAwaiter5 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter);
					int num3 = -1;
					num = -1;
					num2 = num3;
					goto IL_B6A;
				}
				IL_68:
				int num10;
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter6;
					TaskAwaiter<bool> taskAwaiter8;
					TaskAwaiter<string> taskAwaiter9;
					switch (num)
					{
					case 0:
					{
						TaskAwaiter<HttpResponseMessage> taskAwaiter7;
						taskAwaiter6 = taskAwaiter7;
						taskAwaiter7 = default(TaskAwaiter<HttpResponseMessage>);
						int num4 = -1;
						num = -1;
						num2 = num4;
						break;
					}
					case 1:
					{
						taskAwaiter8 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<bool>);
						int num5 = -1;
						num = -1;
						num2 = num5;
						goto IL_A29;
					}
					case 2:
					{
						TaskAwaiter<string> taskAwaiter10;
						taskAwaiter9 = taskAwaiter10;
						taskAwaiter10 = default(TaskAwaiter<string>);
						int num6 = -1;
						num = -1;
						num2 = num6;
						goto IL_A9F;
					}
					default:
					{
						@class.method_5("Submitting shipping method", "#c2c2c2", true, false);
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary["verifiedCheckoutData"] = string.Format("{{\"maxVisitedPane\":\"shipMethodPane\",\"billMyAddressBookIndex\":\"-1\",\"addressNeedsVerification\":false,\"billFirstName\":\"{0}\",\"billLastName\":\"{1}\",\"billAddress1\":\"{2}\",\"billAddress2\":\"{3}\",\"billCity\":\"{4}\",\"billState\":\"{5}\",\"billProvince\":\"{6}\",\"billPostalCode\":\"{7}\",\"billHomePhone\":\"{8}\",\"billMobilePhone\":\"\",\"billCountry\":\"{9}\",\"billEmailAddress\":\"{10}\",\"billConfirmEmail\":\"{11}\",\"billAddrIsPhysical\":true,\"billSubscribePhone\":false,\"billAbbreviatedAddress\":false,\"shipUpdateDefaultAddress\":false,\"VIPNumber\":\"\",\"accountBillAddress\":{{\"billMyAddressBookIndex\":-1}},\"selectedBillAddress\":{{}},\"billMyAddressBook\":[],\"updateBillingForBML\":false,\"shipMyAddressBookIndex\":-1,\"useBillingAsShipping\":false,\"shipFirstName\":\"{12}\",\"shipLastName\":\"{13}\",\"shipAddress1\":\"{14}\",\"shipAddress2\":\"{15}\",\"shipCity\":\"{16}\",\"shipState\":\"{17}\",\"shipProvince\":\"{18}\",\"shipPostalCode\":\"{19}\",\"shipHomePhone\":\"{20}\",\"shipMobilePhone\":\"\",\"shipCountry\":\"{21}\",\"shipHash\":\"{22}\",\"shipMultiple\":false,\"isShipToStoreEligibleCheckout\":false,\"shipToStore\":false,\"isMultipleAddressEligible\":false,\"shipAbbreviatedAddress\":false,\"selectedStore\":{{}},\"accountShipAddress\":{{\"shipMyAddressBookIndex\":-1}},\"selectedShipAddress\":{{}},\"shipMyAddressBook\":[],\"shipMethodCode\":\"{23}\",\"shipMethodName\":\"{24}\",\"shipMethodPrice\":\"$42.00\",\"shipDeliveryEstimate\":\"\",\"shipMethodCodeSDD\":\"\",\"shipMethodNameSDD\":\"\",\"shipMethodPriceSDD\":\"$0.00\",\"shipDeliveryEstimateSDD\":\"\",\"shipMethodCodeS2S\":\"\",\"shipMethodNameS2S\":\"\",\"shipMethodPriceS2S\":\"$0.00\",\"shipDeliveryEstimateS2S\":\"\",\"shipMethodCodeSFS\":\"\",\"shipMethodNameSFS\":\"\",\"shipMethodPriceSFS\":\"$0.00\",\"shipDeliveryEstimateSFS\":\"\",\"homeDeliveryPrice\":\"$42.00\",\"overallHomeDeliveryPrice\":\"$42.00\",\"aggregatedDeliveryPrice\":\"$42.00\",\"aggregatedDeliveryLabel\":\"\",\"showGiftBoxOption\":false,\"addGiftBox\":false,\"giftBoxPrice\":\"$3.99\",\"useGiftReceipt\":false,\"showGiftOptions\":false,\"loyaltyMessageText\":false,\"showLoyaltyRenewalMessage\":false,\"pickupPersonFirstName\":\"\",\"pickupPersonLastName\":\"\"}}", new object[]
						{
							(string)@class.jtoken_1["billing"]["first_name"],
							(string)@class.jtoken_1["billing"]["last_name"],
							(string)@class.jtoken_1["billing"]["addr1"],
							(string)@class.jtoken_1["billing"]["addr2"],
							(string)@class.jtoken_1["billing"]["city"],
							Class43.smethod_1((string)@class.jtoken_1["billing"]["country"], (string)@class.jtoken_1["billing"]["state"]),
							Class43.smethod_1((string)@class.jtoken_1["billing"]["country"], (string)@class.jtoken_1["billing"]["state"]),
							(string)@class.jtoken_1["billing"]["zip"],
							(string)@class.jtoken_1["payment"]["phone"],
							Class43.smethod_0((string)@class.jtoken_1["billing"]["country"], false),
							(string)@class.jtoken_1["payment"]["email"],
							(string)@class.jtoken_1["payment"]["email"],
							(string)@class.jtoken_1["delivery"]["first_name"],
							(string)@class.jtoken_1["delivery"]["last_name"],
							(string)@class.jtoken_1["delivery"]["addr1"],
							(string)@class.jtoken_1["delivery"]["addr2"],
							(string)@class.jtoken_1["delivery"]["city"],
							Class43.smethod_1((string)@class.jtoken_1["delivery"]["country"], (string)@class.jtoken_1["delivery"]["state"]),
							Class43.smethod_1((string)@class.jtoken_1["delivery"]["country"], (string)@class.jtoken_1["delivery"]["state"]),
							(string)@class.jtoken_1["delivery"]["zip"],
							(string)@class.jtoken_1["payment"]["phone"],
							Class43.smethod_0((string)@class.jtoken_1["delivery"]["country"], false),
							@class.string_13,
							@class.string_15,
							@class.string_14
						});
						dictionary["requestKey"] = @class.string_10;
						dictionary["hbg"] = @class.string_11;
						dictionary["addressBookEnabled"] = "true";
						dictionary["billAddressType"] = "new";
						dictionary["billAddressInputType"] = "single";
						dictionary["billCountry"] = Class43.smethod_0((string)@class.jtoken_1["billing"]["country"], false);
						dictionary["billMyAddressBookIndex"] = "-1";
						dictionary["billFirstName"] = (string)@class.jtoken_1["billing"]["first_name"];
						dictionary["billLastName"] = (string)@class.jtoken_1["billing"]["last_name"];
						dictionary["billAddress1"] = (string)@class.jtoken_1["billing"]["addr1"];
						dictionary["billAddress2"] = (string)@class.jtoken_1["billing"]["addr2"];
						dictionary["billPostalCode"] = (string)@class.jtoken_1["billing"]["zip"];
						dictionary["billCity"] = (string)@class.jtoken_1["billing"]["city"];
						dictionary["billState"] = Class43.smethod_1((string)@class.jtoken_1["billing"]["country"], (string)@class.jtoken_1["billing"]["state"]);
						dictionary["billProvince"] = Class43.smethod_1((string)@class.jtoken_1["billing"]["country"], (string)@class.jtoken_1["billing"]["state"]);
						dictionary["billHomePhone"] = (string)@class.jtoken_1["payment"]["phone"];
						dictionary["billEmailAddress"] = (string)@class.jtoken_1["payment"]["email"];
						dictionary["billConfirmEmail"] = (string)@class.jtoken_1["payment"]["email"];
						dictionary["shipAddressType"] = "different";
						dictionary["shipAddressInputType"] = "single";
						dictionary["shipCountry"] = Class43.smethod_0((string)@class.jtoken_1["delivery"]["country"], false);
						dictionary["shipMyAddressBookIndex"] = "-2";
						dictionary["shipToStore"] = "false";
						dictionary["shipFirstName"] = (string)@class.jtoken_1["delivery"]["first_name"];
						dictionary["shipLastName"] = (string)@class.jtoken_1["delivery"]["last_name"];
						dictionary["shipAddress1"] = (string)@class.jtoken_1["delivery"]["addr1"];
						dictionary["shipAddress2"] = (string)@class.jtoken_1["delivery"]["addr2"];
						dictionary["shipPostalCode"] = (string)@class.jtoken_1["delivery"]["zip"];
						dictionary["shipCity"] = (string)@class.jtoken_1["delivery"]["city"];
						dictionary["shipState"] = Class43.smethod_1((string)@class.jtoken_1["delivery"]["country"], (string)@class.jtoken_1["delivery"]["state"]);
						dictionary["shipProvince"] = Class43.smethod_1((string)@class.jtoken_1["delivery"]["country"], (string)@class.jtoken_1["delivery"]["state"]);
						dictionary["shipHomePhone"] = (string)@class.jtoken_1["payment"]["phone"];
						dictionary["shipMethodCode"] = @class.string_15;
						taskAwaiter6 = @class.class14_0.method_3(string.Format("https://www.{0}/checkout/eventGateway?method=validateShipMethodPane", @class.string_9), dictionary, false).GetAwaiter();
						if (!taskAwaiter6.IsCompleted)
						{
							int num7 = 0;
							num = 0;
							num2 = num7;
							TaskAwaiter<HttpResponseMessage> taskAwaiter7 = taskAwaiter6;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class47.Struct63>(ref taskAwaiter6, ref this);
							return;
						}
						break;
					}
					}
					HttpResponseMessage result = taskAwaiter6.GetResult();
					httpResponseMessage = result;
					taskAwaiter8 = @class.method_17(httpResponseMessage).GetAwaiter();
					if (!taskAwaiter8.IsCompleted)
					{
						int num8 = 1;
						num = 1;
						num2 = num8;
						taskAwaiter2 = taskAwaiter8;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, Class47.Struct63>(ref taskAwaiter8, ref this);
						return;
					}
					IL_A29:
					if (taskAwaiter8.GetResult())
					{
						goto IL_B71;
					}
					httpResponseMessage.EnsureSuccessStatusCode();
					taskAwaiter9 = httpResponseMessage.smethod_3().GetAwaiter();
					if (!taskAwaiter9.IsCompleted)
					{
						int num9 = 2;
						num = 2;
						num2 = num9;
						TaskAwaiter<string> taskAwaiter10 = taskAwaiter9;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class47.Struct63>(ref taskAwaiter9, ref this);
						return;
					}
					IL_A9F:
					string result2 = taskAwaiter9.GetResult();
					JObject jobject = JObject.Parse(result2.Substring(2, result2.Length - 2));
					if (jobject["RESPONSEERROR"].ToString() != "False")
					{
						throw new Exception();
					}
					@class.string_10 = jobject["REQUESTKEY"].ToString();
					@class.string_11 = jobject["hbg"].ToString();
					@class.string_12 = jobject["PAYMENTMETHODPANE"]["LGR"].ToString();
					goto IL_BB3;
				}
				catch
				{
					num10 = 1;
				}
				if (num10 != 1)
				{
					goto IL_B71;
				}
				@class.method_5("Error submitting delivery", "#c2c2c2", true, false);
				taskAwaiter5 = @class.method_14(Class130.int_1).GetAwaiter();
				if (!taskAwaiter5.IsCompleted)
				{
					int num11 = 3;
					num = 3;
					num2 = num11;
					taskAwaiter4 = taskAwaiter5;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class47.Struct63>(ref taskAwaiter5, ref this);
					return;
				}
				IL_B6A:
				taskAwaiter5.GetResult();
				IL_B71:
				num10 = 0;
				goto IL_68;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_BB3:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060004E1 RID: 1249 RVA: 0x00004F7E File Offset: 0x0000317E
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000350 RID: 848
		public int int_0;

		// Token: 0x04000351 RID: 849
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000352 RID: 850
		public Class47 class47_0;

		// Token: 0x04000353 RID: 851
		private HttpResponseMessage httpResponseMessage_0;

		// Token: 0x04000354 RID: 852
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000355 RID: 853
		private TaskAwaiter<bool> taskAwaiter_1;

		// Token: 0x04000356 RID: 854
		private TaskAwaiter<string> taskAwaiter_2;

		// Token: 0x04000357 RID: 855
		private TaskAwaiter taskAwaiter_3;
	}

	// Token: 0x020000CF RID: 207
	[StructLayout(LayoutKind.Auto)]
	private struct Struct64 : IAsyncStateMachine
	{
		// Token: 0x060004E2 RID: 1250 RVA: 0x00028D80 File Offset: 0x00026F80
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class47 @class = this;
			bool result2;
			try
			{
				TaskAwaiter<string> taskAwaiter3;
				TaskAwaiter taskAwaiter5;
				switch (num)
				{
				case 0:
				{
					TaskAwaiter<string> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<string>);
					num2 = -1;
					break;
				}
				case 1:
					taskAwaiter5 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					num2 = -1;
					goto IL_240;
				case 2:
					taskAwaiter5 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					num2 = -1;
					goto IL_26A;
				case 3:
					taskAwaiter5 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					num2 = -1;
					goto IL_2AF;
				case 4:
					taskAwaiter5 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					num2 = -1;
					goto IL_2D6;
				default:
					taskAwaiter3 = httpResponseMessage_0.smethod_3().GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						num2 = 0;
						TaskAwaiter<string> taskAwaiter4 = taskAwaiter3;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class47.Struct64>(ref taskAwaiter3, ref this);
						return;
					}
					break;
				}
				string result = taskAwaiter3.GetResult();
				if (result.Contains("CART_WAIT"))
				{
					taskAwaiter5 = @class.method_22().GetAwaiter();
					if (!taskAwaiter5.IsCompleted)
					{
						num2 = 1;
						taskAwaiter2 = taskAwaiter5;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class47.Struct64>(ref taskAwaiter5, ref this);
						return;
					}
				}
				else
				{
					if (httpResponseMessage_0.StatusCode == HttpStatusCode.Found && httpResponseMessage_0.Headers.Location.ToString() == "https://www.footlocker.eu/")
					{
						@class.method_0("US proxy required", "red", true, (GEnum1)0);
						result2 = false;
						goto IL_2FA;
					}
					if (result.Contains("SESSION_EXPIRED"))
					{
						taskAwaiter5 = @class.method_14(1000).GetAwaiter();
						if (!taskAwaiter5.IsCompleted)
						{
							num2 = 2;
							taskAwaiter2 = taskAwaiter5;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class47.Struct64>(ref taskAwaiter5, ref this);
							return;
						}
						goto IL_26A;
					}
					else if (result.Contains("CART_EMPTY"))
					{
						taskAwaiter5 = @class.method_15().GetAwaiter();
						if (!taskAwaiter5.IsCompleted)
						{
							num2 = 3;
							taskAwaiter2 = taskAwaiter5;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class47.Struct64>(ref taskAwaiter5, ref this);
							return;
						}
						goto IL_2AF;
					}
					else
					{
						if (httpResponseMessage_0.StatusCode != HttpStatusCode.Forbidden)
						{
							result2 = false;
							goto IL_2FA;
						}
						@class.method_5("Banned, retrying", "red", true, false);
						taskAwaiter5 = @class.method_14(Class130.int_1).GetAwaiter();
						if (!taskAwaiter5.IsCompleted)
						{
							num2 = 4;
							taskAwaiter2 = taskAwaiter5;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class47.Struct64>(ref taskAwaiter5, ref this);
							return;
						}
						goto IL_2D6;
					}
				}
				IL_240:
				taskAwaiter5.GetResult();
				result2 = true;
				goto IL_2FA;
				IL_26A:
				taskAwaiter5.GetResult();
				if (@class.cookieCollection_0 != null)
				{
					@class.class14_0.cookieContainer_0.Add(@class.cookieCollection_0);
				}
				result2 = true;
				goto IL_2FA;
				IL_2AF:
				taskAwaiter5.GetResult();
				result2 = true;
				goto IL_2FA;
				IL_2D6:
				taskAwaiter5.GetResult();
				result2 = true;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_2FA:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult(result2);
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x00004F8C File Offset: 0x0000318C
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000358 RID: 856
		public int int_0;

		// Token: 0x04000359 RID: 857
		public AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder_0;

		// Token: 0x0400035A RID: 858
		public HttpResponseMessage httpResponseMessage_0;

		// Token: 0x0400035B RID: 859
		public Class47 class47_0;

		// Token: 0x0400035C RID: 860
		private TaskAwaiter<string> taskAwaiter_0;

		// Token: 0x0400035D RID: 861
		private TaskAwaiter taskAwaiter_1;
	}
}
