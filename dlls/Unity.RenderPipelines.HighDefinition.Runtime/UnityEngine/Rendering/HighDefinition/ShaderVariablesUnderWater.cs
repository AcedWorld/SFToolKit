using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200022A RID: 554
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Water\\WaterSystemDef.cs", needAccessors = false, generateCBuffer = true)]
	internal struct ShaderVariablesUnderWater
	{
		// Token: 0x04001943 RID: 6467
		public Vector4 _WaterRefractionColor;

		// Token: 0x04001944 RID: 6468
		public Vector4 _WaterScatteringColor;

		// Token: 0x04001945 RID: 6469
		public float _MaxViewDistanceMultiplier;

		// Token: 0x04001946 RID: 6470
		public float _OutScatteringCoeff;

		// Token: 0x04001947 RID: 6471
		public float _WaterTransitionSize;

		// Token: 0x04001948 RID: 6472
		public float _PaddingUW;
	}
}
