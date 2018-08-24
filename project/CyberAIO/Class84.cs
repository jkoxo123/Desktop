using System;

// Token: 0x02000035 RID: 53
internal sealed class Class84 : Class80
{
	// Token: 0x0600010D RID: 269 RVA: 0x000034E2 File Offset: 0x000016E2
	public Class84(Enum enum_1)
	{
		this.enum_0 = (enum_1 ?? Class84.Enum0.Value);
	}

	// Token: 0x0600010E RID: 270 RVA: 0x000034FB File Offset: 0x000016FB
	public Enum method_2()
	{
		return this.enum_0;
	}

	// Token: 0x0600010F RID: 271 RVA: 0x00003503 File Offset: 0x00001703
	public void method_3(Enum enum_1)
	{
		if (enum_1 == null)
		{
			throw new ArgumentException();
		}
		this.enum_0 = enum_1;
	}

	// Token: 0x06000110 RID: 272 RVA: 0x00003515 File Offset: 0x00001715
	public override object vmethod_0()
	{
		return this.method_2();
	}

	// Token: 0x06000111 RID: 273 RVA: 0x0000351D File Offset: 0x0000171D
	public override void vmethod_1(object object_0)
	{
		this.method_3((Enum)Enum.Parse(this.method_2().GetType(), object_0.ToString()));
	}

	// Token: 0x06000112 RID: 274 RVA: 0x00003540 File Offset: 0x00001740
	public override int vmethod_2()
	{
		return 8;
	}

	// Token: 0x06000113 RID: 275 RVA: 0x0000D5D8 File Offset: 0x0000B7D8
	public override Class80 vmethod_3(Class80 class80_0)
	{
		base.method_1(class80_0.method_0());
		int num = class80_0.vmethod_2();
		if (num != 2)
		{
			switch (num)
			{
			case 7:
				this.method_3((Enum)Enum.ToObject(this.enum_0.GetType(), ((Class85)class80_0).method_2()));
				return this;
			case 8:
			{
				Type type = this.enum_0.GetType();
				Enum @enum = ((Class84)class80_0).method_2();
				if (@enum.GetType() == type)
				{
					this.method_3(@enum);
					return this;
				}
				this.method_3((Enum)Enum.ToObject(type, @enum));
				return this;
			}
			case 9:
			case 11:
			case 12:
			case 13:
			case 15:
			case 17:
			case 19:
				break;
			case 10:
				this.method_3((Enum)Enum.ToObject(this.enum_0.GetType(), ((Class92)class80_0).method_2()));
				return this;
			case 14:
				this.method_3((Enum)Enum.ToObject(this.enum_0.GetType(), ((Class98)class80_0).method_2()));
				return this;
			case 16:
				this.method_3((Enum)Enum.ToObject(this.enum_0.GetType(), ((Class82)class80_0).method_2()));
				return this;
			case 18:
				this.method_3((Enum)Enum.ToObject(this.enum_0.GetType(), ((Class94)class80_0).method_2()));
				return this;
			case 20:
				this.method_3((Enum)Enum.ToObject(this.enum_0.GetType(), ((Class89)class80_0).method_2()));
				return this;
			case 21:
				this.method_3((Enum)Enum.ToObject(this.enum_0.GetType(), ((Class90)class80_0).method_2()));
				return this;
			default:
				if (num == 24)
				{
					this.method_3((Enum)Enum.ToObject(this.enum_0.GetType(), ((Class87)class80_0).method_2()));
					return this;
				}
				break;
			}
			throw new ArgumentOutOfRangeException();
		}
		this.method_3((Enum)Enum.ToObject(this.enum_0.GetType(), ((Class88)class80_0).method_2()));
		return this;
	}

	// Token: 0x06000114 RID: 276 RVA: 0x00003543 File Offset: 0x00001743
	public override Class80 vmethod_4()
	{
		Class84 @class = new Class84(this.enum_0);
		@class.method_1(base.method_0());
		return @class;
	}

	// Token: 0x040000BD RID: 189
	private Enum enum_0;

	// Token: 0x02000036 RID: 54
	private enum Enum0
	{
		// Token: 0x040000BF RID: 191
		Value
	}
}
