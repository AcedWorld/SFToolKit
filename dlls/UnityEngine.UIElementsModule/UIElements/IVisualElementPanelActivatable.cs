using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200040A RID: 1034
	internal interface IVisualElementPanelActivatable
	{
		// Token: 0x170007A9 RID: 1961
		// (get) Token: 0x06002107 RID: 8455
		VisualElement element { get; }

		// Token: 0x06002108 RID: 8456
		bool CanBeActivated();

		// Token: 0x06002109 RID: 8457
		void OnPanelActivate();

		// Token: 0x0600210A RID: 8458
		void OnPanelDeactivate();
	}
}
