using System;
using System.Diagnostics;

namespace UnityEngine.Rendering
{
	// Token: 0x02000102 RID: 258
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public class FloatRangeParameter : VolumeParameter<Vector2>
	{
		// Token: 0x1700013C RID: 316
		// (get) Token: 0x06000826 RID: 2086 RVA: 0x00026977 File Offset: 0x00024B77
		// (set) Token: 0x06000827 RID: 2087 RVA: 0x0002697F File Offset: 0x00024B7F
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

		// Token: 0x06000828 RID: 2088 RVA: 0x000269B9 File Offset: 0x00024BB9
		public FloatRangeParameter(Vector2 value, float min, float max, bool overrideState = false) : base(value, overrideState)
		{
			this.min = min;
			this.max = max;
		}

		// Token: 0x06000829 RID: 2089 RVA: 0x000269D4 File Offset: 0x00024BD4
		public override void Interp(Vector2 from, Vector2 to, float t)
		{
			this.m_Value.x = from.x + (to.x - from.x) * t;
			this.m_Value.y = from.y + (to.y - from.y) * t;
		}

		// Token: 0x040004ED RID: 1261
		[NonSerialized]
		public float min;

		// Token: 0x040004EE RID: 1262
		[NonSerialized]
		public float max;
	}
}
