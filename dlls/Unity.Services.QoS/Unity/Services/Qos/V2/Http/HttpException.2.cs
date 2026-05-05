using System;
using UnityEngine.Scripting;

namespace Unity.Services.Qos.V2.Http
{
	// Token: 0x02000031 RID: 49
	[Preserve]
	[Serializable]
	internal class HttpException<T> : HttpException
	{
		// Token: 0x060000C7 RID: 199 RVA: 0x00004AEA File Offset: 0x00002CEA
		[Preserve]
		public HttpException()
		{
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00004AF2 File Offset: 0x00002CF2
		[Preserve]
		public HttpException(string message) : base(message)
		{
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00004AFB File Offset: 0x00002CFB
		[Preserve]
		public HttpException(string message, Exception inner) : base(message, inner)
		{
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00004B05 File Offset: 0x00002D05
		[Preserve]
		public HttpException(HttpClientResponse response, T actualError) : base(response)
		{
			this.ActualError = actualError;
		}

		// Token: 0x04000091 RID: 145
		[Preserve]
		public T ActualError;
	}
}
