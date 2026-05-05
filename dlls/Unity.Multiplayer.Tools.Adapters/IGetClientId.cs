using System;

namespace Unity.Multiplayer.Tools.Adapters
{
	// Token: 0x0200000A RID: 10
	internal interface IGetClientId : IAdapterComponent
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000013 RID: 19
		ClientId LocalClientId { get; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000014 RID: 20
		ClientId ServerClientId { get; }
	}
}
