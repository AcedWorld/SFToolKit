using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.Networking;

namespace Unity.Services.Qos.V2.Http
{
	// Token: 0x02000033 RID: 51
	internal interface IHttpClient
	{
		// Token: 0x060000CD RID: 205
		Task<HttpClientResponse> MakeRequestAsync(string method, string url, byte[] body, Dictionary<string, string> headers, int requestTimeout);

		// Token: 0x060000CE RID: 206
		Task<HttpClientResponse> MakeRequestAsync(string method, string url, List<IMultipartFormSection> body, Dictionary<string, string> headers, int requestTimeout, string boundary = null);
	}
}
