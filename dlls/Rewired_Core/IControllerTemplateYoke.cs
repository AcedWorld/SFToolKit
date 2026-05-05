using System;
using UnityEngine;

namespace Rewired
{
	// Token: 0x0200008F RID: 143
	public interface IControllerTemplateYoke : IControllerTemplateElement
	{
		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x060005F7 RID: 1527
		Vector2 value { get; }

		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x060005F8 RID: 1528
		Vector2 valuePrev { get; }

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x060005F9 RID: 1529
		IControllerTemplateAxis rotation { get; }

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x060005FA RID: 1530
		IControllerTemplateAxis pushPull { get; }
	}
}
