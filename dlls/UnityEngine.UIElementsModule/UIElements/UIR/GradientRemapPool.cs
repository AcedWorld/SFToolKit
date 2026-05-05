using System;

namespace UnityEngine.UIElements.UIR
{
	// Token: 0x02000471 RID: 1137
	internal class GradientRemapPool : LinkedPool<GradientRemap>
	{
		// Token: 0x0600233A RID: 9018 RVA: 0x00088D28 File Offset: 0x00086F28
		public GradientRemapPool() : base(() => new GradientRemap(), delegate(GradientRemap gradientRemap)
		{
			gradientRemap.Reset();
		}, 10000)
		{
		}
	}
}
