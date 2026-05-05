using System;
using UnityEngine;

namespace Rewired
{
	// Token: 0x0200008E RID: 142
	public interface IControllerTemplateHat : IControllerTemplateElement
	{
		// Token: 0x170001EA RID: 490
		// (get) Token: 0x060005ED RID: 1517
		Vector2 value { get; }

		// Token: 0x170001EB RID: 491
		// (get) Token: 0x060005EE RID: 1518
		Vector2 valuePrev { get; }

		// Token: 0x170001EC RID: 492
		// (get) Token: 0x060005EF RID: 1519
		IControllerTemplateButton up { get; }

		// Token: 0x170001ED RID: 493
		// (get) Token: 0x060005F0 RID: 1520
		IControllerTemplateButton upRight { get; }

		// Token: 0x170001EE RID: 494
		// (get) Token: 0x060005F1 RID: 1521
		IControllerTemplateButton right { get; }

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x060005F2 RID: 1522
		IControllerTemplateButton downRight { get; }

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x060005F3 RID: 1523
		IControllerTemplateButton down { get; }

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x060005F4 RID: 1524
		IControllerTemplateButton downLeft { get; }

		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x060005F5 RID: 1525
		IControllerTemplateButton left { get; }

		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x060005F6 RID: 1526
		IControllerTemplateButton upLeft { get; }
	}
}
