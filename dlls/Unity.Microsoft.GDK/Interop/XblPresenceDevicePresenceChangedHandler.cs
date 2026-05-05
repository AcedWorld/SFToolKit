using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200021C RID: 540
	// (Invoke) Token: 0x06000DD3 RID: 3539
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate void XblPresenceDevicePresenceChangedHandler(IntPtr context, ulong xuid, XblPresenceDeviceType deviceType, [MarshalAs(UnmanagedType.U1)] bool isUserLoggedOnDevice);
}
