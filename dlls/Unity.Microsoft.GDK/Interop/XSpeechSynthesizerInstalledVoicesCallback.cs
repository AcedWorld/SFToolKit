using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200026E RID: 622
	// (Invoke) Token: 0x06000E49 RID: 3657
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.I1)]
	internal delegate bool XSpeechSynthesizerInstalledVoicesCallback([In] ref XSpeechSynthesizerVoiceInformation information, IntPtr context);
}
