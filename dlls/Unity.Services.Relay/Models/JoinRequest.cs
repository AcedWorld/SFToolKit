using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Relay.Models
{
	// Token: 0x02000026 RID: 38
	[Preserve]
	[DataContract(Name = "JoinRequest")]
	public class JoinRequest
	{
		// Token: 0x06000098 RID: 152 RVA: 0x00003542 File Offset: 0x00001742
		[Preserve]
		public JoinRequest(string joinCode)
		{
			this.JoinCode = joinCode;
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000099 RID: 153 RVA: 0x00003551 File Offset: 0x00001751
		[Preserve]
		[DataMember(Name = "joinCode", IsRequired = true, EmitDefaultValue = true)]
		public string JoinCode { get; }

		// Token: 0x0600009A RID: 154 RVA: 0x0000355C File Offset: 0x0000175C
		internal string SerializeAsPathParam()
		{
			string text = "";
			if (this.JoinCode != null)
			{
				text = text + "joinCode," + this.JoinCode;
			}
			return text;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x0000358C File Offset: 0x0000178C
		internal Dictionary<string, string> GetAsQueryParam()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (this.JoinCode != null)
			{
				string value = this.JoinCode.ToString();
				dictionary.Add("joinCode", value);
			}
			return dictionary;
		}
	}
}
