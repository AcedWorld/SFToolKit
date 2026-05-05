using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200019D RID: 413
	public class ExecuteCommandEvent : CommandEventBase<ExecuteCommandEvent>
	{
		// Token: 0x06000C99 RID: 3225 RVA: 0x00031E40 File Offset: 0x00030040
		static ExecuteCommandEvent()
		{
			EventBase<ExecuteCommandEvent>.SetCreateFunction(() => new ExecuteCommandEvent());
		}
	}
}
