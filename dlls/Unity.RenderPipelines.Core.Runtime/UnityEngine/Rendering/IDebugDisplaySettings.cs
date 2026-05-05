using System;

namespace UnityEngine.Rendering
{
	// Token: 0x0200006F RID: 111
	public interface IDebugDisplaySettings : IDebugDisplaySettingsQuery
	{
		// Token: 0x06000392 RID: 914
		void Reset();

		// Token: 0x06000393 RID: 915
		void ForEach(Action<IDebugDisplaySettingsData> onExecute);
	}
}
