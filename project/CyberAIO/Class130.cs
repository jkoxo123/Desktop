using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

// Token: 0x020000ED RID: 237
internal static class Class130
{
	// Token: 0x0600058D RID: 1421 RVA: 0x00030E6C File Offset: 0x0002F06C
	public static void smethod_0()
	{
		if (!File.Exists(Class130.string_1))
		{
			Class130.smethod_1();
		}
		JObject jobject;
		try
		{
			jobject = JObject.Parse(File.ReadAllText(Class130.string_1));
		}
		catch
		{
			jobject = new JObject();
		}
		Class130.int_0 = (int)jobject["settings"]["monitor_delay"];
		Class130.int_1 = (int)jobject["settings"]["retry_delay"];
		Class130.string_2 = (string)jobject["settings"]["webhook"];
		Class130.bool_0 = (jobject["settings"]["notifications"] != null && (bool)jobject["settings"]["notifications"]);
		Class130.string_3 = (string)jobject["license_key"];
		Class130.jarray_0 = ((!jobject["proxies"].smethod_22()) ? ((JArray)jobject["proxies"]) : new JArray());
		Class130.jobject_2 = ((!jobject["profiles"].smethod_22()) ? ((JObject)jobject["profiles"]) : new JObject());
		Class130.jobject_3 = ((!jobject["tasks"].smethod_22()) ? ((JObject)jobject["tasks"]) : new JObject());
		Class130.jobject_5 = ((!jobject["solvers"].smethod_22()) ? ((JObject)jobject["solvers"]) : new JObject());
	}

	// Token: 0x0600058E RID: 1422 RVA: 0x000054CD File Offset: 0x000036CD
	public static void smethod_1()
	{
		Class130.smethod_2();
		Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CyberAIO"));
		File.WriteAllText(Class130.string_1, Class130.jobject_4.ToString());
	}

	// Token: 0x0600058F RID: 1423 RVA: 0x0003101C File Offset: 0x0002F21C
	public static void smethod_2()
	{
		JObject jobject = new JObject();
		string propertyName = "settings";
		JObject jobject2 = new JObject();
		jobject2["monitor_delay"] = Class130.int_0;
		jobject2["retry_delay"] = Class130.int_1;
		jobject2["webhook"] = Class130.string_2;
		jobject2["notifications"] = Class130.bool_0;
		jobject[propertyName] = jobject2;
		jobject["tasks"] = Class130.jobject_3;
		jobject["proxies"] = Class130.jarray_0;
		jobject["profiles"] = Class130.jobject_2;
		jobject["license_key"] = Class130.string_3;
		jobject["solvers"] = Class130.jobject_5;
		Class130.jobject_4 = jobject;
	}

	// Token: 0x04000417 RID: 1047
	public static Dictionary<int, Class44> dictionary_0 = new Dictionary<int, Class44>();

	// Token: 0x04000418 RID: 1048
	public static string string_0 = null;

	// Token: 0x04000419 RID: 1049
	public static JObject jobject_0;

	// Token: 0x0400041A RID: 1050
	public static JObject jobject_1;

	// Token: 0x0400041B RID: 1051
	private static string string_1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CyberAIO\\CyberAIO.data");

	// Token: 0x0400041C RID: 1052
	public static int int_0 = 2500;

	// Token: 0x0400041D RID: 1053
	public static int int_1 = 2500;

	// Token: 0x0400041E RID: 1054
	public static string string_2;

	// Token: 0x0400041F RID: 1055
	public static string string_3;

	// Token: 0x04000420 RID: 1056
	public static JArray jarray_0;

	// Token: 0x04000421 RID: 1057
	public static JObject jobject_2;

	// Token: 0x04000422 RID: 1058
	public static JObject jobject_3;

	// Token: 0x04000423 RID: 1059
	public static JObject jobject_4;

	// Token: 0x04000424 RID: 1060
	public static bool bool_0;

	// Token: 0x04000425 RID: 1061
	public static JObject jobject_5;
}
