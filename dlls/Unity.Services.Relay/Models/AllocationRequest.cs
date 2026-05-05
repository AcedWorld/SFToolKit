using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Relay.Models
{
	// Token: 0x0200001E RID: 30
	[Preserve]
	[DataContract(Name = "AllocationRequest")]
	public class AllocationRequest
	{
		// Token: 0x06000069 RID: 105 RVA: 0x00002D56 File Offset: 0x00000F56
		[Preserve]
		public AllocationRequest(int maxConnections, string region = null)
		{
			this.MaxConnections = maxConnections;
			this.Region = region;
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600006A RID: 106 RVA: 0x00002D6C File Offset: 0x00000F6C
		[Preserve]
		[DataMember(Name = "maxConnections", IsRequired = true, EmitDefaultValue = true)]
		public int MaxConnections { get; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600006B RID: 107 RVA: 0x00002D74 File Offset: 0x00000F74
		[Preserve]
		[DataMember(Name = "region", EmitDefaultValue = false)]
		public string Region { get; }

		// Token: 0x0600006C RID: 108 RVA: 0x00002D7C File Offset: 0x00000F7C
		internal string SerializeAsPathParam()
		{
			string text = "";
			text = text + "maxConnections," + this.MaxConnections.ToString() + ",";
			if (this.Region != null)
			{
				text = text + "region," + this.Region;
			}
			return text;
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00002DCC File Offset: 0x00000FCC
		internal Dictionary<string, string> GetAsQueryParam()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			string value = this.MaxConnections.ToString();
			dictionary.Add("maxConnections", value);
			if (this.Region != null)
			{
				string value2 = this.Region.ToString();
				dictionary.Add("region", value2);
			}
			return dictionary;
		}
	}
}
