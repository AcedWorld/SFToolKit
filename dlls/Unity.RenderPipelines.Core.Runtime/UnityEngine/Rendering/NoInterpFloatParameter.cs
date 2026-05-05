using System;
using System.Diagnostics;

namespace UnityEngine.Rendering
{
	// Token: 0x020000FB RID: 251
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public class NoInterpFloatParameter : VolumeParameter<float>
	{
		// Token: 0x06000813 RID: 2067 RVA: 0x00026843 File Offset: 0x00024A43
		public NoInterpFloatParameter(float value, bool overrideState = false) : base(value, overrideState)
		{
		}
	}
}
