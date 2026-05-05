using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200024C RID: 588
	internal struct XGameStreamingTouchControlsStateOperation
	{
		// Token: 0x0400080A RID: 2058
		internal XGameStreamingTouchControlsStateOperationKind operationKind;

		// Token: 0x0400080B RID: 2059
		[MarshalAs(UnmanagedType.LPStr)]
		internal string path;

		// Token: 0x0400080C RID: 2060
		internal XGameStreamingTouchControlsStateValue value;
	}
}
