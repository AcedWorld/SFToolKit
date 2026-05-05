using System;

namespace UnityWebSocketSharp.Net
{
	// Token: 0x0200003E RID: 62
	internal enum HttpStatusCode
	{
		// Token: 0x040001F0 RID: 496
		Continue = 100,
		// Token: 0x040001F1 RID: 497
		SwitchingProtocols,
		// Token: 0x040001F2 RID: 498
		OK = 200,
		// Token: 0x040001F3 RID: 499
		Created,
		// Token: 0x040001F4 RID: 500
		Accepted,
		// Token: 0x040001F5 RID: 501
		NonAuthoritativeInformation,
		// Token: 0x040001F6 RID: 502
		NoContent,
		// Token: 0x040001F7 RID: 503
		ResetContent,
		// Token: 0x040001F8 RID: 504
		PartialContent,
		// Token: 0x040001F9 RID: 505
		MultipleChoices = 300,
		// Token: 0x040001FA RID: 506
		Ambiguous = 300,
		// Token: 0x040001FB RID: 507
		MovedPermanently,
		// Token: 0x040001FC RID: 508
		Moved = 301,
		// Token: 0x040001FD RID: 509
		Found,
		// Token: 0x040001FE RID: 510
		Redirect = 302,
		// Token: 0x040001FF RID: 511
		SeeOther,
		// Token: 0x04000200 RID: 512
		RedirectMethod = 303,
		// Token: 0x04000201 RID: 513
		NotModified,
		// Token: 0x04000202 RID: 514
		UseProxy,
		// Token: 0x04000203 RID: 515
		Unused,
		// Token: 0x04000204 RID: 516
		TemporaryRedirect,
		// Token: 0x04000205 RID: 517
		RedirectKeepVerb = 307,
		// Token: 0x04000206 RID: 518
		BadRequest = 400,
		// Token: 0x04000207 RID: 519
		Unauthorized,
		// Token: 0x04000208 RID: 520
		PaymentRequired,
		// Token: 0x04000209 RID: 521
		Forbidden,
		// Token: 0x0400020A RID: 522
		NotFound,
		// Token: 0x0400020B RID: 523
		MethodNotAllowed,
		// Token: 0x0400020C RID: 524
		NotAcceptable,
		// Token: 0x0400020D RID: 525
		ProxyAuthenticationRequired,
		// Token: 0x0400020E RID: 526
		RequestTimeout,
		// Token: 0x0400020F RID: 527
		Conflict,
		// Token: 0x04000210 RID: 528
		Gone,
		// Token: 0x04000211 RID: 529
		LengthRequired,
		// Token: 0x04000212 RID: 530
		PreconditionFailed,
		// Token: 0x04000213 RID: 531
		RequestEntityTooLarge,
		// Token: 0x04000214 RID: 532
		RequestUriTooLong,
		// Token: 0x04000215 RID: 533
		UnsupportedMediaType,
		// Token: 0x04000216 RID: 534
		RequestedRangeNotSatisfiable,
		// Token: 0x04000217 RID: 535
		ExpectationFailed,
		// Token: 0x04000218 RID: 536
		InternalServerError = 500,
		// Token: 0x04000219 RID: 537
		NotImplemented,
		// Token: 0x0400021A RID: 538
		BadGateway,
		// Token: 0x0400021B RID: 539
		ServiceUnavailable,
		// Token: 0x0400021C RID: 540
		GatewayTimeout,
		// Token: 0x0400021D RID: 541
		HttpVersionNotSupported
	}
}
