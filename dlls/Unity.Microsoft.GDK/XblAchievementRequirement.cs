using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200006A RID: 106
	[MovedFrom("Unity.GameCore")]
	public class XblAchievementRequirement
	{
		// Token: 0x0600042E RID: 1070 RVA: 0x000099A4 File Offset: 0x00007BA4
		internal XblAchievementRequirement(XblAchievementRequirement interopRequirement)
		{
			this.Id = interopRequirement.id.GetString();
			this.CurrentProgressValue = interopRequirement.currentProgressValue.GetString();
			this.TargetProgressValue = interopRequirement.targetProgressValue.GetString();
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x0600042F RID: 1071 RVA: 0x000099F3 File Offset: 0x00007BF3
		// (set) Token: 0x06000430 RID: 1072 RVA: 0x000099FB File Offset: 0x00007BFB
		public string Id { get; private set; }

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x06000431 RID: 1073 RVA: 0x00009A04 File Offset: 0x00007C04
		// (set) Token: 0x06000432 RID: 1074 RVA: 0x00009A0C File Offset: 0x00007C0C
		public string CurrentProgressValue { get; private set; }

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x06000433 RID: 1075 RVA: 0x00009A15 File Offset: 0x00007C15
		// (set) Token: 0x06000434 RID: 1076 RVA: 0x00009A1D File Offset: 0x00007C1D
		public string TargetProgressValue { get; private set; }
	}
}
