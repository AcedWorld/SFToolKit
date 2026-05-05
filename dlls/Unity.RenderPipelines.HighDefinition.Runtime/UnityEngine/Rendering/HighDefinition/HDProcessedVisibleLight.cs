using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200007C RID: 124
	internal struct HDProcessedVisibleLight
	{
		// Token: 0x040005F1 RID: 1521
		public int dataIndex;

		// Token: 0x040005F2 RID: 1522
		public GPULightType gpuLightType;

		// Token: 0x040005F3 RID: 1523
		public HDLightType lightType;

		// Token: 0x040005F4 RID: 1524
		public float lightDistanceFade;

		// Token: 0x040005F5 RID: 1525
		public float lightVolumetricDistanceFade;

		// Token: 0x040005F6 RID: 1526
		public float distanceToCamera;

		// Token: 0x040005F7 RID: 1527
		public HDProcessedVisibleLightsBuilder.ShadowMapFlags shadowMapFlags;

		// Token: 0x040005F8 RID: 1528
		public bool isBakedShadowMask;
	}
}
