using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000290 RID: 656
	internal struct APP_LOCAL_DEVICE_ID
	{
		// Token: 0x040008C6 RID: 2246
		public const int APP_LOCAL_DEVICE_ID_SIZE = 32;

		// Token: 0x040008C7 RID: 2247
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		public byte[] value;
	}
}
