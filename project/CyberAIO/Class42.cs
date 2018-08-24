using System;

// Token: 0x02000058 RID: 88
internal sealed class Class42
{
	// Token: 0x060001AA RID: 426 RVA: 0x00003A59 File Offset: 0x00001C59
	public Class24[] method_0()
	{
		return this.class24_0;
	}

	// Token: 0x060001AB RID: 427 RVA: 0x00003A61 File Offset: 0x00001C61
	public void method_1(Class24[] class24_1)
	{
		this.class24_0 = class24_1;
	}

	// Token: 0x060001AC RID: 428 RVA: 0x00003A6A File Offset: 0x00001C6A
	public Class128[] method_2()
	{
		return this.class128_0;
	}

	// Token: 0x060001AD RID: 429 RVA: 0x00003A72 File Offset: 0x00001C72
	public void method_3(Class128[] class128_1)
	{
		this.class128_0 = class128_1;
	}

	// Token: 0x060001AE RID: 430 RVA: 0x00003A7B File Offset: 0x00001C7B
	public string method_4()
	{
		return this.string_0;
	}

	// Token: 0x060001AF RID: 431 RVA: 0x00003A83 File Offset: 0x00001C83
	public void method_5(string string_1)
	{
		this.string_0 = string_1;
	}

	// Token: 0x060001B0 RID: 432 RVA: 0x00003A8C File Offset: 0x00001C8C
	public int method_6()
	{
		return this.int_0;
	}

	// Token: 0x060001B1 RID: 433 RVA: 0x00003A94 File Offset: 0x00001C94
	public void method_7(int int_2)
	{
		this.int_0 = int_2;
	}

	// Token: 0x060001B2 RID: 434 RVA: 0x00003A9D File Offset: 0x00001C9D
	public int method_8()
	{
		return this.int_1;
	}

	// Token: 0x060001B3 RID: 435 RVA: 0x00003AA5 File Offset: 0x00001CA5
	public void method_9(int int_2)
	{
		this.int_1 = int_2;
	}

	// Token: 0x060001B4 RID: 436 RVA: 0x00003AAE File Offset: 0x00001CAE
	public byte method_10()
	{
		return this.byte_0;
	}

	// Token: 0x060001B5 RID: 437 RVA: 0x00003AB6 File Offset: 0x00001CB6
	public void method_11(byte byte_1)
	{
		this.byte_0 = byte_1;
	}

	// Token: 0x060001B6 RID: 438 RVA: 0x00003ABF File Offset: 0x00001CBF
	public bool method_12()
	{
		return (this.method_10() & 4) > 0;
	}

	// Token: 0x060001B7 RID: 439 RVA: 0x00003ACC File Offset: 0x00001CCC
	public bool method_13()
	{
		return (this.method_10() & 1) > 0;
	}

	// Token: 0x060001B8 RID: 440 RVA: 0x00003AD9 File Offset: 0x00001CD9
	public bool method_14()
	{
		return (this.method_10() & 8) > 0;
	}

	// Token: 0x04000116 RID: 278
	private Class128[] class128_0;

	// Token: 0x04000117 RID: 279
	private byte byte_0;

	// Token: 0x04000118 RID: 280
	private int int_0;

	// Token: 0x04000119 RID: 281
	private Class24[] class24_0;

	// Token: 0x0400011A RID: 282
	private string string_0;

	// Token: 0x0400011B RID: 283
	private int int_1;
}
