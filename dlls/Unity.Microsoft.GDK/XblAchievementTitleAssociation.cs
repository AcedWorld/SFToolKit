using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200006F RID: 111
	[MovedFrom("Unity.GameCore")]
	public class XblAchievementTitleAssociation
	{
		// Token: 0x0600044A RID: 1098 RVA: 0x00009BC8 File Offset: 0x00007DC8
		internal XblAchievementTitleAssociation(XblAchievementTitleAssociation interopTitleAssociation)
		{
			this.Name = interopTitleAssociation.name.GetString();
			this.TitleId = interopTitleAssociation.titleId;
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x0600044B RID: 1099 RVA: 0x00009BFB File Offset: 0x00007DFB
		// (set) Token: 0x0600044C RID: 1100 RVA: 0x00009C03 File Offset: 0x00007E03
		public string Name { get; private set; }

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x0600044D RID: 1101 RVA: 0x00009C0C File Offset: 0x00007E0C
		// (set) Token: 0x0600044E RID: 1102 RVA: 0x00009C14 File Offset: 0x00007E14
		public uint TitleId { get; private set; }
	}
}
