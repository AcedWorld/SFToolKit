using System;

namespace Unity.Services.Qos.Http
{
	// Token: 0x02000069 RID: 105
	[Serializable]
	internal class ResponseDeserializationException : Exception
	{
		// Token: 0x060001E1 RID: 481 RVA: 0x00007667 File Offset: 0x00005867
		public ResponseDeserializationException()
		{
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x0000766F File Offset: 0x0000586F
		public ResponseDeserializationException(string message) : base(message)
		{
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x00007678 File Offset: 0x00005878
		private ResponseDeserializationException(Exception inner, string message) : base(message, inner)
		{
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x00007682 File Offset: 0x00005882
		public ResponseDeserializationException(HttpClientResponse httpClientResponse) : base("Unable to Deserialize Http Client Response")
		{
			this.response = httpClientResponse;
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x00007696 File Offset: 0x00005896
		public ResponseDeserializationException(HttpClientResponse httpClientResponse, string message) : base(message)
		{
			this.response = httpClientResponse;
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x000076A6 File Offset: 0x000058A6
		public ResponseDeserializationException(HttpClientResponse httpClientResponse, Exception inner, string message) : base(message, inner)
		{
			this.response = httpClientResponse;
		}

		// Token: 0x040000D7 RID: 215
		public HttpClientResponse response;
	}
}
