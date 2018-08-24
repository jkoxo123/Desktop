using System;

// Token: 0x020000AC RID: 172
internal sealed class Class88 : Class80
{
	// Token: 0x0600043A RID: 1082 RVA: 0x0000494F File Offset: 0x00002B4F
	public byte method_2()
	{
		return this.byte_0;
	}

	// Token: 0x0600043B RID: 1083 RVA: 0x00004957 File Offset: 0x00002B57
	public void method_3(byte byte_1)
	{
		this.byte_0 = byte_1;
	}

	// Token: 0x0600043C RID: 1084 RVA: 0x00004960 File Offset: 0x00002B60
	public override Class80 vmethod_4()
	{
		Class88 @class = new Class88();
		@class.method_3(this.byte_0);
		@class.method_1(base.method_0());
		return @class;
	}

	// Token: 0x0600043D RID: 1085 RVA: 0x0000497F File Offset: 0x00002B7F
	public override object vmethod_0()
	{
		return this.method_2();
	}

	// Token: 0x0600043E RID: 1086 RVA: 0x00020F40 File Offset: 0x0001F140
	public override void vmethod_1(object object_0)
	{
		if (object_0 is short)
		{
			this.method_3((byte)((short)object_0));
			return;
		}
		if (object_0 is int)
		{
			this.method_3((byte)((int)object_0));
			return;
		}
		if (object_0 is long)
		{
			this.method_3((byte)((long)object_0));
			return;
		}
		if (object_0 is ushort)
		{
			this.method_3((byte)((ushort)object_0));
			return;
		}
		if (object_0 is uint)
		{
			this.method_3((byte)((uint)object_0));
			return;
		}
		if (object_0 is ulong)
		{
			this.method_3((byte)((ulong)object_0));
			return;
		}
		if (object_0 is float)
		{
			this.method_3((byte)((float)object_0));
			return;
		}
		if (object_0 is double)
		{
			this.method_3((byte)((double)object_0));
			return;
		}
		this.method_3(Convert.ToByte(object_0));
	}

	// Token: 0x0600043F RID: 1087 RVA: 0x0000498C File Offset: 0x00002B8C
	public override int vmethod_2()
	{
		return 2;
	}

	// Token: 0x06000440 RID: 1088 RVA: 0x0002100C File Offset: 0x0001F20C
	public override Class80 vmethod_3(Class80 class80_0)
	{
		base.method_1(class80_0.method_0());
		switch (class80_0.vmethod_2())
		{
		case 0:
			this.method_3(Convert.ToByte(((Class97)class80_0).method_2()));
			return this;
		case 2:
			this.method_3(((Class88)class80_0).method_2());
			return this;
		case 6:
			this.method_3((byte)((uint)((Class83)class80_0).method_2()));
			return this;
		case 7:
			this.method_3((byte)((Class85)class80_0).method_2());
			return this;
		case 8:
			this.method_3(Convert.ToByte(((Class84)class80_0).method_2()));
			return this;
		case 10:
			this.method_3((byte)((Class92)class80_0).method_2());
			return this;
		case 14:
			this.method_3((byte)((Class98)class80_0).method_2());
			return this;
		case 15:
			this.method_3((byte)((Class91)class80_0).method_2());
			return this;
		case 16:
			this.method_3((byte)((Class82)class80_0).method_2());
			return this;
		case 18:
			this.method_3((byte)((Class94)class80_0).method_2());
			return this;
		case 19:
			this.method_3((byte)((Class86)class80_0).method_2());
			return this;
		case 20:
			this.method_3((byte)((Class89)class80_0).method_2());
			return this;
		case 21:
			this.method_3(Convert.ToByte(((Class90)class80_0).method_2()));
			return this;
		case 23:
			this.method_3((byte)((int)((Class99)class80_0).method_2()));
			return this;
		case 24:
			this.method_3((byte)((Class87)class80_0).method_2());
			return this;
		}
		throw new ArgumentOutOfRangeException();
	}

	// Token: 0x040001ED RID: 493
	private byte byte_0;
}
