using System;
using System.Collections.Generic;
using Unity.Services.Authentication.Internal;
using Unity.Services.Lobbies.Models;
using Unity.Services.Lobbies.Scheduler;
using UnityEngine;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Lobby
{
	// Token: 0x02000075 RID: 117
	[Preserve]
	internal class RequestTokensRequest : LobbyApiBaseRequest
	{
		// Token: 0x170000FF RID: 255
		// (get) Token: 0x06000322 RID: 802 RVA: 0x0000B7D0 File Offset: 0x000099D0
		[Preserve]
		public string LobbyId { get; }

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x06000323 RID: 803 RVA: 0x0000B7D8 File Offset: 0x000099D8
		[Preserve]
		public List<TokenRequest> TokenRequest { get; }

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x06000324 RID: 804 RVA: 0x0000B7E0 File Offset: 0x000099E0
		[Preserve]
		public string ServiceId { get; }

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x06000325 RID: 805 RVA: 0x0000B7E8 File Offset: 0x000099E8
		[Preserve]
		public string ImpersonatedUserId { get; }

		// Token: 0x06000326 RID: 806 RVA: 0x0000B7F0 File Offset: 0x000099F0
		[Preserve]
		public RequestTokensRequest(string lobbyId, List<TokenRequest> tokenRequest, string serviceId = null, string impersonatedUserId = null)
		{
			this.LobbyId = lobbyId;
			this.TokenRequest = tokenRequest;
			this.ServiceId = serviceId;
			this.ImpersonatedUserId = impersonatedUserId;
			this.PathAndQueryParams = "/" + lobbyId + "/tokens";
		}

		// Token: 0x06000327 RID: 807 RVA: 0x0000B82B File Offset: 0x00009A2B
		public string ConstructUrl(string requestBasePath)
		{
			return requestBasePath + this.PathAndQueryParams;
		}

		// Token: 0x06000328 RID: 808 RVA: 0x0000B839 File Offset: 0x00009A39
		public byte[] ConstructBody()
		{
			return base.ConstructBody(this.TokenRequest);
		}

		// Token: 0x06000329 RID: 809 RVA: 0x0000B848 File Offset: 0x00009A48
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

		// Token: 0x04000175 RID: 373
		private string PathAndQueryParams;
	}
}
