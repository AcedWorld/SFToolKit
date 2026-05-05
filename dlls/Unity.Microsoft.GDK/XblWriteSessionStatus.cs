using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000A4 RID: 164
	[MovedFrom("Unity.GameCore")]
	public enum XblWriteSessionStatus
	{
		// Token: 0x04000223 RID: 547
		Unknown,
		// Token: 0x04000224 RID: 548
		AccessDenied,
		// Token: 0x04000225 RID: 549
		Created,
		// Token: 0x04000226 RID: 550
		Conflict,
		// Token: 0x04000227 RID: 551
		HandleNotFound,
		// Token: 0x04000228 RID: 552
		OutOfSync,
		// Token: 0x04000229 RID: 553
		SessionDeleted,
		// Token: 0x0400022A RID: 554
		Updated
	}
}
