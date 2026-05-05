using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000212 RID: 530
	internal struct XblMultiplayerPeerToPeerRequirements
	{
		// Token: 0x06000DC3 RID: 3523 RVA: 0x00010E20 File Offset: 0x0000F020
		internal XblMultiplayerPeerToPeerRequirements(XblMultiplayerPeerToPeerRequirements publicObject)
		{
			this.LatencyMaximum = publicObject.LatencyMaximum;
			this.BandwidthMinimumInKbps = publicObject.BandwidthMinimumInKbps;
		}

		// Token: 0x04000747 RID: 1863
		internal readonly ulong LatencyMaximum;

		// Token: 0x04000748 RID: 1864
		internal readonly ulong BandwidthMinimumInKbps;
	}
}
