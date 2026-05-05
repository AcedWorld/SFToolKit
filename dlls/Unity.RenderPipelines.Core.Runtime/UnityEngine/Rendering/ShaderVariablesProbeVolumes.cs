using System;

namespace UnityEngine.Rendering
{
	// Token: 0x0200009A RID: 154
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.core@14.0.11\\Runtime\\Lighting\\ProbeVolume\\ShaderVariablesProbeVolumes.cs", needAccessors = false, generateCBuffer = true, constantRegister = 5)]
	internal struct ShaderVariablesProbeVolumes
	{
		// Token: 0x0400035A RID: 858
		public Vector4 _PoolDim_CellInMeters;

		// Token: 0x0400035B RID: 859
		public Vector4 _MinCellPos_Noise;

		// Token: 0x0400035C RID: 860
		public Vector4 _IndicesDim_IndexChunkSize;

		// Token: 0x0400035D RID: 861
		public Vector4 _Biases_CellInMinBrick_MinBrickSize;

		// Token: 0x0400035E RID: 862
		public Vector4 _LeakReductionParams;

		// Token: 0x0400035F RID: 863
		public Vector4 _Weight_MinLoadedCell;

		// Token: 0x04000360 RID: 864
		public Vector4 _MaxLoadedCell_FrameIndex;

		// Token: 0x04000361 RID: 865
		public Vector4 _NormalizationClamp_Padding12;
	}
}
