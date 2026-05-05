using System;
using System.Collections.Generic;

namespace Rewired
{
	// Token: 0x02000086 RID: 134
	public interface IControllerTemplate
	{
		// Token: 0x170001BC RID: 444
		// (get) Token: 0x060005BB RID: 1467
		Controller controller { get; }

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x060005BC RID: 1468
		string name { get; }

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x060005BD RID: 1469
		Guid typeGuid { get; }

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x060005BE RID: 1470
		IList<IControllerTemplateElement> elements { get; }

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x060005BF RID: 1471
		int elementCount { get; }

		// Token: 0x060005C0 RID: 1472
		IControllerTemplateElement GetElement(int id);

		// Token: 0x060005C1 RID: 1473
		T GetElement<T>(int id) where T : class, IControllerTemplateElement;

		// Token: 0x060005C2 RID: 1474
		int GetElementTargets(ControllerElementTarget target, IList<ControllerTemplateElementTarget> results);
	}
}
