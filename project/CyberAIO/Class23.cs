using System;

// Token: 0x020000A9 RID: 169
internal sealed class Class23 : Class22
{
	// Token: 0x06000429 RID: 1065 RVA: 0x000048DB File Offset: 0x00002ADB
	public Class23(Interface1 interface1_1, Interface2 interface2_1)
	{
		this.interface1_0 = interface1_1;
		this.interface2_0 = interface2_1;
		this.byte_1 = new byte[interface1_1.imethod_2()];
		this.int_0 = 0;
	}

	// Token: 0x0600042A RID: 1066 RVA: 0x00004909 File Offset: 0x00002B09
	public Class23(Interface1 interface1_1) : this(interface1_1, new Class125())
	{
	}

	// Token: 0x0600042B RID: 1067 RVA: 0x00004917 File Offset: 0x00002B17
	public override void imethod_1(bool bool_1, Interface6 interface6_0)
	{
		this.bool_0 = bool_1;
		this.imethod_15();
		this.interface2_0.imethod_0();
		this.interface1_0.imethod_1(bool_1, interface6_0);
	}

	// Token: 0x0600042C RID: 1068 RVA: 0x00020C88 File Offset: 0x0001EE88
	public override int imethod_3(int int_1)
	{
		int num = int_1 + this.int_0;
		int num2 = num % this.byte_1.Length;
		if (num2 != 0)
		{
			return num - num2 + this.byte_1.Length;
		}
		if (this.bool_0)
		{
			return num + this.byte_1.Length;
		}
		return num;
	}

	// Token: 0x0600042D RID: 1069 RVA: 0x00020CD0 File Offset: 0x0001EED0
	public override int imethod_4(int int_1)
	{
		int num = int_1 + this.int_0;
		int num2 = num % this.byte_1.Length;
		if (num2 == 0)
		{
			return num - this.byte_1.Length;
		}
		return num - num2;
	}

	// Token: 0x0600042E RID: 1070 RVA: 0x00020D04 File Offset: 0x0001EF04
	public override int imethod_8(byte[] byte_2, int int_1, int int_2, byte[] byte_3, int int_3)
	{
		if (int_2 < 0)
		{
			throw new ArgumentException("Can't have a negative input length!");
		}
		int num = this.imethod_2();
		int num2 = this.imethod_4(int_2);
		if (num2 > 0 && int_3 + num2 > byte_3.Length)
		{
			throw new Exception2("output buffer too short");
		}
		int num3 = 0;
		int num4 = this.byte_1.Length - this.int_0;
		if (int_2 > num4)
		{
			Array.Copy(byte_2, int_1, this.byte_1, this.int_0, num4);
			num3 += this.interface1_0.imethod_4(this.byte_1, 0, byte_3, int_3);
			this.int_0 = 0;
			int_2 -= num4;
			int_1 += num4;
			while (int_2 > this.byte_1.Length)
			{
				num3 += this.interface1_0.imethod_4(byte_2, int_1, byte_3, int_3 + num3);
				int_2 -= num;
				int_1 += num;
			}
		}
		Array.Copy(byte_2, int_1, this.byte_1, this.int_0, int_2);
		this.int_0 += int_2;
		return num3;
	}

	// Token: 0x0600042F RID: 1071 RVA: 0x00020DF4 File Offset: 0x0001EFF4
	public override int imethod_12(byte[] byte_2, int int_1)
	{
		int num = this.interface1_0.imethod_2();
		int num2 = 0;
		if (!this.bool_0)
		{
			if (this.int_0 == num)
			{
				num2 = this.interface1_0.imethod_4(this.byte_1, 0, this.byte_1, 0);
				this.int_0 = 0;
				try
				{
					num2 -= this.interface2_0.imethod_3(this.byte_1);
					Array.Copy(this.byte_1, 0, byte_2, int_1, num2);
					return num2;
				}
				finally
				{
					this.imethod_15();
				}
			}
			this.imethod_15();
			throw new Exception2("last block incomplete in decryption");
		}
		if (this.int_0 == num)
		{
			if (int_1 + 2 * num > byte_2.Length)
			{
				this.imethod_15();
				throw new Exception2("output buffer too short");
			}
			num2 = this.interface1_0.imethod_4(this.byte_1, 0, byte_2, int_1);
			this.int_0 = 0;
		}
		this.interface2_0.imethod_2(this.byte_1, this.int_0);
		num2 += this.interface1_0.imethod_4(this.byte_1, 0, byte_2, int_1 + num2);
		this.imethod_15();
		return num2;
	}

	// Token: 0x040001EB RID: 491
	private readonly Interface2 interface2_0;
}
