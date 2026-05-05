using System;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	// Token: 0x020000B6 RID: 182
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	internal interface IPlayerMouse : IPlayerController
	{
		// Token: 0x17000258 RID: 600
		// (get) Token: 0x060006D2 RID: 1746
		bool defaultToCenter { get; }

		// Token: 0x17000259 RID: 601
		// (get) Token: 0x060006D3 RID: 1747
		// (set) Token: 0x060006D4 RID: 1748
		ScreenRect movementArea { get; set; }

		// Token: 0x1700025A RID: 602
		// (get) Token: 0x060006D5 RID: 1749
		// (set) Token: 0x060006D6 RID: 1750
		PlayerMouse.MovementAreaUnit movementAreaUnit { get; set; }

		// Token: 0x1700025B RID: 603
		// (get) Token: 0x060006D7 RID: 1751
		Vector2 screenPosition { get; }

		// Token: 0x1700025C RID: 604
		// (get) Token: 0x060006D8 RID: 1752
		Vector2 screenPositionPrev { get; }

		// Token: 0x1700025D RID: 605
		// (get) Token: 0x060006D9 RID: 1753
		Vector2 screenPositionDelta { get; }

		// Token: 0x1700025E RID: 606
		// (get) Token: 0x060006DA RID: 1754
		PlayerController.MouseAxis xAxis { get; }

		// Token: 0x1700025F RID: 607
		// (get) Token: 0x060006DB RID: 1755
		PlayerController.MouseAxis yAxis { get; }

		// Token: 0x17000260 RID: 608
		// (get) Token: 0x060006DC RID: 1756
		PlayerController.MouseWheel wheel { get; }

		// Token: 0x17000261 RID: 609
		// (get) Token: 0x060006DD RID: 1757
		PlayerController.Button leftButton { get; }

		// Token: 0x17000262 RID: 610
		// (get) Token: 0x060006DE RID: 1758
		PlayerController.Button rightButton { get; }

		// Token: 0x17000263 RID: 611
		// (get) Token: 0x060006DF RID: 1759
		PlayerController.Button middleButton { get; }

		// Token: 0x17000264 RID: 612
		// (get) Token: 0x060006E0 RID: 1760
		float pointerSpeed { get; }

		// Token: 0x17000265 RID: 613
		// (get) Token: 0x060006E1 RID: 1761
		bool useHardwarePointerPosition { get; }

		// Token: 0x1400000E RID: 14
		// (add) Token: 0x060006E2 RID: 1762
		// (remove) Token: 0x060006E3 RID: 1763
		event Action<Vector2> ScreenPositionChangedEvent;
	}
}
