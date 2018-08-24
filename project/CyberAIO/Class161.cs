using System;
using System.IO;

// Token: 0x0200013A RID: 314
internal static class Class161
{
	// Token: 0x0600072A RID: 1834 RVA: 0x000061E8 File Offset: 0x000043E8
	public static void smethod_0(int int_0, byte[] byte_0, int int_1)
	{
		byte_0[int_1] = (byte)int_0;
		byte_0[int_1 + 1] = (byte)(int_0 >> 8);
		byte_0[int_1 + 2] = (byte)(int_0 >> 16);
		byte_0[int_1 + 3] = (byte)(int_0 >> 24);
	}

	// Token: 0x0600072B RID: 1835 RVA: 0x0003C728 File Offset: 0x0003A928
	public static void smethod_1(long long_0, byte[] byte_0, int int_0)
	{
		byte_0[int_0] = (byte)long_0;
		byte_0[int_0 + 1] = (byte)(long_0 >> 8);
		byte_0[int_0 + 2] = (byte)(long_0 >> 16);
		byte_0[int_0 + 3] = (byte)(long_0 >> 24);
		byte_0[int_0 + 4] = (byte)(long_0 >> 32);
		byte_0[int_0 + 5] = (byte)(long_0 >> 40);
		byte_0[int_0 + 6] = (byte)(long_0 >> 48);
		byte_0[int_0 + 7] = (byte)(long_0 >> 56);
	}

	// Token: 0x0600072C RID: 1836 RVA: 0x0003C780 File Offset: 0x0003A980
	public static byte[] smethod_2(int int_0)
	{
		if (BitConverter.IsLittleEndian)
		{
			return BitConverter.GetBytes(int_0);
		}
		byte[] array = new byte[4];
		Class161.smethod_0(int_0, array, 0);
		return array;
	}

	// Token: 0x0600072D RID: 1837 RVA: 0x0003C7AC File Offset: 0x0003A9AC
	public static byte[] smethod_3(long long_0)
	{
		if (BitConverter.IsLittleEndian)
		{
			return BitConverter.GetBytes(long_0);
		}
		byte[] array = new byte[8];
		Class161.smethod_1(long_0, array, 0);
		return array;
	}

	// Token: 0x0600072E RID: 1838 RVA: 0x0000620C File Offset: 0x0000440C
	public static int smethod_4(byte[] byte_0, int int_0)
	{
		if (BitConverter.IsLittleEndian)
		{
			return BitConverter.ToInt32(byte_0, int_0);
		}
		return (int)byte_0[int_0] | (int)byte_0[int_0 + 1] << 8 | (int)byte_0[int_0 + 2] << 16 | (int)byte_0[int_0 + 3] << 24;
	}

	// Token: 0x0600072F RID: 1839 RVA: 0x0003C7D8 File Offset: 0x0003A9D8
	public static long smethod_5(byte[] byte_0, int int_0)
	{
		if (BitConverter.IsLittleEndian)
		{
			return BitConverter.ToInt64(byte_0, int_0);
		}
		return (long)((ulong)byte_0[int_0] | (ulong)byte_0[int_0 + 1] << 8 | (ulong)byte_0[int_0 + 2] << 16 | (ulong)byte_0[int_0 + 3] << 24 | (ulong)byte_0[int_0 + 4] << 32 | (ulong)byte_0[int_0 + 5] << 40 | (ulong)byte_0[int_0 + 6] << 48 | (ulong)byte_0[int_0 + 7] << 56);
	}

	// Token: 0x06000730 RID: 1840 RVA: 0x0003C840 File Offset: 0x0003AA40
	public static float smethod_6(byte[] byte_0, int int_0)
	{
		if (BitConverter.IsLittleEndian && Struct144.bool_0)
		{
			return BitConverter.ToSingle(byte_0, int_0);
		}
		BinaryReader binaryReader = new BinaryReader(new MemoryStream(byte_0, int_0, 4, false));
		float result = binaryReader.ReadSingle();
		binaryReader.Close();
		return result;
	}

	// Token: 0x06000731 RID: 1841 RVA: 0x0003C880 File Offset: 0x0003AA80
	public static double smethod_7(byte[] byte_0, int int_0)
	{
		if (BitConverter.IsLittleEndian && Struct52.bool_0)
		{
			return BitConverter.ToDouble(byte_0, int_0);
		}
		BinaryReader binaryReader = new BinaryReader(new MemoryStream(byte_0, int_0, 8, false));
		double result = binaryReader.ReadDouble();
		binaryReader.Close();
		return result;
	}
}
