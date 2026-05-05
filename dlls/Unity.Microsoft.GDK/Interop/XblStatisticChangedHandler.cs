using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020002A2 RID: 674
	// (Invoke) Token: 0x06000EA8 RID: 3752
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public unsafe delegate void XblStatisticChangedHandler(XblStatisticChangeEventArgs statisticChangeEventArgs, void* context);
}
