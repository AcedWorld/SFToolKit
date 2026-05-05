using System;
using System.Diagnostics;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000BC RID: 188
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public sealed class SSRAlgoParameter : VolumeParameter<ScreenSpaceReflectionAlgorithm>
	{
		// Token: 0x06000866 RID: 2150 RVA: 0x0004BD62 File Offset: 0x00049F62
		public SSRAlgoParameter(ScreenSpaceReflectionAlgorithm value, bool overrideState = false) : base(value, overrideState)
		{
		}
	}
}
