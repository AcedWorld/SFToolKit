using System;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Http
{
	// Token: 0x0200004F RID: 79
	[Preserve]
	[Serializable]
	internal class HttpException<T> : HttpException
	{
		// Token: 0x06000225 RID: 549 RVA: 0x00008606 File Offset: 0x00006806
		[Preserve]
		public HttpException()
		{
		}

		// Token: 0x06000226 RID: 550 RVA: 0x0000860E File Offset: 0x0000680E
		[Preserve]
		public HttpException(string message) : base(message)
		{
		}

		// Token: 0x06000227 RID: 551 RVA: 0x00008617 File Offset: 0x00006817
		[Preserve]
		public HttpException(string message, Exception inner) : base(message, inner)
		{
		}

		// Token: 0x06000228 RID: 552 RVA: 0x00008621 File Offset: 0x00006821
		[Preserve]
		public HttpException(HttpClientResponse response, T actualError) : base(response)
		{
			this.ActualError = actualError;
		}

		// Token: 0x04000119 RID: 281
		[Preserve]
		public T ActualError;
	}
}
