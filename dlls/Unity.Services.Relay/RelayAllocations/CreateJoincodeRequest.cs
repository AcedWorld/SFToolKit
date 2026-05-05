using System;
using System.Collections.Generic;
using Unity.Services.Authentication.Internal;
using Unity.Services.Relay.Models;
using Unity.Services.Relay.Scheduler;
using UnityEngine;
using UnityEngine.Scripting;

namespace Unity.Services.Relay.RelayAllocations
{
	// Token: 0x0200004E RID: 78
	[Preserve]
	internal class CreateJoincodeRequest : RelayAllocationsApiBaseRequest
	{
		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000175 RID: 373 RVA: 0x00005688 File Offset: 0x00003888
		[Preserve]
		public JoinCodeRequest JoinCodeRequest { get; }

		// Token: 0x06000176 RID: 374 RVA: 0x00005690 File Offset: 0x00003890
		[Preserve]
		public CreateJoincodeRequest(JoinCodeRequest joinCodeRequest)
		{
			this.JoinCodeRequest = joinCodeRequest;
			this.PathAndQueryParams = "/v1/joincode";
		}

		// Token: 0x06000177 RID: 375 RVA: 0x000056AA File Offset: 0x000038AA
		public string ConstructUrl(string requestBasePath)
		{
			return requestBasePath + this.PathAndQueryParams;
		}

		// Token: 0x06000178 RID: 376 RVA: 0x000056B8 File Offset: 0x000038B8
		public byte[] ConstructBody()
		{
			return base.ConstructBody(this.JoinCodeRequest);
		}

		// Token: 0x06000179 RID: 377 RVA: 0x000056C8 File Offset: 0x000038C8
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

		// Token: 0x040000AC RID: 172
		private string PathAndQueryParams;
	}
}
