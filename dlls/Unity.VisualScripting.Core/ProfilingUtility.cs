using System;
using System.Diagnostics;
using System.Threading;

namespace Unity.VisualScripting
{
	// Token: 0x020000CC RID: 204
	public static class ProfilingUtility
	{
		// Token: 0x1700010D RID: 269
		// (get) Token: 0x060004E4 RID: 1252 RVA: 0x0000AE9F File Offset: 0x0000909F
		// (set) Token: 0x060004E5 RID: 1253 RVA: 0x0000AEA6 File Offset: 0x000090A6
		public static ProfiledSegment rootSegment { get; private set; }

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x060004E6 RID: 1254 RVA: 0x0000AEAE File Offset: 0x000090AE
		// (set) Token: 0x060004E7 RID: 1255 RVA: 0x0000AEB5 File Offset: 0x000090B5
		public static ProfiledSegment currentSegment { get; set; } = ProfilingUtility.rootSegment = new ProfiledSegment(null, "Root");

		// Token: 0x060004E8 RID: 1256 RVA: 0x0000AEBD File Offset: 0x000090BD
		[Conditional("ENABLE_PROFILER")]
		public static void Clear()
		{
			ProfilingUtility.currentSegment = (ProfilingUtility.rootSegment = new ProfiledSegment(null, "Root"));
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x0000AED5 File Offset: 0x000090D5
		public static ProfilingScope SampleBlock(string name)
		{
			return new ProfilingScope(name);
		}

		// Token: 0x060004EA RID: 1258 RVA: 0x0000AEE0 File Offset: 0x000090E0
		[Conditional("ENABLE_PROFILER")]
		public static void BeginSample(string name)
		{
			Monitor.Enter(ProfilingUtility.@lock);
			if (!ProfilingUtility.currentSegment.children.Contains(name))
			{
				ProfilingUtility.currentSegment.children.Add(new ProfiledSegment(ProfilingUtility.currentSegment, name));
			}
			ProfilingUtility.currentSegment = ProfilingUtility.currentSegment.children[name];
			ProfiledSegment currentSegment = ProfilingUtility.currentSegment;
			long calls = currentSegment.calls;
			currentSegment.calls = calls + 1L;
			ProfilingUtility.currentSegment.stopwatch.Start();
			bool allowsAPI = UnityThread.allowsAPI;
		}

		// Token: 0x060004EB RID: 1259 RVA: 0x0000AF62 File Offset: 0x00009162
		[Conditional("ENABLE_PROFILER")]
		public static void EndSample()
		{
			ProfilingUtility.currentSegment.stopwatch.Stop();
			if (ProfilingUtility.currentSegment.parent != null)
			{
				ProfilingUtility.currentSegment = ProfilingUtility.currentSegment.parent;
			}
			bool allowsAPI = UnityThread.allowsAPI;
			Monitor.Exit(ProfilingUtility.@lock);
		}

		// Token: 0x0400011B RID: 283
		private static readonly object @lock = new object();
	}
}
