using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200026A RID: 618
	// (Invoke) Token: 0x06000E41 RID: 3649
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate void XPackageInstalledCallback(IntPtr context, XPackageDetails details);
}
