using System;

namespace Unity.Services.Qos.V2.Http
{
	// Token: 0x02000039 RID: 57
	[Serializable]
	internal class ResponseDeserializationException : Exception
	{
		// Token: 0x060000E9 RID: 233 RVA: 0x00005047 File Offset: 0x00003247
		public ResponseDeserializationException()
		{
		}

		// Token: 0x060000EA RID: 234 RVA: 0x0000504F File Offset: 0x0000324F
		public ResponseDeserializationException(string message) : base(message)
		{
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00005058 File Offset: 0x00003258
		private ResponseDeserializationException(Exception inner, string message) : base(message, inner)
		{
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00005062 File Offset: 0x00003262
		public ResponseDeserializationException(HttpClientResponse httpClientResponse) : base("Unable to Deserialize Http Client Response")
		{
			this.response = httpClientResponse;
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00005076 File Offset: 0x00003276
		public ResponseDeserializationException(HttpClientResponse httpClientResponse, string message) : base(message)
		{
			this.response = httpClientResponse;
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00005086 File Offset: 0x00003286
		public ResponseDeserializationException(HttpClientResponse httpClientResponse, Exception inner, string message) : base(message, inner)
		{
			this.response = httpClientResponse;
		}

		// Token: 0x04000093 RID: 147
		public HttpClientResponse response;
	}
}
