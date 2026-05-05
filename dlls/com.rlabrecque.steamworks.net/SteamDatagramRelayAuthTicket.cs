using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000193 RID: 403
	[Serializable]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SteamDatagramRelayAuthTicket
	{
		// Token: 0x0600098C RID: 2444 RVA: 0x0000EAED File Offset: 0x0000CCED
		public void Clear()
		{
		}

		// Token: 0x04000A52 RID: 2642
		private SteamNetworkingIdentity m_identityGameserver;

		// Token: 0x04000A53 RID: 2643
		private SteamNetworkingIdentity m_identityAuthorizedClient;

		// Token: 0x04000A54 RID: 2644
		private uint m_unPublicIP;

		// Token: 0x04000A55 RID: 2645
		private RTime32 m_rtimeTicketExpiry;

		// Token: 0x04000A56 RID: 2646
		private SteamDatagramHostedAddress m_routing;

		// Token: 0x04000A57 RID: 2647
		private uint m_nAppID;

		// Token: 0x04000A58 RID: 2648
		private int m_nRestrictToVirtualPort;

		// Token: 0x04000A59 RID: 2649
		private const int k_nMaxExtraFields = 16;

		// Token: 0x04000A5A RID: 2650
		private int m_nExtraFields;

		// Token: 0x04000A5B RID: 2651
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		private SteamDatagramRelayAuthTicket.ExtraField[] m_vecExtraFields;

		// Token: 0x020001E9 RID: 489
		[StructLayout(LayoutKind.Sequential, Pack = 8)]
		private struct ExtraField
		{
			// Token: 0x04000ADE RID: 2782
			private SteamDatagramRelayAuthTicket.ExtraField.EType m_eType;

			// Token: 0x04000ADF RID: 2783
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)]
			private byte[] m_szName;

			// Token: 0x04000AE0 RID: 2784
			private SteamDatagramRelayAuthTicket.ExtraField.OptionValue m_val;

			// Token: 0x020001F0 RID: 496
			private enum EType
			{
				// Token: 0x04000AED RID: 2797
				k_EType_String,
				// Token: 0x04000AEE RID: 2798
				k_EType_Int,
				// Token: 0x04000AEF RID: 2799
				k_EType_Fixed64
			}

			// Token: 0x020001F1 RID: 497
			[StructLayout(LayoutKind.Explicit)]
			private struct OptionValue
			{
				// Token: 0x04000AF0 RID: 2800
				[FieldOffset(0)]
				[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
				private byte[] m_szStringValue;

				// Token: 0x04000AF1 RID: 2801
				[FieldOffset(0)]
				private long m_nIntValue;

				// Token: 0x04000AF2 RID: 2802
				[FieldOffset(0)]
				private ulong m_nFixed64Value;
			}
		}
	}
}
