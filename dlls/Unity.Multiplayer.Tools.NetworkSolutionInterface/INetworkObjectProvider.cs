using System;
using UnityEngine;

namespace Unity.Multiplayer.Tools
{
	// Token: 0x02000003 RID: 3
	internal interface INetworkObjectProvider
	{
		// Token: 0x06000003 RID: 3
		Object GetNetworkObject(ulong networkObjectId);
	}
}
