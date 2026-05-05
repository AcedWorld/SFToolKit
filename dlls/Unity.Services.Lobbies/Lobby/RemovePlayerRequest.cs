using System;
using System.Collections.Generic;
using Unity.Services.Authentication.Internal;
using Unity.Services.Lobbies.Scheduler;
using UnityEngine;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Lobby
{
	// Token: 0x02000074 RID: 116
	[Preserve]
	internal class RemovePlayerRequest : LobbyApiBaseRequest
	{
		// Token: 0x170000FB RID: 251
		// (get) Token: 0x0600031A RID: 794 RVA: 0x0000B5D4 File Offset: 0x000097D4
		[Preserve]
		public string LobbyId { get; }

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x0600031B RID: 795 RVA: 0x0000B5DC File Offset: 0x000097DC
		[Preserve]
		public string PlayerId { get; }

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x0600031C RID: 796 RVA: 0x0000B5E4 File Offset: 0x000097E4
		[Preserve]
		public string ServiceId { get; }

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x0600031D RID: 797 RVA: 0x0000B5EC File Offset: 0x000097EC
		[Preserve]
		public string ImpersonatedUserId { get; }

		// Token: 0x0600031E RID: 798 RVA: 0x0000B5F4 File Offset: 0x000097F4
		[Preserve]
		public RemovePlayerRequest(string lobbyId, string playerId, string serviceId = null, string impersonatedUserId = null)
		{
			this.LobbyId = lobbyId;
			this.PlayerId = playerId;
			this.ServiceId = serviceId;
			this.ImpersonatedUserId = impersonatedUserId;
			this.PathAndQueryParams = "/" + lobbyId + "/players/" + playerId;
		}

		// Token: 0x0600031F RID: 799 RVA: 0x0000B630 File Offset: 0x00009830
		public string ConstructUrl(string requestBasePath)
		{
			return requestBasePath + this.PathAndQueryParams;
		}

		// Token: 0x06000320 RID: 800 RVA: 0x0000B63E File Offset: 0x0000983E
		public byte[] ConstructBody()
		{
			return null;
		}

		// Token: 0x06000321 RID: 801 RVA: 0x0000B644 File Offset: 0x00009844
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

		// Token: 0x04000170 RID: 368
		private string PathAndQueryParams;
	}
}
