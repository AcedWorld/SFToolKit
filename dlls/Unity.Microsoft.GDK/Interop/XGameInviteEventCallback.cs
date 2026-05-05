using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000241 RID: 577
	// (Invoke) Token: 0x06000DF7 RID: 3575
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate void XGameInviteEventCallback(IntPtr context, [MarshalAs(UnmanagedType.LPStr)] string inviteUri);
}
