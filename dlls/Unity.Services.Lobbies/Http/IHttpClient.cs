using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.Networking;

namespace Unity.Services.Lobbies.Http
{
	// Token: 0x02000052 RID: 82
	internal interface IHttpClient
	{
		// Token: 0x06000230 RID: 560
		Task<HttpClientResponse> MakeRequestAsync(string method, string url, byte[] body, Dictionary<string, string> headers, int requestTimeout);

		// Token: 0x06000231 RID: 561
		Task<HttpClientResponse> MakeRequestAsync(string method, string url, List<IMultipartFormSection> body, Dictionary<string, string> headers, int requestTimeout, string boundary = null);
	}
}
