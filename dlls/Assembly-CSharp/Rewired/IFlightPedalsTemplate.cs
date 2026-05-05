using System;

namespace Rewired
{
	// Token: 0x0200026A RID: 618
	public interface IFlightPedalsTemplate : IControllerTemplate
	{
		// Token: 0x17000159 RID: 345
		// (get) Token: 0x06000AAF RID: 2735
		IControllerTemplateAxis leftPedal { get; }

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x06000AB0 RID: 2736
		IControllerTemplateAxis rightPedal { get; }

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x06000AB1 RID: 2737
		IControllerTemplateAxis slide { get; }
	}
}
