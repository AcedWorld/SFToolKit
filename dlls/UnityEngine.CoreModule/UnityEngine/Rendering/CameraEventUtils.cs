using System;

namespace UnityEngine.Rendering
{
	// Token: 0x020003FD RID: 1021
	internal static class CameraEventUtils
	{
		// Token: 0x060021A8 RID: 8616 RVA: 0x00037FBC File Offset: 0x000361BC
		public static bool IsValid(CameraEvent value)
		{
			return value >= CameraEvent.BeforeDepthTexture && value <= CameraEvent.AfterHaloAndLensFlares;
		}

		// Token: 0x04000BD3 RID: 3027
		private const CameraEvent k_MinimumValue = CameraEvent.BeforeDepthTexture;

		// Token: 0x04000BD4 RID: 3028
		private const CameraEvent k_MaximumValue = CameraEvent.AfterHaloAndLensFlares;
	}
}
