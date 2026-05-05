using System;

namespace Unity.Services.Relay.Http
{
	// Token: 0x0200003F RID: 63
	[Serializable]
	internal class ResponseDeserializationException : Exception
	{
		// Token: 0x06000103 RID: 259 RVA: 0x00004707 File Offset: 0x00002907
		public ResponseDeserializationException()
		{
		}

		// Token: 0x06000104 RID: 260 RVA: 0x0000470F File Offset: 0x0000290F
		public ResponseDeserializationException(string message) : base(message)
		{
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00004718 File Offset: 0x00002918
		private ResponseDeserializationException(Exception inner, string message) : base(message, inner)
		{
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00004722 File Offset: 0x00002922
		public ResponseDeserializationException(HttpClientResponse httpClientResponse) : base("Unable to Deserialize Http Client Response")
		{
			this.response = httpClientResponse;
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00004736 File Offset: 0x00002936
		public ResponseDeserializationException(HttpClientResponse httpClientResponse, string message) : base(message)
		{
			this.response = httpClientResponse;
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00004746 File Offset: 0x00002946
		public ResponseDeserializationException(HttpClientResponse httpClientResponse, Exception inner, string message) : base(message, inner)
		{
			this.response = httpClientResponse;
		}

		// Token: 0x04000097 RID: 151
		public HttpClientResponse response;
	}
}
