using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x020001AF RID: 431
	internal class EventCallbackListPool
	{
		// Token: 0x06000D1D RID: 3357 RVA: 0x000332EC File Offset: 0x000314EC
		public EventCallbackList Get(EventCallbackList initializer)
		{
			bool flag = this.m_Stack.Count == 0;
			EventCallbackList eventCallbackList;
			if (flag)
			{
				bool flag2 = initializer != null;
				if (flag2)
				{
					eventCallbackList = new EventCallbackList(initializer);
				}
				else
				{
					eventCallbackList = new EventCallbackList();
				}
			}
			else
			{
				eventCallbackList = this.m_Stack.Pop();
				bool flag3 = initializer != null;
				if (flag3)
				{
					eventCallbackList.AddRange(initializer);
				}
			}
			return eventCallbackList;
		}

		// Token: 0x06000D1E RID: 3358 RVA: 0x0003334C File Offset: 0x0003154C
		public void Release(EventCallbackList element)
		{
			element.Clear();
			this.m_Stack.Push(element);
		}

		// Token: 0x04000639 RID: 1593
		private readonly Stack<EventCallbackList> m_Stack = new Stack<EventCallbackList>();
	}
}
