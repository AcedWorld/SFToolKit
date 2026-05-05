using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Relay.Models
{
	// Token: 0x0200001F RID: 31
	[Preserve]
	[DataContract(Name = "ErrorResponseBody")]
	public class ErrorResponseBody
	{
		// Token: 0x0600006E RID: 110 RVA: 0x00002E1B File Offset: 0x0000101B
		[Preserve]
		public ErrorResponseBody(int status, string detail, string title, string type, int code, List<KeyValuePair> details = null)
		{
			this.Status = status;
			this.Detail = detail;
			this.Title = title;
			this.Details = details;
			this.Type = type;
			this.Code = code;
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600006F RID: 111 RVA: 0x00002E50 File Offset: 0x00001050
		[Preserve]
		[DataMember(Name = "status", IsRequired = true, EmitDefaultValue = true)]
		public int Status { get; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000070 RID: 112 RVA: 0x00002E58 File Offset: 0x00001058
		[Preserve]
		[DataMember(Name = "detail", IsRequired = true, EmitDefaultValue = true)]
		public string Detail { get; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000071 RID: 113 RVA: 0x00002E60 File Offset: 0x00001060
		[Preserve]
		[DataMember(Name = "title", IsRequired = true, EmitDefaultValue = true)]
		public string Title { get; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000072 RID: 114 RVA: 0x00002E68 File Offset: 0x00001068
		[Preserve]
		[DataMember(Name = "details", EmitDefaultValue = false)]
		public List<KeyValuePair> Details { get; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000073 RID: 115 RVA: 0x00002E70 File Offset: 0x00001070
		[Preserve]
		[DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
		public string Type { get; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000074 RID: 116 RVA: 0x00002E78 File Offset: 0x00001078
		[Preserve]
		[DataMember(Name = "code", IsRequired = true, EmitDefaultValue = true)]
		public int Code { get; }

		// Token: 0x06000075 RID: 117 RVA: 0x00002E80 File Offset: 0x00001080
		internal string SerializeAsPathParam()
		{
			string str = "";
			str = str + "status," + this.Status.ToString() + ",";
			if (this.Detail != null)
			{
				str = str + "detail," + this.Detail + ",";
			}
			if (this.Title != null)
			{
				str = str + "title," + this.Title + ",";
			}
			if (this.Details != null)
			{
				str = str + "details," + this.Details.ToString() + ",";
			}
			if (this.Type != null)
			{
				str = str + "type," + this.Type + ",";
			}
			return str + "code," + this.Code.ToString();
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00002F50 File Offset: 0x00001150
		internal Dictionary<string, string> GetAsQueryParam()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			string value = this.Status.ToString();
			dictionary.Add("status", value);
			if (this.Detail != null)
			{
				string value2 = this.Detail.ToString();
				dictionary.Add("detail", value2);
			}
			if (this.Title != null)
			{
				string value3 = this.Title.ToString();
				dictionary.Add("title", value3);
			}
			if (this.Type != null)
			{
				string value4 = this.Type.ToString();
				dictionary.Add("type", value4);
			}
			string value5 = this.Code.ToString();
			dictionary.Add("code", value5);
			return dictionary;
		}
	}
}
