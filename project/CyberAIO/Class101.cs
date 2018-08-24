using System;
using System.Reflection;

// Token: 0x02000014 RID: 20
internal sealed class Class101 : Class100
{
	// Token: 0x0600005E RID: 94 RVA: 0x00002ED6 File Offset: 0x000010D6
	public Class101(FieldInfo fieldInfo_1, object object_1)
	{
		this.method_5(fieldInfo_1);
		this.method_3(object_1);
	}

	// Token: 0x0600005F RID: 95 RVA: 0x00002EEC File Offset: 0x000010EC
	public Class101(FieldInfo fieldInfo_1, object object_1, Class100 class100_1) : this(fieldInfo_1, object_1)
	{
		this.method_7(class100_1);
	}

	// Token: 0x06000060 RID: 96 RVA: 0x00002EFD File Offset: 0x000010FD
	private Class101()
	{
	}

	// Token: 0x06000061 RID: 97 RVA: 0x00002F05 File Offset: 0x00001105
	public object method_2()
	{
		return this.object_0;
	}

	// Token: 0x06000062 RID: 98 RVA: 0x00002F0D File Offset: 0x0000110D
	private void method_3(object object_1)
	{
		this.object_0 = object_1;
	}

	// Token: 0x06000063 RID: 99 RVA: 0x00002F16 File Offset: 0x00001116
	public FieldInfo method_4()
	{
		return this.fieldInfo_0;
	}

	// Token: 0x06000064 RID: 100 RVA: 0x00002F1E File Offset: 0x0000111E
	private void method_5(FieldInfo fieldInfo_1)
	{
		this.fieldInfo_0 = fieldInfo_1;
	}

	// Token: 0x06000065 RID: 101 RVA: 0x00002F27 File Offset: 0x00001127
	public Class100 method_6()
	{
		return this.class100_0;
	}

	// Token: 0x06000066 RID: 102 RVA: 0x00002F2F File Offset: 0x0000112F
	private void method_7(Class100 class100_1)
	{
		this.class100_0 = class100_1;
	}

	// Token: 0x06000067 RID: 103 RVA: 0x00002F38 File Offset: 0x00001138
	public override int vmethod_2()
	{
		return 17;
	}

	// Token: 0x06000068 RID: 104 RVA: 0x00008348 File Offset: 0x00006548
	public override Class80 vmethod_3(Class80 class80_0)
	{
		base.method_1(class80_0.method_0());
		int num = class80_0.vmethod_2();
		if (num == 17)
		{
			Class101 @class = (Class101)class80_0;
			this.method_3(@class.method_2());
			this.method_5(@class.method_4());
			return this;
		}
		throw new ArgumentOutOfRangeException();
	}

	// Token: 0x06000069 RID: 105 RVA: 0x00002F3C File Offset: 0x0000113C
	public override Class80 vmethod_4()
	{
		Class101 @class = new Class101();
		@class.method_3(this.method_2());
		@class.method_5(this.method_4());
		@class.method_7(this.method_6());
		@class.method_1(base.method_0());
		return @class;
	}

	// Token: 0x0400002B RID: 43
	private object object_0;

	// Token: 0x0400002C RID: 44
	private FieldInfo fieldInfo_0;

	// Token: 0x0400002D RID: 45
	private Class100 class100_0;
}
