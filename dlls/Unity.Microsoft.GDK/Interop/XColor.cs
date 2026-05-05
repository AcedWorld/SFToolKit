using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001CC RID: 460
	[StructLayout(LayoutKind.Explicit)]
	internal struct XColor
	{
		// Token: 0x040005F7 RID: 1527
		[FieldOffset(0)]
		internal ARGB Argb;

		// Token: 0x040005F8 RID: 1528
		[FieldOffset(0)]
		internal uint Value;
	}
}
