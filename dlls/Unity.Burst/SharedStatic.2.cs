using System;
using System.Diagnostics;
using Unity.Burst.LowLevel;
using UnityEngine;

namespace Unity.Burst
{
	// Token: 0x02000018 RID: 24
	internal static class SharedStatic
	{
		// Token: 0x060000BB RID: 187 RVA: 0x000056D6 File Offset: 0x000038D6
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void CheckSizeOf(uint sizeOf)
		{
			if (sizeOf == 0U)
			{
				throw new ArgumentException("sizeOf must be > 0", "sizeOf");
			}
		}

		// Token: 0x060000BC RID: 188 RVA: 0x000056EB File Offset: 0x000038EB
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private unsafe static void CheckResult(void* result)
		{
			if (result == null)
			{
				throw new InvalidOperationException("Unable to create a SharedStatic for this key. This is most likely due to the size of the struct inside of the SharedStatic having changed or the same key being reused for differently sized values. To fix this the editor needs to be restarted.");
			}
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00005700 File Offset: 0x00003900
		[SharedStatic.PreserveAttribute]
		public unsafe static void* GetOrCreateSharedStaticInternal(long getHashCode64, long getSubHashCode64, uint sizeOf, uint alignment)
		{
			Hash128 hash = new Hash128((ulong)getHashCode64, (ulong)getSubHashCode64);
			return BurstCompilerService.GetOrCreateSharedMemory(ref hash, sizeOf, alignment);
		}

		// Token: 0x0200003D RID: 61
		internal class PreserveAttribute : Attribute
		{
		}
	}
}
