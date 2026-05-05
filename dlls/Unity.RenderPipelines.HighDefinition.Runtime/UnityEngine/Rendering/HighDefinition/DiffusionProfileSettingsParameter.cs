using System;
using System.Buffers;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000066 RID: 102
	[Serializable]
	public sealed class DiffusionProfileSettingsParameter : VolumeParameter<DiffusionProfileSettings[]>
	{
		// Token: 0x06000272 RID: 626 RVA: 0x0000E51B File Offset: 0x0000C71B
		public DiffusionProfileSettingsParameter(DiffusionProfileSettings[] value, bool overrideState = true) : base(value, overrideState)
		{
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0000E528 File Offset: 0x0000C728
		private void AddProfile(DiffusionProfileSettings profile)
		{
			if (profile == null)
			{
				return;
			}
			for (int i = 0; i < this.accumulatedCount; i++)
			{
				if (profile == this.m_Value[i])
				{
					return;
				}
			}
			DiffusionProfileSettings[] value = this.m_Value;
			int num = this.accumulatedCount;
			this.accumulatedCount = num + 1;
			value[num] = profile;
		}

		// Token: 0x06000274 RID: 628 RVA: 0x0000E57C File Offset: 0x0000C77C
		public override void Interp(DiffusionProfileSettings[] from, DiffusionProfileSettings[] to, float t)
		{
			this.m_Value = DiffusionProfileSettingsParameter.s_ArrayPool.Rent(16);
			this.accumulatedCount = 0;
			DiffusionProfileSettings[] value = this.m_Value;
			int i = this.accumulatedCount;
			this.accumulatedCount = i + 1;
			int num = i;
			HDRenderPipeline currentPipeline = HDRenderPipeline.currentPipeline;
			value[num] = ((currentPipeline != null) ? currentPipeline.defaultDiffusionProfile : null);
			if (to != null)
			{
				foreach (DiffusionProfileSettings profile in to)
				{
					this.AddProfile(profile);
					if (this.accumulatedCount >= 16)
					{
						break;
					}
				}
			}
			if (from != null)
			{
				foreach (DiffusionProfileSettings profile2 in from)
				{
					this.AddProfile(profile2);
					if (this.accumulatedCount >= 16)
					{
						break;
					}
				}
			}
			for (int j = this.accumulatedCount; j < this.m_Value.Length; j++)
			{
				this.m_Value[j] = null;
			}
			if (this.accumulatedArray != null)
			{
				DiffusionProfileSettingsParameter.s_ArrayPool.Return(this.accumulatedArray, false);
			}
			this.accumulatedArray = this.m_Value;
		}

		// Token: 0x06000275 RID: 629 RVA: 0x0000E666 File Offset: 0x0000C866
		public override void Release()
		{
			if (this.accumulatedArray != null)
			{
				DiffusionProfileSettingsParameter.s_ArrayPool.Return(this.accumulatedArray, false);
			}
			this.accumulatedArray = null;
		}

		// Token: 0x040002A0 RID: 672
		private static ArrayPool<DiffusionProfileSettings> s_ArrayPool = ArrayPool<DiffusionProfileSettings>.Create(16, 5);

		// Token: 0x040002A1 RID: 673
		internal DiffusionProfileSettings[] accumulatedArray;

		// Token: 0x040002A2 RID: 674
		internal int accumulatedCount;
	}
}
