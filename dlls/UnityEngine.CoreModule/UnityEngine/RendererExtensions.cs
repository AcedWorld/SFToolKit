using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine
{
	// Token: 0x0200015C RID: 348
	[NativeHeader("Runtime/Graphics/GraphicsScriptBindings.h")]
	public static class RendererExtensions
	{
		// Token: 0x06000B82 RID: 2946 RVA: 0x00011E62 File Offset: 0x00010062
		public static void UpdateGIMaterials(this Renderer renderer)
		{
			RendererExtensions.UpdateGIMaterialsForRenderer(renderer);
		}

		// Token: 0x06000B83 RID: 2947
		[FreeFunction("RendererScripting::UpdateGIMaterialsForRenderer")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void UpdateGIMaterialsForRenderer(Renderer renderer);
	}
}
