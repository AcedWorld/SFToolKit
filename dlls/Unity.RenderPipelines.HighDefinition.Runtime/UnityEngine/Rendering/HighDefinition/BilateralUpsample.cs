using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000B4 RID: 180
	internal class BilateralUpsample
	{
		// Token: 0x040007F1 RID: 2033
		internal static float[] distanceBasedWeights_3x3 = new float[]
		{
			0.324652f,
			0.535261f,
			0.119433f,
			0.535261f,
			0.882497f,
			0.196912f,
			0.119433f,
			0.196912f,
			0.0439369f,
			0.119433f,
			0.535261f,
			0.324652f,
			0.196912f,
			0.882497f,
			0.535261f,
			0.0439369f,
			0.196912f,
			0.119433f,
			0.119433f,
			0.196912f,
			0.0439369f,
			0.535261f,
			0.882497f,
			0.196912f,
			0.324652f,
			0.535261f,
			0.119433f,
			0.0439369f,
			0.196912f,
			0.119433f,
			0.196912f,
			0.882497f,
			0.535261f,
			0.119433f,
			0.535261f,
			0.324652f
		};

		// Token: 0x040007F2 RID: 2034
		internal static float[] distanceBasedWeights_2x2 = new float[]
		{
			0.324652f,
			0.535261f,
			0.535261f,
			0.882497f,
			0.535261f,
			0.324652f,
			0.882497f,
			0.535261f,
			0.535261f,
			0.882497f,
			0.324652f,
			0.535261f,
			0.882497f,
			0.535261f,
			0.535261f,
			0.324652f
		};

		// Token: 0x040007F3 RID: 2035
		internal static float[] tapOffsets_2x2 = new float[]
		{
			-1f,
			-1f,
			0f,
			-1f,
			-1f,
			0f,
			0f,
			0f,
			0f,
			-1f,
			1f,
			-1f,
			0f,
			0f,
			1f,
			0f,
			-1f,
			0f,
			0f,
			0f,
			-1f,
			1f,
			0f,
			1f,
			0f,
			0f,
			1f,
			0f,
			0f,
			1f,
			1f,
			1f
		};
	}
}
