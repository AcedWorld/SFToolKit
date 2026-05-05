using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000006 RID: 6
	public interface IUnitConnectionDebugData : IGraphElementDebugData
	{
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000022 RID: 34
		// (set) Token: 0x06000023 RID: 35
		int lastInvokeFrame { get; set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000024 RID: 36
		// (set) Token: 0x06000025 RID: 37
		float lastInvokeTime { get; set; }
	}
}
