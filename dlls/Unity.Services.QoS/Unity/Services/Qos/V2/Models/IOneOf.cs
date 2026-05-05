using System;

namespace Unity.Services.Qos.V2.Models
{
	// Token: 0x02000025 RID: 37
	internal interface IOneOf
	{
		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000096 RID: 150
		Type Type { get; }

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000097 RID: 151
		object Value { get; }
	}
}
