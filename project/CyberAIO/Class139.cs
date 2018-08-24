using System;

// Token: 0x02000111 RID: 273
internal sealed class Class139 : Class136
{
	// Token: 0x06000611 RID: 1553 RVA: 0x0000582D File Offset: 0x00003A2D
	public byte method_0()
	{
		return this.byte_0;
	}

	// Token: 0x06000612 RID: 1554 RVA: 0x00005835 File Offset: 0x00003A35
	public void method_1(byte byte_1)
	{
		this.byte_0 = byte_1;
	}

	// Token: 0x06000613 RID: 1555 RVA: 0x0000583E File Offset: 0x00003A3E
	public bool method_2()
	{
		return (this.method_0() & 2) > 0;
	}

	// Token: 0x06000614 RID: 1556 RVA: 0x0000584B File Offset: 0x00003A4B
	public bool method_3()
	{
		return (this.method_0() & 1) > 0;
	}

	// Token: 0x06000615 RID: 1557 RVA: 0x00005858 File Offset: 0x00003A58
	public Class0 method_4()
	{
		return this.class0_0;
	}

	// Token: 0x06000616 RID: 1558 RVA: 0x00005860 File Offset: 0x00003A60
	public void method_5(Class0 class0_4)
	{
		this.class0_0 = class0_4;
	}

	// Token: 0x06000617 RID: 1559 RVA: 0x00005869 File Offset: 0x00003A69
	public string method_6()
	{
		return this.string_0;
	}

	// Token: 0x06000618 RID: 1560 RVA: 0x00005871 File Offset: 0x00003A71
	public void method_7(string string_1)
	{
		this.string_0 = string_1;
	}

	// Token: 0x06000619 RID: 1561 RVA: 0x0000587A File Offset: 0x00003A7A
	public Class0[] method_8()
	{
		return this.class0_1;
	}

	// Token: 0x0600061A RID: 1562 RVA: 0x00005882 File Offset: 0x00003A82
	public void method_9(Class0[] class0_4)
	{
		this.class0_1 = class0_4;
	}

	// Token: 0x0600061B RID: 1563 RVA: 0x0000588B File Offset: 0x00003A8B
	public Class0[] method_10()
	{
		return this.class0_2;
	}

	// Token: 0x0600061C RID: 1564 RVA: 0x00005893 File Offset: 0x00003A93
	public void method_11(Class0[] class0_4)
	{
		this.class0_2 = class0_4;
	}

	// Token: 0x0600061D RID: 1565 RVA: 0x0000589C File Offset: 0x00003A9C
	public Class0 method_12()
	{
		return this.class0_3;
	}

	// Token: 0x0600061E RID: 1566 RVA: 0x000058A4 File Offset: 0x00003AA4
	public void method_13(Class0 class0_4)
	{
		this.class0_3 = class0_4;
	}

	// Token: 0x0600061F RID: 1567 RVA: 0x00003C82 File Offset: 0x00001E82
	public override byte vmethod_0()
	{
		return 1;
	}

	// Token: 0x040004D7 RID: 1239
	private byte byte_0;

	// Token: 0x040004D8 RID: 1240
	private Class0 class0_0;

	// Token: 0x040004D9 RID: 1241
	private string string_0;

	// Token: 0x040004DA RID: 1242
	private Class0[] class0_1;

	// Token: 0x040004DB RID: 1243
	private Class0[] class0_2;

	// Token: 0x040004DC RID: 1244
	private Class0 class0_3;
}
