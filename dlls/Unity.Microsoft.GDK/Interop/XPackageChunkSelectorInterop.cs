using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000260 RID: 608
	[StructLayout(LayoutKind.Explicit)]
	internal struct XPackageChunkSelectorInterop
	{
		// Token: 0x04000837 RID: 2103
		[FieldOffset(0)]
		internal XPackageChunkSelectorType type;

		// Token: 0x04000838 RID: 2104
		[FieldOffset(8)]
		internal IntPtr languageOrTagOrFeature;

		// Token: 0x04000839 RID: 2105
		[FieldOffset(8)]
		internal uint chunkId;
	}
}
