using System;
using System.Diagnostics;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001F4 RID: 500
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public sealed class SkyIntensityParameter : VolumeParameter<SkyIntensityMode>
	{
		// Token: 0x06000F20 RID: 3872 RVA: 0x00077018 File Offset: 0x00075218
		public SkyIntensityParameter(SkyIntensityMode value, bool overrideState = false) : base(value, overrideState)
		{
		}
	}
}
