using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Models
{
	// Token: 0x0200003F RID: 63
	[Preserve]
	[DataContract(Name = "QueryOrder")]
	public class QueryOrder
	{
		// Token: 0x060001D8 RID: 472 RVA: 0x00007971 File Offset: 0x00005B71
		[Preserve]
		public QueryOrder(bool asc = false, QueryOrder.FieldOptions field = (QueryOrder.FieldOptions)0)
		{
			this.Asc = asc;
			this.Field = field;
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060001D9 RID: 473 RVA: 0x00007987 File Offset: 0x00005B87
		[Preserve]
		[DataMember(Name = "asc", EmitDefaultValue = true)]
		public bool Asc { get; }

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x060001DA RID: 474 RVA: 0x0000798F File Offset: 0x00005B8F
		[Preserve]
		[JsonConverter(typeof(StringEnumConverter))]
		[DataMember(Name = "field", EmitDefaultValue = false)]
		public QueryOrder.FieldOptions Field { get; }

		// Token: 0x060001DB RID: 475 RVA: 0x00007998 File Offset: 0x00005B98
		internal string SerializeAsPathParam()
		{
			return "" + "asc," + this.Asc.ToString() + "," + "field," + this.Field.ToString();
		}

		// Token: 0x060001DC RID: 476 RVA: 0x000079E8 File Offset: 0x00005BE8
		internal Dictionary<string, string> GetAsQueryParam()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			string value = this.Asc.ToString();
			dictionary.Add("asc", value);
			string value2 = this.Field.ToString();
			dictionary.Add("field", value2);
			return dictionary;
		}

		// Token: 0x020000A2 RID: 162
		[Preserve]
		[JsonConverter(typeof(StringEnumConverter))]
		public enum FieldOptions
		{
			// Token: 0x04000276 RID: 630
			[EnumMember(Value = "Name")]
			Name = 1,
			// Token: 0x04000277 RID: 631
			[EnumMember(Value = "MaxPlayers")]
			MaxPlayers,
			// Token: 0x04000278 RID: 632
			[EnumMember(Value = "AvailableSlots")]
			AvailableSlots,
			// Token: 0x04000279 RID: 633
			[EnumMember(Value = "Created")]
			Created,
			// Token: 0x0400027A RID: 634
			[EnumMember(Value = "LastUpdated")]
			LastUpdated,
			// Token: 0x0400027B RID: 635
			[EnumMember(Value = "ID")]
			ID,
			// Token: 0x0400027C RID: 636
			[EnumMember(Value = "S1")]
			S1,
			// Token: 0x0400027D RID: 637
			[EnumMember(Value = "S2")]
			S2,
			// Token: 0x0400027E RID: 638
			[EnumMember(Value = "S3")]
			S3,
			// Token: 0x0400027F RID: 639
			[EnumMember(Value = "S4")]
			S4,
			// Token: 0x04000280 RID: 640
			[EnumMember(Value = "S5")]
			S5,
			// Token: 0x04000281 RID: 641
			[EnumMember(Value = "N1")]
			N1,
			// Token: 0x04000282 RID: 642
			[EnumMember(Value = "N2")]
			N2,
			// Token: 0x04000283 RID: 643
			[EnumMember(Value = "N3")]
			N3,
			// Token: 0x04000284 RID: 644
			[EnumMember(Value = "N4")]
			N4,
			// Token: 0x04000285 RID: 645
			[EnumMember(Value = "N5")]
			N5
		}
	}
}
