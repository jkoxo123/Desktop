using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Resources;

// Token: 0x0200012A RID: 298
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
[DebuggerNonUserCode]
internal sealed class Class158
{
	// Token: 0x060006C9 RID: 1737 RVA: 0x00002B9B File Offset: 0x00000D9B
	internal Class158()
	{
	}

	// Token: 0x060006CA RID: 1738 RVA: 0x00005E47 File Offset: 0x00004047
	internal static ResourceManager smethod_0()
	{
		if (Class158.resourceManager_0 == null)
		{
			Class158.resourceManager_0 = new ResourceManager("CyberAIO.Properties.Resources", typeof(Class158).Assembly);
		}
		return Class158.resourceManager_0;
	}

	// Token: 0x060006CB RID: 1739 RVA: 0x00005E73 File Offset: 0x00004073
	internal static CultureInfo smethod_1()
	{
		return Class158.cultureInfo_0;
	}

	// Token: 0x060006CC RID: 1740 RVA: 0x00005E7A File Offset: 0x0000407A
	internal static void smethod_2(CultureInfo cultureInfo_1)
	{
		Class158.cultureInfo_0 = cultureInfo_1;
	}

	// Token: 0x060006CD RID: 1741 RVA: 0x00005E82 File Offset: 0x00004082
	internal static string smethod_3()
	{
		return Class158.smethod_0().GetString("certificates", Class158.cultureInfo_0);
	}

	// Token: 0x060006CE RID: 1742 RVA: 0x00005E98 File Offset: 0x00004098
	internal static UnmanagedMemoryStream smethod_4()
	{
		return Class158.smethod_0().GetStream("ding", Class158.cultureInfo_0);
	}

	// Token: 0x060006CF RID: 1743 RVA: 0x00005EAE File Offset: 0x000040AE
	internal static Bitmap smethod_5()
	{
		return (Bitmap)Class158.smethod_0().GetObject("download", Class158.cultureInfo_0);
	}

	// Token: 0x060006D0 RID: 1744 RVA: 0x00005EC9 File Offset: 0x000040C9
	internal static string smethod_6()
	{
		return Class158.smethod_0().GetString("GUI", Class158.cultureInfo_0);
	}

	// Token: 0x060006D1 RID: 1745 RVA: 0x00005EDF File Offset: 0x000040DF
	internal static Bitmap smethod_7()
	{
		return (Bitmap)Class158.smethod_0().GetObject("info", Class158.cultureInfo_0);
	}

	// Token: 0x060006D2 RID: 1746 RVA: 0x00005EFA File Offset: 0x000040FA
	internal static string smethod_8()
	{
		return Class158.smethod_0().GetString("Loader", Class158.cultureInfo_0);
	}

	// Token: 0x060006D3 RID: 1747 RVA: 0x00005F10 File Offset: 0x00004110
	internal static string smethod_9()
	{
		return Class158.smethod_0().GetString("shopify", Class158.cultureInfo_0);
	}

	// Token: 0x060006D4 RID: 1748 RVA: 0x00005F26 File Offset: 0x00004126
	internal static Bitmap smethod_10()
	{
		return (Bitmap)Class158.smethod_0().GetObject("stop", Class158.cultureInfo_0);
	}

	// Token: 0x060006D5 RID: 1749 RVA: 0x00005F41 File Offset: 0x00004141
	internal static UnmanagedMemoryStream smethod_11()
	{
		return Class158.smethod_0().GetStream("success", Class158.cultureInfo_0);
	}

	// Token: 0x060006D6 RID: 1750 RVA: 0x00005F57 File Offset: 0x00004157
	internal static Bitmap smethod_12()
	{
		return (Bitmap)Class158.smethod_0().GetObject("tick", Class158.cultureInfo_0);
	}

	// Token: 0x0400052A RID: 1322
	private static ResourceManager resourceManager_0;

	// Token: 0x0400052B RID: 1323
	private static CultureInfo cultureInfo_0;
}
