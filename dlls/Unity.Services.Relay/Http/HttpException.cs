using System;
using UnityEngine.Scripting;

namespace Unity.Services.Relay.Http
{
	// Token: 0x02000037 RID: 55
	[Preserve]
	[Serializable]
	internal class HttpException : Exception
	{
		// Token: 0x060000E0 RID: 224 RVA: 0x00003FDD File Offset: 0x000021DD
		[Preserve]
		public HttpException()
		{
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00003FE5 File Offset: 0x000021E5
		[Preserve]
		public HttpException(string message) : base(message)
		{
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00003FEE File Offset: 0x000021EE
		[Preserve]
		public HttpException(string message, Exception inner) : base(message, inner)
		{
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00003FF8 File Offset: 0x000021F8
		[Preserve]
		public HttpException(HttpClientResponse response) : base(string.Format("({0}) {1}", response.StatusCode, response.ErrorMessage))
		{
			this.Response = response;
		}

		// Token: 0x04000094 RID: 148
		[Preserve]
		public HttpClientResponse Response;
	}
}
