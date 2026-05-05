using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000224 RID: 548
	internal struct XblUserProfile
	{
		// Token: 0x04000798 RID: 1944
		internal readonly ulong xboxUserId;

		// Token: 0x04000799 RID: 1945
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 90)]
		internal byte[] appDisplayName;

		// Token: 0x0400079A RID: 1946
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 675)]
		internal byte[] appDisplayPictureResizeUri;

		// Token: 0x0400079B RID: 1947
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 90)]
		internal byte[] gameDisplayName;

		// Token: 0x0400079C RID: 1948
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 675)]
		internal byte[] gameDisplayPictureResizeUri;

		// Token: 0x0400079D RID: 1949
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
		internal byte[] gamerscore;

		// Token: 0x0400079E RID: 1950
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
		internal byte[] gamertag;

		// Token: 0x0400079F RID: 1951
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 97)]
		internal byte[] modernGamertag;

		// Token: 0x040007A0 RID: 1952
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)]
		internal byte[] modernGamertagSuffix;

		// Token: 0x040007A1 RID: 1953
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 101)]
		internal byte[] uniqueModernGamertag;
	}
}
