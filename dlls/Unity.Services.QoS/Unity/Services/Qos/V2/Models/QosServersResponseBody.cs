using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Qos.V2.Models
{
	// Token: 0x02000029 RID: 41
	[Preserve]
	[DataContract(Name = "QosServersResponseBody")]
	internal class QosServersResponseBody
	{
		// Token: 0x060000AB RID: 171 RVA: 0x00004702 File Offset: 0x00002902
		[Preserve]
		public QosServersResponseBody(QosServersList data)
		{
			this.Data = data;
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060000AC RID: 172 RVA: 0x00004711 File Offset: 0x00002911
		[Preserve]
		[DataMember(Name = "data", IsRequired = true, EmitDefaultValue = true)]
		public QosServersList Data { get; }

		// Token: 0x060000AD RID: 173 RVA: 0x0000471C File Offset: 0x0000291C
		internal string SerializeAsPathParam()
		{
			string text = "";
			if (this.Data != null)
			{
				text = text + "data," + this.Data.ToString();
			}
			return text;
		}

		// Token: 0x060000AE RID: 174 RVA: 0x0000474F File Offset: 0x0000294F
		internal Dictionary<string, string> GetAsQueryParam()
		{
			return new Dictionary<string, string>();
		}
	}
}
