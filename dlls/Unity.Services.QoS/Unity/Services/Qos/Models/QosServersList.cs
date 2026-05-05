using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Qos.Models
{
	// Token: 0x02000056 RID: 86
	[Preserve]
	[DataContract(Name = "QosServersList")]
	internal class QosServersList
	{
		// Token: 0x06000194 RID: 404 RVA: 0x00006980 File Offset: 0x00004B80
		[Preserve]
		public QosServersList(List<QosServer> servers)
		{
			this.Servers = servers;
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000195 RID: 405 RVA: 0x0000698F File Offset: 0x00004B8F
		[Preserve]
		[DataMember(Name = "servers", IsRequired = true, EmitDefaultValue = true)]
		public List<QosServer> Servers { get; }

		// Token: 0x06000196 RID: 406 RVA: 0x00006998 File Offset: 0x00004B98
		internal string SerializeAsPathParam()
		{
			string text = "";
			if (this.Servers != null)
			{
				text = text + "servers," + this.Servers.ToString();
			}
			return text;
		}

		// Token: 0x06000197 RID: 407 RVA: 0x000069CB File Offset: 0x00004BCB
		internal Dictionary<string, string> GetAsQueryParam()
		{
			return new Dictionary<string, string>();
		}
	}
}
