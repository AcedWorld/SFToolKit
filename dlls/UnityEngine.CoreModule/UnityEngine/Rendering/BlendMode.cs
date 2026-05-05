using System;
using UnityEngine.Bindings;

namespace UnityEngine.Rendering
{
	// Token: 0x020003F3 RID: 1011
	[NativeHeader("Runtime/GfxDevice/GfxDeviceTypes.h")]
	public enum BlendMode
	{
		// Token: 0x04000B60 RID: 2912
		Zero,
		// Token: 0x04000B61 RID: 2913
		One,
		// Token: 0x04000B62 RID: 2914
		DstColor,
		// Token: 0x04000B63 RID: 2915
		SrcColor,
		// Token: 0x04000B64 RID: 2916
		OneMinusDstColor,
		// Token: 0x04000B65 RID: 2917
		SrcAlpha,
		// Token: 0x04000B66 RID: 2918
		OneMinusSrcColor,
		// Token: 0x04000B67 RID: 2919
		DstAlpha,
		// Token: 0x04000B68 RID: 2920
		OneMinusDstAlpha,
		// Token: 0x04000B69 RID: 2921
		SrcAlphaSaturate,
		// Token: 0x04000B6A RID: 2922
		OneMinusSrcAlpha
	}
}
