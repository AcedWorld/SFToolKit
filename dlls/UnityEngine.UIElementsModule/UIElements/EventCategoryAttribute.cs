using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000400 RID: 1024
	[AttributeUsage(AttributeTargets.Class)]
	internal class EventCategoryAttribute : Attribute
	{
		// Token: 0x060020DC RID: 8412 RVA: 0x0007C473 File Offset: 0x0007A673
		public EventCategoryAttribute(EventCategory category)
		{
			this.category = category;
		}

		// Token: 0x04000DE6 RID: 3558
		internal EventCategory category;
	}
}
