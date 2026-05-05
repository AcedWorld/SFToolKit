using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200000D RID: 13
	public static class SteamGameServerNetworkingUtils
	{
		// Token: 0x06000166 RID: 358 RVA: 0x0000520E File Offset: 0x0000340E
		public static IntPtr AllocateMessage(int cbAllocateBuffer)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworkingUtils_AllocateMessage(CSteamGameServerAPIContext.GetSteamNetworkingUtils(), cbAllocateBuffer);
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00005220 File Offset: 0x00003420
		public static void InitRelayNetworkAccess()
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamNetworkingUtils_InitRelayNetworkAccess(CSteamGameServerAPIContext.GetSteamNetworkingUtils());
		}

		// Token: 0x06000168 RID: 360 RVA: 0x00005231 File Offset: 0x00003431
		public static ESteamNetworkingAvailability GetRelayNetworkStatus(out SteamRelayNetworkStatus_t pDetails)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworkingUtils_GetRelayNetworkStatus(CSteamGameServerAPIContext.GetSteamNetworkingUtils(), out pDetails);
		}

		// Token: 0x06000169 RID: 361 RVA: 0x00005243 File Offset: 0x00003443
		public static float GetLocalPingLocation(out SteamNetworkPingLocation_t result)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworkingUtils_GetLocalPingLocation(CSteamGameServerAPIContext.GetSteamNetworkingUtils(), out result);
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00005255 File Offset: 0x00003455
		public static int EstimatePingTimeBetweenTwoLocations(ref SteamNetworkPingLocation_t location1, ref SteamNetworkPingLocation_t location2)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworkingUtils_EstimatePingTimeBetweenTwoLocations(CSteamGameServerAPIContext.GetSteamNetworkingUtils(), ref location1, ref location2);
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00005268 File Offset: 0x00003468
		public static int EstimatePingTimeFromLocalHost(ref SteamNetworkPingLocation_t remoteLocation)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworkingUtils_EstimatePingTimeFromLocalHost(CSteamGameServerAPIContext.GetSteamNetworkingUtils(), ref remoteLocation);
		}

		// Token: 0x0600016C RID: 364 RVA: 0x0000527C File Offset: 0x0000347C
		public static void ConvertPingLocationToString(ref SteamNetworkPingLocation_t location, out string pszBuf, int cchBufSize)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr intPtr = Marshal.AllocHGlobal(cchBufSize);
			NativeMethods.ISteamNetworkingUtils_ConvertPingLocationToString(CSteamGameServerAPIContext.GetSteamNetworkingUtils(), ref location, intPtr, cchBufSize);
			pszBuf = InteropHelp.PtrToStringUTF8(intPtr);
			Marshal.FreeHGlobal(intPtr);
		}

		// Token: 0x0600016D RID: 365 RVA: 0x000052B0 File Offset: 0x000034B0
		public static bool ParsePingLocationString(string pszString, out SteamNetworkPingLocation_t result)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result2;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pszString))
			{
				result2 = NativeMethods.ISteamNetworkingUtils_ParsePingLocationString(CSteamGameServerAPIContext.GetSteamNetworkingUtils(), utf8StringHandle, out result);
			}
			return result2;
		}

		// Token: 0x0600016E RID: 366 RVA: 0x000052F4 File Offset: 0x000034F4
		public static bool CheckPingDataUpToDate(float flMaxAgeSeconds)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworkingUtils_CheckPingDataUpToDate(CSteamGameServerAPIContext.GetSteamNetworkingUtils(), flMaxAgeSeconds);
		}

		// Token: 0x0600016F RID: 367 RVA: 0x00005306 File Offset: 0x00003506
		public static int GetPingToDataCenter(SteamNetworkingPOPID popID, out SteamNetworkingPOPID pViaRelayPoP)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworkingUtils_GetPingToDataCenter(CSteamGameServerAPIContext.GetSteamNetworkingUtils(), popID, out pViaRelayPoP);
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00005319 File Offset: 0x00003519
		public static int GetDirectPingToPOP(SteamNetworkingPOPID popID)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworkingUtils_GetDirectPingToPOP(CSteamGameServerAPIContext.GetSteamNetworkingUtils(), popID);
		}

		// Token: 0x06000171 RID: 369 RVA: 0x0000532B File Offset: 0x0000352B
		public static int GetPOPCount()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworkingUtils_GetPOPCount(CSteamGameServerAPIContext.GetSteamNetworkingUtils());
		}

		// Token: 0x06000172 RID: 370 RVA: 0x0000533C File Offset: 0x0000353C
		public static int GetPOPList(out SteamNetworkingPOPID list, int nListSz)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworkingUtils_GetPOPList(CSteamGameServerAPIContext.GetSteamNetworkingUtils(), out list, nListSz);
		}

		// Token: 0x06000173 RID: 371 RVA: 0x0000534F File Offset: 0x0000354F
		public static SteamNetworkingMicroseconds GetLocalTimestamp()
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SteamNetworkingMicroseconds)NativeMethods.ISteamNetworkingUtils_GetLocalTimestamp(CSteamGameServerAPIContext.GetSteamNetworkingUtils());
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00005365 File Offset: 0x00003565
		public static void SetDebugOutputFunction(ESteamNetworkingSocketsDebugOutputType eDetailLevel, FSteamNetworkingSocketsDebugOutput pfnFunc)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamNetworkingUtils_SetDebugOutputFunction(CSteamGameServerAPIContext.GetSteamNetworkingUtils(), eDetailLevel, pfnFunc);
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00005378 File Offset: 0x00003578
		public static bool IsFakeIPv4(uint nIPv4)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworkingUtils_IsFakeIPv4(CSteamGameServerAPIContext.GetSteamNetworkingUtils(), nIPv4);
		}

		// Token: 0x06000176 RID: 374 RVA: 0x0000538A File Offset: 0x0000358A
		public static ESteamNetworkingFakeIPType GetIPv4FakeIPType(uint nIPv4)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworkingUtils_GetIPv4FakeIPType(CSteamGameServerAPIContext.GetSteamNetworkingUtils(), nIPv4);
		}

		// Token: 0x06000177 RID: 375 RVA: 0x0000539C File Offset: 0x0000359C
		public static EResult GetRealIdentityForFakeIP(ref SteamNetworkingIPAddr fakeIP, out SteamNetworkingIdentity pOutRealIdentity)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworkingUtils_GetRealIdentityForFakeIP(CSteamGameServerAPIContext.GetSteamNetworkingUtils(), ref fakeIP, out pOutRealIdentity);
		}

		// Token: 0x06000178 RID: 376 RVA: 0x000053AF File Offset: 0x000035AF
		public static bool SetConfigValue(ESteamNetworkingConfigValue eValue, ESteamNetworkingConfigScope eScopeType, IntPtr scopeObj, ESteamNetworkingConfigDataType eDataType, IntPtr pArg)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworkingUtils_SetConfigValue(CSteamGameServerAPIContext.GetSteamNetworkingUtils(), eValue, eScopeType, scopeObj, eDataType, pArg);
		}

		// Token: 0x06000179 RID: 377 RVA: 0x000053C6 File Offset: 0x000035C6
		public static ESteamNetworkingGetConfigValueResult GetConfigValue(ESteamNetworkingConfigValue eValue, ESteamNetworkingConfigScope eScopeType, IntPtr scopeObj, out ESteamNetworkingConfigDataType pOutDataType, IntPtr pResult, ref ulong cbResult)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworkingUtils_GetConfigValue(CSteamGameServerAPIContext.GetSteamNetworkingUtils(), eValue, eScopeType, scopeObj, out pOutDataType, pResult, ref cbResult);
		}

		// Token: 0x0600017A RID: 378 RVA: 0x000053DF File Offset: 0x000035DF
		public static string GetConfigValueInfo(ESteamNetworkingConfigValue eValue, out ESteamNetworkingConfigDataType pOutDataType, out ESteamNetworkingConfigScope pOutScope)
		{
			InteropHelp.TestIfAvailableGameServer();
			return InteropHelp.PtrToStringUTF8(NativeMethods.ISteamNetworkingUtils_GetConfigValueInfo(CSteamGameServerAPIContext.GetSteamNetworkingUtils(), eValue, out pOutDataType, out pOutScope));
		}

		// Token: 0x0600017B RID: 379 RVA: 0x000053F8 File Offset: 0x000035F8
		public static ESteamNetworkingConfigValue IterateGenericEditableConfigValues(ESteamNetworkingConfigValue eCurrent, bool bEnumerateDevVars)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworkingUtils_IterateGenericEditableConfigValues(CSteamGameServerAPIContext.GetSteamNetworkingUtils(), eCurrent, bEnumerateDevVars);
		}

		// Token: 0x0600017C RID: 380 RVA: 0x0000540C File Offset: 0x0000360C
		public static void SteamNetworkingIPAddr_ToString(ref SteamNetworkingIPAddr addr, out string buf, uint cbBuf, bool bWithPort)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr intPtr = Marshal.AllocHGlobal((int)cbBuf);
			NativeMethods.ISteamNetworkingUtils_SteamNetworkingIPAddr_ToString(CSteamGameServerAPIContext.GetSteamNetworkingUtils(), ref addr, intPtr, cbBuf, bWithPort);
			buf = InteropHelp.PtrToStringUTF8(intPtr);
			Marshal.FreeHGlobal(intPtr);
		}

		// Token: 0x0600017D RID: 381 RVA: 0x00005444 File Offset: 0x00003644
		public static bool SteamNetworkingIPAddr_ParseString(out SteamNetworkingIPAddr pAddr, string pszStr)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pszStr))
			{
				result = NativeMethods.ISteamNetworkingUtils_SteamNetworkingIPAddr_ParseString(CSteamGameServerAPIContext.GetSteamNetworkingUtils(), out pAddr, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x0600017E RID: 382 RVA: 0x00005488 File Offset: 0x00003688
		public static ESteamNetworkingFakeIPType SteamNetworkingIPAddr_GetFakeIPType(ref SteamNetworkingIPAddr addr)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworkingUtils_SteamNetworkingIPAddr_GetFakeIPType(CSteamGameServerAPIContext.GetSteamNetworkingUtils(), ref addr);
		}

		// Token: 0x0600017F RID: 383 RVA: 0x0000549C File Offset: 0x0000369C
		public static void SteamNetworkingIdentity_ToString(ref SteamNetworkingIdentity identity, out string buf, uint cbBuf)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr intPtr = Marshal.AllocHGlobal((int)cbBuf);
			NativeMethods.ISteamNetworkingUtils_SteamNetworkingIdentity_ToString(CSteamGameServerAPIContext.GetSteamNetworkingUtils(), ref identity, intPtr, cbBuf);
			buf = InteropHelp.PtrToStringUTF8(intPtr);
			Marshal.FreeHGlobal(intPtr);
		}

		// Token: 0x06000180 RID: 384 RVA: 0x000054D0 File Offset: 0x000036D0
		public static bool SteamNetworkingIdentity_ParseString(out SteamNetworkingIdentity pIdentity, string pszStr)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pszStr))
			{
				result = NativeMethods.ISteamNetworkingUtils_SteamNetworkingIdentity_ParseString(CSteamGameServerAPIContext.GetSteamNetworkingUtils(), out pIdentity, utf8StringHandle);
			}
			return result;
		}
	}
}
