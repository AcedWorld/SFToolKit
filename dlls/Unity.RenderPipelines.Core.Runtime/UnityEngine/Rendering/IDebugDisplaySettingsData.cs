using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000070 RID: 112
	public interface IDebugDisplaySettingsData : IDebugDisplaySettingsQuery
	{
		// Token: 0x06000394 RID: 916
		IDebugDisplaySettingsPanelDisposable CreatePanel();
	}
}
