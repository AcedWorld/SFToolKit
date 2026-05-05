using System;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x0200001E RID: 30
	[AttributeUsage(AttributeTargets.Field)]
	public class MetricMetadataAttribute : Attribute
	{
		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600007C RID: 124 RVA: 0x00002E27 File Offset: 0x00001027
		// (set) Token: 0x0600007D RID: 125 RVA: 0x00002E2F File Offset: 0x0000102F
		public string DisplayName { get; set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600007E RID: 126 RVA: 0x00002E38 File Offset: 0x00001038
		// (set) Token: 0x0600007F RID: 127 RVA: 0x00002E40 File Offset: 0x00001040
		public MetricKind MetricKind { get; set; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000080 RID: 128 RVA: 0x00002E49 File Offset: 0x00001049
		// (set) Token: 0x06000081 RID: 129 RVA: 0x00002E51 File Offset: 0x00001051
		public Units Units { get; set; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000082 RID: 130 RVA: 0x00002E5A File Offset: 0x0000105A
		// (set) Token: 0x06000083 RID: 131 RVA: 0x00002E62 File Offset: 0x00001062
		public bool DisplayAsPercentage { get; set; }
	}
}
