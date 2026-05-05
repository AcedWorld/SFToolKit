using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000231 RID: 561
	[EventCategory(EventCategory.Style)]
	public class CustomStyleResolvedEvent : EventBase<CustomStyleResolvedEvent>
	{
		// Token: 0x06001026 RID: 4134 RVA: 0x0003B25C File Offset: 0x0003945C
		static CustomStyleResolvedEvent()
		{
			EventBase<CustomStyleResolvedEvent>.SetCreateFunction(() => new CustomStyleResolvedEvent());
		}

		// Token: 0x17000368 RID: 872
		// (get) Token: 0x06001027 RID: 4135 RVA: 0x0003B278 File Offset: 0x00039478
		public ICustomStyle customStyle
		{
			get
			{
				VisualElement visualElement = base.target as VisualElement;
				return (visualElement != null) ? visualElement.customStyle : null;
			}
		}
	}
}
