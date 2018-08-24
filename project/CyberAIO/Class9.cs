using System;
using System.Collections.Generic;

// Token: 0x02000013 RID: 19
internal sealed class Class9 : IDisposable, Interface5
{
	// Token: 0x06000056 RID: 86 RVA: 0x00002E88 File Offset: 0x00001088
	public int imethod_0()
	{
		return this.list_0.Count;
	}

	// Token: 0x06000057 RID: 87 RVA: 0x00002E95 File Offset: 0x00001095
	public void imethod_3()
	{
		this.list_0.Clear();
	}

	// Token: 0x06000058 RID: 88 RVA: 0x00002EA2 File Offset: 0x000010A2
	public Interface5 imethod_4()
	{
		return new Class9();
	}

	// Token: 0x06000059 RID: 89 RVA: 0x00002EA9 File Offset: 0x000010A9
	public void Dispose()
	{
		this.imethod_3();
		this.list_0 = null;
	}

	// Token: 0x0600005A RID: 90 RVA: 0x00002EB8 File Offset: 0x000010B8
	public void imethod_1(int int_0, out byte byte_0)
	{
		byte_0 = this.method_0(this.list_0[int_0], int_0);
	}

	// Token: 0x0600005B RID: 91 RVA: 0x000082E0 File Offset: 0x000064E0
	public void imethod_2(int int_0, ref byte byte_0)
	{
		for (int i = this.list_0.Count; i <= int_0; i++)
		{
			if (i == int_0)
			{
				this.list_0.Add(this.method_1(byte_0, i));
				return;
			}
			this.list_0.Add(this.method_1(0, i));
		}
		this.list_0[int_0] = this.method_1(byte_0, int_0);
	}

	// Token: 0x0600005C RID: 92 RVA: 0x00002ECF File Offset: 0x000010CF
	private byte method_0(byte byte_0, int int_0)
	{
		throw new NotImplementedException();
	}

	// Token: 0x0600005D RID: 93 RVA: 0x00002ECF File Offset: 0x000010CF
	private byte method_1(byte byte_0, int int_0)
	{
		throw new NotImplementedException();
	}

	// Token: 0x0400002A RID: 42
	private List<byte> list_0 = new List<byte>();
}
