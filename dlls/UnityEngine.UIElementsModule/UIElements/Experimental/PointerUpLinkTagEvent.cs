using System;

namespace UnityEngine.UIElements.Experimental
{
	// Token: 0x020004BB RID: 1211
	public class PointerUpLinkTagEvent : PointerEventBase<PointerUpLinkTagEvent>
	{
		// Token: 0x0600258D RID: 9613 RVA: 0x0009E5D2 File Offset: 0x0009C7D2
		static PointerUpLinkTagEvent()
		{
			EventBase<PointerUpLinkTagEvent>.SetCreateFunction(() => new PointerUpLinkTagEvent());
		}

		// Token: 0x17000876 RID: 2166
		// (get) Token: 0x0600258E RID: 9614 RVA: 0x0009E5EB File Offset: 0x0009C7EB
		// (set) Token: 0x0600258F RID: 9615 RVA: 0x0009E5F3 File Offset: 0x0009C7F3
		public string linkID { get; private set; }

		// Token: 0x17000877 RID: 2167
		// (get) Token: 0x06002590 RID: 9616 RVA: 0x0009E5FC File Offset: 0x0009C7FC
		// (set) Token: 0x06002591 RID: 9617 RVA: 0x0009E604 File Offset: 0x0009C804
		public string linkText { get; private set; }

		// Token: 0x06002592 RID: 9618 RVA: 0x0009E60D File Offset: 0x0009C80D
		protected override void Init()
		{
			base.Init();
			this.LocalInit();
		}

		// Token: 0x06002593 RID: 9619 RVA: 0x00036026 File Offset: 0x00034226
		private void LocalInit()
		{
			base.propagation = (EventBase.EventPropagation.Bubbles | EventBase.EventPropagation.TricklesDown);
		}

		// Token: 0x06002594 RID: 9620 RVA: 0x0009E620 File Offset: 0x0009C820
		public static PointerUpLinkTagEvent GetPooled(IPointerEvent evt, string linkID, string linkText)
		{
			PointerUpLinkTagEvent pooled = PointerEventBase<PointerUpLinkTagEvent>.GetPooled(evt);
			pooled.linkID = linkID;
			pooled.linkText = linkText;
			return pooled;
		}

		// Token: 0x06002595 RID: 9621 RVA: 0x0009E64A File Offset: 0x0009C84A
		public PointerUpLinkTagEvent()
		{
			this.LocalInit();
		}
	}
}
