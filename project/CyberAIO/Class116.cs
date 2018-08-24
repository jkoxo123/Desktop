using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;

// Token: 0x020000BC RID: 188
internal static class Class116
{
	// Token: 0x0600049C RID: 1180 RVA: 0x00021B5C File Offset: 0x0001FD5C
	[STAThread]
	internal static void smethod_0()
	{
		if (Class116.mutex_0.WaitOne(TimeSpan.Zero, true))
		{
			Class116.smethod_7();
			new GClass3();
			Class5.smethod_2();
			Class130.smethod_0();
			Application.Run(new Startup(true));
			Class116.mutex_0.ReleaseMutex();
			return;
		}
		Class133.PostMessage((IntPtr)65535, Class133.int_0, IntPtr.Zero, IntPtr.Zero);
	}

	// Token: 0x0600049D RID: 1181 RVA: 0x00004DB5 File Offset: 0x00002FB5
	public static void smethod_1()
	{
		Process.GetCurrentProcess().Kill();
	}

	// Token: 0x0600049E RID: 1182 RVA: 0x00021BC8 File Offset: 0x0001FDC8
	public static bool smethod_2()
	{
		if (Class116.smethod_4())
		{
			return false;
		}
		new Process
		{
			StartInfo = 
			{
				FileName = Application.ExecutablePath,
				UseShellExecute = true,
				Verb = "runas"
			}
		}.Start();
		Process.GetCurrentProcess().Kill();
		return true;
	}

	// Token: 0x0600049F RID: 1183 RVA: 0x00004DC1 File Offset: 0x00002FC1
	public static void smethod_3()
	{
		new Process
		{
			StartInfo = 
			{
				FileName = Application.ExecutablePath,
				UseShellExecute = true
			}
		}.Start();
		Process.GetCurrentProcess().Kill();
	}

	// Token: 0x060004A0 RID: 1184 RVA: 0x00004DF4 File Offset: 0x00002FF4
	public static bool smethod_4()
	{
		return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
	}

	// Token: 0x060004A1 RID: 1185 RVA: 0x00021C20 File Offset: 0x0001FE20
	public static bool smethod_5(string string_0)
	{
		if (string_0 == null)
		{
			string_0 = Application.StartupPath;
		}
		bool result;
		try
		{
			File.Create("lock").Close();
			File.Delete("lock");
			result = true;
		}
		catch (UnauthorizedAccessException)
		{
			result = false;
		}
		return result;
	}

	// Token: 0x060004A2 RID: 1186 RVA: 0x00004E0A File Offset: 0x0000300A
	public static void smethod_6()
	{
		AppDomain.CurrentDomain.FirstChanceException += Class116.Class117.class117_0.method_0;
	}

	// Token: 0x060004A3 RID: 1187 RVA: 0x00021C6C File Offset: 0x0001FE6C
	public static void smethod_7()
	{
		List<string> source = new List<string>
		{
			".temp",
			"Bunifu_UI_v1.5.3.dll"
		};
		Assembly.GetEntryAssembly().GetName().Version == new Version("3.4.0.0");
		int num = 0;
		foreach (string text in Directory.GetFiles(Application.StartupPath))
		{
			try
			{
				if (source.Any(new Func<string, bool>(new Class116.Class118
				{
					string_0 = new FileInfo(text).FullName
				}.method_0)) && text != Application.ExecutablePath)
				{
					File.Delete(text);
					num++;
				}
			}
			catch (UnauthorizedAccessException)
			{
				Class116.smethod_2();
			}
			catch
			{
			}
		}
		if (num > 0)
		{
			Class116.smethod_3();
		}
	}

	// Token: 0x04000212 RID: 530
	private static Mutex mutex_0 = new Mutex(true, "{afd6dd12-3525-4787-a9df-991c8a58a4fe}");

	// Token: 0x020000BD RID: 189
	[Serializable]
	private sealed class Class117
	{
		// Token: 0x060004A6 RID: 1190 RVA: 0x00021D50 File Offset: 0x0001FF50
		internal void method_0(object sender, FirstChanceExceptionEventArgs e)
		{
			if (!e.Exception.GetType().ToString().Contains("ThreadAbortException") && !e.Exception.GetType().ToString().Contains("System.Exception") && !e.Exception.GetType().ToString().Contains("System.AggregateException") && !e.Exception.GetType().ToString().Contains("System.UriFormatException") && !e.Exception.ToString().Contains("wyDay") && !e.Exception.GetType().ToString().Contains("System.UriFormatException") && !e.Exception.ToString().Contains("Updater") && !e.Exception.ToString().Contains("AmbiguousMatchException"))
			{
				GClass3.smethod_0(e.Exception.ToString(), "ERROR");
			}
		}

		// Token: 0x04000213 RID: 531
		public static readonly Class116.Class117 class117_0 = new Class116.Class117();

		// Token: 0x04000214 RID: 532
		public static EventHandler<FirstChanceExceptionEventArgs> eventHandler_0;
	}

	// Token: 0x020000BE RID: 190
	private sealed class Class118
	{
		// Token: 0x060004A8 RID: 1192 RVA: 0x00004E41 File Offset: 0x00003041
		internal bool method_0(string string_1)
		{
			return this.string_0.Contains(string_1);
		}

		// Token: 0x04000215 RID: 533
		public string string_0;
	}
}
