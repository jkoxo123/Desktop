using System;
using System.Reflection;
using System.Runtime.CompilerServices;

// Token: 0x0200002D RID: 45
internal static class Class17
{
	// Token: 0x060000E2 RID: 226 RVA: 0x00003300 File Offset: 0x00001500
	public static void smethod_0(Array array_0, RuntimeFieldHandle runtimeFieldHandle_0)
	{
		if (Class124.smethod_0())
		{
			int metadataToken = FieldInfo.GetFieldFromHandle(runtimeFieldHandle_0).MetadataToken;
		}
		RuntimeHelpers.InitializeArray(array_0, runtimeFieldHandle_0);
	}
}
