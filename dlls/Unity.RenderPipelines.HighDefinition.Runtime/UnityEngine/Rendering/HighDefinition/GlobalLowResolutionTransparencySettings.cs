using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200015B RID: 347
	[Serializable]
	public struct GlobalLowResolutionTransparencySettings
	{
		// Token: 0x06000BCA RID: 3018 RVA: 0x0005FB7C File Offset: 0x0005DD7C
		internal static GlobalLowResolutionTransparencySettings NewDefault()
		{
			return new GlobalLowResolutionTransparencySettings
			{
				enabled = true,
				checkerboardDepthBuffer = true,
				upsampleType = LowResTransparentUpsample.NearestDepth
			};
		}

		// Token: 0x04000D1B RID: 3355
		public bool enabled;

		// Token: 0x04000D1C RID: 3356
		public bool checkerboardDepthBuffer;

		// Token: 0x04000D1D RID: 3357
		public LowResTransparentUpsample upsampleType;
	}
}
