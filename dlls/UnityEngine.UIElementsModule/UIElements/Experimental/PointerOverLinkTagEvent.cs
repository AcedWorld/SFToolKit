using System;

namespace UnityEngine.UIElements.Experimental
{
	// Token: 0x020004B3 RID: 1203
	[EventCategory(EventCategory.EnterLeave)]
	public class PointerOverLinkTagEvent : PointerEventBase<PointerOverLinkTagEvent>
	{
		// Token: 0x06002561 RID: 9569 RVA: 0x0009E395 File Offset: 0x0009C595
		static PointerOverLinkTagEvent()
		{
			EventBase<PointerOverLinkTagEvent>.SetCreateFunction(() => new PointerOverLinkTagEvent());
		}

		// Token: 0x17000870 RID: 2160
		// (get) Token: 0x06002562 RID: 9570 RVA: 0x0009E3AE File Offset: 0x0009C5AE
		// (set) Token: 0x06002563 RID: 9571 RVA: 0x0009E3B6 File Offset: 0x0009C5B6
		public string linkID { get; private set; }

		// Token: 0x17000871 RID: 2161
		// (get) Token: 0x06002564 RID: 9572 RVA: 0x0009E3BF File Offset: 0x0009C5BF
		// (set) Token: 0x06002565 RID: 9573 RVA: 0x0009E3C7 File Offset: 0x0009C5C7
		public string linkText { get; private set; }

		// Token: 0x06002566 RID: 9574 RVA: 0x0009E3D0 File Offset: 0x0009C5D0
		protected override void Init()
		{
			base.Init();
			this.LocalInit();
		}

		// Token: 0x06002567 RID: 9575 RVA: 0x00036026 File Offset: 0x00034226
		private void LocalInit()
		{
			base.propagation = (EventBase.EventPropagation.Bubbles | EventBase.EventPropagation.TricklesDown);
		}

		// Token: 0x06002568 RID: 9576 RVA: 0x0009E3E4 File Offset: 0x0009C5E4
		public static PointerOverLinkTagEvent GetPooled(IPointerEvent evt, string linkID, string linkText)
		{
			PointerOverLinkTagEvent pooled = PointerEventBase<PointerOverLinkTagEvent>.GetPooled(evt);
			pooled.linkID = linkID;
			pooled.linkText = linkText;
			return pooled;
		}

		// Token: 0x06002569 RID: 9577 RVA: 0x0009E40E File Offset: 0x0009C60E
		public PointerOverLinkTagEvent()
		{
			this.LocalInit();
		}
	}
}
