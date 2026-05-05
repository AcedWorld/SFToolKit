using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Qos.Models
{
	// Token: 0x02000059 RID: 89
	[Preserve]
	[DataContract(Name = "QosServiceServersList")]
	internal class QosServiceServersList
	{
		// Token: 0x060001A2 RID: 418 RVA: 0x00006B48 File Offset: 0x00004D48
		[Preserve]
		public QosServiceServersList(List<QosServiceServer> servers)
		{
			this.Servers = servers;
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060001A3 RID: 419 RVA: 0x00006B57 File Offset: 0x00004D57
		[Preserve]
		[DataMember(Name = "servers", IsRequired = true, EmitDefaultValue = true)]
		public List<QosServiceServer> Servers { get; }

		// Token: 0x060001A4 RID: 420 RVA: 0x00006B60 File Offset: 0x00004D60
		internal string SerializeAsPathParam()
		{
			string text = "";
			if (this.Servers != null)
			{
				text = text + "servers," + this.Servers.ToString();
			}
			return text;
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x00006B93 File Offset: 0x00004D93
		internal Dictionary<string, string> GetAsQueryParam()
		{
			return new Dictionary<string, string>();
		}
	}
}
