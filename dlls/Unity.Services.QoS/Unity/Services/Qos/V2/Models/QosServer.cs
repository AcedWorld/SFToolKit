using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Qos.V2.Models
{
	// Token: 0x02000026 RID: 38
	[Preserve]
	[DataContract(Name = "QosServer")]
	public class QosServer
	{
		// Token: 0x06000098 RID: 152 RVA: 0x0000437C File Offset: 0x0000257C
		[Preserve]
		public QosServer(List<string> endpoints, QosServerAnnotations annotations)
		{
			this.Endpoints = endpoints;
			this.Annotations = annotations;
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000099 RID: 153 RVA: 0x00004392 File Offset: 0x00002592
		[Preserve]
		[DataMember(Name = "endpoints", IsRequired = true, EmitDefaultValue = true)]
		public List<string> Endpoints { get; }

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x0600009A RID: 154 RVA: 0x0000439A File Offset: 0x0000259A
		[Preserve]
		[DataMember(Name = "annotations", IsRequired = true, EmitDefaultValue = true)]
		public QosServerAnnotations Annotations { get; }

		// Token: 0x0600009B RID: 155 RVA: 0x000043A4 File Offset: 0x000025A4
		internal string SerializeAsPathParam()
		{
			string text = "";
			if (this.Endpoints != null)
			{
				text = text + "endpoints," + this.Endpoints.ToString() + ",";
			}
			if (this.Annotations != null)
			{
				text = text + "annotations," + this.Annotations.ToString();
			}
			return text;
		}

		// Token: 0x0600009C RID: 156 RVA: 0x000043FC File Offset: 0x000025FC
		internal Dictionary<string, string> GetAsQueryParam()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (this.Endpoints != null)
			{
				string value = this.Endpoints.ToString();
				dictionary.Add("endpoints", value);
			}
			return dictionary;
		}
	}
}
