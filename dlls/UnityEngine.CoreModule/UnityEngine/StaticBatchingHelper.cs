using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine
{
	// Token: 0x020001C8 RID: 456
	[NativeHeader("Runtime/Graphics/Mesh/StaticBatching.h")]
	internal struct StaticBatchingHelper
	{
		// Token: 0x060011E3 RID: 4579
		[FreeFunction("StaticBatching::CombineMeshesForStaticBatching")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void CombineMeshes(GameObject[] gos, GameObject staticBatchRoot);
	}
}
