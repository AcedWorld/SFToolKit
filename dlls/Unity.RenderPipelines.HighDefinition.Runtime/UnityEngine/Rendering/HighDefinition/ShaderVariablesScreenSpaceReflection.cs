using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000C0 RID: 192
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Lighting\\ScreenSpaceLighting\\ShaderVariablesScreenSpaceReflection.cs", needAccessors = false, generateCBuffer = true)]
	internal struct ShaderVariablesScreenSpaceReflection
	{
		// Token: 0x04000848 RID: 2120
		public float _SsrThicknessScale;

		// Token: 0x04000849 RID: 2121
		public float _SsrThicknessBias;

		// Token: 0x0400084A RID: 2122
		public int _SsrStencilBit;

		// Token: 0x0400084B RID: 2123
		public int _SsrIterLimit;

		// Token: 0x0400084C RID: 2124
		public float _SsrRoughnessFadeEnd;

		// Token: 0x0400084D RID: 2125
		public float _SsrRoughnessFadeRcpLength;

		// Token: 0x0400084E RID: 2126
		public float _SsrRoughnessFadeEndTimesRcpLength;

		// Token: 0x0400084F RID: 2127
		public float _SsrEdgeFadeRcpLength;

		// Token: 0x04000850 RID: 2128
		public int _SsrDepthPyramidMaxMip;

		// Token: 0x04000851 RID: 2129
		public int _SsrColorPyramidMaxMip;

		// Token: 0x04000852 RID: 2130
		public int _SsrReflectsSky;

		// Token: 0x04000853 RID: 2131
		public float _SsrAccumulationAmount;

		// Token: 0x04000854 RID: 2132
		public float _SsrPBRSpeedRejection;

		// Token: 0x04000855 RID: 2133
		public float _SsrPBRBias;

		// Token: 0x04000856 RID: 2134
		public float _SsrPRBSpeedRejectionScalerFactor;

		// Token: 0x04000857 RID: 2135
		public float _SsrPBRPad0;
	}
}
