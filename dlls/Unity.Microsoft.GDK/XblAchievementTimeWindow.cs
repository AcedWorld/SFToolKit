using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200006E RID: 110
	[MovedFrom("Unity.GameCore")]
	public class XblAchievementTimeWindow
	{
		// Token: 0x06000445 RID: 1093 RVA: 0x00009B68 File Offset: 0x00007D68
		internal XblAchievementTimeWindow(XblAchievementTimeWindow interopTimeWindow)
		{
			this.StartDate = interopTimeWindow.startDate.DateTime;
			this.EndDate = interopTimeWindow.endDate.DateTime;
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x06000446 RID: 1094 RVA: 0x00009BA3 File Offset: 0x00007DA3
		// (set) Token: 0x06000447 RID: 1095 RVA: 0x00009BAB File Offset: 0x00007DAB
		public DateTime StartDate { get; private set; }

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x06000448 RID: 1096 RVA: 0x00009BB4 File Offset: 0x00007DB4
		// (set) Token: 0x06000449 RID: 1097 RVA: 0x00009BBC File Offset: 0x00007DBC
		public DateTime EndDate { get; private set; }
	}
}
