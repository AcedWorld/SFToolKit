using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000FD RID: 253
	[MovedFrom("Unity.GameCore")]
	public class XblTitleHistory
	{
		// Token: 0x060006AF RID: 1711 RVA: 0x0000C398 File Offset: 0x0000A598
		internal XblTitleHistory(XblTitleHistory interopTitleHistory)
		{
			this.HasUserPlayed = interopTitleHistory.hasUserPlayed;
			this.LastTimeUserPlayed = interopTitleHistory.lastTimeUserPlayed.DateTime;
		}

		// Token: 0x170001CD RID: 461
		// (get) Token: 0x060006B0 RID: 1712 RVA: 0x0000C3CB File Offset: 0x0000A5CB
		// (set) Token: 0x060006B1 RID: 1713 RVA: 0x0000C3D3 File Offset: 0x0000A5D3
		public bool HasUserPlayed { get; private set; }

		// Token: 0x170001CE RID: 462
		// (get) Token: 0x060006B2 RID: 1714 RVA: 0x0000C3DC File Offset: 0x0000A5DC
		// (set) Token: 0x060006B3 RID: 1715 RVA: 0x0000C3E4 File Offset: 0x0000A5E4
		public DateTime LastTimeUserPlayed { get; private set; }
	}
}
