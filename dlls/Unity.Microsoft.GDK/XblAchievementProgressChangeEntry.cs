using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000066 RID: 102
	[MovedFrom("Unity.GameCore")]
	public class XblAchievementProgressChangeEntry
	{
		// Token: 0x06000420 RID: 1056 RVA: 0x00009862 File Offset: 0x00007A62
		internal XblAchievementProgressChangeEntry(XblAchievementProgressChangeEntry interopStruct)
		{
			this.AchievementId = interopStruct.achievementId.GetString();
			this.ProgressState = interopStruct.progressState;
			this.Progression = new XblAchievementProgression(interopStruct.progression);
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000421 RID: 1057 RVA: 0x00009899 File Offset: 0x00007A99
		public string AchievementId { get; }

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x06000422 RID: 1058 RVA: 0x000098A1 File Offset: 0x00007AA1
		public XblAchievementProgressState ProgressState { get; }

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000423 RID: 1059 RVA: 0x000098A9 File Offset: 0x00007AA9
		public XblAchievementProgression Progression { get; }
	}
}
