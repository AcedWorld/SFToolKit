using System;
using System.Collections.Generic;
using Unity.Services.Authentication.Internal;
using Unity.Services.Lobbies.Scheduler;
using UnityEngine;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Lobby
{
	// Token: 0x0200006C RID: 108
	[Preserve]
	internal class GetJoinedLobbiesRequest : LobbyApiBaseRequest
	{
		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x060002DF RID: 735 RVA: 0x0000A580 File Offset: 0x00008780
		[Preserve]
		public string ServiceId { get; }

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x060002E0 RID: 736 RVA: 0x0000A588 File Offset: 0x00008788
		[Preserve]
		public string ImpersonatedUserId { get; }

		// Token: 0x060002E1 RID: 737 RVA: 0x0000A590 File Offset: 0x00008790
		[Preserve]
		public GetJoinedLobbiesRequest(string serviceId = null, string impersonatedUserId = null)
		{
			this.ServiceId = serviceId;
			this.ImpersonatedUserId = impersonatedUserId;
			this.PathAndQueryParams = "/joined";
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x0000A5B1 File Offset: 0x000087B1
		public string ConstructUrl(string requestBasePath)
		{
			return requestBasePath + this.PathAndQueryParams;
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x0000A5BF File Offset: 0x000087BF
		public byte[] ConstructBody()
		{
			return null;
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x0000A5C4 File Offset: 0x000087C4
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

		// Token: 0x0400014B RID: 331
		private string PathAndQueryParams;
	}
}
