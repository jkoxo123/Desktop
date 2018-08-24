using System;

// Token: 0x02000164 RID: 356
internal sealed class Class98 : Class80
{
	// Token: 0x060007C0 RID: 1984 RVA: 0x000065CE File Offset: 0x000047CE
	public int method_2()
	{
		return this.int_0;
	}

	// Token: 0x060007C1 RID: 1985 RVA: 0x000065D6 File Offset: 0x000047D6
	public void method_3(int int_1)
	{
		this.int_0 = int_1;
	}

	// Token: 0x060007C2 RID: 1986 RVA: 0x000065DF File Offset: 0x000047DF
	public override object vmethod_0()
	{
		return this.method_2();
	}

	// Token: 0x060007C3 RID: 1987 RVA: 0x00045B44 File Offset: 0x00043D44
	public override void vmethod_1(object object_0)
	{
		if (object_0 is long)
		{
			this.method_3((int)((long)object_0));
			return;
		}
		if (object_0 is ushort)
		{
			this.method_3((int)((ushort)object_0));
			return;
		}
		if (object_0 is uint)
		{
			this.method_3((int)((uint)object_0));
			return;
		}
		if (object_0 is ulong)
		{
			this.method_3((int)((ulong)object_0));
			return;
		}
		if (object_0 is float)
		{
			this.method_3((int)((float)object_0));
			return;
		}
		if (object_0 is double)
		{
			this.method_3((int)((double)object_0));
			return;
		}
		this.method_3(Convert.ToInt32(object_0));
	}

	// Token: 0x060007C4 RID: 1988 RVA: 0x000065EC File Offset: 0x000047EC
	public override Class80 vmethod_4()
	{
		Class98 @class = new Class98();
		@class.method_3(this.int_0);
		@class.method_1(base.method_0());
		return @class;
	}

	// Token: 0x060007C5 RID: 1989 RVA: 0x0000660B File Offset: 0x0000480B
	public override int vmethod_2()
	{
		return 14;
	}

	// Token: 0x060007C6 RID: 1990 RVA: 0x00045BE0 File Offset: 0x00043DE0
	public override Class80 vmethod_3(Class80 class80_0)
	{
		base.method_1(class80_0.method_0());
		switch (class80_0.vmethod_2())
		{
		case 0:
			this.method_3((int)Convert.ToByte(((Class97)class80_0).method_2()));
			return this;
		case 2:
			this.method_3((int)((Class88)class80_0).method_2());
			return this;
		case 6:
			this.method_3((int)((uint)((Class83)class80_0).method_2()));
			return this;
		case 7:
			this.method_3((int)((Class85)class80_0).method_2());
			return this;
		case 8:
			this.method_3(Convert.ToInt32(((Class84)class80_0).method_2()));
			return this;
		case 10:
			this.method_3((int)((Class92)class80_0).method_2());
			return this;
		case 14:
			this.method_3(((Class98)class80_0).method_2());
			return this;
		case 15:
			this.method_3((int)((Class91)class80_0).method_2());
			return this;
		case 16:
			this.method_3(Convert.ToInt32(((Class82)class80_0).method_2()));
			return this;
		case 18:
			this.method_3((int)((Class94)class80_0).method_2());
			return this;
		case 19:
			this.method_3((int)((Class86)class80_0).method_2());
			return this;
		case 20:
			this.method_3((int)((Class89)class80_0).method_2());
			return this;
		case 21:
			this.method_3(Convert.ToInt32(((Class90)class80_0).method_2()));
			return this;
		case 23:
			this.method_3((int)((Class99)class80_0).method_2());
			return this;
		case 24:
			this.method_3((int)((Class87)class80_0).method_2());
			return this;
		}
		throw new ArgumentOutOfRangeException();
	}

	// Token: 0x04000694 RID: 1684
	private int int_0;
}
