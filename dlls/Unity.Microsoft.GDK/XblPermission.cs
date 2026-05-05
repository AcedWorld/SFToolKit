using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000D7 RID: 215
	[MovedFrom("Unity.GameCore")]
	public enum XblPermission : uint
	{
		// Token: 0x0400033F RID: 831
		Unknown,
		// Token: 0x04000340 RID: 832
		CommunicateUsingText = 1000U,
		// Token: 0x04000341 RID: 833
		CommunicateUsingVideo,
		// Token: 0x04000342 RID: 834
		CommunicateUsingVoice,
		// Token: 0x04000343 RID: 835
		ViewTargetProfile = 1004U,
		// Token: 0x04000344 RID: 836
		ViewTargetGameHistory,
		// Token: 0x04000345 RID: 837
		ViewTargetVideoHistory,
		// Token: 0x04000346 RID: 838
		ViewTargetMusicHistory,
		// Token: 0x04000347 RID: 839
		ViewTargetExerciseInfo = 1009U,
		// Token: 0x04000348 RID: 840
		ViewTargetPresence = 1011U,
		// Token: 0x04000349 RID: 841
		ViewTargetVideoStatus,
		// Token: 0x0400034A RID: 842
		ViewTargetMusicStatus,
		// Token: 0x0400034B RID: 843
		PlayMultiplayer,
		// Token: 0x0400034C RID: 844
		ViewTargetUserCreatedContent = 1018U,
		// Token: 0x0400034D RID: 845
		BroadcastWithTwitch,
		// Token: 0x0400034E RID: 846
		WriteComment = 1022U,
		// Token: 0x0400034F RID: 847
		ShareItem = 1024U,
		// Token: 0x04000350 RID: 848
		ShareTargetContentToExternalNetworks
	}
}
