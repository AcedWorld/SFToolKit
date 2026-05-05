using System;
using UnityEngine;

namespace Rewired
{
	// Token: 0x0200008B RID: 139
	public interface IControllerTemplateThumbStick : IControllerTemplateElement
	{
		// Token: 0x170001DA RID: 474
		// (get) Token: 0x060005DD RID: 1501
		Vector2 value { get; }

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x060005DE RID: 1502
		Vector2 valuePrev { get; }

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x060005DF RID: 1503
		IControllerTemplateAxis horizontal { get; }

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x060005E0 RID: 1504
		IControllerTemplateAxis vertical { get; }

		// Token: 0x170001DE RID: 478
		// (get) Token: 0x060005E1 RID: 1505
		IControllerTemplateButton press { get; }
	}
}
