using System;
using System.Runtime.InteropServices;
using System.Security;

// Token: 0x0200016D RID: 365
internal sealed class Class173 : IDisposable, Interface5
{
	// Token: 0x060007E4 RID: 2020 RVA: 0x00006772 File Offset: 0x00004972
	public int imethod_0()
	{
		return this.secureString_0.Length;
	}

	// Token: 0x060007E5 RID: 2021 RVA: 0x0000677F File Offset: 0x0000497F
	public Interface5 imethod_4()
	{
		return new Class173();
	}

	// Token: 0x060007E6 RID: 2022 RVA: 0x00046450 File Offset: 0x00044650
	public void imethod_1(int int_0, out byte byte_0)
	{
		if (int_0 >= 0 && int_0 < this.imethod_0())
		{
			IntPtr intPtr = IntPtr.Zero;
			char char_ = '\0';
			try
			{
				intPtr = Marshal.SecureStringToGlobalAllocUnicode(this.secureString_0);
				char_ = (char)Marshal.ReadInt16(intPtr, int_0 * 2);
				byte_0 = Class173.smethod_1(char_, int_0);
				return;
			}
			finally
			{
				Class115.smethod_3(ref char_);
				if (intPtr != IntPtr.Zero)
				{
					Marshal.ZeroFreeGlobalAllocUnicode(intPtr);
				}
			}
		}
		throw new ArgumentOutOfRangeException();
	}

	// Token: 0x060007E7 RID: 2023 RVA: 0x000464C8 File Offset: 0x000446C8
	public void imethod_2(int int_0, ref byte byte_0)
	{
		for (int i = this.secureString_0.Length; i <= int_0; i++)
		{
			if (i == int_0)
			{
				this.secureString_0.AppendChar(Class173.smethod_0(byte_0, i));
				return;
			}
			this.secureString_0.AppendChar(Class173.smethod_0(0, i));
		}
		this.secureString_0.SetAt(int_0, Class173.smethod_0(byte_0, int_0));
	}

	// Token: 0x060007E8 RID: 2024 RVA: 0x00006786 File Offset: 0x00004986
	private static char smethod_0(byte byte_0, int int_0)
	{
		return (char)(byte_0 + 1);
	}

	// Token: 0x060007E9 RID: 2025 RVA: 0x0000678C File Offset: 0x0000498C
	private static byte smethod_1(char char_0, int int_0)
	{
		return (byte)(char_0 - '\u0001');
	}

	// Token: 0x060007EA RID: 2026 RVA: 0x00006792 File Offset: 0x00004992
	public void imethod_3()
	{
		this.secureString_0.Clear();
	}

	// Token: 0x060007EB RID: 2027 RVA: 0x0000679F File Offset: 0x0000499F
	public void Dispose()
	{
		this.secureString_0.Dispose();
		this.secureString_0 = null;
	}

	// Token: 0x040006A7 RID: 1703
	private SecureString secureString_0 = new SecureString();
}
