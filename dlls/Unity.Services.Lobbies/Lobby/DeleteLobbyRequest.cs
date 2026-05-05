using System;
using System.Collections.Generic;
using Unity.Services.Authentication.Internal;
using Unity.Services.Lobbies.Scheduler;
using UnityEngine;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Lobby
{
	// Token: 0x0200006A RID: 106
	[Preserve]
	internal class DeleteLobbyRequest : LobbyApiBaseRequest
	{
		// Token: 0x170000DB RID: 219
		// (get) Token: 0x060002D2 RID: 722 RVA: 0x0000A1C4 File Offset: 0x000083C4
		[Preserve]
		public string LobbyId { get; }

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x060002D3 RID: 723 RVA: 0x0000A1CC File Offset: 0x000083CC
		[Preserve]
		public string ServiceId { get; }

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x060002D4 RID: 724 RVA: 0x0000A1D4 File Offset: 0x000083D4
		[Preserve]
		public string ImpersonatedUserId { get; }

		// Token: 0x060002D5 RID: 725 RVA: 0x0000A1DC File Offset: 0x000083DC
		[Preserve]
		public DeleteLobbyRequest(string lobbyId, string serviceId = null, string impersonatedUserId = null)
		{
			this.LobbyId = lobbyId;
			this.ServiceId = serviceId;
			this.ImpersonatedUserId = impersonatedUserId;
			this.PathAndQueryParams = "/" + lobbyId;
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x0000A20A File Offset: 0x0000840A
		public string ConstructUrl(string requestBasePath)
		{
			return requestBasePath + this.PathAndQueryParams;
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x0000A218 File Offset: 0x00008418
		public byte[] ConstructBody()
		{
			return null;
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x0000A21C File Offset: 0x0000841C
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
				"application/problem+json"
			};
			string value = base.GenerateAcceptHeader(accepts);
			if (!string.IsNullOrEmpty(value))
			{
				dictionary.Add("Accept", value);
			}
			string a = "DELETE";
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

		// Token: 0x04000145 RID: 325
		private string PathAndQueryParams;
	}
}
