using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

// Token: 0x02000021 RID: 33
internal sealed class Class45 : Class44
{
	// Token: 0x060000BC RID: 188 RVA: 0x0000A450 File Offset: 0x00008650
	public Class45(JToken jtoken_2, string string_17, string string_18)
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
				this.string_7 = string_17;
				this.string_8 = string_18;
				this.string_10 = (string)jtoken_2["keywords"];
				this.string_0 = ((string)jtoken_2["size"]).Replace("UK ", string.Empty);
				if (this.string_0 == "Random" || this.string_0 == "OneSize")
				{
					this.bool_0 = true;
				}
				this.jobject_0 = new JObject();
				this.jobject_0["User-Agent"] = "Dalvik/2.1.0 (Linux; U; Android 7.0; SM-G950F Build/NRD90M)";
				this.jobject_0["x-api-key"] = string_18;
				this.class14_0 = new Class14(base.method_3(), "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36", 10, false, false, this.jobject_0);
			}
		}
		catch
		{
			base.method_0("Task error", "red", true, (GEnum1)0);
		}
	}

	// Token: 0x060000BD RID: 189 RVA: 0x0000A588 File Offset: 0x00008788
	public override async void vmethod_0()
	{
		try
		{
			Task task = this.method_19();
			await base.method_11();
			await this.method_15();
			base.method_5("Registering customer", "#c2c2c2", true, false);
			await task;
			await this.method_16();
			await this.method_21();
			await this.method_22();
			task = null;
		}
		catch
		{
		}
		base.method_0("Stopped", "red", true, (GEnum1)0);
	}

	// Token: 0x060000BE RID: 190 RVA: 0x000031FF File Offset: 0x000013FF
	public static string smethod_0(Uri uri_0, string string_17)
	{
		return Class45.smethod_2("e705e8f04c662635f34962dfcac2af75", "1c88f5f855", uri_0, string_17);
	}

	// Token: 0x060000BF RID: 191 RVA: 0x00003212 File Offset: 0x00001412
	public static string smethod_1(Uri uri_0, string string_17)
	{
		return Class45.smethod_2("87576edd5a373b323271ad0e367ba452", "7c480586f6", uri_0, string_17);
	}

	// Token: 0x060000C0 RID: 192 RVA: 0x0000A5C4 File Offset: 0x000087C4
	public static string smethod_2(string string_17, string string_18, Uri uri_0, string string_19)
	{
		int num = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
		string text = Guid.NewGuid().ToString().Substring(0, 6);
		string s = string.Format("hawk.1.header\n{0}\n{1}\n{2}\n{3}\n{4}\n80\n\n\n", new object[]
		{
			num,
			text,
			string_19,
			uri_0.PathAndQuery,
			uri_0.Host
		});
		string text2 = Convert.ToBase64String(new HMACSHA256(Encoding.ASCII.GetBytes(string_17)).ComputeHash(Encoding.ASCII.GetBytes(s)));
		return string.Format("Hawk id={0}, mac={1}, ts={2}, nonce={3}, ext=", new object[]
		{
			string_18,
			text2,
			num,
			text
		});
	}

	// Token: 0x060000C1 RID: 193 RVA: 0x0000A694 File Offset: 0x00008894
	public async Task method_15()
	{
		base.method_5("Waiting for product", "#c2c2c2", true, false);
		while (!this.bool_1)
		{
			int num = 0;
			TaskAwaiter taskAwaiter4;
			try
			{
				HttpResponseMessage httpResponseMessage = await GClass2.smethod_1(string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/products/{1}", this.string_7, this.string_10), this.jobject_0, true);
				TaskAwaiter<string> taskAwaiter = httpResponseMessage.smethod_3().GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter<string> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<string>);
				}
				if (taskAwaiter.GetResult().Contains("Product could not be found"))
				{
					TaskAwaiter taskAwaiter3 = base.method_14(Class130.int_0).GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						await taskAwaiter3;
						taskAwaiter3 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter);
					}
					taskAwaiter3.GetResult();
					base.method_5("Waiting for product", "#c2c2c2", true, false);
					continue;
				}
				httpResponseMessage.EnsureSuccessStatusCode();
				TaskAwaiter<JObject> taskAwaiter5 = httpResponseMessage.smethod_1().GetAwaiter();
				if (!taskAwaiter5.IsCompleted)
				{
					await taskAwaiter5;
					TaskAwaiter<JObject> taskAwaiter6;
					taskAwaiter5 = taskAwaiter6;
					taskAwaiter6 = default(TaskAwaiter<JObject>);
				}
				JObject result = taskAwaiter5.GetResult();
				base.method_7(result["name"].ToString(), "#c2c2c2");
				if (this.bool_0)
				{
					JToken[] array = result["sortedOptions"].Where(new Func<JToken, bool>(Class45.Class16.class16_0.method_0)).ToArray<JToken>();
					if (array.Length == 0)
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
						continue;
					}
					JToken jtoken = array[MainWindow.random_0.Next(0, array.Length)];
					base.method_6(jtoken["name"].ToString());
					this.string_9 = jtoken["product"]["SKU"].ToString();
				}
				else
				{
					JToken jtoken2 = result["sortedOptions"].FirstOrDefault(new Func<JToken, bool>(this.method_24));
					if (jtoken2 == null)
					{
						throw new Exception();
					}
					if (jtoken2["product"]["stockStatus"].ToString() != "IN STOCK")
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
						continue;
					}
					base.method_6(jtoken2["name"].ToString());
					this.string_9 = jtoken2["product"]["SKU"].ToString();
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
				TaskAwaiter taskAwaiter3 = base.method_14(Class130.int_0).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter);
				}
				taskAwaiter3.GetResult();
				base.method_5("Waiting for product", "#c2c2c2", true, false);
			}
		}
	}

	// Token: 0x060000C2 RID: 194 RVA: 0x0000A6DC File Offset: 0x000088DC
	public async Task method_16()
	{
		while (!this.bool_1)
		{
			int num = 0;
			TaskAwaiter taskAwaiter6;
			try
			{
				base.method_5("Adding to cart", "#c2c2c2", true, false);
				JObject jobject = new JObject();
				jobject["SKU"] = this.string_9;
				jobject["quantity"] = 1;
				jobject["type"] = "cartproduct";
				JObject jobject2 = new JObject();
				jobject2["contents"] = new JArray(jobject);
				jobject2["customer"] = new JObject();
				jobject2["customer"]["id"] = string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/customers/{1}", this.string_7, this.string_12);
				jobject2["billingAddress"] = new JObject();
				jobject2["billingAddress"]["id"] = string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/customers/{1}/addresses/{2}", this.string_7, this.string_12, this.string_13);
				jobject2["deliveryAddress"] = new JObject();
				jobject2["deliveryAddress"]["id"] = string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/customers/{1}/addresses/{2}", this.string_7, this.string_12, this.string_13);
				jobject2["terminals"] = new JObject();
				jobject2["terminals"]["successURL"] = "http://ok";
				jobject2["terminals"]["failureURL"] = "http://fail";
				jobject2["terminals"]["timeoutURL"] = "http://timeout";
				HttpResponseMessage httpResponseMessage = await this.class14_0.method_4(string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/carts", this.string_7), jobject2, false);
				for (;;)
				{
					TaskAwaiter<string> taskAwaiter = httpResponseMessage.smethod_3().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						await taskAwaiter;
						TaskAwaiter<string> taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<string>);
					}
					if (!taskAwaiter.GetResult().Contains("There is no stock available"))
					{
						break;
					}
					base.method_5("Waiting for restock", "#c2c2c2", true, false);
					TaskAwaiter<HttpResponseMessage> taskAwaiter3 = this.class14_0.method_4(string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/carts", this.string_7), jobject2, false).GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						await taskAwaiter3;
						TaskAwaiter<HttpResponseMessage> taskAwaiter4;
						taskAwaiter3 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<HttpResponseMessage>);
					}
					httpResponseMessage = taskAwaiter3.GetResult();
					TaskAwaiter taskAwaiter5 = base.method_14(Class130.int_0).GetAwaiter();
					if (!taskAwaiter5.IsCompleted)
					{
						await taskAwaiter5;
						taskAwaiter5 = taskAwaiter6;
						taskAwaiter6 = default(TaskAwaiter);
					}
					taskAwaiter5.GetResult();
				}
				httpResponseMessage.EnsureSuccessStatusCode();
				TaskAwaiter<JObject> taskAwaiter7 = httpResponseMessage.smethod_1().GetAwaiter();
				if (!taskAwaiter7.IsCompleted)
				{
					await taskAwaiter7;
					TaskAwaiter<JObject> taskAwaiter8;
					taskAwaiter7 = taskAwaiter8;
					taskAwaiter8 = default(TaskAwaiter<JObject>);
				}
				JObject result = taskAwaiter7.GetResult();
				this.string_11 = result["ID"].ToString();
				this.string_14 = result["delivery"]["deliveryMethodID"].ToString();
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
				base.method_5("Error adding to cart", "#c2c2c2", true, false);
				TaskAwaiter taskAwaiter5 = base.method_14(Class130.int_1).GetAwaiter();
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

	// Token: 0x060000C3 RID: 195 RVA: 0x0000A724 File Offset: 0x00008924
	public async Task method_17()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Getting delivery method ID", "#c2c2c2", true, false);
				TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class14_0.method_2(string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/carts/{1}/deliveryOptionsForProposedAddress?deliverylocale={2}&q={3}", new object[]
				{
					this.string_7,
					this.string_11,
					Class43.smethod_0((string)this.jtoken_1["delivery"]["country"], false),
					(string)this.jtoken_1["delivery"]["zip"]
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
				TaskAwaiter<JObject> taskAwaiter3 = result.smethod_1().GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<JObject> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<JObject>);
				}
				this.string_14 = taskAwaiter3.GetResult()["deliveryMethods"][0]["ID"].ToString();
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
				base.method_5("Error getting delivery method", "#c2c2c2", true, false);
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

	// Token: 0x060000C4 RID: 196 RVA: 0x0000A76C File Offset: 0x0000896C
	public async Task method_18()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Setting delivery method", "#c2c2c2", true, false);
				JObject jobject = new JObject();
				jobject["delivery"] = new JObject();
				jobject["delivery"]["deliveryMethodID"] = this.string_14;
				(await this.class14_0.method_8(string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/carts/{1}", this.string_7, this.string_11), jobject, false)).EnsureSuccessStatusCode();
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
				base.method_5("Error setting delivery method", "#c2c2c2", true, false);
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

	// Token: 0x060000C5 RID: 197 RVA: 0x0000A7B4 File Offset: 0x000089B4
	public async Task method_19()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Collecting delivery data", "#c2c2c2", true, false);
				JObject jobject = new JObject();
				jobject["firstName"] = this.jtoken_1["delivery"]["first_name"];
				jobject["lastName"] = this.jtoken_1["delivery"]["last_name"];
				jobject["email"] = this.jtoken_1["payment"]["email"];
				jobject["phone"] = this.jtoken_1["payment"]["phone"];
				jobject["enrolledForEmailMarketing"] = false;
				jobject["isGuest"] = true;
				JObject jobject2 = jobject;
				JObject jobject3 = new JObject();
				jobject3["firstName"] = this.jtoken_1["delivery"]["first_name"];
				jobject3["lastName"] = this.jtoken_1["delivery"]["last_name"];
				jobject3["address1"] = this.jtoken_1["delivery"]["addr1"];
				jobject3["address2"] = this.jtoken_1["delivery"]["addr2"];
				jobject3["country"] = this.jtoken_1["delivery"]["country"];
				jobject3["locale"] = Class43.smethod_0((string)this.jtoken_1["delivery"]["country"], false);
				jobject3["state"] = Class43.smethod_1((string)this.jtoken_1["delivery"]["country"], (string)this.jtoken_1["delivery"]["state"]);
				jobject3["postcode"] = this.jtoken_1["delivery"]["zip"];
				jobject3["town"] = this.jtoken_1["delivery"]["city"];
				jobject3["isPrimaryBillingAddress"] = false;
				jobject3["isPrimaryAddress"] = true;
				JObject jobject4 = jobject3;
				JObject jobject5 = new JObject();
				jobject5["firstName"] = this.jtoken_1["billing"]["first_name"];
				jobject5["lastName"] = this.jtoken_1["billing"]["last_name"];
				jobject5["address1"] = this.jtoken_1["billing"]["addr1"];
				jobject5["address2"] = this.jtoken_1["billing"]["addr2"];
				jobject5["country"] = this.jtoken_1["billing"]["first_ncountryame"];
				jobject5["locale"] = Class43.smethod_0((string)this.jtoken_1["billing"]["country"], false);
				jobject5["state"] = Class43.smethod_1((string)this.jtoken_1["billing"]["country"], (string)this.jtoken_1["billing"]["state"]);
				jobject5["postcode"] = this.jtoken_1["billing"]["zip"];
				jobject5["town"] = this.jtoken_1["billing"]["city"];
				jobject5["isPrimaryBillingAddress"] = true;
				jobject5["isPrimaryAddress"] = false;
				JObject jobject6 = jobject5;
				jobject2["addresses"] = new JArray(new object[]
				{
					jobject4,
					jobject6
				});
				TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class14_0.method_4(string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/customers", this.string_7), jobject2, false).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter<HttpResponseMessage> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
				}
				HttpResponseMessage result = taskAwaiter.GetResult();
				if (result.StatusCode == HttpStatusCode.Conflict)
				{
					base.method_0("Invalid info", "red", true, (GEnum1)0);
				}
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
				this.string_12 = result2["ID"].ToString();
				this.string_13 = result2["addresses"][0]["ID"].ToString();
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error collecting delivery data", "#c2c2c2", true, false);
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

	// Token: 0x060000C6 RID: 198 RVA: 0x0000A7FC File Offset: 0x000089FC
	public async Task method_20()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Setting delivery data", "#c2c2c2", true, false);
				JObject jobject = new JObject();
				string propertyName = "customer";
				JObject jobject2 = new JObject();
				jobject2["id"] = string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/customers/{1}", this.string_7, this.string_12);
				jobject[propertyName] = jobject2;
				string propertyName2 = "billingAddress";
				JObject jobject3 = new JObject();
				jobject3["id"] = string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/customers/{1}/addresses/{2}", this.string_7, this.string_12, this.string_13);
				jobject[propertyName2] = jobject3;
				string propertyName3 = "deliveryAddress";
				JObject jobject4 = new JObject();
				jobject4["id"] = string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/customers/{1}/addresses/{2}", this.string_7, this.string_12, this.string_13);
				jobject[propertyName3] = jobject4;
				TaskAwaiter<HttpResponseMessage> taskAwaiter = this.class14_0.method_8(string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/carts/{1}", this.string_7, this.string_11), jobject, false).GetAwaiter();
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
				this.string_14 = taskAwaiter3.GetResult()["delivery"]["deliveryMethodID"].ToString();
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error setting delivery data", "#c2c2c2", true, false);
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

	// Token: 0x060000C7 RID: 199 RVA: 0x0000A844 File Offset: 0x00008A44
	public async Task method_21()
	{
		while (!this.bool_1)
		{
			int num = 0;
			TaskAwaiter taskAwaiter6;
			try
			{
				base.method_5("Initialising payment", "#c2c2c2", true, false);
				JObject jobject = new JObject();
				string propertyName = "terminals";
				JObject jobject2 = new JObject();
				jobject2["successURL"] = "http://ok";
				jobject2["failureURL"] = "http://fail";
				jobject2["timeoutURL"] = "http://timeout";
				jobject[propertyName] = jobject2;
				object key = "successURL";
				jobject["terminals"][key] = "http://ok";
				object key2 = "failureURL";
				jobject["terminals"][key2] = "http://fail";
				object key3 = "timeoutURL";
				jobject["terminals"][key3] = "http://timeout";
				JObject jobject3 = jobject;
				HttpResponseMessage httpResponseMessage = await this.class14_0.method_4(string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/carts/{1}/hostedPayment", this.string_7, this.string_11), jobject3, false);
				for (;;)
				{
					TaskAwaiter<string> taskAwaiter = httpResponseMessage.smethod_3().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						await taskAwaiter;
						TaskAwaiter<string> taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<string>);
					}
					if (!taskAwaiter.GetResult().Contains("one or more products is unavailable"))
					{
						break;
					}
					base.method_5("Waiting for restock", "#c2c2c2", true, false);
					TaskAwaiter<HttpResponseMessage> taskAwaiter3 = this.class14_0.method_4(string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/carts/{1}/hostedPayment", this.string_7, this.string_11), jobject3, false).GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						await taskAwaiter3;
						TaskAwaiter<HttpResponseMessage> taskAwaiter4;
						taskAwaiter3 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<HttpResponseMessage>);
					}
					httpResponseMessage = taskAwaiter3.GetResult();
					TaskAwaiter taskAwaiter5 = base.method_14(Class130.int_0).GetAwaiter();
					if (!taskAwaiter5.IsCompleted)
					{
						await taskAwaiter5;
						taskAwaiter5 = taskAwaiter6;
						taskAwaiter6 = default(TaskAwaiter);
					}
					taskAwaiter5.GetResult();
				}
				httpResponseMessage.EnsureSuccessStatusCode();
				TaskAwaiter<JObject> taskAwaiter7 = httpResponseMessage.smethod_1().GetAwaiter();
				if (!taskAwaiter7.IsCompleted)
				{
					await taskAwaiter7;
					TaskAwaiter<JObject> taskAwaiter8;
					taskAwaiter7 = taskAwaiter8;
					taskAwaiter8 = default(TaskAwaiter<JObject>);
				}
				JObject result = taskAwaiter7.GetResult();
				this.string_15 = result["ID"].ToString();
				this.string_16 = result["terminalEndPoints"]["cardEntryURL"].ToString().Split(new char[]
				{
					'='
				})[1].Split(new char[]
				{
					'"'
				})[0];
				break;
			}
			catch
			{
				num = 1;
			}
			if (num == 1)
			{
				base.method_5("Error initialising payment", "#c2c2c2", true, false);
				TaskAwaiter taskAwaiter5 = base.method_14(Class130.int_1).GetAwaiter();
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

	// Token: 0x060000C8 RID: 200 RVA: 0x0000A88C File Offset: 0x00008A8C
	public async Task method_22()
	{
		while (!this.bool_1)
		{
			int num = 0;
			try
			{
				base.method_5("Submitting payment", "orange", true, false);
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary["card_number"] = ((string)this.jtoken_1["payment"]["card"]["number"]).Replace(" ", string.Empty);
				dictionary["exp_month"] = (string)this.jtoken_1["payment"]["card"]["exp_month"];
				dictionary["exp_year"] = (string)this.jtoken_1["payment"]["card"]["exp_year"];
				dictionary["cv2_number"] = (string)this.jtoken_1["payment"]["card"]["cvv"];
				dictionary["HPS_SessionID"] = this.string_16;
				dictionary["action"] = "confirm";
				HttpResponseMessage httpResponseMessage = await this.class14_0.method_3("https://hps.datacash.com/hps/?", dictionary, false);
				TaskAwaiter<string> taskAwaiter = httpResponseMessage.smethod_3().GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter<string> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<string>);
				}
				if (taskAwaiter.GetResult().Contains("Please enter a valid card number"))
				{
					base.method_0("Invalid card details", "red", true, (GEnum1)0);
				}
				await this.method_23(httpResponseMessage.Headers.GetValues("Location").First<string>().ToString());
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

	// Token: 0x060000C9 RID: 201 RVA: 0x0000A8D4 File Offset: 0x00008AD4
	public async Task method_23(string string_17)
	{
		while (!this.bool_1)
		{
			int num = 0;
			TaskAwaiter taskAwaiter2;
			try
			{
				base.method_5("Submitting order", "orange", true, false);
				HttpResponseMessage httpResponseMessage_ = await this.class14_0.method_4(string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/payments/{1}/hostedpaymentresult", this.string_7, this.string_15), JObject.Parse(string.Format("{{'HostedPaymentPageResult':'{0}'}}", string_17)), false);
				TaskAwaiter<HttpResponseMessage> taskAwaiter4;
				while (httpResponseMessage_.smethod_1().ToString().Contains("speed limit"))
				{
					TaskAwaiter taskAwaiter = base.method_14(1000).GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						await taskAwaiter;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
					}
					taskAwaiter.GetResult();
					TaskAwaiter<HttpResponseMessage> taskAwaiter3 = this.class14_0.method_4(string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/payments/{1}/hostedpaymentresult", this.string_7, this.string_15), JObject.Parse(string.Format("{{'HostedPaymentPageResult':'{0}'}}", string_17)), false).GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						await taskAwaiter3;
						taskAwaiter3 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<HttpResponseMessage>);
					}
					httpResponseMessage_ = taskAwaiter3.GetResult();
				}
				while (httpResponseMessage_.smethod_1().ToString().Contains("Payment in progress"))
				{
					TaskAwaiter taskAwaiter = base.method_14(1000).GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						await taskAwaiter;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
					}
					taskAwaiter.GetResult();
					TaskAwaiter<HttpResponseMessage> taskAwaiter3 = this.class14_0.method_4(string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/payments/{1}/hostedpaymentresult", this.string_7, this.string_15), JObject.Parse(string.Format("{{'HostedPaymentPageResult':'{0}'}}", string_17)), false).GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						await taskAwaiter3;
						taskAwaiter3 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<HttpResponseMessage>);
					}
					httpResponseMessage_ = taskAwaiter3.GetResult();
				}
				TaskAwaiter<JObject> taskAwaiter5 = httpResponseMessage_.smethod_1().GetAwaiter();
				if (!taskAwaiter5.IsCompleted)
				{
					await taskAwaiter5;
					TaskAwaiter<JObject> taskAwaiter6;
					taskAwaiter5 = taskAwaiter6;
					taskAwaiter6 = default(TaskAwaiter<JObject>);
				}
				string a = (string)taskAwaiter5.GetResult()["status"];
				if (a == "DECLINED")
				{
					base.method_0("Payment Declined", "red", true, (GEnum1)5);
					break;
				}
				if (!(a == "ERROR"))
				{
					base.method_0("Successfully checked out", "green", true, (GEnum1)6);
					break;
				}
				base.method_0("Payment error", "red", true, (GEnum1)0);
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

	// Token: 0x060000CA RID: 202 RVA: 0x00003225 File Offset: 0x00001425
	private bool method_24(JToken jtoken_2)
	{
		return Class43.smethod_2(this.string_0, jtoken_2["name"].ToString());
	}

	// Token: 0x04000066 RID: 102
	private string string_7;

	// Token: 0x04000067 RID: 103
	private string string_8;

	// Token: 0x04000068 RID: 104
	private string string_9;

	// Token: 0x04000069 RID: 105
	private string string_10;

	// Token: 0x0400006A RID: 106
	private string string_11;

	// Token: 0x0400006B RID: 107
	private string string_12;

	// Token: 0x0400006C RID: 108
	private string string_13;

	// Token: 0x0400006D RID: 109
	private string string_14;

	// Token: 0x0400006E RID: 110
	private string string_15;

	// Token: 0x0400006F RID: 111
	private string string_16;

	// Token: 0x04000070 RID: 112
	private JObject jobject_0;

	// Token: 0x02000022 RID: 34
	[Serializable]
	private sealed class Class16
	{
		// Token: 0x060000CD RID: 205 RVA: 0x0000324E File Offset: 0x0000144E
		internal bool method_0(JToken jtoken_0)
		{
			return jtoken_0["product"]["stockStatus"].ToString() == "IN STOCK";
		}

		// Token: 0x04000071 RID: 113
		public static readonly Class45.Class16 class16_0 = new Class45.Class16();

		// Token: 0x04000072 RID: 114
		public static Func<JToken, bool> func_0;
	}

	// Token: 0x02000023 RID: 35
	[StructLayout(LayoutKind.Auto)]
	private struct Struct13 : IAsyncStateMachine
	{
		// Token: 0x060000CE RID: 206 RVA: 0x0000A924 File Offset: 0x00008B24
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class45 @class = this;
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
						@class.method_5("Setting delivery method", "#c2c2c2", true, false);
						JObject jobject = new JObject();
						jobject["delivery"] = new JObject();
						jobject["delivery"]["deliveryMethodID"] = @class.string_14;
						taskAwaiter4 = @class.class14_0.method_8(string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/carts/{1}", @class.string_7, @class.string_11), jobject, false).GetAwaiter();
						if (!taskAwaiter4.IsCompleted)
						{
							int num5 = 0;
							num = 0;
							num2 = num5;
							TaskAwaiter<HttpResponseMessage> taskAwaiter5 = taskAwaiter4;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class45.Struct13>(ref taskAwaiter4, ref this);
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
					goto IL_1A2;
				}
				catch (ThreadAbortException)
				{
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
				@class.method_5("Error setting delivery method", "#c2c2c2", true, false);
				taskAwaiter3 = @class.method_14(Class130.int_1).GetAwaiter();
				if (taskAwaiter3.IsCompleted)
				{
					goto IL_14F;
				}
				int num7 = 1;
				num = 1;
				num2 = num7;
				taskAwaiter2 = taskAwaiter3;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class45.Struct13>(ref taskAwaiter3, ref this);
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

		// Token: 0x060000CF RID: 207 RVA: 0x00003274 File Offset: 0x00001474
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000073 RID: 115
		public int int_0;

		// Token: 0x04000074 RID: 116
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000075 RID: 117
		public Class45 class45_0;

		// Token: 0x04000076 RID: 118
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000077 RID: 119
		private TaskAwaiter taskAwaiter_1;
	}

	// Token: 0x02000024 RID: 36
	[StructLayout(LayoutKind.Auto)]
	private struct Struct14 : IAsyncStateMachine
	{
		// Token: 0x060000D0 RID: 208 RVA: 0x0000AB34 File Offset: 0x00008D34
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class45 @class = this;
			try
			{
				if (num <= 4)
				{
					goto IL_541;
				}
				if (num != 5)
				{
					goto IL_536;
				}
				TaskAwaiter taskAwaiter9 = taskAwaiter6;
				taskAwaiter6 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_52F:
				taskAwaiter9.GetResult();
				IL_536:
				if (@class.bool_1)
				{
					goto IL_582;
				}
				int num4 = 0;
				IL_541:
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter10;
					TaskAwaiter<string> taskAwaiter11;
					TaskAwaiter<JObject> taskAwaiter12;
					switch (num)
					{
					case 0:
					{
						taskAwaiter10 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<HttpResponseMessage>);
						int num5 = -1;
						num = -1;
						num2 = num5;
						break;
					}
					case 1:
					{
						taskAwaiter10 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<HttpResponseMessage>);
						int num6 = -1;
						num = -1;
						num2 = num6;
						goto IL_36E;
					}
					case 2:
					{
						taskAwaiter9 = taskAwaiter6;
						taskAwaiter6 = default(TaskAwaiter);
						int num7 = -1;
						num = -1;
						num2 = num7;
						goto IL_39C;
					}
					case 3:
					{
						taskAwaiter11 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<string>);
						int num8 = -1;
						num = -1;
						num2 = num8;
						goto IL_3C1;
					}
					case 4:
					{
						taskAwaiter12 = taskAwaiter8;
						taskAwaiter8 = default(TaskAwaiter<JObject>);
						int num9 = -1;
						num = -1;
						num2 = num9;
						goto IL_4AC;
					}
					default:
					{
						@class.method_5("Adding to cart", "#c2c2c2", true, false);
						JObject jobject3 = new JObject();
						jobject3["SKU"] = @class.string_9;
						jobject3["quantity"] = 1;
						jobject3["type"] = "cartproduct";
						jobject2 = new JObject();
						jobject2["contents"] = new JArray(jobject3);
						jobject2["customer"] = new JObject();
						jobject2["customer"]["id"] = string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/customers/{1}", @class.string_7, @class.string_12);
						jobject2["billingAddress"] = new JObject();
						jobject2["billingAddress"]["id"] = string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/customers/{1}/addresses/{2}", @class.string_7, @class.string_12, @class.string_13);
						jobject2["deliveryAddress"] = new JObject();
						jobject2["deliveryAddress"]["id"] = string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/customers/{1}/addresses/{2}", @class.string_7, @class.string_12, @class.string_13);
						jobject2["terminals"] = new JObject();
						jobject2["terminals"]["successURL"] = "http://ok";
						jobject2["terminals"]["failureURL"] = "http://fail";
						jobject2["terminals"]["timeoutURL"] = "http://timeout";
						taskAwaiter10 = @class.class14_0.method_4(string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/carts", @class.string_7), jobject2, false).GetAwaiter();
						if (!taskAwaiter10.IsCompleted)
						{
							int num10 = 0;
							num = 0;
							num2 = num10;
							taskAwaiter4 = taskAwaiter10;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class45.Struct14>(ref taskAwaiter10, ref this);
							return;
						}
						break;
					}
					}
					HttpResponseMessage result = taskAwaiter10.GetResult();
					httpResponseMessage = result;
					goto IL_3A3;
					IL_36E:
					result = taskAwaiter10.GetResult();
					httpResponseMessage = result;
					taskAwaiter9 = @class.method_14(Class130.int_0).GetAwaiter();
					if (!taskAwaiter9.IsCompleted)
					{
						int num11 = 2;
						num = 2;
						num2 = num11;
						taskAwaiter6 = taskAwaiter9;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class45.Struct14>(ref taskAwaiter9, ref this);
						return;
					}
					IL_39C:
					taskAwaiter9.GetResult();
					IL_3A3:
					taskAwaiter11 = httpResponseMessage.smethod_3().GetAwaiter();
					if (!taskAwaiter11.IsCompleted)
					{
						int num12 = 3;
						num = 3;
						num2 = num12;
						taskAwaiter2 = taskAwaiter11;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class45.Struct14>(ref taskAwaiter11, ref this);
						return;
					}
					IL_3C1:
					if (!taskAwaiter11.GetResult().Contains("There is no stock available"))
					{
						httpResponseMessage.EnsureSuccessStatusCode();
						taskAwaiter12 = httpResponseMessage.smethod_1().GetAwaiter();
						if (!taskAwaiter12.IsCompleted)
						{
							int num13 = 4;
							num = 4;
							num2 = num13;
							taskAwaiter8 = taskAwaiter12;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class45.Struct14>(ref taskAwaiter12, ref this);
							return;
						}
					}
					else
					{
						@class.method_5("Waiting for restock", "#c2c2c2", true, false);
						taskAwaiter10 = @class.class14_0.method_4(string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/carts", @class.string_7), jobject2, false).GetAwaiter();
						if (taskAwaiter10.IsCompleted)
						{
							goto IL_36E;
						}
						int num14 = 1;
						num = 1;
						num2 = num14;
						taskAwaiter4 = taskAwaiter10;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class45.Struct14>(ref taskAwaiter10, ref this);
						return;
					}
					IL_4AC:
					JObject result2 = taskAwaiter12.GetResult();
					@class.string_11 = result2["ID"].ToString();
					@class.string_14 = result2["delivery"]["deliveryMethodID"].ToString();
					goto IL_582;
				}
				catch (ThreadAbortException)
				{
					goto IL_582;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_536;
				}
				@class.method_5("Error adding to cart", "#c2c2c2", true, false);
				taskAwaiter9 = @class.method_14(Class130.int_1).GetAwaiter();
				if (taskAwaiter9.IsCompleted)
				{
					goto IL_52F;
				}
				int num15 = 5;
				num = 5;
				num2 = num15;
				taskAwaiter6 = taskAwaiter9;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class45.Struct14>(ref taskAwaiter9, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_582:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00003282 File Offset: 0x00001482
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000078 RID: 120
		public int int_0;

		// Token: 0x04000079 RID: 121
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x0400007A RID: 122
		public Class45 class45_0;

		// Token: 0x0400007B RID: 123
		private JObject jobject_0;

		// Token: 0x0400007C RID: 124
		private HttpResponseMessage httpResponseMessage_0;

		// Token: 0x0400007D RID: 125
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x0400007E RID: 126
		private TaskAwaiter taskAwaiter_1;

		// Token: 0x0400007F RID: 127
		private TaskAwaiter<string> taskAwaiter_2;

		// Token: 0x04000080 RID: 128
		private TaskAwaiter<JObject> taskAwaiter_3;
	}

	// Token: 0x02000025 RID: 37
	[StructLayout(LayoutKind.Auto)]
	private struct Struct15 : IAsyncStateMachine
	{
		// Token: 0x060000D2 RID: 210 RVA: 0x0000B124 File Offset: 0x00009324
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class45 @class = this;
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
						goto IL_154;
					}
					case 3:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_1AF;
					}
					case 4:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_20A;
					}
					case 5:
					{
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						num2 = -1;
						goto IL_262;
					}
					default:
						task = @class.method_19();
						taskAwaiter = @class.method_11().GetAwaiter();
						if (!taskAwaiter.IsCompleted)
						{
							num2 = 0;
							TaskAwaiter taskAwaiter2 = taskAwaiter;
							this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class45.Struct15>(ref taskAwaiter, ref this);
							return;
						}
						break;
					}
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_15().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 1;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class45.Struct15>(ref taskAwaiter, ref this);
						return;
					}
					IL_E7:
					taskAwaiter.GetResult();
					@class.method_5("Registering customer", "#c2c2c2", true, false);
					taskAwaiter = task.GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 2;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class45.Struct15>(ref taskAwaiter, ref this);
						return;
					}
					IL_154:
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_16().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 3;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class45.Struct15>(ref taskAwaiter, ref this);
						return;
					}
					IL_1AF:
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_21().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 4;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class45.Struct15>(ref taskAwaiter, ref this);
						return;
					}
					IL_20A:
					taskAwaiter.GetResult();
					taskAwaiter = @class.method_22().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 5;
						TaskAwaiter taskAwaiter2 = taskAwaiter;
						this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class45.Struct15>(ref taskAwaiter, ref this);
						return;
					}
					IL_262:
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

		// Token: 0x060000D3 RID: 211 RVA: 0x00003290 File Offset: 0x00001490
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000081 RID: 129
		public int int_0;

		// Token: 0x04000082 RID: 130
		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		// Token: 0x04000083 RID: 131
		public Class45 class45_0;

		// Token: 0x04000084 RID: 132
		private Task task_0;

		// Token: 0x04000085 RID: 133
		private TaskAwaiter taskAwaiter_0;
	}

	// Token: 0x02000026 RID: 38
	[StructLayout(LayoutKind.Auto)]
	private struct Struct16 : IAsyncStateMachine
	{
		// Token: 0x060000D4 RID: 212 RVA: 0x0000B418 File Offset: 0x00009618
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class45 @class = this;
			try
			{
				TaskAwaiter taskAwaiter7;
				if (num > 5)
				{
					if (num != 6)
					{
						@class.method_5("Waiting for product", "#c2c2c2", true, false);
						goto IL_4C3;
					}
					taskAwaiter7 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter);
					int num3 = -1;
					num = -1;
					num2 = num3;
					goto IL_4A0;
				}
				IL_4E:
				int num16;
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter8;
					TaskAwaiter<string> taskAwaiter10;
					TaskAwaiter<JObject> taskAwaiter11;
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
						taskAwaiter2 = default(TaskAwaiter<string>);
						int num5 = -1;
						num = -1;
						num2 = num5;
						goto IL_14D;
					}
					case 2:
					{
						taskAwaiter7 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter);
						int num6 = -1;
						num = -1;
						num2 = num6;
						goto IL_207;
					}
					case 3:
					{
						taskAwaiter11 = taskAwaiter6;
						taskAwaiter6 = default(TaskAwaiter<JObject>);
						int num7 = -1;
						num = -1;
						num2 = num7;
						goto IL_242;
					}
					case 4:
					{
						taskAwaiter7 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter);
						int num8 = -1;
						num = -1;
						num2 = num8;
						goto IL_447;
					}
					case 5:
					{
						taskAwaiter7 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter);
						int num9 = -1;
						num = -1;
						num2 = num9;
						goto IL_46C;
					}
					default:
						taskAwaiter8 = GClass2.smethod_1(string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/products/{1}", @class.string_7, @class.string_10), @class.jobject_0, true).GetAwaiter();
						if (!taskAwaiter8.IsCompleted)
						{
							int num10 = 0;
							num = 0;
							num2 = num10;
							TaskAwaiter<HttpResponseMessage> taskAwaiter9 = taskAwaiter8;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class45.Struct16>(ref taskAwaiter8, ref this);
							return;
						}
						break;
					}
					HttpResponseMessage result = taskAwaiter8.GetResult();
					httpResponseMessage = result;
					taskAwaiter10 = httpResponseMessage.smethod_3().GetAwaiter();
					if (!taskAwaiter10.IsCompleted)
					{
						int num11 = 1;
						num = 1;
						num2 = num11;
						taskAwaiter2 = taskAwaiter10;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class45.Struct16>(ref taskAwaiter10, ref this);
						return;
					}
					IL_14D:
					if (taskAwaiter10.GetResult().Contains("Product could not be found"))
					{
						taskAwaiter7 = @class.method_14(Class130.int_0).GetAwaiter();
						if (!taskAwaiter7.IsCompleted)
						{
							int num12 = 2;
							num = 2;
							num2 = num12;
							taskAwaiter4 = taskAwaiter7;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class45.Struct16>(ref taskAwaiter7, ref this);
							return;
						}
					}
					else
					{
						httpResponseMessage.EnsureSuccessStatusCode();
						taskAwaiter11 = httpResponseMessage.smethod_1().GetAwaiter();
						if (!taskAwaiter11.IsCompleted)
						{
							int num13 = 3;
							num = 3;
							num2 = num13;
							taskAwaiter6 = taskAwaiter11;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class45.Struct16>(ref taskAwaiter11, ref this);
							return;
						}
						goto IL_242;
					}
					IL_207:
					taskAwaiter7.GetResult();
					@class.method_5("Waiting for product", "#c2c2c2", true, false);
					goto IL_4C3;
					IL_242:
					JObject result2 = taskAwaiter11.GetResult();
					@class.method_7(result2["name"].ToString(), "#c2c2c2");
					if (@class.bool_0)
					{
						JToken[] array = result2["sortedOptions"].Where(new Func<JToken, bool>(Class45.Class16.class16_0.method_0)).ToArray<JToken>();
						if (array.Length == 0)
						{
							@class.method_5("Waiting for restock", "#c2c2c2", true, false);
							taskAwaiter7 = @class.method_14(Class130.int_0).GetAwaiter();
							if (!taskAwaiter7.IsCompleted)
							{
								int num14 = 4;
								num = 4;
								num2 = num14;
								taskAwaiter4 = taskAwaiter7;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class45.Struct16>(ref taskAwaiter7, ref this);
								return;
							}
							goto IL_447;
						}
						else
						{
							JToken jtoken = array[MainWindow.random_0.Next(0, array.Length)];
							@class.method_6(jtoken["name"].ToString());
							@class.string_9 = jtoken["product"]["SKU"].ToString();
						}
					}
					else
					{
						JToken jtoken2 = result2["sortedOptions"].FirstOrDefault(new Func<JToken, bool>(@class.method_24));
						if (jtoken2 == null)
						{
							throw new Exception();
						}
						if (jtoken2["product"]["stockStatus"].ToString() != "IN STOCK")
						{
							@class.method_5("Waiting for restock", "#c2c2c2", true, false);
							taskAwaiter7 = @class.method_14(Class130.int_0).GetAwaiter();
							if (!taskAwaiter7.IsCompleted)
							{
								int num15 = 5;
								num = 5;
								num2 = num15;
								taskAwaiter4 = taskAwaiter7;
								this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class45.Struct16>(ref taskAwaiter7, ref this);
								return;
							}
							goto IL_46C;
						}
						else
						{
							@class.method_6(jtoken2["name"].ToString());
							@class.string_9 = jtoken2["product"]["SKU"].ToString();
						}
					}
					goto IL_508;
					IL_447:
					taskAwaiter7.GetResult();
					goto IL_4C3;
					IL_46C:
					taskAwaiter7.GetResult();
					goto IL_4C3;
				}
				catch (ThreadAbortException)
				{
					goto IL_508;
				}
				catch
				{
					num16 = 1;
				}
				if (num16 != 1)
				{
					goto IL_4C3;
				}
				taskAwaiter7 = @class.method_14(Class130.int_0).GetAwaiter();
				if (!taskAwaiter7.IsCompleted)
				{
					int num17 = 6;
					num = 6;
					num2 = num17;
					taskAwaiter4 = taskAwaiter7;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class45.Struct16>(ref taskAwaiter7, ref this);
					return;
				}
				IL_4A0:
				taskAwaiter7.GetResult();
				@class.method_5("Waiting for product", "#c2c2c2", true, false);
				IL_4C3:
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
			IL_508:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x0000329E File Offset: 0x0000149E
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000086 RID: 134
		public int int_0;

		// Token: 0x04000087 RID: 135
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000088 RID: 136
		public Class45 class45_0;

		// Token: 0x04000089 RID: 137
		private HttpResponseMessage httpResponseMessage_0;

		// Token: 0x0400008A RID: 138
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x0400008B RID: 139
		private TaskAwaiter<string> taskAwaiter_1;

		// Token: 0x0400008C RID: 140
		private TaskAwaiter taskAwaiter_2;

		// Token: 0x0400008D RID: 141
		private TaskAwaiter<JObject> taskAwaiter_3;
	}

	// Token: 0x02000027 RID: 39
	[StructLayout(LayoutKind.Auto)]
	private struct Struct17 : IAsyncStateMachine
	{
		// Token: 0x060000D6 RID: 214 RVA: 0x0000B98C File Offset: 0x00009B8C
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class45 @class = this;
			try
			{
				if (num <= 5)
				{
					goto IL_44C;
				}
				if (num != 6)
				{
					goto IL_441;
				}
				TaskAwaiter taskAwaiter7 = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_43A:
				taskAwaiter7.GetResult();
				IL_441:
				if (@class.bool_1)
				{
					goto IL_48D;
				}
				int num4 = 0;
				IL_44C:
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter8;
					TaskAwaiter<JObject> taskAwaiter9;
					switch (num)
					{
					case 0:
					{
						taskAwaiter8 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<HttpResponseMessage>);
						int num5 = -1;
						num = -1;
						num2 = num5;
						break;
					}
					case 1:
					{
						taskAwaiter7 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num6 = -1;
						num = -1;
						num2 = num6;
						goto IL_173;
					}
					case 2:
					{
						taskAwaiter8 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<HttpResponseMessage>);
						int num7 = -1;
						num = -1;
						num2 = num7;
						goto IL_1C0;
					}
					case 3:
					{
						taskAwaiter7 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
						int num8 = -1;
						num = -1;
						num2 = num8;
						goto IL_288;
					}
					case 4:
					{
						taskAwaiter8 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<HttpResponseMessage>);
						int num9 = -1;
						num = -1;
						num2 = num9;
						goto IL_2D5;
					}
					case 5:
					{
						taskAwaiter9 = taskAwaiter6;
						taskAwaiter6 = default(TaskAwaiter<JObject>);
						int num10 = -1;
						num = -1;
						num2 = num10;
						goto IL_384;
					}
					default:
						@class.method_5("Submitting order", "orange", true, false);
						taskAwaiter8 = @class.class14_0.method_4(string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/payments/{1}/hostedpaymentresult", @class.string_7, @class.string_15), JObject.Parse(string.Format("{{'HostedPaymentPageResult':'{0}'}}", string_17)), false).GetAwaiter();
						if (!taskAwaiter8.IsCompleted)
						{
							int num11 = 0;
							num = 0;
							num2 = num11;
							taskAwaiter4 = taskAwaiter8;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class45.Struct17>(ref taskAwaiter8, ref this);
							return;
						}
						break;
					}
					HttpResponseMessage result = taskAwaiter8.GetResult();
					IL_13E:
					if (!result.smethod_1().ToString().Contains("speed limit"))
					{
						goto IL_253;
					}
					taskAwaiter7 = @class.method_14(1000).GetAwaiter();
					if (!taskAwaiter7.IsCompleted)
					{
						int num12 = 1;
						num = 1;
						num2 = num12;
						taskAwaiter2 = taskAwaiter7;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class45.Struct17>(ref taskAwaiter7, ref this);
						return;
					}
					IL_173:
					taskAwaiter7.GetResult();
					taskAwaiter8 = @class.class14_0.method_4(string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/payments/{1}/hostedpaymentresult", @class.string_7, @class.string_15), JObject.Parse(string.Format("{{'HostedPaymentPageResult':'{0}'}}", string_17)), false).GetAwaiter();
					if (!taskAwaiter8.IsCompleted)
					{
						int num13 = 2;
						num = 2;
						num2 = num13;
						taskAwaiter4 = taskAwaiter8;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class45.Struct17>(ref taskAwaiter8, ref this);
						return;
					}
					IL_1C0:
					result = taskAwaiter8.GetResult();
					goto IL_13E;
					IL_253:
					if (result.smethod_1().ToString().Contains("Payment in progress"))
					{
						taskAwaiter7 = @class.method_14(1000).GetAwaiter();
						if (!taskAwaiter7.IsCompleted)
						{
							int num14 = 3;
							num = 3;
							num2 = num14;
							taskAwaiter2 = taskAwaiter7;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class45.Struct17>(ref taskAwaiter7, ref this);
							return;
						}
					}
					else
					{
						taskAwaiter9 = result.smethod_1().GetAwaiter();
						if (!taskAwaiter9.IsCompleted)
						{
							int num15 = 5;
							num = 5;
							num2 = num15;
							taskAwaiter6 = taskAwaiter9;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class45.Struct17>(ref taskAwaiter9, ref this);
							return;
						}
						goto IL_384;
					}
					IL_288:
					taskAwaiter7.GetResult();
					taskAwaiter8 = @class.class14_0.method_4(string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/payments/{1}/hostedpaymentresult", @class.string_7, @class.string_15), JObject.Parse(string.Format("{{'HostedPaymentPageResult':'{0}'}}", string_17)), false).GetAwaiter();
					if (!taskAwaiter8.IsCompleted)
					{
						int num16 = 4;
						num = 4;
						num2 = num16;
						taskAwaiter4 = taskAwaiter8;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class45.Struct17>(ref taskAwaiter8, ref this);
						return;
					}
					IL_2D5:
					result = taskAwaiter8.GetResult();
					goto IL_253;
					IL_384:
					string a = (string)taskAwaiter9.GetResult()["status"];
					if (a == "DECLINED")
					{
						@class.method_0("Payment Declined", "red", true, (GEnum1)5);
						goto IL_48D;
					}
					if (!(a == "ERROR"))
					{
						@class.method_0("Successfully checked out", "green", true, (GEnum1)6);
						goto IL_48D;
					}
					@class.method_0("Payment error", "red", true, (GEnum1)0);
					goto IL_48D;
				}
				catch (ThreadAbortException)
				{
					goto IL_48D;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_441;
				}
				@class.method_5("Error submitting order", "#c2c2c2", true, false);
				taskAwaiter7 = @class.method_14(Class130.int_1).GetAwaiter();
				if (taskAwaiter7.IsCompleted)
				{
					goto IL_43A;
				}
				int num17 = 6;
				num = 6;
				num2 = num17;
				taskAwaiter2 = taskAwaiter7;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class45.Struct17>(ref taskAwaiter7, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_48D:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x000032AC File Offset: 0x000014AC
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400008E RID: 142
		public int int_0;

		// Token: 0x0400008F RID: 143
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000090 RID: 144
		public Class45 class45_0;

		// Token: 0x04000091 RID: 145
		public string string_0;

		// Token: 0x04000092 RID: 146
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000093 RID: 147
		private TaskAwaiter taskAwaiter_1;

		// Token: 0x04000094 RID: 148
		private TaskAwaiter<JObject> taskAwaiter_2;
	}

	// Token: 0x02000028 RID: 40
	[StructLayout(LayoutKind.Auto)]
	private struct Struct18 : IAsyncStateMachine
	{
		// Token: 0x060000D8 RID: 216 RVA: 0x0000BE88 File Offset: 0x0000A088
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class45 @class = this;
			try
			{
				if (num <= 1)
				{
					goto IL_212;
				}
				if (num != 2)
				{
					goto IL_208;
				}
				TaskAwaiter taskAwaiter7 = taskAwaiter6;
				taskAwaiter6 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_201:
				taskAwaiter7.GetResult();
				IL_208:
				if (@class.bool_1)
				{
					goto IL_254;
				}
				int num4 = 0;
				IL_212:
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
							goto IL_18B;
						}
						@class.method_5("Getting delivery method ID", "#c2c2c2", true, false);
						taskAwaiter9 = @class.class14_0.method_2(string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/carts/{1}/deliveryOptionsForProposedAddress?deliverylocale={2}&q={3}", new object[]
						{
							@class.string_7,
							@class.string_11,
							Class43.smethod_0((string)@class.jtoken_1["delivery"]["country"], false),
							(string)@class.jtoken_1["delivery"]["zip"]
						}), false).GetAwaiter();
						if (!taskAwaiter9.IsCompleted)
						{
							int num6 = 0;
							num = 0;
							num2 = num6;
							taskAwaiter2 = taskAwaiter9;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class45.Struct18>(ref taskAwaiter9, ref this);
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
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class45.Struct18>(ref taskAwaiter8, ref this);
						return;
					}
					IL_18B:
					JObject result2 = taskAwaiter8.GetResult();
					@class.string_14 = result2["deliveryMethods"][0]["ID"].ToString();
					goto IL_254;
				}
				catch (ThreadAbortException)
				{
					goto IL_254;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_208;
				}
				@class.method_5("Error getting delivery method", "#c2c2c2", true, false);
				taskAwaiter7 = @class.method_14(Class130.int_1).GetAwaiter();
				if (taskAwaiter7.IsCompleted)
				{
					goto IL_201;
				}
				int num9 = 2;
				num = 2;
				num2 = num9;
				taskAwaiter6 = taskAwaiter7;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class45.Struct18>(ref taskAwaiter7, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_254:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x000032BA File Offset: 0x000014BA
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000095 RID: 149
		public int int_0;

		// Token: 0x04000096 RID: 150
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x04000097 RID: 151
		public Class45 class45_0;

		// Token: 0x04000098 RID: 152
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x04000099 RID: 153
		private TaskAwaiter<JObject> taskAwaiter_1;

		// Token: 0x0400009A RID: 154
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x02000029 RID: 41
	[StructLayout(LayoutKind.Auto)]
	private struct Struct19 : IAsyncStateMachine
	{
		// Token: 0x060000DA RID: 218 RVA: 0x0000C148 File Offset: 0x0000A348
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class45 @class = this;
			try
			{
				if (num <= 1)
				{
					goto IL_631;
				}
				if (num != 2)
				{
					goto IL_627;
				}
				TaskAwaiter taskAwaiter7 = taskAwaiter6;
				taskAwaiter6 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_620:
				taskAwaiter7.GetResult();
				IL_627:
				if (@class.bool_1)
				{
					goto IL_673;
				}
				int num4 = 0;
				IL_631:
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
							goto IL_599;
						}
						@class.method_5("Collecting delivery data", "#c2c2c2", true, false);
						JObject jobject = new JObject();
						jobject["firstName"] = @class.jtoken_1["delivery"]["first_name"];
						jobject["lastName"] = @class.jtoken_1["delivery"]["last_name"];
						jobject["email"] = @class.jtoken_1["payment"]["email"];
						jobject["phone"] = @class.jtoken_1["payment"]["phone"];
						jobject["enrolledForEmailMarketing"] = false;
						jobject["isGuest"] = true;
						JObject jobject2 = jobject;
						JObject jobject3 = new JObject();
						jobject3["firstName"] = @class.jtoken_1["delivery"]["first_name"];
						jobject3["lastName"] = @class.jtoken_1["delivery"]["last_name"];
						jobject3["address1"] = @class.jtoken_1["delivery"]["addr1"];
						jobject3["address2"] = @class.jtoken_1["delivery"]["addr2"];
						jobject3["country"] = @class.jtoken_1["delivery"]["country"];
						jobject3["locale"] = Class43.smethod_0((string)@class.jtoken_1["delivery"]["country"], false);
						jobject3["state"] = Class43.smethod_1((string)@class.jtoken_1["delivery"]["country"], (string)@class.jtoken_1["delivery"]["state"]);
						jobject3["postcode"] = @class.jtoken_1["delivery"]["zip"];
						jobject3["town"] = @class.jtoken_1["delivery"]["city"];
						jobject3["isPrimaryBillingAddress"] = false;
						jobject3["isPrimaryAddress"] = true;
						JObject jobject4 = jobject3;
						JObject jobject5 = new JObject();
						jobject5["firstName"] = @class.jtoken_1["billing"]["first_name"];
						jobject5["lastName"] = @class.jtoken_1["billing"]["last_name"];
						jobject5["address1"] = @class.jtoken_1["billing"]["addr1"];
						jobject5["address2"] = @class.jtoken_1["billing"]["addr2"];
						jobject5["country"] = @class.jtoken_1["billing"]["first_ncountryame"];
						jobject5["locale"] = Class43.smethod_0((string)@class.jtoken_1["billing"]["country"], false);
						jobject5["state"] = Class43.smethod_1((string)@class.jtoken_1["billing"]["country"], (string)@class.jtoken_1["billing"]["state"]);
						jobject5["postcode"] = @class.jtoken_1["billing"]["zip"];
						jobject5["town"] = @class.jtoken_1["billing"]["city"];
						jobject5["isPrimaryBillingAddress"] = true;
						jobject5["isPrimaryAddress"] = false;
						JObject jobject6 = jobject5;
						jobject2["addresses"] = new JArray(new object[]
						{
							jobject4,
							jobject6
						});
						taskAwaiter9 = @class.class14_0.method_4(string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/customers", @class.string_7), jobject2, false).GetAwaiter();
						if (!taskAwaiter9.IsCompleted)
						{
							int num6 = 0;
							num = 0;
							num2 = num6;
							taskAwaiter2 = taskAwaiter9;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class45.Struct19>(ref taskAwaiter9, ref this);
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
					if (result.StatusCode == HttpStatusCode.Conflict)
					{
						@class.method_0("Invalid info", "red", true, (GEnum1)0);
					}
					result.EnsureSuccessStatusCode();
					taskAwaiter8 = result.smethod_1().GetAwaiter();
					if (!taskAwaiter8.IsCompleted)
					{
						int num8 = 1;
						num = 1;
						num2 = num8;
						taskAwaiter4 = taskAwaiter8;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class45.Struct19>(ref taskAwaiter8, ref this);
						return;
					}
					IL_599:
					JObject result2 = taskAwaiter8.GetResult();
					@class.string_12 = result2["ID"].ToString();
					@class.string_13 = result2["addresses"][0]["ID"].ToString();
					goto IL_673;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_627;
				}
				@class.method_5("Error collecting delivery data", "#c2c2c2", true, false);
				taskAwaiter7 = @class.method_14(Class130.int_1).GetAwaiter();
				if (taskAwaiter7.IsCompleted)
				{
					goto IL_620;
				}
				int num9 = 2;
				num = 2;
				num2 = num9;
				taskAwaiter6 = taskAwaiter7;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class45.Struct19>(ref taskAwaiter7, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_673:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060000DB RID: 219 RVA: 0x000032C8 File Offset: 0x000014C8
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400009B RID: 155
		public int int_0;

		// Token: 0x0400009C RID: 156
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x0400009D RID: 157
		public Class45 class45_0;

		// Token: 0x0400009E RID: 158
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x0400009F RID: 159
		private TaskAwaiter<JObject> taskAwaiter_1;

		// Token: 0x040000A0 RID: 160
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x0200002A RID: 42
	[StructLayout(LayoutKind.Auto)]
	private struct Struct20 : IAsyncStateMachine
	{
		// Token: 0x060000DC RID: 220 RVA: 0x0000C810 File Offset: 0x0000AA10
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class45 @class = this;
			try
			{
				if (num <= 2)
				{
					goto IL_32A;
				}
				if (num != 3)
				{
					goto IL_31F;
				}
				TaskAwaiter taskAwaiter5 = taskAwaiter4;
				taskAwaiter4 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_318:
				taskAwaiter5.GetResult();
				IL_31F:
				if (@class.bool_1)
				{
					goto IL_36B;
				}
				int num4 = 0;
				IL_32A:
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
						int num5 = -1;
						num = -1;
						num2 = num5;
						break;
					}
					case 1:
					{
						taskAwaiter8 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<string>);
						int num6 = -1;
						num = -1;
						num2 = num6;
						goto IL_239;
					}
					case 2:
					{
						taskAwaiter5 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter);
						int num7 = -1;
						num = -1;
						num2 = num7;
						goto IL_2D5;
					}
					default:
					{
						@class.method_5("Submitting payment", "orange", true, false);
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary["card_number"] = ((string)@class.jtoken_1["payment"]["card"]["number"]).Replace(" ", string.Empty);
						dictionary["exp_month"] = (string)@class.jtoken_1["payment"]["card"]["exp_month"];
						dictionary["exp_year"] = (string)@class.jtoken_1["payment"]["card"]["exp_year"];
						dictionary["cv2_number"] = (string)@class.jtoken_1["payment"]["card"]["cvv"];
						dictionary["HPS_SessionID"] = @class.string_16;
						dictionary["action"] = "confirm";
						taskAwaiter6 = @class.class14_0.method_3("https://hps.datacash.com/hps/?", dictionary, false).GetAwaiter();
						if (!taskAwaiter6.IsCompleted)
						{
							int num8 = 0;
							num = 0;
							num2 = num8;
							TaskAwaiter<HttpResponseMessage> taskAwaiter7 = taskAwaiter6;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class45.Struct20>(ref taskAwaiter6, ref this);
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
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class45.Struct20>(ref taskAwaiter8, ref this);
						return;
					}
					IL_239:
					if (taskAwaiter8.GetResult().Contains("Please enter a valid card number"))
					{
						@class.method_0("Invalid card details", "red", true, (GEnum1)0);
					}
					string string_ = httpResponseMessage.Headers.GetValues("Location").First<string>().ToString();
					taskAwaiter5 = @class.method_23(string_).GetAwaiter();
					if (!taskAwaiter5.IsCompleted)
					{
						int num10 = 2;
						num = 2;
						num2 = num10;
						taskAwaiter4 = taskAwaiter5;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class45.Struct20>(ref taskAwaiter5, ref this);
						return;
					}
					IL_2D5:
					taskAwaiter5.GetResult();
					goto IL_36B;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_31F;
				}
				@class.method_5("Error submitting payment", "#c2c2c2", true, false);
				taskAwaiter5 = @class.method_14(Class130.int_1).GetAwaiter();
				if (taskAwaiter5.IsCompleted)
				{
					goto IL_318;
				}
				int num11 = 3;
				num = 3;
				num2 = num11;
				taskAwaiter4 = taskAwaiter5;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class45.Struct20>(ref taskAwaiter5, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_36B:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060000DD RID: 221 RVA: 0x000032D6 File Offset: 0x000014D6
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040000A1 RID: 161
		public int int_0;

		// Token: 0x040000A2 RID: 162
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040000A3 RID: 163
		public Class45 class45_0;

		// Token: 0x040000A4 RID: 164
		private HttpResponseMessage httpResponseMessage_0;

		// Token: 0x040000A5 RID: 165
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040000A6 RID: 166
		private TaskAwaiter<string> taskAwaiter_1;

		// Token: 0x040000A7 RID: 167
		private TaskAwaiter taskAwaiter_2;
	}

	// Token: 0x0200002B RID: 43
	[StructLayout(LayoutKind.Auto)]
	private struct Struct21 : IAsyncStateMachine
	{
		// Token: 0x060000DE RID: 222 RVA: 0x0000CBD0 File Offset: 0x0000ADD0
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class45 @class = this;
			try
			{
				if (num <= 4)
				{
					goto IL_45B;
				}
				if (num != 5)
				{
					goto IL_450;
				}
				TaskAwaiter taskAwaiter9 = taskAwaiter6;
				taskAwaiter6 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_449:
				taskAwaiter9.GetResult();
				IL_450:
				if (@class.bool_1)
				{
					goto IL_49C;
				}
				int num4 = 0;
				IL_45B:
				try
				{
					TaskAwaiter<HttpResponseMessage> taskAwaiter10;
					TaskAwaiter<string> taskAwaiter11;
					TaskAwaiter<JObject> taskAwaiter12;
					switch (num)
					{
					case 0:
					{
						taskAwaiter10 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<HttpResponseMessage>);
						int num5 = -1;
						num = -1;
						num2 = num5;
						break;
					}
					case 1:
					{
						taskAwaiter10 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<HttpResponseMessage>);
						int num6 = -1;
						num = -1;
						num2 = num6;
						goto IL_26A;
					}
					case 2:
					{
						taskAwaiter9 = taskAwaiter6;
						taskAwaiter6 = default(TaskAwaiter);
						int num7 = -1;
						num = -1;
						num2 = num7;
						goto IL_298;
					}
					case 3:
					{
						taskAwaiter11 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<string>);
						int num8 = -1;
						num = -1;
						num2 = num8;
						goto IL_2BD;
					}
					case 4:
					{
						taskAwaiter12 = taskAwaiter8;
						taskAwaiter8 = default(TaskAwaiter<JObject>);
						int num9 = -1;
						num = -1;
						num2 = num9;
						goto IL_3A8;
					}
					default:
					{
						@class.method_5("Initialising payment", "#c2c2c2", true, false);
						JObject jobject4 = new JObject();
						string propertyName = "terminals";
						JObject jobject5 = new JObject();
						jobject5["successURL"] = "http://ok";
						jobject5["failureURL"] = "http://fail";
						jobject5["timeoutURL"] = "http://timeout";
						jobject4[propertyName] = jobject5;
						object key = "successURL";
						jobject4["terminals"][key] = "http://ok";
						object key2 = "failureURL";
						jobject4["terminals"][key2] = "http://fail";
						object key3 = "timeoutURL";
						jobject4["terminals"][key3] = "http://timeout";
						jobject3 = jobject4;
						taskAwaiter10 = @class.class14_0.method_4(string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/carts/{1}/hostedPayment", @class.string_7, @class.string_11), jobject3, false).GetAwaiter();
						if (!taskAwaiter10.IsCompleted)
						{
							int num10 = 0;
							num = 0;
							num2 = num10;
							taskAwaiter4 = taskAwaiter10;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class45.Struct21>(ref taskAwaiter10, ref this);
							return;
						}
						break;
					}
					}
					HttpResponseMessage result = taskAwaiter10.GetResult();
					httpResponseMessage = result;
					goto IL_29F;
					IL_26A:
					result = taskAwaiter10.GetResult();
					httpResponseMessage = result;
					taskAwaiter9 = @class.method_14(Class130.int_0).GetAwaiter();
					if (!taskAwaiter9.IsCompleted)
					{
						int num11 = 2;
						num = 2;
						num2 = num11;
						taskAwaiter6 = taskAwaiter9;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class45.Struct21>(ref taskAwaiter9, ref this);
						return;
					}
					IL_298:
					taskAwaiter9.GetResult();
					IL_29F:
					taskAwaiter11 = httpResponseMessage.smethod_3().GetAwaiter();
					if (!taskAwaiter11.IsCompleted)
					{
						int num12 = 3;
						num = 3;
						num2 = num12;
						taskAwaiter2 = taskAwaiter11;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class45.Struct21>(ref taskAwaiter11, ref this);
						return;
					}
					IL_2BD:
					if (!taskAwaiter11.GetResult().Contains("one or more products is unavailable"))
					{
						httpResponseMessage.EnsureSuccessStatusCode();
						taskAwaiter12 = httpResponseMessage.smethod_1().GetAwaiter();
						if (!taskAwaiter12.IsCompleted)
						{
							int num13 = 4;
							num = 4;
							num2 = num13;
							taskAwaiter8 = taskAwaiter12;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class45.Struct21>(ref taskAwaiter12, ref this);
							return;
						}
					}
					else
					{
						@class.method_5("Waiting for restock", "#c2c2c2", true, false);
						taskAwaiter10 = @class.class14_0.method_4(string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/carts/{1}/hostedPayment", @class.string_7, @class.string_11), jobject3, false).GetAwaiter();
						if (taskAwaiter10.IsCompleted)
						{
							goto IL_26A;
						}
						int num14 = 1;
						num = 1;
						num2 = num14;
						taskAwaiter4 = taskAwaiter10;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class45.Struct21>(ref taskAwaiter10, ref this);
						return;
					}
					IL_3A8:
					JObject result2 = taskAwaiter12.GetResult();
					@class.string_15 = result2["ID"].ToString();
					@class.string_16 = result2["terminalEndPoints"]["cardEntryURL"].ToString().Split(new char[]
					{
						'='
					})[1].Split(new char[]
					{
						'"'
					})[0];
					goto IL_49C;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_450;
				}
				@class.method_5("Error initialising payment", "#c2c2c2", true, false);
				taskAwaiter9 = @class.method_14(Class130.int_1).GetAwaiter();
				if (taskAwaiter9.IsCompleted)
				{
					goto IL_449;
				}
				int num15 = 5;
				num = 5;
				num2 = num15;
				taskAwaiter6 = taskAwaiter9;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class45.Struct21>(ref taskAwaiter9, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_49C:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060000DF RID: 223 RVA: 0x000032E4 File Offset: 0x000014E4
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040000A8 RID: 168
		public int int_0;

		// Token: 0x040000A9 RID: 169
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040000AA RID: 170
		public Class45 class45_0;

		// Token: 0x040000AB RID: 171
		private JObject jobject_0;

		// Token: 0x040000AC RID: 172
		private HttpResponseMessage httpResponseMessage_0;

		// Token: 0x040000AD RID: 173
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040000AE RID: 174
		private TaskAwaiter taskAwaiter_1;

		// Token: 0x040000AF RID: 175
		private TaskAwaiter<string> taskAwaiter_2;

		// Token: 0x040000B0 RID: 176
		private TaskAwaiter<JObject> taskAwaiter_3;
	}

	// Token: 0x0200002C RID: 44
	[StructLayout(LayoutKind.Auto)]
	private struct Struct22 : IAsyncStateMachine
	{
		// Token: 0x060000E0 RID: 224 RVA: 0x0000D0C0 File Offset: 0x0000B2C0
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class45 @class = this;
			try
			{
				if (num <= 1)
				{
					goto IL_262;
				}
				if (num != 2)
				{
					goto IL_258;
				}
				TaskAwaiter taskAwaiter7 = taskAwaiter6;
				taskAwaiter6 = default(TaskAwaiter);
				int num3 = -1;
				num = -1;
				num2 = num3;
				IL_251:
				taskAwaiter7.GetResult();
				IL_258:
				if (@class.bool_1)
				{
					goto IL_2A4;
				}
				int num4 = 0;
				IL_262:
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
							goto IL_1EC;
						}
						@class.method_5("Setting delivery data", "#c2c2c2", true, false);
						JObject jobject = new JObject();
						string propertyName = "customer";
						JObject jobject2 = new JObject();
						jobject2["id"] = string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/customers/{1}", @class.string_7, @class.string_12);
						jobject[propertyName] = jobject2;
						string propertyName2 = "billingAddress";
						JObject jobject3 = new JObject();
						jobject3["id"] = string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/customers/{1}/addresses/{2}", @class.string_7, @class.string_12, @class.string_13);
						jobject[propertyName2] = jobject3;
						string propertyName3 = "deliveryAddress";
						JObject jobject4 = new JObject();
						jobject4["id"] = string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/customers/{1}/addresses/{2}", @class.string_7, @class.string_12, @class.string_13);
						jobject[propertyName3] = jobject4;
						JObject jobject_ = jobject;
						taskAwaiter9 = @class.class14_0.method_8(string.Format("https://prod.jdgroupmesh.cloud/stores/{0}/carts/{1}", @class.string_7, @class.string_11), jobject_, false).GetAwaiter();
						if (!taskAwaiter9.IsCompleted)
						{
							int num6 = 0;
							num = 0;
							num2 = num6;
							taskAwaiter2 = taskAwaiter9;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class45.Struct22>(ref taskAwaiter9, ref this);
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
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<JObject>, Class45.Struct22>(ref taskAwaiter8, ref this);
						return;
					}
					IL_1EC:
					JObject result2 = taskAwaiter8.GetResult();
					@class.string_14 = result2["delivery"]["deliveryMethodID"].ToString();
					goto IL_2A4;
				}
				catch
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					goto IL_258;
				}
				@class.method_5("Error setting delivery data", "#c2c2c2", true, false);
				taskAwaiter7 = @class.method_14(Class130.int_1).GetAwaiter();
				if (taskAwaiter7.IsCompleted)
				{
					goto IL_251;
				}
				int num9 = 2;
				num = 2;
				num2 = num9;
				taskAwaiter6 = taskAwaiter7;
				this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class45.Struct22>(ref taskAwaiter7, ref this);
				return;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_2A4:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult();
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x000032F2 File Offset: 0x000014F2
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040000B1 RID: 177
		public int int_0;

		// Token: 0x040000B2 RID: 178
		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		// Token: 0x040000B3 RID: 179
		public Class45 class45_0;

		// Token: 0x040000B4 RID: 180
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040000B5 RID: 181
		private TaskAwaiter<JObject> taskAwaiter_1;

		// Token: 0x040000B6 RID: 182
		private TaskAwaiter taskAwaiter_2;
	}
}
