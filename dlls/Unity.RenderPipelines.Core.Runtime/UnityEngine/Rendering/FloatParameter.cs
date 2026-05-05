using System;
using System.Diagnostics;

namespace UnityEngine.Rendering
{
	// Token: 0x020000FA RID: 250
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public class FloatParameter : VolumeParameter<float>
	{
		// Token: 0x06000811 RID: 2065 RVA: 0x0002682A File Offset: 0x00024A2A
		public FloatParameter(float value, bool overrideState = false) : base(value, overrideState)
		{
		}

		// Token: 0x06000812 RID: 2066 RVA: 0x00026834 File Offset: 0x00024A34
		public sealed override void Interp(float from, float to, float t)
		{
			this.m_Value = from + (to - from) * t;
		}
	}
}
