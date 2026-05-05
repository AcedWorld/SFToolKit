using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001C6 RID: 454
	public class FocusOutEvent : FocusEventBase<FocusOutEvent>
	{
		// Token: 0x06000DF4 RID: 3572 RVA: 0x00035FFC File Offset: 0x000341FC
		static FocusOutEvent()
		{
			EventBase<FocusOutEvent>.SetCreateFunction(() => new FocusOutEvent());
		}

		// Token: 0x06000DF5 RID: 3573 RVA: 0x00036015 File Offset: 0x00034215
		protected override void Init()
		{
			base.Init();
			this.LocalInit();
		}

		// Token: 0x06000DF6 RID: 3574 RVA: 0x00036026 File Offset: 0x00034226
		private void LocalInit()
		{
			base.propagation = (EventBase.EventPropagation.Bubbles | EventBase.EventPropagation.TricklesDown);
		}

		// Token: 0x06000DF7 RID: 3575 RVA: 0x00036031 File Offset: 0x00034231
		public FocusOutEvent()
		{
			this.LocalInit();
		}
	}
}
