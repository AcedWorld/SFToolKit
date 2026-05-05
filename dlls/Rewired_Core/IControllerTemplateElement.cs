using System;

namespace Rewired
{
	// Token: 0x02000087 RID: 135
	public interface IControllerTemplateElement
	{
		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x060005C3 RID: 1475
		int id { get; }

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x060005C4 RID: 1476
		string descriptiveName { get; }

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x060005C5 RID: 1477
		ControllerTemplateElementType type { get; }

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x060005C6 RID: 1478
		bool exists { get; }

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x060005C7 RID: 1479
		IControllerTemplateElementSource source { get; }
	}
}
