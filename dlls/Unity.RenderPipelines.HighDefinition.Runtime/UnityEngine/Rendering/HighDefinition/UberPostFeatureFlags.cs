using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000150 RID: 336
	[Flags]
	internal enum UberPostFeatureFlags
	{
		// Token: 0x04000C16 RID: 3094
		None = 0,
		// Token: 0x04000C17 RID: 3095
		ChromaticAberration = 1,
		// Token: 0x04000C18 RID: 3096
		Vignette = 2,
		// Token: 0x04000C19 RID: 3097
		LensDistortion = 4,
		// Token: 0x04000C1A RID: 3098
		EnableAlpha = 8
	}
}
