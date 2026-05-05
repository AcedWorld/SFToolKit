using System;

namespace Rewired
{
	// Token: 0x02000088 RID: 136
	public interface IControllerTemplateButton : IControllerTemplateElement
	{
		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x060005C8 RID: 1480
		bool value { get; }

		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x060005C9 RID: 1481
		bool valuePrev { get; }

		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x060005CA RID: 1482
		float pressure { get; }

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x060005CB RID: 1483
		float pressurePrev { get; }

		// Token: 0x170001CA RID: 458
		// (get) Token: 0x060005CC RID: 1484
		bool justPressed { get; }

		// Token: 0x170001CB RID: 459
		// (get) Token: 0x060005CD RID: 1485
		bool justReleased { get; }

		// Token: 0x170001CC RID: 460
		// (get) Token: 0x060005CE RID: 1486
		bool justChangedState { get; }

		// Token: 0x170001CD RID: 461
		// (get) Token: 0x060005CF RID: 1487
		IControllerTemplateButtonSource source { get; }

		// Token: 0x170001CE RID: 462
		// (get) Token: 0x060005D0 RID: 1488
		IControllerTemplateAxis AsAxis { get; }
	}
}
