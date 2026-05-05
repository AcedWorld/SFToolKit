using System;
using System.Diagnostics;

namespace UnityEngine.Rendering
{
	// Token: 0x020000FF RID: 255
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public class NoInterpMaxFloatParameter : VolumeParameter<float>
	{
		// Token: 0x17000139 RID: 313
		// (get) Token: 0x0600081D RID: 2077 RVA: 0x000268D4 File Offset: 0x00024AD4
		// (set) Token: 0x0600081E RID: 2078 RVA: 0x000268DC File Offset: 0x00024ADC
		public override float value
		{
			get
			{
				return this.m_Value;
			}
			set
			{
				this.m_Value = Mathf.Min(value, this.max);
			}
		}

		// Token: 0x0600081F RID: 2079 RVA: 0x000268F0 File Offset: 0x00024AF0
		public NoInterpMaxFloatParameter(float value, float max, bool overrideState = false) : base(value, overrideState)
		{
			this.max = max;
		}

		// Token: 0x040004E8 RID: 1256
		[NonSerialized]
		public float max;
	}
}
