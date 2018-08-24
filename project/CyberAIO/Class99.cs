using System;

// Token: 0x02000169 RID: 361
internal sealed class Class99 : Class80
{
	// Token: 0x060007D2 RID: 2002 RVA: 0x00006691 File Offset: 0x00004891
	public IntPtr method_2()
	{
		return this.intptr_0;
	}

	// Token: 0x060007D3 RID: 2003 RVA: 0x00006699 File Offset: 0x00004899
	public void method_3(IntPtr intptr_1)
	{
		this.intptr_0 = intptr_1;
	}

	// Token: 0x060007D4 RID: 2004 RVA: 0x000066A2 File Offset: 0x000048A2
	public override Class80 vmethod_4()
	{
		Class99 @class = new Class99();
		@class.method_3(this.intptr_0);
		@class.method_1(base.method_0());
		return @class;
	}

	// Token: 0x060007D5 RID: 2005 RVA: 0x000066C1 File Offset: 0x000048C1
	public override object vmethod_0()
	{
		return this.method_2();
	}

	// Token: 0x060007D6 RID: 2006 RVA: 0x000066CE File Offset: 0x000048CE
	public override void vmethod_1(object object_0)
	{
		this.method_3((IntPtr)object_0);
	}

	// Token: 0x060007D7 RID: 2007 RVA: 0x000066DC File Offset: 0x000048DC
	public override int vmethod_2()
	{
		return 23;
	}

	// Token: 0x060007D8 RID: 2008 RVA: 0x00046258 File Offset: 0x00044458
	public override Class80 vmethod_3(Class80 class80_0)
	{
		base.method_1(class80_0.method_0());
		switch (class80_0.vmethod_2())
		{
		case 2:
			this.method_3((IntPtr)((int)((Class88)class80_0).method_2()));
			return this;
		case 4:
		{
			Class95 @class = (Class95)class80_0;
			this.method_3(@class.method_4());
			return this;
		}
		case 7:
			this.method_3((IntPtr)((int)((Class85)class80_0).method_2()));
			return this;
		case 8:
			this.method_3(new IntPtr(Convert.ToInt64(((Class84)class80_0).method_2())));
			return this;
		case 10:
			this.method_3((IntPtr)((long)((ulong)((Class92)class80_0).method_2())));
			return this;
		case 14:
			this.method_3((IntPtr)((Class98)class80_0).method_2());
			return this;
		case 15:
			this.method_3((IntPtr)((long)((Class91)class80_0).method_2()));
			return this;
		case 16:
			this.method_3((IntPtr)((Class82)class80_0).method_2());
			return this;
		case 18:
			this.method_3((IntPtr)((int)((Class94)class80_0).method_2()));
			return this;
		case 19:
			this.method_3((IntPtr)((long)((Class86)class80_0).method_2()));
			return this;
		case 20:
			this.method_3((IntPtr)((long)((Class89)class80_0).method_2()));
			return this;
		case 21:
			this.method_3((IntPtr)((Class90)class80_0).method_2());
			return this;
		case 23:
			this.method_3(((Class99)class80_0).method_2());
			return this;
		case 24:
			this.method_3((IntPtr)((int)((Class87)class80_0).method_2()));
			return this;
		}
		throw new ArgumentOutOfRangeException();
	}

	// Token: 0x040006A0 RID: 1696
	private IntPtr intptr_0;
}
