using System;

namespace Rewired
{
	// Token: 0x020000DC RID: 220
	[Flags]
	[CustomObfuscation(rename = false)]
	internal enum ButtonStateFlags
	{
		// Token: 0x040005CF RID: 1487
		Off = 0,
		// Token: 0x040005D0 RID: 1488
		On = 1,
		// Token: 0x040005D1 RID: 1489
		Down = 2,
		// Token: 0x040005D2 RID: 1490
		Up = 4
	}
}
