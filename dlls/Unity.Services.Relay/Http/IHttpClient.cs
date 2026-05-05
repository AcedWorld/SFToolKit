using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.Networking;

namespace Unity.Services.Relay.Http
{
	// Token: 0x0200003A RID: 58
	internal interface IHttpClient
	{
		// Token: 0x060000EA RID: 234
		Task<HttpClientResponse> MakeRequestAsync(string method, string url, byte[] body, Dictionary<string, string> headers, int requestTimeout);

		// Token: 0x060000EB RID: 235
		Task<HttpClientResponse> MakeRequestAsync(string method, string url, List<IMultipartFormSection> body, Dictionary<string, string> headers, int requestTimeout, string boundary = null);
	}
}
