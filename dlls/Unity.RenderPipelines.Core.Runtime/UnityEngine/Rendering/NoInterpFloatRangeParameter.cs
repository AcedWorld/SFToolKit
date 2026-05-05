using System;
using System.Diagnostics;

namespace UnityEngine.Rendering
{
	// Token: 0x02000103 RID: 259
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public class NoInterpFloatRangeParameter : VolumeParameter<Vector2>
	{
		// Token: 0x1700013D RID: 317
		// (get) Token: 0x0600082A RID: 2090 RVA: 0x00026A23 File Offset: 0x00024C23
		// (set) Token: 0x0600082B RID: 2091 RVA: 0x00026A2B File Offset: 0x00024C2B
		public override Vector2 value
		{
			get
			{
				return this.m_Value;
			}
			set
			{
				this.m_Value.x = Mathf.Max(value.x, this.min);
				this.m_Value.y = Mathf.Min(value.y, this.max);
			}
		}

		// Token: 0x0600082C RID: 2092 RVA: 0x00026A65 File Offset: 0x00024C65
		public NoInterpFloatRangeParameter(Vector2 value, float min, float max, bool overrideState = false) : base(value, overrideState)
		{
			this.min = min;
			this.max = max;
		}

		// Token: 0x040004EF RID: 1263
		[NonSerialized]
		public float min;

		// Token: 0x040004F0 RID: 1264
		[NonSerialized]
		public float max;
	}
}
