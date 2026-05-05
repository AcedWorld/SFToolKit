using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Unity.Services.Authentication
{
	// Token: 0x0200004B RID: 75
	internal class NetworkHandler : INetworkHandler
	{
		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060001F5 RID: 501 RVA: 0x00005F68 File Offset: 0x00004168
		private INetworkConfiguration Configuration { get; }

		// Token: 0x060001F6 RID: 502 RVA: 0x00005F70 File Offset: 0x00004170
		public NetworkHandler(INetworkConfiguration configuration)
		{
			this.Configuration = configuration;
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x00005F7F File Offset: 0x0000417F
		public Task<T> GetAsync<T>(string url, IDictionary<string, string> headers = null)
		{
			return new WebRequest(this.Configuration, WebRequestVerb.Get, url, headers, null, "application/json").SendAsync<T>();
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x00005F9A File Offset: 0x0000419A
		public Task<T> PostAsync<T>(string url, IDictionary<string, string> headers = null)
		{
			return new WebRequest(this.Configuration, WebRequestVerb.Post, url, headers, null, "application/json").SendAsync<T>();
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x00005FB8 File Offset: 0x000041B8
		public Task<T> PostAsync<T>(string url, object payload, IDictionary<string, string> headers = null)
		{
			string payload2 = (payload != null) ? IsolatedJsonConvert.SerializeObject(payload, SerializerSettings.DefaultSerializerSettings) : null;
			return new WebRequest(this.Configuration, WebRequestVerb.Post, url, headers, payload2, "application/json").SendAsync<T>();
		}

		// Token: 0x060001FA RID: 506 RVA: 0x00005FF0 File Offset: 0x000041F0
		public Task<T> PutAsync<T>(string url, object payload, IDictionary<string, string> headers = null)
		{
			string payload2 = (payload != null) ? IsolatedJsonConvert.SerializeObject(payload, SerializerSettings.DefaultSerializerSettings) : null;
			return new WebRequest(this.Configuration, WebRequestVerb.Put, url, headers, payload2, "application/json").SendAsync<T>();
		}

		// Token: 0x060001FB RID: 507 RVA: 0x00006028 File Offset: 0x00004228
		public Task DeleteAsync(string url, IDictionary<string, string> headers = null)
		{
			return new WebRequest(this.Configuration, WebRequestVerb.Delete, url, headers, null, "application/json").SendAsync();
		}

		// Token: 0x060001FC RID: 508 RVA: 0x00006043 File Offset: 0x00004243
		public Task<T> DeleteAsync<T>(string url, IDictionary<string, string> headers = null)
		{
			return new WebRequest(this.Configuration, WebRequestVerb.Delete, url, headers, null, "application/json").SendAsync<T>();
		}

		// Token: 0x02000095 RID: 149
		public static class ContentType
		{
			// Token: 0x040001F8 RID: 504
			public const string Json = "application/json";
		}
	}
}
