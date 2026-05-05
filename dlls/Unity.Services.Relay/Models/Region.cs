using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Relay.Models
{
	// Token: 0x02000029 RID: 41
	[Preserve]
	[DataContract(Name = "Region")]
	public class Region
	{
		// Token: 0x060000A6 RID: 166 RVA: 0x00003710 File Offset: 0x00001910
		[Preserve]
		public Region(string id, string description)
		{
			this.Id = id;
			this.Description = description;
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000A7 RID: 167 RVA: 0x00003726 File Offset: 0x00001926
		[Preserve]
		[DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
		public string Id { get; }

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000A8 RID: 168 RVA: 0x0000372E File Offset: 0x0000192E
		[Preserve]
		[DataMember(Name = "description", IsRequired = true, EmitDefaultValue = true)]
		public string Description { get; }

		// Token: 0x060000A9 RID: 169 RVA: 0x00003738 File Offset: 0x00001938
		internal string SerializeAsPathParam()
		{
			string text = "";
			if (this.Id != null)
			{
				text = text + "id," + this.Id + ",";
			}
			if (this.Description != null)
			{
				text = text + "description," + this.Description;
			}
			return text;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00003788 File Offset: 0x00001988
		internal Dictionary<string, string> GetAsQueryParam()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (this.Id != null)
			{
				string value = this.Id.ToString();
				dictionary.Add("id", value);
			}
			if (this.Description != null)
			{
				string value2 = this.Description.ToString();
				dictionary.Add("description", value2);
			}
			return dictionary;
		}
	}
}
