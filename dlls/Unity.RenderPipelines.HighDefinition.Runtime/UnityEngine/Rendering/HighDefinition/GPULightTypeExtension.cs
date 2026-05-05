using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000081 RID: 129
	internal static class GPULightTypeExtension
	{
		// Token: 0x06000723 RID: 1827 RVA: 0x00047B98 File Offset: 0x00045D98
		public static bool IsAreaLight(this GPULightType lightType)
		{
			return lightType == GPULightType.Rectangle || lightType == GPULightType.Tube;
		}

		// Token: 0x06000724 RID: 1828 RVA: 0x00047BA4 File Offset: 0x00045DA4
		public static bool IsSpot(this GPULightType lightType)
		{
			return lightType == GPULightType.Spot || lightType == GPULightType.ProjectorBox || lightType == GPULightType.ProjectorPyramid;
		}
	}
}
