using System;
using UnityEngine.Scripting;

namespace Unity.Services.Qos.V2.Http
{
	// Token: 0x02000030 RID: 48
	[Preserve]
	[Serializable]
	internal class HttpException : Exception
	{
		// Token: 0x060000C3 RID: 195 RVA: 0x00004AA5 File Offset: 0x00002CA5
		[Preserve]
		public HttpException()
		{
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00004AAD File Offset: 0x00002CAD
		[Preserve]
		public HttpException(string message) : base(message)
		{
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00004AB6 File Offset: 0x00002CB6
		[Preserve]
		public HttpException(string message, Exception inner) : base(message, inner)
		{
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00004AC0 File Offset: 0x00002CC0
		[Preserve]
		public HttpException(HttpClientResponse response) : base(string.Format("({0}) {1}", response.StatusCode, response.ErrorMessage))
		{
			this.Response = response;
		}

		// Token: 0x04000090 RID: 144
		[Preserve]
		public HttpClientResponse Response;
	}
}
