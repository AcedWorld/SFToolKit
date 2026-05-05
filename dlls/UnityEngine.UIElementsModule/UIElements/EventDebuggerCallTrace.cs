using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001BF RID: 447
	internal class EventDebuggerCallTrace : EventDebuggerTrace
	{
		// Token: 0x170002D4 RID: 724
		// (get) Token: 0x06000DC2 RID: 3522 RVA: 0x000359FF File Offset: 0x00033BFF
		public int callbackHashCode { get; }

		// Token: 0x170002D5 RID: 725
		// (get) Token: 0x06000DC3 RID: 3523 RVA: 0x00035A07 File Offset: 0x00033C07
		public string callbackName { get; }

		// Token: 0x170002D6 RID: 726
		// (get) Token: 0x06000DC4 RID: 3524 RVA: 0x00035A0F File Offset: 0x00033C0F
		public bool propagationHasStopped { get; }

		// Token: 0x170002D7 RID: 727
		// (get) Token: 0x06000DC5 RID: 3525 RVA: 0x00035A17 File Offset: 0x00033C17
		public bool immediatePropagationHasStopped { get; }

		// Token: 0x170002D8 RID: 728
		// (get) Token: 0x06000DC6 RID: 3526 RVA: 0x00035A1F File Offset: 0x00033C1F
		public bool defaultHasBeenPrevented { get; }

		// Token: 0x06000DC7 RID: 3527 RVA: 0x00035A27 File Offset: 0x00033C27
		public EventDebuggerCallTrace(IPanel panel, EventBase evt, int cbHashCode, string cbName, bool propagationHasStopped, bool immediatePropagationHasStopped, bool defaultHasBeenPrevented, long duration, IEventHandler mouseCapture) : base(panel, evt, duration, mouseCapture)
		{
			this.callbackHashCode = cbHashCode;
			this.callbackName = cbName;
			this.propagationHasStopped = propagationHasStopped;
			this.immediatePropagationHasStopped = immediatePropagationHasStopped;
			this.defaultHasBeenPrevented = defaultHasBeenPrevented;
		}
	}
}
