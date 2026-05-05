using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000227 RID: 551
	[GenerateHLSL(PackingRules.Exact, false, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Water\\WaterSystemDef.cs")]
	internal struct WaterSurfaceProfile
	{
		// Token: 0x040018F5 RID: 6389
		public Vector3 waterAmbientProbe;

		// Token: 0x040018F6 RID: 6390
		public float tipScatteringHeight;

		// Token: 0x040018F7 RID: 6391
		public float bodyScatteringHeight;

		// Token: 0x040018F8 RID: 6392
		public float maxRefractionDistance;

		// Token: 0x040018F9 RID: 6393
		public uint lightLayers;

		// Token: 0x040018FA RID: 6394
		public int cameraUnderWater;

		// Token: 0x040018FB RID: 6395
		public Vector3 transparencyColor;

		// Token: 0x040018FC RID: 6396
		public float outScatteringCoefficient;

		// Token: 0x040018FD RID: 6397
		public Vector3 scatteringColor;

		// Token: 0x040018FE RID: 6398
		public float envPerceptualRoughness;

		// Token: 0x040018FF RID: 6399
		public float smoothnessFadeStart;

		// Token: 0x04001900 RID: 6400
		public float smoothnessFadeDistance;

		// Token: 0x04001901 RID: 6401
		public float roughnessEndValue;

		// Token: 0x04001902 RID: 6402
		public float padding;
	}
}
