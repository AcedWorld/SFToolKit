using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000244 RID: 580
	public struct XGameSaveBlobInfo
	{
		// Token: 0x040007F9 RID: 2041
		[MarshalAs(UnmanagedType.LPStr)]
		internal string name;

		// Token: 0x040007FA RID: 2042
		internal uint size;
	}
}
