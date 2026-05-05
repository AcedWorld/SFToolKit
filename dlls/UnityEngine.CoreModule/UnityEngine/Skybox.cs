using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine
{
	// Token: 0x02000178 RID: 376
	[NativeHeader("Runtime/Camera/Skybox.h")]
	public sealed class Skybox : Behaviour
	{
		// Token: 0x17000345 RID: 837
		// (get) Token: 0x06000FE1 RID: 4065
		// (set) Token: 0x06000FE2 RID: 4066
		public extern Material material { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }
	}
}
