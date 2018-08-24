using System;
using System.Reflection;
using System.Security;

// Token: 0x0200015D RID: 349
internal static class Class167
{
	// Token: 0x060007AC RID: 1964 RVA: 0x0004579C File Offset: 0x0004399C
	private static bool smethod_0()
	{
		bool result;
		try
		{
			if (Environment.Version.Major < 4)
			{
				result = false;
			}
			else
			{
				Assembly assembly = typeof(Class65).Assembly;
				Assembly assembly2 = typeof(SecurityCriticalAttribute).Assembly;
				bool flag = false;
				foreach (object obj in assembly.GetCustomAttributes(false))
				{
					if (obj is AllowPartiallyTrustedCallersAttribute)
					{
						flag = true;
					}
					else
					{
						Type type = obj.GetType();
						if (type.Assembly == assembly2 && "System.Security.SecurityRulesAttribute".Equals(type.FullName, StringComparison.Ordinal) && (byte)type.GetProperty("RuleSet").GetValue(obj, null) != 2)
						{
							return false;
						}
					}
				}
				result = flag;
			}
		}
		catch
		{
			result = false;
		}
		return result;
	}

	// Token: 0x060007AD RID: 1965 RVA: 0x00006561 File Offset: 0x00004761
	public static bool smethod_1()
	{
		return Class167.bool_0;
	}

	// Token: 0x04000692 RID: 1682
	private static readonly bool bool_0 = Class167.smethod_0();
}
