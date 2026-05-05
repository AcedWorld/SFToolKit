using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Qos.Models
{
	// Token: 0x02000055 RID: 85
	[Preserve]
	[DataContract(Name = "QosServer")]
	internal class QosServer
	{
		// Token: 0x0600018E RID: 398 RVA: 0x0000685E File Offset: 0x00004A5E
		[Preserve]
		public QosServer(List<string> endpoints, string region, List<string> services = null)
		{
			this.Endpoints = endpoints;
			this.Region = region;
			this.Services = services;
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x0600018F RID: 399 RVA: 0x0000687B File Offset: 0x00004A7B
		[Preserve]
		[DataMember(Name = "endpoints", IsRequired = true, EmitDefaultValue = true)]
		public List<string> Endpoints { get; }

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000190 RID: 400 RVA: 0x00006883 File Offset: 0x00004A83
		[Preserve]
		[DataMember(Name = "region", IsRequired = true, EmitDefaultValue = true)]
		public string Region { get; }

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000191 RID: 401 RVA: 0x0000688B File Offset: 0x00004A8B
		[Preserve]
		[DataMember(Name = "services", EmitDefaultValue = false)]
		public List<string> Services { get; }

		// Token: 0x06000192 RID: 402 RVA: 0x00006894 File Offset: 0x00004A94
		internal string SerializeAsPathParam()
		{
			string text = "";
			if (this.Endpoints != null)
			{
				text = text + "endpoints," + this.Endpoints.ToString() + ",";
			}
			if (this.Region != null)
			{
				text = text + "region," + this.Region + ",";
			}
			if (this.Services != null)
			{
				text = text + "services," + this.Services.ToString();
			}
			return text;
		}

		// Token: 0x06000193 RID: 403 RVA: 0x0000690C File Offset: 0x00004B0C
		internal Dictionary<string, string> GetAsQueryParam()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (this.Endpoints != null)
			{
				string value = this.Endpoints.ToString();
				dictionary.Add("endpoints", value);
			}
			if (this.Region != null)
			{
				string value2 = this.Region.ToString();
				dictionary.Add("region", value2);
			}
			if (this.Services != null)
			{
				string value3 = this.Services.ToString();
				dictionary.Add("services", value3);
			}
			return dictionary;
		}
	}
}
