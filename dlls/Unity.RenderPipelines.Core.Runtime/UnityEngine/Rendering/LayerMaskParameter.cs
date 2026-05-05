using System;
using System.Diagnostics;

namespace UnityEngine.Rendering
{
	// Token: 0x020000F1 RID: 241
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public class LayerMaskParameter : VolumeParameter<LayerMask>
	{
		// Token: 0x060007FB RID: 2043 RVA: 0x000266D0 File Offset: 0x000248D0
		public LayerMaskParameter(LayerMask value, bool overrideState = false) : base(value, overrideState)
		{
		}
	}
}
