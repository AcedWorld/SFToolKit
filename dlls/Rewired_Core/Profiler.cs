using System;
using System.Diagnostics;
using UnityEngine;

namespace Rewired
{
	// Token: 0x0200003C RID: 60
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false)]
	internal static class Profiler
	{
		// Token: 0x0600022C RID: 556 RVA: 0x00003DF7 File Offset: 0x00001FF7
		private static void UeOihLZYdnzrDZmGtUgikKdVypjC()
		{
			Logger.Log("ENABLE_PROFILER must be set in Rewired Core to use the profiler.");
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x0600022D RID: 557 RVA: 0x00003E03 File Offset: 0x00002003
		// (set) Token: 0x0600022E RID: 558 RVA: 0x00003E0B File Offset: 0x0000200B
		public static bool enableBinaryLog
		{
			get
			{
				Profiler.UeOihLZYdnzrDZmGtUgikKdVypjC();
				return false;
			}
			set
			{
				Profiler.UeOihLZYdnzrDZmGtUgikKdVypjC();
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x0600022F RID: 559 RVA: 0x00003E03 File Offset: 0x00002003
		// (set) Token: 0x06000230 RID: 560 RVA: 0x00003E0B File Offset: 0x0000200B
		public static bool enabled
		{
			get
			{
				Profiler.UeOihLZYdnzrDZmGtUgikKdVypjC();
				return false;
			}
			set
			{
				Profiler.UeOihLZYdnzrDZmGtUgikKdVypjC();
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000231 RID: 561 RVA: 0x00003E12 File Offset: 0x00002012
		// (set) Token: 0x06000232 RID: 562 RVA: 0x00003E0B File Offset: 0x0000200B
		public static string logFile
		{
			get
			{
				Profiler.UeOihLZYdnzrDZmGtUgikKdVypjC();
				return string.Empty;
			}
			set
			{
				Profiler.UeOihLZYdnzrDZmGtUgikKdVypjC();
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06000233 RID: 563 RVA: 0x00003E03 File Offset: 0x00002003
		public static bool supported
		{
			get
			{
				Profiler.UeOihLZYdnzrDZmGtUgikKdVypjC();
				return false;
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000234 RID: 564 RVA: 0x00003E03 File Offset: 0x00002003
		public static uint usedHeapSize
		{
			get
			{
				Profiler.UeOihLZYdnzrDZmGtUgikKdVypjC();
				return 0U;
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x06000235 RID: 565 RVA: 0x00003E1E File Offset: 0x0000201E
		public static long usedHeapSizeLong
		{
			get
			{
				Profiler.UeOihLZYdnzrDZmGtUgikKdVypjC();
				return 0L;
			}
		}

		// Token: 0x06000236 RID: 566 RVA: 0x00003E0B File Offset: 0x0000200B
		[Conditional("ENABLE_PROFILER")]
		public static void AddFramesFromFile(string file)
		{
			Profiler.UeOihLZYdnzrDZmGtUgikKdVypjC();
		}

		// Token: 0x06000237 RID: 567 RVA: 0x00003E0B File Offset: 0x0000200B
		[Conditional("ENABLE_PROFILER")]
		public static void BeginSample(string name)
		{
			Profiler.UeOihLZYdnzrDZmGtUgikKdVypjC();
		}

		// Token: 0x06000238 RID: 568 RVA: 0x00003E0B File Offset: 0x0000200B
		[Conditional("ENABLE_PROFILER")]
		public static void BeginSample(string name, Object targetObject)
		{
			Profiler.UeOihLZYdnzrDZmGtUgikKdVypjC();
		}

		// Token: 0x06000239 RID: 569 RVA: 0x00003E0B File Offset: 0x0000200B
		[Conditional("ENABLE_PROFILER")]
		public static void EndSample()
		{
			Profiler.UeOihLZYdnzrDZmGtUgikKdVypjC();
		}

		// Token: 0x0600023A RID: 570 RVA: 0x00003E03 File Offset: 0x00002003
		public static uint GetMonoHeapSize()
		{
			Profiler.UeOihLZYdnzrDZmGtUgikKdVypjC();
			return 0U;
		}

		// Token: 0x0600023B RID: 571 RVA: 0x00003E27 File Offset: 0x00002027
		public static long GetMonoHeapSizeLong()
		{
			return 0L;
		}

		// Token: 0x0600023C RID: 572 RVA: 0x00003E03 File Offset: 0x00002003
		public static uint GetMonoUsedSize()
		{
			Profiler.UeOihLZYdnzrDZmGtUgikKdVypjC();
			return 0U;
		}

		// Token: 0x0600023D RID: 573 RVA: 0x00003E27 File Offset: 0x00002027
		public static long GetMonoUsedSizeLong()
		{
			return 0L;
		}

		// Token: 0x0600023E RID: 574 RVA: 0x00003E03 File Offset: 0x00002003
		public static int GetRuntimeMemorySize(Object o)
		{
			Profiler.UeOihLZYdnzrDZmGtUgikKdVypjC();
			return 0;
		}

		// Token: 0x0600023F RID: 575 RVA: 0x00003E27 File Offset: 0x00002027
		public static long GetRuntimeMemorySizeLong(Object o)
		{
			return 0L;
		}

		// Token: 0x06000240 RID: 576 RVA: 0x00003E03 File Offset: 0x00002003
		public static uint GetTotalAllocatedMemory()
		{
			Profiler.UeOihLZYdnzrDZmGtUgikKdVypjC();
			return 0U;
		}

		// Token: 0x06000241 RID: 577 RVA: 0x00003E27 File Offset: 0x00002027
		public static long GetTotalAllocatedMemoryLong()
		{
			return 0L;
		}

		// Token: 0x06000242 RID: 578 RVA: 0x00003E2B File Offset: 0x0000202B
		public static uint GetTotalReservedMemory()
		{
			return 0U;
		}

		// Token: 0x06000243 RID: 579 RVA: 0x00003E27 File Offset: 0x00002027
		public static long GetTotalReservedMemoryLong()
		{
			return 0L;
		}

		// Token: 0x06000244 RID: 580 RVA: 0x00003E2B File Offset: 0x0000202B
		public static uint GetTotalUnusedReservedMemory()
		{
			return 0U;
		}

		// Token: 0x06000245 RID: 581 RVA: 0x00003E27 File Offset: 0x00002027
		public static long GetTotalUnusedReservedMemoryLong()
		{
			return 0L;
		}

		// Token: 0x04000103 RID: 259
		private const string MyGqoUYPQWgDpOnoQIubnKbLMvz = "ENABLE_PROFILER must be set in Rewired Core to use the profiler.";
	}
}
