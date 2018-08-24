using System;

// Token: 0x0200007F RID: 127
internal static class Class63
{
	// Token: 0x06000238 RID: 568 RVA: 0x000151E0 File Offset: 0x000133E0
	public static bool smethod_0(Type type_0, Type type_1)
	{
		if (type_0 == type_1)
		{
			return true;
		}
		if (type_0 == null || type_1 == null)
		{
			return false;
		}
		if (type_0.IsByRef)
		{
			return type_1.IsByRef && Class63.smethod_0(type_0.GetElementType(), type_1.GetElementType());
		}
		if (type_1.IsByRef)
		{
			return false;
		}
		if (type_0.IsPointer)
		{
			return type_1.IsPointer && Class63.smethod_0(type_0.GetElementType(), type_1.GetElementType());
		}
		if (type_1.IsPointer)
		{
			return false;
		}
		if (type_0.IsArray)
		{
			return type_1.IsArray && type_0.GetArrayRank() == type_1.GetArrayRank() && Class63.smethod_0(type_0.GetElementType(), type_1.GetElementType());
		}
		if (type_1.IsArray)
		{
			return false;
		}
		if (type_0.IsGenericType && !type_0.IsGenericTypeDefinition)
		{
			type_0 = type_0.GetGenericTypeDefinition();
		}
		if (type_1.IsGenericType && !type_1.IsGenericTypeDefinition)
		{
			type_1 = type_1.GetGenericTypeDefinition();
		}
		return type_0 == type_1;
	}
}
