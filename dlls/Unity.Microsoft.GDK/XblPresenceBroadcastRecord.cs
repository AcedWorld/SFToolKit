using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000CA RID: 202
	[MovedFrom("Unity.GameCore")]
	public class XblPresenceBroadcastRecord
	{
		// Token: 0x060005CA RID: 1482 RVA: 0x0000B758 File Offset: 0x00009958
		internal XblPresenceBroadcastRecord(XblPresenceBroadcastRecord interopRecord)
		{
			this.BroadcastId = interopRecord.broadcastId.GetString();
			this.Session = Converters.ByteArrayToString(interopRecord.session);
			this.Provider = interopRecord.provider;
			this.ViewerCount = interopRecord.viewerCount;
			this.StartTime = interopRecord.startTime.DateTime;
		}

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x060005CB RID: 1483 RVA: 0x0000B7BC File Offset: 0x000099BC
		// (set) Token: 0x060005CC RID: 1484 RVA: 0x0000B7C4 File Offset: 0x000099C4
		public string BroadcastId { get; private set; }

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x060005CD RID: 1485 RVA: 0x0000B7CD File Offset: 0x000099CD
		// (set) Token: 0x060005CE RID: 1486 RVA: 0x0000B7D5 File Offset: 0x000099D5
		public string Session { get; private set; }

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x060005CF RID: 1487 RVA: 0x0000B7DE File Offset: 0x000099DE
		// (set) Token: 0x060005D0 RID: 1488 RVA: 0x0000B7E6 File Offset: 0x000099E6
		public XblPresenceBroadcastProvider Provider { get; private set; }

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x060005D1 RID: 1489 RVA: 0x0000B7EF File Offset: 0x000099EF
		// (set) Token: 0x060005D2 RID: 1490 RVA: 0x0000B7F7 File Offset: 0x000099F7
		public uint ViewerCount { get; private set; }

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x060005D3 RID: 1491 RVA: 0x0000B800 File Offset: 0x00009A00
		// (set) Token: 0x060005D4 RID: 1492 RVA: 0x0000B808 File Offset: 0x00009A08
		public DateTime StartTime { get; private set; }
	}
}
