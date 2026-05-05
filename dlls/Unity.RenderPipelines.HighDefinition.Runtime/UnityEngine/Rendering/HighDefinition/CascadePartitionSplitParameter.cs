using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000D5 RID: 213
	[Serializable]
	public class CascadePartitionSplitParameter : VolumeParameter<float>
	{
		// Token: 0x17000150 RID: 336
		// (get) Token: 0x06000922 RID: 2338 RVA: 0x00050B31 File Offset: 0x0004ED31
		internal float min
		{
			get
			{
				CascadePartitionSplitParameter cascadePartitionSplitParameter = this.previous;
				if (cascadePartitionSplitParameter == null)
				{
					return 0f;
				}
				return cascadePartitionSplitParameter.value;
			}
		}

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x06000923 RID: 2339 RVA: 0x00050B48 File Offset: 0x0004ED48
		internal float max
		{
			get
			{
				if (this.cascadeCounts.value <= this.minCascadeToAppears || this.next == null)
				{
					return 1f;
				}
				return this.next.value;
			}
		}

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x06000924 RID: 2340 RVA: 0x00050B76 File Offset: 0x0004ED76
		internal float representationDistance
		{
			get
			{
				return this.maxDistance.value;
			}
		}

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x06000925 RID: 2341 RVA: 0x00050B83 File Offset: 0x0004ED83
		// (set) Token: 0x06000926 RID: 2342 RVA: 0x00050B8B File Offset: 0x0004ED8B
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

		// Token: 0x06000927 RID: 2343 RVA: 0x00050BA5 File Offset: 0x0004EDA5
		public CascadePartitionSplitParameter(float value, bool normalized = false, bool overrideState = false) : base(value, overrideState)
		{
			this.normalized = normalized;
		}

		// Token: 0x06000928 RID: 2344 RVA: 0x00050BB6 File Offset: 0x0004EDB6
		internal void Init(NoInterpClampedIntParameter cascadeCounts, int minCascadeToAppears, NoInterpMinFloatParameter maxDistance, CascadePartitionSplitParameter previous, CascadePartitionSplitParameter next)
		{
			this.maxDistance = maxDistance;
			this.previous = previous;
			this.next = next;
			this.cascadeCounts = cascadeCounts;
			this.minCascadeToAppears = minCascadeToAppears;
		}

		// Token: 0x0400092B RID: 2347
		[NonSerialized]
		private NoInterpMinFloatParameter maxDistance;

		// Token: 0x0400092C RID: 2348
		internal bool normalized;

		// Token: 0x0400092D RID: 2349
		[NonSerialized]
		private CascadePartitionSplitParameter previous;

		// Token: 0x0400092E RID: 2350
		[NonSerialized]
		private CascadePartitionSplitParameter next;

		// Token: 0x0400092F RID: 2351
		[NonSerialized]
		private NoInterpClampedIntParameter cascadeCounts;

		// Token: 0x04000930 RID: 2352
		private int minCascadeToAppears;
	}
}
