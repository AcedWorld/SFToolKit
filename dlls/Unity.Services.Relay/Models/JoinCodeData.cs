using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Relay.Models
{
	// Token: 0x02000022 RID: 34
	[Preserve]
	[DataContract(Name = "JoinCodeData")]
	public class JoinCodeData
	{
		// Token: 0x06000086 RID: 134 RVA: 0x00003328 File Offset: 0x00001528
		[Preserve]
		public JoinCodeData(string joinCode)
		{
			this.JoinCode = joinCode;
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000087 RID: 135 RVA: 0x00003337 File Offset: 0x00001537
		[Preserve]
		[DataMember(Name = "joinCode", IsRequired = true, EmitDefaultValue = true)]
		public string JoinCode { get; }

		// Token: 0x06000088 RID: 136 RVA: 0x00003340 File Offset: 0x00001540
		internal string SerializeAsPathParam()
		{
			string text = "";
			if (this.JoinCode != null)
			{
				text = text + "joinCode," + this.JoinCode;
			}
			return text;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00003370 File Offset: 0x00001570
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
