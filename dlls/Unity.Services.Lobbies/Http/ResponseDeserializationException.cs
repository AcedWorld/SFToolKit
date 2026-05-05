using System;

namespace Unity.Services.Lobbies.Http
{
	// Token: 0x02000057 RID: 87
	[Serializable]
	internal class ResponseDeserializationException : Exception
	{
		// Token: 0x06000249 RID: 585 RVA: 0x00008CEB File Offset: 0x00006EEB
		public ResponseDeserializationException()
		{
		}

		// Token: 0x0600024A RID: 586 RVA: 0x00008CF3 File Offset: 0x00006EF3
		public ResponseDeserializationException(string message) : base(message)
		{
		}

		// Token: 0x0600024B RID: 587 RVA: 0x00008CFC File Offset: 0x00006EFC
		private ResponseDeserializationException(Exception inner, string message) : base(message, inner)
		{
		}

		// Token: 0x0600024C RID: 588 RVA: 0x00008D06 File Offset: 0x00006F06
		public ResponseDeserializationException(HttpClientResponse httpClientResponse) : base("Unable to Deserialize Http Client Response")
		{
			this.response = httpClientResponse;
		}

		// Token: 0x0600024D RID: 589 RVA: 0x00008D1A File Offset: 0x00006F1A
		public ResponseDeserializationException(HttpClientResponse httpClientResponse, string message) : base(message)
		{
			this.response = httpClientResponse;
		}

		// Token: 0x0600024E RID: 590 RVA: 0x00008D2A File Offset: 0x00006F2A
		public ResponseDeserializationException(HttpClientResponse httpClientResponse, Exception inner, string message) : base(message, inner)
		{
			this.response = httpClientResponse;
		}

		// Token: 0x0400011B RID: 283
		public HttpClientResponse response;
	}
}
