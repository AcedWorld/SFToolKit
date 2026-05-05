using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000D1 RID: 209
	internal class HDShadowResolutionRequest
	{
		// Token: 0x060008F2 RID: 2290 RVA: 0x0004ECDE File Offset: 0x0004CEDE
		public HDShadowResolutionRequest ShallowCopy()
		{
			return (HDShadowResolutionRequest)base.MemberwiseClone();
		}

		// Token: 0x04000901 RID: 2305
		public Rect dynamicAtlasViewport;

		// Token: 0x04000902 RID: 2306
		public Rect cachedAtlasViewport;

		// Token: 0x04000903 RID: 2307
		public Vector2 resolution;

		// Token: 0x04000904 RID: 2308
		public ShadowMapType shadowMapType;
	}
}
