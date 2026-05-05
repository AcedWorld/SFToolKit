using System;
using System.Diagnostics;

namespace UnityEngine.Rendering
{
	// Token: 0x020000F3 RID: 243
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public class NoInterpIntParameter : VolumeParameter<int>
	{
		// Token: 0x060007FE RID: 2046 RVA: 0x000266F6 File Offset: 0x000248F6
		public NoInterpIntParameter(int value, bool overrideState = false) : base(value, overrideState)
		{
		}
	}
}
