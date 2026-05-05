using System;
using System.Collections.Generic;
using Unity.Services.Authentication.Internal;
using Unity.Services.Qos.V2.Scheduler;
using UnityEngine;
using UnityEngine.Scripting;

namespace Unity.Services.Qos.V2.QosDiscovery
{
	// Token: 0x02000047 RID: 71
	[Preserve]
	internal class GetAllServersRequest : QosDiscoveryApiBaseRequest
	{
		// Token: 0x17000057 RID: 87
		// (get) Token: 0x06000156 RID: 342 RVA: 0x00005E7B File Offset: 0x0000407B
		[Preserve]
		public Guid XRequestId { get; }

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000157 RID: 343 RVA: 0x00005E83 File Offset: 0x00004083
		[Preserve]
		public string XUser { get; }

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000158 RID: 344 RVA: 0x00005E8B File Offset: 0x0000408B
		[Preserve]
		public string XUserType { get; }

		// Token: 0x06000159 RID: 345 RVA: 0x00005E93 File Offset: 0x00004093
		[Preserve]
		public GetAllServersRequest(Guid xRequestId = default(Guid), string xUser = null, string xUserType = null)
		{
			this.XRequestId = xRequestId;
			this.XUser = xUser;
			this.XUserType = xUserType;
			this.PathAndQueryParams = "/v2alpha1/servers";
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00005EBB File Offset: 0x000040BB
		public string ConstructUrl(string requestBasePath)
		{
			return requestBasePath + this.PathAndQueryParams;
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00005EC9 File Offset: 0x000040C9
		public byte[] ConstructBody()
		{
			return null;
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00005ECC File Offset: 0x000040CC
		public Dictionary<string, string> ConstructHeaders(IAccessToken accessToken, Configuration operationConfiguration = null)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (!string.IsNullOrEmpty(accessToken.AccessToken))
			{
				dictionary.Add("authorization", "Bearer " + accessToken.AccessToken);
			}
			dictionary.Add("Unity-Client-Version", Application.unityVersion);
			dictionary.Add("Unity-Client-Mode", EngineStateHelper.IsPlaying ? "play" : "edit");
			string[] contentTypes = new string[0];
			string[] accepts = new string[]
			{
				"application/json",
				"application/problem+json"
			};
			string value = base.GenerateAcceptHeader(accepts);
			if (!string.IsNullOrEmpty(value))
			{
				dictionary.Add("Accept", value);
			}
			string a = "GET";
			string value2 = base.GenerateContentTypeHeader(contentTypes);
			if (!string.IsNullOrEmpty(value2))
			{
				dictionary.Add("Content-Type", value2);
			}
			else if (a == "POST" || a == "PATCH")
			{
				dictionary.Add("Content-Type", "application/json");
			}
			if (!this.XRequestId.Equals(default(Guid)))
			{
				dictionary.Add("X-Request-Id", this.XRequestId.ToString());
			}
			if (!string.IsNullOrEmpty(this.XUser))
			{
				dictionary.Add("X-User", this.XUser);
			}
			if (!string.IsNullOrEmpty(this.XUserType))
			{
				dictionary.Add("X-User-Type", this.XUserType);
			}
			if (operationConfiguration != null && operationConfiguration.Headers != null)
			{
				foreach (KeyValuePair<string, string> keyValuePair in operationConfiguration.Headers)
				{
					dictionary[keyValuePair.Key] = keyValuePair.Value;
				}
			}
			return dictionary;
		}

		// Token: 0x040000A8 RID: 168
		private string PathAndQueryParams;
	}
}
