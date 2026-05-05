using System;

namespace Rewired.Platforms.Microsoft.WindowsGamingInput
{
	// Token: 0x020000BF RID: 191
	[Flags]
	internal enum GamepadButtons : uint
	{
		// Token: 0x040006CA RID: 1738
		None = 0U,
		// Token: 0x040006CB RID: 1739
		Menu = 1U,
		// Token: 0x040006CC RID: 1740
		View = 2U,
		// Token: 0x040006CD RID: 1741
		A = 4U,
		// Token: 0x040006CE RID: 1742
		B = 8U,
		// Token: 0x040006CF RID: 1743
		X = 16U,
		// Token: 0x040006D0 RID: 1744
		Y = 32U,
		// Token: 0x040006D1 RID: 1745
		DPadUp = 64U,
		// Token: 0x040006D2 RID: 1746
		DPadDown = 128U,
		// Token: 0x040006D3 RID: 1747
		DPadLeft = 256U,
		// Token: 0x040006D4 RID: 1748
		DPadRight = 512U,
		// Token: 0x040006D5 RID: 1749
		LeftShoulder = 1024U,
		// Token: 0x040006D6 RID: 1750
		RightShoulder = 2048U,
		// Token: 0x040006D7 RID: 1751
		LeftThumbstick = 4096U,
		// Token: 0x040006D8 RID: 1752
		RightThumbstick = 8192U
	}
}
