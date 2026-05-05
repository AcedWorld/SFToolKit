using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Unity.Services.Qos.V2.Http;
using UnityEngine.Scripting;

namespace Unity.Services.Qos.V2.Models
{
	// Token: 0x02000024 RID: 36
	[Preserve]
	[DataContract(Name = "ErrorResponseBody")]
	internal class ErrorResponseBody
	{
		// Token: 0x0600008C RID: 140 RVA: 0x00004110 File Offset: 0x00002310
		[Preserve]
		public ErrorResponseBody(string type, string title, int status, int code, string detail, string instance = null, List<object> details = null)
		{
			this.Type = type;
			this.Title = title;
			this.Status = status;
			this.Code = code;
			this.Detail = detail;
			this.Instance = instance;
			this.Details = JsonObject.GetNewJsonObjectResponse(details);
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x0600008D RID: 141 RVA: 0x0000415D File Offset: 0x0000235D
		[Preserve]
		[DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
		public string Type { get; }

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x0600008E RID: 142 RVA: 0x00004165 File Offset: 0x00002365
		[Preserve]
		[DataMember(Name = "title", IsRequired = true, EmitDefaultValue = true)]
		public string Title { get; }

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x0600008F RID: 143 RVA: 0x0000416D File Offset: 0x0000236D
		[Preserve]
		[DataMember(Name = "status", IsRequired = true, EmitDefaultValue = true)]
		public int Status { get; }

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000090 RID: 144 RVA: 0x00004175 File Offset: 0x00002375
		[Preserve]
		[DataMember(Name = "code", IsRequired = true, EmitDefaultValue = true)]
		public int Code { get; }

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000091 RID: 145 RVA: 0x0000417D File Offset: 0x0000237D
		[Preserve]
		[DataMember(Name = "detail", IsRequired = true, EmitDefaultValue = true)]
		public string Detail { get; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000092 RID: 146 RVA: 0x00004185 File Offset: 0x00002385
		[Preserve]
		[DataMember(Name = "instance", EmitDefaultValue = false)]
		public string Instance { get; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000093 RID: 147 RVA: 0x0000418D File Offset: 0x0000238D
		[Preserve]
		[DataMember(Name = "details", EmitDefaultValue = false)]
		public List<IDeserializable> Details { get; }

		// Token: 0x06000094 RID: 148 RVA: 0x00004198 File Offset: 0x00002398
		internal string SerializeAsPathParam()
		{
			string text = "";
			if (this.Type != null)
			{
				text = text + "type," + this.Type + ",";
			}
			if (this.Title != null)
			{
				text = text + "title," + this.Title + ",";
			}
			text = text + "status," + this.Status.ToString() + ",";
			text = text + "code," + this.Code.ToString() + ",";
			if (this.Detail != null)
			{
				text = text + "detail," + this.Detail + ",";
			}
			if (this.Instance != null)
			{
				text = text + "instance," + this.Instance + ",";
			}
			if (this.Details != null)
			{
				text = text + "details," + this.Details.ToString();
			}
			return text;
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00004288 File Offset: 0x00002488
		internal Dictionary<string, string> GetAsQueryParam()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (this.Type != null)
			{
				string value = this.Type.ToString();
				dictionary.Add("type", value);
			}
			if (this.Title != null)
			{
				string value2 = this.Title.ToString();
				dictionary.Add("title", value2);
			}
			string value3 = this.Status.ToString();
			dictionary.Add("status", value3);
			string value4 = this.Code.ToString();
			dictionary.Add("code", value4);
			if (this.Detail != null)
			{
				string value5 = this.Detail.ToString();
				dictionary.Add("detail", value5);
			}
			if (this.Instance != null)
			{
				string value6 = this.Instance.ToString();
				dictionary.Add("instance", value6);
			}
			if (this.Details != null)
			{
				string value7 = this.Details.ToString();
				dictionary.Add("details", value7);
			}
			return dictionary;
		}
	}
}
