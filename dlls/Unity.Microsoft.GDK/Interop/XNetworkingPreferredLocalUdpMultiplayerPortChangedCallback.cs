using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200025F RID: 607
	// (Invoke) Token: 0x06000E28 RID: 3624
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate void XNetworkingPreferredLocalUdpMultiplayerPortChangedCallback(IntPtr context, ushort preferredLocalUdpMultiplayerPort);
}
