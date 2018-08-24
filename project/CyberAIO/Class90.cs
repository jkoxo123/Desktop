using System;

// Token: 0x020000B7 RID: 183
internal sealed class Class90 : Class80
{
	// Token: 0x06000481 RID: 1153 RVA: 0x00004C4D File Offset: 0x00002E4D
	public object method_2()
	{
		return this.object_0;
	}

	// Token: 0x06000482 RID: 1154 RVA: 0x00004C55 File Offset: 0x00002E55
	public void method_3(object object_1)
	{
		this.object_0 = object_1;
	}

	// Token: 0x06000483 RID: 1155 RVA: 0x00004C5E File Offset: 0x00002E5E
	public override object vmethod_0()
	{
		return this.method_2();
	}

	// Token: 0x06000484 RID: 1156 RVA: 0x00004C66 File Offset: 0x00002E66
	public override void vmethod_1(object object_1)
	{
		this.method_3(object_1);
	}

	// Token: 0x06000485 RID: 1157 RVA: 0x00004C6F File Offset: 0x00002E6F
	public override int vmethod_2()
	{
		return 21;
	}

	// Token: 0x06000486 RID: 1158 RVA: 0x00004C73 File Offset: 0x00002E73
	public override Class80 vmethod_3(Class80 class80_0)
	{
		base.method_1(class80_0.method_0());
		this.method_3(class80_0.vmethod_0());
		return this;
	}

	// Token: 0x06000487 RID: 1159 RVA: 0x00004C8E File Offset: 0x00002E8E
	public override Class80 vmethod_4()
	{
		Class90 @class = new Class90();
		@class.method_3(this.object_0);
		@class.method_1(base.method_0());
		return @class;
	}

	// Token: 0x04000209 RID: 521
	private object object_0;
}
