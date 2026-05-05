using System;
using UnityEngine;

namespace Rewired
{
	// Token: 0x02000095 RID: 149
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	internal interface IControllerTemplateAxis3D : IControllerTemplateElement
	{
		// Token: 0x1700020C RID: 524
		// (get) Token: 0x0600060F RID: 1551
		Vector3 value { get; }

		// Token: 0x1700020D RID: 525
		// (get) Token: 0x06000610 RID: 1552
		Vector3 valuePrev { get; }

		// Token: 0x1700020E RID: 526
		// (get) Token: 0x06000611 RID: 1553
		IControllerTemplateAxis horizontal { get; }

		// Token: 0x1700020F RID: 527
		// (get) Token: 0x06000612 RID: 1554
		IControllerTemplateAxis vertical { get; }

		// Token: 0x17000210 RID: 528
		// (get) Token: 0x06000613 RID: 1555
		IControllerTemplateAxis depth { get; }
	}
}
