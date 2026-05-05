using System;
using System.Diagnostics;

namespace UnityEngine.Rendering
{
	// Token: 0x020000FE RID: 254
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public class MaxFloatParameter : FloatParameter
	{
		// Token: 0x17000138 RID: 312
		// (get) Token: 0x0600081A RID: 2074 RVA: 0x000268A7 File Offset: 0x00024AA7
		// (set) Token: 0x0600081B RID: 2075 RVA: 0x000268AF File Offset: 0x00024AAF
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

		// Token: 0x0600081C RID: 2076 RVA: 0x000268C3 File Offset: 0x00024AC3
		public MaxFloatParameter(float value, float max, bool overrideState = false) : base(value, overrideState)
		{
			this.max = max;
		}

		// Token: 0x040004E7 RID: 1255
		[NonSerialized]
		public float max;
	}
}
