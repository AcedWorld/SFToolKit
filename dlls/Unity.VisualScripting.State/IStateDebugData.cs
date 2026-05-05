using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200000A RID: 10
	public interface IStateDebugData : IGraphElementDebugData
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600002E RID: 46
		int lastEnterFrame { get; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600002F RID: 47
		float lastExitTime { get; }
	}
}
