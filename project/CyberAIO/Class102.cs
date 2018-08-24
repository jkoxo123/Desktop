using System;

// Token: 0x02000041 RID: 65
internal sealed class Class102 : Class100
{
	// Token: 0x0600014E RID: 334 RVA: 0x000037AD File Offset: 0x000019AD
	public Class80 method_2()
	{
		return this.class80_0;
	}

	// Token: 0x0600014F RID: 335 RVA: 0x000037B5 File Offset: 0x000019B5
	public void method_3(Class80 class80_1)
	{
		this.class80_0 = class80_1;
	}

	// Token: 0x06000150 RID: 336 RVA: 0x000037BE File Offset: 0x000019BE
	public override int vmethod_2()
	{
		return 5;
	}

	// Token: 0x06000151 RID: 337 RVA: 0x0000F43C File Offset: 0x0000D63C
	public override Class80 vmethod_3(Class80 class80_1)
	{
		base.method_1(class80_1.method_0());
		int num = class80_1.vmethod_2();
		if (num == 5)
		{
			this.method_3(((Class102)class80_1).method_2());
			return this;
		}
		throw new ArgumentOutOfRangeException();
	}

	// Token: 0x06000152 RID: 338 RVA: 0x000037C1 File Offset: 0x000019C1
	public override Class80 vmethod_4()
	{
		Class102 @class = new Class102();
		@class.method_3(this.method_2());
		@class.method_1(base.method_0());
		return @class;
	}

	// Token: 0x040000E1 RID: 225
	private Class80 class80_0;
}
