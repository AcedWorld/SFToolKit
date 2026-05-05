using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x020001B0 RID: 432
	internal class EventCallbackList
	{
		// Token: 0x170002A6 RID: 678
		// (get) Token: 0x06000D20 RID: 3360 RVA: 0x00033377 File Offset: 0x00031577
		// (set) Token: 0x06000D21 RID: 3361 RVA: 0x0003337F File Offset: 0x0003157F
		public int trickleDownCallbackCount { get; private set; }

		// Token: 0x170002A7 RID: 679
		// (get) Token: 0x06000D22 RID: 3362 RVA: 0x00033388 File Offset: 0x00031588
		// (set) Token: 0x06000D23 RID: 3363 RVA: 0x00033390 File Offset: 0x00031590
		public int bubbleUpCallbackCount { get; private set; }

		// Token: 0x06000D24 RID: 3364 RVA: 0x00033399 File Offset: 0x00031599
		public EventCallbackList()
		{
			this.m_List = new List<EventCallbackFunctorBase>();
			this.trickleDownCallbackCount = 0;
			this.bubbleUpCallbackCount = 0;
		}

		// Token: 0x06000D25 RID: 3365 RVA: 0x000333BE File Offset: 0x000315BE
		public EventCallbackList(EventCallbackList source)
		{
			this.m_List = new List<EventCallbackFunctorBase>(source.m_List);
			this.trickleDownCallbackCount = 0;
			this.bubbleUpCallbackCount = 0;
		}

		// Token: 0x06000D26 RID: 3366 RVA: 0x000333EC File Offset: 0x000315EC
		public bool Contains(long eventTypeId, Delegate callback, CallbackPhase phase)
		{
			return this.Find(eventTypeId, callback, phase) != null;
		}

		// Token: 0x06000D27 RID: 3367 RVA: 0x0003340C File Offset: 0x0003160C
		public EventCallbackFunctorBase Find(long eventTypeId, Delegate callback, CallbackPhase phase)
		{
			for (int i = 0; i < this.m_List.Count; i++)
			{
				bool flag = this.m_List[i].IsEquivalentTo(eventTypeId, callback, phase);
				if (flag)
				{
					return this.m_List[i];
				}
			}
			return null;
		}

		// Token: 0x06000D28 RID: 3368 RVA: 0x00033464 File Offset: 0x00031664
		public bool Remove(long eventTypeId, Delegate callback, CallbackPhase phase)
		{
			for (int i = 0; i < this.m_List.Count; i++)
			{
				bool flag = this.m_List[i].IsEquivalentTo(eventTypeId, callback, phase);
				if (flag)
				{
					this.m_List.RemoveAt(i);
					bool flag2 = phase == CallbackPhase.TrickleDownAndTarget;
					if (flag2)
					{
						int num = this.trickleDownCallbackCount;
						this.trickleDownCallbackCount = num - 1;
					}
					else
					{
						bool flag3 = phase == CallbackPhase.TargetAndBubbleUp;
						if (flag3)
						{
							int num = this.bubbleUpCallbackCount;
							this.bubbleUpCallbackCount = num - 1;
						}
					}
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000D29 RID: 3369 RVA: 0x000334FC File Offset: 0x000316FC
		public void Add(EventCallbackFunctorBase item)
		{
			this.m_List.Add(item);
			bool flag = item.phase == CallbackPhase.TrickleDownAndTarget;
			if (flag)
			{
				int num = this.trickleDownCallbackCount;
				this.trickleDownCallbackCount = num + 1;
			}
			else
			{
				bool flag2 = item.phase == CallbackPhase.TargetAndBubbleUp;
				if (flag2)
				{
					int num = this.bubbleUpCallbackCount;
					this.bubbleUpCallbackCount = num + 1;
				}
			}
		}

		// Token: 0x06000D2A RID: 3370 RVA: 0x0003355C File Offset: 0x0003175C
		public void AddRange(EventCallbackList list)
		{
			this.m_List.AddRange(list.m_List);
			foreach (EventCallbackFunctorBase eventCallbackFunctorBase in list.m_List)
			{
				bool flag = eventCallbackFunctorBase.phase == CallbackPhase.TrickleDownAndTarget;
				if (flag)
				{
					int num = this.trickleDownCallbackCount;
					this.trickleDownCallbackCount = num + 1;
				}
				else
				{
					bool flag2 = eventCallbackFunctorBase.phase == CallbackPhase.TargetAndBubbleUp;
					if (flag2)
					{
						int num = this.bubbleUpCallbackCount;
						this.bubbleUpCallbackCount = num + 1;
					}
				}
			}
		}

		// Token: 0x170002A8 RID: 680
		// (get) Token: 0x06000D2B RID: 3371 RVA: 0x00033604 File Offset: 0x00031804
		public int Count
		{
			get
			{
				return this.m_List.Count;
			}
		}

		// Token: 0x170002A9 RID: 681
		public EventCallbackFunctorBase this[int i]
		{
			get
			{
				return this.m_List[i];
			}
			set
			{
				this.m_List[i] = value;
			}
		}

		// Token: 0x06000D2E RID: 3374 RVA: 0x00033653 File Offset: 0x00031853
		public void Clear()
		{
			this.m_List.Clear();
			this.trickleDownCallbackCount = 0;
			this.bubbleUpCallbackCount = 0;
		}

		// Token: 0x0400063A RID: 1594
		private List<EventCallbackFunctorBase> m_List;
	}
}
