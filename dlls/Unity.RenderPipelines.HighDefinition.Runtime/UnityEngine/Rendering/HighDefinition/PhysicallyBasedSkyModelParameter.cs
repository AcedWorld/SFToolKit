using System;
using System.Diagnostics;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001E2 RID: 482
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public sealed class PhysicallyBasedSkyModelParameter : VolumeParameter<PhysicallyBasedSkyModel>
	{
		// Token: 0x06000E8D RID: 3725 RVA: 0x00073679 File Offset: 0x00071879
		public PhysicallyBasedSkyModelParameter(PhysicallyBasedSkyModel value, bool overrideState = false) : base(value, overrideState)
		{
		}
	}
}
