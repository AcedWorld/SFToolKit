using System;
using System.Collections.Generic;

namespace Rewired
{
	// Token: 0x0200009A RID: 154
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	internal interface IPlayerController
	{
		// Token: 0x17000224 RID: 548
		// (get) Token: 0x0600063A RID: 1594
		// (set) Token: 0x0600063B RID: 1595
		bool enabled { get; set; }

		// Token: 0x17000225 RID: 549
		// (get) Token: 0x0600063C RID: 1596
		// (set) Token: 0x0600063D RID: 1597
		int playerId { get; set; }

		// Token: 0x17000226 RID: 550
		// (get) Token: 0x0600063E RID: 1598
		IList<PlayerController.Button> buttons { get; }

		// Token: 0x17000227 RID: 551
		// (get) Token: 0x0600063F RID: 1599
		IList<PlayerController.Axis> axes { get; }

		// Token: 0x17000228 RID: 552
		// (get) Token: 0x06000640 RID: 1600
		IList<PlayerController.Element> elements { get; }

		// Token: 0x17000229 RID: 553
		// (get) Token: 0x06000641 RID: 1601
		int buttonCount { get; }

		// Token: 0x1700022A RID: 554
		// (get) Token: 0x06000642 RID: 1602
		int axisCount { get; }

		// Token: 0x1700022B RID: 555
		// (get) Token: 0x06000643 RID: 1603
		int elementCount { get; }

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x06000644 RID: 1604
		// (remove) Token: 0x06000645 RID: 1605
		event Action<int, bool> ButtonStateChangedEvent;

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x06000646 RID: 1606
		// (remove) Token: 0x06000647 RID: 1607
		event Action<int, float> AxisValueChangedEvent;

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x06000648 RID: 1608
		// (remove) Token: 0x06000649 RID: 1609
		event Action<bool> EnabledStateChangedEvent;

		// Token: 0x0600064A RID: 1610
		bool GetButton(int index);

		// Token: 0x0600064B RID: 1611
		bool GetButtonDown(int index);

		// Token: 0x0600064C RID: 1612
		bool GetButtonUp(int index);

		// Token: 0x0600064D RID: 1613
		float GetAxis(int index);

		// Token: 0x0600064E RID: 1614
		float GetAxisRaw(int index);

		// Token: 0x0600064F RID: 1615
		PlayerController.Element GetElement(int index);

		// Token: 0x06000650 RID: 1616
		T GetElement<T>(int index) where T : PlayerController.Element;
	}
}
