using System;
using UnityEngine;

namespace Unity.Multiplayer.Tools
{
	// Token: 0x02000006 RID: 6
	internal class NullNetworkObjectProvider : INetworkObjectProvider
	{
		// Token: 0x06000006 RID: 6 RVA: 0x000020F2 File Offset: 0x000002F2
		Object INetworkObjectProvider.GetNetworkObject(ulong networkObjectId)
		{
			return null;
		}
	}
}
