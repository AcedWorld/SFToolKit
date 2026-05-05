using System;
using UnityEngine;

namespace Rewired
{
	// Token: 0x0200008A RID: 138
	public interface IControllerTemplateStick : IControllerTemplateElement
	{
		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x060005D8 RID: 1496
		Vector3 value { get; }

		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x060005D9 RID: 1497
		Vector3 valuePrev { get; }

		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x060005DA RID: 1498
		IControllerTemplateAxis horizontal { get; }

		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x060005DB RID: 1499
		IControllerTemplateAxis vertical { get; }

		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x060005DC RID: 1500
		IControllerTemplateAxis rotation { get; }
	}
}
