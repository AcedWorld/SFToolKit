using System;

namespace UnityEngine
{
	// Token: 0x020001AB RID: 427
	[Flags]
	public enum MaterialGlobalIlluminationFlags
	{
		// Token: 0x040005EF RID: 1519
		None = 0,
		// Token: 0x040005F0 RID: 1520
		RealtimeEmissive = 1,
		// Token: 0x040005F1 RID: 1521
		BakedEmissive = 2,
		// Token: 0x040005F2 RID: 1522
		EmissiveIsBlack = 4,
		// Token: 0x040005F3 RID: 1523
		AnyEmissive = 3
	}
}
