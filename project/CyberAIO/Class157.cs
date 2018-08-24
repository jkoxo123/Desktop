using System;
using System.IO;

// Token: 0x02000129 RID: 297
internal sealed class Class157
{
	// Token: 0x060006BD RID: 1725 RVA: 0x00005D95 File Offset: 0x00003F95
	private static Stream smethod_0()
	{
		return (Stream)Class20.smethod_0().method_179(Class20.smethod_1(), "ARoF5@:3SR", null);
	}

	// Token: 0x060006BE RID: 1726 RVA: 0x00005DB1 File Offset: 0x00003FB1
	private static int smethod_1()
	{
		return (int)Class20.smethod_0().method_179(Class20.smethod_1(), "ARoFq@:3SW", null);
	}

	// Token: 0x060006BF RID: 1727 RVA: 0x00005DD2 File Offset: 0x00003FD2
	private static byte[] smethod_2()
	{
		return (byte[])Class20.smethod_0().method_179(Class20.smethod_1(), "ARoHQ@:3SW", null);
	}

	// Token: 0x060006C0 RID: 1728 RVA: 0x00005DEE File Offset: 0x00003FEE
	private static byte[] smethod_3()
	{
		return (byte[])Class20.smethod_0().method_179(Class20.smethod_1(), "ARoH&@:3SW", null);
	}

	// Token: 0x060006C1 RID: 1729 RVA: 0x00005E0A File Offset: 0x0000400A
	public static void smethod_4(string string_0, byte[] byte_0, int int_0, int int_1)
	{
		if (Class157.stream_0 == null)
		{
			Class157.stream_0 = Class157.smethod_0();
		}
		Class157.smethod_9(Class157.smethod_11(string_0), byte_0, int_0, int_1);
	}

	// Token: 0x060006C2 RID: 1730 RVA: 0x00038EC8 File Offset: 0x000370C8
	public static byte[] smethod_5(string string_0)
	{
		if (Class157.stream_0 == null)
		{
			Class157.stream_0 = Class157.smethod_0();
		}
		long num = Class157.smethod_11(string_0);
		byte[] array = new byte[4];
		Class157.smethod_9(num, array, 0, 4);
		int num2 = Class161.smethod_4(array, 0);
		Array.Clear(array, 0, array.Length);
		byte[] array2 = new byte[num2];
		Class157.smethod_9(num + 4L, array2, 0, num2);
		return array2;
	}

	// Token: 0x060006C3 RID: 1731 RVA: 0x00038F28 File Offset: 0x00037128
	private static Class2 smethod_6(out bool bool_0)
	{
		bool_0 = true;
		if (Class157.class2_0 != null)
		{
			return Class157.class2_0;
		}
		if (Class157.class152_0 != null)
		{
			bool_0 = false;
			return Class157.class152_0.method_8();
		}
		Class152 @class = Class157.smethod_8();
		Class2 class2 = @class.method_8();
		if (class2.vmethod_0())
		{
			Class157.class2_0 = class2;
			@class.Dispose();
		}
		else
		{
			Class157.class152_0 = @class;
			bool_0 = false;
		}
		return class2;
	}

	// Token: 0x060006C4 RID: 1732 RVA: 0x00038F88 File Offset: 0x00037188
	private static int smethod_7()
	{
		if (Class157.nullable_0 != null)
		{
			return Class157.nullable_0.Value;
		}
		bool flag;
		Class2 @class = Class157.smethod_6(out flag);
		Class157.nullable_0 = new int?(@class.vmethod_1());
		if (!flag)
		{
			@class.Dispose();
		}
		return Class157.nullable_0.Value;
	}

	// Token: 0x060006C5 RID: 1733 RVA: 0x00005E2B File Offset: 0x0000402B
	private static Class152 smethod_8()
	{
		return (Class152)Class20.smethod_0().method_179(Class20.smethod_1(), "ARoHR@:3SU", null);
	}

	// Token: 0x060006C6 RID: 1734 RVA: 0x00038FD8 File Offset: 0x000371D8
	private static void smethod_9(long long_0, byte[] byte_0, int int_0, int int_1)
	{
		object[] object_ = new object[]
		{
			long_0,
			byte_0,
			int_0,
			int_1
		};
		Class20.smethod_0().method_93(Class20.smethod_1(), "ARoE[@:3S\\", object_);
	}

	// Token: 0x060006C7 RID: 1735 RVA: 0x00039020 File Offset: 0x00037220
	private static void smethod_10(long long_0, byte[] byte_0)
	{
		object[] object_ = new object[]
		{
			long_0,
			byte_0
		};
		Class20.smethod_0().method_93(Class20.smethod_1(), "ARoFt@:3S`", object_);
	}

	// Token: 0x060006C8 RID: 1736 RVA: 0x00039058 File Offset: 0x00037258
	private static long smethod_11(string string_0)
	{
		object[] object_ = new object[]
		{
			string_0
		};
		return (long)Class20.smethod_0().method_179(Class20.smethod_1(), "ARoEY@:3Sd", object_);
	}

	// Token: 0x04000526 RID: 1318
	[ThreadStatic]
	private static Stream stream_0;

	// Token: 0x04000527 RID: 1319
	[ThreadStatic]
	private static Class152 class152_0;

	// Token: 0x04000528 RID: 1320
	[ThreadStatic]
	private static Class2 class2_0;

	// Token: 0x04000529 RID: 1321
	private static int? nullable_0;
}
