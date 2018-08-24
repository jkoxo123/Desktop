using System;
using System.Linq;

// Token: 0x0200005A RID: 90
internal static class Class43
{
	// Token: 0x060001C1 RID: 449 RVA: 0x00010A68 File Offset: 0x0000EC68
	public static string smethod_0(string string_0, bool bool_0)
	{
		string text = Class130.jobject_0[string_0]["code"].ToString();
		if (text == "US" && bool_0)
		{
			text = "USA";
		}
		return text;
	}

	// Token: 0x060001C2 RID: 450 RVA: 0x00010AA8 File Offset: 0x0000ECA8
	public static string smethod_1(string string_0, string string_1)
	{
		if (string_1 == null)
		{
			return "None";
		}
		if (Class130.jobject_0[string_0]["province_codes"][string_1] == null)
		{
			return "None";
		}
		return (Class130.jobject_0[string_0]["province_codes"][string_1] ?? "None").ToString();
	}

	// Token: 0x060001C3 RID: 451 RVA: 0x00010B10 File Offset: 0x0000ED10
	public static bool smethod_2(string string_0, string string_1)
	{
		bool flag = true;
		uint num = Class79.smethod_0(string_0);
		if (num <= 808610076u)
		{
			if (num != 133753942u)
			{
				if (num != 163471254u)
				{
					if (num == 808610076u)
					{
						if (string_0 == "XXLarge")
						{
							string_0 = "2X-Large,2-xl,2-xlarge,2xl,xxl,xxlarge,extraextralarge,extra extra large,extra-extra-large,exexl,exexlarge,x-x-large,x-x-l";
							goto IL_108;
						}
					}
				}
				else if (string_0 == "Medium")
				{
					string_0 = "m,medium";
					goto IL_108;
				}
			}
			else if (string_0 == "XSmall")
			{
				string_0 = "xs,xsmall,extrasmall,extra small,extra-small,exsmall,exs,x-small,x-s";
				goto IL_108;
			}
		}
		else if (num <= 1216374316u)
		{
			if (num != 1173544642u)
			{
				if (num == 1216374316u)
				{
					if (string_0 == "Small")
					{
						string_0 = "small,s";
						goto IL_108;
					}
				}
			}
			else if (string_0 == "XLarge")
			{
				string_0 = "xl,xlarge,extralarge,extra large,extra-large,exl,exlarge,x-large,x-l";
				goto IL_108;
			}
		}
		else if (num != 3314840116u)
		{
			if (num == 4052459348u)
			{
				if (string_0 == "Large")
				{
					string_0 = "l,large";
					goto IL_108;
				}
			}
		}
		else if (string_0 == "XXSmall")
		{
			string_0 = "2x-small,2-xs,2-xsmall,2xs,xxs,xxsmall,extraextrasmall,extra extra small,extra-extra-small,exexs,exexsmall,x-x-small,x-x-s";
			goto IL_108;
		}
		flag = false;
		IL_108:
		if (!flag)
		{
			return string_0.ToLower().Split(new char[]
			{
				','
			}).Any(new Func<string, bool>(string_1.ToLower().Contains));
		}
		return string_0.ToLower().Split(new char[]
		{
			','
		}).Any(new Func<string, bool>(string_1.ToLower().Equals));
	}

	// Token: 0x060001C4 RID: 452 RVA: 0x00010C84 File Offset: 0x0000EE84
	public static string smethod_3(string string_0)
	{
		uint num = Class79.smethod_0(string_0);
		if (num <= 3365677106u)
		{
			if (num <= 2077971157u)
			{
				if (num <= 485192564u)
				{
					if (num != 35021684u)
					{
						if (num != 356068251u)
						{
							if (num == 485192564u)
							{
								if (string_0 == "US 11.5")
								{
									return "46";
								}
							}
						}
						else if (string_0 == "US 5.5")
						{
							return "38";
						}
					}
					else if (string_0 == "US 4.5")
					{
						return "36 2/3";
					}
				}
				else if (num <= 1455067456u)
				{
					if (num != 806239131u)
					{
						if (num == 1455067456u)
						{
							if (string_0 == "US 8.5")
							{
								return "42";
							}
						}
					}
					else if (string_0 == "US 10.5")
					{
						return "44 2/3";
					}
				}
				else if (num != 1807801119u)
				{
					if (num == 2077971157u)
					{
						if (string_0 == "US 3.5")
						{
							return "35 1/3";
						}
					}
				}
				else if (string_0 == "US 14.5")
				{
					return "50";
				}
			}
			else if (num <= 3249639910u)
			{
				if (num != 2882006314u)
				{
					if (num != 3203052881u)
					{
						if (num == 3249639910u)
						{
							if (string_0 == "US 9")
							{
								return "42 2/3";
							}
						}
					}
					else if (string_0 == "US 7.5")
					{
						return "40 2/3";
					}
				}
				else if (string_0 == "US 6.5")
				{
					return "39 1/3";
				}
			}
			else if (num <= 3332177194u)
			{
				if (num != 3266417529u)
				{
					if (num == 3332177194u)
					{
						if (string_0 == "US 13.5")
						{
							return "48 2/3";
						}
					}
				}
				else if (string_0 == "US 8")
				{
					return "41 1/3";
				}
			}
			else if (num != 3350305624u)
			{
				if (num == 3365677106u)
				{
					if (string_0 == "US 18")
					{
						return "53 1/3";
					}
				}
			}
			else if (string_0 == "US 3")
			{
				return "34 2/3";
			}
		}
		else if (num <= 3449565201u)
		{
			if (num <= 3416009963u)
			{
				if (num != 3382454725u)
				{
					if (num != 3399232344u)
					{
						if (num == 3416009963u)
						{
							if (string_0 == "US 17")
							{
								return "52 2/3";
							}
						}
					}
					else if (string_0 == "US 16")
					{
						return "51 1/3";
					}
				}
				else if (string_0 == "US 19")
				{
					return "54 2/3";
				}
			}
			else if (num <= 3432787582u)
			{
				if (num != 3417416100u)
				{
					if (num == 3432787582u)
					{
						if (string_0 == "US 14")
						{
							return "49 1/3";
						}
					}
				}
				else if (string_0 == "US 7")
				{
					return "40";
				}
			}
			else if (num != 3434193719u)
			{
				if (num == 3449565201u)
				{
					if (string_0 == "US 15")
					{
						return "50 2/3";
					}
				}
			}
			else if (string_0 == "US 6")
			{
				return "38 2/3";
			}
		}
		else if (num <= 3483120439u)
		{
			if (num <= 3466342820u)
			{
				if (num != 3450971338u)
				{
					if (num == 3466342820u)
					{
						if (string_0 == "US 12")
						{
							return "46 2/3";
						}
					}
				}
				else if (string_0 == "US 5")
				{
					return "37 1/3";
				}
			}
			else if (num != 3467748957u)
			{
				if (num == 3483120439u)
				{
					if (string_0 == "US 13")
					{
						return "48";
					}
				}
			}
			else if (string_0 == "US 4")
			{
				return "36";
			}
		}
		else if (num <= 3516675677u)
		{
			if (num != 3499898058u)
			{
				if (num == 3516675677u)
				{
					if (string_0 == "US 11")
					{
						return "45 1/3";
					}
				}
			}
			else if (string_0 == "US 10")
			{
				return "44";
			}
		}
		else if (num != 3653223761u)
		{
			if (num == 4192091159u)
			{
				if (string_0 == "US 9.5")
				{
					return "43 1/3";
				}
			}
		}
		else if (string_0 == "US 12.5")
		{
			return "47 1/3";
		}
		return null;
	}

	// Token: 0x060001C5 RID: 453 RVA: 0x00011098 File Offset: 0x0000F298
	public static string smethod_4(string string_0)
	{
		uint num = Class79.smethod_0(string_0);
		if (num <= 808610076u)
		{
			if (num != 133753942u)
			{
				if (num != 163471254u)
				{
					if (num == 808610076u)
					{
						if (string_0 == "XXLarge")
						{
							return "XXL";
						}
					}
				}
				else if (string_0 == "Medium")
				{
					return "M";
				}
			}
			else if (string_0 == "XSmall")
			{
				return "XS";
			}
		}
		else if (num <= 1216374316u)
		{
			if (num != 1173544642u)
			{
				if (num == 1216374316u)
				{
					if (string_0 == "Small")
					{
						return "S";
					}
				}
			}
			else if (string_0 == "XLarge")
			{
				return "XL";
			}
		}
		else if (num != 3314840116u)
		{
			if (num == 4052459348u)
			{
				if (string_0 == "Large")
				{
					return "L";
				}
			}
		}
		else if (string_0 == "XXSmall")
		{
			return "XXS";
		}
		return string_0;
	}
}
