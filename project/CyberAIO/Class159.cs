using System;

// Token: 0x0200012B RID: 299
internal sealed class Class159
{
	// Token: 0x060006D7 RID: 1751 RVA: 0x00005F72 File Offset: 0x00004172
	public Class159(int int_2, int int_3)
	{
		this.method_1(int_2);
		this.int_1 = int_3;
	}

	// Token: 0x060006D8 RID: 1752 RVA: 0x00005F88 File Offset: 0x00004188
	public int method_0()
	{
		return this.int_0;
	}

	// Token: 0x060006D9 RID: 1753 RVA: 0x00005F90 File Offset: 0x00004190
	public void method_1(int int_2)
	{
		this.int_0 = int_2;
	}

	// Token: 0x060006DA RID: 1754 RVA: 0x00005F99 File Offset: 0x00004199
	public int method_2()
	{
		return this.int_1;
	}

	// Token: 0x060006DB RID: 1755 RVA: 0x00039090 File Offset: 0x00037290
	public override bool Equals(object obj)
	{
		Class159 class159_ = obj as Class159;
		return !(class159_ == null) && this.method_3(class159_);
	}

	// Token: 0x060006DC RID: 1756 RVA: 0x00005FA1 File Offset: 0x000041A1
	public bool method_3(Class159 class159_0)
	{
		return class159_0.method_0() == this.method_0();
	}

	// Token: 0x060006DD RID: 1757 RVA: 0x00005FB1 File Offset: 0x000041B1
	public static bool operator ==(Class159 class159_0, Class159 class159_1)
	{
		return class159_0.method_3(class159_1);
	}

	// Token: 0x060006DE RID: 1758 RVA: 0x00005FBA File Offset: 0x000041BA
	public static bool operator !=(Class159 class159_0, Class159 class159_1)
	{
		return !(class159_0 == class159_1);
	}

	// Token: 0x060006DF RID: 1759 RVA: 0x000390B8 File Offset: 0x000372B8
	public override int GetHashCode()
	{
		return this.method_0().GetHashCode();
	}

	// Token: 0x060006E0 RID: 1760 RVA: 0x000390D4 File Offset: 0x000372D4
	public override string ToString()
	{
		return this.method_0().ToString();
	}

	// Token: 0x0400052C RID: 1324
	private int int_0;

	// Token: 0x0400052D RID: 1325
	private readonly int int_1;
}
