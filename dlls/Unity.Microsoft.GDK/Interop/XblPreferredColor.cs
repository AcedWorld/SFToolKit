using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200022A RID: 554
	internal struct XblPreferredColor
	{
		// Token: 0x040007AD RID: 1965
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 21)]
		internal readonly byte[] primaryColor;

		// Token: 0x040007AE RID: 1966
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 21)]
		internal readonly byte[] secondaryColor;

		// Token: 0x040007AF RID: 1967
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 21)]
		internal readonly byte[] tertiaryColor;
	}
}
