using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine.Rendering
{
	// Token: 0x020003E4 RID: 996
	[NativeHeader("Runtime/Graphics/GraphicsScriptBindings.h")]
	public class PIX
	{
		// Token: 0x060021A2 RID: 8610
		[FreeFunction("PIX::BeginGPUCapture")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void BeginGPUCapture();

		// Token: 0x060021A3 RID: 8611
		[FreeFunction("PIX::EndGPUCapture")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void EndGPUCapture();

		// Token: 0x060021A4 RID: 8612
		[FreeFunction("PIX::IsAttached")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsAttached();
	}
}
