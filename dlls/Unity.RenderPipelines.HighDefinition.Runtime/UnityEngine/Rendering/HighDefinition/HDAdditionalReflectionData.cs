using System;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000A2 RID: 162
	[AddComponentMenu("")]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(ReflectionProbe))]
	public sealed class HDAdditionalReflectionData : HDProbe, IAdditionalData, IVersionable<HDAdditionalReflectionData.ReflectionProbeVersion>
	{
		// Token: 0x06000755 RID: 1877 RVA: 0x00048498 File Offset: 0x00046698
		private void Awake()
		{
			base.type = ProbeSettings.ProbeType.ReflectionProbe;
			HDAdditionalReflectionData.k_ReflectionProbeMigration.Migrate(this);
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x06000756 RID: 1878 RVA: 0x000484BB File Offset: 0x000466BB
		private ReflectionProbe reflectionProbe
		{
			get
			{
				if (this.m_LegacyProbe == null || this.m_LegacyProbe.Equals(null))
				{
					this.m_LegacyProbe = base.GetComponent<ReflectionProbe>();
				}
				return this.m_LegacyProbe;
			}
		}

		// Token: 0x06000757 RID: 1879 RVA: 0x000484EC File Offset: 0x000466EC
		public override void PrepareCulling()
		{
			base.PrepareCulling();
			InfluenceVolume influence = base.settings.influence;
			Transform transform = base.transform;
			Vector3 position = transform.position;
			ReflectionProbe reflectionProbe = this.reflectionProbe;
			if (reflectionProbe == null || reflectionProbe.Equals(null))
			{
				return;
			}
			InfluenceShape shape = influence.shape;
			if (shape != InfluenceShape.Box)
			{
				if (shape == InfluenceShape.Sphere)
				{
					reflectionProbe.size = Vector3.one * (2f * influence.sphereRadius);
					reflectionProbe.center = Vector3.zero;
				}
			}
			else
			{
				reflectionProbe.size = influence.boxSize;
				reflectionProbe.center = Vector3.zero;
			}
			transform.position = position;
			reflectionProbe.mode = ReflectionProbeMode.Custom;
			reflectionProbe.refreshMode = ReflectionProbeRefreshMode.ViaScripting;
			if (this.m_ProbeSettings.mode == ProbeSettings.Mode.Realtime)
			{
				reflectionProbe.renderDynamicObjects = true;
			}
		}

		// Token: 0x06000758 RID: 1880 RVA: 0x000485B0 File Offset: 0x000467B0
		internal bool ReflectionProbeIsEnabled()
		{
			return this.reflectionProbe.enabled;
		}

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x06000759 RID: 1881 RVA: 0x000485BD File Offset: 0x000467BD
		// (set) Token: 0x0600075A RID: 1882 RVA: 0x000485C5 File Offset: 0x000467C5
		HDAdditionalReflectionData.ReflectionProbeVersion IVersionable<HDAdditionalReflectionData.ReflectionProbeVersion>.version
		{
			get
			{
				return (HDAdditionalReflectionData.ReflectionProbeVersion)this.m_ReflectionProbeVersion;
			}
			set
			{
				this.m_ReflectionProbeVersion = (int)value;
			}
		}

		// Token: 0x04000752 RID: 1874
		private ReflectionProbe m_LegacyProbe;

		// Token: 0x04000753 RID: 1875
		private static readonly MigrationDescription<HDAdditionalReflectionData.ReflectionProbeVersion, HDAdditionalReflectionData> k_ReflectionProbeMigration = MigrationDescription.New<HDAdditionalReflectionData.ReflectionProbeVersion, HDAdditionalReflectionData>(new MigrationStep<HDAdditionalReflectionData.ReflectionProbeVersion, HDAdditionalReflectionData>[]
		{
			MigrationStep.New<HDAdditionalReflectionData.ReflectionProbeVersion, HDAdditionalReflectionData>(HDAdditionalReflectionData.ReflectionProbeVersion.RemoveUsageOfLegacyProbeParamsForStocking, delegate(HDAdditionalReflectionData t)
			{
				t.m_ObsoleteBlendDistancePositive = (t.m_ObsoleteBlendDistanceNegative = Vector3.one * t.reflectionProbe.blendDistance);
				t.m_ObsoleteWeight = (float)t.reflectionProbe.importance;
				t.m_ObsoleteMultiplier = t.reflectionProbe.intensity;
				ReflectionProbeRefreshMode refreshMode = t.reflectionProbe.refreshMode;
				if (refreshMode != ReflectionProbeRefreshMode.OnAwake)
				{
					if (refreshMode == ReflectionProbeRefreshMode.EveryFrame)
					{
						t.realtimeMode = ProbeSettings.RealtimeMode.EveryFrame;
						return;
					}
				}
				else
				{
					t.realtimeMode = ProbeSettings.RealtimeMode.OnEnable;
				}
			}),
			MigrationStep.New<HDAdditionalReflectionData.ReflectionProbeVersion, HDAdditionalReflectionData>(HDAdditionalReflectionData.ReflectionProbeVersion.UseInfluenceVolume, delegate(HDAdditionalReflectionData t)
			{
				t.m_ObsoleteInfluenceVolume = (t.m_ObsoleteInfluenceVolume ?? new InfluenceVolume());
				t.m_ObsoleteInfluenceVolume.boxSize = t.reflectionProbe.size;
				t.m_ObsoleteInfluenceVolume.obsoleteOffset = t.reflectionProbe.center;
				t.m_ObsoleteInfluenceVolume.sphereRadius = t.m_ObsoleteInfluenceSphereRadius;
				t.m_ObsoleteInfluenceVolume.shape = t.m_ObsoleteInfluenceShape;
				t.m_ObsoleteInfluenceVolume.boxBlendDistancePositive = t.m_ObsoleteBlendDistancePositive;
				t.m_ObsoleteInfluenceVolume.boxBlendDistanceNegative = t.m_ObsoleteBlendDistanceNegative;
				t.m_ObsoleteInfluenceVolume.boxBlendNormalDistancePositive = t.m_ObsoleteBlendNormalDistancePositive;
				t.m_ObsoleteInfluenceVolume.boxBlendNormalDistanceNegative = t.m_ObsoleteBlendNormalDistanceNegative;
				t.m_ObsoleteInfluenceVolume.boxSideFadePositive = t.m_ObsoleteBoxSideFadePositive;
				t.m_ObsoleteInfluenceVolume.boxSideFadeNegative = t.m_ObsoleteBoxSideFadeNegative;
			}),
			MigrationStep.New<HDAdditionalReflectionData.ReflectionProbeVersion, HDAdditionalReflectionData>(HDAdditionalReflectionData.ReflectionProbeVersion.MergeEditors, delegate(HDAdditionalReflectionData t)
			{
				t.m_ObsoleteInfiniteProjection = !t.reflectionProbe.boxProjection;
				t.reflectionProbe.boxProjection = false;
			}),
			MigrationStep.New<HDAdditionalReflectionData.ReflectionProbeVersion, HDAdditionalReflectionData>(HDAdditionalReflectionData.ReflectionProbeVersion.AddCaptureSettingsAndFrameSettings, delegate(HDAdditionalReflectionData t)
			{
				t.m_ObsoleteCaptureSettings = (t.m_ObsoleteCaptureSettings ?? new ObsoleteCaptureSettings());
				t.m_ObsoleteCaptureSettings.cullingMask = t.reflectionProbe.cullingMask;
				t.m_ObsoleteCaptureSettings.nearClipPlane = t.reflectionProbe.nearClipPlane;
				t.m_ObsoleteCaptureSettings.farClipPlane = t.reflectionProbe.farClipPlane;
			}),
			MigrationStep.New<HDAdditionalReflectionData.ReflectionProbeVersion, HDAdditionalReflectionData>(HDAdditionalReflectionData.ReflectionProbeVersion.ModeAndTextures, delegate(HDAdditionalReflectionData t)
			{
				t.m_ObsoleteMode = (ProbeSettings.Mode)t.reflectionProbe.mode;
				t.SetTexture(ProbeSettings.Mode.Baked, t.reflectionProbe.bakedTexture);
				t.SetTexture(ProbeSettings.Mode.Custom, t.reflectionProbe.customBakedTexture);
			}),
			MigrationStep.New<HDAdditionalReflectionData.ReflectionProbeVersion, HDAdditionalReflectionData>(HDAdditionalReflectionData.ReflectionProbeVersion.ProbeSettings, delegate(HDAdditionalReflectionData t)
			{
				HDProbe.k_Migration.ExecuteStep(t, HDProbe.Version.ProbeSettings);
				Vector3 position = t.transform.position;
				Matrix4x4 matrix4x = Matrix4x4.TRS(t.transform.position, t.transform.rotation, Vector3.one);
				t.transform.position = matrix4x.MultiplyPoint(t.influenceVolume.obsoleteOffset);
				Vector3 capturePositionProxySpace = t.proxyToWorld.inverse.MultiplyPoint(position);
				t.m_ProbeSettings.proxySettings.capturePositionProxySpace = capturePositionProxySpace;
			}),
			MigrationStep.New<HDAdditionalReflectionData.ReflectionProbeVersion, HDAdditionalReflectionData>(HDAdditionalReflectionData.ReflectionProbeVersion.SeparatePassThrough, delegate(HDAdditionalReflectionData t)
			{
				HDProbe.k_Migration.ExecuteStep(t, HDProbe.Version.SeparatePassThrough);
			}),
			MigrationStep.New<HDAdditionalReflectionData.ReflectionProbeVersion, HDAdditionalReflectionData>(HDAdditionalReflectionData.ReflectionProbeVersion.UpgradeFrameSettingsToStruct, delegate(HDAdditionalReflectionData t)
			{
				HDProbe.k_Migration.ExecuteStep(t, HDProbe.Version.UpgradeFrameSettingsToStruct);
			})
		});

		// Token: 0x04000754 RID: 1876
		[SerializeField]
		[FormerlySerializedAs("version")]
		[FormerlySerializedAs("m_Version")]
		private int m_ReflectionProbeVersion;

		// Token: 0x04000755 RID: 1877
		[SerializeField]
		[FormerlySerializedAs("influenceShape")]
		[Obsolete("influenceShape is deprecated, use influenceVolume parameters instead")]
		private InfluenceShape m_ObsoleteInfluenceShape;

		// Token: 0x04000756 RID: 1878
		[SerializeField]
		[FormerlySerializedAs("influenceSphereRadius")]
		[Obsolete("influenceSphereRadius is deprecated, use influenceVolume parameters instead")]
		private float m_ObsoleteInfluenceSphereRadius = 3f;

		// Token: 0x04000757 RID: 1879
		[SerializeField]
		[FormerlySerializedAs("blendDistancePositive")]
		[Obsolete("blendDistancePositive is deprecated, use influenceVolume parameters instead")]
		private Vector3 m_ObsoleteBlendDistancePositive = Vector3.zero;

		// Token: 0x04000758 RID: 1880
		[SerializeField]
		[FormerlySerializedAs("blendDistanceNegative")]
		[Obsolete("blendDistanceNegative is deprecated, use influenceVolume parameters instead")]
		private Vector3 m_ObsoleteBlendDistanceNegative = Vector3.zero;

		// Token: 0x04000759 RID: 1881
		[SerializeField]
		[FormerlySerializedAs("blendNormalDistancePositive")]
		[Obsolete("blendNormalDistancePositive is deprecated, use influenceVolume parameters instead")]
		private Vector3 m_ObsoleteBlendNormalDistancePositive = Vector3.zero;

		// Token: 0x0400075A RID: 1882
		[SerializeField]
		[FormerlySerializedAs("blendNormalDistanceNegative")]
		[Obsolete("blendNormalDistanceNegative is deprecated, use influenceVolume parameters instead")]
		private Vector3 m_ObsoleteBlendNormalDistanceNegative = Vector3.zero;

		// Token: 0x0400075B RID: 1883
		[SerializeField]
		[FormerlySerializedAs("boxSideFadePositive")]
		[Obsolete("boxSideFadePositive is deprecated, use influenceVolume parameters instead")]
		private Vector3 m_ObsoleteBoxSideFadePositive = Vector3.one;

		// Token: 0x0400075C RID: 1884
		[SerializeField]
		[FormerlySerializedAs("boxSideFadeNegative")]
		[Obsolete("boxSideFadeNegative is deprecated, use influenceVolume parameters instead")]
		private Vector3 m_ObsoleteBoxSideFadeNegative = Vector3.one;

		// Token: 0x0200033B RID: 827
		private enum ReflectionProbeVersion
		{
			// Token: 0x04002311 RID: 8977
			First,
			// Token: 0x04002312 RID: 8978
			RemoveUsageOfLegacyProbeParamsForStocking,
			// Token: 0x04002313 RID: 8979
			HDProbeChild,
			// Token: 0x04002314 RID: 8980
			UseInfluenceVolume,
			// Token: 0x04002315 RID: 8981
			MergeEditors,
			// Token: 0x04002316 RID: 8982
			AddCaptureSettingsAndFrameSettings,
			// Token: 0x04002317 RID: 8983
			ModeAndTextures,
			// Token: 0x04002318 RID: 8984
			ProbeSettings,
			// Token: 0x04002319 RID: 8985
			SeparatePassThrough,
			// Token: 0x0400231A RID: 8986
			UpgradeFrameSettingsToStruct
		}
	}
}
