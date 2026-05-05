using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001A7 RID: 423
	[Flags]
	[Obsolete]
	internal enum ObsoleteCaptureSettingsOverrides
	{
		// Token: 0x04001447 RID: 5191
		ClearColorMode = 4,
		// Token: 0x04001448 RID: 5192
		BackgroundColorHDR = 8,
		// Token: 0x04001449 RID: 5193
		ClearDepth = 16,
		// Token: 0x0400144A RID: 5194
		CullingMask = 32,
		// Token: 0x0400144B RID: 5195
		UseOcclusionCulling = 64,
		// Token: 0x0400144C RID: 5196
		VolumeLayerMask = 128,
		// Token: 0x0400144D RID: 5197
		VolumeAnchorOverride = 256,
		// Token: 0x0400144E RID: 5198
		Projection = 512,
		// Token: 0x0400144F RID: 5199
		NearClip = 1024,
		// Token: 0x04001450 RID: 5200
		FarClip = 2048,
		// Token: 0x04001451 RID: 5201
		FieldOfview = 4096,
		// Token: 0x04001452 RID: 5202
		OrphographicSize = 8192,
		// Token: 0x04001453 RID: 5203
		RenderingPath = 16384,
		// Token: 0x04001454 RID: 5204
		ShadowDistance = 262144
	}
}
