using System;
using System.IO;

// Token: 0x02000139 RID: 313
internal sealed class Class13 : Class11, IDisposable
{
	// Token: 0x0600070C RID: 1804 RVA: 0x000060C1 File Offset: 0x000042C1
	public Class13() : this(0)
	{
	}

	// Token: 0x0600070D RID: 1805 RVA: 0x0003C000 File Offset: 0x0003A200
	public Class13(int int_4)
	{
		if (int_4 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		this.byte_0 = new byte[int_4];
		this.int_3 = int_4;
		this.bool_0 = true;
		this.bool_1 = true;
		this.int_0 = 0;
		this.bool_2 = true;
	}

	// Token: 0x0600070E RID: 1806 RVA: 0x000060CA File Offset: 0x000042CA
	public Class13(byte[] byte_1) : this(byte_1, true)
	{
	}

	// Token: 0x0600070F RID: 1807 RVA: 0x0003C04C File Offset: 0x0003A24C
	public Class13(byte[] byte_1, bool bool_4)
	{
		if (byte_1 == null)
		{
			throw new ArgumentNullException();
		}
		this.byte_0 = byte_1;
		this.int_2 = (this.int_3 = byte_1.Length);
		this.bool_1 = bool_4;
		this.int_0 = 0;
		this.bool_2 = true;
	}

	// Token: 0x06000710 RID: 1808 RVA: 0x000060D4 File Offset: 0x000042D4
	public Class13(byte[] byte_1, int int_4, int int_5) : this(byte_1, int_4, int_5, true)
	{
	}

	// Token: 0x06000711 RID: 1809 RVA: 0x0003C098 File Offset: 0x0003A298
	public Class13(byte[] byte_1, int int_4, int int_5, bool bool_4)
	{
		if (byte_1 == null)
		{
			throw new ArgumentNullException();
		}
		if (int_4 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (int_5 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (byte_1.Length - int_4 < int_5)
		{
			throw new ArgumentException();
		}
		this.byte_0 = byte_1;
		this.int_1 = int_4;
		this.int_0 = int_4;
		this.int_2 = (this.int_3 = int_4 + int_5);
		this.bool_1 = bool_4;
		this.bool_0 = false;
		this.bool_2 = true;
	}

	// Token: 0x06000712 RID: 1810 RVA: 0x000060E0 File Offset: 0x000042E0
	public override bool vmethod_0()
	{
		return this.bool_2;
	}

	// Token: 0x06000713 RID: 1811 RVA: 0x000060E0 File Offset: 0x000042E0
	public override bool vmethod_2()
	{
		return this.bool_2;
	}

	// Token: 0x06000714 RID: 1812 RVA: 0x000060E8 File Offset: 0x000042E8
	public override bool vmethod_1()
	{
		return this.bool_1;
	}

	// Token: 0x06000715 RID: 1813 RVA: 0x000060F0 File Offset: 0x000042F0
	protected override void vmethod_7(bool bool_4)
	{
		if (!this.bool_3)
		{
			if (bool_4)
			{
				this.bool_2 = false;
				this.bool_1 = false;
				this.bool_0 = false;
			}
			this.bool_3 = true;
		}
	}

	// Token: 0x06000716 RID: 1814 RVA: 0x0003C118 File Offset: 0x0003A318
	private bool method_0(int int_4)
	{
		if (int_4 < 0)
		{
			throw new IOException();
		}
		if (int_4 > this.int_3)
		{
			int num = int_4;
			if (num < 256)
			{
				num = 256;
			}
			if (num < this.int_3 * 2)
			{
				num = this.int_3 * 2;
			}
			this.method_6(num);
			return true;
		}
		return false;
	}

	// Token: 0x06000717 RID: 1815 RVA: 0x00002D6B File Offset: 0x00000F6B
	public override void vmethod_8()
	{
	}

	// Token: 0x06000718 RID: 1816 RVA: 0x00006119 File Offset: 0x00004319
	internal byte[] method_1()
	{
		return this.byte_0;
	}

	// Token: 0x06000719 RID: 1817 RVA: 0x00006121 File Offset: 0x00004321
	internal void method_2(out int int_4, out int int_5)
	{
		if (!this.bool_2)
		{
			throw new Exception();
		}
		int_4 = this.int_0;
		int_5 = this.int_2;
	}

	// Token: 0x0600071A RID: 1818 RVA: 0x00006141 File Offset: 0x00004341
	internal int method_3()
	{
		if (!this.bool_2)
		{
			throw new Exception();
		}
		return this.int_1;
	}

	// Token: 0x0600071B RID: 1819 RVA: 0x0003C168 File Offset: 0x0003A368
	public int method_4(int int_4)
	{
		if (!this.bool_2)
		{
			throw new Exception();
		}
		int num = this.int_2 - this.int_1;
		if (num > int_4)
		{
			num = int_4;
		}
		if (num < 0)
		{
			num = 0;
		}
		this.int_1 += num;
		return num;
	}

	// Token: 0x0600071C RID: 1820 RVA: 0x00006157 File Offset: 0x00004357
	public int method_5()
	{
		if (!this.bool_2)
		{
			throw new Exception();
		}
		return this.int_3 - this.int_0;
	}

	// Token: 0x0600071D RID: 1821 RVA: 0x0003C1AC File Offset: 0x0003A3AC
	public void method_6(int int_4)
	{
		if (!this.bool_2)
		{
			throw new Exception();
		}
		if (int_4 != this.int_3)
		{
			if (!this.bool_0)
			{
				throw new Exception();
			}
			if (int_4 < this.int_2)
			{
				throw new ArgumentOutOfRangeException();
			}
			if (int_4 > 0)
			{
				byte[] dst = new byte[int_4];
				if (this.int_2 > 0)
				{
					Buffer.BlockCopy(this.byte_0, 0, dst, 0, this.int_2);
				}
				this.byte_0 = dst;
			}
			else
			{
				this.byte_0 = null;
			}
			this.int_3 = int_4;
		}
	}

	// Token: 0x0600071E RID: 1822 RVA: 0x00006174 File Offset: 0x00004374
	public override long vmethod_3()
	{
		if (!this.bool_2)
		{
			throw new Exception();
		}
		return (long)(this.int_2 - this.int_0);
	}

	// Token: 0x0600071F RID: 1823 RVA: 0x00006192 File Offset: 0x00004392
	public override long vmethod_4()
	{
		if (!this.bool_2)
		{
			throw new Exception();
		}
		return (long)(this.int_1 - this.int_0);
	}

	// Token: 0x06000720 RID: 1824 RVA: 0x0003C22C File Offset: 0x0003A42C
	public override void vmethod_5(long long_0)
	{
		if (!this.bool_2)
		{
			throw new Exception();
		}
		if (long_0 < 0L)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (long_0 > 2147483647L)
		{
			throw new ArgumentOutOfRangeException();
		}
		this.int_1 = this.int_0 + (int)long_0;
	}

	// Token: 0x06000721 RID: 1825 RVA: 0x0003C27C File Offset: 0x0003A47C
	public override int vmethod_11(byte[] byte_1, int int_4, int int_5)
	{
		if (!this.bool_2)
		{
			throw new Exception();
		}
		if (byte_1 == null)
		{
			throw new ArgumentNullException();
		}
		if (int_4 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (int_5 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (byte_1.Length - int_4 < int_5)
		{
			throw new ArgumentException();
		}
		int num = this.int_2 - this.int_1;
		if (num > int_5)
		{
			num = int_5;
		}
		if (num <= 0)
		{
			return 0;
		}
		if (num <= 8)
		{
			int num2 = num;
			while (--num2 >= 0)
			{
				byte_1[int_4 + num2] = this.byte_0[this.int_1 + num2];
			}
		}
		else
		{
			Buffer.BlockCopy(this.byte_0, this.int_1, byte_1, int_4, num);
		}
		this.int_1 += num;
		return num;
	}

	// Token: 0x06000722 RID: 1826 RVA: 0x0003C328 File Offset: 0x0003A528
	public override int vmethod_12()
	{
		if (!this.bool_2)
		{
			throw new Exception();
		}
		if (this.int_1 >= this.int_2)
		{
			return -1;
		}
		byte[] array = this.byte_0;
		int num = this.int_1;
		this.int_1 = num + 1;
		return array[num];
	}

	// Token: 0x06000723 RID: 1827 RVA: 0x0003C36C File Offset: 0x0003A56C
	public override long vmethod_9(long long_0, int int_4)
	{
		if (!this.bool_2)
		{
			throw new Exception();
		}
		if (long_0 > 2147483647L)
		{
			throw new ArgumentOutOfRangeException();
		}
		switch (int_4)
		{
		case 0:
			if (long_0 < 0L)
			{
				throw new IOException();
			}
			this.int_1 = this.int_0 + (int)long_0;
			break;
		case 1:
			if (long_0 + (long)this.int_1 < (long)this.int_0)
			{
				throw new IOException();
			}
			this.int_1 += (int)long_0;
			break;
		case 2:
			if ((long)this.int_2 + long_0 < (long)this.int_0)
			{
				throw new IOException();
			}
			this.int_1 = this.int_2 + (int)long_0;
			break;
		default:
			throw new ArgumentException();
		}
		return (long)this.int_1;
	}

	// Token: 0x06000724 RID: 1828 RVA: 0x0003C42C File Offset: 0x0003A62C
	public override void vmethod_10(long long_0)
	{
		if (!this.bool_1)
		{
			throw new Exception();
		}
		if (long_0 > 2147483647L)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (long_0 >= 0L && long_0 <= (long)(2147483647 - this.int_0))
		{
			int num = this.int_0 + (int)long_0;
			if (!this.method_0(num) && num > this.int_2)
			{
				Array.Clear(this.byte_0, this.int_2, num - this.int_2);
			}
			this.int_2 = num;
			if (this.int_1 > num)
			{
				this.int_1 = num;
			}
			return;
		}
		throw new ArgumentOutOfRangeException();
	}

	// Token: 0x06000725 RID: 1829 RVA: 0x0003C4CC File Offset: 0x0003A6CC
	public byte[] method_7()
	{
		byte[] array = new byte[this.int_2 - this.int_0];
		Buffer.BlockCopy(this.byte_0, this.int_0, array, 0, this.int_2 - this.int_0);
		return array;
	}

	// Token: 0x06000726 RID: 1830 RVA: 0x0003C510 File Offset: 0x0003A710
	public override void vmethod_13(byte[] byte_1, int int_4, int int_5)
	{
		if (!this.bool_2)
		{
			throw new Exception();
		}
		if (!this.bool_1)
		{
			throw new Exception();
		}
		if (byte_1 == null)
		{
			throw new ArgumentNullException();
		}
		if (int_4 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (int_5 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (byte_1.Length - int_4 < int_5)
		{
			throw new ArgumentException();
		}
		int num = this.int_1 + int_5;
		if (num < 0)
		{
			throw new IOException();
		}
		if (num > this.int_2)
		{
			bool flag = this.int_1 > this.int_2;
			if (num > this.int_3 && this.method_0(num))
			{
				flag = false;
			}
			if (flag)
			{
				Array.Clear(this.byte_0, this.int_2, num - this.int_2);
			}
			this.int_2 = num;
		}
		if (int_5 <= 8)
		{
			int num2 = int_5;
			while (--num2 >= 0)
			{
				this.byte_0[this.int_1 + num2] = byte_1[int_4 + num2];
			}
		}
		else
		{
			Buffer.BlockCopy(byte_1, int_4, this.byte_0, this.int_1, int_5);
		}
		this.int_1 = num;
	}

	// Token: 0x06000727 RID: 1831 RVA: 0x0003C608 File Offset: 0x0003A808
	public override void vmethod_14(byte byte_1)
	{
		if (!this.bool_2)
		{
			throw new Exception();
		}
		if (!this.bool_1)
		{
			throw new Exception();
		}
		if (this.int_1 >= this.int_2)
		{
			int num = this.int_1 + 1;
			bool flag = this.int_1 > this.int_2;
			if (num >= this.int_3 && this.method_0(num))
			{
				flag = false;
			}
			if (flag)
			{
				Array.Clear(this.byte_0, this.int_2, this.int_1 - this.int_2);
			}
			this.int_2 = num;
		}
		byte[] array = this.byte_0;
		int num2 = this.int_1;
		this.int_1 = num2 + 1;
		array[num2] = byte_1;
	}

	// Token: 0x06000728 RID: 1832 RVA: 0x000061B0 File Offset: 0x000043B0
	public void method_8(Stream stream_0)
	{
		if (!this.bool_2)
		{
			throw new Exception();
		}
		if (stream_0 == null)
		{
			throw new ArgumentNullException();
		}
		stream_0.Write(this.byte_0, this.int_0, this.int_2 - this.int_0);
	}

	// Token: 0x06000729 RID: 1833 RVA: 0x0003C6AC File Offset: 0x0003A8AC
	internal int method_9()
	{
		if (!this.bool_2)
		{
			throw new Exception();
		}
		int num = this.int_1 += 4;
		if (num > this.int_2)
		{
			this.int_1 = this.int_2;
			throw new Exception();
		}
		return (int)this.byte_0[num - 4] << 8 | (int)this.byte_0[num - 3] | (int)this.byte_0[num - 1] << 16 | (int)this.byte_0[num - 2] << 24;
	}

	// Token: 0x04000589 RID: 1417
	private byte[] byte_0;

	// Token: 0x0400058A RID: 1418
	private int int_0;

	// Token: 0x0400058B RID: 1419
	private int int_1;

	// Token: 0x0400058C RID: 1420
	private int int_2;

	// Token: 0x0400058D RID: 1421
	private int int_3;

	// Token: 0x0400058E RID: 1422
	private bool bool_0;

	// Token: 0x0400058F RID: 1423
	private bool bool_1;

	// Token: 0x04000590 RID: 1424
	private bool bool_2;

	// Token: 0x04000591 RID: 1425
	private bool bool_3;
}
