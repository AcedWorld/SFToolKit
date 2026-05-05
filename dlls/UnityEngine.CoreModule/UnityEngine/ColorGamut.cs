using System;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x02000198 RID: 408
	[NativeHeader("Runtime/Graphics/ColorGamut.h")]
	[UsedByNativeCode]
	public enum ColorGamut
	{
		// Token: 0x04000530 RID: 1328
		sRGB,
		// Token: 0x04000531 RID: 1329
		Rec709,
		// Token: 0x04000532 RID: 1330
		Rec2020,
		// Token: 0x04000533 RID: 1331
		DisplayP3,
		// Token: 0x04000534 RID: 1332
		HDR10,
		// Token: 0x04000535 RID: 1333
		DolbyHDR,
		// Token: 0x04000536 RID: 1334
		P3D65G22
	}
}
