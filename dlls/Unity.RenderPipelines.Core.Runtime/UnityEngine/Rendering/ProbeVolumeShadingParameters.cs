using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000087 RID: 135
	public struct ProbeVolumeShadingParameters
	{
		// Token: 0x04000291 RID: 657
		public float normalBias;

		// Token: 0x04000292 RID: 658
		public float viewBias;

		// Token: 0x04000293 RID: 659
		public bool scaleBiasByMinDistanceBetweenProbes;

		// Token: 0x04000294 RID: 660
		public float samplingNoise;

		// Token: 0x04000295 RID: 661
		public float weight;

		// Token: 0x04000296 RID: 662
		public APVLeakReductionMode leakReductionMode;

		// Token: 0x04000297 RID: 663
		public float occlusionWeightContribution;

		// Token: 0x04000298 RID: 664
		public float minValidNormalWeight;

		// Token: 0x04000299 RID: 665
		public int frameIndexForNoise;

		// Token: 0x0400029A RID: 666
		public float reflNormalizationLowerClamp;

		// Token: 0x0400029B RID: 667
		public float reflNormalizationUpperClamp;
	}
}
