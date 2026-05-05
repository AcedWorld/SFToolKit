using System;
using System.Collections.Generic;

namespace Unity.Services.Qos.Http
{
	// Token: 0x02000060 RID: 96
	internal class HttpClientResponse
	{
		// Token: 0x060001B7 RID: 439 RVA: 0x00006ED8 File Offset: 0x000050D8
		public HttpClientResponse(Dictionary<string, string> headers, long statusCode, bool isHttpError, bool isNetworkError, byte[] data, string errorMessage)
		{
			this.Headers = headers;
			this.StatusCode = statusCode;
			this.IsHttpError = isHttpError;
			this.IsNetworkError = isNetworkError;
			this.Data = data;
			this.ErrorMessage = errorMessage;
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060001B8 RID: 440 RVA: 0x00006F0D File Offset: 0x0000510D
		public Dictionary<string, string> Headers { get; }

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060001B9 RID: 441 RVA: 0x00006F15 File Offset: 0x00005115
		public long StatusCode { get; }

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060001BA RID: 442 RVA: 0x00006F1D File Offset: 0x0000511D
		public bool IsHttpError { get; }

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060001BB RID: 443 RVA: 0x00006F25 File Offset: 0x00005125
		public bool IsNetworkError { get; }

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060001BC RID: 444 RVA: 0x00006F2D File Offset: 0x0000512D
		public byte[] Data { get; }

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060001BD RID: 445 RVA: 0x00006F35 File Offset: 0x00005135
		public string ErrorMessage { get; }
	}
}
