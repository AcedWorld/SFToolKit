using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020001AF RID: 431
	[Serializable]
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct SteamNetworkingIPAddr : IEquatable<SteamNetworkingIPAddr>
	{
		// Token: 0x06000A77 RID: 2679 RVA: 0x0000F7A4 File Offset: 0x0000D9A4
		public void Clear()
		{
			NativeMethods.SteamAPI_SteamNetworkingIPAddr_Clear(ref this);
		}

		// Token: 0x06000A78 RID: 2680 RVA: 0x0000F7AC File Offset: 0x0000D9AC
		public bool IsIPv6AllZeros()
		{
			return NativeMethods.SteamAPI_SteamNetworkingIPAddr_IsIPv6AllZeros(ref this);
		}

		// Token: 0x06000A79 RID: 2681 RVA: 0x0000F7B4 File Offset: 0x0000D9B4
		public void SetIPv6(byte[] ipv6, ushort nPort)
		{
			NativeMethods.SteamAPI_SteamNetworkingIPAddr_SetIPv6(ref this, ipv6, nPort);
		}

		// Token: 0x06000A7A RID: 2682 RVA: 0x0000F7BE File Offset: 0x0000D9BE
		public void SetIPv4(uint nIP, ushort nPort)
		{
			NativeMethods.SteamAPI_SteamNetworkingIPAddr_SetIPv4(ref this, nIP, nPort);
		}

		// Token: 0x06000A7B RID: 2683 RVA: 0x0000F7C8 File Offset: 0x0000D9C8
		public bool IsIPv4()
		{
			return NativeMethods.SteamAPI_SteamNetworkingIPAddr_IsIPv4(ref this);
		}

		// Token: 0x06000A7C RID: 2684 RVA: 0x0000F7D0 File Offset: 0x0000D9D0
		public uint GetIPv4()
		{
			return NativeMethods.SteamAPI_SteamNetworkingIPAddr_GetIPv4(ref this);
		}

		// Token: 0x06000A7D RID: 2685 RVA: 0x0000F7D8 File Offset: 0x0000D9D8
		public void SetIPv6LocalHost(ushort nPort = 0)
		{
			NativeMethods.SteamAPI_SteamNetworkingIPAddr_SetIPv6LocalHost(ref this, nPort);
		}

		// Token: 0x06000A7E RID: 2686 RVA: 0x0000F7E1 File Offset: 0x0000D9E1
		public bool IsLocalHost()
		{
			return NativeMethods.SteamAPI_SteamNetworkingIPAddr_IsLocalHost(ref this);
		}

		// Token: 0x06000A7F RID: 2687 RVA: 0x0000F7EC File Offset: 0x0000D9EC
		public void ToString(out string buf, bool bWithPort)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(48);
			NativeMethods.SteamAPI_SteamNetworkingIPAddr_ToString(ref this, intPtr, 48U, bWithPort);
			buf = InteropHelp.PtrToStringUTF8(intPtr);
			Marshal.FreeHGlobal(intPtr);
		}

		// Token: 0x06000A80 RID: 2688 RVA: 0x0000F81C File Offset: 0x0000DA1C
		public bool ParseString(string pszStr)
		{
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pszStr))
			{
				result = NativeMethods.SteamAPI_SteamNetworkingIPAddr_ParseString(ref this, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x06000A81 RID: 2689 RVA: 0x0000F858 File Offset: 0x0000DA58
		public bool Equals(SteamNetworkingIPAddr x)
		{
			return NativeMethods.SteamAPI_SteamNetworkingIPAddr_IsEqualTo(ref this, ref x);
		}

		// Token: 0x06000A82 RID: 2690 RVA: 0x0000F862 File Offset: 0x0000DA62
		public ESteamNetworkingFakeIPType GetFakeIPType()
		{
			return NativeMethods.SteamAPI_SteamNetworkingIPAddr_GetFakeIPType(ref this);
		}

		// Token: 0x06000A83 RID: 2691 RVA: 0x0000F86A File Offset: 0x0000DA6A
		public bool IsFakeIP()
		{
			return this.GetFakeIPType() > ESteamNetworkingFakeIPType.k_ESteamNetworkingFakeIPType_NotFake;
		}

		// Token: 0x04000A88 RID: 2696
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public byte[] m_ipv6;

		// Token: 0x04000A89 RID: 2697
		public ushort m_port;

		// Token: 0x04000A8A RID: 2698
		public const int k_cchMaxString = 48;
	}
}
