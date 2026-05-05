using System;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x02000054 RID: 84
	public class EventHookComparer : IEqualityComparer<EventHook>
	{
		// Token: 0x0600026E RID: 622 RVA: 0x0000628B File Offset: 0x0000448B
		public bool Equals(EventHook x, EventHook y)
		{
			return x.Equals(y);
		}

		// Token: 0x0600026F RID: 623 RVA: 0x00006295 File Offset: 0x00004495
		public int GetHashCode(EventHook obj)
		{
			return obj.GetHashCode();
		}
	}
}
