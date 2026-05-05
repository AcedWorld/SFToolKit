using System;

namespace UnityEngine.UIElements.Experimental
{
	// Token: 0x020004B5 RID: 1205
	[EventCategory(EventCategory.PointerMove)]
	public class PointerMoveLinkTagEvent : PointerEventBase<PointerMoveLinkTagEvent>
	{
		// Token: 0x0600256D RID: 9581 RVA: 0x0009E432 File Offset: 0x0009C632
		static PointerMoveLinkTagEvent()
		{
			EventBase<PointerMoveLinkTagEvent>.SetCreateFunction(() => new PointerMoveLinkTagEvent());
		}

		// Token: 0x17000872 RID: 2162
		// (get) Token: 0x0600256E RID: 9582 RVA: 0x0009E44B File Offset: 0x0009C64B
		// (set) Token: 0x0600256F RID: 9583 RVA: 0x0009E453 File Offset: 0x0009C653
		public string linkID { get; private set; }

		// Token: 0x17000873 RID: 2163
		// (get) Token: 0x06002570 RID: 9584 RVA: 0x0009E45C File Offset: 0x0009C65C
		// (set) Token: 0x06002571 RID: 9585 RVA: 0x0009E464 File Offset: 0x0009C664
		public string linkText { get; private set; }

		// Token: 0x06002572 RID: 9586 RVA: 0x0009E46D File Offset: 0x0009C66D
		protected override void Init()
		{
			base.Init();
			this.LocalInit();
		}

		// Token: 0x06002573 RID: 9587 RVA: 0x00036026 File Offset: 0x00034226
		private void LocalInit()
		{
			base.propagation = (EventBase.EventPropagation.Bubbles | EventBase.EventPropagation.TricklesDown);
		}

		// Token: 0x06002574 RID: 9588 RVA: 0x0009E480 File Offset: 0x0009C680
		public static PointerMoveLinkTagEvent GetPooled(IPointerEvent evt, string linkID, string linkText)
		{
			PointerMoveLinkTagEvent pooled = PointerEventBase<PointerMoveLinkTagEvent>.GetPooled(evt);
			pooled.linkID = linkID;
			pooled.linkText = linkText;
			return pooled;
		}

		// Token: 0x06002575 RID: 9589 RVA: 0x0009E4AA File Offset: 0x0009C6AA
		public PointerMoveLinkTagEvent()
		{
			this.LocalInit();
		}
	}
}
