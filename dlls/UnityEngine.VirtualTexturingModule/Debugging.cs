using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Rendering.VirtualTexturing
{
	// Token: 0x02000005 RID: 5
	[NativeHeader("Modules/VirtualTexturing/ScriptBindings/VirtualTexturing.bindings.h")]
	[StaticAccessor("VirtualTexturing::Debugging", StaticAccessorType.DoubleColon)]
	public static class Debugging
	{
		// Token: 0x0600000C RID: 12
		[NativeThrows]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int GetNumHandles();

		// Token: 0x0600000D RID: 13
		[NativeThrows]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void GrabHandleInfo(out Debugging.Handle debugHandle, int index);

		// Token: 0x0600000E RID: 14
		[NativeThrows]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern string GetInfoDump();

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000F RID: 15
		// (set) Token: 0x06000010 RID: 16
		[NativeThrows]
		public static extern bool debugTilesEnabled { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000011 RID: 17
		// (set) Token: 0x06000012 RID: 18
		[NativeThrows]
		public static extern bool resolvingEnabled { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000013 RID: 19
		// (set) Token: 0x06000014 RID: 20
		[NativeThrows]
		public static extern bool flushEveryTickEnabled { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000015 RID: 21
		[NativeThrows]
		public static extern int mipPreloadedTextureCount { [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x02000006 RID: 6
		[NativeHeader("Modules/VirtualTexturing/Public/VirtualTexturingDebugHandle.h")]
		[UsedByNativeCode]
		public struct Handle
		{
			// Token: 0x04000004 RID: 4
			public long handle;

			// Token: 0x04000005 RID: 5
			public string group;

			// Token: 0x04000006 RID: 6
			public string name;

			// Token: 0x04000007 RID: 7
			public int numLayers;

			// Token: 0x04000008 RID: 8
			public Material material;
		}
	}
}
