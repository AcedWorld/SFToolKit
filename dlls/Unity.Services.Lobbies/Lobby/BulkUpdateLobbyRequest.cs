using System;
using System.Collections.Generic;
using Unity.Services.Authentication.Internal;
using Unity.Services.Lobbies.Models;
using Unity.Services.Lobbies.Scheduler;
using UnityEngine;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Lobby
{
	// Token: 0x02000067 RID: 103
	[Preserve]
	internal class BulkUpdateLobbyRequest : LobbyApiBaseRequest
	{
		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x060002BB RID: 699 RVA: 0x00009B83 File Offset: 0x00007D83
		[Preserve]
		public string LobbyId { get; }

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x060002BC RID: 700 RVA: 0x00009B8B File Offset: 0x00007D8B
		[Preserve]
		public string ServiceId { get; }

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x060002BD RID: 701 RVA: 0x00009B93 File Offset: 0x00007D93
		[Preserve]
		public string ImpersonatedUserId { get; }

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x060002BE RID: 702 RVA: 0x00009B9B File Offset: 0x00007D9B
		[Preserve]
		public BulkUpdateRequest BulkUpdateRequest { get; }

		// Token: 0x060002BF RID: 703 RVA: 0x00009BA3 File Offset: 0x00007DA3
		[Preserve]
		public BulkUpdateLobbyRequest(string lobbyId, string serviceId = null, string impersonatedUserId = null, BulkUpdateRequest bulkUpdateRequest = null)
		{
			this.LobbyId = lobbyId;
			this.ServiceId = serviceId;
			this.ImpersonatedUserId = impersonatedUserId;
			this.BulkUpdateRequest = bulkUpdateRequest;
			this.PathAndQueryParams = "/" + lobbyId + "/bulkupdate";
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x00009BDE File Offset: 0x00007DDE
		public string ConstructUrl(string requestBasePath)
		{
			return requestBasePath + this.PathAndQueryParams;
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x00009BEC File Offset: 0x00007DEC
		public byte[] ConstructBody()
		{
			if (this.BulkUpdateRequest != null)
			{
				return base.ConstructBody(this.BulkUpdateRequest);
			}
			return null;
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x00009C04 File Offset: 0x00007E04
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

		// Token: 0x04000138 RID: 312
		private string PathAndQueryParams;
	}
}
