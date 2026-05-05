using System;
using System.Collections.Generic;

namespace Unity.Services.Relay.Http
{
	// Token: 0x02000036 RID: 54
	internal class HttpClientResponse
	{
		// Token: 0x060000D9 RID: 217 RVA: 0x00003F78 File Offset: 0x00002178
		public HttpClientResponse(Dictionary<string, string> headers, long statusCode, bool isHttpError, bool isNetworkError, byte[] data, string errorMessage)
		{
			this.Headers = headers;
			this.StatusCode = statusCode;
			this.IsHttpError = isHttpError;
			this.IsNetworkError = isNetworkError;
			this.Data = data;
			this.ErrorMessage = errorMessage;
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060000DA RID: 218 RVA: 0x00003FAD File Offset: 0x000021AD
		public Dictionary<string, string> Headers { get; }

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060000DB RID: 219 RVA: 0x00003FB5 File Offset: 0x000021B5
		public long StatusCode { get; }

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060000DC RID: 220 RVA: 0x00003FBD File Offset: 0x000021BD
		public bool IsHttpError { get; }

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060000DD RID: 221 RVA: 0x00003FC5 File Offset: 0x000021C5
		public bool IsNetworkError { get; }

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060000DE RID: 222 RVA: 0x00003FCD File Offset: 0x000021CD
		public byte[] Data { get; }

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060000DF RID: 223 RVA: 0x00003FD5 File Offset: 0x000021D5
		public string ErrorMessage { get; }
	}
}
