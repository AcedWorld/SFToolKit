using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001C1 RID: 449
	internal class EventDebuggerPathTrace : EventDebuggerTrace
	{
		// Token: 0x170002DB RID: 731
		// (get) Token: 0x06000DCB RID: 3531 RVA: 0x00035AA6 File Offset: 0x00033CA6
		public PropagationPaths paths { get; }

		// Token: 0x06000DCC RID: 3532 RVA: 0x00035AAE File Offset: 0x00033CAE
		public EventDebuggerPathTrace(IPanel panel, EventBase evt, PropagationPaths paths) : base(panel, evt, -1L, null)
		{
			this.paths = paths;
		}
	}
}
