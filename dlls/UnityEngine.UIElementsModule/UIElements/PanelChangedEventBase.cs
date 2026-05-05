using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200020A RID: 522
	[EventCategory(EventCategory.ChangePanel)]
	public abstract class PanelChangedEventBase<T> : EventBase<T>, IPanelChangedEvent where T : PanelChangedEventBase<T>, new()
	{
		// Token: 0x1700032B RID: 811
		// (get) Token: 0x06000F3E RID: 3902 RVA: 0x00038D81 File Offset: 0x00036F81
		// (set) Token: 0x06000F3F RID: 3903 RVA: 0x00038D89 File Offset: 0x00036F89
		public IPanel originPanel { get; private set; }

		// Token: 0x1700032C RID: 812
		// (get) Token: 0x06000F40 RID: 3904 RVA: 0x00038D92 File Offset: 0x00036F92
		// (set) Token: 0x06000F41 RID: 3905 RVA: 0x00038D9A File Offset: 0x00036F9A
		public IPanel destinationPanel { get; private set; }

		// Token: 0x06000F42 RID: 3906 RVA: 0x00038DA3 File Offset: 0x00036FA3
		protected override void Init()
		{
			base.Init();
			this.LocalInit();
		}

		// Token: 0x06000F43 RID: 3907 RVA: 0x00038DB4 File Offset: 0x00036FB4
		private void LocalInit()
		{
			this.originPanel = null;
			this.destinationPanel = null;
		}

		// Token: 0x06000F44 RID: 3908 RVA: 0x00038DC8 File Offset: 0x00036FC8
		public static T GetPooled(IPanel originPanel, IPanel destinationPanel)
		{
			T pooled = EventBase<T>.GetPooled();
			pooled.originPanel = originPanel;
			pooled.destinationPanel = destinationPanel;
			return pooled;
		}

		// Token: 0x06000F45 RID: 3909 RVA: 0x00038DFB File Offset: 0x00036FFB
		protected PanelChangedEventBase()
		{
			this.LocalInit();
		}
	}
}
