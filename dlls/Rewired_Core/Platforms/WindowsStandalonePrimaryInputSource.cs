using System;
using System.ComponentModel;

namespace Rewired.Platforms
{
	// Token: 0x020001FE RID: 510
	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum WindowsStandalonePrimaryInputSource
	{
		// Token: 0x04000D8E RID: 3470
		RawInput,
		// Token: 0x04000D8F RID: 3471
		DirectInput,
		// Token: 0x04000D90 RID: 3472
		XInput,
		// Token: 0x04000D91 RID: 3473
		WindowsGamingInput,
		// Token: 0x04000D92 RID: 3474
		SDL2 = 10,
		// Token: 0x04000D93 RID: 3475
		Unity = 100
	}
}
