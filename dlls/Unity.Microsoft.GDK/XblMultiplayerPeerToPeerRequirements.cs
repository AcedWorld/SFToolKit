using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000B7 RID: 183
	[MovedFrom("Unity.GameCore")]
	public class XblMultiplayerPeerToPeerRequirements
	{
		// Token: 0x06000587 RID: 1415 RVA: 0x0000B27F File Offset: 0x0000947F
		internal XblMultiplayerPeerToPeerRequirements(XblMultiplayerPeerToPeerRequirements interopStruct)
		{
			this.LatencyMaximum = interopStruct.LatencyMaximum;
			this.BandwidthMinimumInKbps = interopStruct.BandwidthMinimumInKbps;
		}

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x06000588 RID: 1416 RVA: 0x0000B29F File Offset: 0x0000949F
		public ulong LatencyMaximum { get; }

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x06000589 RID: 1417 RVA: 0x0000B2A7 File Offset: 0x000094A7
		public ulong BandwidthMinimumInKbps { get; }
	}
}
