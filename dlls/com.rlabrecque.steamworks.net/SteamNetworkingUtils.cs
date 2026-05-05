using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200001E RID: 30
	public static class SteamNetworkingUtils
	{
		// Token: 0x0600035D RID: 861 RVA: 0x00009076 File Offset: 0x00007276
		public static IntPtr AllocateMessage(int cbAllocateBuffer)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworkingUtils_AllocateMessage(CSteamAPIContext.GetSteamNetworkingUtils(), cbAllocateBuffer);
		}

		// Token: 0x0600035E RID: 862 RVA: 0x00009088 File Offset: 0x00007288
		public static void InitRelayNetworkAccess()
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamNetworkingUtils_InitRelayNetworkAccess(CSteamAPIContext.GetSteamNetworkingUtils());
		}

		// Token: 0x0600035F RID: 863 RVA: 0x00009099 File Offset: 0x00007299
		public static ESteamNetworkingAvailability GetRelayNetworkStatus(out SteamRelayNetworkStatus_t pDetails)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworkingUtils_GetRelayNetworkStatus(CSteamAPIContext.GetSteamNetworkingUtils(), out pDetails);
		}

		// Token: 0x06000360 RID: 864 RVA: 0x000090AB File Offset: 0x000072AB
		public static float GetLocalPingLocation(out SteamNetworkPingLocation_t result)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworkingUtils_GetLocalPingLocation(CSteamAPIContext.GetSteamNetworkingUtils(), out result);
		}

		// Token: 0x06000361 RID: 865 RVA: 0x000090BD File Offset: 0x000072BD
		public static int EstimatePingTimeBetweenTwoLocations(ref SteamNetworkPingLocation_t location1, ref SteamNetworkPingLocation_t location2)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworkingUtils_EstimatePingTimeBetweenTwoLocations(CSteamAPIContext.GetSteamNetworkingUtils(), ref location1, ref location2);
		}

		// Token: 0x06000362 RID: 866 RVA: 0x000090D0 File Offset: 0x000072D0
		public static int EstimatePingTimeFromLocalHost(ref SteamNetworkPingLocation_t remoteLocation)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworkingUtils_EstimatePingTimeFromLocalHost(CSteamAPIContext.GetSteamNetworkingUtils(), ref remoteLocation);
		}

		// Token: 0x06000363 RID: 867 RVA: 0x000090E4 File Offset: 0x000072E4
		public static void ConvertPingLocationToString(ref SteamNetworkPingLocation_t location, out string pszBuf, int cchBufSize)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal(cchBufSize);
			NativeMethods.ISteamNetworkingUtils_ConvertPingLocationToString(CSteamAPIContext.GetSteamNetworkingUtils(), ref location, intPtr, cchBufSize);
			pszBuf = InteropHelp.PtrToStringUTF8(intPtr);
			Marshal.FreeHGlobal(intPtr);
		}

		// Token: 0x06000364 RID: 868 RVA: 0x00009118 File Offset: 0x00007318
		public static bool ParsePingLocationString(string pszString, out SteamNetworkPingLocation_t result)
		{
			InteropHelp.TestIfAvailableClient();
			bool result2;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pszString))
			{
				result2 = NativeMethods.ISteamNetworkingUtils_ParsePingLocationString(CSteamAPIContext.GetSteamNetworkingUtils(), utf8StringHandle, out result);
			}
			return result2;
		}

		// Token: 0x06000365 RID: 869 RVA: 0x0000915C File Offset: 0x0000735C
		public static bool CheckPingDataUpToDate(float flMaxAgeSeconds)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworkingUtils_CheckPingDataUpToDate(CSteamAPIContext.GetSteamNetworkingUtils(), flMaxAgeSeconds);
		}

		// Token: 0x06000366 RID: 870 RVA: 0x0000916E File Offset: 0x0000736E
		public static int GetPingToDataCenter(SteamNetworkingPOPID popID, out SteamNetworkingPOPID pViaRelayPoP)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworkingUtils_GetPingToDataCenter(CSteamAPIContext.GetSteamNetworkingUtils(), popID, out pViaRelayPoP);
		}

		// Token: 0x06000367 RID: 871 RVA: 0x00009181 File Offset: 0x00007381
		public static int GetDirectPingToPOP(SteamNetworkingPOPID popID)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworkingUtils_GetDirectPingToPOP(CSteamAPIContext.GetSteamNetworkingUtils(), popID);
		}

		// Token: 0x06000368 RID: 872 RVA: 0x00009193 File Offset: 0x00007393
		public static int GetPOPCount()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworkingUtils_GetPOPCount(CSteamAPIContext.GetSteamNetworkingUtils());
		}

		// Token: 0x06000369 RID: 873 RVA: 0x000091A4 File Offset: 0x000073A4
		public static int GetPOPList(out SteamNetworkingPOPID list, int nListSz)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworkingUtils_GetPOPList(CSteamAPIContext.GetSteamNetworkingUtils(), out list, nListSz);
		}

		// Token: 0x0600036A RID: 874 RVA: 0x000091B7 File Offset: 0x000073B7
		public static SteamNetworkingMicroseconds GetLocalTimestamp()
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamNetworkingMicroseconds)NativeMethods.ISteamNetworkingUtils_GetLocalTimestamp(CSteamAPIContext.GetSteamNetworkingUtils());
		}

		// Token: 0x0600036B RID: 875 RVA: 0x000091CD File Offset: 0x000073CD
		public static void SetDebugOutputFunction(ESteamNetworkingSocketsDebugOutputType eDetailLevel, FSteamNetworkingSocketsDebugOutput pfnFunc)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamNetworkingUtils_SetDebugOutputFunction(CSteamAPIContext.GetSteamNetworkingUtils(), eDetailLevel, pfnFunc);
		}

		// Token: 0x0600036C RID: 876 RVA: 0x000091E0 File Offset: 0x000073E0
		public static bool IsFakeIPv4(uint nIPv4)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworkingUtils_IsFakeIPv4(CSteamAPIContext.GetSteamNetworkingUtils(), nIPv4);
		}

		// Token: 0x0600036D RID: 877 RVA: 0x000091F2 File Offset: 0x000073F2
		public static ESteamNetworkingFakeIPType GetIPv4FakeIPType(uint nIPv4)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworkingUtils_GetIPv4FakeIPType(CSteamAPIContext.GetSteamNetworkingUtils(), nIPv4);
		}

		// Token: 0x0600036E RID: 878 RVA: 0x00009204 File Offset: 0x00007404
		public static EResult GetRealIdentityForFakeIP(ref SteamNetworkingIPAddr fakeIP, out SteamNetworkingIdentity pOutRealIdentity)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworkingUtils_GetRealIdentityForFakeIP(CSteamAPIContext.GetSteamNetworkingUtils(), ref fakeIP, out pOutRealIdentity);
		}

		// Token: 0x0600036F RID: 879 RVA: 0x00009217 File Offset: 0x00007417
		public static bool SetConfigValue(ESteamNetworkingConfigValue eValue, ESteamNetworkingConfigScope eScopeType, IntPtr scopeObj, ESteamNetworkingConfigDataType eDataType, IntPtr pArg)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworkingUtils_SetConfigValue(CSteamAPIContext.GetSteamNetworkingUtils(), eValue, eScopeType, scopeObj, eDataType, pArg);
		}

		// Token: 0x06000370 RID: 880 RVA: 0x0000922E File Offset: 0x0000742E
		public static ESteamNetworkingGetConfigValueResult GetConfigValue(ESteamNetworkingConfigValue eValue, ESteamNetworkingConfigScope eScopeType, IntPtr scopeObj, out ESteamNetworkingConfigDataType pOutDataType, IntPtr pResult, ref ulong cbResult)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworkingUtils_GetConfigValue(CSteamAPIContext.GetSteamNetworkingUtils(), eValue, eScopeType, scopeObj, out pOutDataType, pResult, ref cbResult);
		}

		// Token: 0x06000371 RID: 881 RVA: 0x00009247 File Offset: 0x00007447
		public static string GetConfigValueInfo(ESteamNetworkingConfigValue eValue, out ESteamNetworkingConfigDataType pOutDataType, out ESteamNetworkingConfigScope pOutScope)
		{
			InteropHelp.TestIfAvailableClient();
			return InteropHelp.PtrToStringUTF8(NativeMethods.ISteamNetworkingUtils_GetConfigValueInfo(CSteamAPIContext.GetSteamNetworkingUtils(), eValue, out pOutDataType, out pOutScope));
		}

		// Token: 0x06000372 RID: 882 RVA: 0x00009260 File Offset: 0x00007460
		public static ESteamNetworkingConfigValue IterateGenericEditableConfigValues(ESteamNetworkingConfigValue eCurrent, bool bEnumerateDevVars)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworkingUtils_IterateGenericEditableConfigValues(CSteamAPIContext.GetSteamNetworkingUtils(), eCurrent, bEnumerateDevVars);
		}

		// Token: 0x06000373 RID: 883 RVA: 0x00009274 File Offset: 0x00007474
		public static void SteamNetworkingIPAddr_ToString(ref SteamNetworkingIPAddr addr, out string buf, uint cbBuf, bool bWithPort)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal((int)cbBuf);
			NativeMethods.ISteamNetworkingUtils_SteamNetworkingIPAddr_ToString(CSteamAPIContext.GetSteamNetworkingUtils(), ref addr, intPtr, cbBuf, bWithPort);
			buf = InteropHelp.PtrToStringUTF8(intPtr);
			Marshal.FreeHGlobal(intPtr);
		}

		// Token: 0x06000374 RID: 884 RVA: 0x000092AC File Offset: 0x000074AC
		public static bool SteamNetworkingIPAddr_ParseString(out SteamNetworkingIPAddr pAddr, string pszStr)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pszStr))
			{
				result = NativeMethods.ISteamNetworkingUtils_SteamNetworkingIPAddr_ParseString(CSteamAPIContext.GetSteamNetworkingUtils(), out pAddr, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x06000375 RID: 885 RVA: 0x000092F0 File Offset: 0x000074F0
		public static ESteamNetworkingFakeIPType SteamNetworkingIPAddr_GetFakeIPType(ref SteamNetworkingIPAddr addr)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworkingUtils_SteamNetworkingIPAddr_GetFakeIPType(CSteamAPIContext.GetSteamNetworkingUtils(), ref addr);
		}

		// Token: 0x06000376 RID: 886 RVA: 0x00009304 File Offset: 0x00007504
		public static void SteamNetworkingIdentity_ToString(ref SteamNetworkingIdentity identity, out string buf, uint cbBuf)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal((int)cbBuf);
			NativeMethods.ISteamNetworkingUtils_SteamNetworkingIdentity_ToString(CSteamAPIContext.GetSteamNetworkingUtils(), ref identity, intPtr, cbBuf);
			buf = InteropHelp.PtrToStringUTF8(intPtr);
			Marshal.FreeHGlobal(intPtr);
		}

		// Token: 0x06000377 RID: 887 RVA: 0x00009338 File Offset: 0x00007538
		public static bool SteamNetworkingIdentity_ParseString(out SteamNetworkingIdentity pIdentity, string pszStr)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pszStr))
			{
				result = NativeMethods.ISteamNetworkingUtils_SteamNetworkingIdentity_ParseString(CSteamAPIContext.GetSteamNetworkingUtils(), out pIdentity, utf8StringHandle);
			}
			return result;
		}
	}
}
