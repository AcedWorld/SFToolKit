using System;
using UnityEngine;

namespace Rewired.UI
{
	// Token: 0x02000476 RID: 1142
	public interface ITouchInputSource
	{
		// Token: 0x17000ADB RID: 2779
		// (get) Token: 0x06002D71 RID: 11633
		int playerId { get; }

		// Token: 0x17000ADC RID: 2780
		// (get) Token: 0x06002D72 RID: 11634
		bool touchSupported { get; }

		// Token: 0x17000ADD RID: 2781
		// (get) Token: 0x06002D73 RID: 11635
		int touchCount { get; }

		// Token: 0x06002D74 RID: 11636
		Touch GetTouch(int index);
	}
}
