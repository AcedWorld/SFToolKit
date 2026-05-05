using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Relay.Models
{
	// Token: 0x0200002B RID: 43
	[Preserve]
	[DataContract(Name = "RegionsResponseBody")]
	public class RegionsResponseBody
	{
		// Token: 0x060000AF RID: 175 RVA: 0x0000382E File Offset: 0x00001A2E
		[Preserve]
		public RegionsResponseBody(RegionsData data)
		{
			this.Data = data;
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x0000383D File Offset: 0x00001A3D
		[Preserve]
		[DataMember(Name = "data", IsRequired = true, EmitDefaultValue = true)]
		public RegionsData Data { get; }

		// Token: 0x060000B1 RID: 177 RVA: 0x00003848 File Offset: 0x00001A48
		internal string SerializeAsPathParam()
		{
			string text = "";
			if (this.Data != null)
			{
				text = text + "data," + this.Data.ToString();
			}
			return text;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000387B File Offset: 0x00001A7B
		internal Dictionary<string, string> GetAsQueryParam()
		{
			return new Dictionary<string, string>();
		}
	}
}
