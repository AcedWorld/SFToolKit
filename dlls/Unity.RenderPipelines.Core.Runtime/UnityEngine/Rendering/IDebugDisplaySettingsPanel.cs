using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000071 RID: 113
	public interface IDebugDisplaySettingsPanel
	{
		// Token: 0x17000077 RID: 119
		// (get) Token: 0x06000395 RID: 917
		string PanelName { get; }

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x06000396 RID: 918
		DebugUI.Widget[] Widgets { get; }

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x06000397 RID: 919
		DebugUI.Flags Flags { get; }
	}
}
