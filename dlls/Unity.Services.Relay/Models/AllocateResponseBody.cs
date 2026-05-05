using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Relay.Models
{
	// Token: 0x0200001B RID: 27
	[Preserve]
	[DataContract(Name = "AllocateResponseBody")]
	public class AllocateResponseBody
	{
		// Token: 0x06000055 RID: 85 RVA: 0x00002A01 File Offset: 0x00000C01
		[Preserve]
		public AllocateResponseBody(ResponseMeta meta, AllocationData data, ResponseLinks links = null)
		{
			this.Meta = meta;
			this.Links = links;
			this.Data = data;
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000056 RID: 86 RVA: 0x00002A1E File Offset: 0x00000C1E
		[Preserve]
		[DataMember(Name = "meta", IsRequired = true, EmitDefaultValue = true)]
		public ResponseMeta Meta { get; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000057 RID: 87 RVA: 0x00002A26 File Offset: 0x00000C26
		[Preserve]
		[DataMember(Name = "links", EmitDefaultValue = false)]
		public ResponseLinks Links { get; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000058 RID: 88 RVA: 0x00002A2E File Offset: 0x00000C2E
		[Preserve]
		[DataMember(Name = "data", IsRequired = true, EmitDefaultValue = true)]
		public AllocationData Data { get; }

		// Token: 0x06000059 RID: 89 RVA: 0x00002A38 File Offset: 0x00000C38
		internal string SerializeAsPathParam()
		{
			string text = "";
			if (this.Meta != null)
			{
				text = text + "meta," + this.Meta.ToString() + ",";
			}
			if (this.Links != null)
			{
				text = text + "links," + this.Links.ToString() + ",";
			}
			if (this.Data != null)
			{
				text = text + "data," + this.Data.ToString();
			}
			return text;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00002AB3 File Offset: 0x00000CB3
		internal Dictionary<string, string> GetAsQueryParam()
		{
			return new Dictionary<string, string>();
		}
	}
}
