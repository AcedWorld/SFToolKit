using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200020D RID: 525
	internal struct XblMultiplayerEvent
	{
		// Token: 0x0400072B RID: 1835
		internal readonly int Result;

		// Token: 0x0400072C RID: 1836
		internal readonly UTF8StringPtr ErrorMessage;

		// Token: 0x0400072D RID: 1837
		internal readonly IntPtr Context;

		// Token: 0x0400072E RID: 1838
		internal readonly XblMultiplayerEventType EventType;

		// Token: 0x0400072F RID: 1839
		internal readonly XblMultiplayerEventArgsHandle EventArgsHandle;

		// Token: 0x04000730 RID: 1840
		internal readonly XblMultiplayerSessionType SessionType;
	}
}
