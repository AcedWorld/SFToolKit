using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Models
{
	// Token: 0x02000038 RID: 56
	[Preserve]
	[DataContract(Name = "JoinByIdRequest")]
	public class JoinByIdRequest
	{
		// Token: 0x06000188 RID: 392 RVA: 0x00006D34 File Offset: 0x00004F34
		[Preserve]
		public JoinByIdRequest(string password = null, Player player = null)
		{
			this.Password = password;
			this.Player = player;
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x06000189 RID: 393 RVA: 0x00006D4A File Offset: 0x00004F4A
		[Preserve]
		[DataMember(Name = "password", EmitDefaultValue = false)]
		public string Password { get; }

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x0600018A RID: 394 RVA: 0x00006D52 File Offset: 0x00004F52
		[Preserve]
		[DataMember(Name = "player", EmitDefaultValue = false)]
		public Player Player { get; }

		// Token: 0x0600018B RID: 395 RVA: 0x00006D5C File Offset: 0x00004F5C
		internal string SerializeAsPathParam()
		{
			string text = "";
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

		// Token: 0x0600018C RID: 396 RVA: 0x00006DB0 File Offset: 0x00004FB0
		internal Dictionary<string, string> GetAsQueryParam()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (this.Password != null)
			{
				string value = this.Password.ToString();
				dictionary.Add("password", value);
			}
			return dictionary;
		}
	}
}
