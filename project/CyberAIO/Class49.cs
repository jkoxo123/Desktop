using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;

// Token: 0x020000FD RID: 253
internal sealed class Class49 : Class44
{
	// Token: 0x060005D8 RID: 1496 RVA: 0x00032194 File Offset: 0x00030394
	public Class49(JToken jtoken_2)
	{
		try
		{
			this.jtoken_0 = jtoken_2;
			this.string_8 = (string)jtoken_2["keywords"];
			if (!((string)jtoken_2["size"] == "Random") && !((string)jtoken_2["size"] == "OneSize"))
			{
				this.string_0 = (string)jtoken_2["size"];
				this.string_0.Replace('.', ',');
			}
			else
			{
				this.bool_0 = true;
			}
			if (!base.method_2(out this.jtoken_1))
			{
				base.method_0("Profile error", "red", true, (GEnum1)0);
			}
			else
			{
				this.class14_0 = new Class14(base.method_3(), "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36", 10, false, false, null);
				this.class14_0.httpClient_0.DefaultRequestHeaders.ExpectContinue = new bool?(false);
			}
		}
		catch
		{
			base.method_0("Task error", "red", true, (GEnum1)0);
		}
	}

	// Token: 0x060005D9 RID: 1497 RVA: 0x000322CC File Offset: 0x000304CC
	public override async void vmethod_0()
	{
		try
		{
			await base.method_11();
			Task task = this.method_15();
			await this.method_16();
			await task;
			await this.method_17();
			await this.method_18();
			await this.method_19();
			await this.method_20();
			task = null;
		}
		catch
		{
		}
		base.method_0("Stopped", "red", true, (GEnum1)0);
	}

	// Token: 0x060005DA RID: 1498 RVA: 0x00032308 File Offset: 0x00030508
	public async Task method_15()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Getting token", "#c2c2c2", true, false);
				TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class14_0.method_2("https://www.footlocker.eu/en/homepage", true).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter<HttpResponseMessage> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
				}
				HttpResponseMessage result = taskAwaiter.GetResult();
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
				this.string_10 = new Uri(htmlDocument.DocumentNode.SelectSingleNode("//a[@class='fl-header--logo']").Attributes["href"].Value).Host;
				this.string_9 = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='SynchronizerToken']").Attributes["value"].Value;
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error getting token", "#c2c2c2", true, false);
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

	// Token: 0x060005DB RID: 1499 RVA: 0x00032350 File Offset: 0x00030550
	public async Task method_16()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Waiting for product", "#c2c2c2", true, false);
				TaskAwaiter<HttpResponseMessage> taskAwaiter = GClass2.smethod_1(string.Format("https://www.footlocker.eu/INTERSHOP/web/WFS/Footlocker-Footlocker_GB-Site/en_GB/-/GBP/ViewProduct-ProductVariationSelect?BaseSKU={0}&InventoryServerity=ProductDetail", this.string_8), null, true).GetAwaiter();
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
					base.method_0("Invalid URL (404)", "red", true, (GEnum1)0);
				}
				result.EnsureSuccessStatusCode();
				HtmlDocument htmlDocument = new HtmlDocument();
				HtmlDocument htmlDocument2 = htmlDocument;
				TaskAwaiter<JObject> taskAwaiter3 = result.smethod_1().GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<JObject> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<JObject>);
				}
				htmlDocument2.LoadHtml(taskAwaiter3.GetResult()["content"].ToString());
				htmlDocument2 = null;
				if (this.bool_0)
				{
					HtmlNodeCollection htmlNodeCollection = htmlDocument.DocumentNode.SelectNodes("//*[@class='fl-product-size--item']");
					if (htmlNodeCollection == null)
					{
						base.method_0("Size unavailable", "red", true, (GEnum1)0);
					}
					this.string_7 = htmlNodeCollection[MainWindow.random_0.Next(0, htmlNodeCollection.Count)].Attributes["data-form-field-value"].Value;
				}
				else
				{
					HtmlNode htmlNode = htmlDocument.DocumentNode.SelectSingleNode(string.Format("//span[contains(text(),'{0}')]", this.string_0));
					if (htmlNode != null)
					{
						this.string_7 = htmlNode.ParentNode.Attributes["data-form-field-value"].Value;
					}
					else
					{
						base.method_0("Size unavailable", "red", true, (GEnum1)0);
					}
				}
				foreach (HtmlNode htmlNode2 in ((IEnumerable<HtmlNode>)htmlDocument.DocumentNode.SelectNodes("//input")))
				{
					if (htmlNode2.Attributes.Contains("value") && htmlNode2.Attributes.Contains("name"))
					{
						if (htmlNode2.Attributes["name"].Value.ToLower().Contains("quantity"))
						{
							this.dictionary_0[htmlNode2.Attributes["name"].Value] = "1";
						}
						else
						{
							this.dictionary_0[htmlNode2.Attributes["name"].Value] = htmlNode2.Attributes["value"].Value;
						}
					}
				}
				this.dictionary_0["SKU"] = this.string_7;
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				TaskAwaiter taskAwaiter5 = base.method_14(Class130.int_0).GetAwaiter();
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

	// Token: 0x060005DC RID: 1500 RVA: 0x00032398 File Offset: 0x00030598
	public async Task method_17()
	{
		while (!this.bool_1)
		{
			int num = 0;
			TaskAwaiter taskAwaiter4;
			try
			{
				base.method_5("Adding to cart", "#c2c2c2", true, false);
				this.dictionary_0["SynchronizerToken"] = this.string_9;
				HttpResponseMessage httpResponseMessage = await this.class14_0.method_3(string.Format("https://{0}/en/addtocart", this.string_10), this.dictionary_0, false);
				TaskAwaiter<string> taskAwaiter;
				TaskAwaiter<string> taskAwaiter2;
				for (;;)
				{
					taskAwaiter = httpResponseMessage.smethod_3().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						await taskAwaiter;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<string>);
					}
					if (!taskAwaiter.GetResult().Contains("Product can not be added before launch date"))
					{
						break;
					}
					base.method_5("Waiting for release", "#c2c2c2", true, false);
					TaskAwaiter taskAwaiter3 = base.method_14(Class130.int_1).GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						await taskAwaiter3;
						taskAwaiter3 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter);
					}
					taskAwaiter3.GetResult();
					TaskAwaiter<HttpResponseMessage> taskAwaiter5 = this.class14_0.method_3(string.Format("https://{0}/en/addtocart", this.string_10), this.dictionary_0, false).GetAwaiter();
					if (!taskAwaiter5.IsCompleted)
					{
						await taskAwaiter5;
						TaskAwaiter<HttpResponseMessage> taskAwaiter6;
						taskAwaiter5 = taskAwaiter6;
						taskAwaiter6 = default(TaskAwaiter<HttpResponseMessage>);
					}
					httpResponseMessage = taskAwaiter5.GetResult();
				}
				HtmlDocument htmlDocument = new HtmlDocument();
				HtmlDocument htmlDocument2 = htmlDocument;
				taskAwaiter = httpResponseMessage.smethod_3().GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<string>);
				}
				htmlDocument2.LoadHtml(taskAwaiter.GetResult());
				htmlDocument2 = null;
				base.method_7(htmlDocument.DocumentNode.SelectSingleNode("//span[@itemprop='name']").InnerText, "#c2c2c2");
				httpResponseMessage.EnsureSuccessStatusCode();
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error adding to cart", "#c2c2c2", true, false);
				TaskAwaiter taskAwaiter3 = base.method_14(Class130.int_1).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter);
				}
				taskAwaiter3.GetResult();
				continue;
			}
		}
	}

	// Token: 0x060005DD RID: 1501 RVA: 0x000323E0 File Offset: 0x000305E0
	public async Task method_18()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Submitting shipping", "#c2c2c2", true, false);
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary["SynchronizerToken"] = this.string_9;
				dictionary["billing_Address3"] = string.Empty;
				dictionary["isshippingaddress"] = string.Empty;
				dictionary["billing_Title"] = "common.account.salutation.mr.text";
				dictionary["billing_FirstName"] = (string)this.jtoken_1["billing"]["first_name"];
				dictionary["billing_LastName"] = (string)this.jtoken_1["billing"]["last_name"];
				dictionary["billing_Address1"] = (string)this.jtoken_1["billing"]["addr1"];
				dictionary["billing_Address2"] = (this.jtoken_1["billing"]["addr1"].ToString().Split(new char[]
				{
					' '
				})[0].smethod_15() ? this.jtoken_1["billing"]["addr1"].ToString().Split(new char[]
				{
					' '
				})[0] : "0");
				dictionary["billing_Address3"] = (string)this.jtoken_1["billing"]["addr2"];
				dictionary["billing_City"] = (string)this.jtoken_1["billing"]["city"];
				dictionary["billing_PostalCode"] = (string)this.jtoken_1["billing"]["zip"];
				dictionary["billing_CountryCode"] = Class43.smethod_0((string)this.jtoken_1["billing"]["country"], false);
				dictionary["billing_PhoneHome"] = (string)this.jtoken_1["payment"]["phone"];
				dictionary["billing_BirthdayRequired"] = "true";
				dictionary["billing_Birthday_Day"] = "01";
				dictionary["billing_Birthday_Month"] = "01";
				dictionary["billing_Birthday_Year"] = "1990";
				dictionary["email_Email"] = (string)this.jtoken_1["payment"]["email"];
				dictionary["billing_ShippingAddressSameAsBilling"] = string.Empty;
				dictionary["isshippingaddress"] = string.Empty;
				dictionary["shipping_Title"] = "common.account.salutation.mr.text";
				dictionary["shipping_FirstName"] = (string)this.jtoken_1["delivery"]["first_name"];
				dictionary["shipping_LastName"] = (string)this.jtoken_1["delivery"]["last_name"];
				dictionary["shipping_Address1"] = (string)this.jtoken_1["delivery"]["addr1"];
				dictionary["shipping_Address2"] = (this.jtoken_1["delivery"]["addr1"].ToString().Split(new char[]
				{
					' '
				})[0].smethod_15() ? this.jtoken_1["delivery"]["addr1"].ToString().Split(new char[]
				{
					' '
				})[0] : "0");
				dictionary["shipping_Address3"] = (string)this.jtoken_1["delivery"]["addr2"];
				dictionary["shipping_City"] = (string)this.jtoken_1["delivery"]["city"];
				dictionary["shipping_PostalCode"] = (string)this.jtoken_1["delivery"]["zip"];
				dictionary["shipping_CountryCode"] = Class43.smethod_0((string)this.jtoken_1["delivery"]["country"], false);
				dictionary["shipping_PhoneHome"] = (string)this.jtoken_1["payment"]["phone"];
				dictionary["promotionCode"] = string.Empty;
				dictionary["PaymentServiceSelection"] = "dMKsFf0SbRcAAAFNHN88qNaq";
				dictionary["UserDeviceTypeForPaymentRedirect"] = "Desktop";
				dictionary["UserDeviceFingerprintForPaymentRedirect"] = "0400bpNfiPCR/AUNf94lis1zttlRfx+VM0Kfnrp/XmcfWoVVgr+Rt2dAZDYKGojTbbj7Ay36XoqtPmZFXM8jbbY2/zc5J3xnltE7Kq6IhM8HltvDlnXzDbRRZMFlj8uo417+TgsSA5y2mIsp2U5yrYp+5igWriMua6v6UX8EvCKxLeADvSEJLLdt5Y3XI2c5FEWnEFb7LoXxcUNydzLtG4iIzgeXlR0StWcKxwwBzmqrQiWxH1ZPRIwM6njw/ujAyYdbGKZt5JLThTvosS1xgSAgNfLEMokGoGJxgu1y04HLnOzU8XBpd1sDgWA73rYZtIsVyoA80pXCaXawrwf88vayC9C1UJgA1BQZQ4JudHOlf1KSnrbJSNyIsWB9R+WFa6fdxifyrThRovESnjwNVGXSgGQ8InPsuf6/kpMgG84gzO5PMQF00uJew9XqxzJ4y+q4+f7ypk+EO6/K3oOxQXYZs5cTbAHNea+iljAlWwXHcT+hgN6tJA4p1nA+k9XRlIy/cY2AmTS50PVkkRWvZSWgvJFEYUMEnFwrc5V3eY0fJJ82UD3fyk93hC6Bo0qhcOVgxA9x3qRKbjM42PnqoOsl8d3pZ/WuuaUQfveZj4MPqv5NOao4N+06jVc4K6FMki+uv9eOvsyvTBVVGK66EXEuaD0YLXuOWeFzAIsjF5E9P9gJB/s4Mwp5boWRHa+7AHqtF/5t+EKgbjXypamhTYJ5p2IPArjDreTC6uFgohzG6thap+9nixWCRWREjH59g5/QSzKz6zFbyZbyxPMQMv7YZ9mxtLKX2QfncSs2NHNZzALZjVp/OGcTE5Ppv736RSsQQEdu2XYvr46icoEUIBl9dJXAAYR3cfgvWnUHhXIkRJtofM5fO4/4C0OCbnRzpX9Skp62yUjciLFgfUflhWun3cYn8q04UaLxEp48DVRl0oBkPCJz7Ln+v5KTIBvOIMzuTzEBdNLiXsPV6scyeMvquPn+8qZPhDuvyt6DsUF2GbOXE2wBzXmvopYwJVsFx3E/58zGq/hZ0ZoyseD0G1/ThxEIvsJRqGfF9spFd7LTpxjhrt64WqIxSK+Vx63F6egN3u5bh8qtOMZhKoST0dhOCOCSU0oZPWNEfF9hXdZ4DRRkrbXWcoCj3I1znntcmg8XIiroNPn6uMT9rxZ7qeEFWXvYjosNCV2dXBYj5IxcLNnvxD/oqMJgm1d3aCEiD23NlOpKlXmV+KS2uervLu8rEx2v132icTYH9sO5D0viD2MsPiZXdNCqfEJwopp3NVIs753xO5Dlr7rXIj00GhUM5orPJVs30sKGZpQRyqKemuLh5VgYvHz52A5oR/IjU+bZjD2O3xUgB+ZtAeHicfLGEKOaSzC6VU9YFFAN6Q1x80WrOPxkUl4i0OeEAjcm7IafMZnevnJtZXgW8Ti68OEwdR5bFcY0rffe2F6NwUwl9obF7jnnc2OUoJ66f15nH1qFVYK/kbdnQGQ2ChqI0224+wMt+l6KrT5mRVzPI222Nv83OSd8Z5bROyquiITPB5bbw5Z18w20UWTBZY/LqONe/k4LEgOctpiLm7rt2eh0RPb1qSJ4QkEi4ePC0vr6rGjmiuv6Xcf4KsKcyM+vwDgHEslOao6gdlb4DUQ/VC4QLgeTp/wvJgFL36CNErrskd0rffV0eXh8dt4Fc+Wqw46CU3fMAd2G/BPPj9Gxv852VX+8flCx6w8epyEV4N7/nQa6Bmocq+j+UE+Ck+l6uGF9YNpL0WZ9Juyy";
				dictionary["ShippingMethodUUID"] = "nS2sFf0L12MAAAFZ6j3hqc5n";
				dictionary["termsAndConditions"] = "on";
				dictionary["email_Newsletter"] = "true";
				dictionary["GDPRDataComplianceRequired"] = "true";
				dictionary["sendOrder"] = string.Empty;
				TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class14_0.method_3(string.Format("https://{0}/INTERSHOP/web/WFS/Footlocker-Footlocker_GB-Site/en_GB/-/GBP/ViewCheckoutOverview-Dispatch", this.string_10), dictionary, true).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter<HttpResponseMessage> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
				}
				TaskAwaiter<string> taskAwaiter3 = taskAwaiter.GetResult().smethod_3().GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<string> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<string>);
				}
				string result = taskAwaiter3.GetResult();
				if (result.Contains("Checkout is currently not possible"))
				{
					throw new Exception();
				}
				HtmlDocument htmlDocument = new HtmlDocument();
				htmlDocument.LoadHtml(result);
				foreach (HtmlNode htmlNode in ((IEnumerable<HtmlNode>)htmlDocument.DocumentNode.SelectNodes("//form//input")))
				{
					if (htmlNode.Attributes.Contains("value") && htmlNode.Attributes.Contains("name"))
					{
						this.dictionary_1[htmlNode.Attributes["name"].Value] = htmlNode.Attributes["value"].Value;
					}
				}
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

	// Token: 0x060005DE RID: 1502 RVA: 0x00032428 File Offset: 0x00030628
	public async Task method_19()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Going to payment", "#c2c2c2", true, false);
				TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class14_0.method_3("https://live.barclaycardsmartpay.com/hpp/pay.shtml", this.dictionary_1, false).GetAwaiter();
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
				if (result2.Contains("Unfortunately we were unable to process this request"))
				{
					base.method_0("Payment error", "red", true, (GEnum1)0);
				}
				HtmlDocument htmlDocument = new HtmlDocument();
				htmlDocument.LoadHtml(result2);
				foreach (HtmlNode htmlNode in ((IEnumerable<HtmlNode>)htmlDocument.DocumentNode.SelectNodes("//form//input")))
				{
					if (htmlNode.Attributes.Contains("value") && htmlNode.Attributes.Contains("name"))
					{
						this.dictionary_2[htmlNode.Attributes["name"].Value] = htmlNode.Attributes["value"].Value;
					}
				}
				this.dictionary_2["displayGroup"] = "card";
				this.dictionary_2["card.cardNumber"] = (string)this.jtoken_1["payment"]["card"]["number"];
				this.dictionary_2["card.cardHolderName"] = this.jtoken_1["billing"]["first_name"] + " " + this.jtoken_1["billing"]["last_name"];
				this.dictionary_2["card.expiryMonth"] = (string)this.jtoken_1["payment"]["card"]["exp_month"];
				this.dictionary_2["card.expiryYear"] = (string)this.jtoken_1["payment"]["card"]["exp_year"];
				this.dictionary_2["card.cvcCode"] = (string)this.jtoken_1["payment"]["card"]["cvv"];
				this.dictionary_2.Remove("back");
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error going to payment", "#c2c2c2", true, false);
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

	// Token: 0x060005DF RID: 1503 RVA: 0x00032470 File Offset: 0x00030670
	public async Task method_20()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Submitting payment", "orange", true, false);
				string text = (await this.class14_0.method_3("https://live.barclaycardsmartpay.com/hpp/completeCard.shtml", this.dictionary_2, false)).Headers.Location.ToString();
				if (text.Contains("3d-redirect"))
				{
					base.method_5("Processing payment", "orange", true, false);
					HttpResponseMessage httpResponseMessage = await this.class14_0.method_2("https://live.barclaycardsmartpay.com" + text, false);
					httpResponseMessage.EnsureSuccessStatusCode();
					string text2 = await httpResponseMessage.smethod_3();
					HtmlDocument htmlDocument = new HtmlDocument();
					htmlDocument.LoadHtml(text2);
					Dictionary<string, string> dictionary = new Dictionary<string, string>();
					foreach (HtmlNode htmlNode in ((IEnumerable<HtmlNode>)htmlDocument.DocumentNode.SelectNodes("//form[@id='pageform']//input[@name][@value]")))
					{
						dictionary[htmlNode.Attributes["name"].Value] = htmlNode.Attributes["value"].Value;
					}
					text2 = await(await this.class14_0.method_3(htmlDocument.DocumentNode.SelectSingleNode("//form[@id='pageform']").Attributes["action"].Value, dictionary, false)).smethod_3();
					if (!text2.Contains("downloadForm"))
					{
						base.method_0("Unsupported card (3D Secure)", "red", true, (GEnum1)0);
					}
					htmlDocument.LoadHtml(text2);
					dictionary = new Dictionary<string, string>();
					foreach (HtmlNode htmlNode2 in ((IEnumerable<HtmlNode>)htmlDocument.DocumentNode.SelectNodes("//form[@name='downloadForm']//input[@name][@value]")))
					{
						dictionary[htmlNode2.Attributes["name"].Value] = htmlNode2.Attributes["value"].Value;
					}
					text = (await this.class14_0.method_3(htmlDocument.DocumentNode.SelectSingleNode("//form[@name='downloadForm']").Attributes["action"].Value, dictionary, false)).Headers.Location.ToString();
					htmlDocument = null;
				}
				if (text.Contains("authResult=REFUSED") || text.Contains("authResult=CANCELLED"))
				{
					base.method_0("Payment Declined", "red", true, (GEnum1)5);
					break;
				}
				if (text.Contains("authResult=AUTHORISED"))
				{
					base.method_5("Submitting order", "orange", true, false);
					TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class14_0.method_2(text, false).GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						await taskAwaiter;
						TaskAwaiter<HttpResponseMessage> taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
					}
					taskAwaiter.GetResult();
					base.method_0("Successfully checked out", "green", true, (GEnum1)6);
					break;
				}
				base.method_0("Payment error", "red", true, (GEnum1)0);
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error submitting payment", "#c2c2c2", true, false);
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
			}
		}
	}

	// Token: 0x04000464 RID: 1124
	private string string_7;

	// Token: 0x04000465 RID: 1125
	private string string_8;

	// Token: 0x04000466 RID: 1126
	private string string_9;

	// Token: 0x04000467 RID: 1127
	private Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();

	// Token: 0x04000468 RID: 1128
	private Dictionary<string, string> dictionary_1 = new Dictionary<string, string>();

	// Token: 0x04000469 RID: 1129
	private Dictionary<string, string> dictionary_2 = new Dictionary<string, string>();

	// Token: 0x0400046A RID: 1130
	private string string_10;

	// Token: 0x020000FE RID: 254
	[StructLayout(LayoutKind.Auto)]
	private struct Struct88 : IAsyncStateMachine
	{
		// Token: 0x060005E0 RID: 1504 RVA: 0x000324B8 File Offset: 0x000306B8
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class49 @class = this;
			try
			{
				if (num <= 4)
				{
					goto IL_393;
				}
				if (num != 5)
				{
					goto IL_388;
				}
				TaskAwaiter taskAwaiter7 = taskAwaiter4;
				taskAwaiter4 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_381:
				taskAwaiter7.GetResult();
				IL_388:
				if (@class.bool_1)
				{
					goto IL_3D4;
				}
				int num4 = 0;
				IL_393:
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter8;
					TaskAwaiter<string> taskAwaiter9;
					switch (num)
					{
					case 0:
					{
						taskAwaiter8 = taskAwaiter6;
						taskAwaiter6 = default(TaskAwaiter<HttpResponseMessage>);
						int num5 = -1;
						num = -1;
						num2 = num5;
						break;
					}
					case 1:
					{
						taskAwaiter7 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter);
						int num6 = -1;
						num = -1;
						num2 = num6;
						goto IL_197;
					}
					case 2:
					{
						taskAwaiter8 = taskAwaiter6;
						taskAwaiter6 = default(TaskAwaiter<HttpResponseMessage>);
						int num7 = -1;
						num = -1;
						num2 = num7;
						goto IL_1D2;
					}
					case 3:
					{
						taskAwaiter9 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<string>);
						int num8 = -1;
						num = -1;
						num2 = num8;
						goto IL_201;
					}
					case 4:
					{
						taskAwaiter9 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<string>);
						int num9 = -1;
						num = -1;
						num2 = num9;
						goto IL_2F7;
					}
					default:
						@class.method_5("Adding to cart", "#c2c2c2", true, false);
						@class.dictionary_0["SynchronizerToken"] = @class.string_9;
						taskAwaiter8 = @class.class14_0.method_3(string.Format("https://{0}/en/addtocart", @class.string_10), @class.dictionary_0, false).GetAwaiter();
						if (!taskAwaiter8.IsCompleted)
						{
							int num10 = 0;
							num = 0;
							num2 = num10;
							taskAwaiter6 = taskAwaiter8;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class49.Struct88>(ref taskAwaiter8, ref this);
							return;
						}
						break;
					}
					HttpResponseMessage result = taskAwaiter8.GetResult();
					httpResponseMessage = result;
					goto IL_1E3;
					IL_197:
					taskAwaiter7.GetResult();
					taskAwaiter8 = @class.class14_0.method_3(string.Format("https://{0}/en/addtocart", @class.string_10), @class.dictionary_0, false).GetAwaiter();
					if (!taskAwaiter8.IsCompleted)
					{
						int num11 = 2;
						num = 2;
						num2 = num11;
						taskAwaiter6 = taskAwaiter8;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class49.Struct88>(ref taskAwaiter8, ref this);
						return;
					}
					IL_1D2:
					result = taskAwaiter8.GetResult();
					httpResponseMessage = result;
					IL_1E3:
					taskAwaiter9 = httpResponseMessage.smethod_3().GetAwaiter();
					if (!taskAwaiter9.IsCompleted)
					{
						int num12 = 3;
						num = 3;
						num2 = num12;
						taskAwaiter2 = taskAwaiter9;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class49.Struct88>(ref taskAwaiter9, ref this);
						return;
					}
					IL_201:
					if (!taskAwaiter9.GetResult().Contains("Product can not be added before launch date"))
					{
						htmlDocument = new HtmlDocument();
						htmlDocument2 = htmlDocument;
						taskAwaiter9 = httpResponseMessage.smethod_3().GetAwaiter();
						if (!taskAwaiter9.IsCompleted)
						{
							int num13 = 4;
							num = 4;
							num2 = num13;
							taskAwaiter2 = taskAwaiter9;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class49.Struct88>(ref taskAwaiter9, ref this);
							return;
						}
					}
					else
					{
						@class.method_5("Waiting for release", "#c2c2c2", true, false);
						taskAwaiter7 = @class.method_14(Class130.int_1).GetAwaiter();
						if (taskAwaiter7.IsCompleted)
						{
							goto IL_197;
						}
						int num14 = 1;
						num = 1;
						num2 = num14;
						taskAwaiter4 = taskAwaiter7;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class49.Struct88>(ref taskAwaiter7, ref this);
						return;
					}
					IL_2F7:
					string result2 = taskAwaiter9.GetResult();
					htmlDocument2.LoadHtml(result2);
					htmlDocument2 = null;
					@class.method_7(htmlDocument.DocumentNode.SelectSingleNode("//span[@itemprop='name']").InnerText, "#c2c2c2");
					httpResponseMessage.EnsureSuccessStatusCode();
					goto IL_3D4;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_388;
				}
				@class.method_5("Error adding to cart", "#c2c2c2", true, false);
				taskAwaiter7 = @class.method_14(Class130.int_1).GetAwaiter();
				if (taskAwaiter7.IsCompleted)
				{
					goto IL_381;
				}
				int num15 = 5;
				num = 5;
				num2 = num15;
				taskAwaiter4 = taskAwaiter7;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class49.Struct88>(ref taskAwaiter7, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_3D4:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060005E1 RID: 1505 RVA: 0x00005743 File Offset: 0x00003943
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400046B RID: 1131
		public int int_0;

		// Token: 0x0400046C RID: 1132
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x0400046D RID: 1133
		public Class49 class49_0;

		// Token: 0x0400046E RID: 1134
		private HttpResponseMessage httpResponseMessage_0;

		// Token: 0x0400046F RID: 1135
		private HtmlDocument htmlDocument_0;

		// Token: 0x04000470 RID: 1136
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000471 RID: 1137
		private TaskAwaiter taskAwaiter_1;

		// Token: 0x04000472 RID: 1138
		private TaskAwaiter<string> taskAwaiter_2;

		// Token: 0x04000473 RID: 1139
		private HtmlDocument htmlDocument_1;
	}

	// Token: 0x020000FF RID: 255
	[StructLayout(LayoutKind.Auto)]
	private struct Struct89 : IAsyncStateMachine
	{
		// Token: 0x060005E2 RID: 1506 RVA: 0x000328E0 File Offset: 0x00030AE0
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class49 @class = this;
			try
			{
				if (num <= 1)
				{
					goto IL_393;
				}
				if (num != 2)
				{
					goto IL_388;
				}
				TaskAwaiter taskAwaiter7 = taskAwaiter6;
				taskAwaiter6 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_381:
				taskAwaiter7.GetResult();
				IL_388:
				if (@class.bool_1)
				{
					goto IL_3D5;
				}
				int num4 = 0;
				IL_393:
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
							goto IL_163;
						}
						@class.method_5("Waiting for product", "#c2c2c2", true, false);
						taskAwaiter9 = GClass2.smethod_1(string.Format("https://www.footlocker.eu/INTERSHOP/web/WFS/Footlocker-Footlocker_GB-Site/en_GB/-/GBP/ViewProduct-ProductVariationSelect?BaseSKU={0}&InventoryServerity=ProductDetail", @class.string_8), null, true).GetAwaiter();
						if (!taskAwaiter9.IsCompleted)
						{
							int num6 = 0;
							num = 0;
							num2 = num6;
							taskAwaiter2 = taskAwaiter9;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class49.Struct89>(ref taskAwaiter9, ref this);
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
					if (result.StatusCode == HttpStatusCode.NotFound)
					{
						@class.method_0("Invalid URL (404)", "red", true, (GEnum1)0);
					}
					result.EnsureSuccessStatusCode();
					htmlDocument = new HtmlDocument();
					htmlDocument2 = htmlDocument;
					taskAwaiter8 = result.smethod_1().GetAwaiter();
					if (!taskAwaiter8.IsCompleted)
					{
						int num8 = 1;
						num = 1;
						num2 = num8;
						taskAwaiter4 = taskAwaiter8;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class49.Struct89>(ref taskAwaiter8, ref this);
						return;
					}
					IL_163:
					JObject result2 = taskAwaiter8.GetResult();
					htmlDocument2.LoadHtml(result2["content"].ToString());
					htmlDocument2 = null;
					if (@class.bool_0)
					{
						HtmlNodeCollection htmlNodeCollection = htmlDocument.DocumentNode.SelectNodes("//*[@class='fl-product-size--item']");
						if (htmlNodeCollection == null)
						{
							@class.method_0("Size unavailable", "red", true, (GEnum1)0);
						}
						@class.string_7 = htmlNodeCollection[MainWindow.random_0.Next(0, htmlNodeCollection.Count)].Attributes["data-form-field-value"].Value;
					}
					else
					{
						HtmlNode htmlNode = htmlDocument.DocumentNode.SelectSingleNode(string.Format("//span[contains(text(),'{0}')]", @class.string_0));
						if (htmlNode != null)
						{
							@class.string_7 = htmlNode.ParentNode.Attributes["data-form-field-value"].Value;
						}
						else
						{
							@class.method_0("Size unavailable", "red", true, (GEnum1)0);
						}
					}
					IEnumerator<HtmlNode> enumerator = ((IEnumerable<HtmlNode>)htmlDocument.DocumentNode.SelectNodes("//input")).GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							HtmlNode htmlNode2 = enumerator.Current;
							if (htmlNode2.Attributes.Contains("value") && htmlNode2.Attributes.Contains("name"))
							{
								if (htmlNode2.Attributes["name"].Value.ToLower().Contains("quantity"))
								{
									@class.dictionary_0[htmlNode2.Attributes["name"].Value] = "1";
								}
								else
								{
									@class.dictionary_0[htmlNode2.Attributes["name"].Value] = htmlNode2.Attributes["value"].Value;
								}
							}
						}
					}
					finally
					{
						if (num < 0 && enumerator != null)
						{
							enumerator.Dispose();
						}
					}
					@class.dictionary_0["SKU"] = @class.string_7;
					goto IL_3D5;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_388;
				}
				taskAwaiter7 = @class.method_14(Class130.int_0).GetAwaiter();
				if (taskAwaiter7.IsCompleted)
				{
					goto IL_381;
				}
				int num9 = 2;
				num = 2;
				num2 = num9;
				taskAwaiter6 = taskAwaiter7;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class49.Struct89>(ref taskAwaiter7, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_3D5:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060005E3 RID: 1507 RVA: 0x00005751 File Offset: 0x00003951
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000474 RID: 1140
		public int int_0;

		// Token: 0x04000475 RID: 1141
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000476 RID: 1142
		public Class49 class49_0;

		// Token: 0x04000477 RID: 1143
		private HtmlDocument htmlDocument_0;

		// Token: 0x04000478 RID: 1144
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000479 RID: 1145
		private HtmlDocument htmlDocument_1;

		// Token: 0x0400047A RID: 1146
		private TaskAwaiter<JObject> taskAwaiter_1;

		// Token: 0x0400047B RID: 1147
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x02000100 RID: 256
	[StructLayout(LayoutKind.Auto)]
	private struct Struct90 : IAsyncStateMachine
	{
		// Token: 0x060005E4 RID: 1508 RVA: 0x00032D24 File Offset: 0x00030F24
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class49 @class = this;
			try
			{
				if (num <= 1)
				{
					goto IL_1FF;
				}
				if (num != 2)
				{
					goto IL_1F5;
				}
				TaskAwaiter taskAwaiter7 = taskAwaiter6;
				taskAwaiter6 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_1EE:
				taskAwaiter7.GetResult();
				IL_1F5:
				if (@class.bool_1)
				{
					goto IL_241;
				}
				int num4 = 0;
				IL_1FF:
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
							goto IL_12E;
						}
						@class.method_5("Getting token", "#c2c2c2", true, false);
						taskAwaiter9 = @class.class14_0.method_2("https://www.footlocker.eu/en/homepage", true).GetAwaiter();
						if (!taskAwaiter9.IsCompleted)
						{
							int num6 = 0;
							num = 0;
							num2 = num6;
							taskAwaiter2 = taskAwaiter9;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class49.Struct90>(ref taskAwaiter9, ref this);
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
					htmlDocument = new HtmlDocument();
					htmlDocument2 = htmlDocument;
					taskAwaiter8 = result.smethod_3().GetAwaiter();
					if (!taskAwaiter8.IsCompleted)
					{
						int num8 = 1;
						num = 1;
						num2 = num8;
						taskAwaiter4 = taskAwaiter8;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class49.Struct90>(ref taskAwaiter8, ref this);
						return;
					}
					IL_12E:
					string result2 = taskAwaiter8.GetResult();
					htmlDocument2.LoadHtml(result2);
					htmlDocument2 = null;
					@class.string_10 = new Uri(htmlDocument.DocumentNode.SelectSingleNode("//a[@class='fl-header--logo']").Attributes["href"].Value).Host;
					@class.string_9 = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='SynchronizerToken']").Attributes["value"].Value;
					goto IL_241;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_1F5;
				}
				@class.method_5("Error getting token", "#c2c2c2", true, false);
				taskAwaiter7 = @class.method_14(Class130.int_1).GetAwaiter();
				if (taskAwaiter7.IsCompleted)
				{
					goto IL_1EE;
				}
				int num9 = 2;
				num = 2;
				num2 = num9;
				taskAwaiter6 = taskAwaiter7;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class49.Struct90>(ref taskAwaiter7, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_241:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060005E5 RID: 1509 RVA: 0x0000575F File Offset: 0x0000395F
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400047C RID: 1148
		public int int_0;

		// Token: 0x0400047D RID: 1149
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x0400047E RID: 1150
		public Class49 class49_0;

		// Token: 0x0400047F RID: 1151
		private HtmlDocument htmlDocument_0;

		// Token: 0x04000480 RID: 1152
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000481 RID: 1153
		private HtmlDocument htmlDocument_1;

		// Token: 0x04000482 RID: 1154
		private TaskAwaiter<string> taskAwaiter_1;

		// Token: 0x04000483 RID: 1155
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x02000101 RID: 257
	[StructLayout(LayoutKind.Auto)]
	private struct Struct91 : IAsyncStateMachine
	{
		// Token: 0x060005E6 RID: 1510 RVA: 0x00032FBC File Offset: 0x000311BC
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class49 @class = this;
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
						goto IL_EB;
					}
					case 2:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_146;
					}
					case 3:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_1A1;
					}
					case 4:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_1FC;
					}
					case 5:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_257;
					}
					case 6:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_2AF;
					}
					default:
						taskAwaiter = @class.method_11().GetAwaiter();
						if (!taskAwaiter.IsCompleted)
						{
							num2 = 0;
							TaskAwaiter taskAwaiter2 = taskAwaiter;
							this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class49.Struct91>(ref taskAwaiter, ref this);
							return;
						}
						break;
					}
					taskAwaiter.GetResult();
					task = @class.method_15();
					taskAwaiter = @class.method_16().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 1;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class49.Struct91>(ref taskAwaiter, ref this);
						return;
					}
					IL_EB:
					taskAwaiter.GetResult();
					taskAwaiter = task.GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 2;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class49.Struct91>(ref taskAwaiter, ref this);
						return;
					}
					IL_146:
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_17().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 3;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class49.Struct91>(ref taskAwaiter, ref this);
						return;
					}
					IL_1A1:
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_18().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 4;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class49.Struct91>(ref taskAwaiter, ref this);
						return;
					}
					IL_1FC:
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_19().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 5;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class49.Struct91>(ref taskAwaiter, ref this);
						return;
					}
					IL_257:
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_20().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 6;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class49.Struct91>(ref taskAwaiter, ref this);
						return;
					}
					IL_2AF:
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

		// Token: 0x060005E7 RID: 1511 RVA: 0x0000576D File Offset: 0x0000396D
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000484 RID: 1156
		public int int_0;

		// Token: 0x04000485 RID: 1157
		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		// Token: 0x04000486 RID: 1158
		public Class49 class49_0;

		// Token: 0x04000487 RID: 1159
		private Task task_0;

		// Token: 0x04000488 RID: 1160
		private TaskAwaiter taskAwaiter_0;
	}

	// Token: 0x02000102 RID: 258
	[StructLayout(LayoutKind.Auto)]
	private struct Struct92 : IAsyncStateMachine
	{
		// Token: 0x060005E8 RID: 1512 RVA: 0x00033300 File Offset: 0x00031500
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class49 @class = this;
			try
			{
				if (num <= 1)
				{
					goto IL_397;
				}
				if (num != 2)
				{
					goto IL_38C;
				}
				TaskAwaiter taskAwaiter7 = taskAwaiter6;
				taskAwaiter6 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_385:
				taskAwaiter7.GetResult();
				IL_38C:
				if (@class.bool_1)
				{
					goto IL_3D9;
				}
				int num4 = 0;
				IL_397:
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
						@class.method_5("Going to payment", "#c2c2c2", true, false);
						taskAwaiter9 = @class.class14_0.method_3("https://live.barclaycardsmartpay.com/hpp/pay.shtml", @class.dictionary_1, false).GetAwaiter();
						if (!taskAwaiter9.IsCompleted)
						{
							int num6 = 0;
							num = 0;
							num2 = num6;
							taskAwaiter2 = taskAwaiter9;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class49.Struct92>(ref taskAwaiter9, ref this);
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
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class49.Struct92>(ref taskAwaiter8, ref this);
						return;
					}
					IL_12A:
					string result2 = taskAwaiter8.GetResult();
					if (result2.Contains("Unfortunately we were unable to process this request"))
					{
						@class.method_0("Payment error", "red", true, (GEnum1)0);
					}
					HtmlDocument htmlDocument = new HtmlDocument();
					htmlDocument.LoadHtml(result2);
					IEnumerator<HtmlNode> enumerator = ((IEnumerable<HtmlNode>)htmlDocument.DocumentNode.SelectNodes("//form//input")).GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							HtmlNode htmlNode = enumerator.Current;
							if (htmlNode.Attributes.Contains("value") && htmlNode.Attributes.Contains("name"))
							{
								@class.dictionary_2[htmlNode.Attributes["name"].Value] = htmlNode.Attributes["value"].Value;
							}
						}
					}
					finally
					{
						if (num < 0 && enumerator != null)
						{
							enumerator.Dispose();
						}
					}
					@class.dictionary_2["displayGroup"] = "card";
					@class.dictionary_2["card.cardNumber"] = (string)@class.jtoken_1["payment"]["card"]["number"];
					@class.dictionary_2["card.cardHolderName"] = @class.jtoken_1["billing"]["first_name"] + " " + @class.jtoken_1["billing"]["last_name"];
					@class.dictionary_2["card.expiryMonth"] = (string)@class.jtoken_1["payment"]["card"]["exp_month"];
					@class.dictionary_2["card.expiryYear"] = (string)@class.jtoken_1["payment"]["card"]["exp_year"];
					@class.dictionary_2["card.cvcCode"] = (string)@class.jtoken_1["payment"]["card"]["cvv"];
					@class.dictionary_2.Remove("back");
					goto IL_3D9;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_38C;
				}
				@class.method_5("Error going to payment", "#c2c2c2", true, false);
				taskAwaiter7 = @class.method_14(Class130.int_1).GetAwaiter();
				if (taskAwaiter7.IsCompleted)
				{
					goto IL_385;
				}
				int num9 = 2;
				num = 2;
				num2 = num9;
				taskAwaiter6 = taskAwaiter7;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class49.Struct92>(ref taskAwaiter7, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_3D9:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060005E9 RID: 1513 RVA: 0x0000577B File Offset: 0x0000397B
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000489 RID: 1161
		public int int_0;

		// Token: 0x0400048A RID: 1162
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x0400048B RID: 1163
		public Class49 class49_0;

		// Token: 0x0400048C RID: 1164
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x0400048D RID: 1165
		private TaskAwaiter<string> taskAwaiter_1;

		// Token: 0x0400048E RID: 1166
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x02000103 RID: 259
	[StructLayout(LayoutKind.Auto)]
	private struct Struct93 : IAsyncStateMachine
	{
		// Token: 0x060005EA RID: 1514 RVA: 0x00033748 File Offset: 0x00031948
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class49 @class = this;
			try
			{
				if (num <= 6)
				{
					goto IL_5DD;
				}
				if (num != 7)
				{
					goto IL_5D2;
				}
				TaskAwaiter taskAwaiter5 = taskAwaiter4;
				taskAwaiter4 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_5CB:
				taskAwaiter5.GetResult();
				IL_5D2:
				if (@class.bool_1)
				{
					goto IL_61F;
				}
				int num4 = 0;
				IL_5DD:
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter6;
					TaskAwaiter<string> taskAwaiter7;
					switch (num)
					{
					case 0:
					{
						taskAwaiter6 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
						int num5 = -1;
						num = -1;
						num2 = num5;
						break;
					}
					case 1:
					{
						taskAwaiter6 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
						int num6 = -1;
						num = -1;
						num2 = num6;
						goto IL_17A;
					}
					case 2:
					{
						TaskAwaiter<string> taskAwaiter8;
						taskAwaiter7 = taskAwaiter8;
						taskAwaiter8 = default(TaskAwaiter<string>);
						int num7 = -1;
						num = -1;
						num2 = num7;
						goto IL_1DE;
					}
					case 3:
					{
						taskAwaiter6 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
						int num8 = -1;
						num = -1;
						num2 = num8;
						goto IL_2FC;
					}
					case 4:
					{
						TaskAwaiter<string> taskAwaiter8;
						taskAwaiter7 = taskAwaiter8;
						taskAwaiter8 = default(TaskAwaiter<string>);
						int num9 = -1;
						num = -1;
						num2 = num9;
						goto IL_359;
					}
					case 5:
					{
						taskAwaiter6 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
						int num10 = -1;
						num = -1;
						num2 = num10;
						goto IL_48C;
					}
					case 6:
					{
						taskAwaiter6 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
						int num11 = -1;
						num = -1;
						num2 = num11;
						goto IL_574;
					}
					default:
						@class.method_5("Submitting payment", "orange", true, false);
						taskAwaiter6 = @class.class14_0.method_3("https://live.barclaycardsmartpay.com/hpp/completeCard.shtml", @class.dictionary_2, false).GetAwaiter();
						if (!taskAwaiter6.IsCompleted)
						{
							int num12 = 0;
							num = 0;
							num2 = num12;
							taskAwaiter2 = taskAwaiter6;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class49.Struct93>(ref taskAwaiter6, ref this);
							return;
						}
						break;
					}
					string text = taskAwaiter6.GetResult().Headers.Location.ToString();
					if (!text.Contains("3d-redirect"))
					{
						goto IL_4AB;
					}
					@class.method_5("Processing payment", "orange", true, false);
					taskAwaiter6 = @class.class14_0.method_2("https://live.barclaycardsmartpay.com" + text, false).GetAwaiter();
					if (!taskAwaiter6.IsCompleted)
					{
						int num13 = 1;
						num = 1;
						num2 = num13;
						taskAwaiter2 = taskAwaiter6;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class49.Struct93>(ref taskAwaiter6, ref this);
						return;
					}
					IL_17A:
					HttpResponseMessage result = taskAwaiter6.GetResult();
					result.EnsureSuccessStatusCode();
					taskAwaiter7 = result.smethod_3().GetAwaiter();
					if (!taskAwaiter7.IsCompleted)
					{
						int num14 = 2;
						num = 2;
						num2 = num14;
						TaskAwaiter<string> taskAwaiter8 = taskAwaiter7;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class49.Struct93>(ref taskAwaiter7, ref this);
						return;
					}
					IL_1DE:
					string result2 = taskAwaiter7.GetResult();
					htmlDocument = new HtmlDocument();
					htmlDocument.LoadHtml(result2);
					Dictionary<string, string> dictionary = new Dictionary<string, string>();
					IEnumerator<HtmlNode> enumerator = ((IEnumerable<HtmlNode>)htmlDocument.DocumentNode.SelectNodes("//form[@id='pageform']//input[@name][@value]")).GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							HtmlNode htmlNode = enumerator.Current;
							dictionary[htmlNode.Attributes["name"].Value] = htmlNode.Attributes["value"].Value;
						}
					}
					finally
					{
						if (num < 0 && enumerator != null)
						{
							enumerator.Dispose();
						}
					}
					taskAwaiter6 = @class.class14_0.method_3(htmlDocument.DocumentNode.SelectSingleNode("//form[@id='pageform']").Attributes["action"].Value, dictionary, false).GetAwaiter();
					if (!taskAwaiter6.IsCompleted)
					{
						int num15 = 3;
						num = 3;
						num2 = num15;
						taskAwaiter2 = taskAwaiter6;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class49.Struct93>(ref taskAwaiter6, ref this);
						return;
					}
					IL_2FC:
					taskAwaiter7 = taskAwaiter6.GetResult().smethod_3().GetAwaiter();
					if (!taskAwaiter7.IsCompleted)
					{
						int num16 = 4;
						num = 4;
						num2 = num16;
						TaskAwaiter<string> taskAwaiter8 = taskAwaiter7;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class49.Struct93>(ref taskAwaiter7, ref this);
						return;
					}
					IL_359:
					result2 = taskAwaiter7.GetResult();
					if (!result2.Contains("downloadForm"))
					{
						@class.method_0("Unsupported card (3D Secure)", "red", true, (GEnum1)0);
					}
					htmlDocument.LoadHtml(result2);
					dictionary = new Dictionary<string, string>();
					enumerator = ((IEnumerable<HtmlNode>)htmlDocument.DocumentNode.SelectNodes("//form[@name='downloadForm']//input[@name][@value]")).GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							HtmlNode htmlNode2 = enumerator.Current;
							dictionary[htmlNode2.Attributes["name"].Value] = htmlNode2.Attributes["value"].Value;
						}
					}
					finally
					{
						if (num < 0 && enumerator != null)
						{
							enumerator.Dispose();
						}
					}
					taskAwaiter6 = @class.class14_0.method_3(htmlDocument.DocumentNode.SelectSingleNode("//form[@name='downloadForm']").Attributes["action"].Value, dictionary, false).GetAwaiter();
					if (!taskAwaiter6.IsCompleted)
					{
						int num17 = 5;
						num = 5;
						num2 = num17;
						taskAwaiter2 = taskAwaiter6;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class49.Struct93>(ref taskAwaiter6, ref this);
						return;
					}
					IL_48C:
					text = taskAwaiter6.GetResult().Headers.Location.ToString();
					htmlDocument = null;
					IL_4AB:
					if (text.Contains("authResult=REFUSED") || text.Contains("authResult=CANCELLED"))
					{
						@class.method_0("Payment Declined", "red", true, (GEnum1)5);
						goto IL_61F;
					}
					if (!text.Contains("authResult=AUTHORISED"))
					{
						@class.method_0("Payment error", "red", true, (GEnum1)0);
						goto IL_61F;
					}
					@class.method_5("Submitting order", "orange", true, false);
					taskAwaiter6 = @class.class14_0.method_2(text, false).GetAwaiter();
					if (!taskAwaiter6.IsCompleted)
					{
						int num18 = 6;
						num = 6;
						num2 = num18;
						taskAwaiter2 = taskAwaiter6;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class49.Struct93>(ref taskAwaiter6, ref this);
						return;
					}
					IL_574:
					taskAwaiter6.GetResult();
					@class.method_0("Successfully checked out", "green", true, (GEnum1)6);
					goto IL_61F;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_5D2;
				}
				@class.method_5("Error submitting payment", "#c2c2c2", true, false);
				taskAwaiter5 = @class.method_14(Class130.int_1).GetAwaiter();
				if (taskAwaiter5.IsCompleted)
				{
					goto IL_5CB;
				}
				int num19 = 7;
				num = 7;
				num2 = num19;
				taskAwaiter4 = taskAwaiter5;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class49.Struct93>(ref taskAwaiter5, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_61F:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060005EB RID: 1515 RVA: 0x00005789 File Offset: 0x00003989
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400048F RID: 1167
		public int int_0;

		// Token: 0x04000490 RID: 1168
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000491 RID: 1169
		public Class49 class49_0;

		// Token: 0x04000492 RID: 1170
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000493 RID: 1171
		private HtmlDocument htmlDocument_0;

		// Token: 0x04000494 RID: 1172
		private TaskAwaiter<string> taskAwaiter_1;

		// Token: 0x04000495 RID: 1173
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x02000104 RID: 260
	[StructLayout(LayoutKind.Auto)]
	private struct Struct94 : IAsyncStateMachine
	{
		// Token: 0x060005EC RID: 1516 RVA: 0x00033DEC File Offset: 0x00031FEC
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class49 @class = this;
			try
			{
				if (num <= 1)
				{
					goto IL_74D;
				}
				if (num != 2)
				{
					goto IL_742;
				}
				TaskAwaiter taskAwaiter7 = taskAwaiter6;
				taskAwaiter6 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_73B:
				taskAwaiter7.GetResult();
				IL_742:
				if (@class.bool_1)
				{
					goto IL_78F;
				}
				int num4 = 0;
				IL_74D:
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
							goto IL_63F;
						}
						@class.method_5("Submitting shipping", "#c2c2c2", true, false);
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary["SynchronizerToken"] = @class.string_9;
						dictionary["billing_Address3"] = string.Empty;
						dictionary["isshippingaddress"] = string.Empty;
						dictionary["billing_Title"] = "common.account.salutation.mr.text";
						dictionary["billing_FirstName"] = (string)@class.jtoken_1["billing"]["first_name"];
						dictionary["billing_LastName"] = (string)@class.jtoken_1["billing"]["last_name"];
						dictionary["billing_Address1"] = (string)@class.jtoken_1["billing"]["addr1"];
						dictionary["billing_Address2"] = (@class.jtoken_1["billing"]["addr1"].ToString().Split(new char[]
						{
							' '
						})[0].smethod_15() ? @class.jtoken_1["billing"]["addr1"].ToString().Split(new char[]
						{
							' '
						})[0] : "0");
						dictionary["billing_Address3"] = (string)@class.jtoken_1["billing"]["addr2"];
						dictionary["billing_City"] = (string)@class.jtoken_1["billing"]["city"];
						dictionary["billing_PostalCode"] = (string)@class.jtoken_1["billing"]["zip"];
						dictionary["billing_CountryCode"] = Class43.smethod_0((string)@class.jtoken_1["billing"]["country"], false);
						dictionary["billing_PhoneHome"] = (string)@class.jtoken_1["payment"]["phone"];
						dictionary["billing_BirthdayRequired"] = "true";
						dictionary["billing_Birthday_Day"] = "01";
						dictionary["billing_Birthday_Month"] = "01";
						dictionary["billing_Birthday_Year"] = "1990";
						dictionary["email_Email"] = (string)@class.jtoken_1["payment"]["email"];
						dictionary["billing_ShippingAddressSameAsBilling"] = string.Empty;
						dictionary["isshippingaddress"] = string.Empty;
						dictionary["shipping_Title"] = "common.account.salutation.mr.text";
						dictionary["shipping_FirstName"] = (string)@class.jtoken_1["delivery"]["first_name"];
						dictionary["shipping_LastName"] = (string)@class.jtoken_1["delivery"]["last_name"];
						dictionary["shipping_Address1"] = (string)@class.jtoken_1["delivery"]["addr1"];
						dictionary["shipping_Address2"] = (@class.jtoken_1["delivery"]["addr1"].ToString().Split(new char[]
						{
							' '
						})[0].smethod_15() ? @class.jtoken_1["delivery"]["addr1"].ToString().Split(new char[]
						{
							' '
						})[0] : "0");
						dictionary["shipping_Address3"] = (string)@class.jtoken_1["delivery"]["addr2"];
						dictionary["shipping_City"] = (string)@class.jtoken_1["delivery"]["city"];
						dictionary["shipping_PostalCode"] = (string)@class.jtoken_1["delivery"]["zip"];
						dictionary["shipping_CountryCode"] = Class43.smethod_0((string)@class.jtoken_1["delivery"]["country"], false);
						dictionary["shipping_PhoneHome"] = (string)@class.jtoken_1["payment"]["phone"];
						dictionary["promotionCode"] = string.Empty;
						dictionary["PaymentServiceSelection"] = "dMKsFf0SbRcAAAFNHN88qNaq";
						dictionary["UserDeviceTypeForPaymentRedirect"] = "Desktop";
						dictionary["UserDeviceFingerprintForPaymentRedirect"] = "0400bpNfiPCR/AUNf94lis1zttlRfx+VM0Kfnrp/XmcfWoVVgr+Rt2dAZDYKGojTbbj7Ay36XoqtPmZFXM8jbbY2/zc5J3xnltE7Kq6IhM8HltvDlnXzDbRRZMFlj8uo417+TgsSA5y2mIsp2U5yrYp+5igWriMua6v6UX8EvCKxLeADvSEJLLdt5Y3XI2c5FEWnEFb7LoXxcUNydzLtG4iIzgeXlR0StWcKxwwBzmqrQiWxH1ZPRIwM6njw/ujAyYdbGKZt5JLThTvosS1xgSAgNfLEMokGoGJxgu1y04HLnOzU8XBpd1sDgWA73rYZtIsVyoA80pXCaXawrwf88vayC9C1UJgA1BQZQ4JudHOlf1KSnrbJSNyIsWB9R+WFa6fdxifyrThRovESnjwNVGXSgGQ8InPsuf6/kpMgG84gzO5PMQF00uJew9XqxzJ4y+q4+f7ypk+EO6/K3oOxQXYZs5cTbAHNea+iljAlWwXHcT+hgN6tJA4p1nA+k9XRlIy/cY2AmTS50PVkkRWvZSWgvJFEYUMEnFwrc5V3eY0fJJ82UD3fyk93hC6Bo0qhcOVgxA9x3qRKbjM42PnqoOsl8d3pZ/WuuaUQfveZj4MPqv5NOao4N+06jVc4K6FMki+uv9eOvsyvTBVVGK66EXEuaD0YLXuOWeFzAIsjF5E9P9gJB/s4Mwp5boWRHa+7AHqtF/5t+EKgbjXypamhTYJ5p2IPArjDreTC6uFgohzG6thap+9nixWCRWREjH59g5/QSzKz6zFbyZbyxPMQMv7YZ9mxtLKX2QfncSs2NHNZzALZjVp/OGcTE5Ppv736RSsQQEdu2XYvr46icoEUIBl9dJXAAYR3cfgvWnUHhXIkRJtofM5fO4/4C0OCbnRzpX9Skp62yUjciLFgfUflhWun3cYn8q04UaLxEp48DVRl0oBkPCJz7Ln+v5KTIBvOIMzuTzEBdNLiXsPV6scyeMvquPn+8qZPhDuvyt6DsUF2GbOXE2wBzXmvopYwJVsFx3E/58zGq/hZ0ZoyseD0G1/ThxEIvsJRqGfF9spFd7LTpxjhrt64WqIxSK+Vx63F6egN3u5bh8qtOMZhKoST0dhOCOCSU0oZPWNEfF9hXdZ4DRRkrbXWcoCj3I1znntcmg8XIiroNPn6uMT9rxZ7qeEFWXvYjosNCV2dXBYj5IxcLNnvxD/oqMJgm1d3aCEiD23NlOpKlXmV+KS2uervLu8rEx2v132icTYH9sO5D0viD2MsPiZXdNCqfEJwopp3NVIs753xO5Dlr7rXIj00GhUM5orPJVs30sKGZpQRyqKemuLh5VgYvHz52A5oR/IjU+bZjD2O3xUgB+ZtAeHicfLGEKOaSzC6VU9YFFAN6Q1x80WrOPxkUl4i0OeEAjcm7IafMZnevnJtZXgW8Ti68OEwdR5bFcY0rffe2F6NwUwl9obF7jnnc2OUoJ66f15nH1qFVYK/kbdnQGQ2ChqI0224+wMt+l6KrT5mRVzPI222Nv83OSd8Z5bROyquiITPB5bbw5Z18w20UWTBZY/LqONe/k4LEgOctpiLm7rt2eh0RPb1qSJ4QkEi4ePC0vr6rGjmiuv6Xcf4KsKcyM+vwDgHEslOao6gdlb4DUQ/VC4QLgeTp/wvJgFL36CNErrskd0rffV0eXh8dt4Fc+Wqw46CU3fMAd2G/BPPj9Gxv852VX+8flCx6w8epyEV4N7/nQa6Bmocq+j+UE+Ck+l6uGF9YNpL0WZ9Juyy";
						dictionary["ShippingMethodUUID"] = "nS2sFf0L12MAAAFZ6j3hqc5n";
						dictionary["termsAndConditions"] = "on";
						dictionary["email_Newsletter"] = "true";
						dictionary["GDPRDataComplianceRequired"] = "true";
						dictionary["sendOrder"] = string.Empty;
						taskAwaiter9 = @class.class14_0.method_3(string.Format("https://{0}/INTERSHOP/web/WFS/Footlocker-Footlocker_GB-Site/en_GB/-/GBP/ViewCheckoutOverview-Dispatch", @class.string_10), dictionary, true).GetAwaiter();
						if (!taskAwaiter9.IsCompleted)
						{
							int num6 = 0;
							num = 0;
							num2 = num6;
							taskAwaiter2 = taskAwaiter9;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class49.Struct94>(ref taskAwaiter9, ref this);
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
					taskAwaiter8 = taskAwaiter9.GetResult().smethod_3().GetAwaiter();
					if (!taskAwaiter8.IsCompleted)
					{
						int num8 = 1;
						num = 1;
						num2 = num8;
						taskAwaiter4 = taskAwaiter8;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class49.Struct94>(ref taskAwaiter8, ref this);
						return;
					}
					IL_63F:
					string result = taskAwaiter8.GetResult();
					if (result.Contains("Checkout is currently not possible"))
					{
						throw new Exception();
					}
					HtmlDocument htmlDocument = new HtmlDocument();
					htmlDocument.LoadHtml(result);
					IEnumerator<HtmlNode> enumerator = ((IEnumerable<HtmlNode>)htmlDocument.DocumentNode.SelectNodes("//form//input")).GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							HtmlNode htmlNode = enumerator.Current;
							if (htmlNode.Attributes.Contains("value") && htmlNode.Attributes.Contains("name"))
							{
								@class.dictionary_1[htmlNode.Attributes["name"].Value] = htmlNode.Attributes["value"].Value;
							}
						}
					}
					finally
					{
						if (num < 0 && enumerator != null)
						{
							enumerator.Dispose();
						}
					}
					goto IL_78F;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_742;
				}
				@class.method_5("Error submitting shipping", "#c2c2c2", true, false);
				taskAwaiter7 = @class.method_14(Class130.int_1).GetAwaiter();
				if (taskAwaiter7.IsCompleted)
				{
					goto IL_73B;
				}
				int num9 = 2;
				num = 2;
				num2 = num9;
				taskAwaiter6 = taskAwaiter7;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class49.Struct94>(ref taskAwaiter7, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_78F:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060005ED RID: 1517 RVA: 0x00005797 File Offset: 0x00003997
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000496 RID: 1174
		public int int_0;

		// Token: 0x04000497 RID: 1175
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000498 RID: 1176
		public Class49 class49_0;

		// Token: 0x04000499 RID: 1177
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x0400049A RID: 1178
		private TaskAwaiter<string> taskAwaiter_1;

		// Token: 0x0400049B RID: 1179
		private TaskAwaiter taskAwaiter_2;
	}
}
