using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Models
{
	// Token: 0x02000044 RID: 68
	[Preserve]
	[DataContract(Name = "TokenRequest")]
	public class TokenRequest
	{
		// Token: 0x060001F5 RID: 501 RVA: 0x00007E50 File Offset: 0x00006050
		[Preserve]
		public TokenRequest(TokenRequest.TokenTypeOptions tokenType)
		{
			this.TokenType = tokenType;
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x060001F6 RID: 502 RVA: 0x00007E5F File Offset: 0x0000605F
		[Preserve]
		[JsonConverter(typeof(StringEnumConverter))]
		[DataMember(Name = "tokenType", IsRequired = true, EmitDefaultValue = true)]
		public TokenRequest.TokenTypeOptions TokenType { get; }

		// Token: 0x060001F7 RID: 503 RVA: 0x00007E68 File Offset: 0x00006068
		internal string SerializeAsPathParam()
		{
			return "" + "tokenType," + this.TokenType.ToString();
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x00007E98 File Offset: 0x00006098
		internal Dictionary<string, string> GetAsQueryParam()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			string value = this.TokenType.ToString();
			dictionary.Add("tokenType", value);
			return dictionary;
		}

		// Token: 0x020000A3 RID: 163
		[Preserve]
		[JsonConverter(typeof(StringEnumConverter))]
		public enum TokenTypeOptions
		{
			// Token: 0x04000287 RID: 647
			[EnumMember(Value = "vivoxJoin")]
			VivoxJoin = 1,
			// Token: 0x04000288 RID: 648
			[EnumMember(Value = "wireJoin")]
			WireJoin
		}
	}
}
