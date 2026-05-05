using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200015B RID: 347
	public interface IUnitDebugData : IGraphElementDebugData
	{
		// Token: 0x17000312 RID: 786
		// (get) Token: 0x06000903 RID: 2307
		// (set) Token: 0x06000904 RID: 2308
		int lastInvokeFrame { get; set; }

		// Token: 0x17000313 RID: 787
		// (get) Token: 0x06000905 RID: 2309
		// (set) Token: 0x06000906 RID: 2310
		float lastInvokeTime { get; set; }
	}
}
