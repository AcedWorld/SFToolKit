using System;
using UnityEngine;

namespace Rewired
{
	// Token: 0x02000090 RID: 144
	public interface IControllerTemplateStick6D : IControllerTemplateElement
	{
		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x060005FB RID: 1531
		Vector3 position { get; }

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x060005FC RID: 1532
		Vector3 positionPrev { get; }

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x060005FD RID: 1533
		Vector3 rotation { get; }

		// Token: 0x170001FB RID: 507
		// (get) Token: 0x060005FE RID: 1534
		Vector3 rotationPrev { get; }

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x060005FF RID: 1535
		IControllerTemplateAxis positionX { get; }

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x06000600 RID: 1536
		IControllerTemplateAxis positionY { get; }

		// Token: 0x170001FE RID: 510
		// (get) Token: 0x06000601 RID: 1537
		IControllerTemplateAxis positionZ { get; }

		// Token: 0x170001FF RID: 511
		// (get) Token: 0x06000602 RID: 1538
		IControllerTemplateAxis rotationX { get; }

		// Token: 0x17000200 RID: 512
		// (get) Token: 0x06000603 RID: 1539
		IControllerTemplateAxis rotationY { get; }

		// Token: 0x17000201 RID: 513
		// (get) Token: 0x06000604 RID: 1540
		IControllerTemplateAxis rotationZ { get; }
	}
}
