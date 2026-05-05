using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000423 RID: 1059
	[Flags]
	public enum RTClearFlags
	{
		// Token: 0x04000CE8 RID: 3304
		None = 0,
		// Token: 0x04000CE9 RID: 3305
		Color = 1,
		// Token: 0x04000CEA RID: 3306
		Depth = 2,
		// Token: 0x04000CEB RID: 3307
		Stencil = 4,
		// Token: 0x04000CEC RID: 3308
		All = 7,
		// Token: 0x04000CED RID: 3309
		DepthStencil = 6,
		// Token: 0x04000CEE RID: 3310
		ColorDepth = 3,
		// Token: 0x04000CEF RID: 3311
		ColorStencil = 5
	}
}
