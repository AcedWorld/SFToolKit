using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200026B RID: 619
	// (Invoke) Token: 0x06000E45 RID: 3653
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate void XPackageInstallationProgressCallback(IntPtr context, IntPtr monitor);
}
