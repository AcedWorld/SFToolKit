using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Experimental.U2D
{
	// Token: 0x020004B7 RID: 1207
	[NativeHeader("Runtime/2D/Renderer/SpriteRendererGroup.h")]
	[RequiredByNativeCode]
	[StructLayout(LayoutKind.Sequential)]
	internal class SpriteRendererGroup
	{
		// Token: 0x06002AB0 RID: 10928 RVA: 0x00047A33 File Offset: 0x00045C33
		public static void AddRenderers(NativeArray<SpriteIntermediateRendererInfo> renderers)
		{
			SpriteRendererGroup.AddRenderers(renderers.GetUnsafeReadOnlyPtr<SpriteIntermediateRendererInfo>(), renderers.Length);
		}

		// Token: 0x06002AB1 RID: 10929
		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern void AddRenderers(void* renderers, int count);

		// Token: 0x06002AB2 RID: 10930
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void Clear();
	}
}
