using System;

// Token: 0x02000120 RID: 288
internal sealed class Class94 : Class80
{
	// Token: 0x06000678 RID: 1656 RVA: 0x00005B53 File Offset: 0x00003D53
	public short method_2()
	{
		return this.short_0;
	}

	// Token: 0x06000679 RID: 1657 RVA: 0x00005B5B File Offset: 0x00003D5B
	public void method_3(short short_1)
	{
		this.short_0 = short_1;
	}

	// Token: 0x0600067A RID: 1658 RVA: 0x00005B64 File Offset: 0x00003D64
	public override object vmethod_0()
	{
		return this.method_2();
	}

	// Token: 0x0600067B RID: 1659 RVA: 0x000389A0 File Offset: 0x00036BA0
	public override void vmethod_1(object object_0)
	{
		if (object_0 is int)
		{
			this.method_3((short)((int)object_0));
			return;
		}
		if (object_0 is long)
		{
			this.method_3((short)((long)object_0));
			return;
		}
		if (object_0 is ushort)
		{
			this.method_3((short)((ushort)object_0));
			return;
		}
		if (object_0 is uint)
		{
			this.method_3((short)((uint)object_0));
			return;
		}
		if (object_0 is ulong)
		{
			this.method_3((short)((ulong)object_0));
			return;
		}
		if (object_0 is float)
		{
			this.method_3((short)((float)object_0));
			return;
		}
		if (object_0 is double)
		{
			this.method_3((short)((double)object_0));
			return;
		}
		this.method_3(Convert.ToInt16(object_0));
	}

	// Token: 0x0600067C RID: 1660 RVA: 0x00005B71 File Offset: 0x00003D71
	public override Class80 vmethod_4()
	{
		Class94 @class = new Class94();
		@class.method_3(this.short_0);
		@class.method_1(base.method_0());
		return @class;
	}

	// Token: 0x0600067D RID: 1661 RVA: 0x00005B90 File Offset: 0x00003D90
	public override int vmethod_2()
	{
		return 18;
	}

	// Token: 0x0600067E RID: 1662 RVA: 0x00038A54 File Offset: 0x00036C54
	public override Class80 vmethod_3(Class80 class80_0)
	{
		base.method_1(class80_0.method_0());
		switch (class80_0.vmethod_2())
		{
		case 0:
			this.method_3((short)Convert.ToByte(((Class97)class80_0).method_2()));
			return this;
		case 2:
			this.method_3((short)((Class88)class80_0).method_2());
			return this;
		case 7:
			this.method_3((short)((Class85)class80_0).method_2());
			return this;
		case 8:
			this.method_3(Convert.ToInt16(((Class84)class80_0).method_2()));
			return this;
		case 10:
			this.method_3((short)((Class92)class80_0).method_2());
			return this;
		case 14:
			this.method_3((short)((Class98)class80_0).method_2());
			return this;
		case 15:
			this.method_3((short)((Class91)class80_0).method_2());
			return this;
		case 16:
			this.method_3((short)((Class82)class80_0).method_2());
			return this;
		case 18:
			this.method_3(((Class94)class80_0).method_2());
			return this;
		case 19:
			this.method_3((short)((Class86)class80_0).method_2());
			return this;
		case 20:
			this.method_3((short)((Class89)class80_0).method_2());
			return this;
		case 21:
			this.method_3(Convert.ToInt16(((Class90)class80_0).method_2()));
			return this;
		case 23:
			this.method_3((short)((int)((Class99)class80_0).method_2()));
			return this;
		case 24:
			this.method_3((short)((Class87)class80_0).method_2());
			return this;
		}
		throw new ArgumentOutOfRangeException();
	}

	// Token: 0x04000513 RID: 1299
	private short short_0;
}
