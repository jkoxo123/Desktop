using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

// Token: 0x02000122 RID: 290
public sealed class GClass3
{
	// Token: 0x0600067F RID: 1663 RVA: 0x00038C28 File Offset: 0x00036E28
	public GClass3()
	{
		Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CyberAIO"));
		File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CyberAIO\\log.txt"), GClass3.string_0);
		Timer timer = new Timer();
		timer.Interval = 5000;
		timer.Tick += this.method_0;
		timer.Start();
	}

	// Token: 0x06000681 RID: 1665 RVA: 0x00038C94 File Offset: 0x00036E94
	public static string smethod_0(string string_1, string string_2)
	{
		string text = string.Format("[{0}] [{1}] [{2}] - {3}", new object[]
		{
			string_2,
			DateTime.Today.Date.ToShortDateString(),
			DateTime.Now.ToString("HH:mm:ss.fff", CultureInfo.InvariantCulture),
			string_1
		}) + Environment.NewLine;
		GClass3.string_0 += text;
		if (Debugger.IsAttached)
		{
			Console.Out.WriteAsync(text);
		}
		return text;
	}

	// Token: 0x06000682 RID: 1666 RVA: 0x00005BA0 File Offset: 0x00003DA0
	private void method_0(object sender, EventArgs e)
	{
		new Task(new Action(GClass3.Class155.class155_0.method_0)).Start();
	}

	// Token: 0x04000515 RID: 1301
	private static string string_0 = string.Empty;

	// Token: 0x02000123 RID: 291
	[Serializable]
	private sealed class Class155
	{
		// Token: 0x06000685 RID: 1669 RVA: 0x00038D1C File Offset: 0x00036F1C
		internal void method_0()
		{
			try
			{
				Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CyberAIO"));
				File.AppendAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CyberAIO\\log.txt"), GClass3.string_0);
				GClass3.string_0 = string.Empty;
			}
			catch
			{
			}
		}

		// Token: 0x04000516 RID: 1302
		public static readonly GClass3.Class155 class155_0 = new GClass3.Class155();

		// Token: 0x04000517 RID: 1303
		public static Action action_0;
	}
}
