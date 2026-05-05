using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000227 RID: 551
	// (Invoke) Token: 0x06000DE2 RID: 3554
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate void XblSocialRelationshipChangedHandler(XblSocialRelationshipChangeEventArgs* eventArgs, IntPtr context);
}
