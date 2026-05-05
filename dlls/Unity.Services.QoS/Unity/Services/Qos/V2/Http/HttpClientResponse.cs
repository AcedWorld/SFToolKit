using System;
using System.Collections.Generic;

namespace Unity.Services.Qos.V2.Http
{
	// Token: 0x0200002F RID: 47
	internal class HttpClientResponse
	{
		// Token: 0x060000BC RID: 188 RVA: 0x00004A40 File Offset: 0x00002C40
		public HttpClientResponse(Dictionary<string, string> headers, long statusCode, bool isHttpError, bool isNetworkError, byte[] data, string errorMessage)
		{
			this.Headers = headers;
			this.StatusCode = statusCode;
			this.IsHttpError = isHttpError;
			this.IsNetworkError = isNetworkError;
			this.Data = data;
			this.ErrorMessage = errorMessage;
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060000BD RID: 189 RVA: 0x00004A75 File Offset: 0x00002C75
		public Dictionary<string, string> Headers { get; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060000BE RID: 190 RVA: 0x00004A7D File Offset: 0x00002C7D
		public long StatusCode { get; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060000BF RID: 191 RVA: 0x00004A85 File Offset: 0x00002C85
		public bool IsHttpError { get; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x00004A8D File Offset: 0x00002C8D
		public bool IsNetworkError { get; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060000C1 RID: 193 RVA: 0x00004A95 File Offset: 0x00002C95
		public byte[] Data { get; }

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060000C2 RID: 194 RVA: 0x00004A9D File Offset: 0x00002C9D
		public string ErrorMessage { get; }
	}
}
