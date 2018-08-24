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

// Token: 0x02000074 RID: 116
internal sealed class Class46 : Class44
{
	// Token: 0x06000216 RID: 534 RVA: 0x00012E40 File Offset: 0x00011040
	public Class46(JToken jtoken_2, string string_14, string string_15)
	{
		try
		{
			this.jtoken_0 = jtoken_2;
			this.string_10 = string_14;
			this.string_9 = string_15;
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
				this.class14_0.cookieContainer_0.Add(new Cookie("napMobileApp", "true", "/", ".mrporter.com"));
			}
		}
		catch
		{
			base.method_0("Task error", "red", true, (GEnum1)0);
		}
	}

	// Token: 0x06000217 RID: 535 RVA: 0x00012F78 File Offset: 0x00011178
	public override async void vmethod_0()
	{
		try
		{
			Task task = this.method_18();
			await this.method_16();
			await this.method_17();
			await task;
			await this.method_20();
			await this.method_19();
			await this.method_21();
			await this.method_22();
			await this.method_23();
			task = null;
		}
		catch
		{
		}
		base.method_0("Stopped", "red", true, (GEnum1)0);
	}

	// Token: 0x06000218 RID: 536 RVA: 0x00012FB4 File Offset: 0x000111B4
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

	// Token: 0x06000219 RID: 537 RVA: 0x00012FF8 File Offset: 0x000111F8
	public async Task method_16()
	{
		base.method_5("Waiting for product", "#c2c2c2", true, false);
		while (!this.bool_1)
		{
			int num = 0;
			TaskAwaiter taskAwaiter2;
			try
			{
				HttpResponseMessage httpResponseMessage = await GClass2.smethod_1(string.Format("https://api.net-a-porter.com/MRP/{0}/en/detail/{1}", this.string_9.ToUpper(), this.string_7), null, true);
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
					JToken jtoken = result["skus"].Where(new Func<JToken, bool>(Class46.Class62.class62_0.method_0)).smethod_5();
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
					JToken jtoken2 = result["skus"].FirstOrDefault(new Func<JToken, bool>(this.method_24));
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

	// Token: 0x0600021A RID: 538 RVA: 0x00013040 File Offset: 0x00011240
	public async Task method_17()
	{
		base.method_5("Adding to cart", "yellow", true, false);
		while (!this.bool_1)
		{
			int num = 0;
			TaskAwaiter taskAwaiter2;
			try
			{
				HttpResponseMessage httpResponseMessage = await this.class14_0.method_2(string.Format("https://www.mrporter.com/{0}/api/basket/addsku/{1}.mrp", this.string_10, this.string_8), false);
				if (httpResponseMessage.StatusCode == HttpStatusCode.Gone)
				{
					base.method_0("Product pulled", "red", true, (GEnum1)0);
				}
				string a = (string)(await httpResponseMessage.smethod_1())["result"];
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

	// Token: 0x0600021B RID: 539 RVA: 0x00013088 File Offset: 0x00011288
	public async Task method_18()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Getting cookies", "#c2c2c2", true, false);
				(await this.class14_0.method_2("https://www.mrporter.com/en-gb/mens/gucci/rhyton-printed-leather-sneakers/975128", true)).EnsureSuccessStatusCode();
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error getting cookies", "#c2c2c2", true, false);
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

	// Token: 0x0600021C RID: 540 RVA: 0x000130D0 File Offset: 0x000112D0
	public async Task method_19()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Getting checkout", "#c2c2c2", true, false);
				(await this.class14_0.method_2(string.Format("https://www.mrporter.com/{0}/purchasepath.mrp", this.string_10), true)).EnsureSuccessStatusCode();
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

	// Token: 0x0600021D RID: 541 RVA: 0x00013118 File Offset: 0x00011318
	public async Task method_20()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				this.class14_0.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("Referer", string.Format("https://www.mrporter.com/{0}/signin.mrp", this.string_10));
				base.method_5("Logging in", "#c2c2c2", true, false);
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary["j_username"] = (this.string_13.Any(new Func<string, bool>(this.method_25)) ? string.Format("{0}+{1}@{2}", this.jtoken_1["payment"]["email"].ToString().Split(new char[]
				{
					'@'
				})[0], MainWindow.random_0.Next(1, 9999).ToString(), this.jtoken_1["payment"]["email"].ToString().Split(new char[]
				{
					'@'
				}).Last<string>()) : this.jtoken_1["payment"]["email"].ToString());
				dictionary["didProvideAPassword"] = "no";
				HttpResponseMessage httpResponseMessage = await this.class14_0.method_3(string.Format("https://www.mrporter.com/{0}/j_spring_security_check", this.string_10), dictionary, false);
				if (httpResponseMessage.StatusCode != HttpStatusCode.Found || !httpResponseMessage.Headers.Location.ToString().Contains("/myaccount"))
				{
					throw new Exception();
				}
				this.class14_0.httpClient_0.DefaultRequestHeaders.Remove("Referer");
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

	// Token: 0x0600021E RID: 542 RVA: 0x00013160 File Offset: 0x00011360
	public async Task method_21()
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
				TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class14_0.method_3(string.Format("https://www.mrporter.com/{0}/purchasepath.mrp?execution=e1s1", this.string_10), dictionary, true).GetAwaiter();
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

	// Token: 0x0600021F RID: 543 RVA: 0x000131A8 File Offset: 0x000113A8
	public async Task method_22()
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
				TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class14_0.method_3(string.Format("https://www.mrporter.com/{0}/purchasepath.mrp?execution=e1s2", this.string_10), dictionary, true).GetAwaiter();
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
				string value4 = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='redirectUrl']").Attributes["value"].Value;
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

	// Token: 0x06000220 RID: 544 RVA: 0x000131F0 File Offset: 0x000113F0
	public async Task method_23()
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

	// Token: 0x06000221 RID: 545 RVA: 0x00003E3D File Offset: 0x0000203D
	private bool method_24(JToken jtoken_2)
	{
		return Class43.smethod_2(this.string_0, (string)jtoken_2["displaySize"]);
	}

	// Token: 0x06000222 RID: 546 RVA: 0x00003E5A File Offset: 0x0000205A
	private bool method_25(string string_14)
	{
		return this.jtoken_1["payment"]["email"].ToString().Contains(string_14);
	}

	// Token: 0x0400015B RID: 347
	private string string_7;

	// Token: 0x0400015C RID: 348
	private string string_8;

	// Token: 0x0400015D RID: 349
	private string string_9;

	// Token: 0x0400015E RID: 350
	private string string_10;

	// Token: 0x0400015F RID: 351
	private string string_11;

	// Token: 0x04000160 RID: 352
	private string string_12;

	// Token: 0x04000161 RID: 353
	private Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();

	// Token: 0x04000162 RID: 354
	private string[] string_13 = new string[]
	{
		"gmail.com",
		"cybersole.io"
	};

	// Token: 0x02000075 RID: 117
	[Serializable]
	private sealed class Class62
	{
		// Token: 0x06000225 RID: 549 RVA: 0x00003E8D File Offset: 0x0000208D
		internal bool method_0(JToken jtoken_0)
		{
			return (string)jtoken_0["stockLevel"] != "Out_of_Stock";
		}

		// Token: 0x04000163 RID: 355
		public static readonly Class46.Class62 class62_0 = new Class46.Class62();

		// Token: 0x04000164 RID: 356
		public static Func<JToken, bool> func_0;
	}

	// Token: 0x02000076 RID: 118
	[StructLayout(LayoutKind.Auto)]
	private struct Struct39 : IAsyncStateMachine
	{
		// Token: 0x06000226 RID: 550 RVA: 0x00013238 File Offset: 0x00011438
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class46 @class = this;
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
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class46.Struct39>(ref taskAwaiter9, ref this);
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
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class46.Struct39>(ref taskAwaiter8, ref this);
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
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class46.Struct39>(ref taskAwaiter7, ref this);
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

		// Token: 0x06000227 RID: 551 RVA: 0x00003EA9 File Offset: 0x000020A9
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000165 RID: 357
		public int int_0;

		// Token: 0x04000166 RID: 358
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000167 RID: 359
		public Class46 class46_0;

		// Token: 0x04000168 RID: 360
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000169 RID: 361
		private TaskAwaiter<string> taskAwaiter_1;

		// Token: 0x0400016A RID: 362
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x02000077 RID: 119
	[StructLayout(LayoutKind.Auto)]
	private struct Struct40 : IAsyncStateMachine
	{
		// Token: 0x06000228 RID: 552 RVA: 0x000134A0 File Offset: 0x000116A0
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class46 @class = this;
			try
			{
				TaskAwaiter taskAwaiter3;
				if (num > 3)
				{
					if (num != 4)
					{
						@class.method_5("Adding to cart", "yellow", true, false);
						goto IL_2E5;
					}
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					int num3 = -1;
					num = -1;
					num2 = num3;
					goto IL_2D4;
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
						goto IL_26F;
					}
					case 3:
					{
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num7 = -1;
						num = -1;
						num2 = num7;
						goto IL_294;
					}
					default:
						taskAwaiter4 = @class.class14_0.method_2(string.Format("https://www.mrporter.com/{0}/api/basket/addsku/{1}.mrp", @class.string_10, @class.string_8), false).GetAwaiter();
						if (!taskAwaiter4.IsCompleted)
						{
							int num8 = 0;
							num = 0;
							num2 = num8;
							TaskAwaiter<HttpResponseMessage> taskAwaiter5 = taskAwaiter4;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class46.Struct40>(ref taskAwaiter4, ref this);
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
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class46.Struct40>(ref taskAwaiter6, ref this);
						return;
					}
					IL_154:
					string a = (string)taskAwaiter6.GetResult()["result"];
					if (!(a == "SIZE_SOLD_OUT"))
					{
						if (!(a == "PRODUCT_NOT_AVAILABLE"))
						{
							if (!(a == "PRODUCT_ADDED"))
							{
								throw new Exception();
							}
							@class.method_5("Successfully carted", "#c2c2c2", true, false);
							goto IL_32A;
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
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class46.Struct40>(ref taskAwaiter3, ref this);
								return;
							}
							goto IL_294;
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
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class46.Struct40>(ref taskAwaiter3, ref this);
							return;
						}
					}
					IL_26F:
					taskAwaiter3.GetResult();
					goto IL_2E5;
					IL_294:
					taskAwaiter3.GetResult();
					goto IL_2E5;
				}
				catch
				{
					num12 = 1;
				}
				if (num12 != 1)
				{
					goto IL_2E5;
				}
				@class.method_5("Error adding to cart", "#c2c2c2", true, false);
				taskAwaiter3 = @class.method_14(Class130.int_1).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					int num13 = 4;
					num = 4;
					num2 = num13;
					taskAwaiter2 = taskAwaiter3;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class46.Struct40>(ref taskAwaiter3, ref this);
					return;
				}
				IL_2D4:
				taskAwaiter3.GetResult();
				IL_2E5:
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
			IL_32A:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000229 RID: 553 RVA: 0x00003EB7 File Offset: 0x000020B7
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400016B RID: 363
		public int int_0;

		// Token: 0x0400016C RID: 364
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x0400016D RID: 365
		public Class46 class46_0;

		// Token: 0x0400016E RID: 366
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x0400016F RID: 367
		private TaskAwaiter<JObject> taskAwaiter_1;

		// Token: 0x04000170 RID: 368
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x02000078 RID: 120
	[StructLayout(LayoutKind.Auto)]
	private struct Struct41 : IAsyncStateMachine
	{
		// Token: 0x0600022A RID: 554 RVA: 0x00013820 File Offset: 0x00011A20
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class46 @class = this;
			try
			{
				if (num <= 1)
				{
					goto IL_438;
				}
				if (num != 2)
				{
					goto IL_42E;
				}
				TaskAwaiter taskAwaiter7 = taskAwaiter6;
				taskAwaiter6 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_427:
				taskAwaiter7.GetResult();
				IL_42E:
				if (@class.bool_1)
				{
					goto IL_47A;
				}
				int num4 = 0;
				IL_438:
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
							goto IL_34A;
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
						taskAwaiter9 = @class.class14_0.method_3(string.Format("https://www.mrporter.com/{0}/purchasepath.mrp?execution=e1s1", @class.string_10), dictionary, true).GetAwaiter();
						if (!taskAwaiter9.IsCompleted)
						{
							int num6 = 0;
							num = 0;
							num2 = num6;
							taskAwaiter2 = taskAwaiter9;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class46.Struct41>(ref taskAwaiter9, ref this);
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
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class46.Struct41>(ref taskAwaiter8, ref this);
						return;
					}
					IL_34A:
					string result2 = taskAwaiter8.GetResult();
					htmlDocument2.LoadHtml(result2);
					htmlDocument2 = null;
					@class.string_11 = htmlDocument.DocumentNode.SelectNodes("//input[@name='selectedShippingMethodId']").Last<HtmlNode>().Attributes["value"].Value;
					@class.string_12 = htmlDocument.DocumentNode.SelectNodes("//input[@name='selectedPackagingOptionId']").First<HtmlNode>().Attributes["value"].Value;
					@class.method_5(string.Format("Found shipping method ID: {0}", @class.string_11), "#c2c2c2", true, false);
					goto IL_47A;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_42E;
				}
				@class.method_5("Error submitting shipping", "#c2c2c2", true, false);
				taskAwaiter7 = @class.method_14(Class130.int_1).GetAwaiter();
				if (taskAwaiter7.IsCompleted)
				{
					goto IL_427;
				}
				int num9 = 2;
				num = 2;
				num2 = num9;
				taskAwaiter6 = taskAwaiter7;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class46.Struct41>(ref taskAwaiter7, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_47A:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x0600022B RID: 555 RVA: 0x00003EC5 File Offset: 0x000020C5
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000171 RID: 369
		public int int_0;

		// Token: 0x04000172 RID: 370
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000173 RID: 371
		public Class46 class46_0;

		// Token: 0x04000174 RID: 372
		private HtmlDocument htmlDocument_0;

		// Token: 0x04000175 RID: 373
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000176 RID: 374
		private HtmlDocument htmlDocument_1;

		// Token: 0x04000177 RID: 375
		private TaskAwaiter<string> taskAwaiter_1;

		// Token: 0x04000178 RID: 376
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x02000079 RID: 121
	[StructLayout(LayoutKind.Auto)]
	private struct Struct42 : IAsyncStateMachine
	{
		// Token: 0x0600022C RID: 556 RVA: 0x00013CF0 File Offset: 0x00011EF0
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class46 @class = this;
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
						taskAwaiter6 = GClass2.smethod_1(string.Format("https://api.net-a-porter.com/MRP/{0}/en/detail/{1}", @class.string_9.ToUpper(), @class.string_7), null, true).GetAwaiter();
						if (!taskAwaiter6.IsCompleted)
						{
							int num10 = 0;
							num = 0;
							num2 = num10;
							TaskAwaiter<HttpResponseMessage> taskAwaiter7 = taskAwaiter6;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class46.Struct42>(ref taskAwaiter6, ref this);
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
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class46.Struct42>(ref taskAwaiter5, ref this);
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
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class46.Struct42>(ref taskAwaiter8, ref this);
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
						JToken jtoken = result2["skus"].Where(new Func<JToken, bool>(Class46.Class62.class62_0.method_0)).smethod_5();
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
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class46.Struct42>(ref taskAwaiter5, ref this);
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
						JToken jtoken2 = result2["skus"].FirstOrDefault(new Func<JToken, bool>(@class.method_24));
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
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class46.Struct42>(ref taskAwaiter5, ref this);
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
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class46.Struct42>(ref taskAwaiter5, ref this);
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
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class46.Struct42>(ref taskAwaiter5, ref this);
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

		// Token: 0x0600022D RID: 557 RVA: 0x00003ED3 File Offset: 0x000020D3
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000179 RID: 377
		public int int_0;

		// Token: 0x0400017A RID: 378
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x0400017B RID: 379
		public Class46 class46_0;

		// Token: 0x0400017C RID: 380
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x0400017D RID: 381
		private TaskAwaiter taskAwaiter_1;

		// Token: 0x0400017E RID: 382
		private TaskAwaiter<JObject> taskAwaiter_2;
	}

	// Token: 0x0200007A RID: 122
	[StructLayout(LayoutKind.Auto)]
	private struct Struct43 : IAsyncStateMachine
	{
		// Token: 0x0600022E RID: 558 RVA: 0x00014204 File Offset: 0x00012404
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class46 @class = this;
			try
			{
				if (num <= 1)
				{
					goto IL_53F;
				}
				if (num != 2)
				{
					goto IL_535;
				}
				TaskAwaiter taskAwaiter7 = taskAwaiter6;
				taskAwaiter6 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_52E:
				taskAwaiter7.GetResult();
				IL_535:
				if (@class.bool_1)
				{
					goto IL_581;
				}
				int num4 = 0;
				IL_53F:
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
							goto IL_1C2;
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
						taskAwaiter9 = @class.class14_0.method_3(string.Format("https://www.mrporter.com/{0}/purchasepath.mrp?execution=e1s2", @class.string_10), dictionary, true).GetAwaiter();
						if (!taskAwaiter9.IsCompleted)
						{
							int num6 = 0;
							num = 0;
							num2 = num6;
							taskAwaiter2 = taskAwaiter9;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class46.Struct43>(ref taskAwaiter9, ref this);
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
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class46.Struct43>(ref taskAwaiter8, ref this);
						return;
					}
					IL_1C2:
					string result2 = taskAwaiter8.GetResult();
					htmlDocument2.LoadHtml(result2);
					htmlDocument2 = null;
					string value = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='paymentSessionId']").Attributes["value"].Value;
					string value2 = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='customerId']").Attributes["value"].Value;
					string value3 = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='site']").Attributes["value"].Value;
					string value4 = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='redirectUrl']").Attributes["value"].Value;
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
					goto IL_581;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_535;
				}
				@class.method_5("Error submitting shipping method", "#c2c2c2", true, false);
				taskAwaiter7 = @class.method_14(Class130.int_1).GetAwaiter();
				if (taskAwaiter7.IsCompleted)
				{
					goto IL_52E;
				}
				int num9 = 2;
				num = 2;
				num2 = num9;
				taskAwaiter6 = taskAwaiter7;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class46.Struct43>(ref taskAwaiter7, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_581:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x0600022F RID: 559 RVA: 0x00003EE1 File Offset: 0x000020E1
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400017F RID: 383
		public int int_0;

		// Token: 0x04000180 RID: 384
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000181 RID: 385
		public Class46 class46_0;

		// Token: 0x04000182 RID: 386
		private HtmlDocument htmlDocument_0;

		// Token: 0x04000183 RID: 387
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000184 RID: 388
		private HtmlDocument htmlDocument_1;

		// Token: 0x04000185 RID: 389
		private TaskAwaiter<string> taskAwaiter_1;

		// Token: 0x04000186 RID: 390
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x0200007B RID: 123
	[StructLayout(LayoutKind.Auto)]
	private struct Struct44 : IAsyncStateMachine
	{
		// Token: 0x06000230 RID: 560 RVA: 0x000147DC File Offset: 0x000129DC
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class46 @class = this;
			try
			{
				if (num == 0)
				{
					goto IL_10C;
				}
				if (num != 1)
				{
					goto IL_102;
				}
				TaskAwaiter taskAwaiter3 = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_FB:
				taskAwaiter3.GetResult();
				IL_102:
				if (@class.bool_1)
				{
					goto IL_14E;
				}
				int num4 = 0;
				IL_10C:
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter4;
					if (num != 0)
					{
						@class.method_5("Getting cookies", "#c2c2c2", true, false);
						taskAwaiter4 = @class.class14_0.method_2("https://www.mrporter.com/en-gb/mens/gucci/rhyton-printed-leather-sneakers/975128", true).GetAwaiter();
						if (!taskAwaiter4.IsCompleted)
						{
							int num5 = 0;
							num = 0;
							num2 = num5;
							TaskAwaiter<HttpResponseMessage> taskAwaiter5 = taskAwaiter4;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class46.Struct44>(ref taskAwaiter4, ref this);
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
					goto IL_14E;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_102;
				}
				@class.method_5("Error getting cookies", "#c2c2c2", true, false);
				taskAwaiter3 = @class.method_14(Class130.int_1).GetAwaiter();
				if (taskAwaiter3.IsCompleted)
				{
					goto IL_FB;
				}
				int num7 = 1;
				num = 1;
				num2 = num7;
				taskAwaiter2 = taskAwaiter3;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class46.Struct44>(ref taskAwaiter3, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_14E:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000231 RID: 561 RVA: 0x00003EEF File Offset: 0x000020EF
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000187 RID: 391
		public int int_0;

		// Token: 0x04000188 RID: 392
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000189 RID: 393
		public Class46 class46_0;

		// Token: 0x0400018A RID: 394
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x0400018B RID: 395
		private TaskAwaiter taskAwaiter_1;
	}

	// Token: 0x0200007C RID: 124
	[StructLayout(LayoutKind.Auto)]
	private struct Struct45 : IAsyncStateMachine
	{
		// Token: 0x06000232 RID: 562 RVA: 0x00014980 File Offset: 0x00012B80
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class46 @class = this;
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
						taskAwaiter4 = @class.class14_0.method_2(string.Format("https://www.mrporter.com/{0}/purchasepath.mrp", @class.string_10), true).GetAwaiter();
						if (!taskAwaiter4.IsCompleted)
						{
							int num5 = 0;
							num = 0;
							num2 = num5;
							TaskAwaiter<HttpResponseMessage> taskAwaiter5 = taskAwaiter4;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class46.Struct45>(ref taskAwaiter4, ref this);
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
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class46.Struct45>(ref taskAwaiter3, ref this);
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

		// Token: 0x06000233 RID: 563 RVA: 0x00003EFD File Offset: 0x000020FD
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400018C RID: 396
		public int int_0;

		// Token: 0x0400018D RID: 397
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x0400018E RID: 398
		public Class46 class46_0;

		// Token: 0x0400018F RID: 399
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000190 RID: 400
		private TaskAwaiter taskAwaiter_1;
	}

	// Token: 0x0200007D RID: 125
	[StructLayout(LayoutKind.Auto)]
	private struct Struct46 : IAsyncStateMachine
	{
		// Token: 0x06000234 RID: 564 RVA: 0x00014B30 File Offset: 0x00012D30
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class46 @class = this;
			try
			{
				if (num == 0)
				{
					goto IL_277;
				}
				if (num != 1)
				{
					goto IL_26D;
				}
				TaskAwaiter taskAwaiter3 = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_266:
				taskAwaiter3.GetResult();
				IL_26D:
				if (@class.bool_1)
				{
					goto IL_2B9;
				}
				int num4 = 0;
				IL_277:
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter4;
					if (num != 0)
					{
						@class.class14_0.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("Referer", string.Format("https://www.mrporter.com/{0}/signin.mrp", @class.string_10));
						@class.method_5("Logging in", "#c2c2c2", true, false);
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary["j_username"] = (@class.string_13.Any(new Func<string, bool>(@class.method_25)) ? string.Format("{0}+{1}@{2}", @class.jtoken_1["payment"]["email"].ToString().Split(new char[]
						{
							'@'
						})[0], MainWindow.random_0.Next(1, 9999).ToString(), @class.jtoken_1["payment"]["email"].ToString().Split(new char[]
						{
							'@'
						}).Last<string>()) : @class.jtoken_1["payment"]["email"].ToString());
						dictionary["didProvideAPassword"] = "no";
						taskAwaiter4 = @class.class14_0.method_3(string.Format("https://www.mrporter.com/{0}/j_spring_security_check", @class.string_10), dictionary, false).GetAwaiter();
						if (!taskAwaiter4.IsCompleted)
						{
							int num5 = 0;
							num = 0;
							num2 = num5;
							TaskAwaiter<HttpResponseMessage> taskAwaiter5 = taskAwaiter4;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class46.Struct46>(ref taskAwaiter4, ref this);
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
					@class.class14_0.httpClient_0.DefaultRequestHeaders.Remove("Referer");
					goto IL_2B9;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_26D;
				}
				@class.method_5("Error logging in", "#c2c2c2", true, false);
				taskAwaiter3 = @class.method_14(Class130.int_1).GetAwaiter();
				if (taskAwaiter3.IsCompleted)
				{
					goto IL_266;
				}
				int num7 = 1;
				num = 1;
				num2 = num7;
				taskAwaiter2 = taskAwaiter3;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class46.Struct46>(ref taskAwaiter3, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_2B9:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000235 RID: 565 RVA: 0x00003F0B File Offset: 0x0000210B
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000191 RID: 401
		public int int_0;

		// Token: 0x04000192 RID: 402
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000193 RID: 403
		public Class46 class46_0;

		// Token: 0x04000194 RID: 404
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000195 RID: 405
		private TaskAwaiter taskAwaiter_1;
	}

	// Token: 0x0200007E RID: 126
	[StructLayout(LayoutKind.Auto)]
	private struct Struct47 : IAsyncStateMachine
	{
		// Token: 0x06000236 RID: 566 RVA: 0x00014E40 File Offset: 0x00013040
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class46 @class = this;
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
						goto IL_EF;
					}
					case 2:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_14A;
					}
					case 3:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_1A5;
					}
					case 4:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_200;
					}
					case 5:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_25B;
					}
					case 6:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_2B6;
					}
					case 7:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_30E;
					}
					default:
						task = @class.method_18();
						taskAwaiter = @class.method_16().GetAwaiter();
						if (!taskAwaiter.IsCompleted)
						{
							num2 = 0;
							TaskAwaiter taskAwaiter2 = taskAwaiter;
							this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class46.Struct47>(ref taskAwaiter, ref this);
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
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class46.Struct47>(ref taskAwaiter, ref this);
						return;
					}
					IL_EF:
					taskAwaiter.GetResult();
					taskAwaiter = task.GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 2;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class46.Struct47>(ref taskAwaiter, ref this);
						return;
					}
					IL_14A:
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_20().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 3;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class46.Struct47>(ref taskAwaiter, ref this);
						return;
					}
					IL_1A5:
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_19().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 4;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class46.Struct47>(ref taskAwaiter, ref this);
						return;
					}
					IL_200:
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_21().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 5;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class46.Struct47>(ref taskAwaiter, ref this);
						return;
					}
					IL_25B:
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_22().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 6;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class46.Struct47>(ref taskAwaiter, ref this);
						return;
					}
					IL_2B6:
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_23().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 7;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class46.Struct47>(ref taskAwaiter, ref this);
						return;
					}
					IL_30E:
					taskAwaiter.GetResult();
					task = null;
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

		// Token: 0x06000237 RID: 567 RVA: 0x00003F19 File Offset: 0x00002119
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000196 RID: 406
		public int int_0;

		// Token: 0x04000197 RID: 407
		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		// Token: 0x04000198 RID: 408
		public Class46 class46_0;

		// Token: 0x04000199 RID: 409
		private Task task_0;

		// Token: 0x0400019A RID: 410
		private TaskAwaiter taskAwaiter_0;
	}
}
