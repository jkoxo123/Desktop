using System;
using System.Runtime.InteropServices;

// Token: 0x02000055 RID: 85
[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
internal static class Class40
{
	// Token: 0x0600019B RID: 411 RVA: 0x000039A0 File Offset: 0x00001BA0
	internal static bool smethod_0<T>(T[] gparam_0)
	{
		if (gparam_0 == null)
		{
			throw new ArgumentNullException();
		}
		return gparam_0.Length != 0;
	}
}
