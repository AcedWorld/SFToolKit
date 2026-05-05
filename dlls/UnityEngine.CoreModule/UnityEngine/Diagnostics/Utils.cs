using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine.Diagnostics
{
	// Token: 0x020004AD RID: 1197
	[NativeHeader("Runtime/Export/Diagnostics/DiagnosticsUtils.bindings.h")]
	[NativeHeader("Runtime/Misc/GarbageCollectSharedAssets.h")]
	public static class Utils
	{
		// Token: 0x060029CC RID: 10700
		[FreeFunction("DiagnosticsUtils_Bindings::ForceCrash", IsThreadSafe = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void ForceCrash(ForcedCrashCategory crashCategory);

		// Token: 0x060029CD RID: 10701
		[FreeFunction("DiagnosticsUtils_Bindings::NativeAssert", IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void NativeAssert(string message);

		// Token: 0x060029CE RID: 10702
		[FreeFunction("DiagnosticsUtils_Bindings::NativeError", IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void NativeError(string message);

		// Token: 0x060029CF RID: 10703
		[FreeFunction("DiagnosticsUtils_Bindings::NativeWarning", IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void NativeWarning(string message);

		// Token: 0x060029D0 RID: 10704
		[FreeFunction("ValidateHeap")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void ValidateHeap();
	}
}
