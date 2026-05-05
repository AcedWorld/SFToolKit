using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000D6 RID: 214
	[Serializable]
	public class CascadeEndBorderParameter : VolumeParameter<float>
	{
		// Token: 0x17000154 RID: 340
		// (get) Token: 0x06000929 RID: 2345 RVA: 0x00050BE0 File Offset: 0x0004EDE0
		internal float representationDistance
		{
			get
			{
				float num = (this.cascadeCounts.value > this.minCascadeToAppears && this.max != null) ? this.max.value : 1f;
				CascadePartitionSplitParameter cascadePartitionSplitParameter = this.min;
				return (num - ((cascadePartitionSplitParameter != null) ? cascadePartitionSplitParameter.value : 0f)) * this.maxDistance.value;
			}
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x0600092A RID: 2346 RVA: 0x00050C3D File Offset: 0x0004EE3D
		// (set) Token: 0x0600092B RID: 2347 RVA: 0x00050C45 File Offset: 0x0004EE45
		public override float value
		{
			get
			{
				return this.m_Value;
			}
			set
			{
				this.m_Value = Mathf.Clamp01(value);
			}
		}

		// Token: 0x0600092C RID: 2348 RVA: 0x00050C53 File Offset: 0x0004EE53
		public CascadeEndBorderParameter(float value, bool normalized = false, bool overrideState = false) : base(value, overrideState)
		{
			this.normalized = normalized;
		}

		// Token: 0x0600092D RID: 2349 RVA: 0x00050C64 File Offset: 0x0004EE64
		internal void Init(NoInterpClampedIntParameter cascadeCounts, int minCascadeToAppears, NoInterpMinFloatParameter maxDistance, CascadePartitionSplitParameter min, CascadePartitionSplitParameter max)
		{
			this.maxDistance = maxDistance;
			this.min = min;
			this.max = max;
			this.cascadeCounts = cascadeCounts;
			this.minCascadeToAppears = minCascadeToAppears;
		}

		// Token: 0x04000931 RID: 2353
		internal bool normalized;

		// Token: 0x04000932 RID: 2354
		[NonSerialized]
		private CascadePartitionSplitParameter min;

		// Token: 0x04000933 RID: 2355
		[NonSerialized]
		private CascadePartitionSplitParameter max;

		// Token: 0x04000934 RID: 2356
		[NonSerialized]
		private NoInterpMinFloatParameter maxDistance;

		// Token: 0x04000935 RID: 2357
		[NonSerialized]
		private NoInterpClampedIntParameter cascadeCounts;

		// Token: 0x04000936 RID: 2358
		private int minCascadeToAppears;
	}
}
