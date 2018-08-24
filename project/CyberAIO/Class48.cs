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

// Token: 0x020000D1 RID: 209
internal sealed class Class48 : Class44
{
	// Token: 0x06000507 RID: 1287 RVA: 0x00029A9C File Offset: 0x00027C9C
	public Class48(JToken jtoken_2)
	{
		try
		{
			this.jtoken_0 = jtoken_2;
			if (!base.method_2(out this.jtoken_1))
			{
				base.method_0("Profile error", "red", true, (GEnum1)0);
			}
			else
			{
				this.string_9 = jtoken_2["keywords"].ToString().Split(new char[]
				{
					'#'
				}).First<string>();
				this.string_0 = ((string)jtoken_2["size"]).Replace("UK ", string.Empty);
				if (this.string_0 == "Random" || this.string_0 == "OneSize")
				{
					this.bool_0 = true;
				}
				this.bool_3 = (jtoken_2["bank_transfer"] != null && (bool)jtoken_2["bank_transfer"]);
				JObject jobject = new JObject();
				jobject["Accept-Language"] = "en-GB,en;q=0.9,en-US;q=0.8,fr;q=0.7";
				jobject["Accept"] = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
				JObject jobject_ = jobject;
				this.class14_0 = new Class14(base.method_3(), "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36", 60, false, false, jobject_);
				if (Class48.string_7 != null)
				{
					this.class14_0.cookieContainer_0.Add(new Cookie
					{
						Name = "cf_clearance",
						Value = Class48.string_7,
						Domain = ".off---white.com",
						Path = "/"
					});
				}
			}
		}
		catch
		{
			base.method_0("Task error", "red", true, (GEnum1)0);
		}
	}

	// Token: 0x06000508 RID: 1288 RVA: 0x00029C58 File Offset: 0x00027E58
	public override async void vmethod_0()
	{
		try
		{
			await base.method_11();
			await this.method_17();
			await this.method_18();
			await this.method_20();
			await this.method_21();
			Task task = this.method_23();
			if (this.bool_3)
			{
				TaskAwaiter taskAwaiter = task.GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter.GetResult();
				await this.method_30();
			}
			else
			{
				TaskAwaiter taskAwaiter = this.method_25().GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter.GetResult();
				await this.method_26();
				await this.method_27();
				await task;
				await this.method_28();
			}
			task = null;
		}
		catch
		{
		}
		base.method_0("Stopped", "red", true, (GEnum1)0);
	}

	// Token: 0x06000509 RID: 1289 RVA: 0x00005062 File Offset: 0x00003262
	public string method_15(string string_19)
	{
		HtmlDocument htmlDocument = new HtmlDocument();
		htmlDocument.LoadHtml(this.string_17);
		return htmlDocument.DocumentNode.SelectSingleNode(string.Format("//option[text() = '{0}']", string_19)).Attributes["value"].Value;
	}

	// Token: 0x0600050A RID: 1290 RVA: 0x00029C94 File Offset: 0x00027E94
	public async Task method_16()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Getting cookies", "#c2c2c2", true, false);
				(await this.class14_0.method_2("https://www.off---white.com/en/GB", false)).EnsureSuccessStatusCode();
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

	// Token: 0x0600050B RID: 1291 RVA: 0x00029CDC File Offset: 0x00027EDC
	public async Task method_17()
	{
		base.method_5("Waiting for product", "#c2c2c2", true, false);
		while (!this.bool_1)
		{
			int num = 0;
			TaskAwaiter taskAwaiter2;
			try
			{
				HttpResponseMessage httpResponseMessage = await this.class14_0.method_2(this.string_9 + ".json", false);
				if (httpResponseMessage.StatusCode == HttpStatusCode.Forbidden)
				{
					base.method_0("Proxy banned", "red", true, (GEnum1)0);
				}
				httpResponseMessage.EnsureSuccessStatusCode();
				JObject jobject = await httpResponseMessage.smethod_1();
				if (this.bool_0)
				{
					JToken jtoken = jobject["available_sizes"];
					if (!jtoken.Any<JToken>())
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
					JToken jtoken2 = jtoken.smethod_5();
					this.string_8 = jtoken2["id"].ToString();
					base.method_6(jtoken2["name"].ToString());
				}
				else
				{
					JToken jtoken3 = jobject["available_sizes"].FirstOrDefault(new Func<JToken, bool>(this.method_31));
					if (jtoken3 == null)
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
					this.string_8 = jtoken3["id"].ToString();
				}
				base.method_5("Found variant ID: " + this.string_8, "#c2c2c2", true, false);
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

	// Token: 0x0600050C RID: 1292 RVA: 0x00029D24 File Offset: 0x00027F24
	public async Task method_18()
	{
		this.class14_0.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("Referer", "https://www.off---white.com/en/GB/cart");
		while (!this.bool_1)
		{
			int num = 0;
			TaskAwaiter taskAwaiter4;
			try
			{
				base.method_5("Adding to cart", "yellow", true, false);
				JObject jobject = new JObject();
				jobject["variant_id"] = this.string_8;
				jobject["quantity"] = "1";
				HttpResponseMessage httpResponseMessage = await this.class14_0.method_4("https://www.off---white.com/en/GB/orders/populate.json", jobject, false);
				TaskAwaiter<string> taskAwaiter = httpResponseMessage.smethod_3().GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter<string> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<string>);
				}
				if (taskAwaiter.GetResult().Contains("not available"))
				{
					base.method_5("Waiting for restock", "#c2c2c2", true, false);
					TaskAwaiter taskAwaiter3 = base.method_14(Class130.int_0).GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						await taskAwaiter3;
						taskAwaiter3 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter);
					}
					taskAwaiter3.GetResult();
					await this.method_17();
					continue;
				}
				httpResponseMessage.EnsureSuccessStatusCode();
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
				TaskAwaiter taskAwaiter3 = base.method_14(Class130.int_0).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter);
				}
				taskAwaiter3.GetResult();
			}
		}
	}

	// Token: 0x0600050D RID: 1293 RVA: 0x00029D6C File Offset: 0x00027F6C
	public async Task method_19()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Logging in", "#c2c2c2", true, false);
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary["_method"] = "put";
				dictionary["order[email]"] = (string)this.jtoken_1["payment"]["email"];
				dictionary["commit"] = "continue";
				(await this.class14_0.method_3("https://www.off---white.com/en/GB/checkout/registration", dictionary, false)).smethod_0();
				base.method_5("Successfully logged in", "#c2c2c2", true, false);
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error logging in", "#c2c2c2", true, false);
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

	// Token: 0x0600050E RID: 1294 RVA: 0x00029DB4 File Offset: 0x00027FB4
	public async Task method_20()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Logging in", "#c2c2c2", true, false);
				JObject jobject = new JObject();
				string propertyName = "order";
				JObject jobject2 = new JObject();
				jobject2["email"] = this.jtoken_1["payment"]["email"];
				jobject[propertyName] = jobject2;
				TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class14_0.method_5("https://www.off---white.com/en/GB/orders/populate.json", jobject, false).GetAwaiter();
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
				if (!(bool)taskAwaiter3.GetResult()["ok"])
				{
					throw new Exception();
				}
				base.method_5("Successfully logged in", "#c2c2c2", true, false);
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

	// Token: 0x0600050F RID: 1295 RVA: 0x00029DFC File Offset: 0x00027FFC
	public async Task method_21()
	{
		this.class14_0.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("Referer", "https://www.off---white.com/en/GB/checkout");
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Submitting shipping", "#c2c2c2", true, false);
				JObject jobject = new JObject();
				jobject["order"] = new JObject();
				jobject["order"]["bill_address_attributes"] = new JObject();
				jobject["order"]["ship_address_attributes"] = new JObject();
				jobject["order"]["email"] = this.jtoken_1["payment"]["email"];
				jobject["order"]["state_lock_version"] = "0";
				jobject["order"]["bill_address_attributes"]["firstname"] = this.jtoken_1["billing"]["first_name"];
				jobject["order"]["bill_address_attributes"]["lastname"] = this.jtoken_1["billing"]["last_name"];
				jobject["order"]["bill_address_attributes"]["address1"] = this.jtoken_1["billing"]["addr1"];
				jobject["order"]["bill_address_attributes"]["address2"] = this.jtoken_1["billing"]["addr2"];
				jobject["order"]["bill_address_attributes"]["city"] = this.jtoken_1["billing"]["city"];
				jobject["order"]["bill_address_attributes"]["country_id"] = this.method_15((string)this.jtoken_1["billing"]["country"]);
				jobject["order"]["bill_address_attributes"]["zipcode"] = this.jtoken_1["billing"]["zip"];
				jobject["order"]["bill_address_attributes"]["phone"] = this.jtoken_1["payment"]["phone"];
				jobject["order"]["bill_address_attributes"]["state_name"] = Class43.smethod_1((string)this.jtoken_1["billing"]["country"], (string)this.jtoken_1["billing"]["state"]);
				jobject["order"]["ship_address_attributes"]["firstname"] = this.jtoken_1["delivery"]["first_name"];
				jobject["order"]["ship_address_attributes"]["lastname"] = this.jtoken_1["delivery"]["last_name"];
				jobject["order"]["ship_address_attributes"]["address1"] = this.jtoken_1["delivery"]["addr1"];
				jobject["order"]["ship_address_attributes"]["address2"] = this.jtoken_1["delivery"]["addr2"];
				jobject["order"]["ship_address_attributes"]["city"] = this.jtoken_1["delivery"]["city"];
				jobject["order"]["ship_address_attributes"]["country_id"] = this.method_15((string)this.jtoken_1["delivery"]["country"]);
				jobject["order"]["ship_address_attributes"]["state_name"] = Class43.smethod_1((string)this.jtoken_1["delivery"]["country"], (string)this.jtoken_1["delivery"]["state"]);
				jobject["order"]["ship_address_attributes"]["zipcode"] = this.jtoken_1["delivery"]["zip"];
				jobject["order"]["ship_address_attributes"]["phone"] = this.jtoken_1["payment"]["phone"];
				jobject["order"]["ship_address_attributes"]["shipping"] = "true";
				jobject["order"]["terms_and_conditions"] = "yes";
				TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class14_0.method_5("https://www.off---white.com/en/GB/checkout/update/address", jobject, true).GetAwaiter();
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
				if (result2.Contains("order_ship_address_attributes_state"))
				{
					base.method_0("Invalid shipping", "red", true, (GEnum1)0);
				}
				HtmlDocument htmlDocument = new HtmlDocument();
				htmlDocument.LoadHtml(result2);
				this.string_10 = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='order[shipments_attributes][0][selected_shipping_rate_id]']").Attributes["value"].Value;
				this.string_11 = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='order[shipments_attributes][0][id]']").Attributes["value"].Value;
				this.string_16 = htmlDocument.DocumentNode.SelectSingleNode("//meta[@name='CART_PATH']").Attributes["content"].Value.Split(new char[]
				{
					'/'
				})[4];
				this.string_13 = result2.Replace(" ", string.Empty).Split(new string[]
				{
					"Spree.current_order_id=\""
				}, StringSplitOptions.None)[1].Split(new char[]
				{
					'"'
				})[0];
				this.string_12 = htmlDocument.DocumentNode.SelectNodes("//span[@class='amount']").Last<HtmlNode>().InnerText.Replace(" ", string.Empty).Replace("€", string.Empty);
				base.method_5("Detected region: " + this.string_16, "#c2c2c2", true, false);
				base.method_7(htmlDocument.DocumentNode.SelectSingleNode("//td[@class='description']//strong").InnerText, "#c2c2c2");
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

	// Token: 0x06000510 RID: 1296 RVA: 0x00029E44 File Offset: 0x00028044
	public async Task method_22()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Getting shipping method", "#c2c2c2", true, false);
				TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class14_0.method_2("https://www.off---white.com/en/GB/checkout/delivery", false).GetAwaiter();
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
				HtmlDocument htmlDocument = new HtmlDocument();
				htmlDocument.LoadHtml(result2);
				this.string_10 = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='order[shipments_attributes][0][selected_shipping_rate_id]']").Attributes["value"].Value;
				this.string_11 = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='order[shipments_attributes][0][id]']").Attributes["value"].Value;
				this.string_13 = result2.Replace(" ", string.Empty).Split(new string[]
				{
					"Spree.current_order_id=\""
				}, StringSplitOptions.None)[1].Split(new char[]
				{
					'"'
				})[0];
				base.method_5("Detected region: " + this.string_16, "#c2c2c2", true, false);
				base.method_7(htmlDocument.DocumentNode.SelectSingleNode("//td[@class='description']//strong").InnerText, "#c2c2c2");
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

	// Token: 0x06000511 RID: 1297 RVA: 0x00029E8C File Offset: 0x0002808C
	public async Task method_23()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Submitting shipping method", "#c2c2c2", true, false);
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary["_method"] = "patch";
				dictionary["order[state_lock_version]"] = "1";
				dictionary["order[shipments_attributes][0][selected_shipping_rate_id]"] = this.string_10;
				dictionary["order[shipments_attributes][0][id]"] = this.string_11;
				(await this.class14_0.method_3(string.Format("https://www.off---white.com/en/{0}/checkout/update/delivery", this.string_16), dictionary, false)).smethod_0();
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error submitting shipping method", "#c2c2c2", true, false);
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

	// Token: 0x06000512 RID: 1298 RVA: 0x00029ED4 File Offset: 0x000280D4
	public async Task method_24()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Submitting shipping method", "#c2c2c2", true, false);
				JObject jobject = new JObject();
				string propertyName = "order";
				JObject jobject2 = new JObject();
				jobject2["state_lock_version"] = "1";
				string propertyName2 = "shipments_attributes";
				JArray jarray = new JArray();
				JObject jobject3 = new JObject();
				jobject3["selected_shipping_rate_id"] = this.string_10;
				jobject3["id"] = this.string_11;
				jarray.Add(jobject3);
				jobject2[propertyName2] = jarray;
				jobject[propertyName] = jobject2;
				(await this.class14_0.method_5("https://www.off---white.com/en/GB/orders/populate.json", jobject, false)).EnsureSuccessStatusCode();
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error submitting shipping method", "#c2c2c2", true, false);
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

	// Token: 0x06000513 RID: 1299 RVA: 0x00029F1C File Offset: 0x0002811C
	public async Task method_25()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Getting payment token", "#c2c2c2", true, false);
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary["transaction"] = this.string_13;
				dictionary["amount"] = (this.string_12.Contains(".") ? this.string_12.Replace(",", string.Empty) : (this.string_12.Replace(",", string.Empty) + ".0"));
				TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class14_0.method_3(string.Format("https://www.off---white.com/en/{0}/checkout/payment/get_token.json", this.string_16), dictionary, false).GetAwaiter();
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
				this.string_14 = taskAwaiter3.GetResult()["token"].ToString();
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
				base.method_5("Error getting payment token", "#c2c2c2", true, false);
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

	// Token: 0x06000514 RID: 1300 RVA: 0x00029F64 File Offset: 0x00028164
	public async Task method_26()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Getting payment info", "#c2c2c2", true, false);
				TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class14_0.method_2(string.Format("https://ecomm.sella.it/Pagam/hiddenIframe.aspx?a=9091712&b={0}&MerchantUrl=https://www.off---white.com/en/GB/checkout/payment", this.string_14), false).GetAwaiter();
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
				foreach (HtmlNode htmlNode in ((IEnumerable<HtmlNode>)htmlDocument.DocumentNode.SelectNodes("//form//input[@value][@name]")))
				{
					this.dictionary_0[htmlNode.Attributes["name"].Value] = htmlNode.Attributes["value"].Value;
				}
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
				base.method_5("Error getting payment info", "#c2c2c2", true, false);
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

	// Token: 0x06000515 RID: 1301 RVA: 0x00029FAC File Offset: 0x000281AC
	public async Task method_27()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Submitting payment", "orange", true, false);
				this.dictionary_0["cardnumber"] = this.jtoken_1["payment"]["card"]["number"].ToString().Replace(" ", string.Empty);
				this.dictionary_0["cardExpiryMonth"] = (string)this.jtoken_1["payment"]["card"]["exp_month"];
				this.dictionary_0["cardExpiryYear"] = this.jtoken_1["payment"]["card"]["exp_year"].ToString().Substring(2);
				this.dictionary_0["cvv"] = (string)this.jtoken_1["payment"]["card"]["cvv"];
				this.dictionary_0["inputString"] = this.string_14;
				TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class14_0.method_3(string.Format("https://ecomm.sella.it/Pagam/hiddenIframe.aspx?a=9091712&b={0}&MerchantUrl=https://www.off---white.com/en/GB/checkout/payment", this.string_14), this.dictionary_0, false).GetAwaiter();
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
				string text = result2.Split(new string[]
				{
					"//<![CDATA["
				}, StringSplitOptions.None)[1].ToLower();
				if (text.Contains("invalid") || text.Contains("wrong") || text.Contains("expired"))
				{
					base.method_0("Invalid card info", "red", true, (GEnum1)0);
				}
				this.string_15 = result2.Split(new string[]
				{
					"delayedSendResult('0','','','','"
				}, StringSplitOptions.None)[1].Split(new string[]
				{
					"')//]"
				}, StringSplitOptions.None)[0];
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
				base.method_5("Error submitting payment", "#c2c2c2", true, false);
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

	// Token: 0x06000516 RID: 1302 RVA: 0x00029FF4 File Offset: 0x000281F4
	public async Task method_28()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Processing payment", "orange", true, false);
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary["token"] = this.string_15;
				HttpResponseMessage httpResponseMessage = await this.class14_0.method_3("https://www.off---white.com/checkout/payment/process_token.json", dictionary, false);
				HttpResponseMessage httpResponseMessage_ = httpResponseMessage;
				string text = await httpResponseMessage_.smethod_3();
				JObject jobject = await httpResponseMessage_.smethod_1();
				if (jobject.ContainsKey("error"))
				{
					if (jobject["error"].ToString().Contains("Autorizzazione negata"))
					{
						base.method_0("Payment Declined", "red", true, (GEnum1)5);
					}
					else
					{
						base.method_0("Payment error", "red", true, (GEnum1)0);
						GClass3.smethod_0(text, "error");
					}
				}
				else if (text.Contains("gestpay_completion"))
				{
					base.method_0("Successfully checked out", "green", true, (GEnum1)6);
				}
				else
				{
					base.method_0("Payment error", "red", true, (GEnum1)0);
					GClass3.smethod_0(text, "error");
				}
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
				base.method_5("Error processing payment", "#c2c2c2", true, false);
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

	// Token: 0x06000517 RID: 1303 RVA: 0x0002A03C File Offset: 0x0002823C
	public async Task method_29()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Submitting order", "orange", true, false);
				TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class14_0.method_2(string.Format("https://www.off---white.com/{0}", this.string_18), false).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter<HttpResponseMessage> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
				}
				HttpResponseMessage result = taskAwaiter.GetResult();
				if (result.StatusCode != HttpStatusCode.Found)
				{
					throw new Exception();
				}
				TaskAwaiter<string> taskAwaiter3 = result.smethod_3().GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<string> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<string>);
				}
				if (taskAwaiter3.GetResult().Contains("orders"))
				{
					base.method_0("Successfully checked out", "green", true, (GEnum1)6);
				}
				else
				{
					base.method_0("Payment error", "red", true, (GEnum1)0);
				}
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
				base.method_5("Error submitting order", "#c2c2c2", true, false);
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

	// Token: 0x06000518 RID: 1304 RVA: 0x0002A084 File Offset: 0x00028284
	public async Task method_30()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Submitting order", "orange", true, false);
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary["utf8"] = "✓";
				dictionary["_method"] = "patch";
				dictionary["authenticity_token"] = string.Empty;
				dictionary["order[payments_attributes][][payment_method_id]"] = "10";
				TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class14_0.method_3(string.Format("https://www.off---white.com/en/{0}/checkout/update/payment", this.string_16), dictionary, false).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter<HttpResponseMessage> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
				}
				HttpResponseMessage result = taskAwaiter.GetResult();
				if (result.StatusCode != HttpStatusCode.Found)
				{
					throw new Exception();
				}
				TaskAwaiter<string> taskAwaiter3 = result.smethod_3().GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<string> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<string>);
				}
				if (taskAwaiter3.GetResult().Contains("orders"))
				{
					base.method_0("Successfully checked out", "green", true, (GEnum1)6);
				}
				else
				{
					base.method_0("Payment error", "red", true, (GEnum1)0);
				}
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
				base.method_5("Error submitting order", "#c2c2c2", true, false);
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

	// Token: 0x06000519 RID: 1305 RVA: 0x00003225 File Offset: 0x00001425
	private bool method_31(JToken jtoken_2)
	{
		return Class43.smethod_2(this.string_0, jtoken_2["name"].ToString());
	}

	// Token: 0x0400036A RID: 874
	public static string string_7;

	// Token: 0x0400036B RID: 875
	private string string_8;

	// Token: 0x0400036C RID: 876
	private string string_9;

	// Token: 0x0400036D RID: 877
	private string string_10;

	// Token: 0x0400036E RID: 878
	private string string_11;

	// Token: 0x0400036F RID: 879
	private string string_12;

	// Token: 0x04000370 RID: 880
	private string string_13;

	// Token: 0x04000371 RID: 881
	private string string_14;

	// Token: 0x04000372 RID: 882
	private string string_15;

	// Token: 0x04000373 RID: 883
	private Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();

	// Token: 0x04000374 RID: 884
	private string string_16;

	// Token: 0x04000375 RID: 885
	private bool bool_3;

	// Token: 0x04000376 RID: 886
	private string string_17 = "<option data-validate-fiscal-code='false' value='178'>Albania</option> <option data-validate-fiscal-code='false' value='179'>Algeria</option> <option data-validate-fiscal-code='false' value='181'>American Samoa</option> <option data-validate-fiscal-code='false' value='184'>Andorra</option> <option data-validate-fiscal-code='false' value='187'>Angola</option> <option data-validate-fiscal-code='false' value='191'>Anguilla</option> <option data-validate-fiscal-code='false' value='197'>Antigua and Barbuda</option> <option data-validate-fiscal-code='false' value='203'>Argentina</option> <option data-validate-fiscal-code='false' value='107'>Armenia</option> <option data-validate-fiscal-code='false' value='108'>Aruba</option> <option data-validate-fiscal-code='false' value='109'>Australia</option> <option data-validate-fiscal-code='false' value='111'>Austria</option> <option data-validate-fiscal-code='false' value='114'>Azerbaijan</option> <option data-validate-fiscal-code='false' value='118'>Bahamas</option> <option data-validate-fiscal-code='false' value='122'>Bahrain</option> <option data-validate-fiscal-code='false' value='126'>Bangladesh</option> <option data-validate-fiscal-code='false' value='132'>Barbados</option> <option data-validate-fiscal-code='false' value='142'>Belarus</option> <option data-validate-fiscal-code='false' value='29'>Belgium</option> <option data-validate-fiscal-code='false' value='30'>Belize</option> <option data-validate-fiscal-code='false' value='33'>Benin</option> <option data-validate-fiscal-code='false' value='36'>Bermuda</option> <option data-validate-fiscal-code='false' value='40'>Bhutan</option> <option data-validate-fiscal-code='false' value='45'>Bolivia, Plurinational State of</option> <option data-validate-fiscal-code='false' value='50'>Bosnia and Herzegovina</option> <option data-validate-fiscal-code='false' value='55'>Botswana</option> <option data-validate-fiscal-code='true' value='61'>Brazil</option> <option data-validate-fiscal-code='false' value='68'>Brunei Darussalam</option> <option data-validate-fiscal-code='false' value='182'>Bulgaria</option> <option data-validate-fiscal-code='false' value='185'>Burkina Faso</option> <option data-validate-fiscal-code='false' value='188'>Burundi</option> <option data-validate-fiscal-code='false' value='192'>Cambodia</option> <option data-validate-fiscal-code='false' value='198'>Cameroon</option> <option data-validate-fiscal-code='false' value='204'>Canada</option> <option data-validate-fiscal-code='false' value='209'>Cape Verde</option> <option data-validate-fiscal-code='false' value='215'>Cayman Islands</option> <option data-validate-fiscal-code='false' value='221'>Central African Republic</option> <option data-validate-fiscal-code='false' value='1'>Chad</option> <option data-validate-fiscal-code='false' value='115'>Chile</option> <option data-validate-fiscal-code='false' value='119'>China</option> <option data-validate-fiscal-code='false' value='123'>Colombia</option> <option data-validate-fiscal-code='false' value='127'>Comoros</option> <option data-validate-fiscal-code='false' value='133'>Congo</option> <option data-validate-fiscal-code='false' value='138'>Congo, The Democratic Republic of the</option> <option data-validate-fiscal-code='false' value='143'>Cook Islands</option> <option data-validate-fiscal-code='false' value='154'>Costa Rica</option> <option data-validate-fiscal-code='false' value='158'>Côte dIvoireIvoire</option> <option data-validate-fiscal-code='false' value='161'>Croatia</option> <option data-validate-fiscal-code='false' value='41'>Cuba</option> <option data-validate-fiscal-code='false' value='46'>Cyprus</option> <option data-validate-fiscal-code='false' value='51'>Czech Republic</option> <option data-validate-fiscal-code='false' value='56'>Denmark</option> <option data-validate-fiscal-code='false' value='62'>Djibouti</option> <option data-validate-fiscal-code='false' value='69'>Dominica</option> <option data-validate-fiscal-code='false' value='74'>Dominican Republic</option> <option data-validate-fiscal-code='false' value='79'>Ecuador</option> <option data-validate-fiscal-code='false' value='85'>Egypt</option> <option data-validate-fiscal-code='false' value='90'>El Salvador</option> <option data-validate-fiscal-code='false' value='193'>Equatorial Guinea</option> <option data-validate-fiscal-code='false' value='205'>Eritrea</option> <option data-validate-fiscal-code='false' value='210'>Estonia</option> <option data-validate-fiscal-code='false' value='216'>Ethiopia</option> <option data-validate-fiscal-code='false' value='222'>Falkland Islands (Malvinas)</option> <option data-validate-fiscal-code='false' value='2'>Faroe Islands</option> <option data-validate-fiscal-code='false' value='6'>Fiji</option> <option data-validate-fiscal-code='false' value='10'>Finland</option> <option data-validate-fiscal-code='false' value='13'>France</option> <option data-validate-fiscal-code='false' value='17'>French Guiana</option> <option data-validate-fiscal-code='false' value='128'>French Polynesia</option> <option data-validate-fiscal-code='false' value='134'>Gabon</option> <option data-validate-fiscal-code='false' value='144'>Gambia</option> <option data-validate-fiscal-code='false' value='149'>Georgia</option> <option data-validate-fiscal-code='false' value='155'>Germany</option> <option data-validate-fiscal-code='false' value='162'>Ghana</option> <option data-validate-fiscal-code='false' value='165'>Gibraltar</option> <option data-validate-fiscal-code='false' value='168'>Greece</option> <option data-validate-fiscal-code='false' value='171'>Greenland</option> <option data-validate-fiscal-code='false' value='173'>Grenada</option> <option data-validate-fiscal-code='false' value='57'>Guadeloupe</option> <option data-validate-fiscal-code='false' value='63'>Guam</option> <option data-validate-fiscal-code='false' value='70'>Guatemala</option> <option data-validate-fiscal-code='false' value='80'>Guinea</option> <option data-validate-fiscal-code='false' value='86'>Guinea-Bissau</option> <option data-validate-fiscal-code='false' value='91'>Guyana</option> <option data-validate-fiscal-code='false' value='93'>Haiti</option> <option data-validate-fiscal-code='false' value='96'>Holy See (Vatican City State)</option> <option data-validate-fiscal-code='false' value='99'>Honduras</option> <option data-validate-fiscal-code='false' value='102'>Hong Kong</option> <option data-validate-fiscal-code='false' value='217'>Hungary</option> <option data-validate-fiscal-code='false' value='223'>Iceland</option> <option data-validate-fiscal-code='false' value='3'>India</option> <option data-validate-fiscal-code='false' value='7'>Indonesia</option> <option data-validate-fiscal-code='false' value='14'>Iran, Islamic Republic of</option> <option data-validate-fiscal-code='false' value='18'>Iraq</option> <option data-validate-fiscal-code='false' value='20'>Ireland</option> <option data-validate-fiscal-code='false' value='22'>Israel</option> <option data-validate-fiscal-code='true' value='24'>Italy</option> <option data-validate-fiscal-code='false' value='26'>Jamaica</option> <option data-validate-fiscal-code='false' value='27'>Japan</option> <option data-validate-fiscal-code='false' value='28'>Jordan</option> <option data-validate-fiscal-code='false' value='31'>Kazakhstan</option> <option data-validate-fiscal-code='false' value='34'>Kenya</option> <option data-validate-fiscal-code='false' value='37'>Kiribati</option> <option data-validate-fiscal-code='false' value='42'>Korea, Democratic Peoples Republic ofs Republic of</option> <option data-validate-fiscal-code='false' value='47'>Korea, Republic of</option> <option data-validate-fiscal-code='false' value='52'>Kuwait</option> <option data-validate-fiscal-code='false' value='58'>Kyrgyzstan</option> <option data-validate-fiscal-code='false' value='64'>Lao Peoples Democratic Republics Democratic Republic</option> <option data-validate-fiscal-code='false' value='180'>Latvia</option> <option data-validate-fiscal-code='false' value='183'>Lebanon</option> <option data-validate-fiscal-code='false' value='186'>Lesotho</option> <option data-validate-fiscal-code='false' value='189'>Liberia</option> <option data-validate-fiscal-code='false' value='194'>Libya</option> <option data-validate-fiscal-code='false' value='199'>Liechtenstein</option> <option data-validate-fiscal-code='false' value='206'>Lithuania</option> <option data-validate-fiscal-code='false' value='211'>Luxembourg</option> <option data-validate-fiscal-code='false' value='218'>Macao</option> <option data-validate-fiscal-code='false' value='224'>Macedonia, Republic of</option> <option data-validate-fiscal-code='false' value='112'>Madagascar</option> <option data-validate-fiscal-code='false' value='116'>Malawi</option> <option data-validate-fiscal-code='false' value='120'>Malaysia</option> <option data-validate-fiscal-code='false' value='124'>Maldives</option> <option data-validate-fiscal-code='false' value='129'>Mali</option> <option data-validate-fiscal-code='false' value='135'>Malta</option> <option data-validate-fiscal-code='false' value='139'>Marshall Islands</option> <option data-validate-fiscal-code='false' value='145'>Martinique</option> <option data-validate-fiscal-code='false' value='150'>Mauritania</option> <option data-validate-fiscal-code='false' value='156'>Mauritius</option> <option data-validate-fiscal-code='false' value='38'>Mexico</option> <option data-validate-fiscal-code='false' value='43'>Micronesia, Federated States of</option> <option data-validate-fiscal-code='false' value='48'>Moldova, Republic of</option> <option data-validate-fiscal-code='false' value='53'>Monaco</option> <option data-validate-fiscal-code='false' value='59'>Mongolia</option> <option data-validate-fiscal-code='false' value='229'>Montenegro</option> <option data-validate-fiscal-code='false' value='65'>Montserrat</option> <option data-validate-fiscal-code='false' value='71'>Morocco</option> <option data-validate-fiscal-code='false' value='75'>Mozambique</option> <option data-validate-fiscal-code='false' value='81'>Myanmar</option> <option data-validate-fiscal-code='false' value='87'>Namibia</option> <option data-validate-fiscal-code='false' value='195'>Nauru</option> <option data-validate-fiscal-code='false' value='200'>Nepal</option> <option data-validate-fiscal-code='false' value='207'>Netherlands</option> <option data-validate-fiscal-code='false' value='212'>Netherlands Antilles</option> <option data-validate-fiscal-code='false' value='219'>New Caledonia</option> <option data-validate-fiscal-code='false' value='225'>New Zealand</option> <option data-validate-fiscal-code='false' value='4'>Nicaragua</option> <option data-validate-fiscal-code='false' value='8'>Niger</option> <option data-validate-fiscal-code='false' value='11'>Nigeria</option> <option data-validate-fiscal-code='false' value='15'>Niue</option> <option data-validate-fiscal-code='false' value='130'>Norfolk Island</option> <option data-validate-fiscal-code='false' value='136'>Northern Mariana Islands</option> <option data-validate-fiscal-code='false' value='140'>Norway</option> <option data-validate-fiscal-code='false' value='146'>Oman</option> <option data-validate-fiscal-code='false' value='151'>Pakistan</option> <option data-validate-fiscal-code='false' value='157'>Palau</option> <option data-validate-fiscal-code='false' value='159'>Panama</option> <option data-validate-fiscal-code='false' value='163'>Papua New Guinea</option> <option data-validate-fiscal-code='false' value='166'>Paraguay</option> <option data-validate-fiscal-code='false' value='169'>Peru</option> <option data-validate-fiscal-code='false' value='60'>Philippines</option> <option data-validate-fiscal-code='false' value='66'>Pitcairn</option> <option data-validate-fiscal-code='false' value='72'>Poland</option> <option data-validate-fiscal-code='false' value='76'>Portugal</option> <option data-validate-fiscal-code='false' value='82'>Puerto Rico</option> <option data-validate-fiscal-code='false' value='88'>Qatar</option> <option data-validate-fiscal-code='false' value='92'>Réunion</option> <option data-validate-fiscal-code='false' value='94'>Romania</option> <option data-validate-fiscal-code='false' value='97'>Russian Federation</option> <option data-validate-fiscal-code='false' value='100'>Rwanda</option> <option data-validate-fiscal-code='false' value='213'>Saint Helena, Ascension and Tristan da Cunha</option> <option data-validate-fiscal-code='false' value='226'>Saint Kitts and Nevis</option> <option data-validate-fiscal-code='false' value='5'>Saint Lucia</option> <option data-validate-fiscal-code='false' value='9'>Saint Pierre and Miquelon</option> <option data-validate-fiscal-code='false' value='12'>Saint Vincent and the Grenadines</option> <option data-validate-fiscal-code='false' value='16'>Samoa</option> <option data-validate-fiscal-code='false' value='19'>San Marino</option> <option data-validate-fiscal-code='false' value='21'>Sao Tome and Principe</option> <option data-validate-fiscal-code='false' value='23'>Saudi Arabia</option> <option data-validate-fiscal-code='false' value='25'>Senegal</option> <option data-validate-fiscal-code='false' value='227'>Serbia</option> <option data-validate-fiscal-code='false' value='147'>Seychelles</option> <option data-validate-fiscal-code='false' value='152'>Sierra Leone</option> <option data-validate-fiscal-code='false' value='160'>Singapore</option> <option data-validate-fiscal-code='false' value='164'>Slovakia</option> <option data-validate-fiscal-code='false' value='167'>Slovenia</option> <option data-validate-fiscal-code='false' value='170'>Solomon Islands</option> <option data-validate-fiscal-code='false' value='172'>Somalia</option> <option data-validate-fiscal-code='false' value='174'>South Africa</option> <option data-validate-fiscal-code='false' value='175'>Spain</option> <option data-validate-fiscal-code='false' value='176'>Sri Lanka</option> <option data-validate-fiscal-code='false' value='77'>Sudan</option> <option data-validate-fiscal-code='false' value='83'>Suriname</option> <option data-validate-fiscal-code='false' value='89'>Svalbard and Jan Mayen</option> <option data-validate-fiscal-code='false' value='95'>Swaziland</option> <option data-validate-fiscal-code='false' value='98'>Sweden</option> <option data-validate-fiscal-code='false' value='101'>Switzerland</option> <option data-validate-fiscal-code='false' value='103'>Syrian Arab Republic</option> <option data-validate-fiscal-code='false' value='104'>Taiwan</option> <option data-validate-fiscal-code='false' value='105'>Tajikistan</option> <option data-validate-fiscal-code='false' value='106'>Tanzania, United Republic of</option> <option data-validate-fiscal-code='false' value='110'>Thailand</option> <option data-validate-fiscal-code='false' value='113'>Togo</option> <option data-validate-fiscal-code='false' value='117'>Tokelau</option> <option data-validate-fiscal-code='false' value='121'>Tonga</option> <option data-validate-fiscal-code='false' value='125'>Trinidad and Tobago</option> <option data-validate-fiscal-code='false' value='131'>Tunisia</option> <option data-validate-fiscal-code='false' value='137'>Turkey</option> <option data-validate-fiscal-code='false' value='141'>Turkmenistan</option> <option data-validate-fiscal-code='false' value='148'>Turks and Caicos Islands</option> <option data-validate-fiscal-code='false' value='153'>Tuvalu</option> <option data-validate-fiscal-code='false' value='32'>Uganda</option> <option data-validate-fiscal-code='false' value='35'>Ukraine</option> <option data-validate-fiscal-code='false' value='39'>United Arab Emirates</option> <option data-validate-fiscal-code='false' value='44'>United Kingdom</option> <option data-validate-fiscal-code='false' selected='selected' value='49'>United States</option> <option data-validate-fiscal-code='false' value='54'>Uruguay</option> <option data-validate-fiscal-code='false' value='67'>Uzbekistan</option> <option data-validate-fiscal-code='false' value='73'>Vanuatu</option> <option data-validate-fiscal-code='false' value='78'>Venezuela, Bolivarian Republic of</option> <option data-validate-fiscal-code='false' value='84'>Viet Nam</option> <option data-validate-fiscal-code='false' value='190'>Virgin Islands, British</option> <option data-validate-fiscal-code='false' value='196'>Virgin Islands, U.S.</option> <option data-validate-fiscal-code='false' value='201'>Wallis and Futuna</option> <option data-validate-fiscal-code='false' value='202'>Western Sahara</option> <option data-validate-fiscal-code='false' value='208'>Yemen</option> <option data-validate-fiscal-code='false' value='214'>Zambia</option> <option data-validate-fiscal-code='false' value='220'>Zimbabwe</option>";

	// Token: 0x04000377 RID: 887
	private string string_18;

	// Token: 0x020000D2 RID: 210
	[StructLayout(LayoutKind.Auto)]
	private struct Struct65 : IAsyncStateMachine
	{
		// Token: 0x0600051A RID: 1306 RVA: 0x0002A0CC File Offset: 0x000282CC
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class48 @class = this;
			try
			{
				TaskAwaiter taskAwaiter5;
				if (num > 3)
				{
					if (num != 4)
					{
						@class.class14_0.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("Referer", "https://www.off---white.com/en/GB/cart");
						goto IL_2D2;
					}
					taskAwaiter5 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter);
					int num3 = -1;
					num = -1;
					num2 = num3;
					goto IL_2C2;
				}
				IL_5C:
				int num12;
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter6;
					TaskAwaiter<string> taskAwaiter8;
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
						taskAwaiter2 = default(TaskAwaiter<string>);
						int num5 = -1;
						num = -1;
						num2 = num5;
						goto IL_188;
					}
					case 2:
					{
						taskAwaiter5 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter);
						int num6 = -1;
						num = -1;
						num2 = num6;
						goto IL_229;
					}
					case 3:
					{
						taskAwaiter5 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter);
						int num7 = -1;
						num = -1;
						num2 = num7;
						goto IL_284;
					}
					default:
					{
						@class.method_5("Adding to cart", "yellow", true, false);
						JObject jobject = new JObject();
						jobject["variant_id"] = @class.string_8;
						jobject["quantity"] = "1";
						JObject jobject_ = jobject;
						taskAwaiter6 = @class.class14_0.method_4("https://www.off---white.com/en/GB/orders/populate.json", jobject_, false).GetAwaiter();
						if (!taskAwaiter6.IsCompleted)
						{
							int num8 = 0;
							num = 0;
							num2 = num8;
							TaskAwaiter<HttpResponseMessage> taskAwaiter7 = taskAwaiter6;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class48.Struct65>(ref taskAwaiter6, ref this);
							return;
						}
						break;
					}
					}
					HttpResponseMessage result = taskAwaiter6.GetResult();
					httpResponseMessage = result;
					taskAwaiter8 = httpResponseMessage.smethod_3().GetAwaiter();
					if (!taskAwaiter8.IsCompleted)
					{
						int num9 = 1;
						num = 1;
						num2 = num9;
						taskAwaiter2 = taskAwaiter8;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class48.Struct65>(ref taskAwaiter8, ref this);
						return;
					}
					IL_188:
					if (!taskAwaiter8.GetResult().Contains("not available"))
					{
						httpResponseMessage.EnsureSuccessStatusCode();
						@class.method_5("Successfully carted", "#c2c2c2", true, false);
						goto IL_317;
					}
					@class.method_5("Waiting for restock", "#c2c2c2", true, false);
					taskAwaiter5 = @class.method_14(Class130.int_0).GetAwaiter();
					if (!taskAwaiter5.IsCompleted)
					{
						int num10 = 2;
						num = 2;
						num2 = num10;
						taskAwaiter4 = taskAwaiter5;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class48.Struct65>(ref taskAwaiter5, ref this);
						return;
					}
					IL_229:
					taskAwaiter5.GetResult();
					taskAwaiter5 = @class.method_17().GetAwaiter();
					if (!taskAwaiter5.IsCompleted)
					{
						int num11 = 3;
						num = 3;
						num2 = num11;
						taskAwaiter4 = taskAwaiter5;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class48.Struct65>(ref taskAwaiter5, ref this);
						return;
					}
					IL_284:
					taskAwaiter5.GetResult();
					goto IL_2D2;
				}
				catch
				{
					num12 = 1;
				}
				if (num12 != 1)
				{
					goto IL_2D2;
				}
				@class.method_5("Error adding to cart", "#c2c2c2", true, false);
				taskAwaiter5 = @class.method_14(Class130.int_0).GetAwaiter();
				if (!taskAwaiter5.IsCompleted)
				{
					int num13 = 4;
					num = 4;
					num2 = num13;
					taskAwaiter4 = taskAwaiter5;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class48.Struct65>(ref taskAwaiter5, ref this);
					return;
				}
				IL_2C2:
				taskAwaiter5.GetResult();
				IL_2D2:
				if (!@class.bool_1)
				{
					num12 = 0;
					goto IL_5C;
				}
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_317:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x0600051B RID: 1307 RVA: 0x0000509E File Offset: 0x0000329E
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000378 RID: 888
		public int int_0;

		// Token: 0x04000379 RID: 889
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x0400037A RID: 890
		public Class48 class48_0;

		// Token: 0x0400037B RID: 891
		private HttpResponseMessage httpResponseMessage_0;

		// Token: 0x0400037C RID: 892
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x0400037D RID: 893
		private TaskAwaiter<string> taskAwaiter_1;

		// Token: 0x0400037E RID: 894
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x020000D3 RID: 211
	[StructLayout(LayoutKind.Auto)]
	private struct Struct66 : IAsyncStateMachine
	{
		// Token: 0x0600051C RID: 1308 RVA: 0x0002A438 File Offset: 0x00028638
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class48 @class = this;
			try
			{
				if (num == 0)
				{
					goto IL_173;
				}
				if (num != 1)
				{
					goto IL_169;
				}
				TaskAwaiter taskAwaiter3 = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_162:
				taskAwaiter3.GetResult();
				IL_169:
				if (@class.bool_1)
				{
					goto IL_1B5;
				}
				int num4 = 0;
				IL_173:
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter4;
					if (num != 0)
					{
						@class.method_5("Logging in", "#c2c2c2", true, false);
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary["_method"] = "put";
						dictionary["order[email]"] = (string)@class.jtoken_1["payment"]["email"];
						dictionary["commit"] = "continue";
						Dictionary<string, string> dictionary_ = dictionary;
						taskAwaiter4 = @class.class14_0.method_3("https://www.off---white.com/en/GB/checkout/registration", dictionary_, false).GetAwaiter();
						if (!taskAwaiter4.IsCompleted)
						{
							int num5 = 0;
							num = 0;
							num2 = num5;
							TaskAwaiter<HttpResponseMessage> taskAwaiter5 = taskAwaiter4;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class48.Struct66>(ref taskAwaiter4, ref this);
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
					taskAwaiter4.GetResult().smethod_0();
					@class.method_5("Successfully logged in", "#c2c2c2", true, false);
					goto IL_1B5;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_169;
				}
				@class.method_5("Error logging in", "#c2c2c2", true, false);
				taskAwaiter3 = @class.method_14(Class130.int_0).GetAwaiter();
				if (taskAwaiter3.IsCompleted)
				{
					goto IL_162;
				}
				int num7 = 1;
				num = 1;
				num2 = num7;
				taskAwaiter2 = taskAwaiter3;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class48.Struct66>(ref taskAwaiter3, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_1B5:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x0600051D RID: 1309 RVA: 0x000050AC File Offset: 0x000032AC
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400037F RID: 895
		public int int_0;

		// Token: 0x04000380 RID: 896
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000381 RID: 897
		public Class48 class48_0;

		// Token: 0x04000382 RID: 898
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000383 RID: 899
		private TaskAwaiter taskAwaiter_1;
	}

	// Token: 0x020000D4 RID: 212
	[StructLayout(LayoutKind.Auto)]
	private struct Struct67 : IAsyncStateMachine
	{
		// Token: 0x0600051E RID: 1310 RVA: 0x0002A644 File Offset: 0x00028844
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class48 @class = this;
			try
			{
				if (num == 0)
				{
					goto IL_165;
				}
				if (num != 1)
				{
					goto IL_15B;
				}
				TaskAwaiter taskAwaiter3 = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_154:
				taskAwaiter3.GetResult();
				IL_15B:
				if (@class.bool_1)
				{
					goto IL_1A7;
				}
				int num4 = 0;
				IL_165:
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter4;
					if (num != 0)
					{
						@class.method_5("Submitting shipping method", "#c2c2c2", true, false);
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary["_method"] = "patch";
						dictionary["order[state_lock_version]"] = "1";
						dictionary["order[shipments_attributes][0][selected_shipping_rate_id]"] = @class.string_10;
						dictionary["order[shipments_attributes][0][id]"] = @class.string_11;
						taskAwaiter4 = @class.class14_0.method_3(string.Format("https://www.off---white.com/en/{0}/checkout/update/delivery", @class.string_16), dictionary, false).GetAwaiter();
						if (!taskAwaiter4.IsCompleted)
						{
							int num5 = 0;
							num = 0;
							num2 = num5;
							TaskAwaiter<HttpResponseMessage> taskAwaiter5 = taskAwaiter4;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class48.Struct67>(ref taskAwaiter4, ref this);
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
					taskAwaiter4.GetResult().smethod_0();
					goto IL_1A7;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_15B;
				}
				@class.method_5("Error submitting shipping method", "#c2c2c2", true, false);
				taskAwaiter3 = @class.method_14(Class130.int_0).GetAwaiter();
				if (taskAwaiter3.IsCompleted)
				{
					goto IL_154;
				}
				int num7 = 1;
				num = 1;
				num2 = num7;
				taskAwaiter2 = taskAwaiter3;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class48.Struct67>(ref taskAwaiter3, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_1A7:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x0600051F RID: 1311 RVA: 0x000050BA File Offset: 0x000032BA
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000384 RID: 900
		public int int_0;

		// Token: 0x04000385 RID: 901
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000386 RID: 902
		public Class48 class48_0;

		// Token: 0x04000387 RID: 903
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000388 RID: 904
		private TaskAwaiter taskAwaiter_1;
	}

	// Token: 0x020000D5 RID: 213
	[StructLayout(LayoutKind.Auto)]
	private struct Struct68 : IAsyncStateMachine
	{
		// Token: 0x06000520 RID: 1312 RVA: 0x0002A840 File Offset: 0x00028A40
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class48 @class = this;
			try
			{
				if (num <= 1)
				{
					goto IL_210;
				}
				if (num != 2)
				{
					goto IL_206;
				}
				TaskAwaiter taskAwaiter7 = taskAwaiter6;
				taskAwaiter6 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_1FF:
				taskAwaiter7.GetResult();
				IL_206:
				if (@class.bool_1)
				{
					goto IL_252;
				}
				int num4 = 0;
				IL_210:
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
							goto IL_185;
						}
						@class.method_5("Submitting order", "orange", true, false);
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary["utf8"] = "✓";
						dictionary["_method"] = "patch";
						dictionary["authenticity_token"] = string.Empty;
						dictionary["order[payments_attributes][][payment_method_id]"] = "10";
						taskAwaiter9 = @class.class14_0.method_3(string.Format("https://www.off---white.com/en/{0}/checkout/update/payment", @class.string_16), dictionary, false).GetAwaiter();
						if (!taskAwaiter9.IsCompleted)
						{
							int num6 = 0;
							num = 0;
							num2 = num6;
							taskAwaiter2 = taskAwaiter9;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class48.Struct68>(ref taskAwaiter9, ref this);
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
					if (result.StatusCode != HttpStatusCode.Found)
					{
						throw new Exception();
					}
					taskAwaiter8 = result.smethod_3().GetAwaiter();
					if (!taskAwaiter8.IsCompleted)
					{
						int num8 = 1;
						num = 1;
						num2 = num8;
						taskAwaiter4 = taskAwaiter8;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class48.Struct68>(ref taskAwaiter8, ref this);
						return;
					}
					IL_185:
					if (taskAwaiter8.GetResult().Contains("orders"))
					{
						@class.method_0("Successfully checked out", "green", true, (GEnum1)6);
					}
					else
					{
						@class.method_0("Payment error", "red", true, (GEnum1)0);
					}
					goto IL_252;
				}
				catch (ThreadAbortException)
				{
					goto IL_252;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_206;
				}
				@class.method_5("Error submitting order", "#c2c2c2", true, false);
				taskAwaiter7 = @class.method_14(Class130.int_0).GetAwaiter();
				if (taskAwaiter7.IsCompleted)
				{
					goto IL_1FF;
				}
				int num9 = 2;
				num = 2;
				num2 = num9;
				taskAwaiter6 = taskAwaiter7;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class48.Struct68>(ref taskAwaiter7, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_252:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000521 RID: 1313 RVA: 0x000050C8 File Offset: 0x000032C8
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000389 RID: 905
		public int int_0;

		// Token: 0x0400038A RID: 906
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x0400038B RID: 907
		public Class48 class48_0;

		// Token: 0x0400038C RID: 908
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x0400038D RID: 909
		private TaskAwaiter<string> taskAwaiter_1;

		// Token: 0x0400038E RID: 910
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x020000D6 RID: 214
	[StructLayout(LayoutKind.Auto)]
	private struct Struct69 : IAsyncStateMachine
	{
		// Token: 0x06000522 RID: 1314 RVA: 0x0002AB00 File Offset: 0x00028D00
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class48 @class = this;
			try
			{
				if (num <= 1)
				{
					goto IL_1F2;
				}
				if (num != 2)
				{
					goto IL_1E8;
				}
				TaskAwaiter taskAwaiter7 = taskAwaiter6;
				taskAwaiter6 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_1E1:
				taskAwaiter7.GetResult();
				IL_1E8:
				if (@class.bool_1)
				{
					goto IL_234;
				}
				int num4 = 0;
				IL_1F2:
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
							goto IL_15B;
						}
						@class.method_5("Logging in", "#c2c2c2", true, false);
						JObject jobject = new JObject();
						string propertyName = "order";
						JObject jobject2 = new JObject();
						jobject2["email"] = @class.jtoken_1["payment"]["email"];
						jobject[propertyName] = jobject2;
						JObject jobject_ = jobject;
						taskAwaiter9 = @class.class14_0.method_5("https://www.off---white.com/en/GB/orders/populate.json", jobject_, false).GetAwaiter();
						if (!taskAwaiter9.IsCompleted)
						{
							int num6 = 0;
							num = 0;
							num2 = num6;
							taskAwaiter2 = taskAwaiter9;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class48.Struct69>(ref taskAwaiter9, ref this);
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
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class48.Struct69>(ref taskAwaiter8, ref this);
						return;
					}
					IL_15B:
					if (!(bool)taskAwaiter8.GetResult()["ok"])
					{
						throw new Exception();
					}
					@class.method_5("Successfully logged in", "#c2c2c2", true, false);
					@class.class14_0.httpClient_0.DefaultRequestHeaders.Remove("Referer");
					goto IL_234;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_1E8;
				}
				@class.method_5("Error logging in", "#c2c2c2", true, false);
				taskAwaiter7 = @class.method_14(Class130.int_0).GetAwaiter();
				if (taskAwaiter7.IsCompleted)
				{
					goto IL_1E1;
				}
				int num9 = 2;
				num = 2;
				num2 = num9;
				taskAwaiter6 = taskAwaiter7;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class48.Struct69>(ref taskAwaiter7, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_234:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000523 RID: 1315 RVA: 0x000050D6 File Offset: 0x000032D6
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400038F RID: 911
		public int int_0;

		// Token: 0x04000390 RID: 912
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000391 RID: 913
		public Class48 class48_0;

		// Token: 0x04000392 RID: 914
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000393 RID: 915
		private TaskAwaiter<JObject> taskAwaiter_1;

		// Token: 0x04000394 RID: 916
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x020000D7 RID: 215
	[StructLayout(LayoutKind.Auto)]
	private struct Struct70 : IAsyncStateMachine
	{
		// Token: 0x06000524 RID: 1316 RVA: 0x0002AD88 File Offset: 0x00028F88
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class48 @class = this;
			try
			{
				if (num == 0)
				{
					goto IL_184;
				}
				if (num != 1)
				{
					goto IL_17A;
				}
				TaskAwaiter taskAwaiter3 = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_173:
				taskAwaiter3.GetResult();
				IL_17A:
				if (@class.bool_1)
				{
					goto IL_1C6;
				}
				int num4 = 0;
				IL_184:
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter4;
					if (num != 0)
					{
						@class.method_5("Submitting shipping method", "#c2c2c2", true, false);
						JObject jobject = new JObject();
						string propertyName = "order";
						JObject jobject2 = new JObject();
						jobject2["state_lock_version"] = "1";
						string propertyName2 = "shipments_attributes";
						JArray jarray = new JArray();
						JObject jobject3 = new JObject();
						jobject3["selected_shipping_rate_id"] = @class.string_10;
						jobject3["id"] = @class.string_11;
						jarray.Add(jobject3);
						jobject2[propertyName2] = jarray;
						jobject[propertyName] = jobject2;
						JObject jobject_ = jobject;
						taskAwaiter4 = @class.class14_0.method_5("https://www.off---white.com/en/GB/orders/populate.json", jobject_, false).GetAwaiter();
						if (!taskAwaiter4.IsCompleted)
						{
							int num5 = 0;
							num = 0;
							num2 = num5;
							TaskAwaiter<HttpResponseMessage> taskAwaiter5 = taskAwaiter4;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class48.Struct70>(ref taskAwaiter4, ref this);
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
					goto IL_1C6;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_17A;
				}
				@class.method_5("Error submitting shipping method", "#c2c2c2", true, false);
				taskAwaiter3 = @class.method_14(Class130.int_0).GetAwaiter();
				if (taskAwaiter3.IsCompleted)
				{
					goto IL_173;
				}
				int num7 = 1;
				num = 1;
				num2 = num7;
				taskAwaiter2 = taskAwaiter3;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class48.Struct70>(ref taskAwaiter3, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_1C6:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000525 RID: 1317 RVA: 0x000050E4 File Offset: 0x000032E4
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000395 RID: 917
		public int int_0;

		// Token: 0x04000396 RID: 918
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000397 RID: 919
		public Class48 class48_0;

		// Token: 0x04000398 RID: 920
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000399 RID: 921
		private TaskAwaiter taskAwaiter_1;
	}

	// Token: 0x020000D8 RID: 216
	[StructLayout(LayoutKind.Auto)]
	private struct Struct71 : IAsyncStateMachine
	{
		// Token: 0x06000526 RID: 1318 RVA: 0x0002AFA4 File Offset: 0x000291A4
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class48 @class = this;
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
						taskAwaiter4 = @class.class14_0.method_2("https://www.off---white.com/en/GB", false).GetAwaiter();
						if (!taskAwaiter4.IsCompleted)
						{
							int num5 = 0;
							num = 0;
							num2 = num5;
							TaskAwaiter<HttpResponseMessage> taskAwaiter5 = taskAwaiter4;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class48.Struct71>(ref taskAwaiter4, ref this);
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
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class48.Struct71>(ref taskAwaiter3, ref this);
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

		// Token: 0x06000527 RID: 1319 RVA: 0x000050F2 File Offset: 0x000032F2
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400039A RID: 922
		public int int_0;

		// Token: 0x0400039B RID: 923
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x0400039C RID: 924
		public Class48 class48_0;

		// Token: 0x0400039D RID: 925
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x0400039E RID: 926
		private TaskAwaiter taskAwaiter_1;
	}

	// Token: 0x020000D9 RID: 217
	[StructLayout(LayoutKind.Auto)]
	private struct Struct72 : IAsyncStateMachine
	{
		// Token: 0x06000528 RID: 1320 RVA: 0x0002B148 File Offset: 0x00029348
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class48 @class = this;
			try
			{
				if (num <= 2)
				{
					goto IL_2C0;
				}
				if (num != 3)
				{
					goto IL_2B6;
				}
				TaskAwaiter taskAwaiter3 = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_2AF:
				taskAwaiter3.GetResult();
				IL_2B6:
				if (@class.bool_1)
				{
					goto IL_302;
				}
				int num4 = 0;
				IL_2C0:
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter4;
					TaskAwaiter<string> taskAwaiter6;
					TaskAwaiter<JObject> taskAwaiter8;
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
						goto IL_14B;
					}
					case 2:
					{
						TaskAwaiter<JObject> taskAwaiter9;
						taskAwaiter8 = taskAwaiter9;
						taskAwaiter9 = default(TaskAwaiter<JObject>);
						int num7 = -1;
						num = -1;
						num2 = num7;
						goto IL_1B8;
					}
					default:
					{
						@class.method_5("Processing payment", "orange", true, false);
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary["token"] = @class.string_15;
						taskAwaiter4 = @class.class14_0.method_3("https://www.off---white.com/checkout/payment/process_token.json", dictionary, false).GetAwaiter();
						if (!taskAwaiter4.IsCompleted)
						{
							int num8 = 0;
							num = 0;
							num2 = num8;
							TaskAwaiter<HttpResponseMessage> taskAwaiter5 = taskAwaiter4;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class48.Struct72>(ref taskAwaiter4, ref this);
							return;
						}
						break;
					}
					}
					HttpResponseMessage result = taskAwaiter4.GetResult();
					httpResponseMessage_ = result;
					taskAwaiter6 = httpResponseMessage_.smethod_3().GetAwaiter();
					if (!taskAwaiter6.IsCompleted)
					{
						int num9 = 1;
						num = 1;
						num2 = num9;
						TaskAwaiter<string> taskAwaiter7 = taskAwaiter6;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class48.Struct72>(ref taskAwaiter6, ref this);
						return;
					}
					IL_14B:
					string result2 = taskAwaiter6.GetResult();
					text = result2;
					taskAwaiter8 = httpResponseMessage_.smethod_1().GetAwaiter();
					if (!taskAwaiter8.IsCompleted)
					{
						int num10 = 2;
						num = 2;
						num2 = num10;
						TaskAwaiter<JObject> taskAwaiter9 = taskAwaiter8;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class48.Struct72>(ref taskAwaiter8, ref this);
						return;
					}
					IL_1B8:
					JObject result3 = taskAwaiter8.GetResult();
					if (result3.ContainsKey("error"))
					{
						if (result3["error"].ToString().Contains("Autorizzazione negata"))
						{
							@class.method_0("Payment Declined", "red", true, (GEnum1)5);
						}
						else
						{
							@class.method_0("Payment error", "red", true, (GEnum1)0);
							GClass3.smethod_0(text, "error");
						}
					}
					else if (text.Contains("gestpay_completion"))
					{
						@class.method_0("Successfully checked out", "green", true, (GEnum1)6);
					}
					else
					{
						@class.method_0("Payment error", "red", true, (GEnum1)0);
						GClass3.smethod_0(text, "error");
					}
					goto IL_302;
				}
				catch (ThreadAbortException)
				{
					goto IL_302;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_2B6;
				}
				@class.method_5("Error processing payment", "#c2c2c2", true, false);
				taskAwaiter3 = @class.method_14(Class130.int_0).GetAwaiter();
				if (taskAwaiter3.IsCompleted)
				{
					goto IL_2AF;
				}
				int num11 = 3;
				num = 3;
				num2 = num11;
				taskAwaiter2 = taskAwaiter3;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class48.Struct72>(ref taskAwaiter3, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_302:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000529 RID: 1321 RVA: 0x00005100 File Offset: 0x00003300
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400039F RID: 927
		public int int_0;

		// Token: 0x040003A0 RID: 928
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040003A1 RID: 929
		public Class48 class48_0;

		// Token: 0x040003A2 RID: 930
		private HttpResponseMessage httpResponseMessage_0;

		// Token: 0x040003A3 RID: 931
		private string string_0;

		// Token: 0x040003A4 RID: 932
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040003A5 RID: 933
		private TaskAwaiter<string> taskAwaiter_1;

		// Token: 0x040003A6 RID: 934
		private TaskAwaiter<JObject> taskAwaiter_2;

		// Token: 0x040003A7 RID: 935
		private TaskAwaiter taskAwaiter_3;
	}

	// Token: 0x020000DA RID: 218
	[StructLayout(LayoutKind.Auto)]
	private struct Struct73 : IAsyncStateMachine
	{
		// Token: 0x0600052A RID: 1322 RVA: 0x0002B4B8 File Offset: 0x000296B8
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class48 @class = this;
			try
			{
				if (num <= 1)
				{
					goto IL_20F;
				}
				if (num != 2)
				{
					goto IL_205;
				}
				TaskAwaiter taskAwaiter7 = taskAwaiter6;
				taskAwaiter6 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_1FE:
				taskAwaiter7.GetResult();
				IL_205:
				if (@class.bool_1)
				{
					goto IL_251;
				}
				int num4 = 0;
				IL_20F:
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
							goto IL_19D;
						}
						@class.method_5("Getting payment token", "#c2c2c2", true, false);
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary["transaction"] = @class.string_13;
						dictionary["amount"] = (@class.string_12.Contains(".") ? @class.string_12.Replace(",", string.Empty) : (@class.string_12.Replace(",", string.Empty) + ".0"));
						taskAwaiter9 = @class.class14_0.method_3(string.Format("https://www.off---white.com/en/{0}/checkout/payment/get_token.json", @class.string_16), dictionary, false).GetAwaiter();
						if (!taskAwaiter9.IsCompleted)
						{
							int num6 = 0;
							num = 0;
							num2 = num6;
							taskAwaiter2 = taskAwaiter9;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class48.Struct73>(ref taskAwaiter9, ref this);
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
					taskAwaiter8 = result.smethod_1().GetAwaiter();
					if (!taskAwaiter8.IsCompleted)
					{
						int num8 = 1;
						num = 1;
						num2 = num8;
						taskAwaiter4 = taskAwaiter8;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class48.Struct73>(ref taskAwaiter8, ref this);
						return;
					}
					IL_19D:
					JObject result2 = taskAwaiter8.GetResult();
					@class.string_14 = result2["token"].ToString();
					goto IL_251;
				}
				catch (ThreadAbortException)
				{
					goto IL_251;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_205;
				}
				@class.method_5("Error getting payment token", "#c2c2c2", true, false);
				taskAwaiter7 = @class.method_14(Class130.int_0).GetAwaiter();
				if (taskAwaiter7.IsCompleted)
				{
					goto IL_1FE;
				}
				int num9 = 2;
				num = 2;
				num2 = num9;
				taskAwaiter6 = taskAwaiter7;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class48.Struct73>(ref taskAwaiter7, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_251:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x0600052B RID: 1323 RVA: 0x0000510E File Offset: 0x0000330E
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040003A8 RID: 936
		public int int_0;

		// Token: 0x040003A9 RID: 937
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040003AA RID: 938
		public Class48 class48_0;

		// Token: 0x040003AB RID: 939
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040003AC RID: 940
		private TaskAwaiter<JObject> taskAwaiter_1;

		// Token: 0x040003AD RID: 941
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x020000DB RID: 219
	[StructLayout(LayoutKind.Auto)]
	private struct Struct74 : IAsyncStateMachine
	{
		// Token: 0x0600052C RID: 1324 RVA: 0x0002B778 File Offset: 0x00029978
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class48 @class = this;
			try
			{
				if (num <= 1)
				{
					goto IL_1C3;
				}
				if (num != 2)
				{
					goto IL_1B9;
				}
				TaskAwaiter taskAwaiter7 = taskAwaiter6;
				taskAwaiter6 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_1B2:
				taskAwaiter7.GetResult();
				IL_1B9:
				if (@class.bool_1)
				{
					goto IL_205;
				}
				int num4 = 0;
				IL_1C3:
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
							goto IL_138;
						}
						@class.method_5("Submitting order", "orange", true, false);
						taskAwaiter9 = @class.class14_0.method_2(string.Format("https://www.off---white.com/{0}", @class.string_18), false).GetAwaiter();
						if (!taskAwaiter9.IsCompleted)
						{
							int num6 = 0;
							num = 0;
							num2 = num6;
							taskAwaiter2 = taskAwaiter9;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class48.Struct74>(ref taskAwaiter9, ref this);
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
					if (result.StatusCode != HttpStatusCode.Found)
					{
						throw new Exception();
					}
					taskAwaiter8 = result.smethod_3().GetAwaiter();
					if (!taskAwaiter8.IsCompleted)
					{
						int num8 = 1;
						num = 1;
						num2 = num8;
						taskAwaiter4 = taskAwaiter8;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class48.Struct74>(ref taskAwaiter8, ref this);
						return;
					}
					IL_138:
					if (taskAwaiter8.GetResult().Contains("orders"))
					{
						@class.method_0("Successfully checked out", "green", true, (GEnum1)6);
					}
					else
					{
						@class.method_0("Payment error", "red", true, (GEnum1)0);
					}
					goto IL_205;
				}
				catch (ThreadAbortException)
				{
					goto IL_205;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_1B9;
				}
				@class.method_5("Error submitting order", "#c2c2c2", true, false);
				taskAwaiter7 = @class.method_14(Class130.int_0).GetAwaiter();
				if (taskAwaiter7.IsCompleted)
				{
					goto IL_1B2;
				}
				int num9 = 2;
				num = 2;
				num2 = num9;
				taskAwaiter6 = taskAwaiter7;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class48.Struct74>(ref taskAwaiter7, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_205:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x0600052D RID: 1325 RVA: 0x0000511C File Offset: 0x0000331C
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040003AE RID: 942
		public int int_0;

		// Token: 0x040003AF RID: 943
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040003B0 RID: 944
		public Class48 class48_0;

		// Token: 0x040003B1 RID: 945
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040003B2 RID: 946
		private TaskAwaiter<string> taskAwaiter_1;

		// Token: 0x040003B3 RID: 947
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x020000DC RID: 220
	[StructLayout(LayoutKind.Auto)]
	private struct Struct75 : IAsyncStateMachine
	{
		// Token: 0x0600052E RID: 1326 RVA: 0x0002B9EC File Offset: 0x00029BEC
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class48 @class = this;
			try
			{
				if (num <= 1)
				{
					goto IL_22A;
				}
				if (num != 2)
				{
					goto IL_220;
				}
				TaskAwaiter taskAwaiter7 = taskAwaiter6;
				taskAwaiter6 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_219:
				taskAwaiter7.GetResult();
				IL_220:
				if (@class.bool_1)
				{
					goto IL_26C;
				}
				int num4 = 0;
				IL_22A:
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
							goto IL_146;
						}
						@class.method_5("Getting payment info", "#c2c2c2", true, false);
						taskAwaiter9 = @class.class14_0.method_2(string.Format("https://ecomm.sella.it/Pagam/hiddenIframe.aspx?a=9091712&b={0}&MerchantUrl=https://www.off---white.com/en/GB/checkout/payment", @class.string_14), false).GetAwaiter();
						if (!taskAwaiter9.IsCompleted)
						{
							int num6 = 0;
							num = 0;
							num2 = num6;
							taskAwaiter2 = taskAwaiter9;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class48.Struct75>(ref taskAwaiter9, ref this);
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
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class48.Struct75>(ref taskAwaiter8, ref this);
						return;
					}
					IL_146:
					string result2 = taskAwaiter8.GetResult();
					htmlDocument2.LoadHtml(result2);
					htmlDocument2 = null;
					IEnumerator<HtmlNode> enumerator = ((IEnumerable<HtmlNode>)htmlDocument.DocumentNode.SelectNodes("//form//input[@value][@name]")).GetEnumerator();
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
					goto IL_26C;
				}
				catch (ThreadAbortException)
				{
					goto IL_26C;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_220;
				}
				@class.method_5("Error getting payment info", "#c2c2c2", true, false);
				taskAwaiter7 = @class.method_14(Class130.int_0).GetAwaiter();
				if (taskAwaiter7.IsCompleted)
				{
					goto IL_219;
				}
				int num9 = 2;
				num = 2;
				num2 = num9;
				taskAwaiter6 = taskAwaiter7;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class48.Struct75>(ref taskAwaiter7, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_26C:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x0600052F RID: 1327 RVA: 0x0000512A File Offset: 0x0000332A
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040003B4 RID: 948
		public int int_0;

		// Token: 0x040003B5 RID: 949
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040003B6 RID: 950
		public Class48 class48_0;

		// Token: 0x040003B7 RID: 951
		private HtmlDocument htmlDocument_0;

		// Token: 0x040003B8 RID: 952
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040003B9 RID: 953
		private HtmlDocument htmlDocument_1;

		// Token: 0x040003BA RID: 954
		private TaskAwaiter<string> taskAwaiter_1;

		// Token: 0x040003BB RID: 955
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x020000DD RID: 221
	[StructLayout(LayoutKind.Auto)]
	private struct Struct76 : IAsyncStateMachine
	{
		// Token: 0x06000530 RID: 1328 RVA: 0x0002BCDC File Offset: 0x00029EDC
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class48 @class = this;
			try
			{
				try
				{
					TaskAwaiter taskAwaiter3;
					switch (num)
					{
					case 0:
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						break;
					case 1:
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_F3;
					case 2:
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_14E;
					case 3:
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_1A9;
					case 4:
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_204;
					case 5:
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_2AE;
					case 6:
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_309;
					case 7:
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_331;
					case 8:
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_38C;
					case 9:
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_3E9;
					case 10:
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_446;
					case 11:
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_4A0;
					default:
						taskAwaiter3 = @class.method_11().GetAwaiter();
						if (!taskAwaiter3.IsCompleted)
						{
							num2 = 0;
							taskAwaiter2 = taskAwaiter3;
							this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class48.Struct76>(ref taskAwaiter3, ref this);
							return;
						}
						break;
					}
					taskAwaiter3.GetResult();
					taskAwaiter3 = @class.method_17().GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						num2 = 1;
						taskAwaiter2 = taskAwaiter3;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class48.Struct76>(ref taskAwaiter3, ref this);
						return;
					}
					IL_F3:
					taskAwaiter3.GetResult();
					taskAwaiter3 = @class.method_18().GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						num2 = 2;
						taskAwaiter2 = taskAwaiter3;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class48.Struct76>(ref taskAwaiter3, ref this);
						return;
					}
					IL_14E:
					taskAwaiter3.GetResult();
					taskAwaiter3 = @class.method_20().GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						num2 = 3;
						taskAwaiter2 = taskAwaiter3;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class48.Struct76>(ref taskAwaiter3, ref this);
						return;
					}
					IL_1A9:
					taskAwaiter3.GetResult();
					taskAwaiter3 = @class.method_21().GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						num2 = 4;
						taskAwaiter2 = taskAwaiter3;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class48.Struct76>(ref taskAwaiter3, ref this);
						return;
					}
					IL_204:
					taskAwaiter3.GetResult();
					task = @class.method_23();
					if (@class.bool_3)
					{
						taskAwaiter3 = task.GetAwaiter();
						if (!taskAwaiter3.IsCompleted)
						{
							num2 = 5;
							taskAwaiter2 = taskAwaiter3;
							this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class48.Struct76>(ref taskAwaiter3, ref this);
							return;
						}
					}
					else
					{
						taskAwaiter3 = @class.method_25().GetAwaiter();
						if (!taskAwaiter3.IsCompleted)
						{
							num2 = 7;
							taskAwaiter2 = taskAwaiter3;
							this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class48.Struct76>(ref taskAwaiter3, ref this);
							return;
						}
						goto IL_331;
					}
					IL_2AE:
					taskAwaiter3.GetResult();
					taskAwaiter3 = @class.method_30().GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						num2 = 6;
						taskAwaiter2 = taskAwaiter3;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class48.Struct76>(ref taskAwaiter3, ref this);
						return;
					}
					IL_309:
					taskAwaiter3.GetResult();
					goto IL_4A7;
					IL_331:
					taskAwaiter3.GetResult();
					taskAwaiter3 = @class.method_26().GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						num2 = 8;
						taskAwaiter2 = taskAwaiter3;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class48.Struct76>(ref taskAwaiter3, ref this);
						return;
					}
					IL_38C:
					taskAwaiter3.GetResult();
					taskAwaiter3 = @class.method_27().GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						num2 = 9;
						taskAwaiter2 = taskAwaiter3;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class48.Struct76>(ref taskAwaiter3, ref this);
						return;
					}
					IL_3E9:
					taskAwaiter3.GetResult();
					taskAwaiter3 = task.GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						num2 = 10;
						taskAwaiter2 = taskAwaiter3;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class48.Struct76>(ref taskAwaiter3, ref this);
						return;
					}
					IL_446:
					taskAwaiter3.GetResult();
					taskAwaiter3 = @class.method_28().GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						num2 = 11;
						taskAwaiter2 = taskAwaiter3;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class48.Struct76>(ref taskAwaiter3, ref this);
						return;
					}
					IL_4A0:
					taskAwaiter3.GetResult();
					IL_4A7:
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

		// Token: 0x06000531 RID: 1329 RVA: 0x00005138 File Offset: 0x00003338
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040003BC RID: 956
		public int int_0;

		// Token: 0x040003BD RID: 957
		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		// Token: 0x040003BE RID: 958
		public Class48 class48_0;

		// Token: 0x040003BF RID: 959
		private Task task_0;

		// Token: 0x040003C0 RID: 960
		private TaskAwaiter taskAwaiter_0;
	}

	// Token: 0x020000DE RID: 222
	[StructLayout(LayoutKind.Auto)]
	private struct Struct77 : IAsyncStateMachine
	{
		// Token: 0x06000532 RID: 1330 RVA: 0x0002C210 File Offset: 0x0002A410
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class48 @class = this;
			try
			{
				TaskAwaiter taskAwaiter3;
				if (num > 3)
				{
					if (num != 4)
					{
						@class.method_5("Waiting for product", "#c2c2c2", true, false);
						goto IL_34B;
					}
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					int num3 = -1;
					num = -1;
					num2 = num3;
					goto IL_329;
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
						goto IL_155;
					}
					case 2:
					{
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num6 = -1;
						num = -1;
						num2 = num6;
						goto IL_2D8;
					}
					case 3:
					{
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num7 = -1;
						num = -1;
						num2 = num7;
						goto IL_2FD;
					}
					default:
						taskAwaiter4 = @class.class14_0.method_2(@class.string_9 + ".json", false).GetAwaiter();
						if (!taskAwaiter4.IsCompleted)
						{
							int num8 = 0;
							num = 0;
							num2 = num8;
							TaskAwaiter<HttpResponseMessage> taskAwaiter5 = taskAwaiter4;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class48.Struct77>(ref taskAwaiter4, ref this);
							return;
						}
						break;
					}
					HttpResponseMessage result = taskAwaiter4.GetResult();
					if (result.StatusCode == HttpStatusCode.Forbidden)
					{
						@class.method_0("Proxy banned", "red", true, (GEnum1)0);
					}
					result.EnsureSuccessStatusCode();
					taskAwaiter6 = result.smethod_1().GetAwaiter();
					if (!taskAwaiter6.IsCompleted)
					{
						int num9 = 1;
						num = 1;
						num2 = num9;
						TaskAwaiter<JObject> taskAwaiter7 = taskAwaiter6;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class48.Struct77>(ref taskAwaiter6, ref this);
						return;
					}
					IL_155:
					JObject result2 = taskAwaiter6.GetResult();
					if (@class.bool_0)
					{
						JToken jtoken = result2["available_sizes"];
						if (!jtoken.Any<JToken>())
						{
							@class.method_5("Waiting for restock", "#c2c2c2", true, false);
							taskAwaiter3 = @class.method_14(Class130.int_0).GetAwaiter();
							if (!taskAwaiter3.IsCompleted)
							{
								int num10 = 2;
								num = 2;
								num2 = num10;
								taskAwaiter2 = taskAwaiter3;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class48.Struct77>(ref taskAwaiter3, ref this);
								return;
							}
							goto IL_2D8;
						}
						else
						{
							JToken jtoken2 = jtoken.smethod_5();
							@class.string_8 = jtoken2["id"].ToString();
							@class.method_6(jtoken2["name"].ToString());
						}
					}
					else
					{
						JToken jtoken3 = result2["available_sizes"].FirstOrDefault(new Func<JToken, bool>(@class.method_31));
						if (jtoken3 == null)
						{
							@class.method_5("Waiting for restock", "#c2c2c2", true, false);
							taskAwaiter3 = @class.method_14(Class130.int_0).GetAwaiter();
							if (!taskAwaiter3.IsCompleted)
							{
								int num11 = 3;
								num = 3;
								num2 = num11;
								taskAwaiter2 = taskAwaiter3;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class48.Struct77>(ref taskAwaiter3, ref this);
								return;
							}
							goto IL_2FD;
						}
						else
						{
							@class.string_8 = jtoken3["id"].ToString();
						}
					}
					@class.method_5("Found variant ID: " + @class.string_8, "#c2c2c2", true, false);
					goto IL_390;
					IL_2D8:
					taskAwaiter3.GetResult();
					goto IL_34B;
					IL_2FD:
					taskAwaiter3.GetResult();
					goto IL_34B;
				}
				catch
				{
					num12 = 1;
				}
				if (num12 != 1)
				{
					goto IL_34B;
				}
				taskAwaiter3 = @class.method_14(Class130.int_0).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					int num13 = 4;
					num = 4;
					num2 = num13;
					taskAwaiter2 = taskAwaiter3;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class48.Struct77>(ref taskAwaiter3, ref this);
					return;
				}
				IL_329:
				taskAwaiter3.GetResult();
				@class.method_5("Waiting for product", "#c2c2c2", true, false);
				IL_34B:
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
			IL_390:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000533 RID: 1331 RVA: 0x00005146 File Offset: 0x00003346
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040003C1 RID: 961
		public int int_0;

		// Token: 0x040003C2 RID: 962
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040003C3 RID: 963
		public Class48 class48_0;

		// Token: 0x040003C4 RID: 964
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040003C5 RID: 965
		private TaskAwaiter<JObject> taskAwaiter_1;

		// Token: 0x040003C6 RID: 966
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x020000DF RID: 223
	[StructLayout(LayoutKind.Auto)]
	private struct Struct78 : IAsyncStateMachine
	{
		// Token: 0x06000534 RID: 1332 RVA: 0x0002C5F4 File Offset: 0x0002A7F4
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class48 @class = this;
			try
			{
				if (num <= 1)
				{
					goto IL_32D;
				}
				if (num != 2)
				{
					goto IL_323;
				}
				TaskAwaiter taskAwaiter7 = taskAwaiter6;
				taskAwaiter6 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_31C:
				taskAwaiter7.GetResult();
				IL_323:
				if (@class.bool_1)
				{
					goto IL_36F;
				}
				int num4 = 0;
				IL_32D:
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
							goto IL_247;
						}
						@class.method_5("Submitting payment", "orange", true, false);
						@class.dictionary_0["cardnumber"] = @class.jtoken_1["payment"]["card"]["number"].ToString().Replace(" ", string.Empty);
						@class.dictionary_0["cardExpiryMonth"] = (string)@class.jtoken_1["payment"]["card"]["exp_month"];
						@class.dictionary_0["cardExpiryYear"] = @class.jtoken_1["payment"]["card"]["exp_year"].ToString().Substring(2);
						@class.dictionary_0["cvv"] = (string)@class.jtoken_1["payment"]["card"]["cvv"];
						@class.dictionary_0["inputString"] = @class.string_14;
						taskAwaiter9 = @class.class14_0.method_3(string.Format("https://ecomm.sella.it/Pagam/hiddenIframe.aspx?a=9091712&b={0}&MerchantUrl=https://www.off---white.com/en/GB/checkout/payment", @class.string_14), @class.dictionary_0, false).GetAwaiter();
						if (!taskAwaiter9.IsCompleted)
						{
							int num6 = 0;
							num = 0;
							num2 = num6;
							taskAwaiter2 = taskAwaiter9;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class48.Struct78>(ref taskAwaiter9, ref this);
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
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class48.Struct78>(ref taskAwaiter8, ref this);
						return;
					}
					IL_247:
					string result2 = taskAwaiter8.GetResult();
					string text = result2.Split(new string[]
					{
						"//<![CDATA["
					}, StringSplitOptions.None)[1].ToLower();
					if (text.Contains("invalid") || text.Contains("wrong") || text.Contains("expired"))
					{
						@class.method_0("Invalid card info", "red", true, (GEnum1)0);
					}
					@class.string_15 = result2.Split(new string[]
					{
						"delayedSendResult('0','','','','"
					}, StringSplitOptions.None)[1].Split(new string[]
					{
						"')//]"
					}, StringSplitOptions.None)[0];
					goto IL_36F;
				}
				catch (ThreadAbortException)
				{
					goto IL_36F;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_323;
				}
				@class.method_5("Error submitting payment", "#c2c2c2", true, false);
				taskAwaiter7 = @class.method_14(Class130.int_0).GetAwaiter();
				if (taskAwaiter7.IsCompleted)
				{
					goto IL_31C;
				}
				int num9 = 2;
				num = 2;
				num2 = num9;
				taskAwaiter6 = taskAwaiter7;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class48.Struct78>(ref taskAwaiter7, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_36F:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000535 RID: 1333 RVA: 0x00005154 File Offset: 0x00003354
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040003C7 RID: 967
		public int int_0;

		// Token: 0x040003C8 RID: 968
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040003C9 RID: 969
		public Class48 class48_0;

		// Token: 0x040003CA RID: 970
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040003CB RID: 971
		private TaskAwaiter<string> taskAwaiter_1;

		// Token: 0x040003CC RID: 972
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x020000E0 RID: 224
	[StructLayout(LayoutKind.Auto)]
	private struct Struct79 : IAsyncStateMachine
	{
		// Token: 0x06000536 RID: 1334 RVA: 0x0002C9D0 File Offset: 0x0002ABD0
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class48 @class = this;
			try
			{
				if (num <= 1)
				{
					goto IL_254;
				}
				if (num != 2)
				{
					goto IL_24A;
				}
				TaskAwaiter taskAwaiter7 = taskAwaiter6;
				taskAwaiter6 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_243:
				taskAwaiter7.GetResult();
				IL_24A:
				if (@class.bool_1)
				{
					goto IL_296;
				}
				int num4 = 0;
				IL_254:
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
							goto IL_121;
						}
						@class.method_5("Getting shipping method", "#c2c2c2", true, false);
						taskAwaiter9 = @class.class14_0.method_2("https://www.off---white.com/en/GB/checkout/delivery", false).GetAwaiter();
						if (!taskAwaiter9.IsCompleted)
						{
							int num6 = 0;
							num = 0;
							num2 = num6;
							taskAwaiter2 = taskAwaiter9;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class48.Struct79>(ref taskAwaiter9, ref this);
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
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class48.Struct79>(ref taskAwaiter8, ref this);
						return;
					}
					IL_121:
					string result2 = taskAwaiter8.GetResult();
					HtmlDocument htmlDocument = new HtmlDocument();
					htmlDocument.LoadHtml(result2);
					@class.string_10 = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='order[shipments_attributes][0][selected_shipping_rate_id]']").Attributes["value"].Value;
					@class.string_11 = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='order[shipments_attributes][0][id]']").Attributes["value"].Value;
					@class.string_13 = result2.Replace(" ", string.Empty).Split(new string[]
					{
						"Spree.current_order_id=\""
					}, StringSplitOptions.None)[1].Split(new char[]
					{
						'"'
					})[0];
					@class.method_5("Detected region: " + @class.string_16, "#c2c2c2", true, false);
					@class.method_7(htmlDocument.DocumentNode.SelectSingleNode("//td[@class='description']//strong").InnerText, "#c2c2c2");
					goto IL_296;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_24A;
				}
				@class.method_5("Error getting shipping method", "#c2c2c2", true, false);
				taskAwaiter7 = @class.method_14(Class130.int_0).GetAwaiter();
				if (taskAwaiter7.IsCompleted)
				{
					goto IL_243;
				}
				int num9 = 2;
				num = 2;
				num2 = num9;
				taskAwaiter6 = taskAwaiter7;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class48.Struct79>(ref taskAwaiter7, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_296:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000537 RID: 1335 RVA: 0x00005162 File Offset: 0x00003362
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040003CD RID: 973
		public int int_0;

		// Token: 0x040003CE RID: 974
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040003CF RID: 975
		public Class48 class48_0;

		// Token: 0x040003D0 RID: 976
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040003D1 RID: 977
		private TaskAwaiter<string> taskAwaiter_1;

		// Token: 0x040003D2 RID: 978
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x020000E1 RID: 225
	[StructLayout(LayoutKind.Auto)]
	private struct Struct80 : IAsyncStateMachine
	{
		// Token: 0x06000538 RID: 1336 RVA: 0x0002CCBC File Offset: 0x0002AEBC
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class48 @class = this;
			try
			{
				if (num <= 1)
				{
					goto IL_876;
				}
				if (num != 2)
				{
					@class.class14_0.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("Referer", "https://www.off---white.com/en/GB/checkout");
					goto IL_86B;
				}
				TaskAwaiter taskAwaiter7 = taskAwaiter6;
				taskAwaiter6 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_864:
				taskAwaiter7.GetResult();
				IL_86B:
				if (@class.bool_1)
				{
					goto IL_8B8;
				}
				int num4 = 0;
				IL_876:
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
							goto IL_6A6;
						}
						@class.method_5("Submitting shipping", "#c2c2c2", true, false);
						JObject jobject = new JObject();
						jobject["order"] = new JObject();
						jobject["order"]["bill_address_attributes"] = new JObject();
						jobject["order"]["ship_address_attributes"] = new JObject();
						jobject["order"]["email"] = @class.jtoken_1["payment"]["email"];
						jobject["order"]["state_lock_version"] = "0";
						jobject["order"]["bill_address_attributes"]["firstname"] = @class.jtoken_1["billing"]["first_name"];
						jobject["order"]["bill_address_attributes"]["lastname"] = @class.jtoken_1["billing"]["last_name"];
						jobject["order"]["bill_address_attributes"]["address1"] = @class.jtoken_1["billing"]["addr1"];
						jobject["order"]["bill_address_attributes"]["address2"] = @class.jtoken_1["billing"]["addr2"];
						jobject["order"]["bill_address_attributes"]["city"] = @class.jtoken_1["billing"]["city"];
						jobject["order"]["bill_address_attributes"]["country_id"] = @class.method_15((string)@class.jtoken_1["billing"]["country"]);
						jobject["order"]["bill_address_attributes"]["zipcode"] = @class.jtoken_1["billing"]["zip"];
						jobject["order"]["bill_address_attributes"]["phone"] = @class.jtoken_1["payment"]["phone"];
						jobject["order"]["bill_address_attributes"]["state_name"] = Class43.smethod_1((string)@class.jtoken_1["billing"]["country"], (string)@class.jtoken_1["billing"]["state"]);
						jobject["order"]["ship_address_attributes"]["firstname"] = @class.jtoken_1["delivery"]["first_name"];
						jobject["order"]["ship_address_attributes"]["lastname"] = @class.jtoken_1["delivery"]["last_name"];
						jobject["order"]["ship_address_attributes"]["address1"] = @class.jtoken_1["delivery"]["addr1"];
						jobject["order"]["ship_address_attributes"]["address2"] = @class.jtoken_1["delivery"]["addr2"];
						jobject["order"]["ship_address_attributes"]["city"] = @class.jtoken_1["delivery"]["city"];
						jobject["order"]["ship_address_attributes"]["country_id"] = @class.method_15((string)@class.jtoken_1["delivery"]["country"]);
						jobject["order"]["ship_address_attributes"]["state_name"] = Class43.smethod_1((string)@class.jtoken_1["delivery"]["country"], (string)@class.jtoken_1["delivery"]["state"]);
						jobject["order"]["ship_address_attributes"]["zipcode"] = @class.jtoken_1["delivery"]["zip"];
						jobject["order"]["ship_address_attributes"]["phone"] = @class.jtoken_1["payment"]["phone"];
						jobject["order"]["ship_address_attributes"]["shipping"] = "true";
						jobject["order"]["terms_and_conditions"] = "yes";
						taskAwaiter9 = @class.class14_0.method_5("https://www.off---white.com/en/GB/checkout/update/address", jobject, true).GetAwaiter();
						if (!taskAwaiter9.IsCompleted)
						{
							int num6 = 0;
							num = 0;
							num2 = num6;
							taskAwaiter2 = taskAwaiter9;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class48.Struct80>(ref taskAwaiter9, ref this);
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
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class48.Struct80>(ref taskAwaiter8, ref this);
						return;
					}
					IL_6A6:
					string result2 = taskAwaiter8.GetResult();
					if (result2.Contains("order_ship_address_attributes_state"))
					{
						@class.method_0("Invalid shipping", "red", true, (GEnum1)0);
					}
					HtmlDocument htmlDocument = new HtmlDocument();
					htmlDocument.LoadHtml(result2);
					@class.string_10 = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='order[shipments_attributes][0][selected_shipping_rate_id]']").Attributes["value"].Value;
					@class.string_11 = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='order[shipments_attributes][0][id]']").Attributes["value"].Value;
					@class.string_16 = htmlDocument.DocumentNode.SelectSingleNode("//meta[@name='CART_PATH']").Attributes["content"].Value.Split(new char[]
					{
						'/'
					})[4];
					@class.string_13 = result2.Replace(" ", string.Empty).Split(new string[]
					{
						"Spree.current_order_id=\""
					}, StringSplitOptions.None)[1].Split(new char[]
					{
						'"'
					})[0];
					@class.string_12 = htmlDocument.DocumentNode.SelectNodes("//span[@class='amount']").Last<HtmlNode>().InnerText.Replace(" ", string.Empty).Replace("€", string.Empty);
					@class.method_5("Detected region: " + @class.string_16, "#c2c2c2", true, false);
					@class.method_7(htmlDocument.DocumentNode.SelectSingleNode("//td[@class='description']//strong").InnerText, "#c2c2c2");
					goto IL_8B8;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_86B;
				}
				@class.method_5("Error submitting shipping", "#c2c2c2", true, false);
				taskAwaiter7 = @class.method_14(Class130.int_0).GetAwaiter();
				if (taskAwaiter7.IsCompleted)
				{
					goto IL_864;
				}
				int num9 = 2;
				num = 2;
				num2 = num9;
				taskAwaiter6 = taskAwaiter7;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class48.Struct80>(ref taskAwaiter7, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_8B8:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000539 RID: 1337 RVA: 0x00005170 File Offset: 0x00003370
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040003D3 RID: 979
		public int int_0;

		// Token: 0x040003D4 RID: 980
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040003D5 RID: 981
		public Class48 class48_0;

		// Token: 0x040003D6 RID: 982
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040003D7 RID: 983
		private TaskAwaiter<string> taskAwaiter_1;

		// Token: 0x040003D8 RID: 984
		private TaskAwaiter taskAwaiter_2;
	}
}
