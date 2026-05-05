using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine.Experimental.GlobalIllumination
{
	// Token: 0x020004CA RID: 1226
	[NativeHeader("Runtime/Camera/RenderSettings.h")]
	[StaticAccessor("GetRenderSettings()", StaticAccessorType.Dot)]
	public class RenderSettings
	{
		// Token: 0x1700083A RID: 2106
		// (get) Token: 0x06002AE5 RID: 10981
		// (set) Token: 0x06002AE6 RID: 10982
		public static extern bool useRadianceAmbientProbe { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }
	}
}
