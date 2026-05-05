using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Relay.Models
{
	// Token: 0x02000027 RID: 39
	[Preserve]
	[DataContract(Name = "JoinResponseBody")]
	public class JoinResponseBody
	{
		// Token: 0x0600009C RID: 156 RVA: 0x000035C0 File Offset: 0x000017C0
		[Preserve]
		public JoinResponseBody(ResponseMeta meta, JoinData data)
		{
			this.Meta = meta;
			this.Data = data;
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600009D RID: 157 RVA: 0x000035D6 File Offset: 0x000017D6
		[Preserve]
		[DataMember(Name = "meta", IsRequired = true, EmitDefaultValue = true)]
		public ResponseMeta Meta { get; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x0600009E RID: 158 RVA: 0x000035DE File Offset: 0x000017DE
		[Preserve]
		[DataMember(Name = "data", IsRequired = true, EmitDefaultValue = true)]
		public JoinData Data { get; }

		// Token: 0x0600009F RID: 159 RVA: 0x000035E8 File Offset: 0x000017E8
		internal string SerializeAsPathParam()
		{
			string text = "";
			if (this.Meta != null)
			{
				text = text + "meta," + this.Meta.ToString() + ",";
			}
			if (this.Data != null)
			{
				text = text + "data," + this.Data.ToString();
			}
			return text;
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x0000363F File Offset: 0x0000183F
		internal Dictionary<string, string> GetAsQueryParam()
		{
			return new Dictionary<string, string>();
		}
	}
}
