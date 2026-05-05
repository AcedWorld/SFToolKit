using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020003FF RID: 1023
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
	public class EventInterestAttribute : Attribute
	{
		// Token: 0x060020D9 RID: 8409 RVA: 0x0007C443 File Offset: 0x0007A643
		public EventInterestAttribute(params Type[] eventTypes)
		{
			this.eventTypes = eventTypes;
		}

		// Token: 0x060020DA RID: 8410 RVA: 0x0007C45B File Offset: 0x0007A65B
		public EventInterestAttribute(EventInterestOptions interests)
		{
			this.categoryFlags = (EventCategoryFlags)interests;
		}

		// Token: 0x060020DB RID: 8411 RVA: 0x0007C45B File Offset: 0x0007A65B
		internal EventInterestAttribute(EventInterestOptionsInternal interests)
		{
			this.categoryFlags = (EventCategoryFlags)interests;
		}

		// Token: 0x04000DE4 RID: 3556
		internal Type[] eventTypes;

		// Token: 0x04000DE5 RID: 3557
		internal EventCategoryFlags categoryFlags = EventCategoryFlags.None;
	}
}
