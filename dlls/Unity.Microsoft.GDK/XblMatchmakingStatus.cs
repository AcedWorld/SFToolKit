using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000087 RID: 135
	[MovedFrom("Unity.GameCore")]
	public enum XblMatchmakingStatus : uint
	{
		// Token: 0x0400017B RID: 379
		Unknown,
		// Token: 0x0400017C RID: 380
		None,
		// Token: 0x0400017D RID: 381
		Searching,
		// Token: 0x0400017E RID: 382
		Expired,
		// Token: 0x0400017F RID: 383
		Found,
		// Token: 0x04000180 RID: 384
		Canceled
	}
}
