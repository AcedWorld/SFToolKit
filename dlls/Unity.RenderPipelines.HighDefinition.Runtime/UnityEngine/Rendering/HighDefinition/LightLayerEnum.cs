using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000075 RID: 117
	[Flags]
	public enum LightLayerEnum
	{
		// Token: 0x0400058B RID: 1419
		Nothing = 0,
		// Token: 0x0400058C RID: 1420
		LightLayerDefault = 1,
		// Token: 0x0400058D RID: 1421
		LightLayer1 = 2,
		// Token: 0x0400058E RID: 1422
		LightLayer2 = 4,
		// Token: 0x0400058F RID: 1423
		LightLayer3 = 8,
		// Token: 0x04000590 RID: 1424
		LightLayer4 = 16,
		// Token: 0x04000591 RID: 1425
		LightLayer5 = 32,
		// Token: 0x04000592 RID: 1426
		LightLayer6 = 64,
		// Token: 0x04000593 RID: 1427
		LightLayer7 = 128,
		// Token: 0x04000594 RID: 1428
		Everything = 255
	}
}
