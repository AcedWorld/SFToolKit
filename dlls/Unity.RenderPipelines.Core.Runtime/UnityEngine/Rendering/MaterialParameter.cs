using System;
using System.Diagnostics;

namespace UnityEngine.Rendering
{
	// Token: 0x02000116 RID: 278
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public class MaterialParameter : VolumeParameter<Material>
	{
		// Token: 0x0600085A RID: 2138 RVA: 0x0002713E File Offset: 0x0002533E
		public MaterialParameter(Material value, bool overrideState = false) : base(value, overrideState)
		{
		}
	}
}
