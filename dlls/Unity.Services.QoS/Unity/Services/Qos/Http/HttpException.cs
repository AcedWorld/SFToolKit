using System;
using UnityEngine.Scripting;

namespace Unity.Services.Qos.Http
{
	// Token: 0x02000061 RID: 97
	[Preserve]
	[Serializable]
	internal class HttpException : Exception
	{
		// Token: 0x060001BE RID: 446 RVA: 0x00006F3D File Offset: 0x0000513D
		[Preserve]
		public HttpException()
		{
		}

		// Token: 0x060001BF RID: 447 RVA: 0x00006F45 File Offset: 0x00005145
		[Preserve]
		public HttpException(string message) : base(message)
		{
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x00006F4E File Offset: 0x0000514E
		[Preserve]
		public HttpException(string message, Exception inner) : base(message, inner)
		{
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x00006F58 File Offset: 0x00005158
		[Preserve]
		public HttpException(HttpClientResponse response) : base(string.Format("({0}) {1}", response.StatusCode, response.ErrorMessage))
		{
			this.Response = response;
		}

		// Token: 0x040000D4 RID: 212
		[Preserve]
		public HttpClientResponse Response;
	}
}
