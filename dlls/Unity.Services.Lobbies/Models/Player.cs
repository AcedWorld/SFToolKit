using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Models
{
	// Token: 0x0200003A RID: 58
	[Preserve]
	[DataContract(Name = "Player")]
	public class Player
	{
		// Token: 0x060001B0 RID: 432 RVA: 0x00007374 File Offset: 0x00005574
		[Preserve]
		public Player(string id = null, string connectionInfo = null, Dictionary<string, PlayerDataObject> data = null, string allocationId = null, DateTime joined = default(DateTime), DateTime lastUpdated = default(DateTime), PlayerProfile profile = null)
		{
			this.Id = id;
			this.Profile = profile;
			this.ConnectionInfo = connectionInfo;
			this.Data = data;
			this.AllocationId = allocationId;
			this.Joined = joined;
			this.LastUpdated = lastUpdated;
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x060001B1 RID: 433 RVA: 0x000073B1 File Offset: 0x000055B1
		// (set) Token: 0x060001B2 RID: 434 RVA: 0x000073B9 File Offset: 0x000055B9
		[Preserve]
		[DataMember(Name = "id", EmitDefaultValue = false)]
		public string Id { get; internal set; }

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060001B3 RID: 435 RVA: 0x000073C2 File Offset: 0x000055C2
		// (set) Token: 0x060001B4 RID: 436 RVA: 0x000073CA File Offset: 0x000055CA
		[Preserve]
		[DataMember(Name = "profile", EmitDefaultValue = false)]
		public PlayerProfile Profile { get; set; }

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x060001B5 RID: 437 RVA: 0x000073D3 File Offset: 0x000055D3
		// (set) Token: 0x060001B6 RID: 438 RVA: 0x000073DB File Offset: 0x000055DB
		[Preserve]
		[DataMember(Name = "connectionInfo", EmitDefaultValue = false)]
		public string ConnectionInfo { get; internal set; }

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060001B7 RID: 439 RVA: 0x000073E4 File Offset: 0x000055E4
		// (set) Token: 0x060001B8 RID: 440 RVA: 0x000073EC File Offset: 0x000055EC
		[Preserve]
		[DataMember(Name = "data", EmitDefaultValue = false)]
		public Dictionary<string, PlayerDataObject> Data { get; set; }

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060001B9 RID: 441 RVA: 0x000073F5 File Offset: 0x000055F5
		// (set) Token: 0x060001BA RID: 442 RVA: 0x000073FD File Offset: 0x000055FD
		[Preserve]
		[DataMember(Name = "allocationId", EmitDefaultValue = false)]
		public string AllocationId { get; internal set; }

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060001BB RID: 443 RVA: 0x00007406 File Offset: 0x00005606
		// (set) Token: 0x060001BC RID: 444 RVA: 0x0000740E File Offset: 0x0000560E
		[Preserve]
		[DataMember(Name = "joined", EmitDefaultValue = false)]
		public DateTime Joined { get; set; }

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060001BD RID: 445 RVA: 0x00007417 File Offset: 0x00005617
		// (set) Token: 0x060001BE RID: 446 RVA: 0x0000741F File Offset: 0x0000561F
		[Preserve]
		[DataMember(Name = "lastUpdated", EmitDefaultValue = false)]
		public DateTime LastUpdated { get; set; }

		// Token: 0x060001BF RID: 447 RVA: 0x00007428 File Offset: 0x00005628
		internal string SerializeAsPathParam()
		{
			string str = "";
			if (this.Id != null)
			{
				str = str + "id," + this.Id + ",";
			}
			if (this.Profile != null)
			{
				str = str + "profile," + this.Profile.ToString() + ",";
			}
			if (this.ConnectionInfo != null)
			{
				str = str + "connectionInfo," + this.ConnectionInfo + ",";
			}
			if (this.Data != null)
			{
				str = str + "data," + this.Data.ToString() + ",";
			}
			if (this.AllocationId != null)
			{
				str = str + "allocationId," + this.AllocationId + ",";
			}
			DateTime joined = this.Joined;
			str = str + "joined," + this.Joined.ToString() + ",";
			DateTime lastUpdated = this.LastUpdated;
			return str + "lastUpdated," + this.LastUpdated.ToString();
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x00007528 File Offset: 0x00005728
		internal Dictionary<string, string> GetAsQueryParam()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (this.Id != null)
			{
				string value = this.Id.ToString();
				dictionary.Add("id", value);
			}
			if (this.ConnectionInfo != null)
			{
				string value2 = this.ConnectionInfo.ToString();
				dictionary.Add("connectionInfo", value2);
			}
			if (this.AllocationId != null)
			{
				string value3 = this.AllocationId.ToString();
				dictionary.Add("allocationId", value3);
			}
			DateTime joined = this.Joined;
			string value4 = this.Joined.ToString();
			dictionary.Add("joined", value4);
			DateTime lastUpdated = this.LastUpdated;
			string value5 = this.LastUpdated.ToString();
			dictionary.Add("lastUpdated", value5);
			return dictionary;
		}
	}
}
