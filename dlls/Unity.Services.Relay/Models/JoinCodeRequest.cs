using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Relay.Models
{
	// Token: 0x02000023 RID: 35
	[Preserve]
	[DataContract(Name = "JoinCodeRequest")]
	public class JoinCodeRequest
	{
		// Token: 0x0600008A RID: 138 RVA: 0x000033A4 File Offset: 0x000015A4
		[Preserve]
		public JoinCodeRequest(Guid allocationId)
		{
			this.AllocationId = allocationId;
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x0600008B RID: 139 RVA: 0x000033B3 File Offset: 0x000015B3
		[Preserve]
		[DataMember(Name = "allocationId", IsRequired = true, EmitDefaultValue = true)]
		public Guid AllocationId { get; }

		// Token: 0x0600008C RID: 140 RVA: 0x000033BC File Offset: 0x000015BC
		internal string SerializeAsPathParam()
		{
			string str = "";
			Guid allocationId = this.AllocationId;
			return str + "allocationId," + this.AllocationId.ToString();
		}

		// Token: 0x0600008D RID: 141 RVA: 0x000033F8 File Offset: 0x000015F8
		internal Dictionary<string, string> GetAsQueryParam()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			Guid allocationId = this.AllocationId;
			string value = this.AllocationId.ToString();
			dictionary.Add("allocationId", value);
			return dictionary;
		}
	}
}
