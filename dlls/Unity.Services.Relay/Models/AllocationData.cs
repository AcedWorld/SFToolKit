using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Relay.Models
{
	// Token: 0x0200001D RID: 29
	[Preserve]
	[DataContract(Name = "AllocationData")]
	public class AllocationData
	{
		// Token: 0x06000065 RID: 101 RVA: 0x00002D02 File Offset: 0x00000F02
		[Preserve]
		public AllocationData(Allocation allocation)
		{
			this.Allocation = allocation;
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000066 RID: 102 RVA: 0x00002D11 File Offset: 0x00000F11
		[Preserve]
		[DataMember(Name = "allocation", IsRequired = true, EmitDefaultValue = true)]
		public Allocation Allocation { get; }

		// Token: 0x06000067 RID: 103 RVA: 0x00002D1C File Offset: 0x00000F1C
		internal string SerializeAsPathParam()
		{
			string text = "";
			if (this.Allocation != null)
			{
				text = text + "allocation," + this.Allocation.ToString();
			}
			return text;
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00002D4F File Offset: 0x00000F4F
		internal Dictionary<string, string> GetAsQueryParam()
		{
			return new Dictionary<string, string>();
		}
	}
}
