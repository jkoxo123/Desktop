using System;

// Token: 0x020000B5 RID: 181
internal sealed class Class3 : Class2
{
	// Token: 0x0600046F RID: 1135 RVA: 0x00004B78 File Offset: 0x00002D78
	public Class3(Interface8 interface8_1)
	{
		this.interface8_0 = interface8_1;
	}

	// Token: 0x06000470 RID: 1136 RVA: 0x00004B87 File Offset: 0x00002D87
	public override void Dispose()
	{
		this.interface8_0.imethod_15();
	}

	// Token: 0x06000471 RID: 1137 RVA: 0x00003C82 File Offset: 0x00001E82
	public override bool vmethod_0()
	{
		return true;
	}

	// Token: 0x06000472 RID: 1138 RVA: 0x00004B94 File Offset: 0x00002D94
	public override int vmethod_1()
	{
		return this.interface8_0.imethod_2();
	}

	// Token: 0x06000473 RID: 1139 RVA: 0x00004BA1 File Offset: 0x00002DA1
	public override int vmethod_2(byte[] byte_0, int int_0, int int_1, byte[] byte_1, int int_2)
	{
		return this.interface8_0.imethod_8(byte_0, int_0, int_1, byte_1, int_2);
	}

	// Token: 0x06000474 RID: 1140 RVA: 0x00004BB5 File Offset: 0x00002DB5
	public override byte[] vmethod_3(byte[] byte_0, int int_0, int int_1)
	{
		return this.interface8_0.imethod_11(byte_0, int_0, int_1);
	}

	// Token: 0x04000200 RID: 512
	private readonly Interface8 interface8_0;
}
