using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000E0 RID: 224
	[MovedFrom("Unity.GameCore")]
	public enum XblPrivilege : uint
	{
		// Token: 0x04000381 RID: 897
		Unknown,
		// Token: 0x04000382 RID: 898
		AllowIngameVoiceCommunications = 205U,
		// Token: 0x04000383 RID: 899
		AllowVideoCommunications = 235U,
		// Token: 0x04000384 RID: 900
		AllowProfileViewing = 249U,
		// Token: 0x04000385 RID: 901
		AllowCommunications = 252U,
		// Token: 0x04000386 RID: 902
		AllowMultiplayer = 254U,
		// Token: 0x04000387 RID: 903
		AllowAddFriend
	}
}
