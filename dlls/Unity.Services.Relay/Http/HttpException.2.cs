using System;
using UnityEngine.Scripting;

namespace Unity.Services.Relay.Http
{
	// Token: 0x02000038 RID: 56
	[Preserve]
	[Serializable]
	internal class HttpException<T> : HttpException
	{
		// Token: 0x060000E4 RID: 228 RVA: 0x00004022 File Offset: 0x00002222
		[Preserve]
		public HttpException()
		{
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x0000402A File Offset: 0x0000222A
		[Preserve]
		public HttpException(string message) : base(message)
		{
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00004033 File Offset: 0x00002233
		[Preserve]
		public HttpException(string message, Exception inner) : base(message, inner)
		{
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x0000403D File Offset: 0x0000223D
		[Preserve]
		public HttpException(HttpClientResponse response, T actualError) : base(response)
		{
			this.ActualError = actualError;
		}

		// Token: 0x04000095 RID: 149
		[Preserve]
		public T ActualError;
	}
}
