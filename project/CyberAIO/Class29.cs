using System;

// Token: 0x0200003F RID: 63
internal static class Class29
{
	// Token: 0x06000147 RID: 327 RVA: 0x0000F14C File Offset: 0x0000D34C
	private static bool smethod_0<T>(Type type_0)
	{
		Type typeFromHandle = typeof(T);
		return type_0 == typeFromHandle || type_0.IsSubclassOf(typeFromHandle);
	}

	// Token: 0x06000148 RID: 328 RVA: 0x0000F174 File Offset: 0x0000D374
	public static Class80 smethod_1(object object_0, Type type_0)
	{
		Class80 @class = object_0 as Class80;
		if (@class != null)
		{
			return @class;
		}
		if (type_0 == null)
		{
			if (object_0 == null)
			{
				return new Class90();
			}
			type_0 = object_0.GetType();
		}
		type_0 = Class37.smethod_1(type_0);
		if (type_0 == Class175.type_0)
		{
			@class = new Class90();
			if (object_0 != null && object_0.GetType() != Class175.type_0)
			{
				@class.method_1(object_0.GetType());
			}
		}
		else if (Class29.smethod_0<Array>(type_0))
		{
			@class = new Class93();
		}
		else if (Class29.smethod_0<string>(type_0))
		{
			@class = new Class96();
		}
		else if (Class29.smethod_0<IntPtr>(type_0))
		{
			@class = new Class99();
		}
		else if (Class29.smethod_0<UIntPtr>(type_0))
		{
			@class = new Class83();
		}
		else if (Class29.smethod_0<ulong>(type_0))
		{
			@class = new Class89();
		}
		else if (Class29.smethod_0<uint>(type_0))
		{
			@class = new Class92();
		}
		else if (Class29.smethod_0<ushort>(type_0))
		{
			@class = new Class87();
		}
		else if (Class29.smethod_0<long>(type_0))
		{
			@class = new Class82();
		}
		else if (Class29.smethod_0<int>(type_0))
		{
			@class = new Class98();
		}
		else if (Class29.smethod_0<short>(type_0))
		{
			@class = new Class94();
		}
		else if (Class29.smethod_0<byte>(type_0))
		{
			@class = new Class88();
		}
		else if (Class29.smethod_0<sbyte>(type_0))
		{
			@class = new Class85();
		}
		else if (Class29.smethod_0<double>(type_0))
		{
			@class = new Class86();
		}
		else if (Class29.smethod_0<float>(type_0))
		{
			@class = new Class91();
		}
		else if (Class29.smethod_0<bool>(type_0))
		{
			@class = new Class97();
		}
		else if (Class29.smethod_0<char>(type_0))
		{
			@class = new Class81();
		}
		else if (Class175.smethod_0(type_0))
		{
			Class90 class2 = new Class90();
			class2.method_1(type_0);
			@class = class2;
		}
		else
		{
			if (Class29.smethod_0<Enum>(type_0))
			{
				Enum enum_;
				if (object_0 == null)
				{
					if (type_0 == Class175.type_2)
					{
						enum_ = null;
					}
					else
					{
						enum_ = (Enum)Activator.CreateInstance(type_0);
					}
				}
				else if (type_0 == Class175.type_2 && object_0 is Enum)
				{
					enum_ = (Enum)object_0;
				}
				else
				{
					enum_ = (Enum)Enum.ToObject(type_0, object_0);
				}
				return new Class84(enum_);
			}
			if (Class29.smethod_0<ValueType>(type_0))
			{
				if (object_0 == null)
				{
					object object_;
					if (type_0 == Class175.type_3)
					{
						object_ = null;
					}
					else
					{
						object_ = Activator.CreateInstance(type_0);
					}
					@class = new Class107(object_);
				}
				else
				{
					if (object_0.GetType() != type_0)
					{
						try
						{
							object_0 = Convert.ChangeType(object_0, type_0);
						}
						catch
						{
						}
					}
					@class = new Class107(object_0);
				}
				return @class;
			}
			@class = new Class90();
		}
		if (object_0 != null)
		{
			@class.vmethod_1(object_0);
		}
		return @class;
	}
}
