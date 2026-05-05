using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000092 RID: 146
	[Obsolete("The texture resolution limit in volumetric fogs have been removed. This enum is unused.")]
	[Serializable]
	public enum LocalVolumetricFogResolution
	{
		// Token: 0x040006D4 RID: 1748
		[InspectorName("32x32x32")]
		Resolution32 = 32,
		// Token: 0x040006D5 RID: 1749
		[InspectorName("64x64x64")]
		Resolution64 = 64,
		// Token: 0x040006D6 RID: 1750
		[InspectorName("128x128x128")]
		Resolution128 = 128,
		// Token: 0x040006D7 RID: 1751
		[InspectorName("256x256x256")]
		Resolution256 = 256
	}
}
