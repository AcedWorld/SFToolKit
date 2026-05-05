using System;

namespace Unity.Services.Relay.Models
{
	// Token: 0x0200002C RID: 44
	public interface IOneOf
	{
		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000B3 RID: 179
		Type Type { get; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000B4 RID: 180
		object Value { get; }
	}
}
