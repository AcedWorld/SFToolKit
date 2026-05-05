using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Unity.Services.Lobbies.Http;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Models
{
	// Token: 0x0200003D RID: 61
	[Preserve]
	[DataContract(Name = "PlayerUpdateRequest")]
	public class PlayerUpdateRequest
	{
		// Token: 0x060001CC RID: 460 RVA: 0x00007744 File Offset: 0x00005944
		[Preserve]
		public PlayerUpdateRequest(string connectionInfo = null, Dictionary<string, PlayerDataObject> data = null, string allocationId = null)
		{
			this.ConnectionInfo = connectionInfo;
			this.Data = new JsonObject(data);
			this.AllocationId = allocationId;
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x060001CD RID: 461 RVA: 0x00007766 File Offset: 0x00005966
		[Preserve]
		[DataMember(Name = "connectionInfo", EmitDefaultValue = false)]
		public string ConnectionInfo { get; }

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x060001CE RID: 462 RVA: 0x0000776E File Offset: 0x0000596E
		[Preserve]
		[JsonConverter(typeof(JsonObjectCollectionConverter))]
		[DataMember(Name = "data", EmitDefaultValue = false)]
		public JsonObject Data { get; }

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x060001CF RID: 463 RVA: 0x00007776 File Offset: 0x00005976
		[Preserve]
		[DataMember(Name = "allocationId", EmitDefaultValue = false)]
		public string AllocationId { get; }

		// Token: 0x060001D0 RID: 464 RVA: 0x00007780 File Offset: 0x00005980
		internal string SerializeAsPathParam()
		{
			string text = "";
			if (this.ConnectionInfo != null)
			{
				text = text + "connectionInfo," + this.ConnectionInfo + ",";
			}
			if (this.Data != null)
			{
				text = text + "data," + this.Data.ToString() + ",";
			}
			if (this.AllocationId != null)
			{
				text = text + "allocationId," + this.AllocationId;
			}
			return text;
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x000077F4 File Offset: 0x000059F4
		internal Dictionary<string, string> GetAsQueryParam()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (this.ConnectionInfo != null)
			{
				string value = this.ConnectionInfo.ToString();
				dictionary.Add("connectionInfo", value);
			}
			if (this.AllocationId != null)
			{
				string value2 = this.AllocationId.ToString();
				dictionary.Add("allocationId", value2);
			}
			return dictionary;
		}
	}
}
