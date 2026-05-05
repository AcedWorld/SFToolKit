using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Relay.Models
{
	// Token: 0x02000020 RID: 32
	[Preserve]
	[DataContract(Name = "JoinAllocation")]
	public class JoinAllocation
	{
		// Token: 0x06000077 RID: 119 RVA: 0x00003000 File Offset: 0x00001200
		[Preserve]
		public JoinAllocation(Guid allocationId, List<RelayServerEndpoint> serverEndpoints, RelayServer relayServer, byte[] key, byte[] connectionData, byte[] allocationIdBytes, string region, byte[] hostConnectionData)
		{
			this.AllocationId = allocationId;
			this.ServerEndpoints = serverEndpoints;
			this.RelayServer = relayServer;
			this.Key = key;
			this.ConnectionData = connectionData;
			this.AllocationIdBytes = allocationIdBytes;
			this.Region = region;
			this.HostConnectionData = hostConnectionData;
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000078 RID: 120 RVA: 0x00003050 File Offset: 0x00001250
		[Preserve]
		[DataMember(Name = "allocationId", IsRequired = true, EmitDefaultValue = true)]
		public Guid AllocationId { get; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000079 RID: 121 RVA: 0x00003058 File Offset: 0x00001258
		[Preserve]
		[DataMember(Name = "serverEndpoints", IsRequired = true, EmitDefaultValue = true)]
		public List<RelayServerEndpoint> ServerEndpoints { get; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600007A RID: 122 RVA: 0x00003060 File Offset: 0x00001260
		[Preserve]
		[DataMember(Name = "relayServer", IsRequired = true, EmitDefaultValue = true)]
		public RelayServer RelayServer { get; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600007B RID: 123 RVA: 0x00003068 File Offset: 0x00001268
		[Preserve]
		[DataMember(Name = "key", IsRequired = true, EmitDefaultValue = true)]
		public byte[] Key { get; }

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x0600007C RID: 124 RVA: 0x00003070 File Offset: 0x00001270
		[Preserve]
		[DataMember(Name = "connectionData", IsRequired = true, EmitDefaultValue = true)]
		public byte[] ConnectionData { get; }

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600007D RID: 125 RVA: 0x00003078 File Offset: 0x00001278
		[Preserve]
		[DataMember(Name = "allocationIdBytes", IsRequired = true, EmitDefaultValue = true)]
		public byte[] AllocationIdBytes { get; }

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x0600007E RID: 126 RVA: 0x00003080 File Offset: 0x00001280
		[Preserve]
		[DataMember(Name = "region", IsRequired = true, EmitDefaultValue = true)]
		public string Region { get; }

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600007F RID: 127 RVA: 0x00003088 File Offset: 0x00001288
		[Preserve]
		[DataMember(Name = "hostConnectionData", IsRequired = true, EmitDefaultValue = true)]
		public byte[] HostConnectionData { get; }

		// Token: 0x06000080 RID: 128 RVA: 0x00003090 File Offset: 0x00001290
		internal string SerializeAsPathParam()
		{
			string text = "";
			Guid allocationId = this.AllocationId;
			text = text + "allocationId," + this.AllocationId.ToString() + ",";
			if (this.ServerEndpoints != null)
			{
				text = text + "serverEndpoints," + this.ServerEndpoints.ToString() + ",";
			}
			if (this.RelayServer != null)
			{
				text = text + "relayServer," + this.RelayServer.ToString() + ",";
			}
			if (this.Key != null)
			{
				text = text + "key," + this.Key.ToString() + ",";
			}
			if (this.ConnectionData != null)
			{
				text = text + "connectionData," + this.ConnectionData.ToString() + ",";
			}
			if (this.AllocationIdBytes != null)
			{
				text = text + "allocationIdBytes," + this.AllocationIdBytes.ToString() + ",";
			}
			if (this.Region != null)
			{
				text = text + "region," + this.Region + ",";
			}
			if (this.HostConnectionData != null)
			{
				text = text + "hostConnectionData," + this.HostConnectionData.ToString();
			}
			return text;
		}

		// Token: 0x06000081 RID: 129 RVA: 0x000031C4 File Offset: 0x000013C4
		internal Dictionary<string, string> GetAsQueryParam()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			Guid allocationId = this.AllocationId;
			string value = this.AllocationId.ToString();
			dictionary.Add("allocationId", value);
			if (this.Key != null)
			{
				string value2 = this.Key.ToString();
				dictionary.Add("key", value2);
			}
			if (this.ConnectionData != null)
			{
				string value3 = this.ConnectionData.ToString();
				dictionary.Add("connectionData", value3);
			}
			if (this.AllocationIdBytes != null)
			{
				string value4 = this.AllocationIdBytes.ToString();
				dictionary.Add("allocationIdBytes", value4);
			}
			if (this.Region != null)
			{
				string value5 = this.Region.ToString();
				dictionary.Add("region", value5);
			}
			if (this.HostConnectionData != null)
			{
				string value6 = this.HostConnectionData.ToString();
				dictionary.Add("hostConnectionData", value6);
			}
			return dictionary;
		}
	}
}
