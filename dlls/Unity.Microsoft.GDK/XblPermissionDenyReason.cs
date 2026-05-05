using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000D9 RID: 217
	[MovedFrom("Unity.GameCore")]
	public enum XblPermissionDenyReason : uint
	{
		// Token: 0x04000357 RID: 855
		Unknown,
		// Token: 0x04000358 RID: 856
		NotAllowed = 2U,
		// Token: 0x04000359 RID: 857
		MissingPrivilege,
		// Token: 0x0400035A RID: 858
		PrivilegeRestrictsTarget,
		// Token: 0x0400035B RID: 859
		BlockListRestrictsTarget,
		// Token: 0x0400035C RID: 860
		MuteListRestrictsTarget = 7U,
		// Token: 0x0400035D RID: 861
		PrivacySettingsRestrictsTarget = 9U
	}
}
