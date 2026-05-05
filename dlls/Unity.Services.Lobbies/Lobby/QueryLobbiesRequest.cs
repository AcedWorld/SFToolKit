using System;
using System.Collections.Generic;
using Unity.Services.Authentication.Internal;
using Unity.Services.Lobbies.Models;
using Unity.Services.Lobbies.Scheduler;
using UnityEngine;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Lobby
{
	// Token: 0x02000071 RID: 113
	[Preserve]
	internal class QueryLobbiesRequest : LobbyApiBaseRequest
	{
		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x06000304 RID: 772 RVA: 0x0000AFAC File Offset: 0x000091AC
		[Preserve]
		public string ServiceId { get; }

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x06000305 RID: 773 RVA: 0x0000AFB4 File Offset: 0x000091B4
		[Preserve]
		public string ImpersonatedUserId { get; }

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x06000306 RID: 774 RVA: 0x0000AFBC File Offset: 0x000091BC
		[Preserve]
		public QueryRequest QueryRequest { get; }

		// Token: 0x06000307 RID: 775 RVA: 0x0000AFC4 File Offset: 0x000091C4
		[Preserve]
		public QueryLobbiesRequest(string serviceId = null, string impersonatedUserId = null, QueryRequest queryRequest = null)
		{
			this.ServiceId = serviceId;
			this.ImpersonatedUserId = impersonatedUserId;
			this.QueryRequest = queryRequest;
			this.PathAndQueryParams = "/query";
		}

		// Token: 0x06000308 RID: 776 RVA: 0x0000AFEC File Offset: 0x000091EC
		public string ConstructUrl(string requestBasePath)
		{
			return requestBasePath + this.PathAndQueryParams;
		}

		// Token: 0x06000309 RID: 777 RVA: 0x0000AFFA File Offset: 0x000091FA
		public byte[] ConstructBody()
		{
			if (this.QueryRequest != null)
			{
				return base.ConstructBody(this.QueryRequest);
			}
			return null;
		}

		// Token: 0x0600030A RID: 778 RVA: 0x0000B014 File Offset: 0x00009214
		public Dictionary<string, string> ConstructHeaders(IAccessToken accessToken, Configuration operationConfiguration = null)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (!string.IsNullOrEmpty(accessToken.AccessToken))
			{
				dictionary.Add("authorization", "Bearer " + accessToken.AccessToken);
			}
			dictionary.Add("Unity-Client-Version", Application.unityVersion);
			dictionary.Add("Unity-Client-Mode", EngineStateHelper.IsPlaying ? "play" : "edit");
			string[] contentTypes = new string[]
			{
				"application/json"
			};
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
			string a = "POST";
			string value2 = base.GenerateContentTypeHeader(contentTypes);
			if (!string.IsNullOrEmpty(value2))
			{
				dictionary.Add("Content-Type", value2);
			}
			else if (a == "POST" || a == "PATCH")
			{
				dictionary.Add("Content-Type", "application/json");
			}
			if (!string.IsNullOrEmpty(this.ServiceId))
			{
				dictionary.Add("Service-id", this.ServiceId);
			}
			if (!string.IsNullOrEmpty(this.ImpersonatedUserId))
			{
				dictionary.Add("Impersonated-user-id", this.ImpersonatedUserId);
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

		// Token: 0x04000162 RID: 354
		private string PathAndQueryParams;
	}
}
