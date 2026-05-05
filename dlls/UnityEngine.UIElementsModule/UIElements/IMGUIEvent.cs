using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000241 RID: 577
	[EventCategory(EventCategory.IMGUI)]
	public class IMGUIEvent : EventBase<IMGUIEvent>
	{
		// Token: 0x06001061 RID: 4193 RVA: 0x0003B658 File Offset: 0x00039858
		static IMGUIEvent()
		{
			EventBase<IMGUIEvent>.SetCreateFunction(() => new IMGUIEvent());
		}

		// Token: 0x06001062 RID: 4194 RVA: 0x0003B674 File Offset: 0x00039874
		public static IMGUIEvent GetPooled(Event systemEvent)
		{
			IMGUIEvent pooled = EventBase<IMGUIEvent>.GetPooled();
			pooled.imguiEvent = systemEvent;
			return pooled;
		}

		// Token: 0x06001063 RID: 4195 RVA: 0x0003B695 File Offset: 0x00039895
		protected override void Init()
		{
			base.Init();
			this.LocalInit();
		}

		// Token: 0x06001064 RID: 4196 RVA: 0x00037CF5 File Offset: 0x00035EF5
		private void LocalInit()
		{
			base.propagation = (EventBase.EventPropagation.Bubbles | EventBase.EventPropagation.TricklesDown | EventBase.EventPropagation.Cancellable);
		}

		// Token: 0x06001065 RID: 4197 RVA: 0x0003B6A6 File Offset: 0x000398A6
		public IMGUIEvent()
		{
			this.LocalInit();
		}
	}
}
