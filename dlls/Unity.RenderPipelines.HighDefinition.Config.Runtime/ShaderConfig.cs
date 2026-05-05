using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000006 RID: 6
	public class ShaderConfig
	{
		// Token: 0x04000017 RID: 23
		public const int k_XRMaxViewsForCBuffer = 2;

		// Token: 0x04000018 RID: 24
		public static int s_CameraRelativeRendering = 1;

		// Token: 0x04000019 RID: 25
		public static int s_PreExposition = 1;

		// Token: 0x0400001A RID: 26
		public static int s_XrMaxViews = 2;

		// Token: 0x0400001B RID: 27
		public static int s_PrecomputedAtmosphericAttenuation = 0;

		// Token: 0x0400001C RID: 28
		public static int s_AreaLights = 1;

		// Token: 0x0400001D RID: 29
		public static int s_BarnDoor = 0;

		// Token: 0x0400001E RID: 30
		public static bool s_GlobalMipBias = true;

		// Token: 0x0400001F RID: 31
		public static int FPTLMaxLightCount = 63;

		// Token: 0x04000020 RID: 32
		public const int LightClusterMaxCellElementCount = 24;

		// Token: 0x04000021 RID: 33
		public static int PathTracingMaxLightCount = 16;
	}
}
