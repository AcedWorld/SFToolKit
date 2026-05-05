using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000E6 RID: 230
	internal class LocalVolumetricFogManager
	{
		// Token: 0x17000157 RID: 343
		// (get) Token: 0x06000966 RID: 2406 RVA: 0x00052433 File Offset: 0x00050633
		public static LocalVolumetricFogManager manager
		{
			get
			{
				if (LocalVolumetricFogManager.m_Manager == null)
				{
					LocalVolumetricFogManager.m_Manager = new LocalVolumetricFogManager();
				}
				return LocalVolumetricFogManager.m_Manager;
			}
		}

		// Token: 0x06000967 RID: 2407 RVA: 0x0005244B File Offset: 0x0005064B
		private LocalVolumetricFogManager()
		{
			this.m_Volumes = new List<LocalVolumetricFog>();
		}

		// Token: 0x06000968 RID: 2408 RVA: 0x0005245E File Offset: 0x0005065E
		public void RegisterVolume(LocalVolumetricFog volume)
		{
			this.m_Volumes.Add(volume);
		}

		// Token: 0x06000969 RID: 2409 RVA: 0x0005246C File Offset: 0x0005066C
		public void DeRegisterVolume(LocalVolumetricFog volume)
		{
			if (this.m_Volumes.Contains(volume))
			{
				this.m_Volumes.Remove(volume);
			}
		}

		// Token: 0x0600096A RID: 2410 RVA: 0x00052489 File Offset: 0x00050689
		public bool ContainsVolume(LocalVolumetricFog volume)
		{
			return this.m_Volumes.Contains(volume);
		}

		// Token: 0x0600096B RID: 2411 RVA: 0x00052498 File Offset: 0x00050698
		public List<LocalVolumetricFog> PrepareLocalVolumetricFogData(CommandBuffer cmd, HDCamera currentCam)
		{
			float time = currentCam.time;
			foreach (LocalVolumetricFog localVolumetricFog in this.m_Volumes)
			{
				localVolumetricFog.PrepareParameters(time);
			}
			return this.m_Volumes;
		}

		// Token: 0x04000995 RID: 2453
		private static LocalVolumetricFogManager m_Manager;

		// Token: 0x04000996 RID: 2454
		private List<LocalVolumetricFog> m_Volumes;
	}
}
