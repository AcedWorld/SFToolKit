using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200009A RID: 154
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Lighting\\LightLoop\\LightLoop.cs")]
	internal struct LightVolumeData
	{
		// Token: 0x04000722 RID: 1826
		public Vector3 lightPos;

		// Token: 0x04000723 RID: 1827
		public uint lightVolume;

		// Token: 0x04000724 RID: 1828
		public Vector3 lightAxisX;

		// Token: 0x04000725 RID: 1829
		public uint lightCategory;

		// Token: 0x04000726 RID: 1830
		public Vector3 lightAxisY;

		// Token: 0x04000727 RID: 1831
		public float radiusSq;

		// Token: 0x04000728 RID: 1832
		public Vector3 lightAxisZ;

		// Token: 0x04000729 RID: 1833
		public float cotan;

		// Token: 0x0400072A RID: 1834
		public Vector3 boxInnerDist;

		// Token: 0x0400072B RID: 1835
		public uint featureFlags;

		// Token: 0x0400072C RID: 1836
		public Vector3 boxInvRange;

		// Token: 0x0400072D RID: 1837
		public float unused2;
	}
}
