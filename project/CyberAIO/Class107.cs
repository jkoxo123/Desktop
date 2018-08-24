using System;
using System.Reflection;

// Token: 0x0200016F RID: 367
internal sealed class Class107 : Class80
{
	// Token: 0x060007ED RID: 2029 RVA: 0x000067B3 File Offset: 0x000049B3
	public Class107(object object_1)
	{
		if (object_1 != null && !(object_1 is ValueType))
		{
			throw new ArgumentException();
		}
		this.object_0 = object_1;
	}

	// Token: 0x060007EE RID: 2030 RVA: 0x000067D3 File Offset: 0x000049D3
	public object method_2()
	{
		return this.object_0;
	}

	// Token: 0x060007EF RID: 2031 RVA: 0x000067DB File Offset: 0x000049DB
	public void method_3(object object_1)
	{
		if (object_1 != null && !(object_1 is ValueType))
		{
			throw new ArgumentException();
		}
		this.object_0 = object_1;
	}

	// Token: 0x060007F0 RID: 2032 RVA: 0x000067F5 File Offset: 0x000049F5
	public override object vmethod_0()
	{
		return this.method_2();
	}

	// Token: 0x060007F1 RID: 2033 RVA: 0x000067FD File Offset: 0x000049FD
	public override void vmethod_1(object object_1)
	{
		this.method_3(object_1);
	}

	// Token: 0x060007F2 RID: 2034 RVA: 0x00006806 File Offset: 0x00004A06
	public override int vmethod_2()
	{
		return 12;
	}

	// Token: 0x060007F3 RID: 2035 RVA: 0x00046560 File Offset: 0x00044760
	public override Class80 vmethod_3(Class80 class80_0)
	{
		base.method_1(class80_0.method_0());
		int num = class80_0.vmethod_2();
		if (num != 12)
		{
			if (num != 21)
			{
				this.method_3(class80_0.vmethod_0());
			}
			else
			{
				this.method_3(((Class90)class80_0).method_2());
			}
		}
		else if (this.method_2() != null)
		{
			object obj = ((Class107)class80_0).method_2();
			Type type = this.method_2().GetType();
			if (obj != null && !type.IsPrimitive && !type.IsEnum && type.IsAssignableFrom(obj.GetType()))
			{
				foreach (FieldInfo fieldInfo in type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.GetField | BindingFlags.SetField))
				{
					fieldInfo.SetValue(this.method_2(), fieldInfo.GetValue(obj));
				}
			}
			else
			{
				this.method_3(obj);
			}
		}
		else
		{
			this.method_3(((Class107)class80_0).method_2());
		}
		return this;
	}

	// Token: 0x060007F4 RID: 2036 RVA: 0x0000680A File Offset: 0x00004A0A
	public override Class80 vmethod_4()
	{
		Class107 @class = new Class107(this.object_0);
		@class.method_1(base.method_0());
		return @class;
	}

	// Token: 0x040006AB RID: 1707
	private object object_0;
}
