using System;
using System.Collections.Generic;
using Unity.Services.Authentication.Internal;
using Unity.Services.Lobbies.Models;
using Unity.Services.Lobbies.Scheduler;
using UnityEngine;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Lobby
{
	// Token: 0x02000076 RID: 118
	[Preserve]
	internal class UpdateLobbyRequest : LobbyApiBaseRequest
	{
		// Token: 0x17000103 RID: 259
		// (get) Token: 0x0600032A RID: 810 RVA: 0x0000B9E4 File Offset: 0x00009BE4
		[Preserve]
		public string LobbyId { get; }

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x0600032B RID: 811 RVA: 0x0000B9EC File Offset: 0x00009BEC
		[Preserve]
		public string ServiceId { get; }

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x0600032C RID: 812 RVA: 0x0000B9F4 File Offset: 0x00009BF4
		[Preserve]
		public string ImpersonatedUserId { get; }

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x0600032D RID: 813 RVA: 0x0000B9FC File Offset: 0x00009BFC
		[Preserve]
		public UpdateRequest UpdateRequest { get; }

		// Token: 0x0600032E RID: 814 RVA: 0x0000BA04 File Offset: 0x00009C04
		[Preserve]
		public UpdateLobbyRequest(string lobbyId, string serviceId = null, string impersonatedUserId = null, UpdateRequest updateRequest = null)
		{
			this.LobbyId = lobbyId;
			this.ServiceId = serviceId;
			this.ImpersonatedUserId = impersonatedUserId;
			this.UpdateRequest = updateRequest;
			this.PathAndQueryParams = "/" + lobbyId;
		}

		// Token: 0x0600032F RID: 815 RVA: 0x0000BA3A File Offset: 0x00009C3A
		public string ConstructUrl(string requestBasePath)
		{
			return requestBasePath + this.PathAndQueryParams;
		}

		// Token: 0x06000330 RID: 816 RVA: 0x0000BA48 File Offset: 0x00009C48
		public byte[] ConstructBody()
		{
			if (this.UpdateRequest != null)
			{
				return base.ConstructBody(this.UpdateRequest);
			}
			return null;
		}

		// Token: 0x06000331 RID: 817 RVA: 0x0000BA60 File Offset: 0x00009C60
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

		// Token: 0x0400017A RID: 378
		private string PathAndQueryParams;
	}
}
