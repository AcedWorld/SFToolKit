using System;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Qos.Models
{
	// Token: 0x02000053 RID: 83
	[Preserve]
	[DataContract(Name = "KeyValuePair")]
	internal class KeyValuePair
	{
		// Token: 0x06000189 RID: 393 RVA: 0x00006838 File Offset: 0x00004A38
		[Preserve]
		public KeyValuePair(string key, string value)
		{
			this.Key = key;
			this.Value = value;
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x0600018A RID: 394 RVA: 0x0000684E File Offset: 0x00004A4E
		[Preserve]
		[DataMember(Name = "key", IsRequired = true, EmitDefaultValue = true)]
		public string Key { get; }

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x0600018B RID: 395 RVA: 0x00006856 File Offset: 0x00004A56
		[Preserve]
		[DataMember(Name = "value", IsRequired = true, EmitDefaultValue = true)]
		public string Value { get; }
	}
}
