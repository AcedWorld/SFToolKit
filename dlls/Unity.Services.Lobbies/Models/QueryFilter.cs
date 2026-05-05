using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Models
{
	// Token: 0x0200003E RID: 62
	[Preserve]
	[DataContract(Name = "QueryFilter")]
	public class QueryFilter
	{
		// Token: 0x060001D2 RID: 466 RVA: 0x00007848 File Offset: 0x00005A48
		[Preserve]
		public QueryFilter(QueryFilter.FieldOptions field, string value, QueryFilter.OpOptions op)
		{
			this.Field = field;
			this.Value = value;
			this.Op = op;
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x060001D3 RID: 467 RVA: 0x00007865 File Offset: 0x00005A65
		[Preserve]
		[JsonConverter(typeof(StringEnumConverter))]
		[DataMember(Name = "field", IsRequired = true, EmitDefaultValue = true)]
		public QueryFilter.FieldOptions Field { get; }

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x060001D4 RID: 468 RVA: 0x0000786D File Offset: 0x00005A6D
		[Preserve]
		[DataMember(Name = "value", IsRequired = true, EmitDefaultValue = true)]
		public string Value { get; }

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060001D5 RID: 469 RVA: 0x00007875 File Offset: 0x00005A75
		[Preserve]
		[JsonConverter(typeof(StringEnumConverter))]
		[DataMember(Name = "op", IsRequired = true, EmitDefaultValue = true)]
		public QueryFilter.OpOptions Op { get; }

		// Token: 0x060001D6 RID: 470 RVA: 0x00007880 File Offset: 0x00005A80
		internal string SerializeAsPathParam()
		{
			string str = "";
			str = str + "field," + this.Field.ToString() + ",";
			if (this.Value != null)
			{
				str = str + "value," + this.Value + ",";
			}
			return str + "op," + this.Op.ToString();
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x000078F8 File Offset: 0x00005AF8
		internal Dictionary<string, string> GetAsQueryParam()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			string value = this.Field.ToString();
			dictionary.Add("field", value);
			if (this.Value != null)
			{
				string value2 = this.Value.ToString();
				dictionary.Add("value", value2);
			}
			string value3 = this.Op.ToString();
			dictionary.Add("op", value3);
			return dictionary;
		}

		// Token: 0x020000A0 RID: 160
		[Preserve]
		[JsonConverter(typeof(StringEnumConverter))]
		public enum FieldOptions
		{
			// Token: 0x0400025C RID: 604
			[EnumMember(Value = "MaxPlayers")]
			MaxPlayers = 1,
			// Token: 0x0400025D RID: 605
			[EnumMember(Value = "AvailableSlots")]
			AvailableSlots,
			// Token: 0x0400025E RID: 606
			[EnumMember(Value = "Name")]
			Name,
			// Token: 0x0400025F RID: 607
			[EnumMember(Value = "Created")]
			Created,
			// Token: 0x04000260 RID: 608
			[EnumMember(Value = "LastUpdated")]
			LastUpdated,
			// Token: 0x04000261 RID: 609
			[EnumMember(Value = "S1")]
			S1,
			// Token: 0x04000262 RID: 610
			[EnumMember(Value = "S2")]
			S2,
			// Token: 0x04000263 RID: 611
			[EnumMember(Value = "S3")]
			S3,
			// Token: 0x04000264 RID: 612
			[EnumMember(Value = "S4")]
			S4,
			// Token: 0x04000265 RID: 613
			[EnumMember(Value = "S5")]
			S5,
			// Token: 0x04000266 RID: 614
			[EnumMember(Value = "N1")]
			N1,
			// Token: 0x04000267 RID: 615
			[EnumMember(Value = "N2")]
			N2,
			// Token: 0x04000268 RID: 616
			[EnumMember(Value = "N3")]
			N3,
			// Token: 0x04000269 RID: 617
			[EnumMember(Value = "N4")]
			N4,
			// Token: 0x0400026A RID: 618
			[EnumMember(Value = "N5")]
			N5,
			// Token: 0x0400026B RID: 619
			[EnumMember(Value = "IsLocked")]
			IsLocked,
			// Token: 0x0400026C RID: 620
			[EnumMember(Value = "HasPassword")]
			HasPassword
		}

		// Token: 0x020000A1 RID: 161
		[Preserve]
		[JsonConverter(typeof(StringEnumConverter))]
		public enum OpOptions
		{
			// Token: 0x0400026E RID: 622
			[EnumMember(Value = "CONTAINS")]
			CONTAINS = 1,
			// Token: 0x0400026F RID: 623
			[EnumMember(Value = "EQ")]
			EQ,
			// Token: 0x04000270 RID: 624
			[EnumMember(Value = "NE")]
			NE,
			// Token: 0x04000271 RID: 625
			[EnumMember(Value = "LT")]
			LT,
			// Token: 0x04000272 RID: 626
			[EnumMember(Value = "LE")]
			LE,
			// Token: 0x04000273 RID: 627
			[EnumMember(Value = "GT")]
			GT,
			// Token: 0x04000274 RID: 628
			[EnumMember(Value = "GE")]
			GE
		}
	}
}
