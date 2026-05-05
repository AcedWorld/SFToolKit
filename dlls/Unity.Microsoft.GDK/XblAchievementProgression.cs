using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000068 RID: 104
	[MovedFrom("Unity.GameCore")]
	public class XblAchievementProgression
	{
		// Token: 0x06000429 RID: 1065 RVA: 0x0000992C File Offset: 0x00007B2C
		internal XblAchievementProgression(XblAchievementProgression interopProgression)
		{
			this.Requirements = interopProgression.GetRequirements<XblAchievementRequirement>((XblAchievementRequirement r) => new XblAchievementRequirement(r));
			this.TimeUnlocked = interopProgression.timeUnlocked.DateTime;
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x0600042A RID: 1066 RVA: 0x0000997F File Offset: 0x00007B7F
		// (set) Token: 0x0600042B RID: 1067 RVA: 0x00009987 File Offset: 0x00007B87
		public XblAchievementRequirement[] Requirements { get; private set; }

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x0600042C RID: 1068 RVA: 0x00009990 File Offset: 0x00007B90
		// (set) Token: 0x0600042D RID: 1069 RVA: 0x00009998 File Offset: 0x00007B98
		public DateTime TimeUnlocked { get; private set; }
	}
}
