using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000292 RID: 658
	// (Invoke) Token: 0x06000E8B RID: 3723
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate void XUserDefaultAudioEndpointUtf16ChangedCallback(IntPtr context, XUserLocalId user, XUserDefaultAudioEndpointKind defaultAudioEndpointKind, [MarshalAs(UnmanagedType.LPWStr)] string endpointIdUtf16);
}
