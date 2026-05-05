using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000283 RID: 643
	[StructLayout(LayoutKind.Explicit)]
	internal struct XVersion
	{
		// Token: 0x040008B8 RID: 2232
		[FieldOffset(0)]
		internal ushort major;

		// Token: 0x040008B9 RID: 2233
		[FieldOffset(2)]
		internal ushort minor;

		// Token: 0x040008BA RID: 2234
		[FieldOffset(4)]
		internal ushort build;

		// Token: 0x040008BB RID: 2235
		[FieldOffset(6)]
		internal ushort revision;

		// Token: 0x040008BC RID: 2236
		[FieldOffset(0)]
		internal ulong Value;
	}
}
