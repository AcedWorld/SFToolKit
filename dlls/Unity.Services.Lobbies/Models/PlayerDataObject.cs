using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Models
{
	// Token: 0x0200003B RID: 59
	[Preserve]
	[DataContract(Name = "PlayerDataObject")]
	public class PlayerDataObject
	{
		// Token: 0x060001C1 RID: 449 RVA: 0x000075E6 File Offset: 0x000057E6
		[Preserve]
		public PlayerDataObject(PlayerDataObject.VisibilityOptions visibility, string value = null)
		{
			this.Value = value;
			this.Visibility = visibility;
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x060001C2 RID: 450 RVA: 0x000075FC File Offset: 0x000057FC
		// (set) Token: 0x060001C3 RID: 451 RVA: 0x00007604 File Offset: 0x00005804
		[Preserve]
		[DataMember(Name = "value", EmitDefaultValue = false)]
		public string Value { get; set; }

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x060001C4 RID: 452 RVA: 0x0000760D File Offset: 0x0000580D
		// (set) Token: 0x060001C5 RID: 453 RVA: 0x00007615 File Offset: 0x00005815
		[Preserve]
		[JsonConverter(typeof(StringEnumConverter))]
		[DataMember(Name = "visibility", IsRequired = true, EmitDefaultValue = true)]
		public PlayerDataObject.VisibilityOptions Visibility { get; internal set; }

		// Token: 0x060001C6 RID: 454 RVA: 0x00007620 File Offset: 0x00005820
		internal string SerializeAsPathParam()
		{
			string str = "";
			if (this.Value != null)
			{
				str = str + "value," + this.Value + ",";
			}
			return str + "visibility," + this.Visibility.ToString();
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x00007674 File Offset: 0x00005874
		internal Dictionary<string, string> GetAsQueryParam()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (this.Value != null)
			{
				string value = this.Value.ToString();
				dictionary.Add("value", value);
			}
			string value2 = this.Visibility.ToString();
			dictionary.Add("visibility", value2);
			return dictionary;
		}

		// Token: 0x0200009F RID: 159
		[Preserve]
		[JsonConverter(typeof(StringEnumConverter))]
		public enum VisibilityOptions
		{
			// Token: 0x04000258 RID: 600
			[EnumMember(Value = "public")]
			Public = 1,
			// Token: 0x04000259 RID: 601
			[EnumMember(Value = "member")]
			Member,
			// Token: 0x0400025A RID: 602
			[EnumMember(Value = "private")]
			Private
		}
	}
}
