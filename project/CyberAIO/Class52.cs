using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using HtmlAgilityPack;
using Jint;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json.Linq;

// Token: 0x0200013B RID: 315
internal sealed class Class52 : Class44
{
	// Token: 0x06000732 RID: 1842 RVA: 0x0003C8C0 File Offset: 0x0003AAC0
	public Class52(JToken jtoken_3, string string_25 = null)
	{
		JObject jobject = new JObject();
		jobject["X-Shopify-Checkout-Version"] = "2016-09-06";
		this.jobject_0 = jobject;
		this.string_13 = string.Empty;
		this.bool_7 = true;
		this.jobject_1 = new JObject();
		this.stopwatch_0 = new Stopwatch();
		this.string_24 = "api";
		Class52.Class163 @class = new Class52.Class163();
		@class.jtoken_0 = jtoken_3;
		base..ctor();
		try
		{
			this.jtoken_0 = @class.jtoken_0;
			Class130.string_0 = null;
			this.jtoken_2 = Class130.jobject_1.Properties().FirstOrDefault(new Func<JProperty, bool>(@class.method_0)).Value;
			if (@class.jtoken_0["store"].ToString() == "Custom")
			{
				this.string_21 = string.Format("{0}://{1}/products.json", new Uri((string)@class.jtoken_0["custom_url"]).Scheme, new Uri((string)@class.jtoken_0["custom_url"]).Host);
				string propertyName = new Uri((string)@class.jtoken_0["custom_url"]).Host.Replace("www.", string.Empty);
				base.method_4(propertyName);
				if (Class130.jobject_1.ContainsKey(propertyName))
				{
					this.jtoken_2 = Class130.jobject_1[propertyName];
				}
			}
			else
			{
				this.string_21 = this.jtoken_2["sitemap"].ToString();
			}
			if (!base.method_2(out this.jtoken_1))
			{
				base.method_0("Profile error", "red", true, (GEnum1)0);
			}
			else
			{
				Uri uri;
				if ((@class.jtoken_0["keywords"].ToString().smethod_15() && @class.jtoken_0["keywords"].ToString().Length > 6) || @class.jtoken_0["keywords"].ToString().Contains("/cart/"))
				{
					if (!@class.jtoken_0["keywords"].ToString().smethod_15())
					{
						@class.jtoken_0["keywords"] = @class.jtoken_0["keywords"].ToString().Split(new char[]
						{
							'/'
						}).Last<string>().Split(new char[]
						{
							':'
						})[0];
					}
					this.string_22 = @class.jtoken_0["keywords"].ToString();
					base.method_7(this.string_22, "#c2c2c2");
					this.string_8 = new Uri(this.string_21).Scheme + "://" + new Uri(this.string_21).Authority + "/";
				}
				else if (Uri.TryCreate(@class.jtoken_0["keywords"].ToString().Split(new char[]
				{
					'?'
				})[0], UriKind.Absolute, out uri))
				{
					this.bool_7 = false;
					this.string_8 = uri.Scheme + "://" + uri.Authority + "/";
					this.string_18 = uri.ToString();
				}
				else
				{
					this.string_15 = ((string)@class.jtoken_0["keywords"]).Replace(" ", string.Empty).ToLower().Split(new char[]
					{
						','
					}).Where(new Func<string, bool>(Class52.Class162.class162_0.method_5)).ToArray<string>();
					this.string_12 = ((string)@class.jtoken_0["keywords"]).Replace(" ", string.Empty).ToLower().Split(new char[]
					{
						','
					}).Where(new Func<string, bool>(Class52.Class162.class162_0.method_6)).ToArray<string>().Select(new Func<string, string>(Class52.Class162.class162_0.method_7)).ToArray<string>();
					this.string_8 = new Uri(this.string_21).Scheme + "://" + new Uri(this.string_21).Authority + "/";
				}
				if (!((string)@class.jtoken_0["size"] == "Random") && !((string)@class.jtoken_0["size"] == "OneSize"))
				{
					this.string_0 = (string)@class.jtoken_0["size"];
				}
				else
				{
					this.bool_6 = true;
				}
				if (this.string_8.Contains("palace"))
				{
					this.bool_5 = true;
				}
				this.string_19 = base.method_3();
				string string_26 = this.string_19;
				string string_27 = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36";
				int int_ = 10;
				bool bool_ = true;
				bool bool_2 = false;
				JObject jobject2;
				if (this.jtoken_2 != null)
				{
					JToken jtoken = this.jtoken_2["old"];
					if (((jtoken != null) ? jtoken.ToString() : null) == "True")
					{
						jobject2 = this.jobject_0;
						goto IL_546;
					}
				}
				jobject2 = new JObject();
				IL_546:
				this.class14_0 = new Class14(string_26, string_27, int_, bool_, bool_2, jobject2);
				this.class14_0.httpClient_0.DefaultRequestHeaders.ExpectContinue = new bool?(false);
				this.string_5 = string_25;
				this.bool_4 = ((string)@class.jtoken_0["store"] == "Funko Shop");
			}
		}
		catch
		{
			base.method_0("Task error", "red", true, (GEnum1)0);
		}
	}

	// Token: 0x06000733 RID: 1843 RVA: 0x0003CE98 File Offset: 0x0003B098
	public async Task method_15()
	{
		while (!this.bool_1)
		{
			int num = 0;
			TaskAwaiter taskAwaiter6;
			try
			{
				HttpResponseMessage result;
				for (;;)
				{
					IL_10B:
					base.method_5("Getting shipping rates", "#c2c2c2", true, false);
					TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class14_0.method_2(this.string_7 + "/shipping_rates.json", false).GetAwaiter();
					TaskAwaiter<HttpResponseMessage> taskAwaiter2;
					if (!taskAwaiter.IsCompleted)
					{
						await taskAwaiter;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
					}
					result = taskAwaiter.GetResult();
					TaskAwaiter<bool> taskAwaiter3 = this.method_32(result).GetAwaiter();
					TaskAwaiter<bool> taskAwaiter4;
					if (!taskAwaiter3.IsCompleted)
					{
						await taskAwaiter3;
						taskAwaiter3 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<bool>);
					}
					if (!taskAwaiter3.GetResult())
					{
						while (result.StatusCode == HttpStatusCode.Accepted)
						{
							TaskAwaiter taskAwaiter5 = base.method_14(500).GetAwaiter();
							if (!taskAwaiter5.IsCompleted)
							{
								await taskAwaiter5;
								taskAwaiter5 = taskAwaiter6;
								taskAwaiter6 = default(TaskAwaiter);
							}
							taskAwaiter5.GetResult();
							taskAwaiter = this.class14_0.method_2(this.string_7 + "/shipping_rates.json", false).GetAwaiter();
							if (!taskAwaiter.IsCompleted)
							{
								await taskAwaiter;
								taskAwaiter = taskAwaiter2;
								taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
							}
							result = taskAwaiter.GetResult();
							taskAwaiter3 = this.method_32(result).GetAwaiter();
							if (!taskAwaiter3.IsCompleted)
							{
								await taskAwaiter3;
								taskAwaiter3 = taskAwaiter4;
								taskAwaiter4 = default(TaskAwaiter<bool>);
							}
							if (taskAwaiter3.GetResult())
							{
								goto IL_10B;
							}
						}
						break;
					}
					goto IL_276;
				}
				TaskAwaiter<JObject> taskAwaiter7 = result.smethod_1().GetAwaiter();
				if (!taskAwaiter7.IsCompleted)
				{
					await taskAwaiter7;
					TaskAwaiter<JObject> taskAwaiter8;
					taskAwaiter7 = taskAwaiter8;
					taskAwaiter8 = default(TaskAwaiter<JObject>);
				}
				JObject result2 = taskAwaiter7.GetResult();
				string text = await result.smethod_3();
				if (text.Contains("does_not_require_shipping"))
				{
					this.string_20 = null;
					break;
				}
				if (text.Contains("is_not_supported"))
				{
					base.method_0("Country not supported", "red", true, (GEnum1)0);
					break;
				}
				if (text.Contains("is_not"))
				{
					base.method_0("Invalid shipping address", "red", true, (GEnum1)0);
					break;
				}
				if (!result2["shipping_rates"].Any<JToken>())
				{
					base.method_0("Country not supported", "red", true, (GEnum1)0);
				}
				this.string_20 = result2["shipping_rates"][0]["id"].ToString();
				base.method_5("Found shipping rate", "#c2c2c2", true, false);
				break;
				IL_276:
				continue;
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
				base.method_5("Error getting shipping rates", "#c2c2c2", true, false);
				TaskAwaiter taskAwaiter5 = base.method_14(Class130.int_1).GetAwaiter();
				if (!taskAwaiter5.IsCompleted)
				{
					await taskAwaiter5;
					taskAwaiter5 = taskAwaiter6;
					taskAwaiter6 = default(TaskAwaiter);
				}
				taskAwaiter5.GetResult();
			}
		}
	}

	// Token: 0x06000734 RID: 1844 RVA: 0x0003CEE0 File Offset: 0x0003B0E0
	public async Task method_16()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Submitting shipping method...", "#c2c2c2", true, false);
				JObject jobject = new JObject();
				string propertyName = "checkout";
				JObject jobject2 = new JObject();
				string propertyName2 = "shipping_rate";
				JObject jobject3 = new JObject();
				jobject3["id"] = this.string_20;
				jobject2[propertyName2] = jobject3;
				jobject[propertyName] = jobject2;
				JObject jobject4 = jobject;
				if (this.bool_5)
				{
					jobject4["checkout"]["note"] = this.string_13;
				}
				HttpResponseMessage httpResponseMessage = await this.class14_0.method_5(this.string_7 + ".json", jobject4, false);
				HttpResponseMessage httpResponseMessage2 = httpResponseMessage;
				TaskAwaiter<bool> taskAwaiter = this.method_32(httpResponseMessage2).GetAwaiter();
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
				httpResponseMessage2.EnsureSuccessStatusCode();
				this.string_16 = (await httpResponseMessage2.smethod_1())["checkout"]["total_price"].ToString();
				base.method_5("Successfully submitted shipping method", "#c2c2c2", true, false);
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
				base.method_5("Error submitting shipping method...", "#c2c2c2", true, false);
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

	// Token: 0x06000735 RID: 1845 RVA: 0x0003CF28 File Offset: 0x0003B128
	public async Task method_17()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Submitting payment...", "orange", true, false);
				JObject jobject = new JObject();
				string propertyName = "payment";
				JObject jobject2 = new JObject();
				jobject2["amount"] = this.string_16;
				jobject2["unique_token"] = Class108.smethod_17(16);
				string propertyName2 = "payment_token";
				JObject jobject3 = new JObject();
				jobject3["type"] = "shopify_payments";
				jobject3["payment_data"] = this.string_14;
				jobject2[propertyName2] = jobject3;
				jobject[propertyName] = jobject2;
				HttpResponseMessage httpResponseMessage_ = await this.class14_0.method_4(this.string_7 + "/payments.json", jobject, false);
				TaskAwaiter<bool> taskAwaiter = this.method_32(httpResponseMessage_).GetAwaiter();
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
				TaskAwaiter<string> taskAwaiter3 = httpResponseMessage_.smethod_3().GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<string> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<string>);
				}
				string result = taskAwaiter3.GetResult();
				if (result.Contains("not_enough_in_stock"))
				{
					base.method_0("Payment Declined (OOS)", "red", true, (GEnum1)0);
				}
				else if (result.ToLower().Contains("Declined"))
				{
					base.method_0("Payment Declined", "red", true, (GEnum1)0);
				}
				else if (result.Contains("processing_error"))
				{
					base.method_0("Payment error", "red", true, (GEnum1)0);
				}
				else if (result.Contains("thank_you"))
				{
					base.method_0("Successfully checked out", "green", true, (GEnum1)0);
				}
				else if (!result.Contains("is invalid") && !result.Contains("is incorrect"))
				{
					if (result.Contains("Some products became unavailable"))
					{
						base.method_0("Payment Declined (OOS)", "red", true, (GEnum1)0);
					}
					else
					{
						GClass3.smethod_0(result, "Unhandled Exception");
						base.method_0("Payment error", "red", true, (GEnum1)0);
					}
				}
				else
				{
					base.method_0("Invalid card info", "red", true, (GEnum1)0);
				}
				throw new Exception();
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
				base.method_5("Error submitting payment...", "#c2c2c2", true, false);
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

	// Token: 0x06000736 RID: 1846 RVA: 0x0003CF70 File Offset: 0x0003B170
	public async Task method_18()
	{
		if (this.bool_7)
		{
			if (this.string_8.Contains("yeezysupply"))
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
			}
			else if (this.string_8.Contains("doverstreetmarket"))
			{
				TaskAwaiter taskAwaiter = this.method_20().GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter.GetResult();
				await this.method_21();
			}
			else if (this.string_21.Contains(".json"))
			{
				TaskAwaiter taskAwaiter = this.method_23().GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter.GetResult();
			}
			else if (this.string_21.Contains(".atom"))
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
			}
			else if (this.string_21.Contains(".oembed"))
			{
				TaskAwaiter taskAwaiter = this.method_24().GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter.GetResult();
			}
			if (this.bool_4)
			{
				await this.method_30(null);
			}
		}
		else
		{
			if (this.string_8.Contains("yeezysupply"))
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
			}
			else if (this.string_8.Contains("doverstreetmarket"))
			{
				TaskAwaiter taskAwaiter = this.method_21().GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter.GetResult();
			}
			else
			{
				TaskAwaiter taskAwaiter = this.method_26().GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter.GetResult();
			}
			if (this.bool_4)
			{
				await this.method_30(null);
			}
		}
		base.method_5("Found variant: " + this.string_22, "#c2c2c2", true, false);
	}

	// Token: 0x06000737 RID: 1847 RVA: 0x0003CFB8 File Offset: 0x0003B1B8
	public async Task method_19()
	{
		base.method_5("Waiting for product", "#c2c2c2", true, false);
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				HttpResponseMessage httpResponseMessage = await GClass2.smethod_1("https://cybersolewebsite.azurewebsites.net/api/sitemaps?token=94112421582745227130", null, true);
				httpResponseMessage.EnsureSuccessStatusCode();
				using (IEnumerator<JProperty> enumerator = (await httpResponseMessage.smethod_1()).Properties().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Class52.Class166 @class = new Class52.Class166();
						@class.jproperty_0 = enumerator.Current;
						JToken jtoken = @class.jproperty_0.Value["products"].FirstOrDefault(new Func<JToken, bool>(this.method_45));
						if (jtoken != null)
						{
							JProperty jproperty = Class130.jobject_1.Properties().Where(new Func<JProperty, bool>(@class.method_0)).FirstOrDefault<JProperty>();
							string text = (jproperty != null) ? jproperty.Name : null;
							if (text != null)
							{
								base.method_4(text);
								base.method_7(jtoken["title"].ToString(), "#c2c2c2");
								this.string_21 = Class130.jobject_1[text]["sitemap"].ToString();
								this.string_8 = new Uri(this.string_21).Scheme + "://" + new Uri(this.string_21).Authority + "/";
								if (this.bool_6)
								{
									if (this.method_33(jtoken["variants"], out this.string_22, "option1", "id", "available"))
									{
										return;
									}
								}
								else
								{
									JToken jtoken2 = jtoken["variants"].Where(new Func<JToken, bool>(this.method_46)).FirstOrDefault<JToken>();
									if (jtoken2 != null)
									{
										this.string_22 = jtoken2["id"].ToString();
										if (!object.Equals(false, (bool)jtoken2["available"]))
										{
											return;
										}
									}
								}
							}
						}
					}
				}
				await base.method_14(Class130.int_0);
				goto IL_389;
			}
			catch
			{
				num = 1;
				goto IL_389;
			}
			IL_354:
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
			IL_389:
			if (num == 1)
			{
				goto IL_354;
			}
		}
	}

	// Token: 0x06000738 RID: 1848 RVA: 0x0003D000 File Offset: 0x0003B200
	public async Task method_20()
	{
		base.method_5("Waiting for product", "#c2c2c2", true, false);
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				if (this.method_34())
				{
					break;
				}
				HttpResponseMessage httpResponseMessage_ = await GClass2.smethod_1(this.string_8, null, true);
				HtmlDocument htmlDocument = new HtmlDocument();
				HtmlDocument htmlDocument2 = htmlDocument;
				htmlDocument2.LoadHtml(await httpResponseMessage_.smethod_3());
				htmlDocument2 = null;
				HtmlNodeCollection htmlNodeCollection = htmlDocument.DocumentNode.SelectNodes("//div[@class='h4 grid-view-item__title']");
				HtmlNode htmlNode = (htmlNodeCollection != null) ? htmlNodeCollection.FirstOrDefault(new Func<HtmlNode, bool>(this.method_48)) : null;
				if (htmlNode != null)
				{
					base.method_7(htmlNode.InnerText, "#c2c2c2");
					this.string_18 = this.string_8 + htmlNode.ParentNode.Attributes["href"].Value;
					break;
				}
				await base.method_14(Class130.int_0);
				base.method_5("Waiting for product", "#c2c2c2", false, false);
				htmlDocument = null;
				goto IL_29B;
			}
			catch
			{
				num = 1;
				goto IL_29B;
			}
			IL_254:
			TaskAwaiter taskAwaiter = base.method_14(Class130.int_0).GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter);
			}
			taskAwaiter.GetResult();
			base.method_5("Waiting for product", "#c2c2c2", false, false);
			continue;
			IL_29B:
			if (num == 1)
			{
				goto IL_254;
			}
		}
	}

	// Token: 0x06000739 RID: 1849 RVA: 0x0003D048 File Offset: 0x0003B248
	public async Task method_21()
	{
		base.method_5("Fetching variants", "#c2c2c2", true, false);
		while (!this.bool_1)
		{
			int num = 0;
			TaskAwaiter taskAwaiter2;
			try
			{
				this.method_34();
				HttpResponseMessage httpResponseMessage_ = await GClass2.smethod_1(this.string_18, null, true);
				HtmlDocument htmlDocument = new HtmlDocument();
				HtmlDocument htmlDocument2 = htmlDocument;
				htmlDocument2.LoadHtml(await httpResponseMessage_.smethod_3());
				htmlDocument2 = null;
				JObject jobject = JObject.Parse(htmlDocument.DocumentNode.SelectSingleNode("//script[@id='ProductJson-product-template']").InnerText);
				base.method_7(jobject["title"].ToString(), "#c2c2c2");
				this.string_17 = jobject["id"].ToString();
				this.jtoken_0["product_id"] = this.string_17;
				JToken jtoken = jobject["variants"];
				if (this.bool_6)
				{
					if (!this.method_33(jtoken, out this.string_22, "option1", "id", "available"))
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
					TaskAwaiter<string> taskAwaiter3 = httpResponseMessage_.smethod_3().GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						await taskAwaiter3;
						TaskAwaiter<string> taskAwaiter4;
						taskAwaiter3 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<string>);
					}
					await this.method_30(taskAwaiter3.GetResult());
					break;
				}
				else
				{
					JToken jtoken2 = jtoken.Where(new Func<JToken, bool>(this.method_49)).FirstOrDefault<JToken>();
					if (jtoken2 != null)
					{
						this.string_22 = jtoken2["id"].ToString();
						if (object.Equals(false, (bool)jtoken2["available"]))
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
						TaskAwaiter<string> taskAwaiter3 = httpResponseMessage_.smethod_3().GetAwaiter();
						if (!taskAwaiter3.IsCompleted)
						{
							await taskAwaiter3;
							TaskAwaiter<string> taskAwaiter4;
							taskAwaiter3 = taskAwaiter4;
							taskAwaiter4 = default(TaskAwaiter<string>);
						}
						await this.method_30(taskAwaiter3.GetResult());
						break;
					}
					else
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
						httpResponseMessage_ = null;
						htmlDocument = null;
					}
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

	// Token: 0x0600073A RID: 1850 RVA: 0x0003D090 File Offset: 0x0003B290
	public async Task method_22()
	{
		base.method_5("Waiting for product", "#c2c2c2", true, false);
		Engine engine = new Engine();
		while (!this.bool_1)
		{
			int num = 0;
			TaskAwaiter taskAwaiter2;
			try
			{
				this.method_34();
				string text = await(await GClass2.smethod_1(this.bool_7 ? this.string_8 : this.string_18, null, true)).smethod_3();
				HtmlDocument htmlDocument = new HtmlDocument();
				htmlDocument.LoadHtml(text);
				JObject jobject;
				if (text.Contains("js-product-json"))
				{
					jobject = JObject.Parse(htmlDocument.DocumentNode.SelectSingleNode("//script[@id='js-product-json']").InnerText);
				}
				else if (text.Contains("js-new-arrivals-json"))
				{
					jobject = (JObject)JObject.Parse(htmlDocument.DocumentNode.SelectSingleNode("//script[@id='js-new-arrivals-json']").InnerText)["products"].Where(new Func<JToken, bool>(this.method_51)).FirstOrDefault<JToken>();
					if (jobject != null)
					{
						this.bool_7 = false;
						this.string_18 = string.Format("{0}products/{1}", this.string_8, jobject["handle"]);
						continue;
					}
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
					engine.Execute("KANYE = {}; " + string.Join(" ", htmlDocument.DocumentNode.SelectNodes("//script").Where(new Func<HtmlNode, bool>(Class52.Class162.class162_0.method_0)).Select(new Func<HtmlNode, string>(Class52.Class162.class162_0.method_1))));
					jobject = (JObject)JObject.Parse(engine.Execute("JSON.stringify(KANYE)").GetCompletionValue().ToString())["p"].FirstOrDefault(new Func<JToken, bool>(this.method_52));
					if (jobject == null)
					{
						throw new Exception();
					}
				}
				base.method_7(jobject["title"].ToString(), "#c2c2c2");
				this.string_17 = jobject["id"].ToString();
				this.jtoken_0["product_id"] = this.string_17;
				JToken jtoken = jobject["variants"];
				if (this.bool_6)
				{
					if (!this.method_33(jtoken, out this.string_22, "option1", "id", "available"))
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
					break;
				}
				else
				{
					JToken jtoken2 = jtoken.Where(new Func<JToken, bool>(this.method_53)).FirstOrDefault<JToken>();
					if (jtoken2 == null)
					{
						throw new Exception();
					}
					this.string_22 = jtoken2["id"].ToString();
					if (object.Equals(false, (bool)jtoken2["available"]))
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
					break;
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

	// Token: 0x0600073B RID: 1851 RVA: 0x0003D0D8 File Offset: 0x0003B2D8
	public async Task method_23()
	{
		base.method_5("Waiting for product", "#c2c2c2", true, false);
		while (!this.bool_1)
		{
			int num = 0;
			TaskAwaiter taskAwaiter2;
			try
			{
				TaskAwaiter taskAwaiter;
				if (this.method_34())
				{
					taskAwaiter = this.method_26().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						await taskAwaiter;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
					}
					taskAwaiter.GetResult();
					break;
				}
				TaskAwaiter<HttpResponseMessage> taskAwaiter3 = GClass2.smethod_1(this.string_21, null, true).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<HttpResponseMessage> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<HttpResponseMessage>);
				}
				HttpResponseMessage result = taskAwaiter3.GetResult();
				if (result.StatusCode == HttpStatusCode.NotFound)
				{
					base.method_0("Unsupported retailer", "red", true, (GEnum1)0);
				}
				result.EnsureSuccessStatusCode();
				JToken jtoken = (await result.smethod_1())["products"].FirstOrDefault(new Func<JToken, bool>(this.method_55));
				if (jtoken != null)
				{
					base.method_7(jtoken["title"].ToString(), "#c2c2c2");
					this.string_17 = jtoken["id"].ToString();
					this.string_18 = string.Format("{0}products/{1}", this.string_8, jtoken["handle"]);
					this.string_2 = (jtoken["images"].Any<JToken>() ? jtoken["images"][0]["src"].ToString() : null);
					if (this.bool_6)
					{
						if (!this.method_33(jtoken["variants"], out this.string_22, "option1", "id", "available"))
						{
							base.method_5("Waiting for restock", "#c2c2c2", true, false);
							taskAwaiter = base.method_14(Class130.int_0).GetAwaiter();
							if (!taskAwaiter.IsCompleted)
							{
								await taskAwaiter;
								taskAwaiter = taskAwaiter2;
								taskAwaiter2 = default(TaskAwaiter);
							}
							taskAwaiter.GetResult();
							continue;
						}
						break;
					}
					else
					{
						JToken jtoken2 = jtoken["variants"].Where(new Func<JToken, bool>(this.method_56)).FirstOrDefault<JToken>();
						if (jtoken2 != null)
						{
							this.string_22 = jtoken2["id"].ToString();
							this.string_16 = jtoken2["price"].ToString();
							this.jtoken_0["product_id"] = this.string_17;
							if (object.Equals(false, (bool)jtoken2["available"]))
							{
								base.method_5("Waiting for restock", "#c2c2c2", true, false);
								taskAwaiter = base.method_14(Class130.int_0).GetAwaiter();
								if (!taskAwaiter.IsCompleted)
								{
									await taskAwaiter;
									taskAwaiter = taskAwaiter2;
									taskAwaiter2 = default(TaskAwaiter);
								}
								taskAwaiter.GetResult();
								continue;
							}
							break;
						}
					}
				}
				taskAwaiter = base.method_14(Class130.int_0).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter.GetResult();
				base.method_5("Waiting for product", "#c2c2c2", false, false);
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

	// Token: 0x0600073C RID: 1852 RVA: 0x0003D120 File Offset: 0x0003B320
	public async Task method_24()
	{
		base.method_5("Waiting for product", "#c2c2c2", true, false);
		while (!this.bool_1)
		{
			int num = 0;
			TaskAwaiter taskAwaiter2;
			try
			{
				TaskAwaiter taskAwaiter;
				if (this.method_34())
				{
					taskAwaiter = this.method_26().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						await taskAwaiter;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
					}
					taskAwaiter.GetResult();
					break;
				}
				TaskAwaiter<HttpResponseMessage> taskAwaiter3 = GClass2.smethod_1(this.string_21, null, true).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<HttpResponseMessage> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<HttpResponseMessage>);
				}
				HttpResponseMessage result = taskAwaiter3.GetResult();
				result.EnsureSuccessStatusCode();
				JToken jtoken = (await result.smethod_1())["products"].FirstOrDefault(new Func<JToken, bool>(this.method_58));
				if (jtoken != null)
				{
					this.string_17 = jtoken["product_id"].ToString();
					base.method_7(jtoken["title"].ToString(), "#c2c2c2");
					this.string_2 = (string)jtoken["thumbnail_url"];
					if (this.bool_6)
					{
						if (!this.method_33(jtoken["offers"], out this.string_22, "title", "offer_id", "in_stock"))
						{
							base.method_5("Waiting for restock", "#c2c2c2", true, false);
							taskAwaiter = base.method_14(Class130.int_0).GetAwaiter();
							if (!taskAwaiter.IsCompleted)
							{
								await taskAwaiter;
								taskAwaiter = taskAwaiter2;
								taskAwaiter2 = default(TaskAwaiter);
							}
							taskAwaiter.GetResult();
							continue;
						}
						break;
					}
					else
					{
						JToken jtoken2 = jtoken["offers"].Where(new Func<JToken, bool>(this.method_59)).FirstOrDefault<JToken>();
						if (jtoken2 != null)
						{
							this.string_22 = jtoken2["offer_id"].ToString();
							if (object.Equals(false, (bool)jtoken2["in_stock"]))
							{
								base.method_5("Waiting for restock", "#c2c2c2", true, false);
								taskAwaiter = base.method_14(Class130.int_0).GetAwaiter();
								if (!taskAwaiter.IsCompleted)
								{
									await taskAwaiter;
									taskAwaiter = taskAwaiter2;
									taskAwaiter2 = default(TaskAwaiter);
								}
								taskAwaiter.GetResult();
								continue;
							}
							break;
						}
					}
				}
				taskAwaiter = base.method_14(Class130.int_0).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter.GetResult();
				base.method_5("Waiting for product", "#c2c2c2", false, false);
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

	// Token: 0x0600073D RID: 1853 RVA: 0x0003D168 File Offset: 0x0003B368
	public async Task method_25()
	{
		base.method_5("Waiting for product", "#c2c2c2", true, false);
		while (!this.bool_1)
		{
			int num = 0;
			TaskAwaiter taskAwaiter;
			TaskAwaiter taskAwaiter2;
			try
			{
				if (this.method_34())
				{
					taskAwaiter = this.method_26().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						await taskAwaiter;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
					}
					taskAwaiter.GetResult();
					break;
				}
				TaskAwaiter<HttpResponseMessage> taskAwaiter3 = GClass2.smethod_1(this.string_21, null, true).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<HttpResponseMessage> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<HttpResponseMessage>);
				}
				HttpResponseMessage result = taskAwaiter3.GetResult();
				result.EnsureSuccessStatusCode();
				XmlDocument xmlDocument = new XmlDocument();
				XmlDocument xmlDocument2 = xmlDocument;
				xmlDocument2.LoadXml(await result.smethod_3());
				xmlDocument2 = null;
				foreach (object obj in xmlDocument.GetElementsByTagName("entry"))
				{
					XmlNode xmlNode = (XmlNode)obj;
					if (this.string_15.All(new Func<string, bool>(xmlNode["title"].InnerText.ToLower().Contains)) && !this.string_12.Any(new Func<string, bool>(xmlNode["title"].InnerText.ToLower().Contains)))
					{
						this.string_18 = xmlNode["link"].Attributes["href"].Value;
						return;
					}
				}
				await base.method_14(Class130.int_0);
				base.method_5("Waiting for product", "#c2c2c2", false, false);
				xmlDocument = null;
				goto IL_361;
			}
			catch
			{
				num = 1;
				goto IL_361;
			}
			IL_31A:
			taskAwaiter = base.method_14(Class130.int_0).GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter);
			}
			taskAwaiter.GetResult();
			base.method_5("Waiting for product", "#c2c2c2", false, false);
			continue;
			IL_361:
			if (num == 1)
			{
				goto IL_31A;
			}
		}
	}

	// Token: 0x0600073E RID: 1854 RVA: 0x0003D1B0 File Offset: 0x0003B3B0
	public async Task method_26()
	{
		base.method_5("Waiting for product", "#c2c2c2", true, false);
		while (!this.bool_1)
		{
			int num = 0;
			TaskAwaiter taskAwaiter2;
			try
			{
				this.method_34();
				HttpResponseMessage httpResponseMessage = await GClass2.smethod_1(this.string_18 + ".js", null, true);
				httpResponseMessage.EnsureSuccessStatusCode();
				JObject jobject = await httpResponseMessage.smethod_1();
				base.method_7(jobject["title"].ToString(), "#c2c2c2");
				this.string_17 = jobject["id"].ToString();
				this.jtoken_0["product_id"] = this.string_17;
				this.string_2 = (string)jobject["featured_image"];
				if (jobject["tags"].Any(new Func<JToken, bool>(Class52.Class162.class162_0.method_2)))
				{
					this.bool_4 = true;
				}
				if (this.bool_6)
				{
					if (!this.method_33(jobject["variants"], out this.string_22, "option1", "id", "available"))
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
					break;
				}
				else
				{
					JToken jtoken = jobject["variants"].FirstOrDefault(new Func<JToken, bool>(this.method_60));
					if (jtoken != null)
					{
						this.string_22 = jtoken["id"].ToString();
						if (object.Equals(false, (bool)jtoken["available"]))
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
						break;
					}
					else
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

	// Token: 0x0600073F RID: 1855 RVA: 0x0003D1F8 File Offset: 0x0003B3F8
	public bool method_27(string string_25)
	{
		HtmlDocument htmlDocument = new HtmlDocument();
		htmlDocument.LoadHtml(string_25);
		foreach (HtmlNode htmlNode in ((IEnumerable<HtmlNode>)htmlDocument.DocumentNode.SelectNodes("//script")))
		{
			if (htmlNode.InnerText.Contains("https") && !htmlNode.InnerText.Contains(new Uri(this.string_8).Authority) && htmlNode.InnerText.Contains("yeezysupply.com"))
			{
				string text = htmlNode.InnerText.Split(new string[]
				{
					"https://"
				}, StringSplitOptions.None)[1].Split(new string[]
				{
					"yeezysupply.com"
				}, StringSplitOptions.None)[0];
				if (text.Length > 0)
				{
					this.string_8 = "https://" + text + "yeezysupply.com";
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06000740 RID: 1856 RVA: 0x0003D2F4 File Offset: 0x0003B4F4
	public async Task method_28()
	{
		if (this.bool_5)
		{
			while (!this.bool_1)
			{
				int num = 0;
				try
				{
					base.method_5("Getting token", "#c2c2c2", true, false);
					TaskAwaiter<HttpResponseMessage> taskAwaiter = new Class14(this.string_19, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36", 10, false, true, null).method_2(string.Format("{0}/cart/add/{1}", this.string_8, this.string_22), true).GetAwaiter();
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
					this.string_13 = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='note']").Attributes["value"].Value;
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
				}
			}
		}
	}

	// Token: 0x06000741 RID: 1857 RVA: 0x0003D33C File Offset: 0x0003B53C
	public async Task method_29()
	{
		while (!this.bool_1)
		{
			try
			{
				if (this.jtoken_2["api_key"].smethod_22())
				{
					base.method_5("Getting API key", "#c2c2c2", true, false);
					TaskAwaiter<HttpResponseMessage> taskAwaiter = GClass2.smethod_1(this.string_8, null, true).GetAwaiter();
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
					string value = htmlDocument.DocumentNode.SelectSingleNode("//meta[@name='shopify-checkout-api-token']").Attributes["content"].Value;
					this.class14_0.httpClient_0.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:", value))));
					JObject jobject = new JObject();
					jobject["api_key"] = value;
					Class130.jobject_1[(string)this.jtoken_0["store"]] = jobject;
					htmlDocument = null;
				}
				else
				{
					string arg = this.jtoken_2["api_key"].ToString();
					this.class14_0.httpClient_0.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:", arg))));
				}
				break;
			}
			catch
			{
				base.method_0("Store not supported", "red", true, (GEnum1)0);
			}
		}
	}

	// Token: 0x06000742 RID: 1858 RVA: 0x0003D384 File Offset: 0x0003B584
	public async Task method_30(string string_25)
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				if (this.string_18 == null && string_25 == null)
				{
					break;
				}
				base.method_5("Getting token", "#c2c2c2", true, false);
				string text = string_25;
				if (text == null)
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter = GClass2.smethod_1(this.string_18, null, true).GetAwaiter();
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
					text = taskAwaiter3.GetResult();
				}
				string text2 = text;
				HtmlDocument htmlDocument = new HtmlDocument();
				htmlDocument.LoadHtml(text2);
				if ((string)this.jtoken_0["store"] == "Kith")
				{
					this.jobject_1[text2.Replace(" ", string.Empty).Split(new string[]
					{
						"theme.htikb="
					}, StringSplitOptions.None)[1].Split(new char[]
					{
						';'
					})[0].Replace("\"", string.Empty).Replace("'", string.Empty)] = text2.Replace(" ", string.Empty).Split(new string[]
					{
						"theme.htikc="
					}, StringSplitOptions.None)[1].Split(new char[]
					{
						';'
					})[0].Replace("\"", string.Empty).Replace("'", string.Empty);
				}
				else if (this.jtoken_0["store"].ToString().Contains("DSM"))
				{
					HtmlNode htmlNode = htmlDocument.DocumentNode.SelectNodes("//script").FirstOrDefault(new Func<HtmlNode, bool>(Class52.Class162.class162_0.method_3));
					if (htmlNode != null)
					{
						string text3 = string.Empty;
						string text4 = string.Empty;
						foreach (string text5 in htmlNode.InnerHtml.Split(new string[]
						{
							"atob('"
						}, StringSplitOptions.None).Skip(1).ToArray<string>())
						{
							try
							{
								string text6 = text5.Split(new string[]
								{
									"')"
								}, StringSplitOptions.None)[0];
								int num2 = text6.Length % 4;
								if (num2 > 0)
								{
									text6 += new string('=', 4 - num2);
								}
								string @string = Encoding.UTF8.GetString(Convert.FromBase64String(text6));
								if (@string.Contains("properties"))
								{
									text3 = @string.Split(new string[]
									{
										"properties["
									}, StringSplitOptions.None)[1].Split(new char[]
									{
										']'
									})[0];
								}
								else if (!@string.Contains("product"))
								{
									text4 = @string;
								}
							}
							catch
							{
							}
						}
						string[] array2 = htmlNode.InnerHtml.Split(new string[]
						{
							".val('"
						}, StringSplitOptions.None);
						if (array2.Count<string>() > 1)
						{
							text4 = array2[1].Split(new string[]
							{
								"')"
							}, StringSplitOptions.None)[0];
						}
						if (text3 != null && text4 != null)
						{
							this.jobject_1[text3] = text4;
						}
					}
				}
				HtmlNodeCollection htmlNodeCollection = htmlDocument.DocumentNode.SelectNodes("//input[@name]");
				HtmlNode htmlNode2;
				if (htmlNodeCollection == null)
				{
					htmlNode2 = null;
				}
				else
				{
					htmlNode2 = htmlNodeCollection.FirstOrDefault(new Func<HtmlNode, bool>(Class52.Class162.class162_0.method_4));
				}
				HtmlNode htmlNode3 = htmlNode2;
				if (htmlNode3 != null)
				{
					this.jobject_1[htmlNode3.Attributes["name"].Value.Replace("properties[", string.Empty).Replace("]", string.Empty)] = htmlNode3.Attributes["value"].Value;
				}
				base.method_5("Successfully found token: " + htmlNode3, "#c2c2c2", true, false);
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

	// Token: 0x06000743 RID: 1859 RVA: 0x0003D3D4 File Offset: 0x0003B5D4
	public override async void vmethod_0()
	{
		try
		{
			base.method_5("Setting up", "#c2c2c2", true, false);
			Task task = this.method_35();
			Task task2 = this.method_40(false);
			await this.method_29();
			Task task3 = this.method_37(null);
			await base.method_11();
			if (this.string_22 == null)
			{
				await this.method_18();
			}
			base.method_5("Waiting for checkout URL", "#c2c2c2", true, false);
			await task3;
			Task task4 = this.method_28();
			if (!this.bool_3)
			{
				await this.method_36();
			}
			if (this.string_20 == null)
			{
				await this.method_15();
			}
			await task;
			await task2;
			await task4;
			await this.method_43();
			await this.method_44();
			task = null;
			task2 = null;
			task3 = null;
			task4 = null;
		}
		catch
		{
		}
		base.method_0("Stopped", "red", true, (GEnum1)0);
	}

	// Token: 0x06000744 RID: 1860 RVA: 0x0003D410 File Offset: 0x0003B610
	public async Task method_31()
	{
		base.method_5("Verifying checkout URL", "#c2c2c2", true, false);
		if (new Uri(this.string_11).Authority != new Uri(this.string_8).Authority)
		{
			await this.method_37(null);
		}
	}

	// Token: 0x06000745 RID: 1861 RVA: 0x0003D458 File Offset: 0x0003B658
	public async Task<bool> method_32(HttpResponseMessage httpResponseMessage_0)
	{
		bool result;
		if (httpResponseMessage_0.StatusCode == (HttpStatusCode)430)
		{
			base.method_5("Banned retry in 5", "#c2c2c2", true, false);
			TaskAwaiter taskAwaiter = base.method_14(5000).GetAwaiter();
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
			TaskAwaiter<string> taskAwaiter3 = httpResponseMessage_0.smethod_3().GetAwaiter();
			if (!taskAwaiter3.IsCompleted)
			{
				await taskAwaiter3;
				TaskAwaiter<string> taskAwaiter4;
				taskAwaiter3 = taskAwaiter4;
				taskAwaiter4 = default(TaskAwaiter<string>);
			}
			if (taskAwaiter3.GetResult().Contains("Online Store channel is locked"))
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
				result = true;
			}
			else
			{
				result = false;
			}
		}
		return result;
	}

	// Token: 0x06000746 RID: 1862 RVA: 0x0003D4A8 File Offset: 0x0003B6A8
	public bool method_33(JToken jtoken_3, out string string_25, string string_26, string string_27, string string_28)
	{
		JToken jtoken = jtoken_3.Where(new Func<JToken, bool>(new Class52.Class164
		{
			string_0 = string_28
		}.method_0)).smethod_5();
		if (jtoken == null)
		{
			string_25 = null;
			return false;
		}
		base.method_6(jtoken[string_26].ToString().ToUpper());
		string_25 = jtoken[string_27].ToString();
		return true;
	}

	// Token: 0x06000747 RID: 1863 RVA: 0x0003D50C File Offset: 0x0003B70C
	public bool method_34()
	{
		bool result;
		try
		{
			if (Class130.string_0 != null && (this.string_18 == null || (this.string_18 != null && Class130.string_0 != this.string_18.ToString())) && Class130.string_0.Replace("www.", string.Empty).Contains(this.string_8.Replace("www.", string.Empty)))
			{
				base.method_7(Class130.string_0, "#c2c2c2");
				this.bool_7 = false;
				this.string_18 = Class130.string_0.Split(new char[]
				{
					'?'
				})[0];
				result = true;
			}
			else
			{
				result = false;
			}
		}
		catch
		{
			result = false;
		}
		return result;
	}

	// Token: 0x06000748 RID: 1864 RVA: 0x0003D5CC File Offset: 0x0003B7CC
	public async Task method_35()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				if (this.jtoken_0["login"].ToString() == "False")
				{
					break;
				}
				base.method_5("Logging in", "#c2c2c2", true, false);
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary["form_type"] = "customer_login";
				dictionary["utf8"] = "✓";
				dictionary["customer[email]"] = this.jtoken_0["login"]["username"].ToString();
				dictionary["customer[password]"] = this.jtoken_0["login"]["password"].ToString();
				HttpResponseMessage httpResponseMessage = await this.class14_0.method_3(this.string_8 + "/account/login", dictionary, false);
				HttpResponseMessage httpResponseMessage_ = httpResponseMessage;
				await this.method_32(httpResponseMessage_);
				TaskAwaiter<string> taskAwaiter = httpResponseMessage_.smethod_3().GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter<string> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<string>);
				}
				if (taskAwaiter.GetResult().Contains("/account/login"))
				{
					base.method_0("Invalid login details", "red", true, (GEnum1)0);
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
				base.method_5("Error logging in", "#c2c2c2", true, false);
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

	// Token: 0x06000749 RID: 1865 RVA: 0x0003D614 File Offset: 0x0003B814
	public async Task method_36()
	{
		while (!this.bool_1)
		{
			int num = 0;
			TaskAwaiter taskAwaiter10;
			try
			{
				JObject result2;
				for (;;)
				{
					base.method_5("Adding to cart", "yellow", true, false);
					JObject jobject = new JObject();
					string propertyName = "checkout";
					JObject jobject2 = new JObject();
					string propertyName2 = "line_items";
					JArray jarray = new JArray();
					JObject jobject3 = new JObject();
					jobject3["variant_id"] = this.string_22;
					jobject3["quantity"] = 1;
					jobject3["properties"] = this.jobject_1;
					jarray.Add(jobject3);
					jobject2[propertyName2] = jarray;
					jobject[propertyName] = jobject2;
					TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class14_0.method_5(this.string_7 + ".json", jobject, false).GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						await taskAwaiter;
						TaskAwaiter<HttpResponseMessage> taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
					}
					HttpResponseMessage result = taskAwaiter.GetResult();
					TaskAwaiter<bool> taskAwaiter3 = this.method_32(result).GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						await taskAwaiter3;
						TaskAwaiter<bool> taskAwaiter4;
						taskAwaiter3 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<bool>);
					}
					if (taskAwaiter3.GetResult())
					{
						break;
					}
					TaskAwaiter<JObject> taskAwaiter5 = result.smethod_1().GetAwaiter();
					if (!taskAwaiter5.IsCompleted)
					{
						await taskAwaiter5;
						TaskAwaiter<JObject> taskAwaiter6;
						taskAwaiter5 = taskAwaiter6;
						taskAwaiter6 = default(TaskAwaiter<JObject>);
					}
					result2 = taskAwaiter5.GetResult();
					TaskAwaiter<string> taskAwaiter7 = result.smethod_3().GetAwaiter();
					if (!taskAwaiter7.IsCompleted)
					{
						await taskAwaiter7;
						TaskAwaiter<string> taskAwaiter8;
						taskAwaiter7 = taskAwaiter8;
						taskAwaiter8 = default(TaskAwaiter<string>);
					}
					if (!taskAwaiter7.GetResult().Contains("not_enough_in_stock") && result2["checkout"]["line_items"].Any<JToken>())
					{
						goto IL_386;
					}
					base.method_5("Waiting for restock", "#c2c2c2", true, false);
					TaskAwaiter taskAwaiter9 = base.method_14(Class130.int_0).GetAwaiter();
					if (!taskAwaiter9.IsCompleted)
					{
						await taskAwaiter9;
						taskAwaiter9 = taskAwaiter10;
						taskAwaiter10 = default(TaskAwaiter);
					}
					taskAwaiter9.GetResult();
					taskAwaiter9 = this.method_18().GetAwaiter();
					if (!taskAwaiter9.IsCompleted)
					{
						await taskAwaiter9;
						taskAwaiter9 = taskAwaiter10;
						taskAwaiter10 = default(TaskAwaiter);
					}
					taskAwaiter9.GetResult();
				}
				continue;
				IL_386:
				if (result2["checkout"]["available_shipping_rates"] != null && result2["checkout"]["available_shipping_rates"].Any<JToken>())
				{
					this.string_20 = result2["checkout"]["available_shipping_rates"][0]["id"].ToString();
				}
				base.method_5("Successfully carted", "#c2c2c2", true, false);
				this.bool_3 = true;
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error adding to cart", "#c2c2c2", true, false);
				TaskAwaiter taskAwaiter9 = base.method_14(Class130.int_1).GetAwaiter();
				if (!taskAwaiter9.IsCompleted)
				{
					await taskAwaiter9;
					taskAwaiter9 = taskAwaiter10;
					taskAwaiter10 = default(TaskAwaiter);
				}
				taskAwaiter9.GetResult();
			}
		}
	}

	// Token: 0x0600074A RID: 1866 RVA: 0x0003D65C File Offset: 0x0003B85C
	public async Task method_37(dynamic object_0)
	{
		base.method_5("Generating checkout url", "#c2c2c2", true, false);
		if (this.string_22 != null)
		{
			object_0 = this.string_22;
		}
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				if (this.jtoken_1["delivery"]["state"].ToString().ToLower().Contains("none"))
				{
					this.jtoken_1["delivery"]["state"] = this.jtoken_1["delivery"]["city"].ToString();
				}
				if (this.jtoken_1["billing"]["state"].ToString().ToLower().Contains("none"))
				{
					this.jtoken_1["billing"]["state"] = this.jtoken_1["billing"]["city"].ToString();
				}
				JObject jobject = new JObject();
				jobject["checkout"] = new JObject();
				jobject["checkout"]["secret"] = true;
				jobject["checkout"]["email"] = this.jtoken_1["payment"]["email"];
				jobject["checkout"]["shipping_address"] = new JObject();
				jobject["checkout"]["shipping_address"]["first_name"] = (string)this.jtoken_1["delivery"]["first_name"];
				jobject["checkout"]["shipping_address"]["last_name"] = (string)this.jtoken_1["delivery"]["last_name"];
				jobject["checkout"]["shipping_address"]["address1"] = (string)this.jtoken_1["delivery"]["addr1"];
				jobject["checkout"]["shipping_address"]["address2"] = (string)this.jtoken_1["delivery"]["addr2"];
				jobject["checkout"]["shipping_address"]["city"] = (string)this.jtoken_1["delivery"]["city"];
				jobject["checkout"]["shipping_address"]["country"] = (string)this.jtoken_1["delivery"]["country"];
				jobject["checkout"]["shipping_address"]["province"] = (string)this.jtoken_1["delivery"]["state"];
				jobject["checkout"]["shipping_address"]["state"] = (string)this.jtoken_1["delivery"]["state"];
				jobject["checkout"]["shipping_address"]["zip"] = (string)this.jtoken_1["delivery"]["zip"];
				jobject["checkout"]["shipping_address"]["phone"] = (string)this.jtoken_1["payment"]["phone"];
				jobject["checkout"]["billing_address"] = new JObject();
				jobject["checkout"]["billing_address"]["first_name"] = (string)this.jtoken_1["billing"]["first_name"];
				jobject["checkout"]["billing_address"]["last_name"] = (string)this.jtoken_1["billing"]["last_name"];
				jobject["checkout"]["billing_address"]["address1"] = (string)this.jtoken_1["billing"]["addr1"];
				jobject["checkout"]["billing_address"]["address2"] = (string)this.jtoken_1["billing"]["addr2"];
				jobject["checkout"]["billing_address"]["city"] = (string)this.jtoken_1["billing"]["city"];
				jobject["checkout"]["billing_address"]["country"] = (string)this.jtoken_1["billing"]["country"];
				jobject["checkout"]["billing_address"]["province"] = (string)this.jtoken_1["billing"]["state"];
				jobject["checkout"]["billing_address"]["state"] = (string)this.jtoken_1["billing"]["state"];
				jobject["checkout"]["billing_address"]["zip"] = (string)this.jtoken_1["billing"]["zip"];
				jobject["checkout"]["billing_address"]["phone"] = (string)this.jtoken_1["payment"]["phone"];
				if (Class52.Class165.callSite_1 == null)
				{
					Class52.Class165.callSite_1 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Class52), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Func<CallSite, object, bool> target = Class52.Class165.callSite_1.Target;
				CallSite callSite_ = Class52.Class165.callSite_1;
				if (Class52.Class165.callSite_0 == null)
				{
					Class52.Class165.callSite_0 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.NotEqual, typeof(Class52), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				if (target(callSite_, Class52.Class165.callSite_0.Target(Class52.Class165.callSite_0, object_0, null)))
				{
					base.method_5("Adding to cart", "yellow", true, false);
					JObject jobject2 = new JObject();
					string propertyName = "variant_id";
					if (Class52.Class165.callSite_2 == null)
					{
						Class52.Class165.callSite_2 = CallSite<Func<CallSite, object, JToken>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(JToken), typeof(Class52)));
					}
					jobject2[propertyName] = Class52.Class165.callSite_2.Target(Class52.Class165.callSite_2, object_0);
					jobject2["quantity"] = 1;
					jobject["checkout"]["line_items"] = new JArray(jobject2);
					this.bool_3 = true;
				}
				HttpResponseMessage httpResponseMessage = await this.class14_0.method_4(this.string_8 + string.Format("{0}/checkouts.json", this.string_24), jobject, false);
				TaskAwaiter<bool> taskAwaiter = this.method_32(httpResponseMessage).GetAwaiter();
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
				TaskAwaiter<string> taskAwaiter3 = httpResponseMessage.smethod_3().GetAwaiter();
				TaskAwaiter<string> taskAwaiter4;
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<string>);
				}
				if (taskAwaiter3.GetResult().Contains("/checkout/poll"))
				{
					httpResponseMessage = await this.method_38(httpResponseMessage.Headers.GetValues("Location").First<string>());
				}
				JObject jobject3 = await httpResponseMessage.smethod_1();
				if (!jobject3.ContainsKey("errors"))
				{
					TaskAwaiter<JObject> taskAwaiter5 = httpResponseMessage.smethod_1().GetAwaiter();
					if (!taskAwaiter5.IsCompleted)
					{
						await taskAwaiter5;
						TaskAwaiter<JObject> taskAwaiter6;
						taskAwaiter5 = taskAwaiter6;
						taskAwaiter6 = default(TaskAwaiter<JObject>);
					}
					JObject result = taskAwaiter5.GetResult();
					this.string_11 = result["checkout"]["web_url"].ToString();
					this.string_10 = result["checkout"]["token"].ToString();
					this.string_9 = "https://" + new Uri(this.string_11).Authority.Replace("/", string.Empty);
					this.string_7 = this.string_9 + string.Format("/{0}/checkouts/", this.string_24) + this.string_10;
					if (result["checkout"]["available_shipping_rates"] != null && result["checkout"]["available_shipping_rates"].Any<JToken>())
					{
						this.string_20 = result["checkout"]["available_shipping_rates"][0]["id"].ToString();
					}
					if (this.bool_3)
					{
						base.method_7((string)result["checkout"]["line_items"][0]["title"], "#c2c2c2");
						base.method_6((string)result["checkout"]["line_items"][0]["variant_title"]);
					}
					break;
				}
				string text = jobject3.ToString();
				if (text.Contains("line_items"))
				{
					if (text.Contains("not_enough_in_stock"))
					{
						base.method_0("Variant sold out", "red", true, (GEnum1)0);
						break;
					}
					base.method_0("Invalid variant", "red", true, (GEnum1)0);
					break;
				}
				else
				{
					if (text.Contains("shipping_address"))
					{
						base.method_0("Invalid shipping address", "red", true, (GEnum1)0);
						break;
					}
					if (text.Contains("billing_address"))
					{
						base.method_0("Invalid billing address", "red", true, (GEnum1)0);
						break;
					}
					taskAwaiter3 = httpResponseMessage.smethod_3().GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						await taskAwaiter3;
						taskAwaiter3 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<string>);
					}
					GClass3.smethod_0(taskAwaiter3.GetResult(), "Uncaught exception");
					throw new Exception();
				}
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error generating checkout url", "#c2c2c2", true, false);
				TaskAwaiter taskAwaiter7 = base.method_14(Class130.int_1).GetAwaiter();
				if (!taskAwaiter7.IsCompleted)
				{
					await taskAwaiter7;
					TaskAwaiter taskAwaiter8;
					taskAwaiter7 = taskAwaiter8;
					taskAwaiter8 = default(TaskAwaiter);
				}
				taskAwaiter7.GetResult();
				base.method_5("Generating checkout url", "#c2c2c2", true, false);
			}
		}
	}

	// Token: 0x0600074B RID: 1867 RVA: 0x0003D6AC File Offset: 0x0003B8AC
	public async Task<HttpResponseMessage> method_38(string string_25)
	{
		this.class14_0.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("Referer", string_25);
		while (!this.bool_1)
		{
			int num = 0;
			TaskAwaiter taskAwaiter2;
			try
			{
				base.method_5("In Queue", "#c2c2c2", true, false);
				HttpResponseMessage httpResponseMessage = await this.class14_0.method_2(string_25, false);
				await this.method_32(httpResponseMessage);
				while (httpResponseMessage.StatusCode != HttpStatusCode.Created)
				{
					TaskAwaiter taskAwaiter = base.method_14(1000).GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						await taskAwaiter;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
					}
					taskAwaiter.GetResult();
					base.method_5("In Queue", "#c2c2c2", true, false);
					TaskAwaiter<HttpResponseMessage> taskAwaiter3 = this.class14_0.method_2(string_25, false).GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						await taskAwaiter3;
						TaskAwaiter<HttpResponseMessage> taskAwaiter4;
						taskAwaiter3 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<HttpResponseMessage>);
					}
					httpResponseMessage = taskAwaiter3.GetResult();
				}
				this.class14_0.httpClient_0.DefaultRequestHeaders.Remove("Referer");
				return httpResponseMessage;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error processing queue", "#c2c2c2", true, false);
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
		return null;
	}

	// Token: 0x0600074C RID: 1868 RVA: 0x0003D6FC File Offset: 0x0003B8FC
	public async Task method_39()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Submitting shipping method...", "#c2c2c2", true, false);
				JObject jobject = new JObject();
				string propertyName = "checkout";
				JObject jobject2 = new JObject();
				string propertyName2 = "shipping_rate";
				JObject jobject3 = new JObject();
				jobject3["id"] = this.string_20;
				jobject2[propertyName2] = jobject3;
				jobject[propertyName] = jobject2;
				jobject["s"] = this.string_14;
				JObject jobject4 = jobject;
				if (this.bool_5)
				{
					jobject4["checkout"]["note"] = this.string_13;
				}
				TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class14_0.method_5(this.string_7, jobject4, false).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter<HttpResponseMessage> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
				}
				HttpResponseMessage result = taskAwaiter.GetResult();
				HttpResponseMessage httpResponseMessage = result;
				TaskAwaiter<bool> taskAwaiter3 = this.method_32(httpResponseMessage).GetAwaiter();
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
				if (!httpResponseMessage.IsSuccessStatusCode && httpResponseMessage.StatusCode != HttpStatusCode.Found)
				{
					throw new Exception();
				}
				base.method_5("Successfully submitted shipping method", "#c2c2c2", true, false);
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
				base.method_5("Error submitting shipping method...", "#c2c2c2", true, false);
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

	// Token: 0x0600074D RID: 1869 RVA: 0x0003D744 File Offset: 0x0003B944
	public async Task method_40(bool bool_9)
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				if (!bool_9)
				{
					base.method_5("Getting payment token", "#c2c2c2", true, false);
				}
				JObject jobject = new JObject();
				jobject["credit_card"] = new JObject();
				jobject["credit_card"]["number"] = ((string)this.jtoken_1["payment"]["card"]["number"]).Replace(" ", string.Empty);
				jobject["credit_card"]["month"] = this.jtoken_1["payment"]["card"]["exp_month"];
				jobject["credit_card"]["year"] = this.jtoken_1["payment"]["card"]["exp_year"];
				jobject["credit_card"]["verification_value"] = this.jtoken_1["payment"]["card"]["cvv"];
				jobject["credit_card"]["first_name"] = this.jtoken_1["billing"]["first_name"];
				jobject["credit_card"]["last_name"] = this.jtoken_1["billing"]["last_name"];
				TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class14_0.method_4("https://elb.deposit.shopifycs.com/sessions", jobject, false).GetAwaiter();
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
				this.string_14 = taskAwaiter3.GetResult()["id"].ToString();
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

	// Token: 0x0600074E RID: 1870 RVA: 0x0003D794 File Offset: 0x0003B994
	public async Task method_41()
	{
		try
		{
			TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class14_0.method_2(this.string_11, false).GetAwaiter();
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
			this.bool_8 = taskAwaiter3.GetResult().Contains("captcha");
		}
		catch
		{
		}
	}

	// Token: 0x0600074F RID: 1871 RVA: 0x0003D7DC File Offset: 0x0003B9DC
	public async Task<string> method_42()
	{
		if (this.bool_8 && (this.string_23 == null || this.stopwatch_0.ElapsedMilliseconds > 110000L))
		{
			base.method_5("Waiting for captcha", "turquoise", true, false);
			this.string_23 = await CaptchaQueue.smethod_0("6LeoeSkTAAAAAA9rkZs5oS82l69OEYjKRZAiKdaF", this.string_11, (string)this.jtoken_0["id"], this.cancellationTokenSource_0.Token);
			this.stopwatch_0.Restart();
		}
		return this.string_23;
	}

	// Token: 0x06000750 RID: 1872 RVA: 0x0003D824 File Offset: 0x0003BA24
	public async Task method_43()
	{
		JObject jobject = new JObject();
		jobject["complete"] = "1";
		string propertyName = "checkout";
		JObject jobject2 = new JObject();
		string propertyName2 = "shipping_rate";
		JObject jobject3 = new JObject();
		jobject3["id"] = this.string_20;
		jobject2[propertyName2] = jobject3;
		jobject[propertyName] = jobject2;
		jobject["s"] = this.string_14;
		JObject jobject4 = jobject;
		if (this.bool_5)
		{
			jobject4["checkout"]["note"] = this.string_13;
		}
		this.string_23 = null;
		int num = 1;
		while (!this.bool_1)
		{
			int num2 = 0;
			TaskAwaiter taskAwaiter6;
			try
			{
				base.method_5("Submitting order", "orange", true, false);
				HttpResponseMessage httpResponseMessage = await this.class14_0.method_5(this.string_11, jobject4, false);
				if (!httpResponseMessage.IsSuccessStatusCode && httpResponseMessage.StatusCode != HttpStatusCode.Found)
				{
					httpResponseMessage.EnsureSuccessStatusCode();
				}
				jobject4.Remove("s");
				jobject4.Remove("g-recaptcha-response");
				jobject4.Remove("checkout");
				TaskAwaiter<bool> taskAwaiter = this.method_32(httpResponseMessage).GetAwaiter();
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
				string text = await httpResponseMessage.smethod_3();
				if (text.ToLower().Contains("captcha validation failed"))
				{
					this.bool_8 = true;
					JObject jobject5 = jobject4;
					TaskAwaiter<string> taskAwaiter3 = this.method_42().GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						await taskAwaiter3;
						TaskAwaiter<string> taskAwaiter4;
						taskAwaiter3 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<string>);
					}
					jobject5["g-recaptcha-response"] = taskAwaiter3.GetResult();
					jobject5 = null;
					continue;
				}
				if (text.Contains("stock_problems"))
				{
					base.method_0("Payment Declined (OOS)", "red", true, (GEnum1)0);
				}
				else if (text.Contains("/account/login") && httpResponseMessage.StatusCode == HttpStatusCode.Found)
				{
					base.method_0("Login required", "red", true, (GEnum1)0);
				}
				else
				{
					if (text.Contains("Calculating taxes"))
					{
						base.method_5("Calculating taxes", "orange", true, false);
						TaskAwaiter taskAwaiter5 = base.method_14(500).GetAwaiter();
						if (!taskAwaiter5.IsCompleted)
						{
							await taskAwaiter5;
							taskAwaiter5 = taskAwaiter6;
							taskAwaiter6 = default(TaskAwaiter);
						}
						taskAwaiter5.GetResult();
						continue;
					}
					if (text.Contains("Please enter a valid credit card number"))
					{
						base.method_0("Invalid credit card number", "red", true, (GEnum1)0);
					}
					else if (text.Contains("Please enter a valid expiry date"))
					{
						base.method_0("Invalid expiry date", "red", true, (GEnum1)0);
					}
					else if (text.Contains("Please check your card details and try again"))
					{
						base.method_0("Invalid credit card", "red", true, (GEnum1)0);
					}
					else
					{
						if (text.Contains("/processing"))
						{
							break;
						}
						if (num > 3)
						{
							base.method_0("Payment error", "red", true, (GEnum1)0);
						}
						JObject jobject6 = new JObject();
						jobject6["complete"] = "1";
						string propertyName3 = "checkout";
						JObject jobject7 = new JObject();
						string propertyName4 = "shipping_rate";
						JObject jobject8 = new JObject();
						jobject8["id"] = this.string_20;
						jobject7[propertyName4] = jobject8;
						jobject6[propertyName3] = jobject7;
						jobject4 = jobject6;
						num++;
						GClass3.smethod_0(text, "Unexpected error");
						continue;
					}
				}
				httpResponseMessage = null;
			}
			catch
			{
				num2 = 1;
			}
			if (num2 == 1)
			{
				base.method_5("Error submitting order", "#c2c2c2", true, false);
				TaskAwaiter taskAwaiter5 = base.method_14(Class130.int_1).GetAwaiter();
				if (!taskAwaiter5.IsCompleted)
				{
					await taskAwaiter5;
					taskAwaiter5 = taskAwaiter6;
					taskAwaiter6 = default(TaskAwaiter);
				}
				taskAwaiter5.GetResult();
			}
		}
	}

	// Token: 0x06000751 RID: 1873 RVA: 0x0003D86C File Offset: 0x0003BA6C
	public async Task method_44()
	{
		this.class14_0.httpClient_0.DefaultRequestHeaders.Remove(this.jobject_0.Properties().First<JProperty>().Name);
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Processing...", "orange", true, false);
				HttpResponseMessage httpResponseMessage = await this.class14_0.method_2(this.string_8 + "/api/checkouts/" + this.string_10 + ".json", false);
				HttpResponseMessage httpResponseMessage_ = httpResponseMessage;
				TaskAwaiter<bool> taskAwaiter = this.method_32(httpResponseMessage_).GetAwaiter();
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
				string text = await httpResponseMessage_.smethod_3();
				if (text.ToLower().Contains("decline"))
				{
					base.method_0("Payment Declined", "red", true, (GEnum1)5);
				}
				else if (text.Contains("processing_error"))
				{
					base.method_0("Payment error", "red", true, (GEnum1)0);
				}
				else if (text.Contains("thank_you"))
				{
					TaskAwaiter<JObject> taskAwaiter3 = httpResponseMessage_.smethod_1().GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						await taskAwaiter3;
						TaskAwaiter<JObject> taskAwaiter4;
						taskAwaiter3 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<JObject>);
					}
					JObject result = taskAwaiter3.GetResult();
					this.string_3 = (string)result["checkout"]["order_id"];
					this.string_4 = (string)result["checkout"]["order_status_url"];
					base.method_0("Successfully checked out", "green", true, (GEnum1)6);
				}
				else if (!text.Contains("is invalid") && !text.Contains("is incorrect"))
				{
					if (text.Contains("Some products became unavailable"))
					{
						base.method_0("Payment Declined (OOS)", "red", true, (GEnum1)0);
					}
					else
					{
						GClass3.smethod_0(text, "Unhandled Exception");
						base.method_0("Payment error", "red", true, (GEnum1)0);
					}
				}
				else
				{
					base.method_0("Invalid card info", "red", true, (GEnum1)0);
				}
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error processing payment...", "#c2c2c2", true, false);
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

	// Token: 0x06000752 RID: 1874 RVA: 0x0003D8B4 File Offset: 0x0003BAB4
	private bool method_45(JToken jtoken_3)
	{
		return (this.string_15.All(new Func<string, bool>(jtoken_3["title"].ToString().ToLower().Contains)) && !this.string_12.Any(new Func<string, bool>(jtoken_3["title"].ToString().ToLower().Contains))) || jtoken_3["id"].ToString() == this.string_17;
	}

	// Token: 0x06000753 RID: 1875 RVA: 0x0003D938 File Offset: 0x0003BB38
	private bool method_46(JToken jtoken_3)
	{
		return new string[]
		{
			jtoken_3["option1"].ToString(),
			jtoken_3["option2"].ToString(),
			jtoken_3["option3"].ToString()
		}.Any(new Func<string, bool>(this.method_47));
	}

	// Token: 0x06000754 RID: 1876 RVA: 0x0000623A File Offset: 0x0000443A
	private bool method_47(string string_25)
	{
		return Class43.smethod_2(this.string_0, string_25);
	}

	// Token: 0x06000755 RID: 1877 RVA: 0x0003D998 File Offset: 0x0003BB98
	private bool method_48(HtmlNode htmlNode_0)
	{
		return this.string_15.All(new Func<string, bool>(htmlNode_0.InnerText.ToLower().Contains)) && !this.string_12.Any(new Func<string, bool>(htmlNode_0.InnerText.ToLower().Contains));
	}

	// Token: 0x06000756 RID: 1878 RVA: 0x0003D9F0 File Offset: 0x0003BBF0
	private bool method_49(JToken jtoken_3)
	{
		return new string[]
		{
			jtoken_3["option1"].ToString(),
			jtoken_3["option2"].ToString(),
			jtoken_3["option3"].ToString()
		}.Any(new Func<string, bool>(this.method_50));
	}

	// Token: 0x06000757 RID: 1879 RVA: 0x00006248 File Offset: 0x00004448
	private bool method_50(string string_25)
	{
		return Class43.smethod_2(this.string_0, string_25.ToString());
	}

	// Token: 0x06000758 RID: 1880 RVA: 0x0000625B File Offset: 0x0000445B
	private bool method_51(JToken jtoken_3)
	{
		return jtoken_3["title"].ToString().smethod_1(this.string_15, this.string_12);
	}

	// Token: 0x06000759 RID: 1881 RVA: 0x0000625B File Offset: 0x0000445B
	private bool method_52(JToken jtoken_3)
	{
		return jtoken_3["title"].ToString().smethod_1(this.string_15, this.string_12);
	}

	// Token: 0x0600075A RID: 1882 RVA: 0x0003DA50 File Offset: 0x0003BC50
	private bool method_53(JToken jtoken_3)
	{
		return new string[]
		{
			jtoken_3["option1"].ToString(),
			jtoken_3["option2"].ToString(),
			jtoken_3["option3"].ToString()
		}.Any(new Func<string, bool>(this.method_54));
	}

	// Token: 0x0600075B RID: 1883 RVA: 0x0000623A File Offset: 0x0000443A
	private bool method_54(string string_25)
	{
		return Class43.smethod_2(this.string_0, string_25);
	}

	// Token: 0x0600075C RID: 1884 RVA: 0x0003D8B4 File Offset: 0x0003BAB4
	private bool method_55(JToken jtoken_3)
	{
		return (this.string_15.All(new Func<string, bool>(jtoken_3["title"].ToString().ToLower().Contains)) && !this.string_12.Any(new Func<string, bool>(jtoken_3["title"].ToString().ToLower().Contains))) || jtoken_3["id"].ToString() == this.string_17;
	}

	// Token: 0x0600075D RID: 1885 RVA: 0x0003DAB0 File Offset: 0x0003BCB0
	private bool method_56(JToken jtoken_3)
	{
		return new string[]
		{
			jtoken_3["option1"].ToString(),
			jtoken_3["option2"].ToString(),
			jtoken_3["option3"].ToString()
		}.Any(new Func<string, bool>(this.method_57));
	}

	// Token: 0x0600075E RID: 1886 RVA: 0x0000623A File Offset: 0x0000443A
	private bool method_57(string string_25)
	{
		return Class43.smethod_2(this.string_0, string_25);
	}

	// Token: 0x0600075F RID: 1887 RVA: 0x0003DB10 File Offset: 0x0003BD10
	private bool method_58(JToken jtoken_3)
	{
		return (this.string_15.All(new Func<string, bool>(jtoken_3["title"].ToString().ToLower().Contains)) && !this.string_12.Any(new Func<string, bool>(jtoken_3["title"].ToString().ToLower().Contains))) || jtoken_3["product_id"].ToString() == this.string_17;
	}

	// Token: 0x06000760 RID: 1888 RVA: 0x0000627E File Offset: 0x0000447E
	private bool method_59(JToken jtoken_3)
	{
		return Class43.smethod_2(this.string_0, jtoken_3["title"].ToString());
	}

	// Token: 0x06000761 RID: 1889 RVA: 0x0000629B File Offset: 0x0000449B
	private bool method_60(JToken jtoken_3)
	{
		return jtoken_3["options"].Any(new Func<JToken, bool>(this.method_61));
	}

	// Token: 0x06000762 RID: 1890 RVA: 0x00006248 File Offset: 0x00004448
	private bool method_61(JToken jtoken_3)
	{
		return Class43.smethod_2(this.string_0, jtoken_3.ToString());
	}

	// Token: 0x04000592 RID: 1426
	private JObject jobject_0;

	// Token: 0x04000593 RID: 1427
	private JToken jtoken_2;

	// Token: 0x04000594 RID: 1428
	private string string_7;

	// Token: 0x04000595 RID: 1429
	private string string_8;

	// Token: 0x04000596 RID: 1430
	private bool bool_3;

	// Token: 0x04000597 RID: 1431
	private string string_9;

	// Token: 0x04000598 RID: 1432
	private string string_10;

	// Token: 0x04000599 RID: 1433
	private string string_11;

	// Token: 0x0400059A RID: 1434
	private bool bool_4;

	// Token: 0x0400059B RID: 1435
	private readonly string[] string_12;

	// Token: 0x0400059C RID: 1436
	private readonly bool bool_5;

	// Token: 0x0400059D RID: 1437
	private string string_13;

	// Token: 0x0400059E RID: 1438
	private string string_14;

	// Token: 0x0400059F RID: 1439
	private readonly string[] string_15;

	// Token: 0x040005A0 RID: 1440
	private string string_16;

	// Token: 0x040005A1 RID: 1441
	private string string_17;

	// Token: 0x040005A2 RID: 1442
	private string string_18;

	// Token: 0x040005A3 RID: 1443
	private readonly string string_19;

	// Token: 0x040005A4 RID: 1444
	private readonly bool bool_6;

	// Token: 0x040005A5 RID: 1445
	private string string_20;

	// Token: 0x040005A6 RID: 1446
	private string string_21;

	// Token: 0x040005A7 RID: 1447
	private string string_22;

	// Token: 0x040005A8 RID: 1448
	private bool bool_7;

	// Token: 0x040005A9 RID: 1449
	private JObject jobject_1;

	// Token: 0x040005AA RID: 1450
	private string string_23;

	// Token: 0x040005AB RID: 1451
	private Stopwatch stopwatch_0;

	// Token: 0x040005AC RID: 1452
	private bool bool_8;

	// Token: 0x040005AD RID: 1453
	private string string_24;

	// Token: 0x0200013C RID: 316
	[Serializable]
	private sealed class Class162
	{
		// Token: 0x06000765 RID: 1893 RVA: 0x000062C5 File Offset: 0x000044C5
		internal bool method_0(HtmlNode htmlNode_0)
		{
			return htmlNode_0.InnerHtml.Contains("KANYE");
		}

		// Token: 0x06000766 RID: 1894 RVA: 0x000062D7 File Offset: 0x000044D7
		internal string method_1(HtmlNode htmlNode_0)
		{
			return htmlNode_0.InnerHtml;
		}

		// Token: 0x06000767 RID: 1895 RVA: 0x000062DF File Offset: 0x000044DF
		internal bool method_2(JToken jtoken_0)
		{
			return jtoken_0.ToString() == "k-exclusive";
		}

		// Token: 0x06000768 RID: 1896 RVA: 0x000062F1 File Offset: 0x000044F1
		internal bool method_3(HtmlNode htmlNode_0)
		{
			return htmlNode_0.InnerHtml.Contains("atob");
		}

		// Token: 0x06000769 RID: 1897 RVA: 0x00006303 File Offset: 0x00004503
		internal bool method_4(HtmlNode htmlNode_0)
		{
			return htmlNode_0.Attributes["name"].Value.Contains("properties");
		}

		// Token: 0x0600076A RID: 1898 RVA: 0x00006324 File Offset: 0x00004524
		internal bool method_5(string string_0)
		{
			return string_0[0] != '-';
		}

		// Token: 0x0600076B RID: 1899 RVA: 0x00006334 File Offset: 0x00004534
		internal bool method_6(string string_0)
		{
			return string_0[0] == '-';
		}

		// Token: 0x0600076C RID: 1900 RVA: 0x00006341 File Offset: 0x00004541
		internal string method_7(string string_0)
		{
			return string_0.Replace("-", string.Empty);
		}

		// Token: 0x040005AE RID: 1454
		public static readonly Class52.Class162 class162_0 = new Class52.Class162();

		// Token: 0x040005AF RID: 1455
		public static Func<HtmlNode, bool> func_0;

		// Token: 0x040005B0 RID: 1456
		public static Func<HtmlNode, string> func_1;

		// Token: 0x040005B1 RID: 1457
		public static Func<JToken, bool> func_2;

		// Token: 0x040005B2 RID: 1458
		public static Func<HtmlNode, bool> func_3;

		// Token: 0x040005B3 RID: 1459
		public static Func<HtmlNode, bool> func_4;

		// Token: 0x040005B4 RID: 1460
		public static Func<string, bool> func_5;

		// Token: 0x040005B5 RID: 1461
		public static Func<string, bool> func_6;

		// Token: 0x040005B6 RID: 1462
		public static Func<string, string> func_7;
	}

	// Token: 0x0200013D RID: 317
	[StructLayout(LayoutKind.Auto)]
	private struct Struct115 : IAsyncStateMachine
	{
		// Token: 0x0600076D RID: 1901 RVA: 0x0003DB94 File Offset: 0x0003BD94
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class52 @class = this;
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
							goto IL_CE;
						}
						taskAwaiter6 = @class.class14_0.method_2(@class.string_11, false).GetAwaiter();
						if (!taskAwaiter6.IsCompleted)
						{
							num2 = 0;
							taskAwaiter2 = taskAwaiter6;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class52.Struct115>(ref taskAwaiter6, ref this);
							return;
						}
					}
					else
					{
						taskAwaiter6 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
						num2 = -1;
					}
					taskAwaiter5 = taskAwaiter6.GetResult().smethod_3().GetAwaiter();
					if (!taskAwaiter5.IsCompleted)
					{
						num2 = 1;
						taskAwaiter4 = taskAwaiter5;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class52.Struct115>(ref taskAwaiter5, ref this);
						return;
					}
					IL_CE:
					string result = taskAwaiter5.GetResult();
					@class.bool_8 = result.Contains("captcha");
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
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x0600076E RID: 1902 RVA: 0x00006353 File Offset: 0x00004553
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040005B7 RID: 1463
		public int int_0;

		// Token: 0x040005B8 RID: 1464
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040005B9 RID: 1465
		public Class52 class52_0;

		// Token: 0x040005BA RID: 1466
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040005BB RID: 1467
		private TaskAwaiter<string> taskAwaiter_1;
	}

	// Token: 0x0200013E RID: 318
	[StructLayout(LayoutKind.Auto)]
	private struct Struct116 : IAsyncStateMachine
	{
		// Token: 0x0600076F RID: 1903 RVA: 0x0003DCDC File Offset: 0x0003BEDC
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class52 @class = this;
			try
			{
				if (num <= 1)
				{
					goto IL_4F6;
				}
				if (num != 2)
				{
					goto IL_4EB;
				}
				TaskAwaiter taskAwaiter7 = taskAwaiter6;
				taskAwaiter6 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_4E4:
				taskAwaiter7.GetResult();
				IL_4EB:
				if (@class.bool_1)
				{
					goto IL_538;
				}
				int num4 = 0;
				IL_4F6:
				try
				{
					TaskAwaiter<string> taskAwaiter8;
					string text;
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
							goto IL_13D;
						}
						if (@class.string_18 == null && string_25 == null)
						{
							goto IL_538;
						}
						@class.method_5("Getting token", "#c2c2c2", true, false);
						text = string_25;
						if (text != null)
						{
							goto IL_146;
						}
						taskAwaiter9 = GClass2.smethod_1(@class.string_18, null, true).GetAwaiter();
						if (!taskAwaiter9.IsCompleted)
						{
							int num6 = 0;
							num = 0;
							num2 = num6;
							taskAwaiter2 = taskAwaiter9;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class52.Struct116>(ref taskAwaiter9, ref this);
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
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class52.Struct116>(ref taskAwaiter8, ref this);
						return;
					}
					IL_13D:
					text = taskAwaiter8.GetResult();
					IL_146:
					string text2 = text;
					HtmlDocument htmlDocument = new HtmlDocument();
					htmlDocument.LoadHtml(text2);
					if ((string)@class.jtoken_0["store"] == "Kith")
					{
						@class.jobject_1[text2.Replace(" ", string.Empty).Split(new string[]
						{
							"theme.htikb="
						}, StringSplitOptions.None)[1].Split(new char[]
						{
							';'
						})[0].Replace("\"", string.Empty).Replace("'", string.Empty)] = text2.Replace(" ", string.Empty).Split(new string[]
						{
							"theme.htikc="
						}, StringSplitOptions.None)[1].Split(new char[]
						{
							';'
						})[0].Replace("\"", string.Empty).Replace("'", string.Empty);
					}
					else if (@class.jtoken_0["store"].ToString().Contains("DSM"))
					{
						HtmlNode htmlNode = htmlDocument.DocumentNode.SelectNodes("//script").FirstOrDefault(new Func<HtmlNode, bool>(Class52.Class162.class162_0.method_3));
						if (htmlNode != null)
						{
							string text3 = string.Empty;
							string text4 = string.Empty;
							foreach (string text5 in htmlNode.InnerHtml.Split(new string[]
							{
								"atob('"
							}, StringSplitOptions.None).Skip(1).ToArray<string>())
							{
								try
								{
									string text6 = text5.Split(new string[]
									{
										"')"
									}, StringSplitOptions.None)[0];
									int num9 = text6.Length % 4;
									if (num9 > 0)
									{
										text6 += new string('=', 4 - num9);
									}
									string @string = Encoding.UTF8.GetString(Convert.FromBase64String(text6));
									if (@string.Contains("properties"))
									{
										text3 = @string.Split(new string[]
										{
											"properties["
										}, StringSplitOptions.None)[1].Split(new char[]
										{
											']'
										})[0];
									}
									else if (!@string.Contains("product"))
									{
										text4 = @string;
									}
								}
								catch
								{
								}
							}
							string[] array2 = htmlNode.InnerHtml.Split(new string[]
							{
								".val('"
							}, StringSplitOptions.None);
							if (array2.Count<string>() > 1)
							{
								text4 = array2[1].Split(new string[]
								{
									"')"
								}, StringSplitOptions.None)[0];
							}
							if (text3 != null && text4 != null)
							{
								@class.jobject_1[text3] = text4;
							}
						}
					}
					HtmlNodeCollection htmlNodeCollection = htmlDocument.DocumentNode.SelectNodes("//input[@name]");
					HtmlNode htmlNode2;
					if (htmlNodeCollection == null)
					{
						htmlNode2 = null;
					}
					else
					{
						htmlNode2 = htmlNodeCollection.FirstOrDefault(new Func<HtmlNode, bool>(Class52.Class162.class162_0.method_4));
					}
					HtmlNode htmlNode3 = htmlNode2;
					if (htmlNode3 != null)
					{
						@class.jobject_1[htmlNode3.Attributes["name"].Value.Replace("properties[", string.Empty).Replace("]", string.Empty)] = htmlNode3.Attributes["value"].Value;
					}
					@class.method_5("Successfully found token: " + htmlNode3, "#c2c2c2", true, false);
					goto IL_538;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_4EB;
				}
				@class.method_5("Error getting token", "#c2c2c2", true, false);
				taskAwaiter7 = @class.method_14(Class130.int_1).GetAwaiter();
				if (taskAwaiter7.IsCompleted)
				{
					goto IL_4E4;
				}
				int num10 = 2;
				num = 2;
				num2 = num10;
				taskAwaiter6 = taskAwaiter7;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct116>(ref taskAwaiter7, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_538:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000770 RID: 1904 RVA: 0x00006361 File Offset: 0x00004561
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040005BC RID: 1468
		public int int_0;

		// Token: 0x040005BD RID: 1469
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040005BE RID: 1470
		public Class52 class52_0;

		// Token: 0x040005BF RID: 1471
		public string string_0;

		// Token: 0x040005C0 RID: 1472
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040005C1 RID: 1473
		private TaskAwaiter<string> taskAwaiter_1;

		// Token: 0x040005C2 RID: 1474
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x0200013F RID: 319
	[StructLayout(LayoutKind.Auto)]
	private struct Struct117 : IAsyncStateMachine
	{
		// Token: 0x06000771 RID: 1905 RVA: 0x0003E280 File Offset: 0x0003C480
		void IAsyncStateMachine.MoveNext()
		{
			int num3;
			int num2 = num3;
			Class52 @class = this;
			try
			{
				TaskAwaiter taskAwaiter3;
				if (num2 > 2)
				{
					if (num2 != 3)
					{
						@class.method_5("Waiting for product", "#c2c2c2", true, false);
						goto IL_287;
					}
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					int num4 = -1;
					num2 = -1;
					num3 = num4;
					goto IL_26E;
				}
				IL_4E:
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter4;
					TaskAwaiter<string> taskAwaiter6;
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
						TaskAwaiter<string> taskAwaiter7;
						taskAwaiter6 = taskAwaiter7;
						taskAwaiter7 = default(TaskAwaiter<string>);
						int num6 = -1;
						num2 = -1;
						num3 = num6;
						goto IL_140;
					}
					case 2:
					{
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num7 = -1;
						num2 = -1;
						num3 = num7;
						goto IL_228;
					}
					default:
						if (@class.method_34())
						{
							goto IL_2E5;
						}
						taskAwaiter4 = GClass2.smethod_1(@class.string_8, null, true).GetAwaiter();
						if (!taskAwaiter4.IsCompleted)
						{
							int num8 = 0;
							num2 = 0;
							num3 = num8;
							TaskAwaiter<HttpResponseMessage> taskAwaiter5 = taskAwaiter4;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class52.Struct117>(ref taskAwaiter4, ref this);
							return;
						}
						break;
					}
					HttpResponseMessage result = taskAwaiter4.GetResult();
					htmlDocument = new HtmlDocument();
					htmlDocument2 = htmlDocument;
					taskAwaiter6 = result.smethod_3().GetAwaiter();
					if (!taskAwaiter6.IsCompleted)
					{
						int num9 = 1;
						num2 = 1;
						num3 = num9;
						TaskAwaiter<string> taskAwaiter7 = taskAwaiter6;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class52.Struct117>(ref taskAwaiter6, ref this);
						return;
					}
					IL_140:
					string result2 = taskAwaiter6.GetResult();
					htmlDocument2.LoadHtml(result2);
					htmlDocument2 = null;
					HtmlNodeCollection htmlNodeCollection = htmlDocument.DocumentNode.SelectNodes("//div[@class='h4 grid-view-item__title']");
					HtmlNode htmlNode = (htmlNodeCollection != null) ? htmlNodeCollection.FirstOrDefault(new Func<HtmlNode, bool>(@class.method_48)) : null;
					if (htmlNode != null)
					{
						@class.method_7(htmlNode.InnerText, "#c2c2c2");
						@class.string_18 = @class.string_8 + htmlNode.ParentNode.Attributes["href"].Value;
						goto IL_2E5;
					}
					taskAwaiter3 = @class.method_14(Class130.int_0).GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						int num10 = 2;
						num2 = 2;
						num3 = num10;
						taskAwaiter2 = taskAwaiter3;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct117>(ref taskAwaiter3, ref this);
						return;
					}
					IL_228:
					taskAwaiter3.GetResult();
					@class.method_5("Waiting for product", "#c2c2c2", false, false);
					htmlDocument = null;
					goto IL_29B;
				}
				catch
				{
					num = 1;
					goto IL_29B;
				}
				IL_254:
				taskAwaiter3 = @class.method_14(Class130.int_0).GetAwaiter();
				if (taskAwaiter3.IsCompleted)
				{
					goto IL_26E;
				}
				int num11 = 3;
				num2 = 3;
				num3 = num11;
				taskAwaiter2 = taskAwaiter3;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct117>(ref taskAwaiter3, ref this);
				return;
				IL_29B:
				int num12 = num;
				if (num12 == 1)
				{
					goto IL_254;
				}
				goto IL_287;
				IL_26E:
				taskAwaiter3.GetResult();
				@class.method_5("Waiting for product", "#c2c2c2", false, false);
				IL_287:
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
			IL_2E5:
			num3 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000772 RID: 1906 RVA: 0x0000636F File Offset: 0x0000456F
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040005C3 RID: 1475
		public int int_0;

		// Token: 0x040005C4 RID: 1476
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040005C5 RID: 1477
		public Class52 class52_0;

		// Token: 0x040005C6 RID: 1478
		private int int_1;

		// Token: 0x040005C7 RID: 1479
		private HtmlDocument htmlDocument_0;

		// Token: 0x040005C8 RID: 1480
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040005C9 RID: 1481
		private HtmlDocument htmlDocument_1;

		// Token: 0x040005CA RID: 1482
		private TaskAwaiter<string> taskAwaiter_1;

		// Token: 0x040005CB RID: 1483
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x02000140 RID: 320
	[StructLayout(LayoutKind.Auto)]
	private struct Struct118 : IAsyncStateMachine
	{
		// Token: 0x06000773 RID: 1907 RVA: 0x0003E5BC File Offset: 0x0003C7BC
		void IAsyncStateMachine.MoveNext()
		{
			int num4;
			int num3 = num4;
			Class52 @class = this;
			try
			{
				TaskAwaiter taskAwaiter7;
				if (num3 > 4)
				{
					if (num3 != 5)
					{
						JObject jobject6 = new JObject();
						jobject6["complete"] = "1";
						string propertyName = "checkout";
						JObject jobject7 = new JObject();
						string propertyName2 = "shipping_rate";
						JObject jobject8 = new JObject();
						jobject8["id"] = @class.string_20;
						jobject7[propertyName2] = jobject8;
						jobject6[propertyName] = jobject7;
						jobject6["s"] = @class.string_14;
						jobject4 = jobject6;
						if (@class.bool_5)
						{
							jobject4["checkout"]["note"] = @class.string_13;
						}
						@class.string_23 = null;
						num = 1;
						goto IL_5AD;
					}
					taskAwaiter7 = taskAwaiter6;
					taskAwaiter6 = default(TaskAwaiter);
					int num5 = -1;
					num3 = -1;
					num4 = num5;
					goto IL_598;
				}
				IL_EA:
				int num15;
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter8;
					TaskAwaiter<bool> taskAwaiter10;
					TaskAwaiter<string> taskAwaiter11;
					switch (num3)
					{
					case 0:
					{
						TaskAwaiter<HttpResponseMessage> taskAwaiter9;
						taskAwaiter8 = taskAwaiter9;
						taskAwaiter9 = default(TaskAwaiter<HttpResponseMessage>);
						int num6 = -1;
						num3 = -1;
						num4 = num6;
						break;
					}
					case 1:
					{
						taskAwaiter10 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<bool>);
						int num7 = -1;
						num3 = -1;
						num4 = num7;
						goto IL_24C;
					}
					case 2:
					{
						taskAwaiter11 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<string>);
						int num8 = -1;
						num3 = -1;
						num4 = num8;
						goto IL_2B3;
					}
					case 3:
					{
						taskAwaiter11 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<string>);
						int num9 = -1;
						num3 = -1;
						num4 = num9;
						goto IL_505;
					}
					case 4:
					{
						taskAwaiter7 = taskAwaiter6;
						taskAwaiter6 = default(TaskAwaiter);
						int num10 = -1;
						num3 = -1;
						num4 = num10;
						goto IL_54B;
					}
					default:
						@class.method_5("Submitting order", "orange", true, false);
						taskAwaiter8 = @class.class14_0.method_5(@class.string_11, jobject4, false).GetAwaiter();
						if (!taskAwaiter8.IsCompleted)
						{
							int num11 = 0;
							num3 = 0;
							num4 = num11;
							TaskAwaiter<HttpResponseMessage> taskAwaiter9 = taskAwaiter8;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class52.Struct118>(ref taskAwaiter8, ref this);
							return;
						}
						break;
					}
					HttpResponseMessage result = taskAwaiter8.GetResult();
					httpResponseMessage = result;
					if (!httpResponseMessage.IsSuccessStatusCode && httpResponseMessage.StatusCode != HttpStatusCode.Found)
					{
						httpResponseMessage.EnsureSuccessStatusCode();
					}
					jobject4.Remove("s");
					jobject4.Remove("g-recaptcha-response");
					jobject4.Remove("checkout");
					taskAwaiter10 = @class.method_32(httpResponseMessage).GetAwaiter();
					if (!taskAwaiter10.IsCompleted)
					{
						int num12 = 1;
						num3 = 1;
						num4 = num12;
						taskAwaiter2 = taskAwaiter10;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, Class52.Struct118>(ref taskAwaiter10, ref this);
						return;
					}
					IL_24C:
					if (taskAwaiter10.GetResult())
					{
						goto IL_5AD;
					}
					taskAwaiter11 = httpResponseMessage.smethod_3().GetAwaiter();
					if (!taskAwaiter11.IsCompleted)
					{
						int num13 = 2;
						num3 = 2;
						num4 = num13;
						taskAwaiter4 = taskAwaiter11;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class52.Struct118>(ref taskAwaiter11, ref this);
						return;
					}
					IL_2B3:
					string result2 = taskAwaiter11.GetResult();
					if (!result2.ToLower().Contains("captcha validation failed"))
					{
						if (result2.Contains("stock_problems"))
						{
							@class.method_0("Payment Declined (OOS)", "red", true, (GEnum1)0);
						}
						else if (result2.Contains("/account/login") && httpResponseMessage.StatusCode == HttpStatusCode.Found)
						{
							@class.method_0("Login required", "red", true, (GEnum1)0);
						}
						else if (result2.Contains("Calculating taxes"))
						{
							@class.method_5("Calculating taxes", "orange", true, false);
							taskAwaiter7 = @class.method_14(500).GetAwaiter();
							if (!taskAwaiter7.IsCompleted)
							{
								int num14 = 4;
								num3 = 4;
								num4 = num14;
								taskAwaiter6 = taskAwaiter7;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct118>(ref taskAwaiter7, ref this);
								return;
							}
							goto IL_54B;
						}
						else if (result2.Contains("Please enter a valid credit card number"))
						{
							@class.method_0("Invalid credit card number", "red", true, (GEnum1)0);
						}
						else if (result2.Contains("Please enter a valid expiry date"))
						{
							@class.method_0("Invalid expiry date", "red", true, (GEnum1)0);
						}
						else if (result2.Contains("Please check your card details and try again"))
						{
							@class.method_0("Invalid credit card", "red", true, (GEnum1)0);
						}
						else
						{
							if (result2.Contains("/processing"))
							{
								goto IL_5F3;
							}
							if (num > 3)
							{
								@class.method_0("Payment error", "red", true, (GEnum1)0);
							}
							JObject jobject9 = new JObject();
							jobject9["complete"] = "1";
							string propertyName3 = "checkout";
							JObject jobject10 = new JObject();
							string propertyName4 = "shipping_rate";
							JObject jobject11 = new JObject();
							jobject11["id"] = @class.string_20;
							jobject10[propertyName4] = jobject11;
							jobject9[propertyName3] = jobject10;
							jobject4 = jobject9;
							num15 = num;
							num = num15 + 1;
							GClass3.smethod_0(result2, "Unexpected error");
							goto IL_5AD;
						}
						httpResponseMessage = null;
						goto IL_55E;
					}
					@class.bool_8 = true;
					jobject5 = jobject4;
					taskAwaiter11 = @class.method_42().GetAwaiter();
					if (!taskAwaiter11.IsCompleted)
					{
						int num16 = 3;
						num3 = 3;
						num4 = num16;
						taskAwaiter4 = taskAwaiter11;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class52.Struct118>(ref taskAwaiter11, ref this);
						return;
					}
					IL_505:
					string result3 = taskAwaiter11.GetResult();
					jobject5["g-recaptcha-response"] = result3;
					jobject5 = null;
					goto IL_5AD;
					IL_54B:
					taskAwaiter7.GetResult();
					goto IL_5AD;
				}
				catch
				{
					num2 = 1;
				}
				IL_55E:
				num15 = num2;
				if (num15 != 1)
				{
					goto IL_5AD;
				}
				@class.method_5("Error submitting order", "#c2c2c2", true, false);
				taskAwaiter7 = @class.method_14(Class130.int_1).GetAwaiter();
				if (!taskAwaiter7.IsCompleted)
				{
					int num17 = 5;
					num3 = 5;
					num4 = num17;
					taskAwaiter6 = taskAwaiter7;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct118>(ref taskAwaiter7, ref this);
					return;
				}
				IL_598:
				taskAwaiter7.GetResult();
				IL_5AD:
				if (!@class.bool_1)
				{
					num2 = 0;
					goto IL_EA;
				}
			}
			catch (Exception exception)
			{
				num4 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_5F3:
			num4 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000774 RID: 1908 RVA: 0x0000637D File Offset: 0x0000457D
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040005CC RID: 1484
		public int int_0;

		// Token: 0x040005CD RID: 1485
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040005CE RID: 1486
		public Class52 class52_0;

		// Token: 0x040005CF RID: 1487
		private JObject jobject_0;

		// Token: 0x040005D0 RID: 1488
		private int int_1;

		// Token: 0x040005D1 RID: 1489
		private int int_2;

		// Token: 0x040005D2 RID: 1490
		private HttpResponseMessage httpResponseMessage_0;

		// Token: 0x040005D3 RID: 1491
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040005D4 RID: 1492
		private TaskAwaiter<bool> taskAwaiter_1;

		// Token: 0x040005D5 RID: 1493
		private TaskAwaiter<string> taskAwaiter_2;

		// Token: 0x040005D6 RID: 1494
		private JObject jobject_1;

		// Token: 0x040005D7 RID: 1495
		private TaskAwaiter taskAwaiter_3;
	}

	// Token: 0x02000141 RID: 321
	private sealed class Class163
	{
		// Token: 0x06000776 RID: 1910 RVA: 0x0000638B File Offset: 0x0000458B
		internal bool method_0(JProperty jproperty_0)
		{
			return jproperty_0.Name.ToLower() == this.jtoken_0["store"].ToString().ToLower();
		}

		// Token: 0x040005D8 RID: 1496
		public JToken jtoken_0;
	}

	// Token: 0x02000142 RID: 322
	[StructLayout(LayoutKind.Auto)]
	private struct Struct119 : IAsyncStateMachine
	{
		// Token: 0x06000777 RID: 1911 RVA: 0x0003EC04 File Offset: 0x0003CE04
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class52 @class = this;
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
					goto IL_2F0;
				case 2:
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					num2 = -1;
					goto IL_34B;
				case 3:
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					num2 = -1;
					goto IL_373;
				case 4:
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					num2 = -1;
					goto IL_39B;
				case 5:
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					num2 = -1;
					goto IL_3F6;
				case 6:
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					num2 = -1;
					goto IL_41B;
				case 7:
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					num2 = -1;
					goto IL_482;
				case 8:
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					num2 = -1;
					goto IL_4AA;
				case 9:
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					num2 = -1;
					goto IL_4CF;
				case 10:
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					num2 = -1;
					goto IL_4F4;
				case 11:
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					num2 = -1;
					goto IL_557;
				default:
					if (@class.bool_7)
					{
						if (@class.string_8.Contains("yeezysupply"))
						{
							taskAwaiter3 = @class.method_22().GetAwaiter();
							if (!taskAwaiter3.IsCompleted)
							{
								num2 = 0;
								taskAwaiter2 = taskAwaiter3;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct119>(ref taskAwaiter3, ref this);
								return;
							}
						}
						else if (@class.string_8.Contains("doverstreetmarket"))
						{
							taskAwaiter3 = @class.method_20().GetAwaiter();
							if (!taskAwaiter3.IsCompleted)
							{
								num2 = 1;
								taskAwaiter2 = taskAwaiter3;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct119>(ref taskAwaiter3, ref this);
								return;
							}
							goto IL_2F0;
						}
						else if (@class.string_21.Contains(".json"))
						{
							taskAwaiter3 = @class.method_23().GetAwaiter();
							if (!taskAwaiter3.IsCompleted)
							{
								num2 = 3;
								taskAwaiter2 = taskAwaiter3;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct119>(ref taskAwaiter3, ref this);
								return;
							}
							goto IL_373;
						}
						else if (@class.string_21.Contains(".atom"))
						{
							taskAwaiter3 = @class.method_25().GetAwaiter();
							if (!taskAwaiter3.IsCompleted)
							{
								num2 = 4;
								taskAwaiter2 = taskAwaiter3;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct119>(ref taskAwaiter3, ref this);
								return;
							}
							goto IL_39B;
						}
						else
						{
							if (!@class.string_21.Contains(".oembed"))
							{
								goto IL_422;
							}
							taskAwaiter3 = @class.method_24().GetAwaiter();
							if (!taskAwaiter3.IsCompleted)
							{
								num2 = 6;
								taskAwaiter2 = taskAwaiter3;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct119>(ref taskAwaiter3, ref this);
								return;
							}
							goto IL_41B;
						}
					}
					else if (@class.string_8.Contains("yeezysupply"))
					{
						taskAwaiter3 = @class.method_22().GetAwaiter();
						if (!taskAwaiter3.IsCompleted)
						{
							num2 = 8;
							taskAwaiter2 = taskAwaiter3;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct119>(ref taskAwaiter3, ref this);
							return;
						}
						goto IL_4AA;
					}
					else if (@class.string_8.Contains("doverstreetmarket"))
					{
						taskAwaiter3 = @class.method_21().GetAwaiter();
						if (!taskAwaiter3.IsCompleted)
						{
							num2 = 9;
							taskAwaiter2 = taskAwaiter3;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct119>(ref taskAwaiter3, ref this);
							return;
						}
						goto IL_4CF;
					}
					else
					{
						taskAwaiter3 = @class.method_26().GetAwaiter();
						if (!taskAwaiter3.IsCompleted)
						{
							num2 = 10;
							taskAwaiter2 = taskAwaiter3;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct119>(ref taskAwaiter3, ref this);
							return;
						}
						goto IL_4F4;
					}
					break;
				}
				taskAwaiter3.GetResult();
				goto IL_422;
				IL_2F0:
				taskAwaiter3.GetResult();
				taskAwaiter3 = @class.method_21().GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					num2 = 2;
					taskAwaiter2 = taskAwaiter3;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct119>(ref taskAwaiter3, ref this);
					return;
				}
				IL_34B:
				taskAwaiter3.GetResult();
				goto IL_422;
				IL_373:
				taskAwaiter3.GetResult();
				goto IL_422;
				IL_39B:
				taskAwaiter3.GetResult();
				taskAwaiter3 = @class.method_26().GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					num2 = 5;
					taskAwaiter2 = taskAwaiter3;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct119>(ref taskAwaiter3, ref this);
					return;
				}
				IL_3F6:
				taskAwaiter3.GetResult();
				goto IL_422;
				IL_41B:
				taskAwaiter3.GetResult();
				IL_422:
				if (!@class.bool_4)
				{
					goto IL_55E;
				}
				taskAwaiter3 = @class.method_30(null).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					num2 = 7;
					taskAwaiter2 = taskAwaiter3;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct119>(ref taskAwaiter3, ref this);
					return;
				}
				IL_482:
				taskAwaiter3.GetResult();
				goto IL_55E;
				IL_4AA:
				taskAwaiter3.GetResult();
				goto IL_4FB;
				IL_4CF:
				taskAwaiter3.GetResult();
				goto IL_4FB;
				IL_4F4:
				taskAwaiter3.GetResult();
				IL_4FB:
				if (!@class.bool_4)
				{
					goto IL_55E;
				}
				taskAwaiter3 = @class.method_30(null).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					num2 = 11;
					taskAwaiter2 = taskAwaiter3;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct119>(ref taskAwaiter3, ref this);
					return;
				}
				IL_557:
				taskAwaiter3.GetResult();
				IL_55E:
				@class.method_5("Found variant: " + @class.string_22, "#c2c2c2", true, false);
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

		// Token: 0x06000778 RID: 1912 RVA: 0x000063B7 File Offset: 0x000045B7
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040005D9 RID: 1497
		public int int_0;

		// Token: 0x040005DA RID: 1498
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040005DB RID: 1499
		public Class52 class52_0;

		// Token: 0x040005DC RID: 1500
		private TaskAwaiter taskAwaiter_0;
	}

	// Token: 0x02000143 RID: 323
	[StructLayout(LayoutKind.Auto)]
	private struct Struct120 : IAsyncStateMachine
	{
		// Token: 0x06000779 RID: 1913 RVA: 0x0003F1D4 File Offset: 0x0003D3D4
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class52 @class = this;
			bool result;
			try
			{
				TaskAwaiter taskAwaiter5;
				TaskAwaiter<string> taskAwaiter6;
				switch (num)
				{
				case 0:
					taskAwaiter5 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					num2 = -1;
					break;
				case 1:
					taskAwaiter6 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<string>);
					num2 = -1;
					goto IL_107;
				case 2:
					taskAwaiter5 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					num2 = -1;
					goto IL_174;
				default:
					if (httpResponseMessage_0.StatusCode == (HttpStatusCode)430)
					{
						@class.method_5("Banned retry in 5", "#c2c2c2", true, false);
						taskAwaiter5 = @class.method_14(5000).GetAwaiter();
						if (!taskAwaiter5.IsCompleted)
						{
							num2 = 0;
							taskAwaiter2 = taskAwaiter5;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct120>(ref taskAwaiter5, ref this);
							return;
						}
					}
					else
					{
						taskAwaiter6 = httpResponseMessage_0.smethod_3().GetAwaiter();
						if (!taskAwaiter6.IsCompleted)
						{
							num2 = 1;
							taskAwaiter4 = taskAwaiter6;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class52.Struct120>(ref taskAwaiter6, ref this);
							return;
						}
						goto IL_107;
					}
					break;
				}
				taskAwaiter5.GetResult();
				result = true;
				goto IL_198;
				IL_107:
				if (!taskAwaiter6.GetResult().Contains("Online Store channel is locked"))
				{
					result = false;
					goto IL_198;
				}
				taskAwaiter5 = @class.method_14(Class130.int_0).GetAwaiter();
				if (!taskAwaiter5.IsCompleted)
				{
					num2 = 2;
					taskAwaiter2 = taskAwaiter5;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct120>(ref taskAwaiter5, ref this);
					return;
				}
				IL_174:
				taskAwaiter5.GetResult();
				result = true;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_198:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult(result);
		}

		// Token: 0x0600077A RID: 1914 RVA: 0x000063C5 File Offset: 0x000045C5
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040005DD RID: 1501
		public int int_0;

		// Token: 0x040005DE RID: 1502
		public AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder_0;

		// Token: 0x040005DF RID: 1503
		public HttpResponseMessage httpResponseMessage_0;

		// Token: 0x040005E0 RID: 1504
		public Class52 class52_0;

		// Token: 0x040005E1 RID: 1505
		private TaskAwaiter taskAwaiter_0;

		// Token: 0x040005E2 RID: 1506
		private TaskAwaiter<string> taskAwaiter_1;
	}

	// Token: 0x02000144 RID: 324
	[StructLayout(LayoutKind.Auto)]
	private struct Struct121 : IAsyncStateMachine
	{
		// Token: 0x0600077B RID: 1915 RVA: 0x0003F3AC File Offset: 0x0003D5AC
		void IAsyncStateMachine.MoveNext()
		{
			int num3;
			int num2 = num3;
			Class52 @class = this;
			try
			{
				TaskAwaiter taskAwaiter5;
				if (num2 > 8)
				{
					if (num2 != 9)
					{
						@class.method_5("Fetching variants", "#c2c2c2", true, false);
						goto IL_5DE;
					}
					taskAwaiter5 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					int num4 = -1;
					num2 = -1;
					num3 = num4;
					goto IL_5B7;
				}
				IL_4F:
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter6;
					TaskAwaiter<string> taskAwaiter8;
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
						taskAwaiter8 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<string>);
						int num6 = -1;
						num2 = -1;
						num3 = num6;
						goto IL_160;
					}
					case 2:
					{
						taskAwaiter5 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num7 = -1;
						num2 = -1;
						num3 = num7;
						goto IL_3FF;
					}
					case 3:
					{
						taskAwaiter8 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<string>);
						int num8 = -1;
						num2 = -1;
						num3 = num8;
						goto IL_427;
					}
					case 4:
					{
						taskAwaiter5 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num9 = -1;
						num2 = -1;
						num3 = num9;
						goto IL_486;
					}
					case 5:
					{
						taskAwaiter5 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num10 = -1;
						num2 = -1;
						num3 = num10;
						goto IL_4AE;
					}
					case 6:
					{
						taskAwaiter8 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<string>);
						int num11 = -1;
						num2 = -1;
						num3 = num11;
						goto IL_4D6;
					}
					case 7:
					{
						taskAwaiter5 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num12 = -1;
						num2 = -1;
						num3 = num12;
						goto IL_535;
					}
					case 8:
					{
						taskAwaiter5 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num13 = -1;
						num2 = -1;
						num3 = num13;
						goto IL_55D;
					}
					default:
						@class.method_34();
						taskAwaiter6 = GClass2.smethod_1(@class.string_18, null, true).GetAwaiter();
						if (!taskAwaiter6.IsCompleted)
						{
							int num14 = 0;
							num2 = 0;
							num3 = num14;
							TaskAwaiter<HttpResponseMessage> taskAwaiter7 = taskAwaiter6;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class52.Struct121>(ref taskAwaiter6, ref this);
							return;
						}
						break;
					}
					HttpResponseMessage result = taskAwaiter6.GetResult();
					httpResponseMessage_ = result;
					htmlDocument = new HtmlDocument();
					htmlDocument2 = htmlDocument;
					taskAwaiter8 = httpResponseMessage_.smethod_3().GetAwaiter();
					if (!taskAwaiter8.IsCompleted)
					{
						int num15 = 1;
						num2 = 1;
						num3 = num15;
						taskAwaiter4 = taskAwaiter8;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class52.Struct121>(ref taskAwaiter8, ref this);
						return;
					}
					IL_160:
					string result2 = taskAwaiter8.GetResult();
					htmlDocument2.LoadHtml(result2);
					htmlDocument2 = null;
					JObject jobject = JObject.Parse(htmlDocument.DocumentNode.SelectSingleNode("//script[@id='ProductJson-product-template']").InnerText);
					@class.method_7(jobject["title"].ToString(), "#c2c2c2");
					@class.string_17 = jobject["id"].ToString();
					@class.jtoken_0["product_id"] = @class.string_17;
					JToken jtoken = jobject["variants"];
					if (@class.bool_6)
					{
						if (!@class.method_33(jtoken, out @class.string_22, "option1", "id", "available"))
						{
							@class.method_5("Waiting for restock", "#c2c2c2", true, false);
							taskAwaiter5 = @class.method_14(Class130.int_0).GetAwaiter();
							if (!taskAwaiter5.IsCompleted)
							{
								int num16 = 2;
								num2 = 2;
								num3 = num16;
								taskAwaiter2 = taskAwaiter5;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct121>(ref taskAwaiter5, ref this);
								return;
							}
						}
						else
						{
							taskAwaiter8 = httpResponseMessage_.smethod_3().GetAwaiter();
							if (!taskAwaiter8.IsCompleted)
							{
								int num17 = 3;
								num2 = 3;
								num3 = num17;
								taskAwaiter4 = taskAwaiter8;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class52.Struct121>(ref taskAwaiter8, ref this);
								return;
							}
							goto IL_427;
						}
					}
					else
					{
						JToken jtoken2 = jtoken.Where(new Func<JToken, bool>(@class.method_49)).FirstOrDefault<JToken>();
						if (jtoken2 != null)
						{
							@class.string_22 = jtoken2["id"].ToString();
							if (object.Equals(false, (bool)jtoken2["available"]))
							{
								@class.method_5("Waiting for restock", "#c2c2c2", true, false);
								taskAwaiter5 = @class.method_14(Class130.int_0).GetAwaiter();
								if (!taskAwaiter5.IsCompleted)
								{
									int num18 = 5;
									num2 = 5;
									num3 = num18;
									taskAwaiter2 = taskAwaiter5;
									this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct121>(ref taskAwaiter5, ref this);
									return;
								}
								goto IL_4AE;
							}
							else
							{
								taskAwaiter8 = httpResponseMessage_.smethod_3().GetAwaiter();
								if (!taskAwaiter8.IsCompleted)
								{
									int num19 = 6;
									num2 = 6;
									num3 = num19;
									taskAwaiter4 = taskAwaiter8;
									this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class52.Struct121>(ref taskAwaiter8, ref this);
									return;
								}
								goto IL_4D6;
							}
						}
						else
						{
							taskAwaiter5 = @class.method_14(Class130.int_0).GetAwaiter();
							if (!taskAwaiter5.IsCompleted)
							{
								int num20 = 8;
								num2 = 8;
								num3 = num20;
								taskAwaiter2 = taskAwaiter5;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct121>(ref taskAwaiter5, ref this);
								return;
							}
							goto IL_55D;
						}
					}
					IL_3FF:
					taskAwaiter5.GetResult();
					goto IL_5DE;
					IL_427:
					result2 = taskAwaiter8.GetResult();
					taskAwaiter5 = @class.method_30(result2).GetAwaiter();
					if (!taskAwaiter5.IsCompleted)
					{
						int num21 = 4;
						num2 = 4;
						num3 = num21;
						taskAwaiter2 = taskAwaiter5;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct121>(ref taskAwaiter5, ref this);
						return;
					}
					IL_486:
					taskAwaiter5.GetResult();
					goto IL_625;
					IL_4AE:
					taskAwaiter5.GetResult();
					goto IL_5DE;
					IL_4D6:
					result2 = taskAwaiter8.GetResult();
					taskAwaiter5 = @class.method_30(result2).GetAwaiter();
					if (!taskAwaiter5.IsCompleted)
					{
						int num22 = 7;
						num2 = 7;
						num3 = num22;
						taskAwaiter2 = taskAwaiter5;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct121>(ref taskAwaiter5, ref this);
						return;
					}
					IL_535:
					taskAwaiter5.GetResult();
					goto IL_625;
					IL_55D:
					taskAwaiter5.GetResult();
					@class.method_5("Waiting for product", "#c2c2c2", false, false);
					httpResponseMessage_ = null;
					htmlDocument = null;
				}
				catch
				{
					num = 1;
				}
				int num23 = num;
				if (num23 != 1)
				{
					goto IL_5DE;
				}
				taskAwaiter5 = @class.method_14(Class130.int_0).GetAwaiter();
				if (!taskAwaiter5.IsCompleted)
				{
					int num24 = 9;
					num2 = 9;
					num3 = num24;
					taskAwaiter2 = taskAwaiter5;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct121>(ref taskAwaiter5, ref this);
					return;
				}
				IL_5B7:
				taskAwaiter5.GetResult();
				@class.method_5("Waiting for product", "#c2c2c2", false, false);
				IL_5DE:
				if (!@class.bool_1)
				{
					num = 0;
					goto IL_4F;
				}
			}
			catch (Exception exception)
			{
				num3 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_625:
			num3 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x0600077C RID: 1916 RVA: 0x000063D3 File Offset: 0x000045D3
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040005E3 RID: 1507
		public int int_0;

		// Token: 0x040005E4 RID: 1508
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040005E5 RID: 1509
		public Class52 class52_0;

		// Token: 0x040005E6 RID: 1510
		private int int_1;

		// Token: 0x040005E7 RID: 1511
		private HttpResponseMessage httpResponseMessage_0;

		// Token: 0x040005E8 RID: 1512
		private HtmlDocument htmlDocument_0;

		// Token: 0x040005E9 RID: 1513
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040005EA RID: 1514
		private HtmlDocument htmlDocument_1;

		// Token: 0x040005EB RID: 1515
		private TaskAwaiter<string> taskAwaiter_1;

		// Token: 0x040005EC RID: 1516
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x02000145 RID: 325
	[StructLayout(LayoutKind.Auto)]
	private struct Struct122 : IAsyncStateMachine
	{
		// Token: 0x0600077D RID: 1917 RVA: 0x0003FA28 File Offset: 0x0003DC28
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class52 @class = this;
			try
			{
				TaskAwaiter taskAwaiter7;
				if (num > 2)
				{
					if (num != 3)
					{
						goto IL_386;
					}
					taskAwaiter7 = taskAwaiter6;
					taskAwaiter6 = default(TaskAwaiter);
					int num3 = -1;
					num = -1;
					num2 = num3;
					goto IL_376;
				}
				IL_3D:
				int num10;
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter8;
					TaskAwaiter<bool> taskAwaiter10;
					TaskAwaiter<string> taskAwaiter11;
					switch (num)
					{
					case 0:
					{
						TaskAwaiter<HttpResponseMessage> taskAwaiter9;
						taskAwaiter8 = taskAwaiter9;
						taskAwaiter9 = default(TaskAwaiter<HttpResponseMessage>);
						int num4 = -1;
						num = -1;
						num2 = num4;
						break;
					}
					case 1:
					{
						taskAwaiter10 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<bool>);
						int num5 = -1;
						num = -1;
						num2 = num5;
						goto IL_1BE;
					}
					case 2:
					{
						taskAwaiter11 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<string>);
						int num6 = -1;
						num = -1;
						num2 = num6;
						goto IL_209;
					}
					default:
					{
						@class.method_5("Submitting payment...", "orange", true, false);
						JObject jobject = new JObject();
						string propertyName = "payment";
						JObject jobject2 = new JObject();
						jobject2["amount"] = @class.string_16;
						jobject2["unique_token"] = Class108.smethod_17(16);
						string propertyName2 = "payment_token";
						JObject jobject3 = new JObject();
						jobject3["type"] = "shopify_payments";
						jobject3["payment_data"] = @class.string_14;
						jobject2[propertyName2] = jobject3;
						jobject[propertyName] = jobject2;
						JObject jobject_ = jobject;
						taskAwaiter8 = @class.class14_0.method_4(@class.string_7 + "/payments.json", jobject_, false).GetAwaiter();
						if (!taskAwaiter8.IsCompleted)
						{
							int num7 = 0;
							num = 0;
							num2 = num7;
							TaskAwaiter<HttpResponseMessage> taskAwaiter9 = taskAwaiter8;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class52.Struct122>(ref taskAwaiter8, ref this);
							return;
						}
						break;
					}
					}
					HttpResponseMessage result = taskAwaiter8.GetResult();
					httpResponseMessage_ = result;
					taskAwaiter10 = @class.method_32(httpResponseMessage_).GetAwaiter();
					if (!taskAwaiter10.IsCompleted)
					{
						int num8 = 1;
						num = 1;
						num2 = num8;
						taskAwaiter2 = taskAwaiter10;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, Class52.Struct122>(ref taskAwaiter10, ref this);
						return;
					}
					IL_1BE:
					if (taskAwaiter10.GetResult())
					{
						goto IL_386;
					}
					taskAwaiter11 = httpResponseMessage_.smethod_3().GetAwaiter();
					if (!taskAwaiter11.IsCompleted)
					{
						int num9 = 2;
						num = 2;
						num2 = num9;
						taskAwaiter4 = taskAwaiter11;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class52.Struct122>(ref taskAwaiter11, ref this);
						return;
					}
					IL_209:
					string result2 = taskAwaiter11.GetResult();
					if (result2.Contains("not_enough_in_stock"))
					{
						@class.method_0("Payment Declined (OOS)", "red", true, (GEnum1)0);
					}
					else if (result2.ToLower().Contains("Declined"))
					{
						@class.method_0("Payment Declined", "red", true, (GEnum1)0);
					}
					else if (result2.Contains("processing_error"))
					{
						@class.method_0("Payment error", "red", true, (GEnum1)0);
					}
					else if (result2.Contains("thank_you"))
					{
						@class.method_0("Successfully checked out", "green", true, (GEnum1)0);
					}
					else if (!result2.Contains("is invalid") && !result2.Contains("is incorrect"))
					{
						if (result2.Contains("Some products became unavailable"))
						{
							@class.method_0("Payment Declined (OOS)", "red", true, (GEnum1)0);
						}
						else
						{
							GClass3.smethod_0(result2, "Unhandled Exception");
							@class.method_0("Payment error", "red", true, (GEnum1)0);
						}
					}
					else
					{
						@class.method_0("Invalid card info", "red", true, (GEnum1)0);
					}
					throw new Exception();
				}
				catch (ThreadAbortException)
				{
					goto IL_3CC;
				}
				catch
				{
					num10 = 1;
				}
				if (num10 != 1)
				{
					goto IL_386;
				}
				@class.method_5("Error submitting payment...", "#c2c2c2", true, false);
				taskAwaiter7 = @class.method_14(Class130.int_1).GetAwaiter();
				if (!taskAwaiter7.IsCompleted)
				{
					int num11 = 3;
					num = 3;
					num2 = num11;
					taskAwaiter6 = taskAwaiter7;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct122>(ref taskAwaiter7, ref this);
					return;
				}
				IL_376:
				taskAwaiter7.GetResult();
				IL_386:
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
			IL_3CC:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x0600077E RID: 1918 RVA: 0x000063E1 File Offset: 0x000045E1
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040005ED RID: 1517
		public int int_0;

		// Token: 0x040005EE RID: 1518
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040005EF RID: 1519
		public Class52 class52_0;

		// Token: 0x040005F0 RID: 1520
		private HttpResponseMessage httpResponseMessage_0;

		// Token: 0x040005F1 RID: 1521
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040005F2 RID: 1522
		private TaskAwaiter<bool> taskAwaiter_1;

		// Token: 0x040005F3 RID: 1523
		private TaskAwaiter<string> taskAwaiter_2;

		// Token: 0x040005F4 RID: 1524
		private TaskAwaiter taskAwaiter_3;
	}

	// Token: 0x02000146 RID: 326
	private sealed class Class164
	{
		// Token: 0x06000780 RID: 1920 RVA: 0x000063EF File Offset: 0x000045EF
		internal bool method_0(JToken jtoken_0)
		{
			return (bool)jtoken_0[this.string_0];
		}

		// Token: 0x040005F5 RID: 1525
		public string string_0;
	}

	// Token: 0x02000147 RID: 327
	[StructLayout(LayoutKind.Auto)]
	private struct Struct123 : IAsyncStateMachine
	{
		// Token: 0x06000781 RID: 1921 RVA: 0x0003FE60 File Offset: 0x0003E060
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class52 @class = this;
			try
			{
				if (num > 1)
				{
					goto IL_254;
				}
				IL_15:
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
							int num3 = -1;
							num = -1;
							num2 = num3;
							goto IL_17D;
						}
						if (!@class.jtoken_2["api_key"].smethod_22())
						{
							string arg = @class.jtoken_2["api_key"].ToString();
							@class.class14_0.httpClient_0.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:", arg))));
							goto IL_23D;
						}
						@class.method_5("Getting API key", "#c2c2c2", true, false);
						taskAwaiter6 = GClass2.smethod_1(@class.string_8, null, true).GetAwaiter();
						if (!taskAwaiter6.IsCompleted)
						{
							int num4 = 0;
							num = 0;
							num2 = num4;
							taskAwaiter2 = taskAwaiter6;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class52.Struct123>(ref taskAwaiter6, ref this);
							return;
						}
					}
					else
					{
						taskAwaiter6 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
						int num5 = -1;
						num = -1;
						num2 = num5;
					}
					HttpResponseMessage result = taskAwaiter6.GetResult();
					result.EnsureSuccessStatusCode();
					htmlDocument = new HtmlDocument();
					htmlDocument2 = htmlDocument;
					taskAwaiter5 = result.smethod_3().GetAwaiter();
					if (!taskAwaiter5.IsCompleted)
					{
						int num6 = 1;
						num = 1;
						num2 = num6;
						taskAwaiter4 = taskAwaiter5;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class52.Struct123>(ref taskAwaiter5, ref this);
						return;
					}
					IL_17D:
					string result2 = taskAwaiter5.GetResult();
					htmlDocument2.LoadHtml(result2);
					htmlDocument2 = null;
					string value = htmlDocument.DocumentNode.SelectSingleNode("//meta[@name='shopify-checkout-api-token']").Attributes["content"].Value;
					@class.class14_0.httpClient_0.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:", value))));
					JObject jobject = new JObject();
					jobject["api_key"] = value;
					JObject value2 = jobject;
					Class130.jobject_1[(string)@class.jtoken_0["store"]] = value2;
					htmlDocument = null;
					IL_23D:
					goto IL_27A;
				}
				catch
				{
					@class.method_0("Store not supported", "red", true, (GEnum1)0);
				}
				IL_254:
				if (!@class.bool_1)
				{
					goto IL_15;
				}
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

		// Token: 0x06000782 RID: 1922 RVA: 0x00006402 File Offset: 0x00004602
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040005F6 RID: 1526
		public int int_0;

		// Token: 0x040005F7 RID: 1527
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040005F8 RID: 1528
		public Class52 class52_0;

		// Token: 0x040005F9 RID: 1529
		private HtmlDocument htmlDocument_0;

		// Token: 0x040005FA RID: 1530
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040005FB RID: 1531
		private HtmlDocument htmlDocument_1;

		// Token: 0x040005FC RID: 1532
		private TaskAwaiter<string> taskAwaiter_1;
	}

	// Token: 0x02000148 RID: 328
	[StructLayout(LayoutKind.Auto)]
	private struct Struct124 : IAsyncStateMachine
	{
		// Token: 0x06000783 RID: 1923 RVA: 0x00040130 File Offset: 0x0003E330
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class52 @class = this;
			try
			{
				if (num <= 2)
				{
					goto IL_2BB;
				}
				if (num != 3)
				{
					goto IL_2B1;
				}
				TaskAwaiter taskAwaiter5 = taskAwaiter4;
				taskAwaiter4 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_2AA:
				taskAwaiter5.GetResult();
				IL_2B1:
				if (@class.bool_1)
				{
					goto IL_2FD;
				}
				int num4 = 0;
				IL_2BB:
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter6;
					TaskAwaiter<bool> taskAwaiter8;
					TaskAwaiter<string> taskAwaiter10;
					switch (num)
					{
					case 0:
					{
						TaskAwaiter<HttpResponseMessage> taskAwaiter7;
						taskAwaiter6 = taskAwaiter7;
						taskAwaiter7 = default(TaskAwaiter<HttpResponseMessage>);
						int num5 = -1;
						num = -1;
						num2 = num5;
						break;
					}
					case 1:
					{
						TaskAwaiter<bool> taskAwaiter9;
						taskAwaiter8 = taskAwaiter9;
						taskAwaiter9 = default(TaskAwaiter<bool>);
						int num6 = -1;
						num = -1;
						num2 = num6;
						goto IL_1E0;
					}
					case 2:
					{
						taskAwaiter10 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<string>);
						int num7 = -1;
						num = -1;
						num2 = num7;
						goto IL_244;
					}
					default:
					{
						if (@class.jtoken_0["login"].ToString() == "False")
						{
							goto IL_2FD;
						}
						@class.method_5("Logging in", "#c2c2c2", true, false);
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary["form_type"] = "customer_login";
						dictionary["utf8"] = "✓";
						dictionary["customer[email]"] = @class.jtoken_0["login"]["username"].ToString();
						dictionary["customer[password]"] = @class.jtoken_0["login"]["password"].ToString();
						taskAwaiter6 = @class.class14_0.method_3(@class.string_8 + "/account/login", dictionary, false).GetAwaiter();
						if (!taskAwaiter6.IsCompleted)
						{
							int num8 = 0;
							num = 0;
							num2 = num8;
							TaskAwaiter<HttpResponseMessage> taskAwaiter7 = taskAwaiter6;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class52.Struct124>(ref taskAwaiter6, ref this);
							return;
						}
						break;
					}
					}
					HttpResponseMessage result = taskAwaiter6.GetResult();
					httpResponseMessage_ = result;
					taskAwaiter8 = @class.method_32(httpResponseMessage_).GetAwaiter();
					if (!taskAwaiter8.IsCompleted)
					{
						int num9 = 1;
						num = 1;
						num2 = num9;
						TaskAwaiter<bool> taskAwaiter9 = taskAwaiter8;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, Class52.Struct124>(ref taskAwaiter8, ref this);
						return;
					}
					IL_1E0:
					taskAwaiter8.GetResult();
					taskAwaiter10 = httpResponseMessage_.smethod_3().GetAwaiter();
					if (!taskAwaiter10.IsCompleted)
					{
						int num10 = 2;
						num = 2;
						num2 = num10;
						taskAwaiter2 = taskAwaiter10;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class52.Struct124>(ref taskAwaiter10, ref this);
						return;
					}
					IL_244:
					if (taskAwaiter10.GetResult().Contains("/account/login"))
					{
						@class.method_0("Invalid login details", "red", true, (GEnum1)0);
					}
					goto IL_2FD;
				}
				catch (ThreadAbortException)
				{
					goto IL_2FD;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_2B1;
				}
				@class.method_5("Error logging in", "#c2c2c2", true, false);
				taskAwaiter5 = @class.method_14(Class130.int_1).GetAwaiter();
				if (taskAwaiter5.IsCompleted)
				{
					goto IL_2AA;
				}
				int num11 = 3;
				num = 3;
				num2 = num11;
				taskAwaiter4 = taskAwaiter5;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct124>(ref taskAwaiter5, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_2FD:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000784 RID: 1924 RVA: 0x00006410 File Offset: 0x00004610
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040005FD RID: 1533
		public int int_0;

		// Token: 0x040005FE RID: 1534
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040005FF RID: 1535
		public Class52 class52_0;

		// Token: 0x04000600 RID: 1536
		private HttpResponseMessage httpResponseMessage_0;

		// Token: 0x04000601 RID: 1537
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000602 RID: 1538
		private TaskAwaiter<bool> taskAwaiter_1;

		// Token: 0x04000603 RID: 1539
		private TaskAwaiter<string> taskAwaiter_2;

		// Token: 0x04000604 RID: 1540
		private TaskAwaiter taskAwaiter_3;
	}

	// Token: 0x02000149 RID: 329
	[StructLayout(LayoutKind.Auto)]
	private struct Struct125 : IAsyncStateMachine
	{
		// Token: 0x06000785 RID: 1925 RVA: 0x0004049C File Offset: 0x0003E69C
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class52 @class = this;
			try
			{
				TaskAwaiter taskAwaiter3;
				if (num > 4)
				{
					if (num != 5)
					{
						@class.method_5("Waiting for product", "#c2c2c2", true, false);
						engine = new Engine();
						goto IL_55B;
					}
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					int num3 = -1;
					num = -1;
					num2 = num3;
					goto IL_538;
				}
				IL_59:
				int num14;
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
						int num4 = -1;
						num = -1;
						num2 = num4;
						break;
					}
					case 1:
					{
						TaskAwaiter<string> taskAwaiter7;
						taskAwaiter6 = taskAwaiter7;
						taskAwaiter7 = default(TaskAwaiter<string>);
						int num5 = -1;
						num = -1;
						num2 = num5;
						goto IL_146;
					}
					case 2:
					{
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num6 = -1;
						num = -1;
						num2 = num6;
						goto IL_4BD;
					}
					case 3:
					{
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num7 = -1;
						num = -1;
						num2 = num7;
						goto IL_4E5;
					}
					case 4:
					{
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num8 = -1;
						num = -1;
						num2 = num8;
						goto IL_50A;
					}
					default:
						@class.method_34();
						taskAwaiter4 = GClass2.smethod_1(@class.bool_7 ? @class.string_8 : @class.string_18, null, true).GetAwaiter();
						if (!taskAwaiter4.IsCompleted)
						{
							int num9 = 0;
							num = 0;
							num2 = num9;
							TaskAwaiter<HttpResponseMessage> taskAwaiter5 = taskAwaiter4;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class52.Struct125>(ref taskAwaiter4, ref this);
							return;
						}
						break;
					}
					taskAwaiter6 = taskAwaiter4.GetResult().smethod_3().GetAwaiter();
					if (!taskAwaiter6.IsCompleted)
					{
						int num10 = 1;
						num = 1;
						num2 = num10;
						TaskAwaiter<string> taskAwaiter7 = taskAwaiter6;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class52.Struct125>(ref taskAwaiter6, ref this);
						return;
					}
					IL_146:
					string result = taskAwaiter6.GetResult();
					HtmlDocument htmlDocument = new HtmlDocument();
					htmlDocument.LoadHtml(result);
					JObject jobject;
					if (result.Contains("js-product-json"))
					{
						jobject = JObject.Parse(htmlDocument.DocumentNode.SelectSingleNode("//script[@id='js-product-json']").InnerText);
					}
					else if (result.Contains("js-new-arrivals-json"))
					{
						jobject = (JObject)JObject.Parse(htmlDocument.DocumentNode.SelectSingleNode("//script[@id='js-new-arrivals-json']").InnerText)["products"].Where(new Func<JToken, bool>(@class.method_51)).FirstOrDefault<JToken>();
						if (jobject != null)
						{
							@class.bool_7 = false;
							@class.string_18 = string.Format("{0}products/{1}", @class.string_8, jobject["handle"]);
							goto IL_55B;
						}
						taskAwaiter3 = @class.method_14(Class130.int_0).GetAwaiter();
						if (!taskAwaiter3.IsCompleted)
						{
							int num11 = 2;
							num = 2;
							num2 = num11;
							taskAwaiter2 = taskAwaiter3;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct125>(ref taskAwaiter3, ref this);
							return;
						}
						goto IL_4BD;
					}
					else
					{
						engine.Execute("KANYE = {}; " + string.Join(" ", htmlDocument.DocumentNode.SelectNodes("//script").Where(new Func<HtmlNode, bool>(Class52.Class162.class162_0.method_0)).Select(new Func<HtmlNode, string>(Class52.Class162.class162_0.method_1))));
						jobject = (JObject)JObject.Parse(engine.Execute("JSON.stringify(KANYE)").GetCompletionValue().ToString())["p"].FirstOrDefault(new Func<JToken, bool>(@class.method_52));
						if (jobject == null)
						{
							throw new Exception();
						}
					}
					@class.method_7(jobject["title"].ToString(), "#c2c2c2");
					@class.string_17 = jobject["id"].ToString();
					@class.jtoken_0["product_id"] = @class.string_17;
					JToken jtoken = jobject["variants"];
					if (@class.bool_6)
					{
						if (@class.method_33(jtoken, out @class.string_22, "option1", "id", "available"))
						{
							goto IL_5A0;
						}
						@class.method_5("Waiting for restock", "#c2c2c2", true, false);
						taskAwaiter3 = @class.method_14(Class130.int_0).GetAwaiter();
						if (!taskAwaiter3.IsCompleted)
						{
							int num12 = 3;
							num = 3;
							num2 = num12;
							taskAwaiter2 = taskAwaiter3;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct125>(ref taskAwaiter3, ref this);
							return;
						}
						goto IL_4E5;
					}
					else
					{
						JToken jtoken2 = jtoken.Where(new Func<JToken, bool>(@class.method_53)).FirstOrDefault<JToken>();
						if (jtoken2 == null)
						{
							throw new Exception();
						}
						@class.string_22 = jtoken2["id"].ToString();
						if (!object.Equals(false, (bool)jtoken2["available"]))
						{
							goto IL_5A0;
						}
						@class.method_5("Waiting for restock", "#c2c2c2", true, false);
						taskAwaiter3 = @class.method_14(Class130.int_0).GetAwaiter();
						if (!taskAwaiter3.IsCompleted)
						{
							int num13 = 4;
							num = 4;
							num2 = num13;
							taskAwaiter2 = taskAwaiter3;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct125>(ref taskAwaiter3, ref this);
							return;
						}
						goto IL_50A;
					}
					IL_4BD:
					taskAwaiter3.GetResult();
					goto IL_55B;
					IL_4E5:
					taskAwaiter3.GetResult();
					goto IL_55B;
					IL_50A:
					taskAwaiter3.GetResult();
					goto IL_55B;
				}
				catch
				{
					num14 = 1;
				}
				if (num14 != 1)
				{
					goto IL_55B;
				}
				taskAwaiter3 = @class.method_14(Class130.int_0).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					int num15 = 5;
					num = 5;
					num2 = num15;
					taskAwaiter2 = taskAwaiter3;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct125>(ref taskAwaiter3, ref this);
					return;
				}
				IL_538:
				taskAwaiter3.GetResult();
				@class.method_5("Waiting for product", "#c2c2c2", false, false);
				IL_55B:
				if (!@class.bool_1)
				{
					num14 = 0;
					goto IL_59;
				}
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_5A0:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000786 RID: 1926 RVA: 0x0000641E File Offset: 0x0000461E
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000605 RID: 1541
		public int int_0;

		// Token: 0x04000606 RID: 1542
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000607 RID: 1543
		public Class52 class52_0;

		// Token: 0x04000608 RID: 1544
		private Engine engine_0;

		// Token: 0x04000609 RID: 1545
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x0400060A RID: 1546
		private TaskAwaiter<string> taskAwaiter_1;

		// Token: 0x0400060B RID: 1547
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x0200014A RID: 330
	[StructLayout(LayoutKind.Auto)]
	private struct Struct126 : IAsyncStateMachine
	{
		// Token: 0x06000787 RID: 1927 RVA: 0x00040A90 File Offset: 0x0003EC90
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class52 @class = this;
			try
			{
				if (num <= 1)
				{
					goto IL_30D;
				}
				if (num != 2)
				{
					goto IL_303;
				}
				TaskAwaiter taskAwaiter7 = taskAwaiter6;
				taskAwaiter6 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_2FC:
				taskAwaiter7.GetResult();
				IL_303:
				if (@class.bool_1)
				{
					goto IL_34F;
				}
				int num4 = 0;
				IL_30D:
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
							goto IL_2A1;
						}
						if (!bool_9)
						{
							@class.method_5("Getting payment token", "#c2c2c2", true, false);
						}
						JObject jobject = new JObject();
						jobject["credit_card"] = new JObject();
						jobject["credit_card"]["number"] = ((string)@class.jtoken_1["payment"]["card"]["number"]).Replace(" ", string.Empty);
						jobject["credit_card"]["month"] = @class.jtoken_1["payment"]["card"]["exp_month"];
						jobject["credit_card"]["year"] = @class.jtoken_1["payment"]["card"]["exp_year"];
						jobject["credit_card"]["verification_value"] = @class.jtoken_1["payment"]["card"]["cvv"];
						jobject["credit_card"]["first_name"] = @class.jtoken_1["billing"]["first_name"];
						jobject["credit_card"]["last_name"] = @class.jtoken_1["billing"]["last_name"];
						taskAwaiter9 = @class.class14_0.method_4("https://elb.deposit.shopifycs.com/sessions", jobject, false).GetAwaiter();
						if (!taskAwaiter9.IsCompleted)
						{
							int num6 = 0;
							num = 0;
							num2 = num6;
							taskAwaiter2 = taskAwaiter9;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class52.Struct126>(ref taskAwaiter9, ref this);
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
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class52.Struct126>(ref taskAwaiter8, ref this);
						return;
					}
					IL_2A1:
					JObject result2 = taskAwaiter8.GetResult();
					@class.string_14 = result2["id"].ToString();
					goto IL_34F;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_303;
				}
				@class.method_5("Error getting payment token", "#c2c2c2", true, false);
				taskAwaiter7 = @class.method_14(Class130.int_1).GetAwaiter();
				if (taskAwaiter7.IsCompleted)
				{
					goto IL_2FC;
				}
				int num9 = 2;
				num = 2;
				num2 = num9;
				taskAwaiter6 = taskAwaiter7;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct126>(ref taskAwaiter7, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_34F:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000788 RID: 1928 RVA: 0x0000642C File Offset: 0x0000462C
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400060C RID: 1548
		public int int_0;

		// Token: 0x0400060D RID: 1549
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x0400060E RID: 1550
		public bool bool_0;

		// Token: 0x0400060F RID: 1551
		public Class52 class52_0;

		// Token: 0x04000610 RID: 1552
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000611 RID: 1553
		private TaskAwaiter<JObject> taskAwaiter_1;

		// Token: 0x04000612 RID: 1554
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x0200014B RID: 331
	private static class Class165
	{
		// Token: 0x04000613 RID: 1555
		public static CallSite<Func<CallSite, object, object, object>> callSite_0;

		// Token: 0x04000614 RID: 1556
		public static CallSite<Func<CallSite, object, bool>> callSite_1;

		// Token: 0x04000615 RID: 1557
		public static CallSite<Func<CallSite, object, JToken>> callSite_2;
	}

	// Token: 0x0200014C RID: 332
	[StructLayout(LayoutKind.Auto)]
	private struct Struct127 : IAsyncStateMachine
	{
		// Token: 0x06000789 RID: 1929 RVA: 0x00040E34 File Offset: 0x0003F034
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class52 @class = this;
			try
			{
				TaskAwaiter taskAwaiter9;
				if (num > 6)
				{
					if (num == 7)
					{
						taskAwaiter9 = taskAwaiter8;
						taskAwaiter8 = default(TaskAwaiter);
						int num3 = -1;
						num = -1;
						num2 = num3;
						goto IL_E01;
					}
					@class.method_5("Generating checkout url", "#c2c2c2", true, false);
					if (@class.string_22 != null)
					{
						object_0 = @class.string_22;
						goto IL_E24;
					}
					goto IL_E24;
				}
				IL_66:
				int num18;
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter10;
					TaskAwaiter<bool> taskAwaiter12;
					TaskAwaiter<string> taskAwaiter13;
					TaskAwaiter<JObject> taskAwaiter14;
					switch (num)
					{
					case 0:
					{
						TaskAwaiter<HttpResponseMessage> taskAwaiter11;
						taskAwaiter10 = taskAwaiter11;
						taskAwaiter11 = default(TaskAwaiter<HttpResponseMessage>);
						int num4 = -1;
						num = -1;
						num2 = num4;
						break;
					}
					case 1:
					{
						taskAwaiter12 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<bool>);
						int num5 = -1;
						num = -1;
						num2 = num5;
						goto IL_95F;
					}
					case 2:
					{
						taskAwaiter13 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<string>);
						int num6 = -1;
						num = -1;
						num2 = num6;
						goto IL_9C9;
					}
					case 3:
					{
						TaskAwaiter<HttpResponseMessage> taskAwaiter11;
						taskAwaiter10 = taskAwaiter11;
						taskAwaiter11 = default(TaskAwaiter<HttpResponseMessage>);
						int num7 = -1;
						num = -1;
						num2 = num7;
						goto IL_A50;
					}
					case 4:
					{
						taskAwaiter14 = taskAwaiter6;
						taskAwaiter6 = default(TaskAwaiter<JObject>);
						int num8 = -1;
						num = -1;
						num2 = num8;
						goto IL_ABD;
					}
					case 5:
					{
						taskAwaiter13 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<string>);
						int num9 = -1;
						num = -1;
						num2 = num9;
						goto IL_C12;
					}
					case 6:
					{
						taskAwaiter14 = taskAwaiter6;
						taskAwaiter6 = default(TaskAwaiter<JObject>);
						int num10 = -1;
						num = -1;
						num2 = num10;
						goto IL_C47;
					}
					default:
					{
						if (@class.jtoken_1["delivery"]["state"].ToString().ToLower().Contains("none"))
						{
							@class.jtoken_1["delivery"]["state"] = @class.jtoken_1["delivery"]["city"].ToString();
						}
						if (@class.jtoken_1["billing"]["state"].ToString().ToLower().Contains("none"))
						{
							@class.jtoken_1["billing"]["state"] = @class.jtoken_1["billing"]["city"].ToString();
						}
						JObject jobject = new JObject();
						jobject["checkout"] = new JObject();
						jobject["checkout"]["secret"] = true;
						jobject["checkout"]["email"] = @class.jtoken_1["payment"]["email"];
						jobject["checkout"]["shipping_address"] = new JObject();
						jobject["checkout"]["shipping_address"]["first_name"] = (string)@class.jtoken_1["delivery"]["first_name"];
						jobject["checkout"]["shipping_address"]["last_name"] = (string)@class.jtoken_1["delivery"]["last_name"];
						jobject["checkout"]["shipping_address"]["address1"] = (string)@class.jtoken_1["delivery"]["addr1"];
						jobject["checkout"]["shipping_address"]["address2"] = (string)@class.jtoken_1["delivery"]["addr2"];
						jobject["checkout"]["shipping_address"]["city"] = (string)@class.jtoken_1["delivery"]["city"];
						jobject["checkout"]["shipping_address"]["country"] = (string)@class.jtoken_1["delivery"]["country"];
						jobject["checkout"]["shipping_address"]["province"] = (string)@class.jtoken_1["delivery"]["state"];
						jobject["checkout"]["shipping_address"]["state"] = (string)@class.jtoken_1["delivery"]["state"];
						jobject["checkout"]["shipping_address"]["zip"] = (string)@class.jtoken_1["delivery"]["zip"];
						jobject["checkout"]["shipping_address"]["phone"] = (string)@class.jtoken_1["payment"]["phone"];
						jobject["checkout"]["billing_address"] = new JObject();
						jobject["checkout"]["billing_address"]["first_name"] = (string)@class.jtoken_1["billing"]["first_name"];
						jobject["checkout"]["billing_address"]["last_name"] = (string)@class.jtoken_1["billing"]["last_name"];
						jobject["checkout"]["billing_address"]["address1"] = (string)@class.jtoken_1["billing"]["addr1"];
						jobject["checkout"]["billing_address"]["address2"] = (string)@class.jtoken_1["billing"]["addr2"];
						jobject["checkout"]["billing_address"]["city"] = (string)@class.jtoken_1["billing"]["city"];
						jobject["checkout"]["billing_address"]["country"] = (string)@class.jtoken_1["billing"]["country"];
						jobject["checkout"]["billing_address"]["province"] = (string)@class.jtoken_1["billing"]["state"];
						jobject["checkout"]["billing_address"]["state"] = (string)@class.jtoken_1["billing"]["state"];
						jobject["checkout"]["billing_address"]["zip"] = (string)@class.jtoken_1["billing"]["zip"];
						jobject["checkout"]["billing_address"]["phone"] = (string)@class.jtoken_1["payment"]["phone"];
						if (Class52.Class165.callSite_1 == null)
						{
							Class52.Class165.callSite_1 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Class52), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Func<CallSite, object, bool> target = Class52.Class165.callSite_1.Target;
						CallSite callSite_ = Class52.Class165.callSite_1;
						if (Class52.Class165.callSite_0 == null)
						{
							Class52.Class165.callSite_0 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.NotEqual, typeof(Class52), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
							}));
						}
						if (target(callSite_, Class52.Class165.callSite_0.Target(Class52.Class165.callSite_0, object_0, null)))
						{
							@class.method_5("Adding to cart", "yellow", true, false);
							JObject jobject2 = new JObject();
							JObject jobject3 = jobject2;
							string propertyName = "variant_id";
							if (Class52.Class165.callSite_2 == null)
							{
								Class52.Class165.callSite_2 = CallSite<Func<CallSite, object, JToken>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(JToken), typeof(Class52)));
							}
							jobject3[propertyName] = Class52.Class165.callSite_2.Target(Class52.Class165.callSite_2, object_0);
							jobject2["quantity"] = 1;
							jobject["checkout"]["line_items"] = new JArray(jobject2);
							@class.bool_3 = true;
						}
						taskAwaiter10 = @class.class14_0.method_4(@class.string_8 + string.Format("{0}/checkouts.json", @class.string_24), jobject, false).GetAwaiter();
						if (!taskAwaiter10.IsCompleted)
						{
							int num11 = 0;
							num = 0;
							num2 = num11;
							TaskAwaiter<HttpResponseMessage> taskAwaiter11 = taskAwaiter10;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class52.Struct127>(ref taskAwaiter10, ref this);
							return;
						}
						break;
					}
					}
					HttpResponseMessage result = taskAwaiter10.GetResult();
					httpResponseMessage = result;
					taskAwaiter12 = @class.method_32(httpResponseMessage).GetAwaiter();
					if (!taskAwaiter12.IsCompleted)
					{
						int num12 = 1;
						num = 1;
						num2 = num12;
						taskAwaiter2 = taskAwaiter12;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, Class52.Struct127>(ref taskAwaiter12, ref this);
						return;
					}
					IL_95F:
					if (taskAwaiter12.GetResult())
					{
						goto IL_E24;
					}
					taskAwaiter13 = httpResponseMessage.smethod_3().GetAwaiter();
					if (!taskAwaiter13.IsCompleted)
					{
						int num13 = 2;
						num = 2;
						num2 = num13;
						taskAwaiter4 = taskAwaiter13;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class52.Struct127>(ref taskAwaiter13, ref this);
						return;
					}
					IL_9C9:
					if (!taskAwaiter13.GetResult().Contains("/checkout/poll"))
					{
						goto IL_A61;
					}
					taskAwaiter10 = @class.method_38(httpResponseMessage.Headers.GetValues("Location").First<string>()).GetAwaiter();
					if (!taskAwaiter10.IsCompleted)
					{
						int num14 = 3;
						num = 3;
						num2 = num14;
						TaskAwaiter<HttpResponseMessage> taskAwaiter11 = taskAwaiter10;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class52.Struct127>(ref taskAwaiter10, ref this);
						return;
					}
					IL_A50:
					result = taskAwaiter10.GetResult();
					httpResponseMessage = result;
					IL_A61:
					taskAwaiter14 = httpResponseMessage.smethod_1().GetAwaiter();
					if (!taskAwaiter14.IsCompleted)
					{
						int num15 = 4;
						num = 4;
						num2 = num15;
						taskAwaiter6 = taskAwaiter14;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class52.Struct127>(ref taskAwaiter14, ref this);
						return;
					}
					IL_ABD:
					JObject result2 = taskAwaiter14.GetResult();
					if (result2.ContainsKey("errors"))
					{
						string text = result2.ToString();
						if (text.Contains("line_items"))
						{
							if (text.Contains("not_enough_in_stock"))
							{
								@class.method_0("Variant sold out", "red", true, (GEnum1)0);
								goto IL_E6A;
							}
							@class.method_0("Invalid variant", "red", true, (GEnum1)0);
							goto IL_E6A;
						}
						else
						{
							if (text.Contains("shipping_address"))
							{
								@class.method_0("Invalid shipping address", "red", true, (GEnum1)0);
								goto IL_E6A;
							}
							if (text.Contains("billing_address"))
							{
								@class.method_0("Invalid billing address", "red", true, (GEnum1)0);
								goto IL_E6A;
							}
							taskAwaiter13 = httpResponseMessage.smethod_3().GetAwaiter();
							if (!taskAwaiter13.IsCompleted)
							{
								int num16 = 5;
								num = 5;
								num2 = num16;
								taskAwaiter4 = taskAwaiter13;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class52.Struct127>(ref taskAwaiter13, ref this);
								return;
							}
						}
					}
					else
					{
						taskAwaiter14 = httpResponseMessage.smethod_1().GetAwaiter();
						if (!taskAwaiter14.IsCompleted)
						{
							int num17 = 6;
							num = 6;
							num2 = num17;
							taskAwaiter6 = taskAwaiter14;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class52.Struct127>(ref taskAwaiter14, ref this);
							return;
						}
						goto IL_C47;
					}
					IL_C12:
					GClass3.smethod_0(taskAwaiter13.GetResult(), "Uncaught exception");
					throw new Exception();
					IL_C47:
					JObject result3 = taskAwaiter14.GetResult();
					@class.string_11 = result3["checkout"]["web_url"].ToString();
					@class.string_10 = result3["checkout"]["token"].ToString();
					@class.string_9 = "https://" + new Uri(@class.string_11).Authority.Replace("/", string.Empty);
					@class.string_7 = @class.string_9 + string.Format("/{0}/checkouts/", @class.string_24) + @class.string_10;
					if (result3["checkout"]["available_shipping_rates"] != null && result3["checkout"]["available_shipping_rates"].Any<JToken>())
					{
						@class.string_20 = result3["checkout"]["available_shipping_rates"][0]["id"].ToString();
					}
					if (@class.bool_3)
					{
						@class.method_7((string)result3["checkout"]["line_items"][0]["title"], "#c2c2c2");
						@class.method_6((string)result3["checkout"]["line_items"][0]["variant_title"]);
					}
					goto IL_E6A;
				}
				catch
				{
					num18 = 1;
				}
				if (num18 != 1)
				{
					goto IL_E24;
				}
				@class.method_5("Error generating checkout url", "#c2c2c2", true, false);
				taskAwaiter9 = @class.method_14(Class130.int_1).GetAwaiter();
				if (!taskAwaiter9.IsCompleted)
				{
					int num19 = 7;
					num = 7;
					num2 = num19;
					taskAwaiter8 = taskAwaiter9;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct127>(ref taskAwaiter9, ref this);
					return;
				}
				IL_E01:
				taskAwaiter9.GetResult();
				@class.method_5("Generating checkout url", "#c2c2c2", true, false);
				IL_E24:
				if (!@class.bool_1)
				{
					num18 = 0;
					goto IL_66;
				}
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_E6A:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x0600078A RID: 1930 RVA: 0x0000643A File Offset: 0x0000463A
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000616 RID: 1558
		public int int_0;

		// Token: 0x04000617 RID: 1559
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000618 RID: 1560
		public Class52 class52_0;

		// Token: 0x04000619 RID: 1561
		public object object_0;

		// Token: 0x0400061A RID: 1562
		private HttpResponseMessage httpResponseMessage_0;

		// Token: 0x0400061B RID: 1563
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x0400061C RID: 1564
		private TaskAwaiter<bool> taskAwaiter_1;

		// Token: 0x0400061D RID: 1565
		private TaskAwaiter<string> taskAwaiter_2;

		// Token: 0x0400061E RID: 1566
		private TaskAwaiter<JObject> taskAwaiter_3;

		// Token: 0x0400061F RID: 1567
		private TaskAwaiter taskAwaiter_4;
	}

	// Token: 0x0200014D RID: 333
	[StructLayout(LayoutKind.Auto)]
	private struct Struct128 : IAsyncStateMachine
	{
		// Token: 0x0600078B RID: 1931 RVA: 0x00041CF4 File Offset: 0x0003FEF4
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class52 @class = this;
			HttpResponseMessage result;
			try
			{
				if (num <= 3)
				{
					goto IL_2CE;
				}
				if (num != 4)
				{
					@class.class14_0.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("Referer", string_25);
					goto IL_2C3;
				}
				TaskAwaiter taskAwaiter5 = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_2BC:
				taskAwaiter5.GetResult();
				IL_2C3:
				if (@class.bool_1)
				{
					result = null;
					goto IL_312;
				}
				int num4 = 0;
				IL_2CE:
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter6;
					TaskAwaiter<bool> taskAwaiter7;
					switch (num)
					{
					case 0:
					{
						taskAwaiter6 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<HttpResponseMessage>);
						int num5 = -1;
						num = -1;
						num2 = num5;
						break;
					}
					case 1:
					{
						TaskAwaiter<bool> taskAwaiter8;
						taskAwaiter7 = taskAwaiter8;
						taskAwaiter8 = default(TaskAwaiter<bool>);
						int num6 = -1;
						num = -1;
						num2 = num6;
						goto IL_156;
					}
					case 2:
					{
						taskAwaiter5 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num7 = -1;
						num = -1;
						num2 = num7;
						goto IL_1CA;
					}
					case 3:
					{
						taskAwaiter6 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<HttpResponseMessage>);
						int num8 = -1;
						num = -1;
						num2 = num8;
						goto IL_204;
					}
					default:
						@class.method_5("In Queue", "#c2c2c2", true, false);
						taskAwaiter6 = @class.class14_0.method_2(string_25, false).GetAwaiter();
						if (!taskAwaiter6.IsCompleted)
						{
							int num9 = 0;
							num = 0;
							num2 = num9;
							taskAwaiter4 = taskAwaiter6;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class52.Struct128>(ref taskAwaiter6, ref this);
							return;
						}
						break;
					}
					HttpResponseMessage result2 = taskAwaiter6.GetResult();
					httpResponseMessage = result2;
					taskAwaiter7 = @class.method_32(httpResponseMessage).GetAwaiter();
					if (!taskAwaiter7.IsCompleted)
					{
						int num10 = 1;
						num = 1;
						num2 = num10;
						TaskAwaiter<bool> taskAwaiter8 = taskAwaiter7;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, Class52.Struct128>(ref taskAwaiter7, ref this);
						return;
					}
					IL_156:
					taskAwaiter7.GetResult();
					IL_19C:
					if (httpResponseMessage.StatusCode == HttpStatusCode.Created)
					{
						@class.class14_0.httpClient_0.DefaultRequestHeaders.Remove("Referer");
						result = httpResponseMessage;
						goto IL_312;
					}
					taskAwaiter5 = @class.method_14(1000).GetAwaiter();
					if (!taskAwaiter5.IsCompleted)
					{
						int num11 = 2;
						num = 2;
						num2 = num11;
						taskAwaiter2 = taskAwaiter5;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct128>(ref taskAwaiter5, ref this);
						return;
					}
					IL_1CA:
					taskAwaiter5.GetResult();
					@class.method_5("In Queue", "#c2c2c2", true, false);
					taskAwaiter6 = @class.class14_0.method_2(string_25, false).GetAwaiter();
					if (!taskAwaiter6.IsCompleted)
					{
						int num12 = 3;
						num = 3;
						num2 = num12;
						taskAwaiter4 = taskAwaiter6;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class52.Struct128>(ref taskAwaiter6, ref this);
						return;
					}
					IL_204:
					result2 = taskAwaiter6.GetResult();
					httpResponseMessage = result2;
					goto IL_19C;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_2C3;
				}
				@class.method_5("Error processing queue", "#c2c2c2", true, false);
				taskAwaiter5 = @class.method_14(Class130.int_1).GetAwaiter();
				if (taskAwaiter5.IsCompleted)
				{
					goto IL_2BC;
				}
				int num13 = 4;
				num = 4;
				num2 = num13;
				taskAwaiter2 = taskAwaiter5;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct128>(ref taskAwaiter5, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_312:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult(result);
		}

		// Token: 0x0600078C RID: 1932 RVA: 0x00006448 File Offset: 0x00004648
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000620 RID: 1568
		public int int_0;

		// Token: 0x04000621 RID: 1569
		public AsyncTaskMethodBuilder<HttpResponseMessage> asyncTaskMethodBuilder_0;

		// Token: 0x04000622 RID: 1570
		public Class52 class52_0;

		// Token: 0x04000623 RID: 1571
		public string string_0;

		// Token: 0x04000624 RID: 1572
		private HttpResponseMessage httpResponseMessage_0;

		// Token: 0x04000625 RID: 1573
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000626 RID: 1574
		private TaskAwaiter<bool> taskAwaiter_1;

		// Token: 0x04000627 RID: 1575
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x0200014E RID: 334
	[StructLayout(LayoutKind.Auto)]
	private struct Struct129 : IAsyncStateMachine
	{
		// Token: 0x0600078D RID: 1933 RVA: 0x0004205C File Offset: 0x0004025C
		void IAsyncStateMachine.MoveNext()
		{
			int num3;
			int num2 = num3;
			Class52 @class = this;
			try
			{
				TaskAwaiter taskAwaiter5;
				if (num2 > 5)
				{
					if (num2 != 6)
					{
						@class.method_5("Waiting for product", "#c2c2c2", true, false);
						goto IL_46B;
					}
					taskAwaiter5 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					int num4 = -1;
					num2 = -1;
					num3 = num4;
					goto IL_444;
				}
				IL_4E:
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter6;
					TaskAwaiter<JObject> taskAwaiter7;
					switch (num2)
					{
					case 0:
					{
						taskAwaiter5 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num5 = -1;
						num2 = -1;
						num3 = num5;
						break;
					}
					case 1:
					{
						taskAwaiter6 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<HttpResponseMessage>);
						int num6 = -1;
						num2 = -1;
						num3 = num6;
						goto IL_136;
					}
					case 2:
					{
						TaskAwaiter<JObject> taskAwaiter8;
						taskAwaiter7 = taskAwaiter8;
						taskAwaiter8 = default(TaskAwaiter<JObject>);
						int num7 = -1;
						num2 = -1;
						num3 = num7;
						goto IL_19A;
					}
					case 3:
					{
						taskAwaiter5 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num8 = -1;
						num2 = -1;
						num3 = num8;
						goto IL_3A8;
					}
					case 4:
					{
						taskAwaiter5 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num9 = -1;
						num2 = -1;
						num3 = num9;
						goto IL_3D0;
					}
					case 5:
					{
						taskAwaiter5 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num10 = -1;
						num2 = -1;
						num3 = num10;
						goto IL_3F8;
					}
					default:
						if (@class.method_34())
						{
							taskAwaiter5 = @class.method_26().GetAwaiter();
							if (!taskAwaiter5.IsCompleted)
							{
								int num11 = 0;
								num2 = 0;
								num3 = num11;
								taskAwaiter2 = taskAwaiter5;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct129>(ref taskAwaiter5, ref this);
								return;
							}
						}
						else
						{
							taskAwaiter6 = GClass2.smethod_1(@class.string_21, null, true).GetAwaiter();
							if (!taskAwaiter6.IsCompleted)
							{
								int num12 = 1;
								num2 = 1;
								num3 = num12;
								taskAwaiter4 = taskAwaiter6;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class52.Struct129>(ref taskAwaiter6, ref this);
								return;
							}
							goto IL_136;
						}
						break;
					}
					taskAwaiter5.GetResult();
					goto IL_4B0;
					IL_136:
					HttpResponseMessage result = taskAwaiter6.GetResult();
					result.EnsureSuccessStatusCode();
					taskAwaiter7 = result.smethod_1().GetAwaiter();
					if (!taskAwaiter7.IsCompleted)
					{
						int num13 = 2;
						num2 = 2;
						num3 = num13;
						TaskAwaiter<JObject> taskAwaiter8 = taskAwaiter7;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class52.Struct129>(ref taskAwaiter7, ref this);
						return;
					}
					IL_19A:
					JToken jtoken = taskAwaiter7.GetResult()["products"].FirstOrDefault(new Func<JToken, bool>(@class.method_58));
					if (jtoken != null)
					{
						@class.string_17 = jtoken["product_id"].ToString();
						@class.method_7(jtoken["title"].ToString(), "#c2c2c2");
						@class.string_2 = (string)jtoken["thumbnail_url"];
						if (@class.bool_6)
						{
							if (@class.method_33(jtoken["offers"], out @class.string_22, "title", "offer_id", "in_stock"))
							{
								goto IL_4B0;
							}
							@class.method_5("Waiting for restock", "#c2c2c2", true, false);
							taskAwaiter5 = @class.method_14(Class130.int_0).GetAwaiter();
							if (!taskAwaiter5.IsCompleted)
							{
								int num14 = 3;
								num2 = 3;
								num3 = num14;
								taskAwaiter2 = taskAwaiter5;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct129>(ref taskAwaiter5, ref this);
								return;
							}
							goto IL_3A8;
						}
						else
						{
							JToken jtoken2 = jtoken["offers"].Where(new Func<JToken, bool>(@class.method_59)).FirstOrDefault<JToken>();
							if (jtoken2 != null)
							{
								@class.string_22 = jtoken2["offer_id"].ToString();
								if (!object.Equals(false, (bool)jtoken2["in_stock"]))
								{
									goto IL_4B0;
								}
								@class.method_5("Waiting for restock", "#c2c2c2", true, false);
								taskAwaiter5 = @class.method_14(Class130.int_0).GetAwaiter();
								if (!taskAwaiter5.IsCompleted)
								{
									int num15 = 4;
									num2 = 4;
									num3 = num15;
									taskAwaiter2 = taskAwaiter5;
									this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct129>(ref taskAwaiter5, ref this);
									return;
								}
								goto IL_3D0;
							}
						}
					}
					taskAwaiter5 = @class.method_14(Class130.int_0).GetAwaiter();
					if (!taskAwaiter5.IsCompleted)
					{
						int num16 = 5;
						num2 = 5;
						num3 = num16;
						taskAwaiter2 = taskAwaiter5;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct129>(ref taskAwaiter5, ref this);
						return;
					}
					goto IL_3F8;
					IL_3A8:
					taskAwaiter5.GetResult();
					goto IL_46B;
					IL_3D0:
					taskAwaiter5.GetResult();
					goto IL_46B;
					IL_3F8:
					taskAwaiter5.GetResult();
					@class.method_5("Waiting for product", "#c2c2c2", false, false);
				}
				catch
				{
					num = 1;
				}
				int num17 = num;
				if (num17 != 1)
				{
					goto IL_46B;
				}
				taskAwaiter5 = @class.method_14(Class130.int_0).GetAwaiter();
				if (!taskAwaiter5.IsCompleted)
				{
					int num18 = 6;
					num2 = 6;
					num3 = num18;
					taskAwaiter2 = taskAwaiter5;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct129>(ref taskAwaiter5, ref this);
					return;
				}
				IL_444:
				taskAwaiter5.GetResult();
				@class.method_5("Waiting for product", "#c2c2c2", false, false);
				IL_46B:
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
			IL_4B0:
			num3 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x0600078E RID: 1934 RVA: 0x00006456 File Offset: 0x00004656
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000628 RID: 1576
		public int int_0;

		// Token: 0x04000629 RID: 1577
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x0400062A RID: 1578
		public Class52 class52_0;

		// Token: 0x0400062B RID: 1579
		private int int_1;

		// Token: 0x0400062C RID: 1580
		private TaskAwaiter taskAwaiter_0;

		// Token: 0x0400062D RID: 1581
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_1;

		// Token: 0x0400062E RID: 1582
		private TaskAwaiter<JObject> taskAwaiter_2;
	}

	// Token: 0x0200014F RID: 335
	[StructLayout(LayoutKind.Auto)]
	private struct Struct130 : IAsyncStateMachine
	{
		// Token: 0x0600078F RID: 1935 RVA: 0x00042560 File Offset: 0x00040760
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class52 @class = this;
			try
			{
				TaskAwaiter taskAwaiter5;
				if (num > 2)
				{
					if (num != 3)
					{
						goto IL_2A5;
					}
					taskAwaiter5 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter);
					int num3 = -1;
					num = -1;
					num2 = num3;
					goto IL_295;
				}
				IL_3D:
				int num10;
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter6;
					TaskAwaiter<bool> taskAwaiter8;
					TaskAwaiter<JObject> taskAwaiter9;
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
						goto IL_1A2;
					}
					case 2:
					{
						TaskAwaiter<JObject> taskAwaiter10;
						taskAwaiter9 = taskAwaiter10;
						taskAwaiter10 = default(TaskAwaiter<JObject>);
						int num6 = -1;
						num = -1;
						num2 = num6;
						goto IL_218;
					}
					default:
					{
						@class.method_5("Submitting shipping method...", "#c2c2c2", true, false);
						JObject jobject = new JObject();
						string propertyName = "checkout";
						JObject jobject2 = new JObject();
						string propertyName2 = "shipping_rate";
						JObject jobject3 = new JObject();
						jobject3["id"] = @class.string_20;
						jobject2[propertyName2] = jobject3;
						jobject[propertyName] = jobject2;
						JObject jobject4 = jobject;
						if (@class.bool_5)
						{
							jobject4["checkout"]["note"] = @class.string_13;
						}
						taskAwaiter6 = @class.class14_0.method_5(@class.string_7 + ".json", jobject4, false).GetAwaiter();
						if (!taskAwaiter6.IsCompleted)
						{
							int num7 = 0;
							num = 0;
							num2 = num7;
							TaskAwaiter<HttpResponseMessage> taskAwaiter7 = taskAwaiter6;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class52.Struct130>(ref taskAwaiter6, ref this);
							return;
						}
						break;
					}
					}
					HttpResponseMessage result = taskAwaiter6.GetResult();
					httpResponseMessage2 = result;
					taskAwaiter8 = @class.method_32(httpResponseMessage2).GetAwaiter();
					if (!taskAwaiter8.IsCompleted)
					{
						int num8 = 1;
						num = 1;
						num2 = num8;
						taskAwaiter2 = taskAwaiter8;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, Class52.Struct130>(ref taskAwaiter8, ref this);
						return;
					}
					IL_1A2:
					if (taskAwaiter8.GetResult())
					{
						goto IL_2A5;
					}
					httpResponseMessage2.EnsureSuccessStatusCode();
					taskAwaiter9 = httpResponseMessage2.smethod_1().GetAwaiter();
					if (!taskAwaiter9.IsCompleted)
					{
						int num9 = 2;
						num = 2;
						num2 = num9;
						TaskAwaiter<JObject> taskAwaiter10 = taskAwaiter9;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class52.Struct130>(ref taskAwaiter9, ref this);
						return;
					}
					IL_218:
					JObject result2 = taskAwaiter9.GetResult();
					@class.string_16 = result2["checkout"]["total_price"].ToString();
					@class.method_5("Successfully submitted shipping method", "#c2c2c2", true, false);
					goto IL_2EB;
				}
				catch (ThreadAbortException)
				{
					goto IL_2EB;
				}
				catch
				{
					num10 = 1;
				}
				if (num10 != 1)
				{
					goto IL_2A5;
				}
				@class.method_5("Error submitting shipping method...", "#c2c2c2", true, false);
				taskAwaiter5 = @class.method_14(Class130.int_1).GetAwaiter();
				if (!taskAwaiter5.IsCompleted)
				{
					int num11 = 3;
					num = 3;
					num2 = num11;
					taskAwaiter4 = taskAwaiter5;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct130>(ref taskAwaiter5, ref this);
					return;
				}
				IL_295:
				taskAwaiter5.GetResult();
				IL_2A5:
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
			IL_2EB:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000790 RID: 1936 RVA: 0x00006464 File Offset: 0x00004664
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400062F RID: 1583
		public int int_0;

		// Token: 0x04000630 RID: 1584
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000631 RID: 1585
		public Class52 class52_0;

		// Token: 0x04000632 RID: 1586
		private HttpResponseMessage httpResponseMessage_0;

		// Token: 0x04000633 RID: 1587
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000634 RID: 1588
		private TaskAwaiter<bool> taskAwaiter_1;

		// Token: 0x04000635 RID: 1589
		private TaskAwaiter<JObject> taskAwaiter_2;

		// Token: 0x04000636 RID: 1590
		private TaskAwaiter taskAwaiter_3;
	}

	// Token: 0x02000150 RID: 336
	private sealed class Class166
	{
		// Token: 0x06000792 RID: 1938 RVA: 0x00006472 File Offset: 0x00004672
		internal bool method_0(JProperty jproperty_1)
		{
			return jproperty_1.Value["sitemap"] != null && jproperty_1.Value["sitemap"].ToString().Contains(this.jproperty_0.Name);
		}

		// Token: 0x04000637 RID: 1591
		public JProperty jproperty_0;
	}

	// Token: 0x02000151 RID: 337
	[StructLayout(LayoutKind.Auto)]
	private struct Struct131 : IAsyncStateMachine
	{
		// Token: 0x06000793 RID: 1939 RVA: 0x000428B8 File Offset: 0x00040AB8
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class52 @class = this;
			string string_;
			try
			{
				TaskAwaiter<string> taskAwaiter;
				if (num != 0)
				{
					if (!@class.bool_8 || (@class.string_23 != null && @class.stopwatch_0.ElapsedMilliseconds <= 110000L))
					{
						goto IL_E9;
					}
					@class.method_5("Waiting for captcha", "turquoise", true, false);
					taskAwaiter = CaptchaQueue.smethod_0("6LeoeSkTAAAAAA9rkZs5oS82l69OEYjKRZAiKdaF", @class.string_11, (string)@class.jtoken_0["id"], @class.cancellationTokenSource_0.Token).GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 0;
						TaskAwaiter<string> taskAwaiter2 = taskAwaiter;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class52.Struct131>(ref taskAwaiter, ref this);
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
				string result = taskAwaiter.GetResult();
				@class.string_23 = result;
				@class.stopwatch_0.Restart();
				IL_E9:
				string_ = @class.string_23;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult(string_);
		}

		// Token: 0x06000794 RID: 1940 RVA: 0x000064AD File Offset: 0x000046AD
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000638 RID: 1592
		public int int_0;

		// Token: 0x04000639 RID: 1593
		public AsyncTaskMethodBuilder<string> asyncTaskMethodBuilder_0;

		// Token: 0x0400063A RID: 1594
		public Class52 class52_0;

		// Token: 0x0400063B RID: 1595
		private TaskAwaiter<string> taskAwaiter_0;
	}

	// Token: 0x02000152 RID: 338
	[StructLayout(LayoutKind.Auto)]
	private struct Struct132 : IAsyncStateMachine
	{
		// Token: 0x06000795 RID: 1941 RVA: 0x000429F4 File Offset: 0x00040BF4
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class52 @class = this;
			try
			{
				TaskAwaiter taskAwaiter7;
				if (num > 3)
				{
					if (num != 4)
					{
						@class.class14_0.httpClient_0.DefaultRequestHeaders.Remove(@class.jobject_0.Properties().First<JProperty>().Name);
						goto IL_3BF;
					}
					taskAwaiter7 = taskAwaiter6;
					taskAwaiter6 = default(TaskAwaiter);
					int num3 = -1;
					num = -1;
					num2 = num3;
					goto IL_3AF;
				}
				IL_68:
				int num12;
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter8;
					TaskAwaiter<bool> taskAwaiter10;
					TaskAwaiter<string> taskAwaiter11;
					TaskAwaiter<JObject> taskAwaiter13;
					switch (num)
					{
					case 0:
					{
						TaskAwaiter<HttpResponseMessage> taskAwaiter9;
						taskAwaiter8 = taskAwaiter9;
						taskAwaiter9 = default(TaskAwaiter<HttpResponseMessage>);
						int num4 = -1;
						num = -1;
						num2 = num4;
						break;
					}
					case 1:
					{
						taskAwaiter10 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<bool>);
						int num5 = -1;
						num = -1;
						num2 = num5;
						goto IL_177;
					}
					case 2:
					{
						TaskAwaiter<string> taskAwaiter12;
						taskAwaiter11 = taskAwaiter12;
						taskAwaiter12 = default(TaskAwaiter<string>);
						int num6 = -1;
						num = -1;
						num2 = num6;
						goto IL_1E1;
					}
					case 3:
					{
						taskAwaiter13 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<JObject>);
						int num7 = -1;
						num = -1;
						num2 = num7;
						goto IL_317;
					}
					default:
						@class.method_5("Processing...", "orange", true, false);
						taskAwaiter8 = @class.class14_0.method_2(@class.string_8 + "/api/checkouts/" + @class.string_10 + ".json", false).GetAwaiter();
						if (!taskAwaiter8.IsCompleted)
						{
							int num8 = 0;
							num = 0;
							num2 = num8;
							TaskAwaiter<HttpResponseMessage> taskAwaiter9 = taskAwaiter8;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class52.Struct132>(ref taskAwaiter8, ref this);
							return;
						}
						break;
					}
					HttpResponseMessage result = taskAwaiter8.GetResult();
					httpResponseMessage_ = result;
					taskAwaiter10 = @class.method_32(httpResponseMessage_).GetAwaiter();
					if (!taskAwaiter10.IsCompleted)
					{
						int num9 = 1;
						num = 1;
						num2 = num9;
						taskAwaiter2 = taskAwaiter10;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, Class52.Struct132>(ref taskAwaiter10, ref this);
						return;
					}
					IL_177:
					if (taskAwaiter10.GetResult())
					{
						goto IL_3BF;
					}
					taskAwaiter11 = httpResponseMessage_.smethod_3().GetAwaiter();
					if (!taskAwaiter11.IsCompleted)
					{
						int num10 = 2;
						num = 2;
						num2 = num10;
						TaskAwaiter<string> taskAwaiter12 = taskAwaiter11;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class52.Struct132>(ref taskAwaiter11, ref this);
						return;
					}
					IL_1E1:
					string result2 = taskAwaiter11.GetResult();
					if (result2.ToLower().Contains("decline"))
					{
						@class.method_0("Payment Declined", "red", true, (GEnum1)5);
						goto IL_374;
					}
					if (result2.Contains("processing_error"))
					{
						@class.method_0("Payment error", "red", true, (GEnum1)0);
						goto IL_374;
					}
					if (result2.Contains("thank_you"))
					{
						taskAwaiter13 = httpResponseMessage_.smethod_1().GetAwaiter();
						if (!taskAwaiter13.IsCompleted)
						{
							int num11 = 3;
							num = 3;
							num2 = num11;
							taskAwaiter4 = taskAwaiter13;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class52.Struct132>(ref taskAwaiter13, ref this);
							return;
						}
					}
					else
					{
						if (result2.Contains("is invalid") || result2.Contains("is incorrect"))
						{
							@class.method_0("Invalid card info", "red", true, (GEnum1)0);
							goto IL_374;
						}
						if (result2.Contains("Some products became unavailable"))
						{
							@class.method_0("Payment Declined (OOS)", "red", true, (GEnum1)0);
							goto IL_374;
						}
						GClass3.smethod_0(result2, "Unhandled Exception");
						@class.method_0("Payment error", "red", true, (GEnum1)0);
						goto IL_374;
					}
					IL_317:
					JObject result3 = taskAwaiter13.GetResult();
					@class.string_3 = (string)result3["checkout"]["order_id"];
					@class.string_4 = (string)result3["checkout"]["order_status_url"];
					@class.method_0("Successfully checked out", "green", true, (GEnum1)6);
					IL_374:
					goto IL_405;
				}
				catch
				{
					num12 = 1;
				}
				if (num12 != 1)
				{
					goto IL_3BF;
				}
				@class.method_5("Error processing payment...", "#c2c2c2", true, false);
				taskAwaiter7 = @class.method_14(Class130.int_1).GetAwaiter();
				if (!taskAwaiter7.IsCompleted)
				{
					int num13 = 4;
					num = 4;
					num2 = num13;
					taskAwaiter6 = taskAwaiter7;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct132>(ref taskAwaiter7, ref this);
					return;
				}
				IL_3AF:
				taskAwaiter7.GetResult();
				IL_3BF:
				if (!@class.bool_1)
				{
					num12 = 0;
					goto IL_68;
				}
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_405:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000796 RID: 1942 RVA: 0x000064BB File Offset: 0x000046BB
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400063C RID: 1596
		public int int_0;

		// Token: 0x0400063D RID: 1597
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x0400063E RID: 1598
		public Class52 class52_0;

		// Token: 0x0400063F RID: 1599
		private HttpResponseMessage httpResponseMessage_0;

		// Token: 0x04000640 RID: 1600
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000641 RID: 1601
		private TaskAwaiter<bool> taskAwaiter_1;

		// Token: 0x04000642 RID: 1602
		private TaskAwaiter<string> taskAwaiter_2;

		// Token: 0x04000643 RID: 1603
		private TaskAwaiter<JObject> taskAwaiter_3;

		// Token: 0x04000644 RID: 1604
		private TaskAwaiter taskAwaiter_4;
	}

	// Token: 0x02000153 RID: 339
	[StructLayout(LayoutKind.Auto)]
	private struct Struct133 : IAsyncStateMachine
	{
		// Token: 0x06000797 RID: 1943 RVA: 0x00042E50 File Offset: 0x00041050
		void IAsyncStateMachine.MoveNext()
		{
			int num3;
			int num2 = num3;
			Class52 @class = this;
			try
			{
				TaskAwaiter taskAwaiter5;
				if (num2 > 5)
				{
					if (num2 != 6)
					{
						@class.method_5("Waiting for product", "#c2c2c2", true, false);
						goto IL_507;
					}
					taskAwaiter5 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					int num4 = -1;
					num2 = -1;
					num3 = num4;
					goto IL_4E0;
				}
				IL_4E:
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter6;
					TaskAwaiter<JObject> taskAwaiter7;
					switch (num2)
					{
					case 0:
					{
						taskAwaiter5 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num5 = -1;
						num2 = -1;
						num3 = num5;
						break;
					}
					case 1:
					{
						taskAwaiter6 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<HttpResponseMessage>);
						int num6 = -1;
						num2 = -1;
						num3 = num6;
						goto IL_136;
					}
					case 2:
					{
						TaskAwaiter<JObject> taskAwaiter8;
						taskAwaiter7 = taskAwaiter8;
						taskAwaiter8 = default(TaskAwaiter<JObject>);
						int num7 = -1;
						num2 = -1;
						num3 = num7;
						goto IL_1B9;
					}
					case 3:
					{
						taskAwaiter5 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num8 = -1;
						num2 = -1;
						num3 = num8;
						goto IL_444;
					}
					case 4:
					{
						taskAwaiter5 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num9 = -1;
						num2 = -1;
						num3 = num9;
						goto IL_46C;
					}
					case 5:
					{
						taskAwaiter5 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num10 = -1;
						num2 = -1;
						num3 = num10;
						goto IL_494;
					}
					default:
						if (@class.method_34())
						{
							taskAwaiter5 = @class.method_26().GetAwaiter();
							if (!taskAwaiter5.IsCompleted)
							{
								int num11 = 0;
								num2 = 0;
								num3 = num11;
								taskAwaiter2 = taskAwaiter5;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct133>(ref taskAwaiter5, ref this);
								return;
							}
						}
						else
						{
							taskAwaiter6 = GClass2.smethod_1(@class.string_21, null, true).GetAwaiter();
							if (!taskAwaiter6.IsCompleted)
							{
								int num12 = 1;
								num2 = 1;
								num3 = num12;
								taskAwaiter4 = taskAwaiter6;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class52.Struct133>(ref taskAwaiter6, ref this);
								return;
							}
							goto IL_136;
						}
						break;
					}
					taskAwaiter5.GetResult();
					goto IL_54C;
					IL_136:
					HttpResponseMessage result = taskAwaiter6.GetResult();
					if (result.StatusCode == HttpStatusCode.NotFound)
					{
						@class.method_0("Unsupported retailer", "red", true, (GEnum1)0);
					}
					result.EnsureSuccessStatusCode();
					taskAwaiter7 = result.smethod_1().GetAwaiter();
					if (!taskAwaiter7.IsCompleted)
					{
						int num13 = 2;
						num2 = 2;
						num3 = num13;
						TaskAwaiter<JObject> taskAwaiter8 = taskAwaiter7;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class52.Struct133>(ref taskAwaiter7, ref this);
						return;
					}
					IL_1B9:
					JToken jtoken = taskAwaiter7.GetResult()["products"].FirstOrDefault(new Func<JToken, bool>(@class.method_55));
					if (jtoken != null)
					{
						@class.method_7(jtoken["title"].ToString(), "#c2c2c2");
						@class.string_17 = jtoken["id"].ToString();
						@class.string_18 = string.Format("{0}products/{1}", @class.string_8, jtoken["handle"]);
						@class.string_2 = (jtoken["images"].Any<JToken>() ? jtoken["images"][0]["src"].ToString() : null);
						if (@class.bool_6)
						{
							if (@class.method_33(jtoken["variants"], out @class.string_22, "option1", "id", "available"))
							{
								goto IL_54C;
							}
							@class.method_5("Waiting for restock", "#c2c2c2", true, false);
							taskAwaiter5 = @class.method_14(Class130.int_0).GetAwaiter();
							if (!taskAwaiter5.IsCompleted)
							{
								int num14 = 3;
								num2 = 3;
								num3 = num14;
								taskAwaiter2 = taskAwaiter5;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct133>(ref taskAwaiter5, ref this);
								return;
							}
							goto IL_444;
						}
						else
						{
							JToken jtoken2 = jtoken["variants"].Where(new Func<JToken, bool>(@class.method_56)).FirstOrDefault<JToken>();
							if (jtoken2 != null)
							{
								@class.string_22 = jtoken2["id"].ToString();
								@class.string_16 = jtoken2["price"].ToString();
								@class.jtoken_0["product_id"] = @class.string_17;
								if (!object.Equals(false, (bool)jtoken2["available"]))
								{
									goto IL_54C;
								}
								@class.method_5("Waiting for restock", "#c2c2c2", true, false);
								taskAwaiter5 = @class.method_14(Class130.int_0).GetAwaiter();
								if (!taskAwaiter5.IsCompleted)
								{
									int num15 = 4;
									num2 = 4;
									num3 = num15;
									taskAwaiter2 = taskAwaiter5;
									this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct133>(ref taskAwaiter5, ref this);
									return;
								}
								goto IL_46C;
							}
						}
					}
					taskAwaiter5 = @class.method_14(Class130.int_0).GetAwaiter();
					if (!taskAwaiter5.IsCompleted)
					{
						int num16 = 5;
						num2 = 5;
						num3 = num16;
						taskAwaiter2 = taskAwaiter5;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct133>(ref taskAwaiter5, ref this);
						return;
					}
					goto IL_494;
					IL_444:
					taskAwaiter5.GetResult();
					goto IL_507;
					IL_46C:
					taskAwaiter5.GetResult();
					goto IL_507;
					IL_494:
					taskAwaiter5.GetResult();
					@class.method_5("Waiting for product", "#c2c2c2", false, false);
				}
				catch
				{
					num = 1;
				}
				int num17 = num;
				if (num17 != 1)
				{
					goto IL_507;
				}
				taskAwaiter5 = @class.method_14(Class130.int_0).GetAwaiter();
				if (!taskAwaiter5.IsCompleted)
				{
					int num18 = 6;
					num2 = 6;
					num3 = num18;
					taskAwaiter2 = taskAwaiter5;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct133>(ref taskAwaiter5, ref this);
					return;
				}
				IL_4E0:
				taskAwaiter5.GetResult();
				@class.method_5("Waiting for product", "#c2c2c2", false, false);
				IL_507:
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
			IL_54C:
			num3 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x06000798 RID: 1944 RVA: 0x000064C9 File Offset: 0x000046C9
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000645 RID: 1605
		public int int_0;

		// Token: 0x04000646 RID: 1606
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000647 RID: 1607
		public Class52 class52_0;

		// Token: 0x04000648 RID: 1608
		private int int_1;

		// Token: 0x04000649 RID: 1609
		private TaskAwaiter taskAwaiter_0;

		// Token: 0x0400064A RID: 1610
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_1;

		// Token: 0x0400064B RID: 1611
		private TaskAwaiter<JObject> taskAwaiter_2;
	}

	// Token: 0x02000154 RID: 340
	[StructLayout(LayoutKind.Auto)]
	private struct Struct134 : IAsyncStateMachine
	{
		// Token: 0x06000799 RID: 1945 RVA: 0x000433F0 File Offset: 0x000415F0
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class52 @class = this;
			try
			{
				TaskAwaiter taskAwaiter7;
				if (num > 1)
				{
					if (num != 2)
					{
						goto IL_241;
					}
					taskAwaiter7 = taskAwaiter6;
					taskAwaiter6 = default(TaskAwaiter);
					int num3 = -1;
					num = -1;
					num2 = num3;
					goto IL_231;
				}
				IL_3D:
				int num8;
				try
				{
					TaskAwaiter<bool> taskAwaiter8;
					TaskAwaiter<HttpResponseMessage> taskAwaiter9;
					if (num != 0)
					{
						if (num == 1)
						{
							taskAwaiter8 = taskAwaiter4;
							taskAwaiter4 = default(TaskAwaiter<bool>);
							int num4 = -1;
							num = -1;
							num2 = num4;
							goto IL_1AB;
						}
						@class.method_5("Submitting shipping method...", "#c2c2c2", true, false);
						JObject jobject = new JObject();
						string propertyName = "checkout";
						JObject jobject2 = new JObject();
						string propertyName2 = "shipping_rate";
						JObject jobject3 = new JObject();
						jobject3["id"] = @class.string_20;
						jobject2[propertyName2] = jobject3;
						jobject[propertyName] = jobject2;
						jobject["s"] = @class.string_14;
						JObject jobject4 = jobject;
						if (@class.bool_5)
						{
							jobject4["checkout"]["note"] = @class.string_13;
						}
						taskAwaiter9 = @class.class14_0.method_5(@class.string_7, jobject4, false).GetAwaiter();
						if (!taskAwaiter9.IsCompleted)
						{
							int num5 = 0;
							num = 0;
							num2 = num5;
							taskAwaiter2 = taskAwaiter9;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class52.Struct134>(ref taskAwaiter9, ref this);
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
					httpResponseMessage = result;
					taskAwaiter8 = @class.method_32(httpResponseMessage).GetAwaiter();
					if (!taskAwaiter8.IsCompleted)
					{
						int num7 = 1;
						num = 1;
						num2 = num7;
						taskAwaiter4 = taskAwaiter8;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, Class52.Struct134>(ref taskAwaiter8, ref this);
						return;
					}
					IL_1AB:
					if (taskAwaiter8.GetResult())
					{
						goto IL_241;
					}
					if (!httpResponseMessage.IsSuccessStatusCode && httpResponseMessage.StatusCode != HttpStatusCode.Found)
					{
						throw new Exception();
					}
					@class.method_5("Successfully submitted shipping method", "#c2c2c2", true, false);
					goto IL_287;
				}
				catch (ThreadAbortException)
				{
					goto IL_287;
				}
				catch
				{
					num8 = 1;
				}
				if (num8 != 1)
				{
					goto IL_241;
				}
				@class.method_5("Error submitting shipping method...", "#c2c2c2", true, false);
				taskAwaiter7 = @class.method_14(Class130.int_1).GetAwaiter();
				if (!taskAwaiter7.IsCompleted)
				{
					int num9 = 2;
					num = 2;
					num2 = num9;
					taskAwaiter6 = taskAwaiter7;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct134>(ref taskAwaiter7, ref this);
					return;
				}
				IL_231:
				taskAwaiter7.GetResult();
				IL_241:
				if (!@class.bool_1)
				{
					num8 = 0;
					goto IL_3D;
				}
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_287:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x0600079A RID: 1946 RVA: 0x000064D7 File Offset: 0x000046D7
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400064C RID: 1612
		public int int_0;

		// Token: 0x0400064D RID: 1613
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x0400064E RID: 1614
		public Class52 class52_0;

		// Token: 0x0400064F RID: 1615
		private HttpResponseMessage httpResponseMessage_0;

		// Token: 0x04000650 RID: 1616
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000651 RID: 1617
		private TaskAwaiter<bool> taskAwaiter_1;

		// Token: 0x04000652 RID: 1618
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x02000155 RID: 341
	[StructLayout(LayoutKind.Auto)]
	private struct Struct135 : IAsyncStateMachine
	{
		// Token: 0x0600079B RID: 1947 RVA: 0x000436E4 File Offset: 0x000418E4
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class52 @class = this;
			try
			{
				TaskAwaiter taskAwaiter11;
				if (num > 5)
				{
					if (num != 6)
					{
						goto IL_4A6;
					}
					taskAwaiter11 = taskAwaiter10;
					taskAwaiter10 = default(TaskAwaiter);
					int num3 = -1;
					num = -1;
					num2 = num3;
					goto IL_496;
				}
				IL_3C:
				int num16;
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter12;
					TaskAwaiter<bool> taskAwaiter13;
					TaskAwaiter<JObject> taskAwaiter14;
					TaskAwaiter<string> taskAwaiter15;
					switch (num)
					{
					case 0:
					{
						taskAwaiter12 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
						int num4 = -1;
						num = -1;
						num2 = num4;
						goto IL_1D7;
					}
					case 1:
					{
						taskAwaiter13 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<bool>);
						int num5 = -1;
						num = -1;
						num2 = num5;
						goto IL_207;
					}
					case 2:
					{
						taskAwaiter14 = taskAwaiter6;
						taskAwaiter6 = default(TaskAwaiter<JObject>);
						int num6 = -1;
						num = -1;
						num2 = num6;
						goto IL_231;
					}
					case 3:
					{
						taskAwaiter15 = taskAwaiter8;
						taskAwaiter8 = default(TaskAwaiter<string>);
						int num7 = -1;
						num = -1;
						num2 = num7;
						goto IL_260;
					}
					case 4:
					{
						taskAwaiter11 = taskAwaiter10;
						taskAwaiter10 = default(TaskAwaiter);
						int num8 = -1;
						num = -1;
						num2 = num8;
						goto IL_2C6;
					}
					case 5:
					{
						taskAwaiter11 = taskAwaiter10;
						taskAwaiter10 = default(TaskAwaiter);
						int num9 = -1;
						num = -1;
						num2 = num9;
						goto IL_2E5;
					}
					}
					IL_12A:
					@class.method_5("Adding to cart", "yellow", true, false);
					JObject jobject = new JObject();
					string propertyName = "checkout";
					JObject jobject2 = new JObject();
					string propertyName2 = "line_items";
					JArray jarray = new JArray();
					JObject jobject3 = new JObject();
					jobject3["variant_id"] = @class.string_22;
					jobject3["quantity"] = 1;
					jobject3["properties"] = @class.jobject_1;
					jarray.Add(jobject3);
					jobject2[propertyName2] = jarray;
					jobject[propertyName] = jobject2;
					JObject jobject4 = jobject;
					taskAwaiter12 = @class.class14_0.method_5(@class.string_7 + ".json", jobject4, false).GetAwaiter();
					if (!taskAwaiter12.IsCompleted)
					{
						int num10 = 0;
						num = 0;
						num2 = num10;
						taskAwaiter2 = taskAwaiter12;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class52.Struct135>(ref taskAwaiter12, ref this);
						return;
					}
					IL_1D7:
					HttpResponseMessage result3 = taskAwaiter12.GetResult();
					result = result3;
					taskAwaiter13 = @class.method_32(result).GetAwaiter();
					if (!taskAwaiter13.IsCompleted)
					{
						int num11 = 1;
						num = 1;
						num2 = num11;
						taskAwaiter4 = taskAwaiter13;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, Class52.Struct135>(ref taskAwaiter13, ref this);
						return;
					}
					IL_207:
					if (taskAwaiter13.GetResult())
					{
						goto IL_4A6;
					}
					taskAwaiter14 = result.smethod_1().GetAwaiter();
					if (!taskAwaiter14.IsCompleted)
					{
						int num12 = 2;
						num = 2;
						num2 = num12;
						taskAwaiter6 = taskAwaiter14;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class52.Struct135>(ref taskAwaiter14, ref this);
						return;
					}
					IL_231:
					JObject result4 = taskAwaiter14.GetResult();
					result2 = result4;
					taskAwaiter15 = result.smethod_3().GetAwaiter();
					if (!taskAwaiter15.IsCompleted)
					{
						int num13 = 3;
						num = 3;
						num2 = num13;
						taskAwaiter8 = taskAwaiter15;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class52.Struct135>(ref taskAwaiter15, ref this);
						return;
					}
					IL_260:
					if (!taskAwaiter15.GetResult().Contains("not_enough_in_stock") && result2["checkout"]["line_items"].Any<JToken>())
					{
						if (result2["checkout"]["available_shipping_rates"] != null && result2["checkout"]["available_shipping_rates"].Any<JToken>())
						{
							@class.string_20 = result2["checkout"]["available_shipping_rates"][0]["id"].ToString();
						}
						@class.method_5("Successfully carted", "#c2c2c2", true, false);
						@class.bool_3 = true;
						goto IL_4EB;
					}
					@class.method_5("Waiting for restock", "#c2c2c2", true, false);
					taskAwaiter11 = @class.method_14(Class130.int_0).GetAwaiter();
					if (!taskAwaiter11.IsCompleted)
					{
						int num14 = 4;
						num = 4;
						num2 = num14;
						taskAwaiter10 = taskAwaiter11;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct135>(ref taskAwaiter11, ref this);
						return;
					}
					IL_2C6:
					taskAwaiter11.GetResult();
					taskAwaiter11 = @class.method_18().GetAwaiter();
					if (!taskAwaiter11.IsCompleted)
					{
						int num15 = 5;
						num = 5;
						num2 = num15;
						taskAwaiter10 = taskAwaiter11;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct135>(ref taskAwaiter11, ref this);
						return;
					}
					IL_2E5:
					taskAwaiter11.GetResult();
					goto IL_12A;
				}
				catch
				{
					num16 = 1;
				}
				if (num16 != 1)
				{
					goto IL_4A6;
				}
				@class.method_5("Error adding to cart", "#c2c2c2", true, false);
				taskAwaiter11 = @class.method_14(Class130.int_1).GetAwaiter();
				if (!taskAwaiter11.IsCompleted)
				{
					int num17 = 6;
					num = 6;
					num2 = num17;
					taskAwaiter10 = taskAwaiter11;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct135>(ref taskAwaiter11, ref this);
					return;
				}
				IL_496:
				taskAwaiter11.GetResult();
				IL_4A6:
				if (!@class.bool_1)
				{
					num16 = 0;
					goto IL_3C;
				}
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_4EB:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x0600079C RID: 1948 RVA: 0x000064E5 File Offset: 0x000046E5
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000653 RID: 1619
		public int int_0;

		// Token: 0x04000654 RID: 1620
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000655 RID: 1621
		public Class52 class52_0;

		// Token: 0x04000656 RID: 1622
		private HttpResponseMessage httpResponseMessage_0;

		// Token: 0x04000657 RID: 1623
		private JObject jobject_0;

		// Token: 0x04000658 RID: 1624
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000659 RID: 1625
		private TaskAwaiter<bool> taskAwaiter_1;

		// Token: 0x0400065A RID: 1626
		private TaskAwaiter<JObject> taskAwaiter_2;

		// Token: 0x0400065B RID: 1627
		private TaskAwaiter<string> taskAwaiter_3;

		// Token: 0x0400065C RID: 1628
		private TaskAwaiter taskAwaiter_4;
	}

	// Token: 0x02000156 RID: 342
	[StructLayout(LayoutKind.Auto)]
	private struct Struct136 : IAsyncStateMachine
	{
		// Token: 0x0600079D RID: 1949 RVA: 0x00043C24 File Offset: 0x00041E24
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class52 @class = this;
			try
			{
				if (num <= 1)
				{
					goto IL_1FB;
				}
				TaskAwaiter taskAwaiter7;
				if (num != 2)
				{
					if (@class.bool_5)
					{
						goto IL_1F1;
					}
					goto IL_222;
				}
				else
				{
					taskAwaiter7 = taskAwaiter6;
					taskAwaiter6 = default(TaskAwaiter);
					int num3 = -1;
					num = -1;
					num2 = num3;
				}
				IL_1EA:
				taskAwaiter7.GetResult();
				IL_1F1:
				if (@class.bool_1)
				{
					goto IL_222;
				}
				int num4 = 0;
				IL_1FB:
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
							goto IL_163;
						}
						@class.method_5("Getting token", "#c2c2c2", true, false);
						taskAwaiter9 = new Class14(@class.string_19, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36", 10, false, true, null).method_2(string.Format("{0}/cart/add/{1}", @class.string_8, @class.string_22), true).GetAwaiter();
						if (!taskAwaiter9.IsCompleted)
						{
							int num6 = 0;
							num = 0;
							num2 = num6;
							taskAwaiter2 = taskAwaiter9;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class52.Struct136>(ref taskAwaiter9, ref this);
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
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class52.Struct136>(ref taskAwaiter8, ref this);
						return;
					}
					IL_163:
					string result2 = taskAwaiter8.GetResult();
					htmlDocument2.LoadHtml(result2);
					htmlDocument2 = null;
					@class.string_13 = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='note']").Attributes["value"].Value;
					goto IL_23D;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_1F1;
				}
				@class.method_5("Error getting token", "#c2c2c2", true, false);
				taskAwaiter7 = @class.method_14(Class130.int_1).GetAwaiter();
				if (taskAwaiter7.IsCompleted)
				{
					goto IL_1EA;
				}
				int num9 = 2;
				num = 2;
				num2 = num9;
				taskAwaiter6 = taskAwaiter7;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct136>(ref taskAwaiter7, ref this);
				return;
				IL_222:;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_23D:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x0600079E RID: 1950 RVA: 0x000064F3 File Offset: 0x000046F3
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400065D RID: 1629
		public int int_0;

		// Token: 0x0400065E RID: 1630
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x0400065F RID: 1631
		public Class52 class52_0;

		// Token: 0x04000660 RID: 1632
		private HtmlDocument htmlDocument_0;

		// Token: 0x04000661 RID: 1633
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000662 RID: 1634
		private HtmlDocument htmlDocument_1;

		// Token: 0x04000663 RID: 1635
		private TaskAwaiter<string> taskAwaiter_1;

		// Token: 0x04000664 RID: 1636
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x02000157 RID: 343
	[StructLayout(LayoutKind.Auto)]
	private struct Struct137 : IAsyncStateMachine
	{
		// Token: 0x0600079F RID: 1951 RVA: 0x00043EB8 File Offset: 0x000420B8
		void IAsyncStateMachine.MoveNext()
		{
			int num3;
			int num2 = num3;
			Class52 @class = this;
			try
			{
				TaskAwaiter taskAwaiter3;
				if (num2 > 2)
				{
					if (num2 != 3)
					{
						@class.method_5("Waiting for product", "#c2c2c2", true, false);
						goto IL_375;
					}
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					int num4 = -1;
					num2 = -1;
					num3 = num4;
					goto IL_36E;
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
						goto IL_122;
					}
					case 2:
					{
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num7 = -1;
						num2 = -1;
						num3 = num7;
						goto IL_341;
					}
					default:
						taskAwaiter4 = GClass2.smethod_1("https://cybersolewebsite.azurewebsites.net/api/sitemaps?token=94112421582745227130", null, true).GetAwaiter();
						if (!taskAwaiter4.IsCompleted)
						{
							int num8 = 0;
							num2 = 0;
							num3 = num8;
							TaskAwaiter<HttpResponseMessage> taskAwaiter5 = taskAwaiter4;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class52.Struct137>(ref taskAwaiter4, ref this);
							return;
						}
						break;
					}
					HttpResponseMessage result = taskAwaiter4.GetResult();
					result.EnsureSuccessStatusCode();
					taskAwaiter6 = result.smethod_1().GetAwaiter();
					if (!taskAwaiter6.IsCompleted)
					{
						int num9 = 1;
						num2 = 1;
						num3 = num9;
						TaskAwaiter<JObject> taskAwaiter7 = taskAwaiter6;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class52.Struct137>(ref taskAwaiter6, ref this);
						return;
					}
					IL_122:
					IEnumerator<JProperty> enumerator = taskAwaiter6.GetResult().Properties().GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							Class52.Class166 class2 = new Class52.Class166();
							class2.jproperty_0 = enumerator.Current;
							JToken jtoken = class2.jproperty_0.Value["products"].FirstOrDefault(new Func<JToken, bool>(@class.method_45));
							if (jtoken != null)
							{
								JProperty jproperty = Class130.jobject_1.Properties().Where(new Func<JProperty, bool>(class2.method_0)).FirstOrDefault<JProperty>();
								string text = (jproperty != null) ? jproperty.Name : null;
								if (text != null)
								{
									@class.method_4(text);
									@class.method_7(jtoken["title"].ToString(), "#c2c2c2");
									@class.string_21 = Class130.jobject_1[text]["sitemap"].ToString();
									@class.string_8 = new Uri(@class.string_21).Scheme + "://" + new Uri(@class.string_21).Authority + "/";
									if (@class.bool_6)
									{
										if (@class.method_33(jtoken["variants"], out @class.string_22, "option1", "id", "available"))
										{
											goto IL_3D3;
										}
									}
									else
									{
										JToken jtoken2 = jtoken["variants"].Where(new Func<JToken, bool>(@class.method_46)).FirstOrDefault<JToken>();
										if (jtoken2 != null)
										{
											@class.string_22 = jtoken2["id"].ToString();
											if (!object.Equals(false, (bool)jtoken2["available"]))
											{
												goto IL_3D3;
											}
										}
									}
								}
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
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct137>(ref taskAwaiter3, ref this);
						return;
					}
					IL_341:
					taskAwaiter3.GetResult();
					goto IL_389;
				}
				catch
				{
					num = 1;
					goto IL_389;
				}
				IL_354:
				taskAwaiter3 = @class.method_14(Class130.int_0).GetAwaiter();
				if (taskAwaiter3.IsCompleted)
				{
					goto IL_36E;
				}
				int num11 = 3;
				num2 = 3;
				num3 = num11;
				taskAwaiter2 = taskAwaiter3;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct137>(ref taskAwaiter3, ref this);
				return;
				IL_389:
				int num12 = num;
				if (num12 == 1)
				{
					goto IL_354;
				}
				goto IL_375;
				IL_36E:
				taskAwaiter3.GetResult();
				IL_375:
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
			IL_3D3:
			num3 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060007A0 RID: 1952 RVA: 0x00006501 File Offset: 0x00004701
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000665 RID: 1637
		public int int_0;

		// Token: 0x04000666 RID: 1638
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000667 RID: 1639
		public Class52 class52_0;

		// Token: 0x04000668 RID: 1640
		private int int_1;

		// Token: 0x04000669 RID: 1641
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x0400066A RID: 1642
		private TaskAwaiter<JObject> taskAwaiter_1;

		// Token: 0x0400066B RID: 1643
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x02000158 RID: 344
	[StructLayout(LayoutKind.Auto)]
	private struct Struct138 : IAsyncStateMachine
	{
		// Token: 0x060007A1 RID: 1953 RVA: 0x000442F8 File Offset: 0x000424F8
		void IAsyncStateMachine.MoveNext()
		{
			int num3;
			int num2 = num3;
			Class52 @class = this;
			try
			{
				TaskAwaiter taskAwaiter3;
				if (num2 > 4)
				{
					if (num2 != 5)
					{
						@class.method_5("Waiting for product", "#c2c2c2", true, false);
						goto IL_43A;
					}
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					int num4 = -1;
					num2 = -1;
					num3 = num4;
					goto IL_413;
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
						goto IL_13C;
					}
					case 2:
					{
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num7 = -1;
						num2 = -1;
						num3 = num7;
						goto IL_377;
					}
					case 3:
					{
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num8 = -1;
						num2 = -1;
						num3 = num8;
						goto IL_39F;
					}
					case 4:
					{
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num9 = -1;
						num2 = -1;
						num3 = num9;
						goto IL_3C7;
					}
					default:
						@class.method_34();
						taskAwaiter4 = GClass2.smethod_1(@class.string_18 + ".js", null, true).GetAwaiter();
						if (!taskAwaiter4.IsCompleted)
						{
							int num10 = 0;
							num2 = 0;
							num3 = num10;
							TaskAwaiter<HttpResponseMessage> taskAwaiter5 = taskAwaiter4;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class52.Struct138>(ref taskAwaiter4, ref this);
							return;
						}
						break;
					}
					HttpResponseMessage result = taskAwaiter4.GetResult();
					result.EnsureSuccessStatusCode();
					taskAwaiter6 = result.smethod_1().GetAwaiter();
					if (!taskAwaiter6.IsCompleted)
					{
						int num11 = 1;
						num2 = 1;
						num3 = num11;
						TaskAwaiter<JObject> taskAwaiter7 = taskAwaiter6;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class52.Struct138>(ref taskAwaiter6, ref this);
						return;
					}
					IL_13C:
					JObject result2 = taskAwaiter6.GetResult();
					@class.method_7(result2["title"].ToString(), "#c2c2c2");
					@class.string_17 = result2["id"].ToString();
					@class.jtoken_0["product_id"] = @class.string_17;
					@class.string_2 = (string)result2["featured_image"];
					if (result2["tags"].Any(new Func<JToken, bool>(Class52.Class162.class162_0.method_2)))
					{
						@class.bool_4 = true;
					}
					if (@class.bool_6)
					{
						if (@class.method_33(result2["variants"], out @class.string_22, "option1", "id", "available"))
						{
							goto IL_47F;
						}
						@class.method_5("Waiting for restock", "#c2c2c2", true, false);
						taskAwaiter3 = @class.method_14(Class130.int_0).GetAwaiter();
						if (!taskAwaiter3.IsCompleted)
						{
							int num12 = 2;
							num2 = 2;
							num3 = num12;
							taskAwaiter2 = taskAwaiter3;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct138>(ref taskAwaiter3, ref this);
							return;
						}
					}
					else
					{
						JToken jtoken = result2["variants"].FirstOrDefault(new Func<JToken, bool>(@class.method_60));
						if (jtoken != null)
						{
							@class.string_22 = jtoken["id"].ToString();
							if (!object.Equals(false, (bool)jtoken["available"]))
							{
								goto IL_47F;
							}
							@class.method_5("Waiting for restock", "#c2c2c2", true, false);
							taskAwaiter3 = @class.method_14(Class130.int_0).GetAwaiter();
							if (!taskAwaiter3.IsCompleted)
							{
								int num13 = 3;
								num2 = 3;
								num3 = num13;
								taskAwaiter2 = taskAwaiter3;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct138>(ref taskAwaiter3, ref this);
								return;
							}
							goto IL_39F;
						}
						else
						{
							taskAwaiter3 = @class.method_14(Class130.int_0).GetAwaiter();
							if (!taskAwaiter3.IsCompleted)
							{
								int num14 = 4;
								num2 = 4;
								num3 = num14;
								taskAwaiter2 = taskAwaiter3;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct138>(ref taskAwaiter3, ref this);
								return;
							}
							goto IL_3C7;
						}
					}
					IL_377:
					taskAwaiter3.GetResult();
					goto IL_43A;
					IL_39F:
					taskAwaiter3.GetResult();
					goto IL_43A;
					IL_3C7:
					taskAwaiter3.GetResult();
					@class.method_5("Waiting for product", "#c2c2c2", false, false);
				}
				catch
				{
					num = 1;
				}
				int num15 = num;
				if (num15 != 1)
				{
					goto IL_43A;
				}
				taskAwaiter3 = @class.method_14(Class130.int_0).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					int num16 = 5;
					num2 = 5;
					num3 = num16;
					taskAwaiter2 = taskAwaiter3;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct138>(ref taskAwaiter3, ref this);
					return;
				}
				IL_413:
				taskAwaiter3.GetResult();
				@class.method_5("Waiting for product", "#c2c2c2", false, false);
				IL_43A:
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
			IL_47F:
			num3 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060007A2 RID: 1954 RVA: 0x0000650F File Offset: 0x0000470F
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400066C RID: 1644
		public int int_0;

		// Token: 0x0400066D RID: 1645
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x0400066E RID: 1646
		public Class52 class52_0;

		// Token: 0x0400066F RID: 1647
		private int int_1;

		// Token: 0x04000670 RID: 1648
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000671 RID: 1649
		private TaskAwaiter<JObject> taskAwaiter_1;

		// Token: 0x04000672 RID: 1650
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x02000159 RID: 345
	[StructLayout(LayoutKind.Auto)]
	private struct Struct139 : IAsyncStateMachine
	{
		// Token: 0x060007A3 RID: 1955 RVA: 0x000447CC File Offset: 0x000429CC
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class52 @class = this;
			try
			{
				TaskAwaiter taskAwaiter;
				if (num != 0)
				{
					@class.method_5("Verifying checkout URL", "#c2c2c2", true, false);
					if (!(new Uri(@class.string_11).Authority != new Uri(@class.string_8).Authority))
					{
						goto IL_A3;
					}
					taskAwaiter = @class.method_37(null).GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 0;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct139>(ref taskAwaiter, ref this);
						return;
					}
				}
				else
				{
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					num2 = -1;
				}
				taskAwaiter.GetResult();
				IL_A3:;
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

		// Token: 0x060007A4 RID: 1956 RVA: 0x0000651D File Offset: 0x0000471D
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000673 RID: 1651
		public int int_0;

		// Token: 0x04000674 RID: 1652
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000675 RID: 1653
		public Class52 class52_0;

		// Token: 0x04000676 RID: 1654
		private TaskAwaiter taskAwaiter_0;
	}

	// Token: 0x0200015A RID: 346
	[StructLayout(LayoutKind.Auto)]
	private struct Struct140 : IAsyncStateMachine
	{
		// Token: 0x060007A5 RID: 1957 RVA: 0x000448B8 File Offset: 0x00042AB8
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class52 @class = this;
			try
			{
				TaskAwaiter taskAwaiter9;
				if (num > 6)
				{
					if (num != 7)
					{
						goto IL_4DD;
					}
					taskAwaiter9 = taskAwaiter6;
					taskAwaiter6 = default(TaskAwaiter);
					int num3 = -1;
					num = -1;
					num2 = num3;
					goto IL_4CC;
				}
				IL_3D:
				int num18;
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter10;
					TaskAwaiter<bool> taskAwaiter11;
					TaskAwaiter<JObject> taskAwaiter12;
					TaskAwaiter<string> taskAwaiter13;
					switch (num)
					{
					case 0:
					{
						taskAwaiter10 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
						int num4 = -1;
						num = -1;
						num2 = num4;
						goto IL_14B;
					}
					case 1:
					{
						taskAwaiter11 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<bool>);
						int num5 = -1;
						num = -1;
						num2 = num5;
						goto IL_17A;
					}
					case 2:
					{
						taskAwaiter9 = taskAwaiter6;
						taskAwaiter6 = default(TaskAwaiter);
						int num6 = -1;
						num = -1;
						num2 = num6;
						goto IL_1BB;
					}
					case 3:
					{
						taskAwaiter10 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
						int num7 = -1;
						num = -1;
						num2 = num7;
						goto IL_1F0;
					}
					case 4:
					{
						taskAwaiter11 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<bool>);
						int num8 = -1;
						num = -1;
						num2 = num8;
						goto IL_21F;
					}
					case 5:
					{
						taskAwaiter12 = taskAwaiter8;
						taskAwaiter8 = default(TaskAwaiter<JObject>);
						int num9 = -1;
						num = -1;
						num2 = num9;
						goto IL_344;
					}
					case 6:
					{
						TaskAwaiter<string> taskAwaiter14;
						taskAwaiter13 = taskAwaiter14;
						taskAwaiter14 = default(TaskAwaiter<string>);
						int num10 = -1;
						num = -1;
						num2 = num10;
						goto IL_3B1;
					}
					}
					IL_10B:
					@class.method_5("Getting shipping rates", "#c2c2c2", true, false);
					taskAwaiter10 = @class.class14_0.method_2(@class.string_7 + "/shipping_rates.json", false).GetAwaiter();
					if (!taskAwaiter10.IsCompleted)
					{
						int num11 = 0;
						num = 0;
						num2 = num11;
						taskAwaiter2 = taskAwaiter10;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class52.Struct140>(ref taskAwaiter10, ref this);
						return;
					}
					IL_14B:
					HttpResponseMessage result3 = taskAwaiter10.GetResult();
					result = result3;
					taskAwaiter11 = @class.method_32(result).GetAwaiter();
					if (!taskAwaiter11.IsCompleted)
					{
						int num12 = 1;
						num = 1;
						num2 = num12;
						taskAwaiter4 = taskAwaiter11;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, Class52.Struct140>(ref taskAwaiter11, ref this);
						return;
					}
					IL_17A:
					if (taskAwaiter11.GetResult())
					{
						goto IL_4DD;
					}
					IL_186:
					if (result.StatusCode != HttpStatusCode.Accepted)
					{
						taskAwaiter12 = result.smethod_1().GetAwaiter();
						if (!taskAwaiter12.IsCompleted)
						{
							int num13 = 5;
							num = 5;
							num2 = num13;
							taskAwaiter8 = taskAwaiter12;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class52.Struct140>(ref taskAwaiter12, ref this);
							return;
						}
						goto IL_344;
					}
					else
					{
						taskAwaiter9 = @class.method_14(500).GetAwaiter();
						if (!taskAwaiter9.IsCompleted)
						{
							int num14 = 2;
							num = 2;
							num2 = num14;
							taskAwaiter6 = taskAwaiter9;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct140>(ref taskAwaiter9, ref this);
							return;
						}
					}
					IL_1BB:
					taskAwaiter9.GetResult();
					taskAwaiter10 = @class.class14_0.method_2(@class.string_7 + "/shipping_rates.json", false).GetAwaiter();
					if (!taskAwaiter10.IsCompleted)
					{
						int num15 = 3;
						num = 3;
						num2 = num15;
						taskAwaiter2 = taskAwaiter10;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class52.Struct140>(ref taskAwaiter10, ref this);
						return;
					}
					IL_1F0:
					result3 = taskAwaiter10.GetResult();
					result = result3;
					taskAwaiter11 = @class.method_32(result).GetAwaiter();
					if (!taskAwaiter11.IsCompleted)
					{
						int num16 = 4;
						num = 4;
						num2 = num16;
						taskAwaiter4 = taskAwaiter11;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, Class52.Struct140>(ref taskAwaiter11, ref this);
						return;
					}
					IL_21F:
					if (!taskAwaiter11.GetResult())
					{
						goto IL_186;
					}
					goto IL_10B;
					IL_344:
					JObject result4 = taskAwaiter12.GetResult();
					result2 = result4;
					taskAwaiter13 = result.smethod_3().GetAwaiter();
					if (!taskAwaiter13.IsCompleted)
					{
						int num17 = 6;
						num = 6;
						num2 = num17;
						TaskAwaiter<string> taskAwaiter14 = taskAwaiter13;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class52.Struct140>(ref taskAwaiter13, ref this);
						return;
					}
					IL_3B1:
					string result5 = taskAwaiter13.GetResult();
					if (result5.Contains("does_not_require_shipping"))
					{
						@class.string_20 = null;
						goto IL_523;
					}
					if (result5.Contains("is_not_supported"))
					{
						@class.method_0("Country not supported", "red", true, (GEnum1)0);
						goto IL_523;
					}
					if (result5.Contains("is_not"))
					{
						@class.method_0("Invalid shipping address", "red", true, (GEnum1)0);
						goto IL_523;
					}
					if (!result2["shipping_rates"].Any<JToken>())
					{
						@class.method_0("Country not supported", "red", true, (GEnum1)0);
					}
					@class.string_20 = result2["shipping_rates"][0]["id"].ToString();
					@class.method_5("Found shipping rate", "#c2c2c2", true, false);
					goto IL_523;
				}
				catch (ThreadAbortException)
				{
					goto IL_523;
				}
				catch
				{
					num18 = 1;
				}
				if (num18 != 1)
				{
					goto IL_4DD;
				}
				@class.method_5("Error getting shipping rates", "#c2c2c2", true, false);
				taskAwaiter9 = @class.method_14(Class130.int_1).GetAwaiter();
				if (!taskAwaiter9.IsCompleted)
				{
					int num19 = 7;
					num = 7;
					num2 = num19;
					taskAwaiter6 = taskAwaiter9;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct140>(ref taskAwaiter9, ref this);
					return;
				}
				IL_4CC:
				taskAwaiter9.GetResult();
				IL_4DD:
				if (!@class.bool_1)
				{
					num18 = 0;
					goto IL_3D;
				}
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_523:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060007A6 RID: 1958 RVA: 0x0000652B File Offset: 0x0000472B
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000677 RID: 1655
		public int int_0;

		// Token: 0x04000678 RID: 1656
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000679 RID: 1657
		public Class52 class52_0;

		// Token: 0x0400067A RID: 1658
		private HttpResponseMessage httpResponseMessage_0;

		// Token: 0x0400067B RID: 1659
		private JObject jobject_0;

		// Token: 0x0400067C RID: 1660
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x0400067D RID: 1661
		private TaskAwaiter<bool> taskAwaiter_1;

		// Token: 0x0400067E RID: 1662
		private TaskAwaiter taskAwaiter_2;

		// Token: 0x0400067F RID: 1663
		private TaskAwaiter<JObject> taskAwaiter_3;

		// Token: 0x04000680 RID: 1664
		private TaskAwaiter<string> taskAwaiter_4;
	}

	// Token: 0x0200015B RID: 347
	[StructLayout(LayoutKind.Auto)]
	private struct Struct141 : IAsyncStateMachine
	{
		// Token: 0x060007A7 RID: 1959 RVA: 0x00044E48 File Offset: 0x00043048
		void IAsyncStateMachine.MoveNext()
		{
			int num3;
			int num2 = num3;
			Class52 @class = this;
			try
			{
				TaskAwaiter taskAwaiter5;
				if (num2 > 3)
				{
					if (num2 != 4)
					{
						@class.method_5("Waiting for product", "#c2c2c2", true, false);
						goto IL_34D;
					}
					taskAwaiter5 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
					int num4 = -1;
					num2 = -1;
					num3 = num4;
					goto IL_334;
				}
				IL_4E:
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter6;
					TaskAwaiter<string> taskAwaiter7;
					switch (num2)
					{
					case 0:
					{
						taskAwaiter5 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num5 = -1;
						num2 = -1;
						num3 = num5;
						break;
					}
					case 1:
					{
						taskAwaiter6 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<HttpResponseMessage>);
						int num6 = -1;
						num2 = -1;
						num3 = num6;
						goto IL_12E;
					}
					case 2:
					{
						TaskAwaiter<string> taskAwaiter8;
						taskAwaiter7 = taskAwaiter8;
						taskAwaiter8 = default(TaskAwaiter<string>);
						int num7 = -1;
						num2 = -1;
						num3 = num7;
						goto IL_1A9;
					}
					case 3:
					{
						taskAwaiter5 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num8 = -1;
						num2 = -1;
						num3 = num8;
						goto IL_2EE;
					}
					default:
						if (@class.method_34())
						{
							taskAwaiter5 = @class.method_26().GetAwaiter();
							if (!taskAwaiter5.IsCompleted)
							{
								int num9 = 0;
								num2 = 0;
								num3 = num9;
								taskAwaiter2 = taskAwaiter5;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct141>(ref taskAwaiter5, ref this);
								return;
							}
						}
						else
						{
							taskAwaiter6 = GClass2.smethod_1(@class.string_21, null, true).GetAwaiter();
							if (!taskAwaiter6.IsCompleted)
							{
								int num10 = 1;
								num2 = 1;
								num3 = num10;
								taskAwaiter4 = taskAwaiter6;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class52.Struct141>(ref taskAwaiter6, ref this);
								return;
							}
							goto IL_12E;
						}
						break;
					}
					taskAwaiter5.GetResult();
					goto IL_3AB;
					IL_12E:
					HttpResponseMessage result = taskAwaiter6.GetResult();
					result.EnsureSuccessStatusCode();
					xmlDocument = new XmlDocument();
					xmlDocument2 = xmlDocument;
					taskAwaiter7 = result.smethod_3().GetAwaiter();
					if (!taskAwaiter7.IsCompleted)
					{
						int num11 = 2;
						num2 = 2;
						num3 = num11;
						TaskAwaiter<string> taskAwaiter8 = taskAwaiter7;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class52.Struct141>(ref taskAwaiter7, ref this);
						return;
					}
					IL_1A9:
					string result2 = taskAwaiter7.GetResult();
					xmlDocument2.LoadXml(result2);
					xmlDocument2 = null;
					IEnumerator enumerator = xmlDocument.GetElementsByTagName("entry").GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							XmlNode xmlNode = (XmlNode)obj;
							if (@class.string_15.All(new Func<string, bool>(xmlNode["title"].InnerText.ToLower().Contains)) && !@class.string_12.Any(new Func<string, bool>(xmlNode["title"].InnerText.ToLower().Contains)))
							{
								@class.string_18 = xmlNode["link"].Attributes["href"].Value;
								goto IL_3AB;
							}
						}
					}
					finally
					{
						if (num2 < 0)
						{
							IDisposable disposable = enumerator as IDisposable;
							if (disposable != null)
							{
								disposable.Dispose();
							}
						}
					}
					taskAwaiter5 = @class.method_14(Class130.int_0).GetAwaiter();
					if (!taskAwaiter5.IsCompleted)
					{
						int num12 = 3;
						num2 = 3;
						num3 = num12;
						taskAwaiter2 = taskAwaiter5;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct141>(ref taskAwaiter5, ref this);
						return;
					}
					IL_2EE:
					taskAwaiter5.GetResult();
					@class.method_5("Waiting for product", "#c2c2c2", false, false);
					xmlDocument = null;
					goto IL_361;
				}
				catch
				{
					num = 1;
					goto IL_361;
				}
				IL_31A:
				taskAwaiter5 = @class.method_14(Class130.int_0).GetAwaiter();
				if (taskAwaiter5.IsCompleted)
				{
					goto IL_334;
				}
				int num13 = 4;
				num2 = 4;
				num3 = num13;
				taskAwaiter2 = taskAwaiter5;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct141>(ref taskAwaiter5, ref this);
				return;
				IL_361:
				int num14 = num;
				if (num14 == 1)
				{
					goto IL_31A;
				}
				goto IL_34D;
				IL_334:
				taskAwaiter5.GetResult();
				@class.method_5("Waiting for product", "#c2c2c2", false, false);
				IL_34D:
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
			IL_3AB:
			num3 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060007A8 RID: 1960 RVA: 0x00006539 File Offset: 0x00004739
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000681 RID: 1665
		public int int_0;

		// Token: 0x04000682 RID: 1666
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000683 RID: 1667
		public Class52 class52_0;

		// Token: 0x04000684 RID: 1668
		private int int_1;

		// Token: 0x04000685 RID: 1669
		private XmlDocument xmlDocument_0;

		// Token: 0x04000686 RID: 1670
		private TaskAwaiter taskAwaiter_0;

		// Token: 0x04000687 RID: 1671
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_1;

		// Token: 0x04000688 RID: 1672
		private XmlDocument xmlDocument_1;

		// Token: 0x04000689 RID: 1673
		private TaskAwaiter<string> taskAwaiter_2;
	}

	// Token: 0x0200015C RID: 348
	[StructLayout(LayoutKind.Auto)]
	private struct Struct142 : IAsyncStateMachine
	{
		// Token: 0x060007A9 RID: 1961 RVA: 0x00045260 File Offset: 0x00043460
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class52 @class = this;
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
						goto IL_127;
					}
					case 2:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_18A;
					}
					case 3:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_1F7;
					}
					case 4:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_266;
					}
					case 5:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_2C9;
					}
					case 6:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_324;
					}
					case 7:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_37F;
					}
					case 8:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_3DA;
					}
					case 9:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_437;
					}
					case 10:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_494;
					}
					default:
						@class.method_5("Setting up", "#c2c2c2", true, false);
						task = @class.method_35();
						task2 = @class.method_40(false);
						taskAwaiter = @class.method_29().GetAwaiter();
						if (!taskAwaiter.IsCompleted)
						{
							num2 = 0;
							TaskAwaiter taskAwaiter2 = taskAwaiter;
							this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct142>(ref taskAwaiter, ref this);
							return;
						}
						break;
					}
					taskAwaiter.GetResult();
					task3 = @class.method_37(null);
					taskAwaiter = @class.method_11().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 1;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct142>(ref taskAwaiter, ref this);
						return;
					}
					IL_127:
					taskAwaiter.GetResult();
					if (@class.string_22 != null)
					{
						goto IL_191;
					}
					taskAwaiter = @class.method_18().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 2;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct142>(ref taskAwaiter, ref this);
						return;
					}
					IL_18A:
					taskAwaiter.GetResult();
					IL_191:
					@class.method_5("Waiting for checkout URL", "#c2c2c2", true, false);
					taskAwaiter = task3.GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 3;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct142>(ref taskAwaiter, ref this);
						return;
					}
					IL_1F7:
					taskAwaiter.GetResult();
					task4 = @class.method_28();
					if (@class.bool_3)
					{
						goto IL_26D;
					}
					taskAwaiter = @class.method_36().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 4;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct142>(ref taskAwaiter, ref this);
						return;
					}
					IL_266:
					taskAwaiter.GetResult();
					IL_26D:
					if (@class.string_20 != null)
					{
						goto IL_2D0;
					}
					taskAwaiter = @class.method_15().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 5;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct142>(ref taskAwaiter, ref this);
						return;
					}
					IL_2C9:
					taskAwaiter.GetResult();
					IL_2D0:
					taskAwaiter = task.GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 6;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct142>(ref taskAwaiter, ref this);
						return;
					}
					IL_324:
					taskAwaiter.GetResult();
					taskAwaiter = task2.GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 7;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct142>(ref taskAwaiter, ref this);
						return;
					}
					IL_37F:
					taskAwaiter.GetResult();
					taskAwaiter = task4.GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 8;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct142>(ref taskAwaiter, ref this);
						return;
					}
					IL_3DA:
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_43().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 9;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct142>(ref taskAwaiter, ref this);
						return;
					}
					IL_437:
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_44().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 10;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class52.Struct142>(ref taskAwaiter, ref this);
						return;
					}
					IL_494:
					taskAwaiter.GetResult();
					task = null;
					task2 = null;
					task3 = null;
					task4 = null;
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

		// Token: 0x060007AA RID: 1962 RVA: 0x00006547 File Offset: 0x00004747
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400068A RID: 1674
		public int int_0;

		// Token: 0x0400068B RID: 1675
		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		// Token: 0x0400068C RID: 1676
		public Class52 class52_0;

		// Token: 0x0400068D RID: 1677
		private Task task_0;

		// Token: 0x0400068E RID: 1678
		private Task task_1;

		// Token: 0x0400068F RID: 1679
		private Task task_2;

		// Token: 0x04000690 RID: 1680
		private Task task_3;

		// Token: 0x04000691 RID: 1681
		private TaskAwaiter taskAwaiter_0;
	}
}
