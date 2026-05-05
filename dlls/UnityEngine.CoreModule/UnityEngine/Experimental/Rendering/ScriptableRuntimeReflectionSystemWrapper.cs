using System;
using UnityEngine.Scripting;

namespace UnityEngine.Experimental.Rendering
{
	// Token: 0x020004D5 RID: 1237
	[RequiredByNativeCode]
	internal class ScriptableRuntimeReflectionSystemWrapper
	{
		// Token: 0x1700083F RID: 2111
		// (get) Token: 0x06002B2D RID: 11053 RVA: 0x0004922B File Offset: 0x0004742B
		// (set) Token: 0x06002B2E RID: 11054 RVA: 0x00049233 File Offset: 0x00047433
		internal IScriptableRuntimeReflectionSystem implementation { get; set; }

		// Token: 0x06002B2F RID: 11055 RVA: 0x0004923C File Offset: 0x0004743C
		[RequiredByNativeCode]
		private void Internal_ScriptableRuntimeReflectionSystemWrapper_TickRealtimeProbes(out bool result)
		{
			result = (this.implementation != null && this.implementation.TickRealtimeProbes());
		}
	}
}
