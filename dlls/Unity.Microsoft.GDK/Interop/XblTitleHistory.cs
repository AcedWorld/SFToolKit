using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000230 RID: 560
	internal struct XblTitleHistory
	{
		// Token: 0x040007D0 RID: 2000
		[MarshalAs(UnmanagedType.U1)]
		internal readonly bool hasUserPlayed;

		// Token: 0x040007D1 RID: 2001
		internal readonly TimeT lastTimeUserPlayed;
	}
}
