using System;
using System.Collections.Generic;

namespace Unity.Services.Authentication
{
	// Token: 0x0200004D RID: 77
	internal class WebRequestException : Exception
	{
		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000208 RID: 520 RVA: 0x0000640E File Offset: 0x0000460E
		// (set) Token: 0x06000209 RID: 521 RVA: 0x00006416 File Offset: 0x00004616
		public bool NetworkError { get; private set; }

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x0600020A RID: 522 RVA: 0x0000641F File Offset: 0x0000461F
		// (set) Token: 0x0600020B RID: 523 RVA: 0x00006427 File Offset: 0x00004627
		public bool DeserializationError { get; private set; }

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x0600020C RID: 524 RVA: 0x00006430 File Offset: 0x00004630
		// (set) Token: 0x0600020D RID: 525 RVA: 0x00006438 File Offset: 0x00004638
		public bool ServerError { get; private set; }

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x0600020E RID: 526 RVA: 0x00006441 File Offset: 0x00004641
		// (set) Token: 0x0600020F RID: 527 RVA: 0x00006449 File Offset: 0x00004649
		public long ResponseCode { get; private set; }

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000210 RID: 528 RVA: 0x00006452 File Offset: 0x00004652
		// (set) Token: 0x06000211 RID: 529 RVA: 0x0000645A File Offset: 0x0000465A
		public IDictionary<string, string> ResponseHeaders { get; private set; }

		// Token: 0x06000212 RID: 530 RVA: 0x00006463 File Offset: 0x00004663
		internal WebRequestException(bool isNetworkError, bool isServerError, bool isDeserializationError, long responseCode, string errorMessage, IDictionary<string, string> responseHeaders = null) : base(errorMessage)
		{
			this.NetworkError = isNetworkError;
			this.ServerError = isServerError;
			this.DeserializationError = isDeserializationError;
			this.ResponseCode = responseCode;
			this.ResponseHeaders = responseHeaders;
		}
	}
}
