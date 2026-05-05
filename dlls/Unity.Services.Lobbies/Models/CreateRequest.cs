using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Models
{
	// Token: 0x02000032 RID: 50
	[Preserve]
	[DataContract(Name = "CreateRequest")]
	public class CreateRequest
	{
		// Token: 0x06000162 RID: 354 RVA: 0x000065E9 File Offset: 0x000047E9
		[Preserve]
		public CreateRequest(string name, int maxPlayers, bool? isPrivate = false, bool? isLocked = false, Player player = null, Dictionary<string, DataObject> data = null, string password = null)
		{
			this.Name = name;
			this.MaxPlayers = maxPlayers;
			this.IsPrivate = isPrivate;
			this.IsLocked = isLocked;
			this.Player = player;
			this.Password = password;
			this.Data = data;
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000163 RID: 355 RVA: 0x00006626 File Offset: 0x00004826
		[Preserve]
		[DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
		public string Name { get; }

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000164 RID: 356 RVA: 0x0000662E File Offset: 0x0000482E
		[Preserve]
		[DataMember(Name = "maxPlayers", IsRequired = true, EmitDefaultValue = true)]
		public int MaxPlayers { get; }

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000165 RID: 357 RVA: 0x00006636 File Offset: 0x00004836
		[Preserve]
		[DataMember(Name = "isPrivate", EmitDefaultValue = true)]
		public bool? IsPrivate { get; }

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000166 RID: 358 RVA: 0x0000663E File Offset: 0x0000483E
		[Preserve]
		[DataMember(Name = "isLocked", EmitDefaultValue = true)]
		public bool? IsLocked { get; }

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000167 RID: 359 RVA: 0x00006646 File Offset: 0x00004846
		[Preserve]
		[DataMember(Name = "player", EmitDefaultValue = false)]
		public Player Player { get; }

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000168 RID: 360 RVA: 0x0000664E File Offset: 0x0000484E
		[Preserve]
		[DataMember(Name = "password", EmitDefaultValue = false)]
		public string Password { get; }

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000169 RID: 361 RVA: 0x00006656 File Offset: 0x00004856
		[Preserve]
		[DataMember(Name = "data", EmitDefaultValue = false)]
		public Dictionary<string, DataObject> Data { get; }

		// Token: 0x0600016A RID: 362 RVA: 0x00006660 File Offset: 0x00004860
		internal string SerializeAsPathParam()
		{
			string text = "";
			if (this.Name != null)
			{
				text = text + "name," + this.Name + ",";
			}
			text = text + "maxPlayers," + this.MaxPlayers.ToString() + ",";
			if (this.IsPrivate != null)
			{
				text = text + "isPrivate," + this.IsPrivate.ToString() + ",";
			}
			if (this.IsLocked != null)
			{
				text = text + "isLocked," + this.IsLocked.ToString() + ",";
			}
			if (this.Player != null)
			{
				text = text + "player," + this.Player.ToString() + ",";
			}
			if (this.Password != null)
			{
				text = text + "password," + this.Password + ",";
			}
			if (this.Data != null)
			{
				text = text + "data," + this.Data.ToString();
			}
			return text;
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00006780 File Offset: 0x00004980
		internal Dictionary<string, string> GetAsQueryParam()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (this.Name != null)
			{
				string value = this.Name.ToString();
				dictionary.Add("name", value);
			}
			string value2 = this.MaxPlayers.ToString();
			dictionary.Add("maxPlayers", value2);
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
			return dictionary;
		}
	}
}
