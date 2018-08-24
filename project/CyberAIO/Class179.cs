using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

// Token: 0x0200018F RID: 399
internal static class Class179
{
	// Token: 0x0600085F RID: 2143 RVA: 0x0004C3B8 File Offset: 0x0004A5B8
	internal static long smethod_0()
	{
		if (Assembly.GetCallingAssembly() == typeof(Class179).Assembly && Class179.smethod_2())
		{
			long result;
			lock (Class179.class187_0)
			{
				long num = Class179.class187_0.method_0();
				if (num == 0L)
				{
					Assembly executingAssembly = Assembly.GetExecutingAssembly();
					List<byte> list = new List<byte>();
					AssemblyName assemblyName;
					try
					{
						assemblyName = executingAssembly.GetName();
					}
					catch
					{
						assemblyName = new AssemblyName(executingAssembly.FullName);
					}
					byte[] array = assemblyName.GetPublicKeyToken();
					if (array != null && array.Length == 0)
					{
						array = null;
					}
					if (array != null)
					{
						list.AddRange(array);
					}
					list.AddRange(Encoding.Unicode.GetBytes(assemblyName.Name));
					int num2 = Class179.smethod_4(typeof(Class179));
					int num3 = Class179.Class180.smethod_0();
					list.Add((byte)(num2 >> 8));
					list.Add((byte)(num3 >> 8));
					list.Add((byte)(num2 >> 16));
					list.Add((byte)(num3 >> 16));
					list.Add((byte)(num2 >> 24));
					list.Add((byte)num3);
					list.Add((byte)num2);
					list.Add((byte)(num3 >> 24));
					int count = list.Count;
					ulong num4 = 0UL;
					for (int num5 = 0; num5 != count; num5++)
					{
						num4 += (ulong)list[num5];
						num4 += num4 << 20;
						num4 ^= num4 >> 12;
						list[num5] = 0;
					}
					num4 += num4 << 6;
					num4 ^= num4 >> 22;
					num4 += num4 << 30;
					num = (long)num4;
					num ^= 5431364615967954426L;
					Class179.class187_0.method_1(num);
				}
				result = num;
			}
			return result;
		}
		return 0L;
	}

	// Token: 0x06000860 RID: 2144 RVA: 0x0004C59C File Offset: 0x0004A79C
	internal static void smethod_1(byte[] byte_0)
	{
		if (Assembly.GetCallingAssembly() == typeof(Class179).Assembly && Class179.smethod_2())
		{
			long num = Class179.smethod_0();
			byte[] array = new byte[]
			{
				(byte)num,
				(byte)(num >> 40),
				(byte)(num >> 56),
				(byte)(num >> 48),
				(byte)(num >> 32),
				(byte)(num >> 24),
				(byte)(num >> 16),
				(byte)(num >> 8)
			};
			int num2 = byte_0.Length;
			for (int num3 = 0; num3 != num2; num3++)
			{
				int num4 = num3;
				byte_0[num4] ^= (byte)((int)array[num3 & 7] + num3);
			}
			return;
		}
	}

	// Token: 0x06000861 RID: 2145 RVA: 0x00006AB2 File Offset: 0x00004CB2
	private static bool smethod_2()
	{
		return Class179.smethod_3();
	}

	// Token: 0x06000862 RID: 2146 RVA: 0x0004C63C File Offset: 0x0004A83C
	private static bool smethod_3()
	{
		StackTrace stackTrace = new StackTrace();
		StackFrame frame = stackTrace.GetFrame(3);
		MethodBase methodBase = (frame == null) ? null : frame.GetMethod();
		Type type = (methodBase == null) ? null : methodBase.DeclaringType;
		return type != typeof(RuntimeMethodHandle) && type != null && type.Assembly == typeof(Class179).Assembly;
	}

	// Token: 0x06000863 RID: 2147 RVA: 0x00006ABE File Offset: 0x00004CBE
	private static int smethod_4(Type type_0)
	{
		return type_0.MetadataToken;
	}

	// Token: 0x0400076D RID: 1901
	private static Class179.Class187 class187_0 = new Class179.Class187();

	// Token: 0x02000190 RID: 400
	private sealed class Class180
	{
		// Token: 0x06000865 RID: 2149 RVA: 0x0004C6A0 File Offset: 0x0004A8A0
		internal static int smethod_0()
		{
			return Class179.Class182.smethod_2(Class179.Class182.smethod_1(Class179.smethod_4(typeof(Class179.Class183)), Class179.Class182.smethod_2(Class179.smethod_4(typeof(Class179.Class180)), Class179.smethod_4(typeof(Class179.Class185)))), Class179.Class184.smethod_0());
		}
	}

	// Token: 0x02000191 RID: 401
	private sealed class Class181
	{
		// Token: 0x06000867 RID: 2151 RVA: 0x0004C6F0 File Offset: 0x0004A8F0
		internal static int smethod_0()
		{
			return Class179.Class182.smethod_2(Class179.Class182.smethod_0(Class179.Class183.smethod_0() ^ 527758446, Class179.smethod_4(typeof(Class179.Class186))), Class179.Class182.smethod_1(Class179.smethod_4(typeof(Class179.Class180)) ^ Class179.smethod_4(typeof(Class179.Class184)), 1098920027));
		}
	}

	// Token: 0x02000192 RID: 402
	private static class Class182
	{
		// Token: 0x06000868 RID: 2152 RVA: 0x00006AC6 File Offset: 0x00004CC6
		internal static int smethod_0(int int_0, int int_1)
		{
			return int_0 ^ int_1 - -654079302;
		}

		// Token: 0x06000869 RID: 2153 RVA: 0x00006AD1 File Offset: 0x00004CD1
		internal static int smethod_1(int int_0, int int_1)
		{
			return int_0 - -1787593491 ^ int_1 + 556016531;
		}

		// Token: 0x0600086A RID: 2154 RVA: 0x00006AE2 File Offset: 0x00004CE2
		internal static int smethod_2(int int_0, int int_1)
		{
			return int_0 ^ (int_1 - 346095056 ^ int_0 - int_1);
		}
	}

	// Token: 0x02000193 RID: 403
	private sealed class Class183
	{
		// Token: 0x0600086C RID: 2156 RVA: 0x0004C74C File Offset: 0x0004A94C
		internal static int smethod_0()
		{
			return Class179.Class182.smethod_0(Class179.smethod_4(typeof(Class179.Class181)), Class179.smethod_4(typeof(Class179.Class186)) ^ Class179.Class182.smethod_1(Class179.smethod_4(typeof(Class179.Class183)), Class179.Class182.smethod_2(Class179.smethod_4(typeof(Class179.Class184)), Class179.Class186.smethod_0())));
		}
	}

	// Token: 0x02000194 RID: 404
	private sealed class Class184
	{
		// Token: 0x0600086E RID: 2158 RVA: 0x0004C7AC File Offset: 0x0004A9AC
		internal static int smethod_0()
		{
			return Class179.Class182.smethod_0(Class179.smethod_4(typeof(Class179.Class184)), Class179.Class182.smethod_2(Class179.Class182.smethod_1(Class179.smethod_4(typeof(Class179.Class185)), Class179.smethod_4(typeof(Class179.Class180))), Class179.Class182.smethod_2(Class179.smethod_4(typeof(Class179.Class181)) ^ -1167500389, Class179.Class185.smethod_0())));
		}
	}

	// Token: 0x02000195 RID: 405
	private sealed class Class185
	{
		// Token: 0x06000870 RID: 2160 RVA: 0x00006AF1 File Offset: 0x00004CF1
		internal static int smethod_0()
		{
			return Class179.Class182.smethod_1(Class179.Class182.smethod_1(Class179.Class181.smethod_0(), Class179.Class182.smethod_0(Class179.smethod_4(typeof(Class179.Class185)), Class179.Class183.smethod_0())), Class179.smethod_4(typeof(Class179.Class184)));
		}
	}

	// Token: 0x02000196 RID: 406
	private sealed class Class186
	{
		// Token: 0x06000872 RID: 2162 RVA: 0x0004C814 File Offset: 0x0004AA14
		internal static int smethod_0()
		{
			return Class179.Class182.smethod_2(Class179.smethod_4(typeof(Class179.Class186)), Class179.Class182.smethod_0(Class179.smethod_4(typeof(Class179.Class180)), Class179.Class182.smethod_1(Class179.smethod_4(typeof(Class179.Class183)), Class179.Class182.smethod_2(Class179.smethod_4(typeof(Class179.Class181)), Class179.Class182.smethod_0(Class179.smethod_4(typeof(Class179.Class185)), Class179.smethod_4(typeof(Class179.Class184)))))));
		}
	}

	// Token: 0x02000197 RID: 407
	private sealed class Class187
	{
		// Token: 0x06000873 RID: 2163 RVA: 0x00006B2A File Offset: 0x00004D2A
		internal Class187()
		{
			this.method_1(0L);
		}

		// Token: 0x06000874 RID: 2164 RVA: 0x0004C894 File Offset: 0x0004AA94
		internal long method_0()
		{
			if (Assembly.GetCallingAssembly() != typeof(Class179.Class187).Assembly)
			{
				return 2918384L;
			}
			if (!Class179.smethod_2())
			{
				return 2918384L;
			}
			int[] array = new int[]
			{
				0,
				0,
				0,
				582780343
			};
			array[1] = -1820440729;
			array[2] = -236152097;
			array[0] = -705570316;
			int num = this.int_0;
			int num2 = this.int_1;
			int num3 = -1640531527;
			int num4 = -957401312;
			for (int num5 = 0; num5 != 32; num5++)
			{
				num2 -= ((num << 4 ^ num >> 5) + num ^ num4 + array[num4 >> 11 & 3]);
				num4 -= num3;
				num -= ((num2 << 4 ^ num2 >> 5) + num2 ^ num4 + array[num4 & 3]);
			}
			for (int num6 = 0; num6 != 4; num6++)
			{
				array[num6] = 0;
			}
			ulong num7 = (ulong)((ulong)((long)num2) << 32);
			return (long)(num7 | (ulong)num);
		}

		// Token: 0x06000875 RID: 2165 RVA: 0x0004C97C File Offset: 0x0004AB7C
		internal void method_1(long long_0)
		{
			if (Assembly.GetCallingAssembly() != typeof(Class179.Class187).Assembly)
			{
				return;
			}
			if (!Class179.smethod_2())
			{
				return;
			}
			int[] array = new int[4];
			array[1] = -1820440729;
			array[0] = -705570316;
			array[2] = -236152097;
			array[3] = 582780343;
			int num = -1640531527;
			int num2 = (int)long_0;
			int num3 = (int)(long_0 >> 32);
			int num4 = 0;
			for (int num5 = 0; num5 != 32; num5++)
			{
				num2 += ((num3 << 4 ^ num3 >> 5) + num3 ^ num4 + array[num4 & 3]);
				num4 += num;
				num3 += ((num2 << 4 ^ num2 >> 5) + num2 ^ num4 + array[num4 >> 11 & 3]);
			}
			for (int num6 = 0; num6 != 4; num6++)
			{
				array[num6] = 0;
			}
			this.int_0 = num2;
			this.int_1 = num3;
		}

		// Token: 0x0400076E RID: 1902
		private int int_0;

		// Token: 0x0400076F RID: 1903
		private int int_1;
	}
}
