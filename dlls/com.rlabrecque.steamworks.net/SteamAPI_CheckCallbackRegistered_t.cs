using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200018E RID: 398
	// (Invoke) Token: 0x0600093D RID: 2365
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void SteamAPI_CheckCallbackRegistered_t(int iCallbackNum);
}
