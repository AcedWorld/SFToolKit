using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001E6 RID: 486
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Sky\\PhysicallyBasedSky\\ShaderVariablesPhysicallyBasedSky.cs", needAccessors = false, generateCBuffer = true, constantRegister = 2)]
	internal struct ShaderVariablesPhysicallyBasedSky
	{
		// Token: 0x0400172D RID: 5933
		public float _PlanetaryRadius;

		// Token: 0x0400172E RID: 5934
		public float _RcpPlanetaryRadius;

		// Token: 0x0400172F RID: 5935
		public float _AtmosphericDepth;

		// Token: 0x04001730 RID: 5936
		public float _RcpAtmosphericDepth;

		// Token: 0x04001731 RID: 5937
		public float _AtmosphericRadius;

		// Token: 0x04001732 RID: 5938
		public float _AerosolAnisotropy;

		// Token: 0x04001733 RID: 5939
		public float _AerosolPhasePartConstant;

		// Token: 0x04001734 RID: 5940
		public float _Unused;

		// Token: 0x04001735 RID: 5941
		public float _AirDensityFalloff;

		// Token: 0x04001736 RID: 5942
		public float _AirScaleHeight;

		// Token: 0x04001737 RID: 5943
		public float _AerosolDensityFalloff;

		// Token: 0x04001738 RID: 5944
		public float _AerosolScaleHeight;

		// Token: 0x04001739 RID: 5945
		public Vector4 _AirSeaLevelExtinction;

		// Token: 0x0400173A RID: 5946
		public Vector4 _AirSeaLevelScattering;

		// Token: 0x0400173B RID: 5947
		public Vector4 _AerosolSeaLevelScattering;

		// Token: 0x0400173C RID: 5948
		public Vector4 _GroundAlbedo;

		// Token: 0x0400173D RID: 5949
		public Vector4 _PlanetCenterPosition;

		// Token: 0x0400173E RID: 5950
		public Vector4 _HorizonTint;

		// Token: 0x0400173F RID: 5951
		public Vector4 _ZenithTint;

		// Token: 0x04001740 RID: 5952
		public float _AerosolSeaLevelExtinction;

		// Token: 0x04001741 RID: 5953
		public float _IntensityMultiplier;

		// Token: 0x04001742 RID: 5954
		public float _ColorSaturation;

		// Token: 0x04001743 RID: 5955
		public float _AlphaSaturation;

		// Token: 0x04001744 RID: 5956
		public float _AlphaMultiplier;

		// Token: 0x04001745 RID: 5957
		public float _HorizonZenithShiftPower;

		// Token: 0x04001746 RID: 5958
		public float _HorizonZenithShiftScale;

		// Token: 0x04001747 RID: 5959
		public float _Unused2;
	}
}
