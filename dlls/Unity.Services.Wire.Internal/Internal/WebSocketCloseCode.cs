using System;

namespace Unity.Services.Wire.Internal
{
	// Token: 0x02000031 RID: 49
	internal enum WebSocketCloseCode
	{
		// Token: 0x0400009E RID: 158
		NotSet,
		// Token: 0x0400009F RID: 159
		Normal = 1000,
		// Token: 0x040000A0 RID: 160
		Away,
		// Token: 0x040000A1 RID: 161
		ProtocolError,
		// Token: 0x040000A2 RID: 162
		UnsupportedData,
		// Token: 0x040000A3 RID: 163
		Undefined,
		// Token: 0x040000A4 RID: 164
		NoStatus,
		// Token: 0x040000A5 RID: 165
		Abnormal,
		// Token: 0x040000A6 RID: 166
		InvalidData,
		// Token: 0x040000A7 RID: 167
		PolicyViolation,
		// Token: 0x040000A8 RID: 168
		TooBig,
		// Token: 0x040000A9 RID: 169
		MandatoryExtension,
		// Token: 0x040000AA RID: 170
		ServerError,
		// Token: 0x040000AB RID: 171
		TlsHandshakeFailure = 1015
	}
}
