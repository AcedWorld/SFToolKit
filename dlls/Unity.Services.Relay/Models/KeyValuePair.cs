using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Relay.Models
{
	// Token: 0x02000028 RID: 40
	[Preserve]
	[DataContract(Name = "KeyValuePair")]
	public class KeyValuePair
	{
		// Token: 0x060000A1 RID: 161 RVA: 0x00003646 File Offset: 0x00001846
		[Preserve]
		public KeyValuePair(string key, string value)
		{
			this.Key = key;
			this.Value = value;
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000A2 RID: 162 RVA: 0x0000365C File Offset: 0x0000185C
		[Preserve]
		[DataMember(Name = "key", IsRequired = true, EmitDefaultValue = true)]
		public string Key { get; }

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000A3 RID: 163 RVA: 0x00003664 File Offset: 0x00001864
		[Preserve]
		[DataMember(Name = "value", IsRequired = true, EmitDefaultValue = true)]
		public string Value { get; }

		// Token: 0x060000A4 RID: 164 RVA: 0x0000366C File Offset: 0x0000186C
		internal string SerializeAsPathParam()
		{
			string text = "";
			if (this.Key != null)
			{
				text = text + "key," + this.Key + ",";
			}
			if (this.Value != null)
			{
				text = text + "value," + this.Value;
			}
			return text;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x000036BC File Offset: 0x000018BC
		internal Dictionary<string, string> GetAsQueryParam()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (this.Key != null)
			{
				string value = this.Key.ToString();
				dictionary.Add("key", value);
			}
			if (this.Value != null)
			{
				string value2 = this.Value.ToString();
				dictionary.Add("value", value2);
			}
			return dictionary;
		}
	}
}
