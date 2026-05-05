using System;
using System.Collections.Generic;

namespace Unity.Multiplayer.Tools.Adapters
{
	// Token: 0x0200000D RID: 13
	internal interface IGetObjectIds : IAdapterComponent
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000017 RID: 23
		IEnumerable<ObjectId> ObjectIds { get; }
	}
}
