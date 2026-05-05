using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Unity.Services.Authentication.PlayerAccounts
{
	// Token: 0x0200001E RID: 30
	internal class NetworkHandler : INetworkHandler
	{
		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000090 RID: 144 RVA: 0x00003344 File Offset: 0x00001544
		private INetworkConfiguration Configuration { get; }

		// Token: 0x06000091 RID: 145 RVA: 0x0000334C File Offset: 0x0000154C
		public NetworkHandler()
		{
			this.Configuration = new NetworkConfiguration();
		}

		// Token: 0x06000092 RID: 146 RVA: 0x0000336A File Offset: 0x0000156A
		public Task<T> GetAsync<T>(string url, IDictionary<string, string> headers = null)
		{
			return new WebRequest(this.Configuration, WebRequestVerb.Get, url, headers, null, "application/json").SendAsync<T>();
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00003385 File Offset: 0x00001585
		public Task<T> PostAsync<T>(string url, IDictionary<string, string> headers = null)
		{
			return new WebRequest(this.Configuration, WebRequestVerb.Post, url, headers, null, "application/json").SendAsync<T>();
		}

		// Token: 0x06000094 RID: 148 RVA: 0x000033A0 File Offset: 0x000015A0
		public Task<T> PostAsync<T>(string url, string payload, IDictionary<string, string> headers = null)
		{
			return new WebRequest(this.Configuration, WebRequestVerb.Post, url, headers, payload, "application/x-www-form-urlencoded").SendAsync<T>();
		}

		// Token: 0x06000095 RID: 149 RVA: 0x000033BC File Offset: 0x000015BC
		public Task<T> PutAsync<T>(string url, object payload, IDictionary<string, string> headers = null)
		{
			string payload2 = (payload != null) ? JsonConvert.SerializeObject(payload, this.m_JsonSerializerSettings) : null;
			return new WebRequest(this.Configuration, WebRequestVerb.Put, url, headers, payload2, "application/json").SendAsync<T>();
		}

		// Token: 0x06000096 RID: 150 RVA: 0x000033F5 File Offset: 0x000015F5
		public Task DeleteAsync(string url, IDictionary<string, string> headers = null)
		{
			return new WebRequest(this.Configuration, WebRequestVerb.Delete, url, headers, null, "application/json").SendAsync();
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00003410 File Offset: 0x00001610
		public Task<T> DeleteAsync<T>(string url, IDictionary<string, string> headers = null)
		{
			return new WebRequest(this.Configuration, WebRequestVerb.Delete, url, headers, null, "application/json").SendAsync<T>();
		}

		// Token: 0x04000057 RID: 87
		private readonly JsonSerializerSettings m_JsonSerializerSettings = new JsonSerializerSettings();

		// Token: 0x0200002C RID: 44
		public static class ContentType
		{
			// Token: 0x0400008A RID: 138
			public const string Json = "application/json";
		}
	}
}
