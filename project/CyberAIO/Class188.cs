using System;

// Token: 0x0200019B RID: 411
internal sealed class Class188 : Interface6
{
	// Token: 0x0600088A RID: 2186 RVA: 0x00006B41 File Offset: 0x00004D41
	public Class188(byte[] byte_1)
	{
		if (byte_1 == null)
		{
			throw new ArgumentNullException("\u0002");
		}
		this.byte_0 = (byte[])byte_1.Clone();
	}

	// Token: 0x0600088B RID: 2187 RVA: 0x0004CA48 File Offset: 0x0004AC48
	public Class188(byte[] byte_1, int int_0, int int_1)
	{
		if (byte_1 == null)
		{
			throw new ArgumentNullException("\u0002");
		}
		if (int_0 < 0 || int_0 > byte_1.Length)
		{
			throw new ArgumentOutOfRangeException("\u0003");
		}
		if (int_1 < 0 || int_0 + int_1 > byte_1.Length)
		{
			throw new ArgumentOutOfRangeException("\u0005");
		}
		this.byte_0 = new byte[int_1];
		Array.Copy(byte_1, int_0, this.byte_0, 0, int_1);
	}

	// Token: 0x0600088C RID: 2188 RVA: 0x00006B68 File Offset: 0x00004D68
	public byte[] method_0()
	{
		return (byte[])this.byte_0.Clone();
	}

	// Token: 0x04000770 RID: 1904
	private readonly byte[] byte_0;
}
