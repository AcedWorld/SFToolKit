using System;

namespace Unity.Multiplayer.Tools.Adapters
{
	// Token: 0x0200000F RID: 15
	internal interface IGetPriority : IAdapterComponent
	{
		// Token: 0x06000019 RID: 25
		int GetPriority(ObjectId objectId);
	}
}
