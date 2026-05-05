using System;

namespace Rewired
{
	// Token: 0x0200008D RID: 141
	public interface IControllerTemplateThrottle : IControllerTemplateElement
	{
		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x060005E9 RID: 1513
		float value { get; }

		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x060005EA RID: 1514
		float valuePrev { get; }

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x060005EB RID: 1515
		IControllerTemplateAxis throttle { get; }

		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x060005EC RID: 1516
		IControllerTemplateButton minDetent { get; }
	}
}
