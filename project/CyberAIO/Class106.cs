using System;

// Token: 0x02000127 RID: 295
internal sealed class Class106 : Class104
{
	// Token: 0x060006AA RID: 1706 RVA: 0x00005CC7 File Offset: 0x00003EC7
	public Array method_4()
	{
		return this.array_0;
	}

	// Token: 0x060006AB RID: 1707 RVA: 0x00005CCF File Offset: 0x00003ECF
	public void method_5(Array array_1)
	{
		this.array_0 = array_1;
	}

	// Token: 0x060006AC RID: 1708 RVA: 0x00005CD8 File Offset: 0x00003ED8
	public long method_6()
	{
		return this.long_0;
	}

	// Token: 0x060006AD RID: 1709 RVA: 0x00005CE0 File Offset: 0x00003EE0
	public void method_7(long long_1)
	{
		this.long_0 = long_1;
	}

	// Token: 0x060006AE RID: 1710 RVA: 0x00005CE9 File Offset: 0x00003EE9
	public override object vmethod_5()
	{
		return this.array_0.GetValue(this.long_0);
	}

	// Token: 0x060006AF RID: 1711 RVA: 0x00005CFC File Offset: 0x00003EFC
	public override void vmethod_6(object object_0)
	{
		this.array_0.SetValue(object_0, this.long_0);
	}

	// Token: 0x060006B0 RID: 1712 RVA: 0x00005D10 File Offset: 0x00003F10
	public override int vmethod_2()
	{
		return 11;
	}

	// Token: 0x060006B1 RID: 1713 RVA: 0x00038DDC File Offset: 0x00036FDC
	public override Class80 vmethod_3(Class80 class80_0)
	{
		base.method_1(class80_0.method_0());
		int num = class80_0.vmethod_2();
		if (num == 11)
		{
			Class106 @class = (Class106)class80_0;
			this.method_5(@class.method_4());
			this.method_7(@class.method_6());
			base.method_3(@class.method_2());
			return this;
		}
		throw new ArgumentOutOfRangeException();
	}

	// Token: 0x060006B2 RID: 1714 RVA: 0x00005D14 File Offset: 0x00003F14
	public override Class80 vmethod_4()
	{
		Class106 @class = new Class106();
		@class.method_5(this.array_0);
		@class.method_7(this.long_0);
		@class.method_3(base.method_2());
		@class.method_1(base.method_0());
		return @class;
	}

	// Token: 0x060006B3 RID: 1715 RVA: 0x00038E38 File Offset: 0x00037038
	public override bool vmethod_7(Class104 class104_0)
	{
		Class106 @class = (Class106)class104_0;
		return this.method_6() == @class.method_6() && this.method_4() == @class.method_4();
	}

	// Token: 0x04000523 RID: 1315
	private Array array_0;

	// Token: 0x04000524 RID: 1316
	private long long_0;
}
