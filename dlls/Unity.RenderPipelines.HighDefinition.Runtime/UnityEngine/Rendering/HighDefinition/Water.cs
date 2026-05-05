using System;
using UnityEngine.Rendering.HighDefinition.Attributes;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000118 RID: 280
	internal class Water : RenderPipelineMaterial
	{
		// Token: 0x020003A1 RID: 929
		[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Material\\Water\\Water.cs")]
		public enum MaterialFeatureFlags
		{
			// Token: 0x040025D3 RID: 9683
			WaterStandard = 1,
			// Token: 0x040025D4 RID: 9684
			WaterCinematic
		}

		// Token: 0x020003A2 RID: 930
		[GenerateHLSL(PackingRules.Exact, false, false, true, 1600, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Material\\Water\\Water.cs")]
		public struct SurfaceData
		{
			// Token: 0x040025D5 RID: 9685
			[MaterialSharedPropertyMapping(MaterialSharedProperty.Albedo)]
			[SurfaceDataAttributes("Base Color", false, true, FieldPrecision.Default, false, "")]
			public Vector3 baseColor;

			// Token: 0x040025D6 RID: 9686
			[MaterialSharedPropertyMapping(MaterialSharedProperty.Normal)]
			[SurfaceDataAttributes(new string[]
			{
				"Normal WS",
				"Normal View Space"
			}, true, false, FieldPrecision.Default, true, "")]
			public Vector3 normalWS;

			// Token: 0x040025D7 RID: 9687
			[SurfaceDataAttributes(new string[]
			{
				"Low Frequency Normal WS",
				"Low Frequency Normal View Space"
			}, true, false, FieldPrecision.Default, true, "")]
			public Vector3 lowFrequencyNormalWS;

			// Token: 0x040025D8 RID: 9688
			[MaterialSharedPropertyMapping(MaterialSharedProperty.Smoothness)]
			[SurfaceDataAttributes("Smoothness", false, false, FieldPrecision.Default, false, "")]
			public float perceptualSmoothness;

			// Token: 0x040025D9 RID: 9689
			[SurfaceDataAttributes("Foam", false, false, FieldPrecision.Default, false, "")]
			public float foam;

			// Token: 0x040025DA RID: 9690
			public float tipThickness;

			// Token: 0x040025DB RID: 9691
			[SurfaceDataAttributes("Caustics", false, false, FieldPrecision.Default, false, "")]
			public float caustics;
		}

		// Token: 0x020003A3 RID: 931
		[GenerateHLSL(PackingRules.Exact, false, false, true, 1650, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Material\\Water\\Water.cs")]
		public struct BSDFData
		{
			// Token: 0x040025DC RID: 9692
			[SurfaceDataAttributes("", false, true, FieldPrecision.Default, false, "")]
			public Vector3 diffuseColor;

			// Token: 0x040025DD RID: 9693
			public Vector3 fresnel0;

			// Token: 0x040025DE RID: 9694
			[SurfaceDataAttributes(new string[]
			{
				"Normal WS",
				"Normal View Space"
			}, true, false, FieldPrecision.Default, true, "")]
			public Vector3 normalWS;

			// Token: 0x040025DF RID: 9695
			[SurfaceDataAttributes(new string[]
			{
				"Low Frequency Normal WS",
				"Low Frequency Normal View Space"
			}, true, false, FieldPrecision.Default, false, "")]
			public Vector3 lowFrequencyNormalWS;

			// Token: 0x040025E0 RID: 9696
			public float perceptualRoughness;

			// Token: 0x040025E1 RID: 9697
			public float roughness;

			// Token: 0x040025E2 RID: 9698
			public float caustics;

			// Token: 0x040025E3 RID: 9699
			public float foam;

			// Token: 0x040025E4 RID: 9700
			public float tipThickness;

			// Token: 0x040025E5 RID: 9701
			public uint surfaceIndex;
		}
	}
}
