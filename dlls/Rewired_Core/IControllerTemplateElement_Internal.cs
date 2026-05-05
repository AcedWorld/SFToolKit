using System;
using System.Collections.Generic;

namespace Rewired
{
	// Token: 0x02000097 RID: 151
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	internal interface IControllerTemplateElement_Internal
	{
		// Token: 0x1700021B RID: 539
		// (get) Token: 0x0600061E RID: 1566
		IControllerTemplate parent { get; }

		// Token: 0x1700021C RID: 540
		// (get) Token: 0x0600061F RID: 1567
		int elementCount { get; }

		// Token: 0x06000620 RID: 1568
		IControllerTemplateElement GetElement(int index);

		// Token: 0x06000621 RID: 1569
		int GetElementTargets(ControllerElementTarget find, ref IList<ControllerTemplateElementTarget> list);
	}
}
