using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Models
{
	// Token: 0x02000035 RID: 53
	[Preserve]
	[DataContract(Name = "ErrorStatus")]
	public class ErrorStatus
	{
		// Token: 0x06000177 RID: 375 RVA: 0x00006A4C File Offset: 0x00004C4C
		[Preserve]
		public ErrorStatus(string type = null, int status = 0, string title = null, string detail = null, int code = 0, List<Detail> details = null)
		{
			this.Type = type;
			this.Status = status;
			this.Title = title;
			this.Detail = detail;
			this.Code = code;
			this.Details = details;
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000178 RID: 376 RVA: 0x00006A81 File Offset: 0x00004C81
		[Preserve]
		[DataMember(Name = "type", EmitDefaultValue = false)]
		public string Type { get; }

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x06000179 RID: 377 RVA: 0x00006A89 File Offset: 0x00004C89
		[Preserve]
		[DataMember(Name = "status", EmitDefaultValue = false)]
		public int Status { get; }

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x0600017A RID: 378 RVA: 0x00006A91 File Offset: 0x00004C91
		[Preserve]
		[DataMember(Name = "title", EmitDefaultValue = false)]
		public string Title { get; }

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x0600017B RID: 379 RVA: 0x00006A99 File Offset: 0x00004C99
		[Preserve]
		[DataMember(Name = "detail", EmitDefaultValue = false)]
		public string Detail { get; }

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x0600017C RID: 380 RVA: 0x00006AA1 File Offset: 0x00004CA1
		[Preserve]
		[DataMember(Name = "code", EmitDefaultValue = false)]
		public int Code { get; }

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x0600017D RID: 381 RVA: 0x00006AA9 File Offset: 0x00004CA9
		[Preserve]
		[DataMember(Name = "details", EmitDefaultValue = false)]
		public List<Detail> Details { get; }

		// Token: 0x0600017E RID: 382 RVA: 0x00006AB4 File Offset: 0x00004CB4
		internal string SerializeAsPathParam()
		{
			string text = "";
			if (this.Type != null)
			{
				text = text + "type," + this.Type + ",";
			}
			text = text + "status," + this.Status.ToString() + ",";
			if (this.Title != null)
			{
				text = text + "title," + this.Title + ",";
			}
			if (this.Detail != null)
			{
				text = text + "detail," + this.Detail + ",";
			}
			text = text + "code," + this.Code.ToString() + ",";
			if (this.Details != null)
			{
				text = text + "details," + this.Details.ToString();
			}
			return text;
		}

		// Token: 0x0600017F RID: 383 RVA: 0x00006B84 File Offset: 0x00004D84
		internal Dictionary<string, string> GetAsQueryParam()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (this.Type != null)
			{
				string value = this.Type.ToString();
				dictionary.Add("type", value);
			}
			string value2 = this.Status.ToString();
			dictionary.Add("status", value2);
			if (this.Title != null)
			{
				string value3 = this.Title.ToString();
				dictionary.Add("title", value3);
			}
			if (this.Detail != null)
			{
				string value4 = this.Detail.ToString();
				dictionary.Add("detail", value4);
			}
			string value5 = this.Code.ToString();
			dictionary.Add("code", value5);
			return dictionary;
		}
	}
}
