using System;

namespace UnityEngine.Rendering
{
	// Token: 0x020000A9 RID: 169
	public interface IShaderVariantSettings
	{
		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x0600054E RID: 1358
		// (set) Token: 0x0600054F RID: 1359
		ShaderVariantLogLevel shaderVariantLogLevel { get; set; }

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x06000550 RID: 1360
		// (set) Token: 0x06000551 RID: 1361
		bool exportShaderVariants { get; set; }
	}
}
