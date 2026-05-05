using System;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000AC RID: 172
	[ExecuteAlways]
	[AddComponentMenu("Rendering/Planar Reflection Probe")]
	public sealed class PlanarReflectionProbe : HDProbe, IVersionable<PlanarReflectionProbe.PlanarProbeVersion>
	{
		// Token: 0x1700011A RID: 282
		// (get) Token: 0x060007E8 RID: 2024 RVA: 0x00049C4D File Offset: 0x00047E4D
		// (set) Token: 0x060007E9 RID: 2025 RVA: 0x00049C55 File Offset: 0x00047E55
		public Vector3 localReferencePosition
		{
			get
			{
				return this.m_LocalReferencePosition;
			}
			set
			{
				this.m_LocalReferencePosition = value;
			}
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x060007EA RID: 2026 RVA: 0x00049C5E File Offset: 0x00047E5E
		public Vector3 referencePosition
		{
			get
			{
				return base.transform.TransformPoint(this.m_LocalReferencePosition);
			}
		}

		// Token: 0x060007EB RID: 2027 RVA: 0x00049C74 File Offset: 0x00047E74
		private void Awake()
		{
			base.type = ProbeSettings.ProbeType.PlanarProbe;
			PlanarReflectionProbe.k_PlanarProbeMigration.Migrate(this);
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x060007EC RID: 2028 RVA: 0x00049C97 File Offset: 0x00047E97
		// (set) Token: 0x060007ED RID: 2029 RVA: 0x00049C9F File Offset: 0x00047E9F
		PlanarReflectionProbe.PlanarProbeVersion IVersionable<PlanarReflectionProbe.PlanarProbeVersion>.version
		{
			get
			{
				return (PlanarReflectionProbe.PlanarProbeVersion)this.m_PlanarProbeVersion;
			}
			set
			{
				this.m_PlanarProbeVersion = (int)value;
			}
		}

		// Token: 0x0400079C RID: 1948
		[SerializeField]
		private Vector3 m_LocalReferencePosition = -Vector3.forward;

		// Token: 0x0400079D RID: 1949
		[SerializeField]
		[FormerlySerializedAs("version")]
		[FormerlySerializedAs("m_Version")]
		private int m_PlanarProbeVersion;

		// Token: 0x0400079E RID: 1950
		private static readonly MigrationDescription<PlanarReflectionProbe.PlanarProbeVersion, PlanarReflectionProbe> k_PlanarProbeMigration = MigrationDescription.New<PlanarReflectionProbe.PlanarProbeVersion, PlanarReflectionProbe>(new MigrationStep<PlanarReflectionProbe.PlanarProbeVersion, PlanarReflectionProbe>[]
		{
			MigrationStep.New<PlanarReflectionProbe.PlanarProbeVersion, PlanarReflectionProbe>(PlanarReflectionProbe.PlanarProbeVersion.CaptureSettings, delegate(PlanarReflectionProbe p)
			{
				if (p.m_ObsoleteCaptureSettings == null)
				{
					p.m_ObsoleteCaptureSettings = new ObsoleteCaptureSettings();
				}
				if (p.m_ObsoleteOverrideFieldOfView)
				{
					p.m_ObsoleteCaptureSettings.overrides |= ObsoleteCaptureSettingsOverrides.FieldOfview;
				}
				p.m_ObsoleteCaptureSettings.fieldOfView = p.m_ObsoleteFieldOfViewOverride;
				p.m_ObsoleteCaptureSettings.nearClipPlane = p.m_ObsoleteCaptureNearPlane;
				p.m_ObsoleteCaptureSettings.farClipPlane = p.m_ObsoleteCaptureFarPlane;
			}),
			MigrationStep.New<PlanarReflectionProbe.PlanarProbeVersion, PlanarReflectionProbe>(PlanarReflectionProbe.PlanarProbeVersion.ProbeSettings, delegate(PlanarReflectionProbe p)
			{
				HDProbe.k_Migration.ExecuteStep(p, HDProbe.Version.ProbeSettings);
				Vector3 position = p.transform.position;
				Matrix4x4 matrix4x = Matrix4x4.TRS(p.transform.position, p.transform.rotation, Vector3.one);
				p.transform.position = matrix4x.MultiplyPoint(p.influenceVolume.obsoleteOffset);
				Quaternion rhs = p.transform.rotation * Quaternion.Euler(-90f, 0f, 0f);
				Matrix4x4 inverse = p.proxyToWorld.inverse;
				Vector3 mirrorPositionProxySpace = inverse.MultiplyPoint(position);
				Quaternion mirrorRotationProxySpace = inverse.rotation * rhs;
				p.m_ProbeSettings.proxySettings.mirrorPositionProxySpace = mirrorPositionProxySpace;
				p.m_ProbeSettings.proxySettings.mirrorRotationProxySpace = mirrorRotationProxySpace;
				p.m_LocalReferencePosition = Quaternion.Euler(-90f, 0f, 0f) * -p.m_LocalReferencePosition;
			}),
			MigrationStep.New<PlanarReflectionProbe.PlanarProbeVersion, PlanarReflectionProbe>(PlanarReflectionProbe.PlanarProbeVersion.SeparatePassThrough, delegate(PlanarReflectionProbe t)
			{
				HDProbe.k_Migration.ExecuteStep(t, HDProbe.Version.SeparatePassThrough);
			}),
			MigrationStep.New<PlanarReflectionProbe.PlanarProbeVersion, PlanarReflectionProbe>(PlanarReflectionProbe.PlanarProbeVersion.UpgradeFrameSettingsToStruct, delegate(PlanarReflectionProbe t)
			{
				HDProbe.k_Migration.ExecuteStep(t, HDProbe.Version.UpgradeFrameSettingsToStruct);
			}),
			MigrationStep.New<PlanarReflectionProbe.PlanarProbeVersion, PlanarReflectionProbe>(PlanarReflectionProbe.PlanarProbeVersion.PlanarResolutionScalability, delegate(PlanarReflectionProbe p)
			{
				HDProbe.k_Migration.ExecuteStep(p, HDProbe.Version.PlanarResolutionScalability);
				p.m_ProbeSettings.resolutionScalable.useOverride = true;
				if (p.m_ProbeSettings.resolution != (PlanarReflectionAtlasResolution)0)
				{
					p.m_ProbeSettings.resolutionScalable.@override = p.m_ProbeSettings.resolution;
					return;
				}
				p.m_ProbeSettings.resolutionScalable.@override = PlanarReflectionAtlasResolution.Resolution512;
			})
		});

		// Token: 0x0400079F RID: 1951
		[SerializeField]
		[FormerlySerializedAs("m_CaptureNearPlane")]
		[Obsolete("For data migration")]
		private float m_ObsoleteCaptureNearPlane = ObsoleteCaptureSettings.@default.nearClipPlane;

		// Token: 0x040007A0 RID: 1952
		[SerializeField]
		[FormerlySerializedAs("m_CaptureFarPlane")]
		[Obsolete("For data migration")]
		private float m_ObsoleteCaptureFarPlane = ObsoleteCaptureSettings.@default.farClipPlane;

		// Token: 0x040007A1 RID: 1953
		[SerializeField]
		[FormerlySerializedAs("m_OverrideFieldOfView")]
		[Obsolete("For data migration")]
		private bool m_ObsoleteOverrideFieldOfView;

		// Token: 0x040007A2 RID: 1954
		[SerializeField]
		[FormerlySerializedAs("m_FieldOfViewOverride")]
		[Obsolete("For data migration")]
		private float m_ObsoleteFieldOfViewOverride = ObsoleteCaptureSettings.@default.fieldOfView;

		// Token: 0x02000341 RID: 833
		private enum PlanarProbeVersion
		{
			// Token: 0x04002330 RID: 9008
			Initial,
			// Token: 0x04002331 RID: 9009
			First = 2,
			// Token: 0x04002332 RID: 9010
			CaptureSettings,
			// Token: 0x04002333 RID: 9011
			ProbeSettings,
			// Token: 0x04002334 RID: 9012
			SeparatePassThrough,
			// Token: 0x04002335 RID: 9013
			UpgradeFrameSettingsToStruct,
			// Token: 0x04002336 RID: 9014
			PlanarResolutionScalability
		}
	}
}
