using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine.Experimental.Rendering
{
	// Token: 0x020004D6 RID: 1238
	[NativeHeader("Runtime/Graphics/GraphicsScriptBindings.h")]
	public static class ExternalGPUProfiler
	{
		// Token: 0x06002B31 RID: 11057
		[FreeFunction("ExternalGPUProfilerBindings::BeginGPUCapture")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void BeginGPUCapture();

		// Token: 0x06002B32 RID: 11058
		[FreeFunction("ExternalGPUProfilerBindings::EndGPUCapture")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void EndGPUCapture();

		// Token: 0x06002B33 RID: 11059
		[FreeFunction("ExternalGPUProfilerBindings::IsAttached")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsAttached();
	}
}
