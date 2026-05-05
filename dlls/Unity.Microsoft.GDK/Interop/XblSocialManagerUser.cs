using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200022E RID: 558
	internal struct XblSocialManagerUser
	{
		// Token: 0x040007BF RID: 1983
		internal readonly ulong xboxUserId;

		// Token: 0x040007C0 RID: 1984
		[MarshalAs(UnmanagedType.U1)]
		internal readonly bool isFavorite;

		// Token: 0x040007C1 RID: 1985
		[MarshalAs(UnmanagedType.U1)]
		internal readonly bool isFollowingUser;

		// Token: 0x040007C2 RID: 1986
		[MarshalAs(UnmanagedType.U1)]
		internal readonly bool isFollowedByCaller;

		// Token: 0x040007C3 RID: 1987
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 90)]
		internal readonly byte[] displayName;

		// Token: 0x040007C4 RID: 1988
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 765)]
		internal readonly byte[] realName;

		// Token: 0x040007C5 RID: 1989
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 675)]
		internal readonly byte[] displayPicUrlRaw;

		// Token: 0x040007C6 RID: 1990
		[MarshalAs(UnmanagedType.U1)]
		internal readonly bool useAvatar;

		// Token: 0x040007C7 RID: 1991
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
		internal readonly byte[] gamerscore;

		// Token: 0x040007C8 RID: 1992
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
		internal readonly byte[] gamertag;

		// Token: 0x040007C9 RID: 1993
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 97)]
		internal readonly byte[] modernGamertag;

		// Token: 0x040007CA RID: 1994
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)]
		internal readonly byte[] modernGamertagSuffix;

		// Token: 0x040007CB RID: 1995
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 101)]
		internal readonly byte[] uniqueModernGamertag;

		// Token: 0x040007CC RID: 1996
		internal readonly XblSocialManagerPresenceRecord presenceRecord;

		// Token: 0x040007CD RID: 1997
		internal readonly XblTitleHistory titleHistory;

		// Token: 0x040007CE RID: 1998
		internal readonly XblPreferredColor preferredColor;
	}
}
