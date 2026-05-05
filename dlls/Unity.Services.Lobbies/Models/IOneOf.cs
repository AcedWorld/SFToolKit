using System;

namespace Unity.Services.Lobbies.Models
{
	// Token: 0x02000036 RID: 54
	public interface IOneOf
	{
		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000180 RID: 384
		Type Type { get; }

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000181 RID: 385
		object Value { get; }
	}
}
