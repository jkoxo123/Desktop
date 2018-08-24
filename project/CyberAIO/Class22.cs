using System;

// Token: 0x02000056 RID: 86
internal class Class22 : Class21
{
	// Token: 0x0600019C RID: 412 RVA: 0x000039B4 File Offset: 0x00001BB4
	protected Class22()
	{
	}

	// Token: 0x0600019D RID: 413 RVA: 0x000039BC File Offset: 0x00001BBC
	public Class22(Interface1 interface1_1)
	{
		if (interface1_1 == null)
		{
			throw new ArgumentNullException("cipher");
		}
		this.interface1_0 = interface1_1;
		this.byte_1 = new byte[interface1_1.imethod_2()];
		this.int_0 = 0;
	}

	// Token: 0x0600019E RID: 414 RVA: 0x000039F1 File Offset: 0x00001BF1
	public override string imethod_0()
	{
		return this.interface1_0.imethod_0();
	}

	// Token: 0x0600019F RID: 415 RVA: 0x000039FE File Offset: 0x00001BFE
	public override void imethod_1(bool bool_1, Interface6 interface6_0)
	{
		this.bool_0 = bool_1;
		this.imethod_15();
		this.interface1_0.imethod_1(bool_1, interface6_0);
	}

	// Token: 0x060001A0 RID: 416 RVA: 0x00003A1A File Offset: 0x00001C1A
	public override int imethod_2()
	{
		return this.interface1_0.imethod_2();
	}

	// Token: 0x060001A1 RID: 417 RVA: 0x000105EC File Offset: 0x0000E7EC
	public override int imethod_4(int int_1)
	{
		int num = int_1 + this.int_0;
		int num2 = num % this.byte_1.Length;
		return num - num2;
	}

	// Token: 0x060001A2 RID: 418 RVA: 0x00003A27 File Offset: 0x00001C27
	public override int imethod_3(int int_1)
	{
		return int_1 + this.int_0;
	}

	// Token: 0x060001A3 RID: 419 RVA: 0x00010610 File Offset: 0x0000E810
	public override byte[] imethod_6(byte[] byte_2, int int_1, int int_2)
	{
		if (byte_2 == null)
		{
			throw new ArgumentNullException("\u0002");
		}
		if (int_2 < 1)
		{
			return null;
		}
		int num = this.imethod_4(int_2);
		byte[] array = (num > 0) ? new byte[num] : null;
		int num2 = this.imethod_8(byte_2, int_1, int_2, array, 0);
		if (num > 0 && num2 < num)
		{
			byte[] array2 = new byte[num2];
			Array.Copy(array, 0, array2, 0, num2);
			array = array2;
		}
		return array;
	}

	// Token: 0x060001A4 RID: 420 RVA: 0x00010670 File Offset: 0x0000E870
	public override int imethod_8(byte[] byte_2, int int_1, int int_2, byte[] byte_3, int int_3)
	{
		if (int_2 < 1)
		{
			if (int_2 < 0)
			{
				throw new ArgumentException("Can't have a negative input length!");
			}
			return 0;
		}
		else
		{
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
			if (this.int_0 == this.byte_1.Length)
			{
				num3 += this.interface1_0.imethod_4(this.byte_1, 0, byte_3, int_3 + num3);
				this.int_0 = 0;
			}
			return num3;
		}
	}

	// Token: 0x060001A5 RID: 421 RVA: 0x00010798 File Offset: 0x0000E998
	public override byte[] imethod_9()
	{
		byte[] array = Class21.byte_0;
		int num = this.imethod_3(0);
		if (num > 0)
		{
			array = new byte[num];
			int num2 = this.imethod_12(array, 0);
			if (num2 < array.Length)
			{
				byte[] array2 = new byte[num2];
				Array.Copy(array, 0, array2, 0, num2);
				array = array2;
			}
		}
		else
		{
			this.imethod_15();
		}
		return array;
	}

	// Token: 0x060001A6 RID: 422 RVA: 0x000107EC File Offset: 0x0000E9EC
	public override byte[] imethod_11(byte[] byte_2, int int_1, int int_2)
	{
		if (byte_2 == null)
		{
			throw new ArgumentNullException("\u0002");
		}
		int num = this.imethod_3(int_2);
		byte[] array = Class21.byte_0;
		if (num > 0)
		{
			array = new byte[num];
			int num2 = (int_2 > 0) ? this.imethod_8(byte_2, int_1, int_2, array, 0) : 0;
			num2 += this.imethod_12(array, num2);
			if (num2 < array.Length)
			{
				byte[] array2 = new byte[num2];
				Array.Copy(array, 0, array2, 0, num2);
				array = array2;
			}
		}
		else
		{
			this.imethod_15();
		}
		return array;
	}

	// Token: 0x060001A7 RID: 423 RVA: 0x00010860 File Offset: 0x0000EA60
	public override int imethod_12(byte[] byte_2, int int_1)
	{
		int result;
		try
		{
			if (this.int_0 != 0)
			{
				if (!this.interface1_0.imethod_3())
				{
					throw new Exception2("data not block size aligned");
				}
				if (int_1 + this.int_0 > byte_2.Length)
				{
					throw new Exception2("output buffer too short for DoFinal()");
				}
				this.interface1_0.imethod_4(this.byte_1, 0, this.byte_1, 0);
				Array.Copy(this.byte_1, 0, byte_2, int_1, this.int_0);
			}
			result = this.int_0;
		}
		finally
		{
			this.imethod_15();
		}
		return result;
	}

	// Token: 0x060001A8 RID: 424 RVA: 0x00003A31 File Offset: 0x00001C31
	public override void imethod_15()
	{
		Array.Clear(this.byte_1, 0, this.byte_1.Length);
		this.int_0 = 0;
		this.interface1_0.imethod_5();
	}

	// Token: 0x04000112 RID: 274
	internal byte[] byte_1;

	// Token: 0x04000113 RID: 275
	internal int int_0;

	// Token: 0x04000114 RID: 276
	internal bool bool_0;

	// Token: 0x04000115 RID: 277
	internal Interface1 interface1_0;
}
