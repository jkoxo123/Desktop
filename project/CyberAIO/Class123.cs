using System;
using System.IO;
using System.Text;

// Token: 0x020000D0 RID: 208
internal sealed class Class123 : IDisposable
{
	// Token: 0x060004E4 RID: 1252 RVA: 0x00004F9A File Offset: 0x0000319A
	public Class123(Class11 class11_1) : this(class11_1, new UTF8Encoding())
	{
	}

	// Token: 0x060004E5 RID: 1253 RVA: 0x000290B8 File Offset: 0x000272B8
	private Class123(Class11 class11_1, Encoding encoding_0)
	{
		if (class11_1 == null)
		{
			throw new ArgumentNullException();
		}
		if (encoding_0 == null)
		{
			throw new ArgumentNullException();
		}
		if (!class11_1.vmethod_0())
		{
			throw new ArgumentException();
		}
		this.class11_0 = class11_1;
		this.decoder_0 = encoding_0.GetDecoder();
		this.int_0 = encoding_0.GetMaxCharCount(128);
		int num = encoding_0.GetMaxByteCount(1);
		if (num < 16)
		{
			num = 16;
		}
		this.byte_0 = new byte[num];
		this.char_1 = null;
		this.byte_1 = null;
		this.bool_0 = (encoding_0 is UnicodeEncoding);
		this.bool_1 = (this.class11_0 is Class13);
	}

	// Token: 0x060004E6 RID: 1254 RVA: 0x00004FA8 File Offset: 0x000031A8
	public Class11 method_0()
	{
		return this.class11_0;
	}

	// Token: 0x060004E7 RID: 1255 RVA: 0x00004FB0 File Offset: 0x000031B0
	public void method_1()
	{
		this.method_2(true);
	}

	// Token: 0x060004E8 RID: 1256 RVA: 0x0002915C File Offset: 0x0002735C
	private void method_2(bool bool_2)
	{
		if (bool_2)
		{
			Class11 @class = this.class11_0;
			this.class11_0 = null;
			if (@class != null)
			{
				@class.vmethod_6();
			}
		}
		this.class11_0 = null;
		this.byte_0 = null;
		this.decoder_0 = null;
		this.byte_1 = null;
		this.char_0 = null;
		this.char_1 = null;
	}

	// Token: 0x060004E9 RID: 1257 RVA: 0x00004FB0 File Offset: 0x000031B0
	void IDisposable.Dispose()
	{
		this.method_2(true);
	}

	// Token: 0x060004EA RID: 1258 RVA: 0x000291B0 File Offset: 0x000273B0
	public int method_3()
	{
		this.method_15();
		if (!this.class11_0.vmethod_2())
		{
			return -1;
		}
		long long_ = this.class11_0.vmethod_4();
		int result = this.method_4();
		this.class11_0.vmethod_5(long_);
		return result;
	}

	// Token: 0x060004EB RID: 1259 RVA: 0x00004FB9 File Offset: 0x000031B9
	public int method_4()
	{
		this.method_15();
		return this.method_12();
	}

	// Token: 0x060004EC RID: 1260 RVA: 0x00004FC7 File Offset: 0x000031C7
	public bool method_5()
	{
		this.method_17(1);
		return this.byte_0[0] > 0;
	}

	// Token: 0x060004ED RID: 1261 RVA: 0x00004FDB File Offset: 0x000031DB
	public byte method_6()
	{
		this.method_15();
		int num = this.class11_0.vmethod_12();
		if (num == -1)
		{
			throw new Exception();
		}
		return (byte)num;
	}

	// Token: 0x060004EE RID: 1262 RVA: 0x00004FF9 File Offset: 0x000031F9
	public sbyte method_7()
	{
		this.method_17(1);
		return (sbyte)this.byte_0[0];
	}

	// Token: 0x060004EF RID: 1263 RVA: 0x0000500B File Offset: 0x0000320B
	public char method_8()
	{
		int num = this.method_4();
		if (num == -1)
		{
			throw new Exception();
		}
		return (char)num;
	}

	// Token: 0x060004F0 RID: 1264 RVA: 0x000291F0 File Offset: 0x000273F0
	private static decimal smethod_0(int int_1, int int_2, int int_3, int int_4)
	{
		bool isNegative = (int_4 & int.MinValue) != 0;
		byte scale = (byte)(int_4 >> 16);
		return new decimal(int_1, int_2, int_3, isNegative, scale);
	}

	// Token: 0x060004F1 RID: 1265 RVA: 0x00029218 File Offset: 0x00027418
	internal static decimal smethod_1(byte[] byte_3)
	{
		int int_ = (int)byte_3[0] | (int)byte_3[1] << 8 | (int)byte_3[2] << 16 | (int)byte_3[3] << 24;
		int int_2 = (int)byte_3[4] | (int)byte_3[5] << 8 | (int)byte_3[6] << 16 | (int)byte_3[7] << 24;
		int int_3 = (int)byte_3[8] | (int)byte_3[9] << 8 | (int)byte_3[10] << 16 | (int)byte_3[11] << 24;
		int int_4 = (int)byte_3[12] | (int)byte_3[13] << 8 | (int)byte_3[14] << 16 | (int)byte_3[15] << 24;
		return Class123.smethod_0(int_, int_2, int_3, int_4);
	}

	// Token: 0x060004F2 RID: 1266 RVA: 0x00029294 File Offset: 0x00027494
	public string method_9()
	{
		int num = 0;
		this.method_15();
		int num2 = this.method_18();
		if (num2 < 0)
		{
			throw new IOException();
		}
		if (num2 == 0)
		{
			return string.Empty;
		}
		if (this.byte_1 == null)
		{
			this.byte_1 = new byte[128];
		}
		if (this.char_1 == null)
		{
			this.char_1 = new char[this.int_0];
		}
		StringBuilder stringBuilder = null;
		int chars;
		for (;;)
		{
			int int_ = (num2 - num > 128) ? 128 : (num2 - num);
			int num3 = this.class11_0.vmethod_11(this.byte_1, 0, int_);
			if (num3 == 0)
			{
				goto IL_D0;
			}
			chars = this.decoder_0.GetChars(this.byte_1, 0, num3, this.char_1, 0);
			if (num == 0 && num3 == num2)
			{
				break;
			}
			if (stringBuilder == null)
			{
				stringBuilder = new StringBuilder(num2);
			}
			stringBuilder.Append(this.char_1, 0, chars);
			num += num3;
			if (num >= num2)
			{
				goto Block_9;
			}
		}
		return new string(this.char_1, 0, chars);
		Block_9:
		return stringBuilder.ToString();
		IL_D0:
		throw new Exception();
	}

	// Token: 0x060004F3 RID: 1267 RVA: 0x0002938C File Offset: 0x0002758C
	public int method_10(char[] char_2, int int_1, int int_2)
	{
		if (char_2 == null)
		{
			throw new ArgumentNullException("\u0002", "ArgumentNull_Buffer");
		}
		if (int_1 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (int_2 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (char_2.Length - int_1 < int_2)
		{
			throw new ArgumentException();
		}
		this.method_15();
		return this.method_11(char_2, int_1, int_2);
	}

	// Token: 0x060004F4 RID: 1268 RVA: 0x000293E0 File Offset: 0x000275E0
	private int method_11(char[] char_2, int int_1, int int_2)
	{
		int i = int_2;
		if (this.byte_1 == null)
		{
			this.byte_1 = new byte[128];
		}
		while (i > 0)
		{
			int num = i;
			if (this.bool_0)
			{
				num <<= 1;
			}
			if (num > 128)
			{
				num = 128;
			}
			int chars;
			if (this.bool_1)
			{
				Class13 @class = (Class13)this.class11_0;
				int byteIndex = @class.method_3();
				num = @class.method_4(num);
				if (num == 0)
				{
					return int_2 - i;
				}
				chars = this.decoder_0.GetChars(@class.method_1(), byteIndex, num, char_2, int_1);
			}
			else
			{
				num = this.class11_0.vmethod_11(this.byte_1, 0, num);
				if (num == 0)
				{
					return int_2 - i;
				}
				chars = this.decoder_0.GetChars(this.byte_1, 0, num, char_2, int_1);
			}
			i -= chars;
			int_1 += chars;
		}
		return int_2;
	}

	// Token: 0x060004F5 RID: 1269 RVA: 0x000294B8 File Offset: 0x000276B8
	private int method_12()
	{
		int num = 0;
		long num2 = 0L;
		long num3 = 0L;
		num3 = num2;
		if (this.class11_0.vmethod_2())
		{
			num3 = this.class11_0.vmethod_4();
		}
		if (this.byte_1 == null)
		{
			this.byte_1 = new byte[128];
		}
		if (this.char_0 == null)
		{
			this.char_0 = new char[1];
		}
		while (num == 0)
		{
			int num4 = this.bool_0 ? 2 : 1;
			int num5 = this.class11_0.vmethod_12();
			this.byte_1[0] = (byte)num5;
			if (num5 == -1)
			{
				num4 = 0;
			}
			if (num4 == 2)
			{
				num5 = this.class11_0.vmethod_12();
				this.byte_1[1] = (byte)num5;
				if (num5 == -1)
				{
					num4 = 1;
				}
			}
			if (num4 == 0)
			{
				return -1;
			}
			try
			{
				num = this.decoder_0.GetChars(this.byte_1, 0, num4, this.char_0, 0);
			}
			catch
			{
				if (this.class11_0.vmethod_2())
				{
					this.class11_0.vmethod_9(num3 - this.class11_0.vmethod_4(), 1);
				}
				throw;
			}
		}
		if (num == 0)
		{
			return -1;
		}
		return (int)this.char_0[0];
	}

	// Token: 0x060004F6 RID: 1270 RVA: 0x000295E4 File Offset: 0x000277E4
	public char[] method_13(int int_1)
	{
		this.method_15();
		if (int_1 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		char[] array = new char[int_1];
		int num = this.method_11(array, 0, int_1);
		if (num != int_1)
		{
			char[] array2 = new char[num];
			Buffer.BlockCopy(array, 0, array2, 0, 2 * num);
			array = array2;
		}
		return array;
	}

	// Token: 0x060004F7 RID: 1271 RVA: 0x0002962C File Offset: 0x0002782C
	public int method_14(byte[] byte_3, int int_1, int int_2)
	{
		if (byte_3 == null)
		{
			throw new ArgumentNullException();
		}
		if (int_1 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (int_2 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (byte_3.Length - int_1 < int_2)
		{
			throw new ArgumentException();
		}
		this.method_15();
		return this.class11_0.vmethod_11(byte_3, int_1, int_2);
	}

	// Token: 0x060004F8 RID: 1272 RVA: 0x0000501E File Offset: 0x0000321E
	private void method_15()
	{
		if (this.class11_0 == null)
		{
			throw new Exception();
		}
	}

	// Token: 0x060004F9 RID: 1273 RVA: 0x00029678 File Offset: 0x00027878
	public byte[] method_16(int int_1)
	{
		if (int_1 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		this.method_15();
		byte[] array = new byte[int_1];
		int num = 0;
		do
		{
			int num2 = this.class11_0.vmethod_11(array, num, int_1);
			if (num2 == 0)
			{
				break;
			}
			num += num2;
			int_1 -= num2;
		}
		while (int_1 > 0);
		if (num != array.Length)
		{
			byte[] array2 = new byte[num];
			Buffer.BlockCopy(array, 0, array2, 0, num);
			array = array2;
		}
		return array;
	}

	// Token: 0x060004FA RID: 1274 RVA: 0x000296DC File Offset: 0x000278DC
	private void method_17(int int_1)
	{
		this.method_15();
		int num = 0;
		int num2;
		if (int_1 != 1)
		{
			for (;;)
			{
				num2 = this.class11_0.vmethod_11(this.byte_0, num, int_1 - num);
				if (num2 == 0)
				{
					break;
				}
				num += num2;
				if (num >= int_1)
				{
					return;
				}
			}
			throw new Exception();
		}
		num2 = this.class11_0.vmethod_12();
		if (num2 == -1)
		{
			throw new Exception();
		}
		this.byte_0[0] = (byte)num2;
	}

	// Token: 0x060004FB RID: 1275 RVA: 0x00029740 File Offset: 0x00027940
	internal int method_18()
	{
		int num = 0;
		int num2 = 0;
		while (num2 != 35)
		{
			byte b = this.method_6();
			num |= (int)(b & 127) << num2;
			num2 += 7;
			if ((b & 128) == 0)
			{
				return num;
			}
		}
		throw new FormatException();
	}

	// Token: 0x060004FC RID: 1276 RVA: 0x00029780 File Offset: 0x00027980
	public int method_19()
	{
		if (this.bool_1)
		{
			return ((Class13)this.class11_0).method_9();
		}
		this.method_17(4);
		return (int)this.byte_0[2] << 24 | (int)this.byte_0[0] << 8 | (int)this.byte_0[1] | (int)this.byte_0[3] << 16;
	}

	// Token: 0x060004FD RID: 1277 RVA: 0x0000502E File Offset: 0x0000322E
	public uint method_20()
	{
		this.method_17(4);
		return (uint)((int)this.byte_0[1] << 24 | (int)this.byte_0[0] << 8 | (int)this.byte_0[3] | (int)this.byte_0[2] << 16);
	}

	// Token: 0x060004FE RID: 1278 RVA: 0x000297D8 File Offset: 0x000279D8
	public long method_21()
	{
		this.method_17(8);
		byte[] array = this.byte_0;
		return (long)((ulong)((int)array[3] | (int)array[4] << 24 | (int)array[7] << 8 | (int)array[6] << 16) | (ulong)((ulong)((long)((int)array[0] << 8 | (int)array[2] | (int)array[1] << 24 | (int)array[5] << 16)) << 32));
	}

	// Token: 0x060004FF RID: 1279 RVA: 0x00029828 File Offset: 0x00027A28
	public ulong method_22()
	{
		this.method_17(8);
		byte[] array = this.byte_0;
		return (ulong)((int)array[2] << 8 | (int)array[4] << 16 | (int)array[1] | (int)array[0] << 24) | (ulong)((ulong)((long)((int)array[6] << 16 | (int)array[7] << 8 | (int)array[5] << 24 | (int)array[3])) << 32);
	}

	// Token: 0x06000500 RID: 1280 RVA: 0x00029878 File Offset: 0x00027A78
	public short method_23()
	{
		this.method_17(2);
		byte[] array = this.byte_0;
		return (short)((int)array[0] | (int)array[1] << 8);
	}

	// Token: 0x06000501 RID: 1281 RVA: 0x000298A0 File Offset: 0x00027AA0
	public ushort method_24()
	{
		this.method_17(2);
		byte[] array = this.byte_0;
		return (ushort)((int)array[0] << 8 | (int)array[1]);
	}

	// Token: 0x06000502 RID: 1282 RVA: 0x000298C8 File Offset: 0x00027AC8
	private byte[] method_25()
	{
		byte[] array = this.byte_2;
		if (array == null)
		{
			array = (this.byte_2 = new byte[16]);
		}
		return array;
	}

	// Token: 0x06000503 RID: 1283 RVA: 0x000298F0 File Offset: 0x00027AF0
	public float method_26()
	{
		this.method_17(4);
		byte[] array = this.byte_0;
		byte[] array2 = this.method_25();
		array2[3] = array[0];
		array2[1] = array[1];
		array2[0] = array[2];
		array2[2] = array[3];
		return this.method_29(array2).ReadSingle();
	}

	// Token: 0x06000504 RID: 1284 RVA: 0x00029938 File Offset: 0x00027B38
	public double method_27()
	{
		this.method_17(8);
		byte[] array = this.byte_0;
		byte[] array2 = this.method_25();
		array2[2] = array[0];
		array2[5] = array[2];
		array2[6] = array[4];
		array2[4] = array[6];
		array2[1] = array[3];
		array2[0] = array[5];
		array2[7] = array[1];
		array2[3] = array[7];
		return this.method_29(array2).ReadDouble();
	}

	// Token: 0x06000505 RID: 1285 RVA: 0x00029998 File Offset: 0x00027B98
	public decimal method_28()
	{
		this.method_17(16);
		byte[] array = this.byte_0;
		byte[] array2 = this.method_25();
		array2[5] = array[7];
		array2[15] = array[4];
		array2[10] = array[10];
		array2[7] = array[13];
		array2[9] = array[5];
		array2[8] = array[6];
		array2[3] = array[14];
		array2[2] = array[2];
		array2[4] = array[11];
		array2[6] = array[12];
		array2[13] = array[1];
		array2[12] = array[0];
		array2[0] = array[9];
		array2[11] = array[8];
		array2[1] = array[15];
		array2[14] = array[3];
		return Class123.smethod_1(array2);
	}

	// Token: 0x06000506 RID: 1286 RVA: 0x00029A30 File Offset: 0x00027C30
	private BinaryReader method_29(byte[] byte_3)
	{
		MemoryStream memoryStream = this.memoryStream_0;
		BinaryReader binaryReader = this.binaryReader_0;
		if (memoryStream == null)
		{
			memoryStream = (this.memoryStream_0 = new MemoryStream(8));
			binaryReader = (this.binaryReader_0 = new BinaryReader(memoryStream));
		}
		else
		{
			binaryReader.BaseStream.Position = 0L;
		}
		memoryStream.Write(byte_3, 0, byte_3.Length);
		memoryStream.Position = 0L;
		return binaryReader;
	}

	// Token: 0x0400035E RID: 862
	private Class11 class11_0;

	// Token: 0x0400035F RID: 863
	private byte[] byte_0;

	// Token: 0x04000360 RID: 864
	private Decoder decoder_0;

	// Token: 0x04000361 RID: 865
	private byte[] byte_1;

	// Token: 0x04000362 RID: 866
	private char[] char_0;

	// Token: 0x04000363 RID: 867
	private char[] char_1;

	// Token: 0x04000364 RID: 868
	private int int_0;

	// Token: 0x04000365 RID: 869
	private bool bool_0;

	// Token: 0x04000366 RID: 870
	private bool bool_1;

	// Token: 0x04000367 RID: 871
	private byte[] byte_2;

	// Token: 0x04000368 RID: 872
	private MemoryStream memoryStream_0;

	// Token: 0x04000369 RID: 873
	private BinaryReader binaryReader_0;
}
