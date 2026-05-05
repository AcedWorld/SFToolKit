using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200008D RID: 141
	[MovedFrom("Unity.GameCore")]
	public enum XblMultiplayerInitializationStage : uint
	{
		// Token: 0x0400019E RID: 414
		Unknown,
		// Token: 0x0400019F RID: 415
		None,
		// Token: 0x040001A0 RID: 416
		Joining,
		// Token: 0x040001A1 RID: 417
		Measuring,
		// Token: 0x040001A2 RID: 418
		Evaluating,
		// Token: 0x040001A3 RID: 419
		Failed
	}
}
