using System;

// Token: 0x02000011 RID: 17
internal sealed class Class83 : Class80
{
	// Token: 0x0600004C RID: 76 RVA: 0x00002E01 File Offset: 0x00001001
	public UIntPtr method_2()
	{
		return this.uintptr_0;
	}

	// Token: 0x0600004D RID: 77 RVA: 0x00002E09 File Offset: 0x00001009
	public void method_3(UIntPtr uintptr_1)
	{
		this.uintptr_0 = uintptr_1;
	}

	// Token: 0x0600004E RID: 78 RVA: 0x00002E12 File Offset: 0x00001012
	public override Class80 vmethod_4()
	{
		Class83 @class = new Class83();
		@class.method_3(this.uintptr_0);
		@class.method_1(base.method_0());
		return @class;
	}

	// Token: 0x0600004F RID: 79 RVA: 0x00002E31 File Offset: 0x00001031
	public override object vmethod_0()
	{
		return this.method_2();
	}

	// Token: 0x06000050 RID: 80 RVA: 0x00002E3E File Offset: 0x0000103E
	public override void vmethod_1(object object_0)
	{
		this.method_3((UIntPtr)object_0);
	}

	// Token: 0x06000051 RID: 81 RVA: 0x00002E4C File Offset: 0x0000104C
	public override int vmethod_2()
	{
		return 6;
	}

	// Token: 0x06000052 RID: 82 RVA: 0x00008140 File Offset: 0x00006340
	public override Class80 vmethod_3(Class80 class80_0)
	{
		base.method_1(class80_0.method_0());
		int num = class80_0.vmethod_2();
		if (num != 2)
		{
			switch (num)
			{
			case 6:
				this.method_3(((Class83)class80_0).method_2());
				return this;
			case 8:
				this.method_3(new UIntPtr(Convert.ToUInt64(((Class84)class80_0).method_2())));
				return this;
			case 10:
				this.method_3((UIntPtr)((Class92)class80_0).method_2());
				return this;
			case 14:
				this.method_3((UIntPtr)((ulong)((long)((Class98)class80_0).method_2())));
				return this;
			case 15:
				this.method_3((UIntPtr)((ulong)((Class91)class80_0).method_2()));
				return this;
			case 16:
				this.method_3((UIntPtr)((ulong)((Class82)class80_0).method_2()));
				return this;
			case 19:
				this.method_3((UIntPtr)((ulong)((Class86)class80_0).method_2()));
				return this;
			case 20:
				this.method_3((UIntPtr)((Class89)class80_0).method_2());
				return this;
			case 21:
				this.method_3((UIntPtr)((Class90)class80_0).method_2());
				return this;
			case 24:
				this.method_3((UIntPtr)((uint)((Class87)class80_0).method_2()));
				return this;
			}
			throw new ArgumentOutOfRangeException();
		}
		this.method_3((UIntPtr)((uint)((Class88)class80_0).method_2()));
		return this;
	}

	// Token: 0x04000023 RID: 35
	private UIntPtr uintptr_0;
}
