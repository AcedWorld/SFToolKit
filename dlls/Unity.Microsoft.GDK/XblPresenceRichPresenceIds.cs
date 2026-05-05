using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000D1 RID: 209
	[MovedFrom("Unity.GameCore")]
	public class XblPresenceRichPresenceIds
	{
		// Token: 0x060005EA RID: 1514 RVA: 0x0000B95D File Offset: 0x00009B5D
		private XblPresenceRichPresenceIds(string serviceConfigurationId, string presenceId, string[] presenceTokenIds)
		{
			this.ServiceConfigurationId = serviceConfigurationId;
			this.PresenceId = presenceId;
			this.PresenceTokenIds = presenceTokenIds;
		}

		// Token: 0x060005EB RID: 1515 RVA: 0x0000B97A File Offset: 0x00009B7A
		public static int Create(string serviceConfigurationId, string presenceId, string[] presenceTokenIds, out XblPresenceRichPresenceIds richPresenceIds)
		{
			if (!XblPresenceRichPresenceIdsRef.ValidateFields(serviceConfigurationId))
			{
				richPresenceIds = null;
				return -2147024809;
			}
			richPresenceIds = new XblPresenceRichPresenceIds(serviceConfigurationId, presenceId, presenceTokenIds);
			return 0;
		}

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x060005EC RID: 1516 RVA: 0x0000B998 File Offset: 0x00009B98
		// (set) Token: 0x060005ED RID: 1517 RVA: 0x0000B9A0 File Offset: 0x00009BA0
		public string ServiceConfigurationId { get; private set; }

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x060005EE RID: 1518 RVA: 0x0000B9A9 File Offset: 0x00009BA9
		// (set) Token: 0x060005EF RID: 1519 RVA: 0x0000B9B1 File Offset: 0x00009BB1
		public string PresenceId { get; private set; }

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x060005F0 RID: 1520 RVA: 0x0000B9BA File Offset: 0x00009BBA
		// (set) Token: 0x060005F1 RID: 1521 RVA: 0x0000B9C2 File Offset: 0x00009BC2
		public string[] PresenceTokenIds { get; private set; }
	}
}
