using System;
using System.Collections.Generic;
using Unity.Services.Authentication.Internal;
using Unity.Services.Relay.Models;
using Unity.Services.Relay.Scheduler;
using UnityEngine;
using UnityEngine.Scripting;

namespace Unity.Services.Relay.RelayAllocations
{
	// Token: 0x0200004F RID: 79
	[Preserve]
	internal class JoinRelayRequest : RelayAllocationsApiBaseRequest
	{
		// Token: 0x17000062 RID: 98
		// (get) Token: 0x0600017A RID: 378 RVA: 0x00005828 File Offset: 0x00003A28
		[Preserve]
		public JoinRequest JoinRequest { get; }

		// Token: 0x0600017B RID: 379 RVA: 0x00005830 File Offset: 0x00003A30
		[Preserve]
		public JoinRelayRequest(JoinRequest joinRequest)
		{
			this.JoinRequest = joinRequest;
			this.PathAndQueryParams = "/v1/join";
		}

		// Token: 0x0600017C RID: 380 RVA: 0x0000584A File Offset: 0x00003A4A
		public string ConstructUrl(string requestBasePath)
		{
			return requestBasePath + this.PathAndQueryParams;
		}

		// Token: 0x0600017D RID: 381 RVA: 0x00005858 File Offset: 0x00003A58
		public byte[] ConstructBody()
		{
			return base.ConstructBody(this.JoinRequest);
		}

		// Token: 0x0600017E RID: 382 RVA: 0x00005868 File Offset: 0x00003A68
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
			if (operationConfiguration != null && operationConfiguration.Headers != null)
			{
				foreach (KeyValuePair<string, string> keyValuePair in operationConfiguration.Headers)
				{
					dictionary[keyValuePair.Key] = keyValuePair.Value;
				}
			}
			return dictionary;
		}

		// Token: 0x040000AE RID: 174
		private string PathAndQueryParams;
	}
}
