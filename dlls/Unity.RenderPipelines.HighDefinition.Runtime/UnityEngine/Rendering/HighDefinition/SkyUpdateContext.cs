using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001F6 RID: 502
	internal class SkyUpdateContext
	{
		// Token: 0x17000253 RID: 595
		// (get) Token: 0x06000F2B RID: 3883 RVA: 0x000772B1 File Offset: 0x000754B1
		// (set) Token: 0x06000F2C RID: 3884 RVA: 0x000772B9 File Offset: 0x000754B9
		public SkyRenderer skyRenderer { get; private set; }

		// Token: 0x17000254 RID: 596
		// (get) Token: 0x06000F2D RID: 3885 RVA: 0x000772C2 File Offset: 0x000754C2
		// (set) Token: 0x06000F2E RID: 3886 RVA: 0x000772CA File Offset: 0x000754CA
		public CloudRenderer cloudRenderer { get; private set; }

		// Token: 0x17000255 RID: 597
		// (get) Token: 0x06000F2F RID: 3887 RVA: 0x000772D3 File Offset: 0x000754D3
		// (set) Token: 0x06000F30 RID: 3888 RVA: 0x000772DB File Offset: 0x000754DB
		public bool settingsHadBigDifferenceWithPrev { get; private set; }

		// Token: 0x17000256 RID: 598
		// (get) Token: 0x06000F31 RID: 3889 RVA: 0x000772E4 File Offset: 0x000754E4
		// (set) Token: 0x06000F32 RID: 3890 RVA: 0x000772EC File Offset: 0x000754EC
		public SkySettings skySettings
		{
			get
			{
				return this.m_SkySettings;
			}
			set
			{
				if (this.skyRenderer != null && (value == null || value.GetSkyRendererType() != this.skyRenderer.GetType()))
				{
					this.skyRenderer.Cleanup();
					this.skyRenderer = null;
				}
				if (this.m_SkySettings == null)
				{
					this.settingsHadBigDifferenceWithPrev = true;
				}
				else
				{
					this.settingsHadBigDifferenceWithPrev = this.m_SkySettings.SignificantlyDivergesFrom(value);
				}
				if (this.m_SkySettings == value)
				{
					return;
				}
				this.skyParametersHash = -1;
				this.m_SkySettings = value;
				this.currentUpdateTime = 0f;
				if (this.m_SkySettings != null && this.skyRenderer == null)
				{
					Type skyRendererType = this.m_SkySettings.GetSkyRendererType();
					this.skyRenderer = (SkyRenderer)Activator.CreateInstance(skyRendererType);
					this.skyRenderer.Build();
				}
			}
		}

		// Token: 0x17000257 RID: 599
		// (get) Token: 0x06000F33 RID: 3891 RVA: 0x000773C3 File Offset: 0x000755C3
		// (set) Token: 0x06000F34 RID: 3892 RVA: 0x000773CC File Offset: 0x000755CC
		public CloudSettings cloudSettings
		{
			get
			{
				return this.m_CloudSettings;
			}
			set
			{
				if (this.cloudRenderer != null && (value == null || value.GetCloudRendererType() != this.cloudRenderer.GetType()))
				{
					this.cloudRenderer.Cleanup();
					this.cloudRenderer = null;
				}
				if (this.m_CloudSettings == value)
				{
					return;
				}
				this.skyParametersHash = -1;
				this.m_CloudSettings = value;
				if (this.m_CloudSettings != null && this.cloudRenderer == null)
				{
					Type cloudRendererType = this.m_CloudSettings.GetCloudRendererType();
					this.cloudRenderer = (CloudRenderer)Activator.CreateInstance(cloudRendererType);
					this.cloudRenderer.Build();
				}
			}
		}

		// Token: 0x17000258 RID: 600
		// (get) Token: 0x06000F35 RID: 3893 RVA: 0x0007746F File Offset: 0x0007566F
		// (set) Token: 0x06000F36 RID: 3894 RVA: 0x00077477 File Offset: 0x00075677
		public VolumetricClouds volumetricClouds
		{
			get
			{
				return this.m_VolumetricClouds;
			}
			set
			{
				if (this.m_VolumetricClouds == value)
				{
					return;
				}
				this.m_VolumetricClouds = value;
			}
		}

		// Token: 0x06000F37 RID: 3895 RVA: 0x00077490 File Offset: 0x00075690
		public void Cleanup()
		{
			if (this.skyRenderer != null)
			{
				this.skyRenderer.Cleanup();
			}
			if (this.cloudRenderer != null)
			{
				this.cloudRenderer.Cleanup();
			}
			HDRenderPipeline currentPipeline = HDRenderPipeline.currentPipeline;
			if (currentPipeline != null)
			{
				currentPipeline.skyManager.ReleaseCachedContext(this.cachedSkyRenderingContextId);
			}
		}

		// Token: 0x06000F38 RID: 3896 RVA: 0x000774DD File Offset: 0x000756DD
		public bool IsValid()
		{
			return this.m_SkySettings != null;
		}

		// Token: 0x06000F39 RID: 3897 RVA: 0x000774EB File Offset: 0x000756EB
		public bool HasClouds()
		{
			return this.m_CloudSettings != null;
		}

		// Token: 0x06000F3A RID: 3898 RVA: 0x000774F9 File Offset: 0x000756F9
		public bool HasVolumetricClouds()
		{
			return this.m_VolumetricClouds != null;
		}

		// Token: 0x06000F3B RID: 3899 RVA: 0x00077507 File Offset: 0x00075707
		public void Reset()
		{
			if (this.skyRenderer != null)
			{
				this.skyRenderer.Reset();
			}
			if (this.cloudRenderer != null)
			{
				this.cloudRenderer.Reset();
			}
		}

		// Token: 0x040017B3 RID: 6067
		private SkySettings m_SkySettings;

		// Token: 0x040017B5 RID: 6069
		public int cachedSkyRenderingContextId = -1;

		// Token: 0x040017B6 RID: 6070
		private CloudSettings m_CloudSettings;

		// Token: 0x040017B8 RID: 6072
		public int skyParametersHash = -1;

		// Token: 0x040017B9 RID: 6073
		public float currentUpdateTime;

		// Token: 0x040017BA RID: 6074
		private VolumetricClouds m_VolumetricClouds;
	}
}
