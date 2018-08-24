using System;

// Token: 0x020000E5 RID: 229
internal sealed class Class125 : Interface2
{
	// Token: 0x06000542 RID: 1346 RVA: 0x00002D6B File Offset: 0x00000F6B
	public void imethod_0()
	{
	}

	// Token: 0x06000543 RID: 1347 RVA: 0x00005185 File Offset: 0x00003385
	public string imethod_1()
	{
		return "PKCS7";
	}

	// Token: 0x06000544 RID: 1348 RVA: 0x0002D604 File Offset: 0x0002B804
	public int imethod_2(byte[] byte_0, int int_0)
	{
		byte b = (byte)(byte_0.Length - int_0);
		while (int_0 < byte_0.Length)
		{
			byte_0[int_0] = b;
			int_0++;
		}
		return (int)b;
	}

	// Token: 0x06000545 RID: 1349 RVA: 0x0002D62C File Offset: 0x0002B82C
	public int imethod_3(byte[] byte_0)
	{
		int num = (int)byte_0[byte_0.Length - 1];
		if (num >= 1 && num <= byte_0.Length)
		{
			for (int i = 1; i <= num; i++)
			{
				if ((int)byte_0[byte_0.Length - i] != num)
				{
					throw new Exception1("pad block corrupted");
				}
			}
			return num;
		}
		throw new Exception1("pad block corrupted");
	}
}
