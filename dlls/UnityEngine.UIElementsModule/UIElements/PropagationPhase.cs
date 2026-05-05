using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001CE RID: 462
	public enum PropagationPhase
	{
		// Token: 0x040006A2 RID: 1698
		None,
		// Token: 0x040006A3 RID: 1699
		TrickleDown,
		// Token: 0x040006A4 RID: 1700
		AtTarget,
		// Token: 0x040006A5 RID: 1701
		DefaultActionAtTarget = 5,
		// Token: 0x040006A6 RID: 1702
		BubbleUp = 3,
		// Token: 0x040006A7 RID: 1703
		DefaultAction
	}
}
