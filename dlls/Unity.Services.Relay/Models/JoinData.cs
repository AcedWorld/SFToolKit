using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Relay.Models
{
	// Token: 0x02000025 RID: 37
	[Preserve]
	[DataContract(Name = "JoinData")]
	public class JoinData
	{
		// Token: 0x06000094 RID: 148 RVA: 0x000034EE File Offset: 0x000016EE
		[Preserve]
		public JoinData(JoinAllocation allocation)
		{
			this.Allocation = allocation;
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000095 RID: 149 RVA: 0x000034FD File Offset: 0x000016FD
		[Preserve]
		[DataMember(Name = "allocation", IsRequired = true, EmitDefaultValue = true)]
		public JoinAllocation Allocation { get; }

		// Token: 0x06000096 RID: 150 RVA: 0x00003508 File Offset: 0x00001708
		internal string SerializeAsPathParam()
		{
			string text = "";
			if (this.Allocation != null)
			{
				text = text + "allocation," + this.Allocation.ToString();
			}
			return text;
		}

		// Token: 0x06000097 RID: 151 RVA: 0x0000353B File Offset: 0x0000173B
		internal Dictionary<string, string> GetAsQueryParam()
		{
			return new Dictionary<string, string>();
		}
	}
}
