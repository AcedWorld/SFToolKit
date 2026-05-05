using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine.Rendering
{
	// Token: 0x020003E5 RID: 997
	public static class LoadStoreActionDebugModeSettings
	{
		// Token: 0x17000657 RID: 1623
		// (get) Token: 0x060021A6 RID: 8614
		// (set) Token: 0x060021A7 RID: 8615
		[StaticAccessor("GetGfxDevice()", StaticAccessorType.Dot)]
		public static extern bool LoadStoreDebugModeEnabled { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }
	}
}
