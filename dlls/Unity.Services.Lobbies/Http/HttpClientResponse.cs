using System;
using System.Collections.Generic;

namespace Unity.Services.Lobbies.Http
{
	// Token: 0x0200004D RID: 77
	internal class HttpClientResponse
	{
		// Token: 0x0600021A RID: 538 RVA: 0x0000855C File Offset: 0x0000675C
		public HttpClientResponse(Dictionary<string, string> headers, long statusCode, bool isHttpError, bool isNetworkError, byte[] data, string errorMessage)
		{
			this.Headers = headers;
			this.StatusCode = statusCode;
			this.IsHttpError = isHttpError;
			this.IsNetworkError = isNetworkError;
			this.Data = data;
			this.ErrorMessage = errorMessage;
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x0600021B RID: 539 RVA: 0x00008591 File Offset: 0x00006791
		public Dictionary<string, string> Headers { get; }

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x0600021C RID: 540 RVA: 0x00008599 File Offset: 0x00006799
		public long StatusCode { get; }

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x0600021D RID: 541 RVA: 0x000085A1 File Offset: 0x000067A1
		public bool IsHttpError { get; }

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x0600021E RID: 542 RVA: 0x000085A9 File Offset: 0x000067A9
		public bool IsNetworkError { get; }

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x0600021F RID: 543 RVA: 0x000085B1 File Offset: 0x000067B1
		public byte[] Data { get; }

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x06000220 RID: 544 RVA: 0x000085B9 File Offset: 0x000067B9
		public string ErrorMessage { get; }
	}
}
