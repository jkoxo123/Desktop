using System;

// Token: 0x020000BB RID: 187
internal sealed class Class105 : Class104
{
	// Token: 0x06000491 RID: 1169 RVA: 0x00004D23 File Offset: 0x00002F23
	public Array method_4()
	{
		return this.array_0;
	}

	// Token: 0x06000492 RID: 1170 RVA: 0x00004D2B File Offset: 0x00002F2B
	public void method_5(Array array_1)
	{
		this.array_0 = array_1;
	}

	// Token: 0x06000493 RID: 1171 RVA: 0x00004D34 File Offset: 0x00002F34
	public int[] method_6()
	{
		return this.int_0;
	}

	// Token: 0x06000494 RID: 1172 RVA: 0x00004D3C File Offset: 0x00002F3C
	public void method_7(int[] int_1)
	{
		this.int_0 = int_1;
	}

	// Token: 0x06000495 RID: 1173 RVA: 0x00004D45 File Offset: 0x00002F45
	public override object vmethod_5()
	{
		return this.method_4().GetValue(this.method_6());
	}

	// Token: 0x06000496 RID: 1174 RVA: 0x00004D58 File Offset: 0x00002F58
	public override void vmethod_6(object object_0)
	{
		this.method_4().SetValue(object_0, this.method_6());
	}

	// Token: 0x06000497 RID: 1175 RVA: 0x00004D6C File Offset: 0x00002F6C
	public override Class80 vmethod_4()
	{
		Class105 @class = new Class105();
		@class.method_5(this.method_4());
		@class.method_7(this.method_6());
		@class.method_3(base.method_2());
		@class.method_1(base.method_0());
		return @class;
	}

	// Token: 0x06000498 RID: 1176 RVA: 0x0000399D File Offset: 0x00001B9D
	public override int vmethod_2()
	{
		return 3;
	}

	// Token: 0x06000499 RID: 1177 RVA: 0x00021ACC File Offset: 0x0001FCCC
	public override Class80 vmethod_3(Class80 class80_0)
	{
		base.method_1(class80_0.method_0());
		int num = class80_0.vmethod_2();
		if (num == 3)
		{
			Class105 @class = (Class105)class80_0;
			this.method_5(@class.method_4());
			this.method_7(@class.method_6());
			base.method_3(@class.method_2());
			return this;
		}
		throw new ArgumentOutOfRangeException();
	}

	// Token: 0x0600049A RID: 1178 RVA: 0x00021B24 File Offset: 0x0001FD24
	public override bool vmethod_7(Class104 class104_0)
	{
		Class105 @class = (Class105)class104_0;
		return this.method_4() == @class.method_4() && Class30.smethod_0(this.method_6(), @class.method_6());
	}

	// Token: 0x04000210 RID: 528
	private Array array_0;

	// Token: 0x04000211 RID: 529
	private int[] int_0;
}
