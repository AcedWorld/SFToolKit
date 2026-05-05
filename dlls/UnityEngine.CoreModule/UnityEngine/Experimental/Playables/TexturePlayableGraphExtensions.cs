using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Playables;

namespace UnityEngine.Experimental.Playables
{
	// Token: 0x020004CF RID: 1231
	[NativeHeader("Runtime/Director/Core/HPlayableOutput.h")]
	[NativeHeader("Runtime/Export/Director/TexturePlayableGraphExtensions.bindings.h")]
	[StaticAccessor("TexturePlayableGraphExtensionsBindings", StaticAccessorType.DoubleColon)]
	internal static class TexturePlayableGraphExtensions
	{
		// Token: 0x06002B10 RID: 11024
		[NativeThrows]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool InternalCreateTextureOutput(ref PlayableGraph graph, string name, out PlayableOutputHandle handle);
	}
}
