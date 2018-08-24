using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;

// Token: 0x02000174 RID: 372
internal sealed class Class53 : Class44
{
	// Token: 0x06000800 RID: 2048 RVA: 0x00046D50 File Offset: 0x00044F50
	public Class53(JToken jtoken_2, string string_17)
	{
		try
		{
			this.jtoken_0 = jtoken_2;
			this.string_16 = string_17;
			if (!base.method_2(out this.jtoken_1))
			{
				base.method_0("Profile error", "red", true, (GEnum1)0);
			}
			else
			{
				this.string_8 = jtoken_2["keywords"].ToString().Replace(" ", string.Empty).ToUpper().Split(new char[]
				{
					','
				}).FirstOrDefault(new Func<string, bool>(Class53.Class176.class176_0.method_0));
				if (this.string_8 == null)
				{
					base.method_0("Invalid SKU", "red", true, (GEnum1)0);
				}
				else
				{
					this.string_9 = jtoken_2["keywords"].ToString().Replace(" ", string.Empty).ToLower().Split(new char[]
					{
						','
					}).Where(new Func<string, bool>(Class53.Class176.class176_0.method_1)).ToArray<string>();
					this.string_0 = ((string)jtoken_2["size"]).Replace("UK ", string.Empty);
					if (this.string_0 == "Random" || this.string_0 == "OneSize")
					{
						this.bool_3 = true;
					}
					this.class14_0 = new Class14(base.method_3(), "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36", 60, false, false, null);
				}
			}
		}
		catch
		{
			base.method_0("Task error", "red", true, (GEnum1)0);
		}
	}

	// Token: 0x06000801 RID: 2049 RVA: 0x00046F14 File Offset: 0x00045114
	public override async void vmethod_0()
	{
		try
		{
			await base.method_11();
			await this.method_16();
			await this.method_17();
			await this.method_18();
			await this.method_19();
			await this.method_20();
			await this.method_21();
			await this.method_22();
			await this.method_23();
		}
		catch
		{
		}
		base.method_0("Stopped", "red", true, (GEnum1)0);
	}

	// Token: 0x06000802 RID: 2050 RVA: 0x00046F50 File Offset: 0x00045150
	public string method_15(string string_17)
	{
		switch (string_17[0])
		{
		case '3':
			return "Amex";
		case '4':
			return "Visa";
		case '5':
			return "MasterCard";
		default:
			return "MasterCard";
		}
	}

	// Token: 0x06000803 RID: 2051 RVA: 0x00046F94 File Offset: 0x00045194
	public async Task method_16()
	{
		base.method_5("Waiting for product", "#c2c2c2", true, false);
		while (!this.bool_1)
		{
			int num = 0;
			TaskAwaiter taskAwaiter2;
			try
			{
				HttpResponseMessage httpResponseMessage = await this.class14_0.method_2(string.Format("https://www.lacoste.com{0}ProductApi-GetProduct?pid={1}", this.string_16, this.string_8), false);
				httpResponseMessage.EnsureSuccessStatusCode();
				JObject jobject = await httpResponseMessage.smethod_1();
				if ((int)jobject["status"] != 0 || object.Equals(false, (bool)jobject["details"]["isOnline"]))
				{
					throw new Exception();
				}
				base.method_7(jobject["details"]["name"].ToString(), "#c2c2c2");
				if (object.Equals(false, (bool)jobject["details"]["isInStock"]))
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
				JToken[] array = jobject["details"]["colors"]["all"].Where(new Func<JToken, bool>(this.method_27)).ToArray<JToken>();
				if (!Class40.smethod_0<JToken>(array))
				{
					throw new Exception();
				}
				if (!Class40.smethod_0<string>(this.string_9))
				{
					this.string_10 = array[MainWindow.random_0.Next(0, array.Count<JToken>())]["ID"].ToString();
				}
				else
				{
					this.string_10 = array[0]["ID"].ToString();
				}
				base.method_5("Found color ID: " + this.string_10, "#c2c2c2", true, false);
				if (this.bool_3)
				{
					JToken jtoken = jobject["details"]["sizes"]["all"];
					if (!jtoken.Any<JToken>())
					{
						base.method_0("Size unavailable", "red", true, (GEnum1)0);
					}
					else
					{
						jtoken = jtoken[MainWindow.random_0.Next(0, jtoken.Count<JToken>() - 1)];
						this.string_11 = jtoken["value"].ToString();
					}
					base.method_6(jtoken["displayValue"].ToString());
				}
				else
				{
					JToken jtoken2 = jobject["details"]["sizes"]["all"].FirstOrDefault(new Func<JToken, bool>(this.method_28));
					if (jtoken2 == null)
					{
						base.method_0("Size unavailable", "red", true, (GEnum1)0);
					}
					else
					{
						this.string_11 = jtoken2["value"].ToString();
					}
				}
				base.method_5("Found size ID: " + this.string_11, "#c2c2c2", true, false);
				break;
			}
			catch (ThreadAbortException)
			{
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				TaskAwaiter taskAwaiter = base.method_14(Class130.int_0).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter.GetResult();
				base.method_5("Waiting for product", "#c2c2c2", true, false);
			}
		}
	}

	// Token: 0x06000804 RID: 2052 RVA: 0x00046FDC File Offset: 0x000451DC
	public async Task method_17()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Waiting for variants", "#c2c2c2", true, false);
				TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class14_0.method_2(string.Format("https://www.lacoste.com{0}ProductV2-SkuProduct?pid={1}&dwvar_{2}_size={3}&dwvar_{4}_color={5}&selectMode=1", new object[]
				{
					this.string_16,
					this.string_8,
					this.string_8,
					this.string_11,
					this.string_8,
					this.string_10
				}), false).GetAwaiter();
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
				this.string_7 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='pid']").Attributes["value"].Value;
				base.method_5("Found PID: " + this.string_7, "#c2c2c2", true, false);
				break;
			}
			catch (ThreadAbortException)
			{
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Waiting for variants", "#c2c2c2", true, false);
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

	// Token: 0x06000805 RID: 2053 RVA: 0x00047024 File Offset: 0x00045224
	public async Task method_18()
	{
		while (!this.bool_1)
		{
			int num = 0;
			TaskAwaiter taskAwaiter6;
			try
			{
				base.method_5("Adding to cart", "yellow", true, false);
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary["pid"] = this.string_7;
				dictionary["format"] = "ajax";
				for (;;)
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class14_0.method_3(string.Format("https://www.lacoste.com{0}Cart-AddProduct", this.string_16), dictionary, false).GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						await taskAwaiter;
						TaskAwaiter<HttpResponseMessage> taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
					}
					HttpResponseMessage result = taskAwaiter.GetResult();
					result.EnsureSuccessStatusCode();
					TaskAwaiter<JObject> taskAwaiter3 = result.smethod_1().GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						await taskAwaiter3;
						TaskAwaiter<JObject> taskAwaiter4;
						taskAwaiter3 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<JObject>);
					}
					JObject result2 = taskAwaiter3.GetResult();
					if (!result2.ContainsKey("Success") || (bool)result2["Success"])
					{
						goto IL_24A;
					}
					if (!(result2["error"].ToString() == "OUT_OF_STOCK"))
					{
						break;
					}
					base.method_5("Waiting for restock", "#c2c2c2", true, false);
					TaskAwaiter taskAwaiter5 = base.method_14(Class130.int_0).GetAwaiter();
					if (!taskAwaiter5.IsCompleted)
					{
						await taskAwaiter5;
						taskAwaiter5 = taskAwaiter6;
						taskAwaiter6 = default(TaskAwaiter);
					}
					taskAwaiter5.GetResult();
				}
				throw new Exception();
				IL_24A:
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
				TaskAwaiter taskAwaiter5 = base.method_14(Class130.int_0).GetAwaiter();
				if (!taskAwaiter5.IsCompleted)
				{
					await taskAwaiter5;
					taskAwaiter5 = taskAwaiter6;
					taskAwaiter6 = default(TaskAwaiter);
				}
				taskAwaiter5.GetResult();
				continue;
			}
		}
	}

	// Token: 0x06000806 RID: 2054 RVA: 0x0004706C File Offset: 0x0004526C
	public async Task method_19()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Checking email", "#c2c2c2", true, false);
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary["email"] = (string)this.jtoken_1["payment"]["email"];
				dictionary["format"] = "ajax";
				(await this.class14_0.method_3(string.Format("https://www.lacoste.com{0}LoginV2-LoginValidateEmail", this.string_16), dictionary, false)).EnsureSuccessStatusCode();
				base.method_5("Done", "#c2c2c2", true, false);
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error checking email", "#c2c2c2", true, false);
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
			}
		}
	}

	// Token: 0x06000807 RID: 2055 RVA: 0x000470B4 File Offset: 0x000452B4
	public async Task method_20()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Logging in", "#c2c2c2", true, false);
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary["email"] = (string)this.jtoken_1["payment"]["email"];
				(await this.class14_0.method_3(string.Format("https://www.lacoste.com{0}LoginV2-LoginCheckout", this.string_16), dictionary, false)).EnsureSuccessStatusCode();
				base.method_5("Successfully logged in", "#c2c2c2", true, false);
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error loggin in", "#c2c2c2", true, false);
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
			}
		}
	}

	// Token: 0x06000808 RID: 2056 RVA: 0x000470FC File Offset: 0x000452FC
	public async Task method_21()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Getting shipping method", "#c2c2c2", true, false);
				TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class14_0.method_2(string.Format("https://www.lacoste.com{0}COShipmentV2-Show", this.string_16), false).GetAwaiter();
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
				if (result2.Contains("ENTER YOUR EMAIL ADDRESS TO CONTINUE"))
				{
					base.method_0("Invalid email", "red", true, (GEnum1)0);
				}
				HtmlDocument htmlDocument = new HtmlDocument();
				htmlDocument.LoadHtml(result2);
				this.string_12 = htmlDocument.DocumentNode.SelectSingleNode("//ul[@class='home-delivery-methods-list']//input").Attributes["value"].Value;
				base.method_5("Got shipping method: " + this.string_12, "#c2c2c2", true, false);
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error getting shipping method", "#c2c2c2", true, false);
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

	// Token: 0x06000809 RID: 2057 RVA: 0x00047144 File Offset: 0x00045344
	public async Task method_22()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Submitting shipping", "#c2c2c2", true, false);
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary["shipping-method"] = this.string_12;
				dictionary["newsletter-email"] = "off";
				dictionary["sa-civility"] = "MR";
				dictionary["sa-first-name"] = (string)this.jtoken_1["delivery"]["first_name"];
				dictionary["sa-last-name"] = (string)this.jtoken_1["delivery"]["last_name"];
				dictionary["sa-number-and-street"] = (string)this.jtoken_1["delivery"]["addr1"];
				dictionary["sa-zip-code"] = (string)this.jtoken_1["delivery"]["zip"];
				dictionary["sa-town"] = (string)this.jtoken_1["delivery"]["city"];
				dictionary["sa-phone"] = (string)this.jtoken_1["payment"]["phone"];
				dictionary["sa-state"] = Class43.smethod_1((string)this.jtoken_1["delivery"]["country"], (string)this.jtoken_1["delivery"]["state"]);
				dictionary["sa-country"] = Class43.smethod_0((string)this.jtoken_1["delivery"]["country"], false);
				dictionary["guest-emailconfirmation"] = (string)this.jtoken_1["payment"]["email"];
				dictionary["ba-civility"] = "MR";
				dictionary["ba-first-name"] = (string)this.jtoken_1["billing"]["first_name"];
				dictionary["ba-last-name"] = (string)this.jtoken_1["billing"]["last_name"];
				dictionary["ba-number-and-street"] = (string)this.jtoken_1["billing"]["addr1"];
				dictionary["ba-zip-code"] = (string)this.jtoken_1["billing"]["zip"];
				dictionary["ba-town"] = (string)this.jtoken_1["billing"]["city"];
				dictionary["ba-phone"] = (string)this.jtoken_1["payment"]["phone"];
				dictionary["ba-state"] = Class43.smethod_1((string)this.jtoken_1["billing"]["country"], (string)this.jtoken_1["billing"]["state"]);
				dictionary["ba-country"] = Class43.smethod_0((string)this.jtoken_1["billing"]["country"], false);
				dictionary["receivenews"] = "off";
				dictionary["sa-ignoredavcheck"] = "true";
				TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class14_0.method_3(string.Format("https://www.lacoste.com{0}COShipmentV2-ValidateShippingStep?isajax=true", this.string_16), dictionary, false).GetAwaiter();
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
				if (taskAwaiter3.GetResult().Contains("We apologize but we do not ship to"))
				{
					base.method_0("Unsupported country", "red", true, (GEnum1)0);
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

	// Token: 0x0600080A RID: 2058 RVA: 0x0004718C File Offset: 0x0004538C
	public async Task method_23()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Submitting payment", "orange", true, false);
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary["npm-holder-name"] = this.jtoken_1["billing"]["first_name"] + " " + this.jtoken_1["billing"]["last_name"];
				dictionary["npm-card-number"] = (string)this.jtoken_1["payment"]["card"]["number"];
				dictionary["cc-exp"] = string.Format("{0} / {1}", (string)this.jtoken_1["payment"]["card"]["exp_month"], this.jtoken_1["payment"]["card"]["exp_year"].ToString().Substring(2));
				dictionary["npm-cryptogramme"] = (string)this.jtoken_1["payment"]["card"]["cvv"];
				dictionary["npm-savecard"] = "false";
				dictionary["isCyberSource"] = "true";
				dictionary["npm-expiry-date-month"] = (string)this.jtoken_1["payment"]["card"]["exp_month"];
				dictionary["npm-expiry-date-year"] = (string)this.jtoken_1["payment"]["card"]["exp_year"];
				dictionary["npm-type-card"] = this.method_15((string)this.jtoken_1["payment"]["card"]["number"]);
				dictionary["add-payment-method"] = "CREDIT_CARD";
				dictionary["payment-method"] = "CREDIT_CARD";
				dictionary["check-condition"] = "on";
				HttpResponseMessage httpResponseMessage = await this.class14_0.method_3(string.Format("https://www.lacoste.com{0}COPaymentV2-ValidateOrder", this.string_16), dictionary, false);
				if (httpResponseMessage.StatusCode != HttpStatusCode.Found)
				{
					string text = await httpResponseMessage.smethod_3();
					if (text.ToLower().Contains("thank you for your purchase"))
					{
						base.method_0("Successfully checked out", "green", true, (GEnum1)6);
					}
					else if (text.Contains("We're sorry, an error occured. Please try again."))
					{
						base.method_0("Payment error", "red", true, (GEnum1)0);
					}
					else
					{
						HtmlDocument htmlDocument = new HtmlDocument();
						htmlDocument.LoadHtml(text);
						HtmlNodeCollection htmlNodeCollection = htmlDocument.DocumentNode.SelectNodes("//form[@name='PAInfoForm']");
						if (htmlNodeCollection.Count > 0)
						{
							this.string_13 = htmlNodeCollection[0].Attributes["action"].Value;
							this.dictionary_0 = new Dictionary<string, string>();
							foreach (HtmlNode htmlNode in htmlNodeCollection[0].Elements("input"))
							{
								this.dictionary_0[htmlNode.Attributes["name"].Value] = htmlNode.Attributes["value"].Value;
							}
							await this.method_24();
						}
					}
					break;
				}
				if (httpResponseMessage.Headers.Location.ToString().Contains("Please check the information on your card or use an alternative payment method"))
				{
					base.method_0("Payment Declined", "red", true, (GEnum1)5);
					break;
				}
				if (httpResponseMessage.Headers.Location.ToString().Contains("Please check that all the requested information is filled in before submitting your order"))
				{
					base.method_0("Invalid info", "red", true, (GEnum1)0);
					break;
				}
				base.method_0("Payment Declined", "red", true, (GEnum1)5);
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error submitting payment", "#c2c2c2", true, false);
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
			}
		}
	}

	// Token: 0x0600080B RID: 2059 RVA: 0x000471D4 File Offset: 0x000453D4
	public async Task method_24()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Processing payment", "orange", true, false);
				HttpResponseMessage httpResponseMessage = await this.class14_0.method_3(this.string_13, this.dictionary_0, false);
				httpResponseMessage.EnsureSuccessStatusCode();
				HtmlDocument htmlDocument = new HtmlDocument();
				HtmlDocument htmlDocument2 = htmlDocument;
				htmlDocument2.LoadHtml(await httpResponseMessage.smethod_3());
				htmlDocument2 = null;
				if (htmlDocument.DocumentNode.SelectSingleNode("//form[@name='downloadForm']") == null)
				{
					base.method_0("Unsupported card", "red", true, (GEnum1)0);
				}
				this.string_14 = htmlDocument.DocumentNode.SelectSingleNode("//form[@name='downloadForm']").Attributes["action"].Value;
				this.dictionary_1 = new Dictionary<string, string>();
				foreach (HtmlNode htmlNode in ((IEnumerable<HtmlNode>)htmlDocument.DocumentNode.SelectNodes("//form[@name='downloadForm']//input[@name]")))
				{
					this.dictionary_1[htmlNode.Attributes["name"].Value] = htmlNode.Attributes["value"].Value;
				}
				await this.method_25();
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error processing order", "#c2c2c2", true, false);
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
			}
		}
	}

	// Token: 0x0600080C RID: 2060 RVA: 0x0004721C File Offset: 0x0004541C
	public async Task method_25()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Submitting order", "orange", true, false);
				HttpResponseMessage httpResponseMessage = await this.class14_0.method_3(this.string_14, this.dictionary_1, false);
				httpResponseMessage.EnsureSuccessStatusCode();
				HtmlDocument htmlDocument = new HtmlDocument();
				HtmlDocument htmlDocument2 = htmlDocument;
				htmlDocument2.LoadHtml(await httpResponseMessage.smethod_3());
				htmlDocument2 = null;
				this.string_15 = htmlDocument.DocumentNode.SelectSingleNode("//form[@name='RedirectForm']").Attributes["action"].Value;
				await this.method_26();
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				TaskAwaiter taskAwaiter = base.method_14(Class130.int_0).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter.GetResult();
				base.method_5("Waiting for product", "#c2c2c2", true, false);
				continue;
			}
		}
	}

	// Token: 0x0600080D RID: 2061 RVA: 0x00047264 File Offset: 0x00045464
	public async Task method_26()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Processing order", "orange", true, false);
				TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class14_0.method_3(this.string_15, new Dictionary<string, string>(), false).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter<HttpResponseMessage> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
				}
				HttpResponseMessage result = taskAwaiter.GetResult();
				if (result.StatusCode == HttpStatusCode.Found)
				{
					if (!result.Headers.Location.ToString().Contains("Technical error occurred during payment") && !result.Headers.Location.ToString().Contains("Please check the information on your card or use an alternative payment method"))
					{
						if (result.Headers.Location.ToString().Contains("Please check that all the requested information is filled in before submitting your order"))
						{
							base.method_0("Invalid info", "red", true, (GEnum1)0);
						}
						else
						{
							base.method_0("Payment error", "red", true, (GEnum1)0);
						}
					}
					else
					{
						base.method_0("Payment Declined", "red", true, (GEnum1)5);
					}
				}
				else
				{
					TaskAwaiter<string> taskAwaiter3 = result.smethod_3().GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						await taskAwaiter3;
						TaskAwaiter<string> taskAwaiter4;
						taskAwaiter3 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<string>);
					}
					if (!taskAwaiter3.GetResult().ToLower().Contains("thank you for your purchase"))
					{
						throw new Exception();
					}
					base.method_0("Successfully checked out", "green", true, (GEnum1)6);
				}
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error processing order", "#c2c2c2", true, false);
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

	// Token: 0x0600080E RID: 2062 RVA: 0x0000686A File Offset: 0x00004A6A
	private bool method_27(JToken jtoken_2)
	{
		return this.string_9.Any(new Func<string, bool>(jtoken_2["displayValue"].ToString().ToLower().Contains)) || this.string_9.Count<string>() == 0;
	}

	// Token: 0x0600080F RID: 2063 RVA: 0x000472AC File Offset: 0x000454AC
	private bool method_28(JToken jtoken_2)
	{
		return Class43.smethod_2(this.string_0, jtoken_2["displayValue"].ToString().Replace(" ", string.Empty).Split(new char[]
		{
			'-'
		}).Last<string>());
	}

	// Token: 0x040006C4 RID: 1732
	private bool bool_3;

	// Token: 0x040006C5 RID: 1733
	private string string_7;

	// Token: 0x040006C6 RID: 1734
	private string string_8;

	// Token: 0x040006C7 RID: 1735
	private string[] string_9;

	// Token: 0x040006C8 RID: 1736
	private string string_10;

	// Token: 0x040006C9 RID: 1737
	private string string_11;

	// Token: 0x040006CA RID: 1738
	private string string_12;

	// Token: 0x040006CB RID: 1739
	private Dictionary<string, string> dictionary_0;

	// Token: 0x040006CC RID: 1740
	private string string_13;

	// Token: 0x040006CD RID: 1741
	private Dictionary<string, string> dictionary_1;

	// Token: 0x040006CE RID: 1742
	private string string_14;

	// Token: 0x040006CF RID: 1743
	private string string_15;

	// Token: 0x040006D0 RID: 1744
	private string string_16;

	// Token: 0x02000175 RID: 373
	[Serializable]
	private sealed class Class176
	{
		// Token: 0x06000812 RID: 2066 RVA: 0x000068B5 File Offset: 0x00004AB5
		internal bool method_0(string string_0)
		{
			return string_0.smethod_12();
		}

		// Token: 0x06000813 RID: 2067 RVA: 0x000068BD File Offset: 0x00004ABD
		internal bool method_1(string string_0)
		{
			return !string_0.smethod_12();
		}

		// Token: 0x040006D1 RID: 1745
		public static readonly Class53.Class176 class176_0 = new Class53.Class176();

		// Token: 0x040006D2 RID: 1746
		public static Func<string, bool> func_0;

		// Token: 0x040006D3 RID: 1747
		public static Func<string, bool> func_1;
	}

	// Token: 0x02000176 RID: 374
	[StructLayout(LayoutKind.Auto)]
	private struct Struct147 : IAsyncStateMachine
	{
		// Token: 0x06000814 RID: 2068 RVA: 0x000472F8 File Offset: 0x000454F8
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class53 @class = this;
			try
			{
				if (num <= 2)
				{
					goto IL_2E5;
				}
				if (num != 3)
				{
					goto IL_2DA;
				}
				TaskAwaiter taskAwaiter3 = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_2D3:
				taskAwaiter3.GetResult();
				IL_2DA:
				if (@class.bool_1)
				{
					goto IL_326;
				}
				int num4 = 0;
				IL_2E5:
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter4;
					TaskAwaiter<string> taskAwaiter6;
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
						TaskAwaiter<string> taskAwaiter7;
						taskAwaiter6 = taskAwaiter7;
						taskAwaiter7 = default(TaskAwaiter<string>);
						int num6 = -1;
						num = -1;
						num2 = num6;
						goto IL_147;
					}
					case 2:
					{
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num7 = -1;
						num = -1;
						num2 = num7;
						goto IL_290;
					}
					default:
						@class.method_5("Processing payment", "orange", true, false);
						taskAwaiter4 = @class.class14_0.method_3(@class.string_13, @class.dictionary_0, false).GetAwaiter();
						if (!taskAwaiter4.IsCompleted)
						{
							int num8 = 0;
							num = 0;
							num2 = num8;
							TaskAwaiter<HttpResponseMessage> taskAwaiter5 = taskAwaiter4;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class53.Struct147>(ref taskAwaiter4, ref this);
							return;
						}
						break;
					}
					HttpResponseMessage result = taskAwaiter4.GetResult();
					result.EnsureSuccessStatusCode();
					htmlDocument = new HtmlDocument();
					htmlDocument2 = htmlDocument;
					taskAwaiter6 = result.smethod_3().GetAwaiter();
					if (!taskAwaiter6.IsCompleted)
					{
						int num9 = 1;
						num = 1;
						num2 = num9;
						TaskAwaiter<string> taskAwaiter7 = taskAwaiter6;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class53.Struct147>(ref taskAwaiter6, ref this);
						return;
					}
					IL_147:
					string result2 = taskAwaiter6.GetResult();
					htmlDocument2.LoadHtml(result2);
					htmlDocument2 = null;
					if (htmlDocument.DocumentNode.SelectSingleNode("//form[@name='downloadForm']") == null)
					{
						@class.method_0("Unsupported card", "red", true, (GEnum1)0);
					}
					@class.string_14 = htmlDocument.DocumentNode.SelectSingleNode("//form[@name='downloadForm']").Attributes["action"].Value;
					@class.dictionary_1 = new Dictionary<string, string>();
					IEnumerator<HtmlNode> enumerator = ((IEnumerable<HtmlNode>)htmlDocument.DocumentNode.SelectNodes("//form[@name='downloadForm']//input[@name]")).GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							HtmlNode htmlNode = enumerator.Current;
							@class.dictionary_1[htmlNode.Attributes["name"].Value] = htmlNode.Attributes["value"].Value;
						}
					}
					finally
					{
						if (num < 0 && enumerator != null)
						{
							enumerator.Dispose();
						}
					}
					taskAwaiter3 = @class.method_25().GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						int num10 = 2;
						num = 2;
						num2 = num10;
						taskAwaiter2 = taskAwaiter3;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class53.Struct147>(ref taskAwaiter3, ref this);
						return;
					}
					IL_290:
					taskAwaiter3.GetResult();
					goto IL_326;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_2DA;
				}
				@class.method_5("Error processing order", "#c2c2c2", true, false);
				taskAwaiter3 = @class.method_14(Class130.int_0).GetAwaiter();
				if (taskAwaiter3.IsCompleted)
				{
					goto IL_2D3;
				}
				int num11 = 3;
				num = 3;
				num2 = num11;
				taskAwaiter2 = taskAwaiter3;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class53.Struct147>(ref taskAwaiter3, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_326:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000815 RID: 2069 RVA: 0x000068C8 File Offset: 0x00004AC8
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040006D4 RID: 1748
		public int int_0;

		// Token: 0x040006D5 RID: 1749
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040006D6 RID: 1750
		public Class53 class53_0;

		// Token: 0x040006D7 RID: 1751
		private HtmlDocument htmlDocument_0;

		// Token: 0x040006D8 RID: 1752
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040006D9 RID: 1753
		private HtmlDocument htmlDocument_1;

		// Token: 0x040006DA RID: 1754
		private TaskAwaiter<string> taskAwaiter_1;

		// Token: 0x040006DB RID: 1755
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x02000177 RID: 375
	[StructLayout(LayoutKind.Auto)]
	private struct Struct148 : IAsyncStateMachine
	{
		// Token: 0x06000816 RID: 2070 RVA: 0x0004768C File Offset: 0x0004588C
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class53 @class = this;
			try
			{
				if (num <= 2)
				{
					goto IL_2AA;
				}
				if (num != 3)
				{
					goto IL_29F;
				}
				TaskAwaiter taskAwaiter7 = taskAwaiter6;
				taskAwaiter6 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_298:
				taskAwaiter7.GetResult();
				IL_29F:
				if (@class.bool_1)
				{
					goto IL_2EB;
				}
				int num4 = 0;
				IL_2AA:
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter8;
					TaskAwaiter<JObject> taskAwaiter9;
					switch (num)
					{
					case 0:
					{
						taskAwaiter8 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
						int num5 = -1;
						num = -1;
						num2 = num5;
						goto IL_12F;
					}
					case 1:
					{
						taskAwaiter9 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<JObject>);
						int num6 = -1;
						num = -1;
						num2 = num6;
						goto IL_155;
					}
					case 2:
					{
						taskAwaiter7 = taskAwaiter6;
						taskAwaiter6 = default(TaskAwaiter);
						int num7 = -1;
						num = -1;
						num2 = num7;
						goto IL_1CD;
					}
					default:
						@class.method_5("Adding to cart", "yellow", true, false);
						dictionary = new Dictionary<string, string>();
						dictionary["pid"] = @class.string_7;
						dictionary["format"] = "ajax";
						break;
					}
					IL_FA:
					taskAwaiter8 = @class.class14_0.method_3(string.Format("https://www.lacoste.com{0}Cart-AddProduct", @class.string_16), dictionary, false).GetAwaiter();
					if (!taskAwaiter8.IsCompleted)
					{
						int num8 = 0;
						num = 0;
						num2 = num8;
						taskAwaiter2 = taskAwaiter8;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class53.Struct148>(ref taskAwaiter8, ref this);
						return;
					}
					IL_12F:
					HttpResponseMessage result = taskAwaiter8.GetResult();
					result.EnsureSuccessStatusCode();
					taskAwaiter9 = result.smethod_1().GetAwaiter();
					if (!taskAwaiter9.IsCompleted)
					{
						int num9 = 1;
						num = 1;
						num2 = num9;
						taskAwaiter4 = taskAwaiter9;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class53.Struct148>(ref taskAwaiter9, ref this);
						return;
					}
					IL_155:
					JObject result2 = taskAwaiter9.GetResult();
					if (!result2.ContainsKey("Success") || (bool)result2["Success"])
					{
						@class.method_5("Successfully carted", "#c2c2c2", true, false);
						goto IL_2EB;
					}
					if (!(result2["error"].ToString() == "OUT_OF_STOCK"))
					{
						throw new Exception();
					}
					@class.method_5("Waiting for restock", "#c2c2c2", true, false);
					taskAwaiter7 = @class.method_14(Class130.int_0).GetAwaiter();
					if (!taskAwaiter7.IsCompleted)
					{
						int num10 = 2;
						num = 2;
						num2 = num10;
						taskAwaiter6 = taskAwaiter7;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class53.Struct148>(ref taskAwaiter7, ref this);
						return;
					}
					IL_1CD:
					taskAwaiter7.GetResult();
					goto IL_FA;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_29F;
				}
				@class.method_5("Error adding to cart", "#c2c2c2", true, false);
				taskAwaiter7 = @class.method_14(Class130.int_0).GetAwaiter();
				if (taskAwaiter7.IsCompleted)
				{
					goto IL_298;
				}
				int num11 = 3;
				num = 3;
				num2 = num11;
				taskAwaiter6 = taskAwaiter7;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class53.Struct148>(ref taskAwaiter7, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_2EB:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000817 RID: 2071 RVA: 0x000068D6 File Offset: 0x00004AD6
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040006DC RID: 1756
		public int int_0;

		// Token: 0x040006DD RID: 1757
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040006DE RID: 1758
		public Class53 class53_0;

		// Token: 0x040006DF RID: 1759
		private Dictionary<string, string> dictionary_0;

		// Token: 0x040006E0 RID: 1760
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040006E1 RID: 1761
		private TaskAwaiter<JObject> taskAwaiter_1;

		// Token: 0x040006E2 RID: 1762
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x02000178 RID: 376
	[StructLayout(LayoutKind.Auto)]
	private struct Struct149 : IAsyncStateMachine
	{
		// Token: 0x06000818 RID: 2072 RVA: 0x000479CC File Offset: 0x00045BCC
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class53 @class = this;
			try
			{
				if (num <= 1)
				{
					goto IL_24C;
				}
				if (num != 2)
				{
					goto IL_242;
				}
				TaskAwaiter taskAwaiter7 = taskAwaiter6;
				taskAwaiter6 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_23B:
				taskAwaiter7.GetResult();
				IL_242:
				if (@class.bool_1)
				{
					goto IL_28E;
				}
				int num4 = 0;
				IL_24C:
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
							goto IL_1CE;
						}
						@class.method_5("Processing order", "orange", true, false);
						taskAwaiter9 = @class.class14_0.method_3(@class.string_15, new Dictionary<string, string>(), false).GetAwaiter();
						if (!taskAwaiter9.IsCompleted)
						{
							int num6 = 0;
							num = 0;
							num2 = num6;
							taskAwaiter2 = taskAwaiter9;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class53.Struct149>(ref taskAwaiter9, ref this);
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
					if (result.StatusCode == HttpStatusCode.Found)
					{
						if (result.Headers.Location.ToString().Contains("Technical error occurred during payment") || result.Headers.Location.ToString().Contains("Please check the information on your card or use an alternative payment method"))
						{
							@class.method_0("Payment Declined", "red", true, (GEnum1)5);
							goto IL_200;
						}
						if (result.Headers.Location.ToString().Contains("Please check that all the requested information is filled in before submitting your order"))
						{
							@class.method_0("Invalid info", "red", true, (GEnum1)0);
							goto IL_200;
						}
						@class.method_0("Payment error", "red", true, (GEnum1)0);
						goto IL_200;
					}
					else
					{
						taskAwaiter8 = result.smethod_3().GetAwaiter();
						if (!taskAwaiter8.IsCompleted)
						{
							int num8 = 1;
							num = 1;
							num2 = num8;
							taskAwaiter4 = taskAwaiter8;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class53.Struct149>(ref taskAwaiter8, ref this);
							return;
						}
					}
					IL_1CE:
					if (!taskAwaiter8.GetResult().ToLower().Contains("thank you for your purchase"))
					{
						throw new Exception();
					}
					@class.method_0("Successfully checked out", "green", true, (GEnum1)6);
					IL_200:
					goto IL_28E;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_242;
				}
				@class.method_5("Error processing order", "#c2c2c2", true, false);
				taskAwaiter7 = @class.method_14(Class130.int_0).GetAwaiter();
				if (taskAwaiter7.IsCompleted)
				{
					goto IL_23B;
				}
				int num9 = 2;
				num = 2;
				num2 = num9;
				taskAwaiter6 = taskAwaiter7;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class53.Struct149>(ref taskAwaiter7, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_28E:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000819 RID: 2073 RVA: 0x000068E4 File Offset: 0x00004AE4
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040006E3 RID: 1763
		public int int_0;

		// Token: 0x040006E4 RID: 1764
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040006E5 RID: 1765
		public Class53 class53_0;

		// Token: 0x040006E6 RID: 1766
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040006E7 RID: 1767
		private TaskAwaiter<string> taskAwaiter_1;

		// Token: 0x040006E8 RID: 1768
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x02000179 RID: 377
	[StructLayout(LayoutKind.Auto)]
	private struct Struct150 : IAsyncStateMachine
	{
		// Token: 0x0600081A RID: 2074 RVA: 0x00047CB0 File Offset: 0x00045EB0
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class53 @class = this;
			try
			{
				if (num == 0)
				{
					goto IL_170;
				}
				if (num != 1)
				{
					goto IL_166;
				}
				TaskAwaiter taskAwaiter3 = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_15F:
				taskAwaiter3.GetResult();
				IL_166:
				if (@class.bool_1)
				{
					goto IL_1B2;
				}
				int num4 = 0;
				IL_170:
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter4;
					if (num != 0)
					{
						@class.method_5("Checking email", "#c2c2c2", true, false);
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary["email"] = (string)@class.jtoken_1["payment"]["email"];
						dictionary["format"] = "ajax";
						taskAwaiter4 = @class.class14_0.method_3(string.Format("https://www.lacoste.com{0}LoginV2-LoginValidateEmail", @class.string_16), dictionary, false).GetAwaiter();
						if (!taskAwaiter4.IsCompleted)
						{
							int num5 = 0;
							num = 0;
							num2 = num5;
							TaskAwaiter<HttpResponseMessage> taskAwaiter5 = taskAwaiter4;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class53.Struct150>(ref taskAwaiter4, ref this);
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
					@class.method_5("Done", "#c2c2c2", true, false);
					goto IL_1B2;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_166;
				}
				@class.method_5("Error checking email", "#c2c2c2", true, false);
				taskAwaiter3 = @class.method_14(Class130.int_0).GetAwaiter();
				if (taskAwaiter3.IsCompleted)
				{
					goto IL_15F;
				}
				int num7 = 1;
				num = 1;
				num2 = num7;
				taskAwaiter2 = taskAwaiter3;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class53.Struct150>(ref taskAwaiter3, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_1B2:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x0600081B RID: 2075 RVA: 0x000068F2 File Offset: 0x00004AF2
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040006E9 RID: 1769
		public int int_0;

		// Token: 0x040006EA RID: 1770
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040006EB RID: 1771
		public Class53 class53_0;

		// Token: 0x040006EC RID: 1772
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040006ED RID: 1773
		private TaskAwaiter taskAwaiter_1;
	}

	// Token: 0x0200017A RID: 378
	[StructLayout(LayoutKind.Auto)]
	private struct Struct151 : IAsyncStateMachine
	{
		// Token: 0x0600081C RID: 2076 RVA: 0x00047EB8 File Offset: 0x000460B8
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class53 @class = this;
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
						goto IL_142;
					}
					case 3:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_19D;
					}
					case 4:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_1F8;
					}
					case 5:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_253;
					}
					case 6:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_2AE;
					}
					case 7:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_309;
					}
					case 8:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_361;
					}
					default:
						taskAwaiter = @class.method_11().GetAwaiter();
						if (!taskAwaiter.IsCompleted)
						{
							num2 = 0;
							TaskAwaiter taskAwaiter2 = taskAwaiter;
							this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class53.Struct151>(ref taskAwaiter, ref this);
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
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class53.Struct151>(ref taskAwaiter, ref this);
						return;
					}
					IL_E7:
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_17().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 2;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class53.Struct151>(ref taskAwaiter, ref this);
						return;
					}
					IL_142:
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_18().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 3;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class53.Struct151>(ref taskAwaiter, ref this);
						return;
					}
					IL_19D:
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_19().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 4;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class53.Struct151>(ref taskAwaiter, ref this);
						return;
					}
					IL_1F8:
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_20().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 5;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class53.Struct151>(ref taskAwaiter, ref this);
						return;
					}
					IL_253:
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_21().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 6;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class53.Struct151>(ref taskAwaiter, ref this);
						return;
					}
					IL_2AE:
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_22().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 7;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class53.Struct151>(ref taskAwaiter, ref this);
						return;
					}
					IL_309:
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_23().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 8;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class53.Struct151>(ref taskAwaiter, ref this);
						return;
					}
					IL_361:
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

		// Token: 0x0600081D RID: 2077 RVA: 0x00006900 File Offset: 0x00004B00
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040006EE RID: 1774
		public int int_0;

		// Token: 0x040006EF RID: 1775
		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		// Token: 0x040006F0 RID: 1776
		public Class53 class53_0;

		// Token: 0x040006F1 RID: 1777
		private TaskAwaiter taskAwaiter_0;
	}

	// Token: 0x0200017B RID: 379
	[StructLayout(LayoutKind.Auto)]
	private struct Struct152 : IAsyncStateMachine
	{
		// Token: 0x0600081E RID: 2078 RVA: 0x000482A4 File Offset: 0x000464A4
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class53 @class = this;
			try
			{
				if (num <= 1)
				{
					goto IL_1F9;
				}
				if (num != 2)
				{
					goto IL_1EF;
				}
				TaskAwaiter taskAwaiter7 = taskAwaiter6;
				taskAwaiter6 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_1E8:
				taskAwaiter7.GetResult();
				IL_1EF:
				if (@class.bool_1)
				{
					goto IL_23B;
				}
				int num4 = 0;
				IL_1F9:
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
							goto IL_12F;
						}
						@class.method_5("Getting shipping method", "#c2c2c2", true, false);
						taskAwaiter9 = @class.class14_0.method_2(string.Format("https://www.lacoste.com{0}COShipmentV2-Show", @class.string_16), false).GetAwaiter();
						if (!taskAwaiter9.IsCompleted)
						{
							int num6 = 0;
							num = 0;
							num2 = num6;
							taskAwaiter2 = taskAwaiter9;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class53.Struct152>(ref taskAwaiter9, ref this);
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
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class53.Struct152>(ref taskAwaiter8, ref this);
						return;
					}
					IL_12F:
					string result2 = taskAwaiter8.GetResult();
					if (result2.Contains("ENTER YOUR EMAIL ADDRESS TO CONTINUE"))
					{
						@class.method_0("Invalid email", "red", true, (GEnum1)0);
					}
					HtmlDocument htmlDocument = new HtmlDocument();
					htmlDocument.LoadHtml(result2);
					@class.string_12 = htmlDocument.DocumentNode.SelectSingleNode("//ul[@class='home-delivery-methods-list']//input").Attributes["value"].Value;
					@class.method_5("Got shipping method: " + @class.string_12, "#c2c2c2", true, false);
					goto IL_23B;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_1EF;
				}
				@class.method_5("Error getting shipping method", "#c2c2c2", true, false);
				taskAwaiter7 = @class.method_14(Class130.int_0).GetAwaiter();
				if (taskAwaiter7.IsCompleted)
				{
					goto IL_1E8;
				}
				int num9 = 2;
				num = 2;
				num2 = num9;
				taskAwaiter6 = taskAwaiter7;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class53.Struct152>(ref taskAwaiter7, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_23B:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x0600081F RID: 2079 RVA: 0x0000690E File Offset: 0x00004B0E
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040006F2 RID: 1778
		public int int_0;

		// Token: 0x040006F3 RID: 1779
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040006F4 RID: 1780
		public Class53 class53_0;

		// Token: 0x040006F5 RID: 1781
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040006F6 RID: 1782
		private TaskAwaiter<string> taskAwaiter_1;

		// Token: 0x040006F7 RID: 1783
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x0200017C RID: 380
	[StructLayout(LayoutKind.Auto)]
	private struct Struct153 : IAsyncStateMachine
	{
		// Token: 0x06000820 RID: 2080 RVA: 0x00048534 File Offset: 0x00046734
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class53 @class = this;
			try
			{
				if (num <= 2)
				{
					goto IL_5A5;
				}
				if (num != 3)
				{
					goto IL_59A;
				}
				TaskAwaiter taskAwaiter3 = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_593:
				taskAwaiter3.GetResult();
				IL_59A:
				if (@class.bool_1)
				{
					goto IL_5E6;
				}
				int num4 = 0;
				IL_5A5:
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter4;
					TaskAwaiter<string> taskAwaiter6;
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
						TaskAwaiter<string> taskAwaiter7;
						taskAwaiter6 = taskAwaiter7;
						taskAwaiter7 = default(TaskAwaiter<string>);
						int num6 = -1;
						num = -1;
						num2 = num6;
						goto IL_3D5;
					}
					case 2:
					{
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num7 = -1;
						num = -1;
						num2 = num7;
						goto IL_550;
					}
					default:
					{
						@class.method_5("Submitting payment", "orange", true, false);
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary["npm-holder-name"] = @class.jtoken_1["billing"]["first_name"] + " " + @class.jtoken_1["billing"]["last_name"];
						dictionary["npm-card-number"] = (string)@class.jtoken_1["payment"]["card"]["number"];
						dictionary["cc-exp"] = string.Format("{0} / {1}", (string)@class.jtoken_1["payment"]["card"]["exp_month"], @class.jtoken_1["payment"]["card"]["exp_year"].ToString().Substring(2));
						dictionary["npm-cryptogramme"] = (string)@class.jtoken_1["payment"]["card"]["cvv"];
						dictionary["npm-savecard"] = "false";
						dictionary["isCyberSource"] = "true";
						dictionary["npm-expiry-date-month"] = (string)@class.jtoken_1["payment"]["card"]["exp_month"];
						dictionary["npm-expiry-date-year"] = (string)@class.jtoken_1["payment"]["card"]["exp_year"];
						dictionary["npm-type-card"] = @class.method_15((string)@class.jtoken_1["payment"]["card"]["number"]);
						dictionary["add-payment-method"] = "CREDIT_CARD";
						dictionary["payment-method"] = "CREDIT_CARD";
						dictionary["check-condition"] = "on";
						taskAwaiter4 = @class.class14_0.method_3(string.Format("https://www.lacoste.com{0}COPaymentV2-ValidateOrder", @class.string_16), dictionary, false).GetAwaiter();
						if (!taskAwaiter4.IsCompleted)
						{
							int num8 = 0;
							num = 0;
							num2 = num8;
							TaskAwaiter<HttpResponseMessage> taskAwaiter5 = taskAwaiter4;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class53.Struct153>(ref taskAwaiter4, ref this);
							return;
						}
						break;
					}
					}
					HttpResponseMessage result = taskAwaiter4.GetResult();
					if (result.StatusCode == HttpStatusCode.Found)
					{
						if (result.Headers.Location.ToString().Contains("Please check the information on your card or use an alternative payment method"))
						{
							@class.method_0("Payment Declined", "red", true, (GEnum1)5);
							goto IL_5E6;
						}
						if (result.Headers.Location.ToString().Contains("Please check that all the requested information is filled in before submitting your order"))
						{
							@class.method_0("Invalid info", "red", true, (GEnum1)0);
							goto IL_5E6;
						}
						@class.method_0("Payment Declined", "red", true, (GEnum1)5);
						goto IL_5E6;
					}
					else
					{
						taskAwaiter6 = result.smethod_3().GetAwaiter();
						if (!taskAwaiter6.IsCompleted)
						{
							int num9 = 1;
							num = 1;
							num2 = num9;
							TaskAwaiter<string> taskAwaiter7 = taskAwaiter6;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class53.Struct153>(ref taskAwaiter6, ref this);
							return;
						}
					}
					IL_3D5:
					string result2 = taskAwaiter6.GetResult();
					if (result2.ToLower().Contains("thank you for your purchase"))
					{
						@class.method_0("Successfully checked out", "green", true, (GEnum1)6);
						goto IL_557;
					}
					if (result2.Contains("We're sorry, an error occured. Please try again."))
					{
						@class.method_0("Payment error", "red", true, (GEnum1)0);
						goto IL_557;
					}
					HtmlDocument htmlDocument = new HtmlDocument();
					htmlDocument.LoadHtml(result2);
					HtmlNodeCollection htmlNodeCollection = htmlDocument.DocumentNode.SelectNodes("//form[@name='PAInfoForm']");
					if (htmlNodeCollection.Count <= 0)
					{
						goto IL_557;
					}
					@class.string_13 = htmlNodeCollection[0].Attributes["action"].Value;
					@class.dictionary_0 = new Dictionary<string, string>();
					IEnumerator<HtmlNode> enumerator = htmlNodeCollection[0].Elements("input").GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							HtmlNode htmlNode = enumerator.Current;
							@class.dictionary_0[htmlNode.Attributes["name"].Value] = htmlNode.Attributes["value"].Value;
						}
					}
					finally
					{
						if (num < 0 && enumerator != null)
						{
							enumerator.Dispose();
						}
					}
					taskAwaiter3 = @class.method_24().GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						int num10 = 2;
						num = 2;
						num2 = num10;
						taskAwaiter2 = taskAwaiter3;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class53.Struct153>(ref taskAwaiter3, ref this);
						return;
					}
					IL_550:
					taskAwaiter3.GetResult();
					IL_557:
					goto IL_5E6;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_59A;
				}
				@class.method_5("Error submitting payment", "#c2c2c2", true, false);
				taskAwaiter3 = @class.method_14(Class130.int_0).GetAwaiter();
				if (taskAwaiter3.IsCompleted)
				{
					goto IL_593;
				}
				int num11 = 3;
				num = 3;
				num2 = num11;
				taskAwaiter2 = taskAwaiter3;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class53.Struct153>(ref taskAwaiter3, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_5E6:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000821 RID: 2081 RVA: 0x0000691C File Offset: 0x00004B1C
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040006F8 RID: 1784
		public int int_0;

		// Token: 0x040006F9 RID: 1785
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040006FA RID: 1786
		public Class53 class53_0;

		// Token: 0x040006FB RID: 1787
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040006FC RID: 1788
		private TaskAwaiter<string> taskAwaiter_1;

		// Token: 0x040006FD RID: 1789
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x0200017D RID: 381
	[StructLayout(LayoutKind.Auto)]
	private struct Struct154 : IAsyncStateMachine
	{
		// Token: 0x06000822 RID: 2082 RVA: 0x00048B88 File Offset: 0x00046D88
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class53 @class = this;
			try
			{
				TaskAwaiter taskAwaiter3;
				if (num > 2)
				{
					if (num != 3)
					{
						@class.method_5("Waiting for product", "#c2c2c2", true, false);
						goto IL_471;
					}
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					int num3 = -1;
					num = -1;
					num2 = num3;
					goto IL_44E;
				}
				IL_4F:
				int num10;
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
						goto IL_139;
					}
					case 2:
					{
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num6 = -1;
						num = -1;
						num2 = num6;
						goto IL_419;
					}
					default:
						taskAwaiter4 = @class.class14_0.method_2(string.Format("https://www.lacoste.com{0}ProductApi-GetProduct?pid={1}", @class.string_16, @class.string_8), false).GetAwaiter();
						if (!taskAwaiter4.IsCompleted)
						{
							int num7 = 0;
							num = 0;
							num2 = num7;
							TaskAwaiter<HttpResponseMessage> taskAwaiter5 = taskAwaiter4;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class53.Struct154>(ref taskAwaiter4, ref this);
							return;
						}
						break;
					}
					HttpResponseMessage result = taskAwaiter4.GetResult();
					result.EnsureSuccessStatusCode();
					taskAwaiter6 = result.smethod_1().GetAwaiter();
					if (!taskAwaiter6.IsCompleted)
					{
						int num8 = 1;
						num = 1;
						num2 = num8;
						TaskAwaiter<JObject> taskAwaiter7 = taskAwaiter6;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class53.Struct154>(ref taskAwaiter6, ref this);
						return;
					}
					IL_139:
					JObject result2 = taskAwaiter6.GetResult();
					if ((int)result2["status"] != 0 || object.Equals(false, (bool)result2["details"]["isOnline"]))
					{
						throw new Exception();
					}
					@class.method_7(result2["details"]["name"].ToString(), "#c2c2c2");
					if (object.Equals(false, (bool)result2["details"]["isInStock"]))
					{
						@class.method_5("Waiting for restock", "#c2c2c2", true, false);
						taskAwaiter3 = @class.method_14(Class130.int_0).GetAwaiter();
						if (!taskAwaiter3.IsCompleted)
						{
							int num9 = 2;
							num = 2;
							num2 = num9;
							taskAwaiter2 = taskAwaiter3;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class53.Struct154>(ref taskAwaiter3, ref this);
							return;
						}
					}
					else
					{
						JToken[] array = result2["details"]["colors"]["all"].Where(new Func<JToken, bool>(@class.method_27)).ToArray<JToken>();
						if (!Class40.smethod_0<JToken>(array))
						{
							throw new Exception();
						}
						if (!Class40.smethod_0<string>(@class.string_9))
						{
							@class.string_10 = array[MainWindow.random_0.Next(0, array.Count<JToken>())]["ID"].ToString();
						}
						else
						{
							@class.string_10 = array[0]["ID"].ToString();
						}
						@class.method_5("Found color ID: " + @class.string_10, "#c2c2c2", true, false);
						if (@class.bool_3)
						{
							JToken jtoken = result2["details"]["sizes"]["all"];
							if (!jtoken.Any<JToken>())
							{
								@class.method_0("Size unavailable", "red", true, (GEnum1)0);
							}
							else
							{
								jtoken = jtoken[MainWindow.random_0.Next(0, jtoken.Count<JToken>() - 1)];
								@class.string_11 = jtoken["value"].ToString();
							}
							@class.method_6(jtoken["displayValue"].ToString());
						}
						else
						{
							JToken jtoken2 = result2["details"]["sizes"]["all"].FirstOrDefault(new Func<JToken, bool>(@class.method_28));
							if (jtoken2 == null)
							{
								@class.method_0("Size unavailable", "red", true, (GEnum1)0);
							}
							else
							{
								@class.string_11 = jtoken2["value"].ToString();
							}
						}
						@class.method_5("Found size ID: " + @class.string_11, "#c2c2c2", true, false);
						goto IL_4B7;
					}
					IL_419:
					taskAwaiter3.GetResult();
					goto IL_471;
				}
				catch (ThreadAbortException)
				{
					goto IL_4B7;
				}
				catch
				{
					num10 = 1;
				}
				if (num10 != 1)
				{
					goto IL_471;
				}
				taskAwaiter3 = @class.method_14(Class130.int_0).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					int num11 = 3;
					num = 3;
					num2 = num11;
					taskAwaiter2 = taskAwaiter3;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class53.Struct154>(ref taskAwaiter3, ref this);
					return;
				}
				IL_44E:
				taskAwaiter3.GetResult();
				@class.method_5("Waiting for product", "#c2c2c2", true, false);
				IL_471:
				if (!@class.bool_1)
				{
					num10 = 0;
					goto IL_4F;
				}
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_4B7:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000823 RID: 2083 RVA: 0x0000692A File Offset: 0x00004B2A
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040006FE RID: 1790
		public int int_0;

		// Token: 0x040006FF RID: 1791
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000700 RID: 1792
		public Class53 class53_0;

		// Token: 0x04000701 RID: 1793
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000702 RID: 1794
		private TaskAwaiter<JObject> taskAwaiter_1;

		// Token: 0x04000703 RID: 1795
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x0200017E RID: 382
	[StructLayout(LayoutKind.Auto)]
	private struct Struct155 : IAsyncStateMachine
	{
		// Token: 0x06000824 RID: 2084 RVA: 0x000490AC File Offset: 0x000472AC
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class53 @class = this;
			try
			{
				if (num <= 2)
				{
					goto IL_239;
				}
				if (num != 3)
				{
					goto IL_22F;
				}
				TaskAwaiter taskAwaiter3 = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_216:
				taskAwaiter3.GetResult();
				@class.method_5("Waiting for product", "#c2c2c2", true, false);
				IL_22F:
				if (@class.bool_1)
				{
					goto IL_27A;
				}
				int num4 = 0;
				IL_239:
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter4;
					TaskAwaiter<string> taskAwaiter6;
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
						TaskAwaiter<string> taskAwaiter7;
						taskAwaiter6 = taskAwaiter7;
						taskAwaiter7 = default(TaskAwaiter<string>);
						int num6 = -1;
						num = -1;
						num2 = num6;
						goto IL_147;
					}
					case 2:
					{
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num7 = -1;
						num = -1;
						num2 = num7;
						goto IL_1E7;
					}
					default:
						@class.method_5("Submitting order", "orange", true, false);
						taskAwaiter4 = @class.class14_0.method_3(@class.string_14, @class.dictionary_1, false).GetAwaiter();
						if (!taskAwaiter4.IsCompleted)
						{
							int num8 = 0;
							num = 0;
							num2 = num8;
							TaskAwaiter<HttpResponseMessage> taskAwaiter5 = taskAwaiter4;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class53.Struct155>(ref taskAwaiter4, ref this);
							return;
						}
						break;
					}
					HttpResponseMessage result = taskAwaiter4.GetResult();
					result.EnsureSuccessStatusCode();
					htmlDocument = new HtmlDocument();
					htmlDocument2 = htmlDocument;
					taskAwaiter6 = result.smethod_3().GetAwaiter();
					if (!taskAwaiter6.IsCompleted)
					{
						int num9 = 1;
						num = 1;
						num2 = num9;
						TaskAwaiter<string> taskAwaiter7 = taskAwaiter6;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class53.Struct155>(ref taskAwaiter6, ref this);
						return;
					}
					IL_147:
					string result2 = taskAwaiter6.GetResult();
					htmlDocument2.LoadHtml(result2);
					htmlDocument2 = null;
					@class.string_15 = htmlDocument.DocumentNode.SelectSingleNode("//form[@name='RedirectForm']").Attributes["action"].Value;
					taskAwaiter3 = @class.method_26().GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						int num10 = 2;
						num = 2;
						num2 = num10;
						taskAwaiter2 = taskAwaiter3;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class53.Struct155>(ref taskAwaiter3, ref this);
						return;
					}
					IL_1E7:
					taskAwaiter3.GetResult();
					goto IL_27A;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_22F;
				}
				taskAwaiter3 = @class.method_14(Class130.int_0).GetAwaiter();
				if (taskAwaiter3.IsCompleted)
				{
					goto IL_216;
				}
				int num11 = 3;
				num = 3;
				num2 = num11;
				taskAwaiter2 = taskAwaiter3;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class53.Struct155>(ref taskAwaiter3, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_27A:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000825 RID: 2085 RVA: 0x00006938 File Offset: 0x00004B38
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000704 RID: 1796
		public int int_0;

		// Token: 0x04000705 RID: 1797
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000706 RID: 1798
		public Class53 class53_0;

		// Token: 0x04000707 RID: 1799
		private HtmlDocument htmlDocument_0;

		// Token: 0x04000708 RID: 1800
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000709 RID: 1801
		private HtmlDocument htmlDocument_1;

		// Token: 0x0400070A RID: 1802
		private TaskAwaiter<string> taskAwaiter_1;

		// Token: 0x0400070B RID: 1803
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x0200017F RID: 383
	[StructLayout(LayoutKind.Auto)]
	private struct Struct156 : IAsyncStateMachine
	{
		// Token: 0x06000826 RID: 2086 RVA: 0x0004937C File Offset: 0x0004757C
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class53 @class = this;
			try
			{
				if (num <= 1)
				{
					goto IL_237;
				}
				if (num != 2)
				{
					goto IL_22D;
				}
				TaskAwaiter taskAwaiter7 = taskAwaiter6;
				taskAwaiter6 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_226:
				taskAwaiter7.GetResult();
				IL_22D:
				if (@class.bool_1)
				{
					goto IL_279;
				}
				int num4 = 0;
				IL_237:
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
							goto IL_17C;
						}
						@class.method_5("Waiting for variants", "#c2c2c2", true, false);
						taskAwaiter9 = @class.class14_0.method_2(string.Format("https://www.lacoste.com{0}ProductV2-SkuProduct?pid={1}&dwvar_{2}_size={3}&dwvar_{4}_color={5}&selectMode=1", new object[]
						{
							@class.string_16,
							@class.string_8,
							@class.string_8,
							@class.string_11,
							@class.string_8,
							@class.string_10
						}), false).GetAwaiter();
						if (!taskAwaiter9.IsCompleted)
						{
							int num6 = 0;
							num = 0;
							num2 = num6;
							taskAwaiter2 = taskAwaiter9;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class53.Struct156>(ref taskAwaiter9, ref this);
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
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class53.Struct156>(ref taskAwaiter8, ref this);
						return;
					}
					IL_17C:
					string result2 = taskAwaiter8.GetResult();
					htmlDocument2.LoadHtml(result2);
					htmlDocument2 = null;
					@class.string_7 = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='pid']").Attributes["value"].Value;
					@class.method_5("Found PID: " + @class.string_7, "#c2c2c2", true, false);
					goto IL_279;
				}
				catch (ThreadAbortException)
				{
					goto IL_279;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_22D;
				}
				@class.method_5("Waiting for variants", "#c2c2c2", true, false);
				taskAwaiter7 = @class.method_14(Class130.int_0).GetAwaiter();
				if (taskAwaiter7.IsCompleted)
				{
					goto IL_226;
				}
				int num9 = 2;
				num = 2;
				num2 = num9;
				taskAwaiter6 = taskAwaiter7;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class53.Struct156>(ref taskAwaiter7, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_279:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000827 RID: 2087 RVA: 0x00006946 File Offset: 0x00004B46
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400070C RID: 1804
		public int int_0;

		// Token: 0x0400070D RID: 1805
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x0400070E RID: 1806
		public Class53 class53_0;

		// Token: 0x0400070F RID: 1807
		private HtmlDocument htmlDocument_0;

		// Token: 0x04000710 RID: 1808
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000711 RID: 1809
		private HtmlDocument htmlDocument_1;

		// Token: 0x04000712 RID: 1810
		private TaskAwaiter<string> taskAwaiter_1;

		// Token: 0x04000713 RID: 1811
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x02000180 RID: 384
	[StructLayout(LayoutKind.Auto)]
	private struct Struct157 : IAsyncStateMachine
	{
		// Token: 0x06000828 RID: 2088 RVA: 0x00049664 File Offset: 0x00047864
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class53 @class = this;
			try
			{
				if (num <= 1)
				{
					goto IL_529;
				}
				if (num != 2)
				{
					goto IL_51F;
				}
				TaskAwaiter taskAwaiter7 = taskAwaiter6;
				taskAwaiter6 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_518:
				taskAwaiter7.GetResult();
				IL_51F:
				if (@class.bool_1)
				{
					goto IL_56B;
				}
				int num4 = 0;
				IL_529:
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
							goto IL_4B8;
						}
						@class.method_5("Submitting shipping", "#c2c2c2", true, false);
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary["shipping-method"] = @class.string_12;
						dictionary["newsletter-email"] = "off";
						dictionary["sa-civility"] = "MR";
						dictionary["sa-first-name"] = (string)@class.jtoken_1["delivery"]["first_name"];
						dictionary["sa-last-name"] = (string)@class.jtoken_1["delivery"]["last_name"];
						dictionary["sa-number-and-street"] = (string)@class.jtoken_1["delivery"]["addr1"];
						dictionary["sa-zip-code"] = (string)@class.jtoken_1["delivery"]["zip"];
						dictionary["sa-town"] = (string)@class.jtoken_1["delivery"]["city"];
						dictionary["sa-phone"] = (string)@class.jtoken_1["payment"]["phone"];
						dictionary["sa-state"] = Class43.smethod_1((string)@class.jtoken_1["delivery"]["country"], (string)@class.jtoken_1["delivery"]["state"]);
						dictionary["sa-country"] = Class43.smethod_0((string)@class.jtoken_1["delivery"]["country"], false);
						dictionary["guest-emailconfirmation"] = (string)@class.jtoken_1["payment"]["email"];
						dictionary["ba-civility"] = "MR";
						dictionary["ba-first-name"] = (string)@class.jtoken_1["billing"]["first_name"];
						dictionary["ba-last-name"] = (string)@class.jtoken_1["billing"]["last_name"];
						dictionary["ba-number-and-street"] = (string)@class.jtoken_1["billing"]["addr1"];
						dictionary["ba-zip-code"] = (string)@class.jtoken_1["billing"]["zip"];
						dictionary["ba-town"] = (string)@class.jtoken_1["billing"]["city"];
						dictionary["ba-phone"] = (string)@class.jtoken_1["payment"]["phone"];
						dictionary["ba-state"] = Class43.smethod_1((string)@class.jtoken_1["billing"]["country"], (string)@class.jtoken_1["billing"]["state"]);
						dictionary["ba-country"] = Class43.smethod_0((string)@class.jtoken_1["billing"]["country"], false);
						dictionary["receivenews"] = "off";
						dictionary["sa-ignoredavcheck"] = "true";
						taskAwaiter9 = @class.class14_0.method_3(string.Format("https://www.lacoste.com{0}COShipmentV2-ValidateShippingStep?isajax=true", @class.string_16), dictionary, false).GetAwaiter();
						if (!taskAwaiter9.IsCompleted)
						{
							int num6 = 0;
							num = 0;
							num2 = num6;
							taskAwaiter2 = taskAwaiter9;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class53.Struct157>(ref taskAwaiter9, ref this);
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
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class53.Struct157>(ref taskAwaiter8, ref this);
						return;
					}
					IL_4B8:
					if (taskAwaiter8.GetResult().Contains("We apologize but we do not ship to"))
					{
						@class.method_0("Unsupported country", "red", true, (GEnum1)0);
					}
					goto IL_56B;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_51F;
				}
				@class.method_5("Error submitting shipping", "#c2c2c2", true, false);
				taskAwaiter7 = @class.method_14(Class130.int_0).GetAwaiter();
				if (taskAwaiter7.IsCompleted)
				{
					goto IL_518;
				}
				int num9 = 2;
				num = 2;
				num2 = num9;
				taskAwaiter6 = taskAwaiter7;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class53.Struct157>(ref taskAwaiter7, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_56B:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000829 RID: 2089 RVA: 0x00006954 File Offset: 0x00004B54
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000714 RID: 1812
		public int int_0;

		// Token: 0x04000715 RID: 1813
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000716 RID: 1814
		public Class53 class53_0;

		// Token: 0x04000717 RID: 1815
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000718 RID: 1816
		private TaskAwaiter<string> taskAwaiter_1;

		// Token: 0x04000719 RID: 1817
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x02000181 RID: 385
	[StructLayout(LayoutKind.Auto)]
	private struct Struct158 : IAsyncStateMachine
	{
		// Token: 0x0600082A RID: 2090 RVA: 0x00049C24 File Offset: 0x00047E24
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class53 @class = this;
			try
			{
				if (num == 0)
				{
					goto IL_160;
				}
				if (num != 1)
				{
					goto IL_156;
				}
				TaskAwaiter taskAwaiter3 = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_14F:
				taskAwaiter3.GetResult();
				IL_156:
				if (@class.bool_1)
				{
					goto IL_1A2;
				}
				int num4 = 0;
				IL_160:
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter4;
					if (num != 0)
					{
						@class.method_5("Logging in", "#c2c2c2", true, false);
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary["email"] = (string)@class.jtoken_1["payment"]["email"];
						taskAwaiter4 = @class.class14_0.method_3(string.Format("https://www.lacoste.com{0}LoginV2-LoginCheckout", @class.string_16), dictionary, false).GetAwaiter();
						if (!taskAwaiter4.IsCompleted)
						{
							int num5 = 0;
							num = 0;
							num2 = num5;
							TaskAwaiter<HttpResponseMessage> taskAwaiter5 = taskAwaiter4;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class53.Struct158>(ref taskAwaiter4, ref this);
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
					@class.method_5("Successfully logged in", "#c2c2c2", true, false);
					goto IL_1A2;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_156;
				}
				@class.method_5("Error loggin in", "#c2c2c2", true, false);
				taskAwaiter3 = @class.method_14(Class130.int_0).GetAwaiter();
				if (taskAwaiter3.IsCompleted)
				{
					goto IL_14F;
				}
				int num7 = 1;
				num = 1;
				num2 = num7;
				taskAwaiter2 = taskAwaiter3;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class53.Struct158>(ref taskAwaiter3, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_1A2:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x0600082B RID: 2091 RVA: 0x00006962 File Offset: 0x00004B62
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400071A RID: 1818
		public int int_0;

		// Token: 0x0400071B RID: 1819
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x0400071C RID: 1820
		public Class53 class53_0;

		// Token: 0x0400071D RID: 1821
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x0400071E RID: 1822
		private TaskAwaiter taskAwaiter_1;
	}
}
