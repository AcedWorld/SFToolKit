using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Unity.Services.Qos.Http;
using UnityEngine.Scripting;

namespace Unity.Services.Qos.Models
{
	// Token: 0x02000052 RID: 82
	[Preserve]
	[DataContract(Name = "ErrorResponseBody")]
	internal class ErrorResponseBody
	{
		// Token: 0x0600017F RID: 383 RVA: 0x000065CC File Offset: 0x000047CC
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

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000180 RID: 384 RVA: 0x00006619 File Offset: 0x00004819
		[Preserve]
		[DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
		public string Type { get; }

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000181 RID: 385 RVA: 0x00006621 File Offset: 0x00004821
		[Preserve]
		[DataMember(Name = "title", IsRequired = true, EmitDefaultValue = true)]
		public string Title { get; }

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000182 RID: 386 RVA: 0x00006629 File Offset: 0x00004829
		[Preserve]
		[DataMember(Name = "status", IsRequired = true, EmitDefaultValue = true)]
		public int Status { get; }

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000183 RID: 387 RVA: 0x00006631 File Offset: 0x00004831
		[Preserve]
		[DataMember(Name = "code", IsRequired = true, EmitDefaultValue = true)]
		public int Code { get; }

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000184 RID: 388 RVA: 0x00006639 File Offset: 0x00004839
		[Preserve]
		[DataMember(Name = "detail", IsRequired = true, EmitDefaultValue = true)]
		public string Detail { get; }

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000185 RID: 389 RVA: 0x00006641 File Offset: 0x00004841
		[Preserve]
		[DataMember(Name = "instance", EmitDefaultValue = false)]
		public string Instance { get; }

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000186 RID: 390 RVA: 0x00006649 File Offset: 0x00004849
		[Preserve]
		[DataMember(Name = "details", EmitDefaultValue = false)]
		public List<IDeserializable> Details { get; }

		// Token: 0x06000187 RID: 391 RVA: 0x00006654 File Offset: 0x00004854
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

		// Token: 0x06000188 RID: 392 RVA: 0x00006744 File Offset: 0x00004944
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
