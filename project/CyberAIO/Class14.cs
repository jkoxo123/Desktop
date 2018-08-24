using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CloudFlareUtilities;
using Newtonsoft.Json.Linq;

// Token: 0x0200001D RID: 29
internal sealed class Class14 : IDisposable
{
	// Token: 0x06000096 RID: 150 RVA: 0x00009944 File Offset: 0x00007B44
	public Class14(string string_0 = null, string string_1 = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36", int int_0 = 10, bool bool_1 = false, bool bool_2 = false, JObject jobject_0 = null)
	{
		this.bool_0 = bool_1;
		this.cookieContainer_0 = new CookieContainer();
		WebRequestHandler webRequestHandler = new WebRequestHandler
		{
			UseCookies = true,
			CookieContainer = this.cookieContainer_0,
			AllowAutoRedirect = false,
			Proxy = Class14.smethod_0(string_0),
			PreAuthenticate = true,
			AutomaticDecompression = (DecompressionMethods.GZip | DecompressionMethods.Deflate),
			ClientCertificateOptions = ClientCertificateOption.Manual
		};
		if (!bool_2)
		{
			webRequestHandler.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(this.method_0);
		}
		Class174 innerHandler = new Class174
		{
			InnerHandler = webRequestHandler
		};
		ClearanceHandler handler = new ClearanceHandler
		{
			InnerHandler = innerHandler,
			MaxRetries = 3
		};
		this.httpClient_0 = new HttpClient(handler)
		{
			Timeout = TimeSpan.FromSeconds((double)int_0)
		};
		this.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", string_1);
		this.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");
		this.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("Upgrade-Insecure-Requests", "1");
		this.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Language", "en-GB,en-US;q=0.9,en;q=0.8");
		this.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation("Connection", "keep-alive");
		if (jobject_0 != null)
		{
			foreach (KeyValuePair<string, JToken> keyValuePair in jobject_0)
			{
				this.httpClient_0.DefaultRequestHeaders.TryAddWithoutValidation(keyValuePair.Key, (string)keyValuePair.Value);
			}
		}
	}

	// Token: 0x06000097 RID: 151 RVA: 0x00003050 File Offset: 0x00001250
	public void Dispose()
	{
		this.httpClient_0.Dispose();
	}

	// Token: 0x06000098 RID: 152 RVA: 0x00009AE0 File Offset: 0x00007CE0
	public bool method_0(object object_0, X509Certificate x509Certificate_0, X509Chain x509Chain_0, SslPolicyErrors sslPolicyErrors_0)
	{
		string host = ((HttpWebRequest)object_0).Host;
		string certHashString = x509Certificate_0.GetCertHashString();
		if (Debugger.IsAttached)
		{
			return true;
		}
		if (Class158.smethod_3().ToUpper().Contains(certHashString.ToUpper()))
		{
			return true;
		}
		if (this.bool_0)
		{
			if (!x509Certificate_0.Issuer.Contains("Let's Encrypt Authority X3") && !x509Certificate_0.Issuer.Contains("DigiCert SHA2 High Assurance Server CA"))
			{
				GClass3.smethod_0(certHashString, "SSL");
				return false;
			}
			return true;
		}
		else
		{
			if (host.Contains("supreme"))
			{
				return true;
			}
			GClass3.smethod_0(certHashString, "SSL");
			return host.Replace("www.", string.Empty) == "supremenewyork.com" && x509Certificate_0.Issuer == "CN=GlobalSign CloudSSL CA - SHA256 - G3, O=GlobalSign nv-sa, C=BE";
		}
	}

	// Token: 0x06000099 RID: 153 RVA: 0x00009BA8 File Offset: 0x00007DA8
	public static WebProxy smethod_0(string string_0)
	{
		WebProxy result;
		try
		{
			WebProxy webProxy = Debugger.IsAttached ? null : new WebProxy();
			if (string_0 == null)
			{
				result = webProxy;
			}
			else
			{
				string[] array = string_0.Split(new char[]
				{
					':'
				});
				if (array.Length == 4)
				{
					string address = string.Format("http://{0}:{1}", array[0], array[1]);
					NetworkCredential credentials = new NetworkCredential(array[2], array[3]);
					webProxy = new WebProxy(address, false)
					{
						UseDefaultCredentials = false,
						Credentials = credentials
					};
					result = webProxy;
				}
				else
				{
					result = ((array.Length == 2) ? new WebProxy(string.Format("{0}:{1}", array[0], array[1]), false) : webProxy);
				}
			}
		}
		catch
		{
			result = new WebProxy();
		}
		return result;
	}

	// Token: 0x0600009A RID: 154 RVA: 0x00009C58 File Offset: 0x00007E58
	private async Task<HttpResponseMessage> method_1(string string_0, Task<HttpResponseMessage> task_0)
	{
		TaskAwaiter<HttpResponseMessage> taskAwaiter = task_0.GetAwaiter();
		TaskAwaiter<HttpResponseMessage> taskAwaiter2;
		if (!taskAwaiter.IsCompleted)
		{
			await taskAwaiter;
			taskAwaiter = taskAwaiter2;
			taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
		}
		HttpResponseMessage result = taskAwaiter.GetResult();
		while (result.StatusCode >= HttpStatusCode.MultipleChoices && result.StatusCode <= (HttpStatusCode)399)
		{
			Uri uri = result.Headers.Location;
			if (!uri.IsAbsoluteUri)
			{
				uri = new Uri(new Uri(string_0).GetLeftPart(UriPartial.Authority) + uri);
			}
			taskAwaiter = this.httpClient_0.GetAsync(uri).GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
			}
			result = taskAwaiter.GetResult();
		}
		return result;
	}

	// Token: 0x0600009B RID: 155 RVA: 0x00009CB0 File Offset: 0x00007EB0
	public Task<HttpResponseMessage> method_2(string string_0, bool bool_1)
	{
		Task<HttpResponseMessage> async = this.httpClient_0.GetAsync(string_0);
		if (!bool_1)
		{
			return async;
		}
		return this.method_1(string_0, async);
	}

	// Token: 0x0600009C RID: 156 RVA: 0x00009CD8 File Offset: 0x00007ED8
	public Task<HttpResponseMessage> method_3(string string_0, Dictionary<string, string> dictionary_0, bool bool_1)
	{
		Task<HttpResponseMessage> task = this.httpClient_0.PostAsync(string_0, new FormUrlEncodedContent(dictionary_0));
		if (!bool_1)
		{
			return task;
		}
		return this.method_1(string_0, task);
	}

	// Token: 0x0600009D RID: 157 RVA: 0x00009D08 File Offset: 0x00007F08
	public Task<HttpResponseMessage> method_4(string string_0, JObject jobject_0, bool bool_1)
	{
		Task<HttpResponseMessage> task = this.httpClient_0.PostAsync(string_0, new StringContent(jobject_0.ToString(), Encoding.UTF8, "application/json"));
		if (!bool_1)
		{
			return task;
		}
		return this.method_1(string_0, task);
	}

	// Token: 0x0600009E RID: 158 RVA: 0x00009D44 File Offset: 0x00007F44
	public Task<HttpResponseMessage> method_5(string string_0, JObject jobject_0, bool bool_1)
	{
		Task<HttpResponseMessage> task = this.httpClient_0.SendAsync(new HttpRequestMessage
		{
			Method = new HttpMethod("PATCH"),
			RequestUri = new Uri(string_0),
			Content = new StringContent(jobject_0.ToString(), Encoding.UTF8, "application/json")
		});
		if (!bool_1)
		{
			return task;
		}
		return this.method_1(string_0, task);
	}

	// Token: 0x0600009F RID: 159 RVA: 0x00009DA8 File Offset: 0x00007FA8
	public Task<HttpResponseMessage> method_6(string string_0, Dictionary<string, string> dictionary_0, bool bool_1)
	{
		Task<HttpResponseMessage> task = this.httpClient_0.SendAsync(new HttpRequestMessage
		{
			Method = new HttpMethod("PATCH"),
			RequestUri = new Uri(string_0),
			Content = new FormUrlEncodedContent(dictionary_0)
		});
		if (!bool_1)
		{
			return task;
		}
		return this.method_1(string_0, task);
	}

	// Token: 0x060000A0 RID: 160 RVA: 0x00009DFC File Offset: 0x00007FFC
	public Task<HttpResponseMessage> method_7(string string_0, Dictionary<string, string> dictionary_0, bool bool_1)
	{
		Task<HttpResponseMessage> task = this.httpClient_0.PutAsync(string_0, new FormUrlEncodedContent(dictionary_0));
		if (!bool_1)
		{
			return task;
		}
		return this.method_1(string_0, task);
	}

	// Token: 0x060000A1 RID: 161 RVA: 0x00009E2C File Offset: 0x0000802C
	public Task<HttpResponseMessage> method_8(string string_0, JObject jobject_0, bool bool_1)
	{
		Task<HttpResponseMessage> task = this.httpClient_0.PutAsync(string_0, new StringContent(jobject_0.ToString(), Encoding.UTF8, "application/json"));
		if (!bool_1)
		{
			return task;
		}
		return this.method_1(string_0, task);
	}

	// Token: 0x04000055 RID: 85
	public CookieContainer cookieContainer_0;

	// Token: 0x04000056 RID: 86
	public HttpClient httpClient_0;

	// Token: 0x04000057 RID: 87
	private readonly bool bool_0;

	// Token: 0x0200001E RID: 30
	[StructLayout(LayoutKind.Auto)]
	private struct Struct11 : IAsyncStateMachine
	{
		// Token: 0x060000A2 RID: 162 RVA: 0x00009E68 File Offset: 0x00008068
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class14 @class = this;
			HttpResponseMessage result2;
			try
			{
				TaskAwaiter<HttpResponseMessage> taskAwaiter3;
				if (num != 0)
				{
					if (num == 1)
					{
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
						num2 = -1;
						goto IL_F2;
					}
					taskAwaiter3 = task_0.GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						num2 = 0;
						taskAwaiter2 = taskAwaiter3;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class14.Struct11>(ref taskAwaiter3, ref this);
						return;
					}
				}
				else
				{
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
					num2 = -1;
				}
				HttpResponseMessage result = taskAwaiter3.GetResult();
				goto IL_FA;
				IL_F2:
				result = taskAwaiter3.GetResult();
				IL_FA:
				if (result.StatusCode >= HttpStatusCode.MultipleChoices && result.StatusCode <= (HttpStatusCode)399)
				{
					Uri uri = result.Headers.Location;
					if (!uri.IsAbsoluteUri)
					{
						uri = new Uri(new Uri(string_0).GetLeftPart(UriPartial.Authority) + uri);
					}
					taskAwaiter3 = @class.httpClient_0.GetAsync(uri).GetAwaiter();
					if (taskAwaiter3.IsCompleted)
					{
						goto IL_F2;
					}
					num2 = 1;
					taskAwaiter2 = taskAwaiter3;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class14.Struct11>(ref taskAwaiter3, ref this);
					return;
				}
				else
				{
					result2 = result;
				}
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult(result2);
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x0000305D File Offset: 0x0000125D
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000058 RID: 88
		public int int_0;

		// Token: 0x04000059 RID: 89
		public AsyncTaskMethodBuilder<HttpResponseMessage> asyncTaskMethodBuilder_0;

		// Token: 0x0400005A RID: 90
		public Task<HttpResponseMessage> task_0;

		// Token: 0x0400005B RID: 91
		public string string_0;

		// Token: 0x0400005C RID: 92
		public Class14 class14_0;

		// Token: 0x0400005D RID: 93
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;
	}
}
