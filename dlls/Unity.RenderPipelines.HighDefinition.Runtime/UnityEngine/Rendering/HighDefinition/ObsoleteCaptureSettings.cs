using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001A8 RID: 424
	[Obsolete]
	[Serializable]
	internal class ObsoleteCaptureSettings
	{
		// Token: 0x04001455 RID: 5205
		public static ObsoleteCaptureSettings @default = new ObsoleteCaptureSettings();

		// Token: 0x04001456 RID: 5206
		public ObsoleteCaptureSettingsOverrides overrides;

		// Token: 0x04001457 RID: 5207
		public HDAdditionalCameraData.ClearColorMode clearColorMode;

		// Token: 0x04001458 RID: 5208
		[ColorUsage(true, true)]
		public Color backgroundColorHDR = new Color32(6, 18, 48, 0);

		// Token: 0x04001459 RID: 5209
		public bool clearDepth = true;

		// Token: 0x0400145A RID: 5210
		public LayerMask cullingMask = -1;

		// Token: 0x0400145B RID: 5211
		public bool useOcclusionCulling = true;

		// Token: 0x0400145C RID: 5212
		public LayerMask volumeLayerMask = 1;

		// Token: 0x0400145D RID: 5213
		public Transform volumeAnchorOverride;

		// Token: 0x0400145E RID: 5214
		public CameraProjection projection;

		// Token: 0x0400145F RID: 5215
		public float nearClipPlane = 0.3f;

		// Token: 0x04001460 RID: 5216
		public float farClipPlane = 1000f;

		// Token: 0x04001461 RID: 5217
		public float fieldOfView = 90f;

		// Token: 0x04001462 RID: 5218
		public float orthographicSize = 5f;

		// Token: 0x04001463 RID: 5219
		public int renderingPath;

		// Token: 0x04001464 RID: 5220
		public float shadowDistance = 100f;
	}
}
