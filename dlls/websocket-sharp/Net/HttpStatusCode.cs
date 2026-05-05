using System;

namespace WebSocketSharp.Net
{
	// Token: 0x0200002C RID: 44
	public enum HttpStatusCode
	{
		// Token: 0x0400013D RID: 317
		Continue = 100,
		// Token: 0x0400013E RID: 318
		SwitchingProtocols,
		// Token: 0x0400013F RID: 319
		OK = 200,
		// Token: 0x04000140 RID: 320
		Created,
		// Token: 0x04000141 RID: 321
		Accepted,
		// Token: 0x04000142 RID: 322
		NonAuthoritativeInformation,
		// Token: 0x04000143 RID: 323
		NoContent,
		// Token: 0x04000144 RID: 324
		ResetContent,
		// Token: 0x04000145 RID: 325
		PartialContent,
		// Token: 0x04000146 RID: 326
		MultipleChoices = 300,
		// Token: 0x04000147 RID: 327
		Ambiguous = 300,
		// Token: 0x04000148 RID: 328
		MovedPermanently,
		// Token: 0x04000149 RID: 329
		Moved = 301,
		// Token: 0x0400014A RID: 330
		Found,
		// Token: 0x0400014B RID: 331
		Redirect = 302,
		// Token: 0x0400014C RID: 332
		SeeOther,
		// Token: 0x0400014D RID: 333
		RedirectMethod = 303,
		// Token: 0x0400014E RID: 334
		NotModified,
		// Token: 0x0400014F RID: 335
		UseProxy,
		// Token: 0x04000150 RID: 336
		Unused,
		// Token: 0x04000151 RID: 337
		TemporaryRedirect,
		// Token: 0x04000152 RID: 338
		RedirectKeepVerb = 307,
		// Token: 0x04000153 RID: 339
		BadRequest = 400,
		// Token: 0x04000154 RID: 340
		Unauthorized,
		// Token: 0x04000155 RID: 341
		PaymentRequired,
		// Token: 0x04000156 RID: 342
		Forbidden,
		// Token: 0x04000157 RID: 343
		NotFound,
		// Token: 0x04000158 RID: 344
		MethodNotAllowed,
		// Token: 0x04000159 RID: 345
		NotAcceptable,
		// Token: 0x0400015A RID: 346
		ProxyAuthenticationRequired,
		// Token: 0x0400015B RID: 347
		RequestTimeout,
		// Token: 0x0400015C RID: 348
		Conflict,
		// Token: 0x0400015D RID: 349
		Gone,
		// Token: 0x0400015E RID: 350
		LengthRequired,
		// Token: 0x0400015F RID: 351
		PreconditionFailed,
		// Token: 0x04000160 RID: 352
		RequestEntityTooLarge,
		// Token: 0x04000161 RID: 353
		RequestUriTooLong,
		// Token: 0x04000162 RID: 354
		UnsupportedMediaType,
		// Token: 0x04000163 RID: 355
		RequestedRangeNotSatisfiable,
		// Token: 0x04000164 RID: 356
		ExpectationFailed,
		// Token: 0x04000165 RID: 357
		InternalServerError = 500,
		// Token: 0x04000166 RID: 358
		NotImplemented,
		// Token: 0x04000167 RID: 359
		BadGateway,
		// Token: 0x04000168 RID: 360
		ServiceUnavailable,
		// Token: 0x04000169 RID: 361
		GatewayTimeout,
		// Token: 0x0400016A RID: 362
		HttpVersionNotSupported
	}
}
