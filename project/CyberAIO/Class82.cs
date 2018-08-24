using System;

// Token: 0x02000009 RID: 9
internal sealed class Class82 : Class80
{
	// Token: 0x0600002C RID: 44 RVA: 0x00002D2A File Offset: 0x00000F2A
	public long method_2()
	{
		return this.long_0;
	}

	// Token: 0x0600002D RID: 45 RVA: 0x00002D32 File Offset: 0x00000F32
	public void method_3(long long_1)
	{
		this.long_0 = long_1;
	}

	// Token: 0x0600002E RID: 46 RVA: 0x00002D3B File Offset: 0x00000F3B
	public override object vmethod_0()
	{
		return this.method_2();
	}

	// Token: 0x0600002F RID: 47 RVA: 0x0000787C File Offset: 0x00005A7C
	public override void vmethod_1(object object_0)
	{
		if (object_0 is ulong)
		{
			this.method_3((long)((ulong)object_0));
			return;
		}
		if (object_0 is float)
		{
			this.method_3((long)((float)object_0));
			return;
		}
		if (object_0 is double)
		{
			this.method_3((long)((double)object_0));
			return;
		}
		this.method_3(Convert.ToInt64(object_0));
	}

	// Token: 0x06000030 RID: 48 RVA: 0x00002D48 File Offset: 0x00000F48
	public override Class80 vmethod_4()
	{
		Class82 @class = new Class82();
		@class.method_3(this.long_0);
		@class.method_1(base.method_0());
		return @class;
	}

	// Token: 0x06000031 RID: 49 RVA: 0x00002D67 File Offset: 0x00000F67
	public override int vmethod_2()
	{
		return 16;
	}

	// Token: 0x06000032 RID: 50 RVA: 0x000078D8 File Offset: 0x00005AD8
	public override Class80 vmethod_3(Class80 class80_0)
	{
		base.method_1(class80_0.method_0());
		switch (class80_0.vmethod_2())
		{
		case 0:
			this.method_3((long)((ulong)Convert.ToByte(((Class97)class80_0).method_2())));
			return this;
		case 2:
			this.method_3((long)((ulong)((Class88)class80_0).method_2()));
			return this;
		case 6:
			this.method_3((long)((ulong)((Class83)class80_0).method_2()));
			return this;
		case 7:
			this.method_3((long)((Class85)class80_0).method_2());
			return this;
		case 8:
			this.method_3(Convert.ToInt64(((Class84)class80_0).method_2()));
			return this;
		case 10:
			this.method_3((long)((ulong)((Class92)class80_0).method_2()));
			return this;
		case 14:
			this.method_3((long)((Class98)class80_0).method_2());
			return this;
		case 15:
			this.method_3((long)((Class91)class80_0).method_2());
			return this;
		case 16:
			this.method_3(((Class82)class80_0).method_2());
			return this;
		case 18:
			this.method_3((long)((Class94)class80_0).method_2());
			return this;
		case 19:
			this.method_3((long)((Class86)class80_0).method_2());
			return this;
		case 20:
			this.method_3((long)((Class89)class80_0).method_2());
			return this;
		case 21:
			this.method_3(Convert.ToInt64(((Class90)class80_0).method_2()));
			return this;
		case 23:
			this.method_3((long)((Class99)class80_0).method_2());
			return this;
		case 24:
			this.method_3((long)((ulong)((Class87)class80_0).method_2()));
			return this;
		}
		throw new ArgumentOutOfRangeException();
	}

	// Token: 0x04000012 RID: 18
	private long long_0;
}
