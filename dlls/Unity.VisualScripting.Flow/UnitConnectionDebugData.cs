using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000009 RID: 9
	public class UnitConnectionDebugData : IUnitConnectionDebugData, IGraphElementDebugData
	{
		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000039 RID: 57 RVA: 0x0000264D File Offset: 0x0000084D
		// (set) Token: 0x0600003A RID: 58 RVA: 0x00002655 File Offset: 0x00000855
		public int lastInvokeFrame { get; set; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600003B RID: 59 RVA: 0x0000265E File Offset: 0x0000085E
		// (set) Token: 0x0600003C RID: 60 RVA: 0x00002666 File Offset: 0x00000866
		public float lastInvokeTime { get; set; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600003D RID: 61 RVA: 0x0000266F File Offset: 0x0000086F
		// (set) Token: 0x0600003E RID: 62 RVA: 0x00002677 File Offset: 0x00000877
		public Exception runtimeException { get; set; }
	}
}
