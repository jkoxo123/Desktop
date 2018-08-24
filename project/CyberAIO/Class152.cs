using System;
using System.Reflection;
using System.Security.Cryptography;

// Token: 0x0200011B RID: 283
internal sealed class Class152 : IDisposable
{
	// Token: 0x06000652 RID: 1618 RVA: 0x000059F4 File Offset: 0x00003BF4
	public Class152()
	{
		this.method_1((Enum2)1);
	}

	// Token: 0x06000653 RID: 1619 RVA: 0x000382A4 File Offset: 0x000364A4
	public void Dispose()
	{
		IDisposable disposable = this.symmetricAlgorithm_0;
		if (disposable != null)
		{
			disposable.Dispose();
		}
	}

	// Token: 0x06000654 RID: 1620 RVA: 0x00005A03 File Offset: 0x00003C03
	public Enum2 method_0()
	{
		return this.enum2_0;
	}

	// Token: 0x06000655 RID: 1621 RVA: 0x00005A0B File Offset: 0x00003C0B
	public void method_1(Enum2 enum2_1)
	{
		if (this.enum2_0 == enum2_1)
		{
			return;
		}
		this.enum2_0 = enum2_1;
		this.bool_1 = true;
	}

	// Token: 0x06000656 RID: 1622 RVA: 0x00005A25 File Offset: 0x00003C25
	public Enum1 method_2()
	{
		return this.enum1_0;
	}

	// Token: 0x06000657 RID: 1623 RVA: 0x00005A2D File Offset: 0x00003C2D
	public void method_3(Enum1 enum1_1)
	{
		if (this.enum1_0 == enum1_1)
		{
			return;
		}
		this.enum1_0 = enum1_1;
		this.bool_1 = true;
	}

	// Token: 0x06000658 RID: 1624 RVA: 0x00005A47 File Offset: 0x00003C47
	public byte[] method_4()
	{
		return this.byte_0;
	}

	// Token: 0x06000659 RID: 1625 RVA: 0x00005A4F File Offset: 0x00003C4F
	public void method_5(byte[] byte_2)
	{
		this.byte_0 = byte_2;
		this.bool_1 = true;
	}

	// Token: 0x0600065A RID: 1626 RVA: 0x00005A5F File Offset: 0x00003C5F
	public byte[] method_6()
	{
		return this.byte_1;
	}

	// Token: 0x0600065B RID: 1627 RVA: 0x00005A67 File Offset: 0x00003C67
	public void method_7(byte[] byte_2)
	{
		this.byte_1 = byte_2;
		this.bool_1 = true;
	}

	// Token: 0x0600065C RID: 1628 RVA: 0x000382C4 File Offset: 0x000364C4
	private static SymmetricAlgorithm smethod_0()
	{
		if (Class152.type_0 != null)
		{
			if (Class152.type_0 == typeof(Class152.Class153))
			{
				return null;
			}
			return Activator.CreateInstance(Class152.type_0) as SymmetricAlgorithm;
		}
		else
		{
			Class152.type_0 = typeof(Class152.Class153);
			Assembly assembly = null;
			try
			{
				assembly = Assembly.Load("System.Core, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089");
			}
			catch
			{
			}
			if (assembly == null)
			{
				return null;
			}
			try
			{
				Type type = assembly.GetType("System.Security.Cryptography.AesCryptoServiceProvider");
				if (type != null)
				{
					SymmetricAlgorithm result = Activator.CreateInstance(type) as SymmetricAlgorithm;
					Class152.type_0 = type;
					return result;
				}
			}
			catch
			{
			}
			try
			{
				Type type2 = assembly.GetType("System.Security.Cryptography.AesManaged");
				if (type2 != null)
				{
					SymmetricAlgorithm result2 = Activator.CreateInstance(type2) as SymmetricAlgorithm;
					Class152.type_0 = type2;
					return result2;
				}
			}
			catch
			{
			}
			return null;
		}
	}

	// Token: 0x0600065D RID: 1629 RVA: 0x00005A77 File Offset: 0x00003C77
	private static CipherMode smethod_1(Enum2 enum2_1)
	{
		if (enum2_1 == (Enum2)1)
		{
			return CipherMode.CBC;
		}
		throw new InvalidOperationException("Cipher mode is not supported");
	}

	// Token: 0x0600065E RID: 1630 RVA: 0x00005A8B File Offset: 0x00003C8B
	private static PaddingMode smethod_2(Enum1 enum1_1)
	{
		if (enum1_1 == (Enum1)1)
		{
			return PaddingMode.None;
		}
		if (enum1_1 != (Enum1)2)
		{
			throw new InvalidOperationException("Padding mode is not supported");
		}
		return PaddingMode.PKCS7;
	}

	// Token: 0x0600065F RID: 1631 RVA: 0x00005AA3 File Offset: 0x00003CA3
	public Class2 method_8()
	{
		return this.method_10(true);
	}

	// Token: 0x06000660 RID: 1632 RVA: 0x00005AAC File Offset: 0x00003CAC
	public Class2 method_9()
	{
		return this.method_10(false);
	}

	// Token: 0x06000661 RID: 1633 RVA: 0x000383C8 File Offset: 0x000365C8
	private Class2 method_10(bool bool_2)
	{
		if (!this.bool_0)
		{
			bool flag = this.bool_1 || this.symmetricAlgorithm_0 == null;
			if (this.symmetricAlgorithm_0 == null)
			{
				this.symmetricAlgorithm_0 = Class152.smethod_0();
				if (this.symmetricAlgorithm_0 == null)
				{
					this.bool_0 = true;
				}
			}
			if (this.symmetricAlgorithm_0 != null)
			{
				if (flag)
				{
					this.symmetricAlgorithm_0.Key = this.method_4();
					this.symmetricAlgorithm_0.IV = this.method_6();
					this.symmetricAlgorithm_0.Mode = Class152.smethod_1(this.method_0());
					this.symmetricAlgorithm_0.Padding = Class152.smethod_2(this.method_2());
				}
				return new Class4(bool_2 ? this.symmetricAlgorithm_0.CreateEncryptor() : this.symmetricAlgorithm_0.CreateDecryptor());
			}
		}
		Class73 interface1_ = new Class73(new Class151());
		Class22 @class;
		if (this.method_2() != (Enum1)1)
		{
			@class = new Class23(interface1_, Class152.smethod_3(this.method_2()));
		}
		else
		{
			@class = new Class22(interface1_);
		}
		Class25 interface6_ = new Class25(new Class188(this.method_4()), this.method_6());
		@class.imethod_1(bool_2, interface6_);
		return new Class3(@class);
	}

	// Token: 0x06000662 RID: 1634 RVA: 0x00005AB5 File Offset: 0x00003CB5
	private static Interface2 smethod_3(Enum1 enum1_1)
	{
		if (enum1_1 == (Enum1)1)
		{
			return null;
		}
		if (enum1_1 != (Enum1)2)
		{
			throw new InvalidOperationException("Padding mode is not supported");
		}
		return new Class125();
	}

	// Token: 0x04000505 RID: 1285
	private Enum2 enum2_0;

	// Token: 0x04000506 RID: 1286
	private Enum1 enum1_0;

	// Token: 0x04000507 RID: 1287
	private byte[] byte_0;

	// Token: 0x04000508 RID: 1288
	private byte[] byte_1;

	// Token: 0x04000509 RID: 1289
	private static Type type_0;

	// Token: 0x0400050A RID: 1290
	private bool bool_0;

	// Token: 0x0400050B RID: 1291
	private bool bool_1;

	// Token: 0x0400050C RID: 1292
	private SymmetricAlgorithm symmetricAlgorithm_0;

	// Token: 0x0200011C RID: 284
	private sealed class Class153
	{
	}
}
