using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000093 RID: 147
	[Serializable]
	internal struct VirtualOffsetSettings
	{
		// Token: 0x060004D7 RID: 1239 RVA: 0x00017A14 File Offset: 0x00015C14
		internal void SetDefaults()
		{
			this.useVirtualOffset = true;
			this.outOfGeoOffset = 0.01f;
			this.searchMultiplier = 0.2f;
			this.UpgradeFromTo(ProbeVolumeBakingProcessSettings.SettingsVersion.Initial, ProbeVolumeBakingProcessSettings.SettingsVersion.ThreadedVirtualOffset);
		}

		// Token: 0x060004D8 RID: 1240 RVA: 0x00017A3B File Offset: 0x00015C3B
		internal void UpgradeFromTo(ProbeVolumeBakingProcessSettings.SettingsVersion from, ProbeVolumeBakingProcessSettings.SettingsVersion to)
		{
			if (from < ProbeVolumeBakingProcessSettings.SettingsVersion.ThreadedVirtualOffset && to >= ProbeVolumeBakingProcessSettings.SettingsVersion.ThreadedVirtualOffset)
			{
				this.rayOriginBias = -0.001f;
				this.maxHitsPerRay = 10;
				this.collisionMask = -5;
			}
		}

		// Token: 0x04000334 RID: 820
		public bool useVirtualOffset;

		// Token: 0x04000335 RID: 821
		[Range(0f, 1f)]
		public float outOfGeoOffset;

		// Token: 0x04000336 RID: 822
		[Range(0f, 2f)]
		public float searchMultiplier;

		// Token: 0x04000337 RID: 823
		[Range(-0.05f, 0f)]
		public float rayOriginBias;

		// Token: 0x04000338 RID: 824
		[Range(4f, 24f)]
		public int maxHitsPerRay;

		// Token: 0x04000339 RID: 825
		public LayerMask collisionMask;
	}
}
