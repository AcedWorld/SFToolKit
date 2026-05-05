using System;

namespace UnityEngine.UIElements.UIR
{
	// Token: 0x02000470 RID: 1136
	internal class VectorImageRenderInfo : LinkedPoolItem<VectorImageRenderInfo>
	{
		// Token: 0x06002338 RID: 9016 RVA: 0x00088D00 File Offset: 0x00086F00
		public void Reset()
		{
			this.useCount = 0;
			this.firstGradientRemap = null;
			this.gradientSettingsAlloc = default(Alloc);
		}

		// Token: 0x0400105D RID: 4189
		public int useCount;

		// Token: 0x0400105E RID: 4190
		public GradientRemap firstGradientRemap;

		// Token: 0x0400105F RID: 4191
		public Alloc gradientSettingsAlloc;
	}
}
