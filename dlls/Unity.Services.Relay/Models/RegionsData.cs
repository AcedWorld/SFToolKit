using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Relay.Models
{
	// Token: 0x0200002A RID: 42
	[Preserve]
	[DataContract(Name = "RegionsData")]
	public class RegionsData
	{
		// Token: 0x060000AB RID: 171 RVA: 0x000037DC File Offset: 0x000019DC
		[Preserve]
		public RegionsData(List<Region> regions)
		{
			this.Regions = regions;
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000AC RID: 172 RVA: 0x000037EB File Offset: 0x000019EB
		[Preserve]
		[DataMember(Name = "regions", IsRequired = true, EmitDefaultValue = true)]
		public List<Region> Regions { get; }

		// Token: 0x060000AD RID: 173 RVA: 0x000037F4 File Offset: 0x000019F4
		internal string SerializeAsPathParam()
		{
			string text = "";
			if (this.Regions != null)
			{
				text = text + "regions," + this.Regions.ToString();
			}
			return text;
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00003827 File Offset: 0x00001A27
		internal Dictionary<string, string> GetAsQueryParam()
		{
			return new Dictionary<string, string>();
		}
	}
}
