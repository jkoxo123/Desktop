using System;

// Token: 0x020000EB RID: 235
internal sealed class Class91 : Class80
{
	// Token: 0x06000582 RID: 1410 RVA: 0x000053E1 File Offset: 0x000035E1
	public float method_2()
	{
		return this.float_0;
	}

	// Token: 0x06000583 RID: 1411 RVA: 0x000053E9 File Offset: 0x000035E9
	public void method_3(float float_1)
	{
		this.float_0 = float_1;
	}

	// Token: 0x06000584 RID: 1412 RVA: 0x000053F2 File Offset: 0x000035F2
	public override object vmethod_0()
	{
		return this.method_2();
	}

	// Token: 0x06000585 RID: 1413 RVA: 0x000053FF File Offset: 0x000035FF
	public override void vmethod_1(object object_0)
	{
		this.method_3(Convert.ToSingle(object_0));
	}

	// Token: 0x06000586 RID: 1414 RVA: 0x0000540D File Offset: 0x0000360D
	public override Class80 vmethod_4()
	{
		Class91 @class = new Class91();
		@class.method_3(this.float_0);
		@class.method_1(base.method_0());
		return @class;
	}

	// Token: 0x06000587 RID: 1415 RVA: 0x0000542C File Offset: 0x0000362C
	public override int vmethod_2()
	{
		return 15;
	}

	// Token: 0x06000588 RID: 1416 RVA: 0x00030CD0 File Offset: 0x0002EED0
	public override Class80 vmethod_3(Class80 class80_0)
	{
		base.method_1(class80_0.method_0());
		switch (class80_0.vmethod_2())
		{
		case 2:
			this.method_3((float)((Class88)class80_0).method_2());
			return this;
		case 7:
			this.method_3((float)((Class85)class80_0).method_2());
			return this;
		case 8:
			this.method_3(Convert.ToSingle(((Class84)class80_0).method_2()));
			return this;
		case 10:
			this.method_3(((Class92)class80_0).method_2());
			return this;
		case 14:
			this.method_3((float)((Class98)class80_0).method_2());
			return this;
		case 15:
			this.method_3(((Class91)class80_0).method_2());
			return this;
		case 16:
			this.method_3((float)((Class82)class80_0).method_2());
			return this;
		case 18:
			this.method_3((float)((Class94)class80_0).method_2());
			return this;
		case 19:
			this.method_3((float)((Class86)class80_0).method_2());
			return this;
		case 20:
			this.method_3(((Class89)class80_0).method_2());
			return this;
		case 21:
			this.method_3((float)((Class90)class80_0).method_2());
			return this;
		case 24:
			this.method_3((float)((Class87)class80_0).method_2());
			return this;
		}
		throw new ArgumentOutOfRangeException();
	}

	// Token: 0x04000416 RID: 1046
	private float float_0;
}
