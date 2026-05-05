using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine.Scripting;

namespace Unity.Services.Relay.Models
{
	// Token: 0x0200002E RID: 46
	[Preserve]
	[DataContract(Name = "RelayServerEndpoint")]
	public class RelayServerEndpoint
	{
		// Token: 0x060000BA RID: 186 RVA: 0x00003947 File Offset: 0x00001B47
		[Preserve]
		public RelayServerEndpoint(string connectionType, RelayServerEndpoint.NetworkOptions network, bool reliable, bool secure, string host, int port)
		{
			this.ConnectionType = connectionType;
			this.Network = network;
			this.Reliable = reliable;
			this.Secure = secure;
			this.Host = host;
			this.Port = port;
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060000BB RID: 187 RVA: 0x0000397C File Offset: 0x00001B7C
		[Preserve]
		[DataMember(Name = "connectionType", IsRequired = true, EmitDefaultValue = true)]
		public string ConnectionType { get; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060000BC RID: 188 RVA: 0x00003984 File Offset: 0x00001B84
		[Preserve]
		[JsonConverter(typeof(StringEnumConverter))]
		[DataMember(Name = "network", IsRequired = true, EmitDefaultValue = true)]
		public RelayServerEndpoint.NetworkOptions Network { get; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060000BD RID: 189 RVA: 0x0000398C File Offset: 0x00001B8C
		[Preserve]
		[DataMember(Name = "reliable", IsRequired = true, EmitDefaultValue = true)]
		public bool Reliable { get; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060000BE RID: 190 RVA: 0x00003994 File Offset: 0x00001B94
		[Preserve]
		[DataMember(Name = "secure", IsRequired = true, EmitDefaultValue = true)]
		public bool Secure { get; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060000BF RID: 191 RVA: 0x0000399C File Offset: 0x00001B9C
		[Preserve]
		[DataMember(Name = "host", IsRequired = true, EmitDefaultValue = true)]
		public string Host { get; }

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x000039A4 File Offset: 0x00001BA4
		[Preserve]
		[DataMember(Name = "port", IsRequired = true, EmitDefaultValue = true)]
		public int Port { get; }

		// Token: 0x060000C1 RID: 193 RVA: 0x000039AC File Offset: 0x00001BAC
		internal string SerializeAsPathParam()
		{
			string str = "";
			if (this.ConnectionType != null)
			{
				str = str + "connectionType," + this.ConnectionType + ",";
			}
			str = str + "network," + this.Network.ToString() + ",";
			str = str + "reliable," + this.Reliable.ToString() + ",";
			str = str + "secure," + this.Secure.ToString() + ",";
			if (this.Host != null)
			{
				str = str + "host," + this.Host + ",";
			}
			return str + "port," + this.Port.ToString();
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00003A7C File Offset: 0x00001C7C
		internal Dictionary<string, string> GetAsQueryParam()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (this.ConnectionType != null)
			{
				string value = this.ConnectionType.ToString();
				dictionary.Add("connectionType", value);
			}
			string value2 = this.Network.ToString();
			dictionary.Add("network", value2);
			string value3 = this.Reliable.ToString();
			dictionary.Add("reliable", value3);
			string value4 = this.Secure.ToString();
			dictionary.Add("secure", value4);
			if (this.Host != null)
			{
				string value5 = this.Host.ToString();
				dictionary.Add("host", value5);
			}
			string value6 = this.Port.ToString();
			dictionary.Add("port", value6);
			return dictionary;
		}

		// Token: 0x0400007D RID: 125
		public const string ConnectionTypeUdp = "udp";

		// Token: 0x0400007E RID: 126
		public const string ConnectionTypeDtls = "dtls";

		// Token: 0x0400007F RID: 127
		public const string ConnectionTypeWss = "wss";

		// Token: 0x0200005B RID: 91
		[Preserve]
		[JsonConverter(typeof(StringEnumConverter))]
		public enum NetworkOptions
		{
			// Token: 0x040000D4 RID: 212
			[EnumMember(Value = "udp")]
			Udp = 1,
			// Token: 0x040000D5 RID: 213
			[EnumMember(Value = "tcp")]
			Tcp
		}
	}
}
