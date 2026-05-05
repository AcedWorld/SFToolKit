using System;

namespace Unity.Services.Relay
{
	// Token: 0x0200000D RID: 13
	public enum RelayExceptionReason
	{
		// Token: 0x04000011 RID: 17
		Min = 15000,
		// Token: 0x04000012 RID: 18
		NoError = 15000,
		// Token: 0x04000013 RID: 19
		InvalidRequest,
		// Token: 0x04000014 RID: 20
		InactiveProject = 15006,
		// Token: 0x04000015 RID: 21
		RegionNotFound,
		// Token: 0x04000016 RID: 22
		AllocationNotFound,
		// Token: 0x04000017 RID: 23
		JoinCodeNotFound,
		// Token: 0x04000018 RID: 24
		NoSuitableRelay,
		// Token: 0x04000019 RID: 25
		InvalidArgument = 15400,
		// Token: 0x0400001A RID: 26
		Unauthorized,
		// Token: 0x0400001B RID: 27
		PaymentRequired,
		// Token: 0x0400001C RID: 28
		Forbidden,
		// Token: 0x0400001D RID: 29
		EntityNotFound,
		// Token: 0x0400001E RID: 30
		MethodNotAllowed,
		// Token: 0x0400001F RID: 31
		NotAcceptable,
		// Token: 0x04000020 RID: 32
		ProxyAuthenticationRequired,
		// Token: 0x04000021 RID: 33
		RequestTimeOut,
		// Token: 0x04000022 RID: 34
		Conflict,
		// Token: 0x04000023 RID: 35
		Gone,
		// Token: 0x04000024 RID: 36
		LengthRequired,
		// Token: 0x04000025 RID: 37
		PreconditionFailed,
		// Token: 0x04000026 RID: 38
		RequestEntityTooLarge,
		// Token: 0x04000027 RID: 39
		RequestUriTooLong,
		// Token: 0x04000028 RID: 40
		UnsupportedMediaType,
		// Token: 0x04000029 RID: 41
		RangeNotSatisfiable,
		// Token: 0x0400002A RID: 42
		ExpectationFailed,
		// Token: 0x0400002B RID: 43
		Teapot,
		// Token: 0x0400002C RID: 44
		Misdirected = 15421,
		// Token: 0x0400002D RID: 45
		UnprocessableTransaction,
		// Token: 0x0400002E RID: 46
		Locked,
		// Token: 0x0400002F RID: 47
		FailedDependency,
		// Token: 0x04000030 RID: 48
		TooEarly,
		// Token: 0x04000031 RID: 49
		UpgradeRequired,
		// Token: 0x04000032 RID: 50
		PreconditionRequired = 15428,
		// Token: 0x04000033 RID: 51
		RateLimited,
		// Token: 0x04000034 RID: 52
		RequestHeaderFieldsTooLarge = 15431,
		// Token: 0x04000035 RID: 53
		UnavailableForLegalReasons = 15451,
		// Token: 0x04000036 RID: 54
		InternalServerError = 15500,
		// Token: 0x04000037 RID: 55
		NotImplemented,
		// Token: 0x04000038 RID: 56
		BadGateway,
		// Token: 0x04000039 RID: 57
		ServiceUnavailable,
		// Token: 0x0400003A RID: 58
		GatewayTimeout,
		// Token: 0x0400003B RID: 59
		HttpVersionNotSupported,
		// Token: 0x0400003C RID: 60
		VariantAlsoNegotiates,
		// Token: 0x0400003D RID: 61
		InsufficientStorage,
		// Token: 0x0400003E RID: 62
		LoopDetected,
		// Token: 0x0400003F RID: 63
		NotExtended = 15510,
		// Token: 0x04000040 RID: 64
		NetworkAuthenticationRequired,
		// Token: 0x04000041 RID: 65
		NetworkError = 15998,
		// Token: 0x04000042 RID: 66
		Unknown,
		// Token: 0x04000043 RID: 67
		Max = 15999
	}
}
