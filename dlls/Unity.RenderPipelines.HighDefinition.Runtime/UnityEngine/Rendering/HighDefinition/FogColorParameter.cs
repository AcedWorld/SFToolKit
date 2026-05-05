using System;
using System.Diagnostics;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200005F RID: 95
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public sealed class FogColorParameter : VolumeParameter<FogColorMode>
	{
		// Token: 0x0600026C RID: 620 RVA: 0x0000E43A File Offset: 0x0000C63A
		public FogColorParameter(FogColorMode value, bool overrideState = false) : base(value, overrideState)
		{
		}
	}
}
