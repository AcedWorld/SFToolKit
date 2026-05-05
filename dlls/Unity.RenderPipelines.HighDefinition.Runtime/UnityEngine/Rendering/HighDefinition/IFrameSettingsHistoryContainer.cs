using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001B7 RID: 439
	internal interface IFrameSettingsHistoryContainer : IDebugData
	{
		// Token: 0x17000217 RID: 535
		// (get) Token: 0x06000D6D RID: 3437
		// (set) Token: 0x06000D6E RID: 3438
		FrameSettingsHistory frameSettingsHistory { get; set; }

		// Token: 0x17000218 RID: 536
		// (get) Token: 0x06000D6F RID: 3439
		FrameSettingsOverrideMask frameSettingsMask { get; }

		// Token: 0x17000219 RID: 537
		// (get) Token: 0x06000D70 RID: 3440
		FrameSettings frameSettings { get; }

		// Token: 0x1700021A RID: 538
		// (get) Token: 0x06000D71 RID: 3441
		bool hasCustomFrameSettings { get; }

		// Token: 0x1700021B RID: 539
		// (get) Token: 0x06000D72 RID: 3442
		string panelName { get; }
	}
}
