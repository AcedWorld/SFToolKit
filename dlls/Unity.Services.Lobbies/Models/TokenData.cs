using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Models
{
	// Token: 0x02000043 RID: 67
	[Preserve]
	[DataContract(Name = "TokenData")]
	public class TokenData
	{
		// Token: 0x060001F0 RID: 496 RVA: 0x00007D86 File Offset: 0x00005F86
		[Preserve]
		public TokenData(string tokenValue = null, string uri = null)
		{
			this.TokenValue = tokenValue;
			this.Uri = uri;
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x060001F1 RID: 497 RVA: 0x00007D9C File Offset: 0x00005F9C
		[Preserve]
		[DataMember(Name = "tokenValue", EmitDefaultValue = false)]
		public string TokenValue { get; }

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x060001F2 RID: 498 RVA: 0x00007DA4 File Offset: 0x00005FA4
		[Preserve]
		[DataMember(Name = "uri", EmitDefaultValue = false)]
		public string Uri { get; }

		// Token: 0x060001F3 RID: 499 RVA: 0x00007DAC File Offset: 0x00005FAC
		internal string SerializeAsPathParam()
		{
			string text = "";
			if (this.TokenValue != null)
			{
				text = text + "tokenValue," + this.TokenValue + ",";
			}
			if (this.Uri != null)
			{
				text = text + "uri," + this.Uri;
			}
			return text;
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x00007DFC File Offset: 0x00005FFC
		internal Dictionary<string, string> GetAsQueryParam()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (this.TokenValue != null)
			{
				string value = this.TokenValue.ToString();
				dictionary.Add("tokenValue", value);
			}
			if (this.Uri != null)
			{
				string value2 = this.Uri.ToString();
				dictionary.Add("uri", value2);
			}
			return dictionary;
		}
	}
}
