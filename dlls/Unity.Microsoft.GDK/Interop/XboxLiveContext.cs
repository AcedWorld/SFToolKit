using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020002A5 RID: 677
	public static class XboxLiveContext
	{
		// Token: 0x06000EAB RID: 3755
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int XblContextDuplicateHandle(IntPtr xboxLiveContextHandle, out IntPtr duplicatedHandle);

		// Token: 0x06000EAC RID: 3756
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int XblContextGetUser(IntPtr context, out IntPtr user);

		// Token: 0x06000EAD RID: 3757
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int XblContextGetXboxUserId(IntPtr context, out ulong xboxUserId);
	}
}
