using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Models
{
	// Token: 0x02000037 RID: 55
	[Preserve]
	[DataContract(Name = "JoinByCodeRequest")]
	public class JoinByCodeRequest
	{
		// Token: 0x06000182 RID: 386 RVA: 0x00006C34 File Offset: 0x00004E34
		[Preserve]
		public JoinByCodeRequest(string lobbyCode, Player player = null, string password = null)
		{
			this.LobbyCode = lobbyCode;
			this.Password = password;
			this.Player = player;
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06000183 RID: 387 RVA: 0x00006C51 File Offset: 0x00004E51
		[Preserve]
		[DataMember(Name = "lobbyCode", IsRequired = true, EmitDefaultValue = true)]
		public string LobbyCode { get; }

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x06000184 RID: 388 RVA: 0x00006C59 File Offset: 0x00004E59
		[Preserve]
		[DataMember(Name = "password", EmitDefaultValue = false)]
		public string Password { get; }

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x06000185 RID: 389 RVA: 0x00006C61 File Offset: 0x00004E61
		[Preserve]
		[DataMember(Name = "player", EmitDefaultValue = false)]
		public Player Player { get; }

		// Token: 0x06000186 RID: 390 RVA: 0x00006C6C File Offset: 0x00004E6C
		internal string SerializeAsPathParam()
		{
			string text = "";
			if (this.LobbyCode != null)
			{
				text = text + "lobbyCode," + this.LobbyCode + ",";
			}
			if (this.Password != null)
			{
				text = text + "password," + this.Password + ",";
			}
			if (this.Player != null)
			{
				text = text + "player," + this.Player.ToString();
			}
			return text;
		}

		// Token: 0x06000187 RID: 391 RVA: 0x00006CE0 File Offset: 0x00004EE0
		internal Dictionary<string, string> GetAsQueryParam()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (this.LobbyCode != null)
			{
				string value = this.LobbyCode.ToString();
				dictionary.Add("lobbyCode", value);
			}
			if (this.Password != null)
			{
				string value2 = this.Password.ToString();
				dictionary.Add("password", value2);
			}
			return dictionary;
		}
	}
}
