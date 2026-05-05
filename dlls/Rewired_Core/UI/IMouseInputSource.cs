using System;
using UnityEngine;

namespace Rewired.UI
{
	// Token: 0x02000475 RID: 1141
	public interface IMouseInputSource
	{
		// Token: 0x17000AD4 RID: 2772
		// (get) Token: 0x06002D67 RID: 11623
		int playerId { get; }

		// Token: 0x17000AD5 RID: 2773
		// (get) Token: 0x06002D68 RID: 11624
		bool enabled { get; }

		// Token: 0x17000AD6 RID: 2774
		// (get) Token: 0x06002D69 RID: 11625
		bool locked { get; }

		// Token: 0x17000AD7 RID: 2775
		// (get) Token: 0x06002D6A RID: 11626
		int buttonCount { get; }

		// Token: 0x06002D6B RID: 11627
		bool GetButtonDown(int button);

		// Token: 0x06002D6C RID: 11628
		bool GetButtonUp(int button);

		// Token: 0x06002D6D RID: 11629
		bool GetButton(int button);

		// Token: 0x17000AD8 RID: 2776
		// (get) Token: 0x06002D6E RID: 11630
		Vector2 screenPosition { get; }

		// Token: 0x17000AD9 RID: 2777
		// (get) Token: 0x06002D6F RID: 11631
		Vector2 screenPositionDelta { get; }

		// Token: 0x17000ADA RID: 2778
		// (get) Token: 0x06002D70 RID: 11632
		Vector2 wheelDelta { get; }
	}
}
