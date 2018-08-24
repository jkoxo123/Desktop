using System;

// Token: 0x02000032 RID: 50
internal abstract class Class21 : Interface8
{
	// Token: 0x060000F9 RID: 249
	public abstract string imethod_0();

	// Token: 0x060000FA RID: 250
	public abstract void imethod_1(bool bool_0, Interface6 interface6_0);

	// Token: 0x060000FB RID: 251
	public abstract int imethod_2();

	// Token: 0x060000FC RID: 252
	public abstract int imethod_3(int int_0);

	// Token: 0x060000FD RID: 253
	public abstract int imethod_4(int int_0);

	// Token: 0x060000FE RID: 254 RVA: 0x00003499 File Offset: 0x00001699
	public virtual byte[] imethod_5(byte[] byte_1)
	{
		return this.imethod_6(byte_1, 0, byte_1.Length);
	}

	// Token: 0x060000FF RID: 255
	public abstract byte[] imethod_6(byte[] byte_1, int int_0, int int_1);

	// Token: 0x06000100 RID: 256 RVA: 0x000034A6 File Offset: 0x000016A6
	public virtual int imethod_7(byte[] byte_1, byte[] byte_2, int int_0)
	{
		return this.imethod_8(byte_1, 0, byte_1.Length, byte_2, int_0);
	}

	// Token: 0x06000101 RID: 257 RVA: 0x0000D538 File Offset: 0x0000B738
	public virtual int imethod_8(byte[] byte_1, int int_0, int int_1, byte[] byte_2, int int_2)
	{
		byte[] array = this.imethod_6(byte_1, int_0, int_1);
		if (array == null)
		{
			return 0;
		}
		if (int_2 + array.Length > byte_2.Length)
		{
			throw new Exception2("output buffer too short");
		}
		array.CopyTo(byte_2, int_2);
		return array.Length;
	}

	// Token: 0x06000102 RID: 258
	public abstract byte[] imethod_9();

	// Token: 0x06000103 RID: 259 RVA: 0x000034B5 File Offset: 0x000016B5
	public virtual byte[] imethod_10(byte[] byte_1)
	{
		return this.imethod_11(byte_1, 0, byte_1.Length);
	}

	// Token: 0x06000104 RID: 260
	public abstract byte[] imethod_11(byte[] byte_1, int int_0, int int_1);

	// Token: 0x06000105 RID: 261 RVA: 0x0000D578 File Offset: 0x0000B778
	public virtual int imethod_12(byte[] byte_1, int int_0)
	{
		byte[] array = this.imethod_9();
		if (int_0 + array.Length > byte_1.Length)
		{
			throw new Exception2("output buffer too short");
		}
		array.CopyTo(byte_1, int_0);
		return array.Length;
	}

	// Token: 0x06000106 RID: 262 RVA: 0x000034C2 File Offset: 0x000016C2
	public virtual int imethod_13(byte[] byte_1, byte[] byte_2, int int_0)
	{
		return this.imethod_14(byte_1, 0, byte_1.Length, byte_2, int_0);
	}

	// Token: 0x06000107 RID: 263 RVA: 0x0000D5AC File Offset: 0x0000B7AC
	public virtual int imethod_14(byte[] byte_1, int int_0, int int_1, byte[] byte_2, int int_2)
	{
		int num = this.imethod_8(byte_1, int_0, int_1, byte_2, int_2);
		return num + this.imethod_12(byte_2, int_2 + num);
	}

	// Token: 0x06000108 RID: 264
	public abstract void imethod_15();

	// Token: 0x040000BB RID: 187
	protected static readonly byte[] byte_0 = new byte[0];
}
