using System;
using System.Reflection;

// Token: 0x02000173 RID: 371
internal static class Class175
{
	// Token: 0x060007FF RID: 2047 RVA: 0x00006851 File Offset: 0x00004A51
	public static bool smethod_0(Type type_4)
	{
		return type_4.IsGenericType && type_4.GetGenericTypeDefinition() == Class175.type_1;
	}

	// Token: 0x040006BF RID: 1727
	public static readonly Type type_0 = typeof(object);

	// Token: 0x040006C0 RID: 1728
	public static readonly Type type_1 = typeof(Nullable<>);

	// Token: 0x040006C1 RID: 1729
	public static readonly Type type_2 = typeof(Enum);

	// Token: 0x040006C2 RID: 1730
	public static readonly Type type_3 = typeof(ValueType);

	// Token: 0x040006C3 RID: 1731
	public static readonly Assembly assembly_0 = typeof(Class175).Assembly;
}
