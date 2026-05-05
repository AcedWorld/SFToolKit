using System;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine.UIElements
{
	// Token: 0x02000243 RID: 579
	[MovedFrom(true, "UnityEditor.UIElements", "UnityEditor.UIElementsModule", null)]
	public abstract class BaseFieldMouseDragger
	{
		// Token: 0x06001069 RID: 4201 RVA: 0x0003B6CA File Offset: 0x000398CA
		public void SetDragZone(VisualElement dragElement)
		{
			this.SetDragZone(dragElement, new Rect(0f, 0f, -1f, -1f));
		}

		// Token: 0x0600106A RID: 4202
		public abstract void SetDragZone(VisualElement dragElement, Rect hotZone);
	}
}
