using System;
using UnityEngine.Playables;
using UnityEngine.VFX.Utility;

namespace UnityEngine.VFX
{
	// Token: 0x0200001B RID: 27
	internal class VisualEffectControlPlayableBehaviour : PlayableBehaviour
	{
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600003F RID: 63 RVA: 0x00002DDA File Offset: 0x00000FDA
		// (set) Token: 0x06000040 RID: 64 RVA: 0x00002DE2 File Offset: 0x00000FE2
		public double clipStart { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000041 RID: 65 RVA: 0x00002DEB File Offset: 0x00000FEB
		// (set) Token: 0x06000042 RID: 66 RVA: 0x00002DF3 File Offset: 0x00000FF3
		public double clipEnd { get; set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000043 RID: 67 RVA: 0x00002DFC File Offset: 0x00000FFC
		// (set) Token: 0x06000044 RID: 68 RVA: 0x00002E04 File Offset: 0x00001004
		public bool scrubbing { get; set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000045 RID: 69 RVA: 0x00002E0D File Offset: 0x0000100D
		// (set) Token: 0x06000046 RID: 70 RVA: 0x00002E15 File Offset: 0x00001015
		public bool reinitEnter { get; set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000047 RID: 71 RVA: 0x00002E1E File Offset: 0x0000101E
		// (set) Token: 0x06000048 RID: 72 RVA: 0x00002E26 File Offset: 0x00001026
		public bool reinitExit { get; set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000049 RID: 73 RVA: 0x00002E2F File Offset: 0x0000102F
		// (set) Token: 0x0600004A RID: 74 RVA: 0x00002E37 File Offset: 0x00001037
		public uint startSeed { get; set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600004B RID: 75 RVA: 0x00002E40 File Offset: 0x00001040
		// (set) Token: 0x0600004C RID: 76 RVA: 0x00002E48 File Offset: 0x00001048
		public VisualEffectPlayableSerializedEvent[] events { get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600004D RID: 77 RVA: 0x00002E51 File Offset: 0x00001051
		// (set) Token: 0x0600004E RID: 78 RVA: 0x00002E59 File Offset: 0x00001059
		public uint clipEventsCount { get; set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600004F RID: 79 RVA: 0x00002E62 File Offset: 0x00001062
		// (set) Token: 0x06000050 RID: 80 RVA: 0x00002E6A File Offset: 0x0000106A
		public uint prewarmStepCount { get; set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000051 RID: 81 RVA: 0x00002E73 File Offset: 0x00001073
		// (set) Token: 0x06000052 RID: 82 RVA: 0x00002E7B File Offset: 0x0000107B
		public float prewarmDeltaTime { get; set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000053 RID: 83 RVA: 0x00002E84 File Offset: 0x00001084
		// (set) Token: 0x06000054 RID: 84 RVA: 0x00002E8C File Offset: 0x0000108C
		public ExposedProperty prewarmEvent { get; set; }
	}
}
