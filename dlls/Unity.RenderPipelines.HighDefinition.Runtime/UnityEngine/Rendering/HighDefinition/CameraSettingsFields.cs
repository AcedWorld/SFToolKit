using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000201 RID: 513
	[Flags]
	public enum CameraSettingsFields
	{
		// Token: 0x040017E2 RID: 6114
		none = 0,
		// Token: 0x040017E3 RID: 6115
		bufferClearColorMode = 2,
		// Token: 0x040017E4 RID: 6116
		bufferClearBackgroundColorHDR = 4,
		// Token: 0x040017E5 RID: 6117
		bufferClearClearDepth = 8,
		// Token: 0x040017E6 RID: 6118
		volumesLayerMask = 16,
		// Token: 0x040017E7 RID: 6119
		volumesAnchorOverride = 32,
		// Token: 0x040017E8 RID: 6120
		frustumMode = 64,
		// Token: 0x040017E9 RID: 6121
		frustumAspect = 128,
		// Token: 0x040017EA RID: 6122
		frustumFarClipPlane = 256,
		// Token: 0x040017EB RID: 6123
		frustumNearClipPlane = 512,
		// Token: 0x040017EC RID: 6124
		frustumFieldOfView = 1024,
		// Token: 0x040017ED RID: 6125
		frustumProjectionMatrix = 2048,
		// Token: 0x040017EE RID: 6126
		cullingUseOcclusionCulling = 4096,
		// Token: 0x040017EF RID: 6127
		cullingCullingMask = 8192,
		// Token: 0x040017F0 RID: 6128
		cullingInvertFaceCulling = 16384,
		// Token: 0x040017F1 RID: 6129
		customRenderingSettings = 32768,
		// Token: 0x040017F2 RID: 6130
		flipYMode = 65536,
		// Token: 0x040017F3 RID: 6131
		frameSettings = 131072,
		// Token: 0x040017F4 RID: 6132
		probeLayerMask = 262144
	}
}
