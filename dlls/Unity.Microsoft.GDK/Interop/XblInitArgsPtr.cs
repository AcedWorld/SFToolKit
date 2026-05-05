using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200023D RID: 573
	internal struct XblInitArgsPtr
	{
		// Token: 0x06000DED RID: 3565 RVA: 0x0001148F File Offset: 0x0000F68F
		internal XblInitArgsPtr(IntPtr intPtr)
		{
			this.IntPtr = intPtr;
		}

		// Token: 0x040007F5 RID: 2037
		internal readonly IntPtr IntPtr;
	}
}
