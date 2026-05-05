using System;

namespace Unity.Services.Wire.Internal
{
	// Token: 0x02000015 RID: 21
	public enum CentrifugeCloseCode
	{
		// Token: 0x04000046 RID: 70
		WebsocketNotSet,
		// Token: 0x04000047 RID: 71
		WebsocketNormal = 1000,
		// Token: 0x04000048 RID: 72
		WebsocketAway,
		// Token: 0x04000049 RID: 73
		WebsocketProtocolError,
		// Token: 0x0400004A RID: 74
		WebsocketUnsupportedData,
		// Token: 0x0400004B RID: 75
		WebsocketUndefined,
		// Token: 0x0400004C RID: 76
		WebsocketNoStatus,
		// Token: 0x0400004D RID: 77
		WebsocketAbnormal,
		// Token: 0x0400004E RID: 78
		WebsocketInvalidData,
		// Token: 0x0400004F RID: 79
		WebsocketPolicyViolation,
		// Token: 0x04000050 RID: 80
		WebsocketTooBig,
		// Token: 0x04000051 RID: 81
		WebsocketMandatoryExtension,
		// Token: 0x04000052 RID: 82
		WebsocketServerError,
		// Token: 0x04000053 RID: 83
		WebsocketTlsHandshakeFailure = 1015,
		// Token: 0x04000054 RID: 84
		Normal = 3000,
		// Token: 0x04000055 RID: 85
		Shutdown,
		// Token: 0x04000056 RID: 86
		InvalidToken,
		// Token: 0x04000057 RID: 87
		BadRequest,
		// Token: 0x04000058 RID: 88
		InternalServerError,
		// Token: 0x04000059 RID: 89
		Expired,
		// Token: 0x0400005A RID: 90
		SubscriptionExpired,
		// Token: 0x0400005B RID: 91
		Stale,
		// Token: 0x0400005C RID: 92
		Slow,
		// Token: 0x0400005D RID: 93
		WriteError,
		// Token: 0x0400005E RID: 94
		InsufficientState,
		// Token: 0x0400005F RID: 95
		ForceReconnect,
		// Token: 0x04000060 RID: 96
		ForceNoReconnect,
		// Token: 0x04000061 RID: 97
		ConnectionLimit,
		// Token: 0x04000062 RID: 98
		ChannelLimit
	}
}
