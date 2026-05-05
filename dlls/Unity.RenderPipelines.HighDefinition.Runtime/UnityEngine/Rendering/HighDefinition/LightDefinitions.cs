using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000098 RID: 152
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Lighting\\LightLoop\\LightLoop.cs")]
	internal class LightDefinitions
	{
		// Token: 0x04000706 RID: 1798
		public static float s_ViewportScaleZ = 1f;

		// Token: 0x04000707 RID: 1799
		public static int s_UseLeftHandCameraSpace = 1;

		// Token: 0x04000708 RID: 1800
		public static int s_TileSizeFptl = 16;

		// Token: 0x04000709 RID: 1801
		public static int s_TileSizeClustered = 32;

		// Token: 0x0400070A RID: 1802
		public static int s_TileSizeBigTile = 64;

		// Token: 0x0400070B RID: 1803
		public static int s_TileIndexMask = 32767;

		// Token: 0x0400070C RID: 1804
		public static int s_TileIndexShiftX = 0;

		// Token: 0x0400070D RID: 1805
		public static int s_TileIndexShiftY = 15;

		// Token: 0x0400070E RID: 1806
		public static int s_TileIndexShiftEye = 30;

		// Token: 0x0400070F RID: 1807
		public static int s_NumFeatureVariants = 29;

		// Token: 0x04000710 RID: 1808
		public static uint s_LightFeatureMaskFlags = 16773120U;

		// Token: 0x04000711 RID: 1809
		public static uint s_LightFeatureMaskFlagsOpaque = 16642048U;

		// Token: 0x04000712 RID: 1810
		public static uint s_LightFeatureMaskFlagsTransparent = 16510976U;

		// Token: 0x04000713 RID: 1811
		public static uint s_MaterialFeatureMaskFlags = 4095U;

		// Token: 0x04000714 RID: 1812
		public static uint s_RayTracedScreenSpaceShadowFlag = 4096U;

		// Token: 0x04000715 RID: 1813
		public static uint s_ScreenSpaceColorShadowFlag = 256U;

		// Token: 0x04000716 RID: 1814
		public static uint s_InvalidScreenSpaceShadow = 255U;

		// Token: 0x04000717 RID: 1815
		public static uint s_ScreenSpaceShadowIndexMask = 255U;

		// Token: 0x04000718 RID: 1816
		public static int s_ContactShadowFadeBits = 8;

		// Token: 0x04000719 RID: 1817
		public static int s_ContactShadowMaskBits = 32 - LightDefinitions.s_ContactShadowFadeBits;

		// Token: 0x0400071A RID: 1818
		public static int s_ContactShadowFadeMask = (1 << LightDefinitions.s_ContactShadowFadeBits) - 1;

		// Token: 0x0400071B RID: 1819
		public static int s_ContactShadowMaskMask = (1 << LightDefinitions.s_ContactShadowMaskBits) - 1;
	}
}
