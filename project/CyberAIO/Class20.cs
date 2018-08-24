using System;
using System.IO;
using System.Runtime.CompilerServices;

// Token: 0x02000030 RID: 48
internal static class Class20
{
	// Token: 0x060000F2 RID: 242 RVA: 0x00003428 File Offset: 0x00001628
	[MethodImpl(MethodImplOptions.Synchronized)]
	public static Class65 smethod_0()
	{
		if (Class20.class119_0 == null)
		{
			Class20.class119_0 = new Class119();
		}
		return new Class65(Class20.class119_0);
	}

	// Token: 0x060000F3 RID: 243 RVA: 0x00003445 File Offset: 0x00001645
	public static Stream smethod_1()
	{
		if (Class20.stream_0 == null)
		{
			Class20.stream_0 = typeof(Class20).Assembly.GetManifestResourceStream("4155e30f986b4d09b610b7fa5ef8038b");
		}
		return Class20.stream_0;
	}

	// Token: 0x040000B9 RID: 185
	private static Class119 class119_0;

	// Token: 0x040000BA RID: 186
	[ThreadStatic]
	private static Stream stream_0;
}
