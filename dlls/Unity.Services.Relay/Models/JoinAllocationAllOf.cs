using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Relay.Models
{
	// Token: 0x02000021 RID: 33
	[Preserve]
	[DataContract(Name = "JoinAllocation_allOf")]
	public class JoinAllocationAllOf
	{
		// Token: 0x06000082 RID: 130 RVA: 0x000032A8 File Offset: 0x000014A8
		[Preserve]
		public JoinAllocationAllOf(byte[] hostConnectionData)
		{
			this.HostConnectionData = hostConnectionData;
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000083 RID: 131 RVA: 0x000032B7 File Offset: 0x000014B7
		[Preserve]
		[DataMember(Name = "hostConnectionData", IsRequired = true, EmitDefaultValue = true)]
		public byte[] HostConnectionData { get; }

		// Token: 0x06000084 RID: 132 RVA: 0x000032C0 File Offset: 0x000014C0
		internal string SerializeAsPathParam()
		{
			string text = "";
			if (this.HostConnectionData != null)
			{
				text = text + "hostConnectionData," + this.HostConnectionData.ToString();
			}
			return text;
		}

		// Token: 0x06000085 RID: 133 RVA: 0x000032F4 File Offset: 0x000014F4
		internal Dictionary<string, string> GetAsQueryParam()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (this.HostConnectionData != null)
			{
				string value = this.HostConnectionData.ToString();
				dictionary.Add("hostConnectionData", value);
			}
			return dictionary;
		}
	}
}
