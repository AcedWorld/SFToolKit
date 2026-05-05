using System;

namespace UnityEngine.UIElements.Experimental
{
	// Token: 0x020004B7 RID: 1207
	[EventCategory(EventCategory.EnterLeave)]
	public class PointerOutLinkTagEvent : PointerEventBase<PointerOutLinkTagEvent>
	{
		// Token: 0x06002579 RID: 9593 RVA: 0x0009E4CE File Offset: 0x0009C6CE
		static PointerOutLinkTagEvent()
		{
			EventBase<PointerOutLinkTagEvent>.SetCreateFunction(() => new PointerOutLinkTagEvent());
		}

		// Token: 0x0600257A RID: 9594 RVA: 0x0009E4E7 File Offset: 0x0009C6E7
		protected override void Init()
		{
			base.Init();
			this.LocalInit();
		}

		// Token: 0x0600257B RID: 9595 RVA: 0x00036026 File Offset: 0x00034226
		private void LocalInit()
		{
			base.propagation = (EventBase.EventPropagation.Bubbles | EventBase.EventPropagation.TricklesDown);
		}

		// Token: 0x0600257C RID: 9596 RVA: 0x0009E4F8 File Offset: 0x0009C6F8
		public static PointerOutLinkTagEvent GetPooled(IPointerEvent evt, string linkID)
		{
			return PointerEventBase<PointerOutLinkTagEvent>.GetPooled(evt);
		}

		// Token: 0x0600257D RID: 9597 RVA: 0x0009E512 File Offset: 0x0009C712
		public PointerOutLinkTagEvent()
		{
			this.LocalInit();
		}
	}
}
