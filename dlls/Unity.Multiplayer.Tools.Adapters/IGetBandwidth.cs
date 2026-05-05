using System;

namespace Unity.Multiplayer.Tools.Adapters
{
	// Token: 0x02000009 RID: 9
	internal interface IGetBandwidth : IAdapterComponent
	{
		// Token: 0x06000012 RID: 18
		int GetBandwidthBytes(ObjectId objectId);
	}
}
