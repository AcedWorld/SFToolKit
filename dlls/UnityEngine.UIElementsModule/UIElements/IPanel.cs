using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x02000292 RID: 658
	public interface IPanel : IDisposable
	{
		// Token: 0x170003C7 RID: 967
		// (get) Token: 0x0600124C RID: 4684
		VisualElement visualTree { get; }

		// Token: 0x170003C8 RID: 968
		// (get) Token: 0x0600124D RID: 4685
		EventDispatcher dispatcher { get; }

		// Token: 0x170003C9 RID: 969
		// (get) Token: 0x0600124E RID: 4686
		ContextType contextType { get; }

		// Token: 0x170003CA RID: 970
		// (get) Token: 0x0600124F RID: 4687
		FocusController focusController { get; }

		// Token: 0x06001250 RID: 4688
		VisualElement Pick(Vector2 point);

		// Token: 0x06001251 RID: 4689
		VisualElement PickAll(Vector2 point, List<VisualElement> picked);

		// Token: 0x170003CB RID: 971
		// (get) Token: 0x06001252 RID: 4690
		ContextualMenuManager contextualMenuManager { get; }

		// Token: 0x170003CC RID: 972
		// (get) Token: 0x06001253 RID: 4691
		bool isDirty { get; }
	}
}
