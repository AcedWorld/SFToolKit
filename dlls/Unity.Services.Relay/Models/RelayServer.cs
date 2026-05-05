using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Relay.Models
{
	// Token: 0x0200002D RID: 45
	[Preserve]
	[DataContract(Name = "RelayServer")]
	public class RelayServer
	{
		// Token: 0x060000B5 RID: 181 RVA: 0x00003882 File Offset: 0x00001A82
		[Preserve]
		public RelayServer(string ipV4, int port)
		{
			this.IpV4 = ipV4;
			this.Port = port;
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000B6 RID: 182 RVA: 0x00003898 File Offset: 0x00001A98
		[Preserve]
		[DataMember(Name = "ipV4", IsRequired = true, EmitDefaultValue = true)]
		public string IpV4 { get; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060000B7 RID: 183 RVA: 0x000038A0 File Offset: 0x00001AA0
		[Preserve]
		[DataMember(Name = "port", IsRequired = true, EmitDefaultValue = true)]
		public int Port { get; }

		// Token: 0x060000B8 RID: 184 RVA: 0x000038A8 File Offset: 0x00001AA8
		internal string SerializeAsPathParam()
		{
			string str = "";
			if (this.IpV4 != null)
			{
				str = str + "ipV4," + this.IpV4 + ",";
			}
			return str + "port," + this.Port.ToString();
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x000038F8 File Offset: 0x00001AF8
		internal Dictionary<string, string> GetAsQueryParam()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (this.IpV4 != null)
			{
				string value = this.IpV4.ToString();
				dictionary.Add("ipV4", value);
			}
			string value2 = this.Port.ToString();
			dictionary.Add("port", value2);
			return dictionary;
		}
	}
}
