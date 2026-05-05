using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000092 RID: 146
	[Serializable]
	internal struct ProbeDilationSettings
	{
		// Token: 0x060004D5 RID: 1237 RVA: 0x000179E5 File Offset: 0x00015BE5
		internal void SetDefaults()
		{
			this.enableDilation = true;
			this.dilationDistance = 1f;
			this.dilationValidityThreshold = 0.25f;
			this.dilationIterations = 1;
			this.squaredDistWeighting = true;
		}

		// Token: 0x060004D6 RID: 1238 RVA: 0x00017A12 File Offset: 0x00015C12
		internal void UpgradeFromTo(ProbeVolumeBakingProcessSettings.SettingsVersion from, ProbeVolumeBakingProcessSettings.SettingsVersion to)
		{
		}

		// Token: 0x0400032F RID: 815
		public bool enableDilation;

		// Token: 0x04000330 RID: 816
		public float dilationDistance;

		// Token: 0x04000331 RID: 817
		public float dilationValidityThreshold;

		// Token: 0x04000332 RID: 818
		public int dilationIterations;

		// Token: 0x04000333 RID: 819
		public bool squaredDistWeighting;
	}
}
