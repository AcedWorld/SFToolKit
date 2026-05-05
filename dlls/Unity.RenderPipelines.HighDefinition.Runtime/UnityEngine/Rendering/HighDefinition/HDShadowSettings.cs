using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000D4 RID: 212
	[VolumeComponentMenuForRenderPipeline("Shadowing/Shadows", new Type[]
	{
		typeof(HDRenderPipeline)
	})]
	[Serializable]
	public class HDShadowSettings : VolumeComponent, ISerializationCallbackReceiver
	{
		// Token: 0x1700014E RID: 334
		// (get) Token: 0x0600091A RID: 2330 RVA: 0x00050610 File Offset: 0x0004E810
		public float[] cascadeShadowSplits
		{
			get
			{
				this.m_CascadeShadowSplits[0] = this.cascadeShadowSplit0.value;
				this.m_CascadeShadowSplits[1] = this.cascadeShadowSplit1.value;
				this.m_CascadeShadowSplits[2] = this.cascadeShadowSplit2.value;
				return this.m_CascadeShadowSplits;
			}
		}

		// Token: 0x0600091B RID: 2331 RVA: 0x0005065C File Offset: 0x0004E85C
		internal float InterCascadeToSqRangeBorder(float interCascadeBorder, float prevCascadeRelRange, float cascadeRelRange)
		{
			float num = (cascadeRelRange >= 0f) ? ((cascadeRelRange - prevCascadeRelRange) * interCascadeBorder / cascadeRelRange) : 0f;
			return 1f - (1f - num) * (1f - num);
		}

		// Token: 0x0600091C RID: 2332 RVA: 0x00050698 File Offset: 0x0004E898
		internal float SqRangeBorderToInterCascade(float sqRangeBorder, float prevCascadeRelRange, float cascadeRelRange)
		{
			float num = cascadeRelRange - prevCascadeRelRange;
			if (num <= 0f)
			{
				return 0f;
			}
			return Mathf.Clamp01((1f - Mathf.Sqrt(1f - sqRangeBorder)) * cascadeRelRange / num);
		}

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x0600091D RID: 2333 RVA: 0x000506D4 File Offset: 0x0004E8D4
		public float[] cascadeShadowBorders
		{
			get
			{
				int value = this.cascadeShadowSplitCount.value;
				this.m_CascadeShadowBorders[0] = this.InterCascadeToSqRangeBorder(this.cascadeShadowBorder0.value, 0f, (value > 1) ? this.cascadeShadowSplit0.value : 1f);
				this.m_CascadeShadowBorders[1] = this.InterCascadeToSqRangeBorder(this.cascadeShadowBorder1.value, this.cascadeShadowSplit0.value, (value > 2) ? this.cascadeShadowSplit1.value : 1f);
				this.m_CascadeShadowBorders[2] = this.InterCascadeToSqRangeBorder(this.cascadeShadowBorder2.value, this.cascadeShadowSplit1.value, (value > 3) ? this.cascadeShadowSplit2.value : 1f);
				this.m_CascadeShadowBorders[3] = this.InterCascadeToSqRangeBorder(this.cascadeShadowBorder3.value, this.cascadeShadowSplit2.value, 1f);
				if (!HDRenderPipeline.s_UseCascadeBorders)
				{
					this.m_CascadeShadowBorders[this.cascadeShadowSplitCount.value - 1] = 0.2f;
				}
				return this.m_CascadeShadowBorders;
			}
		}

		// Token: 0x0600091E RID: 2334 RVA: 0x000507E4 File Offset: 0x0004E9E4
		public void OnBeforeSerialize()
		{
			this.interCascadeBorders = true;
		}

		// Token: 0x0600091F RID: 2335 RVA: 0x000507F0 File Offset: 0x0004E9F0
		public void OnAfterDeserialize()
		{
			if (!this.interCascadeBorders)
			{
				int value = this.cascadeShadowSplitCount.value;
				this.cascadeShadowBorder0.value = this.SqRangeBorderToInterCascade(this.cascadeShadowBorder0.value, 0f, (value > 1) ? this.cascadeShadowSplit0.value : 1f);
				this.cascadeShadowBorder1.value = this.SqRangeBorderToInterCascade(this.cascadeShadowBorder1.value, this.cascadeShadowSplit0.value, (value > 2) ? this.cascadeShadowSplit1.value : 1f);
				this.cascadeShadowBorder2.value = this.SqRangeBorderToInterCascade(this.cascadeShadowBorder2.value, this.cascadeShadowSplit1.value, (value > 3) ? this.cascadeShadowSplit2.value : 1f);
				this.cascadeShadowBorder3.value = this.SqRangeBorderToInterCascade(this.cascadeShadowBorder3.value, this.cascadeShadowSplit2.value, 1f);
			}
		}

		// Token: 0x06000920 RID: 2336 RVA: 0x000508F4 File Offset: 0x0004EAF4
		private HDShadowSettings()
		{
			base.displayName = "Shadows";
			this.cascadeShadowSplit0.Init(this.cascadeShadowSplitCount, 2, this.maxShadowDistance, null, this.cascadeShadowSplit1);
			this.cascadeShadowSplit1.Init(this.cascadeShadowSplitCount, 3, this.maxShadowDistance, this.cascadeShadowSplit0, this.cascadeShadowSplit2);
			this.cascadeShadowSplit2.Init(this.cascadeShadowSplitCount, 4, this.maxShadowDistance, this.cascadeShadowSplit1, null);
			this.cascadeShadowBorder0.Init(this.cascadeShadowSplitCount, 1, this.maxShadowDistance, null, this.cascadeShadowSplit0);
			this.cascadeShadowBorder1.Init(this.cascadeShadowSplitCount, 2, this.maxShadowDistance, this.cascadeShadowSplit0, this.cascadeShadowSplit1);
			this.cascadeShadowBorder2.Init(this.cascadeShadowSplitCount, 3, this.maxShadowDistance, this.cascadeShadowSplit1, this.cascadeShadowSplit2);
			this.cascadeShadowBorder3.Init(this.cascadeShadowSplitCount, 4, this.maxShadowDistance, this.cascadeShadowSplit2, null);
		}

		// Token: 0x06000921 RID: 2337 RVA: 0x00050AD0 File Offset: 0x0004ECD0
		internal void InitNormalized(bool normalized)
		{
			this.cascadeShadowSplit0.normalized = normalized;
			this.cascadeShadowSplit1.normalized = normalized;
			this.cascadeShadowSplit2.normalized = normalized;
			this.cascadeShadowBorder0.normalized = normalized;
			this.cascadeShadowBorder1.normalized = normalized;
			this.cascadeShadowBorder2.normalized = normalized;
			this.cascadeShadowBorder3.normalized = normalized;
		}

		// Token: 0x0400091E RID: 2334
		private float[] m_CascadeShadowSplits = new float[3];

		// Token: 0x0400091F RID: 2335
		private float[] m_CascadeShadowBorders = new float[4];

		// Token: 0x04000920 RID: 2336
		[SerializeField]
		private bool interCascadeBorders;

		// Token: 0x04000921 RID: 2337
		[Tooltip("Sets the maximum distance HDRP renders shadows for all Light types.")]
		public NoInterpMinFloatParameter maxShadowDistance = new NoInterpMinFloatParameter(500f, 0f, false);

		// Token: 0x04000922 RID: 2338
		[Tooltip("Multiplier for thick transmission.")]
		public ClampedFloatParameter directionalTransmissionMultiplier = new ClampedFloatParameter(1f, 0f, 1f, false);

		// Token: 0x04000923 RID: 2339
		[Tooltip("Controls the number of cascades HDRP uses for cascaded shadow maps.")]
		public NoInterpClampedIntParameter cascadeShadowSplitCount = new NoInterpClampedIntParameter(4, 1, 4, false);

		// Token: 0x04000924 RID: 2340
		[Tooltip("Sets the position of the first cascade split as a percentage of Max Distance if the parameter is normalized or as the distance from the camera if it's not normalized.")]
		public CascadePartitionSplitParameter cascadeShadowSplit0 = new CascadePartitionSplitParameter(0.05f, false, false);

		// Token: 0x04000925 RID: 2341
		[Tooltip("Sets the position of the second cascade split as a percentage of Max Distance if the parameter is normalized or as the distance from the camera if it's not normalized.")]
		public CascadePartitionSplitParameter cascadeShadowSplit1 = new CascadePartitionSplitParameter(0.15f, false, false);

		// Token: 0x04000926 RID: 2342
		[Tooltip("Sets the position of the third cascade split as a percentage of Max Distance if the parameter is normalized or as the distance from the camera if it's not normalized.")]
		public CascadePartitionSplitParameter cascadeShadowSplit2 = new CascadePartitionSplitParameter(0.3f, false, false);

		// Token: 0x04000927 RID: 2343
		[Tooltip("Sets the border size between the first and second cascade split.")]
		public CascadeEndBorderParameter cascadeShadowBorder0 = new CascadeEndBorderParameter(0f, false, false);

		// Token: 0x04000928 RID: 2344
		[Tooltip("Sets the border size between the second and third cascade split.")]
		public CascadeEndBorderParameter cascadeShadowBorder1 = new CascadeEndBorderParameter(0f, false, false);

		// Token: 0x04000929 RID: 2345
		[Tooltip("Sets the border size between the third and last cascade split.")]
		public CascadeEndBorderParameter cascadeShadowBorder2 = new CascadeEndBorderParameter(0f, false, false);

		// Token: 0x0400092A RID: 2346
		[Tooltip("Sets the border size at the end of the last cascade split.")]
		public CascadeEndBorderParameter cascadeShadowBorder3 = new CascadeEndBorderParameter(0f, false, false);
	}
}
