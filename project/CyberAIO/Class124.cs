using System;

// Token: 0x020000E2 RID: 226
internal static class Class124
{
	// Token: 0x0600053A RID: 1338 RVA: 0x0002D5C8 File Offset: 0x0002B7C8
	static Class124()
	{
		try
		{
			Class124.bool_0 = (Type.GetType("Mono.Runtime") != null);
		}
		catch
		{
			Class124.bool_0 = false;
		}
	}

	// Token: 0x0600053B RID: 1339 RVA: 0x0000517E File Offset: 0x0000337E
	public static bool smethod_0()
	{
		return Class124.bool_0;
	}

	// Token: 0x040003D9 RID: 985
	private static readonly bool bool_0;
}
