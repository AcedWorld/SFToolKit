using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001FF RID: 511
	public interface INavigationEvent
	{
		// Token: 0x1700031A RID: 794
		// (get) Token: 0x06000F0E RID: 3854
		EventModifiers modifiers { get; }

		// Token: 0x1700031B RID: 795
		// (get) Token: 0x06000F0F RID: 3855
		NavigationDeviceType deviceType { get; }

		// Token: 0x1700031C RID: 796
		// (get) Token: 0x06000F10 RID: 3856
		bool shiftKey { get; }

		// Token: 0x1700031D RID: 797
		// (get) Token: 0x06000F11 RID: 3857
		bool ctrlKey { get; }

		// Token: 0x1700031E RID: 798
		// (get) Token: 0x06000F12 RID: 3858
		bool commandKey { get; }

		// Token: 0x1700031F RID: 799
		// (get) Token: 0x06000F13 RID: 3859
		bool altKey { get; }

		// Token: 0x17000320 RID: 800
		// (get) Token: 0x06000F14 RID: 3860
		bool actionKey { get; }
	}
}
