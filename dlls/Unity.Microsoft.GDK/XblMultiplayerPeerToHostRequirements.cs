using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000B6 RID: 182
	[MovedFrom("Unity.GameCore")]
	public class XblMultiplayerPeerToHostRequirements
	{
		// Token: 0x06000582 RID: 1410 RVA: 0x0000B227 File Offset: 0x00009427
		internal XblMultiplayerPeerToHostRequirements(XblMultiplayerPeerToHostRequirements interopStruct)
		{
			this.LatencyMaximum = interopStruct.LatencyMaximum;
			this.BandwidthDownMinimumInKbps = interopStruct.BandwidthDownMinimumInKbps;
			this.BandwidthUpMinimumInKbps = interopStruct.BandwidthUpMinimumInKbps;
			this.HostSelectionMetric = interopStruct.HostSelectionMetric;
		}

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x06000583 RID: 1411 RVA: 0x0000B25F File Offset: 0x0000945F
		public ulong LatencyMaximum { get; }

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x06000584 RID: 1412 RVA: 0x0000B267 File Offset: 0x00009467
		public ulong BandwidthDownMinimumInKbps { get; }

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x06000585 RID: 1413 RVA: 0x0000B26F File Offset: 0x0000946F
		public ulong BandwidthUpMinimumInKbps { get; }

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x06000586 RID: 1414 RVA: 0x0000B277 File Offset: 0x00009477
		public XblMultiplayerMetrics HostSelectionMetric { get; }
	}
}
