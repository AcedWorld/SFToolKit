using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000215 RID: 533
	internal struct XblMultiplayerSessionConstants
	{
		// Token: 0x06000DC7 RID: 3527 RVA: 0x00010F5C File Offset: 0x0000F15C
		internal unsafe T[] GetInitiatorXuids<T>(Func<ulong, T> ctor)
		{
			return Converters.PtrToClassArray<T, ulong>((IntPtr)((void*)this.InitiatorXuids), this.InitiatorXuidsCount, ctor);
		}

		// Token: 0x06000DC8 RID: 3528 RVA: 0x00010F75 File Offset: 0x0000F175
		internal unsafe T GetMemberInitialization<T>(Func<XblMultiplayerMemberInitialization, T> ctor) where T : class
		{
			return Converters.PtrToClass<T, XblMultiplayerMemberInitialization>((IntPtr)((void*)this.MemberInitialization), ctor);
		}

		// Token: 0x04000756 RID: 1878
		internal readonly uint MaxMembersInSession;

		// Token: 0x04000757 RID: 1879
		internal readonly XblMultiplayerSessionVisibility Visibility;

		// Token: 0x04000758 RID: 1880
		private unsafe readonly ulong* InitiatorXuids;

		// Token: 0x04000759 RID: 1881
		internal readonly SizeT InitiatorXuidsCount;

		// Token: 0x0400075A RID: 1882
		internal readonly UTF8StringPtr CustomJson;

		// Token: 0x0400075B RID: 1883
		internal readonly UTF8StringPtr SessionCloudComputePackageConstantsJson;

		// Token: 0x0400075C RID: 1884
		internal readonly ulong MemberReservedTimeout;

		// Token: 0x0400075D RID: 1885
		internal readonly ulong MemberInactiveTimeout;

		// Token: 0x0400075E RID: 1886
		internal readonly ulong MemberReadyTimeout;

		// Token: 0x0400075F RID: 1887
		internal readonly ulong SessionEmptyTimeout;

		// Token: 0x04000760 RID: 1888
		internal readonly ulong ArbitrationTimeout;

		// Token: 0x04000761 RID: 1889
		internal readonly ulong ForfeitTimeout;

		// Token: 0x04000762 RID: 1890
		internal readonly NativeBool EnableMetricsLatency;

		// Token: 0x04000763 RID: 1891
		internal readonly NativeBool EnableMetricsBandwidthDown;

		// Token: 0x04000764 RID: 1892
		internal readonly NativeBool EnableMetricsBandwidthUp;

		// Token: 0x04000765 RID: 1893
		internal readonly NativeBool EnableMetricsCustom;

		// Token: 0x04000766 RID: 1894
		private unsafe readonly XblMultiplayerMemberInitialization* MemberInitialization;

		// Token: 0x04000767 RID: 1895
		internal readonly XblMultiplayerPeerToPeerRequirements PeerToPeerRequirements;

		// Token: 0x04000768 RID: 1896
		internal readonly XblMultiplayerPeerToHostRequirements PeerToHostRequirements;

		// Token: 0x04000769 RID: 1897
		internal readonly UTF8StringPtr MeasurementServerAddressesJson;

		// Token: 0x0400076A RID: 1898
		internal readonly NativeBool ClientMatchmakingCapable;

		// Token: 0x0400076B RID: 1899
		internal readonly XblMultiplayerSessionCapabilities SessionCapabilities;
	}
}
