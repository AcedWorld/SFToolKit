using System;
using System.Diagnostics;

namespace UnityEngine.Rendering
{
	// Token: 0x02000100 RID: 256
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public class ClampedFloatParameter : FloatParameter
	{
		// Token: 0x1700013A RID: 314
		// (get) Token: 0x06000820 RID: 2080 RVA: 0x00026901 File Offset: 0x00024B01
		// (set) Token: 0x06000821 RID: 2081 RVA: 0x00026909 File Offset: 0x00024B09
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

		// Token: 0x06000822 RID: 2082 RVA: 0x00026923 File Offset: 0x00024B23
		public ClampedFloatParameter(float value, float min, float max, bool overrideState = false) : base(value, overrideState)
		{
			this.min = min;
			this.max = max;
		}

		// Token: 0x040004E9 RID: 1257
		[NonSerialized]
		public float min;

		// Token: 0x040004EA RID: 1258
		[NonSerialized]
		public float max;
	}
}
