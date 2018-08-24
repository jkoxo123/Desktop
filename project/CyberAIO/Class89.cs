using System;

// Token: 0x020000B4 RID: 180
internal sealed class Class89 : Class80
{
	// Token: 0x06000468 RID: 1128 RVA: 0x00004B37 File Offset: 0x00002D37
	public ulong method_2()
	{
		return this.ulong_0;
	}

	// Token: 0x06000469 RID: 1129 RVA: 0x00004B3F File Offset: 0x00002D3F
	public void method_3(ulong ulong_1)
	{
		this.ulong_0 = ulong_1;
	}

	// Token: 0x0600046A RID: 1130 RVA: 0x00004B48 File Offset: 0x00002D48
	public override object vmethod_0()
	{
		return this.method_2();
	}

	// Token: 0x0600046B RID: 1131 RVA: 0x00021818 File Offset: 0x0001FA18
	public override void vmethod_1(object object_0)
	{
		if (object_0 is short)
		{
			this.method_3((ulong)((long)((short)object_0)));
			return;
		}
		if (object_0 is int)
		{
			this.method_3((ulong)((long)((int)object_0)));
			return;
		}
		if (object_0 is long)
		{
			this.method_3((ulong)((long)object_0));
			return;
		}
		if (object_0 is float)
		{
			this.method_3((ulong)((float)object_0));
			return;
		}
		if (object_0 is double)
		{
			this.method_3((ulong)((double)object_0));
			return;
		}
		this.method_3(Convert.ToUInt64(object_0));
	}

	// Token: 0x0600046C RID: 1132 RVA: 0x00004B55 File Offset: 0x00002D55
	public override Class80 vmethod_4()
	{
		Class89 @class = new Class89();
		@class.method_3(this.ulong_0);
		@class.method_1(base.method_0());
		return @class;
	}

	// Token: 0x0600046D RID: 1133 RVA: 0x00004B74 File Offset: 0x00002D74
	public override int vmethod_2()
	{
		return 20;
	}

	// Token: 0x0600046E RID: 1134 RVA: 0x000218A0 File Offset: 0x0001FAA0
	public override Class80 vmethod_3(Class80 class80_0)
	{
		base.method_1(class80_0.method_0());
		switch (class80_0.vmethod_2())
		{
		case 0:
			this.method_3((ulong)Convert.ToByte(((Class97)class80_0).method_2()));
			return this;
		case 2:
			this.method_3((ulong)((Class88)class80_0).method_2());
			return this;
		case 6:
			this.method_3((ulong)((Class83)class80_0).method_2());
			return this;
		case 7:
			this.method_3((ulong)((long)((Class85)class80_0).method_2()));
			return this;
		case 8:
			this.method_3(Convert.ToUInt64(((Class84)class80_0).method_2()));
			return this;
		case 10:
			this.method_3((ulong)((Class92)class80_0).method_2());
			return this;
		case 14:
			this.method_3((ulong)((long)((Class98)class80_0).method_2()));
			return this;
		case 15:
			this.method_3((ulong)((Class91)class80_0).method_2());
			return this;
		case 16:
			this.method_3((ulong)((Class82)class80_0).method_2());
			return this;
		case 18:
			this.method_3((ulong)((long)((Class94)class80_0).method_2()));
			return this;
		case 19:
			this.method_3((ulong)((Class86)class80_0).method_2());
			return this;
		case 20:
			this.method_3(((Class89)class80_0).method_2());
			return this;
		case 21:
			this.method_3(Convert.ToUInt64(((Class90)class80_0).method_2()));
			return this;
		case 23:
			this.method_3((ulong)((long)((Class99)class80_0).method_2()));
			return this;
		case 24:
			this.method_3((ulong)((Class87)class80_0).method_2());
			return this;
		}
		throw new ArgumentOutOfRangeException();
	}

	// Token: 0x040001FF RID: 511
	private ulong ulong_0;
}
