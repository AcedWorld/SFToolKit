using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200024E RID: 590
	internal struct XGameStreamingDisplayDetails
	{
		// Token: 0x04000811 RID: 2065
		internal uint preferredWidth;

		// Token: 0x04000812 RID: 2066
		internal uint preferredHeight;

		// Token: 0x04000813 RID: 2067
		internal RECT safeArea;

		// Token: 0x04000814 RID: 2068
		internal uint maxPixels;

		// Token: 0x04000815 RID: 2069
		internal uint maxWidth;

		// Token: 0x04000816 RID: 2070
		internal uint maxHeight;

		// Token: 0x04000817 RID: 2071
		internal XGameStreamingVideoFlags flags;
	}
}
