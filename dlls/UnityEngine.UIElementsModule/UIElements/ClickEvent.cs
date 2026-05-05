using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000224 RID: 548
	public sealed class ClickEvent : PointerEventBase<ClickEvent>
	{
		// Token: 0x06000FFD RID: 4093 RVA: 0x0003AEBF File Offset: 0x000390BF
		static ClickEvent()
		{
			EventBase<ClickEvent>.SetCreateFunction(() => new ClickEvent());
		}

		// Token: 0x06000FFE RID: 4094 RVA: 0x0003AED8 File Offset: 0x000390D8
		protected override void Init()
		{
			base.Init();
			this.LocalInit();
		}

		// Token: 0x06000FFF RID: 4095 RVA: 0x00037AE2 File Offset: 0x00035CE2
		private void LocalInit()
		{
			base.propagation = (EventBase.EventPropagation.Bubbles | EventBase.EventPropagation.TricklesDown | EventBase.EventPropagation.Cancellable | EventBase.EventPropagation.SkipDisabledElements);
		}

		// Token: 0x06001000 RID: 4096 RVA: 0x0003AEE9 File Offset: 0x000390E9
		public ClickEvent()
		{
			this.LocalInit();
		}

		// Token: 0x06001001 RID: 4097 RVA: 0x0003AEFC File Offset: 0x000390FC
		internal static ClickEvent GetPooled(PointerUpEvent pointerEvent, int clickCount)
		{
			ClickEvent pooled = PointerEventBase<ClickEvent>.GetPooled(pointerEvent);
			pooled.clickCount = clickCount;
			return pooled;
		}
	}
}
