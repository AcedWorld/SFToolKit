using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000071 RID: 113
	[MovedFrom("Unity.GameCore")]
	public class XblAchievementsManagerEvent
	{
		// Token: 0x0600044F RID: 1103 RVA: 0x00009C1D File Offset: 0x00007E1D
		internal XblAchievementsManagerEvent(XblAchievementsManagerEvent interopStruct)
		{
			this.progressInfo = new XblAchievementProgressChangeEntry(interopStruct.progressInfo);
			this.xboxUserId = interopStruct.xboxUserId;
			this.eventType = interopStruct.eventType;
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000450 RID: 1104 RVA: 0x00009C4E File Offset: 0x00007E4E
		public XblAchievementProgressChangeEntry progressInfo { get; }

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000451 RID: 1105 RVA: 0x00009C56 File Offset: 0x00007E56
		public ulong xboxUserId { get; }

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x06000452 RID: 1106 RVA: 0x00009C5E File Offset: 0x00007E5E
		public XblAchievementsManagerEventType eventType { get; }
	}
}
