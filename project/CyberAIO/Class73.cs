using System;

// Token: 0x020000A2 RID: 162
internal sealed class Class73 : Interface1
{
	// Token: 0x060003FF RID: 1023 RVA: 0x00020644 File Offset: 0x0001E844
	public Class73(Interface1 interface1_1)
	{
		this.interface1_0 = interface1_1;
		this.int_0 = interface1_1.imethod_2();
		this.byte_0 = new byte[this.int_0];
		this.byte_1 = new byte[this.int_0];
		this.byte_2 = new byte[this.int_0];
	}

	// Token: 0x06000400 RID: 1024 RVA: 0x0000474F File Offset: 0x0000294F
	public Interface1 method_0()
	{
		return this.interface1_0;
	}

	// Token: 0x06000401 RID: 1025 RVA: 0x000206A0 File Offset: 0x0001E8A0
	public void imethod_1(bool bool_1, Interface6 interface6_0)
	{
		this.bool_0 = bool_1;
		if (interface6_0 is Class25)
		{
			Class25 @class = (Class25)interface6_0;
			byte[] array = @class.method_0();
			if (array.Length != this.int_0)
			{
				throw new ArgumentException("initialisation vector must be the same length as block size");
			}
			Array.Copy(array, 0, this.byte_0, 0, array.Length);
			interface6_0 = @class.method_1();
		}
		this.imethod_5();
		this.interface1_0.imethod_1(this.bool_0, interface6_0);
	}

	// Token: 0x06000402 RID: 1026 RVA: 0x00004757 File Offset: 0x00002957
	public string imethod_0()
	{
		return this.interface1_0.imethod_0() + "/CBC";
	}

	// Token: 0x06000403 RID: 1027 RVA: 0x000030C0 File Offset: 0x000012C0
	public bool imethod_3()
	{
		return false;
	}

	// Token: 0x06000404 RID: 1028 RVA: 0x0000476E File Offset: 0x0000296E
	public int imethod_2()
	{
		return this.interface1_0.imethod_2();
	}

	// Token: 0x06000405 RID: 1029 RVA: 0x0000477B File Offset: 0x0000297B
	public int imethod_4(byte[] byte_3, int int_1, byte[] byte_4, int int_2)
	{
		if (!this.bool_0)
		{
			return this.method_2(byte_3, int_1, byte_4, int_2);
		}
		return this.method_1(byte_3, int_1, byte_4, int_2);
	}

	// Token: 0x06000406 RID: 1030 RVA: 0x0000479C File Offset: 0x0000299C
	public void imethod_5()
	{
		Array.Copy(this.byte_0, 0, this.byte_1, 0, this.byte_0.Length);
		Array.Clear(this.byte_2, 0, this.byte_2.Length);
		this.interface1_0.imethod_5();
	}

	// Token: 0x06000407 RID: 1031 RVA: 0x00020714 File Offset: 0x0001E914
	private int method_1(byte[] byte_3, int int_1, byte[] byte_4, int int_2)
	{
		if (int_1 + this.int_0 > byte_3.Length)
		{
			throw new Exception2("input buffer too short");
		}
		for (int i = 0; i < this.int_0; i++)
		{
			byte[] array = this.byte_1;
			int num = i;
			array[num] ^= byte_3[int_1 + i];
		}
		int result = this.interface1_0.imethod_4(this.byte_1, 0, byte_4, int_2);
		Array.Copy(byte_4, int_2, this.byte_1, 0, this.byte_1.Length);
		return result;
	}

	// Token: 0x06000408 RID: 1032 RVA: 0x0002078C File Offset: 0x0001E98C
	private int method_2(byte[] byte_3, int int_1, byte[] byte_4, int int_2)
	{
		if (int_1 + this.int_0 > byte_3.Length)
		{
			throw new Exception2("input buffer too short");
		}
		Array.Copy(byte_3, int_1, this.byte_2, 0, this.int_0);
		int result = this.interface1_0.imethod_4(byte_3, int_1, byte_4, int_2);
		for (int i = 0; i < this.int_0; i++)
		{
			int num = int_2 + i;
			byte_4[num] ^= this.byte_1[i];
		}
		byte[] array = this.byte_1;
		this.byte_1 = this.byte_2;
		this.byte_2 = array;
		return result;
	}

	// Token: 0x040001CB RID: 459
	private byte[] byte_0;

	// Token: 0x040001CC RID: 460
	private byte[] byte_1;

	// Token: 0x040001CD RID: 461
	private byte[] byte_2;

	// Token: 0x040001CE RID: 462
	private int int_0;

	// Token: 0x040001CF RID: 463
	private Interface1 interface1_0;

	// Token: 0x040001D0 RID: 464
	private bool bool_0;
}
