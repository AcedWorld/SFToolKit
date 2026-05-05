using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200019B RID: 411
	public class ValidateCommandEvent : CommandEventBase<ValidateCommandEvent>
	{
		// Token: 0x06000C94 RID: 3220 RVA: 0x00031E0B File Offset: 0x0003000B
		static ValidateCommandEvent()
		{
			EventBase<ValidateCommandEvent>.SetCreateFunction(() => new ValidateCommandEvent());
		}
	}
}
