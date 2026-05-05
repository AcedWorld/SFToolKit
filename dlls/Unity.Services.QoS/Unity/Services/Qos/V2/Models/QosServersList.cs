using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Qos.V2.Models
{
	// Token: 0x02000028 RID: 40
	[Preserve]
	[DataContract(Name = "QosServersList")]
	internal class QosServersList
	{
		// Token: 0x060000A7 RID: 167 RVA: 0x000046B0 File Offset: 0x000028B0
		[Preserve]
		public QosServersList(List<QosServer> servers)
		{
			this.Servers = servers;
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000A8 RID: 168 RVA: 0x000046BF File Offset: 0x000028BF
		[Preserve]
		[DataMember(Name = "servers", IsRequired = true, EmitDefaultValue = true)]
		public List<QosServer> Servers { get; }

		// Token: 0x060000A9 RID: 169 RVA: 0x000046C8 File Offset: 0x000028C8
		internal string SerializeAsPathParam()
		{
			string text = "";
			if (this.Servers != null)
			{
				text = text + "servers," + this.Servers.ToString();
			}
			return text;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x000046FB File Offset: 0x000028FB
		internal Dictionary<string, string> GetAsQueryParam()
		{
			return new Dictionary<string, string>();
		}
	}
}
