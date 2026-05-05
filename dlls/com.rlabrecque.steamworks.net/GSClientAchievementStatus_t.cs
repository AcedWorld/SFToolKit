using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200004A RID: 74
	[CallbackIdentity(206)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GSClientAchievementStatus_t
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600084D RID: 2125 RVA: 0x0000BE5F File Offset: 0x0000A05F
		// (set) Token: 0x0600084E RID: 2126 RVA: 0x0000BE6C File Offset: 0x0000A06C
		public string m_pchAchievement
		{
			get
			{
				return InteropHelp.ByteArrayToStringUTF8(this.m_pchAchievement_);
			}
			set
			{
				InteropHelp.StringToByteArrayUTF8(value, this.m_pchAchievement_, 128);
			}
		}

		// Token: 0x0400006D RID: 109
		public const int k_iCallback = 206;

		// Token: 0x0400006E RID: 110
		public ulong m_SteamID;

		// Token: 0x0400006F RID: 111
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
		private byte[] m_pchAchievement_;

		// Token: 0x04000070 RID: 112
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bUnlocked;
	}
}
