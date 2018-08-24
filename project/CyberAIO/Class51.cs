using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

// Token: 0x0200012C RID: 300
internal sealed class Class51 : Class44
{
	// Token: 0x060006E1 RID: 1761 RVA: 0x000390F0 File Offset: 0x000372F0
	public Class51(JToken jtoken_2, string string_14)
	{
		try
		{
			this.jtoken_0 = jtoken_2;
			this.string_8 = (string)jtoken_2["keywords"];
			this.string_10 = string_14;
			if (!((string)jtoken_2["size"] == "Random") && !((string)jtoken_2["size"] == "OneSize"))
			{
				this.string_0 = (string)jtoken_2["size"];
				if (!this.string_0.Contains(".5") && this.string_0.Replace(".", string.Empty).smethod_15())
				{
					this.string_0 += ".0";
				}
				if (this.string_0.Length == 3)
				{
					this.string_0 = "0" + this.string_0;
				}
			}
			else
			{
				this.bool_0 = true;
			}
			this.string_0 = Class43.smethod_4(this.string_0);
			if (!base.method_2(out this.jtoken_1))
			{
				base.method_0("Profile error", "red", true, (GEnum1)0);
			}
			else
			{
				this.class14_0 = new Class14(base.method_3(), "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36", 10, false, false, null);
				this.class14_0.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
				this.class14_0.httpClient_0.DefaultRequestHeaders.ExpectContinue = new bool?(false);
			}
		}
		catch
		{
			base.method_0("Task error", "red", true, (GEnum1)0);
		}
	}

	// Token: 0x060006E2 RID: 1762 RVA: 0x000392A8 File Offset: 0x000374A8
	public override async void vmethod_0()
	{
		try
		{
			await this.method_16();
			this.task_0 = this.method_19();
			this.task_1 = this.method_22();
			this.task_3 = this.method_20();
			this.task_4 = this.method_21();
			this.task_2 = this.method_23();
			await base.method_11();
			await this.method_15();
			await this.method_18();
			await this.task_3;
			await this.task_4;
			await this.task_2;
			await this.method_24();
		}
		catch
		{
		}
		base.method_0("Stopped", "red", true, (GEnum1)0);
	}

	// Token: 0x060006E3 RID: 1763 RVA: 0x000392E4 File Offset: 0x000374E4
	public async Task method_15()
	{
		base.method_5("Waiting for product", "#c2c2c2", true, false);
		while (!this.bool_1)
		{
			int num = 0;
			TaskAwaiter taskAwaiter2;
			try
			{
				HttpResponseMessage httpResponseMessage = await this.class14_0.method_2(string.Format("https://www.{0}/api/products/pdp/{1}", this.string_10, this.string_8), false);
				httpResponseMessage.EnsureSuccessStatusCode();
				JObject jobject = await httpResponseMessage.smethod_1();
				base.method_7(jobject["name"].ToString(), "#c2c2c2");
				JToken jtoken = jobject["variantAttributes"].FirstOrDefault(new Func<JToken, bool>(this.method_25));
				if (jtoken != null)
				{
					this.bool_3 = (bool)jtoken["recaptchaOn"];
					if ((bool)jtoken["displayCountDownTimer"])
					{
						TaskAwaiter taskAwaiter = base.method_12(Convert.ToDateTime(jtoken["skuLaunchDate"].ToString().Replace(" GMT+0000", string.Empty)), "Waiting", true).GetAwaiter();
						if (!taskAwaiter.IsCompleted)
						{
							await taskAwaiter;
							taskAwaiter = taskAwaiter2;
							taskAwaiter2 = default(TaskAwaiter);
						}
						taskAwaiter.GetResult();
					}
					this.string_9 = (string)jtoken["code"];
					if (this.bool_0)
					{
						JToken jtoken2 = jobject["sellableUnits"].Where(new Func<JToken, bool>(this.method_26)).smethod_5();
						if (jtoken2 != null && !(jtoken2["stockLevelStatus"].ToString() != "inStock"))
						{
							base.method_6(jtoken2["attributes"].First(new Func<JToken, bool>(Class51.Class160.class160_0.method_1))["value"].ToString());
							this.string_7 = jtoken2["code"].ToString();
							base.method_5("Found size code: " + this.string_7, "#c2c2c2", true, false);
							break;
						}
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
					else
					{
						JToken jtoken3 = jobject["sellableUnits"].FirstOrDefault(new Func<JToken, bool>(this.method_27));
						if (jtoken3 == null)
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
						if (jtoken3["stockLevelStatus"].ToString() != "inStock")
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
						this.string_7 = jtoken3["code"].ToString();
						base.method_5("Found size code: " + this.string_7, "#c2c2c2", true, false);
						break;
					}
				}
				else
				{
					base.method_0("Product pulled", "red", true, (GEnum1)0);
					jobject = null;
					jtoken = null;
				}
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
				base.method_5("Waiting for product", "#c2c2c2", false, false);
			}
		}
	}

	// Token: 0x060006E4 RID: 1764 RVA: 0x0003932C File Offset: 0x0003752C
	public async Task method_16()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Getting session", "#c2c2c2", true, false);
				TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class14_0.method_2(string.Format("https://www.{0}/api/session", this.string_10), false).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter<HttpResponseMessage> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
				}
				HttpResponseMessage result = taskAwaiter.GetResult();
				if (result.StatusCode == HttpStatusCode.Found && result.Headers.Location.Host == "www.footlocker.eu")
				{
					base.method_0("US proxy required", "red", true, (GEnum1)0);
				}
				result.EnsureSuccessStatusCode();
				HttpRequestHeaders httpRequestHeaders = this.class14_0.httpClient_0.DefaultRequestHeaders;
				TaskAwaiter<JObject> taskAwaiter3 = result.smethod_1().GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<JObject> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<JObject>);
				}
				httpRequestHeaders.TryAddWithoutValidation("x-csrf-token", taskAwaiter3.GetResult()["data"]["csrfToken"].ToString());
				httpRequestHeaders = null;
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error getting session", "#c2c2c2", true, false);
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

	// Token: 0x060006E5 RID: 1765 RVA: 0x00039374 File Offset: 0x00037574
	public async Task method_17()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Getting cookies", "#c2c2c2", true, false);
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error getting cookies", "#c2c2c2", true, false);
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
			}
		}
	}

	// Token: 0x060006E6 RID: 1766 RVA: 0x000393BC File Offset: 0x000375BC
	public async Task method_18()
	{
		JObject jobject = new JObject();
		jobject["productId"] = this.string_7;
		jobject["productQuantity"] = "1";
		JObject jobject2 = jobject;
		if (this.bool_3)
		{
			base.method_5("Waiting for captcha", "turquoise", true, false);
			jobject2["g-recaptcha-response"] = "03AJpayVHiEb9A_5g6z1Dfc_lPxQN7tRhAYf9bxCEQtwx7yRDuCNefGi1RpoQ5fmb7hVx0GVp5Xd5S-O0K3_DzVlKYNKZgNvsGr9VoFcwOCArpECry3oSTAsIa4zoa2d9ojkQVvczakU__iBsKzQntJa6gsyV15juQkkhPGAFiyJrEIxBdiBTdvdgVgiO2whkba3d9FvOpnQSLXht0EoUgUb4pD0oFexemT0BrWlQjqXUOv7LVd0vDtjsOWdqeNJd_nXcHW2NwOMPs-XPsPI9v5VkYipiilieQvuccjSPwicRmXZEBXMHyhfgj5J_G37ezer0bj9sWpI4Spzf6zsPFUcejACU2MgFPdPE-B3jB_RtNwuNwoyM6Q5MNY3TE2_9JO7NDQus3cdZkrrtaTeL7HyrBYNYqBNBrlFHIKi0Wfko5ZyJuDBfkV1JoShSYsWCG-0CPOjAksr1kA_XyV_LTbgSs6s1br3y2UA";
			base.method_5("Adding to cart", "yellow", true, false);
		}
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Adding to cart", "yellow", true, false);
				HttpResponseMessage httpResponseMessage = await this.class14_0.method_4(string.Format("https://www.{0}/api/users/carts/current/entries/", this.string_10), jobject2, false);
				string text = await httpResponseMessage.smethod_3();
				if (!text.Contains("maximum quantity limit") && !text.Contains("ProductLowStockException"))
				{
					httpResponseMessage.EnsureSuccessStatusCode();
					TaskAwaiter<JObject> taskAwaiter = httpResponseMessage.smethod_1().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						await taskAwaiter;
						TaskAwaiter<JObject> taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<JObject>);
					}
					this.string_13 = taskAwaiter.GetResult()["guid"].ToString();
					this.class14_0.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("x-csrf-token", httpResponseMessage.Headers.GetValues("x-csrf-token").First<string>());
					break;
				}
				base.method_5("Waiting for restock", "#c2c2c2", true, false);
				await base.method_14(Class130.int_0);
				await this.method_15();
				continue;
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
					TaskAwaiter taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter);
				}
				taskAwaiter3.GetResult();
			}
		}
	}

	// Token: 0x060006E7 RID: 1767 RVA: 0x00039404 File Offset: 0x00037604
	public async Task method_19()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Setting email", "#c2c2c2", true, false);
				(await this.class14_0.method_8(string.Format("https://www.footaction.com/api/users/carts/current/email/{0}/", this.jtoken_1["payment"]["email"]), new JObject(), false)).EnsureSuccessStatusCode();
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error setting email", "#c2c2c2", true, false);
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

	// Token: 0x060006E8 RID: 1768 RVA: 0x0003944C File Offset: 0x0003764C
	public async Task method_20()
	{
		await this.task_0;
		JObject jobject = new JObject(new JProperty("shippingAddress", new JObject()));
		jobject["shippingAddress"]["country"] = new JObject();
		jobject["shippingAddress"]["country"]["isocode"] = Class43.smethod_0(this.jtoken_1["delivery"]["country"].ToString(), false);
		jobject["shippingAddress"]["country"]["name"] = this.jtoken_1["delivery"]["country"];
		jobject["shippingAddress"]["region"] = new JObject();
		jobject["shippingAddress"]["region"]["isocode"] = Class43.smethod_0(this.jtoken_1["delivery"]["country"].ToString(), false) + "-" + Class43.smethod_1(this.jtoken_1["delivery"]["country"].ToString(), this.jtoken_1["delivery"]["state"].ToString());
		jobject["shippingAddress"]["type"] = "Home/Business Address";
		jobject["shippingAddress"]["setAsBilling"] = true;
		jobject["shippingAddress"]["firstName"] = this.jtoken_1["delivery"]["first_name"];
		jobject["shippingAddress"]["lastName"] = this.jtoken_1["delivery"]["last_name"];
		jobject["shippingAddress"]["line1"] = this.jtoken_1["delivery"]["addr1"];
		jobject["shippingAddress"]["line2"] = this.jtoken_1["delivery"]["addr2"];
		jobject["shippingAddress"]["postalCode"] = this.jtoken_1["delivery"]["zip"];
		jobject["shippingAddress"]["phone"] = this.jtoken_1["payment"]["phone"];
		jobject["shippingAddress"]["email"] = this.jtoken_1["payment"]["email"];
		jobject["shippingAddress"]["town"] = this.jtoken_1["delivery"]["city"];
		jobject["shippingAddress"]["isFPO"] = false;
		jobject["shippingAddress"]["shippingAddress"] = true;
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Submitting shipping", "#c2c2c2", true, false);
				TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class14_0.method_4(string.Format("https://www.{0}/api/users/carts/current/addresses/shipping", this.string_10), jobject, false).GetAwaiter();
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
				this.string_12 = taskAwaiter3.GetResult()["id"].ToString();
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

	// Token: 0x060006E9 RID: 1769 RVA: 0x00039494 File Offset: 0x00037694
	public async Task method_21()
	{
		await this.task_0;
		JObject jobject = new JObject(new JProperty("shippingAddress", new JObject()));
		jobject["country"] = new JObject();
		jobject["country"]["isocode"] = Class43.smethod_0(this.jtoken_1["billing"]["country"].ToString(), false);
		jobject["country"]["name"] = this.jtoken_1["billing"]["country"];
		jobject["region"] = new JObject();
		jobject["region"]["isocode"] = Class43.smethod_0(this.jtoken_1["billing"]["country"].ToString(), false) + "-" + Class43.smethod_1(this.jtoken_1["billing"]["country"].ToString(), this.jtoken_1["delivery"]["state"].ToString());
		jobject["type"] = "Home/Business Address";
		jobject["setAsBilling"] = true;
		jobject["firstName"] = this.jtoken_1["billing"]["first_name"];
		jobject["lastName"] = this.jtoken_1["billing"]["last_name"];
		jobject["line1"] = this.jtoken_1["billing"]["addr1"];
		jobject["line2"] = this.jtoken_1["billing"]["addr2"];
		jobject["postalCode"] = this.jtoken_1["billing"]["zip"];
		jobject["phone"] = this.jtoken_1["payment"]["phone"];
		jobject["email"] = this.jtoken_1["payment"]["email"];
		jobject["town"] = this.jtoken_1["billing"]["city"];
		jobject["isFPO"] = false;
		jobject["shippingAddress"] = false;
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Submitting billing", "#c2c2c2", true, false);
				(await this.class14_0.method_4(string.Format("https://www.{0}/api/users/carts/current/set-billing", this.string_10), jobject, false)).EnsureSuccessStatusCode();
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error submitting billing", "#c2c2c2", true, false);
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

	// Token: 0x060006EA RID: 1770 RVA: 0x000394DC File Offset: 0x000376DC
	public async Task method_22()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary["action"] = "authorize";
		dictionary["companyNumber"] = "1";
		dictionary["customerNumber"] = "1";
		dictionary["cardNumber"] = this.jtoken_1["payment"]["card"]["number"].ToString().Replace(" ", string.Empty);
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Getting payment token", "#c2c2c2", true, false);
				TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class14_0.method_3(string.Format("https://www.{0}/paygate/ccn", this.string_10), dictionary, false).GetAwaiter();
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
				this.string_11 = taskAwaiter3.GetResult().Replace(" ", string.Empty).Split(new string[]
				{
					"token:'"
				}, StringSplitOptions.None)[1].Split(new char[]
				{
					'\''
				})[0];
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error getting payment token", "#c2c2c2", true, false);
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

	// Token: 0x060006EB RID: 1771 RVA: 0x00039524 File Offset: 0x00037724
	public async Task method_23()
	{
		await this.task_3;
		await this.task_4;
		JObject jobject = new JObject();
		jobject["cardType"] = new JObject();
		jobject["cardType"]["code"] = "master";
		jobject["billingAddress"] = new JObject();
		jobject["billingAddress"]["id"] = this.string_12;
		jobject["flApiCCNumber"] = this.string_11;
		jobject["expiryMonth"] = this.jtoken_1["payment"]["card"]["exp_month"];
		jobject["expiryYear"] = this.jtoken_1["payment"]["card"]["exp_year"];
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Submitting payment", "#c2c2c2", true, false);
				(await this.class14_0.method_4(string.Format("https://www.{0}/api/users/carts/current/payment-detail", this.string_10), jobject, false)).EnsureSuccessStatusCode();
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error submitting payment", "#c2c2c2", true, false);
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

	// Token: 0x060006EC RID: 1772 RVA: 0x0003956C File Offset: 0x0003776C
	public async Task method_24()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Submitting order", "orange", true, false);
				JObject jobject = new JObject();
				jobject["cartId"] = this.string_13;
				jobject["securityCode"] = this.jtoken_1["payment"]["card"]["cvv"];
				jobject["deviceId"] = Class108.smethod_17(50);
				HttpResponseMessage httpResponseMessage = await this.class14_0.method_4(string.Format("https://www.{0}/api/users/orders", this.string_10), jobject, false);
				HttpResponseMessage httpResponseMessage_ = httpResponseMessage;
				JObject jobject2 = await httpResponseMessage_.smethod_1();
				string text = await httpResponseMessage_.smethod_3();
				if (text.Contains("we are unable to process your credit card"))
				{
					base.method_0("Payment Declined", "red", true, (GEnum1)5);
				}
				else if (jobject2["calculated"] != null)
				{
					base.method_0("Successfully checked out", "green", true, (GEnum1)6);
				}
				else if (text.Contains("shipping is restricted"))
				{
					base.method_0("Shipping restricted", "red", true, (GEnum1)0);
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
				base.method_5("Error submitting order", "#c2c2c2", true, false);
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

	// Token: 0x060006ED RID: 1773 RVA: 0x00005FC6 File Offset: 0x000041C6
	private bool method_25(JToken jtoken_2)
	{
		return jtoken_2["sku"].ToString() == this.string_8;
	}

	// Token: 0x060006EE RID: 1774 RVA: 0x000395B4 File Offset: 0x000377B4
	private bool method_26(JToken jtoken_2)
	{
		return jtoken_2["attributes"].First(new Func<JToken, bool>(Class51.Class160.class160_0.method_0))["id"].ToString() == this.string_9 && jtoken_2["stockLevelStatus"].ToString() == "inStock";
	}

	// Token: 0x060006EF RID: 1775 RVA: 0x00039628 File Offset: 0x00037828
	private bool method_27(JToken jtoken_2)
	{
		if (jtoken_2["attributes"].First(new Func<JToken, bool>(Class51.Class160.class160_0.method_2))["id"].ToString() == this.string_9)
		{
			return Class43.smethod_2(this.string_0, jtoken_2["attributes"].First(new Func<JToken, bool>(Class51.Class160.class160_0.method_3))["value"].ToString());
		}
		return false;
	}

	// Token: 0x0400052E RID: 1326
	private string string_7;

	// Token: 0x0400052F RID: 1327
	private string string_8;

	// Token: 0x04000530 RID: 1328
	private string string_9;

	// Token: 0x04000531 RID: 1329
	private string string_10;

	// Token: 0x04000532 RID: 1330
	private string string_11;

	// Token: 0x04000533 RID: 1331
	private string string_12;

	// Token: 0x04000534 RID: 1332
	private string string_13;

	// Token: 0x04000535 RID: 1333
	private bool bool_3;

	// Token: 0x04000536 RID: 1334
	private Task task_0;

	// Token: 0x04000537 RID: 1335
	private Task task_1;

	// Token: 0x04000538 RID: 1336
	private Task task_2;

	// Token: 0x04000539 RID: 1337
	private Task task_3;

	// Token: 0x0400053A RID: 1338
	private Task task_4;

	// Token: 0x0200012D RID: 301
	[Serializable]
	private sealed class Class160
	{
		// Token: 0x060006F2 RID: 1778 RVA: 0x00005FEF File Offset: 0x000041EF
		internal bool method_0(JToken jtoken_0)
		{
			return jtoken_0["type"].ToString() == "style";
		}

		// Token: 0x060006F3 RID: 1779 RVA: 0x0000600B File Offset: 0x0000420B
		internal bool method_1(JToken jtoken_0)
		{
			return jtoken_0["type"].ToString() == "size";
		}

		// Token: 0x060006F4 RID: 1780 RVA: 0x00005FEF File Offset: 0x000041EF
		internal bool method_2(JToken jtoken_0)
		{
			return jtoken_0["type"].ToString() == "style";
		}

		// Token: 0x060006F5 RID: 1781 RVA: 0x0000600B File Offset: 0x0000420B
		internal bool method_3(JToken jtoken_0)
		{
			return jtoken_0["type"].ToString() == "size";
		}

		// Token: 0x0400053B RID: 1339
		public static readonly Class51.Class160 class160_0 = new Class51.Class160();

		// Token: 0x0400053C RID: 1340
		public static Func<JToken, bool> func_0;

		// Token: 0x0400053D RID: 1341
		public static Func<JToken, bool> func_1;

		// Token: 0x0400053E RID: 1342
		public static Func<JToken, bool> func_2;

		// Token: 0x0400053F RID: 1343
		public static Func<JToken, bool> func_3;
	}

	// Token: 0x0200012E RID: 302
	[StructLayout(LayoutKind.Auto)]
	private struct Struct104 : IAsyncStateMachine
	{
		// Token: 0x060006F6 RID: 1782 RVA: 0x000396CC File Offset: 0x000378CC
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class51 @class = this;
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
						goto IL_11F;
					}
					case 2:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_17A;
					}
					case 3:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_1D5;
					}
					case 4:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_230;
					}
					case 5:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_28B;
					}
					case 6:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_2E6;
					}
					case 7:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_33E;
					}
					default:
						taskAwaiter = @class.method_16().GetAwaiter();
						if (!taskAwaiter.IsCompleted)
						{
							num2 = 0;
							TaskAwaiter taskAwaiter2 = taskAwaiter;
							this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class51.Struct104>(ref taskAwaiter, ref this);
							return;
						}
						break;
					}
					taskAwaiter.GetResult();
					@class.task_0 = @class.method_19();
					@class.task_1 = @class.method_22();
					@class.task_3 = @class.method_20();
					@class.task_4 = @class.method_21();
					@class.task_2 = @class.method_23();
					taskAwaiter = @class.method_11().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 1;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class51.Struct104>(ref taskAwaiter, ref this);
						return;
					}
					IL_11F:
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_15().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 2;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class51.Struct104>(ref taskAwaiter, ref this);
						return;
					}
					IL_17A:
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_18().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 3;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class51.Struct104>(ref taskAwaiter, ref this);
						return;
					}
					IL_1D5:
					taskAwaiter.GetResult();
					taskAwaiter = @class.task_3.GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 4;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class51.Struct104>(ref taskAwaiter, ref this);
						return;
					}
					IL_230:
					taskAwaiter.GetResult();
					taskAwaiter = @class.task_4.GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 5;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class51.Struct104>(ref taskAwaiter, ref this);
						return;
					}
					IL_28B:
					taskAwaiter.GetResult();
					taskAwaiter = @class.task_2.GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 6;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class51.Struct104>(ref taskAwaiter, ref this);
						return;
					}
					IL_2E6:
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_24().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 7;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class51.Struct104>(ref taskAwaiter, ref this);
						return;
					}
					IL_33E:
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

		// Token: 0x060006F7 RID: 1783 RVA: 0x00006027 File Offset: 0x00004227
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000540 RID: 1344
		public int int_0;

		// Token: 0x04000541 RID: 1345
		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		// Token: 0x04000542 RID: 1346
		public Class51 class51_0;

		// Token: 0x04000543 RID: 1347
		private TaskAwaiter taskAwaiter_0;
	}

	// Token: 0x0200012F RID: 303
	[StructLayout(LayoutKind.Auto)]
	private struct Struct105 : IAsyncStateMachine
	{
		// Token: 0x060006F8 RID: 1784 RVA: 0x00039A98 File Offset: 0x00037C98
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class51 @class = this;
			try
			{
				TaskAwaiter taskAwaiter5;
				if (num > 4)
				{
					if (num == 5)
					{
						taskAwaiter5 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter);
						int num3 = -1;
						num = -1;
						num2 = num3;
						goto IL_3BF;
					}
					JObject jobject3 = new JObject();
					jobject3["productId"] = @class.string_7;
					jobject3["productQuantity"] = "1";
					jobject2 = jobject3;
					if (@class.bool_3)
					{
						@class.method_5("Waiting for captcha", "turquoise", true, false);
						jobject2["g-recaptcha-response"] = "03AJpayVHiEb9A_5g6z1Dfc_lPxQN7tRhAYf9bxCEQtwx7yRDuCNefGi1RpoQ5fmb7hVx0GVp5Xd5S-O0K3_DzVlKYNKZgNvsGr9VoFcwOCArpECry3oSTAsIa4zoa2d9ojkQVvczakU__iBsKzQntJa6gsyV15juQkkhPGAFiyJrEIxBdiBTdvdgVgiO2whkba3d9FvOpnQSLXht0EoUgUb4pD0oFexemT0BrWlQjqXUOv7LVd0vDtjsOWdqeNJd_nXcHW2NwOMPs-XPsPI9v5VkYipiilieQvuccjSPwicRmXZEBXMHyhfgj5J_G37ezer0bj9sWpI4Spzf6zsPFUcejACU2MgFPdPE-B3jB_RtNwuNwoyM6Q5MNY3TE2_9JO7NDQus3cdZkrrtaTeL7HyrBYNYqBNBrlFHIKi0Wfko5ZyJuDBfkV1JoShSYsWCG-0CPOjAksr1kA_XyV_LTbgSs6s1br3y2UA";
						@class.method_5("Adding to cart", "yellow", true, false);
						goto IL_3CF;
					}
					goto IL_3CF;
				}
				IL_C1:
				int num14;
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter6;
					TaskAwaiter<string> taskAwaiter8;
					TaskAwaiter<JObject> taskAwaiter10;
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
						TaskAwaiter<string> taskAwaiter9;
						taskAwaiter8 = taskAwaiter9;
						taskAwaiter9 = default(TaskAwaiter<string>);
						int num5 = -1;
						num = -1;
						num2 = num5;
						goto IL_1CE;
					}
					case 2:
					{
						taskAwaiter5 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter);
						int num6 = -1;
						num = -1;
						num2 = num6;
						goto IL_2AC;
					}
					case 3:
					{
						taskAwaiter5 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter);
						int num7 = -1;
						num = -1;
						num2 = num7;
						goto IL_307;
					}
					case 4:
					{
						taskAwaiter10 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<JObject>);
						int num8 = -1;
						num = -1;
						num2 = num8;
						goto IL_330;
					}
					default:
						@class.method_5("Adding to cart", "yellow", true, false);
						taskAwaiter6 = @class.class14_0.method_4(string.Format("https://www.{0}/api/users/carts/current/entries/", @class.string_10), jobject2, false).GetAwaiter();
						if (!taskAwaiter6.IsCompleted)
						{
							int num9 = 0;
							num = 0;
							num2 = num9;
							TaskAwaiter<HttpResponseMessage> taskAwaiter7 = taskAwaiter6;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class51.Struct105>(ref taskAwaiter6, ref this);
							return;
						}
						break;
					}
					HttpResponseMessage result = taskAwaiter6.GetResult();
					httpResponseMessage = result;
					taskAwaiter8 = httpResponseMessage.smethod_3().GetAwaiter();
					if (!taskAwaiter8.IsCompleted)
					{
						int num10 = 1;
						num = 1;
						num2 = num10;
						TaskAwaiter<string> taskAwaiter9 = taskAwaiter8;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class51.Struct105>(ref taskAwaiter8, ref this);
						return;
					}
					IL_1CE:
					string result2 = taskAwaiter8.GetResult();
					if (!result2.Contains("maximum quantity limit") && !result2.Contains("ProductLowStockException"))
					{
						httpResponseMessage.EnsureSuccessStatusCode();
						taskAwaiter10 = httpResponseMessage.smethod_1().GetAwaiter();
						if (!taskAwaiter10.IsCompleted)
						{
							int num11 = 4;
							num = 4;
							num2 = num11;
							taskAwaiter2 = taskAwaiter10;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class51.Struct105>(ref taskAwaiter10, ref this);
							return;
						}
						goto IL_330;
					}
					else
					{
						@class.method_5("Waiting for restock", "#c2c2c2", true, false);
						taskAwaiter5 = @class.method_14(Class130.int_0).GetAwaiter();
						if (!taskAwaiter5.IsCompleted)
						{
							int num12 = 2;
							num = 2;
							num2 = num12;
							taskAwaiter4 = taskAwaiter5;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class51.Struct105>(ref taskAwaiter5, ref this);
							return;
						}
					}
					IL_2AC:
					taskAwaiter5.GetResult();
					taskAwaiter5 = @class.method_15().GetAwaiter();
					if (!taskAwaiter5.IsCompleted)
					{
						int num13 = 3;
						num = 3;
						num2 = num13;
						taskAwaiter4 = taskAwaiter5;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class51.Struct105>(ref taskAwaiter5, ref this);
						return;
					}
					IL_307:
					taskAwaiter5.GetResult();
					goto IL_3CF;
					IL_330:
					JObject result3 = taskAwaiter10.GetResult();
					@class.string_13 = result3["guid"].ToString();
					@class.class14_0.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("x-csrf-token", httpResponseMessage.Headers.GetValues("x-csrf-token").First<string>());
					goto IL_414;
				}
				catch
				{
					num14 = 1;
				}
				if (num14 != 1)
				{
					goto IL_3CF;
				}
				@class.method_5("Error adding to cart", "#c2c2c2", true, false);
				taskAwaiter5 = @class.method_14(Class130.int_1).GetAwaiter();
				if (!taskAwaiter5.IsCompleted)
				{
					int num15 = 5;
					num = 5;
					num2 = num15;
					taskAwaiter4 = taskAwaiter5;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class51.Struct105>(ref taskAwaiter5, ref this);
					return;
				}
				IL_3BF:
				taskAwaiter5.GetResult();
				IL_3CF:
				if (!@class.bool_1)
				{
					num14 = 0;
					goto IL_C1;
				}
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_414:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060006F9 RID: 1785 RVA: 0x00006035 File Offset: 0x00004235
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000544 RID: 1348
		public int int_0;

		// Token: 0x04000545 RID: 1349
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000546 RID: 1350
		public Class51 class51_0;

		// Token: 0x04000547 RID: 1351
		private JObject jobject_0;

		// Token: 0x04000548 RID: 1352
		private HttpResponseMessage httpResponseMessage_0;

		// Token: 0x04000549 RID: 1353
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x0400054A RID: 1354
		private TaskAwaiter<string> taskAwaiter_1;

		// Token: 0x0400054B RID: 1355
		private TaskAwaiter taskAwaiter_2;

		// Token: 0x0400054C RID: 1356
		private TaskAwaiter<JObject> taskAwaiter_3;
	}

	// Token: 0x02000130 RID: 304
	[StructLayout(LayoutKind.Auto)]
	private struct Struct106 : IAsyncStateMachine
	{
		// Token: 0x060006FA RID: 1786 RVA: 0x00039F00 File Offset: 0x00038100
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class51 @class = this;
			try
			{
				TaskAwaiter taskAwaiter3;
				int num6;
				switch (num)
				{
				case 0:
				{
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					int num3 = -1;
					num = -1;
					num2 = num3;
					break;
				}
				case 1:
				{
					IL_39C:
					try
					{
						TaskAwaiter<HttpResponseMessage> taskAwaiter4;
						if (num != 1)
						{
							@class.method_5("Submitting billing", "#c2c2c2", true, false);
							taskAwaiter4 = @class.class14_0.method_4(string.Format("https://www.{0}/api/users/carts/current/set-billing", @class.string_10), jobject, false).GetAwaiter();
							if (!taskAwaiter4.IsCompleted)
							{
								int num4 = 1;
								num = 1;
								num2 = num4;
								TaskAwaiter<HttpResponseMessage> taskAwaiter5 = taskAwaiter4;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class51.Struct106>(ref taskAwaiter4, ref this);
								return;
							}
						}
						else
						{
							TaskAwaiter<HttpResponseMessage> taskAwaiter5;
							taskAwaiter4 = taskAwaiter5;
							taskAwaiter5 = default(TaskAwaiter<HttpResponseMessage>);
							int num5 = -1;
							num = -1;
							num2 = num5;
						}
						taskAwaiter4.GetResult().EnsureSuccessStatusCode();
						goto IL_4C0;
					}
					catch
					{
						num6 = 1;
					}
					if (num6 != 1)
					{
						goto IL_443;
					}
					@class.method_5("Error submitting billing", "#c2c2c2", true, false);
					taskAwaiter3 = @class.method_14(Class130.int_1).GetAwaiter();
					if (taskAwaiter3.IsCompleted)
					{
						goto IL_47C;
					}
					int num7 = 2;
					num = 2;
					num2 = num7;
					taskAwaiter2 = taskAwaiter3;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class51.Struct106>(ref taskAwaiter3, ref this);
					return;
				}
				case 2:
				{
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					int num8 = -1;
					num = -1;
					num2 = num8;
					goto IL_47C;
				}
				default:
					taskAwaiter3 = @class.task_0.GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						int num9 = 0;
						num = 0;
						num2 = num9;
						taskAwaiter2 = taskAwaiter3;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class51.Struct106>(ref taskAwaiter3, ref this);
						return;
					}
					break;
				}
				taskAwaiter3.GetResult();
				jobject = new JObject(new JProperty("shippingAddress", new JObject()));
				jobject["country"] = new JObject();
				jobject["country"]["isocode"] = Class43.smethod_0(@class.jtoken_1["billing"]["country"].ToString(), false);
				jobject["country"]["name"] = @class.jtoken_1["billing"]["country"];
				jobject["region"] = new JObject();
				jobject["region"]["isocode"] = Class43.smethod_0(@class.jtoken_1["billing"]["country"].ToString(), false) + "-" + Class43.smethod_1(@class.jtoken_1["billing"]["country"].ToString(), @class.jtoken_1["delivery"]["state"].ToString());
				jobject["type"] = "Home/Business Address";
				jobject["setAsBilling"] = true;
				jobject["firstName"] = @class.jtoken_1["billing"]["first_name"];
				jobject["lastName"] = @class.jtoken_1["billing"]["last_name"];
				jobject["line1"] = @class.jtoken_1["billing"]["addr1"];
				jobject["line2"] = @class.jtoken_1["billing"]["addr2"];
				jobject["postalCode"] = @class.jtoken_1["billing"]["zip"];
				jobject["phone"] = @class.jtoken_1["payment"]["phone"];
				jobject["email"] = @class.jtoken_1["payment"]["email"];
				jobject["town"] = @class.jtoken_1["billing"]["city"];
				jobject["isFPO"] = false;
				jobject["shippingAddress"] = false;
				IL_443:
				if (@class.bool_1)
				{
					goto IL_4C0;
				}
				num6 = 0;
				goto IL_39C;
				IL_47C:
				taskAwaiter3.GetResult();
				goto IL_443;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_4C0:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060006FB RID: 1787 RVA: 0x00006043 File Offset: 0x00004243
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400054D RID: 1357
		public int int_0;

		// Token: 0x0400054E RID: 1358
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x0400054F RID: 1359
		public Class51 class51_0;

		// Token: 0x04000550 RID: 1360
		private JObject jobject_0;

		// Token: 0x04000551 RID: 1361
		private TaskAwaiter taskAwaiter_0;

		// Token: 0x04000552 RID: 1362
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_1;
	}

	// Token: 0x02000131 RID: 305
	[StructLayout(LayoutKind.Auto)]
	private struct Struct107 : IAsyncStateMachine
	{
		// Token: 0x060006FC RID: 1788 RVA: 0x0003A414 File Offset: 0x00038614
		void IAsyncStateMachine.MoveNext()
		{
			int num3;
			int num2 = num3;
			Class51 @class = this;
			try
			{
				TaskAwaiter taskAwaiter3;
				if (num2 > 5)
				{
					if (num2 != 6)
					{
						@class.method_5("Waiting for product", "#c2c2c2", true, false);
						goto IL_5A5;
					}
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					int num4 = -1;
					num2 = -1;
					num3 = num4;
					goto IL_57E;
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
						goto IL_144;
					}
					case 2:
					{
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num7 = -1;
						num2 = -1;
						num3 = num7;
						goto IL_288;
					}
					case 3:
					{
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num8 = -1;
						num2 = -1;
						num3 = num8;
						goto IL_4F7;
					}
					case 4:
					{
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num9 = -1;
						num2 = -1;
						num3 = num9;
						goto IL_51F;
					}
					case 5:
					{
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num10 = -1;
						num2 = -1;
						num3 = num10;
						goto IL_544;
					}
					default:
						taskAwaiter4 = @class.class14_0.method_2(string.Format("https://www.{0}/api/products/pdp/{1}", @class.string_10, @class.string_8), false).GetAwaiter();
						if (!taskAwaiter4.IsCompleted)
						{
							int num11 = 0;
							num2 = 0;
							num3 = num11;
							TaskAwaiter<HttpResponseMessage> taskAwaiter5 = taskAwaiter4;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class51.Struct107>(ref taskAwaiter4, ref this);
							return;
						}
						break;
					}
					HttpResponseMessage result = taskAwaiter4.GetResult();
					result.EnsureSuccessStatusCode();
					taskAwaiter6 = result.smethod_1().GetAwaiter();
					if (!taskAwaiter6.IsCompleted)
					{
						int num12 = 1;
						num2 = 1;
						num3 = num12;
						TaskAwaiter<JObject> taskAwaiter7 = taskAwaiter6;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class51.Struct107>(ref taskAwaiter6, ref this);
						return;
					}
					IL_144:
					JObject result2 = taskAwaiter6.GetResult();
					jobject = result2;
					@class.method_7(jobject["name"].ToString(), "#c2c2c2");
					jtoken = jobject["variantAttributes"].FirstOrDefault(new Func<JToken, bool>(@class.method_25));
					if (jtoken == null)
					{
						@class.method_0("Product pulled", "red", true, (GEnum1)0);
						jobject = null;
						jtoken = null;
						goto IL_557;
					}
					@class.bool_3 = (bool)jtoken["recaptchaOn"];
					if (!(bool)jtoken["displayCountDownTimer"])
					{
						goto IL_28F;
					}
					DateTime dateTime_ = Convert.ToDateTime(jtoken["skuLaunchDate"].ToString().Replace(" GMT+0000", string.Empty));
					taskAwaiter3 = @class.method_12(dateTime_, "Waiting", true).GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						int num13 = 2;
						num2 = 2;
						num3 = num13;
						taskAwaiter2 = taskAwaiter3;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class51.Struct107>(ref taskAwaiter3, ref this);
						return;
					}
					IL_288:
					taskAwaiter3.GetResult();
					IL_28F:
					@class.string_9 = (string)jtoken["code"];
					if (@class.bool_0)
					{
						JToken jtoken2 = jobject["sellableUnits"].Where(new Func<JToken, bool>(@class.method_26)).smethod_5();
						if (jtoken2 != null && !(jtoken2["stockLevelStatus"].ToString() != "inStock"))
						{
							@class.method_6(jtoken2["attributes"].First(new Func<JToken, bool>(Class51.Class160.class160_0.method_1))["value"].ToString());
							@class.string_7 = jtoken2["code"].ToString();
							@class.method_5("Found size code: " + @class.string_7, "#c2c2c2", true, false);
							goto IL_5EA;
						}
						@class.method_5("Waiting for restock", "#c2c2c2", true, false);
						taskAwaiter3 = @class.method_14(Class130.int_0).GetAwaiter();
						if (!taskAwaiter3.IsCompleted)
						{
							int num14 = 3;
							num2 = 3;
							num3 = num14;
							taskAwaiter2 = taskAwaiter3;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class51.Struct107>(ref taskAwaiter3, ref this);
							return;
						}
					}
					else
					{
						JToken jtoken3 = jobject["sellableUnits"].FirstOrDefault(new Func<JToken, bool>(@class.method_27));
						if (jtoken3 == null)
						{
							taskAwaiter3 = @class.method_14(Class130.int_0).GetAwaiter();
							if (!taskAwaiter3.IsCompleted)
							{
								int num15 = 4;
								num2 = 4;
								num3 = num15;
								taskAwaiter2 = taskAwaiter3;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class51.Struct107>(ref taskAwaiter3, ref this);
								return;
							}
							goto IL_51F;
						}
						else
						{
							if (!(jtoken3["stockLevelStatus"].ToString() != "inStock"))
							{
								@class.string_7 = jtoken3["code"].ToString();
								@class.method_5("Found size code: " + @class.string_7, "#c2c2c2", true, false);
								goto IL_5EA;
							}
							@class.method_5("Waiting for restock", "#c2c2c2", true, false);
							taskAwaiter3 = @class.method_14(Class130.int_0).GetAwaiter();
							if (!taskAwaiter3.IsCompleted)
							{
								int num16 = 5;
								num2 = 5;
								num3 = num16;
								taskAwaiter2 = taskAwaiter3;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class51.Struct107>(ref taskAwaiter3, ref this);
								return;
							}
							goto IL_544;
						}
					}
					IL_4F7:
					taskAwaiter3.GetResult();
					goto IL_5A5;
					IL_51F:
					taskAwaiter3.GetResult();
					goto IL_5A5;
					IL_544:
					taskAwaiter3.GetResult();
					goto IL_5A5;
				}
				catch
				{
					num = 1;
				}
				IL_557:
				int num17 = num;
				if (num17 != 1)
				{
					goto IL_5A5;
				}
				taskAwaiter3 = @class.method_14(Class130.int_0).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					int num18 = 6;
					num2 = 6;
					num3 = num18;
					taskAwaiter2 = taskAwaiter3;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class51.Struct107>(ref taskAwaiter3, ref this);
					return;
				}
				IL_57E:
				taskAwaiter3.GetResult();
				@class.method_5("Waiting for product", "#c2c2c2", false, false);
				IL_5A5:
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
			IL_5EA:
			num3 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060006FD RID: 1789 RVA: 0x00006051 File Offset: 0x00004251
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000553 RID: 1363
		public int int_0;

		// Token: 0x04000554 RID: 1364
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000555 RID: 1365
		public Class51 class51_0;

		// Token: 0x04000556 RID: 1366
		private int int_1;

		// Token: 0x04000557 RID: 1367
		private JObject jobject_0;

		// Token: 0x04000558 RID: 1368
		private JToken jtoken_0;

		// Token: 0x04000559 RID: 1369
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x0400055A RID: 1370
		private TaskAwaiter<JObject> taskAwaiter_1;

		// Token: 0x0400055B RID: 1371
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x02000132 RID: 306
	[StructLayout(LayoutKind.Auto)]
	private struct Struct108 : IAsyncStateMachine
	{
		// Token: 0x060006FE RID: 1790 RVA: 0x0003AA54 File Offset: 0x00038C54
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class51 @class = this;
			try
			{
				if (num <= 2)
				{
					goto IL_2DF;
				}
				if (num != 3)
				{
					goto IL_2D5;
				}
				TaskAwaiter taskAwaiter3 = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_2CE:
				taskAwaiter3.GetResult();
				IL_2D5:
				if (@class.bool_1)
				{
					goto IL_321;
				}
				int num4 = 0;
				IL_2DF:
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter4;
					TaskAwaiter<JObject> taskAwaiter6;
					TaskAwaiter<string> taskAwaiter8;
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
						goto IL_1A1;
					}
					case 2:
					{
						TaskAwaiter<string> taskAwaiter9;
						taskAwaiter8 = taskAwaiter9;
						taskAwaiter9 = default(TaskAwaiter<string>);
						int num7 = -1;
						num = -1;
						num2 = num7;
						goto IL_20E;
					}
					default:
					{
						@class.method_5("Submitting order", "orange", true, false);
						JObject jobject3 = new JObject();
						jobject3["cartId"] = @class.string_13;
						jobject3["securityCode"] = @class.jtoken_1["payment"]["card"]["cvv"];
						jobject3["deviceId"] = Class108.smethod_17(50);
						taskAwaiter4 = @class.class14_0.method_4(string.Format("https://www.{0}/api/users/orders", @class.string_10), jobject3, false).GetAwaiter();
						if (!taskAwaiter4.IsCompleted)
						{
							int num8 = 0;
							num = 0;
							num2 = num8;
							TaskAwaiter<HttpResponseMessage> taskAwaiter5 = taskAwaiter4;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class51.Struct108>(ref taskAwaiter4, ref this);
							return;
						}
						break;
					}
					}
					HttpResponseMessage result = taskAwaiter4.GetResult();
					httpResponseMessage_ = result;
					taskAwaiter6 = httpResponseMessage_.smethod_1().GetAwaiter();
					if (!taskAwaiter6.IsCompleted)
					{
						int num9 = 1;
						num = 1;
						num2 = num9;
						TaskAwaiter<JObject> taskAwaiter7 = taskAwaiter6;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class51.Struct108>(ref taskAwaiter6, ref this);
						return;
					}
					IL_1A1:
					JObject result2 = taskAwaiter6.GetResult();
					jobject2 = result2;
					taskAwaiter8 = httpResponseMessage_.smethod_3().GetAwaiter();
					if (!taskAwaiter8.IsCompleted)
					{
						int num10 = 2;
						num = 2;
						num2 = num10;
						TaskAwaiter<string> taskAwaiter9 = taskAwaiter8;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class51.Struct108>(ref taskAwaiter8, ref this);
						return;
					}
					IL_20E:
					string result3 = taskAwaiter8.GetResult();
					if (result3.Contains("we are unable to process your credit card"))
					{
						@class.method_0("Payment Declined", "red", true, (GEnum1)5);
					}
					else if (jobject2["calculated"] != null)
					{
						@class.method_0("Successfully checked out", "green", true, (GEnum1)6);
					}
					else if (result3.Contains("shipping is restricted"))
					{
						@class.method_0("Shipping restricted", "red", true, (GEnum1)0);
					}
					else
					{
						@class.method_0("Payment error", "red", true, (GEnum1)0);
					}
					goto IL_321;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_2D5;
				}
				@class.method_5("Error submitting order", "#c2c2c2", true, false);
				taskAwaiter3 = @class.method_14(Class130.int_1).GetAwaiter();
				if (taskAwaiter3.IsCompleted)
				{
					goto IL_2CE;
				}
				int num11 = 3;
				num = 3;
				num2 = num11;
				taskAwaiter2 = taskAwaiter3;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class51.Struct108>(ref taskAwaiter3, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_321:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060006FF RID: 1791 RVA: 0x0000605F File Offset: 0x0000425F
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400055C RID: 1372
		public int int_0;

		// Token: 0x0400055D RID: 1373
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x0400055E RID: 1374
		public Class51 class51_0;

		// Token: 0x0400055F RID: 1375
		private HttpResponseMessage httpResponseMessage_0;

		// Token: 0x04000560 RID: 1376
		private JObject jobject_0;

		// Token: 0x04000561 RID: 1377
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000562 RID: 1378
		private TaskAwaiter<JObject> taskAwaiter_1;

		// Token: 0x04000563 RID: 1379
		private TaskAwaiter<string> taskAwaiter_2;

		// Token: 0x04000564 RID: 1380
		private TaskAwaiter taskAwaiter_3;
	}

	// Token: 0x02000133 RID: 307
	[StructLayout(LayoutKind.Auto)]
	private struct Struct109 : IAsyncStateMachine
	{
		// Token: 0x06000700 RID: 1792 RVA: 0x0003ADCC File Offset: 0x00038FCC
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class51 @class = this;
			try
			{
				if (num <= 1)
				{
					goto IL_25B;
				}
				if (num != 2)
				{
					dictionary = new Dictionary<string, string>();
					dictionary["action"] = "authorize";
					dictionary["companyNumber"] = "1";
					dictionary["customerNumber"] = "1";
					dictionary["cardNumber"] = @class.jtoken_1["payment"]["card"]["number"].ToString().Replace(" ", string.Empty);
					goto IL_251;
				}
				TaskAwaiter taskAwaiter7 = taskAwaiter6;
				taskAwaiter6 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_24A:
				taskAwaiter7.GetResult();
				IL_251:
				if (@class.bool_1)
				{
					goto IL_29D;
				}
				int num4 = 0;
				IL_25B:
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
							goto IL_1C7;
						}
						@class.method_5("Getting payment token", "#c2c2c2", true, false);
						taskAwaiter9 = @class.class14_0.method_3(string.Format("https://www.{0}/paygate/ccn", @class.string_10), dictionary, false).GetAwaiter();
						if (!taskAwaiter9.IsCompleted)
						{
							int num6 = 0;
							num = 0;
							num2 = num6;
							taskAwaiter2 = taskAwaiter9;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class51.Struct109>(ref taskAwaiter9, ref this);
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
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class51.Struct109>(ref taskAwaiter8, ref this);
						return;
					}
					IL_1C7:
					string result2 = taskAwaiter8.GetResult();
					@class.string_11 = result2.Replace(" ", string.Empty).Split(new string[]
					{
						"token:'"
					}, StringSplitOptions.None)[1].Split(new char[]
					{
						'\''
					})[0];
					goto IL_29D;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_251;
				}
				@class.method_5("Error getting payment token", "#c2c2c2", true, false);
				taskAwaiter7 = @class.method_14(Class130.int_1).GetAwaiter();
				if (taskAwaiter7.IsCompleted)
				{
					goto IL_24A;
				}
				int num9 = 2;
				num = 2;
				num2 = num9;
				taskAwaiter6 = taskAwaiter7;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class51.Struct109>(ref taskAwaiter7, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_29D:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000701 RID: 1793 RVA: 0x0000606D File Offset: 0x0000426D
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000565 RID: 1381
		public int int_0;

		// Token: 0x04000566 RID: 1382
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000567 RID: 1383
		public Class51 class51_0;

		// Token: 0x04000568 RID: 1384
		private Dictionary<string, string> dictionary_0;

		// Token: 0x04000569 RID: 1385
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x0400056A RID: 1386
		private TaskAwaiter<string> taskAwaiter_1;

		// Token: 0x0400056B RID: 1387
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x02000134 RID: 308
	[StructLayout(LayoutKind.Auto)]
	private struct Struct110 : IAsyncStateMachine
	{
		// Token: 0x06000702 RID: 1794 RVA: 0x0003B0C0 File Offset: 0x000392C0
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class51 @class = this;
			try
			{
				TaskAwaiter taskAwaiter7;
				switch (num)
				{
				case 0:
				{
					taskAwaiter7 = taskAwaiter6;
					taskAwaiter6 = default(TaskAwaiter);
					int num3 = -1;
					num = -1;
					num2 = num3;
					break;
				}
				case 1:
				case 2:
				{
					IL_5BA:
					int num8;
					try
					{
						TaskAwaiter<JObject> taskAwaiter8;
						TaskAwaiter<HttpResponseMessage> taskAwaiter9;
						if (num != 1)
						{
							if (num == 2)
							{
								taskAwaiter8 = taskAwaiter4;
								taskAwaiter4 = default(TaskAwaiter<JObject>);
								int num4 = -1;
								num = -1;
								num2 = num4;
								goto IL_54C;
							}
							@class.method_5("Submitting shipping", "#c2c2c2", true, false);
							taskAwaiter9 = @class.class14_0.method_4(string.Format("https://www.{0}/api/users/carts/current/addresses/shipping", @class.string_10), jobject, false).GetAwaiter();
							if (!taskAwaiter9.IsCompleted)
							{
								int num5 = 1;
								num = 1;
								num2 = num5;
								taskAwaiter2 = taskAwaiter9;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class51.Struct110>(ref taskAwaiter9, ref this);
								return;
							}
						}
						else
						{
							taskAwaiter9 = taskAwaiter2;
							taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
							int num6 = -1;
							num = -1;
							num2 = num6;
						}
						HttpResponseMessage result = taskAwaiter9.GetResult();
						result.EnsureSuccessStatusCode();
						taskAwaiter8 = result.smethod_1().GetAwaiter();
						if (!taskAwaiter8.IsCompleted)
						{
							int num7 = 2;
							num = 2;
							num2 = num7;
							taskAwaiter4 = taskAwaiter8;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class51.Struct110>(ref taskAwaiter8, ref this);
							return;
						}
						IL_54C:
						JObject result2 = taskAwaiter8.GetResult();
						@class.string_12 = result2["id"].ToString();
						goto IL_5FB;
					}
					catch
					{
						num8 = 1;
					}
					if (num8 != 1)
					{
						goto IL_57C;
					}
					@class.method_5("Error submitting shipping", "#c2c2c2", true, false);
					taskAwaiter7 = @class.method_14(Class130.int_1).GetAwaiter();
					if (!taskAwaiter7.IsCompleted)
					{
						int num9 = 3;
						num = 3;
						num2 = num9;
						taskAwaiter6 = taskAwaiter7;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class51.Struct110>(ref taskAwaiter7, ref this);
						return;
					}
					goto IL_443;
				}
				case 3:
				{
					taskAwaiter7 = taskAwaiter6;
					taskAwaiter6 = default(TaskAwaiter);
					int num10 = -1;
					num = -1;
					num2 = num10;
					goto IL_443;
				}
				default:
					taskAwaiter7 = @class.task_0.GetAwaiter();
					if (!taskAwaiter7.IsCompleted)
					{
						int num11 = 0;
						num = 0;
						num2 = num11;
						taskAwaiter6 = taskAwaiter7;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class51.Struct110>(ref taskAwaiter7, ref this);
						return;
					}
					break;
				}
				taskAwaiter7.GetResult();
				jobject = new JObject(new JProperty("shippingAddress", new JObject()));
				jobject["shippingAddress"]["country"] = new JObject();
				jobject["shippingAddress"]["country"]["isocode"] = Class43.smethod_0(@class.jtoken_1["delivery"]["country"].ToString(), false);
				jobject["shippingAddress"]["country"]["name"] = @class.jtoken_1["delivery"]["country"];
				jobject["shippingAddress"]["region"] = new JObject();
				jobject["shippingAddress"]["region"]["isocode"] = Class43.smethod_0(@class.jtoken_1["delivery"]["country"].ToString(), false) + "-" + Class43.smethod_1(@class.jtoken_1["delivery"]["country"].ToString(), @class.jtoken_1["delivery"]["state"].ToString());
				jobject["shippingAddress"]["type"] = "Home/Business Address";
				jobject["shippingAddress"]["setAsBilling"] = true;
				jobject["shippingAddress"]["firstName"] = @class.jtoken_1["delivery"]["first_name"];
				jobject["shippingAddress"]["lastName"] = @class.jtoken_1["delivery"]["last_name"];
				jobject["shippingAddress"]["line1"] = @class.jtoken_1["delivery"]["addr1"];
				jobject["shippingAddress"]["line2"] = @class.jtoken_1["delivery"]["addr2"];
				jobject["shippingAddress"]["postalCode"] = @class.jtoken_1["delivery"]["zip"];
				jobject["shippingAddress"]["phone"] = @class.jtoken_1["payment"]["phone"];
				jobject["shippingAddress"]["email"] = @class.jtoken_1["payment"]["email"];
				jobject["shippingAddress"]["town"] = @class.jtoken_1["delivery"]["city"];
				jobject["shippingAddress"]["isFPO"] = false;
				jobject["shippingAddress"]["shippingAddress"] = true;
				goto IL_57C;
				IL_443:
				taskAwaiter7.GetResult();
				IL_57C:
				if (!@class.bool_1)
				{
					int num8 = 0;
					goto IL_5BA;
				}
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_5FB:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000703 RID: 1795 RVA: 0x0000607B File Offset: 0x0000427B
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400056C RID: 1388
		public int int_0;

		// Token: 0x0400056D RID: 1389
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x0400056E RID: 1390
		public Class51 class51_0;

		// Token: 0x0400056F RID: 1391
		private JObject jobject_0;

		// Token: 0x04000570 RID: 1392
		private TaskAwaiter taskAwaiter_0;

		// Token: 0x04000571 RID: 1393
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_1;

		// Token: 0x04000572 RID: 1394
		private TaskAwaiter<JObject> taskAwaiter_2;
	}

	// Token: 0x02000135 RID: 309
	[StructLayout(LayoutKind.Auto)]
	private struct Struct111 : IAsyncStateMachine
	{
		// Token: 0x06000704 RID: 1796 RVA: 0x0003B710 File Offset: 0x00039910
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class51 @class = this;
			try
			{
				TaskAwaiter taskAwaiter3;
				if (num == 0)
				{
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					num2 = -1;
					goto IL_88;
				}
				IL_53:
				while (!@class.bool_1)
				{
					int num3 = 0;
					try
					{
						@class.method_5("Getting cookies", "#c2c2c2", true, false);
						break;
					}
					catch
					{
						num3 = 1;
					}
					if (num3 == 1)
					{
						@class.method_5("Error getting cookies", "#c2c2c2", true, false);
						taskAwaiter3 = Task.Delay(Class130.int_0).GetAwaiter();
						if (taskAwaiter3.IsCompleted)
						{
							goto IL_88;
						}
						num2 = 0;
						taskAwaiter2 = taskAwaiter3;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class51.Struct111>(ref taskAwaiter3, ref this);
						return;
					}
				}
				goto IL_CC;
				IL_88:
				taskAwaiter3.GetResult();
				goto IL_53;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_CC:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000705 RID: 1797 RVA: 0x00006089 File Offset: 0x00004289
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000573 RID: 1395
		public int int_0;

		// Token: 0x04000574 RID: 1396
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000575 RID: 1397
		public Class51 class51_0;

		// Token: 0x04000576 RID: 1398
		private TaskAwaiter taskAwaiter_0;
	}

	// Token: 0x02000136 RID: 310
	[StructLayout(LayoutKind.Auto)]
	private struct Struct112 : IAsyncStateMachine
	{
		// Token: 0x06000706 RID: 1798 RVA: 0x0003B818 File Offset: 0x00039A18
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class51 @class = this;
			try
			{
				TaskAwaiter taskAwaiter3;
				int num7;
				switch (num)
				{
				case 0:
				{
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					int num3 = -1;
					num = -1;
					num2 = num3;
					break;
				}
				case 1:
				{
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					int num4 = -1;
					num = -1;
					num2 = num4;
					goto IL_D3;
				}
				case 2:
				{
					IL_203:
					try
					{
						TaskAwaiter<HttpResponseMessage> taskAwaiter4;
						if (num != 2)
						{
							@class.method_5("Submitting payment", "#c2c2c2", true, false);
							taskAwaiter4 = @class.class14_0.method_4(string.Format("https://www.{0}/api/users/carts/current/payment-detail", @class.string_10), jobject, false).GetAwaiter();
							if (!taskAwaiter4.IsCompleted)
							{
								int num5 = 2;
								num = 2;
								num2 = num5;
								TaskAwaiter<HttpResponseMessage> taskAwaiter5 = taskAwaiter4;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class51.Struct112>(ref taskAwaiter4, ref this);
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
						goto IL_327;
					}
					catch
					{
						num7 = 1;
					}
					if (num7 != 1)
					{
						goto IL_2AA;
					}
					@class.method_5("Error submitting payment", "#c2c2c2", true, false);
					taskAwaiter3 = @class.method_14(Class130.int_1).GetAwaiter();
					if (taskAwaiter3.IsCompleted)
					{
						goto IL_2E3;
					}
					int num8 = 3;
					num = 3;
					num2 = num8;
					taskAwaiter2 = taskAwaiter3;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class51.Struct112>(ref taskAwaiter3, ref this);
					return;
				}
				case 3:
				{
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					int num9 = -1;
					num = -1;
					num2 = num9;
					goto IL_2E3;
				}
				default:
					taskAwaiter3 = @class.task_3.GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						int num10 = 0;
						num = 0;
						num2 = num10;
						taskAwaiter2 = taskAwaiter3;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class51.Struct112>(ref taskAwaiter3, ref this);
						return;
					}
					break;
				}
				taskAwaiter3.GetResult();
				taskAwaiter3 = @class.task_4.GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					int num11 = 1;
					num = 1;
					num2 = num11;
					taskAwaiter2 = taskAwaiter3;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class51.Struct112>(ref taskAwaiter3, ref this);
					return;
				}
				IL_D3:
				taskAwaiter3.GetResult();
				jobject = new JObject();
				jobject["cardType"] = new JObject();
				jobject["cardType"]["code"] = "master";
				jobject["billingAddress"] = new JObject();
				jobject["billingAddress"]["id"] = @class.string_12;
				jobject["flApiCCNumber"] = @class.string_11;
				jobject["expiryMonth"] = @class.jtoken_1["payment"]["card"]["exp_month"];
				jobject["expiryYear"] = @class.jtoken_1["payment"]["card"]["exp_year"];
				IL_2AA:
				if (@class.bool_1)
				{
					goto IL_327;
				}
				num7 = 0;
				goto IL_203;
				IL_2E3:
				taskAwaiter3.GetResult();
				goto IL_2AA;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_327:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000707 RID: 1799 RVA: 0x00006097 File Offset: 0x00004297
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000577 RID: 1399
		public int int_0;

		// Token: 0x04000578 RID: 1400
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000579 RID: 1401
		public Class51 class51_0;

		// Token: 0x0400057A RID: 1402
		private JObject jobject_0;

		// Token: 0x0400057B RID: 1403
		private TaskAwaiter taskAwaiter_0;

		// Token: 0x0400057C RID: 1404
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_1;
	}

	// Token: 0x02000137 RID: 311
	[StructLayout(LayoutKind.Auto)]
	private struct Struct113 : IAsyncStateMachine
	{
		// Token: 0x06000708 RID: 1800 RVA: 0x0003BB94 File Offset: 0x00039D94
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class51 @class = this;
			try
			{
				if (num <= 1)
				{
					goto IL_20D;
				}
				if (num != 2)
				{
					goto IL_203;
				}
				TaskAwaiter taskAwaiter7 = taskAwaiter6;
				taskAwaiter6 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_1FC:
				taskAwaiter7.GetResult();
				IL_203:
				if (@class.bool_1)
				{
					goto IL_24F;
				}
				int num4 = 0;
				IL_20D:
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
							goto IL_185;
						}
						@class.method_5("Getting session", "#c2c2c2", true, false);
						taskAwaiter9 = @class.class14_0.method_2(string.Format("https://www.{0}/api/session", @class.string_10), false).GetAwaiter();
						if (!taskAwaiter9.IsCompleted)
						{
							int num6 = 0;
							num = 0;
							num2 = num6;
							taskAwaiter2 = taskAwaiter9;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class51.Struct113>(ref taskAwaiter9, ref this);
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
					if (result.StatusCode == HttpStatusCode.Found && result.Headers.Location.Host == "www.footlocker.eu")
					{
						@class.method_0("US proxy required", "red", true, (GEnum1)0);
					}
					result.EnsureSuccessStatusCode();
					httpRequestHeaders = @class.class14_0.httpClient_0.DefaultRequestHeaders;
					taskAwaiter8 = result.smethod_1().GetAwaiter();
					if (!taskAwaiter8.IsCompleted)
					{
						int num8 = 1;
						num = 1;
						num2 = num8;
						taskAwaiter4 = taskAwaiter8;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class51.Struct113>(ref taskAwaiter8, ref this);
						return;
					}
					IL_185:
					JObject result2 = taskAwaiter8.GetResult();
					httpRequestHeaders.TryAddWithoutValidation("x-csrf-token", result2["data"]["csrfToken"].ToString());
					httpRequestHeaders = null;
					goto IL_24F;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_203;
				}
				@class.method_5("Error getting session", "#c2c2c2", true, false);
				taskAwaiter7 = @class.method_14(Class130.int_1).GetAwaiter();
				if (taskAwaiter7.IsCompleted)
				{
					goto IL_1FC;
				}
				int num9 = 2;
				num = 2;
				num2 = num9;
				taskAwaiter6 = taskAwaiter7;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class51.Struct113>(ref taskAwaiter7, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_24F:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000709 RID: 1801 RVA: 0x000060A5 File Offset: 0x000042A5
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400057D RID: 1405
		public int int_0;

		// Token: 0x0400057E RID: 1406
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x0400057F RID: 1407
		public Class51 class51_0;

		// Token: 0x04000580 RID: 1408
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000581 RID: 1409
		private HttpRequestHeaders httpRequestHeaders_0;

		// Token: 0x04000582 RID: 1410
		private TaskAwaiter<JObject> taskAwaiter_1;

		// Token: 0x04000583 RID: 1411
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x02000138 RID: 312
	[StructLayout(LayoutKind.Auto)]
	private struct Struct114 : IAsyncStateMachine
	{
		// Token: 0x0600070A RID: 1802 RVA: 0x0003BE38 File Offset: 0x0003A038
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class51 @class = this;
			try
			{
				if (num == 0)
				{
					goto IL_130;
				}
				if (num != 1)
				{
					goto IL_126;
				}
				TaskAwaiter taskAwaiter3 = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_11F:
				taskAwaiter3.GetResult();
				IL_126:
				if (@class.bool_1)
				{
					goto IL_172;
				}
				int num4 = 0;
				IL_130:
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter4;
					if (num != 0)
					{
						@class.method_5("Setting email", "#c2c2c2", true, false);
						taskAwaiter4 = @class.class14_0.method_8(string.Format("https://www.footaction.com/api/users/carts/current/email/{0}/", @class.jtoken_1["payment"]["email"]), new JObject(), false).GetAwaiter();
						if (!taskAwaiter4.IsCompleted)
						{
							int num5 = 0;
							num = 0;
							num2 = num5;
							TaskAwaiter<HttpResponseMessage> taskAwaiter5 = taskAwaiter4;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class51.Struct114>(ref taskAwaiter4, ref this);
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
					goto IL_172;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_126;
				}
				@class.method_5("Error setting email", "#c2c2c2", true, false);
				taskAwaiter3 = @class.method_14(Class130.int_1).GetAwaiter();
				if (taskAwaiter3.IsCompleted)
				{
					goto IL_11F;
				}
				int num7 = 1;
				num = 1;
				num2 = num7;
				taskAwaiter2 = taskAwaiter3;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class51.Struct114>(ref taskAwaiter3, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_172:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x0600070B RID: 1803 RVA: 0x000060B3 File Offset: 0x000042B3
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000584 RID: 1412
		public int int_0;

		// Token: 0x04000585 RID: 1413
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000586 RID: 1414
		public Class51 class51_0;

		// Token: 0x04000587 RID: 1415
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000588 RID: 1416
		private TaskAwaiter taskAwaiter_1;
	}
}
