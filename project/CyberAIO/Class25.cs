using System;

// Token: 0x02000037 RID: 55
internal sealed class Class25 : Interface6
{
	// Token: 0x06000115 RID: 277 RVA: 0x0000355C File Offset: 0x0000175C
	public Class25(Interface6 interface6_1, byte[] byte_1) : this(interface6_1, byte_1, 0, byte_1.Length)
	{
	}

	// Token: 0x06000116 RID: 278 RVA: 0x0000D810 File Offset: 0x0000BA10
	public Class25(Interface6 interface6_1, byte[] byte_1, int int_0, int int_1)
	{
		if (interface6_1 == null)
		{
			throw new ArgumentNullException("parameters");
		}
		if (byte_1 == null)
		{
			throw new ArgumentNullException("iv");
		}
		this.interface6_0 = interface6_1;
		this.byte_0 = new byte[int_1];
		Array.Copy(byte_1, int_0, this.byte_0, 0, int_1);
	}

	// Token: 0x06000117 RID: 279 RVA: 0x0000356A File Offset: 0x0000176A
	public byte[] method_0()
	{
		return (byte[])this.byte_0.Clone();
	}

	// Token: 0x06000118 RID: 280 RVA: 0x0000357C File Offset: 0x0000177C
	public Interface6 method_1()
	{
		return this.interface6_0;
	}

	// Token: 0x040000C0 RID: 192
	private readonly Interface6 interface6_0;

	// Token: 0x040000C1 RID: 193
	private readonly byte[] byte_0;
}
