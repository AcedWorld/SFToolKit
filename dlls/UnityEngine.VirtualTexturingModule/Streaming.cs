using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine.Rendering.VirtualTexturing
{
	// Token: 0x0200000A RID: 10
	[NativeHeader("Modules/VirtualTexturing/ScriptBindings/VirtualTexturing.bindings.h")]
	[StaticAccessor("VirtualTexturing::Streaming", StaticAccessorType.DoubleColon)]
	public static class Streaming
	{
		// Token: 0x06000025 RID: 37 RVA: 0x0000226B File Offset: 0x0000046B
		[NativeThrows]
		public static void RequestRegion([NotNull("ArgumentNullException")] Material mat, int stackNameId, Rect r, int mipMap, int numMips)
		{
			Streaming.RequestRegion_Injected(mat, stackNameId, ref r, mipMap, numMips);
		}

		// Token: 0x06000026 RID: 38
		[NativeThrows]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void GetTextureStackSize([NotNull("ArgumentNullException")] Material mat, int stackNameId, out int width, out int height);

		// Token: 0x06000027 RID: 39
		[NativeThrows]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetCPUCacheSize(int sizeInMegabytes);

		// Token: 0x06000028 RID: 40
		[NativeThrows]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int GetCPUCacheSize();

		// Token: 0x06000029 RID: 41
		[NativeThrows]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetGPUCacheSettings(GPUCacheSetting[] cacheSettings);

		// Token: 0x0600002A RID: 42
		[NativeThrows]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern GPUCacheSetting[] GetGPUCacheSettings();

		// Token: 0x0600002B RID: 43
		[NativeThrows]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void EnableMipPreloading(int texturesPerFrame, int mipCount);

		// Token: 0x0600002C RID: 44
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void RequestRegion_Injected(Material mat, int stackNameId, ref Rect r, int mipMap, int numMips);
	}
}
