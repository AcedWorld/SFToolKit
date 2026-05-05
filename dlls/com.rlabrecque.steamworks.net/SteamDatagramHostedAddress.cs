using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000192 RID: 402
	[Serializable]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SteamDatagramHostedAddress
	{
		// Token: 0x0600098B RID: 2443 RVA: 0x0000EAD4 File Offset: 0x0000CCD4
		public void Clear()
		{
			this.m_cbSize = 0;
			this.m_data = new byte[128];
		}

		// Token: 0x04000A50 RID: 2640
		public int m_cbSize;

		// Token: 0x04000A51 RID: 2641
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
		public byte[] m_data;
	}
}
