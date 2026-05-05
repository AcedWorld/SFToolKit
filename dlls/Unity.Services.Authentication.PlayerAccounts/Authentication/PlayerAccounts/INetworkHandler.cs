using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Unity.Services.Authentication.PlayerAccounts
{
	// Token: 0x0200001C RID: 28
	internal interface INetworkHandler
	{
		// Token: 0x06000085 RID: 133
		Task<T> GetAsync<T>(string url, IDictionary<string, string> headers = null);

		// Token: 0x06000086 RID: 134
		Task<T> PostAsync<T>(string url, IDictionary<string, string> headers = null);

		// Token: 0x06000087 RID: 135
		Task<T> PostAsync<T>(string url, string payload, IDictionary<string, string> headers = null);

		// Token: 0x06000088 RID: 136
		Task<T> PutAsync<T>(string url, object payload, IDictionary<string, string> headers = null);

		// Token: 0x06000089 RID: 137
		Task DeleteAsync(string url, IDictionary<string, string> headers = null);

		// Token: 0x0600008A RID: 138
		Task<T> DeleteAsync<T>(string url, IDictionary<string, string> headers = null);
	}
}
