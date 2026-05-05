using System;
using System.Collections.Generic;
using Unity.Services.Authentication.Internal;
using Unity.Services.Lobbies.Models;
using Unity.Services.Lobbies.Scheduler;
using UnityEngine;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Lobby
{
	// Token: 0x02000068 RID: 104
	[Preserve]
	internal class CreateLobbyRequest : LobbyApiBaseRequest
	{
		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x060002C3 RID: 707 RVA: 0x00009DA0 File Offset: 0x00007FA0
		[Preserve]
		public string ServiceId { get; }

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x060002C4 RID: 708 RVA: 0x00009DA8 File Offset: 0x00007FA8
		[Preserve]
		public string ImpersonatedUserId { get; }

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x060002C5 RID: 709 RVA: 0x00009DB0 File Offset: 0x00007FB0
		[Preserve]
		public CreateRequest CreateRequest { get; }

		// Token: 0x060002C6 RID: 710 RVA: 0x00009DB8 File Offset: 0x00007FB8
		[Preserve]
		public CreateLobbyRequest(string serviceId = null, string impersonatedUserId = null, CreateRequest createRequest = null)
		{
			this.ServiceId = serviceId;
			this.ImpersonatedUserId = impersonatedUserId;
			this.CreateRequest = createRequest;
			this.PathAndQueryParams = "/create";
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x00009DE0 File Offset: 0x00007FE0
		public string ConstructUrl(string requestBasePath)
		{
			return requestBasePath + this.PathAndQueryParams;
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x00009DEE File Offset: 0x00007FEE
		public byte[] ConstructBody()
		{
			if (this.CreateRequest != null)
			{
				return base.ConstructBody(this.CreateRequest);
			}
			return null;
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x00009E08 File Offset: 0x00008008
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

		// Token: 0x0400013C RID: 316
		private string PathAndQueryParams;
	}
}
