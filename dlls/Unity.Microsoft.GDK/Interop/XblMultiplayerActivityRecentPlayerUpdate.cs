using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000209 RID: 521
	internal struct XblMultiplayerActivityRecentPlayerUpdate
	{
		// Token: 0x06000DBA RID: 3514 RVA: 0x00010BE7 File Offset: 0x0000EDE7
		internal XblMultiplayerActivityRecentPlayerUpdate(XblMultiplayerActivityRecentPlayerUpdate publicObject)
		{
			this.xuid = publicObject.Xuid;
			this.encounterType = publicObject.EncounterType;
		}

		// Token: 0x04000725 RID: 1829
		internal readonly ulong xuid;

		// Token: 0x04000726 RID: 1830
		internal readonly XblMultiplayerActivityEncounterType encounterType;
	}
}
