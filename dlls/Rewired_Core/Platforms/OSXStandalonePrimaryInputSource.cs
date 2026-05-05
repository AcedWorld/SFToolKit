using System;
using System.ComponentModel;

namespace Rewired.Platforms
{
	// Token: 0x020001FF RID: 511
	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum OSXStandalonePrimaryInputSource
	{
		// Token: 0x04000D95 RID: 3477
		Native,
		// Token: 0x04000D96 RID: 3478
		GameController,
		// Token: 0x04000D97 RID: 3479
		SDL2 = 10,
		// Token: 0x04000D98 RID: 3480
		Unity = 100
	}
}
