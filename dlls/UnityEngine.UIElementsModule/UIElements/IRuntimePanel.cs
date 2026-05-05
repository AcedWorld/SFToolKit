using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000253 RID: 595
	internal interface IRuntimePanel
	{
		// Token: 0x1700039F RID: 927
		// (get) Token: 0x06001112 RID: 4370
		PanelSettings panelSettings { get; }

		// Token: 0x170003A0 RID: 928
		// (get) Token: 0x06001113 RID: 4371
		// (set) Token: 0x06001114 RID: 4372
		GameObject selectableGameObject { get; set; }
	}
}
