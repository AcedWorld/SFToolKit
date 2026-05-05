using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001DC RID: 476
	[EventCategory(EventCategory.Geometry)]
	public class GeometryChangedEvent : EventBase<GeometryChangedEvent>
	{
		// Token: 0x06000E4E RID: 3662 RVA: 0x00036DFD File Offset: 0x00034FFD
		static GeometryChangedEvent()
		{
			EventBase<GeometryChangedEvent>.SetCreateFunction(() => new GeometryChangedEvent());
		}

		// Token: 0x06000E4F RID: 3663 RVA: 0x00036E18 File Offset: 0x00035018
		public static GeometryChangedEvent GetPooled(Rect oldRect, Rect newRect)
		{
			GeometryChangedEvent pooled = EventBase<GeometryChangedEvent>.GetPooled();
			pooled.oldRect = oldRect;
			pooled.newRect = newRect;
			return pooled;
		}

		// Token: 0x06000E50 RID: 3664 RVA: 0x00036E41 File Offset: 0x00035041
		protected override void Init()
		{
			base.Init();
			this.LocalInit();
		}

		// Token: 0x06000E51 RID: 3665 RVA: 0x00036E52 File Offset: 0x00035052
		private void LocalInit()
		{
			this.oldRect = Rect.zero;
			this.newRect = Rect.zero;
			this.layoutPass = 0;
		}

		// Token: 0x170002F5 RID: 757
		// (get) Token: 0x06000E52 RID: 3666 RVA: 0x00036E75 File Offset: 0x00035075
		// (set) Token: 0x06000E53 RID: 3667 RVA: 0x00036E7D File Offset: 0x0003507D
		public Rect oldRect { get; private set; }

		// Token: 0x170002F6 RID: 758
		// (get) Token: 0x06000E54 RID: 3668 RVA: 0x00036E86 File Offset: 0x00035086
		// (set) Token: 0x06000E55 RID: 3669 RVA: 0x00036E8E File Offset: 0x0003508E
		public Rect newRect { get; private set; }

		// Token: 0x170002F7 RID: 759
		// (get) Token: 0x06000E56 RID: 3670 RVA: 0x00036E97 File Offset: 0x00035097
		// (set) Token: 0x06000E57 RID: 3671 RVA: 0x00036E9F File Offset: 0x0003509F
		internal int layoutPass { get; set; }

		// Token: 0x06000E58 RID: 3672 RVA: 0x00036EA8 File Offset: 0x000350A8
		public GeometryChangedEvent()
		{
			this.LocalInit();
		}
	}
}
