using System;
using JetBrains.Annotations;

namespace Unity.Multiplayer.Tools.Adapters
{
	// Token: 0x02000018 RID: 24
	internal interface INetworkAdapter
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600001C RID: 28
		AdapterMetadata Metadata { get; }

		// Token: 0x0600001D RID: 29
		[CanBeNull]
		T GetComponent<T>() where T : class, IAdapterComponent;
	}
}
