using System;
using System.Collections.Generic;

namespace Unity.Services.Authentication.PlayerAccounts
{
	// Token: 0x02000021 RID: 33
	internal class WebRequestException : Exception
	{
		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000A3 RID: 163 RVA: 0x000037CE File Offset: 0x000019CE
		// (set) Token: 0x060000A4 RID: 164 RVA: 0x000037D6 File Offset: 0x000019D6
		public bool NetworkError { get; private set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000A5 RID: 165 RVA: 0x000037DF File Offset: 0x000019DF
		// (set) Token: 0x060000A6 RID: 166 RVA: 0x000037E7 File Offset: 0x000019E7
		public bool DeserializationError { get; private set; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000A7 RID: 167 RVA: 0x000037F0 File Offset: 0x000019F0
		// (set) Token: 0x060000A8 RID: 168 RVA: 0x000037F8 File Offset: 0x000019F8
		public bool ServerError { get; private set; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000A9 RID: 169 RVA: 0x00003801 File Offset: 0x00001A01
		// (set) Token: 0x060000AA RID: 170 RVA: 0x00003809 File Offset: 0x00001A09
		public long ResponseCode { get; private set; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000AB RID: 171 RVA: 0x00003812 File Offset: 0x00001A12
		// (set) Token: 0x060000AC RID: 172 RVA: 0x0000381A File Offset: 0x00001A1A
		public IDictionary<string, string> ResponseHeaders { get; private set; }

		// Token: 0x060000AD RID: 173 RVA: 0x00003823 File Offset: 0x00001A23
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
