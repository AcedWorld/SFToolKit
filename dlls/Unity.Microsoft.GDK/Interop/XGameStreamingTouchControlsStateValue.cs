using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200024B RID: 587
	[StructLayout(LayoutKind.Explicit)]
	internal struct XGameStreamingTouchControlsStateValue
	{
		// Token: 0x04000805 RID: 2053
		[FieldOffset(0)]
		internal XGameStreamingTouchControlsStateValueKind valueKind;

		// Token: 0x04000806 RID: 2054
		[FieldOffset(8)]
		internal IntPtr stringValue;

		// Token: 0x04000807 RID: 2055
		[FieldOffset(8)]
		internal double doubleValue;

		// Token: 0x04000808 RID: 2056
		[FieldOffset(8)]
		internal bool boolValue;

		// Token: 0x04000809 RID: 2057
		[FieldOffset(8)]
		internal uint integerValue;
	}
}
