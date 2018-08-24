using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Threading;

// Token: 0x0200011E RID: 286
internal static class Class154
{
	// Token: 0x06000665 RID: 1637 RVA: 0x000384E8 File Offset: 0x000366E8
	// Note: this type is marked as 'beforefieldinit'.
	static Class154()
	{
		Class154.dictionary_1.Add("bunifu.core", "costura.bunifu.core.dll.compressed");
		Class154.dictionary_1.Add("bunifu.ui.winforms.bunifuradiobutton", "costura.bunifu.ui.winforms.bunifuradiobutton.dll.compressed");
		Class154.dictionary_1.Add("bunifu_ui_v1.5.3", "costura.bunifu_ui_v1.5.3.dll.compressed");
		Class154.dictionary_1.Add("cloudflareutilities", "costura.cloudflareutilities.dll.compressed");
		Class154.dictionary_1.Add("costura", "costura.costura.dll.compressed");
		Class154.dictionary_1.Add("eo.base", "costura.eo.base.dll.compressed");
		Class154.dictionary_1.Add("eo.webbrowser", "costura.eo.webbrowser.dll.compressed");
		Class154.dictionary_1.Add("eo.webengine", "costura.eo.webengine.dll.compressed");
		Class154.dictionary_1.Add("htmlagilitypack", "costura.htmlagilitypack.dll.compressed");
		Class154.dictionary_2.Add("htmlagilitypack", "costura.htmlagilitypack.pdb.compressed");
		Class154.dictionary_1.Add("jint", "costura.jint.dll.compressed");
		Class154.dictionary_1.Add("newtonsoft.json", "costura.newtonsoft.json.dll.compressed");
		Class154.dictionary_1.Add("system.io.compression", "costura.system.io.compression.dll.compressed");
		Class154.dictionary_1.Add("websocket-sharp", "costura.websocket-sharp.dll.compressed");
	}

	// Token: 0x06000666 RID: 1638 RVA: 0x00005AD1 File Offset: 0x00003CD1
	private static string smethod_0(CultureInfo cultureInfo_0)
	{
		if (cultureInfo_0 == null)
		{
			return string.Empty;
		}
		return cultureInfo_0.Name;
	}

	// Token: 0x06000667 RID: 1639 RVA: 0x00038638 File Offset: 0x00036838
	private static Assembly smethod_1(AssemblyName assemblyName_0)
	{
		foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
		{
			AssemblyName name = assembly.GetName();
			if (string.Equals(name.Name, assemblyName_0.Name, StringComparison.InvariantCultureIgnoreCase) && string.Equals(Class154.smethod_0(name.CultureInfo), Class154.smethod_0(assemblyName_0.CultureInfo), StringComparison.InvariantCultureIgnoreCase))
			{
				return assembly;
			}
		}
		return null;
	}

	// Token: 0x06000668 RID: 1640 RVA: 0x000386A0 File Offset: 0x000368A0
	private static void smethod_2(Stream stream_0, Stream stream_1)
	{
		byte[] array = new byte[81920];
		int count;
		while ((count = stream_0.Read(array, 0, array.Length)) != 0)
		{
			stream_1.Write(array, 0, count);
		}
	}

	// Token: 0x06000669 RID: 1641 RVA: 0x000386D4 File Offset: 0x000368D4
	private static Stream smethod_3(string string_0)
	{
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		if (string_0.EndsWith(".compressed"))
		{
			Stream result;
			using (Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(string_0))
			{
				DeflateStream deflateStream = new DeflateStream(manifestResourceStream, CompressionMode.Decompress);
				try
				{
					MemoryStream memoryStream = new MemoryStream();
					Class154.smethod_2(deflateStream, memoryStream);
					memoryStream.Position = 0L;
					result = memoryStream;
				}
				finally
				{
					((IDisposable)deflateStream).Dispose();
				}
			}
			return result;
		}
		return executingAssembly.GetManifestResourceStream(string_0);
	}

	// Token: 0x0600066A RID: 1642 RVA: 0x0003875C File Offset: 0x0003695C
	private static Stream smethod_4(Dictionary<string, string> dictionary_3, string string_0)
	{
		string string_;
		if (dictionary_3.TryGetValue(string_0, out string_))
		{
			return Class154.smethod_3(string_);
		}
		return null;
	}

	// Token: 0x0600066B RID: 1643 RVA: 0x0003877C File Offset: 0x0003697C
	private static byte[] smethod_5(Stream stream_0)
	{
		byte[] array = new byte[stream_0.Length];
		stream_0.Read(array, 0, array.Length);
		return array;
	}

	// Token: 0x0600066C RID: 1644 RVA: 0x000387A4 File Offset: 0x000369A4
	private static Assembly smethod_6(Dictionary<string, string> dictionary_3, Dictionary<string, string> dictionary_4, AssemblyName assemblyName_0)
	{
		string text = assemblyName_0.Name.ToLowerInvariant();
		if (assemblyName_0.CultureInfo != null && !string.IsNullOrEmpty(assemblyName_0.CultureInfo.Name))
		{
			text = string.Format("{0}.{1}", assemblyName_0.CultureInfo.Name, text);
		}
		byte[] rawAssembly;
		using (Stream stream = Class154.smethod_4(dictionary_3, text))
		{
			if (stream == null)
			{
				return null;
			}
			rawAssembly = Class154.smethod_5(stream);
		}
		using (Stream stream2 = Class154.smethod_4(dictionary_4, text))
		{
			if (stream2 != null)
			{
				byte[] rawSymbolStore = Class154.smethod_5(stream2);
				return Assembly.Load(rawAssembly, rawSymbolStore);
			}
		}
		return Assembly.Load(rawAssembly);
	}

	// Token: 0x0600066D RID: 1645 RVA: 0x00038864 File Offset: 0x00036A64
	public static Assembly smethod_7(object object_1, ResolveEventArgs resolveEventArgs_0)
	{
		object obj = Class154.object_0;
		lock (obj)
		{
			if (Class154.dictionary_0.ContainsKey(resolveEventArgs_0.Name))
			{
				return null;
			}
		}
		AssemblyName assemblyName = new AssemblyName(resolveEventArgs_0.Name);
		Assembly assembly = Class154.smethod_1(assemblyName);
		if (assembly != null)
		{
			return assembly;
		}
		assembly = Class154.smethod_6(Class154.dictionary_1, Class154.dictionary_2, assemblyName);
		if (assembly == null)
		{
			obj = Class154.object_0;
			lock (obj)
			{
				Class154.dictionary_0[resolveEventArgs_0.Name] = true;
			}
			if ((assemblyName.Flags & AssemblyNameFlags.Retargetable) != AssemblyNameFlags.None)
			{
				assembly = Assembly.Load(assemblyName);
			}
		}
		return assembly;
	}

	// Token: 0x0600066E RID: 1646 RVA: 0x00005AE2 File Offset: 0x00003CE2
	public static void smethod_8()
	{
		if (Interlocked.Exchange(ref Class154.int_0, 1) == 1)
		{
			return;
		}
		AppDomain.CurrentDomain.AssemblyResolve += Class154.smethod_7;
	}

	// Token: 0x0400050D RID: 1293
	private static object object_0 = new object();

	// Token: 0x0400050E RID: 1294
	private static Dictionary<string, bool> dictionary_0 = new Dictionary<string, bool>();

	// Token: 0x0400050F RID: 1295
	private static Dictionary<string, string> dictionary_1 = new Dictionary<string, string>();

	// Token: 0x04000510 RID: 1296
	private static Dictionary<string, string> dictionary_2 = new Dictionary<string, string>();

	// Token: 0x04000511 RID: 1297
	private static int int_0;
}
