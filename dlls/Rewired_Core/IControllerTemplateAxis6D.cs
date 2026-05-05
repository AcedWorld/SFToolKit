using System;
using UnityEngine;

namespace Rewired
{
	// Token: 0x02000096 RID: 150
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	internal interface IControllerTemplateAxis6D : IControllerTemplateElement
	{
		// Token: 0x17000211 RID: 529
		// (get) Token: 0x06000614 RID: 1556
		Vector3 position { get; }

		// Token: 0x17000212 RID: 530
		// (get) Token: 0x06000615 RID: 1557
		Vector3 positionPrev { get; }

		// Token: 0x17000213 RID: 531
		// (get) Token: 0x06000616 RID: 1558
		Vector3 rotation { get; }

		// Token: 0x17000214 RID: 532
		// (get) Token: 0x06000617 RID: 1559
		Vector3 rotationPrev { get; }

		// Token: 0x17000215 RID: 533
		// (get) Token: 0x06000618 RID: 1560
		IControllerTemplateAxis positionX { get; }

		// Token: 0x17000216 RID: 534
		// (get) Token: 0x06000619 RID: 1561
		IControllerTemplateAxis positionY { get; }

		// Token: 0x17000217 RID: 535
		// (get) Token: 0x0600061A RID: 1562
		IControllerTemplateAxis positionZ { get; }

		// Token: 0x17000218 RID: 536
		// (get) Token: 0x0600061B RID: 1563
		IControllerTemplateAxis rotationX { get; }

		// Token: 0x17000219 RID: 537
		// (get) Token: 0x0600061C RID: 1564
		IControllerTemplateAxis rotationY { get; }

		// Token: 0x1700021A RID: 538
		// (get) Token: 0x0600061D RID: 1565
		IControllerTemplateAxis rotationZ { get; }
	}
}
