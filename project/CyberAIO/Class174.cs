using System;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using HtmlAgilityPack;

// Token: 0x02000170 RID: 368
internal sealed class Class174 : DelegatingHandler
{
	// Token: 0x060007F6 RID: 2038 RVA: 0x0004664C File Offset: 0x0004484C
	protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		HttpResponseMessage result;
		for (;;)
		{
			this.method_0(request);
			TaskAwaiter<HttpResponseMessage> taskAwaiter = this.method_2(request, cancellationToken).GetAwaiter();
			TaskAwaiter<HttpResponseMessage> taskAwaiter2;
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
			}
			result = taskAwaiter.GetResult();
			if (!result.Headers.Contains("cf-chl-bypass"))
			{
				break;
			}
			HttpMethod method = request.Method;
			Uri requestUri = request.RequestUri;
			request.Method = HttpMethod.Get;
			HttpRequestMessage httpRequestMessage = request;
			TaskAwaiter<Uri> taskAwaiter3 = this.method_1(result, cancellationToken).GetAwaiter();
			if (!taskAwaiter3.IsCompleted)
			{
				await taskAwaiter3;
				TaskAwaiter<Uri> taskAwaiter4;
				taskAwaiter3 = taskAwaiter4;
				taskAwaiter4 = default(TaskAwaiter<Uri>);
			}
			httpRequestMessage.RequestUri = taskAwaiter3.GetResult();
			httpRequestMessage = null;
			request.Headers.TryAddWithoutValidation("referer", requestUri.ToString());
			taskAwaiter = this.method_2(request, cancellationToken).GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
			}
			HttpResponseMessage result2 = taskAwaiter.GetResult();
			if (result2.Headers.Contains("Set-Cookie"))
			{
				foreach (string text in (string[])result2.Headers.GetValues("Set-Cookie"))
				{
					if (text.Contains("cf_clearance"))
					{
						Class48.string_7 = text.Replace("cf_clearance=", string.Empty).Split(new char[]
						{
							';'
						})[0];
						Console.WriteLine(Class48.string_7);
					}
				}
			}
			request.Method = method;
			request.RequestUri = requestUri;
		}
		return result;
	}

	// Token: 0x060007F7 RID: 2039 RVA: 0x000466A4 File Offset: 0x000448A4
	private void method_0(HttpRequestMessage httpRequestMessage_0)
	{
		if (httpRequestMessage_0.RequestUri.Host != "prod.jdgroupmesh.cloud")
		{
			return;
		}
		string a = httpRequestMessage_0.RequestUri.AbsolutePath.Split(new char[]
		{
			'/'
		})[2];
		if (a == "footpatrol")
		{
			httpRequestMessage_0.Headers.TryAddWithoutValidation("X-Request-Auth", Class45.smethod_0(httpRequestMessage_0.RequestUri, httpRequestMessage_0.Method.ToString()));
			return;
		}
		if (!(a == "thehipstore"))
		{
			return;
		}
		httpRequestMessage_0.Headers.TryAddWithoutValidation("X-Request-Auth", Class45.smethod_1(httpRequestMessage_0.RequestUri, httpRequestMessage_0.Method.ToString()));
	}

	// Token: 0x060007F8 RID: 2040 RVA: 0x00046754 File Offset: 0x00044954
	private async Task<Uri> method_1(HttpResponseMessage httpResponseMessage_0, CancellationToken cancellationToken_0)
	{
		HtmlDocument htmlDocument = new HtmlDocument();
		HtmlDocument htmlDocument2 = htmlDocument;
		TaskAwaiter<string> taskAwaiter = httpResponseMessage_0.smethod_3().GetAwaiter();
		TaskAwaiter<string> taskAwaiter2;
		if (!taskAwaiter.IsCompleted)
		{
			await taskAwaiter;
			taskAwaiter = taskAwaiter2;
			taskAwaiter2 = default(TaskAwaiter<string>);
		}
		htmlDocument2.LoadHtml(taskAwaiter.GetResult());
		htmlDocument2 = null;
		HtmlNode htmlNode = htmlDocument.DocumentNode.SelectSingleNode("//script[@src='/cdn-cgi/scripts/cf.challenge.js']");
		Uri result;
		if (htmlNode == null)
		{
			result = null;
		}
		else
		{
			string value = htmlNode.Attributes["data-ray"].Value;
			string text = string.Format("{0}://{1}", httpResponseMessage_0.RequestMessage.RequestUri.Scheme, httpResponseMessage_0.RequestMessage.RequestUri.Authority);
			string value2 = htmlNode.Attributes["data-sitekey"].Value;
			string str = text + htmlDocument.GetElementbyId("challenge-form").Attributes["action"].Value;
			taskAwaiter = CaptchaQueue.smethod_0(value2, text, "0", cancellationToken_0).GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter<string>);
			}
			result = new Uri(str + string.Format("?id={0}&g-recaptcha-response={1}", value, taskAwaiter.GetResult()));
		}
		return result;
	}

	// Token: 0x060007F9 RID: 2041 RVA: 0x0000682B File Offset: 0x00004A2B
	[DebuggerHidden]
	private Task<HttpResponseMessage> method_2(HttpRequestMessage httpRequestMessage_0, CancellationToken cancellationToken_0)
	{
		return base.SendAsync(httpRequestMessage_0, cancellationToken_0);
	}

	// Token: 0x02000171 RID: 369
	[StructLayout(LayoutKind.Auto)]
	private struct Struct145 : IAsyncStateMachine
	{
		// Token: 0x060007FA RID: 2042 RVA: 0x000467A4 File Offset: 0x000449A4
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Class174 @class = this;
			HttpResponseMessage result2;
			try
			{
				TaskAwaiter<HttpResponseMessage> taskAwaiter5;
				TaskAwaiter<Uri> taskAwaiter6;
				switch (num)
				{
				case 0:
					taskAwaiter5 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
					num2 = -1;
					goto IL_DB;
				case 1:
					taskAwaiter6 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<Uri>);
					num2 = -1;
					goto IL_159;
				case 2:
					taskAwaiter5 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
					num2 = -1;
					goto IL_22F;
				}
				IL_AB:
				@class.method_0(request);
				taskAwaiter5 = @class.method_2(request, cancellationToken).GetAwaiter();
				if (!taskAwaiter5.IsCompleted)
				{
					num2 = 0;
					taskAwaiter2 = taskAwaiter5;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class174.Struct145>(ref taskAwaiter5, ref this);
					return;
				}
				IL_DB:
				HttpResponseMessage result = taskAwaiter5.GetResult();
				if (!result.Headers.Contains("cf-chl-bypass"))
				{
					result2 = result;
					goto IL_2D3;
				}
				method = request.Method;
				requestUri = request.RequestUri;
				request.Method = HttpMethod.Get;
				httpRequestMessage = request;
				taskAwaiter6 = @class.method_1(result, cancellationToken).GetAwaiter();
				if (!taskAwaiter6.IsCompleted)
				{
					num2 = 1;
					taskAwaiter4 = taskAwaiter6;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<Uri>, Class174.Struct145>(ref taskAwaiter6, ref this);
					return;
				}
				IL_159:
				Uri result3 = taskAwaiter6.GetResult();
				httpRequestMessage.RequestUri = result3;
				httpRequestMessage = null;
				request.Headers.TryAddWithoutValidation("referer", requestUri.ToString());
				taskAwaiter5 = @class.method_2(request, cancellationToken).GetAwaiter();
				if (!taskAwaiter5.IsCompleted)
				{
					num2 = 2;
					taskAwaiter2 = taskAwaiter5;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class174.Struct145>(ref taskAwaiter5, ref this);
					return;
				}
				IL_22F:
				HttpResponseMessage result4 = taskAwaiter5.GetResult();
				if (result4.Headers.Contains("Set-Cookie"))
				{
					foreach (string text in (string[])result4.Headers.GetValues("Set-Cookie"))
					{
						if (text.Contains("cf_clearance"))
						{
							Class48.string_7 = text.Replace("cf_clearance=", string.Empty).Split(new char[]
							{
								';'
							})[0];
							Console.WriteLine(Class48.string_7);
						}
					}
				}
				request.Method = method;
				request.RequestUri = requestUri;
				goto IL_AB;
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_2D3:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult(result2);
		}

		// Token: 0x060007FB RID: 2043 RVA: 0x00006835 File Offset: 0x00004A35
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040006AC RID: 1708
		public int int_0;

		// Token: 0x040006AD RID: 1709
		public AsyncTaskMethodBuilder<HttpResponseMessage> asyncTaskMethodBuilder_0;

		// Token: 0x040006AE RID: 1710
		public Class174 class174_0;

		// Token: 0x040006AF RID: 1711
		public HttpRequestMessage httpRequestMessage_0;

		// Token: 0x040006B0 RID: 1712
		public CancellationToken cancellationToken_0;

		// Token: 0x040006B1 RID: 1713
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x040006B2 RID: 1714
		private HttpMethod httpMethod_0;

		// Token: 0x040006B3 RID: 1715
		private Uri uri_0;

		// Token: 0x040006B4 RID: 1716
		private HttpRequestMessage httpRequestMessage_1;

		// Token: 0x040006B5 RID: 1717
		private TaskAwaiter<Uri> taskAwaiter_1;
	}

	// Token: 0x02000172 RID: 370
	[StructLayout(LayoutKind.Auto)]
	private struct Struct146 : IAsyncStateMachine
	{
		// Token: 0x060007FC RID: 2044 RVA: 0x00046AB8 File Offset: 0x00044CB8
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			Uri result2;
			try
			{
				TaskAwaiter<string> taskAwaiter3;
				if (num != 0)
				{
					if (num == 1)
					{
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<string>);
						num2 = -1;
						goto IL_1B4;
					}
					htmlDocument = new HtmlDocument();
					htmlDocument2 = htmlDocument;
					taskAwaiter3 = httpResponseMessage_0.smethod_3().GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						num2 = 0;
						taskAwaiter2 = taskAwaiter3;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class174.Struct146>(ref taskAwaiter3, ref this);
						return;
					}
				}
				else
				{
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<string>);
					num2 = -1;
				}
				string result = taskAwaiter3.GetResult();
				htmlDocument2.LoadHtml(result);
				htmlDocument2 = null;
				HtmlNode htmlNode = htmlDocument.DocumentNode.SelectSingleNode("//script[@src='/cdn-cgi/scripts/cf.challenge.js']");
				if (htmlNode == null)
				{
					result2 = null;
					goto IL_1FB;
				}
				value = htmlNode.Attributes["data-ray"].Value;
				string str2 = string.Format("{0}://{1}", httpResponseMessage_0.RequestMessage.RequestUri.Scheme, httpResponseMessage_0.RequestMessage.RequestUri.Authority);
				string value2 = htmlNode.Attributes["data-sitekey"].Value;
				str = str2 + htmlDocument.GetElementbyId("challenge-form").Attributes["action"].Value;
				taskAwaiter3 = CaptchaQueue.smethod_0(value2, str2, "0", cancellationToken_0).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					num2 = 1;
					taskAwaiter2 = taskAwaiter3;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class174.Struct146>(ref taskAwaiter3, ref this);
					return;
				}
				IL_1B4:
				string result3 = taskAwaiter3.GetResult();
				result2 = new Uri(str + string.Format("?id={0}&g-recaptcha-response={1}", value, result3));
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			IL_1FB:
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult(result2);
		}

		// Token: 0x060007FD RID: 2045 RVA: 0x00006843 File Offset: 0x00004A43
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040006B6 RID: 1718
		public int int_0;

		// Token: 0x040006B7 RID: 1719
		public AsyncTaskMethodBuilder<Uri> asyncTaskMethodBuilder_0;

		// Token: 0x040006B8 RID: 1720
		public HttpResponseMessage httpResponseMessage_0;

		// Token: 0x040006B9 RID: 1721
		public CancellationToken cancellationToken_0;

		// Token: 0x040006BA RID: 1722
		private HtmlDocument htmlDocument_0;

		// Token: 0x040006BB RID: 1723
		private string string_0;

		// Token: 0x040006BC RID: 1724
		private string string_1;

		// Token: 0x040006BD RID: 1725
		private HtmlDocument htmlDocument_1;

		// Token: 0x040006BE RID: 1726
		private TaskAwaiter<string> taskAwaiter_0;
	}
}
