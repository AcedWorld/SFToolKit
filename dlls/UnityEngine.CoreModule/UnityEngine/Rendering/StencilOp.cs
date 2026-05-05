using System;
using UnityEngine.Bindings;

namespace UnityEngine.Rendering
{
	// Token: 0x020003F8 RID: 1016
	[NativeHeader("Runtime/GfxDevice/GfxDeviceTypes.h")]
	public enum StencilOp
	{
		// Token: 0x04000BA5 RID: 2981
		Keep,
		// Token: 0x04000BA6 RID: 2982
		Zero,
		// Token: 0x04000BA7 RID: 2983
		Replace,
		// Token: 0x04000BA8 RID: 2984
		IncrementSaturate,
		// Token: 0x04000BA9 RID: 2985
		DecrementSaturate,
		// Token: 0x04000BAA RID: 2986
		Invert,
		// Token: 0x04000BAB RID: 2987
		IncrementWrap,
		// Token: 0x04000BAC RID: 2988
		DecrementWrap
	}
}
