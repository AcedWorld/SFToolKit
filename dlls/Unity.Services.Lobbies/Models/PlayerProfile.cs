using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Models
{
	// Token: 0x0200003C RID: 60
	[Preserve]
	[DataContract(Name = "PlayerProfile")]
	public class PlayerProfile
	{
		// Token: 0x060001C8 RID: 456 RVA: 0x000076C9 File Offset: 0x000058C9
		[Preserve]
		public PlayerProfile(string name = null)
		{
			this.Name = name;
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x060001C9 RID: 457 RVA: 0x000076D8 File Offset: 0x000058D8
		[Preserve]
		[DataMember(Name = "name", EmitDefaultValue = false)]
		public string Name { get; }

		// Token: 0x060001CA RID: 458 RVA: 0x000076E0 File Offset: 0x000058E0
		internal string SerializeAsPathParam()
		{
			string text = "";
			if (this.Name != null)
			{
				text = text + "name," + this.Name;
			}
			return text;
		}

		// Token: 0x060001CB RID: 459 RVA: 0x00007710 File Offset: 0x00005910
		internal Dictionary<string, string> GetAsQueryParam()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (this.Name != null)
			{
				string value = this.Name.ToString();
				dictionary.Add("name", value);
			}
			return dictionary;
		}
	}
}
