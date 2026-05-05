using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000211 RID: 529
	internal struct XblMultiplayerPeerToHostRequirements
	{
		// Token: 0x06000DC2 RID: 3522 RVA: 0x00010DEE File Offset: 0x0000EFEE
		internal XblMultiplayerPeerToHostRequirements(XblMultiplayerPeerToHostRequirements publicObject)
		{
			this.LatencyMaximum = publicObject.LatencyMaximum;
			this.BandwidthDownMinimumInKbps = publicObject.BandwidthDownMinimumInKbps;
			this.BandwidthUpMinimumInKbps = publicObject.BandwidthUpMinimumInKbps;
			this.HostSelectionMetric = publicObject.HostSelectionMetric;
		}

		// Token: 0x04000743 RID: 1859
		internal readonly ulong LatencyMaximum;

		// Token: 0x04000744 RID: 1860
		internal readonly ulong BandwidthDownMinimumInKbps;

		// Token: 0x04000745 RID: 1861
		internal readonly ulong BandwidthUpMinimumInKbps;

		// Token: 0x04000746 RID: 1862
		internal readonly XblMultiplayerMetrics HostSelectionMetric;
	}
}
