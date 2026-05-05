using System;

namespace Unity.Multiplayer.Tools.Adapters
{
	// Token: 0x02000010 RID: 16
	internal interface IGetRpcCount : IAdapterComponent
	{
		// Token: 0x0600001A RID: 26
		int GetRpcCount(ObjectId objectId);
	}
}
