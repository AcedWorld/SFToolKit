using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000251 RID: 593
	// (Invoke) Token: 0x06000E14 RID: 3604
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate void XGameStreamingClientPropertiesChangedCallback(IntPtr context, XGameStreamingClientId client, uint updatedPropertiesCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] XGameStreamingClientProperty[] updatedProperties);
}
