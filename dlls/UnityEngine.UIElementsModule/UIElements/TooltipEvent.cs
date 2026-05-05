using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000233 RID: 563
	[EventCategory(EventCategory.Tooltip)]
	public class TooltipEvent : EventBase<TooltipEvent>
	{
		// Token: 0x0600102C RID: 4140 RVA: 0x0003B2BD File Offset: 0x000394BD
		static TooltipEvent()
		{
			EventBase<TooltipEvent>.SetCreateFunction(() => new TooltipEvent());
		}

		// Token: 0x17000369 RID: 873
		// (get) Token: 0x0600102D RID: 4141 RVA: 0x0003B2D6 File Offset: 0x000394D6
		// (set) Token: 0x0600102E RID: 4142 RVA: 0x0003B2DE File Offset: 0x000394DE
		public string tooltip { get; set; }

		// Token: 0x1700036A RID: 874
		// (get) Token: 0x0600102F RID: 4143 RVA: 0x0003B2E7 File Offset: 0x000394E7
		// (set) Token: 0x06001030 RID: 4144 RVA: 0x0003B2EF File Offset: 0x000394EF
		public Rect rect { get; set; }

		// Token: 0x06001031 RID: 4145 RVA: 0x0003B2F8 File Offset: 0x000394F8
		protected override void Init()
		{
			base.Init();
			this.LocalInit();
		}

		// Token: 0x06001032 RID: 4146 RVA: 0x0003B30C File Offset: 0x0003950C
		private void LocalInit()
		{
			base.propagation = (EventBase.EventPropagation.Bubbles | EventBase.EventPropagation.TricklesDown);
			this.rect = default(Rect);
			this.tooltip = string.Empty;
			base.ignoreCompositeRoots = true;
		}

		// Token: 0x06001033 RID: 4147 RVA: 0x0003B348 File Offset: 0x00039548
		internal static TooltipEvent GetPooled(string tooltip, Rect rect)
		{
			TooltipEvent pooled = EventBase<TooltipEvent>.GetPooled();
			pooled.tooltip = tooltip;
			pooled.rect = rect;
			return pooled;
		}

		// Token: 0x06001034 RID: 4148 RVA: 0x0003B371 File Offset: 0x00039571
		public TooltipEvent()
		{
			this.LocalInit();
		}
	}
}
