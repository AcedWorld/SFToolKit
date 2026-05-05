using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001A5 RID: 421
	[EventCategory(EventCategory.Default)]
	public abstract class EventBase<T> : EventBase where T : EventBase<T>, new()
	{
		// Token: 0x06000CF9 RID: 3321 RVA: 0x00032EB1 File Offset: 0x000310B1
		internal static void SetCreateFunction(Func<T> createMethod)
		{
			EventBase<T>.s_Pool.CreateFunc = createMethod;
		}

		// Token: 0x06000CFA RID: 3322 RVA: 0x00032EBF File Offset: 0x000310BF
		protected EventBase() : base(EventBase<T>.EventCategory)
		{
			this.m_RefCount = 0;
		}

		// Token: 0x06000CFB RID: 3323 RVA: 0x00032ED8 File Offset: 0x000310D8
		public static long TypeId()
		{
			return EventBase<T>.s_TypeId;
		}

		// Token: 0x06000CFC RID: 3324 RVA: 0x00032EF0 File Offset: 0x000310F0
		protected override void Init()
		{
			base.Init();
			bool flag = this.m_RefCount != 0;
			if (flag)
			{
				Debug.Log("Event improperly released.");
				this.m_RefCount = 0;
			}
		}

		// Token: 0x06000CFD RID: 3325 RVA: 0x00032F28 File Offset: 0x00031128
		public static T GetPooled()
		{
			T t = EventBase<T>.s_Pool.Get();
			t.Init();
			t.pooled = true;
			t.Acquire();
			return t;
		}

		// Token: 0x06000CFE RID: 3326 RVA: 0x00032F6C File Offset: 0x0003116C
		internal static T GetPooled(EventBase e)
		{
			T pooled = EventBase<T>.GetPooled();
			bool flag = e != null;
			if (flag)
			{
				pooled.SetTriggerEventId(e.eventId);
			}
			return pooled;
		}

		// Token: 0x06000CFF RID: 3327 RVA: 0x00032FA4 File Offset: 0x000311A4
		private static void ReleasePooled(T evt)
		{
			bool pooled = evt.pooled;
			if (pooled)
			{
				evt.Init();
				EventBase<T>.s_Pool.Release(evt);
				evt.pooled = false;
			}
		}

		// Token: 0x06000D00 RID: 3328 RVA: 0x00032FE8 File Offset: 0x000311E8
		internal override void Acquire()
		{
			this.m_RefCount++;
		}

		// Token: 0x06000D01 RID: 3329 RVA: 0x00032FFC File Offset: 0x000311FC
		public sealed override void Dispose()
		{
			int num = this.m_RefCount - 1;
			this.m_RefCount = num;
			bool flag = num == 0;
			if (flag)
			{
				EventBase<T>.ReleasePooled((T)((object)this));
			}
		}

		// Token: 0x170002A2 RID: 674
		// (get) Token: 0x06000D02 RID: 3330 RVA: 0x00033030 File Offset: 0x00031230
		public override long eventTypeId
		{
			get
			{
				return EventBase<T>.s_TypeId;
			}
		}

		// Token: 0x04000624 RID: 1572
		private static readonly long s_TypeId = EventBase.RegisterEventType();

		// Token: 0x04000625 RID: 1573
		private static readonly ObjectPool<T> s_Pool = new ObjectPool<T>(() => Activator.CreateInstance<T>(), 100);

		// Token: 0x04000626 RID: 1574
		private int m_RefCount;

		// Token: 0x04000627 RID: 1575
		internal static readonly EventCategory EventCategory = EventInterestReflectionUtils.GetEventCategory(typeof(T));
	}
}
