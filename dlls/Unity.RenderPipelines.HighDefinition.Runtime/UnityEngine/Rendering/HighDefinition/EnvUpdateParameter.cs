using System;
using System.Diagnostics;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001F0 RID: 496
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public sealed class EnvUpdateParameter : VolumeParameter<EnvironmentUpdateMode>
	{
		// Token: 0x06000F1E RID: 3870 RVA: 0x00077004 File Offset: 0x00075204
		public EnvUpdateParameter(EnvironmentUpdateMode value, bool overrideState = false) : base(value, overrideState)
		{
		}
	}
}
