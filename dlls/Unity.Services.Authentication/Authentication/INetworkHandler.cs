using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Unity.Services.Authentication
{
	// Token: 0x0200004A RID: 74
	internal interface INetworkHandler
	{
		// Token: 0x060001EF RID: 495
		Task<T> GetAsync<T>(string url, IDictionary<string, string> headers = null);

		// Token: 0x060001F0 RID: 496
		Task<T> PostAsync<T>(string url, IDictionary<string, string> headers = null);

		// Token: 0x060001F1 RID: 497
		Task<T> PostAsync<T>(string url, object payload, IDictionary<string, string> headers = null);

		// Token: 0x060001F2 RID: 498
		Task<T> PutAsync<T>(string url, object payload, IDictionary<string, string> headers = null);

		// Token: 0x060001F3 RID: 499
		Task DeleteAsync(string url, IDictionary<string, string> headers = null);

		// Token: 0x060001F4 RID: 500
		Task<T> DeleteAsync<T>(string url, IDictionary<string, string> headers = null);
	}
}
