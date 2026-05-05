using System;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Http
{
	// Token: 0x0200004E RID: 78
	[Preserve]
	[Serializable]
	internal class HttpException : Exception
	{
		// Token: 0x06000221 RID: 545 RVA: 0x000085C1 File Offset: 0x000067C1
		[Preserve]
		public HttpException()
		{
		}

		// Token: 0x06000222 RID: 546 RVA: 0x000085C9 File Offset: 0x000067C9
		[Preserve]
		public HttpException(string message) : base(message)
		{
		}

		// Token: 0x06000223 RID: 547 RVA: 0x000085D2 File Offset: 0x000067D2
		[Preserve]
		public HttpException(string message, Exception inner) : base(message, inner)
		{
		}

		// Token: 0x06000224 RID: 548 RVA: 0x000085DC File Offset: 0x000067DC
		[Preserve]
		public HttpException(HttpClientResponse response) : base(string.Format("({0}) {1}", response.StatusCode, response.ErrorMessage))
		{
			this.Response = response;
		}

		// Token: 0x04000118 RID: 280
		[Preserve]
		public HttpClientResponse Response;
	}
}
