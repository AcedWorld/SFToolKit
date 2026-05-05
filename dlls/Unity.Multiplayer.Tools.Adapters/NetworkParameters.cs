using System;

namespace Unity.Multiplayer.Tools.Adapters
{
	// Token: 0x02000004 RID: 4
	internal class NetworkParameters
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000005 RID: 5 RVA: 0x000020C0 File Offset: 0x000002C0
		// (set) Token: 0x06000006 RID: 6 RVA: 0x000020C8 File Offset: 0x000002C8
		public int PacketDelayMilliseconds { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000007 RID: 7 RVA: 0x000020D1 File Offset: 0x000002D1
		// (set) Token: 0x06000008 RID: 8 RVA: 0x000020D9 File Offset: 0x000002D9
		public int PacketDelayRangeMilliseconds { get; set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000009 RID: 9 RVA: 0x000020E2 File Offset: 0x000002E2
		// (set) Token: 0x0600000A RID: 10 RVA: 0x000020EA File Offset: 0x000002EA
		public int PacketLossIntervalMilliseconds { get; set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000B RID: 11 RVA: 0x000020F3 File Offset: 0x000002F3
		// (set) Token: 0x0600000C RID: 12 RVA: 0x000020FB File Offset: 0x000002FB
		public int PacketLossPercent { get; set; }
	}
}
