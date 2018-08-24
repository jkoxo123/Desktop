using System;
using System.Runtime.InteropServices;

// Token: 0x020000F1 RID: 241
internal sealed class Class133
{
	// Token: 0x0600059C RID: 1436
	[DllImport("user32")]
	public static extern bool PostMessage(IntPtr intptr_0, int int_1, IntPtr intptr_1, IntPtr intptr_2);

	// Token: 0x0600059D RID: 1437
	[DllImport("user32")]
	public static extern int RegisterWindowMessage(string string_0);

	// Token: 0x0400042F RID: 1071
	public static readonly int int_0 = Class133.RegisterWindowMessage("WM_SHOWME");
}
