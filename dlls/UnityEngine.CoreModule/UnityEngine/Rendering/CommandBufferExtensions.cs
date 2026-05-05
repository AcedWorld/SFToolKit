using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Rendering
{
	// Token: 0x0200042F RID: 1071
	[NativeHeader("Runtime/Export/Graphics/RenderingCommandBufferExtensions.bindings.h")]
	[UsedByNativeCode]
	public static class CommandBufferExtensions
	{
		// Token: 0x0600241C RID: 9244
		[FreeFunction("RenderingCommandBufferExtensions_Bindings::Internal_SwitchIntoFastMemory")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_SwitchIntoFastMemory([NotNull("NullExceptionObject")] CommandBuffer cmd, ref RenderTargetIdentifier rt, FastMemoryFlags fastMemoryFlags, float residency, bool copyContents);

		// Token: 0x0600241D RID: 9245
		[FreeFunction("RenderingCommandBufferExtensions_Bindings::Internal_SwitchOutOfFastMemory")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_SwitchOutOfFastMemory([NotNull("NullExceptionObject")] CommandBuffer cmd, ref RenderTargetIdentifier rt, bool copyContents);

		// Token: 0x0600241E RID: 9246 RVA: 0x0003BFFA File Offset: 0x0003A1FA
		[NativeConditional("UNITY_XBOXONE || UNITY_GAMECORE_XBOXONE")]
		public static void SwitchIntoFastMemory(this CommandBuffer cmd, RenderTargetIdentifier rid, FastMemoryFlags fastMemoryFlags, float residency, bool copyContents)
		{
			CommandBufferExtensions.Internal_SwitchIntoFastMemory(cmd, ref rid, fastMemoryFlags, residency, copyContents);
		}

		// Token: 0x0600241F RID: 9247 RVA: 0x0003C00A File Offset: 0x0003A20A
		[NativeConditional("UNITY_XBOXONE || UNITY_GAMECORE_XBOXONE")]
		public static void SwitchOutOfFastMemory(this CommandBuffer cmd, RenderTargetIdentifier rid, bool copyContents)
		{
			CommandBufferExtensions.Internal_SwitchOutOfFastMemory(cmd, ref rid, copyContents);
		}
	}
}
