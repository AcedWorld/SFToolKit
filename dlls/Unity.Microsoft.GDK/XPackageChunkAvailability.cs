using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000158 RID: 344
	[MovedFrom("Unity.GameCore")]
	public enum XPackageChunkAvailability : uint
	{
		// Token: 0x040004FD RID: 1277
		Ready,
		// Token: 0x040004FE RID: 1278
		Pending,
		// Token: 0x040004FF RID: 1279
		Installable,
		// Token: 0x04000500 RID: 1280
		Unavailable
	}
}
