using System;

// Token: 0x0200011A RID: 282
internal sealed class Class151 : Interface1
{
	// Token: 0x06000643 RID: 1603 RVA: 0x00005949 File Offset: 0x00003B49
	private uint method_0(uint uint_7, int int_1)
	{
		return uint_7 >> int_1 | uint_7 << 32 - int_1;
	}

	// Token: 0x06000644 RID: 1604 RVA: 0x0000595B File Offset: 0x00003B5B
	private uint method_1(uint uint_7)
	{
		return (uint_7 & 2139062143u) << 1 ^ ((uint_7 & 2155905152u) >> 7) * 27u;
	}

	// Token: 0x06000645 RID: 1605 RVA: 0x000371BC File Offset: 0x000353BC
	private uint method_2(uint uint_7)
	{
		uint num = this.method_1(uint_7);
		uint num2 = this.method_1(num);
		uint num3 = this.method_1(num2);
		uint num4 = uint_7 ^ num3;
		return num ^ num2 ^ num3 ^ this.method_0(num ^ num4, 8) ^ this.method_0(num2 ^ num4, 16) ^ this.method_0(num4, 24);
	}

	// Token: 0x06000646 RID: 1606 RVA: 0x0003720C File Offset: 0x0003540C
	private uint method_3(uint uint_7)
	{
		return (uint)((int)Class151.byte_0[(int)(uint_7 & 255u)] | (int)Class151.byte_0[(int)(uint_7 >> 8 & 255u)] << 8 | (int)Class151.byte_0[(int)(uint_7 >> 16 & 255u)] << 16 | (int)Class151.byte_0[(int)(uint_7 >> 24 & 255u)] << 24);
	}

	// Token: 0x06000647 RID: 1607 RVA: 0x00037260 File Offset: 0x00035460
	private uint[,] method_4(byte[] byte_3, bool bool_1)
	{
		int num = byte_3.Length / 4;
		if (num != 4 && num != 6 && num != 8)
		{
			throw new ArgumentException("Key length not 128/192/256 bits.");
		}
		this.int_0 = num + 6;
		uint[,] array = new uint[this.int_0 + 1, 4];
		int num2 = 0;
		int i = 0;
		while (i < byte_3.Length)
		{
			array[num2 >> 2, num2 & 3] = Class129.smethod_1(byte_3, i);
			i += 4;
			num2++;
		}
		int num3 = this.int_0 + 1 << 2;
		for (int j = num; j < num3; j++)
		{
			uint num4 = array[j - 1 >> 2, j - 1 & 3];
			if (j % num == 0)
			{
				num4 = (this.method_3(this.method_0(num4, 8)) ^ (uint)Class151.byte_2[j / num - 1]);
			}
			else if (num > 6 && j % num == 4)
			{
				num4 = this.method_3(num4);
			}
			array[j >> 2, j & 3] = (array[j - num >> 2, j - num & 3] ^ num4);
		}
		if (!bool_1)
		{
			for (int k = 1; k < this.int_0; k++)
			{
				for (int l = 0; l < 4; l++)
				{
					array[k, l] = this.method_2(array[k, l]);
				}
			}
		}
		return array;
	}

	// Token: 0x06000648 RID: 1608 RVA: 0x00037394 File Offset: 0x00035594
	public void imethod_1(bool bool_1, Interface6 interface6_0)
	{
		Class188 @class = interface6_0 as Class188;
		if (@class == null)
		{
			throw new ArgumentException("invalid parameter passed to AES init - " + interface6_0.GetType().Name);
		}
		this.uint_2 = this.method_4(@class.method_0(), bool_1);
		this.bool_0 = bool_1;
	}

	// Token: 0x06000649 RID: 1609 RVA: 0x00005973 File Offset: 0x00003B73
	public string imethod_0()
	{
		return "AES";
	}

	// Token: 0x0600064A RID: 1610 RVA: 0x000030C0 File Offset: 0x000012C0
	public bool imethod_3()
	{
		return false;
	}

	// Token: 0x0600064B RID: 1611 RVA: 0x00002D67 File Offset: 0x00000F67
	public int imethod_2()
	{
		return 16;
	}

	// Token: 0x0600064C RID: 1612 RVA: 0x000373E0 File Offset: 0x000355E0
	public int imethod_4(byte[] byte_3, int int_1, byte[] byte_4, int int_2)
	{
		if (this.uint_2 == null)
		{
			throw new InvalidOperationException("AES engine not initialised");
		}
		if (int_1 + 16 > byte_3.Length)
		{
			throw new Exception2("input buffer too short");
		}
		if (int_2 + 16 > byte_4.Length)
		{
			throw new Exception2("output buffer too short");
		}
		this.method_5(byte_3, int_1);
		if (this.bool_0)
		{
			this.method_7(this.uint_2);
		}
		else
		{
			this.method_8(this.uint_2);
		}
		this.method_6(byte_4, int_2);
		return 16;
	}

	// Token: 0x0600064D RID: 1613 RVA: 0x00002D6B File Offset: 0x00000F6B
	public void imethod_5()
	{
	}

	// Token: 0x0600064E RID: 1614 RVA: 0x0000597A File Offset: 0x00003B7A
	private void method_5(byte[] byte_3, int int_1)
	{
		this.uint_3 = Class129.smethod_1(byte_3, int_1);
		this.uint_4 = Class129.smethod_1(byte_3, int_1 + 4);
		this.uint_5 = Class129.smethod_1(byte_3, int_1 + 8);
		this.uint_6 = Class129.smethod_1(byte_3, int_1 + 12);
	}

	// Token: 0x0600064F RID: 1615 RVA: 0x000059B7 File Offset: 0x00003BB7
	private void method_6(byte[] byte_3, int int_1)
	{
		Class129.smethod_0(this.uint_3, byte_3, int_1);
		Class129.smethod_0(this.uint_4, byte_3, int_1 + 4);
		Class129.smethod_0(this.uint_5, byte_3, int_1 + 8);
		Class129.smethod_0(this.uint_6, byte_3, int_1 + 12);
	}

	// Token: 0x06000650 RID: 1616 RVA: 0x00037460 File Offset: 0x00035660
	private void method_7(uint[,] uint_7)
	{
		this.uint_3 ^= uint_7[0, 0];
		this.uint_4 ^= uint_7[0, 1];
		this.uint_5 ^= uint_7[0, 2];
		this.uint_6 ^= uint_7[0, 3];
		uint num = 1u;
		uint num2;
		uint num3;
		uint num4;
		uint num5;
		while ((ulong)num < (ulong)((long)(this.int_0 - 1)))
		{
			num2 = (Class151.uint_0[(int)(this.uint_3 & 255u)] ^ this.method_0(Class151.uint_0[(int)(this.uint_4 >> 8 & 255u)], 24) ^ this.method_0(Class151.uint_0[(int)(this.uint_5 >> 16 & 255u)], 16) ^ this.method_0(Class151.uint_0[(int)(this.uint_6 >> 24 & 255u)], 8) ^ uint_7[(int)num, 0]);
			num3 = (Class151.uint_0[(int)(this.uint_4 & 255u)] ^ this.method_0(Class151.uint_0[(int)(this.uint_5 >> 8 & 255u)], 24) ^ this.method_0(Class151.uint_0[(int)(this.uint_6 >> 16 & 255u)], 16) ^ this.method_0(Class151.uint_0[(int)(this.uint_3 >> 24 & 255u)], 8) ^ uint_7[(int)num, 1]);
			num4 = (Class151.uint_0[(int)(this.uint_5 & 255u)] ^ this.method_0(Class151.uint_0[(int)(this.uint_6 >> 8 & 255u)], 24) ^ this.method_0(Class151.uint_0[(int)(this.uint_3 >> 16 & 255u)], 16) ^ this.method_0(Class151.uint_0[(int)(this.uint_4 >> 24 & 255u)], 8) ^ uint_7[(int)num, 2]);
			num5 = (Class151.uint_0[(int)(this.uint_6 & 255u)] ^ this.method_0(Class151.uint_0[(int)(this.uint_3 >> 8 & 255u)], 24) ^ this.method_0(Class151.uint_0[(int)(this.uint_4 >> 16 & 255u)], 16) ^ this.method_0(Class151.uint_0[(int)(this.uint_5 >> 24 & 255u)], 8) ^ uint_7[(int)num++, 3]);
			this.uint_3 = (Class151.uint_0[(int)(num2 & 255u)] ^ this.method_0(Class151.uint_0[(int)(num3 >> 8 & 255u)], 24) ^ this.method_0(Class151.uint_0[(int)(num4 >> 16 & 255u)], 16) ^ this.method_0(Class151.uint_0[(int)(num5 >> 24 & 255u)], 8) ^ uint_7[(int)num, 0]);
			this.uint_4 = (Class151.uint_0[(int)(num3 & 255u)] ^ this.method_0(Class151.uint_0[(int)(num4 >> 8 & 255u)], 24) ^ this.method_0(Class151.uint_0[(int)(num5 >> 16 & 255u)], 16) ^ this.method_0(Class151.uint_0[(int)(num2 >> 24 & 255u)], 8) ^ uint_7[(int)num, 1]);
			this.uint_5 = (Class151.uint_0[(int)(num4 & 255u)] ^ this.method_0(Class151.uint_0[(int)(num5 >> 8 & 255u)], 24) ^ this.method_0(Class151.uint_0[(int)(num2 >> 16 & 255u)], 16) ^ this.method_0(Class151.uint_0[(int)(num3 >> 24 & 255u)], 8) ^ uint_7[(int)num, 2]);
			this.uint_6 = (Class151.uint_0[(int)(num5 & 255u)] ^ this.method_0(Class151.uint_0[(int)(num2 >> 8 & 255u)], 24) ^ this.method_0(Class151.uint_0[(int)(num3 >> 16 & 255u)], 16) ^ this.method_0(Class151.uint_0[(int)(num4 >> 24 & 255u)], 8) ^ uint_7[(int)num++, 3]);
		}
		num2 = (Class151.uint_0[(int)(this.uint_3 & 255u)] ^ this.method_0(Class151.uint_0[(int)(this.uint_4 >> 8 & 255u)], 24) ^ this.method_0(Class151.uint_0[(int)(this.uint_5 >> 16 & 255u)], 16) ^ this.method_0(Class151.uint_0[(int)(this.uint_6 >> 24 & 255u)], 8) ^ uint_7[(int)num, 0]);
		num3 = (Class151.uint_0[(int)(this.uint_4 & 255u)] ^ this.method_0(Class151.uint_0[(int)(this.uint_5 >> 8 & 255u)], 24) ^ this.method_0(Class151.uint_0[(int)(this.uint_6 >> 16 & 255u)], 16) ^ this.method_0(Class151.uint_0[(int)(this.uint_3 >> 24 & 255u)], 8) ^ uint_7[(int)num, 1]);
		num4 = (Class151.uint_0[(int)(this.uint_5 & 255u)] ^ this.method_0(Class151.uint_0[(int)(this.uint_6 >> 8 & 255u)], 24) ^ this.method_0(Class151.uint_0[(int)(this.uint_3 >> 16 & 255u)], 16) ^ this.method_0(Class151.uint_0[(int)(this.uint_4 >> 24 & 255u)], 8) ^ uint_7[(int)num, 2]);
		num5 = (Class151.uint_0[(int)(this.uint_6 & 255u)] ^ this.method_0(Class151.uint_0[(int)(this.uint_3 >> 8 & 255u)], 24) ^ this.method_0(Class151.uint_0[(int)(this.uint_4 >> 16 & 255u)], 16) ^ this.method_0(Class151.uint_0[(int)(this.uint_5 >> 24 & 255u)], 8) ^ uint_7[(int)num++, 3]);
		this.uint_3 = (uint)((int)Class151.byte_0[(int)(num2 & 255u)] ^ (int)Class151.byte_0[(int)(num3 >> 8 & 255u)] << 8 ^ (int)Class151.byte_0[(int)(num4 >> 16 & 255u)] << 16 ^ (int)Class151.byte_0[(int)(num5 >> 24 & 255u)] << 24 ^ (int)uint_7[(int)num, 0]);
		this.uint_4 = (uint)((int)Class151.byte_0[(int)(num3 & 255u)] ^ (int)Class151.byte_0[(int)(num4 >> 8 & 255u)] << 8 ^ (int)Class151.byte_0[(int)(num5 >> 16 & 255u)] << 16 ^ (int)Class151.byte_0[(int)(num2 >> 24 & 255u)] << 24 ^ (int)uint_7[(int)num, 1]);
		this.uint_5 = (uint)((int)Class151.byte_0[(int)(num4 & 255u)] ^ (int)Class151.byte_0[(int)(num5 >> 8 & 255u)] << 8 ^ (int)Class151.byte_0[(int)(num2 >> 16 & 255u)] << 16 ^ (int)Class151.byte_0[(int)(num3 >> 24 & 255u)] << 24 ^ (int)uint_7[(int)num, 2]);
		this.uint_6 = (uint)((int)Class151.byte_0[(int)(num5 & 255u)] ^ (int)Class151.byte_0[(int)(num2 >> 8 & 255u)] << 8 ^ (int)Class151.byte_0[(int)(num3 >> 16 & 255u)] << 16 ^ (int)Class151.byte_0[(int)(num4 >> 24 & 255u)] << 24 ^ (int)uint_7[(int)num, 3]);
	}

	// Token: 0x06000651 RID: 1617 RVA: 0x00037B7C File Offset: 0x00035D7C
	private void method_8(uint[,] uint_7)
	{
		this.uint_3 ^= uint_7[this.int_0, 0];
		this.uint_4 ^= uint_7[this.int_0, 1];
		this.uint_5 ^= uint_7[this.int_0, 2];
		this.uint_6 ^= uint_7[this.int_0, 3];
		int i = this.int_0 - 1;
		uint num;
		uint num2;
		uint num3;
		uint num4;
		while (i > 1)
		{
			num = (Class151.uint_1[(int)(this.uint_3 & 255u)] ^ this.method_0(Class151.uint_1[(int)(this.uint_6 >> 8 & 255u)], 24) ^ this.method_0(Class151.uint_1[(int)(this.uint_5 >> 16 & 255u)], 16) ^ this.method_0(Class151.uint_1[(int)(this.uint_4 >> 24 & 255u)], 8) ^ uint_7[i, 0]);
			num2 = (Class151.uint_1[(int)(this.uint_4 & 255u)] ^ this.method_0(Class151.uint_1[(int)(this.uint_3 >> 8 & 255u)], 24) ^ this.method_0(Class151.uint_1[(int)(this.uint_6 >> 16 & 255u)], 16) ^ this.method_0(Class151.uint_1[(int)(this.uint_5 >> 24 & 255u)], 8) ^ uint_7[i, 1]);
			num3 = (Class151.uint_1[(int)(this.uint_5 & 255u)] ^ this.method_0(Class151.uint_1[(int)(this.uint_4 >> 8 & 255u)], 24) ^ this.method_0(Class151.uint_1[(int)(this.uint_3 >> 16 & 255u)], 16) ^ this.method_0(Class151.uint_1[(int)(this.uint_6 >> 24 & 255u)], 8) ^ uint_7[i, 2]);
			num4 = (Class151.uint_1[(int)(this.uint_6 & 255u)] ^ this.method_0(Class151.uint_1[(int)(this.uint_5 >> 8 & 255u)], 24) ^ this.method_0(Class151.uint_1[(int)(this.uint_4 >> 16 & 255u)], 16) ^ this.method_0(Class151.uint_1[(int)(this.uint_3 >> 24 & 255u)], 8) ^ uint_7[i--, 3]);
			this.uint_3 = (Class151.uint_1[(int)(num & 255u)] ^ this.method_0(Class151.uint_1[(int)(num4 >> 8 & 255u)], 24) ^ this.method_0(Class151.uint_1[(int)(num3 >> 16 & 255u)], 16) ^ this.method_0(Class151.uint_1[(int)(num2 >> 24 & 255u)], 8) ^ uint_7[i, 0]);
			this.uint_4 = (Class151.uint_1[(int)(num2 & 255u)] ^ this.method_0(Class151.uint_1[(int)(num >> 8 & 255u)], 24) ^ this.method_0(Class151.uint_1[(int)(num4 >> 16 & 255u)], 16) ^ this.method_0(Class151.uint_1[(int)(num3 >> 24 & 255u)], 8) ^ uint_7[i, 1]);
			this.uint_5 = (Class151.uint_1[(int)(num3 & 255u)] ^ this.method_0(Class151.uint_1[(int)(num2 >> 8 & 255u)], 24) ^ this.method_0(Class151.uint_1[(int)(num >> 16 & 255u)], 16) ^ this.method_0(Class151.uint_1[(int)(num4 >> 24 & 255u)], 8) ^ uint_7[i, 2]);
			this.uint_6 = (Class151.uint_1[(int)(num4 & 255u)] ^ this.method_0(Class151.uint_1[(int)(num3 >> 8 & 255u)], 24) ^ this.method_0(Class151.uint_1[(int)(num2 >> 16 & 255u)], 16) ^ this.method_0(Class151.uint_1[(int)(num >> 24 & 255u)], 8) ^ uint_7[i--, 3]);
		}
		num = (Class151.uint_1[(int)(this.uint_3 & 255u)] ^ this.method_0(Class151.uint_1[(int)(this.uint_6 >> 8 & 255u)], 24) ^ this.method_0(Class151.uint_1[(int)(this.uint_5 >> 16 & 255u)], 16) ^ this.method_0(Class151.uint_1[(int)(this.uint_4 >> 24 & 255u)], 8) ^ uint_7[i, 0]);
		num2 = (Class151.uint_1[(int)(this.uint_4 & 255u)] ^ this.method_0(Class151.uint_1[(int)(this.uint_3 >> 8 & 255u)], 24) ^ this.method_0(Class151.uint_1[(int)(this.uint_6 >> 16 & 255u)], 16) ^ this.method_0(Class151.uint_1[(int)(this.uint_5 >> 24 & 255u)], 8) ^ uint_7[i, 1]);
		num3 = (Class151.uint_1[(int)(this.uint_5 & 255u)] ^ this.method_0(Class151.uint_1[(int)(this.uint_4 >> 8 & 255u)], 24) ^ this.method_0(Class151.uint_1[(int)(this.uint_3 >> 16 & 255u)], 16) ^ this.method_0(Class151.uint_1[(int)(this.uint_6 >> 24 & 255u)], 8) ^ uint_7[i, 2]);
		num4 = (Class151.uint_1[(int)(this.uint_6 & 255u)] ^ this.method_0(Class151.uint_1[(int)(this.uint_5 >> 8 & 255u)], 24) ^ this.method_0(Class151.uint_1[(int)(this.uint_4 >> 16 & 255u)], 16) ^ this.method_0(Class151.uint_1[(int)(this.uint_3 >> 24 & 255u)], 8) ^ uint_7[i, 3]);
		this.uint_3 = (uint)((int)Class151.byte_1[(int)(num & 255u)] ^ (int)Class151.byte_1[(int)(num4 >> 8 & 255u)] << 8 ^ (int)Class151.byte_1[(int)(num3 >> 16 & 255u)] << 16 ^ (int)Class151.byte_1[(int)(num2 >> 24 & 255u)] << 24 ^ (int)uint_7[0, 0]);
		this.uint_4 = (uint)((int)Class151.byte_1[(int)(num2 & 255u)] ^ (int)Class151.byte_1[(int)(num >> 8 & 255u)] << 8 ^ (int)Class151.byte_1[(int)(num4 >> 16 & 255u)] << 16 ^ (int)Class151.byte_1[(int)(num3 >> 24 & 255u)] << 24 ^ (int)uint_7[0, 1]);
		this.uint_5 = (uint)((int)Class151.byte_1[(int)(num3 & 255u)] ^ (int)Class151.byte_1[(int)(num2 >> 8 & 255u)] << 8 ^ (int)Class151.byte_1[(int)(num >> 16 & 255u)] << 16 ^ (int)Class151.byte_1[(int)(num4 >> 24 & 255u)] << 24 ^ (int)uint_7[0, 2]);
		this.uint_6 = (uint)((int)Class151.byte_1[(int)(num4 & 255u)] ^ (int)Class151.byte_1[(int)(num3 >> 8 & 255u)] << 8 ^ (int)Class151.byte_1[(int)(num2 >> 16 & 255u)] << 16 ^ (int)Class151.byte_1[(int)(num >> 24 & 255u)] << 24 ^ (int)uint_7[0, 3]);
	}

	// Token: 0x040004F9 RID: 1273
	private static readonly byte[] byte_0 = new byte[]
	{
		99,
		124,
		119,
		123,
		242,
		107,
		111,
		197,
		48,
		1,
		103,
		43,
		254,
		215,
		171,
		118,
		202,
		130,
		201,
		125,
		250,
		89,
		71,
		240,
		173,
		212,
		162,
		175,
		156,
		164,
		114,
		192,
		183,
		253,
		147,
		38,
		54,
		63,
		247,
		204,
		52,
		165,
		229,
		241,
		113,
		216,
		49,
		21,
		4,
		199,
		35,
		195,
		24,
		150,
		5,
		154,
		7,
		18,
		128,
		226,
		235,
		39,
		178,
		117,
		9,
		131,
		44,
		26,
		27,
		110,
		90,
		160,
		82,
		59,
		214,
		179,
		41,
		227,
		47,
		132,
		83,
		209,
		0,
		237,
		32,
		252,
		177,
		91,
		106,
		203,
		190,
		57,
		74,
		76,
		88,
		207,
		208,
		239,
		170,
		251,
		67,
		77,
		51,
		133,
		69,
		249,
		2,
		127,
		80,
		60,
		159,
		168,
		81,
		163,
		64,
		143,
		146,
		157,
		56,
		245,
		188,
		182,
		218,
		33,
		16,
		byte.MaxValue,
		243,
		210,
		205,
		12,
		19,
		236,
		95,
		151,
		68,
		23,
		196,
		167,
		126,
		61,
		100,
		93,
		25,
		115,
		96,
		129,
		79,
		220,
		34,
		42,
		144,
		136,
		70,
		238,
		184,
		20,
		222,
		94,
		11,
		219,
		224,
		50,
		58,
		10,
		73,
		6,
		36,
		92,
		194,
		211,
		172,
		98,
		145,
		149,
		228,
		121,
		231,
		200,
		55,
		109,
		141,
		213,
		78,
		169,
		108,
		86,
		244,
		234,
		101,
		122,
		174,
		8,
		186,
		120,
		37,
		46,
		28,
		166,
		180,
		198,
		232,
		221,
		116,
		31,
		75,
		189,
		139,
		138,
		112,
		62,
		181,
		102,
		72,
		3,
		246,
		14,
		97,
		53,
		87,
		185,
		134,
		193,
		29,
		158,
		225,
		248,
		152,
		17,
		105,
		217,
		142,
		148,
		155,
		30,
		135,
		233,
		206,
		85,
		40,
		223,
		140,
		161,
		137,
		13,
		191,
		230,
		66,
		104,
		65,
		153,
		45,
		15,
		176,
		84,
		187,
		22
	};

	// Token: 0x040004FA RID: 1274
	private static readonly byte[] byte_1 = new byte[]
	{
		82,
		9,
		106,
		213,
		48,
		54,
		165,
		56,
		191,
		64,
		163,
		158,
		129,
		243,
		215,
		251,
		124,
		227,
		57,
		130,
		155,
		47,
		byte.MaxValue,
		135,
		52,
		142,
		67,
		68,
		196,
		222,
		233,
		203,
		84,
		123,
		148,
		50,
		166,
		194,
		35,
		61,
		238,
		76,
		149,
		11,
		66,
		250,
		195,
		78,
		8,
		46,
		161,
		102,
		40,
		217,
		36,
		178,
		118,
		91,
		162,
		73,
		109,
		139,
		209,
		37,
		114,
		248,
		246,
		100,
		134,
		104,
		152,
		22,
		212,
		164,
		92,
		204,
		93,
		101,
		182,
		146,
		108,
		112,
		72,
		80,
		253,
		237,
		185,
		218,
		94,
		21,
		70,
		87,
		167,
		141,
		157,
		132,
		144,
		216,
		171,
		0,
		140,
		188,
		211,
		10,
		247,
		228,
		88,
		5,
		184,
		179,
		69,
		6,
		208,
		44,
		30,
		143,
		202,
		63,
		15,
		2,
		193,
		175,
		189,
		3,
		1,
		19,
		138,
		107,
		58,
		145,
		17,
		65,
		79,
		103,
		220,
		234,
		151,
		242,
		207,
		206,
		240,
		180,
		230,
		115,
		150,
		172,
		116,
		34,
		231,
		173,
		53,
		133,
		226,
		249,
		55,
		232,
		28,
		117,
		223,
		110,
		71,
		241,
		26,
		113,
		29,
		41,
		197,
		137,
		111,
		183,
		98,
		14,
		170,
		24,
		190,
		27,
		252,
		86,
		62,
		75,
		198,
		210,
		121,
		32,
		154,
		219,
		192,
		254,
		120,
		205,
		90,
		244,
		31,
		221,
		168,
		51,
		136,
		7,
		199,
		49,
		177,
		18,
		16,
		89,
		39,
		128,
		236,
		95,
		96,
		81,
		127,
		169,
		25,
		181,
		74,
		13,
		45,
		229,
		122,
		159,
		147,
		201,
		156,
		239,
		160,
		224,
		59,
		77,
		174,
		42,
		245,
		176,
		200,
		235,
		187,
		60,
		131,
		83,
		153,
		97,
		23,
		43,
		4,
		126,
		186,
		119,
		214,
		38,
		225,
		105,
		20,
		99,
		85,
		33,
		12,
		125
	};

	// Token: 0x040004FB RID: 1275
	private static readonly byte[] byte_2 = new byte[]
	{
		1,
		2,
		4,
		8,
		16,
		32,
		64,
		128,
		27,
		54,
		108,
		216,
		171,
		77,
		154,
		47,
		94,
		188,
		99,
		198,
		151,
		53,
		106,
		212,
		179,
		125,
		250,
		239,
		197,
		145
	};

	// Token: 0x040004FC RID: 1276
	private static readonly uint[] uint_0 = new uint[]
	{
		2774754246u,
		2222750968u,
		2574743534u,
		2373680118u,
		234025727u,
		3177933782u,
		2976870366u,
		1422247313u,
		1345335392u,
		50397442u,
		2842126286u,
		2099981142u,
		436141799u,
		1658312629u,
		3870010189u,
		2591454956u,
		1170918031u,
		2642575903u,
		1086966153u,
		2273148410u,
		368769775u,
		3948501426u,
		3376891790u,
		200339707u,
		3970805057u,
		1742001331u,
		4255294047u,
		3937382213u,
		3214711843u,
		4154762323u,
		2524082916u,
		1539358875u,
		3266819957u,
		486407649u,
		2928907069u,
		1780885068u,
		1513502316u,
		1094664062u,
		49805301u,
		1338821763u,
		1546925160u,
		4104496465u,
		887481809u,
		150073849u,
		2473685474u,
		1943591083u,
		1395732834u,
		1058346282u,
		201589768u,
		1388824469u,
		1696801606u,
		1589887901u,
		672667696u,
		2711000631u,
		251987210u,
		3046808111u,
		151455502u,
		907153956u,
		2608889883u,
		1038279391u,
		652995533u,
		1764173646u,
		3451040383u,
		2675275242u,
		453576978u,
		2659418909u,
		1949051992u,
		773462580u,
		756751158u,
		2993581788u,
		3998898868u,
		4221608027u,
		4132590244u,
		1295727478u,
		1641469623u,
		3467883389u,
		2066295122u,
		1055122397u,
		1898917726u,
		2542044179u,
		4115878822u,
		1758581177u,
		0u,
		753790401u,
		1612718144u,
		536673507u,
		3367088505u,
		3982187446u,
		3194645204u,
		1187761037u,
		3653156455u,
		1262041458u,
		3729410708u,
		3561770136u,
		3898103984u,
		1255133061u,
		1808847035u,
		720367557u,
		3853167183u,
		385612781u,
		3309519750u,
		3612167578u,
		1429418854u,
		2491778321u,
		3477423498u,
		284817897u,
		100794884u,
		2172616702u,
		4031795360u,
		1144798328u,
		3131023141u,
		3819481163u,
		4082192802u,
		4272137053u,
		3225436288u,
		2324664069u,
		2912064063u,
		3164445985u,
		1211644016u,
		83228145u,
		3753688163u,
		3249976951u,
		1977277103u,
		1663115586u,
		806359072u,
		452984805u,
		250868733u,
		1842533055u,
		1288555905u,
		336333848u,
		890442534u,
		804056259u,
		3781124030u,
		2727843637u,
		3427026056u,
		957814574u,
		1472513171u,
		4071073621u,
		2189328124u,
		1195195770u,
		2892260552u,
		3881655738u,
		723065138u,
		2507371494u,
		2690670784u,
		2558624025u,
		3511635870u,
		2145180835u,
		1713513028u,
		2116692564u,
		2878378043u,
		2206763019u,
		3393603212u,
		703524551u,
		3552098411u,
		1007948840u,
		2044649127u,
		3797835452u,
		487262998u,
		1994120109u,
		1004593371u,
		1446130276u,
		1312438900u,
		503974420u,
		3679013266u,
		168166924u,
		1814307912u,
		3831258296u,
		1573044895u,
		1859376061u,
		4021070915u,
		2791465668u,
		2828112185u,
		2761266481u,
		937747667u,
		2339994098u,
		854058965u,
		1137232011u,
		1496790894u,
		3077402074u,
		2358086913u,
		1691735473u,
		3528347292u,
		3769215305u,
		3027004632u,
		4199962284u,
		133494003u,
		636152527u,
		2942657994u,
		2390391540u,
		3920539207u,
		403179536u,
		3585784431u,
		2289596656u,
		1864705354u,
		1915629148u,
		605822008u,
		4054230615u,
		3350508659u,
		1371981463u,
		602466507u,
		2094914977u,
		2624877800u,
		555687742u,
		3712699286u,
		3703422305u,
		2257292045u,
		2240449039u,
		2423288032u,
		1111375484u,
		3300242801u,
		2858837708u,
		3628615824u,
		84083462u,
		32962295u,
		302911004u,
		2741068226u,
		1597322602u,
		4183250862u,
		3501832553u,
		2441512471u,
		1489093017u,
		656219450u,
		3114180135u,
		954327513u,
		335083755u,
		3013122091u,
		856756514u,
		3144247762u,
		1893325225u,
		2307821063u,
		2811532339u,
		3063651117u,
		572399164u,
		2458355477u,
		552200649u,
		1238290055u,
		4283782570u,
		2015897680u,
		2061492133u,
		2408352771u,
		4171342169u,
		2156497161u,
		386731290u,
		3669999461u,
		837215959u,
		3326231172u,
		3093850320u,
		3275833730u,
		2962856233u,
		1999449434u,
		286199582u,
		3417354363u,
		4233385128u,
		3602627437u,
		974525996u
	};

	// Token: 0x040004FD RID: 1277
	private static readonly uint[] uint_1 = new uint[]
	{
		1353184337u,
		1399144830u,
		3282310938u,
		2522752826u,
		3412831035u,
		4047871263u,
		2874735276u,
		2466505547u,
		1442459680u,
		4134368941u,
		2440481928u,
		625738485u,
		4242007375u,
		3620416197u,
		2151953702u,
		2409849525u,
		1230680542u,
		1729870373u,
		2551114309u,
		3787521629u,
		41234371u,
		317738113u,
		2744600205u,
		3338261355u,
		3881799427u,
		2510066197u,
		3950669247u,
		3663286933u,
		763608788u,
		3542185048u,
		694804553u,
		1154009486u,
		1787413109u,
		2021232372u,
		1799248025u,
		3715217703u,
		3058688446u,
		397248752u,
		1722556617u,
		3023752829u,
		407560035u,
		2184256229u,
		1613975959u,
		1165972322u,
		3765920945u,
		2226023355u,
		480281086u,
		2485848313u,
		1483229296u,
		436028815u,
		2272059028u,
		3086515026u,
		601060267u,
		3791801202u,
		1468997603u,
		715871590u,
		120122290u,
		63092015u,
		2591802758u,
		2768779219u,
		4068943920u,
		2997206819u,
		3127509762u,
		1552029421u,
		723308426u,
		2461301159u,
		4042393587u,
		2715969870u,
		3455375973u,
		3586000134u,
		526529745u,
		2331944644u,
		2639474228u,
		2689987490u,
		853641733u,
		1978398372u,
		971801355u,
		2867814464u,
		111112542u,
		1360031421u,
		4186579262u,
		1023860118u,
		2919579357u,
		1186850381u,
		3045938321u,
		90031217u,
		1876166148u,
		4279586912u,
		620468249u,
		2548678102u,
		3426959497u,
		2006899047u,
		3175278768u,
		2290845959u,
		945494503u,
		3689859193u,
		1191869601u,
		3910091388u,
		3374220536u,
		0u,
		2206629897u,
		1223502642u,
		2893025566u,
		1316117100u,
		4227796733u,
		1446544655u,
		517320253u,
		658058550u,
		1691946762u,
		564550760u,
		3511966619u,
		976107044u,
		2976320012u,
		266819475u,
		3533106868u,
		2660342555u,
		1338359936u,
		2720062561u,
		1766553434u,
		370807324u,
		179999714u,
		3844776128u,
		1138762300u,
		488053522u,
		185403662u,
		2915535858u,
		3114841645u,
		3366526484u,
		2233069911u,
		1275557295u,
		3151862254u,
		4250959779u,
		2670068215u,
		3170202204u,
		3309004356u,
		880737115u,
		1982415755u,
		3703972811u,
		1761406390u,
		1676797112u,
		3403428311u,
		277177154u,
		1076008723u,
		538035844u,
		2099530373u,
		4164795346u,
		288553390u,
		1839278535u,
		1261411869u,
		4080055004u,
		3964831245u,
		3504587127u,
		1813426987u,
		2579067049u,
		4199060497u,
		577038663u,
		3297574056u,
		440397984u,
		3626794326u,
		4019204898u,
		3343796615u,
		3251714265u,
		4272081548u,
		906744984u,
		3481400742u,
		685669029u,
		646887386u,
		2764025151u,
		3835509292u,
		227702864u,
		2613862250u,
		1648787028u,
		3256061430u,
		3904428176u,
		1593260334u,
		4121936770u,
		3196083615u,
		2090061929u,
		2838353263u,
		3004310991u,
		999926984u,
		2809993232u,
		1852021992u,
		2075868123u,
		158869197u,
		4095236462u,
		28809964u,
		2828685187u,
		1701746150u,
		2129067946u,
		147831841u,
		3873969647u,
		3650873274u,
		3459673930u,
		3557400554u,
		3598495785u,
		2947720241u,
		824393514u,
		815048134u,
		3227951669u,
		935087732u,
		2798289660u,
		2966458592u,
		366520115u,
		1251476721u,
		4158319681u,
		240176511u,
		804688151u,
		2379631990u,
		1303441219u,
		1414376140u,
		3741619940u,
		3820343710u,
		461924940u,
		3089050817u,
		2136040774u,
		82468509u,
		1563790337u,
		1937016826u,
		776014843u,
		1511876531u,
		1389550482u,
		861278441u,
		323475053u,
		2355222426u,
		2047648055u,
		2383738969u,
		2302415851u,
		3995576782u,
		902390199u,
		3991215329u,
		1018251130u,
		1507840668u,
		1064563285u,
		2043548696u,
		3208103795u,
		3939366739u,
		1537932639u,
		342834655u,
		2262516856u,
		2180231114u,
		1053059257u,
		741614648u,
		1598071746u,
		1925389590u,
		203809468u,
		2336832552u,
		1100287487u,
		1895934009u,
		3736275976u,
		2632234200u,
		2428589668u,
		1636092795u,
		1890988757u,
		1952214088u,
		1113045200u
	};

	// Token: 0x040004FE RID: 1278
	private int int_0;

	// Token: 0x040004FF RID: 1279
	private uint[,] uint_2;

	// Token: 0x04000500 RID: 1280
	private uint uint_3;

	// Token: 0x04000501 RID: 1281
	private uint uint_4;

	// Token: 0x04000502 RID: 1282
	private uint uint_5;

	// Token: 0x04000503 RID: 1283
	private uint uint_6;

	// Token: 0x04000504 RID: 1284
	private bool bool_0;
}
