using System;

namespace Unity.Netcode
{
	// Token: 0x020000F2 RID: 242
	public enum SceneEventProgressStatus
	{
		// Token: 0x040002DE RID: 734
		None,
		// Token: 0x040002DF RID: 735
		Started,
		// Token: 0x040002E0 RID: 736
		SceneNotLoaded,
		// Token: 0x040002E1 RID: 737
		SceneEventInProgress,
		// Token: 0x040002E2 RID: 738
		InvalidSceneName,
		// Token: 0x040002E3 RID: 739
		SceneFailedVerification,
		// Token: 0x040002E4 RID: 740
		InternalNetcodeError,
		// Token: 0x040002E5 RID: 741
		SceneManagementNotEnabled,
		// Token: 0x040002E6 RID: 742
		ServerOnlyAction
	}
}
