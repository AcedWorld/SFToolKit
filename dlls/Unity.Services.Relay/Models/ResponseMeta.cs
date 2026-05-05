using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Relay.Models
{
	// Token: 0x02000030 RID: 48
	[Preserve]
	[DataContract(Name = "ResponseMeta")]
	public class ResponseMeta
	{
		// Token: 0x060000C7 RID: 199 RVA: 0x00003BC8 File Offset: 0x00001DC8
		[Preserve]
		public ResponseMeta(string requestId, int status)
		{
			this.RequestId = requestId;
			this.Status = status;
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060000C8 RID: 200 RVA: 0x00003BDE File Offset: 0x00001DDE
		[Preserve]
		[DataMember(Name = "requestId", IsRequired = true, EmitDefaultValue = true)]
		public string RequestId { get; }

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060000C9 RID: 201 RVA: 0x00003BE6 File Offset: 0x00001DE6
		[Preserve]
		[DataMember(Name = "status", IsRequired = true, EmitDefaultValue = true)]
		public int Status { get; }

		// Token: 0x060000CA RID: 202 RVA: 0x00003BF0 File Offset: 0x00001DF0
		internal string SerializeAsPathParam()
		{
			string str = "";
			if (this.RequestId != null)
			{
				str = str + "requestId," + this.RequestId + ",";
			}
			return str + "status," + this.Status.ToString();
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00003C40 File Offset: 0x00001E40
		internal Dictionary<string, string> GetAsQueryParam()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (this.RequestId != null)
			{
				string value = this.RequestId.ToString();
				dictionary.Add("requestId", value);
			}
			string value2 = this.Status.ToString();
			dictionary.Add("status", value2);
			return dictionary;
		}
	}
}
