using System;
using System.Collections.Generic;
using Unity.Services.Authentication.Internal;
using Unity.Services.Lobbies.Models;
using Unity.Services.Lobbies.Scheduler;
using UnityEngine;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Lobby
{
	// Token: 0x02000070 RID: 112
	[Preserve]
	internal class JoinLobbyByIdRequest : LobbyApiBaseRequest
	{
		// Token: 0x170000ED RID: 237
		// (get) Token: 0x060002FC RID: 764 RVA: 0x0000AD8C File Offset: 0x00008F8C
		[Preserve]
		public string LobbyId { get; }

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x060002FD RID: 765 RVA: 0x0000AD94 File Offset: 0x00008F94
		[Preserve]
		public string ServiceId { get; }

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x060002FE RID: 766 RVA: 0x0000AD9C File Offset: 0x00008F9C
		[Preserve]
		public string ImpersonatedUserId { get; }

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x060002FF RID: 767 RVA: 0x0000ADA4 File Offset: 0x00008FA4
		[Preserve]
		public JoinByIdRequest JoinByIdRequest { get; }

		// Token: 0x06000300 RID: 768 RVA: 0x0000ADAC File Offset: 0x00008FAC
		[Preserve]
		public JoinLobbyByIdRequest(string lobbyId, string serviceId = null, string impersonatedUserId = null, JoinByIdRequest joinByIdRequest = null)
		{
			this.LobbyId = lobbyId;
			this.ServiceId = serviceId;
			this.ImpersonatedUserId = impersonatedUserId;
			this.JoinByIdRequest = joinByIdRequest;
			this.PathAndQueryParams = "/" + lobbyId + "/join";
		}

		// Token: 0x06000301 RID: 769 RVA: 0x0000ADE7 File Offset: 0x00008FE7
		public string ConstructUrl(string requestBasePath)
		{
			return requestBasePath + this.PathAndQueryParams;
		}

		// Token: 0x06000302 RID: 770 RVA: 0x0000ADF5 File Offset: 0x00008FF5
		public byte[] ConstructBody()
		{
			if (this.JoinByIdRequest != null)
			{
				return base.ConstructBody(this.JoinByIdRequest);
			}
			return null;
		}

		// Token: 0x06000303 RID: 771 RVA: 0x0000AE10 File Offset: 0x00009010
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

		// Token: 0x0400015E RID: 350
		private string PathAndQueryParams;
	}
}
