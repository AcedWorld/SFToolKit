using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Services.Authentication.Internal;
using Unity.Services.Qos.Scheduler;
using UnityEngine;
using UnityEngine.Scripting;

namespace Unity.Services.Qos.QosDiscovery
{
	// Token: 0x02000078 RID: 120
	[Preserve]
	internal class GetServiceServersRequest : QosDiscoveryApiBaseRequest
	{
		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000254 RID: 596 RVA: 0x0000868C File Offset: 0x0000688C
		[Preserve]
		public string ServiceId { get; }

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000255 RID: 597 RVA: 0x00008694 File Offset: 0x00006894
		[Preserve]
		public List<string> Region { get; }

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000256 RID: 598 RVA: 0x0000869C File Offset: 0x0000689C
		[Preserve]
		public List<string> Fleet { get; }

		// Token: 0x06000257 RID: 599 RVA: 0x000086A4 File Offset: 0x000068A4
		[Preserve]
		public GetServiceServersRequest(string serviceId, List<string> region = null, List<string> fleet = null)
		{
			this.ServiceId = serviceId;
			this.Region = region;
			this.Fleet = fleet;
			this.PathAndQueryParams = "/v1/services/" + serviceId + "/servers";
			List<string> list = new List<string>();
			if (this.Region != null)
			{
				List<string> values = (from v in this.Region
				select v.ToString()).ToList<string>();
				list = base.AddParamsToQueryParams(list, "region", values, "form", true);
			}
			if (this.Fleet != null)
			{
				List<string> values2 = (from v in this.Fleet
				select v.ToString()).ToList<string>();
				list = base.AddParamsToQueryParams(list, "fleet", values2, "form", true);
			}
			if (list.Count > 0)
			{
				this.PathAndQueryParams = this.PathAndQueryParams + "?" + string.Join("&", list);
			}
		}

		// Token: 0x06000258 RID: 600 RVA: 0x000087AA File Offset: 0x000069AA
		public string ConstructUrl(string requestBasePath)
		{
			return requestBasePath + this.PathAndQueryParams;
		}

		// Token: 0x06000259 RID: 601 RVA: 0x000087B8 File Offset: 0x000069B8
		public byte[] ConstructBody()
		{
			return null;
		}

		// Token: 0x0600025A RID: 602 RVA: 0x000087BC File Offset: 0x000069BC
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

		// Token: 0x040000EC RID: 236
		public const string ServiceIdRelay = "relay";

		// Token: 0x040000ED RID: 237
		public const string ServiceIdMultiplay = "multiplay";

		// Token: 0x040000F1 RID: 241
		private string PathAndQueryParams;
	}
}
