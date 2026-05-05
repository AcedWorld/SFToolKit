using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200019C RID: 412
	// (Invoke) Token: 0x060009E2 RID: 2530
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void SteamInputActionEventCallbackPointer(IntPtr SteamInputActionEvent);
}
