using System;

// Token: 0x020000AB RID: 171
internal abstract class Class80
{
	// Token: 0x06000432 RID: 1074
	public abstract object vmethod_0();

	// Token: 0x06000433 RID: 1075
	public abstract void vmethod_1(object object_0);

	// Token: 0x06000434 RID: 1076
	public abstract int vmethod_2();

	// Token: 0x06000435 RID: 1077
	public abstract Class80 vmethod_3(Class80 class80_0);

	// Token: 0x06000436 RID: 1078
	public abstract Class80 vmethod_4();

	// Token: 0x06000437 RID: 1079 RVA: 0x0000493E File Offset: 0x00002B3E
	public Type method_0()
	{
		return this.type_0;
	}

	// Token: 0x06000438 RID: 1080 RVA: 0x00004946 File Offset: 0x00002B46
	public void method_1(Type type_1)
	{
		this.type_0 = type_1;
	}

	// Token: 0x040001EC RID: 492
	private Type type_0;
}
