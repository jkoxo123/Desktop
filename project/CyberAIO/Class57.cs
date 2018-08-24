using System;
using System.Threading;

// Token: 0x02000065 RID: 101
internal static class Class57
{
	// Token: 0x060001E6 RID: 486 RVA: 0x00003C4C File Offset: 0x00001E4C
	public static Interface5 smethod_0()
	{
		return Class57.smethod_1() ?? new Class9();
	}

	// Token: 0x060001E7 RID: 487 RVA: 0x000123E0 File Offset: 0x000105E0
	private static Interface5 smethod_1()
	{
		Interface5 result;
		try
		{
			Class173 @class = new Class173();
			if (!Class57.smethod_3(@class))
			{
				@class.Dispose();
				result = null;
			}
			else
			{
				result = @class;
			}
		}
		catch (Exception exception_) when (!Class57.smethod_2(exception_))
		{
			result = null;
		}
		return result;
	}

	// Token: 0x060001E8 RID: 488 RVA: 0x00003C5C File Offset: 0x00001E5C
	private static bool smethod_2(Exception exception_0)
	{
		return exception_0 is ThreadAbortException || exception_0 is ThreadInterruptedException;
	}

	// Token: 0x060001E9 RID: 489 RVA: 0x00012438 File Offset: 0x00010638
	private static bool smethod_3(Interface5 interface5_0)
	{
		byte[] array = new byte[]
		{
			0,
			130,
			byte.MaxValue
		};
		for (int i = 0; i < array.Length; i++)
		{
			byte b = array[i];
			interface5_0.imethod_2(i, ref b);
		}
		if (interface5_0.imethod_0() != array.Length)
		{
			return false;
		}
		for (int j = 0; j < array.Length; j++)
		{
			byte b2;
			interface5_0.imethod_1(j, out b2);
			if (b2 != array[j])
			{
				return false;
			}
		}
		interface5_0.imethod_3();
		return interface5_0.imethod_0() == 0;
	}
}
