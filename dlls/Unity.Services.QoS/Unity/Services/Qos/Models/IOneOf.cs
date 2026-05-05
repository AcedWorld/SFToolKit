using System;

namespace Unity.Services.Qos.Models
{
	// Token: 0x02000054 RID: 84
	internal interface IOneOf
	{
		// Token: 0x17000068 RID: 104
		// (get) Token: 0x0600018C RID: 396
		Type Type { get; }

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x0600018D RID: 397
		object Value { get; }
	}
}
