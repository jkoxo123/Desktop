using System;
using System.Reflection;

// Token: 0x02000124 RID: 292
internal sealed class Class95 : Class80
{
	// Token: 0x06000687 RID: 1671 RVA: 0x00005BD7 File Offset: 0x00003DD7
	public MethodBase method_2()
	{
		return this.methodBase_0;
	}

	// Token: 0x06000688 RID: 1672 RVA: 0x00005BDF File Offset: 0x00003DDF
	public void method_3(MethodBase methodBase_1)
	{
		this.methodBase_0 = methodBase_1;
	}

	// Token: 0x06000689 RID: 1673 RVA: 0x00038D7C File Offset: 0x00036F7C
	public IntPtr method_4()
	{
		return this.method_2().MethodHandle.GetFunctionPointer();
	}

	// Token: 0x0600068A RID: 1674 RVA: 0x00005BE8 File Offset: 0x00003DE8
	public override object vmethod_0()
	{
		return this.method_2();
	}

	// Token: 0x0600068B RID: 1675 RVA: 0x00005BF0 File Offset: 0x00003DF0
	public override void vmethod_1(object object_0)
	{
		this.method_3((MethodBase)object_0);
	}

	// Token: 0x0600068C RID: 1676 RVA: 0x0000391E File Offset: 0x00001B1E
	public override int vmethod_2()
	{
		return 4;
	}

	// Token: 0x0600068D RID: 1677 RVA: 0x00038D9C File Offset: 0x00036F9C
	public override Class80 vmethod_3(Class80 class80_0)
	{
		base.method_1(class80_0.method_0());
		int num = class80_0.vmethod_2();
		if (num == 4)
		{
			this.method_3(((Class95)class80_0).method_2());
			return this;
		}
		throw new ArgumentOutOfRangeException();
	}

	// Token: 0x0600068E RID: 1678 RVA: 0x00005BFE File Offset: 0x00003DFE
	public override Class80 vmethod_4()
	{
		Class95 @class = new Class95();
		@class.method_3(this.methodBase_0);
		@class.method_1(base.method_0());
		return @class;
	}

	// Token: 0x04000518 RID: 1304
	private MethodBase methodBase_0;
}
