using System;

namespace Rewired
{
	// Token: 0x020000DF RID: 223
	public interface IControllerElementTarget
	{
		// Token: 0x1700027F RID: 639
		// (get) Token: 0x06000748 RID: 1864
		int elementIdentifierId { get; }

		// Token: 0x17000280 RID: 640
		// (get) Token: 0x06000749 RID: 1865
		AxisRange axisRange { get; }

		// Token: 0x17000281 RID: 641
		// (get) Token: 0x0600074A RID: 1866
		bool hasTarget { get; }

		// Token: 0x17000282 RID: 642
		// (get) Token: 0x0600074B RID: 1867
		ControllerElementType elementType { get; }

		// Token: 0x17000283 RID: 643
		// (get) Token: 0x0600074C RID: 1868
		string descriptiveName { get; }

		// Token: 0x17000284 RID: 644
		// (get) Token: 0x0600074D RID: 1869
		Controller controller { get; }

		// Token: 0x17000285 RID: 645
		// (get) Token: 0x0600074E RID: 1870
		Controller.Element element { get; }
	}
}
