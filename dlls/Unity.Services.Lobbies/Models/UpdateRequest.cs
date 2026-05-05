using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Unity.Services.Lobbies.Http;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Models
{
	// Token: 0x02000045 RID: 69
	[Preserve]
	[DataContract(Name = "UpdateRequest")]
	public class UpdateRequest
	{
		// Token: 0x060001F9 RID: 505 RVA: 0x00007ECC File Offset: 0x000060CC
		[Preserve]
		public UpdateRequest(string name = null, int? maxPlayers = null, bool? isPrivate = null, bool? isLocked = null, Dictionary<string, DataObject> data = null, string hostId = null, string password = null)
		{
			this.Name = name;
			this.MaxPlayers = maxPlayers;
			this.IsPrivate = isPrivate;
			this.IsLocked = isLocked;
			this.Password = password;
			this.Data = new JsonObject(data);
			this.HostId = hostId;
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x060001FA RID: 506 RVA: 0x00007F19 File Offset: 0x00006119
		[Preserve]
		[DataMember(Name = "name", EmitDefaultValue = false)]
		public string Name { get; }

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x060001FB RID: 507 RVA: 0x00007F21 File Offset: 0x00006121
		[Preserve]
		[DataMember(Name = "maxPlayers", EmitDefaultValue = false)]
		public int? MaxPlayers { get; }

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x060001FC RID: 508 RVA: 0x00007F29 File Offset: 0x00006129
		[Preserve]
		[DataMember(Name = "isPrivate", EmitDefaultValue = true)]
		public bool? IsPrivate { get; }

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x060001FD RID: 509 RVA: 0x00007F31 File Offset: 0x00006131
		[Preserve]
		[DataMember(Name = "isLocked", EmitDefaultValue = true)]
		public bool? IsLocked { get; }

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060001FE RID: 510 RVA: 0x00007F39 File Offset: 0x00006139
		[Preserve]
		[DataMember(Name = "password", EmitDefaultValue = false)]
		public string Password { get; }

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060001FF RID: 511 RVA: 0x00007F41 File Offset: 0x00006141
		[Preserve]
		[JsonConverter(typeof(JsonObjectCollectionConverter))]
		[DataMember(Name = "data", EmitDefaultValue = false)]
		public JsonObject Data { get; }

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x06000200 RID: 512 RVA: 0x00007F49 File Offset: 0x00006149
		[Preserve]
		[DataMember(Name = "hostId", EmitDefaultValue = false)]
		public string HostId { get; }

		// Token: 0x06000201 RID: 513 RVA: 0x00007F54 File Offset: 0x00006154
		internal string SerializeAsPathParam()
		{
			string text = "";
			if (this.Name != null)
			{
				text = text + "name," + this.Name + ",";
			}
			if (this.MaxPlayers != null)
			{
				text = text + "maxPlayers," + this.MaxPlayers.ToString() + ",";
			}
			if (this.IsPrivate != null)
			{
				text = text + "isPrivate," + this.IsPrivate.ToString() + ",";
			}
			if (this.IsLocked != null)
			{
				text = text + "isLocked," + this.IsLocked.ToString() + ",";
			}
			if (this.Password != null)
			{
				text = text + "password," + this.Password + ",";
			}
			if (this.Data != null)
			{
				text = text + "data," + this.Data.ToString() + ",";
			}
			if (this.HostId != null)
			{
				text = text + "hostId," + this.HostId;
			}
			return text;
		}

		// Token: 0x06000202 RID: 514 RVA: 0x00008084 File Offset: 0x00006284
		internal Dictionary<string, string> GetAsQueryParam()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (this.Name != null)
			{
				string value = this.Name.ToString();
				dictionary.Add("name", value);
			}
			if (this.MaxPlayers != null)
			{
				string value2 = this.MaxPlayers.ToString();
				dictionary.Add("maxPlayers", value2);
			}
			if (this.IsPrivate != null)
			{
				string value3 = this.IsPrivate.ToString();
				dictionary.Add("isPrivate", value3);
			}
			if (this.IsLocked != null)
			{
				string value4 = this.IsLocked.ToString();
				dictionary.Add("isLocked", value4);
			}
			if (this.Password != null)
			{
				string value5 = this.Password.ToString();
				dictionary.Add("password", value5);
			}
			if (this.HostId != null)
			{
				string value6 = this.HostId.ToString();
				dictionary.Add("hostId", value6);
			}
			return dictionary;
		}
	}
}
