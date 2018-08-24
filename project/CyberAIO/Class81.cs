using System;

// Token: 0x02000003 RID: 3
internal sealed class Class81 : Class80
{
	// Token: 0x0600000B RID: 11 RVA: 0x00002BDE File Offset: 0x00000DDE
	public char method_2()
	{
		return this.char_0;
	}

	// Token: 0x0600000C RID: 12 RVA: 0x00002BE6 File Offset: 0x00000DE6
	public void method_3(char char_1)
	{
		this.char_0 = char_1;
	}

	// Token: 0x0600000D RID: 13 RVA: 0x00002BEF File Offset: 0x00000DEF
	public override object vmethod_0()
	{
		return this.method_2();
	}

	// Token: 0x0600000E RID: 14 RVA: 0x00002BFC File Offset: 0x00000DFC
	public override void vmethod_1(object object_0)
	{
		this.method_3(Convert.ToChar(object_0));
	}

	// Token: 0x0600000F RID: 15 RVA: 0x00002C0A File Offset: 0x00000E0A
	public override int vmethod_2()
	{
		return 13;
	}

	// Token: 0x06000010 RID: 16 RVA: 0x00006BC8 File Offset: 0x00004DC8
	public override Class80 vmethod_3(Class80 class80_0)
	{
		base.method_1(class80_0.method_0());
		switch (class80_0.vmethod_2())
		{
		case 0:
			this.method_3(Convert.ToChar(((Class97)class80_0).method_2()));
			return this;
		case 2:
			this.method_3((char)((Class88)class80_0).method_2());
			return this;
		case 6:
			this.method_3((char)((uint)((Class83)class80_0).method_2()));
			return this;
		case 7:
			this.method_3((char)((Class85)class80_0).method_2());
			return this;
		case 8:
			this.method_3(Convert.ToChar(((Class84)class80_0).method_2()));
			return this;
		case 10:
			this.method_3((char)((Class92)class80_0).method_2());
			return this;
		case 13:
			this.method_3(((Class81)class80_0).method_2());
			return this;
		case 14:
			this.method_3((char)((Class98)class80_0).method_2());
			return this;
		case 16:
			this.method_3((char)((Class82)class80_0).method_2());
			return this;
		case 18:
			this.method_3((char)((Class94)class80_0).method_2());
			return this;
		case 20:
			this.method_3((char)((Class89)class80_0).method_2());
			return this;
		case 21:
			this.method_3(Convert.ToChar(((Class90)class80_0).method_2()));
			return this;
		case 23:
			this.method_3((char)((int)((Class99)class80_0).method_2()));
			return this;
		case 24:
			this.method_3((char)((Class87)class80_0).method_2());
			return this;
		}
		throw new ArgumentOutOfRangeException();
	}

	// Token: 0x06000011 RID: 17 RVA: 0x00002C0E File Offset: 0x00000E0E
	public override Class80 vmethod_4()
	{
		Class81 @class = new Class81();
		@class.method_3(this.char_0);
		@class.method_1(base.method_0());
		return @class;
	}

	// Token: 0x04000004 RID: 4
	private char char_0;
}
