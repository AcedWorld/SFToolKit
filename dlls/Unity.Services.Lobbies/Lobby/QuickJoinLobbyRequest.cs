using System;
using System.Collections.Generic;
using Unity.Services.Authentication.Internal;
using Unity.Services.Lobbies.Models;
using Unity.Services.Lobbies.Scheduler;
using UnityEngine;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Lobby
{
	// Token: 0x02000072 RID: 114
	[Preserve]
	internal class QuickJoinLobbyRequest : LobbyApiBaseRequest
	{
		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x0600030B RID: 779 RVA: 0x0000B1B0 File Offset: 0x000093B0
		[Preserve]
		public string ServiceId { get; }

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x0600030C RID: 780 RVA: 0x0000B1B8 File Offset: 0x000093B8
		[Preserve]
		public string ImpersonatedUserId { get; }

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x0600030D RID: 781 RVA: 0x0000B1C0 File Offset: 0x000093C0
		[Preserve]
		public QuickJoinRequest QuickJoinRequest { get; }

		// Token: 0x0600030E RID: 782 RVA: 0x0000B1C8 File Offset: 0x000093C8
		[Preserve]
		public QuickJoinLobbyRequest(string serviceId = null, string impersonatedUserId = null, QuickJoinRequest quickJoinRequest = null)
		{
			this.ServiceId = serviceId;
			this.ImpersonatedUserId = impersonatedUserId;
			this.QuickJoinRequest = quickJoinRequest;
			this.PathAndQueryParams = "/quickjoin";
		}

		// Token: 0x0600030F RID: 783 RVA: 0x0000B1F0 File Offset: 0x000093F0
		public string ConstructUrl(string requestBasePath)
		{
			return requestBasePath + this.PathAndQueryParams;
		}

		// Token: 0x06000310 RID: 784 RVA: 0x0000B1FE File Offset: 0x000093FE
		public byte[] ConstructBody()
		{
			if (this.QuickJoinRequest != null)
			{
				return base.ConstructBody(this.QuickJoinRequest);
			}
			return null;
		}

		// Token: 0x06000311 RID: 785 RVA: 0x0000B218 File Offset: 0x00009418
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

		// Token: 0x04000166 RID: 358
		private string PathAndQueryParams;
	}
}
