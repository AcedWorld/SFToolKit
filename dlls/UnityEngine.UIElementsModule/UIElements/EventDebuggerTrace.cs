using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001BE RID: 446
	internal class EventDebuggerTrace
	{
		// Token: 0x170002D0 RID: 720
		// (get) Token: 0x06000DBC RID: 3516 RVA: 0x00035986 File Offset: 0x00033B86
		public EventDebuggerEventRecord eventBase { get; }

		// Token: 0x170002D1 RID: 721
		// (get) Token: 0x06000DBD RID: 3517 RVA: 0x0003598E File Offset: 0x00033B8E
		public IEventHandler focusedElement { get; }

		// Token: 0x170002D2 RID: 722
		// (get) Token: 0x06000DBE RID: 3518 RVA: 0x00035996 File Offset: 0x00033B96
		public IEventHandler mouseCapture { get; }

		// Token: 0x170002D3 RID: 723
		// (get) Token: 0x06000DBF RID: 3519 RVA: 0x0003599E File Offset: 0x00033B9E
		// (set) Token: 0x06000DC0 RID: 3520 RVA: 0x000359A6 File Offset: 0x00033BA6
		public long duration { get; set; }

		// Token: 0x06000DC1 RID: 3521 RVA: 0x000359B0 File Offset: 0x00033BB0
		public EventDebuggerTrace(IPanel panel, EventBase evt, long duration, IEventHandler mouseCapture)
		{
			this.eventBase = new EventDebuggerEventRecord(evt);
			object obj;
			if (panel == null)
			{
				obj = null;
			}
			else
			{
				FocusController focusController = panel.focusController;
				obj = ((focusController != null) ? focusController.focusedElement : null);
			}
			this.focusedElement = obj;
			this.mouseCapture = mouseCapture;
			this.duration = duration;
		}
	}
}
