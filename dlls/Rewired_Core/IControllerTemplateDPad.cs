using System;
using UnityEngine;

namespace Rewired
{
	// Token: 0x0200008C RID: 140
	public interface IControllerTemplateDPad : IControllerTemplateElement
	{
		// Token: 0x170001DF RID: 479
		// (get) Token: 0x060005E2 RID: 1506
		Vector2 value { get; }

		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x060005E3 RID: 1507
		Vector2 valuePrev { get; }

		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x060005E4 RID: 1508
		IControllerTemplateButton up { get; }

		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x060005E5 RID: 1509
		IControllerTemplateButton right { get; }

		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x060005E6 RID: 1510
		IControllerTemplateButton down { get; }

		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x060005E7 RID: 1511
		IControllerTemplateButton left { get; }

		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x060005E8 RID: 1512
		IControllerTemplateButton press { get; }
	}
}
