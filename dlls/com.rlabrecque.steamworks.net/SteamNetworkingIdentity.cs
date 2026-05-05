using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020001AE RID: 430
	[Serializable]
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct SteamNetworkingIdentity : IEquatable<SteamNetworkingIdentity>
	{
		// Token: 0x06000A62 RID: 2658 RVA: 0x0000F64C File Offset: 0x0000D84C
		public void Clear()
		{
			NativeMethods.SteamAPI_SteamNetworkingIdentity_Clear(ref this);
		}

		// Token: 0x06000A63 RID: 2659 RVA: 0x0000F654 File Offset: 0x0000D854
		public bool IsInvalid()
		{
			return NativeMethods.SteamAPI_SteamNetworkingIdentity_IsInvalid(ref this);
		}

		// Token: 0x06000A64 RID: 2660 RVA: 0x0000F65C File Offset: 0x0000D85C
		public void SetSteamID(CSteamID steamID)
		{
			NativeMethods.SteamAPI_SteamNetworkingIdentity_SetSteamID(ref this, (ulong)steamID);
		}

		// Token: 0x06000A65 RID: 2661 RVA: 0x0000F66A File Offset: 0x0000D86A
		public CSteamID GetSteamID()
		{
			return (CSteamID)NativeMethods.SteamAPI_SteamNetworkingIdentity_GetSteamID(ref this);
		}

		// Token: 0x06000A66 RID: 2662 RVA: 0x0000F677 File Offset: 0x0000D877
		public void SetSteamID64(ulong steamID)
		{
			NativeMethods.SteamAPI_SteamNetworkingIdentity_SetSteamID64(ref this, steamID);
		}

		// Token: 0x06000A67 RID: 2663 RVA: 0x0000F680 File Offset: 0x0000D880
		public ulong GetSteamID64()
		{
			return NativeMethods.SteamAPI_SteamNetworkingIdentity_GetSteamID64(ref this);
		}

		// Token: 0x06000A68 RID: 2664 RVA: 0x0000F688 File Offset: 0x0000D888
		public void SetIPAddr(SteamNetworkingIPAddr addr)
		{
			NativeMethods.SteamAPI_SteamNetworkingIdentity_SetIPAddr(ref this, ref addr);
		}

		// Token: 0x06000A69 RID: 2665 RVA: 0x0000F693 File Offset: 0x0000D893
		public SteamNetworkingIPAddr GetIPAddr()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000A6A RID: 2666 RVA: 0x0000F69A File Offset: 0x0000D89A
		public void SetIPv4Addr(uint nIPv4, ushort nPort)
		{
			NativeMethods.SteamAPI_SteamNetworkingIdentity_SetIPv4Addr(ref this, nIPv4, nPort);
		}

		// Token: 0x06000A6B RID: 2667 RVA: 0x0000F6A4 File Offset: 0x0000D8A4
		public uint GetIPv4()
		{
			return NativeMethods.SteamAPI_SteamNetworkingIdentity_GetIPv4(ref this);
		}

		// Token: 0x06000A6C RID: 2668 RVA: 0x0000F6AC File Offset: 0x0000D8AC
		public ESteamNetworkingFakeIPType GetFakeIPType()
		{
			return NativeMethods.SteamAPI_SteamNetworkingIdentity_GetFakeIPType(ref this);
		}

		// Token: 0x06000A6D RID: 2669 RVA: 0x0000F6B4 File Offset: 0x0000D8B4
		public bool IsFakeIP()
		{
			return this.GetFakeIPType() > ESteamNetworkingFakeIPType.k_ESteamNetworkingFakeIPType_NotFake;
		}

		// Token: 0x06000A6E RID: 2670 RVA: 0x0000F6BF File Offset: 0x0000D8BF
		public void SetLocalHost()
		{
			NativeMethods.SteamAPI_SteamNetworkingIdentity_SetLocalHost(ref this);
		}

		// Token: 0x06000A6F RID: 2671 RVA: 0x0000F6C7 File Offset: 0x0000D8C7
		public bool IsLocalHost()
		{
			return NativeMethods.SteamAPI_SteamNetworkingIdentity_IsLocalHost(ref this);
		}

		// Token: 0x06000A70 RID: 2672 RVA: 0x0000F6D0 File Offset: 0x0000D8D0
		public bool SetGenericString(string pszString)
		{
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pszString))
			{
				result = NativeMethods.SteamAPI_SteamNetworkingIdentity_SetGenericString(ref this, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x06000A71 RID: 2673 RVA: 0x0000F70C File Offset: 0x0000D90C
		public string GetGenericString()
		{
			return InteropHelp.PtrToStringUTF8(NativeMethods.SteamAPI_SteamNetworkingIdentity_GetGenericString(ref this));
		}

		// Token: 0x06000A72 RID: 2674 RVA: 0x0000F719 File Offset: 0x0000D919
		public bool SetGenericBytes(byte[] data, uint cbLen)
		{
			return NativeMethods.SteamAPI_SteamNetworkingIdentity_SetGenericBytes(ref this, data, cbLen);
		}

		// Token: 0x06000A73 RID: 2675 RVA: 0x0000F723 File Offset: 0x0000D923
		public byte[] GetGenericBytes(out int cbLen)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000A74 RID: 2676 RVA: 0x0000F72A File Offset: 0x0000D92A
		public bool Equals(SteamNetworkingIdentity x)
		{
			return NativeMethods.SteamAPI_SteamNetworkingIdentity_IsEqualTo(ref this, ref x);
		}

		// Token: 0x06000A75 RID: 2677 RVA: 0x0000F734 File Offset: 0x0000D934
		public void ToString(out string buf)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(128);
			NativeMethods.SteamAPI_SteamNetworkingIdentity_ToString(ref this, intPtr, 128U);
			buf = InteropHelp.PtrToStringUTF8(intPtr);
			Marshal.FreeHGlobal(intPtr);
		}

		// Token: 0x06000A76 RID: 2678 RVA: 0x0000F768 File Offset: 0x0000D968
		public bool ParseString(string pszStr)
		{
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pszStr))
			{
				result = NativeMethods.SteamAPI_SteamNetworkingIdentity_ParseString(ref this, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x04000A82 RID: 2690
		public ESteamNetworkingIdentityType m_eType;

		// Token: 0x04000A83 RID: 2691
		private int m_cbSize;

		// Token: 0x04000A84 RID: 2692
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		private uint[] m_reserved;

		// Token: 0x04000A85 RID: 2693
		public const int k_cchMaxString = 128;

		// Token: 0x04000A86 RID: 2694
		public const int k_cchMaxGenericString = 32;

		// Token: 0x04000A87 RID: 2695
		public const int k_cbMaxGenericBytes = 32;
	}
}
