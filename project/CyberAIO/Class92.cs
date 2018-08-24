using System;

// Token: 0x020000EE RID: 238
internal sealed class Class92 : Class80
{
	// Token: 0x06000591 RID: 1425 RVA: 0x000054FF File Offset: 0x000036FF
	public uint method_2()
	{
		return this.uint_0;
	}

	// Token: 0x06000592 RID: 1426 RVA: 0x00005507 File Offset: 0x00003707
	public void method_3(uint uint_1)
	{
		this.uint_0 = uint_1;
	}

	// Token: 0x06000593 RID: 1427 RVA: 0x00005510 File Offset: 0x00003710
	public override object vmethod_0()
	{
		return this.method_2();
	}

	// Token: 0x06000594 RID: 1428 RVA: 0x000310EC File Offset: 0x0002F2EC
	public override void vmethod_1(object object_0)
	{
		if (object_0 is short)
		{
			this.method_3((uint)((short)object_0));
			return;
		}
		if (object_0 is int)
		{
			this.method_3((uint)((int)object_0));
			return;
		}
		if (object_0 is long)
		{
			this.method_3((uint)((long)object_0));
			return;
		}
		if (object_0 is ulong)
		{
			this.method_3((uint)((ulong)object_0));
			return;
		}
		if (object_0 is float)
		{
			this.method_3((uint)((float)object_0));
			return;
		}
		if (object_0 is double)
		{
			this.method_3((uint)((double)object_0));
			return;
		}
		this.method_3(Convert.ToUInt32(object_0));
	}

	// Token: 0x06000595 RID: 1429 RVA: 0x0000551D File Offset: 0x0000371D
	public override Class80 vmethod_4()
	{
		Class92 @class = new Class92();
		@class.method_3(this.uint_0);
		@class.method_1(base.method_0());
		return @class;
	}

	// Token: 0x06000596 RID: 1430 RVA: 0x0000553C File Offset: 0x0000373C
	public override int vmethod_2()
	{
		return 10;
	}

	// Token: 0x06000597 RID: 1431 RVA: 0x00031188 File Offset: 0x0002F388
	public override Class80 vmethod_3(Class80 class80_0)
	{
		base.method_1(class80_0.method_0());
		switch (class80_0.vmethod_2())
		{
		case 0:
			this.method_3((uint)Convert.ToByte(((Class97)class80_0).method_2()));
			return this;
		case 2:
			this.method_3((uint)((Class88)class80_0).method_2());
			return this;
		case 6:
			this.method_3((uint)((Class83)class80_0).method_2());
			return this;
		case 7:
			this.method_3((uint)((Class85)class80_0).method_2());
			return this;
		case 8:
			this.method_3(Convert.ToUInt32(((Class84)class80_0).method_2()));
			return this;
		case 10:
			this.method_3(((Class92)class80_0).method_2());
			return this;
		case 14:
			this.method_3((uint)((Class98)class80_0).method_2());
			return this;
		case 15:
			this.method_3((uint)((Class91)class80_0).method_2());
			return this;
		case 16:
			this.method_3((uint)((Class82)class80_0).method_2());
			return this;
		case 18:
			this.method_3((uint)((Class94)class80_0).method_2());
			return this;
		case 19:
			this.method_3((uint)((Class86)class80_0).method_2());
			return this;
		case 20:
			this.method_3((uint)((Class89)class80_0).method_2());
			return this;
		case 21:
			this.method_3(Convert.ToUInt32(((Class90)class80_0).method_2()));
			return this;
		case 23:
			this.method_3((uint)((int)((Class99)class80_0).method_2()));
			return this;
		case 24:
			this.method_3((uint)((Class87)class80_0).method_2());
			return this;
		}
		throw new ArgumentOutOfRangeException();
	}

	// Token: 0x04000426 RID: 1062
	private uint uint_0;
}
