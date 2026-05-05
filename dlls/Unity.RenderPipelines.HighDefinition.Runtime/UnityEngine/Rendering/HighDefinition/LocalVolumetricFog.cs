using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000E5 RID: 229
	[ExecuteAlways]
	[AddComponentMenu("Rendering/Local Volumetric Fog")]
	public class LocalVolumetricFog : MonoBehaviour, IVersionable<LocalVolumetricFog.Version>
	{
		// Token: 0x0600095C RID: 2396 RVA: 0x00052334 File Offset: 0x00050534
		internal void PrepareParameters(float time)
		{
			this.parameters.Update(time);
		}

		// Token: 0x0600095D RID: 2397 RVA: 0x00052342 File Offset: 0x00050542
		private void NotifyUpdatedTexure()
		{
			if (this.OnTextureUpdated != null)
			{
				this.OnTextureUpdated();
			}
		}

		// Token: 0x0600095E RID: 2398 RVA: 0x00052357 File Offset: 0x00050557
		private void OnEnable()
		{
			LocalVolumetricFogManager.manager.RegisterVolume(this);
		}

		// Token: 0x0600095F RID: 2399 RVA: 0x00052364 File Offset: 0x00050564
		private void OnDisable()
		{
			LocalVolumetricFogManager.manager.DeRegisterVolume(this);
		}

		// Token: 0x06000960 RID: 2400 RVA: 0x00052371 File Offset: 0x00050571
		private void OnValidate()
		{
			this.parameters.Constrain();
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x06000961 RID: 2401 RVA: 0x0005237E File Offset: 0x0005057E
		// (set) Token: 0x06000962 RID: 2402 RVA: 0x00052386 File Offset: 0x00050586
		LocalVolumetricFog.Version IVersionable<LocalVolumetricFog.Version>.version
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

		// Token: 0x06000963 RID: 2403 RVA: 0x00052390 File Offset: 0x00050590
		private void Awake()
		{
			LocalVolumetricFog.k_Migration.Migrate(this);
		}

		// Token: 0x04000991 RID: 2449
		public LocalVolumetricFogArtistParameters parameters = new LocalVolumetricFogArtistParameters(Color.white, 10f, 0f);

		// Token: 0x04000992 RID: 2450
		public Action OnTextureUpdated;

		// Token: 0x04000993 RID: 2451
		private static readonly MigrationDescription<LocalVolumetricFog.Version, LocalVolumetricFog> k_Migration = MigrationDescription.New<LocalVolumetricFog.Version, LocalVolumetricFog>(new MigrationStep<LocalVolumetricFog.Version, LocalVolumetricFog>[]
		{
			MigrationStep.New<LocalVolumetricFog.Version, LocalVolumetricFog>(LocalVolumetricFog.Version.ScaleIndependent, delegate(LocalVolumetricFog data)
			{
				data.parameters.size = data.transform.lossyScale;
				data.parameters.m_EditorAdvancedFade = true;
			}),
			MigrationStep.New<LocalVolumetricFog.Version, LocalVolumetricFog>(LocalVolumetricFog.Version.FixUniformBlendDistanceToBeMetric, delegate(LocalVolumetricFog data)
			{
				data.parameters.MigrateToFixUniformBlendDistanceToBeMetric();
			})
		});

		// Token: 0x04000994 RID: 2452
		[SerializeField]
		private LocalVolumetricFog.Version m_Version = MigrationDescription.LastVersion<LocalVolumetricFog.Version>();

		// Token: 0x02000360 RID: 864
		private enum Version
		{
			// Token: 0x04002399 RID: 9113
			First,
			// Token: 0x0400239A RID: 9114
			ScaleIndependent,
			// Token: 0x0400239B RID: 9115
			FixUniformBlendDistanceToBeMetric
		}
	}
}
