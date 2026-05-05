using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001CD RID: 461
	internal struct XClosedCaptionProperties
	{
		// Token: 0x040005F9 RID: 1529
		internal XColor BackgroundColor;

		// Token: 0x040005FA RID: 1530
		internal XColor FontColor;

		// Token: 0x040005FB RID: 1531
		internal XColor WindowColor;

		// Token: 0x040005FC RID: 1532
		internal XClosedCaptionFontEdgeAttribute FontEdgeAttribute;

		// Token: 0x040005FD RID: 1533
		internal XClosedCaptionFontStyle FontStyle;

		// Token: 0x040005FE RID: 1534
		internal float FontScale;

		// Token: 0x040005FF RID: 1535
		[MarshalAs(UnmanagedType.I1)]
		internal bool Enabled;
	}
}
