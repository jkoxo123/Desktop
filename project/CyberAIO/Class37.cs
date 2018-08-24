using System;

// Token: 0x0200004B RID: 75
internal static class Class37
{
	// Token: 0x0600016C RID: 364 RVA: 0x0000384F File Offset: 0x00001A4F
	public static Type smethod_0(Type type_0)
	{
		if (!type_0.IsByRef && !type_0.IsArray && !type_0.IsPointer)
		{
			return type_0;
		}
		return Class37.smethod_0(type_0.GetElementType());
	}

	// Token: 0x0600016D RID: 365 RVA: 0x00003876 File Offset: 0x00001A76
	public static Type smethod_1(Type type_0)
	{
		if (type_0.HasElementType && !type_0.IsArray)
		{
			type_0 = type_0.GetElementType();
		}
		return type_0;
	}

	// Token: 0x0600016E RID: 366 RVA: 0x0000FDDC File Offset: 0x0000DFDC
	public static Class15<Struct87> smethod_2(Type type_0)
	{
		Class15<Struct87> @class = new Class15<Struct87>();
		Type type = type_0;
		for (;;)
		{
			if (type.IsArray)
			{
				@class.method_7(new Struct87
				{
					int_0 = 2,
					int_1 = type.GetArrayRank()
				});
			}
			else if (type.IsByRef)
			{
				@class.method_7(new Struct87
				{
					int_0 = 1
				});
			}
			else
			{
				if (!type.IsPointer)
				{
					break;
				}
				@class.method_7(new Struct87
				{
					int_0 = 0
				});
			}
			type = type.GetElementType();
		}
		return @class;
	}

	// Token: 0x0600016F RID: 367 RVA: 0x0000FE70 File Offset: 0x0000E070
	public static Class15<Struct87> smethod_3(string string_0)
	{
		string text = string_0;
		Class15<Struct87> @class = new Class15<Struct87>();
		for (;;)
		{
			if (text.EndsWith("&", StringComparison.Ordinal))
			{
				@class.method_7(new Struct87
				{
					int_0 = 1
				});
				text = text.Substring(0, text.Length - 1);
			}
			else if (text.EndsWith("*", StringComparison.Ordinal))
			{
				@class.method_7(new Struct87
				{
					int_0 = 0
				});
				text = text.Substring(0, text.Length - 1);
			}
			else if (text.EndsWith("[]", StringComparison.Ordinal))
			{
				@class.method_7(new Struct87
				{
					int_0 = 2,
					int_1 = 1
				});
				text = text.Substring(0, text.Length - 2);
			}
			else
			{
				if (!text.EndsWith(",]", StringComparison.Ordinal))
				{
					return @class;
				}
				int num = 1;
				int num2 = -1;
				for (int i = text.Length - 2; i >= 0; i--)
				{
					char c = text[i];
					if (c != ',')
					{
						if (c != '[')
						{
							goto Block_5;
						}
						num2 = i;
						i = -1;
					}
					else
					{
						num++;
					}
				}
				if (num2 < 0)
				{
					goto IL_145;
				}
				text = text.Substring(0, num2);
				@class.method_7(new Struct87
				{
					int_0 = 2,
					int_1 = num
				});
			}
		}
		Block_5:
		throw new InvalidOperationException("VM-3012");
		IL_145:
		throw new InvalidOperationException("VM-3014");
	}

	// Token: 0x06000170 RID: 368 RVA: 0x0000FFDC File Offset: 0x0000E1DC
	public static Type smethod_4(Type type_0, Class15<Struct87> class15_0)
	{
		Type type = type_0;
		while (class15_0.Count > 0)
		{
			Struct87 @struct = class15_0.method_6();
			switch (@struct.int_0)
			{
			case 0:
				type = type.MakePointerType();
				break;
			case 1:
				type = type.MakeByRefType();
				break;
			case 2:
				if (@struct.int_1 == 1)
				{
					type = type.MakeArrayType();
				}
				else
				{
					type = type.MakeArrayType(@struct.int_1);
				}
				break;
			}
		}
		return type;
	}
}
