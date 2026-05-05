using System;
using System.Collections.Generic;
using Unity.Services.Authentication.Internal;
using Unity.Services.Lobbies.Models;
using Unity.Services.Lobbies.Scheduler;
using UnityEngine;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Lobby
{
	// Token: 0x02000077 RID: 119
	[Preserve]
	internal class UpdatePlayerRequest : LobbyApiBaseRequest
	{
		// Token: 0x17000107 RID: 263
		// (get) Token: 0x06000332 RID: 818 RVA: 0x0000BBFC File Offset: 0x00009DFC
		[Preserve]
		public string LobbyId { get; }

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x06000333 RID: 819 RVA: 0x0000BC04 File Offset: 0x00009E04
		[Preserve]
		public string PlayerId { get; }

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x06000334 RID: 820 RVA: 0x0000BC0C File Offset: 0x00009E0C
		[Preserve]
		public string ServiceId { get; }

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x06000335 RID: 821 RVA: 0x0000BC14 File Offset: 0x00009E14
		[Preserve]
		public string ImpersonatedUserId { get; }

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x06000336 RID: 822 RVA: 0x0000BC1C File Offset: 0x00009E1C
		[Preserve]
		public PlayerUpdateRequest PlayerUpdateRequest { get; }

		// Token: 0x06000337 RID: 823 RVA: 0x0000BC24 File Offset: 0x00009E24
		[Preserve]
		public UpdatePlayerRequest(string lobbyId, string playerId, string serviceId = null, string impersonatedUserId = null, PlayerUpdateRequest playerUpdateRequest = null)
		{
			this.LobbyId = lobbyId;
			this.PlayerId = playerId;
			this.ServiceId = serviceId;
			this.ImpersonatedUserId = impersonatedUserId;
			this.PlayerUpdateRequest = playerUpdateRequest;
			this.PathAndQueryParams = "/" + lobbyId + "/players/" + playerId;
		}

		// Token: 0x06000338 RID: 824 RVA: 0x0000BC73 File Offset: 0x00009E73
		public string ConstructUrl(string requestBasePath)
		{
			return requestBasePath + this.PathAndQueryParams;
		}

		// Token: 0x06000339 RID: 825 RVA: 0x0000BC81 File Offset: 0x00009E81
		public byte[] ConstructBody()
		{
			if (this.PlayerUpdateRequest != null)
			{
				return base.ConstructBody(this.PlayerUpdateRequest);
			}
			return null;
		}

		// Token: 0x0600033A RID: 826 RVA: 0x0000BC9C File Offset: 0x00009E9C
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

		// Token: 0x04000180 RID: 384
		private string PathAndQueryParams;
	}
}
