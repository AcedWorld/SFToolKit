using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200029C RID: 668
	public static class RealTimeActivity
	{
		// Token: 0x06000E9E RID: 3742
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int XblRealTimeActivityAddConnectionStateChangeHandler(IntPtr xboxLiveContext, RealTimeActivity.XblRealTimeActivityConnectionStateChangeHandler handler, IntPtr context);

		// Token: 0x06000E9F RID: 3743
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int XblRealTimeActivityRemoveConnectionStateChangeHandler(IntPtr xboxLiveContext, int token);

		// Token: 0x06000EA0 RID: 3744
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int XblRealTimeActivityAddResyncHandler(IntPtr xboxLiveContext, RealTimeActivity.XblRealTimeActivityResyncHandler handler, IntPtr context);

		// Token: 0x06000EA1 RID: 3745
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int XblRealTimeActivityRemoveResyncHandler(IntPtr xboxLiveContext, int token);

		// Token: 0x02000346 RID: 838
		// (Invoke) Token: 0x06001114 RID: 4372
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate void XblRealTimeActivityConnectionStateChangeHandler(IntPtr context, XblRealTimeActivityConnectionState connectionState);

		// Token: 0x02000347 RID: 839
		// (Invoke) Token: 0x06001118 RID: 4376
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate void XblRealTimeActivityResyncHandler(IntPtr context);
	}
}
