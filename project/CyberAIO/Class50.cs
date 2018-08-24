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

// Token: 0x02000107 RID: 263
internal sealed class Class50 : Class44
{
	// Token: 0x060005F1 RID: 1521 RVA: 0x000345E8 File Offset: 0x000327E8
	public Class50(JToken jtoken_2, string string_14, string string_15)
	{
		try
		{
			this.jtoken_0 = jtoken_2;
			this.string_9 = string_15;
			this.string_10 = string_14;
			if (!base.method_2(out this.jtoken_1))
			{
				base.method_0("Profile error", "red", true, (GEnum1)0);
			}
			else
			{
				this.string_7 = (string)jtoken_2["keywords"];
				this.string_0 = (string)jtoken_2["size"];
				if (this.string_0 == "Random" || this.string_0 == "OneSize")
				{
					this.bool_0 = true;
				}
				this.class14_0 = new Class14(base.method_3(), "Mozilla/5.0 (iPhone; CPU iPhone OS 11_4_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/15G77", 10, false, false, null);
				this.class14_0.cookieContainer_0.Add(new Cookie("napMobileApp", "true", "/", ".net-a-porter.com"));
			}
		}
		catch
		{
			base.method_0("Task error", "red", true, (GEnum1)0);
		}
	}

	// Token: 0x060005F2 RID: 1522 RVA: 0x00034720 File Offset: 0x00032920
	public override async void vmethod_0()
	{
		try
		{
			await this.method_16();
			await this.method_17();
			await this.method_19();
			await this.method_18();
			await this.method_20();
			await this.method_21();
			await this.method_22();
		}
		catch
		{
		}
		base.method_0("Stopped", "red", true, (GEnum1)0);
	}

	// Token: 0x060005F3 RID: 1523 RVA: 0x00012FB4 File Offset: 0x000111B4
	public string method_15(string string_14)
	{
		switch (string_14[0])
		{
		case '3':
			return "AMEX";
		case '4':
			return "VISA";
		case '5':
			return "MASTERCARD";
		default:
			return "MASTERCARD";
		}
	}

	// Token: 0x060005F4 RID: 1524 RVA: 0x0003475C File Offset: 0x0003295C
	public async Task method_16()
	{
		base.method_5("Waiting for product", "#c2c2c2", true, false);
		while (!this.bool_1)
		{
			int num = 0;
			TaskAwaiter taskAwaiter2;
			try
			{
				HttpResponseMessage httpResponseMessage = await GClass2.smethod_1(string.Format("https://api.net-a-porter.com/NAP/{0}/en/detail/{1}", this.string_9.ToUpper(), this.string_7), null, true);
				if (httpResponseMessage.StatusCode == HttpStatusCode.NotFound)
				{
					TaskAwaiter taskAwaiter = base.method_14(Class130.int_0).GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						await taskAwaiter;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
					}
					taskAwaiter.GetResult();
					continue;
				}
				httpResponseMessage.EnsureSuccessStatusCode();
				TaskAwaiter<JObject> taskAwaiter3 = httpResponseMessage.smethod_1().GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<JObject> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<JObject>);
				}
				JObject result = taskAwaiter3.GetResult();
				if (result.ContainsKey("message"))
				{
					throw new Exception();
				}
				base.method_7((string)result["name"], "#c2c2c2");
				if (this.bool_0)
				{
					JToken jtoken = result["skus"].Where(new Func<JToken, bool>(Class50.Class143.class143_0.method_0)).smethod_5();
					if (jtoken == null)
					{
						base.method_5("Waiting for restock", "#c2c2c2", true, false);
						TaskAwaiter taskAwaiter = base.method_14(Class130.int_0).GetAwaiter();
						if (!taskAwaiter.IsCompleted)
						{
							await taskAwaiter;
							taskAwaiter = taskAwaiter2;
							taskAwaiter2 = default(TaskAwaiter);
						}
						taskAwaiter.GetResult();
						continue;
					}
					base.method_6((string)jtoken["displaySize"]);
					this.string_8 = (string)jtoken["id"];
				}
				else
				{
					JToken jtoken2 = result["skus"].FirstOrDefault(new Func<JToken, bool>(this.method_23));
					if (jtoken2 == null)
					{
						base.method_5("Waiting for product", "#c2c2c2", true, false);
						TaskAwaiter taskAwaiter = base.method_14(Class130.int_0).GetAwaiter();
						if (!taskAwaiter.IsCompleted)
						{
							await taskAwaiter;
							taskAwaiter = taskAwaiter2;
							taskAwaiter2 = default(TaskAwaiter);
						}
						taskAwaiter.GetResult();
						continue;
					}
					if ((string)jtoken2["stockLevel"] == "Out_of_Stock")
					{
						base.method_5("Waiting for restock", "#c2c2c2", true, false);
						TaskAwaiter taskAwaiter = base.method_14(Class130.int_0).GetAwaiter();
						if (!taskAwaiter.IsCompleted)
						{
							await taskAwaiter;
							taskAwaiter = taskAwaiter2;
							taskAwaiter2 = default(TaskAwaiter);
						}
						taskAwaiter.GetResult();
						continue;
					}
					this.string_8 = (string)jtoken2["id"];
				}
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Waiting for product", "#c2c2c2", true, false);
				TaskAwaiter taskAwaiter = base.method_14(Class130.int_0).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter.GetResult();
			}
		}
	}

	// Token: 0x060005F5 RID: 1525 RVA: 0x000347A4 File Offset: 0x000329A4
	public async Task method_17()
	{
		base.method_5("Adding to cart", "yellow", true, false);
		while (!this.bool_1)
		{
			int num = 0;
			TaskAwaiter taskAwaiter2;
			try
			{
				HttpResponseMessage httpResponseMessage = await this.class14_0.method_2(string.Format("https://www.net-a-porter.com/{0}/en/api/basket/addskus/{1}.nap", this.string_9, this.string_8), false);
				if (httpResponseMessage.StatusCode == HttpStatusCode.Gone)
				{
					base.method_0("Product pulled", "red", true, (GEnum1)0);
				}
				string a = (string)(await httpResponseMessage.smethod_1())["results"][0]["result"];
				if (a == "SIZE_SOLD_OUT")
				{
					base.method_5("Waiting for restock", "#c2c2c2", true, false);
					await base.method_14(Class130.int_0);
					continue;
				}
				if (a == "PRODUCT_NOT_AVAILABLE")
				{
					base.method_5("Waiting for restock", "#c2c2c2", true, false);
					TaskAwaiter taskAwaiter = base.method_14(Class130.int_0).GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						await taskAwaiter;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
					}
					taskAwaiter.GetResult();
					continue;
				}
				if (!(a == "PRODUCT_ADDED"))
				{
					throw new Exception();
				}
				base.method_5("Successfully carted", "#c2c2c2", true, false);
				break;
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
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter.GetResult();
			}
		}
	}

	// Token: 0x060005F6 RID: 1526 RVA: 0x000347EC File Offset: 0x000329EC
	public async Task method_18()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Getting checkout", "#c2c2c2", true, false);
				(await this.class14_0.method_2(string.Format("https://www.net-a-porter.com/{0}/en/purchasepath.nap", this.string_9), true)).EnsureSuccessStatusCode();
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error getting checkout", "#c2c2c2", true, false);
				TaskAwaiter taskAwaiter = base.method_14(Class130.int_1).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter.GetResult();
				continue;
			}
		}
	}

	// Token: 0x060005F7 RID: 1527 RVA: 0x00034834 File Offset: 0x00032A34
	public async Task method_19()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				this.class14_0.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("Referer", string.Format("https://www.net-a-porter.com/{0}/en/signinpurchasepath.nap", this.string_9));
				base.method_5("Logging in", "#c2c2c2", true, false);
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary["j_username"] = (this.string_13.Any(new Func<string, bool>(this.method_24)) ? string.Format("{0}+{1}@{2}", this.jtoken_1["payment"]["email"].ToString().Split(new char[]
				{
					'@'
				})[0], MainWindow.random_0.Next(1, 9999).ToString(), this.jtoken_1["payment"]["email"].ToString().Split(new char[]
				{
					'@'
				}).Last<string>()) : this.jtoken_1["payment"]["email"].ToString());
				dictionary["didProvideAPassword"] = "no";
				dictionary["sourceForm"] = "guestcheckout";
				HttpResponseMessage httpResponseMessage = await this.class14_0.method_3(string.Format("https://www.net-a-porter.com/{0}/en/j_spring_security_check", this.string_9), dictionary, false);
				if (httpResponseMessage.StatusCode != HttpStatusCode.Found || !httpResponseMessage.Headers.Location.ToString().Contains("/myaccount"))
				{
					throw new Exception();
				}
				this.string_10 = httpResponseMessage.Headers.Location.ToString().Split(new char[]
				{
					'/'
				}).Reverse<string>().ToList<string>()[1];
				this.class14_0.httpClient_0.DefaultRequestHeaders.Remove("Referer");
				base.method_5(string.Format("Found store channel: {0}", this.string_10), "#c2c2c2", true, false);
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error logging in", "#c2c2c2", true, false);
				TaskAwaiter taskAwaiter = base.method_14(Class130.int_1).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter.GetResult();
				continue;
			}
		}
	}

	// Token: 0x060005F8 RID: 1528 RVA: 0x0003487C File Offset: 0x00032A7C
	public async Task method_20()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Submitting shipping", "#c2c2c2", true, false);
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary["addressType"] = "_SHIPPING";
				dictionary["address.title"] = "Mr";
				dictionary["address.firstName"] = (string)this.jtoken_1["delivery"]["first_name"];
				dictionary["address.lastName"] = (string)this.jtoken_1["delivery"]["last_name"];
				dictionary["address.countryLookup"] = Class43.smethod_0((string)this.jtoken_1["delivery"]["country"], false);
				dictionary["address.address1"] = (string)this.jtoken_1["delivery"]["addr1"];
				dictionary["address.towncity"] = (string)this.jtoken_1["delivery"]["city"];
				dictionary["address.state"] = Class43.smethod_1((string)this.jtoken_1["delivery"]["country"], (string)this.jtoken_1["delivery"]["state"]);
				dictionary["address.postcode"] = (string)this.jtoken_1["delivery"]["zip"];
				dictionary["address.work"] = (string)this.jtoken_1["payment"]["phone"];
				dictionary["signatureRequired"] = "false";
				dictionary["stickerDetails.stickerOption"] = "FOR_ME";
				dictionary["deliveryAndBillingSame"] = "true";
				dictionary["_eventId_proceedToPurchase"] = "Proceed to purchase";
				dictionary["_flowExecutionKey"] = "e1s2";
				dictionary["eventId"] = "eventIdNotSet";
				TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class14_0.method_3(string.Format("https://www.net-a-porter.com/{0}/{1}/en/purchasepath.nap?execution=e1s1", this.string_10, this.string_9), dictionary, true).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter<HttpResponseMessage> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
				}
				HttpResponseMessage result = taskAwaiter.GetResult();
				result.EnsureSuccessStatusCode();
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
				this.string_11 = htmlDocument.DocumentNode.SelectNodes("//input[@name='selectedShippingMethodId']").Last<HtmlNode>().Attributes["value"].Value;
				this.string_12 = htmlDocument.DocumentNode.SelectNodes("//input[@name='selectedPackagingOptionId']").First<HtmlNode>().Attributes["value"].Value;
				base.method_5(string.Format("Found shipping method ID: {0}", this.string_11), "#c2c2c2", true, false);
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error submitting shipping", "#c2c2c2", true, false);
				TaskAwaiter taskAwaiter5 = base.method_14(Class130.int_1).GetAwaiter();
				if (!taskAwaiter5.IsCompleted)
				{
					await taskAwaiter5;
					TaskAwaiter taskAwaiter6;
					taskAwaiter5 = taskAwaiter6;
					taskAwaiter6 = default(TaskAwaiter);
				}
				taskAwaiter5.GetResult();
				continue;
			}
		}
	}

	// Token: 0x060005F9 RID: 1529 RVA: 0x000348C4 File Offset: 0x00032AC4
	public async Task method_21()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Submitting shipping method", "#c2c2c2", true, false);
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary["selectedShippingMethodId"] = this.string_11;
				dictionary["selectedPackagingOptionId"] = this.string_12;
				dictionary["signatureRequired"] = "false";
				dictionary["stickerDetails.stickerOption"] = "FOR_ME";
				dictionary["_eventId_proceedToPurchase"] = "Proceed to purchase";
				dictionary["_flowExecutionKey"] = "e1s2";
				dictionary["eventId"] = "eventIdNotSet";
				TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class14_0.method_3(string.Format("https://www.net-a-porter.com/{0}/{1}/en/purchasepath.nap?execution=e1s2", this.string_10, this.string_9), dictionary, true).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter<HttpResponseMessage> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
				}
				HttpResponseMessage result = taskAwaiter.GetResult();
				result.EnsureSuccessStatusCode();
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
				string value = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='paymentSessionId']").Attributes["value"].Value;
				string value2 = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='customerId']").Attributes["value"].Value;
				string value3 = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='site']").Attributes["value"].Value;
				string value4 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='redirectUrl']").Attributes["value"].Value;
				this.dictionary_0["redirectUrl"] = value4;
				this.dictionary_0["adminId"] = "0";
				this.dictionary_0["cardType"] = this.method_15((string)this.jtoken_1["payment"]["card"]["number"]);
				this.dictionary_0["savedCard"] = "false";
				this.dictionary_0["cardNumber"] = this.jtoken_1["payment"]["card"]["number"].ToString().Replace(" ", string.Empty);
				this.dictionary_0["cardHoldersName"] = this.jtoken_1["billing"]["first_name"] + " " + this.jtoken_1["billing"]["last_name"];
				this.dictionary_0["cVSNumber"] = (string)this.jtoken_1["payment"]["card"]["cvv"];
				this.dictionary_0["expiryMonth"] = (string)this.jtoken_1["payment"]["card"]["exp_month"];
				this.dictionary_0["expiryYear"] = this.jtoken_1["payment"]["card"]["exp_year"].ToString()[2].ToString() + this.jtoken_1["payment"]["card"]["exp_year"].ToString()[3].ToString();
				this.dictionary_0["issueNumber"] = string.Empty;
				this.dictionary_0["keepCard"] = "false";
				this.dictionary_0["paymentSessionId"] = value;
				this.dictionary_0["customerId"] = value2;
				this.dictionary_0["site"] = value3;
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error submitting shipping method", "#c2c2c2", true, false);
				TaskAwaiter taskAwaiter5 = base.method_14(Class130.int_1).GetAwaiter();
				if (!taskAwaiter5.IsCompleted)
				{
					await taskAwaiter5;
					TaskAwaiter taskAwaiter6;
					taskAwaiter5 = taskAwaiter6;
					taskAwaiter6 = default(TaskAwaiter);
				}
				taskAwaiter5.GetResult();
				continue;
			}
		}
	}

	// Token: 0x060005FA RID: 1530 RVA: 0x0003490C File Offset: 0x00032B0C
	public async Task method_22()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Submitting payment", "orange", true, false);
				TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class14_0.method_3("https://secure.net-a-porter.com/psp/payment", this.dictionary_0, true).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter<HttpResponseMessage> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
				}
				HttpResponseMessage result = taskAwaiter.GetResult();
				result.EnsureSuccessStatusCode();
				TaskAwaiter<string> taskAwaiter3 = result.smethod_3().GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<string> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<string>);
				}
				string result2 = taskAwaiter3.GetResult();
				if (result2.Contains("your payment has not been authorized"))
				{
					base.method_0("Payment Declined", "red", true, (GEnum1)5);
				}
				else if (result2.Contains("Order confirmation"))
				{
					base.method_0("Successfully checked out", "green", true, (GEnum1)6);
				}
				else
				{
					base.method_0("Payment error", "red", true, (GEnum1)0);
				}
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error submitting payment", "#c2c2c2", true, false);
				TaskAwaiter taskAwaiter5 = base.method_14(Class130.int_1).GetAwaiter();
				if (!taskAwaiter5.IsCompleted)
				{
					await taskAwaiter5;
					TaskAwaiter taskAwaiter6;
					taskAwaiter5 = taskAwaiter6;
					taskAwaiter6 = default(TaskAwaiter);
				}
				taskAwaiter5.GetResult();
				continue;
			}
		}
	}

	// Token: 0x060005FB RID: 1531 RVA: 0x00003E3D File Offset: 0x0000203D
	private bool method_23(JToken jtoken_2)
	{
		return Class43.smethod_2(this.string_0, (string)jtoken_2["displaySize"]);
	}

	// Token: 0x060005FC RID: 1532 RVA: 0x00003E5A File Offset: 0x0000205A
	private bool method_24(string string_14)
	{
		return this.jtoken_1["payment"]["email"].ToString().Contains(string_14);
	}

	// Token: 0x0400049D RID: 1181
	private string string_7;

	// Token: 0x0400049E RID: 1182
	private string string_8;

	// Token: 0x0400049F RID: 1183
	private string string_9;

	// Token: 0x040004A0 RID: 1184
	private string string_10;

	// Token: 0x040004A1 RID: 1185
	private string string_11;

	// Token: 0x040004A2 RID: 1186
	private string string_12;

	// Token: 0x040004A3 RID: 1187
	private Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();

	// Token: 0x040004A4 RID: 1188
	private string[] string_13 = new string[]
	{
		"gmail.com",
		"cybersole.io"
	};

	// Token: 0x02000108 RID: 264
	[Serializable]
	private sealed class Class143
	{
		// Token: 0x060005FF RID: 1535 RVA: 0x00003E8D File Offset: 0x0000208D
		internal bool method_0(JToken jtoken_0)
		{
			return (string)jtoken_0["stockLevel"] != "Out_of_Stock";
		}

		// Token: 0x040004A5 RID: 1189
		public static readonly Class50.Class143 class143_0 = new Class50.Class143();

		// Token: 0x040004A6 RID: 1190
		public static Func<JToken, bool> func_0;
	}

	// Token: 0x02000109 RID: 265
	[StructLayout(LayoutKind.Auto)]
	private struct Struct95 : IAsyncStateMachine
	{
		// Token: 0x06000600 RID: 1536 RVA: 0x00034954 File Offset: 0x00032B54
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class50 @class = this;
			try
			{
				if (num <= 1)
				{
					goto IL_43E;
				}
				if (num != 2)
				{
					goto IL_434;
				}
				TaskAwaiter taskAwaiter7 = taskAwaiter6;
				taskAwaiter6 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_42D:
				taskAwaiter7.GetResult();
				IL_434:
				if (@class.bool_1)
				{
					goto IL_480;
				}
				int num4 = 0;
				IL_43E:
				try
				{
					TaskAwaiter<string> taskAwaiter8;
					TaskAwaiter<HttpResponseMessage> taskAwaiter9;
					if (num != 0)
					{
						if (num == 1)
						{
							taskAwaiter8 = taskAwaiter4;
							taskAwaiter4 = default(TaskAwaiter<string>);
							int num5 = -1;
							num = -1;
							num2 = num5;
							goto IL_350;
						}
						@class.method_5("Submitting shipping", "#c2c2c2", true, false);
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary["addressType"] = "_SHIPPING";
						dictionary["address.title"] = "Mr";
						dictionary["address.firstName"] = (string)@class.jtoken_1["delivery"]["first_name"];
						dictionary["address.lastName"] = (string)@class.jtoken_1["delivery"]["last_name"];
						dictionary["address.countryLookup"] = Class43.smethod_0((string)@class.jtoken_1["delivery"]["country"], false);
						dictionary["address.address1"] = (string)@class.jtoken_1["delivery"]["addr1"];
						dictionary["address.towncity"] = (string)@class.jtoken_1["delivery"]["city"];
						dictionary["address.state"] = Class43.smethod_1((string)@class.jtoken_1["delivery"]["country"], (string)@class.jtoken_1["delivery"]["state"]);
						dictionary["address.postcode"] = (string)@class.jtoken_1["delivery"]["zip"];
						dictionary["address.work"] = (string)@class.jtoken_1["payment"]["phone"];
						dictionary["signatureRequired"] = "false";
						dictionary["stickerDetails.stickerOption"] = "FOR_ME";
						dictionary["deliveryAndBillingSame"] = "true";
						dictionary["_eventId_proceedToPurchase"] = "Proceed to purchase";
						dictionary["_flowExecutionKey"] = "e1s2";
						dictionary["eventId"] = "eventIdNotSet";
						taskAwaiter9 = @class.class14_0.method_3(string.Format("https://www.net-a-porter.com/{0}/{1}/en/purchasepath.nap?execution=e1s1", @class.string_10, @class.string_9), dictionary, true).GetAwaiter();
						if (!taskAwaiter9.IsCompleted)
						{
							int num6 = 0;
							num = 0;
							num2 = num6;
							taskAwaiter2 = taskAwaiter9;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class50.Struct95>(ref taskAwaiter9, ref this);
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
					HttpResponseMessage result = taskAwaiter9.GetResult();
					result.EnsureSuccessStatusCode();
					htmlDocument = new HtmlDocument();
					htmlDocument2 = htmlDocument;
					taskAwaiter8 = result.smethod_3().GetAwaiter();
					if (!taskAwaiter8.IsCompleted)
					{
						int num8 = 1;
						num = 1;
						num2 = num8;
						taskAwaiter4 = taskAwaiter8;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class50.Struct95>(ref taskAwaiter8, ref this);
						return;
					}
					IL_350:
					string result2 = taskAwaiter8.GetResult();
					htmlDocument2.LoadHtml(result2);
					htmlDocument2 = null;
					@class.string_11 = htmlDocument.DocumentNode.SelectNodes("//input[@name='selectedShippingMethodId']").Last<HtmlNode>().Attributes["value"].Value;
					@class.string_12 = htmlDocument.DocumentNode.SelectNodes("//input[@name='selectedPackagingOptionId']").First<HtmlNode>().Attributes["value"].Value;
					@class.method_5(string.Format("Found shipping method ID: {0}", @class.string_11), "#c2c2c2", true, false);
					goto IL_480;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_434;
				}
				@class.method_5("Error submitting shipping", "#c2c2c2", true, false);
				taskAwaiter7 = @class.method_14(Class130.int_1).GetAwaiter();
				if (taskAwaiter7.IsCompleted)
				{
					goto IL_42D;
				}
				int num9 = 2;
				num = 2;
				num2 = num9;
				taskAwaiter6 = taskAwaiter7;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class50.Struct95>(ref taskAwaiter7, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_480:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000601 RID: 1537 RVA: 0x000057BD File Offset: 0x000039BD
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040004A7 RID: 1191
		public int int_0;

		// Token: 0x040004A8 RID: 1192
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040004A9 RID: 1193
		public Class50 class50_0;

		// Token: 0x040004AA RID: 1194
		private HtmlDocument htmlDocument_0;

		// Token: 0x040004AB RID: 1195
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040004AC RID: 1196
		private HtmlDocument htmlDocument_1;

		// Token: 0x040004AD RID: 1197
		private TaskAwaiter<string> taskAwaiter_1;

		// Token: 0x040004AE RID: 1198
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x0200010A RID: 266
	[StructLayout(LayoutKind.Auto)]
	private struct Struct96 : IAsyncStateMachine
	{
		// Token: 0x06000602 RID: 1538 RVA: 0x00034E28 File Offset: 0x00033028
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class50 @class = this;
			try
			{
				TaskAwaiter taskAwaiter3;
				if (num > 3)
				{
					if (num != 4)
					{
						@class.method_5("Adding to cart", "yellow", true, false);
						goto IL_2FA;
					}
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					int num3 = -1;
					num = -1;
					num2 = num3;
					goto IL_2E9;
				}
				IL_4E:
				int num12;
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
						int num4 = -1;
						num = -1;
						num2 = num4;
						break;
					}
					case 1:
					{
						TaskAwaiter<JObject> taskAwaiter7;
						taskAwaiter6 = taskAwaiter7;
						taskAwaiter7 = default(TaskAwaiter<JObject>);
						int num5 = -1;
						num = -1;
						num2 = num5;
						goto IL_154;
					}
					case 2:
					{
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num6 = -1;
						num = -1;
						num2 = num6;
						goto IL_284;
					}
					case 3:
					{
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num7 = -1;
						num = -1;
						num2 = num7;
						goto IL_2A9;
					}
					default:
						taskAwaiter4 = @class.class14_0.method_2(string.Format("https://www.net-a-porter.com/{0}/en/api/basket/addskus/{1}.nap", @class.string_9, @class.string_8), false).GetAwaiter();
						if (!taskAwaiter4.IsCompleted)
						{
							int num8 = 0;
							num = 0;
							num2 = num8;
							TaskAwaiter<HttpResponseMessage> taskAwaiter5 = taskAwaiter4;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class50.Struct96>(ref taskAwaiter4, ref this);
							return;
						}
						break;
					}
					HttpResponseMessage result = taskAwaiter4.GetResult();
					if (result.StatusCode == HttpStatusCode.Gone)
					{
						@class.method_0("Product pulled", "red", true, (GEnum1)0);
					}
					taskAwaiter6 = result.smethod_1().GetAwaiter();
					if (!taskAwaiter6.IsCompleted)
					{
						int num9 = 1;
						num = 1;
						num2 = num9;
						TaskAwaiter<JObject> taskAwaiter7 = taskAwaiter6;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class50.Struct96>(ref taskAwaiter6, ref this);
						return;
					}
					IL_154:
					string a = (string)taskAwaiter6.GetResult()["results"][0]["result"];
					if (!(a == "SIZE_SOLD_OUT"))
					{
						if (!(a == "PRODUCT_NOT_AVAILABLE"))
						{
							if (!(a == "PRODUCT_ADDED"))
							{
								throw new Exception();
							}
							@class.method_5("Successfully carted", "#c2c2c2", true, false);
							goto IL_33F;
						}
						else
						{
							@class.method_5("Waiting for restock", "#c2c2c2", true, false);
							taskAwaiter3 = @class.method_14(Class130.int_0).GetAwaiter();
							if (!taskAwaiter3.IsCompleted)
							{
								int num10 = 3;
								num = 3;
								num2 = num10;
								taskAwaiter2 = taskAwaiter3;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class50.Struct96>(ref taskAwaiter3, ref this);
								return;
							}
							goto IL_2A9;
						}
					}
					else
					{
						@class.method_5("Waiting for restock", "#c2c2c2", true, false);
						taskAwaiter3 = @class.method_14(Class130.int_0).GetAwaiter();
						if (!taskAwaiter3.IsCompleted)
						{
							int num11 = 2;
							num = 2;
							num2 = num11;
							taskAwaiter2 = taskAwaiter3;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class50.Struct96>(ref taskAwaiter3, ref this);
							return;
						}
					}
					IL_284:
					taskAwaiter3.GetResult();
					goto IL_2FA;
					IL_2A9:
					taskAwaiter3.GetResult();
					goto IL_2FA;
				}
				catch
				{
					num12 = 1;
				}
				if (num12 != 1)
				{
					goto IL_2FA;
				}
				@class.method_5("Error adding to cart", "#c2c2c2", true, false);
				taskAwaiter3 = @class.method_14(Class130.int_1).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					int num13 = 4;
					num = 4;
					num2 = num13;
					taskAwaiter2 = taskAwaiter3;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class50.Struct96>(ref taskAwaiter3, ref this);
					return;
				}
				IL_2E9:
				taskAwaiter3.GetResult();
				IL_2FA:
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
			IL_33F:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000603 RID: 1539 RVA: 0x000057CB File Offset: 0x000039CB
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040004AF RID: 1199
		public int int_0;

		// Token: 0x040004B0 RID: 1200
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040004B1 RID: 1201
		public Class50 class50_0;

		// Token: 0x040004B2 RID: 1202
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040004B3 RID: 1203
		private TaskAwaiter<JObject> taskAwaiter_1;

		// Token: 0x040004B4 RID: 1204
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x0200010B RID: 267
	[StructLayout(LayoutKind.Auto)]
	private struct Struct97 : IAsyncStateMachine
	{
		// Token: 0x06000604 RID: 1540 RVA: 0x000351BC File Offset: 0x000333BC
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class50 @class = this;
			try
			{
				if (num <= 1)
				{
					goto IL_545;
				}
				if (num != 2)
				{
					goto IL_53B;
				}
				TaskAwaiter taskAwaiter7 = taskAwaiter6;
				taskAwaiter6 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_534:
				taskAwaiter7.GetResult();
				IL_53B:
				if (@class.bool_1)
				{
					goto IL_587;
				}
				int num4 = 0;
				IL_545:
				try
				{
					TaskAwaiter<string> taskAwaiter8;
					TaskAwaiter<HttpResponseMessage> taskAwaiter9;
					if (num != 0)
					{
						if (num == 1)
						{
							taskAwaiter8 = taskAwaiter4;
							taskAwaiter4 = default(TaskAwaiter<string>);
							int num5 = -1;
							num = -1;
							num2 = num5;
							goto IL_1C8;
						}
						@class.method_5("Submitting shipping method", "#c2c2c2", true, false);
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary["selectedShippingMethodId"] = @class.string_11;
						dictionary["selectedPackagingOptionId"] = @class.string_12;
						dictionary["signatureRequired"] = "false";
						dictionary["stickerDetails.stickerOption"] = "FOR_ME";
						dictionary["_eventId_proceedToPurchase"] = "Proceed to purchase";
						dictionary["_flowExecutionKey"] = "e1s2";
						dictionary["eventId"] = "eventIdNotSet";
						taskAwaiter9 = @class.class14_0.method_3(string.Format("https://www.net-a-porter.com/{0}/{1}/en/purchasepath.nap?execution=e1s2", @class.string_10, @class.string_9), dictionary, true).GetAwaiter();
						if (!taskAwaiter9.IsCompleted)
						{
							int num6 = 0;
							num = 0;
							num2 = num6;
							taskAwaiter2 = taskAwaiter9;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class50.Struct97>(ref taskAwaiter9, ref this);
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
					HttpResponseMessage result = taskAwaiter9.GetResult();
					result.EnsureSuccessStatusCode();
					htmlDocument = new HtmlDocument();
					htmlDocument2 = htmlDocument;
					taskAwaiter8 = result.smethod_3().GetAwaiter();
					if (!taskAwaiter8.IsCompleted)
					{
						int num8 = 1;
						num = 1;
						num2 = num8;
						taskAwaiter4 = taskAwaiter8;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class50.Struct97>(ref taskAwaiter8, ref this);
						return;
					}
					IL_1C8:
					string result2 = taskAwaiter8.GetResult();
					htmlDocument2.LoadHtml(result2);
					htmlDocument2 = null;
					string value = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='paymentSessionId']").Attributes["value"].Value;
					string value2 = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='customerId']").Attributes["value"].Value;
					string value3 = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='site']").Attributes["value"].Value;
					string value4 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='redirectUrl']").Attributes["value"].Value;
					@class.dictionary_0["redirectUrl"] = value4;
					@class.dictionary_0["adminId"] = "0";
					@class.dictionary_0["cardType"] = @class.method_15((string)@class.jtoken_1["payment"]["card"]["number"]);
					@class.dictionary_0["savedCard"] = "false";
					@class.dictionary_0["cardNumber"] = @class.jtoken_1["payment"]["card"]["number"].ToString().Replace(" ", string.Empty);
					@class.dictionary_0["cardHoldersName"] = @class.jtoken_1["billing"]["first_name"] + " " + @class.jtoken_1["billing"]["last_name"];
					@class.dictionary_0["cVSNumber"] = (string)@class.jtoken_1["payment"]["card"]["cvv"];
					@class.dictionary_0["expiryMonth"] = (string)@class.jtoken_1["payment"]["card"]["exp_month"];
					@class.dictionary_0["expiryYear"] = @class.jtoken_1["payment"]["card"]["exp_year"].ToString()[2].ToString() + @class.jtoken_1["payment"]["card"]["exp_year"].ToString()[3].ToString();
					@class.dictionary_0["issueNumber"] = string.Empty;
					@class.dictionary_0["keepCard"] = "false";
					@class.dictionary_0["paymentSessionId"] = value;
					@class.dictionary_0["customerId"] = value2;
					@class.dictionary_0["site"] = value3;
					goto IL_587;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_53B;
				}
				@class.method_5("Error submitting shipping method", "#c2c2c2", true, false);
				taskAwaiter7 = @class.method_14(Class130.int_1).GetAwaiter();
				if (taskAwaiter7.IsCompleted)
				{
					goto IL_534;
				}
				int num9 = 2;
				num = 2;
				num2 = num9;
				taskAwaiter6 = taskAwaiter7;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class50.Struct97>(ref taskAwaiter7, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_587:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000605 RID: 1541 RVA: 0x000057D9 File Offset: 0x000039D9
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040004B5 RID: 1205
		public int int_0;

		// Token: 0x040004B6 RID: 1206
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040004B7 RID: 1207
		public Class50 class50_0;

		// Token: 0x040004B8 RID: 1208
		private HtmlDocument htmlDocument_0;

		// Token: 0x040004B9 RID: 1209
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040004BA RID: 1210
		private HtmlDocument htmlDocument_1;

		// Token: 0x040004BB RID: 1211
		private TaskAwaiter<string> taskAwaiter_1;

		// Token: 0x040004BC RID: 1212
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x0200010C RID: 268
	[StructLayout(LayoutKind.Auto)]
	private struct Struct98 : IAsyncStateMachine
	{
		// Token: 0x06000606 RID: 1542 RVA: 0x00035798 File Offset: 0x00033998
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class50 @class = this;
			try
			{
				TaskAwaiter taskAwaiter5;
				if (num > 5)
				{
					if (num != 6)
					{
						@class.method_5("Waiting for product", "#c2c2c2", true, false);
						goto IL_478;
					}
					taskAwaiter5 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					int num3 = -1;
					num = -1;
					num2 = num3;
					goto IL_467;
				}
				IL_4E:
				int num16;
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter6;
					TaskAwaiter<JObject> taskAwaiter8;
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
						taskAwaiter5 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num5 = -1;
						num = -1;
						num2 = num5;
						goto IL_196;
					}
					case 2:
					{
						taskAwaiter8 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<JObject>);
						int num6 = -1;
						num = -1;
						num2 = num6;
						goto IL_1BF;
					}
					case 3:
					{
						taskAwaiter5 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num7 = -1;
						num = -1;
						num2 = num7;
						goto IL_3DA;
					}
					case 4:
					{
						taskAwaiter5 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num8 = -1;
						num = -1;
						num2 = num8;
						goto IL_402;
					}
					case 5:
					{
						taskAwaiter5 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num9 = -1;
						num = -1;
						num2 = num9;
						goto IL_427;
					}
					default:
						taskAwaiter6 = GClass2.smethod_1(string.Format("https://api.net-a-porter.com/NAP/{0}/en/detail/{1}", @class.string_9.ToUpper(), @class.string_7), null, true).GetAwaiter();
						if (!taskAwaiter6.IsCompleted)
						{
							int num10 = 0;
							num = 0;
							num2 = num10;
							TaskAwaiter<HttpResponseMessage> taskAwaiter7 = taskAwaiter6;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class50.Struct98>(ref taskAwaiter6, ref this);
							return;
						}
						break;
					}
					HttpResponseMessage result = taskAwaiter6.GetResult();
					if (result.StatusCode == HttpStatusCode.NotFound)
					{
						taskAwaiter5 = @class.method_14(Class130.int_0).GetAwaiter();
						if (!taskAwaiter5.IsCompleted)
						{
							int num11 = 1;
							num = 1;
							num2 = num11;
							taskAwaiter2 = taskAwaiter5;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class50.Struct98>(ref taskAwaiter5, ref this);
							return;
						}
					}
					else
					{
						result.EnsureSuccessStatusCode();
						taskAwaiter8 = result.smethod_1().GetAwaiter();
						if (!taskAwaiter8.IsCompleted)
						{
							int num12 = 2;
							num = 2;
							num2 = num12;
							taskAwaiter4 = taskAwaiter8;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class50.Struct98>(ref taskAwaiter8, ref this);
							return;
						}
						goto IL_1BF;
					}
					IL_196:
					taskAwaiter5.GetResult();
					goto IL_478;
					IL_1BF:
					JObject result2 = taskAwaiter8.GetResult();
					if (result2.ContainsKey("message"))
					{
						throw new Exception();
					}
					@class.method_7((string)result2["name"], "#c2c2c2");
					if (@class.bool_0)
					{
						JToken jtoken = result2["skus"].Where(new Func<JToken, bool>(Class50.Class143.class143_0.method_0)).smethod_5();
						if (jtoken == null)
						{
							@class.method_5("Waiting for restock", "#c2c2c2", true, false);
							taskAwaiter5 = @class.method_14(Class130.int_0).GetAwaiter();
							if (!taskAwaiter5.IsCompleted)
							{
								int num13 = 3;
								num = 3;
								num2 = num13;
								taskAwaiter2 = taskAwaiter5;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class50.Struct98>(ref taskAwaiter5, ref this);
								return;
							}
							goto IL_3DA;
						}
						else
						{
							@class.method_6((string)jtoken["displaySize"]);
							@class.string_8 = (string)jtoken["id"];
						}
					}
					else
					{
						JToken jtoken2 = result2["skus"].FirstOrDefault(new Func<JToken, bool>(@class.method_23));
						if (jtoken2 == null)
						{
							@class.method_5("Waiting for product", "#c2c2c2", true, false);
							taskAwaiter5 = @class.method_14(Class130.int_0).GetAwaiter();
							if (!taskAwaiter5.IsCompleted)
							{
								int num14 = 4;
								num = 4;
								num2 = num14;
								taskAwaiter2 = taskAwaiter5;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class50.Struct98>(ref taskAwaiter5, ref this);
								return;
							}
							goto IL_402;
						}
						else if ((string)jtoken2["stockLevel"] == "Out_of_Stock")
						{
							@class.method_5("Waiting for restock", "#c2c2c2", true, false);
							taskAwaiter5 = @class.method_14(Class130.int_0).GetAwaiter();
							if (!taskAwaiter5.IsCompleted)
							{
								int num15 = 5;
								num = 5;
								num2 = num15;
								taskAwaiter2 = taskAwaiter5;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class50.Struct98>(ref taskAwaiter5, ref this);
								return;
							}
							goto IL_427;
						}
						else
						{
							@class.string_8 = (string)jtoken2["id"];
						}
					}
					goto IL_4BD;
					IL_3DA:
					taskAwaiter5.GetResult();
					goto IL_478;
					IL_402:
					taskAwaiter5.GetResult();
					goto IL_478;
					IL_427:
					taskAwaiter5.GetResult();
					goto IL_478;
				}
				catch
				{
					num16 = 1;
				}
				if (num16 != 1)
				{
					goto IL_478;
				}
				@class.method_5("Waiting for product", "#c2c2c2", true, false);
				taskAwaiter5 = @class.method_14(Class130.int_0).GetAwaiter();
				if (!taskAwaiter5.IsCompleted)
				{
					int num17 = 6;
					num = 6;
					num2 = num17;
					taskAwaiter2 = taskAwaiter5;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class50.Struct98>(ref taskAwaiter5, ref this);
					return;
				}
				IL_467:
				taskAwaiter5.GetResult();
				IL_478:
				if (!@class.bool_1)
				{
					num16 = 0;
					goto IL_4E;
				}
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_4BD:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000607 RID: 1543 RVA: 0x000057E7 File Offset: 0x000039E7
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040004BD RID: 1213
		public int int_0;

		// Token: 0x040004BE RID: 1214
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040004BF RID: 1215
		public Class50 class50_0;

		// Token: 0x040004C0 RID: 1216
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040004C1 RID: 1217
		private TaskAwaiter taskAwaiter_1;

		// Token: 0x040004C2 RID: 1218
		private TaskAwaiter<JObject> taskAwaiter_2;
	}

	// Token: 0x0200010D RID: 269
	[StructLayout(LayoutKind.Auto)]
	private struct Struct99 : IAsyncStateMachine
	{
		// Token: 0x06000608 RID: 1544 RVA: 0x00035CAC File Offset: 0x00033EAC
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class50 @class = this;
			try
			{
				if (num == 0)
				{
					goto IL_2DA;
				}
				if (num != 1)
				{
					goto IL_2CF;
				}
				TaskAwaiter taskAwaiter3 = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_2C8:
				taskAwaiter3.GetResult();
				IL_2CF:
				if (@class.bool_1)
				{
					goto IL_31C;
				}
				int num4 = 0;
				IL_2DA:
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter4;
					if (num != 0)
					{
						@class.class14_0.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("Referer", string.Format("https://www.net-a-porter.com/{0}/en/signinpurchasepath.nap", @class.string_9));
						@class.method_5("Logging in", "#c2c2c2", true, false);
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary["j_username"] = (@class.string_13.Any(new Func<string, bool>(@class.method_24)) ? string.Format("{0}+{1}@{2}", @class.jtoken_1["payment"]["email"].ToString().Split(new char[]
						{
							'@'
						})[0], MainWindow.random_0.Next(1, 9999).ToString(), @class.jtoken_1["payment"]["email"].ToString().Split(new char[]
						{
							'@'
						}).Last<string>()) : @class.jtoken_1["payment"]["email"].ToString());
						dictionary["didProvideAPassword"] = "no";
						dictionary["sourceForm"] = "guestcheckout";
						taskAwaiter4 = @class.class14_0.method_3(string.Format("https://www.net-a-porter.com/{0}/en/j_spring_security_check", @class.string_9), dictionary, false).GetAwaiter();
						if (!taskAwaiter4.IsCompleted)
						{
							int num5 = 0;
							num = 0;
							num2 = num5;
							TaskAwaiter<HttpResponseMessage> taskAwaiter5 = taskAwaiter4;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class50.Struct99>(ref taskAwaiter4, ref this);
							return;
						}
					}
					else
					{
						TaskAwaiter<HttpResponseMessage> taskAwaiter5;
						taskAwaiter4 = taskAwaiter5;
						taskAwaiter5 = default(TaskAwaiter<HttpResponseMessage>);
						int num6 = -1;
						num = -1;
						num2 = num6;
					}
					HttpResponseMessage result = taskAwaiter4.GetResult();
					if (result.StatusCode != HttpStatusCode.Found || !result.Headers.Location.ToString().Contains("/myaccount"))
					{
						throw new Exception();
					}
					@class.string_10 = result.Headers.Location.ToString().Split(new char[]
					{
						'/'
					}).Reverse<string>().ToList<string>()[1];
					@class.class14_0.httpClient_0.DefaultRequestHeaders.Remove("Referer");
					@class.method_5(string.Format("Found store channel: {0}", @class.string_10), "#c2c2c2", true, false);
					goto IL_31C;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_2CF;
				}
				@class.method_5("Error logging in", "#c2c2c2", true, false);
				taskAwaiter3 = @class.method_14(Class130.int_1).GetAwaiter();
				if (taskAwaiter3.IsCompleted)
				{
					goto IL_2C8;
				}
				int num7 = 1;
				num = 1;
				num2 = num7;
				taskAwaiter2 = taskAwaiter3;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class50.Struct99>(ref taskAwaiter3, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_31C:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000609 RID: 1545 RVA: 0x000057F5 File Offset: 0x000039F5
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040004C3 RID: 1219
		public int int_0;

		// Token: 0x040004C4 RID: 1220
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040004C5 RID: 1221
		public Class50 class50_0;

		// Token: 0x040004C6 RID: 1222
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040004C7 RID: 1223
		private TaskAwaiter taskAwaiter_1;
	}

	// Token: 0x0200010E RID: 270
	[StructLayout(LayoutKind.Auto)]
	private struct Struct100 : IAsyncStateMachine
	{
		// Token: 0x0600060A RID: 1546 RVA: 0x0003601C File Offset: 0x0003421C
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class50 @class = this;
			try
			{
				if (num == 0)
				{
					goto IL_117;
				}
				if (num != 1)
				{
					goto IL_10D;
				}
				TaskAwaiter taskAwaiter3 = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_106:
				taskAwaiter3.GetResult();
				IL_10D:
				if (@class.bool_1)
				{
					goto IL_159;
				}
				int num4 = 0;
				IL_117:
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter4;
					if (num != 0)
					{
						@class.method_5("Getting checkout", "#c2c2c2", true, false);
						taskAwaiter4 = @class.class14_0.method_2(string.Format("https://www.net-a-porter.com/{0}/en/purchasepath.nap", @class.string_9), true).GetAwaiter();
						if (!taskAwaiter4.IsCompleted)
						{
							int num5 = 0;
							num = 0;
							num2 = num5;
							TaskAwaiter<HttpResponseMessage> taskAwaiter5 = taskAwaiter4;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class50.Struct100>(ref taskAwaiter4, ref this);
							return;
						}
					}
					else
					{
						TaskAwaiter<HttpResponseMessage> taskAwaiter5;
						taskAwaiter4 = taskAwaiter5;
						taskAwaiter5 = default(TaskAwaiter<HttpResponseMessage>);
						int num6 = -1;
						num = -1;
						num2 = num6;
					}
					taskAwaiter4.GetResult().EnsureSuccessStatusCode();
					goto IL_159;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_10D;
				}
				@class.method_5("Error getting checkout", "#c2c2c2", true, false);
				taskAwaiter3 = @class.method_14(Class130.int_1).GetAwaiter();
				if (taskAwaiter3.IsCompleted)
				{
					goto IL_106;
				}
				int num7 = 1;
				num = 1;
				num2 = num7;
				taskAwaiter2 = taskAwaiter3;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class50.Struct100>(ref taskAwaiter3, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_159:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x0600060B RID: 1547 RVA: 0x00005803 File Offset: 0x00003A03
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040004C8 RID: 1224
		public int int_0;

		// Token: 0x040004C9 RID: 1225
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040004CA RID: 1226
		public Class50 class50_0;

		// Token: 0x040004CB RID: 1227
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040004CC RID: 1228
		private TaskAwaiter taskAwaiter_1;
	}

	// Token: 0x0200010F RID: 271
	[StructLayout(LayoutKind.Auto)]
	private struct Struct101 : IAsyncStateMachine
	{
		// Token: 0x0600060C RID: 1548 RVA: 0x000361CC File Offset: 0x000343CC
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class50 @class = this;
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
						taskAwaiter = @class.method_16().GetAwaiter();
						if (!taskAwaiter.IsCompleted)
						{
							num2 = 0;
							TaskAwaiter taskAwaiter2 = taskAwaiter;
							this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class50.Struct101>(ref taskAwaiter, ref this);
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
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class50.Struct101>(ref taskAwaiter, ref this);
						return;
					}
					IL_DF:
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_19().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 2;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class50.Struct101>(ref taskAwaiter, ref this);
						return;
					}
					IL_13A:
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_18().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 3;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class50.Struct101>(ref taskAwaiter, ref this);
						return;
					}
					IL_195:
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_20().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 4;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class50.Struct101>(ref taskAwaiter, ref this);
						return;
					}
					IL_1F0:
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_21().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 5;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class50.Struct101>(ref taskAwaiter, ref this);
						return;
					}
					IL_24B:
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_22().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 6;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class50.Struct101>(ref taskAwaiter, ref this);
						return;
					}
					IL_2A3:
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

		// Token: 0x0600060D RID: 1549 RVA: 0x00005811 File Offset: 0x00003A11
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040004CD RID: 1229
		public int int_0;

		// Token: 0x040004CE RID: 1230
		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		// Token: 0x040004CF RID: 1231
		public Class50 class50_0;

		// Token: 0x040004D0 RID: 1232
		private TaskAwaiter taskAwaiter_0;
	}

	// Token: 0x02000110 RID: 272
	[StructLayout(LayoutKind.Auto)]
	private struct Struct102 : IAsyncStateMachine
	{
		// Token: 0x0600060E RID: 1550 RVA: 0x000364FC File Offset: 0x000346FC
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class50 @class = this;
			try
			{
				if (num <= 1)
				{
					goto IL_1D2;
				}
				if (num != 2)
				{
					goto IL_1C8;
				}
				TaskAwaiter taskAwaiter7 = taskAwaiter6;
				taskAwaiter6 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_1C1:
				taskAwaiter7.GetResult();
				IL_1C8:
				if (@class.bool_1)
				{
					goto IL_214;
				}
				int num4 = 0;
				IL_1D2:
				try
				{
					TaskAwaiter<string> taskAwaiter8;
					TaskAwaiter<HttpResponseMessage> taskAwaiter9;
					if (num != 0)
					{
						if (num == 1)
						{
							taskAwaiter8 = taskAwaiter4;
							taskAwaiter4 = default(TaskAwaiter<string>);
							int num5 = -1;
							num = -1;
							num2 = num5;
							goto IL_12A;
						}
						@class.method_5("Submitting payment", "orange", true, false);
						taskAwaiter9 = @class.class14_0.method_3("https://secure.net-a-porter.com/psp/payment", @class.dictionary_0, true).GetAwaiter();
						if (!taskAwaiter9.IsCompleted)
						{
							int num6 = 0;
							num = 0;
							num2 = num6;
							taskAwaiter2 = taskAwaiter9;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class50.Struct102>(ref taskAwaiter9, ref this);
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
					HttpResponseMessage result = taskAwaiter9.GetResult();
					result.EnsureSuccessStatusCode();
					taskAwaiter8 = result.smethod_3().GetAwaiter();
					if (!taskAwaiter8.IsCompleted)
					{
						int num8 = 1;
						num = 1;
						num2 = num8;
						taskAwaiter4 = taskAwaiter8;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class50.Struct102>(ref taskAwaiter8, ref this);
						return;
					}
					IL_12A:
					string result2 = taskAwaiter8.GetResult();
					if (result2.Contains("your payment has not been authorized"))
					{
						@class.method_0("Payment Declined", "red", true, (GEnum1)5);
					}
					else if (result2.Contains("Order confirmation"))
					{
						@class.method_0("Successfully checked out", "green", true, (GEnum1)6);
					}
					else
					{
						@class.method_0("Payment error", "red", true, (GEnum1)0);
					}
					goto IL_214;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_1C8;
				}
				@class.method_5("Error submitting payment", "#c2c2c2", true, false);
				taskAwaiter7 = @class.method_14(Class130.int_1).GetAwaiter();
				if (taskAwaiter7.IsCompleted)
				{
					goto IL_1C1;
				}
				int num9 = 2;
				num = 2;
				num2 = num9;
				taskAwaiter6 = taskAwaiter7;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class50.Struct102>(ref taskAwaiter7, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_214:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x0600060F RID: 1551 RVA: 0x0000581F File Offset: 0x00003A1F
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040004D1 RID: 1233
		public int int_0;

		// Token: 0x040004D2 RID: 1234
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040004D3 RID: 1235
		public Class50 class50_0;

		// Token: 0x040004D4 RID: 1236
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040004D5 RID: 1237
		private TaskAwaiter<string> taskAwaiter_1;

		// Token: 0x040004D6 RID: 1238
		private TaskAwaiter taskAwaiter_2;
	}
}
