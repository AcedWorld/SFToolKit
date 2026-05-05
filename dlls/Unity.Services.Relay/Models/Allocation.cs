using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Relay.Models
{
	// Token: 0x0200001C RID: 28
	[Preserve]
	[DataContract(Name = "Allocation")]
	public class Allocation
	{
		// Token: 0x0600005B RID: 91 RVA: 0x00002ABA File Offset: 0x00000CBA
		[Preserve]
		public Allocation(Guid allocationId, List<RelayServerEndpoint> serverEndpoints, RelayServer relayServer, byte[] key, byte[] connectionData, byte[] allocationIdBytes, string region)
		{
			this.AllocationId = allocationId;
			this.ServerEndpoints = serverEndpoints;
			this.RelayServer = relayServer;
			this.Key = key;
			this.ConnectionData = connectionData;
			this.AllocationIdBytes = allocationIdBytes;
			this.Region = region;
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600005C RID: 92 RVA: 0x00002AF7 File Offset: 0x00000CF7
		[Preserve]
		[DataMember(Name = "allocationId", IsRequired = true, EmitDefaultValue = true)]
		public Guid AllocationId { get; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600005D RID: 93 RVA: 0x00002AFF File Offset: 0x00000CFF
		[Preserve]
		[DataMember(Name = "serverEndpoints", IsRequired = true, EmitDefaultValue = true)]
		public List<RelayServerEndpoint> ServerEndpoints { get; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600005E RID: 94 RVA: 0x00002B07 File Offset: 0x00000D07
		[Preserve]
		[DataMember(Name = "relayServer", IsRequired = true, EmitDefaultValue = true)]
		public RelayServer RelayServer { get; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600005F RID: 95 RVA: 0x00002B0F File Offset: 0x00000D0F
		[Preserve]
		[DataMember(Name = "key", IsRequired = true, EmitDefaultValue = true)]
		public byte[] Key { get; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000060 RID: 96 RVA: 0x00002B17 File Offset: 0x00000D17
		[Preserve]
		[DataMember(Name = "connectionData", IsRequired = true, EmitDefaultValue = true)]
		public byte[] ConnectionData { get; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000061 RID: 97 RVA: 0x00002B1F File Offset: 0x00000D1F
		[Preserve]
		[DataMember(Name = "allocationIdBytes", IsRequired = true, EmitDefaultValue = true)]
		public byte[] AllocationIdBytes { get; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000062 RID: 98 RVA: 0x00002B27 File Offset: 0x00000D27
		[Preserve]
		[DataMember(Name = "region", IsRequired = true, EmitDefaultValue = true)]
		public string Region { get; }

		// Token: 0x06000063 RID: 99 RVA: 0x00002B30 File Offset: 0x00000D30
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
				text = text + "region," + this.Region;
			}
			return text;
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00002C40 File Offset: 0x00000E40
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
			return dictionary;
		}
	}
}
