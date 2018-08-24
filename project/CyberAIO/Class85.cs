using System;

// Token: 0x0200003B RID: 59
internal sealed class Class85 : Class80
{
	// Token: 0x06000123 RID: 291 RVA: 0x000035FD File Offset: 0x000017FD
	public sbyte method_2()
	{
		return this.sbyte_0;
	}

	// Token: 0x06000124 RID: 292 RVA: 0x00003605 File Offset: 0x00001805
	public void method_3(sbyte sbyte_1)
	{
		this.sbyte_0 = sbyte_1;
	}

	// Token: 0x06000125 RID: 293 RVA: 0x0000360E File Offset: 0x0000180E
	public override object vmethod_0()
	{
		return this.method_2();
	}

	// Token: 0x06000126 RID: 294 RVA: 0x0000E214 File Offset: 0x0000C414
	public override void vmethod_1(object object_0)
	{
		if (object_0 is byte)
		{
			this.method_3((sbyte)((byte)object_0));
			return;
		}
		if (object_0 is short)
		{
			this.method_3((sbyte)((short)object_0));
			return;
		}
		if (object_0 is int)
		{
			this.method_3((sbyte)((int)object_0));
			return;
		}
		if (object_0 is long)
		{
			this.method_3((sbyte)((long)object_0));
			return;
		}
		if (object_0 is ushort)
		{
			this.method_3((sbyte)((ushort)object_0));
			return;
		}
		if (object_0 is uint)
		{
			this.method_3((sbyte)((uint)object_0));
			return;
		}
		if (object_0 is ulong)
		{
			this.method_3((sbyte)((ulong)object_0));
			return;
		}
		if (object_0 is float)
		{
			this.method_3((sbyte)((float)object_0));
			return;
		}
		if (object_0 is double)
		{
			this.method_3((sbyte)((double)object_0));
			return;
		}
		this.method_3(Convert.ToSByte(object_0));
	}

	// Token: 0x06000127 RID: 295 RVA: 0x0000361B File Offset: 0x0000181B
	public override Class80 vmethod_4()
	{
		Class85 @class = new Class85();
		@class.method_3(this.sbyte_0);
		@class.method_1(base.method_0());
		return @class;
	}

	// Token: 0x06000128 RID: 296 RVA: 0x0000363A File Offset: 0x0000183A
	public override int vmethod_2()
	{
		return 7;
	}

	// Token: 0x06000129 RID: 297 RVA: 0x0000E2F4 File Offset: 0x0000C4F4
	public override Class80 vmethod_3(Class80 class80_0)
	{
		base.method_1(class80_0.method_0());
		switch (class80_0.vmethod_2())
		{
		case 0:
			this.method_3(Convert.ToSByte(((Class97)class80_0).method_2()));
			return this;
		case 2:
			this.method_3((sbyte)((Class88)class80_0).method_2());
			return this;
		case 7:
			this.method_3(((Class85)class80_0).method_2());
			return this;
		case 8:
			this.method_3(Convert.ToSByte(((Class84)class80_0).method_2()));
			return this;
		case 10:
			this.method_3((sbyte)((Class92)class80_0).method_2());
			return this;
		case 14:
			this.method_3((sbyte)((Class98)class80_0).method_2());
			return this;
		case 15:
			this.method_3((sbyte)((Class91)class80_0).method_2());
			return this;
		case 16:
			this.method_3((sbyte)((Class82)class80_0).method_2());
			return this;
		case 18:
			this.method_3((sbyte)((Class94)class80_0).method_2());
			return this;
		case 19:
			this.method_3((sbyte)((Class86)class80_0).method_2());
			return this;
		case 20:
			this.method_3((sbyte)((Class89)class80_0).method_2());
			return this;
		case 21:
			this.method_3(Convert.ToSByte(((Class90)class80_0).method_2()));
			return this;
		case 23:
			this.method_3((sbyte)((int)((Class99)class80_0).method_2()));
			return this;
		case 24:
			this.method_3((sbyte)((Class87)class80_0).method_2());
			return this;
		}
		throw new ArgumentOutOfRangeException();
	}

	// Token: 0x040000C9 RID: 201
	private sbyte sbyte_0;
}
