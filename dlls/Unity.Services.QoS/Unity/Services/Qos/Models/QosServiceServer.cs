using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Qos.Models
{
	// Token: 0x02000058 RID: 88
	[Preserve]
	[DataContract(Name = "QosServiceServer")]
	internal class QosServiceServer
	{
		// Token: 0x0600019C RID: 412 RVA: 0x00006A26 File Offset: 0x00004C26
		[Preserve]
		public QosServiceServer(List<string> endpoints, string region, Dictionary<string, List<string>> annotations = null)
		{
			this.Endpoints = endpoints;
			this.Region = region;
			this.Annotations = annotations;
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x0600019D RID: 413 RVA: 0x00006A43 File Offset: 0x00004C43
		[Preserve]
		[DataMember(Name = "endpoints", IsRequired = true, EmitDefaultValue = true)]
		public List<string> Endpoints { get; }

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x0600019E RID: 414 RVA: 0x00006A4B File Offset: 0x00004C4B
		[Preserve]
		[DataMember(Name = "region", IsRequired = true, EmitDefaultValue = true)]
		public string Region { get; }

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x0600019F RID: 415 RVA: 0x00006A53 File Offset: 0x00004C53
		[Preserve]
		[DataMember(Name = "annotations", EmitDefaultValue = false)]
		public Dictionary<string, List<string>> Annotations { get; }

		// Token: 0x060001A0 RID: 416 RVA: 0x00006A5C File Offset: 0x00004C5C
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
			if (this.Annotations != null)
			{
				text = text + "annotations," + this.Annotations.ToString();
			}
			return text;
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x00006AD4 File Offset: 0x00004CD4
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
			if (this.Annotations != null)
			{
				string value3 = this.Annotations.ToString();
				dictionary.Add("annotations", value3);
			}
			return dictionary;
		}
	}
}
