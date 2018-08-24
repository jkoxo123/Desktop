using System;

// Token: 0x020000AA RID: 170
internal sealed class Class79
{
	// Token: 0x06000430 RID: 1072 RVA: 0x00020F08 File Offset: 0x0001F108
	internal static uint smethod_0(string string_0)
	{
		uint num;
		if (string_0 != null)
		{
			num = 2166136261u;
			for (int i = 0; i < string_0.Length; i++)
			{
				num = ((uint)string_0[i] ^ num) * 16777619u;
			}
		}
		return num;
	}
}
