using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000269 RID: 617
	// (Invoke) Token: 0x06000E3D RID: 3645
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.I1)]
	internal delegate bool XPackageFeatureEnumerationCallbackInterop(IntPtr context, XPackageFeature feature);
}
