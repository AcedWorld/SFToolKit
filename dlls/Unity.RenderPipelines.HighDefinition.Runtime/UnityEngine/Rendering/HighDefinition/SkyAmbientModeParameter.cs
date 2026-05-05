using System;
using System.Diagnostics;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001FC RID: 508
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public sealed class SkyAmbientModeParameter : VolumeParameter<SkyAmbientMode>
	{
		// Token: 0x06000F59 RID: 3929 RVA: 0x00077D3B File Offset: 0x00075F3B
		public SkyAmbientModeParameter(SkyAmbientMode value, bool overrideState = false) : base(value, overrideState)
		{
		}
	}
}
