using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000005 RID: 5
	[MovedFrom("Unity.GameCore")]
	public enum HCWebSocketCloseStatus : uint
	{
		// Token: 0x04000006 RID: 6
		Normal = 1000U,
		// Token: 0x04000007 RID: 7
		GoingAway,
		// Token: 0x04000008 RID: 8
		ProtocolError,
		// Token: 0x04000009 RID: 9
		Unsupported,
		// Token: 0x0400000A RID: 10
		EmptyStatus = 1005U,
		// Token: 0x0400000B RID: 11
		AbnormalClose,
		// Token: 0x0400000C RID: 12
		InconsistentDatatype,
		// Token: 0x0400000D RID: 13
		PolicyViolation,
		// Token: 0x0400000E RID: 14
		TooLarge,
		// Token: 0x0400000F RID: 15
		NegotiateError,
		// Token: 0x04000010 RID: 16
		ServerTerminate,
		// Token: 0x04000011 RID: 17
		HandshakeError = 1015U,
		// Token: 0x04000012 RID: 18
		UnknownError = 4000U,
		// Token: 0x04000013 RID: 19
		ErrorWinhttpTimeout = 12002U
	}
}
