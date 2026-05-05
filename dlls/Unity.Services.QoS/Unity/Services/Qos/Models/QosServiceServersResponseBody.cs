using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Qos.Models
{
	// Token: 0x0200005A RID: 90
	[Preserve]
	[DataContract(Name = "QosServiceServersResponseBody")]
	internal class QosServiceServersResponseBody
	{
		// Token: 0x060001A6 RID: 422 RVA: 0x00006B9A File Offset: 0x00004D9A
		[Preserve]
		public QosServiceServersResponseBody(QosServiceServersList data)
		{
			this.Data = data;
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060001A7 RID: 423 RVA: 0x00006BA9 File Offset: 0x00004DA9
		[Preserve]
		[DataMember(Name = "data", IsRequired = true, EmitDefaultValue = true)]
		public QosServiceServersList Data { get; }

		// Token: 0x060001A8 RID: 424 RVA: 0x00006BB4 File Offset: 0x00004DB4
		internal string SerializeAsPathParam()
		{
			string text = "";
			if (this.Data != null)
			{
				text = text + "data," + this.Data.ToString();
			}
			return text;
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x00006BE7 File Offset: 0x00004DE7
		internal Dictionary<string, string> GetAsQueryParam()
		{
			return new Dictionary<string, string>();
		}
	}
}
