using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200004C RID: 76
	[Serializable]
	public class MipMapDebugSettings
	{
		// Token: 0x0600023E RID: 574 RVA: 0x0000D522 File Offset: 0x0000B722
		public bool IsDebugDisplayEnabled()
		{
			return this.debugMipMapMode > DebugMipMapMode.None;
		}

		// Token: 0x0400022E RID: 558
		public DebugMipMapMode debugMipMapMode;

		// Token: 0x0400022F RID: 559
		public DebugMipMapModeTerrainTexture terrainTexture;
	}
}
