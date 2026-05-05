using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Models
{
	// Token: 0x02000041 RID: 65
	[Preserve]
	[DataContract(Name = "QueryResponse")]
	public class QueryResponse
	{
		// Token: 0x060001E6 RID: 486 RVA: 0x00007C52 File Offset: 0x00005E52
		[Preserve]
		public QueryResponse(List<Lobby> results = null, string continuationToken = null)
		{
			this.Results = results;
			this.ContinuationToken = continuationToken;
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x060001E7 RID: 487 RVA: 0x00007C68 File Offset: 0x00005E68
		[Preserve]
		[DataMember(Name = "results", EmitDefaultValue = false)]
		public List<Lobby> Results { get; }

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x060001E8 RID: 488 RVA: 0x00007C70 File Offset: 0x00005E70
		[Preserve]
		[DataMember(Name = "continuationToken", EmitDefaultValue = false)]
		public string ContinuationToken { get; }

		// Token: 0x060001E9 RID: 489 RVA: 0x00007C78 File Offset: 0x00005E78
		internal string SerializeAsPathParam()
		{
			string text = "";
			if (this.Results != null)
			{
				text = text + "results," + this.Results.ToString() + ",";
			}
			if (this.ContinuationToken != null)
			{
				text = text + "continuationToken," + this.ContinuationToken;
			}
			return text;
		}

		// Token: 0x060001EA RID: 490 RVA: 0x00007CCC File Offset: 0x00005ECC
		internal Dictionary<string, string> GetAsQueryParam()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (this.ContinuationToken != null)
			{
				string value = this.ContinuationToken.ToString();
				dictionary.Add("continuationToken", value);
			}
			return dictionary;
		}
	}
}
