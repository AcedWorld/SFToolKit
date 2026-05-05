using System;

namespace Rewired.Utils
{
	// Token: 0x02000488 RID: 1160
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class SystemInfo
	{
		// Token: 0x040019A7 RID: 6567
		public static readonly bool is64Bit = IntPtr.Size == 8;
	}
}
