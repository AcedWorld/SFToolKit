using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001D5 RID: 469
	public interface IKeyboardEvent
	{
		// Token: 0x170002E4 RID: 740
		// (get) Token: 0x06000E26 RID: 3622
		EventModifiers modifiers { get; }

		// Token: 0x170002E5 RID: 741
		// (get) Token: 0x06000E27 RID: 3623
		char character { get; }

		// Token: 0x170002E6 RID: 742
		// (get) Token: 0x06000E28 RID: 3624
		KeyCode keyCode { get; }

		// Token: 0x170002E7 RID: 743
		// (get) Token: 0x06000E29 RID: 3625
		bool shiftKey { get; }

		// Token: 0x170002E8 RID: 744
		// (get) Token: 0x06000E2A RID: 3626
		bool ctrlKey { get; }

		// Token: 0x170002E9 RID: 745
		// (get) Token: 0x06000E2B RID: 3627
		bool commandKey { get; }

		// Token: 0x170002EA RID: 746
		// (get) Token: 0x06000E2C RID: 3628
		bool altKey { get; }

		// Token: 0x170002EB RID: 747
		// (get) Token: 0x06000E2D RID: 3629
		bool actionKey { get; }
	}
}
