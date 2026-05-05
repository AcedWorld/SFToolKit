using System;
using System.Collections.Generic;
using Unity.Services.Authentication.Internal;
using Unity.Services.Lobbies.Scheduler;
using UnityEngine;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Lobby
{
	// Token: 0x02000073 RID: 115
	[Preserve]
	internal class ReconnectRequest : LobbyApiBaseRequest
	{
		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x06000312 RID: 786 RVA: 0x0000B3B4 File Offset: 0x000095B4
		[Preserve]
		public string LobbyId { get; }

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x06000313 RID: 787 RVA: 0x0000B3BC File Offset: 0x000095BC
		[Preserve]
		public string ServiceId { get; }

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x06000314 RID: 788 RVA: 0x0000B3C4 File Offset: 0x000095C4
		[Preserve]
		public string ImpersonatedUserId { get; }

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x06000315 RID: 789 RVA: 0x0000B3CC File Offset: 0x000095CC
		[Preserve]
		public object Body { get; }

		// Token: 0x06000316 RID: 790 RVA: 0x0000B3D4 File Offset: 0x000095D4
		[Preserve]
		public ReconnectRequest(string lobbyId, string serviceId = null, string impersonatedUserId = null, object body = null)
		{
			this.LobbyId = lobbyId;
			this.ServiceId = serviceId;
			this.ImpersonatedUserId = impersonatedUserId;
			this.Body = body;
			this.PathAndQueryParams = "/" + lobbyId + "/reconnect";
		}

		// Token: 0x06000317 RID: 791 RVA: 0x0000B40F File Offset: 0x0000960F
		public string ConstructUrl(string requestBasePath)
		{
			return requestBasePath + this.PathAndQueryParams;
		}

		// Token: 0x06000318 RID: 792 RVA: 0x0000B41D File Offset: 0x0000961D
		public byte[] ConstructBody()
		{
			if (this.Body != null)
			{
				return base.ConstructBody(this.Body);
			}
			return null;
		}

		// Token: 0x06000319 RID: 793 RVA: 0x0000B438 File Offset: 0x00009638
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

		// Token: 0x0400016B RID: 363
		private string PathAndQueryParams;
	}
}
