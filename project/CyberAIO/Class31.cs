using System;

// Token: 0x02000043 RID: 67
internal static class Class31
{
	// Token: 0x06000154 RID: 340 RVA: 0x0000F4BC File Offset: 0x0000D6BC
	public static void smethod_0(byte[] byte_0, int int_0, int int_1)
	{
		for (int i = 0; i < 4; i++)
		{
			int num = int_0++;
			byte_0[num] ^= (byte)(int_1 >> i * 8);
		}
	}

	// Token: 0x06000155 RID: 341 RVA: 0x0000F4F4 File Offset: 0x0000D6F4
	public static void smethod_1(byte[] byte_0, int int_0, int int_1)
	{
		for (int i = 0; i < 4; i++)
		{
			if (int_0 >= byte_0.Length)
			{
				return;
			}
			int num = int_0++;
			byte_0[num] ^= (byte)(int_1 >> i * 8);
		}
	}

	// Token: 0x06000156 RID: 342 RVA: 0x0000F530 File Offset: 0x0000D730
	public static void smethod_2(byte[] byte_0, int int_0, long long_0)
	{
		for (int i = 0; i < 8; i++)
		{
			int num = int_0++;
			byte_0[num] ^= (byte)(long_0 >> i * 8);
		}
	}
}
