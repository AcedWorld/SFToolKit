using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000018 RID: 24
	public static class SteamParties
	{
		// Token: 0x060002DD RID: 733 RVA: 0x00008451 File Offset: 0x00006651
		public static uint GetNumActiveBeacons()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamParties_GetNumActiveBeacons(CSteamAPIContext.GetSteamParties());
		}

		// Token: 0x060002DE RID: 734 RVA: 0x00008462 File Offset: 0x00006662
		public static PartyBeaconID_t GetBeaconByIndex(uint unIndex)
		{
			InteropHelp.TestIfAvailableClient();
			return (PartyBeaconID_t)NativeMethods.ISteamParties_GetBeaconByIndex(CSteamAPIContext.GetSteamParties(), unIndex);
		}

		// Token: 0x060002DF RID: 735 RVA: 0x0000847C File Offset: 0x0000667C
		public static bool GetBeaconDetails(PartyBeaconID_t ulBeaconID, out CSteamID pSteamIDBeaconOwner, out SteamPartyBeaconLocation_t pLocation, out string pchMetadata, int cchMetadata)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal(cchMetadata);
			bool flag = NativeMethods.ISteamParties_GetBeaconDetails(CSteamAPIContext.GetSteamParties(), ulBeaconID, out pSteamIDBeaconOwner, out pLocation, intPtr, cchMetadata);
			pchMetadata = (flag ? InteropHelp.PtrToStringUTF8(intPtr) : null);
			Marshal.FreeHGlobal(intPtr);
			return flag;
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x000084BC File Offset: 0x000066BC
		public static SteamAPICall_t JoinParty(PartyBeaconID_t ulBeaconID)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamParties_JoinParty(CSteamAPIContext.GetSteamParties(), ulBeaconID);
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x000084D3 File Offset: 0x000066D3
		public static bool GetNumAvailableBeaconLocations(out uint puNumLocations)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamParties_GetNumAvailableBeaconLocations(CSteamAPIContext.GetSteamParties(), out puNumLocations);
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x000084E5 File Offset: 0x000066E5
		public static bool GetAvailableBeaconLocations(SteamPartyBeaconLocation_t[] pLocationList, uint uMaxNumLocations)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamParties_GetAvailableBeaconLocations(CSteamAPIContext.GetSteamParties(), pLocationList, uMaxNumLocations);
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x000084F8 File Offset: 0x000066F8
		public static SteamAPICall_t CreateBeacon(uint unOpenSlots, ref SteamPartyBeaconLocation_t pBeaconLocation, string pchConnectString, string pchMetadata)
		{
			InteropHelp.TestIfAvailableClient();
			SteamAPICall_t result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchConnectString))
			{
				using (InteropHelp.UTF8StringHandle utf8StringHandle2 = new InteropHelp.UTF8StringHandle(pchMetadata))
				{
					result = (SteamAPICall_t)NativeMethods.ISteamParties_CreateBeacon(CSteamAPIContext.GetSteamParties(), unOpenSlots, ref pBeaconLocation, utf8StringHandle, utf8StringHandle2);
				}
			}
			return result;
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x00008560 File Offset: 0x00006760
		public static void OnReservationCompleted(PartyBeaconID_t ulBeacon, CSteamID steamIDUser)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamParties_OnReservationCompleted(CSteamAPIContext.GetSteamParties(), ulBeacon, steamIDUser);
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x00008573 File Offset: 0x00006773
		public static void CancelReservation(PartyBeaconID_t ulBeacon, CSteamID steamIDUser)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamParties_CancelReservation(CSteamAPIContext.GetSteamParties(), ulBeacon, steamIDUser);
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x00008586 File Offset: 0x00006786
		public static SteamAPICall_t ChangeNumOpenSlots(PartyBeaconID_t ulBeacon, uint unOpenSlots)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamParties_ChangeNumOpenSlots(CSteamAPIContext.GetSteamParties(), ulBeacon, unOpenSlots);
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x0000859E File Offset: 0x0000679E
		public static bool DestroyBeacon(PartyBeaconID_t ulBeacon)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamParties_DestroyBeacon(CSteamAPIContext.GetSteamParties(), ulBeacon);
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x000085B0 File Offset: 0x000067B0
		public static bool GetBeaconLocationData(SteamPartyBeaconLocation_t BeaconLocation, ESteamPartyBeaconLocationData eData, out string pchDataStringOut, int cchDataStringOut)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal(cchDataStringOut);
			bool flag = NativeMethods.ISteamParties_GetBeaconLocationData(CSteamAPIContext.GetSteamParties(), BeaconLocation, eData, intPtr, cchDataStringOut);
			pchDataStringOut = (flag ? InteropHelp.PtrToStringUTF8(intPtr) : null);
			Marshal.FreeHGlobal(intPtr);
			return flag;
		}
	}
}
