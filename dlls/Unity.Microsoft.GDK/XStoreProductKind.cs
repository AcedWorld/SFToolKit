using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000172 RID: 370
	[Flags]
	[MovedFrom("Unity.GameCore")]
	public enum XStoreProductKind : uint
	{
		// Token: 0x0400051F RID: 1311
		None = 0U,
		// Token: 0x04000520 RID: 1312
		Consumable = 1U,
		// Token: 0x04000521 RID: 1313
		Durable = 2U,
		// Token: 0x04000522 RID: 1314
		Game = 4U,
		// Token: 0x04000523 RID: 1315
		Pass = 8U,
		// Token: 0x04000524 RID: 1316
		UnmanagedConsumable = 16U
	}
}
