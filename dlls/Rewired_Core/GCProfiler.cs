using System;
using System.Diagnostics;

namespace Rewired
{
	// Token: 0x020000BE RID: 190
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal static class GCProfiler
	{
		// Token: 0x06000735 RID: 1845 RVA: 0x00002FF9 File Offset: 0x000011F9
		[Conditional("ENABLE_GCPROFILER")]
		public static void Begin(string name)
		{
		}

		// Token: 0x06000736 RID: 1846 RVA: 0x00002FF9 File Offset: 0x000011F9
		[Conditional("ENABLE_GCPROFILER")]
		public static void End()
		{
		}

		// Token: 0x06000737 RID: 1847 RVA: 0x00002FF9 File Offset: 0x000011F9
		[Conditional("ENABLE_GCPROFILER")]
		public static void LogReport()
		{
		}

		// Token: 0x06000738 RID: 1848 RVA: 0x00002FF9 File Offset: 0x000011F9
		[Conditional("ENABLE_GCPROFILER")]
		public static void Clear()
		{
		}
	}
}
