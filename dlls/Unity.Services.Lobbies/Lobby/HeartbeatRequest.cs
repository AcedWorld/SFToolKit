using System;
using System.Collections.Generic;
using Unity.Services.Authentication.Internal;
using Unity.Services.Lobbies.Scheduler;
using UnityEngine;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Lobby
{
	// Token: 0x0200006E RID: 110
	[Preserve]
	internal class HeartbeatRequest : LobbyApiBaseRequest
	{
		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x060002ED RID: 749 RVA: 0x0000A970 File Offset: 0x00008B70
		[Preserve]
		public string LobbyId { get; }

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x060002EE RID: 750 RVA: 0x0000A978 File Offset: 0x00008B78
		[Preserve]
		public string ServiceId { get; }

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x060002EF RID: 751 RVA: 0x0000A980 File Offset: 0x00008B80
		[Preserve]
		public string ImpersonatedUserId { get; }

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x060002F0 RID: 752 RVA: 0x0000A988 File Offset: 0x00008B88
		[Preserve]
		public object Body { get; }

		// Token: 0x060002F1 RID: 753 RVA: 0x0000A990 File Offset: 0x00008B90
		[Preserve]
		public HeartbeatRequest(string lobbyId, string serviceId = null, string impersonatedUserId = null, object body = null)
		{
			this.LobbyId = lobbyId;
			this.ServiceId = serviceId;
			this.ImpersonatedUserId = impersonatedUserId;
			this.Body = body;
			this.PathAndQueryParams = "/" + lobbyId + "/heartbeat";
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x0000A9CB File Offset: 0x00008BCB
		public string ConstructUrl(string requestBasePath)
		{
			return requestBasePath + this.PathAndQueryParams;
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x0000A9D9 File Offset: 0x00008BD9
		public byte[] ConstructBody()
		{
			if (this.Body != null)
			{
				return base.ConstructBody(this.Body);
			}
			return null;
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x0000A9F4 File Offset: 0x00008BF4
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

		// Token: 0x04000155 RID: 341
		private string PathAndQueryParams;
	}
}
