using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200018A RID: 394
	[EventCategory(EventCategory.Pointer)]
	public abstract class PointerCaptureEventBase<T> : EventBase<T>, IPointerCaptureEvent, IPointerCaptureEventInternal where T : PointerCaptureEventBase<T>, new()
	{
		// Token: 0x1700027C RID: 636
		// (get) Token: 0x06000C5D RID: 3165 RVA: 0x00031994 File Offset: 0x0002FB94
		// (set) Token: 0x06000C5E RID: 3166 RVA: 0x0003199C File Offset: 0x0002FB9C
		public IEventHandler relatedTarget { get; private set; }

		// Token: 0x1700027D RID: 637
		// (get) Token: 0x06000C5F RID: 3167 RVA: 0x000319A5 File Offset: 0x0002FBA5
		// (set) Token: 0x06000C60 RID: 3168 RVA: 0x000319AD File Offset: 0x0002FBAD
		public int pointerId { get; private set; }

		// Token: 0x06000C61 RID: 3169 RVA: 0x000319B6 File Offset: 0x0002FBB6
		protected override void Init()
		{
			base.Init();
			this.LocalInit();
		}

		// Token: 0x06000C62 RID: 3170 RVA: 0x000319C7 File Offset: 0x0002FBC7
		private void LocalInit()
		{
			base.propagation = (EventBase.EventPropagation.Bubbles | EventBase.EventPropagation.TricklesDown);
			this.relatedTarget = null;
			this.pointerId = PointerId.invalidPointerId;
		}

		// Token: 0x06000C63 RID: 3171 RVA: 0x000319E8 File Offset: 0x0002FBE8
		public static T GetPooled(IEventHandler target, IEventHandler relatedTarget, int pointerId)
		{
			T pooled = EventBase<T>.GetPooled();
			pooled.target = target;
			pooled.relatedTarget = relatedTarget;
			pooled.pointerId = pointerId;
			return pooled;
		}

		// Token: 0x06000C64 RID: 3172 RVA: 0x00031A28 File Offset: 0x0002FC28
		protected PointerCaptureEventBase()
		{
			this.LocalInit();
		}
	}
}
