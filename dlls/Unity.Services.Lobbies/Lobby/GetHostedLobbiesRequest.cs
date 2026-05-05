using System;
using System.Collections.Generic;
using Unity.Services.Authentication.Internal;
using Unity.Services.Lobbies.Scheduler;
using UnityEngine;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Lobby
{
	// Token: 0x0200006B RID: 107
	[Preserve]
	internal class GetHostedLobbiesRequest : LobbyApiBaseRequest
	{
		// Token: 0x170000DE RID: 222
		// (get) Token: 0x060002D9 RID: 729 RVA: 0x0000A3A8 File Offset: 0x000085A8
		[Preserve]
		public string ServiceId { get; }

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x060002DA RID: 730 RVA: 0x0000A3B0 File Offset: 0x000085B0
		[Preserve]
		public string ImpersonatedUserId { get; }

		// Token: 0x060002DB RID: 731 RVA: 0x0000A3B8 File Offset: 0x000085B8
		[Preserve]
		public GetHostedLobbiesRequest(string serviceId = null, string impersonatedUserId = null)
		{
			this.ServiceId = serviceId;
			this.ImpersonatedUserId = impersonatedUserId;
			this.PathAndQueryParams = "/hosted";
		}

		// Token: 0x060002DC RID: 732 RVA: 0x0000A3D9 File Offset: 0x000085D9
		public string ConstructUrl(string requestBasePath)
		{
			return requestBasePath + this.PathAndQueryParams;
		}

		// Token: 0x060002DD RID: 733 RVA: 0x0000A3E7 File Offset: 0x000085E7
		public byte[] ConstructBody()
		{
			return null;
		}

		// Token: 0x060002DE RID: 734 RVA: 0x0000A3EC File Offset: 0x000085EC
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
			if (operationConfiguration != null && operationConfiguration.Headers != null)
			{
				foreach (KeyValuePair<string, string> keyValuePair in operationConfiguration.Headers)
				{
					dictionary[keyValuePair.Key] = keyValuePair.Value;
				}
			}
			return dictionary;
		}

		// Token: 0x04000148 RID: 328
		private string PathAndQueryParams;
	}
}
