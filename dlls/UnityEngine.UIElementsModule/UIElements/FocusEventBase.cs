using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001C5 RID: 453
	[EventCategory(EventCategory.Focus)]
	public abstract class FocusEventBase<T> : EventBase<T>, IFocusEvent where T : FocusEventBase<T>, new()
	{
		// Token: 0x170002DE RID: 734
		// (get) Token: 0x06000DE8 RID: 3560 RVA: 0x00035F14 File Offset: 0x00034114
		// (set) Token: 0x06000DE9 RID: 3561 RVA: 0x00035F1C File Offset: 0x0003411C
		public Focusable relatedTarget { get; private set; }

		// Token: 0x170002DF RID: 735
		// (get) Token: 0x06000DEA RID: 3562 RVA: 0x00035F25 File Offset: 0x00034125
		// (set) Token: 0x06000DEB RID: 3563 RVA: 0x00035F2D File Offset: 0x0003412D
		public FocusChangeDirection direction { get; private set; }

		// Token: 0x170002E0 RID: 736
		// (get) Token: 0x06000DEC RID: 3564 RVA: 0x00035F36 File Offset: 0x00034136
		// (set) Token: 0x06000DED RID: 3565 RVA: 0x00035F3E File Offset: 0x0003413E
		private protected FocusController focusController { protected get; private set; }

		// Token: 0x170002E1 RID: 737
		// (get) Token: 0x06000DEE RID: 3566 RVA: 0x00035F47 File Offset: 0x00034147
		// (set) Token: 0x06000DEF RID: 3567 RVA: 0x00035F4F File Offset: 0x0003414F
		internal bool IsFocusDelegated { get; private set; }

		// Token: 0x06000DF0 RID: 3568 RVA: 0x00035F58 File Offset: 0x00034158
		protected override void Init()
		{
			base.Init();
			this.LocalInit();
		}

		// Token: 0x06000DF1 RID: 3569 RVA: 0x00035F69 File Offset: 0x00034169
		private void LocalInit()
		{
			base.propagation = EventBase.EventPropagation.TricklesDown;
			this.relatedTarget = null;
			this.direction = FocusChangeDirection.unspecified;
			this.focusController = null;
		}

		// Token: 0x06000DF2 RID: 3570 RVA: 0x00035F90 File Offset: 0x00034190
		public static T GetPooled(IEventHandler target, Focusable relatedTarget, FocusChangeDirection direction, FocusController focusController, bool bIsFocusDelegated = false)
		{
			T pooled = EventBase<T>.GetPooled();
			pooled.target = target;
			pooled.relatedTarget = relatedTarget;
			pooled.direction = direction;
			pooled.focusController = focusController;
			pooled.IsFocusDelegated = bIsFocusDelegated;
			return pooled;
		}

		// Token: 0x06000DF3 RID: 3571 RVA: 0x00035FEB File Offset: 0x000341EB
		protected FocusEventBase()
		{
			this.LocalInit();
		}
	}
}
