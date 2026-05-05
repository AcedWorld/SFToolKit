using System;

namespace UnityEngine
{
	// Token: 0x0200019C RID: 412
	public enum ScreenOrientation
	{
		// Token: 0x04000547 RID: 1351
		Portrait = 1,
		// Token: 0x04000548 RID: 1352
		PortraitUpsideDown,
		// Token: 0x04000549 RID: 1353
		LandscapeLeft,
		// Token: 0x0400054A RID: 1354
		LandscapeRight,
		// Token: 0x0400054B RID: 1355
		AutoRotation,
		// Token: 0x0400054C RID: 1356
		[Obsolete("Enum member Unknown has been deprecated.", false)]
		Unknown = 0,
		// Token: 0x0400054D RID: 1357
		[Obsolete("Use LandscapeLeft instead (UnityUpgradable) -> LandscapeLeft", true)]
		Landscape = 3
	}
}
