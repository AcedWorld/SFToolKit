using System;
using System.IO;

namespace Unity.VisualScripting
{
	// Token: 0x0200005A RID: 90
	public static class DebugUtility
	{
		// Token: 0x17000094 RID: 148
		// (get) Token: 0x0600028C RID: 652 RVA: 0x0000663C File Offset: 0x0000483C
		public static string logPath
		{
			get
			{
				return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Ludiq.log");
			}
		}

		// Token: 0x0600028D RID: 653 RVA: 0x0000664E File Offset: 0x0000484E
		public static void LogToFile(string message)
		{
			File.AppendAllText(DebugUtility.logPath, message + Environment.NewLine);
		}
	}
}
