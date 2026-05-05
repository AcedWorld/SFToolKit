using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Models
{
	// Token: 0x02000034 RID: 52
	[Preserve]
	[DataContract(Name = "Detail")]
	public class Detail
	{
		// Token: 0x06000172 RID: 370 RVA: 0x00006980 File Offset: 0x00004B80
		[Preserve]
		public Detail(string errorType = null, string message = null)
		{
			this.ErrorType = errorType;
			this.Message = message;
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000173 RID: 371 RVA: 0x00006996 File Offset: 0x00004B96
		[Preserve]
		[DataMember(Name = "errorType", EmitDefaultValue = false)]
		public string ErrorType { get; }

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000174 RID: 372 RVA: 0x0000699E File Offset: 0x00004B9E
		[Preserve]
		[DataMember(Name = "message", EmitDefaultValue = false)]
		public string Message { get; }

		// Token: 0x06000175 RID: 373 RVA: 0x000069A8 File Offset: 0x00004BA8
		internal string SerializeAsPathParam()
		{
			string text = "";
			if (this.ErrorType != null)
			{
				text = text + "errorType," + this.ErrorType + ",";
			}
			if (this.Message != null)
			{
				text = text + "message," + this.Message;
			}
			return text;
		}

		// Token: 0x06000176 RID: 374 RVA: 0x000069F8 File Offset: 0x00004BF8
		internal Dictionary<string, string> GetAsQueryParam()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (this.ErrorType != null)
			{
				string value = this.ErrorType.ToString();
				dictionary.Add("errorType", value);
			}
			if (this.Message != null)
			{
				string value2 = this.Message.ToString();
				dictionary.Add("message", value2);
			}
			return dictionary;
		}
	}
}
