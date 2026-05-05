using System;
using System.Collections.Generic;
using Unity.Services.Authentication.Internal;
using Unity.Services.Lobbies.Models;
using Unity.Services.Lobbies.Scheduler;
using UnityEngine;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Lobby
{
	// Token: 0x02000069 RID: 105
	[Preserve]
	internal class CreateOrJoinLobbyRequest : LobbyApiBaseRequest
	{
		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x060002CA RID: 714 RVA: 0x00009FA4 File Offset: 0x000081A4
		[Preserve]
		public string LobbyId { get; }

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x060002CB RID: 715 RVA: 0x00009FAC File Offset: 0x000081AC
		[Preserve]
		public string ServiceId { get; }

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x060002CC RID: 716 RVA: 0x00009FB4 File Offset: 0x000081B4
		[Preserve]
		public string ImpersonatedUserId { get; }

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x060002CD RID: 717 RVA: 0x00009FBC File Offset: 0x000081BC
		[Preserve]
		public CreateRequest CreateRequest { get; }

		// Token: 0x060002CE RID: 718 RVA: 0x00009FC4 File Offset: 0x000081C4
		[Preserve]
		public CreateOrJoinLobbyRequest(string lobbyId, string serviceId = null, string impersonatedUserId = null, CreateRequest createRequest = null)
		{
			this.LobbyId = lobbyId;
			this.ServiceId = serviceId;
			this.ImpersonatedUserId = impersonatedUserId;
			this.CreateRequest = createRequest;
			this.PathAndQueryParams = "/" + lobbyId + "/createorjoin";
		}

		// Token: 0x060002CF RID: 719 RVA: 0x00009FFF File Offset: 0x000081FF
		public string ConstructUrl(string requestBasePath)
		{
			return requestBasePath + this.PathAndQueryParams;
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x0000A00D File Offset: 0x0000820D
		public byte[] ConstructBody()
		{
			if (this.CreateRequest != null)
			{
				return base.ConstructBody(this.CreateRequest);
			}
			return null;
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x0000A028 File Offset: 0x00008228
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

		// Token: 0x04000141 RID: 321
		private string PathAndQueryParams;
	}
}
