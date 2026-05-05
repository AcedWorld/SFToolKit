using System;

namespace UnityWebSocketSharp
{
	// Token: 0x02000005 RID: 5
	internal enum CloseStatusCode : ushort
	{
		// Token: 0x04000007 RID: 7
		Normal = 1000,
		// Token: 0x04000008 RID: 8
		Away,
		// Token: 0x04000009 RID: 9
		ProtocolError,
		// Token: 0x0400000A RID: 10
		UnsupportedData,
		// Token: 0x0400000B RID: 11
		Undefined,
		// Token: 0x0400000C RID: 12
		NoStatus,
		// Token: 0x0400000D RID: 13
		Abnormal,
		// Token: 0x0400000E RID: 14
		InvalidData,
		// Token: 0x0400000F RID: 15
		PolicyViolation,
		// Token: 0x04000010 RID: 16
		TooBig,
		// Token: 0x04000011 RID: 17
		MandatoryExtension,
		// Token: 0x04000012 RID: 18
		ServerError,
		// Token: 0x04000013 RID: 19
		TlsHandshakeFailure = 1015
	}
}
