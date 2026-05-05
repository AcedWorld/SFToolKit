using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000BF RID: 191
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Lighting\\ScreenSpaceLighting\\ShaderVariablesAmbientOcclusion.cs", needAccessors = false, generateCBuffer = true)]
	internal struct ShaderVariablesAmbientOcclusion
	{
		// Token: 0x04000840 RID: 2112
		public Vector4 _AOBufferSize;

		// Token: 0x04000841 RID: 2113
		public Vector4 _AOParams0;

		// Token: 0x04000842 RID: 2114
		public Vector4 _AOParams1;

		// Token: 0x04000843 RID: 2115
		public Vector4 _AOParams2;

		// Token: 0x04000844 RID: 2116
		public Vector4 _AOParams3;

		// Token: 0x04000845 RID: 2117
		public Vector4 _AOParams4;

		// Token: 0x04000846 RID: 2118
		public Vector4 _FirstTwoDepthMipOffsets;

		// Token: 0x04000847 RID: 2119
		public Vector4 _AODepthToViewParams;
	}
}
