using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200018D RID: 397
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\RenderPipeline\\Raytracing\\Shaders\\ShaderVariablesRaytracingLightLoop.cs", needAccessors = false, generateCBuffer = true, constantRegister = 4)]
	internal struct ShaderVariablesRaytracingLightLoop
	{
		// Token: 0x04001394 RID: 5012
		public Vector3 _MinClusterPos;

		// Token: 0x04001395 RID: 5013
		public uint _LightPerCellCount;

		// Token: 0x04001396 RID: 5014
		public Vector3 _MaxClusterPos;

		// Token: 0x04001397 RID: 5015
		public uint _PunctualLightCountRT;

		// Token: 0x04001398 RID: 5016
		public uint _AreaLightCountRT;

		// Token: 0x04001399 RID: 5017
		public uint _EnvLightCountRT;
	}
}
