using System;

// Token: 0x02000128 RID: 296
internal sealed class Class96 : Class80
{
	// Token: 0x060006B5 RID: 1717 RVA: 0x00005D4B File Offset: 0x00003F4B
	public string method_2()
	{
		return this.string_0;
	}

	// Token: 0x060006B6 RID: 1718 RVA: 0x00005D53 File Offset: 0x00003F53
	public void method_3(string string_1)
	{
		this.string_0 = string_1;
	}

	// Token: 0x060006B7 RID: 1719 RVA: 0x00005D5C File Offset: 0x00003F5C
	public override object vmethod_0()
	{
		return this.method_2();
	}

	// Token: 0x060006B8 RID: 1720 RVA: 0x00005D64 File Offset: 0x00003F64
	public override void vmethod_1(object object_0)
	{
		this.method_3((string)object_0);
	}

	// Token: 0x060006B9 RID: 1721 RVA: 0x00005D72 File Offset: 0x00003F72
	public override int vmethod_2()
	{
		return 22;
	}

	// Token: 0x060006BA RID: 1722 RVA: 0x00038E6C File Offset: 0x0003706C
	public override Class80 vmethod_3(Class80 class80_0)
	{
		base.method_1(class80_0.method_0());
		int num = class80_0.vmethod_2();
		if (num != 21)
		{
			if (num != 22)
			{
				throw new ArgumentOutOfRangeException();
			}
			this.method_3(((Class96)class80_0).method_2());
		}
		else
		{
			this.method_3((string)((Class90)class80_0).method_2());
		}
		return this;
	}

	// Token: 0x060006BB RID: 1723 RVA: 0x00005D76 File Offset: 0x00003F76
	public override Class80 vmethod_4()
	{
		Class96 @class = new Class96();
		@class.method_3(this.string_0);
		@class.method_1(base.method_0());
		return @class;
	}

	// Token: 0x04000525 RID: 1317
	private string string_0;
}
