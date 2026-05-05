using System;

namespace UnityEngine.Rendering.HighDefinition.Compositor
{
	// Token: 0x0200023F RID: 575
	[Serializable]
	internal class CompositionFilter
	{
		// Token: 0x06001027 RID: 4135 RVA: 0x0007CCC7 File Offset: 0x0007AEC7
		public static CompositionFilter Create(CompositionFilter.FilterType type)
		{
			return new CompositionFilter
			{
				filterType = type
			};
		}

		// Token: 0x0400197E RID: 6526
		public CompositionFilter.FilterType filterType;

		// Token: 0x0400197F RID: 6527
		public Color maskColor;

		// Token: 0x04001980 RID: 6528
		public float keyThreshold = 0.8f;

		// Token: 0x04001981 RID: 6529
		public float keyTolerance = 0.5f;

		// Token: 0x04001982 RID: 6530
		[Range(0f, 1f)]
		public float spillRemoval;

		// Token: 0x04001983 RID: 6531
		public Texture alphaMask;

		// Token: 0x02000455 RID: 1109
		public enum FilterType
		{
			// Token: 0x040029D6 RID: 10710
			CHROMA_KEYING,
			// Token: 0x040029D7 RID: 10711
			ALPHA_MASK
		}
	}
}
