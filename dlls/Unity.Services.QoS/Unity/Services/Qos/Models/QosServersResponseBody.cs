using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Qos.Models
{
	// Token: 0x02000057 RID: 87
	[Preserve]
	[DataContract(Name = "QosServersResponseBody")]
	internal class QosServersResponseBody
	{
		// Token: 0x06000198 RID: 408 RVA: 0x000069D2 File Offset: 0x00004BD2
		[Preserve]
		public QosServersResponseBody(QosServersList data)
		{
			this.Data = data;
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000199 RID: 409 RVA: 0x000069E1 File Offset: 0x00004BE1
		[Preserve]
		[DataMember(Name = "data", IsRequired = true, EmitDefaultValue = true)]
		public QosServersList Data { get; }

		// Token: 0x0600019A RID: 410 RVA: 0x000069EC File Offset: 0x00004BEC
		internal string SerializeAsPathParam()
		{
			string text = "";
			if (this.Data != null)
			{
				text = text + "data," + this.Data.ToString();
			}
			return text;
		}

		// Token: 0x0600019B RID: 411 RVA: 0x00006A1F File Offset: 0x00004C1F
		internal Dictionary<string, string> GetAsQueryParam()
		{
			return new Dictionary<string, string>();
		}
	}
}
