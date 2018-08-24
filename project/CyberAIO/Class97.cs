using System;

// Token: 0x02000163 RID: 355
internal sealed class Class97 : Class80
{
	// Token: 0x060007B8 RID: 1976 RVA: 0x00006583 File Offset: 0x00004783
	public bool method_2()
	{
		return this.bool_0;
	}

	// Token: 0x060007B9 RID: 1977 RVA: 0x0000658B File Offset: 0x0000478B
	public void method_3(bool bool_1)
	{
		this.bool_0 = bool_1;
	}

	// Token: 0x060007BA RID: 1978 RVA: 0x00006594 File Offset: 0x00004794
	public override object vmethod_0()
	{
		return this.method_2();
	}

	// Token: 0x060007BB RID: 1979 RVA: 0x000065A1 File Offset: 0x000047A1
	public override void vmethod_1(object object_0)
	{
		this.method_3(Convert.ToBoolean(object_0));
	}

	// Token: 0x060007BC RID: 1980 RVA: 0x000030C0 File Offset: 0x000012C0
	public override int vmethod_2()
	{
		return 0;
	}

	// Token: 0x060007BD RID: 1981 RVA: 0x00045958 File Offset: 0x00043B58
	public override Class80 vmethod_3(Class80 class80_0)
	{
		base.method_1(class80_0.method_0());
		switch (class80_0.vmethod_2())
		{
		case 0:
			this.method_3(((Class97)class80_0).method_2());
			return this;
		case 2:
			this.method_3(Convert.ToBoolean(((Class88)class80_0).method_2()));
			return this;
		case 6:
			this.method_3(Convert.ToBoolean(((Class83)class80_0).method_2()));
			return this;
		case 7:
			this.method_3(Convert.ToBoolean(((Class85)class80_0).method_2()));
			return this;
		case 8:
			this.method_3(Convert.ToBoolean(((Class84)class80_0).method_2()));
			return this;
		case 10:
			this.method_3(Convert.ToBoolean(((Class92)class80_0).method_2()));
			return this;
		case 14:
			this.method_3(Convert.ToBoolean(((Class98)class80_0).method_2()));
			return this;
		case 16:
			this.method_3(Convert.ToBoolean(((Class82)class80_0).method_2()));
			return this;
		case 18:
			this.method_3(Convert.ToBoolean(((Class94)class80_0).method_2()));
			return this;
		case 20:
			this.method_3(Convert.ToBoolean(((Class89)class80_0).method_2()));
			return this;
		case 21:
			this.method_3(Convert.ToBoolean(((Class90)class80_0).method_2()));
			return this;
		case 23:
			this.method_3(Convert.ToBoolean(((Class99)class80_0).method_2()));
			return this;
		case 24:
			this.method_3(Convert.ToBoolean(((Class87)class80_0).method_2()));
			return this;
		}
		throw new ArgumentOutOfRangeException();
	}

	// Token: 0x060007BE RID: 1982 RVA: 0x000065AF File Offset: 0x000047AF
	public override Class80 vmethod_4()
	{
		Class97 @class = new Class97();
		@class.method_3(this.bool_0);
		@class.method_1(base.method_0());
		return @class;
	}

	// Token: 0x04000693 RID: 1683
	private bool bool_0;
}
