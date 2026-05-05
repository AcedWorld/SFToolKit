using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks
{
	// Token: 0x020001A8 RID: 424
	// (Invoke) Token: 0x06000A3E RID: 2622
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void FSteamNetworkingSocketsDebugOutput(ESteamNetworkingSocketsDebugOutputType nType, StringBuilder pszMsg);
}
