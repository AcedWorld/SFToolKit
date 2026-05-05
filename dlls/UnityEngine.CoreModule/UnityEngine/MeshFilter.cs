using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x02000179 RID: 377
	[RequireComponent(typeof(Transform))]
	[NativeHeader("Runtime/Graphics/Mesh/MeshFilter.h")]
	public sealed class MeshFilter : Component
	{
		// Token: 0x06000FE4 RID: 4068 RVA: 0x00002669 File Offset: 0x00000869
		[RequiredByNativeCode]
		private void DontStripMeshFilter()
		{
		}

		// Token: 0x17000346 RID: 838
		// (get) Token: 0x06000FE5 RID: 4069
		// (set) Token: 0x06000FE6 RID: 4070
		public extern Mesh sharedMesh { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000347 RID: 839
		// (get) Token: 0x06000FE7 RID: 4071
		// (set) Token: 0x06000FE8 RID: 4072
		public extern Mesh mesh { [NativeName("GetInstantiatedMeshFromScript")] [MethodImpl(MethodImplOptions.InternalCall)] get; [NativeName("SetInstantiatedMesh")] [MethodImpl(MethodImplOptions.InternalCall)] set; }
	}
}
