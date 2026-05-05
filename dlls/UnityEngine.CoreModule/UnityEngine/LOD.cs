using System;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x020001C3 RID: 451
	[UsedByNativeCode]
	public struct LOD
	{
		// Token: 0x0600103E RID: 4158 RVA: 0x00015E8D File Offset: 0x0001408D
		public LOD(float screenRelativeTransitionHeight, Renderer[] renderers)
		{
			this.screenRelativeTransitionHeight = screenRelativeTransitionHeight;
			this.fadeTransitionWidth = 0f;
			this.renderers = renderers;
		}

		// Token: 0x04000639 RID: 1593
		public float screenRelativeTransitionHeight;

		// Token: 0x0400063A RID: 1594
		public float fadeTransitionWidth;

		// Token: 0x0400063B RID: 1595
		public Renderer[] renderers;
	}
}
