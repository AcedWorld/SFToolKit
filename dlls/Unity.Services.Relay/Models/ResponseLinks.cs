using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Relay.Models
{
	// Token: 0x0200002F RID: 47
	[Preserve]
	[DataContract(Name = "ResponseLinks")]
	public class ResponseLinks
	{
		// Token: 0x060000C3 RID: 195 RVA: 0x00003B4C File Offset: 0x00001D4C
		[Preserve]
		public ResponseLinks(string next = null)
		{
			this.Next = next;
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060000C4 RID: 196 RVA: 0x00003B5B File Offset: 0x00001D5B
		[Preserve]
		[DataMember(Name = "next", EmitDefaultValue = false)]
		public string Next { get; }

		// Token: 0x060000C5 RID: 197 RVA: 0x00003B64 File Offset: 0x00001D64
		internal string SerializeAsPathParam()
		{
			string text = "";
			if (this.Next != null)
			{
				text = text + "next," + this.Next;
			}
			return text;
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00003B94 File Offset: 0x00001D94
		internal Dictionary<string, string> GetAsQueryParam()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (this.Next != null)
			{
				string value = this.Next.ToString();
				dictionary.Add("next", value);
			}
			return dictionary;
		}
	}
}
