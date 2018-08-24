using System;

// Token: 0x0200005B RID: 91
internal sealed class Class87 : Class80
{
	// Token: 0x060001C7 RID: 455 RVA: 0x00003B35 File Offset: 0x00001D35
	public ushort method_2()
	{
		return this.ushort_0;
	}

	// Token: 0x060001C8 RID: 456 RVA: 0x00003B3D File Offset: 0x00001D3D
	public void method_3(ushort ushort_1)
	{
		this.ushort_0 = ushort_1;
	}

	// Token: 0x060001C9 RID: 457 RVA: 0x00003B46 File Offset: 0x00001D46
	public override object vmethod_0()
	{
		return this.method_2();
	}

	// Token: 0x060001CA RID: 458 RVA: 0x0001118C File Offset: 0x0000F38C
	public override void vmethod_1(object object_0)
	{
		if (object_0 is short)
		{
			this.method_3((ushort)((short)object_0));
			return;
		}
		if (object_0 is int)
		{
			this.method_3((ushort)((int)object_0));
			return;
		}
		if (object_0 is long)
		{
			this.method_3((ushort)((long)object_0));
			return;
		}
		if (object_0 is uint)
		{
			this.method_3((ushort)((uint)object_0));
			return;
		}
		if (object_0 is ulong)
		{
			this.method_3((ushort)((ulong)object_0));
			return;
		}
		if (object_0 is float)
		{
			this.method_3((ushort)((float)object_0));
			return;
		}
		if (object_0 is double)
		{
			this.method_3((ushort)((double)object_0));
			return;
		}
		this.method_3(Convert.ToUInt16(object_0));
	}

	// Token: 0x060001CB RID: 459 RVA: 0x00003B53 File Offset: 0x00001D53
	public override Class80 vmethod_4()
	{
		Class87 @class = new Class87();
		@class.method_3(this.ushort_0);
		@class.method_1(base.method_0());
		return @class;
	}

	// Token: 0x060001CC RID: 460 RVA: 0x00003B72 File Offset: 0x00001D72
	public override int vmethod_2()
	{
		return 24;
	}

	// Token: 0x060001CD RID: 461 RVA: 0x00011240 File Offset: 0x0000F440
	public override Class80 vmethod_3(Class80 class80_0)
	{
		base.method_1(class80_0.method_0());
		switch (class80_0.vmethod_2())
		{
		case 0:
			this.method_3((ushort)Convert.ToByte(((Class97)class80_0).method_2()));
			return this;
		case 2:
			this.method_3((ushort)((Class88)class80_0).method_2());
			return this;
		case 6:
			this.method_3((ushort)((uint)((Class83)class80_0).method_2()));
			return this;
		case 7:
			this.method_3((ushort)((Class85)class80_0).method_2());
			return this;
		case 8:
			this.method_3(Convert.ToUInt16(((Class84)class80_0).method_2()));
			return this;
		case 10:
			this.method_3((ushort)((Class92)class80_0).method_2());
			return this;
		case 14:
			this.method_3((ushort)((Class98)class80_0).method_2());
			return this;
		case 15:
			this.method_3((ushort)((Class91)class80_0).method_2());
			return this;
		case 16:
			this.method_3((ushort)((Class82)class80_0).method_2());
			return this;
		case 18:
			this.method_3((ushort)((Class94)class80_0).method_2());
			return this;
		case 19:
			this.method_3((ushort)((Class86)class80_0).method_2());
			return this;
		case 20:
			this.method_3((ushort)((Class89)class80_0).method_2());
			return this;
		case 21:
			this.method_3(Convert.ToUInt16(((Class90)class80_0).method_2()));
			return this;
		case 23:
			this.method_3((ushort)((int)((Class99)class80_0).method_2()));
			return this;
		case 24:
			this.method_3(((Class87)class80_0).method_2());
			return this;
		}
		throw new ArgumentOutOfRangeException();
	}

	// Token: 0x0400011D RID: 285
	private ushort ushort_0;
}
