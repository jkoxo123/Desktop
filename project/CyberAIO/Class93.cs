using System;

// Token: 0x0200011F RID: 287
internal sealed class Class93 : Class80
{
	// Token: 0x06000670 RID: 1648 RVA: 0x00005B09 File Offset: 0x00003D09
	public Array method_2()
	{
		return this.array_0;
	}

	// Token: 0x06000671 RID: 1649 RVA: 0x00005B11 File Offset: 0x00003D11
	public void method_3(Array array_1)
	{
		this.array_0 = array_1;
	}

	// Token: 0x06000672 RID: 1650 RVA: 0x00005B1A File Offset: 0x00003D1A
	public override object vmethod_0()
	{
		return this.method_2();
	}

	// Token: 0x06000673 RID: 1651 RVA: 0x00005B22 File Offset: 0x00003D22
	public override void vmethod_1(object object_0)
	{
		this.method_3((Array)object_0);
	}

	// Token: 0x06000674 RID: 1652 RVA: 0x00005B30 File Offset: 0x00003D30
	public override Class80 vmethod_4()
	{
		Class93 @class = new Class93();
		@class.method_3(this.array_0);
		@class.method_1(base.method_0());
		return @class;
	}

	// Token: 0x06000675 RID: 1653 RVA: 0x00005B4F File Offset: 0x00003D4F
	public override int vmethod_2()
	{
		return 9;
	}

	// Token: 0x06000676 RID: 1654 RVA: 0x00038944 File Offset: 0x00036B44
	public override Class80 vmethod_3(Class80 class80_0)
	{
		base.method_1(class80_0.method_0());
		int num = class80_0.vmethod_2();
		if (num != 9)
		{
			if (num != 21)
			{
				throw new ArgumentOutOfRangeException();
			}
			this.method_3((Array)((Class90)class80_0).method_2());
		}
		else
		{
			this.method_3(((Class93)class80_0).method_2());
		}
		return this;
	}

	// Token: 0x04000512 RID: 1298
	private Array array_0;
}
