using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Models
{
	// Token: 0x02000040 RID: 64
	[Preserve]
	[DataContract(Name = "QueryRequest")]
	public class QueryRequest
	{
		// Token: 0x060001DD RID: 477 RVA: 0x00007A36 File Offset: 0x00005C36
		[Preserve]
		public QueryRequest(int? count = 10, int? skip = 0, bool sampleResults = false, List<QueryFilter> filter = null, List<QueryOrder> order = null, string continuationToken = null)
		{
			this.Count = count;
			this.Skip = skip;
			this.SampleResults = sampleResults;
			this.Filter = filter;
			this.Order = order;
			this.ContinuationToken = continuationToken;
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x060001DE RID: 478 RVA: 0x00007A6B File Offset: 0x00005C6B
		[Preserve]
		[DataMember(Name = "count", EmitDefaultValue = false)]
		public int? Count { get; }

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x060001DF RID: 479 RVA: 0x00007A73 File Offset: 0x00005C73
		[Preserve]
		[DataMember(Name = "skip", EmitDefaultValue = false)]
		public int? Skip { get; }

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060001E0 RID: 480 RVA: 0x00007A7B File Offset: 0x00005C7B
		[Preserve]
		[DataMember(Name = "sampleResults", EmitDefaultValue = true)]
		public bool SampleResults { get; }

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060001E1 RID: 481 RVA: 0x00007A83 File Offset: 0x00005C83
		[Preserve]
		[DataMember(Name = "filter", EmitDefaultValue = false)]
		public List<QueryFilter> Filter { get; }

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x060001E2 RID: 482 RVA: 0x00007A8B File Offset: 0x00005C8B
		[Preserve]
		[DataMember(Name = "order", EmitDefaultValue = false)]
		public List<QueryOrder> Order { get; }

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x060001E3 RID: 483 RVA: 0x00007A93 File Offset: 0x00005C93
		[Preserve]
		[DataMember(Name = "continuationToken", EmitDefaultValue = false)]
		public string ContinuationToken { get; }

		// Token: 0x060001E4 RID: 484 RVA: 0x00007A9C File Offset: 0x00005C9C
		internal string SerializeAsPathParam()
		{
			string text = "";
			if (this.Count != null)
			{
				text = text + "count," + this.Count.ToString() + ",";
			}
			if (this.Skip != null)
			{
				text = text + "skip," + this.Skip.ToString() + ",";
			}
			text = text + "sampleResults," + this.SampleResults.ToString() + ",";
			if (this.Filter != null)
			{
				text = text + "filter," + this.Filter.ToString() + ",";
			}
			if (this.Order != null)
			{
				text = text + "order," + this.Order.ToString() + ",";
			}
			if (this.ContinuationToken != null)
			{
				text = text + "continuationToken," + this.ContinuationToken;
			}
			return text;
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x00007B9C File Offset: 0x00005D9C
		internal Dictionary<string, string> GetAsQueryParam()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (this.Count != null)
			{
				string value = this.Count.ToString();
				dictionary.Add("count", value);
			}
			if (this.Skip != null)
			{
				string value2 = this.Skip.ToString();
				dictionary.Add("skip", value2);
			}
			string value3 = this.SampleResults.ToString();
			dictionary.Add("sampleResults", value3);
			if (this.ContinuationToken != null)
			{
				string value4 = this.ContinuationToken.ToString();
				dictionary.Add("continuationToken", value4);
			}
			return dictionary;
		}
	}
}
