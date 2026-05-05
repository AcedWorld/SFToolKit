using System;
using UnityEngine.Bindings;

namespace UnityEngine.Rendering
{
	// Token: 0x020003F4 RID: 1012
	[NativeHeader("Runtime/GfxDevice/GfxDeviceTypes.h")]
	public enum BlendOp
	{
		// Token: 0x04000B6C RID: 2924
		Add,
		// Token: 0x04000B6D RID: 2925
		Subtract,
		// Token: 0x04000B6E RID: 2926
		ReverseSubtract,
		// Token: 0x04000B6F RID: 2927
		Min,
		// Token: 0x04000B70 RID: 2928
		Max,
		// Token: 0x04000B71 RID: 2929
		LogicalClear,
		// Token: 0x04000B72 RID: 2930
		LogicalSet,
		// Token: 0x04000B73 RID: 2931
		LogicalCopy,
		// Token: 0x04000B74 RID: 2932
		LogicalCopyInverted,
		// Token: 0x04000B75 RID: 2933
		LogicalNoop,
		// Token: 0x04000B76 RID: 2934
		LogicalInvert,
		// Token: 0x04000B77 RID: 2935
		LogicalAnd,
		// Token: 0x04000B78 RID: 2936
		LogicalNand,
		// Token: 0x04000B79 RID: 2937
		LogicalOr,
		// Token: 0x04000B7A RID: 2938
		LogicalNor,
		// Token: 0x04000B7B RID: 2939
		LogicalXor,
		// Token: 0x04000B7C RID: 2940
		LogicalEquivalence,
		// Token: 0x04000B7D RID: 2941
		LogicalAndReverse,
		// Token: 0x04000B7E RID: 2942
		LogicalAndInverted,
		// Token: 0x04000B7F RID: 2943
		LogicalOrReverse,
		// Token: 0x04000B80 RID: 2944
		LogicalOrInverted,
		// Token: 0x04000B81 RID: 2945
		Multiply,
		// Token: 0x04000B82 RID: 2946
		Screen,
		// Token: 0x04000B83 RID: 2947
		Overlay,
		// Token: 0x04000B84 RID: 2948
		Darken,
		// Token: 0x04000B85 RID: 2949
		Lighten,
		// Token: 0x04000B86 RID: 2950
		ColorDodge,
		// Token: 0x04000B87 RID: 2951
		ColorBurn,
		// Token: 0x04000B88 RID: 2952
		HardLight,
		// Token: 0x04000B89 RID: 2953
		SoftLight,
		// Token: 0x04000B8A RID: 2954
		Difference,
		// Token: 0x04000B8B RID: 2955
		Exclusion,
		// Token: 0x04000B8C RID: 2956
		HSLHue,
		// Token: 0x04000B8D RID: 2957
		HSLSaturation,
		// Token: 0x04000B8E RID: 2958
		HSLColor,
		// Token: 0x04000B8F RID: 2959
		HSLLuminosity
	}
}
