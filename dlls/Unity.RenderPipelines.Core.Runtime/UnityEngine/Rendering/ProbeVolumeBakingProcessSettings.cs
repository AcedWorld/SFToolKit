using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000094 RID: 148
	[Serializable]
	internal struct ProbeVolumeBakingProcessSettings
	{
		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x060004D9 RID: 1241 RVA: 0x00017A68 File Offset: 0x00015C68
		internal static ProbeVolumeBakingProcessSettings Default
		{
			get
			{
				ProbeVolumeBakingProcessSettings result = default(ProbeVolumeBakingProcessSettings);
				result.SetDefaults();
				return result;
			}
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x00017A85 File Offset: 0x00015C85
		internal ProbeVolumeBakingProcessSettings(ProbeDilationSettings dilationSettings, VirtualOffsetSettings virtualOffsetSettings)
		{
			this.m_Version = ProbeVolumeBakingProcessSettings.SettingsVersion.ThreadedVirtualOffset;
			this.dilationSettings = dilationSettings;
			this.virtualOffsetSettings = virtualOffsetSettings;
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x00017A9C File Offset: 0x00015C9C
		internal void SetDefaults()
		{
			this.m_Version = ProbeVolumeBakingProcessSettings.SettingsVersion.ThreadedVirtualOffset;
			this.dilationSettings.SetDefaults();
			this.virtualOffsetSettings.SetDefaults();
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x00017ABB File Offset: 0x00015CBB
		internal void Upgrade()
		{
			if (this.m_Version != ProbeVolumeBakingProcessSettings.SettingsVersion.ThreadedVirtualOffset)
			{
				this.dilationSettings.UpgradeFromTo(this.m_Version, ProbeVolumeBakingProcessSettings.SettingsVersion.ThreadedVirtualOffset);
				this.virtualOffsetSettings.UpgradeFromTo(this.m_Version, ProbeVolumeBakingProcessSettings.SettingsVersion.ThreadedVirtualOffset);
				this.m_Version = ProbeVolumeBakingProcessSettings.SettingsVersion.ThreadedVirtualOffset;
			}
		}

		// Token: 0x0400033A RID: 826
		[SerializeField]
		private ProbeVolumeBakingProcessSettings.SettingsVersion m_Version;

		// Token: 0x0400033B RID: 827
		public ProbeDilationSettings dilationSettings;

		// Token: 0x0400033C RID: 828
		public VirtualOffsetSettings virtualOffsetSettings;

		// Token: 0x020001AD RID: 429
		internal enum SettingsVersion
		{
			// Token: 0x04000719 RID: 1817
			Initial,
			// Token: 0x0400071A RID: 1818
			ThreadedVirtualOffset,
			// Token: 0x0400071B RID: 1819
			Max,
			// Token: 0x0400071C RID: 1820
			Current = 1
		}
	}
}
