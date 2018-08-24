using System;
using System.Net.Http;
using System.Threading.Tasks;

// Token: 0x0200016B RID: 363
public sealed class GClass4
{
	// Token: 0x040006A2 RID: 1698
	public readonly TaskCompletionSource<bool> taskCompletionSource_0 = new TaskCompletionSource<bool>();

	// Token: 0x040006A3 RID: 1699
	public DateTime dateTime_0 = DateTime.Now;

	// Token: 0x040006A4 RID: 1700
	public Task task_0;

	// Token: 0x040006A5 RID: 1701
	public Task<HttpResponseMessage> task_1;

	// Token: 0x040006A6 RID: 1702
	public HttpResponseMessage httpResponseMessage_0;
}
