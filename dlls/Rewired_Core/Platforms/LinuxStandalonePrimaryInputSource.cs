using System;
using System.ComponentModel;

namespace Rewired.Platforms
{
	// Token: 0x02000200 RID: 512
	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum LinuxStandalonePrimaryInputSource
	{
		// Token: 0x04000D9A RID: 3482
		Native,
		// Token: 0x04000D9B RID: 3483
		SDL2 = 10,
		// Token: 0x04000D9C RID: 3484
		Unity = 100
	}
}
