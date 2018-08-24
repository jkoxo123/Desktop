using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace CyberAIO.Properties
{
	// Token: 0x0200019E RID: 414
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.7.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000896 RID: 2198 RVA: 0x00006BC0 File Offset: 0x00004DC0
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x0400077B RID: 1915
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
