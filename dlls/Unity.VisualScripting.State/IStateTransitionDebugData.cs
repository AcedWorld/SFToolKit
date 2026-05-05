using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200000C RID: 12
	public interface IStateTransitionDebugData : IGraphElementDebugData
	{
		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000033 RID: 51
		int lastBranchFrame { get; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000034 RID: 52
		float lastBranchTime { get; }
	}
}
