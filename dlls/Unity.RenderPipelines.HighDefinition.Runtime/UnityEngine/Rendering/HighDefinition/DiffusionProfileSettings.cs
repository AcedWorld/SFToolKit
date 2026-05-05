using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000100 RID: 256
	public sealed class DiffusionProfileSettings : ScriptableObject, IVersionable<DiffusionProfileSettings.Version>
	{
		// Token: 0x17000175 RID: 373
		// (get) Token: 0x060009F8 RID: 2552 RVA: 0x00055957 File Offset: 0x00053B57
		// (set) Token: 0x060009F9 RID: 2553 RVA: 0x00055974 File Offset: 0x00053B74
		public Color scatteringDistance
		{
			get
			{
				return this.profile.scatteringDistance * this.profile.scatteringDistanceMultiplier;
			}
			set
			{
				HDUtils.ConvertHDRColorToLDR(value, out this.profile.scatteringDistance, out this.profile.scatteringDistanceMultiplier);
				this.profile.Validate();
				this.UpdateCache();
			}
		}

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x060009FA RID: 2554 RVA: 0x000559A3 File Offset: 0x00053BA3
		public float maximumRadius
		{
			get
			{
				return this.profile.filterRadius;
			}
		}

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x060009FB RID: 2555 RVA: 0x000559B0 File Offset: 0x00053BB0
		// (set) Token: 0x060009FC RID: 2556 RVA: 0x000559BD File Offset: 0x00053BBD
		public float indexOfRefraction
		{
			get
			{
				return this.profile.ior;
			}
			set
			{
				this.profile.ior = value;
				this.profile.Validate();
				this.UpdateCache();
			}
		}

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x060009FD RID: 2557 RVA: 0x000559DC File Offset: 0x00053BDC
		// (set) Token: 0x060009FE RID: 2558 RVA: 0x000559E9 File Offset: 0x00053BE9
		public float worldScale
		{
			get
			{
				return this.profile.worldScale;
			}
			set
			{
				this.profile.worldScale = value;
				this.profile.Validate();
				this.UpdateCache();
			}
		}

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x060009FF RID: 2559 RVA: 0x00055A08 File Offset: 0x00053C08
		// (set) Token: 0x06000A00 RID: 2560 RVA: 0x00055A15 File Offset: 0x00053C15
		public Color transmissionTint
		{
			get
			{
				return this.profile.transmissionTint;
			}
			set
			{
				this.profile.transmissionTint = value;
				this.profile.Validate();
				this.UpdateCache();
			}
		}

		// Token: 0x06000A01 RID: 2561 RVA: 0x00055A34 File Offset: 0x00053C34
		private void OnEnable()
		{
			if (this.profile == null)
			{
				this.profile = new DiffusionProfile(true);
			}
			this.profile.Validate();
			this.UpdateCache();
		}

		// Token: 0x06000A02 RID: 2562 RVA: 0x00055A5C File Offset: 0x00053C5C
		internal void UpdateCache()
		{
			this.worldScaleAndFilterRadiusAndThicknessRemap = new Vector4(this.profile.worldScale, this.profile.filterRadius, this.profile.thicknessRemap.x, this.profile.thicknessRemap.y - this.profile.thicknessRemap.x);
			this.shapeParamAndMaxScatterDist = this.profile.shapeParam;
			this.shapeParamAndMaxScatterDist.w = this.profile.maxScatteringDistance;
			float num = (this.profile.ior - 1f) / (this.profile.ior + 1f);
			num *= num;
			this.transmissionTintAndFresnel0 = new Vector4(this.profile.transmissionTint.r * 0.25f, this.profile.transmissionTint.g * 0.25f, this.profile.transmissionTint.b * 0.25f, num);
			this.disabledTransmissionTintAndFresnel0 = new Vector4(0f, 0f, 0f, num);
			this.updateCount++;
		}

		// Token: 0x06000A03 RID: 2563 RVA: 0x00055B86 File Offset: 0x00053D86
		internal bool HasChanged(int update)
		{
			return update == this.updateCount;
		}

		// Token: 0x06000A04 RID: 2564 RVA: 0x00055B94 File Offset: 0x00053D94
		internal void SetDefaultParams()
		{
			this.worldScaleAndFilterRadiusAndThicknessRemap = new Vector4(1f, 0f, 0f, 1f);
			this.shapeParamAndMaxScatterDist = new Vector4(16777216f, 16777216f, 16777216f, 0f);
			this.transmissionTintAndFresnel0.w = 0.04f;
		}

		// Token: 0x1700017A RID: 378
		[Obsolete("Profiles are obsolete, only one diffusion profile per asset is allowed.")]
		internal DiffusionProfile this[int index]
		{
			get
			{
				return this.profile;
			}
		}

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x06000A06 RID: 2566 RVA: 0x00055BF7 File Offset: 0x00053DF7
		// (set) Token: 0x06000A07 RID: 2567 RVA: 0x00055BFF File Offset: 0x00053DFF
		DiffusionProfileSettings.Version IVersionable<DiffusionProfileSettings.Version>.version
		{
			get
			{
				return this.m_Version;
			}
			set
			{
				this.m_Version = value;
			}
		}

		// Token: 0x04000ACE RID: 2766
		[SerializeField]
		internal DiffusionProfile profile;

		// Token: 0x04000ACF RID: 2767
		[NonSerialized]
		internal Vector4 worldScaleAndFilterRadiusAndThicknessRemap;

		// Token: 0x04000AD0 RID: 2768
		[NonSerialized]
		internal Vector4 shapeParamAndMaxScatterDist;

		// Token: 0x04000AD1 RID: 2769
		[NonSerialized]
		internal Vector4 transmissionTintAndFresnel0;

		// Token: 0x04000AD2 RID: 2770
		[NonSerialized]
		internal Vector4 disabledTransmissionTintAndFresnel0;

		// Token: 0x04000AD3 RID: 2771
		[NonSerialized]
		internal int updateCount;

		// Token: 0x04000AD4 RID: 2772
		[SerializeField]
		private DiffusionProfileSettings.Version m_Version = MigrationDescription.LastVersion<DiffusionProfileSettings.Version>();

		// Token: 0x04000AD5 RID: 2773
		[Obsolete("Profiles are obsolete, only one diffusion profile per asset is allowed.")]
		internal DiffusionProfile[] profiles;

		// Token: 0x04000AD6 RID: 2774
		private static readonly MigrationDescription<DiffusionProfileSettings.Version, DiffusionProfileSettings> k_Migration = MigrationDescription.New<DiffusionProfileSettings.Version, DiffusionProfileSettings>(new MigrationStep<DiffusionProfileSettings.Version, DiffusionProfileSettings>[]
		{
			MigrationStep.New<DiffusionProfileSettings.Version, DiffusionProfileSettings>(DiffusionProfileSettings.Version.DiffusionProfileRework, delegate(DiffusionProfileSettings d)
			{
			}),
			MigrationStep.New<DiffusionProfileSettings.Version, DiffusionProfileSettings>(DiffusionProfileSettings.Version.SplitScatteringDistance, delegate(DiffusionProfileSettings d)
			{
				d.scatteringDistance = d.profile.scatteringDistance;
			})
		});

		// Token: 0x02000384 RID: 900
		private enum Version
		{
			// Token: 0x0400247C RID: 9340
			Initial,
			// Token: 0x0400247D RID: 9341
			DiffusionProfileRework,
			// Token: 0x0400247E RID: 9342
			SplitScatteringDistance
		}
	}
}
