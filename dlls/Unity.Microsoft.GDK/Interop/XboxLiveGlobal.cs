using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020002A6 RID: 678
	public static class XboxLiveGlobal
	{
		// Token: 0x06000EAE RID: 3758
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int XblGetScid(sbyte** scid);
	}
}
