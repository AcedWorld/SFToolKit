using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000052 RID: 82
	public abstract class ContextualMenuManager
	{
		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000380 RID: 896 RVA: 0x0000D5E9 File Offset: 0x0000B7E9
		// (set) Token: 0x06000381 RID: 897 RVA: 0x0000D5F1 File Offset: 0x0000B7F1
		internal bool displayMenuHandledOSX { get; set; }

		// Token: 0x06000382 RID: 898
		public abstract void DisplayMenuIfEventMatches(EventBase evt, IEventHandler eventHandler);

		// Token: 0x06000383 RID: 899 RVA: 0x0000D5FC File Offset: 0x0000B7FC
		public void DisplayMenu(EventBase triggerEvent, IEventHandler target)
		{
			DropdownMenu menu = new DropdownMenu();
			int pointerId;
			int button;
			using (ContextualMenuPopulateEvent pooled = ContextualMenuPopulateEvent.GetPooled(triggerEvent, menu, target, this))
			{
				IPointerEvent pointerEvent = triggerEvent as IPointerEvent;
				pointerId = ((pointerEvent != null) ? pointerEvent.pointerId : PointerId.mousePointerId);
				button = pooled.button;
				if (target != null)
				{
					target.SendEvent(pooled);
				}
			}
			bool flag = Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer;
			if (flag)
			{
				this.displayMenuHandledOSX = true;
				bool flag2 = button >= 0;
				if (flag2)
				{
					PointerDeviceState.ReleaseButton(pointerId, button);
				}
			}
		}

		// Token: 0x06000384 RID: 900
		protected internal abstract void DoDisplayMenu(DropdownMenu menu, EventBase triggerEvent);
	}
}
