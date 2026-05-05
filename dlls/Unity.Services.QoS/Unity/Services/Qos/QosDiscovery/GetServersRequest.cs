using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Services.Authentication.Internal;
using Unity.Services.Qos.Scheduler;
using UnityEngine;
using UnityEngine.Scripting;

namespace Unity.Services.Qos.QosDiscovery
{
	// Token: 0x02000077 RID: 119
	[Preserve]
	internal class GetServersRequest : QosDiscoveryApiBaseRequest
	{
		// Token: 0x17000087 RID: 135
		// (get) Token: 0x0600024E RID: 590 RVA: 0x00008447 File Offset: 0x00006647
		[Preserve]
		public List<string> Region { get; }

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x0600024F RID: 591 RVA: 0x0000844F File Offset: 0x0000664F
		[Preserve]
		public string Service { get; }

		// Token: 0x06000250 RID: 592 RVA: 0x00008458 File Offset: 0x00006658
		[Preserve]
		public GetServersRequest(List<string> region = null, string service = null)
		{
			this.Region = region;
			this.Service = service;
			this.PathAndQueryParams = "/v1/servers";
			List<string> list = new List<string>();
			if (this.Region != null)
			{
				List<string> values = (from v in this.Region
				select v.ToString()).ToList<string>();
				list = base.AddParamsToQueryParams(list, "region", values, "form", true);
			}
			if (!string.IsNullOrEmpty(this.Service))
			{
				list = base.AddParamsToQueryParams(list, "service", this.Service);
			}
			if (list.Count > 0)
			{
				this.PathAndQueryParams = this.PathAndQueryParams + "?" + string.Join("&", list);
			}
		}

		// Token: 0x06000251 RID: 593 RVA: 0x00008520 File Offset: 0x00006720
		public string ConstructUrl(string requestBasePath)
		{
			return requestBasePath + this.PathAndQueryParams;
		}

		// Token: 0x06000252 RID: 594 RVA: 0x0000852E File Offset: 0x0000672E
		public byte[] ConstructBody()
		{
			return null;
		}

		// Token: 0x06000253 RID: 595 RVA: 0x00008534 File Offset: 0x00006734
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

		// Token: 0x040000EB RID: 235
		private string PathAndQueryParams;
	}
}
