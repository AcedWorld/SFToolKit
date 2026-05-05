using System;
using UnityEngine;

namespace Rewired
{
	// Token: 0x02000094 RID: 148
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	internal interface IControllerTemplateAxis2D : IControllerTemplateElement
	{
		// Token: 0x17000208 RID: 520
		// (get) Token: 0x0600060B RID: 1547
		Vector2 value { get; }

		// Token: 0x17000209 RID: 521
		// (get) Token: 0x0600060C RID: 1548
		Vector2 valuePrev { get; }

		// Token: 0x1700020A RID: 522
		// (get) Token: 0x0600060D RID: 1549
		IControllerTemplateAxis horizontal { get; }

		// Token: 0x1700020B RID: 523
		// (get) Token: 0x0600060E RID: 1550
		IControllerTemplateAxis vertical { get; }
	}
}
