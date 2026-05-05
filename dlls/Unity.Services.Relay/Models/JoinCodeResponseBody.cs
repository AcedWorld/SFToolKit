using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Relay.Models
{
	// Token: 0x02000024 RID: 36
	[Preserve]
	[DataContract(Name = "JoinCodeResponseBody")]
	public class JoinCodeResponseBody
	{
		// Token: 0x0600008E RID: 142 RVA: 0x00003434 File Offset: 0x00001634
		[Preserve]
		public JoinCodeResponseBody(ResponseMeta meta, ResponseLinks links, JoinCodeData data)
		{
			this.Meta = meta;
			this.Links = links;
			this.Data = data;
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x0600008F RID: 143 RVA: 0x00003451 File Offset: 0x00001651
		[Preserve]
		[DataMember(Name = "meta", IsRequired = true, EmitDefaultValue = true)]
		public ResponseMeta Meta { get; }

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000090 RID: 144 RVA: 0x00003459 File Offset: 0x00001659
		[Preserve]
		[DataMember(Name = "links", IsRequired = true, EmitDefaultValue = true)]
		public ResponseLinks Links { get; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000091 RID: 145 RVA: 0x00003461 File Offset: 0x00001661
		[Preserve]
		[DataMember(Name = "data", IsRequired = true, EmitDefaultValue = true)]
		public JoinCodeData Data { get; }

		// Token: 0x06000092 RID: 146 RVA: 0x0000346C File Offset: 0x0000166C
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

		// Token: 0x06000093 RID: 147 RVA: 0x000034E7 File Offset: 0x000016E7
		internal Dictionary<string, string> GetAsQueryParam()
		{
			return new Dictionary<string, string>();
		}
	}
}
