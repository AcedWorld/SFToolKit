using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001C0 RID: 448
	internal class EventDebuggerDefaultActionTrace : EventDebuggerTrace
	{
		// Token: 0x170002D9 RID: 729
		// (get) Token: 0x06000DC8 RID: 3528 RVA: 0x00035A5E File Offset: 0x00033C5E
		public PropagationPhase phase { get; }

		// Token: 0x170002DA RID: 730
		// (get) Token: 0x06000DC9 RID: 3529 RVA: 0x00035A68 File Offset: 0x00033C68
		public string targetName
		{
			get
			{
				return base.eventBase.target.GetType().FullName;
			}
		}

		// Token: 0x06000DCA RID: 3530 RVA: 0x00035A8F File Offset: 0x00033C8F
		public EventDebuggerDefaultActionTrace(IPanel panel, EventBase evt, PropagationPhase phase, long duration, IEventHandler mouseCapture) : base(panel, evt, duration, mouseCapture)
		{
			this.phase = phase;
		}
	}
}
