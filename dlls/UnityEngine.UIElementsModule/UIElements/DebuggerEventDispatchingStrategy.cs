using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200019F RID: 415
	internal class DebuggerEventDispatchingStrategy : IEventDispatchingStrategy
	{
		// Token: 0x06000C9E RID: 3230 RVA: 0x00031E78 File Offset: 0x00030078
		public bool CanDispatchEvent(EventBase evt)
		{
			return false;
		}

		// Token: 0x06000C9F RID: 3231 RVA: 0x00003CD2 File Offset: 0x00001ED2
		public void DispatchEvent(EventBase evt, IPanel panel)
		{
		}

		// Token: 0x06000CA0 RID: 3232 RVA: 0x00003CD2 File Offset: 0x00001ED2
		public void PostDispatch(EventBase evt, IPanel panel)
		{
		}
	}
}
