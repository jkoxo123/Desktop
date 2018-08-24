using System;

// Token: 0x02000059 RID: 89
internal sealed class Class86 : Class80
{
	// Token: 0x060001BA RID: 442 RVA: 0x00003AE6 File Offset: 0x00001CE6
	public double method_2()
	{
		return this.double_0;
	}

	// Token: 0x060001BB RID: 443 RVA: 0x00003AEE File Offset: 0x00001CEE
	public void method_3(double double_1)
	{
		this.double_0 = double_1;
	}

	// Token: 0x060001BC RID: 444 RVA: 0x00003AF7 File Offset: 0x00001CF7
	public override object vmethod_0()
	{
		return this.method_2();
	}

	// Token: 0x060001BD RID: 445 RVA: 0x00003B04 File Offset: 0x00001D04
	public override void vmethod_1(object object_0)
	{
		this.method_3(Convert.ToDouble(object_0));
	}

	// Token: 0x060001BE RID: 446 RVA: 0x00003B12 File Offset: 0x00001D12
	public override Class80 vmethod_4()
	{
		Class86 @class = new Class86();
		@class.method_3(this.double_0);
		@class.method_1(base.method_0());
		return @class;
	}

	// Token: 0x060001BF RID: 447 RVA: 0x00003B31 File Offset: 0x00001D31
	public override int vmethod_2()
	{
		return 19;
	}

	// Token: 0x060001C0 RID: 448 RVA: 0x000108F4 File Offset: 0x0000EAF4
	public override Class80 vmethod_3(Class80 class80_0)
	{
		base.method_1(class80_0.method_0());
		int num = class80_0.vmethod_2();
		if (num != 2)
		{
			switch (num)
			{
			case 7:
				this.method_3((double)((Class85)class80_0).method_2());
				return this;
			case 10:
				this.method_3(((Class92)class80_0).method_2());
				return this;
			case 14:
				this.method_3((double)((Class98)class80_0).method_2());
				return this;
			case 15:
				this.method_3((double)((Class91)class80_0).method_2());
				return this;
			case 16:
				this.method_3((double)((Class82)class80_0).method_2());
				return this;
			case 18:
				this.method_3((double)((Class94)class80_0).method_2());
				return this;
			case 19:
				this.method_3(((Class86)class80_0).method_2());
				return this;
			case 20:
				this.method_3(((Class89)class80_0).method_2());
				return this;
			case 21:
				this.method_3((double)((Class90)class80_0).method_2());
				return this;
			case 24:
				this.method_3((double)((Class87)class80_0).method_2());
				return this;
			}
			throw new ArgumentOutOfRangeException();
		}
		this.method_3((double)((Class88)class80_0).method_2());
		return this;
	}

	// Token: 0x0400011C RID: 284
	private double double_0;
}
