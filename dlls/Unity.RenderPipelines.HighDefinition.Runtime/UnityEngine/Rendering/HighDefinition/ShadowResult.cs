using System;
using UnityEngine.Experimental.Rendering.RenderGraphModule;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000D2 RID: 210
	internal struct ShadowResult
	{
		// Token: 0x04000905 RID: 2309
		public TextureHandle punctualShadowResult;

		// Token: 0x04000906 RID: 2310
		public TextureHandle cachedPunctualShadowResult;

		// Token: 0x04000907 RID: 2311
		public TextureHandle directionalShadowResult;

		// Token: 0x04000908 RID: 2312
		public TextureHandle areaShadowResult;

		// Token: 0x04000909 RID: 2313
		public TextureHandle cachedAreaShadowResult;
	}
}
