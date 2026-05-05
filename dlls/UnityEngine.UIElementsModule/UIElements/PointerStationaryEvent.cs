using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200021E RID: 542
	public sealed class PointerStationaryEvent : PointerEventBase<PointerStationaryEvent>
	{
		// Token: 0x06000FE6 RID: 4070 RVA: 0x0003AC4B File Offset: 0x00038E4B
		static PointerStationaryEvent()
		{
			EventBase<PointerStationaryEvent>.SetCreateFunction(() => new PointerStationaryEvent());
		}

		// Token: 0x06000FE7 RID: 4071 RVA: 0x0003AC64 File Offset: 0x00038E64
		protected override void Init()
		{
			base.Init();
			this.LocalInit();
		}

		// Token: 0x06000FE8 RID: 4072 RVA: 0x0003AC75 File Offset: 0x00038E75
		private void LocalInit()
		{
			base.propagation = (EventBase.EventPropagation.Bubbles | EventBase.EventPropagation.TricklesDown | EventBase.EventPropagation.Cancellable);
			((IPointerEventInternal)this).triggeredByOS = true;
			((IPointerEventInternal)this).recomputeTopElementUnderPointer = true;
		}

		// Token: 0x06000FE9 RID: 4073 RVA: 0x0003AC90 File Offset: 0x00038E90
		public PointerStationaryEvent()
		{
			this.LocalInit();
		}
	}
}
