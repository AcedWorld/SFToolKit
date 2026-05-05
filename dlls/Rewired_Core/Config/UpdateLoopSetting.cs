using System;

namespace Rewired.Config
{
	// Token: 0x020003C9 RID: 969
	[Flags]
	public enum UpdateLoopSetting
	{
		// Token: 0x040016BE RID: 5822
		None = 0,
		// Token: 0x040016BF RID: 5823
		Update = 1,
		// Token: 0x040016C0 RID: 5824
		FixedUpdate = 2,
		// Token: 0x040016C1 RID: 5825
		OnGUI = 4
	}
}
