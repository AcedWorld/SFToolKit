using System;

namespace UnityEngine.Rendering
{
	// Token: 0x020000A8 RID: 168
	public enum ShaderVariantLogLevel
	{
		// Token: 0x040003C9 RID: 969
		[Tooltip("No shader variants are logged")]
		Disabled,
		// Token: 0x040003CA RID: 970
		[Tooltip("Only shaders that are compatible with SRPs (e.g., URP, HDRP) are logged")]
		OnlySRPShaders,
		// Token: 0x040003CB RID: 971
		[Tooltip("All shader variants are logged")]
		AllShaders
	}
}
