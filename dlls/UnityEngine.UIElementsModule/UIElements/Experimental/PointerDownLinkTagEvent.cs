using System;

namespace UnityEngine.UIElements.Experimental
{
	// Token: 0x020004B9 RID: 1209
	public sealed class PointerDownLinkTagEvent : PointerEventBase<PointerDownLinkTagEvent>
	{
		// Token: 0x06002581 RID: 9601 RVA: 0x0009E536 File Offset: 0x0009C736
		static PointerDownLinkTagEvent()
		{
			EventBase<PointerDownLinkTagEvent>.SetCreateFunction(() => new PointerDownLinkTagEvent());
		}

		// Token: 0x17000874 RID: 2164
		// (get) Token: 0x06002582 RID: 9602 RVA: 0x0009E54F File Offset: 0x0009C74F
		// (set) Token: 0x06002583 RID: 9603 RVA: 0x0009E557 File Offset: 0x0009C757
		public string linkID { get; private set; }

		// Token: 0x17000875 RID: 2165
		// (get) Token: 0x06002584 RID: 9604 RVA: 0x0009E560 File Offset: 0x0009C760
		// (set) Token: 0x06002585 RID: 9605 RVA: 0x0009E568 File Offset: 0x0009C768
		public string linkText { get; private set; }

		// Token: 0x06002586 RID: 9606 RVA: 0x0009E571 File Offset: 0x0009C771
		protected override void Init()
		{
			base.Init();
			this.LocalInit();
		}

		// Token: 0x06002587 RID: 9607 RVA: 0x00036026 File Offset: 0x00034226
		private void LocalInit()
		{
			base.propagation = (EventBase.EventPropagation.Bubbles | EventBase.EventPropagation.TricklesDown);
		}

		// Token: 0x06002588 RID: 9608 RVA: 0x0009E584 File Offset: 0x0009C784
		public static PointerDownLinkTagEvent GetPooled(IPointerEvent evt, string linkID, string linkText)
		{
			PointerDownLinkTagEvent pooled = PointerEventBase<PointerDownLinkTagEvent>.GetPooled(evt);
			pooled.linkID = linkID;
			pooled.linkText = linkText;
			return pooled;
		}

		// Token: 0x06002589 RID: 9609 RVA: 0x0009E5AE File Offset: 0x0009C7AE
		public PointerDownLinkTagEvent()
		{
			this.LocalInit();
		}
	}
}
