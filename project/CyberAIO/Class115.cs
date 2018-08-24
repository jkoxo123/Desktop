using System;

// Token: 0x020000B9 RID: 185
internal static class Class115
{
	// Token: 0x06000489 RID: 1161 RVA: 0x00004CAD File Offset: 0x00002EAD
	public static void smethod_0(ref byte byte_0)
	{
		byte_0 = (byte)Class115.int_0;
		Class115.int_1 = (int)byte_0;
	}

	// Token: 0x0600048A RID: 1162 RVA: 0x00004CC2 File Offset: 0x00002EC2
	public static void smethod_1(ref int int_2)
	{
		int_2 = Class115.int_0;
		Class115.int_1 = int_2;
	}

	// Token: 0x0600048B RID: 1163 RVA: 0x00004CD6 File Offset: 0x00002ED6
	public static void smethod_2(ref long long_0)
	{
		long_0 = (long)Class115.int_0;
		Class115.int_1 = (int)long_0;
	}

	// Token: 0x0600048C RID: 1164 RVA: 0x00004CEC File Offset: 0x00002EEC
	public static void smethod_3(ref char char_0)
	{
		char_0 = (char)Class115.int_0;
		Class115.int_1 = (int)char_0;
	}

	// Token: 0x0600048D RID: 1165 RVA: 0x00004D01 File Offset: 0x00002F01
	public static void smethod_4(Array array_0, int int_2, int int_3)
	{
		Array.Clear(array_0, int_2, int_3);
	}

	// Token: 0x0600048E RID: 1166 RVA: 0x00004D0B File Offset: 0x00002F0B
	public static void smethod_5(Array array_0)
	{
		Class115.smethod_4(array_0, 0, array_0.GetLength(0));
	}

	// Token: 0x0400020B RID: 523
	private static int int_0;

	// Token: 0x0400020C RID: 524
	private static int int_1;
}
