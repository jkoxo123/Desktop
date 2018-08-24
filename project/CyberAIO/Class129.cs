using System;

// Token: 0x020000EC RID: 236
internal sealed class Class129
{
	// Token: 0x06000589 RID: 1417 RVA: 0x00002B9B File Offset: 0x00000D9B
	private Class129()
	{
	}

	// Token: 0x0600058A RID: 1418 RVA: 0x00005430 File Offset: 0x00003630
	internal static void smethod_0(uint uint_0, byte[] byte_0, int int_0)
	{
		byte_0[int_0] = (byte)uint_0;
		byte_0[++int_0] = (byte)(uint_0 >> 8);
		byte_0[++int_0] = (byte)(uint_0 >> 16);
		byte_0[++int_0] = (byte)(uint_0 >> 24);
	}

	// Token: 0x0600058B RID: 1419 RVA: 0x00005463 File Offset: 0x00003663
	internal static uint smethod_1(byte[] byte_0, int int_0)
	{
		return (uint)((int)byte_0[int_0] | (int)byte_0[++int_0] << 8 | (int)byte_0[++int_0] << 16 | (int)byte_0[++int_0] << 24);
	}
}
