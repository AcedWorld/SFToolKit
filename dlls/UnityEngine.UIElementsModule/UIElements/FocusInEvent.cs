using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001CA RID: 458
	public class FocusInEvent : FocusEventBase<FocusInEvent>
	{
		// Token: 0x06000E01 RID: 3585 RVA: 0x000360BE File Offset: 0x000342BE
		static FocusInEvent()
		{
			EventBase<FocusInEvent>.SetCreateFunction(() => new FocusInEvent());
		}

		// Token: 0x06000E02 RID: 3586 RVA: 0x000360D7 File Offset: 0x000342D7
		protected override void Init()
		{
			base.Init();
			this.LocalInit();
		}

		// Token: 0x06000E03 RID: 3587 RVA: 0x00036026 File Offset: 0x00034226
		private void LocalInit()
		{
			base.propagation = (EventBase.EventPropagation.Bubbles | EventBase.EventPropagation.TricklesDown);
		}

		// Token: 0x06000E04 RID: 3588 RVA: 0x000360E8 File Offset: 0x000342E8
		public FocusInEvent()
		{
			this.LocalInit();
		}
	}
}
