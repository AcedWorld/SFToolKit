using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Models
{
	// Token: 0x02000033 RID: 51
	[Preserve]
	[DataContract(Name = "DataObject")]
	public class DataObject
	{
		// Token: 0x0600016C RID: 364 RVA: 0x0000685B File Offset: 0x00004A5B
		[Preserve]
		public DataObject(DataObject.VisibilityOptions visibility, string value = null, DataObject.IndexOptions index = (DataObject.IndexOptions)0)
		{
			this.Value = value;
			this.Visibility = visibility;
			this.Index = index;
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x0600016D RID: 365 RVA: 0x00006878 File Offset: 0x00004A78
		[Preserve]
		[DataMember(Name = "value", EmitDefaultValue = false)]
		public string Value { get; }

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x0600016E RID: 366 RVA: 0x00006880 File Offset: 0x00004A80
		[Preserve]
		[JsonConverter(typeof(StringEnumConverter))]
		[DataMember(Name = "visibility", IsRequired = true, EmitDefaultValue = true)]
		public DataObject.VisibilityOptions Visibility { get; }

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x0600016F RID: 367 RVA: 0x00006888 File Offset: 0x00004A88
		[Preserve]
		[JsonConverter(typeof(StringEnumConverter))]
		[DataMember(Name = "index", EmitDefaultValue = false)]
		public DataObject.IndexOptions Index { get; }

		// Token: 0x06000170 RID: 368 RVA: 0x00006890 File Offset: 0x00004A90
		internal string SerializeAsPathParam()
		{
			string str = "";
			if (this.Value != null)
			{
				str = str + "value," + this.Value + ",";
			}
			str = str + "visibility," + this.Visibility.ToString() + ",";
			return str + "index," + this.Index.ToString();
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00006908 File Offset: 0x00004B08
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
			string value3 = this.Index.ToString();
			dictionary.Add("index", value3);
			return dictionary;
		}

		// Token: 0x0200009D RID: 157
		[Preserve]
		[JsonConverter(typeof(StringEnumConverter))]
		public enum VisibilityOptions
		{
			// Token: 0x04000249 RID: 585
			[EnumMember(Value = "public")]
			Public = 1,
			// Token: 0x0400024A RID: 586
			[EnumMember(Value = "member")]
			Member,
			// Token: 0x0400024B RID: 587
			[EnumMember(Value = "private")]
			Private
		}

		// Token: 0x0200009E RID: 158
		[Preserve]
		[JsonConverter(typeof(StringEnumConverter))]
		public enum IndexOptions
		{
			// Token: 0x0400024D RID: 589
			[EnumMember(Value = "S1")]
			S1 = 1,
			// Token: 0x0400024E RID: 590
			[EnumMember(Value = "S2")]
			S2,
			// Token: 0x0400024F RID: 591
			[EnumMember(Value = "S3")]
			S3,
			// Token: 0x04000250 RID: 592
			[EnumMember(Value = "S4")]
			S4,
			// Token: 0x04000251 RID: 593
			[EnumMember(Value = "S5")]
			S5,
			// Token: 0x04000252 RID: 594
			[EnumMember(Value = "N1")]
			N1,
			// Token: 0x04000253 RID: 595
			[EnumMember(Value = "N2")]
			N2,
			// Token: 0x04000254 RID: 596
			[EnumMember(Value = "N3")]
			N3,
			// Token: 0x04000255 RID: 597
			[EnumMember(Value = "N4")]
			N4,
			// Token: 0x04000256 RID: 598
			[EnumMember(Value = "N5")]
			N5
		}
	}
}
