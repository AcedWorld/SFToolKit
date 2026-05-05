using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001EC RID: 492
	public class WheelEvent : MouseEventBase<WheelEvent>
	{
		// Token: 0x06000EC5 RID: 3781 RVA: 0x00037D98 File Offset: 0x00035F98
		static WheelEvent()
		{
			EventBase<WheelEvent>.SetCreateFunction(() => new WheelEvent());
		}

		// Token: 0x17000317 RID: 791
		// (get) Token: 0x06000EC6 RID: 3782 RVA: 0x00037DB1 File Offset: 0x00035FB1
		// (set) Token: 0x06000EC7 RID: 3783 RVA: 0x00037DB9 File Offset: 0x00035FB9
		public Vector3 delta { get; private set; }

		// Token: 0x06000EC8 RID: 3784 RVA: 0x00037DC4 File Offset: 0x00035FC4
		public new static WheelEvent GetPooled(Event systemEvent)
		{
			WheelEvent pooled = MouseEventBase<WheelEvent>.GetPooled(systemEvent);
			pooled.imguiEvent = systemEvent;
			bool flag = systemEvent != null;
			if (flag)
			{
				pooled.delta = systemEvent.delta;
			}
			return pooled;
		}

		// Token: 0x06000EC9 RID: 3785 RVA: 0x00037E04 File Offset: 0x00036004
		internal static WheelEvent GetPooled(Vector3 delta, Vector3 mousePosition, EventModifiers modifiers = EventModifiers.None)
		{
			WheelEvent pooled = EventBase<WheelEvent>.GetPooled();
			pooled.delta = delta;
			pooled.mousePosition = mousePosition;
			pooled.modifiers = modifiers;
			return pooled;
		}

		// Token: 0x06000ECA RID: 3786 RVA: 0x00037E3C File Offset: 0x0003603C
		internal static WheelEvent GetPooled(Vector3 delta, IPointerEvent pointerEvent)
		{
			WheelEvent pooled = MouseEventBase<WheelEvent>.GetPooled(pointerEvent);
			pooled.delta = delta;
			return pooled;
		}

		// Token: 0x06000ECB RID: 3787 RVA: 0x00037E5E File Offset: 0x0003605E
		protected override void Init()
		{
			base.Init();
			this.LocalInit();
		}

		// Token: 0x06000ECC RID: 3788 RVA: 0x00037E6F File Offset: 0x0003606F
		private void LocalInit()
		{
			base.propagation = (EventBase.EventPropagation.Bubbles | EventBase.EventPropagation.TricklesDown | EventBase.EventPropagation.Cancellable | EventBase.EventPropagation.SkipDisabledElements);
			this.delta = Vector3.zero;
		}

		// Token: 0x06000ECD RID: 3789 RVA: 0x00037E87 File Offset: 0x00036087
		public WheelEvent()
		{
			this.LocalInit();
		}
	}
}
