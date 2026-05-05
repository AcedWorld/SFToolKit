using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000267 RID: 615
	// (Invoke) Token: 0x06000E35 RID: 3637
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.I1)]
	internal delegate bool XPackageEnumerationCallback(IntPtr context, XPackageDetails details);
}
