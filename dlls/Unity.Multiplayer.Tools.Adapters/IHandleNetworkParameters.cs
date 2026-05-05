using System;

namespace Unity.Multiplayer.Tools.Adapters
{
	// Token: 0x02000003 RID: 3
	internal interface IHandleNetworkParameters : IAdapterComponent
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000003 RID: 3
		// (set) Token: 0x06000004 RID: 4
		NetworkParameters NetworkParameters { get; set; }
	}
}
