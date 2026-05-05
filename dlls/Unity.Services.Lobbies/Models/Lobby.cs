using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Models
{
	// Token: 0x02000039 RID: 57
	[Preserve]
	[DataContract(Name = "Lobby")]
	public class Lobby
	{
		// Token: 0x0600018D RID: 397 RVA: 0x00006DE4 File Offset: 0x00004FE4
		[Preserve]
		public Lobby(string id = null, string lobbyCode = null, string upid = null, string environmentId = null, string name = null, int maxPlayers = 0, int availableSlots = 0, bool isPrivate = false, bool isLocked = false, List<Player> players = null, Dictionary<string, DataObject> data = null, string hostId = null, DateTime created = default(DateTime), DateTime lastUpdated = default(DateTime), int version = 0, bool hasPassword = false)
		{
			this.Id = id;
			this.LobbyCode = lobbyCode;
			this.Upid = upid;
			this.EnvironmentId = environmentId;
			this.Name = name;
			this.MaxPlayers = maxPlayers;
			this.AvailableSlots = availableSlots;
			this.IsPrivate = isPrivate;
			this.IsLocked = isLocked;
			this.HasPassword = hasPassword;
			this.Players = players;
			this.Data = data;
			this.HostId = hostId;
			this.Created = created;
			this.LastUpdated = lastUpdated;
			this.Version = version;
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x0600018E RID: 398 RVA: 0x00006E74 File Offset: 0x00005074
		// (set) Token: 0x0600018F RID: 399 RVA: 0x00006E7C File Offset: 0x0000507C
		[Preserve]
		[DataMember(Name = "id", EmitDefaultValue = false)]
		public string Id { get; internal set; }

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000190 RID: 400 RVA: 0x00006E85 File Offset: 0x00005085
		// (set) Token: 0x06000191 RID: 401 RVA: 0x00006E8D File Offset: 0x0000508D
		[Preserve]
		[DataMember(Name = "lobbyCode", EmitDefaultValue = false)]
		public string LobbyCode { get; internal set; }

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06000192 RID: 402 RVA: 0x00006E96 File Offset: 0x00005096
		// (set) Token: 0x06000193 RID: 403 RVA: 0x00006E9E File Offset: 0x0000509E
		[Preserve]
		[DataMember(Name = "upid", EmitDefaultValue = false)]
		public string Upid { get; internal set; }

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000194 RID: 404 RVA: 0x00006EA7 File Offset: 0x000050A7
		// (set) Token: 0x06000195 RID: 405 RVA: 0x00006EAF File Offset: 0x000050AF
		[Preserve]
		[DataMember(Name = "environmentId", EmitDefaultValue = false)]
		public string EnvironmentId { get; internal set; }

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000196 RID: 406 RVA: 0x00006EB8 File Offset: 0x000050B8
		// (set) Token: 0x06000197 RID: 407 RVA: 0x00006EC0 File Offset: 0x000050C0
		[Preserve]
		[DataMember(Name = "name", EmitDefaultValue = false)]
		public string Name { get; internal set; }

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000198 RID: 408 RVA: 0x00006EC9 File Offset: 0x000050C9
		// (set) Token: 0x06000199 RID: 409 RVA: 0x00006ED1 File Offset: 0x000050D1
		[Preserve]
		[DataMember(Name = "maxPlayers", EmitDefaultValue = false)]
		public int MaxPlayers { get; internal set; }

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x0600019A RID: 410 RVA: 0x00006EDA File Offset: 0x000050DA
		// (set) Token: 0x0600019B RID: 411 RVA: 0x00006EE2 File Offset: 0x000050E2
		[Preserve]
		[DataMember(Name = "availableSlots", EmitDefaultValue = false)]
		public int AvailableSlots { get; internal set; }

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x0600019C RID: 412 RVA: 0x00006EEB File Offset: 0x000050EB
		// (set) Token: 0x0600019D RID: 413 RVA: 0x00006EF3 File Offset: 0x000050F3
		[Preserve]
		[DataMember(Name = "isPrivate", EmitDefaultValue = true)]
		public bool IsPrivate { get; internal set; }

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x0600019E RID: 414 RVA: 0x00006EFC File Offset: 0x000050FC
		// (set) Token: 0x0600019F RID: 415 RVA: 0x00006F04 File Offset: 0x00005104
		[Preserve]
		[DataMember(Name = "isLocked", EmitDefaultValue = true)]
		public bool IsLocked { get; internal set; }

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x060001A0 RID: 416 RVA: 0x00006F0D File Offset: 0x0000510D
		// (set) Token: 0x060001A1 RID: 417 RVA: 0x00006F15 File Offset: 0x00005115
		[Preserve]
		[DataMember(Name = "hasPassword", EmitDefaultValue = true)]
		public bool HasPassword { get; internal set; }

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060001A2 RID: 418 RVA: 0x00006F1E File Offset: 0x0000511E
		// (set) Token: 0x060001A3 RID: 419 RVA: 0x00006F26 File Offset: 0x00005126
		[Preserve]
		[DataMember(Name = "players", EmitDefaultValue = false)]
		public List<Player> Players { get; internal set; }

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x060001A4 RID: 420 RVA: 0x00006F2F File Offset: 0x0000512F
		// (set) Token: 0x060001A5 RID: 421 RVA: 0x00006F37 File Offset: 0x00005137
		[Preserve]
		[DataMember(Name = "data", EmitDefaultValue = false)]
		public Dictionary<string, DataObject> Data { get; internal set; }

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x060001A6 RID: 422 RVA: 0x00006F40 File Offset: 0x00005140
		// (set) Token: 0x060001A7 RID: 423 RVA: 0x00006F48 File Offset: 0x00005148
		[Preserve]
		[DataMember(Name = "hostId", EmitDefaultValue = false)]
		public string HostId { get; internal set; }

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060001A8 RID: 424 RVA: 0x00006F51 File Offset: 0x00005151
		// (set) Token: 0x060001A9 RID: 425 RVA: 0x00006F59 File Offset: 0x00005159
		[Preserve]
		[DataMember(Name = "created", EmitDefaultValue = false)]
		public DateTime Created { get; internal set; }

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060001AA RID: 426 RVA: 0x00006F62 File Offset: 0x00005162
		// (set) Token: 0x060001AB RID: 427 RVA: 0x00006F6A File Offset: 0x0000516A
		[Preserve]
		[DataMember(Name = "lastUpdated", EmitDefaultValue = false)]
		public DateTime LastUpdated { get; internal set; }

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060001AC RID: 428 RVA: 0x00006F73 File Offset: 0x00005173
		// (set) Token: 0x060001AD RID: 429 RVA: 0x00006F7B File Offset: 0x0000517B
		[Preserve]
		[DataMember(Name = "version", EmitDefaultValue = false)]
		public int Version { get; set; }

		// Token: 0x060001AE RID: 430 RVA: 0x00006F84 File Offset: 0x00005184
		internal string SerializeAsPathParam()
		{
			string str = "";
			if (this.Id != null)
			{
				str = str + "id," + this.Id + ",";
			}
			if (this.LobbyCode != null)
			{
				str = str + "lobbyCode," + this.LobbyCode + ",";
			}
			if (this.Upid != null)
			{
				str = str + "upid," + this.Upid + ",";
			}
			if (this.EnvironmentId != null)
			{
				str = str + "environmentId," + this.EnvironmentId + ",";
			}
			if (this.Name != null)
			{
				str = str + "name," + this.Name + ",";
			}
			str = str + "maxPlayers," + this.MaxPlayers.ToString() + ",";
			str = str + "availableSlots," + this.AvailableSlots.ToString() + ",";
			str = str + "isPrivate," + this.IsPrivate.ToString() + ",";
			str = str + "isLocked," + this.IsLocked.ToString() + ",";
			str = str + "hasPassword," + this.HasPassword.ToString() + ",";
			if (this.Players != null)
			{
				str = str + "players," + this.Players.ToString() + ",";
			}
			if (this.Data != null)
			{
				str = str + "data," + this.Data.ToString() + ",";
			}
			if (this.HostId != null)
			{
				str = str + "hostId," + this.HostId + ",";
			}
			DateTime created = this.Created;
			str = str + "created," + this.Created.ToString() + ",";
			DateTime lastUpdated = this.LastUpdated;
			str = str + "lastUpdated," + this.LastUpdated.ToString() + ",";
			return str + "version," + this.Version.ToString();
		}

		// Token: 0x060001AF RID: 431 RVA: 0x0000719C File Offset: 0x0000539C
		internal Dictionary<string, string> GetAsQueryParam()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (this.Id != null)
			{
				string value = this.Id.ToString();
				dictionary.Add("id", value);
			}
			if (this.LobbyCode != null)
			{
				string value2 = this.LobbyCode.ToString();
				dictionary.Add("lobbyCode", value2);
			}
			if (this.Upid != null)
			{
				string value3 = this.Upid.ToString();
				dictionary.Add("upid", value3);
			}
			if (this.EnvironmentId != null)
			{
				string value4 = this.EnvironmentId.ToString();
				dictionary.Add("environmentId", value4);
			}
			if (this.Name != null)
			{
				string value5 = this.Name.ToString();
				dictionary.Add("name", value5);
			}
			string value6 = this.MaxPlayers.ToString();
			dictionary.Add("maxPlayers", value6);
			string value7 = this.AvailableSlots.ToString();
			dictionary.Add("availableSlots", value7);
			string value8 = this.IsPrivate.ToString();
			dictionary.Add("isPrivate", value8);
			string value9 = this.IsLocked.ToString();
			dictionary.Add("isLocked", value9);
			string value10 = this.HasPassword.ToString();
			dictionary.Add("hasPassword", value10);
			if (this.HostId != null)
			{
				string value11 = this.HostId.ToString();
				dictionary.Add("hostId", value11);
			}
			DateTime created = this.Created;
			string value12 = this.Created.ToString();
			dictionary.Add("created", value12);
			DateTime lastUpdated = this.LastUpdated;
			string value13 = this.LastUpdated.ToString();
			dictionary.Add("lastUpdated", value13);
			string value14 = this.Version.ToString();
			dictionary.Add("version", value14);
			return dictionary;
		}
	}
}
