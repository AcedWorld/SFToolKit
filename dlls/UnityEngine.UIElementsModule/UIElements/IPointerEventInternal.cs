using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000217 RID: 535
	internal interface IPointerEventInternal
	{
		// Token: 0x17000349 RID: 841
		// (get) Token: 0x06000F8C RID: 3980
		// (set) Token: 0x06000F8D RID: 3981
		bool triggeredByOS { get; set; }

		// Token: 0x1700034A RID: 842
		// (get) Token: 0x06000F8E RID: 3982
		// (set) Token: 0x06000F8F RID: 3983
		bool recomputeTopElementUnderPointer { get; set; }
	}
}
