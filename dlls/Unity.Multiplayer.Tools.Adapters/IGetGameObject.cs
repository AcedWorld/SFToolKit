using System;
using UnityEngine;

namespace Unity.Multiplayer.Tools.Adapters
{
	// Token: 0x0200000B RID: 11
	internal interface IGetGameObject : IAdapterComponent
	{
		// Token: 0x06000015 RID: 21
		GameObject GetGameObject(ObjectId objectId);
	}
}
