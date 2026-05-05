using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine.Experimental.Rendering
{
	// Token: 0x020004D9 RID: 1241
	public static class GraphicsDeviceSettings
	{
		// Token: 0x17000840 RID: 2112
		// (get) Token: 0x06002B34 RID: 11060
		// (set) Token: 0x06002B35 RID: 11061
		[StaticAccessor("GetGfxDevice()", StaticAccessorType.Dot)]
		public static extern WaitForPresentSyncPoint waitForPresentSyncPoint { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000841 RID: 2113
		// (get) Token: 0x06002B36 RID: 11062
		// (set) Token: 0x06002B37 RID: 11063
		[StaticAccessor("GetGfxDevice()", StaticAccessorType.Dot)]
		public static extern GraphicsJobsSyncPoint graphicsJobsSyncPoint { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }
	}
}
