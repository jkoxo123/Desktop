using System;
using Bunifu.Framework.UI;

// Token: 0x02000040 RID: 64
public sealed class GClass1
{
	// Token: 0x0600014A RID: 330 RVA: 0x00003797 File Offset: 0x00001997
	public void method_0(string string_0, bool bool_0)
	{
		this.method_2(string_0, true, bool_0);
	}

	// Token: 0x0600014B RID: 331 RVA: 0x000037A2 File Offset: 0x000019A2
	public void method_1()
	{
		this.method_2(null, false, false);
	}

	// Token: 0x0600014C RID: 332 RVA: 0x0000F3EC File Offset: 0x0000D5EC
	private void method_2(string string_0, bool bool_0, bool bool_1)
	{
		if (string_0 != null)
		{
			this.bunifuThinButton2_0.ButtonText = string_0;
		}
		this.bunifuThinButton2_0.Visible = bool_0;
		this.bunifuThinButton2_1.Visible = bool_0;
		if (bool_0)
		{
			this.bunifuThinButton2_1.BringToFront();
		}
		this.bunifuCustomLabel_0.Visible = bool_1;
	}

	// Token: 0x040000DE RID: 222
	public BunifuThinButton2 bunifuThinButton2_0;

	// Token: 0x040000DF RID: 223
	public BunifuCustomLabel bunifuCustomLabel_0;

	// Token: 0x040000E0 RID: 224
	public BunifuThinButton2 bunifuThinButton2_1;
}
