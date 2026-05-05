using System;
using System.Collections.Generic;
using Unity.Services.Authentication.Internal;
using Unity.Services.Relay.Scheduler;
using UnityEngine;
using UnityEngine.Scripting;

namespace Unity.Services.Relay.RelayAllocations
{
	// Token: 0x02000050 RID: 80
	[Preserve]
	internal class ListRegionsRequest : RelayAllocationsApiBaseRequest
	{
		// Token: 0x0600017F RID: 383 RVA: 0x000059C8 File Offset: 0x00003BC8
		[Preserve]
		public ListRegionsRequest()
		{
			this.PathAndQueryParams = "/v1/regions";
		}

		// Token: 0x06000180 RID: 384 RVA: 0x000059DB File Offset: 0x00003BDB
		public string ConstructUrl(string requestBasePath)
		{
			return requestBasePath + this.PathAndQueryParams;
		}

		// Token: 0x06000181 RID: 385 RVA: 0x000059E9 File Offset: 0x00003BE9
		public byte[] ConstructBody()
		{
			return null;
		}

		// Token: 0x06000182 RID: 386 RVA: 0x000059EC File Offset: 0x00003BEC
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
			if (operationConfiguration != null && operationConfiguration.Headers != null)
			{
				foreach (KeyValuePair<string, string> keyValuePair in operationConfiguration.Headers)
				{
					dictionary[keyValuePair.Key] = keyValuePair.Value;
				}
			}
			return dictionary;
		}

		// Token: 0x040000AF RID: 175
		private string PathAndQueryParams;
	}
}
