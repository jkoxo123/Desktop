using System;
using System.Security.Cryptography;

// Token: 0x0200016A RID: 362
internal sealed class Class4 : Class2
{
	// Token: 0x060007D9 RID: 2009 RVA: 0x000066E0 File Offset: 0x000048E0
	public Class4(ICryptoTransform icryptoTransform_1)
	{
		this.icryptoTransform_0 = icryptoTransform_1;
	}

	// Token: 0x060007DA RID: 2010 RVA: 0x000066EF File Offset: 0x000048EF
	public override void Dispose()
	{
		this.icryptoTransform_0.Dispose();
	}

	// Token: 0x060007DB RID: 2011 RVA: 0x000066FC File Offset: 0x000048FC
	public override bool vmethod_0()
	{
		return this.icryptoTransform_0.CanReuseTransform;
	}

	// Token: 0x060007DC RID: 2012 RVA: 0x00006709 File Offset: 0x00004909
	public override int vmethod_1()
	{
		return this.icryptoTransform_0.InputBlockSize;
	}

	// Token: 0x060007DD RID: 2013 RVA: 0x00006716 File Offset: 0x00004916
	public override int vmethod_2(byte[] byte_0, int int_0, int int_1, byte[] byte_1, int int_2)
	{
		return this.icryptoTransform_0.TransformBlock(byte_0, int_0, int_1, byte_1, int_2);
	}

	// Token: 0x060007DE RID: 2014 RVA: 0x0000672A File Offset: 0x0000492A
	public override byte[] vmethod_3(byte[] byte_0, int int_0, int int_1)
	{
		return this.icryptoTransform_0.TransformFinalBlock(byte_0, int_0, int_1);
	}

	// Token: 0x040006A1 RID: 1697
	private ICryptoTransform icryptoTransform_0;
}
