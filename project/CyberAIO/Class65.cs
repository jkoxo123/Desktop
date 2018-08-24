using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;

// Token: 0x02000081 RID: 129
internal sealed class Class65
{
	// Token: 0x0600023A RID: 570 RVA: 0x000152D8 File Offset: 0x000134D8
	public Class65(Class119 class119_1, Module module_1)
	{
		this.dictionary_0 = new Dictionary<MethodBase, int>(256);
		this.dictionary_3 = new Dictionary<MethodBase, object>();
		this.class15_1 = new Class15<Class65.Struct49>();
		this.class15_0 = new Class15<Class80>();
		base..ctor();
		this.class119_0 = class119_1;
		this.module_0 = module_1;
		this.method_247();
	}

	// Token: 0x0600023B RID: 571 RVA: 0x00003F2E File Offset: 0x0000212E
	public Class65(Class119 class119_1) : this(class119_1, typeof(Class65).Module)
	{
	}

	// Token: 0x0600023C RID: 572 RVA: 0x00015340 File Offset: 0x00013540
	// Note: this type is marked as 'beforefieldinit'.
	static Class65()
	{
		Class65.type_3 = typeof(IntPtr);
		Class65.type_6 = typeof(Assembly);
		Class65.type_0 = typeof(MethodBase);
		Class65.type_8 = typeof(RuntimeHelpers);
	}

	// Token: 0x0600023D RID: 573 RVA: 0x00003F46 File Offset: 0x00002146
	private void method_0(Class80 class80_2)
	{
		this.method_2(typeof(byte));
	}

	// Token: 0x0600023E RID: 574 RVA: 0x000153BC File Offset: 0x000135BC
	private void method_1(Stream stream_1, long long_1, string string_0)
	{
		int int_ = this.method_270();
		Class12 class11_ = new Class12(stream_1, int_);
		this.class123_1 = new Class123(class11_);
		if (string_0 != null)
		{
			long_1 = this.method_79(string_0);
		}
		Class11 @class = this.class123_1.method_0();
		Class11 obj = @class;
		lock (obj)
		{
			@class.vmethod_9(long_1, 0);
			this.method_9(this.class123_1);
			this.class42_0 = this.method_238(this.class123_1);
			this.class134_0 = Class65.smethod_14(this.class123_1);
			this.byte_0 = Class65.smethod_28(this.class123_1);
		}
		this.method_249();
	}

	// Token: 0x0600023F RID: 575 RVA: 0x00015470 File Offset: 0x00013670
	private void method_2(Type type_9)
	{
		Class100 class100_ = (Class100)this.method_112();
		this.method_293(Class29.smethod_1(this.method_259(class100_).vmethod_0(), type_9));
	}

	// Token: 0x06000240 RID: 576 RVA: 0x00003F58 File Offset: 0x00002158
	private int method_3()
	{
		return 108174632;
	}

	// Token: 0x06000241 RID: 577 RVA: 0x00003F5F File Offset: 0x0000215F
	private void method_4(Class80 class80_2)
	{
		Class98 @class = new Class98();
		@class.method_3(4);
		this.method_293(@class);
	}

	// Token: 0x06000242 RID: 578 RVA: 0x00003F73 File Offset: 0x00002173
	private void method_5(Class80 class80_2)
	{
		this.method_269();
	}

	// Token: 0x06000243 RID: 579 RVA: 0x00003F7B File Offset: 0x0000217B
	private void method_6(Class80 class80_2)
	{
		this.method_277(typeof(int));
	}

	// Token: 0x06000244 RID: 580 RVA: 0x00003F8D File Offset: 0x0000218D
	private void method_7(Class80 class80_2)
	{
		this.method_293(this.class80_1[0].vmethod_4());
	}

	// Token: 0x06000245 RID: 581 RVA: 0x000154A4 File Offset: 0x000136A4
	private void method_8(Class80 class80_2)
	{
		Class80 @class = this.method_112();
		int num = @class.vmethod_2();
		checked
		{
			IntPtr intptr_;
			if (num <= 14)
			{
				if (num == 8)
				{
					intptr_ = new IntPtr((long)Convert.ToUInt64(((Class84)@class).method_2()));
					goto IL_87;
				}
				if (num == 14)
				{
					intptr_ = new IntPtr((long)(unchecked((ulong)(checked((uint)((Class98)@class).method_2())))));
					goto IL_87;
				}
			}
			else
			{
				if (num == 16)
				{
					intptr_ = new IntPtr((long)((ulong)((Class82)@class).method_2()));
					goto IL_87;
				}
				if (num == 19)
				{
					intptr_ = new IntPtr((long)((Class86)@class).method_2());
					goto IL_87;
				}
			}
			throw new InvalidOperationException();
			IL_87:
			Class99 class2 = new Class99();
			class2.method_3(intptr_);
			this.method_293(class2);
		}
	}

	// Token: 0x06000246 RID: 582 RVA: 0x00002D6B File Offset: 0x00000F6B
	private void method_9(Class123 class123_2)
	{
	}

	// Token: 0x06000247 RID: 583 RVA: 0x0001554C File Offset: 0x0001374C
	private static bool smethod_0(Class80 class80_2, Class80 class80_3)
	{
		bool result = false;
		switch (class80_2.vmethod_2())
		{
		case 1:
		{
			Class103 @class = (Class103)class80_2;
			Class103 class2 = (Class103)class80_3;
			return @class.method_2() == class2.method_2();
		}
		case 3:
		case 11:
		{
			Class104 class3 = (Class104)class80_2;
			Class104 class104_ = (Class104)class80_3;
			return class3.vmethod_7(class104_);
		}
		case 5:
		{
			Class102 class4 = (Class102)class80_2;
			Class102 class5 = (Class102)class80_3;
			return Class65.smethod_0(class4.method_2(), class5.method_2());
		}
		case 6:
			if (class80_3.vmethod_2() == 21 && class80_3.vmethod_0() == null)
			{
				return ((Class83)class80_2).method_2() == UIntPtr.Zero;
			}
			if (class80_3.vmethod_2() == 14)
			{
				return ((Class83)class80_2).method_2() == new UIntPtr((uint)((Class98)class80_3).method_2());
			}
			if (class80_3.vmethod_2() == 16)
			{
				return ((Class83)class80_2).method_2() == new UIntPtr((ulong)((Class82)class80_3).method_2());
			}
			return ((Class83)class80_2).method_2() == ((Class83)class80_3).method_2();
		case 8:
		{
			Class84 class6 = (Class84)class80_2;
			if (class80_3.vmethod_2() == 8)
			{
				return Convert.ToInt64(class6.method_2()) == Convert.ToInt64(((Class84)class80_3).method_2());
			}
			if (class6.method_2() == null)
			{
				return class80_3.vmethod_0() == null;
			}
			if (class80_3.vmethod_0() != null)
			{
				return Convert.ToInt64(class6.method_2()) == Convert.ToInt64(class80_3.vmethod_0());
			}
			return result;
		}
		case 12:
			return (class80_3.vmethod_2() != 21 || class80_3.vmethod_0() != null) && ((Class107)class80_2).method_2() == ((Class107)class80_3).method_2();
		case 14:
			if (class80_3.vmethod_2() == 8)
			{
				return (long)((Class98)class80_2).method_2() == Convert.ToInt64(((Class84)class80_3).method_2());
			}
			if (class80_3.vmethod_2() == 21 && class80_3.vmethod_0() == null)
			{
				return ((Class98)class80_2).method_2() == 0;
			}
			return ((Class98)class80_2).method_2() == ((Class98)class80_3).method_2();
		case 16:
			if (class80_3.vmethod_2() == 8)
			{
				return ((Class82)class80_2).method_2() == Convert.ToInt64(((Class84)class80_3).method_2());
			}
			if (class80_3.vmethod_2() == 21 && class80_3.vmethod_0() == null)
			{
				return ((Class82)class80_2).method_2() == 0L;
			}
			return ((Class82)class80_2).method_2() == ((Class82)class80_3).method_2();
		case 17:
		{
			Class101 class7 = (Class101)class80_2;
			Class101 class8 = (Class101)class80_3;
			return class7.method_2() == class8.method_2() && class7.method_4() == class8.method_4();
		}
		case 19:
		{
			double d = ((Class86)class80_2).method_2();
			double num = ((Class86)class80_3).method_2();
			return !double.IsNaN(d) && !double.IsNaN(num) && d.Equals(num);
		}
		case 21:
			return class80_2.vmethod_0() == class80_3.vmethod_0();
		case 23:
			if (class80_3.vmethod_2() == 21 && class80_3.vmethod_0() == null)
			{
				return ((Class99)class80_2).method_2() == IntPtr.Zero;
			}
			if (class80_3.vmethod_2() == 14)
			{
				return ((Class99)class80_2).method_2() == new IntPtr(((Class98)class80_3).method_2());
			}
			if (class80_3.vmethod_2() == 16)
			{
				return ((Class99)class80_2).method_2() == new IntPtr(((Class82)class80_3).method_2());
			}
			return ((Class99)class80_2).method_2() == ((Class99)class80_3).method_2();
		}
		result = (class80_2.vmethod_0() == class80_3.vmethod_0());
		return result;
	}

	// Token: 0x06000248 RID: 584 RVA: 0x000159B0 File Offset: 0x00013BB0
	private void method_10(Class80 class80_2)
	{
		Class87 @class = (Class87)class80_2;
		this.method_293(this.class80_0[(int)@class.method_2()].vmethod_4());
	}

	// Token: 0x06000249 RID: 585 RVA: 0x000159E0 File Offset: 0x00013BE0
	private static Class80 smethod_1(Class80 class80_2, Class80 class80_3, bool bool_2, bool bool_3)
	{
		if (!bool_3)
		{
			long num = ((Class82)class80_2).method_2();
			long num2 = ((Class82)class80_3).method_2();
			long long_;
			if (bool_2)
			{
				long_ = checked(num - num2);
			}
			else
			{
				long_ = num - num2;
			}
			Class82 @class = new Class82();
			@class.method_3(long_);
			return @class;
		}
		ulong num3 = (ulong)((Class82)class80_2).method_2();
		ulong num4 = (ulong)((Class82)class80_3).method_2();
		ulong long_2;
		if (bool_2)
		{
			long_2 = checked(num3 - num4);
		}
		else
		{
			long_2 = num3 - num4;
		}
		Class82 class2 = new Class82();
		class2.method_3((long)long_2);
		return class2;
	}

	// Token: 0x0600024A RID: 586 RVA: 0x00015A5C File Offset: 0x00013C5C
	private Class80 method_11(Class80 class80_2, Class80 class80_3)
	{
		if (class80_2.vmethod_2() == 14)
		{
			if (class80_3.vmethod_2() == 14)
			{
				int num = ((Class98)class80_2).method_2();
				int num2 = ((Class98)class80_3).method_2();
				int int_ = num << num2;
				Class98 @class = new Class98();
				@class.method_3(int_);
				return @class;
			}
			if (class80_3.vmethod_2() == 8)
			{
				Class98 class2 = new Class98();
				class2.method_3(Convert.ToInt32(class80_3.vmethod_0()));
				return this.method_11(class80_2, class2);
			}
		}
		if (class80_2.vmethod_2() == 16)
		{
			if (class80_3.vmethod_2() == 14)
			{
				long num3 = ((Class82)class80_2).method_2();
				int num4 = ((Class98)class80_3).method_2();
				long long_ = num3 << num4;
				Class82 class3 = new Class82();
				class3.method_3(long_);
				return class3;
			}
			if (class80_3.vmethod_2() == 8)
			{
				Class98 class4 = new Class98();
				class4.method_3(Convert.ToInt32(class80_3.vmethod_0()));
				return this.method_11(class80_2, class4);
			}
		}
		if (class80_2.vmethod_2() == 8)
		{
			Type underlyingType = Enum.GetUnderlyingType(class80_2.vmethod_0().GetType());
			if (underlyingType != typeof(long))
			{
				if (underlyingType != typeof(ulong))
				{
					Class98 class5 = new Class98();
					class5.method_3(Convert.ToInt32(class80_2.vmethod_0()));
					return this.method_11(class5, class80_3);
				}
			}
			Class82 class6 = new Class82();
			class6.method_3(Convert.ToInt64(class80_2.vmethod_0()));
			return this.method_11(class6, class80_3);
		}
		throw new InvalidOperationException();
	}

	// Token: 0x0600024B RID: 587 RVA: 0x00015BAC File Offset: 0x00013DAC
	private static bool smethod_2(Class80 class80_2, Class80 class80_3)
	{
		int num = class80_2.vmethod_2();
		if (num <= 8)
		{
			if (num != 6)
			{
				if (num == 8)
				{
					long num2 = Convert.ToInt64(((Class84)class80_2).method_2());
					long num3;
					if (class80_3.vmethod_2() == 14)
					{
						num3 = (long)((Class98)class80_3).method_2();
					}
					else
					{
						num3 = Convert.ToInt64(((Class84)class80_3).method_2());
					}
					return num2 > num3;
				}
			}
			else
			{
				if (class80_3.vmethod_2() == 21 && class80_3.vmethod_0() == null)
				{
					return ((Class83)class80_2).method_2() != UIntPtr.Zero;
				}
				return ((Class83)class80_2).method_2() != ((Class83)class80_3).method_2();
			}
		}
		else
		{
			switch (num)
			{
			case 12:
				return (class80_3.vmethod_2() == 21 && class80_3.vmethod_0() == null) || ((Class107)class80_2).method_2() != ((Class107)class80_3).method_2();
			case 13:
			case 15:
				break;
			case 14:
				return ((Class98)class80_2).method_2() > ((Class98)class80_3).method_2();
			case 16:
				return ((Class82)class80_2).method_2() > ((Class82)class80_3).method_2();
			default:
				switch (num)
				{
				case 19:
				{
					double num4 = ((Class86)class80_2).method_2();
					double num5 = ((Class86)class80_3).method_2();
					return num4 > num5 || double.IsNaN(num4) || double.IsNaN(num5);
				}
				case 21:
					return ((Class90)class80_2).method_2() != ((Class90)class80_3).method_2();
				case 23:
					if (class80_3.vmethod_2() == 21 && class80_3.vmethod_0() == null)
					{
						return ((Class99)class80_2).method_2() != IntPtr.Zero;
					}
					return ((Class99)class80_2).method_2() != ((Class99)class80_3).method_2();
				}
				break;
			}
		}
		return class80_2.vmethod_0() != class80_3.vmethod_0();
	}

	// Token: 0x0600024C RID: 588 RVA: 0x00015DC8 File Offset: 0x00013FC8
	private void method_12(Class80 class80_2)
	{
		Class87 @class = (Class87)class80_2;
		Class80 class2 = this.method_112();
		this.class80_0[(int)@class.method_2()].vmethod_3(class2);
	}

	// Token: 0x0600024D RID: 589 RVA: 0x00003FA6 File Offset: 0x000021A6
	private void method_13(Class80 class80_2)
	{
		this.method_208(3);
	}

	// Token: 0x0600024E RID: 590 RVA: 0x00015DFC File Offset: 0x00013FFC
	private Class65.Delegate20 method_14(MethodBase methodBase_0, bool bool_2)
	{
		DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, Class175.type_0, new Type[]
		{
			Class175.type_0,
			Class65.type_5
		}, typeof(Class65).Module, true);
		ILGenerator ilgenerator = dynamicMethod.GetILGenerator();
		ParameterInfo[] parameters = methodBase_0.GetParameters();
		Type[] array = new Type[parameters.Length];
		bool flag = false;
		for (int i = 0; i < parameters.Length; i++)
		{
			Type type = parameters[i].ParameterType;
			if (type.IsByRef)
			{
				flag = true;
				type = type.GetElementType();
			}
			array[i] = type;
		}
		LocalBuilder[] array2 = new LocalBuilder[array.Length];
		if (array2.Length != 0)
		{
			dynamicMethod.InitLocals = true;
		}
		for (int j = 0; j < array.Length; j++)
		{
			array2[j] = ilgenerator.DeclareLocal(array[j]);
		}
		for (int k = 0; k < array.Length; k++)
		{
			ilgenerator.Emit(OpCodes.Ldarg_1);
			Class65.smethod_6(ilgenerator, k);
			ilgenerator.Emit(OpCodes.Ldelem_Ref);
			Class65.smethod_12(ilgenerator, array[k]);
			ilgenerator.Emit(OpCodes.Stloc, array2[k]);
		}
		if (flag)
		{
			ilgenerator.BeginExceptionBlock();
		}
		if (!methodBase_0.IsStatic && !methodBase_0.IsConstructor)
		{
			ilgenerator.Emit(OpCodes.Ldarg_0);
			Type declaringType = methodBase_0.DeclaringType;
			if (declaringType.IsValueType)
			{
				ilgenerator.Emit(OpCodes.Unbox, declaringType);
				bool_2 = false;
			}
			else
			{
				Class65.smethod_30(ilgenerator, declaringType);
			}
		}
		for (int l = 0; l < array.Length; l++)
		{
			if (parameters[l].ParameterType.IsByRef)
			{
				ilgenerator.Emit(OpCodes.Ldloca_S, array2[l]);
			}
			else
			{
				ilgenerator.Emit(OpCodes.Ldloc, array2[l]);
			}
		}
		if (methodBase_0.IsConstructor)
		{
			ilgenerator.Emit(OpCodes.Newobj, (ConstructorInfo)methodBase_0);
			Class65.smethod_26(ilgenerator, methodBase_0.DeclaringType);
		}
		else
		{
			MethodInfo methodInfo = (MethodInfo)methodBase_0;
			if (bool_2 && !methodBase_0.IsStatic)
			{
				ilgenerator.EmitCall(OpCodes.Callvirt, methodInfo, null);
			}
			else
			{
				ilgenerator.EmitCall(OpCodes.Call, methodInfo, null);
			}
			if (methodInfo.ReturnType == Class65.type_4)
			{
				ilgenerator.Emit(OpCodes.Ldnull);
			}
			else
			{
				Class65.smethod_26(ilgenerator, methodInfo.ReturnType);
			}
		}
		if (flag)
		{
			LocalBuilder local = ilgenerator.DeclareLocal(Class175.type_0);
			ilgenerator.Emit(OpCodes.Stloc, local);
			ilgenerator.BeginFinallyBlock();
			for (int m = 0; m < array.Length; m++)
			{
				if (parameters[m].ParameterType.IsByRef)
				{
					ilgenerator.Emit(OpCodes.Ldarg_1);
					Class65.smethod_6(ilgenerator, m);
					ilgenerator.Emit(OpCodes.Ldloc, array2[m]);
					if (array2[m].LocalType.IsValueType || Class37.smethod_0(array2[m].LocalType).IsGenericParameter)
					{
						ilgenerator.Emit(OpCodes.Box, array2[m].LocalType);
					}
					ilgenerator.Emit(OpCodes.Stelem_Ref);
				}
			}
			ilgenerator.EndExceptionBlock();
			ilgenerator.Emit(OpCodes.Ldloc, local);
		}
		ilgenerator.Emit(OpCodes.Ret);
		return (Class65.Delegate20)dynamicMethod.CreateDelegate(typeof(Class65.Delegate20));
	}

	// Token: 0x0600024F RID: 591 RVA: 0x00016148 File Offset: 0x00014348
	private Class24[] method_15(Class123 class123_2)
	{
		Class24[] array = new Class24[(int)class123_2.method_23()];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = this.method_150(class123_2);
		}
		return array;
	}

	// Token: 0x06000250 RID: 592 RVA: 0x00016180 File Offset: 0x00014380
	private Type method_16(int int_0, bool bool_2)
	{
		Dictionary<int, object> obj = Class65.dictionary_1;
		Type type;
		lock (obj)
		{
			bool flag = true;
			object obj2;
			if (Class65.dictionary_1.TryGetValue(int_0, out obj2))
			{
				type = (Type)obj2;
			}
			else
			{
				Class0 class0_ = this.method_111(int_0);
				type = this.method_39(int_0, class0_, ref flag, bool_2);
				if (flag)
				{
					Class65.dictionary_1.Add(int_0, type);
				}
			}
		}
		if (bool_2)
		{
			this.method_57(type);
		}
		return type;
	}

	// Token: 0x06000251 RID: 593 RVA: 0x000161FC File Offset: 0x000143FC
	private void method_17(Class80 class80_2)
	{
		int int_ = ((Class98)class80_2).method_2();
		Type type_ = this.method_16(int_, true);
		Class80 class80_3 = this.method_112();
		if (!this.method_98(class80_3, type_))
		{
			throw new InvalidCastException();
		}
		this.method_293(class80_3);
	}

	// Token: 0x06000252 RID: 594 RVA: 0x0001623C File Offset: 0x0001443C
	private void method_18(Class80 class80_2)
	{
		Class80 class80_3 = this.method_112();
		Class80 class80_4 = this.method_112();
		Class98 @class = new Class98();
		@class.method_3(Class65.smethod_5(class80_4, class80_3) ? 1 : 0);
		this.method_293(@class);
	}

	// Token: 0x06000253 RID: 595 RVA: 0x00016278 File Offset: 0x00014478
	private void method_19(Class80 class80_2)
	{
		Class88 @class = (Class88)class80_2;
		this.method_208((int)@class.method_2());
	}

	// Token: 0x06000254 RID: 596 RVA: 0x00016298 File Offset: 0x00014498
	private void method_20(Class80 class80_2)
	{
		Class80 @class = this.method_112();
		int num = @class.vmethod_2();
		checked
		{
			uint int_;
			if (num <= 14)
			{
				if (num == 8)
				{
					int_ = (uint)Convert.ToUInt64(((Class84)@class).method_2());
					goto IL_6E;
				}
				if (num == 14)
				{
					int_ = (uint)((Class98)@class).method_2();
					goto IL_6E;
				}
			}
			else
			{
				if (num == 16)
				{
					int_ = (uint)((ulong)((Class82)@class).method_2());
					goto IL_6E;
				}
				if (num == 19)
				{
					int_ = (uint)((Class86)@class).method_2();
					goto IL_6E;
				}
			}
			throw new InvalidOperationException();
			IL_6E:
			Class98 class2 = new Class98();
			class2.method_3((int)int_);
			this.method_293(class2);
		}
	}

	// Token: 0x06000255 RID: 597 RVA: 0x00003FAF File Offset: 0x000021AF
	private void method_21(Class80 class80_2)
	{
		this.method_242(typeof(float));
	}

	// Token: 0x06000256 RID: 598 RVA: 0x00016328 File Offset: 0x00014528
	private void method_22(Class80 class80_2)
	{
		Class80 class80_3 = this.method_112();
		Class80 class80_4 = this.method_112();
		this.method_293(this.method_136(class80_4, class80_3, false));
	}

	// Token: 0x06000257 RID: 599 RVA: 0x00003FC1 File Offset: 0x000021C1
	private void method_23(Class80 class80_2)
	{
		this.method_34(true);
	}

	// Token: 0x06000258 RID: 600 RVA: 0x00003FCA File Offset: 0x000021CA
	private void method_24(Class80 class80_2)
	{
		this.method_221();
	}

	// Token: 0x06000259 RID: 601 RVA: 0x00016354 File Offset: 0x00014554
	private void method_25(Class80 class80_2)
	{
		Class86 @class = (Class86)this.method_112();
		if (double.IsNaN(@class.method_2()) || double.IsInfinity(@class.method_2()))
		{
			throw new OverflowException("The value is not finite real number.");
		}
		this.method_293(@class);
	}

	// Token: 0x0600025A RID: 602 RVA: 0x00003FD2 File Offset: 0x000021D2
	private void method_26(Class80 class80_2)
	{
		throw new NotSupportedException("Refanytype is not supported.");
	}

	// Token: 0x0600025B RID: 603 RVA: 0x00003FDE File Offset: 0x000021DE
	private void method_27(Class80 class80_2)
	{
		Class98 @class = new Class98();
		@class.method_3(6);
		this.method_293(@class);
	}

	// Token: 0x0600025C RID: 604 RVA: 0x0001639C File Offset: 0x0001459C
	private Class80[] method_28(object[] object_3)
	{
		Class128[] array = this.class42_0.method_2();
		int num = array.Length;
		Class80[] array2 = new Class80[num];
		for (int i = 0; i < num; i++)
		{
			object obj = object_3[i];
			Type type = this.method_16(array[i].method_0(), false);
			Type type2 = Class37.smethod_1(type);
			Type type3;
			if (type2 != Class175.type_0 && !Class175.smethod_0(type2))
			{
				type3 = ((obj != null) ? obj.GetType() : type);
			}
			else
			{
				type3 = type;
			}
			if (obj != null && !type.IsAssignableFrom(type3) && type.IsByRef && !type.GetElementType().IsAssignableFrom(type3))
			{
				throw new ArgumentException(string.Format("Object of type {0} cannot be converted to type {1}.", type3, type));
			}
			array2[i] = Class29.smethod_1(obj, type3);
		}
		if (!this.class42_0.method_12() && this.method_16(this.class42_0.method_6(), false).IsValueType)
		{
			Class80[] array3 = array2;
			int num2 = 0;
			Class102 @class = new Class102();
			@class.method_3(array2[0]);
			array3[num2] = @class;
		}
		for (int j = 0; j < num; j++)
		{
			if (array[j].method_2())
			{
				Class80[] array4 = array2;
				int num3 = j;
				Class102 class2 = new Class102();
				class2.method_3(array2[j]);
				array4[num3] = class2;
			}
		}
		return array2;
	}

	// Token: 0x0600025D RID: 605 RVA: 0x00003FF2 File Offset: 0x000021F2
	private void method_29(Class80 class80_2)
	{
		this.method_293(class80_2);
	}

	// Token: 0x0600025E RID: 606 RVA: 0x00003FFB File Offset: 0x000021FB
	private void method_30(Class80 class80_2)
	{
		this.method_2(Class175.type_0);
	}

	// Token: 0x0600025F RID: 607 RVA: 0x00004008 File Offset: 0x00002208
	private void method_31(Class80 class80_2)
	{
		this.method_224(false);
	}

	// Token: 0x06000260 RID: 608 RVA: 0x000164E0 File Offset: 0x000146E0
	private void method_32(Class80 class80_2)
	{
		Class87 @class = (Class87)class80_2;
		Class102 class2 = new Class102();
		class2.method_3(this.class80_0[(int)@class.method_2()]);
		this.method_293(class2);
	}

	// Token: 0x06000261 RID: 609 RVA: 0x00016518 File Offset: 0x00014718
	private Class80 method_33(Class80 class80_2, Class80 class80_3, bool bool_2, bool bool_3)
	{
		if (class80_2.vmethod_2() == 14)
		{
			if (class80_3.vmethod_2() == 14)
			{
				if (!bool_3)
				{
					int num = ((Class98)class80_2).method_2();
					int num2 = ((Class98)class80_3).method_2();
					int int_;
					if (bool_2)
					{
						int_ = checked(num * num2);
					}
					else
					{
						int_ = num * num2;
					}
					Class98 @class = new Class98();
					@class.method_3(int_);
					return @class;
				}
				uint num3 = (uint)((Class98)class80_2).method_2();
				uint num4 = (uint)((Class98)class80_3).method_2();
				uint int_2;
				if (bool_2)
				{
					int_2 = checked(num3 * num4);
				}
				else
				{
					int_2 = num3 * num4;
				}
				Class98 class2 = new Class98();
				class2.method_3((int)int_2);
				return class2;
			}
			else
			{
				if (class80_3.vmethod_2() == 16)
				{
					Class82 class3 = new Class82();
					class3.method_3((long)((Class98)class80_2).method_2());
					return Class65.smethod_4(class3, class80_3, bool_2, bool_3);
				}
				if (class80_3.vmethod_2() == 8)
				{
					Type underlyingType = Enum.GetUnderlyingType(class80_3.vmethod_0().GetType());
					if (underlyingType != typeof(long))
					{
						if (underlyingType != typeof(ulong))
						{
							Class98 class4 = new Class98();
							class4.method_3(Convert.ToInt32(class80_3.vmethod_0()));
							return this.method_33(class80_2, class4, bool_2, bool_3);
						}
					}
					Class82 class5 = new Class82();
					class5.method_3((long)((Class98)class80_2).method_2());
					Class82 class6 = new Class82();
					class6.method_3(Convert.ToInt64(class80_3.vmethod_0()));
					return Class65.smethod_4(class5, class6, bool_2, bool_3);
				}
			}
		}
		if (class80_2.vmethod_2() == 16)
		{
			if (class80_3.vmethod_2() == 16)
			{
				return Class65.smethod_4(class80_2, class80_3, bool_2, bool_3);
			}
			if (class80_3.vmethod_2() == 14)
			{
				Class82 class7 = new Class82();
				class7.method_3((long)((Class98)class80_3).method_2());
				return Class65.smethod_4(class80_2, class7, bool_2, bool_3);
			}
			if (class80_3.vmethod_2() == 8)
			{
				Type underlyingType2 = Enum.GetUnderlyingType(class80_3.vmethod_0().GetType());
				if (underlyingType2 != typeof(long))
				{
					if (underlyingType2 != typeof(ulong))
					{
						Class98 class8 = new Class98();
						class8.method_3(Convert.ToInt32(class80_3.vmethod_0()));
						return Class65.smethod_4(class80_2, class8, bool_2, bool_3);
					}
				}
				Class82 class9 = new Class82();
				class9.method_3(Convert.ToInt64(class80_3.vmethod_0()));
				return Class65.smethod_4(class80_2, class9, bool_2, bool_3);
			}
		}
		if (class80_2.vmethod_2() == 19 && class80_3.vmethod_2() == 19)
		{
			Class86 class10 = new Class86();
			class10.method_3(((Class86)class80_2).method_2() * ((Class86)class80_3).method_2());
			return class10;
		}
		if (class80_2.vmethod_2() == 8)
		{
			Type underlyingType3 = Enum.GetUnderlyingType(class80_2.vmethod_0().GetType());
			if (underlyingType3 != typeof(long))
			{
				if (underlyingType3 != typeof(ulong))
				{
					Class98 class11 = new Class98();
					class11.method_3(Convert.ToInt32(class80_2.vmethod_0()));
					return this.method_33(class11, class80_3, bool_2, bool_3);
				}
			}
			Class82 class12 = new Class82();
			class12.method_3(Convert.ToInt64(class80_2.vmethod_0()));
			return this.method_33(class12, class80_3, bool_2, bool_3);
		}
		throw new InvalidOperationException();
	}

	// Token: 0x06000262 RID: 610 RVA: 0x000167E8 File Offset: 0x000149E8
	private static string smethod_3(MethodBase methodBase_0)
	{
		Type declaringType = methodBase_0.DeclaringType;
		ParameterInfo[] parameters = methodBase_0.GetParameters();
		string[] array = new string[parameters.Length];
		for (int i = 0; i < parameters.Length; i++)
		{
			ParameterInfo parameterInfo = parameters[i];
			array[i] = string.Format("{0} {1}", parameterInfo.ParameterType, parameterInfo.Name);
		}
		string arg = string.Join(", ", array);
		return string.Format("{0}.{1}({2})", declaringType.FullName, methodBase_0.Name, arg);
	}

	// Token: 0x06000263 RID: 611 RVA: 0x00016868 File Offset: 0x00014A68
	private void method_34(bool bool_2)
	{
		Class80 @class = this.method_112();
		int num = @class.vmethod_2();
		sbyte int_;
		if (num <= 14)
		{
			if (num != 8)
			{
				if (num == 14)
				{
					if (bool_2)
					{
						int_ = checked((sbyte)((Class98)@class).method_2());
						goto IL_BD;
					}
					int_ = (sbyte)((Class98)@class).method_2();
					goto IL_BD;
				}
			}
			else
			{
				if (bool_2)
				{
					int_ = checked((sbyte)Convert.ToUInt64(((Class84)@class).method_2()));
					goto IL_BD;
				}
				int_ = (sbyte)Convert.ToUInt64(((Class84)@class).method_2());
				goto IL_BD;
			}
		}
		else if (num != 16)
		{
			if (num == 19)
			{
				if (bool_2)
				{
					int_ = checked((sbyte)((Class86)@class).method_2());
					goto IL_BD;
				}
				int_ = (sbyte)((Class86)@class).method_2();
				goto IL_BD;
			}
		}
		else
		{
			if (bool_2)
			{
				int_ = checked((sbyte)((Class82)@class).method_2());
				goto IL_BD;
			}
			int_ = (sbyte)((Class82)@class).method_2();
			goto IL_BD;
		}
		throw new InvalidOperationException();
		IL_BD:
		Class98 class2 = new Class98();
		class2.method_3((int)int_);
		this.method_293(class2);
	}

	// Token: 0x06000264 RID: 612 RVA: 0x00016944 File Offset: 0x00014B44
	private void method_35(Class80 class80_2)
	{
		int int_ = ((Class98)class80_2).method_2();
		FieldInfo fieldInfo_ = this.method_223(int_);
		Class80 @class = this.method_112();
		Class100 class2 = @class as Class100;
		object obj;
		if (class2 != null)
		{
			obj = this.method_259(class2).vmethod_0();
		}
		else
		{
			obj = @class.vmethod_0();
		}
		this.method_293(new Class101(fieldInfo_, obj, class2));
	}

	// Token: 0x06000265 RID: 613 RVA: 0x0001699C File Offset: 0x00014B9C
	private static Class80 smethod_4(Class80 class80_2, Class80 class80_3, bool bool_2, bool bool_3)
	{
		if (!bool_3)
		{
			long num = ((Class82)class80_2).method_2();
			long num2 = ((Class82)class80_3).method_2();
			long long_;
			if (bool_2)
			{
				long_ = checked(num * num2);
			}
			else
			{
				long_ = num * num2;
			}
			Class82 @class = new Class82();
			@class.method_3(long_);
			return @class;
		}
		ulong num3 = (ulong)((Class82)class80_2).method_2();
		ulong num4 = (ulong)((Class82)class80_3).method_2();
		ulong long_2;
		if (bool_2)
		{
			long_2 = checked(num3 * num4);
		}
		else
		{
			long_2 = num3 * num4;
		}
		Class82 class2 = new Class82();
		class2.method_3((long)long_2);
		return class2;
	}

	// Token: 0x06000266 RID: 614 RVA: 0x00004011 File Offset: 0x00002211
	private void method_36(Class80 class80_2)
	{
		Class98 @class = new Class98();
		@class.method_3(0);
		this.method_293(@class);
	}

	// Token: 0x06000267 RID: 615 RVA: 0x00002D6B File Offset: 0x00000F6B
	private void method_37(Class80 class80_2)
	{
	}

	// Token: 0x06000268 RID: 616 RVA: 0x00016A18 File Offset: 0x00014C18
	private Dictionary<int, Class65.Class67> method_38()
	{
		return new Dictionary<int, Class65.Class67>(256)
		{
			{
				this.class119_0.class159_165.method_0(),
				new Class65.Class67(this.class119_0.class159_165, new Class65.Delegate21(this.method_27))
			},
			{
				this.class119_0.class159_99.method_0(),
				new Class65.Class67(this.class119_0.class159_99, new Class65.Delegate21(this.method_18))
			},
			{
				this.class119_0.class159_189.method_0(),
				new Class65.Class67(this.class119_0.class159_189, new Class65.Delegate21(this.method_193))
			},
			{
				this.class119_0.class159_108.method_0(),
				new Class65.Class67(this.class119_0.class159_108, new Class65.Delegate21(this.method_252))
			},
			{
				this.class119_0.class159_95.method_0(),
				new Class65.Class67(this.class119_0.class159_95, new Class65.Delegate21(this.method_177))
			},
			{
				this.class119_0.class159_77.method_0(),
				new Class65.Class67(this.class119_0.class159_77, new Class65.Delegate21(this.method_173))
			},
			{
				this.class119_0.class159_24.method_0(),
				new Class65.Class67(this.class119_0.class159_24, new Class65.Delegate21(this.method_146))
			},
			{
				this.class119_0.class159_7.method_0(),
				new Class65.Class67(this.class119_0.class159_7, new Class65.Delegate21(this.method_274))
			},
			{
				this.class119_0.class159_13.method_0(),
				new Class65.Class67(this.class119_0.class159_13, new Class65.Delegate21(this.method_73))
			},
			{
				this.class119_0.class159_62.method_0(),
				new Class65.Class67(this.class119_0.class159_62, new Class65.Delegate21(this.method_85))
			},
			{
				this.class119_0.class159_187.method_0(),
				new Class65.Class67(this.class119_0.class159_187, new Class65.Delegate21(this.method_261))
			},
			{
				this.class119_0.class159_102.method_0(),
				new Class65.Class67(this.class119_0.class159_102, new Class65.Delegate21(this.method_286))
			},
			{
				this.class119_0.class159_194.method_0(),
				new Class65.Class67(this.class119_0.class159_194, new Class65.Delegate21(this.method_174))
			},
			{
				this.class119_0.class159_169.method_0(),
				new Class65.Class67(this.class119_0.class159_169, new Class65.Delegate21(this.method_122))
			},
			{
				this.class119_0.class159_144.method_0(),
				new Class65.Class67(this.class119_0.class159_144, new Class65.Delegate21(this.method_296))
			},
			{
				this.class119_0.class159_89.method_0(),
				new Class65.Class67(this.class119_0.class159_89, new Class65.Delegate21(this.method_60))
			},
			{
				this.class119_0.class159_74.method_0(),
				new Class65.Class67(this.class119_0.class159_74, new Class65.Delegate21(this.method_133))
			},
			{
				this.class119_0.class159_158.method_0(),
				new Class65.Class67(this.class119_0.class159_158, new Class65.Delegate21(this.method_213))
			},
			{
				this.class119_0.class159_174.method_0(),
				new Class65.Class67(this.class119_0.class159_174, new Class65.Delegate21(this.method_80))
			},
			{
				this.class119_0.class159_118.method_0(),
				new Class65.Class67(this.class119_0.class159_118, new Class65.Delegate21(this.method_154))
			},
			{
				this.class119_0.class159_38.method_0(),
				new Class65.Class67(this.class119_0.class159_38, new Class65.Delegate21(this.method_239))
			},
			{
				this.class119_0.class159_151.method_0(),
				new Class65.Class67(this.class119_0.class159_151, new Class65.Delegate21(this.method_228))
			},
			{
				this.class119_0.class159_58.method_0(),
				new Class65.Class67(this.class119_0.class159_58, new Class65.Delegate21(this.method_101))
			},
			{
				this.class119_0.class159_155.method_0(),
				new Class65.Class67(this.class119_0.class159_155, new Class65.Delegate21(this.method_5))
			},
			{
				this.class119_0.class159_6.method_0(),
				new Class65.Class67(this.class119_0.class159_6, new Class65.Delegate21(this.method_77))
			},
			{
				this.class119_0.class159_179.method_0(),
				new Class65.Class67(this.class119_0.class159_179, new Class65.Delegate21(this.method_100))
			},
			{
				this.class119_0.class159_207.method_0(),
				new Class65.Class67(this.class119_0.class159_207, new Class65.Delegate21(this.method_68))
			},
			{
				this.class119_0.class159_125.method_0(),
				new Class65.Class67(this.class119_0.class159_125, new Class65.Delegate21(this.method_12))
			},
			{
				this.class119_0.class159_129.method_0(),
				new Class65.Class67(this.class119_0.class159_129, new Class65.Delegate21(this.method_218))
			},
			{
				this.class119_0.class159_143.method_0(),
				new Class65.Class67(this.class119_0.class159_143, new Class65.Delegate21(this.method_130))
			},
			{
				this.class119_0.class159_92.method_0(),
				new Class65.Class67(this.class119_0.class159_92, new Class65.Delegate21(this.method_222))
			},
			{
				this.class119_0.class159_30.method_0(),
				new Class65.Class67(this.class119_0.class159_30, new Class65.Delegate21(this.method_19))
			},
			{
				this.class119_0.class159_33.method_0(),
				new Class65.Class67(this.class119_0.class159_33, new Class65.Delegate21(this.method_216))
			},
			{
				this.class119_0.class159_117.method_0(),
				new Class65.Class67(this.class119_0.class159_117, new Class65.Delegate21(this.method_71))
			},
			{
				this.class119_0.class159_20.method_0(),
				new Class65.Class67(this.class119_0.class159_20, new Class65.Delegate21(this.method_211))
			},
			{
				this.class119_0.class159_161.method_0(),
				new Class65.Class67(this.class119_0.class159_161, new Class65.Delegate21(this.method_251))
			},
			{
				this.class119_0.class159_157.method_0(),
				new Class65.Class67(this.class119_0.class159_157, new Class65.Delegate21(this.method_182))
			},
			{
				this.class119_0.class159_2.method_0(),
				new Class65.Class67(this.class119_0.class159_2, new Class65.Delegate21(this.method_233))
			},
			{
				this.class119_0.class159_193.method_0(),
				new Class65.Class67(this.class119_0.class159_193, new Class65.Delegate21(this.method_134))
			},
			{
				this.class119_0.class159_116.method_0(),
				new Class65.Class67(this.class119_0.class159_116, new Class65.Delegate21(this.method_52))
			},
			{
				this.class119_0.class159_82.method_0(),
				new Class65.Class67(this.class119_0.class159_82, new Class65.Delegate21(this.method_240))
			},
			{
				this.class119_0.class159_122.method_0(),
				new Class65.Class67(this.class119_0.class159_122, new Class65.Delegate21(this.method_262))
			},
			{
				this.class119_0.class159_152.method_0(),
				new Class65.Class67(this.class119_0.class159_152, new Class65.Delegate21(this.method_298))
			},
			{
				this.class119_0.class159_8.method_0(),
				new Class65.Class67(this.class119_0.class159_8, new Class65.Delegate21(this.method_25))
			},
			{
				this.class119_0.class159_9.method_0(),
				new Class65.Class67(this.class119_0.class159_9, new Class65.Delegate21(this.method_235))
			},
			{
				this.class119_0.class159_204.method_0(),
				new Class65.Class67(this.class119_0.class159_204, new Class65.Delegate21(this.method_106))
			},
			{
				this.class119_0.class159_133.method_0(),
				new Class65.Class67(this.class119_0.class159_133, new Class65.Delegate21(this.method_209))
			},
			{
				this.class119_0.class159_199.method_0(),
				new Class65.Class67(this.class119_0.class159_199, new Class65.Delegate21(this.method_54))
			},
			{
				this.class119_0.class159_135.method_0(),
				new Class65.Class67(this.class119_0.class159_135, new Class65.Delegate21(this.method_108))
			},
			{
				this.class119_0.class159_34.method_0(),
				new Class65.Class67(this.class119_0.class159_34, new Class65.Delegate21(this.method_94))
			},
			{
				this.class119_0.class159_184.method_0(),
				new Class65.Class67(this.class119_0.class159_184, new Class65.Delegate21(this.method_117))
			},
			{
				this.class119_0.class159_60.method_0(),
				new Class65.Class67(this.class119_0.class159_60, new Class65.Delegate21(this.method_36))
			},
			{
				this.class119_0.class159_75.method_0(),
				new Class65.Class67(this.class119_0.class159_75, new Class65.Delegate21(this.method_37))
			},
			{
				this.class119_0.class159_166.method_0(),
				new Class65.Class67(this.class119_0.class159_166, new Class65.Delegate21(this.method_109))
			},
			{
				this.class119_0.class159_192.method_0(),
				new Class65.Class67(this.class119_0.class159_192, new Class65.Delegate21(this.method_161))
			},
			{
				this.class119_0.class159_172.method_0(),
				new Class65.Class67(this.class119_0.class159_177, new Class65.Delegate21(this.method_195))
			},
			{
				this.class119_0.class159_49.method_0(),
				new Class65.Class67(this.class119_0.class159_49, new Class65.Delegate21(this.method_202))
			},
			{
				this.class119_0.class159_111.method_0(),
				new Class65.Class67(this.class119_0.class159_111, new Class65.Delegate21(this.method_69))
			},
			{
				this.class119_0.class159_197.method_0(),
				new Class65.Class67(this.class119_0.class159_197, new Class65.Delegate21(this.method_169))
			},
			{
				this.class119_0.class159_109.method_0(),
				new Class65.Class67(this.class119_0.class159_109, new Class65.Delegate21(this.method_184))
			},
			{
				this.class119_0.class159_86.method_0(),
				new Class65.Class67(this.class119_0.class159_86, new Class65.Delegate21(this.method_256))
			},
			{
				this.class119_0.class159_142.method_0(),
				new Class65.Class67(this.class119_0.class159_142, new Class65.Delegate21(this.method_107))
			},
			{
				this.class119_0.class159_26.method_0(),
				new Class65.Class67(this.class119_0.class159_26, new Class65.Delegate21(this.method_124))
			},
			{
				this.class119_0.class159_191.method_0(),
				new Class65.Class67(this.class119_0.class159_191, new Class65.Delegate21(this.method_74))
			},
			{
				this.class119_0.class159_14.method_0(),
				new Class65.Class67(this.class119_0.class159_14, new Class65.Delegate21(this.method_288))
			},
			{
				this.class119_0.class159_210.method_0(),
				new Class65.Class67(this.class119_0.class159_210, new Class65.Delegate21(this.method_48))
			},
			{
				this.class119_0.class159_50.method_0(),
				new Class65.Class67(this.class119_0.class159_50, new Class65.Delegate21(this.method_83))
			},
			{
				this.class119_0.class159_124.method_0(),
				new Class65.Class67(this.class119_0.class159_124, new Class65.Delegate21(this.method_141))
			},
			{
				this.class119_0.class159_186.method_0(),
				new Class65.Class67(this.class119_0.class159_186, new Class65.Delegate21(this.method_225))
			},
			{
				this.class119_0.class159_182.method_0(),
				new Class65.Class67(this.class119_0.class159_182, new Class65.Delegate21(this.method_126))
			},
			{
				this.class119_0.class159_137.method_0(),
				new Class65.Class67(this.class119_0.class159_137, new Class65.Delegate21(this.method_264))
			},
			{
				this.class119_0.class159_128.method_0(),
				new Class65.Class67(this.class119_0.class159_128, new Class65.Delegate21(this.method_24))
			},
			{
				this.class119_0.class159_134.method_0(),
				new Class65.Class67(this.class119_0.class159_134, new Class65.Delegate21(this.method_102))
			},
			{
				this.class119_0.class159_188.method_0(),
				new Class65.Class67(this.class119_0.class159_188, new Class65.Delegate21(this.method_26))
			},
			{
				this.class119_0.class159_45.method_0(),
				new Class65.Class67(this.class119_0.class159_45, new Class65.Delegate21(this.method_201))
			},
			{
				this.class119_0.class159_94.method_0(),
				new Class65.Class67(this.class119_0.class159_94, new Class65.Delegate21(this.method_186))
			},
			{
				this.class119_0.class159_105.method_0(),
				new Class65.Class67(this.class119_0.class159_105, new Class65.Delegate21(this.method_155))
			},
			{
				this.class119_0.class159_66.method_0(),
				new Class65.Class67(this.class119_0.class159_66, new Class65.Delegate21(this.method_230))
			},
			{
				this.class119_0.class159_57.method_0(),
				new Class65.Class67(this.class119_0.class159_57, new Class65.Delegate21(this.method_231))
			},
			{
				this.class119_0.class159_106.method_0(),
				new Class65.Class67(this.class119_0.class159_106, new Class65.Delegate21(this.method_207))
			},
			{
				this.class119_0.class159_148.method_0(),
				new Class65.Class67(this.class119_0.class159_148, new Class65.Delegate21(this.method_76))
			},
			{
				this.class119_0.class159_23.method_0(),
				new Class65.Class67(this.class119_0.class159_23, new Class65.Delegate21(this.method_210))
			},
			{
				this.class119_0.class159_104.method_0(),
				new Class65.Class67(this.class119_0.class159_104, new Class65.Delegate21(this.method_151))
			},
			{
				this.class119_0.class159_21.method_0(),
				new Class65.Class67(this.class119_0.class159_21, new Class65.Delegate21(this.method_300))
			},
			{
				this.class119_0.class159_190.method_0(),
				new Class65.Class67(this.class119_0.class159_190, new Class65.Delegate21(this.method_62))
			},
			{
				this.class119_0.class159_100.method_0(),
				new Class65.Class67(this.class119_0.class159_100, new Class65.Delegate21(this.method_291))
			},
			{
				this.class119_0.class159_40.method_0(),
				new Class65.Class67(this.class119_0.class159_40, new Class65.Delegate21(this.method_7))
			},
			{
				this.class119_0.class159_81.method_0(),
				new Class65.Class67(this.class119_0.class159_81, new Class65.Delegate21(this.method_226))
			},
			{
				this.class119_0.class159_93.method_0(),
				new Class65.Class67(this.class119_0.class159_93, new Class65.Delegate21(this.method_91))
			},
			{
				this.class119_0.class159_85.method_0(),
				new Class65.Class67(this.class119_0.class159_85, new Class65.Delegate21(this.method_99))
			},
			{
				this.class119_0.class159_150.method_0(),
				new Class65.Class67(this.class119_0.class159_150, new Class65.Delegate21(this.method_22))
			},
			{
				this.class119_0.class159_22.method_0(),
				new Class65.Class67(this.class119_0.class159_22, new Class65.Delegate21(this.method_114))
			},
			{
				this.class119_0.class159_29.method_0(),
				new Class65.Class67(this.class119_0.class159_29, new Class65.Delegate21(this.method_96))
			},
			{
				this.class119_0.class159_160.method_0(),
				new Class65.Class67(this.class119_0.class159_160, new Class65.Delegate21(this.method_196))
			},
			{
				this.class119_0.class159_72.method_0(),
				new Class65.Class67(this.class119_0.class159_72, new Class65.Delegate21(this.method_157))
			},
			{
				this.class119_0.class159_52.method_0(),
				new Class65.Class67(this.class119_0.class159_52, new Class65.Delegate21(this.method_180))
			},
			{
				this.class119_0.class159_110.method_0(),
				new Class65.Class67(this.class119_0.class159_110, new Class65.Delegate21(this.method_144))
			},
			{
				this.class119_0.class159_41.method_0(),
				new Class65.Class67(this.class119_0.class159_41, new Class65.Delegate21(this.method_66))
			},
			{
				this.class119_0.class159_53.method_0(),
				new Class65.Class67(this.class119_0.class159_53, new Class65.Delegate21(this.method_104))
			},
			{
				this.class119_0.class159_32.method_0(),
				new Class65.Class67(this.class119_0.class159_32, new Class65.Delegate21(this.method_204))
			},
			{
				this.class119_0.class159_209.method_0(),
				new Class65.Class67(this.class119_0.class159_209, new Class65.Delegate21(this.method_188))
			},
			{
				this.class119_0.class159_46.method_0(),
				new Class65.Class67(this.class119_0.class159_46, new Class65.Delegate21(this.method_70))
			},
			{
				this.class119_0.class159_115.method_0(),
				new Class65.Class67(this.class119_0.class159_115, new Class65.Delegate21(this.method_95))
			},
			{
				this.class119_0.class159_178.method_0(),
				new Class65.Class67(this.class119_0.class159_178, new Class65.Delegate21(this.method_88))
			},
			{
				this.class119_0.class159_130.method_0(),
				new Class65.Class67(this.class119_0.class159_130, new Class65.Delegate21(this.method_58))
			},
			{
				this.class119_0.class159_120.method_0(),
				new Class65.Class67(this.class119_0.class159_120, new Class65.Delegate21(this.method_21))
			},
			{
				this.class119_0.class159_175.method_0(),
				new Class65.Class67(this.class119_0.class159_175, new Class65.Delegate21(this.method_192))
			},
			{
				this.class119_0.class159_55.method_0(),
				new Class65.Class67(this.class119_0.class159_55, new Class65.Delegate21(this.method_229))
			},
			{
				this.class119_0.class159_202.method_0(),
				new Class65.Class67(this.class119_0.class159_202, new Class65.Delegate21(this.method_17))
			},
			{
				this.class119_0.class159_176.method_0(),
				new Class65.Class67(this.class119_0.class159_176, new Class65.Delegate21(this.method_87))
			},
			{
				this.class119_0.class159_203.method_0(),
				new Class65.Class67(this.class119_0.class159_203, new Class65.Delegate21(this.method_160))
			},
			{
				this.class119_0.class159_154.method_0(),
				new Class65.Class67(this.class119_0.class159_154, new Class65.Delegate21(this.method_153))
			},
			{
				this.class119_0.class159_42.method_0(),
				new Class65.Class67(this.class119_0.class159_42, new Class65.Delegate21(this.method_257))
			},
			{
				this.class119_0.class159_56.method_0(),
				new Class65.Class67(this.class119_0.class159_56, new Class65.Delegate21(this.method_0))
			},
			{
				this.class119_0.class159_65.method_0(),
				new Class65.Class67(this.class119_0.class159_65, new Class65.Delegate21(this.method_42))
			},
			{
				this.class119_0.class159_131.method_0(),
				new Class65.Class67(this.class119_0.class159_131, new Class65.Delegate21(this.method_8))
			},
			{
				this.class119_0.class159_47.method_0(),
				new Class65.Class67(this.class119_0.class159_47, new Class65.Delegate21(this.method_31))
			},
			{
				this.class119_0.class159_101.method_0(),
				new Class65.Class67(this.class119_0.class159_101, new Class65.Delegate21(this.method_63))
			},
			{
				this.class119_0.class159_98.method_0(),
				new Class65.Class67(this.class119_0.class159_98, new Class65.Delegate21(this.method_280))
			},
			{
				this.class119_0.class159_44.method_0(),
				new Class65.Class67(this.class119_0.class159_44, new Class65.Delegate21(this.method_53))
			},
			{
				this.class119_0.class159_0.method_0(),
				new Class65.Class67(this.class119_0.class159_0, new Class65.Delegate21(this.method_148))
			},
			{
				this.class119_0.class159_11.method_0(),
				new Class65.Class67(this.class119_0.class159_11, new Class65.Delegate21(this.method_200))
			},
			{
				this.class119_0.class159_73.method_0(),
				new Class65.Class67(this.class119_0.class159_73, new Class65.Delegate21(this.method_267))
			},
			{
				this.class119_0.class159_63.method_0(),
				new Class65.Class67(this.class119_0.class159_63, new Class65.Delegate21(this.method_50))
			},
			{
				this.class119_0.class159_67.method_0(),
				new Class65.Class67(this.class119_0.class159_67, new Class65.Delegate21(this.method_250))
			},
			{
				this.class119_0.class159_198.method_0(),
				new Class65.Class67(this.class119_0.class159_198, new Class65.Delegate21(this.method_78))
			},
			{
				this.class119_0.class159_88.method_0(),
				new Class65.Class67(this.class119_0.class159_88, new Class65.Delegate21(this.method_275))
			},
			{
				this.class119_0.class159_211.method_0(),
				new Class65.Class67(this.class119_0.class159_211, new Class65.Delegate21(this.method_171))
			},
			{
				this.class119_0.class159_61.method_0(),
				new Class65.Class67(this.class119_0.class159_61, new Class65.Delegate21(this.method_90))
			},
			{
				this.class119_0.class159_196.method_0(),
				new Class65.Class67(this.class119_0.class159_196, new Class65.Delegate21(this.method_217))
			},
			{
				this.class119_0.class159_48.method_0(),
				new Class65.Class67(this.class119_0.class159_48, new Class65.Delegate21(this.method_170))
			},
			{
				this.class119_0.class159_213.method_0(),
				new Class65.Class67(this.class119_0.class159_213, new Class65.Delegate21(this.method_248))
			},
			{
				this.class119_0.class159_18.method_0(),
				new Class65.Class67(this.class119_0.class159_18, new Class65.Delegate21(this.method_81))
			},
			{
				this.class119_0.class159_170.method_0(),
				new Class65.Class67(this.class119_0.class159_170, new Class65.Delegate21(this.method_149))
			},
			{
				this.class119_0.class159_177.method_0(),
				new Class65.Class67(this.class119_0.class159_177, new Class65.Delegate21(this.method_56))
			},
			{
				this.class119_0.class159_168.method_0(),
				new Class65.Class67(this.class119_0.class159_168, new Class65.Delegate21(this.method_284))
			},
			{
				this.class119_0.class159_173.method_0(),
				new Class65.Class67(this.class119_0.class159_173, new Class65.Delegate21(this.method_265))
			},
			{
				this.class119_0.class159_200.method_0(),
				new Class65.Class67(this.class119_0.class159_200, new Class65.Delegate21(this.method_125))
			},
			{
				this.class119_0.class159_54.method_0(),
				new Class65.Class67(this.class119_0.class159_54, new Class65.Delegate21(this.method_278))
			},
			{
				this.class119_0.class159_31.method_0(),
				new Class65.Class67(this.class119_0.class159_31, new Class65.Delegate21(this.method_135))
			},
			{
				this.class119_0.class159_149.method_0(),
				new Class65.Class67(this.class119_0.class159_149, new Class65.Delegate21(this.method_175))
			},
			{
				this.class119_0.class159_17.method_0(),
				new Class65.Class67(this.class119_0.class159_17, new Class65.Delegate21(this.method_165))
			},
			{
				this.class119_0.class159_126.method_0(),
				new Class65.Class67(this.class119_0.class159_126, new Class65.Delegate21(this.method_6))
			},
			{
				this.class119_0.class159_164.method_0(),
				new Class65.Class67(this.class119_0.class159_164, new Class65.Delegate21(this.method_232))
			},
			{
				this.class119_0.class159_156.method_0(),
				new Class65.Class67(this.class119_0.class159_156, new Class65.Delegate21(this.method_292))
			},
			{
				this.class119_0.class159_3.method_0(),
				new Class65.Class67(this.class119_0.class159_3, new Class65.Delegate21(this.method_44))
			},
			{
				this.class119_0.class159_183.method_0(),
				new Class65.Class67(this.class119_0.class159_183, new Class65.Delegate21(this.method_10))
			},
			{
				this.class119_0.class159_35.method_0(),
				new Class65.Class67(this.class119_0.class159_35, new Class65.Delegate21(this.method_189))
			},
			{
				this.class119_0.class159_208.method_0(),
				new Class65.Class67(this.class119_0.class159_208, new Class65.Delegate21(this.method_23))
			},
			{
				this.class119_0.class159_132.method_0(),
				new Class65.Class67(this.class119_0.class159_132, new Class65.Delegate21(this.method_119))
			},
			{
				this.class119_0.class159_51.method_0(),
				new Class65.Class67(this.class119_0.class159_51, new Class65.Delegate21(this.method_92))
			},
			{
				this.class119_0.class159_96.method_0(),
				new Class65.Class67(this.class119_0.class159_96, new Class65.Delegate21(this.method_84))
			},
			{
				this.class119_0.class159_27.method_0(),
				new Class65.Class67(this.class119_0.class159_27, new Class65.Delegate21(this.method_237))
			},
			{
				this.class119_0.class159_36.method_0(),
				new Class65.Class67(this.class119_0.class159_36, new Class65.Delegate21(this.method_172))
			},
			{
				this.class119_0.class159_112.method_0(),
				new Class65.Class67(this.class119_0.class159_112, new Class65.Delegate21(this.method_20))
			},
			{
				this.class119_0.class159_16.method_0(),
				new Class65.Class67(this.class119_0.class159_16, new Class65.Delegate21(this.method_181))
			},
			{
				this.class119_0.class159_1.method_0(),
				new Class65.Class67(this.class119_0.class159_1, new Class65.Delegate21(this.method_113))
			},
			{
				this.class119_0.class159_138.method_0(),
				new Class65.Class67(this.class119_0.class159_138, new Class65.Delegate21(this.method_97))
			},
			{
				this.class119_0.class159_123.method_0(),
				new Class65.Class67(this.class119_0.class159_123, new Class65.Delegate21(this.method_35))
			},
			{
				this.class119_0.class159_71.method_0(),
				new Class65.Class67(this.class119_0.class159_71, new Class65.Delegate21(this.method_234))
			},
			{
				this.class119_0.class159_114.method_0(),
				new Class65.Class67(this.class119_0.class159_114, new Class65.Delegate21(this.method_140))
			},
			{
				this.class119_0.class159_83.method_0(),
				new Class65.Class67(this.class119_0.class159_83, new Class65.Delegate21(this.method_162))
			},
			{
				this.class119_0.class159_185.method_0(),
				new Class65.Class67(this.class119_0.class159_185, new Class65.Delegate21(this.method_253))
			},
			{
				this.class119_0.class159_70.method_0(),
				new Class65.Class67(this.class119_0.class159_70, new Class65.Delegate21(this.method_13))
			},
			{
				this.class119_0.class159_84.method_0(),
				new Class65.Class67(this.class119_0.class159_84, new Class65.Delegate21(this.method_129))
			},
			{
				this.class119_0.class159_37.method_0(),
				new Class65.Class67(this.class119_0.class159_37, new Class65.Delegate21(this.method_299))
			},
			{
				this.class119_0.class159_147.method_0(),
				new Class65.Class67(this.class119_0.class159_147, new Class65.Delegate21(this.method_258))
			},
			{
				this.class119_0.class159_4.method_0(),
				new Class65.Class67(this.class119_0.class159_4, new Class65.Delegate21(this.method_118))
			},
			{
				this.class119_0.class159_119.method_0(),
				new Class65.Class67(this.class119_0.class159_119, new Class65.Delegate21(this.method_147))
			},
			{
				this.class119_0.class159_163.method_0(),
				new Class65.Class67(this.class119_0.class159_163, new Class65.Delegate21(this.method_139))
			},
			{
				this.class119_0.class159_68.method_0(),
				new Class65.Class67(this.class119_0.class159_68, new Class65.Delegate21(this.method_185))
			},
			{
				this.class119_0.class159_15.method_0(),
				new Class65.Class67(this.class119_0.class159_15, new Class65.Delegate21(this.method_45))
			},
			{
				this.class119_0.class159_136.method_0(),
				new Class65.Class67(this.class119_0.class159_136, new Class65.Delegate21(this.method_295))
			},
			{
				this.class119_0.class159_28.method_0(),
				new Class65.Class67(this.class119_0.class159_28, new Class65.Delegate21(this.method_156))
			},
			{
				this.class119_0.class159_91.method_0(),
				new Class65.Class67(this.class119_0.class159_91, new Class65.Delegate21(this.method_32))
			},
			{
				this.class119_0.class159_90.method_0(),
				new Class65.Class67(this.class119_0.class159_90, new Class65.Delegate21(this.method_255))
			},
			{
				this.class119_0.class159_212.method_0(),
				new Class65.Class67(this.class119_0.class159_212, new Class65.Delegate21(this.method_263))
			},
			{
				this.class119_0.class159_127.method_0(),
				new Class65.Class67(this.class119_0.class159_127, new Class65.Delegate21(this.method_4))
			},
			{
				this.class119_0.class159_59.method_0(),
				new Class65.Class67(this.class119_0.class159_59, new Class65.Delegate21(this.method_167))
			},
			{
				this.class119_0.class159_97.method_0(),
				new Class65.Class67(this.class119_0.class159_97, new Class65.Delegate21(this.method_244))
			},
			{
				this.class119_0.class159_195.method_0(),
				new Class65.Class67(this.class119_0.class159_195, new Class65.Delegate21(this.method_89))
			},
			{
				this.class119_0.class159_80.method_0(),
				new Class65.Class67(this.class119_0.class159_80, new Class65.Delegate21(this.method_121))
			},
			{
				this.class119_0.class159_139.method_0(),
				new Class65.Class67(this.class119_0.class159_139, new Class65.Delegate21(this.method_194))
			},
			{
				this.class119_0.class159_39.method_0(),
				new Class65.Class67(this.class119_0.class159_39, new Class65.Delegate21(this.method_46))
			},
			{
				this.class119_0.class159_162.method_0(),
				new Class65.Class67(this.class119_0.class159_162, new Class65.Delegate21(this.method_205))
			},
			{
				this.class119_0.class159_167.method_0(),
				new Class65.Class67(this.class119_0.class159_167, new Class65.Delegate21(this.method_132))
			},
			{
				this.class119_0.class159_171.method_0(),
				new Class65.Class67(this.class119_0.class159_171, new Class65.Delegate21(this.method_29))
			},
			{
				this.class119_0.class159_10.method_0(),
				new Class65.Class67(this.class119_0.class159_10, new Class65.Delegate21(this.method_289))
			},
			{
				this.class119_0.class159_76.method_0(),
				new Class65.Class67(this.class119_0.class159_76, new Class65.Delegate21(this.method_64))
			},
			{
				this.class119_0.class159_69.method_0(),
				new Class65.Class67(this.class119_0.class159_69, new Class65.Delegate21(this.method_110))
			},
			{
				this.class119_0.class159_121.method_0(),
				new Class65.Class67(this.class119_0.class159_121, new Class65.Delegate21(this.method_30))
			},
			{
				this.class119_0.class159_79.method_0(),
				new Class65.Class67(this.class119_0.class159_79, new Class65.Delegate21(this.method_245))
			},
			{
				this.class119_0.class159_19.method_0(),
				new Class65.Class67(this.class119_0.class159_19, new Class65.Delegate21(this.method_276))
			},
			{
				this.class119_0.class159_145.method_0(),
				new Class65.Class67(this.class119_0.class159_145, new Class65.Delegate21(this.method_75))
			},
			{
				this.class119_0.class159_206.method_0(),
				new Class65.Class67(this.class119_0.class159_206, new Class65.Delegate21(this.method_220))
			},
			{
				this.class119_0.class159_103.method_0(),
				new Class65.Class67(this.class119_0.class159_103, new Class65.Delegate21(this.method_72))
			},
			{
				this.class119_0.class159_141.method_0(),
				new Class65.Class67(this.class119_0.class159_141, new Class65.Delegate21(this.method_142))
			},
			{
				this.class119_0.class159_64.method_0(),
				new Class65.Class67(this.class119_0.class159_64, new Class65.Delegate21(this.method_212))
			},
			{
				this.class119_0.class159_205.method_0(),
				new Class65.Class67(this.class119_0.class159_205, new Class65.Delegate21(this.method_166))
			},
			{
				this.class119_0.class159_180.method_0(),
				new Class65.Class67(this.class119_0.class159_180, new Class65.Delegate21(this.method_203))
			},
			{
				this.class119_0.class159_201.method_0(),
				new Class65.Class67(this.class119_0.class159_201, new Class65.Delegate21(this.method_178))
			},
			{
				this.class119_0.class159_153.method_0(),
				new Class65.Class67(this.class119_0.class159_153, new Class65.Delegate21(this.method_214))
			},
			{
				this.class119_0.class159_107.method_0(),
				new Class65.Class67(this.class119_0.class159_107, new Class65.Delegate21(this.method_266))
			}
		};
	}

	// Token: 0x06000269 RID: 617 RVA: 0x000191D8 File Offset: 0x000173D8
	private static bool smethod_5(Class80 class80_2, Class80 class80_3)
	{
		bool result = false;
		int num = class80_2.vmethod_2();
		if (num <= 14)
		{
			if (num == 8)
			{
				Class82 @class = new Class82();
				@class.method_3(Convert.ToInt64(((Class84)class80_2).method_2()));
				return Class65.smethod_5(@class, class80_3);
			}
			if (num == 14)
			{
				if (class80_3.vmethod_2() == 8)
				{
					Class98 class2 = new Class98();
					class2.method_3(Convert.ToInt32(((Class84)class80_3).method_2()));
					return Class65.smethod_5(class80_2, class2);
				}
				result = (((Class98)class80_2).method_2() > ((Class98)class80_3).method_2());
			}
		}
		else if (num != 16)
		{
			if (num == 19)
			{
				double num2 = ((Class86)class80_2).method_2();
				double num3 = ((Class86)class80_3).method_2();
				result = (!double.IsNaN(num2) && !double.IsNaN(num3) && num2 > num3);
			}
		}
		else
		{
			if (class80_3.vmethod_2() == 8)
			{
				Class82 class3 = new Class82();
				class3.method_3(Convert.ToInt64(((Class84)class80_3).method_2()));
				return Class65.smethod_5(class80_2, class3);
			}
			if (class80_3.vmethod_2() == 14)
			{
				Class82 class4 = new Class82();
				class4.method_3((long)((Class98)class80_3).method_2());
				return Class65.smethod_5(class80_2, class4);
			}
			result = (((Class82)class80_2).method_2() > ((Class82)class80_3).method_2());
		}
		return result;
	}

	// Token: 0x0600026A RID: 618 RVA: 0x0001931C File Offset: 0x0001751C
	private Type method_39(int int_0, Class0 class0_0, ref bool bool_2, bool bool_3)
	{
		if (class0_0.method_0() == 0)
		{
			return this.module_0.ResolveType(class0_0.method_2());
		}
		Class138 @class = (Class138)class0_0.method_4();
		Type type;
		if (@class.method_2())
		{
			if (@class.method_10() != -1)
			{
				if (this.type_2 == null)
				{
					throw new InvalidOperationException("EF-VM-0521");
				}
				type = this.type_2[@class.method_10()];
			}
			else
			{
				if (@class.method_8() == -1)
				{
					throw new Exception();
				}
				if (this.type_7 == null)
				{
					throw new InvalidOperationException("EF-VM-0522");
				}
				type = this.type_7[@class.method_8()];
			}
			Class15<Struct87> class2 = Class37.smethod_3(@class.method_0());
			type = Class37.smethod_4(type, class2);
			bool_2 = false;
			return type;
		}
		string text = @class.method_0();
		type = Type.GetType(text);
		if (type == null)
		{
			int num = text.IndexOf(',');
			string text2 = text.Substring(0, num);
			string text3 = text.Substring(num + 1).Trim();
			Assembly assembly_ = Class175.assembly_0;
			if (text3.Equals(assembly_.FullName, StringComparison.Ordinal))
			{
				type = assembly_.GetType(text2);
			}
			else
			{
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				int i = 0;
				while (i < assemblies.Length)
				{
					Assembly assembly = assemblies[i];
					string value = null;
					try
					{
						value = assembly.Location;
						goto IL_161;
					}
					catch (NotSupportedException)
					{
						goto IL_161;
					}
					goto IL_13E;
					IL_15B:
					i++;
					continue;
					IL_13E:
					if (!assembly.FullName.Equals(text3, StringComparison.Ordinal))
					{
						goto IL_15B;
					}
					type = assembly.GetType(text2);
					if (type == null)
					{
						goto IL_15B;
					}
					break;
					IL_161:
					if (string.IsNullOrEmpty(value))
					{
						goto IL_13E;
					}
					goto IL_15B;
				}
			}
			if (type == null && text2.StartsWith("<PrivateImplementationDetails><", StringComparison.Ordinal) && text2.Contains("."))
			{
				try
				{
					foreach (Type type2 in Assembly.Load(text3).GetTypes())
					{
						if (type2.FullName == text2)
						{
							type = type2;
							break;
						}
					}
				}
				catch
				{
				}
			}
		}
		if (@class.method_4())
		{
			Type[] array = new Type[@class.method_6().Length];
			for (int j = 0; j < @class.method_6().Length; j++)
			{
				array[j] = this.method_16(@class.method_6()[j].method_2(), bool_3);
			}
			if (array != null)
			{
				Type genericTypeDefinition = Class37.smethod_0(type).GetGenericTypeDefinition();
				Class15<Struct87> class3 = Class37.smethod_2(type);
				type = genericTypeDefinition.MakeGenericType(array);
				type = Class37.smethod_4(type, class3);
			}
			bool_2 = false;
		}
		return type;
	}

	// Token: 0x0600026B RID: 619 RVA: 0x00019590 File Offset: 0x00017790
	private Class80 method_40(Class123 class123_2, int int_0)
	{
		switch (int_0)
		{
		case 0:
		{
			Class92 @class = new Class92();
			@class.method_3(class123_2.method_20());
			return @class;
		}
		case 1:
			return null;
		case 2:
		{
			Class82 class2 = new Class82();
			class2.method_3(class123_2.method_21());
			return class2;
		}
		case 3:
		{
			Class86 class3 = new Class86();
			class3.method_3(class123_2.method_27());
			return class3;
		}
		case 4:
		case 7:
		{
			Class87 class4 = new Class87();
			class4.method_3(class123_2.method_24());
			return class4;
		}
		case 5:
		case 9:
		{
			Class88 class5 = new Class88();
			class5.method_3(class123_2.method_6());
			return class5;
		}
		case 6:
		case 11:
		{
			Class98 class6 = new Class98();
			class6.method_3(class123_2.method_19());
			return class6;
		}
		case 8:
		{
			int num = class123_2.method_19();
			Class98[] array = new Class98[num];
			for (int i = 0; i < num; i++)
			{
				Class98[] array2 = array;
				int num2 = i;
				Class98 class7 = new Class98();
				class7.method_3(class123_2.method_19());
				array2[num2] = class7;
			}
			Class93 class8 = new Class93();
			class8.method_3(array);
			return class8;
		}
		case 10:
		{
			Class85 class9 = new Class85();
			class9.method_3(class123_2.method_7());
			return class9;
		}
		case 12:
		{
			Class91 class10 = new Class91();
			class10.method_3(class123_2.method_26());
			return class10;
		}
		default:
			throw new Exception("Unknown operand type.");
		}
	}

	// Token: 0x0600026C RID: 620 RVA: 0x000196B0 File Offset: 0x000178B0
	private void method_41()
	{
		long num = this.class123_0.method_0().vmethod_4();
		int key = this.class123_0.method_19();
		Class65.Class67 @class;
		if (!this.dictionary_2.TryGetValue(key, out @class))
		{
			throw new InvalidOperationException("Unsupported instruction.");
		}
		this.long_0 = num;
		@class.delegate21_0(this.method_40(this.class123_0, @class.class159_0.method_2()));
	}

	// Token: 0x0600026D RID: 621 RVA: 0x00004025 File Offset: 0x00002225
	private void method_42(Class80 class80_2)
	{
		this.method_277(typeof(short));
	}

	// Token: 0x0600026E RID: 622 RVA: 0x00019720 File Offset: 0x00017920
	private Class159 method_43(int int_0)
	{
		foreach (Class159 @class in this.class119_0.method_0())
		{
			if (@class.method_0() == int_0)
			{
				return @class;
			}
		}
		return null;
	}

	// Token: 0x0600026F RID: 623 RVA: 0x00004037 File Offset: 0x00002237
	private void method_44(Class80 class80_2)
	{
		this.method_277(Class65.type_3);
	}

	// Token: 0x06000270 RID: 624 RVA: 0x00004044 File Offset: 0x00002244
	private void method_45(Class80 class80_2)
	{
		this.method_293(this.class80_1[3].vmethod_4());
	}

	// Token: 0x06000271 RID: 625 RVA: 0x0000405D File Offset: 0x0000225D
	private void method_46(Class80 class80_2)
	{
		this.method_277(typeof(long));
	}

	// Token: 0x06000272 RID: 626 RVA: 0x00019780 File Offset: 0x00017980
	private static void smethod_6(ILGenerator ilgenerator_0, int int_0)
	{
		switch (int_0)
		{
		case -1:
			ilgenerator_0.Emit(OpCodes.Ldc_I4_M1);
			return;
		case 0:
			ilgenerator_0.Emit(OpCodes.Ldc_I4_0);
			return;
		case 1:
			ilgenerator_0.Emit(OpCodes.Ldc_I4_1);
			return;
		case 2:
			ilgenerator_0.Emit(OpCodes.Ldc_I4_2);
			return;
		case 3:
			ilgenerator_0.Emit(OpCodes.Ldc_I4_3);
			return;
		case 4:
			ilgenerator_0.Emit(OpCodes.Ldc_I4_4);
			return;
		case 5:
			ilgenerator_0.Emit(OpCodes.Ldc_I4_5);
			return;
		case 6:
			ilgenerator_0.Emit(OpCodes.Ldc_I4_6);
			return;
		case 7:
			ilgenerator_0.Emit(OpCodes.Ldc_I4_7);
			return;
		case 8:
			ilgenerator_0.Emit(OpCodes.Ldc_I4_8);
			return;
		default:
			if (int_0 > -129 && int_0 < 128)
			{
				ilgenerator_0.Emit(OpCodes.Ldc_I4_S, (sbyte)int_0);
				return;
			}
			ilgenerator_0.Emit(OpCodes.Ldc_I4, int_0);
			return;
		}
	}

	// Token: 0x06000273 RID: 627 RVA: 0x00019860 File Offset: 0x00017A60
	private void method_47(int int_0, Type[] type_9, Type[] type_10, bool bool_2)
	{
		this.class123_1.method_0().vmethod_9((long)int_0, 0);
		this.method_9(this.class123_1);
		Class42 @class = this.method_238(this.class123_1);
		this.method_143(@class);
		int num = @class.method_2().Length;
		object[] array = new object[num];
		Class80[] array2 = new Class80[num];
		if (this.type_1 != null && bool_2)
		{
			int num2 = @class.method_12() ? 0 : 1;
			Type[] array3 = new Type[num - num2];
			for (int i = num - 1; i >= num2; i--)
			{
				array3[i] = this.method_16(@class.method_2()[i].method_0(), true);
			}
			MethodInfo method = this.type_1.GetMethod(@class.method_4(), BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.InvokeMethod | BindingFlags.GetProperty | BindingFlags.SetProperty, null, array3, null);
			this.type_1 = null;
			if (method != null)
			{
				this.method_105(method, true);
				return;
			}
		}
		for (int j = num - 1; j >= 0; j--)
		{
			Class80 class2 = this.method_112();
			array2[j] = class2;
			Class100 class100_;
			if ((class100_ = (class2 as Class100)) != null)
			{
				class2 = this.method_259(class100_);
			}
			if (class2.method_0() != null)
			{
				class2 = Class29.smethod_1(null, class2.method_0()).vmethod_3(class2);
			}
			Class80 class3 = Class29.smethod_1(null, this.method_16(@class.method_2()[j].method_0(), true)).vmethod_3(class2);
			array[j] = class3.vmethod_0();
			if (j == 0 && bool_2 && !@class.method_12() && array[j] == null)
			{
				throw new NullReferenceException();
			}
		}
		Class65 class4 = new Class65(this.class119_0);
		object[] object_ = new object[]
		{
			this.module_0.Assembly
		};
		object obj;
		try
		{
			obj = class4.method_290(this.stream_0, int_0, array, type_9, type_10, object_);
		}
		finally
		{
			for (int k = 0; k < array2.Length; k++)
			{
				Class100 class100_2;
				if ((class100_2 = (array2[k] as Class100)) != null)
				{
					object obj2 = array[k];
					this.method_241(class100_2, Class29.smethod_1(obj2, null));
				}
			}
		}
		Type type = class4.method_16(class4.class42_0.method_8(), true);
		if (type != Class65.type_4)
		{
			this.method_293(Class29.smethod_1(obj, type));
		}
	}

	// Token: 0x06000274 RID: 628 RVA: 0x00019AA4 File Offset: 0x00017CA4
	private void method_48(Class80 class80_2)
	{
		Class80 class80_3 = this.method_112();
		Class80 class80_4 = this.method_112();
		this.method_293(this.method_61(class80_4, class80_3, true));
	}

	// Token: 0x06000275 RID: 629 RVA: 0x00019AD0 File Offset: 0x00017CD0
	private static Class134 smethod_7(Class123 class123_2)
	{
		Class134 @class = new Class134();
		@class.method_3((int)class123_2.method_6());
		@class.method_1(class123_2.method_19());
		@class.method_9(class123_2.method_20());
		@class.method_5(class123_2.method_20());
		@class.method_11(class123_2.method_20());
		@class.method_7(class123_2.method_20());
		return @class;
	}

	// Token: 0x06000276 RID: 630 RVA: 0x00002D6B File Offset: 0x00000F6B
	private void method_49()
	{
	}

	// Token: 0x06000277 RID: 631 RVA: 0x00019B2C File Offset: 0x00017D2C
	private void method_50(Class80 class80_2)
	{
		Array array = (Array)this.method_112().vmethod_0();
		Class98 @class = new Class98();
		@class.method_3(array.Length);
		this.method_293(@class);
	}

	// Token: 0x06000278 RID: 632 RVA: 0x00019B64 File Offset: 0x00017D64
	private static bool smethod_8(Class80 class80_2, Class80 class80_3)
	{
		bool result = false;
		int num = class80_2.vmethod_2();
		if (num <= 14)
		{
			if (num == 8)
			{
				Class82 @class = new Class82();
				@class.method_3(Convert.ToInt64(((Class84)class80_2).method_2()));
				return Class65.smethod_8(@class, class80_3);
			}
			if (num == 14)
			{
				if (class80_3.vmethod_2() == 8)
				{
					Class98 class2 = new Class98();
					class2.method_3(Convert.ToInt32(((Class84)class80_3).method_2()));
					return Class65.smethod_8(class80_2, class2);
				}
				result = (((Class98)class80_2).method_2() < ((Class98)class80_3).method_2());
			}
		}
		else if (num != 16)
		{
			if (num == 19)
			{
				double num2 = ((Class86)class80_2).method_2();
				double num3 = ((Class86)class80_3).method_2();
				result = (num2 < num3 || double.IsNaN(num2) || double.IsNaN(num3));
			}
		}
		else
		{
			if (class80_3.vmethod_2() == 8)
			{
				Class82 class3 = new Class82();
				class3.method_3(Convert.ToInt64(((Class84)class80_3).method_2()));
				return Class65.smethod_8(class80_2, class3);
			}
			if (class80_3.vmethod_2() == 14)
			{
				Class82 class4 = new Class82();
				class4.method_3((long)((Class98)class80_3).method_2());
				return Class65.smethod_8(class80_2, class4);
			}
			result = (((Class82)class80_2).method_2() < ((Class82)class80_3).method_2());
		}
		return result;
	}

	// Token: 0x06000279 RID: 633 RVA: 0x00002D6B File Offset: 0x00000F6B
	[Conditional("DEBUG")]
	private void method_51(object object_3)
	{
	}

	// Token: 0x0600027A RID: 634 RVA: 0x0000406F File Offset: 0x0000226F
	private void method_52(Class80 class80_2)
	{
		this.method_55(false);
	}

	// Token: 0x0600027B RID: 635 RVA: 0x00019CA4 File Offset: 0x00017EA4
	private void method_53(Class80 class80_2)
	{
		Class80 @class = this.method_112();
		int num = @class.vmethod_2();
		bool flag;
		if (num <= 14)
		{
			if (num == 6)
			{
				flag = (((Class83)@class).method_2() != UIntPtr.Zero);
				goto IL_BE;
			}
			if (num == 8)
			{
				flag = Convert.ToBoolean(((Class84)@class).method_2());
				goto IL_BE;
			}
			if (num == 14)
			{
				flag = (((Class98)@class).method_2() != 0);
				goto IL_BE;
			}
		}
		else
		{
			if (num == 16)
			{
				flag = (((Class82)@class).method_2() != 0L);
				goto IL_BE;
			}
			if (num == 21)
			{
				flag = (((Class90)@class).method_2() != null);
				goto IL_BE;
			}
			if (num == 23)
			{
				flag = (((Class99)@class).method_2() != IntPtr.Zero);
				goto IL_BE;
			}
		}
		flag = (@class.vmethod_0() != null);
		IL_BE:
		if (flag)
		{
			uint uint_ = ((Class92)class80_2).method_2();
			this.method_273(uint_);
		}
	}

	// Token: 0x0600027C RID: 636 RVA: 0x00004078 File Offset: 0x00002278
	private void method_54(Class80 class80_2)
	{
		this.method_2(typeof(uint));
	}

	// Token: 0x0600027D RID: 637 RVA: 0x00019D88 File Offset: 0x00017F88
	private void method_55(bool bool_2)
	{
		Class80 @class = this.method_112();
		int num = @class.vmethod_2();
		int int_;
		if (num <= 14)
		{
			if (num != 8)
			{
				if (num == 14)
				{
					if (bool_2)
					{
						int_ = ((Class98)@class).method_2();
						goto IL_BB;
					}
					int_ = ((Class98)@class).method_2();
					goto IL_BB;
				}
			}
			else
			{
				if (bool_2)
				{
					int_ = checked((int)Convert.ToUInt64(((Class84)@class).method_2()));
					goto IL_BB;
				}
				int_ = (int)Convert.ToUInt64(((Class84)@class).method_2());
				goto IL_BB;
			}
		}
		else if (num != 16)
		{
			if (num == 19)
			{
				if (bool_2)
				{
					int_ = checked((int)((Class86)@class).method_2());
					goto IL_BB;
				}
				int_ = (int)((Class86)@class).method_2();
				goto IL_BB;
			}
		}
		else
		{
			if (bool_2)
			{
				int_ = checked((int)((Class82)@class).method_2());
				goto IL_BB;
			}
			int_ = (int)((Class82)@class).method_2();
			goto IL_BB;
		}
		throw new InvalidOperationException();
		IL_BB:
		Class98 class2 = new Class98();
		class2.method_3(int_);
		this.method_293(class2);
	}

	// Token: 0x0600027E RID: 638 RVA: 0x00002D6B File Offset: 0x00000F6B
	private void method_56(Class80 class80_2)
	{
	}

	// Token: 0x0600027F RID: 639 RVA: 0x00019E64 File Offset: 0x00018064
	private void method_57(MemberInfo memberInfo_0)
	{
		if (Class65.smethod_27() && !this.class42_0.method_13())
		{
			bool flag = false;
			Assembly assembly = typeof(SecurityCriticalAttribute).Assembly;
			MemberInfo memberInfo = memberInfo_0;
			while (memberInfo != null)
			{
				object[] customAttributes = memberInfo.GetCustomAttributes(false);
				for (int i = 0; i < customAttributes.Length; i++)
				{
					Type type = customAttributes[i].GetType();
					if (type.Assembly == assembly)
					{
						string fullName = type.FullName;
						if ("System.Security.SecurityCriticalAttribute".Equals(fullName, StringComparison.Ordinal))
						{
							flag = true;
							goto IL_91;
						}
						if ("System.Security.SecuritySafeCriticalAttribute".Equals(fullName, StringComparison.Ordinal))
						{
							goto IL_91;
						}
					}
				}
				memberInfo = memberInfo.DeclaringType;
				continue;
				IL_91:
				if (!flag)
				{
					return;
				}
				if (memberInfo_0 is MethodBase)
				{
					string string_ = Class65.smethod_3((MethodBase)memberInfo_0);
					throw Class65.smethod_13(this.method_152(this.class42_0), string_);
				}
				if (memberInfo_0 is FieldInfo)
				{
					Type declaringType = memberInfo_0.DeclaringType;
					string string_2 = string.Format("{0}.{1}", declaringType.FullName, memberInfo_0.Name);
					throw Class65.smethod_17(this.method_152(this.class42_0), string_2);
				}
				if (memberInfo_0 is Type)
				{
					string fullName2 = ((Type)memberInfo_0).FullName;
					throw Class65.smethod_22(this.method_152(this.class42_0), fullName2);
				}
				throw new SecurityException("A caller does not have the permissions required to access a resource.");
			}
			goto IL_91;
		}
	}

	// Token: 0x06000280 RID: 640 RVA: 0x0000408A File Offset: 0x0000228A
	private void method_58(Class80 class80_2)
	{
		this.method_293(this.class80_1[1].vmethod_4());
	}

	// Token: 0x06000281 RID: 641 RVA: 0x00019FA4 File Offset: 0x000181A4
	private FieldInfo method_59(int int_0, Class0 class0_0, ref bool bool_2)
	{
		if (class0_0.method_0() == 0)
		{
			bool_2 = false;
			return this.module_0.ResolveField(class0_0.method_2());
		}
		Class140 @class = (Class140)class0_0.method_4();
		Type type = this.method_16(@class.method_0().method_2(), false);
		if (type.IsGenericType)
		{
			bool_2 = false;
		}
		BindingFlags bindingAttr = Class65.smethod_24(@class.method_4());
		return type.GetField(@class.method_2(), bindingAttr);
	}

	// Token: 0x06000282 RID: 642 RVA: 0x00003F73 File Offset: 0x00002173
	private void method_60(Class80 class80_2)
	{
		this.method_269();
	}

	// Token: 0x06000283 RID: 643 RVA: 0x0001A010 File Offset: 0x00018210
	private Class80 method_61(Class80 class80_2, Class80 class80_3, bool bool_2)
	{
		if (class80_2.vmethod_2() == 14)
		{
			if (class80_3.vmethod_2() == 14)
			{
				if (!bool_2)
				{
					int num = ((Class98)class80_2).method_2();
					int num2 = ((Class98)class80_3).method_2();
					Class98 @class = new Class98();
					@class.method_3(num / num2);
					return @class;
				}
				uint num3 = (uint)((Class98)class80_2).method_2();
				uint num4 = (uint)((Class98)class80_3).method_2();
				Class98 class2 = new Class98();
				class2.method_3((int)(num3 / num4));
				return class2;
			}
			else
			{
				if (class80_3.vmethod_2() == 16)
				{
					Class82 class3 = new Class82();
					class3.method_3((long)((Class98)class80_2).method_2());
					return Class65.smethod_21(class3, class80_3, bool_2);
				}
				if (class80_3.vmethod_2() == 8)
				{
					Type underlyingType = Enum.GetUnderlyingType(class80_3.vmethod_0().GetType());
					if (underlyingType != typeof(long))
					{
						if (underlyingType != typeof(ulong))
						{
							Class98 class4 = new Class98();
							class4.method_3(Convert.ToInt32(class80_3.vmethod_0()));
							return this.method_61(class80_2, class4, bool_2);
						}
					}
					Class82 class5 = new Class82();
					class5.method_3((long)((Class98)class80_2).method_2());
					Class82 class6 = new Class82();
					class6.method_3(Convert.ToInt64(class80_3.vmethod_0()));
					return Class65.smethod_21(class5, class6, bool_2);
				}
			}
		}
		if (class80_2.vmethod_2() == 16)
		{
			if (class80_3.vmethod_2() == 16)
			{
				return Class65.smethod_21(class80_2, class80_3, bool_2);
			}
			if (class80_3.vmethod_2() == 14)
			{
				Class82 class7 = new Class82();
				class7.method_3((long)((Class98)class80_3).method_2());
				return Class65.smethod_21(class80_2, class7, bool_2);
			}
			if (class80_3.vmethod_2() == 8)
			{
				Type underlyingType2 = Enum.GetUnderlyingType(class80_3.vmethod_0().GetType());
				if (underlyingType2 != typeof(long))
				{
					if (underlyingType2 != typeof(ulong))
					{
						Class98 class8 = new Class98();
						class8.method_3(Convert.ToInt32(class80_3.vmethod_0()));
						return Class65.smethod_21(class80_2, class8, bool_2);
					}
				}
				Class82 class9 = new Class82();
				class9.method_3(Convert.ToInt64(class80_3.vmethod_0()));
				return Class65.smethod_21(class80_2, class9, bool_2);
			}
		}
		if (class80_2.vmethod_2() == 19 && class80_3.vmethod_2() == 19)
		{
			Class86 class10 = new Class86();
			class10.method_3(((Class86)class80_2).method_2() / ((Class86)class80_3).method_2());
			return class10;
		}
		if (class80_2.vmethod_2() == 8)
		{
			Type underlyingType3 = Enum.GetUnderlyingType(class80_2.vmethod_0().GetType());
			if (underlyingType3 != typeof(long))
			{
				if (underlyingType3 != typeof(ulong))
				{
					Class98 class11 = new Class98();
					class11.method_3(Convert.ToInt32(class80_2.vmethod_0()));
					return this.method_61(class11, class80_3, bool_2);
				}
			}
			Class82 class12 = new Class82();
			class12.method_3(Convert.ToInt64(class80_2.vmethod_0()));
			return this.method_61(class12, class80_3, bool_2);
		}
		throw new InvalidOperationException();
	}

	// Token: 0x06000284 RID: 644 RVA: 0x0001A2AC File Offset: 0x000184AC
	private void method_62(Class80 class80_2)
	{
		Class80 class80_3 = this.method_112();
		if (Class65.smethod_9(this.method_112(), class80_3))
		{
			uint uint_ = ((Class92)class80_2).method_2();
			this.method_273(uint_);
		}
	}

	// Token: 0x06000285 RID: 645 RVA: 0x0001A2E4 File Offset: 0x000184E4
	private void method_63(Class80 class80_2)
	{
		Class80 class80_3 = this.method_112();
		if (Class65.smethod_8(this.method_112(), class80_3))
		{
			uint uint_ = ((Class92)class80_2).method_2();
			this.method_273(uint_);
		}
	}

	// Token: 0x06000286 RID: 646 RVA: 0x0001A31C File Offset: 0x0001851C
	private static bool smethod_9(Class80 class80_2, Class80 class80_3)
	{
		bool result = false;
		int num = class80_2.vmethod_2();
		if (num <= 14)
		{
			if (num == 8)
			{
				Class82 @class = new Class82();
				@class.method_3(Convert.ToInt64(((Class84)class80_2).method_2()));
				return Class65.smethod_9(@class, class80_3);
			}
			if (num == 14)
			{
				if (class80_3.vmethod_2() == 8)
				{
					Class98 class2 = new Class98();
					class2.method_3(Convert.ToInt32(((Class84)class80_3).method_2()));
					return Class65.smethod_9(class80_2, class2);
				}
				result = (((Class98)class80_2).method_2() < ((Class98)class80_3).method_2());
			}
		}
		else if (num != 16)
		{
			if (num == 19)
			{
				result = (((Class86)class80_2).method_2() < ((Class86)class80_3).method_2());
			}
		}
		else
		{
			if (class80_3.vmethod_2() == 8)
			{
				Class82 class3 = new Class82();
				class3.method_3(Convert.ToInt64(((Class84)class80_3).method_2()));
				return Class65.smethod_9(class80_2, class3);
			}
			if (class80_3.vmethod_2() == 14)
			{
				Class82 class4 = new Class82();
				class4.method_3((long)((Class98)class80_3).method_2());
				return Class65.smethod_9(class80_2, class4);
			}
			result = (((Class82)class80_2).method_2() < ((Class82)class80_3).method_2());
		}
		return result;
	}

	// Token: 0x06000287 RID: 647 RVA: 0x0001A448 File Offset: 0x00018648
	private void method_64(Class80 class80_2)
	{
		Class80 @class = this.method_112();
		int num = @class.vmethod_2();
		uint num2;
		if (num != 8)
		{
			if (num != 14)
			{
				if (num != 16)
				{
					throw new InvalidOperationException();
				}
				num2 = (uint)((Class82)@class).method_2();
			}
			else
			{
				num2 = (uint)((Class98)@class).method_2();
			}
		}
		else
		{
			num2 = (uint)Convert.ToInt64(@class.vmethod_0());
		}
		Class98[] array = (Class98[])((Class93)class80_2).method_2();
		if ((ulong)num2 >= (ulong)((long)array.Length))
		{
			return;
		}
		uint uint_ = (uint)array[(int)num2].method_2();
		this.method_273(uint_);
	}

	// Token: 0x06000288 RID: 648 RVA: 0x0001A4D4 File Offset: 0x000186D4
	private Class80 method_65(Class80 class80_2, Class80 class80_3)
	{
		if (class80_2.vmethod_2() == 14)
		{
			if (class80_3.vmethod_2() == 14)
			{
				int num = ((Class98)class80_2).method_2();
				int num2 = ((Class98)class80_3).method_2();
				Class98 @class = new Class98();
				@class.method_3(num & num2);
				return @class;
			}
			if (class80_3.vmethod_2() == 8)
			{
				int num3 = ((Class98)class80_2).method_2();
				Type underlyingType = Enum.GetUnderlyingType(class80_3.vmethod_0().GetType());
				if (underlyingType != typeof(long))
				{
					if (underlyingType != typeof(ulong))
					{
						int num4 = Convert.ToInt32(class80_3.vmethod_0());
						Class98 class2 = new Class98();
						class2.method_3(num3 & num4);
						return class2;
					}
				}
				long num5 = Convert.ToInt64(class80_3.vmethod_0());
				Class82 class3 = new Class82();
				class3.method_3((long)num3 & num5);
				return class3;
			}
		}
		if (class80_2.vmethod_2() == 16)
		{
			if (class80_3.vmethod_2() == 16)
			{
				long num6 = ((Class82)class80_2).method_2();
				long num7 = ((Class82)class80_3).method_2();
				Class82 class4 = new Class82();
				class4.method_3(num6 & num7);
				return class4;
			}
			if (class80_3.vmethod_2() == 8)
			{
				int num8 = ((Class98)class80_2).method_2();
				long num9 = Convert.ToInt64(class80_3.vmethod_0());
				Class82 class5 = new Class82();
				class5.method_3((long)num8 & num9);
				return class5;
			}
		}
		if (class80_2.vmethod_2() == 8)
		{
			if (class80_3.vmethod_2() == 14)
			{
				int num10 = ((Class98)class80_3).method_2();
				Type underlyingType2 = Enum.GetUnderlyingType(class80_2.vmethod_0().GetType());
				if (underlyingType2 != typeof(long))
				{
					if (underlyingType2 != typeof(ulong))
					{
						int num11 = Convert.ToInt32(class80_2.vmethod_0());
						Class98 class6 = new Class98();
						class6.method_3(num11 & num10);
						return class6;
					}
				}
				long num12 = Convert.ToInt64(class80_3.vmethod_0());
				Class82 class7 = new Class82();
				class7.method_3(num12 & (long)num10);
				return class7;
			}
			if (class80_3.vmethod_2() == 16)
			{
				long num13 = Convert.ToInt64(class80_2.vmethod_0());
				long num14 = ((Class82)class80_3).method_2();
				Class82 class8 = new Class82();
				class8.method_3(num13 & num14);
				return class8;
			}
			if (class80_3.vmethod_2() == 8)
			{
				Type underlyingType3 = Enum.GetUnderlyingType(class80_2.vmethod_0().GetType());
				Type underlyingType4 = Enum.GetUnderlyingType(class80_3.vmethod_0().GetType());
				if (underlyingType3 != typeof(long) && underlyingType3 != typeof(ulong) && underlyingType4 != typeof(long))
				{
					if (underlyingType4 != typeof(ulong))
					{
						int num15 = Convert.ToInt32(class80_2.vmethod_0());
						int num16 = Convert.ToInt32(class80_3.vmethod_0());
						Class98 class9 = new Class98();
						class9.method_3(num15 & num16);
						return class9;
					}
				}
				long num17 = Convert.ToInt64(class80_2.vmethod_0());
				long num18 = Convert.ToInt64(class80_3.vmethod_0());
				Class82 class10 = new Class82();
				class10.method_3(num17 & num18);
				return class10;
			}
		}
		throw new InvalidOperationException();
	}

	// Token: 0x06000289 RID: 649 RVA: 0x0001A798 File Offset: 0x00018998
	public static void smethod_10<T>(T[] gparam_0, Comparison<T> comparison_0)
	{
		KeyValuePair<int, T>[] array = new KeyValuePair<int, T>[gparam_0.Length];
		for (int i = 0; i < gparam_0.Length; i++)
		{
			array[i] = new KeyValuePair<int, T>(i, gparam_0[i]);
		}
		Array.Sort<KeyValuePair<int, T>, T>(array, gparam_0, new Class65.Class71<T>(comparison_0));
	}

	// Token: 0x0600028A RID: 650 RVA: 0x0001A7E0 File Offset: 0x000189E0
	private void method_66(Class80 class80_2)
	{
		Class80 @class = this.method_112();
		this.method_260(@class.vmethod_0());
	}

	// Token: 0x0600028B RID: 651 RVA: 0x0001A800 File Offset: 0x00018A00
	private void method_67(bool bool_2)
	{
		Class80 @class = this.method_112();
		int num = @class.vmethod_2();
		uint int_;
		if (num <= 14)
		{
			if (num != 8)
			{
				if (num == 14)
				{
					if (bool_2)
					{
						int_ = checked((uint)((Class98)@class).method_2());
						goto IL_BD;
					}
					int_ = (uint)((ushort)((Class98)@class).method_2());
					goto IL_BD;
				}
			}
			else
			{
				if (bool_2)
				{
					int_ = checked((uint)Convert.ToUInt64(((Class84)@class).method_2()));
					goto IL_BD;
				}
				int_ = (uint)Convert.ToUInt64(((Class84)@class).method_2());
				goto IL_BD;
			}
		}
		else if (num != 16)
		{
			if (num == 19)
			{
				if (bool_2)
				{
					int_ = checked((uint)((Class86)@class).method_2());
					goto IL_BD;
				}
				int_ = (uint)((Class86)@class).method_2();
				goto IL_BD;
			}
		}
		else
		{
			if (bool_2)
			{
				int_ = checked((uint)((Class82)@class).method_2());
				goto IL_BD;
			}
			int_ = (uint)((Class82)@class).method_2();
			goto IL_BD;
		}
		throw new InvalidOperationException();
		IL_BD:
		Class98 class2 = new Class98();
		class2.method_3((int)int_);
		this.method_293(class2);
	}

	// Token: 0x0600028C RID: 652 RVA: 0x000040A3 File Offset: 0x000022A3
	private void method_68(Class80 class80_2)
	{
		this.method_272(false);
	}

	// Token: 0x0600028D RID: 653 RVA: 0x0001A8DC File Offset: 0x00018ADC
	private void method_69(Class80 class80_2)
	{
		int int_ = ((Class98)class80_2).method_2();
		Type t = this.method_16(int_, true);
		Class98 @class = new Class98();
		@class.method_3(Marshal.SizeOf(t));
		this.method_293(@class);
	}

	// Token: 0x0600028E RID: 654 RVA: 0x0001A918 File Offset: 0x00018B18
	private void method_70(Class80 class80_2)
	{
		object object_ = this.method_112().vmethod_0();
		long num = this.method_294();
		Array array = (Array)this.method_112().vmethod_0();
		Type elementType = array.GetType().GetElementType();
		checked
		{
			if (elementType == typeof(sbyte))
			{
				Class80 @class = Class29.smethod_1(object_, typeof(sbyte));
				((sbyte[])array)[(int)((IntPtr)num)] = (sbyte)@class.vmethod_0();
				return;
			}
			if (elementType == typeof(byte))
			{
				Class80 class2 = Class29.smethod_1(object_, typeof(byte));
				((byte[])array)[(int)((IntPtr)num)] = (byte)class2.vmethod_0();
				return;
			}
			if (elementType == typeof(bool))
			{
				Class80 class3 = Class29.smethod_1(object_, typeof(bool));
				((bool[])array)[(int)((IntPtr)num)] = (bool)class3.vmethod_0();
				return;
			}
			if (elementType.IsEnum)
			{
				this.method_287(elementType, object_, num, array);
				return;
			}
			this.method_287(typeof(sbyte), object_, num, array);
		}
	}

	// Token: 0x0600028F RID: 655 RVA: 0x0001AA1C File Offset: 0x00018C1C
	private void method_71(Class80 class80_2)
	{
		Class80 @class = this.method_112();
		int num = @class.vmethod_2();
		ulong long_;
		if (num <= 14)
		{
			if (num == 8)
			{
				long_ = Convert.ToUInt64(((Class84)@class).method_2());
				goto IL_6D;
			}
			if (num == 14)
			{
				long_ = (ulong)(checked((uint)((Class98)@class).method_2()));
				goto IL_6D;
			}
		}
		else
		{
			checked
			{
				if (num == 16)
				{
					long_ = (ulong)((Class82)@class).method_2();
					goto IL_6D;
				}
				if (num == 19)
				{
					long_ = (ulong)((Class86)@class).method_2();
					goto IL_6D;
				}
			}
		}
		throw new InvalidOperationException();
		IL_6D:
		Class82 class2 = new Class82();
		class2.method_3((long)long_);
		this.method_293(class2);
	}

	// Token: 0x06000290 RID: 656 RVA: 0x0001AAA8 File Offset: 0x00018CA8
	private static string smethod_11(string string_0, string string_1)
	{
		string fullName = typeof(Class65).Assembly.FullName;
		return string.Concat(new string[]
		{
			string.Format("Attempt by {0} to access {1} failed.", string_0, string_1),
			Environment.NewLine,
			Environment.NewLine,
			string.Format("Assembly '{0}' is marked with the AllowPartiallyTrustedCallersAttribute, and uses the level 2 security transparency model. ", fullName),
			"Level 2 transparency causes all methods in AllowPartiallyTrustedCallers assemblies to become security transparent by default, which may be the cause of this exception."
		});
	}

	// Token: 0x06000291 RID: 657 RVA: 0x000040AC File Offset: 0x000022AC
	private void method_72(Class80 class80_2)
	{
		this.method_277(typeof(byte));
	}

	// Token: 0x06000292 RID: 658 RVA: 0x0001AB0C File Offset: 0x00018D0C
	private void method_73(Class80 class80_2)
	{
		Class80 @class = this.method_112();
		int num = @class.vmethod_2();
		double double_;
		if (num != 8)
		{
			if (num != 14)
			{
				if (num != 16)
				{
					throw new InvalidOperationException();
				}
				double_ = ((Class82)@class).method_2();
			}
			else
			{
				double_ = ((Class98)@class).method_2();
			}
		}
		else
		{
			double_ = Convert.ToUInt64(((Class84)@class).method_2());
		}
		Class86 class2 = new Class86();
		class2.method_3(double_);
		this.method_293(class2);
	}

	// Token: 0x06000293 RID: 659 RVA: 0x000040BE File Offset: 0x000022BE
	private void method_74(Class80 class80_2)
	{
		this.method_123(false);
	}

	// Token: 0x06000294 RID: 660 RVA: 0x0001AB80 File Offset: 0x00018D80
	private void method_75(Class80 class80_2)
	{
		Class88 @class = (Class88)class80_2;
		Class103 class2 = new Class103();
		class2.method_3((int)@class.method_2());
		this.method_293(class2);
	}

	// Token: 0x06000295 RID: 661 RVA: 0x0001ABAC File Offset: 0x00018DAC
	private void method_76(Class80 class80_2)
	{
		Class88 @class = (Class88)class80_2;
		this.method_293(this.class80_1[(int)@class.method_2()].vmethod_4());
	}

	// Token: 0x06000296 RID: 662 RVA: 0x000040C7 File Offset: 0x000022C7
	private static void smethod_12(ILGenerator ilgenerator_0, Type type_9)
	{
		if (!type_9.IsValueType && !Class37.smethod_0(type_9).IsGenericParameter)
		{
			Class65.smethod_30(ilgenerator_0, type_9);
			return;
		}
		ilgenerator_0.Emit(OpCodes.Unbox_Any, type_9);
	}

	// Token: 0x06000297 RID: 663 RVA: 0x00003F73 File Offset: 0x00002173
	private void method_77(Class80 class80_2)
	{
		this.method_269();
	}

	// Token: 0x06000298 RID: 664 RVA: 0x0001ABDC File Offset: 0x00018DDC
	private void method_78(Class80 class80_2)
	{
		Class80 class80_3 = this.method_112();
		Class80 class80_4 = this.method_112();
		this.method_293(this.method_128(class80_4, class80_3, true, true));
	}

	// Token: 0x06000299 RID: 665 RVA: 0x0001AC08 File Offset: 0x00018E08
	private long method_79(string string_0)
	{
		MemoryStream memoryStream = new MemoryStream(Class61.smethod_0(string_0));
		long result = new Class123(new Class12(memoryStream, this.method_3())).method_21();
		memoryStream.Dispose();
		return result;
	}

	// Token: 0x0600029A RID: 666 RVA: 0x0001AC40 File Offset: 0x00018E40
	private void method_80(Class80 class80_2)
	{
		int int_ = ((Class98)class80_2).method_2();
		FieldInfo fieldInfo = this.method_223(int_);
		this.method_293(Class29.smethod_1(fieldInfo.GetValue(null), fieldInfo.FieldType));
	}

	// Token: 0x0600029B RID: 667 RVA: 0x000040F2 File Offset: 0x000022F2
	private static Exception smethod_13(string string_0, string string_1)
	{
		return new MethodAccessException(Class65.smethod_11(string.Format("security transparent method '{0}'", string_0), string.Format("security critical method '{0}'", string_1)));
	}

	// Token: 0x0600029C RID: 668 RVA: 0x00004114 File Offset: 0x00002314
	private void method_81(Class80 class80_2)
	{
		this.method_293(this.class80_0[3].vmethod_4());
	}

	// Token: 0x0600029D RID: 669 RVA: 0x0001AC7C File Offset: 0x00018E7C
	private static Class134[] smethod_14(Class123 class123_2)
	{
		int num = (int)class123_2.method_23();
		Class134[] array = new Class134[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = Class65.smethod_7(class123_2);
		}
		return array;
	}

	// Token: 0x0600029E RID: 670 RVA: 0x0001ACB4 File Offset: 0x00018EB4
	private void method_82(Class137 class137_0)
	{
		Class0 @class = this.method_111(class137_0.method_2());
		Class139 class2 = (Class139)@class.method_4();
		MethodBase methodBase = this.method_191(class137_0.method_2(), @class);
		methodBase.GetParameters();
		int num = class137_0.method_0();
		bool bool_ = (num & 1073741824) != 0;
		num &= -1073741825;
		Type[] array = this.type_2;
		Type[] array2 = this.type_7;
		try
		{
			this.type_2 = ((methodBase is ConstructorInfo) ? null : methodBase.GetGenericArguments());
			this.type_7 = methodBase.DeclaringType.GetGenericArguments();
			this.method_47(num, this.type_2, this.type_7, bool_);
		}
		finally
		{
			this.type_2 = array;
			this.type_7 = array2;
		}
	}

	// Token: 0x0600029F RID: 671 RVA: 0x0000412D File Offset: 0x0000232D
	private void method_83(Class80 class80_2)
	{
		Class98 @class = new Class98();
		@class.method_3(5);
		this.method_293(@class);
	}

	// Token: 0x060002A0 RID: 672 RVA: 0x000030C0 File Offset: 0x000012C0
	private static bool smethod_15()
	{
		return false;
	}

	// Token: 0x060002A1 RID: 673 RVA: 0x0001AD78 File Offset: 0x00018F78
	private void method_84(Class80 class80_2)
	{
		int int_ = ((Class98)class80_2).method_2();
		FieldInfo fieldInfo = this.method_223(int_);
		Class80 @class = Class29.smethod_1(this.method_112().vmethod_0(), fieldInfo.FieldType);
		fieldInfo.SetValue(null, @class.vmethod_0());
	}

	// Token: 0x060002A2 RID: 674 RVA: 0x0001ADC0 File Offset: 0x00018FC0
	private void method_85(Class80 class80_2)
	{
		Class80 class80_3 = this.method_112();
		Class80 class80_4 = this.method_112();
		this.method_293(this.method_285(class80_4, class80_3, true, false));
	}

	// Token: 0x060002A3 RID: 675 RVA: 0x0001ADEC File Offset: 0x00018FEC
	private object method_86(object[] object_3, Type[] type_9, Type[] type_10, object[] object_4)
	{
		if (object_3 == null)
		{
			object_3 = Class132<object>.gparam_0;
		}
		this.object_2 = object_4;
		this.type_2 = type_9;
		this.type_7 = type_10;
		this.class80_0 = this.method_28(object_3);
		this.class80_1 = this.method_120();
		object result;
		try
		{
			Class13 @class = new Class13(this.byte_0);
			try
			{
				using (this.class123_0 = new Class123(@class))
				{
					this.bool_0 = false;
					this.nullable_0 = null;
					this.class15_0.method_0();
					this.method_138();
				}
			}
			finally
			{
				((IDisposable)@class).Dispose();
			}
			Type type = this.method_16(this.class42_0.method_8(), false);
			if (type != Class65.type_4 && this.class15_0.Count > 0)
			{
				result = Class29.smethod_1(null, type).vmethod_3(this.method_112()).vmethod_0();
			}
			else
			{
				result = null;
			}
		}
		finally
		{
			for (int i = 0; i < this.class42_0.method_2().Length; i++)
			{
				Class128 class3 = this.class42_0.method_2()[i];
				if (class3.method_2())
				{
					Class102 class4 = (Class102)this.class80_0[i];
					Type type2 = this.method_16(class3.method_0(), false);
					object_3[i] = Class29.smethod_1(null, type2.GetElementType()).vmethod_3(class4.method_2()).vmethod_0();
				}
			}
			this.object_2 = null;
			this.class80_0 = null;
			this.class80_1 = null;
		}
		return result;
	}

	// Token: 0x060002A4 RID: 676 RVA: 0x00003F73 File Offset: 0x00002173
	private void method_87(Class80 class80_2)
	{
		this.method_269();
	}

	// Token: 0x060002A5 RID: 677 RVA: 0x0001AF90 File Offset: 0x00019190
	private void method_88(Class80 class80_2)
	{
		Class80 @class = this.method_112();
		int num = @class.vmethod_2();
		checked
		{
			byte int_;
			if (num <= 14)
			{
				if (num == 8)
				{
					int_ = (byte)Convert.ToUInt64(((Class84)@class).method_2());
					goto IL_6F;
				}
				if (num == 14)
				{
					int_ = (byte)((uint)((Class98)@class).method_2());
					goto IL_6F;
				}
			}
			else
			{
				if (num == 16)
				{
					int_ = (byte)((ulong)((Class82)@class).method_2());
					goto IL_6F;
				}
				if (num == 19)
				{
					int_ = (byte)((Class86)@class).method_2();
					goto IL_6F;
				}
			}
			throw new InvalidOperationException();
			IL_6F:
			Class98 class2 = new Class98();
			class2.method_3((int)int_);
			this.method_293(class2);
		}
	}

	// Token: 0x060002A6 RID: 678 RVA: 0x00004141 File Offset: 0x00002341
	private void method_89(Class80 class80_2)
	{
		throw new NotSupportedException("Cpobj is not supported.");
	}

	// Token: 0x060002A7 RID: 679 RVA: 0x0000414D File Offset: 0x0000234D
	private void method_90(Class80 class80_2)
	{
		throw new NotSupportedException("Cpblk not supported.");
	}

	// Token: 0x060002A8 RID: 680 RVA: 0x00004159 File Offset: 0x00002359
	private void method_91(Class80 class80_2)
	{
		this.method_281(true);
	}

	// Token: 0x060002A9 RID: 681 RVA: 0x00004162 File Offset: 0x00002362
	private void method_92(Class80 class80_2)
	{
		this.method_208(0);
	}

	// Token: 0x060002AA RID: 682 RVA: 0x0000416B File Offset: 0x0000236B
	public void method_93(Stream stream_1, string string_0, object[] object_3)
	{
		this.method_179(stream_1, string_0, object_3);
	}

	// Token: 0x060002AB RID: 683 RVA: 0x0001B020 File Offset: 0x00019220
	private void method_94(Class80 class80_2)
	{
		Class80 class80_3 = this.method_112();
		Class80 class80_4 = this.method_112();
		this.method_293(this.method_11(class80_4, class80_3));
	}

	// Token: 0x060002AC RID: 684 RVA: 0x0001B04C File Offset: 0x0001924C
	private void method_95(Class80 class80_2)
	{
		int int_ = ((Class98)class80_2).method_2();
		Class0 @class = this.method_111(int_);
		object obj;
		if (@class.method_0() == 0)
		{
			obj = this.method_236(@class.method_2());
		}
		else
		{
			switch (@class.method_4().vmethod_0())
			{
			case 1:
				obj = this.method_158(int_).MethodHandle;
				break;
			case 2:
				obj = this.method_223(int_).FieldHandle;
				break;
			case 3:
				obj = this.method_16(int_, true).TypeHandle;
				break;
			default:
				throw new InvalidOperationException();
			}
		}
		Class90 class2 = new Class90();
		class2.method_3(obj);
		this.method_293(class2);
	}

	// Token: 0x060002AD RID: 685 RVA: 0x0001B0F8 File Offset: 0x000192F8
	private void method_96(Class80 class80_2)
	{
		Class80 class80_3 = this.method_112();
		Class80 class80_4 = this.method_112();
		this.method_293(this.method_61(class80_4, class80_3, false));
	}

	// Token: 0x060002AE RID: 686 RVA: 0x00004177 File Offset: 0x00002377
	private void method_97(Class80 class80_2)
	{
		this.method_2(typeof(long));
	}

	// Token: 0x060002AF RID: 687 RVA: 0x0001B124 File Offset: 0x00019324
	private bool method_98(Class80 class80_2, Type type_9)
	{
		if (class80_2.vmethod_0() == null)
		{
			return true;
		}
		Type type = class80_2.method_0() ?? class80_2.vmethod_0().GetType();
		if (type != type_9 && !type_9.IsAssignableFrom(type))
		{
			if (!type.IsValueType && !type_9.IsValueType && Marshal.IsComObject(class80_2.vmethod_0()))
			{
				IntPtr intPtr;
				try
				{
					intPtr = Marshal.GetComInterfaceForObject(class80_2.vmethod_0(), type_9);
				}
				catch (InvalidCastException)
				{
					intPtr = IntPtr.Zero;
				}
				if (intPtr != IntPtr.Zero)
				{
					try
					{
						Marshal.Release(intPtr);
					}
					catch
					{
					}
					return true;
				}
			}
			return false;
		}
		return true;
	}

	// Token: 0x060002B0 RID: 688 RVA: 0x00004189 File Offset: 0x00002389
	private void method_99(Class80 class80_2)
	{
		Class98 @class = new Class98();
		@class.method_3(7);
		this.method_293(@class);
	}

	// Token: 0x060002B1 RID: 689 RVA: 0x0000419D File Offset: 0x0000239D
	private void method_100(Class80 class80_2)
	{
		Debugger.Break();
	}

	// Token: 0x060002B2 RID: 690 RVA: 0x0001B1D0 File Offset: 0x000193D0
	private void method_101(Class80 class80_2)
	{
		Class87 @class = (Class87)class80_2;
		this.method_208((int)@class.method_2());
	}

	// Token: 0x060002B3 RID: 691 RVA: 0x0001B1F0 File Offset: 0x000193F0
	private void method_102(Class80 class80_2)
	{
		int int_ = ((Class98)class80_2).method_2();
		string string_ = this.method_219(int_);
		Class96 @class = new Class96();
		@class.method_3(string_);
		this.method_293(@class);
	}

	// Token: 0x060002B4 RID: 692 RVA: 0x000041A4 File Offset: 0x000023A4
	private void method_103(Stream stream_1, string string_0)
	{
		this.method_1(stream_1, 0L, string_0);
	}

	// Token: 0x060002B5 RID: 693 RVA: 0x000041B7 File Offset: 0x000023B7
	private void method_104(Class80 class80_2)
	{
		this.method_208(2);
	}

	// Token: 0x060002B6 RID: 694 RVA: 0x0001B224 File Offset: 0x00019424
	private void method_105(MethodBase methodBase_0, bool bool_2)
	{
		bool flag;
		if ((flag = (!bool_2 && this.method_159(methodBase_0))) && Class65.Class69.bool_0)
		{
			methodBase_0 = Class65.Class70.smethod_0(this, this.class42_0, methodBase_0, bool_2);
		}
		ParameterInfo[] parameters = methodBase_0.GetParameters();
		int num = parameters.Length;
		Class80[] array = new Class80[num];
		object[] array2 = new object[num];
		Class65.Struct48 @struct = default(Class65.Struct48);
		try
		{
			this.method_254(ref @struct, methodBase_0, bool_2);
			for (int i = num - 1; i >= 0; i--)
			{
				Class80 @class = this.method_112();
				array[i] = @class;
				Class100 class100_;
				if ((class100_ = (@class as Class100)) != null)
				{
					@class = this.method_259(class100_);
				}
				if (@class.method_0() != null)
				{
					@class = Class29.smethod_1(null, @class.method_0()).vmethod_3(@class);
				}
				Class80 class2 = Class29.smethod_1(null, parameters[i].ParameterType).vmethod_3(@class);
				array2[i] = class2.vmethod_0();
			}
			Class80 class3 = null;
			if (!methodBase_0.IsStatic)
			{
				class3 = this.method_112();
				if (class3 != null && class3.method_0() != null)
				{
					class3 = Class29.smethod_1(null, class3.method_0()).vmethod_3(class3);
				}
			}
			object obj = null;
			try
			{
				Class100 class4;
				if (methodBase_0.IsConstructor)
				{
					obj = Activator.CreateInstance(methodBase_0.DeclaringType, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, array2, null);
					class4 = (class3 as Class100);
					if (class4 == null)
					{
						throw new InvalidOperationException();
					}
				}
				else
				{
					object obj2 = null;
					if (class3 != null)
					{
						Class80 class5 = class3;
						Class100 class100_2;
						if ((class100_2 = (class3 as Class100)) != null)
						{
							class5 = this.method_259(class100_2);
						}
						obj2 = class5.vmethod_0();
					}
					try
					{
						if (!this.method_197(methodBase_0, obj2, ref obj, array2))
						{
							if (bool_2 && !methodBase_0.IsStatic && obj2 == null)
							{
								throw new NullReferenceException();
							}
							if (!this.method_246(methodBase_0, obj2, array, array2, bool_2, ref obj))
							{
								MethodBase methodBase_ = methodBase_0;
								object object_ = obj2;
								if (flag && !Class65.Class69.bool_0)
								{
									MethodInfo methodInfo;
									object_ = Class65.Class68.smethod_0(obj2, methodBase_0, out methodInfo);
									methodBase_ = methodInfo;
								}
								obj = this.method_183(methodBase_, object_, array2, bool_2);
							}
						}
						Class100 class100_3;
						if ((class100_3 = (class3 as Class100)) != null)
						{
							this.method_241(class100_3, Class29.smethod_1(obj2, methodBase_0.DeclaringType));
						}
						goto IL_24C;
					}
					catch (TargetInvocationException ex)
					{
						Exception object_2 = ex.InnerException ?? ex;
						this.method_260(object_2);
						goto IL_24C;
					}
				}
				this.method_241(class4, Class29.smethod_1(obj, methodBase_0.DeclaringType));
			}
			finally
			{
				for (int j = 0; j < array.Length; j++)
				{
					Class100 class100_4;
					if ((class100_4 = (array[j] as Class100)) != null)
					{
						object obj3 = array2[j];
						this.method_241(class100_4, Class29.smethod_1(obj3, null));
					}
				}
			}
			IL_24C:
			MethodInfo methodInfo2 = methodBase_0 as MethodInfo;
			if (methodInfo2 != null)
			{
				Type returnType = methodInfo2.ReturnType;
				if (returnType != Class65.type_4)
				{
					this.method_293(Class29.smethod_1(obj, returnType));
				}
			}
		}
		finally
		{
			this.method_199(ref @struct);
		}
	}

	// Token: 0x060002B7 RID: 695 RVA: 0x0001B504 File Offset: 0x00019704
	private void method_106(Class80 class80_2)
	{
		Class80 @class = this.method_112();
		int num = @class.vmethod_2();
		checked
		{
			ushort int_;
			if (num <= 14)
			{
				if (num == 8)
				{
					int_ = (ushort)Convert.ToUInt64(((Class84)@class).method_2());
					goto IL_6F;
				}
				if (num == 14)
				{
					int_ = (ushort)((uint)((Class98)@class).method_2());
					goto IL_6F;
				}
			}
			else
			{
				if (num == 16)
				{
					int_ = (ushort)((ulong)((Class82)@class).method_2());
					goto IL_6F;
				}
				if (num == 19)
				{
					int_ = (ushort)((Class86)@class).method_2();
					goto IL_6F;
				}
			}
			throw new InvalidOperationException();
			IL_6F:
			Class98 class2 = new Class98();
			class2.method_3((int)int_);
			this.method_293(class2);
		}
	}

	// Token: 0x060002B8 RID: 696 RVA: 0x000041C0 File Offset: 0x000023C0
	private void method_107(Class80 class80_2)
	{
		this.method_277(typeof(uint));
	}

	// Token: 0x060002B9 RID: 697 RVA: 0x0001B594 File Offset: 0x00019794
	private void method_108(Class80 class80_2)
	{
		int int_ = ((Class98)class80_2).method_2();
		this.type_1 = this.method_16(int_, true);
	}

	// Token: 0x060002BA RID: 698 RVA: 0x0001B5BC File Offset: 0x000197BC
	private void method_109(Class80 class80_2)
	{
		Class80 class80_3 = this.method_112();
		if (Class65.smethod_5(this.method_112(), class80_3))
		{
			uint uint_ = ((Class92)class80_2).method_2();
			this.method_273(uint_);
		}
	}

	// Token: 0x060002BB RID: 699 RVA: 0x0001B5F4 File Offset: 0x000197F4
	private void method_110(Class80 class80_2)
	{
		Class98 @class = (Class98)class80_2;
		MethodBase methodBase = this.method_158(@class.method_2());
		Type declaringType = methodBase.DeclaringType;
		Type type = this.method_112().vmethod_0().GetType();
		ParameterInfo[] parameters = methodBase.GetParameters();
		Type[] array = new Type[parameters.Length];
		for (int i = 0; i < parameters.Length; i++)
		{
			array[i] = parameters[i].ParameterType;
		}
		MethodBase methodBase2 = null;
		for (Type type2 = type; type2 != null; type2 = type2.BaseType)
		{
			if (type2 == declaringType)
			{
				break;
			}
			MethodInfo method = type2.GetMethod(methodBase.Name, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.ExactBinding, null, CallingConventions.Any, array, null);
			if (method != null && method.GetBaseDefinition() == methodBase)
			{
				methodBase2 = method;
				break;
			}
		}
		if (methodBase2 == null)
		{
			methodBase2 = methodBase;
		}
		Class95 class2 = new Class95();
		class2.method_3(methodBase2);
		this.method_293(class2);
	}

	// Token: 0x060002BC RID: 700 RVA: 0x0001B6C4 File Offset: 0x000198C4
	private Class0 method_111(int int_0)
	{
		if (this.class123_1 == null)
		{
			throw new InvalidOperationException();
		}
		Class11 obj = this.class123_1.method_0();
		Class0 result;
		lock (obj)
		{
			this.class123_1.method_0().vmethod_9((long)int_0, 0);
			Class0 @class = new Class0();
			@class.method_1(this.class123_1.method_6());
			if (@class.method_0() == 0)
			{
				@class.method_3(this.class123_1.method_19());
			}
			else
			{
				@class.method_5(this.method_164(this.class123_1));
			}
			result = @class;
		}
		return result;
	}

	// Token: 0x060002BD RID: 701 RVA: 0x000041D2 File Offset: 0x000023D2
	private Class80 method_112()
	{
		return this.class15_0.method_6();
	}

	// Token: 0x060002BE RID: 702 RVA: 0x000041DF File Offset: 0x000023DF
	private void method_113(Class80 class80_2)
	{
		this.method_206(false);
	}

	// Token: 0x060002BF RID: 703 RVA: 0x0001B768 File Offset: 0x00019968
	private void method_114(Class80 class80_2)
	{
		Class80 class80_3 = this.method_112();
		if (Class65.smethod_0(this.method_112(), class80_3))
		{
			uint uint_ = ((Class92)class80_2).method_2();
			this.method_273(uint_);
		}
	}

	// Token: 0x060002C0 RID: 704 RVA: 0x0001B7A0 File Offset: 0x000199A0
	private bool method_115(MethodBase methodBase_0, object object_3, ref object object_4, object[] object_5)
	{
		if (!methodBase_0.IsStatic && methodBase_0.Name == "Address")
		{
			MethodInfo methodInfo = methodBase_0 as MethodInfo;
			if (methodInfo != null)
			{
				Type type = methodInfo.ReturnType;
				if (type.IsByRef)
				{
					type = type.GetElementType();
					int num = object_5.Length;
					if (num >= 1 && object_5[0] is int)
					{
						int[] array = new int[num];
						for (int i = 0; i < num; i++)
						{
							array[i] = (int)object_5[i];
						}
						Class105 @class = new Class105();
						@class.method_5((Array)object_3);
						@class.method_7(array);
						@class.method_3(type);
						object_4 = @class;
						return true;
					}
				}
			}
		}
		return false;
	}

	// Token: 0x060002C1 RID: 705 RVA: 0x0001B844 File Offset: 0x00019A44
	private void method_116()
	{
		long num = this.class123_0.method_0().vmethod_3();
		while (!this.bool_0)
		{
			if (this.nullable_0 != null)
			{
				this.class123_0.method_0().vmethod_5((long)((ulong)this.nullable_0.Value));
				this.nullable_0 = null;
			}
			this.method_137();
			if (this.class123_0.method_0().vmethod_4() >= num && this.nullable_0 == null)
			{
				break;
			}
		}
	}

	// Token: 0x060002C2 RID: 706 RVA: 0x000041E8 File Offset: 0x000023E8
	private void method_117(Class80 class80_2)
	{
		this.method_293(this.class80_0[0].vmethod_4());
	}

	// Token: 0x060002C3 RID: 707 RVA: 0x00004201 File Offset: 0x00002401
	private void method_118(Class80 class80_2)
	{
		Class98 @class = new Class98();
		@class.method_3(3);
		this.method_293(@class);
	}

	// Token: 0x060002C4 RID: 708 RVA: 0x00004215 File Offset: 0x00002415
	private void method_119(Class80 class80_2)
	{
		this.method_208(1);
	}

	// Token: 0x060002C5 RID: 709 RVA: 0x0001B8C8 File Offset: 0x00019AC8
	private Class80[] method_120()
	{
		Class24[] array = this.class42_0.method_0();
		int num = array.Length;
		Class80[] array2 = new Class80[num];
		for (int i = 0; i < num; i++)
		{
			array2[i] = Class29.smethod_1(null, this.method_16(array[i].method_0(), false));
		}
		return array2;
	}

	// Token: 0x060002C6 RID: 710 RVA: 0x0000421E File Offset: 0x0000241E
	private void method_121(Class80 class80_2)
	{
		this.method_67(true);
	}

	// Token: 0x060002C7 RID: 711 RVA: 0x00004227 File Offset: 0x00002427
	private void method_122(Class80 class80_2)
	{
		this.method_297(true);
	}

	// Token: 0x060002C8 RID: 712 RVA: 0x0001B91C File Offset: 0x00019B1C
	private void method_123(bool bool_2)
	{
		Class80 @class = this.method_112();
		int num = @class.vmethod_2();
		ulong long_;
		if (num <= 14)
		{
			if (num != 8)
			{
				if (num == 14)
				{
					if (bool_2)
					{
						long_ = (ulong)(checked((uint)((Class98)@class).method_2()));
						goto IL_BB;
					}
					long_ = (ulong)((Class98)@class).method_2();
					goto IL_BB;
				}
			}
			else
			{
				if (bool_2)
				{
					long_ = Convert.ToUInt64(((Class84)@class).method_2());
					goto IL_BB;
				}
				long_ = Convert.ToUInt64(((Class84)@class).method_2());
				goto IL_BB;
			}
		}
		else if (num != 16)
		{
			if (num == 19)
			{
				if (bool_2)
				{
					long_ = checked((ulong)((Class86)@class).method_2());
					goto IL_BB;
				}
				long_ = (ulong)((Class86)@class).method_2();
				goto IL_BB;
			}
		}
		else
		{
			if (bool_2)
			{
				long_ = checked((ulong)((Class82)@class).method_2());
				goto IL_BB;
			}
			long_ = (ulong)((Class82)@class).method_2();
			goto IL_BB;
		}
		throw new InvalidOperationException();
		IL_BB:
		Class82 class2 = new Class82();
		class2.method_3((long)long_);
		this.method_293(class2);
	}

	// Token: 0x060002C9 RID: 713 RVA: 0x00004230 File Offset: 0x00002430
	private void method_124(Class80 class80_2)
	{
		this.method_242(Class65.type_3);
	}

	// Token: 0x060002CA RID: 714 RVA: 0x0001B9F8 File Offset: 0x00019BF8
	private void method_125(Class80 class80_2)
	{
		Class80 class80_3 = this.method_112();
		Class80 class80_4 = this.method_112();
		Class98 @class = new Class98();
		@class.method_3(Class65.smethod_8(class80_4, class80_3) ? 1 : 0);
		this.method_293(@class);
	}

	// Token: 0x060002CB RID: 715 RVA: 0x00003F73 File Offset: 0x00002173
	private void method_126(Class80 class80_2)
	{
		this.method_269();
	}

	// Token: 0x060002CC RID: 716 RVA: 0x0001BA34 File Offset: 0x00019C34
	private Class65.Delegate20 method_127(Class65.Struct50 struct50_0)
	{
		Dictionary<Class65.Struct50, Class65.Delegate20> obj = this.dictionary_4;
		Class65.Delegate20 result;
		lock (obj)
		{
			this.dictionary_4.TryGetValue(struct50_0, out result);
		}
		return result;
	}

	// Token: 0x060002CD RID: 717 RVA: 0x0001BA78 File Offset: 0x00019C78
	private Class80 method_128(Class80 class80_2, Class80 class80_3, bool bool_2, bool bool_3)
	{
		if (class80_2.vmethod_2() == 14)
		{
			if (class80_3.vmethod_2() == 14)
			{
				if (!bool_3)
				{
					int num = ((Class98)class80_2).method_2();
					int num2 = ((Class98)class80_3).method_2();
					int int_;
					if (bool_2)
					{
						int_ = checked(num - num2);
					}
					else
					{
						int_ = num - num2;
					}
					Class98 @class = new Class98();
					@class.method_3(int_);
					return @class;
				}
				uint num3 = (uint)((Class98)class80_2).method_2();
				uint num4 = (uint)((Class98)class80_3).method_2();
				uint int_2;
				if (bool_2)
				{
					int_2 = checked(num3 - num4);
				}
				else
				{
					int_2 = num3 - num4;
				}
				Class98 class2 = new Class98();
				class2.method_3((int)int_2);
				return class2;
			}
			else
			{
				if (class80_3.vmethod_2() == 16)
				{
					Class82 class3 = new Class82();
					class3.method_3((long)((Class98)class80_2).method_2());
					return Class65.smethod_1(class3, class80_3, bool_2, bool_3);
				}
				if (class80_3.vmethod_2() == 8)
				{
					Type underlyingType = Enum.GetUnderlyingType(class80_3.vmethod_0().GetType());
					if (underlyingType != typeof(long))
					{
						if (underlyingType != typeof(ulong))
						{
							Class98 class4 = new Class98();
							class4.method_3(Convert.ToInt32(class80_3.vmethod_0()));
							return this.method_128(class80_2, class4, bool_2, bool_3);
						}
					}
					Class82 class5 = new Class82();
					class5.method_3((long)((Class98)class80_2).method_2());
					Class82 class6 = new Class82();
					class6.method_3(Convert.ToInt64(class80_3.vmethod_0()));
					return Class65.smethod_1(class5, class6, bool_2, bool_3);
				}
			}
		}
		if (class80_2.vmethod_2() == 16)
		{
			if (class80_3.vmethod_2() == 16)
			{
				return Class65.smethod_1(class80_2, class80_3, bool_2, bool_3);
			}
			if (class80_3.vmethod_2() == 14)
			{
				Class82 class7 = new Class82();
				class7.method_3((long)((Class98)class80_3).method_2());
				return Class65.smethod_1(class80_2, class7, bool_2, bool_3);
			}
			if (class80_3.vmethod_2() == 8)
			{
				Type underlyingType2 = Enum.GetUnderlyingType(class80_3.vmethod_0().GetType());
				if (underlyingType2 != typeof(long))
				{
					if (underlyingType2 != typeof(ulong))
					{
						Class98 class8 = new Class98();
						class8.method_3(Convert.ToInt32(class80_3.vmethod_0()));
						return Class65.smethod_1(class80_2, class8, bool_2, bool_3);
					}
				}
				Class82 class9 = new Class82();
				class9.method_3(Convert.ToInt64(class80_3.vmethod_0()));
				return Class65.smethod_1(class80_2, class9, bool_2, bool_3);
			}
		}
		if (class80_2.vmethod_2() == 19 && class80_3.vmethod_2() == 19)
		{
			Class86 class10 = new Class86();
			class10.method_3(((Class86)class80_2).method_2() - ((Class86)class80_3).method_2());
			return class10;
		}
		if (class80_2.vmethod_2() == 8)
		{
			Type underlyingType3 = Enum.GetUnderlyingType(class80_2.vmethod_0().GetType());
			if (underlyingType3 != typeof(long))
			{
				if (underlyingType3 != typeof(ulong))
				{
					Class98 class11 = new Class98();
					class11.method_3(Convert.ToInt32(class80_2.vmethod_0()));
					return this.method_128(class11, class80_3, bool_2, bool_3);
				}
			}
			Class82 class12 = new Class82();
			class12.method_3(Convert.ToInt64(class80_2.vmethod_0()));
			return this.method_128(class12, class80_3, bool_2, bool_3);
		}
		throw new InvalidOperationException();
	}

	// Token: 0x060002CE RID: 718 RVA: 0x0001BD48 File Offset: 0x00019F48
	private void method_129(Class80 class80_2)
	{
		Class80 class80_3 = this.method_112();
		this.method_293(this.method_163(class80_3));
	}

	// Token: 0x060002CF RID: 719 RVA: 0x0001BD6C File Offset: 0x00019F6C
	private void method_130(Class80 class80_2)
	{
		Class80 @class = this.method_112();
		int num = @class.vmethod_2();
		double double_;
		if (num <= 14)
		{
			if (num == 8)
			{
				double_ = Convert.ToUInt64(((Class84)@class).method_2());
				goto IL_6D;
			}
			if (num == 14)
			{
				double_ = (double)((Class98)@class).method_2();
				goto IL_6D;
			}
		}
		else
		{
			if (num == 16)
			{
				double_ = (double)((Class82)@class).method_2();
				goto IL_6D;
			}
			if (num == 19)
			{
				double_ = ((Class86)@class).method_2();
				goto IL_6D;
			}
		}
		throw new InvalidOperationException();
		IL_6D:
		Class86 class2 = new Class86();
		class2.method_3(double_);
		this.method_293(class2);
	}

	// Token: 0x060002D0 RID: 720 RVA: 0x0001BDF8 File Offset: 0x00019FF8
	private Class80 method_131(Class80 class80_2, Class80 class80_3)
	{
		if (class80_2.vmethod_2() == 14)
		{
			if (class80_3.vmethod_2() == 14)
			{
				int num = ((Class98)class80_2).method_2();
				int num2 = ((Class98)class80_3).method_2();
				Class98 @class = new Class98();
				@class.method_3(num ^ num2);
				return @class;
			}
			if (class80_3.vmethod_2() == 8)
			{
				int num3 = ((Class98)class80_2).method_2();
				Type underlyingType = Enum.GetUnderlyingType(class80_3.vmethod_0().GetType());
				if (underlyingType != typeof(long))
				{
					if (underlyingType != typeof(ulong))
					{
						int num4 = Convert.ToInt32(class80_3.vmethod_0());
						Class98 class2 = new Class98();
						class2.method_3(num3 ^ num4);
						return class2;
					}
				}
				long num5 = Convert.ToInt64(class80_3.vmethod_0());
				Class82 class3 = new Class82();
				class3.method_3((long)num3 ^ num5);
				return class3;
			}
		}
		if (class80_2.vmethod_2() == 16)
		{
			if (class80_3.vmethod_2() == 16)
			{
				long num6 = ((Class82)class80_2).method_2();
				long num7 = ((Class82)class80_3).method_2();
				Class82 class4 = new Class82();
				class4.method_3(num6 ^ num7);
				return class4;
			}
			if (class80_3.vmethod_2() == 8)
			{
				int num8 = ((Class98)class80_2).method_2();
				long num9 = Convert.ToInt64(class80_3.vmethod_0());
				Class82 class5 = new Class82();
				class5.method_3((long)num8 ^ num9);
				return class5;
			}
		}
		if (class80_2.vmethod_2() == 8)
		{
			if (class80_3.vmethod_2() == 14)
			{
				int num10 = ((Class98)class80_3).method_2();
				Type underlyingType2 = Enum.GetUnderlyingType(class80_2.vmethod_0().GetType());
				if (underlyingType2 != typeof(long))
				{
					if (underlyingType2 != typeof(ulong))
					{
						int num11 = Convert.ToInt32(class80_2.vmethod_0());
						Class98 class6 = new Class98();
						class6.method_3(num11 ^ num10);
						return class6;
					}
				}
				long num12 = Convert.ToInt64(class80_3.vmethod_0());
				Class82 class7 = new Class82();
				class7.method_3(num12 ^ (long)num10);
				return class7;
			}
			if (class80_3.vmethod_2() == 16)
			{
				long num13 = Convert.ToInt64(class80_2.vmethod_0());
				long num14 = ((Class82)class80_3).method_2();
				Class82 class8 = new Class82();
				class8.method_3(num13 ^ num14);
				return class8;
			}
			if (class80_3.vmethod_2() == 8)
			{
				Type underlyingType3 = Enum.GetUnderlyingType(class80_2.vmethod_0().GetType());
				Type underlyingType4 = Enum.GetUnderlyingType(class80_3.vmethod_0().GetType());
				if (underlyingType3 != typeof(long) && underlyingType3 != typeof(ulong) && underlyingType4 != typeof(long))
				{
					if (underlyingType4 != typeof(ulong))
					{
						int num15 = Convert.ToInt32(class80_2.vmethod_0());
						int num16 = Convert.ToInt32(class80_3.vmethod_0());
						Class98 class9 = new Class98();
						class9.method_3(num15 ^ num16);
						return class9;
					}
				}
				long num17 = Convert.ToInt64(class80_2.vmethod_0());
				long num18 = Convert.ToInt64(class80_3.vmethod_0());
				Class82 class10 = new Class82();
				class10.method_3(num17 ^ num18);
				return class10;
			}
		}
		throw new InvalidOperationException();
	}

	// Token: 0x060002D1 RID: 721 RVA: 0x0001C0BC File Offset: 0x0001A2BC
	private void method_132(Class80 class80_2)
	{
		Class80 class80_3 = this.method_112();
		if (!Class65.smethod_9(this.method_112(), class80_3))
		{
			uint uint_ = ((Class92)class80_2).method_2();
			this.method_273(uint_);
		}
	}

	// Token: 0x060002D2 RID: 722 RVA: 0x0001C0F4 File Offset: 0x0001A2F4
	private void method_133(Class80 class80_2)
	{
		Class80 class80_3 = this.method_112();
		Class80 class80_4 = this.method_112();
		this.method_293(this.method_33(class80_4, class80_3, true, false));
	}

	// Token: 0x060002D3 RID: 723 RVA: 0x0000423D File Offset: 0x0000243D
	private static void smethod_16(object object_3)
	{
		throw object_3;
	}

	// Token: 0x060002D4 RID: 724 RVA: 0x00004240 File Offset: 0x00002440
	private void method_134(Class80 class80_2)
	{
		Class98 @class = new Class98();
		@class.method_3(1);
		this.method_293(@class);
	}

	// Token: 0x060002D5 RID: 725 RVA: 0x00003FF2 File Offset: 0x000021F2
	private void method_135(Class80 class80_2)
	{
		this.method_293(class80_2);
	}

	// Token: 0x060002D6 RID: 726 RVA: 0x0001C120 File Offset: 0x0001A320
	private Class80 method_136(Class80 class80_2, Class80 class80_3, bool bool_2)
	{
		if (class80_2.vmethod_2() == 14)
		{
			if (class80_3.vmethod_2() == 14)
			{
				if (!bool_2)
				{
					int num = ((Class98)class80_2).method_2();
					int num2 = ((Class98)class80_3).method_2();
					Class98 @class = new Class98();
					@class.method_3(num % num2);
					return @class;
				}
				uint num3 = (uint)((Class98)class80_2).method_2();
				uint num4 = (uint)((Class98)class80_3).method_2();
				Class98 class2 = new Class98();
				class2.method_3((int)(num3 % num4));
				return class2;
			}
			else
			{
				if (class80_3.vmethod_2() == 16)
				{
					Class82 class3 = new Class82();
					class3.method_3((long)((Class98)class80_2).method_2());
					return Class65.smethod_20(class3, class80_3, bool_2);
				}
				if (class80_3.vmethod_2() == 8)
				{
					Type underlyingType = Enum.GetUnderlyingType(class80_3.vmethod_0().GetType());
					if (underlyingType != typeof(long))
					{
						if (underlyingType != typeof(ulong))
						{
							Class98 class4 = new Class98();
							class4.method_3(Convert.ToInt32(class80_3.vmethod_0()));
							return this.method_136(class80_2, class4, bool_2);
						}
					}
					Class82 class5 = new Class82();
					class5.method_3((long)((Class98)class80_2).method_2());
					Class82 class6 = new Class82();
					class6.method_3(Convert.ToInt64(class80_3.vmethod_0()));
					return Class65.smethod_20(class5, class6, bool_2);
				}
			}
		}
		if (class80_2.vmethod_2() == 16)
		{
			if (class80_3.vmethod_2() == 16)
			{
				return Class65.smethod_20(class80_2, class80_3, bool_2);
			}
			if (class80_3.vmethod_2() == 14)
			{
				Class82 class7 = new Class82();
				class7.method_3((long)((Class98)class80_3).method_2());
				return Class65.smethod_20(class80_2, class7, bool_2);
			}
			if (class80_3.vmethod_2() == 8)
			{
				Type underlyingType2 = Enum.GetUnderlyingType(class80_3.vmethod_0().GetType());
				if (underlyingType2 != typeof(long))
				{
					if (underlyingType2 != typeof(ulong))
					{
						Class98 class8 = new Class98();
						class8.method_3(Convert.ToInt32(class80_3.vmethod_0()));
						return Class65.smethod_20(class80_2, class8, bool_2);
					}
				}
				Class82 class9 = new Class82();
				class9.method_3(Convert.ToInt64(class80_3.vmethod_0()));
				return Class65.smethod_20(class80_2, class9, bool_2);
			}
		}
		if (class80_2.vmethod_2() == 19 && class80_3.vmethod_2() == 19)
		{
			Class86 class10 = new Class86();
			class10.method_3(((Class86)class80_2).method_2() % ((Class86)class80_3).method_2());
			return class10;
		}
		if (class80_2.vmethod_2() == 8)
		{
			Type underlyingType3 = Enum.GetUnderlyingType(class80_2.vmethod_0().GetType());
			if (underlyingType3 != typeof(long))
			{
				if (underlyingType3 != typeof(ulong))
				{
					Class98 class11 = new Class98();
					class11.method_3(Convert.ToInt32(class80_2.vmethod_0()));
					return this.method_136(class11, class80_3, bool_2);
				}
			}
			Class82 class12 = new Class82();
			class12.method_3(Convert.ToInt64(class80_2.vmethod_0()));
			return this.method_136(class12, class80_3, bool_2);
		}
		throw new InvalidOperationException();
	}

	// Token: 0x060002D7 RID: 727 RVA: 0x0001C3BC File Offset: 0x0001A5BC
	private void method_137()
	{
		try
		{
			this.method_41();
		}
		catch (object object_)
		{
			this.method_145(object_, 0u);
		}
	}

	// Token: 0x060002D8 RID: 728 RVA: 0x0001C3EC File Offset: 0x0001A5EC
	private void method_138()
	{
		try
		{
			this.method_116();
		}
		catch (Exception object_)
		{
			this.method_145(object_, 0u);
			this.method_116();
		}
	}

	// Token: 0x060002D9 RID: 729 RVA: 0x00004254 File Offset: 0x00002454
	private void method_139(Class80 class80_2)
	{
		this.method_224(true);
	}

	// Token: 0x060002DA RID: 730 RVA: 0x00002D6B File Offset: 0x00000F6B
	private void method_140(Class80 class80_2)
	{
	}

	// Token: 0x060002DB RID: 731 RVA: 0x00003F73 File Offset: 0x00002173
	private void method_141(Class80 class80_2)
	{
		this.method_269();
	}

	// Token: 0x060002DC RID: 732 RVA: 0x0001C424 File Offset: 0x0001A624
	private void method_142(Class80 class80_2)
	{
		Class80 @class = this.method_112();
		int num = @class.vmethod_2();
		float num2;
		if (num <= 14)
		{
			if (num == 8)
			{
				num2 = Convert.ToUInt64(((Class84)@class).method_2());
				goto IL_6E;
			}
			if (num == 14)
			{
				num2 = (float)((Class98)@class).method_2();
				goto IL_6E;
			}
		}
		else
		{
			if (num == 16)
			{
				num2 = (float)((Class82)@class).method_2();
				goto IL_6E;
			}
			if (num == 19)
			{
				num2 = (float)((Class86)@class).method_2();
				goto IL_6E;
			}
		}
		throw new InvalidOperationException();
		IL_6E:
		Class86 class2 = new Class86();
		class2.method_3((double)num2);
		this.method_293(class2);
	}

	// Token: 0x060002DD RID: 733 RVA: 0x0001C4B4 File Offset: 0x0001A6B4
	private void method_143(Class42 class42_1)
	{
		if (Class65.smethod_27() && !this.class42_0.method_13() && class42_1.method_13() && !class42_1.method_14())
		{
			string string_ = this.method_152(class42_1);
			throw Class65.smethod_13(this.method_152(this.class42_0), string_);
		}
	}

	// Token: 0x060002DE RID: 734 RVA: 0x0001C500 File Offset: 0x0001A700
	private void method_144(Class80 class80_2)
	{
		Class80 class80_3 = this.method_112();
		Class80 class80_4 = this.method_112();
		this.method_293(this.method_33(class80_4, class80_3, false, false));
	}

	// Token: 0x060002DF RID: 735 RVA: 0x0001C52C File Offset: 0x0001A72C
	private void method_145(object object_3, uint uint_0)
	{
		bool flag = object_3 != null;
		this.object_1 = object_3;
		if (flag)
		{
			this.class15_1.method_0();
		}
		this.bool_1 = flag;
		if (!flag)
		{
			this.class15_1.method_7(new Class65.Struct49(uint_0));
		}
		foreach (Class134 @class in this.class134_0)
		{
			if (this.method_190(this.long_0, @class.method_10(), @class.method_6()))
			{
				switch (@class.method_2())
				{
				case 0:
					if (flag)
					{
						Type type = object_3.GetType();
						Type type2 = this.method_16(@class.method_0(), true);
						if (type == type2 || type.IsSubclassOf(type2))
						{
							this.class15_1.method_7(new Class65.Struct49(@class.method_4(), object_3));
							this.bool_1 = false;
						}
					}
					break;
				case 1:
					if (flag)
					{
						this.class15_1.method_7(new Class65.Struct49(@class.method_8(), object_3));
					}
					break;
				case 2:
					if (flag || !this.method_190((long)((ulong)uint_0), @class.method_10(), @class.method_6()))
					{
						this.class15_1.method_7(new Class65.Struct49(@class.method_4()));
					}
					break;
				case 4:
					if (flag)
					{
						this.class15_1.method_7(new Class65.Struct49(@class.method_4()));
					}
					break;
				}
			}
		}
		this.method_282();
	}

	// Token: 0x060002E0 RID: 736 RVA: 0x0001C694 File Offset: 0x0001A894
	private void method_146(Class80 class80_2)
	{
		Class80 class80_3 = this.method_112();
		Class80 class80_4 = this.method_112();
		this.method_293(this.method_136(class80_4, class80_3, true));
	}

	// Token: 0x060002E1 RID: 737 RVA: 0x0001C6C0 File Offset: 0x0001A8C0
	private void method_147(Class80 class80_2)
	{
		Class87 @class = (Class87)class80_2;
		Class103 class2 = new Class103();
		class2.method_3((int)@class.method_2());
		this.method_293(class2);
	}

	// Token: 0x060002E2 RID: 738 RVA: 0x0001C6EC File Offset: 0x0001A8EC
	private void method_148(Class80 class80_2)
	{
		Class80 class80_3 = this.method_112();
		Class80 @class = this.method_112();
		bool flag;
		if (@class.vmethod_2() == 19)
		{
			flag = !Class65.smethod_2(@class, class80_3);
		}
		else
		{
			flag = !Class65.smethod_5(@class, class80_3);
		}
		if (flag)
		{
			uint uint_ = ((Class92)class80_2).method_2();
			this.method_273(uint_);
		}
	}

	// Token: 0x060002E3 RID: 739 RVA: 0x0001C740 File Offset: 0x0001A940
	private void method_149(Class80 class80_2)
	{
		Class87 @class = (Class87)class80_2;
		this.method_293(this.class80_1[(int)@class.method_2()].vmethod_4());
	}

	// Token: 0x060002E4 RID: 740 RVA: 0x0000425D File Offset: 0x0000245D
	private Class24 method_150(Class123 class123_2)
	{
		Class24 @class = new Class24();
		@class.method_1(class123_2.method_19());
		return @class;
	}

	// Token: 0x060002E5 RID: 741 RVA: 0x00004270 File Offset: 0x00002470
	private static Exception smethod_17(string string_0, string string_1)
	{
		return new FieldAccessException(Class65.smethod_11(string.Format("security transparent method '{0}'", string_0), string.Format("security critical field '{0}'", string_1)));
	}

	// Token: 0x060002E6 RID: 742 RVA: 0x00004292 File Offset: 0x00002492
	private void method_151(Class80 class80_2)
	{
		Class98 @class = new Class98();
		@class.method_3(2);
		this.method_293(@class);
	}

	// Token: 0x060002E7 RID: 743 RVA: 0x0001C770 File Offset: 0x0001A970
	private string method_152(Class42 class42_1)
	{
		Type type = this.method_16(class42_1.method_6(), false);
		Class128[] array = class42_1.method_2();
		string[] array2 = new string[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			string[] array3 = array2;
			int num = i;
			Type type2 = this.method_16(array[i].method_0(), false);
			array3[num] = ((type2 != null) ? type2.FullName : null);
		}
		string arg = string.Join(", ", array2);
		return string.Format("{0}.{1}({2})", type.FullName, class42_1.method_4(), arg);
	}

	// Token: 0x060002E8 RID: 744 RVA: 0x0001C7F0 File Offset: 0x0001A9F0
	private void method_153(Class80 class80_2)
	{
		int int_ = ((Class98)class80_2).method_2();
		Type type_ = this.method_16(int_, true);
		this.method_242(type_);
	}

	// Token: 0x060002E9 RID: 745 RVA: 0x0001C81C File Offset: 0x0001AA1C
	private void method_154(Class80 class80_2)
	{
		Class80 class80_3 = this.method_112();
		Class80 @class = this.method_112();
		bool flag;
		if (@class.vmethod_2() == 19)
		{
			flag = !Class65.smethod_5(@class, class80_3);
		}
		else
		{
			flag = !Class65.smethod_2(@class, class80_3);
		}
		if (flag)
		{
			uint uint_ = ((Class92)class80_2).method_2();
			this.method_273(uint_);
		}
	}

	// Token: 0x060002EA RID: 746 RVA: 0x0001C870 File Offset: 0x0001AA70
	private void method_155(Class80 class80_2)
	{
		Class80 class80_3 = this.method_112();
		Class80 class80_4 = this.method_112();
		this.method_293(this.method_279(class80_4, class80_3, false));
	}

	// Token: 0x060002EB RID: 747 RVA: 0x000042A6 File Offset: 0x000024A6
	private void method_156(Class80 class80_2)
	{
		this.method_206(true);
	}

	// Token: 0x060002EC RID: 748 RVA: 0x0001C89C File Offset: 0x0001AA9C
	private void method_157(Class80 class80_2)
	{
		Class80 class80_3 = this.method_112();
		Class80 class80_4 = this.method_112();
		Class98 @class = new Class98();
		@class.method_3(Class65.smethod_9(class80_4, class80_3) ? 1 : 0);
		this.method_293(@class);
	}

	// Token: 0x060002ED RID: 749 RVA: 0x0001C8D8 File Offset: 0x0001AAD8
	[DebuggerNonUserCode]
	private MethodBase method_158(int int_0)
	{
		Class0 class0_ = this.method_111(int_0);
		MethodBase methodBase = this.method_191(int_0, class0_);
		this.method_57(methodBase);
		return methodBase;
	}

	// Token: 0x060002EE RID: 750 RVA: 0x000042AF File Offset: 0x000024AF
	private bool method_159(MethodBase methodBase_0)
	{
		return methodBase_0.IsVirtual && this.method_16(this.class42_0.method_6(), true).IsSubclassOf(methodBase_0.DeclaringType);
	}

	// Token: 0x060002EF RID: 751 RVA: 0x0001C900 File Offset: 0x0001AB00
	private static Class80 smethod_18(Class80 class80_2, Class80 class80_3, bool bool_2, bool bool_3)
	{
		if (!bool_3)
		{
			long num = ((Class82)class80_2).method_2();
			long num2 = ((Class82)class80_3).method_2();
			long long_;
			if (bool_2)
			{
				long_ = checked(num + num2);
			}
			else
			{
				long_ = num + num2;
			}
			Class82 @class = new Class82();
			@class.method_3(long_);
			return @class;
		}
		ulong num3 = (ulong)((Class82)class80_2).method_2();
		ulong num4 = (ulong)((Class82)class80_3).method_2();
		ulong long_2;
		if (bool_2)
		{
			long_2 = checked(num3 + num4);
		}
		else
		{
			long_2 = num3 + num4;
		}
		Class82 class2 = new Class82();
		class2.method_3((long)long_2);
		return class2;
	}

	// Token: 0x060002F0 RID: 752 RVA: 0x0001C97C File Offset: 0x0001AB7C
	private void method_160(Class80 class80_2)
	{
		Class80 @class = this.method_112();
		int num = @class.vmethod_2();
		checked
		{
			int int_;
			if (num <= 14)
			{
				if (num == 8)
				{
					int_ = (int)Convert.ToUInt64(((Class84)@class).method_2());
					goto IL_6F;
				}
				if (num == 14)
				{
					int_ = (int)((uint)((Class98)@class).method_2());
					goto IL_6F;
				}
			}
			else
			{
				if (num == 16)
				{
					int_ = (int)((ulong)((Class82)@class).method_2());
					goto IL_6F;
				}
				if (num == 19)
				{
					int_ = (int)((Class86)@class).method_2();
					goto IL_6F;
				}
			}
			throw new InvalidOperationException();
			IL_6F:
			Class98 class2 = new Class98();
			class2.method_3(int_);
			this.method_293(class2);
		}
	}

	// Token: 0x060002F1 RID: 753 RVA: 0x000042DD File Offset: 0x000024DD
	private void method_161(Class80 class80_2)
	{
		this.method_277(typeof(double));
	}

	// Token: 0x060002F2 RID: 754 RVA: 0x0001CA0C File Offset: 0x0001AC0C
	private void method_162(Class80 class80_2)
	{
		int int_ = ((Class98)class80_2).method_2();
		FieldInfo fieldInfo = this.method_223(int_);
		Class80 @class = this.method_112();
		Class80 class2 = this.method_112();
		Class100 class3 = class2 as Class100;
		object obj;
		if (class3 != null)
		{
			obj = this.method_259(class3).vmethod_0();
		}
		else
		{
			obj = class2.vmethod_0();
		}
		if (obj == null)
		{
			throw new NullReferenceException();
		}
		Class80 class4 = Class29.smethod_1(@class.vmethod_0(), fieldInfo.FieldType);
		fieldInfo.SetValue(obj, class4.vmethod_0());
		if (class3 != null && obj != null && obj.GetType().IsValueType)
		{
			this.method_241(class3, Class29.smethod_1(obj, null));
		}
	}

	// Token: 0x060002F3 RID: 755 RVA: 0x0001CAA8 File Offset: 0x0001ACA8
	private Class80 method_163(Class80 class80_2)
	{
		if (class80_2.vmethod_2() == 14)
		{
			int num = ((Class98)class80_2).method_2();
			Class98 @class = new Class98();
			@class.method_3(~num);
			return @class;
		}
		if (class80_2.vmethod_2() == 16)
		{
			long num2 = ((Class82)class80_2).method_2();
			Class82 class2 = new Class82();
			class2.method_3(~num2);
			return class2;
		}
		if (class80_2.vmethod_2() == 8)
		{
			Type underlyingType = Enum.GetUnderlyingType(class80_2.vmethod_0().GetType());
			if (underlyingType != typeof(long))
			{
				if (underlyingType != typeof(ulong))
				{
					int num3 = Convert.ToInt32(class80_2.vmethod_0());
					Class98 class3 = new Class98();
					class3.method_3(~num3);
					return class3;
				}
			}
			long num4 = Convert.ToInt64(class80_2.vmethod_0());
			Class82 class4 = new Class82();
			class4.method_3(~num4);
			return class4;
		}
		throw new InvalidOperationException();
	}

	// Token: 0x060002F4 RID: 756 RVA: 0x0001CB70 File Offset: 0x0001AD70
	private Class136 method_164(Class123 class123_2)
	{
		switch (class123_2.method_6())
		{
		case 0:
		{
			Class141 @class = new Class141();
			@class.method_1(class123_2.method_9());
			return @class;
		}
		case 1:
		{
			Class139 class2 = new Class139();
			Class139 class3 = class2;
			Class0 class4 = new Class0();
			class4.method_1(1);
			class4.method_3(class123_2.method_19());
			class3.method_5(class4);
			class2.method_1(class123_2.method_6());
			class2.method_7(class123_2.method_9());
			Class139 class5 = class2;
			Class0 class6 = new Class0();
			class6.method_1(1);
			class6.method_3(class123_2.method_19());
			class5.method_13(class6);
			int num = class123_2.method_18();
			Class0[] array = new Class0[num];
			for (int i = 0; i < num; i++)
			{
				Class0[] array2 = array;
				int num2 = i;
				Class0 class7 = new Class0();
				class7.method_1(1);
				class7.method_3(class123_2.method_19());
				array2[num2] = class7;
			}
			class2.method_9(array);
			int num3 = class123_2.method_18();
			Class0[] array3 = new Class0[num3];
			for (int j = 0; j < num3; j++)
			{
				Class0[] array4 = array3;
				int num4 = j;
				Class0 class8 = new Class0();
				class8.method_1(1);
				class8.method_3(class123_2.method_19());
				array4[num4] = class8;
			}
			class2.method_11(array3);
			return class2;
		}
		case 2:
		{
			Class140 class9 = new Class140();
			Class0 class10 = new Class0();
			class10.method_1(1);
			class10.method_3(class123_2.method_19());
			class9.method_1(class10);
			class9.method_3(class123_2.method_9());
			class9.method_5(class123_2.method_5());
			return class9;
		}
		case 3:
		{
			Class138 class11 = new Class138();
			class11.method_1(class123_2.method_9());
			class11.method_5(class123_2.method_5());
			class11.method_3(class123_2.method_5());
			class11.method_11(class123_2.method_19());
			class11.method_9(class123_2.method_19());
			int num5 = class123_2.method_18();
			Class0[] array5 = new Class0[num5];
			for (int k = 0; k < num5; k++)
			{
				Class0[] array6 = array5;
				int num6 = k;
				Class0 class12 = new Class0();
				class12.method_1(1);
				class12.method_3(class123_2.method_19());
				array6[num6] = class12;
			}
			class11.method_7(array5);
			return class11;
		}
		case 4:
		{
			Class137 class13 = new Class137();
			class13.method_1(class123_2.method_19());
			class13.method_3(class123_2.method_19());
			return class13;
		}
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	// Token: 0x060002F5 RID: 757 RVA: 0x000042EF File Offset: 0x000024EF
	private void method_165(Class80 class80_2)
	{
		this.method_2(typeof(double));
	}

	// Token: 0x060002F6 RID: 758 RVA: 0x00004301 File Offset: 0x00002501
	private void method_166(Class80 class80_2)
	{
		throw new NotSupportedException("Refanyval is not supported.");
	}

	// Token: 0x060002F7 RID: 759 RVA: 0x0001CD7C File Offset: 0x0001AF7C
	private void method_167(Class80 class80_2)
	{
		object object_ = this.method_112().vmethod_0();
		long num = this.method_294();
		Array array = (Array)this.method_112().vmethod_0();
		Type elementType = array.GetType().GetElementType();
		checked
		{
			if (elementType == typeof(short))
			{
				Class80 @class = Class29.smethod_1(object_, typeof(short));
				((short[])array)[(int)((IntPtr)num)] = (short)@class.vmethod_0();
				return;
			}
			if (elementType == typeof(ushort))
			{
				Class80 class2 = Class29.smethod_1(object_, typeof(ushort));
				((ushort[])array)[(int)((IntPtr)num)] = (ushort)class2.vmethod_0();
				return;
			}
			if (elementType == typeof(char))
			{
				Class80 class3 = Class29.smethod_1(object_, typeof(char));
				((char[])array)[(int)((IntPtr)num)] = (char)class3.vmethod_0();
				return;
			}
			if (elementType.IsEnum)
			{
				this.method_287(elementType, object_, num, array);
				return;
			}
			this.method_287(typeof(short), object_, num, array);
		}
	}

	// Token: 0x060002F8 RID: 760 RVA: 0x0001CE80 File Offset: 0x0001B080
	private Class80 method_168(Class80 class80_2, Class80 class80_3)
	{
		if (class80_2.vmethod_2() == 14)
		{
			if (class80_3.vmethod_2() == 14)
			{
				int num = ((Class98)class80_2).method_2();
				int num2 = ((Class98)class80_3).method_2();
				Class98 @class = new Class98();
				@class.method_3(num | num2);
				return @class;
			}
			if (class80_3.vmethod_2() == 8)
			{
				int num3 = ((Class98)class80_2).method_2();
				Type underlyingType = Enum.GetUnderlyingType(class80_3.vmethod_0().GetType());
				if (underlyingType != typeof(long))
				{
					if (underlyingType != typeof(ulong))
					{
						int num4 = Convert.ToInt32(class80_3.vmethod_0());
						Class98 class2 = new Class98();
						class2.method_3(num3 | num4);
						return class2;
					}
				}
				long num5 = Convert.ToInt64(class80_3.vmethod_0());
				Class82 class3 = new Class82();
				class3.method_3((long)num3 | num5);
				return class3;
			}
		}
		if (class80_2.vmethod_2() == 16)
		{
			if (class80_3.vmethod_2() == 16)
			{
				long num6 = ((Class82)class80_2).method_2();
				long num7 = ((Class82)class80_3).method_2();
				Class82 class4 = new Class82();
				class4.method_3(num6 | num7);
				return class4;
			}
			if (class80_3.vmethod_2() == 8)
			{
				int num8 = ((Class98)class80_2).method_2();
				long num9 = Convert.ToInt64(class80_3.vmethod_0());
				Class82 class5 = new Class82();
				class5.method_3((long)num8 | num9);
				return class5;
			}
		}
		if (class80_2.vmethod_2() == 8)
		{
			if (class80_3.vmethod_2() == 14)
			{
				int num10 = ((Class98)class80_3).method_2();
				Type underlyingType2 = Enum.GetUnderlyingType(class80_2.vmethod_0().GetType());
				if (underlyingType2 != typeof(long))
				{
					if (underlyingType2 != typeof(ulong))
					{
						int num11 = Convert.ToInt32(class80_2.vmethod_0());
						Class98 class6 = new Class98();
						class6.method_3(num11 | num10);
						return class6;
					}
				}
				long num12 = Convert.ToInt64(class80_3.vmethod_0());
				Class82 class7 = new Class82();
				class7.method_3(num12 | (long)num10);
				return class7;
			}
			if (class80_3.vmethod_2() == 16)
			{
				long num13 = Convert.ToInt64(class80_2.vmethod_0());
				long num14 = ((Class82)class80_3).method_2();
				Class82 class8 = new Class82();
				class8.method_3(num13 | num14);
				return class8;
			}
			if (class80_3.vmethod_2() == 8)
			{
				Type underlyingType3 = Enum.GetUnderlyingType(class80_2.vmethod_0().GetType());
				Type underlyingType4 = Enum.GetUnderlyingType(class80_3.vmethod_0().GetType());
				if (underlyingType3 != typeof(long) && underlyingType3 != typeof(ulong) && underlyingType4 != typeof(long))
				{
					if (underlyingType4 != typeof(ulong))
					{
						int num15 = Convert.ToInt32(class80_2.vmethod_0());
						int num16 = Convert.ToInt32(class80_3.vmethod_0());
						Class98 class9 = new Class98();
						class9.method_3(num15 | num16);
						return class9;
					}
				}
				long num17 = Convert.ToInt64(class80_2.vmethod_0());
				long num18 = Convert.ToInt64(class80_3.vmethod_0());
				Class82 class10 = new Class82();
				class10.method_3(num17 | num18);
				return class10;
			}
		}
		throw new InvalidOperationException();
	}

	// Token: 0x060002F9 RID: 761 RVA: 0x0001D144 File Offset: 0x0001B344
	private void method_169(Class80 class80_2)
	{
		Class98 @class = (Class98)class80_2;
		MethodBase methodBase_ = this.method_158(@class.method_2());
		this.method_105(methodBase_, false);
	}

	// Token: 0x060002FA RID: 762 RVA: 0x0001D170 File Offset: 0x0001B370
	private void method_170(Class80 class80_2)
	{
		Class80 class80_3 = this.method_112();
		Class80 class80_4 = this.method_112();
		this.method_293(this.method_131(class80_4, class80_3));
	}

	// Token: 0x060002FB RID: 763 RVA: 0x00003F73 File Offset: 0x00002173
	private void method_171(Class80 class80_2)
	{
		this.method_269();
	}

	// Token: 0x060002FC RID: 764 RVA: 0x0001D19C File Offset: 0x0001B39C
	private void method_172(Class80 class80_2)
	{
		Class80 class80_3 = this.method_112();
		Class80 class80_4 = this.method_112();
		this.method_293(this.method_279(class80_4, class80_3, true));
	}

	// Token: 0x060002FD RID: 765 RVA: 0x0000430D File Offset: 0x0000250D
	public static object smethod_19(Type type_9)
	{
		if (type_9.IsValueType)
		{
			return Activator.CreateInstance(type_9);
		}
		return null;
	}

	// Token: 0x060002FE RID: 766 RVA: 0x0001D1C8 File Offset: 0x0001B3C8
	private void method_173(Class80 class80_2)
	{
		Class80 @class = this.method_112();
		int num = @class.vmethod_2();
		checked
		{
			long long_;
			if (num <= 14)
			{
				if (num == 8)
				{
					long_ = (long)Convert.ToUInt64(((Class84)@class).method_2());
					goto IL_6F;
				}
				if (num == 14)
				{
					long_ = (long)(unchecked((ulong)(checked((uint)((Class98)@class).method_2()))));
					goto IL_6F;
				}
			}
			else
			{
				if (num == 16)
				{
					long_ = (long)((ulong)((Class82)@class).method_2());
					goto IL_6F;
				}
				if (num == 19)
				{
					long_ = (long)((Class86)@class).method_2();
					goto IL_6F;
				}
			}
			throw new InvalidOperationException();
			IL_6F:
			Class82 class2 = new Class82();
			class2.method_3(long_);
			this.method_293(class2);
		}
	}

	// Token: 0x060002FF RID: 767 RVA: 0x0000431F File Offset: 0x0000251F
	private void method_174(Class80 class80_2)
	{
		this.method_55(true);
	}

	// Token: 0x06000300 RID: 768 RVA: 0x0001D258 File Offset: 0x0001B458
	private void method_175(Class80 class80_2)
	{
		Class80 class80_3 = this.method_112();
		Class80 class80_4 = this.method_112();
		this.method_293(this.method_285(class80_4, class80_3, false, false));
	}

	// Token: 0x06000301 RID: 769 RVA: 0x0001D284 File Offset: 0x0001B484
	private Class80 method_176(Class80 class80_2)
	{
		if (class80_2.vmethod_2() == 14)
		{
			int num = ((Class98)class80_2).method_2();
			Class98 @class = new Class98();
			@class.method_3(-num);
			return @class;
		}
		if (class80_2.vmethod_2() == 16)
		{
			long num2 = ((Class82)class80_2).method_2();
			Class82 class2 = new Class82();
			class2.method_3(-num2);
			return class2;
		}
		if (class80_2.vmethod_2() == 19)
		{
			Class86 class3 = new Class86();
			class3.method_3(-((Class86)class80_2).method_2());
			return class3;
		}
		if (class80_2.vmethod_2() == 8)
		{
			Type underlyingType = Enum.GetUnderlyingType(class80_2.vmethod_0().GetType());
			if (underlyingType != typeof(long))
			{
				if (underlyingType != typeof(ulong))
				{
					Class98 class4 = new Class98();
					class4.method_3(Convert.ToInt32(class80_2.vmethod_0()));
					return this.method_176(class4);
				}
			}
			Class82 class5 = new Class82();
			class5.method_3(Convert.ToInt64(class80_2.vmethod_0()));
			return this.method_176(class5);
		}
		throw new InvalidOperationException();
	}

	// Token: 0x06000302 RID: 770 RVA: 0x00004328 File Offset: 0x00002528
	private void method_177(Class80 class80_2)
	{
		Class98 @class = new Class98();
		@class.method_3(8);
		this.method_293(@class);
	}

	// Token: 0x06000303 RID: 771 RVA: 0x0000433C File Offset: 0x0000253C
	private void method_178(Class80 class80_2)
	{
		this.method_297(false);
	}

	// Token: 0x06000304 RID: 772 RVA: 0x00004345 File Offset: 0x00002545
	public object method_179(Stream stream_1, string string_0, object[] object_3)
	{
		return this.method_268(stream_1, string_0, object_3, null, null, null);
	}

	// Token: 0x06000305 RID: 773 RVA: 0x00004353 File Offset: 0x00002553
	private void method_180(Class80 class80_2)
	{
		this.method_283(false);
	}

	// Token: 0x06000306 RID: 774 RVA: 0x0001D370 File Offset: 0x0001B570
	private void method_181(Class80 class80_2)
	{
		MethodBase methodBase_ = ((Class95)this.method_112()).method_2();
		this.method_105(methodBase_, false);
	}

	// Token: 0x06000307 RID: 775 RVA: 0x0001D398 File Offset: 0x0001B598
	private void method_182(Class80 class80_2)
	{
		int int_ = ((Class98)class80_2).method_2();
		Type type = this.method_16(int_, true);
		Class80 class80_3 = Class29.smethod_1(this.method_112().vmethod_0(), type);
		this.method_293(class80_3);
	}

	// Token: 0x06000308 RID: 776 RVA: 0x0001D3D4 File Offset: 0x0001B5D4
	private object method_183(MethodBase methodBase_0, object object_3, object[] object_4, bool bool_2)
	{
		if (!Class65.Class69.bool_0)
		{
			return this.method_271(methodBase_0, object_3, object_4);
		}
		Class65.Struct50 struct50_ = new Class65.Struct50(methodBase_0, bool_2);
		Class65.Delegate20 @delegate = this.method_127(struct50_);
		if (@delegate == null)
		{
			Dictionary<MethodBase, int> obj = this.dictionary_0;
			bool flag;
			lock (obj)
			{
				int num;
				this.dictionary_0.TryGetValue(methodBase_0, out num);
				if (!(flag = (num >= 50)))
				{
					this.dictionary_0[methodBase_0] = num + 1;
				}
			}
			if (!(flag = (flag || (!bool_2 && object_3 == null && !methodBase_0.IsStatic && !methodBase_0.IsConstructor) || Class65.smethod_23(methodBase_0) || (methodBase_0.CallingConvention & CallingConventions.Any) == CallingConventions.VarArgs)))
			{
				return this.method_271(methodBase_0, object_3, object_4);
			}
			@delegate = this.method_227(struct50_);
			obj = this.dictionary_0;
			lock (obj)
			{
				this.dictionary_0.Remove(methodBase_0);
			}
		}
		return @delegate(object_3, object_4);
	}

	// Token: 0x06000309 RID: 777 RVA: 0x0001D4DC File Offset: 0x0001B6DC
	private void method_184(Class80 class80_2)
	{
		Class80 @class = this.method_112();
		int num = @class.vmethod_2();
		checked
		{
			short int_;
			if (num <= 14)
			{
				if (num == 8)
				{
					int_ = (short)Convert.ToUInt64(((Class84)@class).method_2());
					goto IL_6F;
				}
				if (num == 14)
				{
					int_ = (short)((uint)((Class98)@class).method_2());
					goto IL_6F;
				}
			}
			else
			{
				if (num == 16)
				{
					int_ = (short)((ulong)((Class82)@class).method_2());
					goto IL_6F;
				}
				if (num == 19)
				{
					int_ = (short)((Class86)@class).method_2();
					goto IL_6F;
				}
			}
			throw new InvalidOperationException();
			IL_6F:
			Class98 class2 = new Class98();
			class2.method_3((int)int_);
			this.method_293(class2);
		}
	}

	// Token: 0x0600030A RID: 778 RVA: 0x0001D56C File Offset: 0x0001B76C
	private void method_185(Class80 class80_2)
	{
		Class80 @class = this.method_112();
		int num = @class.vmethod_2();
		UIntPtr uintptr_;
		if (num <= 14)
		{
			if (num == 8)
			{
				uintptr_ = new UIntPtr(Convert.ToUInt64(((Class84)@class).method_2()));
				goto IL_82;
			}
			if (num == 14)
			{
				uintptr_ = new UIntPtr((uint)((Class98)@class).method_2());
				goto IL_82;
			}
		}
		else
		{
			if (num == 16)
			{
				uintptr_ = new UIntPtr((ulong)((Class82)@class).method_2());
				goto IL_82;
			}
			if (num == 19)
			{
				uintptr_ = new UIntPtr((ulong)((Class86)@class).method_2());
				goto IL_82;
			}
		}
		throw new InvalidOperationException();
		IL_82:
		Class83 class2 = new Class83();
		class2.method_3(uintptr_);
		this.method_293(class2);
	}

	// Token: 0x0600030B RID: 779 RVA: 0x0001D610 File Offset: 0x0001B810
	private void method_186(Class80 class80_2)
	{
		Class88 @class = (Class88)class80_2;
		this.class80_0[(int)@class.method_2()].vmethod_3(this.method_112());
	}

	// Token: 0x0600030C RID: 780 RVA: 0x0001D644 File Offset: 0x0001B844
	private MethodBase method_187(Class139 class139_0)
	{
		Type type = this.method_16(class139_0.method_4().method_2(), false);
		BindingFlags bindingAttr = Class65.smethod_24(class139_0.method_2());
		MemberInfo[] member = type.GetMember(class139_0.method_6(), bindingAttr);
		MethodInfo methodInfo = null;
		foreach (MethodInfo methodInfo2 in member)
		{
			if (methodInfo2.IsGenericMethodDefinition)
			{
				ParameterInfo[] parameters = methodInfo2.GetParameters();
				if (parameters.Length == class139_0.method_8().Length && methodInfo2.GetGenericArguments().Length == class139_0.method_10().Length && this.method_243(methodInfo2.ReturnType, class139_0.method_12()))
				{
					bool flag = true;
					int j = 0;
					while (j < parameters.Length)
					{
						if (this.method_243(parameters[j].ParameterType, class139_0.method_8()[j]))
						{
							j++;
						}
						else
						{
							flag = false;
							IL_C6:
							if (!flag)
							{
								goto IL_CA;
							}
							methodInfo = methodInfo2;
							goto IL_DD;
						}
					}
					goto IL_C6;
					IL_DD:
					if (methodInfo == null)
					{
						throw new Exception(string.Format("Cannot bind method: {0}.{1}", type.Name, class139_0.method_6()));
					}
					Type[] array2 = new Type[class139_0.method_10().Length];
					for (int k = 0; k < array2.Length; k++)
					{
						array2[k] = this.method_16(class139_0.method_10()[k].method_2(), true);
					}
					return methodInfo.MakeGenericMethod(array2);
				}
			}
			IL_CA:;
		}
		goto IL_DD;
	}

	// Token: 0x0600030D RID: 781 RVA: 0x0000435C File Offset: 0x0000255C
	private void method_188(Class80 class80_2)
	{
		throw new NotSupportedException("Initblk not supported.");
	}

	// Token: 0x0600030E RID: 782 RVA: 0x0001D798 File Offset: 0x0001B998
	private void method_189(Class80 class80_2)
	{
		int int_ = ((Class98)class80_2).method_2();
		Type type_ = this.method_16(int_, true);
		this.method_2(type_);
	}

	// Token: 0x0600030F RID: 783 RVA: 0x00004368 File Offset: 0x00002568
	private bool method_190(long long_1, uint uint_0, uint uint_1)
	{
		return long_1 >= (long)((ulong)uint_0) && long_1 <= (long)((ulong)(uint_0 + uint_1));
	}

	// Token: 0x06000310 RID: 784 RVA: 0x0001D7C4 File Offset: 0x0001B9C4
	[DebuggerNonUserCode]
	private MethodBase method_191(int int_0, Class0 class0_0)
	{
		Dictionary<int, object> obj = Class65.dictionary_1;
		MethodBase result;
		lock (obj)
		{
			bool flag = true;
			object obj2;
			if (Class65.dictionary_1.TryGetValue(int_0, out obj2))
			{
				result = (MethodBase)obj2;
			}
			else if (class0_0.method_0() == 0)
			{
				MethodBase methodBase = this.module_0.ResolveMethod(class0_0.method_2());
				if (flag)
				{
					Class65.dictionary_1.Add(int_0, methodBase);
				}
				result = methodBase;
			}
			else
			{
				Class139 @class = (Class139)class0_0.method_4();
				if (@class.method_3())
				{
					result = this.method_187(@class);
				}
				else
				{
					Type type = this.method_16(@class.method_4().method_2(), false);
					Type type2 = this.method_16(@class.method_12().method_2(), true);
					Type[] array = new Type[@class.method_8().Length];
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = this.method_16(@class.method_8()[i].method_2(), true);
					}
					if (type.IsGenericType)
					{
						flag = false;
					}
					if (@class.method_6() == ".ctor")
					{
						ConstructorInfo constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, CallingConventions.Any, array, null);
						if (constructor == null)
						{
							throw new Exception();
						}
						if (flag)
						{
							Class65.dictionary_1.Add(int_0, constructor);
						}
						result = constructor;
					}
					else
					{
						BindingFlags bindingAttr = Class65.smethod_24(@class.method_2());
						MethodBase methodBase2 = null;
						try
						{
							methodBase2 = type.GetMethod(@class.method_6(), bindingAttr, null, CallingConventions.Any, array, null);
						}
						catch (AmbiguousMatchException)
						{
							foreach (MethodInfo methodInfo in type.GetMethods(bindingAttr))
							{
								if (!(methodInfo.Name != @class.method_6()) && methodInfo.ReturnType == type2)
								{
									ParameterInfo[] parameters = methodInfo.GetParameters();
									if (parameters.Length == array.Length)
									{
										bool flag2 = false;
										for (int k = 0; k < array.Length; k++)
										{
											if (parameters[k].ParameterType != array[k])
											{
												flag2 = true;
												break;
											}
										}
										if (!flag2)
										{
											methodBase2 = methodInfo;
											break;
										}
									}
								}
							}
						}
						if (methodBase2 == null)
						{
							throw new Exception(string.Format("Cannot bind method: {0}.{1}", type.Name, @class.method_6()));
						}
						if (flag)
						{
							Class65.dictionary_1.Add(int_0, methodBase2);
						}
						result = methodBase2;
					}
				}
			}
		}
		return result;
	}

	// Token: 0x06000311 RID: 785 RVA: 0x0001DA44 File Offset: 0x0001BC44
	private void method_192(Class80 class80_2)
	{
		Class80 class80_3 = this.method_112();
		if (Class65.smethod_2(this.method_112(), class80_3))
		{
			uint uint_ = ((Class92)class80_2).method_2();
			this.method_273(uint_);
		}
	}

	// Token: 0x06000312 RID: 786 RVA: 0x0000437B File Offset: 0x0000257B
	private void method_193(Class80 class80_2)
	{
		this.method_293(new Class90());
	}

	// Token: 0x06000313 RID: 787 RVA: 0x0001DA7C File Offset: 0x0001BC7C
	private void method_194(Class80 class80_2)
	{
		uint uint_ = ((Class92)class80_2).method_2();
		this.method_145(null, uint_);
	}

	// Token: 0x06000314 RID: 788 RVA: 0x00002D6B File Offset: 0x00000F6B
	private void method_195(Class80 class80_2)
	{
	}

	// Token: 0x06000315 RID: 789 RVA: 0x00004388 File Offset: 0x00002588
	private void method_196(Class80 class80_2)
	{
		this.method_293(this.class80_0[2].vmethod_4());
	}

	// Token: 0x06000316 RID: 790 RVA: 0x0001DAA0 File Offset: 0x0001BCA0
	private bool method_197(MethodBase methodBase_0, object object_3, ref object object_4, object[] object_5)
	{
		Type declaringType = methodBase_0.DeclaringType;
		if (declaringType == null)
		{
			return false;
		}
		if (Class175.smethod_0(declaringType))
		{
			if (string.Equals(methodBase_0.Name, "get_HasValue", StringComparison.Ordinal))
			{
				object_4 = (object_3 != null);
			}
			else if (string.Equals(methodBase_0.Name, "get_Value", StringComparison.Ordinal))
			{
				if (object_3 == null)
				{
					return ((bool?)null).Value;
				}
				object_4 = object_3;
			}
			else if (methodBase_0.Name.Equals("GetValueOrDefault", StringComparison.Ordinal))
			{
				if (object_3 == null)
				{
					object_4 = Activator.CreateInstance(Nullable.GetUnderlyingType(methodBase_0.DeclaringType));
				}
				object_4 = object_3;
			}
			else
			{
				if (object_3 != null || methodBase_0.IsStatic)
				{
					return false;
				}
				object_4 = null;
			}
			return true;
		}
		if (declaringType == Class65.type_6)
		{
			if (methodBase_0.Name.Equals("GetExecutingAssembly", StringComparison.Ordinal))
			{
				object_4 = Class175.assembly_0;
				return true;
			}
			if (this.object_2 != null && methodBase_0.Name == "GetCallingAssembly")
			{
				object[] array = this.object_2;
				for (int i = 0; i < array.Length; i++)
				{
					Assembly assembly = array[i] as Assembly;
					if (assembly != null)
					{
						object_4 = assembly;
						return true;
					}
				}
			}
		}
		else if (declaringType == Class65.type_0)
		{
			if (methodBase_0.Name == "GetCurrentMethod")
			{
				if (this.object_2 != null)
				{
					object[] array = this.object_2;
					for (int i = 0; i < array.Length; i++)
					{
						MethodBase methodBase = array[i] as MethodBase;
						if (methodBase != null)
						{
							object_4 = methodBase;
							return true;
						}
					}
				}
				object_4 = MethodBase.GetCurrentMethod();
				return true;
			}
		}
		else if (declaringType.IsArray && declaringType.GetArrayRank() >= 2)
		{
			return this.method_115(methodBase_0, object_3, ref object_4, object_5);
		}
		return false;
	}

	// Token: 0x06000317 RID: 791 RVA: 0x0001DC34 File Offset: 0x0001BE34
	private Class128[] method_198(Class123 class123_2)
	{
		Class128[] array = new Class128[(int)class123_2.method_23()];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = this.method_215(class123_2);
		}
		return array;
	}

	// Token: 0x06000318 RID: 792 RVA: 0x000043A1 File Offset: 0x000025A1
	private void method_199(ref Class65.Struct48 struct48_0)
	{
		if (struct48_0.bool_0)
		{
			Monitor.Exit(Class65.object_0);
		}
	}

	// Token: 0x06000319 RID: 793 RVA: 0x000043B5 File Offset: 0x000025B5
	private void method_200(Class80 class80_2)
	{
		this.method_293(this.class80_1[2].vmethod_4());
	}

	// Token: 0x0600031A RID: 794 RVA: 0x0001DC6C File Offset: 0x0001BE6C
	private void method_201(Class80 class80_2)
	{
		if (((Class98)this.method_112()).method_2() != 0)
		{
			this.class15_1.method_7(new Class65.Struct49((uint)this.class123_0.method_0().vmethod_4(), this.object_1));
			this.bool_1 = false;
		}
		this.method_282();
	}

	// Token: 0x0600031B RID: 795 RVA: 0x00003F73 File Offset: 0x00002173
	private void method_202(Class80 class80_2)
	{
		this.method_269();
	}

	// Token: 0x0600031C RID: 796 RVA: 0x000043CE File Offset: 0x000025CE
	private void method_203(Class80 class80_2)
	{
		throw new NotSupportedException("Localloc not supported.");
	}

	// Token: 0x0600031D RID: 797 RVA: 0x0001DCC0 File Offset: 0x0001BEC0
	private void method_204(Class80 class80_2)
	{
		Class98 @class = (Class98)class80_2;
		MethodBase methodBase = this.method_158(@class.method_2());
		if (this.type_1 != null)
		{
			ParameterInfo[] parameters = methodBase.GetParameters();
			Type[] array = new Type[parameters.Length];
			int num = 0;
			foreach (ParameterInfo parameterInfo in parameters)
			{
				array[num++] = parameterInfo.ParameterType;
			}
			MethodInfo method = this.type_1.GetMethod(methodBase.Name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.InvokeMethod | BindingFlags.GetProperty | BindingFlags.SetProperty, null, array, null);
			if (method != null)
			{
				methodBase = method;
			}
			this.type_1 = null;
		}
		this.method_105(methodBase, true);
	}

	// Token: 0x0600031E RID: 798 RVA: 0x0001DD58 File Offset: 0x0001BF58
	private void method_205(Class80 class80_2)
	{
		int int_ = ((Class98)class80_2).method_2();
		Type type_ = this.method_16(int_, true);
		this.method_277(type_);
	}

	// Token: 0x0600031F RID: 799 RVA: 0x0001DD84 File Offset: 0x0001BF84
	private void method_206(bool bool_2)
	{
		Class80 @class = this.method_112();
		int num = @class.vmethod_2();
		short int_;
		if (num <= 14)
		{
			if (num != 8)
			{
				if (num == 14)
				{
					if (bool_2)
					{
						int_ = checked((short)((Class98)@class).method_2());
						goto IL_BD;
					}
					int_ = (short)((Class98)@class).method_2();
					goto IL_BD;
				}
			}
			else
			{
				if (bool_2)
				{
					int_ = checked((short)Convert.ToUInt64(((Class84)@class).method_2()));
					goto IL_BD;
				}
				int_ = (short)Convert.ToUInt64(((Class84)@class).method_2());
				goto IL_BD;
			}
		}
		else if (num != 16)
		{
			if (num == 19)
			{
				if (bool_2)
				{
					int_ = checked((short)((Class86)@class).method_2());
					goto IL_BD;
				}
				int_ = (short)((Class86)@class).method_2();
				goto IL_BD;
			}
		}
		else
		{
			if (bool_2)
			{
				int_ = checked((short)((Class82)@class).method_2());
				goto IL_BD;
			}
			int_ = (short)((Class82)@class).method_2();
			goto IL_BD;
		}
		throw new InvalidOperationException();
		IL_BD:
		Class98 class2 = new Class98();
		class2.method_3((int)int_);
		this.method_293(class2);
	}

	// Token: 0x06000320 RID: 800 RVA: 0x0001DE60 File Offset: 0x0001C060
	private void method_207(Class80 class80_2)
	{
		Class80 class80_3 = this.method_112();
		Class80 class80_4 = this.method_112();
		this.method_293(this.method_65(class80_4, class80_3));
	}

	// Token: 0x06000321 RID: 801 RVA: 0x0001DE8C File Offset: 0x0001C08C
	private void method_208(int int_0)
	{
		Class80 @class = this.method_112();
		if (@class is Class100)
		{
			this.class80_1[int_0] = @class;
			return;
		}
		this.class80_1[int_0].vmethod_3(@class);
	}

	// Token: 0x06000322 RID: 802 RVA: 0x000043DA File Offset: 0x000025DA
	private void method_209(Class80 class80_2)
	{
		this.method_283(true);
	}

	// Token: 0x06000323 RID: 803 RVA: 0x000043E3 File Offset: 0x000025E3
	private void method_210(Class80 class80_2)
	{
		this.method_277(typeof(float));
	}

	// Token: 0x06000324 RID: 804 RVA: 0x000043F5 File Offset: 0x000025F5
	private void method_211(Class80 class80_2)
	{
		this.method_277(typeof(sbyte));
	}

	// Token: 0x06000325 RID: 805 RVA: 0x0001DECC File Offset: 0x0001C0CC
	private void method_212(Class80 class80_2)
	{
		Class98 @class = (Class98)class80_2;
		MethodBase methodBase_ = this.method_158(@class.method_2());
		foreach (Class80 class80_3 in this.class80_0)
		{
			this.method_293(class80_3);
		}
		this.method_105(methodBase_, false);
	}

	// Token: 0x06000326 RID: 806 RVA: 0x00004407 File Offset: 0x00002607
	private void method_213(Class80 class80_2)
	{
		this.method_242(Class175.type_0);
	}

	// Token: 0x06000327 RID: 807 RVA: 0x00004414 File Offset: 0x00002614
	private void method_214(Class80 class80_2)
	{
		throw new NotSupportedException("Arglist is not supported.");
	}

	// Token: 0x06000328 RID: 808 RVA: 0x00004420 File Offset: 0x00002620
	private Class128 method_215(Class123 class123_2)
	{
		Class128 @class = new Class128();
		@class.method_1(class123_2.method_19());
		@class.method_3(class123_2.method_5());
		return @class;
	}

	// Token: 0x06000329 RID: 809 RVA: 0x0000443F File Offset: 0x0000263F
	private void method_216(Class80 class80_2)
	{
		this.method_277(Class175.type_0);
	}

	// Token: 0x0600032A RID: 810 RVA: 0x0000444C File Offset: 0x0000264C
	private void method_217(Class80 class80_2)
	{
		this.method_2(typeof(ushort));
	}

	// Token: 0x0600032B RID: 811 RVA: 0x0001DF1C File Offset: 0x0001C11C
	private void method_218(Class80 class80_2)
	{
		int num = ((Class98)class80_2).method_2();
		bool flag = (num & int.MinValue) != 0;
		bool bool_ = (num & 1073741824) != 0;
		num &= 1073741823;
		if (flag)
		{
			this.method_47(num, null, null, bool_);
			return;
		}
		Class137 class137_ = (Class137)this.method_111(num).method_4();
		this.method_82(class137_);
	}

	// Token: 0x0600032C RID: 812 RVA: 0x0001DF78 File Offset: 0x0001C178
	private string method_219(int int_0)
	{
		Dictionary<int, object> obj = Class65.dictionary_1;
		string result;
		lock (obj)
		{
			bool flag = true;
			object obj2;
			if (Class65.dictionary_1.TryGetValue(int_0, out obj2))
			{
				result = (string)obj2;
			}
			else
			{
				Class0 @class = this.method_111(int_0);
				if (@class.method_0() == 0)
				{
					result = this.module_0.ResolveString(@class.method_2());
				}
				else
				{
					string text = ((Class141)@class.method_4()).method_0();
					if (flag)
					{
						Class65.dictionary_1.Add(int_0, text);
					}
					result = text;
				}
			}
		}
		return result;
	}

	// Token: 0x0600032D RID: 813 RVA: 0x0001E010 File Offset: 0x0001C210
	private void method_220(Class80 class80_2)
	{
		Class80 class80_3 = this.method_112();
		Class80 class80_4 = this.method_112();
		this.method_293(this.method_285(class80_4, class80_3, true, true));
	}

	// Token: 0x0600032E RID: 814 RVA: 0x0000445E File Offset: 0x0000265E
	private void method_221()
	{
		this.bool_0 = true;
	}

	// Token: 0x0600032F RID: 815 RVA: 0x0001E03C File Offset: 0x0001C23C
	private void method_222(Class80 class80_2)
	{
		Class80 class80_3 = this.method_112();
		Class80 class80_4 = this.method_112();
		this.method_293(this.method_33(class80_4, class80_3, true, true));
	}

	// Token: 0x06000330 RID: 816 RVA: 0x0001E068 File Offset: 0x0001C268
	private FieldInfo method_223(int int_0)
	{
		Dictionary<int, object> obj = Class65.dictionary_1;
		FieldInfo result;
		lock (obj)
		{
			bool flag = true;
			object obj2;
			FieldInfo fieldInfo;
			if (Class65.dictionary_1.TryGetValue(int_0, out obj2))
			{
				fieldInfo = (FieldInfo)obj2;
			}
			else
			{
				Class0 class0_ = this.method_111(int_0);
				fieldInfo = this.method_59(int_0, class0_, ref flag);
				if (flag)
				{
					Class65.dictionary_1.Add(int_0, fieldInfo);
				}
			}
			this.method_57(fieldInfo);
			result = fieldInfo;
		}
		return result;
	}

	// Token: 0x06000331 RID: 817 RVA: 0x0001E0E4 File Offset: 0x0001C2E4
	private void method_224(bool bool_2)
	{
		Class80 @class = this.method_112();
		int num = @class.vmethod_2();
		ushort int_;
		if (num <= 14)
		{
			if (num != 8)
			{
				if (num == 14)
				{
					if (bool_2)
					{
						int_ = checked((ushort)((uint)((Class98)@class).method_2()));
						goto IL_BF;
					}
					int_ = (ushort)((Class98)@class).method_2();
					goto IL_BF;
				}
			}
			else
			{
				if (bool_2)
				{
					int_ = checked((ushort)Convert.ToUInt64(((Class84)@class).method_2()));
					goto IL_BF;
				}
				int_ = (ushort)Convert.ToUInt64(((Class84)@class).method_2());
				goto IL_BF;
			}
		}
		else if (num != 16)
		{
			if (num == 19)
			{
				if (bool_2)
				{
					int_ = checked((ushort)((Class86)@class).method_2());
					goto IL_BF;
				}
				int_ = (ushort)((Class86)@class).method_2();
				goto IL_BF;
			}
		}
		else
		{
			if (bool_2)
			{
				int_ = checked((ushort)((ulong)((Class82)@class).method_2()));
				goto IL_BF;
			}
			int_ = (ushort)((Class82)@class).method_2();
			goto IL_BF;
		}
		throw new InvalidOperationException();
		IL_BF:
		Class98 class2 = new Class98();
		class2.method_3((int)int_);
		this.method_293(class2);
	}

	// Token: 0x06000332 RID: 818 RVA: 0x00004467 File Offset: 0x00002667
	private void method_225(Class80 class80_2)
	{
		this.method_2(Class65.type_3);
	}

	// Token: 0x06000333 RID: 819 RVA: 0x00004474 File Offset: 0x00002674
	private void method_226(Class80 class80_2)
	{
		Class98 @class = new Class98();
		@class.method_3(-1);
		this.method_293(@class);
	}

	// Token: 0x06000334 RID: 820 RVA: 0x0001E1C4 File Offset: 0x0001C3C4
	private Class65.Delegate20 method_227(Class65.Struct50 struct50_0)
	{
		Dictionary<Class65.Struct50, Class65.Delegate20> obj = this.dictionary_4;
		Class65.Delegate20 @delegate;
		lock (obj)
		{
			this.dictionary_4.TryGetValue(struct50_0, out @delegate);
		}
		if (@delegate != null)
		{
			return @delegate;
		}
		MethodBase methodBase = struct50_0.method_0();
		Dictionary<MethodBase, object> obj2 = this.dictionary_3;
		lock (obj2)
		{
			while (this.dictionary_3.ContainsKey(methodBase))
			{
				Monitor.Wait(this.dictionary_3);
			}
			this.dictionary_3[methodBase] = null;
		}
		Class65.Delegate20 result;
		try
		{
			obj = this.dictionary_4;
			lock (obj)
			{
				this.dictionary_4.TryGetValue(struct50_0, out @delegate);
			}
			if (@delegate == null)
			{
				@delegate = this.method_14(methodBase, struct50_0.method_1());
				obj = this.dictionary_4;
				lock (obj)
				{
					this.dictionary_4[struct50_0] = @delegate;
				}
			}
			result = @delegate;
		}
		finally
		{
			obj2 = this.dictionary_3;
			lock (obj2)
			{
				this.dictionary_3.Remove(methodBase);
				Monitor.PulseAll(this.dictionary_3);
			}
		}
		return result;
	}

	// Token: 0x06000335 RID: 821 RVA: 0x00004488 File Offset: 0x00002688
	private void method_228(Class80 class80_2)
	{
		this.method_67(false);
	}

	// Token: 0x06000336 RID: 822 RVA: 0x0001E320 File Offset: 0x0001C520
	private static Class80 smethod_20(Class80 class80_2, Class80 class80_3, bool bool_2)
	{
		if (!bool_2)
		{
			long num = ((Class82)class80_2).method_2();
			long num2 = ((Class82)class80_3).method_2();
			Class82 @class = new Class82();
			@class.method_3(num % num2);
			return @class;
		}
		ulong num3 = (ulong)((Class82)class80_2).method_2();
		ulong num4 = (ulong)((Class82)class80_3).method_2();
		Class82 class2 = new Class82();
		class2.method_3((long)(num3 % num4));
		return class2;
	}

	// Token: 0x06000337 RID: 823 RVA: 0x0001E380 File Offset: 0x0001C580
	private void method_229(Class80 class80_2)
	{
		Class80 class80_3 = this.method_112();
		if (!Class65.smethod_0(this.method_112(), class80_3))
		{
			uint uint_ = ((Class92)class80_2).method_2();
			this.method_273(uint_);
		}
	}

	// Token: 0x06000338 RID: 824 RVA: 0x00004491 File Offset: 0x00002691
	private void method_230(Class80 class80_2)
	{
		this.method_112();
	}

	// Token: 0x06000339 RID: 825 RVA: 0x0000449A File Offset: 0x0000269A
	private void method_231(Class80 class80_2)
	{
		this.method_242(typeof(double));
	}

	// Token: 0x0600033A RID: 826 RVA: 0x0001E3B8 File Offset: 0x0001C5B8
	private void method_232(Class80 class80_2)
	{
		Class98 @class = (Class98)class80_2;
		MethodBase methodBase_ = this.method_158(@class.method_2());
		Class95 class2 = new Class95();
		class2.method_3(methodBase_);
		this.method_293(class2);
	}

	// Token: 0x0600033B RID: 827 RVA: 0x0001E3EC File Offset: 0x0001C5EC
	private void method_233(Class80 class80_2)
	{
		int int_ = ((Class98)class80_2).method_2();
		Type type = this.method_16(int_, true);
		Class100 @class = (Class100)this.method_112();
		if (!type.IsValueType)
		{
			this.method_241(@class, new Class90());
			return;
		}
		object obj = this.method_259(@class).vmethod_0();
		if (Class175.smethod_0(type))
		{
			Class100 class100_ = @class;
			Class90 class2 = new Class90();
			class2.method_1(type);
			this.method_241(class100_, class2);
			return;
		}
		foreach (FieldInfo fieldInfo in type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy))
		{
			fieldInfo.SetValue(obj, Class65.smethod_19(fieldInfo.FieldType));
		}
	}

	// Token: 0x0600033C RID: 828 RVA: 0x000044AC File Offset: 0x000026AC
	private void method_234(Class80 class80_2)
	{
		this.method_2(typeof(short));
	}

	// Token: 0x0600033D RID: 829 RVA: 0x0001E490 File Offset: 0x0001C690
	private void method_235(Class80 class80_2)
	{
		int int_ = ((Class98)class80_2).method_2();
		MethodBase methodBase = this.method_158(int_);
		Type declaringType = methodBase.DeclaringType;
		ParameterInfo[] parameters = methodBase.GetParameters();
		int num = parameters.Length;
		object[] array = new object[num];
		Dictionary<int, Class100> dictionary = new Dictionary<int, Class100>();
		for (int i = num - 1; i >= 0; i--)
		{
			Class80 @class = this.method_112();
			Class100 class2;
			if ((class2 = (@class as Class100)) != null)
			{
				dictionary.Add(i, class2);
				@class = this.method_259(class2);
			}
			if (@class.method_0() != null)
			{
				@class = Class29.smethod_1(null, @class.method_0()).vmethod_3(@class);
			}
			Class80 class3 = Class29.smethod_1(null, parameters[i].ParameterType).vmethod_3(@class);
			array[i] = class3.vmethod_0();
		}
		object obj;
		try
		{
			obj = this.method_183(methodBase, null, array, false);
		}
		catch (TargetInvocationException ex)
		{
			Exception object_ = ex.InnerException ?? ex;
			this.method_260(object_);
			return;
		}
		foreach (KeyValuePair<int, Class100> keyValuePair in dictionary)
		{
			this.method_241(keyValuePair.Value, Class29.smethod_1(array[keyValuePair.Key], null));
		}
		this.method_293(Class29.smethod_1(obj, declaringType));
	}

	// Token: 0x0600033E RID: 830 RVA: 0x0001E5E8 File Offset: 0x0001C7E8
	private object method_236(int int_0)
	{
		int num = Class150.smethod_0(int_0);
		object result;
		if (num > 67108864)
		{
			if (num <= 167772160)
			{
				if (num == 100663296)
				{
					goto IL_C4;
				}
				if (num != 167772160)
				{
					goto IL_BE;
				}
				try
				{
					return this.module_0.ModuleHandle.ResolveFieldHandle(int_0);
				}
				catch
				{
					try
					{
						result = this.module_0.ModuleHandle.ResolveMethodHandle(int_0);
					}
					catch
					{
						throw new InvalidOperationException();
					}
					return result;
				}
			}
			if (num == 452984832)
			{
				goto IL_E0;
			}
			if (num != 721420288)
			{
				goto IL_BE;
			}
			IL_C4:
			return this.module_0.ModuleHandle.ResolveMethodHandle(int_0);
		}
		if (num == 16777216 || num == 33554432)
		{
			goto IL_E0;
		}
		if (num == 67108864)
		{
			return this.module_0.ModuleHandle.ResolveFieldHandle(int_0);
		}
		IL_BE:
		throw new InvalidOperationException();
		IL_E0:
		result = this.module_0.ModuleHandle.ResolveTypeHandle(int_0);
		return result;
	}

	// Token: 0x0600033F RID: 831 RVA: 0x0001E70C File Offset: 0x0001C90C
	private void method_237(Class80 class80_2)
	{
		object object_ = this.method_112().vmethod_0();
		long num = this.method_294();
		Array array = (Array)this.method_112().vmethod_0();
		Type elementType = array.GetType().GetElementType();
		checked
		{
			if (elementType == typeof(int))
			{
				Class80 @class = Class29.smethod_1(object_, typeof(int));
				((int[])array)[(int)((IntPtr)num)] = (int)@class.vmethod_0();
				return;
			}
			if (elementType == typeof(uint))
			{
				Class80 class2 = Class29.smethod_1(object_, typeof(uint));
				((uint[])array)[(int)((IntPtr)num)] = (uint)class2.vmethod_0();
				return;
			}
			if (elementType.IsEnum)
			{
				this.method_287(elementType, object_, num, array);
				return;
			}
			this.method_287(typeof(int), object_, num, array);
		}
	}

	// Token: 0x06000340 RID: 832 RVA: 0x0001E7DC File Offset: 0x0001C9DC
	private Class42 method_238(Class123 class123_2)
	{
		Class42 @class = new Class42();
		@class.method_3(this.method_198(class123_2));
		@class.method_11(class123_2.method_6());
		@class.method_7(class123_2.method_19());
		@class.method_1(this.method_15(class123_2));
		@class.method_5(class123_2.method_9());
		@class.method_9(class123_2.method_19());
		return @class;
	}

	// Token: 0x06000341 RID: 833 RVA: 0x000044BE File Offset: 0x000026BE
	private void method_239(Class80 class80_2)
	{
		if (this.object_1 == null)
		{
			throw new InvalidOperationException();
		}
		this.method_260(this.object_1);
	}

	// Token: 0x06000342 RID: 834 RVA: 0x0001E838 File Offset: 0x0001CA38
	private static Class80 smethod_21(Class80 class80_2, Class80 class80_3, bool bool_2)
	{
		if (!bool_2)
		{
			long num = ((Class82)class80_2).method_2();
			long num2 = ((Class82)class80_3).method_2();
			Class82 @class = new Class82();
			@class.method_3(num / num2);
			return @class;
		}
		ulong num3 = (ulong)((Class82)class80_2).method_2();
		ulong num4 = (ulong)((Class82)class80_3).method_2();
		Class82 class2 = new Class82();
		class2.method_3((long)(num3 / num4));
		return class2;
	}

	// Token: 0x06000343 RID: 835 RVA: 0x00003FF2 File Offset: 0x000021F2
	private void method_240(Class80 class80_2)
	{
		this.method_293(class80_2);
	}

	// Token: 0x06000344 RID: 836 RVA: 0x0001E898 File Offset: 0x0001CA98
	private void method_241(Class100 class100_0, Class80 class80_2)
	{
		int num = class100_0.vmethod_2();
		switch (num)
		{
		case 1:
			this.class80_1[((Class103)class100_0).method_2()].vmethod_3(class80_2);
			return;
		case 2:
		case 4:
			goto IL_DE;
		case 3:
			break;
		case 5:
			((Class102)class100_0).method_2().vmethod_3(class80_2);
			return;
		default:
			if (num != 11)
			{
				if (num != 17)
				{
					goto IL_DE;
				}
				Class101 @class = (Class101)class100_0;
				FieldInfo fieldInfo = @class.method_4();
				Class80 class2 = Class29.smethod_1(class80_2.vmethod_0(), fieldInfo.FieldType);
				fieldInfo.SetValue(@class.method_2(), class2.vmethod_0());
				Class100 class3 = @class.method_6();
				if (class3 != null && fieldInfo.DeclaringType.IsValueType)
				{
					this.method_241(class3, Class29.smethod_1(@class.method_2(), null));
					return;
				}
				return;
			}
			break;
		}
		Class104 class4 = (Class104)class100_0;
		Class80 class5 = Class29.smethod_1(class80_2.vmethod_0(), class4.method_2());
		class4.vmethod_6(class5.vmethod_0());
		return;
		IL_DE:
		throw new ArgumentOutOfRangeException();
	}

	// Token: 0x06000345 RID: 837 RVA: 0x0001E99C File Offset: 0x0001CB9C
	private void method_242(Type type_9)
	{
		object object_ = this.method_112().vmethod_0();
		long long_ = this.method_294();
		Array array_ = (Array)this.method_112().vmethod_0();
		this.method_287(type_9, object_, long_, array_);
	}

	// Token: 0x06000346 RID: 838 RVA: 0x0001E9D8 File Offset: 0x0001CBD8
	private bool method_243(Type type_9, Class0 class0_0)
	{
		Class138 @class = (Class138)class0_0.method_4();
		if (Class37.smethod_0(type_9).IsGenericParameter)
		{
			return @class == null || @class.method_2();
		}
		Type type = this.method_16(class0_0.method_2(), false);
		return Class63.smethod_0(type_9, type);
	}

	// Token: 0x06000347 RID: 839 RVA: 0x000044DA File Offset: 0x000026DA
	private static Exception smethod_22(string string_0, string string_1)
	{
		return new TypeLoadException(Class65.smethod_11(string.Format("security transparent method '{0}'", string_0), string.Format("security critical type '{0}'", string_1)));
	}

	// Token: 0x06000348 RID: 840 RVA: 0x0001EA28 File Offset: 0x0001CC28
	private static bool smethod_23(MethodBase methodBase_0)
	{
		ParameterInfo[] parameters = methodBase_0.GetParameters();
		for (int i = 0; i < parameters.Length; i++)
		{
			if (parameters[i].ParameterType.IsByRef)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000349 RID: 841 RVA: 0x0001EA60 File Offset: 0x0001CC60
	private void method_244(Class80 class80_2)
	{
		uint uint_ = ((Class92)class80_2).method_2();
		this.method_273(uint_);
	}

	// Token: 0x0600034A RID: 842 RVA: 0x000044FC File Offset: 0x000026FC
	private void method_245(Class80 class80_2)
	{
		this.method_2(typeof(sbyte));
	}

	// Token: 0x0600034B RID: 843 RVA: 0x0001EA80 File Offset: 0x0001CC80
	private bool method_246(MethodBase methodBase_0, object object_3, Class80[] class80_2, object[] object_4, bool bool_2, ref object object_5)
	{
		Type declaringType = methodBase_0.DeclaringType;
		if (declaringType == null)
		{
			return false;
		}
		if (declaringType == Class65.type_8 && methodBase_0.Name == "InitializeArray" && object_4.Length == 2)
		{
			string a = methodBase_0.ToString();
			if (a == "Void InitializeArray(System.Array, System.RuntimeFieldHandle)")
			{
				Class17.smethod_0((Array)object_4[0], (RuntimeFieldHandle)object_4[1]);
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600034C RID: 844 RVA: 0x0001EAE8 File Offset: 0x0001CCE8
	private void method_247()
	{
		if (!this.class119_0.method_1())
		{
			Class119 obj = this.class119_0;
			lock (obj)
			{
				if (!this.class119_0.method_1())
				{
					this.dictionary_2 = this.method_38();
					this.method_49();
					this.class119_0.method_2(true);
				}
			}
		}
		if (this.dictionary_2 == null)
		{
			this.dictionary_2 = this.method_38();
		}
	}

	// Token: 0x0600034D RID: 845 RVA: 0x0001EB68 File Offset: 0x0001CD68
	private void method_248(Class80 class80_2)
	{
		Class80 class80_3 = this.method_112();
		Class80 class80_4 = this.method_112();
		this.method_293(this.method_128(class80_4, class80_3, true, false));
	}

	// Token: 0x0600034E RID: 846 RVA: 0x0000450E File Offset: 0x0000270E
	private void method_249()
	{
		Class65.smethod_10<Class134>(this.class134_0, new Comparison<Class134>(Class65.Class66.class66_0.method_0));
	}

	// Token: 0x0600034F RID: 847 RVA: 0x0001EB94 File Offset: 0x0001CD94
	private static BindingFlags smethod_24(bool bool_2)
	{
		BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic;
		if (bool_2)
		{
			bindingFlags |= BindingFlags.Static;
		}
		else
		{
			bindingFlags |= BindingFlags.Instance;
		}
		return bindingFlags;
	}

	// Token: 0x06000350 RID: 848 RVA: 0x0000453A File Offset: 0x0000273A
	private void method_250(Class80 class80_2)
	{
		this.method_34(false);
	}

	// Token: 0x06000351 RID: 849 RVA: 0x0001EBB4 File Offset: 0x0001CDB4
	private void method_251(Class80 class80_2)
	{
		Class80 class80_3 = this.method_112();
		Class80 class80_4 = this.method_112();
		Class98 @class = new Class98();
		@class.method_3(Class65.smethod_0(class80_4, class80_3) ? 1 : 0);
		this.method_293(@class);
	}

	// Token: 0x06000352 RID: 850 RVA: 0x00004543 File Offset: 0x00002743
	private void method_252(Class80 class80_2)
	{
		this.method_282();
	}

	// Token: 0x06000353 RID: 851 RVA: 0x0001EBF0 File Offset: 0x0001CDF0
	private void method_253(Class80 class80_2)
	{
		Class80 @class = this.method_112();
		int num = @class.vmethod_2();
		bool flag;
		if (num <= 14)
		{
			if (num == 6)
			{
				flag = (((Class83)@class).method_2() == UIntPtr.Zero);
				goto IL_C1;
			}
			if (num == 8)
			{
				flag = !Convert.ToBoolean(((Class84)@class).method_2());
				goto IL_C1;
			}
			if (num == 14)
			{
				flag = (((Class98)@class).method_2() == 0);
				goto IL_C1;
			}
		}
		else
		{
			if (num == 16)
			{
				flag = (((Class82)@class).method_2() == 0L);
				goto IL_C1;
			}
			if (num == 21)
			{
				flag = (((Class90)@class).method_2() == null);
				goto IL_C1;
			}
			if (num == 23)
			{
				flag = (((Class99)@class).method_2() == IntPtr.Zero);
				goto IL_C1;
			}
		}
		flag = (@class.vmethod_0() == null);
		IL_C1:
		if (flag)
		{
			uint uint_ = ((Class92)class80_2).method_2();
			this.method_273(uint_);
		}
	}

	// Token: 0x06000354 RID: 852 RVA: 0x0001ECD4 File Offset: 0x0001CED4
	private void method_254(ref Class65.Struct48 struct48_0, MethodBase methodBase_0, bool bool_2)
	{
		bool flag = false;
		if (methodBase_0.DeclaringType == typeof(Interlocked) && methodBase_0.IsStatic)
		{
			string name = methodBase_0.Name;
			if (name == "Add" || name == "CompareExchange" || name == "Decrement" || name == "Exchange" || name == "Increment" || name == "Read")
			{
				flag = true;
			}
		}
		if (flag)
		{
			try
			{
			}
			finally
			{
				Monitor.Enter(Class65.object_0);
				struct48_0.bool_0 = true;
			}
		}
	}

	// Token: 0x06000355 RID: 853 RVA: 0x0001ED7C File Offset: 0x0001CF7C
	private void method_255(Class80 class80_2)
	{
		int int_ = ((Class98)class80_2).method_2();
		Type elementType = this.method_16(int_, true);
		Class80 @class = this.method_112();
		Class98 class2 = @class as Class98;
		int length;
		if (class2 != null)
		{
			length = class2.method_2();
		}
		else
		{
			Class99 class3 = @class as Class99;
			if (class3 != null)
			{
				length = class3.method_2().ToInt32();
			}
			else
			{
				Class83 class4 = @class as Class83;
				if (class4 == null)
				{
					throw new Exception();
				}
				length = (int)class4.method_2().ToUInt32();
			}
		}
		Array array_ = Array.CreateInstance(elementType, length);
		Class93 class5 = new Class93();
		class5.method_3(array_);
		this.method_293(class5);
	}

	// Token: 0x06000356 RID: 854 RVA: 0x0001EE18 File Offset: 0x0001D018
	private void method_256(Class80 class80_2)
	{
		Class80 class80_3 = this.method_112();
		if (!Class65.smethod_8(this.method_112(), class80_3))
		{
			uint uint_ = ((Class92)class80_2).method_2();
			this.method_273(uint_);
		}
	}

	// Token: 0x06000357 RID: 855 RVA: 0x0000454B File Offset: 0x0000274B
	private void method_257(Class80 class80_2)
	{
		this.method_293(this.class80_0[1].vmethod_4());
	}

	// Token: 0x06000358 RID: 856 RVA: 0x0001EE50 File Offset: 0x0001D050
	private void method_258(Class80 class80_2)
	{
		int int_ = ((Class98)class80_2).method_2();
		Type type = this.method_16(int_, true);
		long long_ = this.method_294();
		Array array_ = (Array)this.method_112().vmethod_0();
		Class106 @class = new Class106();
		@class.method_5(array_);
		@class.method_3(type);
		@class.method_7(long_);
		this.method_293(@class);
	}

	// Token: 0x06000359 RID: 857 RVA: 0x0001EEAC File Offset: 0x0001D0AC
	private Class80 method_259(Class100 class100_0)
	{
		int num = class100_0.vmethod_2();
		switch (num)
		{
		case 1:
			return this.class80_1[((Class103)class100_0).method_2()];
		case 2:
		case 4:
			goto IL_7E;
		case 3:
			break;
		case 5:
			return ((Class102)class100_0).method_2();
		default:
			if (num != 11)
			{
				if (num != 17)
				{
					goto IL_7E;
				}
				Class101 @class = (Class101)class100_0;
				return Class29.smethod_1(@class.method_4().GetValue(@class.method_2()), null);
			}
			break;
		}
		Class104 class2 = (Class104)class100_0;
		return Class29.smethod_1(class2.vmethod_5(), class2.method_2());
		IL_7E:
		throw new ArgumentOutOfRangeException();
	}

	// Token: 0x0600035A RID: 858 RVA: 0x0001EF48 File Offset: 0x0001D148
	private void method_260(object object_3)
	{
		Exception ex = object_3 as Exception;
		if (ex != null)
		{
			Class65.smethod_29(ex);
		}
		Class65.smethod_16(object_3);
	}

	// Token: 0x0600035B RID: 859 RVA: 0x00002D6B File Offset: 0x00000F6B
	[Conditional("DEBUG")]
	public static void smethod_25(string string_0)
	{
	}

	// Token: 0x0600035C RID: 860 RVA: 0x00004564 File Offset: 0x00002764
	private void method_261(Class80 class80_2)
	{
		this.method_272(true);
	}

	// Token: 0x0600035D RID: 861 RVA: 0x0001EF6C File Offset: 0x0001D16C
	private void method_262(Class80 class80_2)
	{
		int int_ = ((Class98)class80_2).method_2();
		Type type = this.method_16(int_, true);
		Class80 @class = Class29.smethod_1(this.method_112().vmethod_0(), type);
		@class.method_1(type);
		this.method_293(@class);
	}

	// Token: 0x0600035E RID: 862 RVA: 0x0000456D File Offset: 0x0000276D
	private static void smethod_26(ILGenerator ilgenerator_0, Type type_9)
	{
		if (type_9.IsValueType || Class37.smethod_0(type_9).IsGenericParameter)
		{
			ilgenerator_0.Emit(OpCodes.Box, type_9);
		}
	}

	// Token: 0x0600035F RID: 863 RVA: 0x0001EFB0 File Offset: 0x0001D1B0
	private void method_263(Class80 class80_2)
	{
		int int_ = ((Class98)class80_2).method_2();
		FieldInfo fieldInfo = this.method_223(int_);
		Class80 @class = this.method_112();
		Class100 class100_;
		if ((class100_ = (@class as Class100)) != null)
		{
			@class = this.method_259(class100_);
		}
		object obj = @class.vmethod_0();
		if (obj == null)
		{
			throw new NullReferenceException();
		}
		this.method_293(Class29.smethod_1(fieldInfo.GetValue(obj), fieldInfo.FieldType));
	}

	// Token: 0x06000360 RID: 864 RVA: 0x00004590 File Offset: 0x00002790
	private void method_264(Class80 class80_2)
	{
		this.method_123(true);
	}

	// Token: 0x06000361 RID: 865 RVA: 0x000030C0 File Offset: 0x000012C0
	private static bool smethod_27()
	{
		return false;
	}

	// Token: 0x06000362 RID: 866 RVA: 0x0001F014 File Offset: 0x0001D214
	private void method_265(Class80 class80_2)
	{
		object object_ = this.method_112().vmethod_0();
		long num = this.method_294();
		Array array = (Array)this.method_112().vmethod_0();
		Type elementType = array.GetType().GetElementType();
		checked
		{
			if (elementType == typeof(long))
			{
				Class80 @class = Class29.smethod_1(object_, typeof(long));
				((long[])array)[(int)((IntPtr)num)] = (long)@class.vmethod_0();
				return;
			}
			if (elementType == typeof(ulong))
			{
				Class80 class2 = Class29.smethod_1(object_, typeof(ulong));
				((ulong[])array)[(int)((IntPtr)num)] = (ulong)class2.vmethod_0();
				return;
			}
			if (elementType.IsEnum)
			{
				this.method_287(elementType, object_, num, array);
				return;
			}
			this.method_287(typeof(long), object_, num, array);
		}
	}

	// Token: 0x06000363 RID: 867 RVA: 0x0001F0E4 File Offset: 0x0001D2E4
	private void method_266(Class80 class80_2)
	{
		int int_ = ((Class98)class80_2).method_2();
		Type type_ = this.method_16(int_, true);
		Class80 class80_3 = this.method_112();
		if (this.method_98(class80_3, type_))
		{
			this.method_293(class80_3);
			return;
		}
		this.method_293(new Class90());
	}

	// Token: 0x06000364 RID: 868 RVA: 0x00004599 File Offset: 0x00002799
	private void method_267(Class80 class80_2)
	{
		this.method_2(typeof(float));
	}

	// Token: 0x06000365 RID: 869 RVA: 0x000045AB File Offset: 0x000027AB
	public object method_268(Stream stream_1, string string_0, object[] object_3, Type[] type_9, Type[] type_10, object[] object_4)
	{
		this.stream_0 = stream_1;
		this.method_103(stream_1, string_0);
		return this.method_86(object_3, type_9, type_10, object_4);
	}

	// Token: 0x06000366 RID: 870 RVA: 0x0001F12C File Offset: 0x0001D32C
	private static byte[] smethod_28(Class123 class123_2)
	{
		int num = class123_2.method_19();
		byte[] array = new byte[num];
		class123_2.method_14(array, 0, num);
		return array;
	}

	// Token: 0x06000367 RID: 871 RVA: 0x0001F154 File Offset: 0x0001D354
	private void method_269()
	{
		Class80 class80_ = this.method_112();
		Class100 class100_ = (Class100)this.method_112();
		this.method_241(class100_, class80_);
	}

	// Token: 0x06000368 RID: 872 RVA: 0x000045C9 File Offset: 0x000027C9
	private int method_270()
	{
		return -1172070570;
	}

	// Token: 0x06000369 RID: 873 RVA: 0x000045D0 File Offset: 0x000027D0
	private object method_271(MethodBase methodBase_0, object object_3, object[] object_4)
	{
		if (methodBase_0.IsConstructor)
		{
			return Activator.CreateInstance(methodBase_0.DeclaringType, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, object_4, null);
		}
		return methodBase_0.Invoke(object_3, object_4);
	}

	// Token: 0x0600036A RID: 874 RVA: 0x0001F17C File Offset: 0x0001D37C
	private void method_272(bool bool_2)
	{
		Class80 @class = this.method_112();
		int num = @class.vmethod_2();
		long long_;
		if (num <= 14)
		{
			if (num != 8)
			{
				if (num == 14)
				{
					if (bool_2)
					{
						long_ = (long)((Class98)@class).method_2();
						goto IL_BA;
					}
					long_ = (long)((Class98)@class).method_2();
					goto IL_BA;
				}
			}
			else
			{
				if (bool_2)
				{
					long_ = checked((long)Convert.ToUInt64(((Class84)@class).method_2()));
					goto IL_BA;
				}
				long_ = (long)Convert.ToUInt64(((Class84)@class).method_2());
				goto IL_BA;
			}
		}
		else if (num != 16)
		{
			if (num == 19)
			{
				if (bool_2)
				{
					long_ = checked((long)((Class86)@class).method_2());
					goto IL_BA;
				}
				long_ = (long)((Class86)@class).method_2();
				goto IL_BA;
			}
		}
		else
		{
			if (bool_2)
			{
				long_ = ((Class82)@class).method_2();
				goto IL_BA;
			}
			long_ = ((Class82)@class).method_2();
			goto IL_BA;
		}
		throw new InvalidOperationException();
		IL_BA:
		Class82 class2 = new Class82();
		class2.method_3(long_);
		this.method_293(class2);
	}

	// Token: 0x0600036B RID: 875 RVA: 0x000045F3 File Offset: 0x000027F3
	private void method_273(uint uint_0)
	{
		this.nullable_0 = new uint?(uint_0);
	}

	// Token: 0x0600036C RID: 876 RVA: 0x0001F258 File Offset: 0x0001D458
	private void method_274(Class80 class80_2)
	{
		Class88 @class = (Class88)class80_2;
		this.method_293(this.class80_0[(int)@class.method_2()].vmethod_4());
	}

	// Token: 0x0600036D RID: 877 RVA: 0x0001F288 File Offset: 0x0001D488
	private void method_275(Class80 class80_2)
	{
		Class80 @class = this.method_112();
		Class80 class80_3 = @class.vmethod_4();
		this.method_293(@class);
		this.method_293(class80_3);
	}

	// Token: 0x0600036E RID: 878 RVA: 0x0001F2B4 File Offset: 0x0001D4B4
	private void method_276(Class80 class80_2)
	{
		Class80 class80_3 = this.method_112();
		Class80 class80_4 = this.method_112();
		Class98 @class = new Class98();
		@class.method_3(Class65.smethod_2(class80_4, class80_3) ? 1 : 0);
		this.method_293(@class);
	}

	// Token: 0x0600036F RID: 879 RVA: 0x0001F2F0 File Offset: 0x0001D4F0
	private void method_277(Type type_9)
	{
		long index = this.method_294();
		Array array = (Array)this.method_112().vmethod_0();
		this.method_293(Class29.smethod_1(array.GetValue(index), type_9));
	}

	// Token: 0x06000370 RID: 880 RVA: 0x0001F328 File Offset: 0x0001D528
	private void method_278(Class80 class80_2)
	{
		int int_ = ((Class98)class80_2).method_2();
		FieldInfo fieldInfo_ = this.method_223(int_);
		this.method_293(new Class101(fieldInfo_, null));
	}

	// Token: 0x06000371 RID: 881 RVA: 0x0001F358 File Offset: 0x0001D558
	private Class80 method_279(Class80 class80_2, Class80 class80_3, bool bool_2)
	{
		if (class80_2.vmethod_2() == 14)
		{
			if (class80_3.vmethod_2() == 14)
			{
				if (!bool_2)
				{
					int num = ((Class98)class80_2).method_2();
					int num2 = ((Class98)class80_3).method_2();
					Class98 @class = new Class98();
					@class.method_3(num >> num2);
					return @class;
				}
				uint num3 = (uint)((Class98)class80_2).method_2();
				int num4 = ((Class98)class80_3).method_2();
				Class98 class2 = new Class98();
				class2.method_3((int)(num3 >> num4));
				return class2;
			}
			else if (class80_3.vmethod_2() == 8)
			{
				Class98 class3 = new Class98();
				class3.method_3(Convert.ToInt32(class80_3.vmethod_0()));
				return this.method_279(class80_2, class3, bool_2);
			}
		}
		if (class80_2.vmethod_2() == 16)
		{
			if (class80_3.vmethod_2() == 14)
			{
				if (!bool_2)
				{
					long num5 = ((Class82)class80_2).method_2();
					int num6 = ((Class98)class80_3).method_2();
					Class82 class4 = new Class82();
					class4.method_3(num5 >> num6);
					return class4;
				}
				ulong num7 = (ulong)((Class82)class80_2).method_2();
				int num8 = ((Class98)class80_3).method_2();
				Class82 class5 = new Class82();
				class5.method_3((long)(num7 >> num8));
				return class5;
			}
			else if (class80_3.vmethod_2() == 8)
			{
				Class98 class6 = new Class98();
				class6.method_3(Convert.ToInt32(class80_3.vmethod_0()));
				return this.method_279(class80_2, class6, bool_2);
			}
		}
		if (class80_2.vmethod_2() == 8)
		{
			Type underlyingType = Enum.GetUnderlyingType(class80_2.vmethod_0().GetType());
			if (underlyingType != typeof(long))
			{
				if (underlyingType != typeof(ulong))
				{
					Class98 class7 = new Class98();
					class7.method_3(Convert.ToInt32(class80_2.vmethod_0()));
					return this.method_279(class7, class80_3, bool_2);
				}
			}
			Class82 class8 = new Class82();
			class8.method_3(Convert.ToInt64(class80_2.vmethod_0()));
			return this.method_279(class8, class80_3, bool_2);
		}
		throw new InvalidOperationException();
	}

	// Token: 0x06000372 RID: 882 RVA: 0x00004601 File Offset: 0x00002801
	private void method_280(Class80 class80_2)
	{
		this.method_2(typeof(int));
	}

	// Token: 0x06000373 RID: 883 RVA: 0x0001F514 File Offset: 0x0001D714
	private void method_281(bool bool_2)
	{
		Class80 @class = this.method_112();
		int num = @class.vmethod_2();
		checked
		{
			UIntPtr uintptr_;
			if (num <= 14)
			{
				if (num != 8)
				{
					if (num == 14)
					{
						if (bool_2)
						{
							uintptr_ = new UIntPtr((uint)((Class98)@class).method_2());
							goto IL_EF;
						}
						uintptr_ = new UIntPtr((uint)((Class98)@class).method_2());
						goto IL_EF;
					}
				}
				else
				{
					if (bool_2)
					{
						uintptr_ = new UIntPtr(Convert.ToUInt64(((Class84)@class).method_2()));
						goto IL_EF;
					}
					uintptr_ = new UIntPtr(Convert.ToUInt64(((Class84)@class).method_2()));
					goto IL_EF;
				}
			}
			else if (num != 16)
			{
				if (num == 19)
				{
					if (bool_2)
					{
						uintptr_ = new UIntPtr((ulong)((Class86)@class).method_2());
						goto IL_EF;
					}
					uintptr_ = new UIntPtr(unchecked((ulong)((Class86)@class).method_2()));
					goto IL_EF;
				}
			}
			else
			{
				if (bool_2)
				{
					uintptr_ = new UIntPtr((ulong)((Class82)@class).method_2());
					goto IL_EF;
				}
				uintptr_ = new UIntPtr((ulong)((Class82)@class).method_2());
				goto IL_EF;
			}
			throw new InvalidOperationException();
			IL_EF:
			Class83 class2 = new Class83();
			class2.method_3(uintptr_);
			this.method_293(class2);
		}
	}

	// Token: 0x06000374 RID: 884 RVA: 0x0001F624 File Offset: 0x0001D824
	private void method_282()
	{
		if (this.class15_1.Count == 0)
		{
			if (this.bool_1)
			{
				this.method_260(this.object_1);
			}
			return;
		}
		Class65.Struct49 @struct = this.class15_1.method_6();
		if (@struct.method_1() != null)
		{
			Class90 @class = new Class90();
			@class.vmethod_1(@struct.method_1());
			this.method_293(@class);
		}
		else
		{
			this.class15_0.method_0();
		}
		this.method_273(@struct.method_0());
	}

	// Token: 0x06000375 RID: 885 RVA: 0x0001F69C File Offset: 0x0001D89C
	private void method_283(bool bool_2)
	{
		Class80 @class = this.method_112();
		int num = @class.vmethod_2();
		IntPtr intptr_;
		if (num <= 14)
		{
			if (num != 8)
			{
				if (num == 14)
				{
					if (bool_2)
					{
						intptr_ = new IntPtr(((Class98)@class).method_2());
						goto IL_EB;
					}
					intptr_ = new IntPtr(((Class98)@class).method_2());
					goto IL_EB;
				}
			}
			else
			{
				if (bool_2)
				{
					intptr_ = new IntPtr(checked((long)Convert.ToUInt64(((Class84)@class).method_2())));
					goto IL_EB;
				}
				intptr_ = new IntPtr((long)Convert.ToUInt64(((Class84)@class).method_2()));
				goto IL_EB;
			}
		}
		else if (num != 16)
		{
			if (num == 19)
			{
				if (bool_2)
				{
					intptr_ = new IntPtr(checked((long)((Class86)@class).method_2()));
					goto IL_EB;
				}
				intptr_ = new IntPtr((long)((Class86)@class).method_2());
				goto IL_EB;
			}
		}
		else
		{
			if (bool_2)
			{
				intptr_ = new IntPtr(((Class82)@class).method_2());
				goto IL_EB;
			}
			intptr_ = new IntPtr(((Class82)@class).method_2());
			goto IL_EB;
		}
		throw new InvalidOperationException();
		IL_EB:
		Class99 class2 = new Class99();
		class2.method_3(intptr_);
		this.method_293(class2);
	}

	// Token: 0x06000376 RID: 886 RVA: 0x00004613 File Offset: 0x00002813
	private void method_284(Class80 class80_2)
	{
		this.method_281(false);
	}

	// Token: 0x06000377 RID: 887 RVA: 0x0001F7A8 File Offset: 0x0001D9A8
	private Class80 method_285(Class80 class80_2, Class80 class80_3, bool bool_2, bool bool_3)
	{
		if (class80_2.vmethod_2() == 14)
		{
			if (class80_3.vmethod_2() == 14)
			{
				if (!bool_3)
				{
					int num = ((Class98)class80_2).method_2();
					int num2 = ((Class98)class80_3).method_2();
					int int_;
					if (bool_2)
					{
						int_ = checked(num + num2);
					}
					else
					{
						int_ = num + num2;
					}
					Class98 @class = new Class98();
					@class.method_3(int_);
					return @class;
				}
				uint num3 = (uint)((Class98)class80_2).method_2();
				uint num4 = (uint)((Class98)class80_3).method_2();
				uint int_2;
				if (bool_2)
				{
					int_2 = checked(num3 + num4);
				}
				else
				{
					int_2 = num3 + num4;
				}
				Class98 class2 = new Class98();
				class2.method_3((int)int_2);
				return class2;
			}
			else
			{
				if (class80_3.vmethod_2() == 16)
				{
					Class82 class3 = new Class82();
					class3.method_3((long)((Class98)class80_2).method_2());
					return Class65.smethod_18(class3, class80_3, bool_2, bool_3);
				}
				if (class80_3.vmethod_2() == 8)
				{
					Type underlyingType = Enum.GetUnderlyingType(class80_3.vmethod_0().GetType());
					if (underlyingType != typeof(long))
					{
						if (underlyingType != typeof(ulong))
						{
							Class98 class4 = new Class98();
							class4.method_3(Convert.ToInt32(class80_3.vmethod_0()));
							return this.method_285(class80_2, class4, bool_2, bool_3);
						}
					}
					Class82 class5 = new Class82();
					class5.method_3((long)((Class98)class80_2).method_2());
					Class82 class6 = new Class82();
					class6.method_3(Convert.ToInt64(class80_3.vmethod_0()));
					return Class65.smethod_18(class5, class6, bool_2, bool_3);
				}
			}
		}
		if (class80_2.vmethod_2() == 16)
		{
			if (class80_3.vmethod_2() == 16)
			{
				return Class65.smethod_18(class80_2, class80_3, bool_2, bool_3);
			}
			if (class80_3.vmethod_2() == 14)
			{
				Class82 class7 = new Class82();
				class7.method_3((long)((Class98)class80_3).method_2());
				return Class65.smethod_18(class80_2, class7, bool_2, bool_3);
			}
			if (class80_3.vmethod_2() == 8)
			{
				Type underlyingType2 = Enum.GetUnderlyingType(class80_3.vmethod_0().GetType());
				if (underlyingType2 != typeof(long))
				{
					if (underlyingType2 != typeof(ulong))
					{
						Class98 class8 = new Class98();
						class8.method_3(Convert.ToInt32(class80_3.vmethod_0()));
						return Class65.smethod_18(class80_2, class8, bool_2, bool_3);
					}
				}
				Class82 class9 = new Class82();
				class9.method_3(Convert.ToInt64(class80_3.vmethod_0()));
				return Class65.smethod_18(class80_2, class9, bool_2, bool_3);
			}
		}
		if (class80_2.vmethod_2() == 19 && class80_3.vmethod_2() == 19)
		{
			Class86 class10 = new Class86();
			class10.method_3(((Class86)class80_2).method_2() + ((Class86)class80_3).method_2());
			return class10;
		}
		if (class80_2.vmethod_2() == 8)
		{
			Type underlyingType3 = Enum.GetUnderlyingType(class80_2.vmethod_0().GetType());
			if (underlyingType3 != typeof(long))
			{
				if (underlyingType3 != typeof(ulong))
				{
					Class98 class11 = new Class98();
					class11.method_3(Convert.ToInt32(class80_2.vmethod_0()));
					return this.method_285(class11, class80_3, bool_2, bool_3);
				}
			}
			Class82 class12 = new Class82();
			class12.method_3(Convert.ToInt64(class80_2.vmethod_0()));
			return this.method_285(class12, class80_3, bool_2, bool_3);
		}
		throw new InvalidOperationException();
	}

	// Token: 0x06000378 RID: 888 RVA: 0x0001FA78 File Offset: 0x0001DC78
	private void method_286(Class80 class80_2)
	{
		Class80 @class = this.method_112();
		int num = @class.vmethod_2();
		checked
		{
			sbyte int_;
			if (num <= 14)
			{
				if (num == 8)
				{
					int_ = (sbyte)Convert.ToUInt64(((Class84)@class).method_2());
					goto IL_6F;
				}
				if (num == 14)
				{
					int_ = (sbyte)((uint)((Class98)@class).method_2());
					goto IL_6F;
				}
			}
			else
			{
				if (num == 16)
				{
					int_ = (sbyte)((ulong)((Class82)@class).method_2());
					goto IL_6F;
				}
				if (num == 19)
				{
					int_ = (sbyte)((Class86)@class).method_2();
					goto IL_6F;
				}
			}
			throw new InvalidOperationException();
			IL_6F:
			Class98 class2 = new Class98();
			class2.method_3((int)int_);
			this.method_293(class2);
		}
	}

	// Token: 0x06000379 RID: 889 RVA: 0x0000461C File Offset: 0x0000281C
	private static void smethod_29(Exception exception_0)
	{
		ExceptionDispatchInfo.Capture(exception_0).Throw();
	}

	// Token: 0x0600037A RID: 890 RVA: 0x00004629 File Offset: 0x00002829
	private static void smethod_30(ILGenerator ilgenerator_0, Type type_9)
	{
		if (type_9 == Class175.type_0)
		{
			return;
		}
		ilgenerator_0.Emit(OpCodes.Castclass, type_9);
	}

	// Token: 0x0600037B RID: 891 RVA: 0x0001FB08 File Offset: 0x0001DD08
	private void method_287(Type type_9, object object_3, long long_1, Array array_0)
	{
		Class80 @class = Class29.smethod_1(object_3, type_9);
		array_0.SetValue(@class.vmethod_0(), long_1);
	}

	// Token: 0x0600037C RID: 892 RVA: 0x00003F73 File Offset: 0x00002173
	private void method_288(Class80 class80_2)
	{
		this.method_269();
	}

	// Token: 0x0600037D RID: 893 RVA: 0x00004640 File Offset: 0x00002840
	private void method_289(Class80 class80_2)
	{
		this.method_277(typeof(ushort));
	}

	// Token: 0x0600037E RID: 894 RVA: 0x0001FB2C File Offset: 0x0001DD2C
	private object method_290(Stream stream_1, int int_0, object[] object_3, Type[] type_9, Type[] type_10, object[] object_4)
	{
		this.stream_0 = stream_1;
		this.method_1(stream_1, (long)int_0, null);
		if (this.class42_0.method_12())
		{
			Type type;
			try
			{
				type = this.method_16(this.class42_0.method_6(), false);
			}
			catch (InvalidOperationException)
			{
				type = null;
			}
			if (type != null)
			{
				RuntimeHelpers.RunClassConstructor(type.TypeHandle);
			}
		}
		return this.method_86(object_3, type_9, type_10, object_4);
	}

	// Token: 0x0600037F RID: 895 RVA: 0x00003FF2 File Offset: 0x000021F2
	private void method_291(Class80 class80_2)
	{
		this.method_293(class80_2);
	}

	// Token: 0x06000380 RID: 896 RVA: 0x00003FF2 File Offset: 0x000021F2
	private void method_292(Class80 class80_2)
	{
		this.method_293(class80_2);
	}

	// Token: 0x06000381 RID: 897 RVA: 0x0001FB9C File Offset: 0x0001DD9C
	private void method_293(Class80 class80_2)
	{
		if (class80_2 == null)
		{
			throw new ArgumentNullException("obj");
		}
		Class80 gparam_;
		if (class80_2.method_0() != null)
		{
			gparam_ = class80_2;
		}
		else
		{
			int num = class80_2.vmethod_2();
			if (num <= 7)
			{
				if (num == 0)
				{
					Class98 @class = new Class98();
					@class.method_3(((Class97)class80_2).method_2() ? 1 : 0);
					@class.method_1(class80_2.method_0());
					gparam_ = @class;
					goto IL_235;
				}
				if (num == 2)
				{
					Class98 class2 = new Class98();
					class2.method_3((int)((Class88)class80_2).method_2());
					class2.method_1(class80_2.method_0());
					gparam_ = class2;
					goto IL_235;
				}
				if (num == 7)
				{
					Class98 class3 = new Class98();
					class3.method_3((int)((Class85)class80_2).method_2());
					class3.method_1(class80_2.method_0());
					gparam_ = class3;
					goto IL_235;
				}
			}
			else
			{
				if (num == 10)
				{
					Class98 class4 = new Class98();
					class4.method_3((int)((Class92)class80_2).method_2());
					class4.method_1(class80_2.method_0());
					gparam_ = class4;
					goto IL_235;
				}
				switch (num)
				{
				case 13:
				{
					Class98 class5 = new Class98();
					class5.method_3((int)((Class81)class80_2).method_2());
					class5.method_1(class80_2.method_0());
					gparam_ = class5;
					goto IL_235;
				}
				case 14:
				case 16:
				case 17:
				case 19:
					break;
				case 15:
				{
					Class86 class6 = new Class86();
					class6.method_3((double)((Class91)class80_2).method_2());
					class6.method_1(class80_2.method_0());
					gparam_ = class6;
					goto IL_235;
				}
				case 18:
				{
					Class98 class7 = new Class98();
					class7.method_3((int)((Class94)class80_2).method_2());
					class7.method_1(class80_2.method_0());
					gparam_ = class7;
					goto IL_235;
				}
				case 20:
				{
					Class82 class8 = new Class82();
					class8.method_3((long)((Class89)class80_2).method_2());
					class8.method_1(class80_2.method_0());
					gparam_ = class8;
					goto IL_235;
				}
				case 21:
				{
					object obj = class80_2.vmethod_0();
					if (obj == null)
					{
						gparam_ = class80_2;
						goto IL_235;
					}
					Type type = obj.GetType();
					if (type.HasElementType && !type.IsArray)
					{
						type = type.GetElementType();
					}
					if (type != null && !type.IsValueType && !type.IsEnum)
					{
						gparam_ = class80_2;
						goto IL_235;
					}
					gparam_ = Class29.smethod_1(obj, type);
					goto IL_235;
				}
				default:
					if (num == 24)
					{
						Class98 class9 = new Class98();
						class9.method_3((int)((Class87)class80_2).method_2());
						class9.method_1(class80_2.method_0());
						gparam_ = class9;
						goto IL_235;
					}
					break;
				}
			}
			gparam_ = class80_2;
		}
		IL_235:
		this.class15_0.method_7(gparam_);
	}

	// Token: 0x06000382 RID: 898 RVA: 0x0001FDEC File Offset: 0x0001DFEC
	private long method_294()
	{
		Class80 @class = this.method_112();
		int num = @class.vmethod_2();
		if (num <= 8)
		{
			if (num == 6)
			{
				return (long)((Class83)@class).method_2().ToUInt64();
			}
			if (num == 8)
			{
				return Convert.ToInt64(((Class84)@class).method_2());
			}
		}
		else
		{
			if (num == 14)
			{
				return (long)((Class98)@class).method_2();
			}
			if (num == 23)
			{
				return ((Class99)@class).method_2().ToInt64();
			}
		}
		throw new Exception("Unexpected value on the stack.");
	}

	// Token: 0x06000383 RID: 899 RVA: 0x0001FE78 File Offset: 0x0001E078
	private void method_295(Class80 class80_2)
	{
		Class80 class80_3 = this.method_112();
		this.method_293(this.method_176(class80_3));
	}

	// Token: 0x06000384 RID: 900 RVA: 0x00004652 File Offset: 0x00002852
	private void method_296(Class80 class80_2)
	{
		throw new NotSupportedException("Mkrefany is not supported.");
	}

	// Token: 0x06000385 RID: 901 RVA: 0x0001FE9C File Offset: 0x0001E09C
	private void method_297(bool bool_2)
	{
		Class80 @class = this.method_112();
		int num = @class.vmethod_2();
		byte int_;
		if (num <= 14)
		{
			if (num != 8)
			{
				if (num == 14)
				{
					if (bool_2)
					{
						int_ = checked((byte)((uint)((Class98)@class).method_2()));
						goto IL_BF;
					}
					int_ = (byte)((Class98)@class).method_2();
					goto IL_BF;
				}
			}
			else
			{
				if (bool_2)
				{
					int_ = checked((byte)Convert.ToUInt64(((Class84)@class).method_2()));
					goto IL_BF;
				}
				int_ = (byte)Convert.ToUInt64(((Class84)@class).method_2());
				goto IL_BF;
			}
		}
		else if (num != 16)
		{
			if (num == 19)
			{
				if (bool_2)
				{
					int_ = checked((byte)((Class86)@class).method_2());
					goto IL_BF;
				}
				int_ = (byte)((Class86)@class).method_2();
				goto IL_BF;
			}
		}
		else
		{
			if (bool_2)
			{
				int_ = checked((byte)((ulong)((Class82)@class).method_2()));
				goto IL_BF;
			}
			int_ = (byte)((Class82)@class).method_2();
			goto IL_BF;
		}
		throw new InvalidOperationException();
		IL_BF:
		Class98 class2 = new Class98();
		class2.method_3((int)int_);
		this.method_293(class2);
	}

	// Token: 0x06000386 RID: 902 RVA: 0x0001FF7C File Offset: 0x0001E17C
	private void method_298(Class80 class80_2)
	{
		Class88 @class = (Class88)class80_2;
		Class102 class2 = new Class102();
		class2.method_3(this.class80_0[(int)@class.method_2()]);
		this.method_293(class2);
	}

	// Token: 0x06000387 RID: 903 RVA: 0x0001FFB4 File Offset: 0x0001E1B4
	private void method_299(Class80 class80_2)
	{
		Class80 class80_3 = this.method_112();
		Class80 class80_4 = this.method_112();
		this.method_293(this.method_168(class80_4, class80_3));
	}

	// Token: 0x06000388 RID: 904 RVA: 0x0001FFE0 File Offset: 0x0001E1E0
	private void method_300(Class80 class80_2)
	{
		Class80 class80_3 = this.method_112();
		Class80 class80_4 = this.method_112();
		this.method_293(this.method_128(class80_4, class80_3, false, false));
	}

	// Token: 0x0400019B RID: 411
	private static Type type_0;

	// Token: 0x0400019C RID: 412
	private bool bool_0;

	// Token: 0x0400019D RID: 413
	private Type type_1;

	// Token: 0x0400019E RID: 414
	private readonly Module module_0;

	// Token: 0x0400019F RID: 415
	private Stream stream_0;

	// Token: 0x040001A0 RID: 416
	private Type[] type_2;

	// Token: 0x040001A1 RID: 417
	private Class80[] class80_0;

	// Token: 0x040001A2 RID: 418
	private bool bool_1;

	// Token: 0x040001A3 RID: 419
	private readonly Dictionary<MethodBase, int> dictionary_0;

	// Token: 0x040001A4 RID: 420
	private Class42 class42_0;

	// Token: 0x040001A5 RID: 421
	private static readonly Dictionary<int, object> dictionary_1 = new Dictionary<int, object>();

	// Token: 0x040001A6 RID: 422
	private static Type type_3;

	// Token: 0x040001A7 RID: 423
	private static object object_0 = new object();

	// Token: 0x040001A8 RID: 424
	private static Type type_4 = typeof(void);

	// Token: 0x040001A9 RID: 425
	private Dictionary<int, Class65.Class67> dictionary_2;

	// Token: 0x040001AA RID: 426
	private long long_0;

	// Token: 0x040001AB RID: 427
	private static Type type_5 = typeof(object[]);

	// Token: 0x040001AC RID: 428
	private Class123 class123_0;

	// Token: 0x040001AD RID: 429
	private static Type type_6;

	// Token: 0x040001AE RID: 430
	private uint? nullable_0;

	// Token: 0x040001AF RID: 431
	private object object_1;

	// Token: 0x040001B0 RID: 432
	private Class80[] class80_1;

	// Token: 0x040001B1 RID: 433
	private byte[] byte_0;

	// Token: 0x040001B2 RID: 434
	private Class123 class123_1;

	// Token: 0x040001B3 RID: 435
	private Dictionary<MethodBase, object> dictionary_3;

	// Token: 0x040001B4 RID: 436
	private readonly Class15<Class80> class15_0;

	// Token: 0x040001B5 RID: 437
	private readonly Dictionary<Class65.Struct50, Class65.Delegate20> dictionary_4 = new Dictionary<Class65.Struct50, Class65.Delegate20>(256);

	// Token: 0x040001B6 RID: 438
	private Class134[] class134_0;

	// Token: 0x040001B7 RID: 439
	private Type[] type_7;

	// Token: 0x040001B8 RID: 440
	private object[] object_2;

	// Token: 0x040001B9 RID: 441
	private readonly Class119 class119_0;

	// Token: 0x040001BA RID: 442
	private static Type type_8;

	// Token: 0x040001BB RID: 443
	private readonly Class15<Class65.Struct49> class15_1;

	// Token: 0x02000082 RID: 130
	[Serializable]
	private sealed class Class66
	{
		// Token: 0x0600038B RID: 907 RVA: 0x0002000C File Offset: 0x0001E20C
		internal int method_0(Class134 class134_0, Class134 class134_1)
		{
			if (class134_0.method_10() == class134_1.method_10())
			{
				return class134_1.method_6().CompareTo(class134_0.method_6());
			}
			return class134_0.method_10().CompareTo(class134_1.method_10());
		}

		// Token: 0x040001BC RID: 444
		public static readonly Class65.Class66 class66_0 = new Class65.Class66();

		// Token: 0x040001BD RID: 445
		public static Comparison<Class134> comparison_0;
	}

	// Token: 0x02000083 RID: 131
	private sealed class Class67
	{
		// Token: 0x0600038C RID: 908 RVA: 0x0000466A File Offset: 0x0000286A
		public Class67(Class159 class159_1, Class65.Delegate21 delegate21_1)
		{
			this.class159_0 = class159_1;
			this.delegate21_0 = delegate21_1;
		}

		// Token: 0x040001BE RID: 446
		public Class159 class159_0;

		// Token: 0x040001BF RID: 447
		public Class65.Delegate21 delegate21_0;
	}

	// Token: 0x02000084 RID: 132
	private struct Struct48
	{
		// Token: 0x040001C0 RID: 448
		public bool bool_0;
	}

	// Token: 0x02000085 RID: 133
	private static class Class68
	{
		// Token: 0x0600038E RID: 910 RVA: 0x00020050 File Offset: 0x0001E250
		public static object smethod_0(object object_0, MethodBase methodBase_0, out MethodInfo methodInfo_0)
		{
			KeyValuePair<Type, MethodInfo> keyValuePair = Class65.Class68.smethod_1(methodBase_0);
			object result = (Delegate)Activator.CreateInstance(keyValuePair.Key, new object[]
			{
				object_0,
				methodBase_0.MethodHandle.GetFunctionPointer()
			});
			methodInfo_0 = keyValuePair.Value;
			return result;
		}

		// Token: 0x0600038F RID: 911 RVA: 0x000200A0 File Offset: 0x0001E2A0
		private static KeyValuePair<Type, MethodInfo> smethod_1(MethodBase methodBase_0)
		{
			Dictionary<MethodBase, KeyValuePair<Type, MethodInfo>> obj = Class65.Class68.dictionary_0;
			KeyValuePair<Type, MethodInfo> result;
			lock (obj)
			{
				KeyValuePair<Type, MethodInfo> keyValuePair;
				if (Class65.Class68.dictionary_0.TryGetValue(methodBase_0, out keyValuePair))
				{
					result = keyValuePair;
				}
				else
				{
					MethodInfo methodInfo = methodBase_0 as MethodInfo;
					Type type;
					if (methodInfo != null)
					{
						if ((type = methodInfo.ReturnType) != null)
						{
							goto IL_41;
						}
					}
					type = Class65.type_4;
					IL_41:
					Type type2 = type;
					bool flag = type2 != Class65.type_4;
					ParameterInfo[] parameters = methodBase_0.GetParameters();
					if (parameters.Length > 9)
					{
						throw new Exception(string.Format("Cannot create delegate for a method. Unsupported number of parameters: {0}.", parameters.Length));
					}
					Type[] array = new Type[parameters.Length + (flag ? 1 : 0)];
					for (int i = 0; i < parameters.Length; i++)
					{
						Type parameterType = parameters[i].ParameterType;
						if (parameterType.IsByRef || parameterType.IsPointer)
						{
							throw new Exception("Cannot create delegate for a method with parameters passed by reference.");
						}
						array[i] = parameterType;
					}
					if (flag)
					{
						array[array.Length - 1] = type2;
					}
					Type type3 = flag ? Class65.Class68.smethod_2(array) : Class65.Class68.smethod_3(array);
					MethodInfo method = type3.GetMethod("Invoke");
					keyValuePair = new KeyValuePair<Type, MethodInfo>(type3, method);
					Class65.Class68.dictionary_0.Add(methodBase_0, keyValuePair);
					result = keyValuePair;
				}
			}
			return result;
		}

		// Token: 0x06000390 RID: 912 RVA: 0x000201F0 File Offset: 0x0001E3F0
		private static Type smethod_2(Type[] type_0)
		{
			switch (type_0.Length)
			{
			case 1:
				return typeof(Class65.Class68.Delegate13<>).MakeGenericType(type_0);
			case 2:
				return typeof(Class65.Class68.Delegate16<, >).MakeGenericType(type_0);
			case 3:
				return typeof(Class65.Class68.Delegate19<, , >).MakeGenericType(type_0);
			case 4:
				return typeof(Class65.Class68.Delegate2<, , , >).MakeGenericType(type_0);
			case 5:
				return typeof(Class65.Class68.Delegate5<, , , , >).MakeGenericType(type_0);
			case 6:
				return typeof(Class65.Class68.Delegate8<, , , , , >).MakeGenericType(type_0);
			case 7:
				return typeof(Class65.Class68.Delegate14<, , , , , , >).MakeGenericType(type_0);
			case 8:
				return typeof(Class65.Class68.Delegate11<, , , , , , , >).MakeGenericType(type_0);
			case 9:
				return typeof(Class65.Class68.Delegate17<, , , , , , , , >).MakeGenericType(type_0);
			case 10:
				return typeof(Class65.Class68.Delegate10<, , , , , , , , , >).MakeGenericType(type_0);
			default:
				return null;
			}
		}

		// Token: 0x06000391 RID: 913 RVA: 0x000202DC File Offset: 0x0001E4DC
		private static Type smethod_3(Type[] type_0)
		{
			switch (type_0.Length)
			{
			case 0:
				return typeof(Class65.Class68.Delegate0);
			case 1:
				return typeof(Class65.Class68.Delegate3<>).MakeGenericType(type_0);
			case 2:
				return typeof(Class65.Class68.Delegate6<, >).MakeGenericType(type_0);
			case 3:
				return typeof(Class65.Class68.Delegate12<, , >).MakeGenericType(type_0);
			case 4:
				return typeof(Class65.Class68.Delegate9<, , , >).MakeGenericType(type_0);
			case 5:
				return typeof(Class65.Class68.Delegate15<, , , , >).MakeGenericType(type_0);
			case 6:
				return typeof(Class65.Class68.Delegate18<, , , , , >).MakeGenericType(type_0);
			case 7:
				return typeof(Class65.Class68.Delegate1<, , , , , , >).MakeGenericType(type_0);
			case 8:
				return typeof(Class65.Class68.Delegate4<, , , , , , , >).MakeGenericType(type_0);
			case 9:
				return typeof(Class65.Class68.Delegate7<, , , , , , , , >).MakeGenericType(type_0);
			default:
				return null;
			}
		}

		// Token: 0x040001C1 RID: 449
		private static readonly Dictionary<MethodBase, KeyValuePair<Type, MethodInfo>> dictionary_0 = new Dictionary<MethodBase, KeyValuePair<Type, MethodInfo>>();

		// Token: 0x02000086 RID: 134
		// (Invoke) Token: 0x06000393 RID: 915
		private delegate void Delegate0();

		// Token: 0x02000087 RID: 135
		// (Invoke) Token: 0x06000397 RID: 919
		private delegate void Delegate1<in T, in U, in V, in W, in X, in Y, in Z>(T gparam_0, U gparam_1, V gparam_2, W gparam_3, X gparam_4, Y gparam_5, Z gparam_6);

		// Token: 0x02000088 RID: 136
		// (Invoke) Token: 0x0600039B RID: 923
		private delegate W Delegate2<in T, in U, in V, out W>(T gparam_0, U gparam_1, V gparam_2);

		// Token: 0x02000089 RID: 137
		// (Invoke) Token: 0x0600039F RID: 927
		private delegate void Delegate3<in T>(T gparam_0);

		// Token: 0x0200008A RID: 138
		// (Invoke) Token: 0x060003A3 RID: 931
		private delegate void Delegate4<in T, in U, in V, in W, in X, in Y, in Z, in T7>(T gparam_0, U gparam_1, V gparam_2, W gparam_3, X gparam_4, Y gparam_5, Z gparam_6, T7 gparam_7);

		// Token: 0x0200008B RID: 139
		// (Invoke) Token: 0x060003A7 RID: 935
		private delegate X Delegate5<in T, in U, in V, in W, out X>(T gparam_0, U gparam_1, V gparam_2, W gparam_3);

		// Token: 0x0200008C RID: 140
		// (Invoke) Token: 0x060003AB RID: 939
		private delegate void Delegate6<in T, in U>(T gparam_0, U gparam_1);

		// Token: 0x0200008D RID: 141
		// (Invoke) Token: 0x060003AF RID: 943
		private delegate void Delegate7<in T, in U, in V, in W, in X, in Y, in Z, in T7, in T8>(T gparam_0, U gparam_1, V gparam_2, W gparam_3, X gparam_4, Y gparam_5, Z gparam_6, T7 gparam_7, T8 gparam_8);

		// Token: 0x0200008E RID: 142
		// (Invoke) Token: 0x060003B3 RID: 947
		private delegate Y Delegate8<in T, in U, in V, in W, in X, out Y>(T gparam_0, U gparam_1, V gparam_2, W gparam_3, X gparam_4);

		// Token: 0x0200008F RID: 143
		// (Invoke) Token: 0x060003B7 RID: 951
		private delegate void Delegate9<in T, in U, in V, in W>(T gparam_0, U gparam_1, V gparam_2, W gparam_3);

		// Token: 0x02000090 RID: 144
		// (Invoke) Token: 0x060003BB RID: 955
		private delegate T9 Delegate10<in T, in U, in V, in W, in X, in Y, in Z, in T7, in T8, out T9>(T gparam_0, U gparam_1, V gparam_2, W gparam_3, X gparam_4, Y gparam_5, Z gparam_6, T7 gparam_7, T8 gparam_8);

		// Token: 0x02000091 RID: 145
		// (Invoke) Token: 0x060003BF RID: 959
		private delegate T7 Delegate11<in T, in U, in V, in W, in X, in Y, in Z, out T7>(T gparam_0, U gparam_1, V gparam_2, W gparam_3, X gparam_4, Y gparam_5, Z gparam_6);

		// Token: 0x02000092 RID: 146
		// (Invoke) Token: 0x060003C3 RID: 963
		private delegate void Delegate12<in T, in U, in V>(T gparam_0, U gparam_1, V gparam_2);

		// Token: 0x02000093 RID: 147
		// (Invoke) Token: 0x060003C7 RID: 967
		private delegate T Delegate13<out T>();

		// Token: 0x02000094 RID: 148
		// (Invoke) Token: 0x060003CB RID: 971
		private delegate Z Delegate14<in T, in U, in V, in W, in X, in Y, out Z>(T gparam_0, U gparam_1, V gparam_2, W gparam_3, X gparam_4, Y gparam_5);

		// Token: 0x02000095 RID: 149
		// (Invoke) Token: 0x060003CF RID: 975
		private delegate void Delegate15<in T, in U, in V, in W, in X>(T gparam_0, U gparam_1, V gparam_2, W gparam_3, X gparam_4);

		// Token: 0x02000096 RID: 150
		// (Invoke) Token: 0x060003D3 RID: 979
		private delegate U Delegate16<in T, out U>(T gparam_0);

		// Token: 0x02000097 RID: 151
		// (Invoke) Token: 0x060003D7 RID: 983
		private delegate T8 Delegate17<in T, in U, in V, in W, in X, in Y, in Z, in T7, out T8>(T gparam_0, U gparam_1, V gparam_2, W gparam_3, X gparam_4, Y gparam_5, Z gparam_6, T7 gparam_7);

		// Token: 0x02000098 RID: 152
		// (Invoke) Token: 0x060003DB RID: 987
		private delegate void Delegate18<in T, in U, in V, in W, in X, in Y>(T gparam_0, U gparam_1, V gparam_2, W gparam_3, X gparam_4, Y gparam_5);

		// Token: 0x02000099 RID: 153
		// (Invoke) Token: 0x060003DF RID: 991
		private delegate V Delegate19<in T, in U, out V>(T gparam_0, U gparam_1);
	}

	// Token: 0x0200009A RID: 154
	private static class Class69
	{
		// Token: 0x060003E2 RID: 994 RVA: 0x000203C0 File Offset: 0x0001E5C0
		static Class69()
		{
			try
			{
				Class65.Class69.bool_0 = Class65.Class69.smethod_0();
			}
			catch
			{
				Class65.Class69.bool_0 = false;
			}
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x0000468C File Offset: 0x0000288C
		private static bool smethod_0()
		{
			return !typeof(DynamicMethod).IsAbstract;
		}

		// Token: 0x040001C2 RID: 450
		public static readonly bool bool_0;
	}

	// Token: 0x0200009B RID: 155
	private static class Class70
	{
		// Token: 0x060003E5 RID: 997 RVA: 0x000203F4 File Offset: 0x0001E5F4
		public static MethodBase smethod_0(Class65 class65_0, Class42 class42_0, MethodBase methodBase_0, bool bool_0)
		{
			Dictionary<MethodBase, MethodInfo> obj = Class65.Class70.dictionary_0;
			MethodBase result;
			lock (obj)
			{
				MethodInfo methodInfo;
				if (Class65.Class70.dictionary_0.TryGetValue(methodBase_0, out methodInfo))
				{
					result = methodInfo;
				}
				else
				{
					MethodInfo methodInfo2;
					Type returnType;
					if ((methodInfo2 = (methodBase_0 as MethodInfo)) != null)
					{
						returnType = methodInfo2.ReturnType;
					}
					else
					{
						returnType = Class65.type_4;
					}
					ParameterInfo[] parameters = methodBase_0.GetParameters();
					Type[] array;
					if (methodBase_0.IsStatic)
					{
						array = new Type[parameters.Length];
						for (int i = 0; i < parameters.Length; i++)
						{
							array[i] = parameters[i].ParameterType;
						}
					}
					else
					{
						array = new Type[parameters.Length + 1];
						Type type = methodBase_0.DeclaringType;
						if (type.IsValueType)
						{
							type = type.MakeByRefType();
							bool_0 = false;
						}
						array[0] = type;
						for (int j = 0; j < parameters.Length; j++)
						{
							array[j + 1] = parameters[j].ParameterType;
						}
					}
					string empty = string.Empty;
					if (methodInfo == null)
					{
						methodInfo = new DynamicMethod(empty, returnType, array, class65_0.method_16(class42_0.method_6(), true), true);
					}
					ILGenerator ilgenerator = ((DynamicMethod)methodInfo).GetILGenerator();
					for (int k = 0; k < array.Length; k++)
					{
						ilgenerator.Emit(OpCodes.Ldarg, k);
					}
					ConstructorInfo con;
					if ((con = (methodBase_0 as ConstructorInfo)) != null)
					{
						ilgenerator.Emit(bool_0 ? OpCodes.Callvirt : OpCodes.Call, con);
					}
					else
					{
						ilgenerator.Emit(bool_0 ? OpCodes.Callvirt : OpCodes.Call, (MethodInfo)methodBase_0);
					}
					ilgenerator.Emit(OpCodes.Ret);
					Class65.Class70.dictionary_0.Add(methodBase_0, methodInfo);
					result = methodInfo;
				}
			}
			return result;
		}

		// Token: 0x040001C3 RID: 451
		private static readonly Dictionary<MethodBase, MethodInfo> dictionary_0 = new Dictionary<MethodBase, MethodInfo>();
	}

	// Token: 0x0200009C RID: 156
	// (Invoke) Token: 0x060003E7 RID: 999
	private delegate object Delegate20(object object_0, object[] object_1);

	// Token: 0x0200009D RID: 157
	private sealed class Class71<T> : IComparer<KeyValuePair<int, T>>
	{
		// Token: 0x060003EA RID: 1002 RVA: 0x000046AC File Offset: 0x000028AC
		public Class71(Comparison<T> comparison_1)
		{
			this.comparison_0 = comparison_1;
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x000205B0 File Offset: 0x0001E7B0
		public int Compare(KeyValuePair<int, T> x, KeyValuePair<int, T> y)
		{
			int num = this.comparison_0(x.Value, y.Value);
			if (num == 0)
			{
				return y.Key.CompareTo(x.Key);
			}
			return num;
		}

		// Token: 0x040001C4 RID: 452
		private readonly Comparison<T> comparison_0;
	}

	// Token: 0x0200009E RID: 158
	private struct Struct49
	{
		// Token: 0x060003EC RID: 1004 RVA: 0x000046BB File Offset: 0x000028BB
		public Struct49(uint uint_1)
		{
			this.uint_0 = uint_1;
			this.object_0 = null;
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x000046CB File Offset: 0x000028CB
		public Struct49(uint uint_1, object object_1)
		{
			this.uint_0 = uint_1;
			this.object_0 = object_1;
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x000046DB File Offset: 0x000028DB
		public uint method_0()
		{
			return this.uint_0;
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x000046E3 File Offset: 0x000028E3
		public object method_1()
		{
			return this.object_0;
		}

		// Token: 0x040001C5 RID: 453
		private readonly uint uint_0;

		// Token: 0x040001C6 RID: 454
		private readonly object object_0;
	}

	// Token: 0x0200009F RID: 159
	private struct Struct50 : IEquatable<Class65.Struct50>
	{
		// Token: 0x060003F0 RID: 1008 RVA: 0x000046EB File Offset: 0x000028EB
		public Struct50(MethodBase methodBase_1, bool bool_1)
		{
			this.methodBase_0 = methodBase_1;
			this.bool_0 = bool_1;
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x000046FB File Offset: 0x000028FB
		public MethodBase method_0()
		{
			return this.methodBase_0;
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x00004703 File Offset: 0x00002903
		public bool method_1()
		{
			return this.bool_0;
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x000205F4 File Offset: 0x0001E7F4
		public override int GetHashCode()
		{
			return this.method_0().GetHashCode() ^ this.method_1().GetHashCode();
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x0002061C File Offset: 0x0001E81C
		public override bool Equals(object obj)
		{
			if (obj is Class65.Struct50)
			{
				Class65.Struct50 other = (Class65.Struct50)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x0000470B File Offset: 0x0000290B
		public bool Equals(Class65.Struct50 other)
		{
			return this.method_0() == other.method_0() && this.method_1() == other.method_1();
		}

		// Token: 0x040001C7 RID: 455
		private readonly MethodBase methodBase_0;

		// Token: 0x040001C8 RID: 456
		private readonly bool bool_0;
	}

	// Token: 0x020000A0 RID: 160
	private sealed class Class72
	{
		// Token: 0x060003F7 RID: 1015 RVA: 0x0000472D File Offset: 0x0000292D
		public string method_0()
		{
			return this.string_0;
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x00004735 File Offset: 0x00002935
		public void method_1(string string_1)
		{
			this.string_0 = string_1;
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x0000473E File Offset: 0x0000293E
		public Type method_2()
		{
			return this.type_0;
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x00004746 File Offset: 0x00002946
		public void method_3(Type type_1)
		{
			this.type_0 = type_1;
		}

		// Token: 0x040001C9 RID: 457
		private string string_0;

		// Token: 0x040001CA RID: 458
		private Type type_0;
	}

	// Token: 0x020000A1 RID: 161
	// (Invoke) Token: 0x060003FC RID: 1020
	private delegate void Delegate21(Class80 class80_0);
}
