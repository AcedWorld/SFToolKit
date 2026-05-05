using System;
using UnityEngine.Bindings;

namespace UnityEngine.Rendering
{
	// Token: 0x020003F5 RID: 1013
	[NativeHeader("Runtime/GfxDevice/GfxDeviceTypes.h")]
	public enum CompareFunction
	{
		// Token: 0x04000B91 RID: 2961
		Disabled,
		// Token: 0x04000B92 RID: 2962
		Never,
		// Token: 0x04000B93 RID: 2963
		Less,
		// Token: 0x04000B94 RID: 2964
		Equal,
		// Token: 0x04000B95 RID: 2965
		LessEqual,
		// Token: 0x04000B96 RID: 2966
		Greater,
		// Token: 0x04000B97 RID: 2967
		NotEqual,
		// Token: 0x04000B98 RID: 2968
		GreaterEqual,
		// Token: 0x04000B99 RID: 2969
		Always
	}
}
