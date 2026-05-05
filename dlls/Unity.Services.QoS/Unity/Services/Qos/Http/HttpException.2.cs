using System;
using UnityEngine.Scripting;

namespace Unity.Services.Qos.Http
{
	// Token: 0x02000062 RID: 98
	[Preserve]
	[Serializable]
	internal class HttpException<T> : HttpException
	{
		// Token: 0x060001C2 RID: 450 RVA: 0x00006F82 File Offset: 0x00005182
		[Preserve]
		public HttpException()
		{
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x00006F8A File Offset: 0x0000518A
		[Preserve]
		public HttpException(string message) : base(message)
		{
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x00006F93 File Offset: 0x00005193
		[Preserve]
		public HttpException(string message, Exception inner) : base(message, inner)
		{
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x00006F9D File Offset: 0x0000519D
		[Preserve]
		public HttpException(HttpClientResponse response, T actualError) : base(response)
		{
			this.ActualError = actualError;
		}

		// Token: 0x040000D5 RID: 213
		[Preserve]
		public T ActualError;
	}
}
