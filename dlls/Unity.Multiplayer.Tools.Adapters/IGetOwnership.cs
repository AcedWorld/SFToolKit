using System;

namespace Unity.Multiplayer.Tools.Adapters
{
	// Token: 0x0200000E RID: 14
	internal interface IGetOwnership : IAdapterComponent
	{
		// Token: 0x06000018 RID: 24
		ClientId GetOwner(ObjectId objectId);
	}
}
