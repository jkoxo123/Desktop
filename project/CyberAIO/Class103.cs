using System;

// Token: 0x0200006B RID: 107
internal sealed class Class103 : Class100
{
	// Token: 0x060001EB RID: 491 RVA: 0x00003C71 File Offset: 0x00001E71
	public int method_2()
	{
		return this.int_0;
	}

	// Token: 0x060001EC RID: 492 RVA: 0x00003C79 File Offset: 0x00001E79
	public void method_3(int int_1)
	{
		this.int_0 = int_1;
	}

	// Token: 0x060001ED RID: 493 RVA: 0x00003C82 File Offset: 0x00001E82
	public override int vmethod_2()
	{
		return 1;
	}

	// Token: 0x060001EE RID: 494 RVA: 0x000124B8 File Offset: 0x000106B8
	public override Class80 vmethod_3(Class80 class80_0)
	{
		base.method_1(class80_0.method_0());
		int num = class80_0.vmethod_2();
		if (num == 1)
		{
			this.method_3(((Class103)class80_0).method_2());
			return this;
		}
		throw new ArgumentOutOfRangeException();
	}

	// Token: 0x060001EF RID: 495 RVA: 0x00003C85 File Offset: 0x00001E85
	public override Class80 vmethod_4()
	{
		Class103 @class = new Class103();
		@class.method_3(this.int_0);
		@class.method_1(base.method_0());
		return @class;
	}

	// Token: 0x04000148 RID: 328
	private int int_0;
}
