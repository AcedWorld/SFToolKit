using System;
using System.Collections.Generic;
using Unity.Services.Authentication.Internal;
using Unity.Services.Relay.Models;
using Unity.Services.Relay.Scheduler;
using UnityEngine;
using UnityEngine.Scripting;

namespace Unity.Services.Relay.RelayAllocations
{
	// Token: 0x0200004D RID: 77
	[Preserve]
	internal class CreateAllocationRequest : RelayAllocationsApiBaseRequest
	{
		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000170 RID: 368 RVA: 0x000054E7 File Offset: 0x000036E7
		[Preserve]
		public AllocationRequest AllocationRequest { get; }

		// Token: 0x06000171 RID: 369 RVA: 0x000054EF File Offset: 0x000036EF
		[Preserve]
		public CreateAllocationRequest(AllocationRequest allocationRequest)
		{
			this.AllocationRequest = allocationRequest;
			this.PathAndQueryParams = "/v1/allocate";
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00005509 File Offset: 0x00003709
		public string ConstructUrl(string requestBasePath)
		{
			return requestBasePath + this.PathAndQueryParams;
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00005517 File Offset: 0x00003717
		public byte[] ConstructBody()
		{
			return base.ConstructBody(this.AllocationRequest);
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00005528 File Offset: 0x00003728
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

		// Token: 0x040000AA RID: 170
		private string PathAndQueryParams;
	}
}
