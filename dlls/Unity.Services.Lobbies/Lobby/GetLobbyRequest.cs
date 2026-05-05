using System;
using System.Collections.Generic;
using Unity.Services.Authentication.Internal;
using Unity.Services.Lobbies.Scheduler;
using UnityEngine;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Lobby
{
	// Token: 0x0200006D RID: 109
	[Preserve]
	internal class GetLobbyRequest : LobbyApiBaseRequest
	{
		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x060002E5 RID: 741 RVA: 0x0000A758 File Offset: 0x00008958
		[Preserve]
		public string LobbyId { get; }

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x060002E6 RID: 742 RVA: 0x0000A760 File Offset: 0x00008960
		[Preserve]
		public string ServiceId { get; }

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x060002E7 RID: 743 RVA: 0x0000A768 File Offset: 0x00008968
		[Preserve]
		public string ImpersonatedUserId { get; }

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x060002E8 RID: 744 RVA: 0x0000A770 File Offset: 0x00008970
		[Preserve]
		public string IfNoneMatch { get; }

		// Token: 0x060002E9 RID: 745 RVA: 0x0000A778 File Offset: 0x00008978
		[Preserve]
		public GetLobbyRequest(string lobbyId, string serviceId = null, string impersonatedUserId = null, string ifNoneMatch = null)
		{
			this.LobbyId = lobbyId;
			this.ServiceId = serviceId;
			this.ImpersonatedUserId = impersonatedUserId;
			this.IfNoneMatch = ifNoneMatch;
			this.PathAndQueryParams = "/" + lobbyId;
		}

		// Token: 0x060002EA RID: 746 RVA: 0x0000A7AE File Offset: 0x000089AE
		public string ConstructUrl(string requestBasePath)
		{
			return requestBasePath + this.PathAndQueryParams;
		}

		// Token: 0x060002EB RID: 747 RVA: 0x0000A7BC File Offset: 0x000089BC
		public byte[] ConstructBody()
		{
			return null;
		}

		// Token: 0x060002EC RID: 748 RVA: 0x0000A7C0 File Offset: 0x000089C0
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
			if (!string.IsNullOrEmpty(this.ServiceId))
			{
				dictionary.Add("Service-id", this.ServiceId);
			}
			if (!string.IsNullOrEmpty(this.ImpersonatedUserId))
			{
				dictionary.Add("Impersonated-user-id", this.ImpersonatedUserId);
			}
			if (!string.IsNullOrEmpty(this.IfNoneMatch))
			{
				dictionary.Add("If-none-match", this.IfNoneMatch);
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

		// Token: 0x04000150 RID: 336
		private string PathAndQueryParams;
	}
}
