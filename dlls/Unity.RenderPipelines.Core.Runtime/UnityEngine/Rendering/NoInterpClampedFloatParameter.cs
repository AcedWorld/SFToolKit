using System;
using System.Diagnostics;

namespace UnityEngine.Rendering
{
	// Token: 0x02000101 RID: 257
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public class NoInterpClampedFloatParameter : VolumeParameter<float>
	{
		// Token: 0x1700013B RID: 315
		// (get) Token: 0x06000823 RID: 2083 RVA: 0x0002693C File Offset: 0x00024B3C
		// (set) Token: 0x06000824 RID: 2084 RVA: 0x00026944 File Offset: 0x00024B44
		public override float value
		{
			get
			{
				return this.m_Value;
			}
			set
			{
				this.m_Value = Mathf.Clamp(value, this.min, this.max);
			}
		}

		// Token: 0x06000825 RID: 2085 RVA: 0x0002695E File Offset: 0x00024B5E
		public NoInterpClampedFloatParameter(float value, float min, float max, bool overrideState = false) : base(value, overrideState)
		{
			this.min = min;
			this.max = max;
		}

		// Token: 0x040004EB RID: 1259
		[NonSerialized]
		public float min;

		// Token: 0x040004EC RID: 1260
		[NonSerialized]
		public float max;
	}
}
