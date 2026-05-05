using System;
using System.Collections.Generic;
using Unity.Services.Authentication.Internal;
using Unity.Services.Lobbies.Models;
using Unity.Services.Lobbies.Scheduler;
using UnityEngine;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Lobby
{
	// Token: 0x0200006F RID: 111
	[Preserve]
	internal class JoinLobbyByCodeRequest : LobbyApiBaseRequest
	{
		// Token: 0x170000EA RID: 234
		// (get) Token: 0x060002F5 RID: 757 RVA: 0x0000AB88 File Offset: 0x00008D88
		[Preserve]
		public string ServiceId { get; }

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x060002F6 RID: 758 RVA: 0x0000AB90 File Offset: 0x00008D90
		[Preserve]
		public string ImpersonatedUserId { get; }

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x060002F7 RID: 759 RVA: 0x0000AB98 File Offset: 0x00008D98
		[Preserve]
		public JoinByCodeRequest JoinByCodeRequest { get; }

		// Token: 0x060002F8 RID: 760 RVA: 0x0000ABA0 File Offset: 0x00008DA0
		[Preserve]
		public JoinLobbyByCodeRequest(string serviceId = null, string impersonatedUserId = null, JoinByCodeRequest joinByCodeRequest = null)
		{
			this.ServiceId = serviceId;
			this.ImpersonatedUserId = impersonatedUserId;
			this.JoinByCodeRequest = joinByCodeRequest;
			this.PathAndQueryParams = "/joinbycode";
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x0000ABC8 File Offset: 0x00008DC8
		public string ConstructUrl(string requestBasePath)
		{
			return requestBasePath + this.PathAndQueryParams;
		}

		// Token: 0x060002FA RID: 762 RVA: 0x0000ABD6 File Offset: 0x00008DD6
		public byte[] ConstructBody()
		{
			if (this.JoinByCodeRequest != null)
			{
				return base.ConstructBody(this.JoinByCodeRequest);
			}
			return null;
		}

		// Token: 0x060002FB RID: 763 RVA: 0x0000ABF0 File Offset: 0x00008DF0
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

		// Token: 0x04000159 RID: 345
		private string PathAndQueryParams;
	}
}
