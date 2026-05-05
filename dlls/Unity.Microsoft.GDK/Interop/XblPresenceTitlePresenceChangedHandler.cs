using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200021D RID: 541
	// (Invoke) Token: 0x06000DD7 RID: 3543
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate void XblPresenceTitlePresenceChangedHandler(IntPtr context, ulong xuid, uint titleId, XblPresenceTitleState titleState);
}
