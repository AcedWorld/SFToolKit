using System;

namespace Unity.Services.Lobbies
{
	// Token: 0x0200000F RID: 15
	public enum LobbyExceptionReason
	{
		// Token: 0x04000022 RID: 34
		UnknownErrorCode,
		// Token: 0x04000023 RID: 35
		ValidationError = 16000,
		// Token: 0x04000024 RID: 36
		LobbyNotFound,
		// Token: 0x04000025 RID: 37
		PlayerNotFound,
		// Token: 0x04000026 RID: 38
		LobbyConflict,
		// Token: 0x04000027 RID: 39
		LobbyFull,
		// Token: 0x04000028 RID: 40
		LobbyLocked,
		// Token: 0x04000029 RID: 41
		NoOpenLobbies,
		// Token: 0x0400002A RID: 42
		LobbyAlreadyExists,
		// Token: 0x0400002B RID: 43
		IncorrectPassword = 16009,
		// Token: 0x0400002C RID: 44
		InvalidJoinCode,
		// Token: 0x0400002D RID: 45
		InvalidArgument = 16400,
		// Token: 0x0400002E RID: 46
		BadRequest = 16400,
		// Token: 0x0400002F RID: 47
		Unauthorized,
		// Token: 0x04000030 RID: 48
		PaymentRequired,
		// Token: 0x04000031 RID: 49
		Forbidden,
		// Token: 0x04000032 RID: 50
		EntityNotFound,
		// Token: 0x04000033 RID: 51
		MethodNotAllowed,
		// Token: 0x04000034 RID: 52
		NotAcceptable,
		// Token: 0x04000035 RID: 53
		ProxyAuthenticationRequired,
		// Token: 0x04000036 RID: 54
		RequestTimeOut,
		// Token: 0x04000037 RID: 55
		Conflict,
		// Token: 0x04000038 RID: 56
		Gone,
		// Token: 0x04000039 RID: 57
		LengthRequired,
		// Token: 0x0400003A RID: 58
		PreconditionFailed,
		// Token: 0x0400003B RID: 59
		RequestEntityTooLarge,
		// Token: 0x0400003C RID: 60
		RequestUriTooLong,
		// Token: 0x0400003D RID: 61
		UnsupportedMediaType,
		// Token: 0x0400003E RID: 62
		RangeNotSatisfiable,
		// Token: 0x0400003F RID: 63
		ExpectationFailed,
		// Token: 0x04000040 RID: 64
		Teapot,
		// Token: 0x04000041 RID: 65
		Misdirected = 16421,
		// Token: 0x04000042 RID: 66
		UnprocessableTransaction,
		// Token: 0x04000043 RID: 67
		Locked,
		// Token: 0x04000044 RID: 68
		FailedDependency,
		// Token: 0x04000045 RID: 69
		TooEarly,
		// Token: 0x04000046 RID: 70
		UpgradeRequired,
		// Token: 0x04000047 RID: 71
		PreconditionRequired = 16428,
		// Token: 0x04000048 RID: 72
		RateLimited,
		// Token: 0x04000049 RID: 73
		RequestHeaderFieldsTooLarge = 16431,
		// Token: 0x0400004A RID: 74
		UnavailableForLegalReasons = 16451,
		// Token: 0x0400004B RID: 75
		InternalServerError = 16500,
		// Token: 0x0400004C RID: 76
		NotImplemented,
		// Token: 0x0400004D RID: 77
		BadGateway,
		// Token: 0x0400004E RID: 78
		ServiceUnavailable,
		// Token: 0x0400004F RID: 79
		GatewayTimeout,
		// Token: 0x04000050 RID: 80
		HttpVersionNotSupported,
		// Token: 0x04000051 RID: 81
		VariantAlsoNegotiates,
		// Token: 0x04000052 RID: 82
		InsufficientStorage,
		// Token: 0x04000053 RID: 83
		LoopDetected,
		// Token: 0x04000054 RID: 84
		NotExtended = 16510,
		// Token: 0x04000055 RID: 85
		NetworkAuthenticationRequired,
		// Token: 0x04000056 RID: 86
		AlreadySubscribedToLobby = 16601,
		// Token: 0x04000057 RID: 87
		AlreadyUnsubscribedFromLobby,
		// Token: 0x04000058 RID: 88
		SubscriptionToLobbyLostWhileBusy,
		// Token: 0x04000059 RID: 89
		LobbyEventServiceConnectionError,
		// Token: 0x0400005A RID: 90
		NetworkError = 16998,
		// Token: 0x0400005B RID: 91
		Unknown
	}
}
