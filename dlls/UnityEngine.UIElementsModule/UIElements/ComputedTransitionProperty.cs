using System;
using UnityEngine.UIElements.StyleSheets;

namespace UnityEngine.UIElements
{
	// Token: 0x020002C8 RID: 712
	internal struct ComputedTransitionProperty
	{
		// Token: 0x0400099B RID: 2459
		public StylePropertyId id;

		// Token: 0x0400099C RID: 2460
		public int durationMs;

		// Token: 0x0400099D RID: 2461
		public int delayMs;

		// Token: 0x0400099E RID: 2462
		public Func<float, float> easingCurve;
	}
}
