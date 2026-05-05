using System;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000A6 RID: 166
	[ExecuteAlways]
	public abstract class HDProbe : MonoBehaviour, IVersionable<HDProbe.Version>
	{
		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x06000764 RID: 1892 RVA: 0x000487E4 File Offset: 0x000469E4
		// (set) Token: 0x06000763 RID: 1891 RVA: 0x000487DB File Offset: 0x000469DB
		public bool ExposureControlEnabled { get; set; }

		// Token: 0x06000765 RID: 1893 RVA: 0x000487EC File Offset: 0x000469EC
		internal void SetProbeExposureValue(float exposure)
		{
			this.m_ProbeExposureValue = exposure;
		}

		// Token: 0x06000766 RID: 1894 RVA: 0x000487F5 File Offset: 0x000469F5
		internal float ProbeExposureValue()
		{
			return this.m_ProbeExposureValue;
		}

		// Token: 0x06000767 RID: 1895 RVA: 0x000487FD File Offset: 0x000469FD
		private bool HasRemainingRenderSteps()
		{
			return !this.m_RemainingRenderSteps.IsNone() || this.m_HasPendingRenderRequest;
		}

		// Token: 0x06000768 RID: 1896 RVA: 0x00048814 File Offset: 0x00046A14
		private void EnqueueAllRenderSteps()
		{
			ProbeRenderSteps probeRenderSteps = ProbeRenderStepsExt.FromProbeType(this.type);
			if (this.m_RemainingRenderSteps != probeRenderSteps)
			{
				this.m_HasPendingRenderRequest = true;
			}
		}

		// Token: 0x06000769 RID: 1897 RVA: 0x00048840 File Offset: 0x00046A40
		internal ProbeRenderSteps NextRenderSteps()
		{
			if (this.m_RemainingRenderSteps.IsNone() && this.m_HasPendingRenderRequest)
			{
				this.m_RemainingRenderSteps = ProbeRenderStepsExt.FromProbeType(this.type);
				this.m_HasPendingRenderRequest = false;
			}
			if (this.type == ProbeSettings.ProbeType.ReflectionProbe)
			{
				ProbeRenderSteps probeRenderSteps = this.timeSlicing ? this.m_RemainingRenderSteps.LowestSetBit() : this.m_RemainingRenderSteps;
				bool flag = this.realtimeMode == ProbeSettings.RealtimeMode.EveryFrame || this.timeSlicing;
				if (!probeRenderSteps.IsNone() && flag)
				{
					int frameCount = Time.frameCount;
					if (this.m_LastStepFrameCount == frameCount)
					{
						probeRenderSteps = ProbeRenderSteps.None;
					}
					else
					{
						this.m_LastStepFrameCount = frameCount;
					}
				}
				this.m_RemainingRenderSteps &= ~probeRenderSteps;
				return probeRenderSteps;
			}
			this.m_RemainingRenderSteps = ProbeRenderSteps.None;
			return ProbeRenderSteps.PlanarProbeMask;
		}

		// Token: 0x0600076A RID: 1898 RVA: 0x000488F4 File Offset: 0x00046AF4
		internal void IncrementRealtimeRenderCount()
		{
			this.m_RealtimeRenderCount += 1U;
			this.texture.IncrementUpdateCount();
		}

		// Token: 0x0600076B RID: 1899 RVA: 0x0004890F File Offset: 0x00046B0F
		internal void RepeatRenderSteps(ProbeRenderSteps renderSteps)
		{
			this.m_RemainingRenderSteps |= renderSteps;
		}

		// Token: 0x0600076C RID: 1900 RVA: 0x0004891F File Offset: 0x00046B1F
		internal uint GetTextureHash()
		{
			if (this.mode != ProbeSettings.Mode.Realtime)
			{
				return this.texture.updateCount;
			}
			return this.m_RealtimeRenderCount;
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x0600076D RID: 1901 RVA: 0x0004893C File Offset: 0x00046B3C
		internal bool requiresRealtimeUpdate
		{
			get
			{
				if (this.mode != ProbeSettings.Mode.Realtime)
				{
					return false;
				}
				switch (this.realtimeMode)
				{
				case ProbeSettings.RealtimeMode.EveryFrame:
					return true;
				case ProbeSettings.RealtimeMode.OnEnable:
					return !this.wasRenderedAfterOnEnable || this.HasRemainingRenderSteps();
				case ProbeSettings.RealtimeMode.OnDemand:
					return !this.m_WasRenderedSinceLastOnDemandRequest || this.HasRemainingRenderSteps();
				default:
					throw new ArgumentOutOfRangeException("realtimeMode");
				}
			}
		}

		// Token: 0x0600076E RID: 1902 RVA: 0x000489A0 File Offset: 0x00046BA0
		internal bool HasValidRenderedData()
		{
			bool flag = this.texture != null;
			if (this.mode != ProbeSettings.Mode.Realtime)
			{
				return flag;
			}
			return this.hasEverRendered && flag;
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x0600076F RID: 1903 RVA: 0x000489CD File Offset: 0x00046BCD
		// (set) Token: 0x06000770 RID: 1904 RVA: 0x000489D5 File Offset: 0x00046BD5
		public Texture bakedTexture
		{
			get
			{
				return this.m_BakedTexture;
			}
			set
			{
				this.m_BakedTexture = value;
			}
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x06000771 RID: 1905 RVA: 0x000489DE File Offset: 0x00046BDE
		// (set) Token: 0x06000772 RID: 1906 RVA: 0x000489E6 File Offset: 0x00046BE6
		public Texture customTexture
		{
			get
			{
				return this.m_CustomTexture;
			}
			set
			{
				this.m_CustomTexture = value;
			}
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x06000773 RID: 1907 RVA: 0x000489EF File Offset: 0x00046BEF
		// (set) Token: 0x06000774 RID: 1908 RVA: 0x00048A08 File Offset: 0x00046C08
		public RenderTexture realtimeTexture
		{
			get
			{
				return (this.m_RealtimeTexture != null) ? this.m_RealtimeTexture : null;
			}
			set
			{
				if (this.m_RealtimeTexture != null)
				{
					this.m_RealtimeTexture.Release();
				}
				this.m_RealtimeTexture = RTHandles.Alloc(value);
				this.m_RealtimeTexture.rt.name = "ProbeRealTimeTexture_" + base.name;
			}
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x06000775 RID: 1909 RVA: 0x00048A54 File Offset: 0x00046C54
		// (set) Token: 0x06000776 RID: 1910 RVA: 0x00048A6C File Offset: 0x00046C6C
		public RenderTexture realtimeDepthTexture
		{
			get
			{
				return (this.m_RealtimeDepthBuffer != null) ? this.m_RealtimeDepthBuffer : null;
			}
			set
			{
				if (this.m_RealtimeDepthBuffer != null)
				{
					this.m_RealtimeDepthBuffer.Release();
				}
				this.m_RealtimeDepthBuffer = RTHandles.Alloc(value);
				this.m_RealtimeDepthBuffer.rt.name = "ProbeRealTimeDepthTexture_" + base.name;
			}
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x06000777 RID: 1911 RVA: 0x00048AB8 File Offset: 0x00046CB8
		public RTHandle realtimeTextureRTH
		{
			get
			{
				return this.m_RealtimeTexture;
			}
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x06000778 RID: 1912 RVA: 0x00048AC0 File Offset: 0x00046CC0
		public RTHandle realtimeDepthTextureRTH
		{
			get
			{
				return this.m_RealtimeDepthBuffer;
			}
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x06000779 RID: 1913 RVA: 0x00048AC8 File Offset: 0x00046CC8
		public Texture texture
		{
			get
			{
				return this.GetTexture(this.mode);
			}
		}

		// Token: 0x0600077A RID: 1914 RVA: 0x00048AD6 File Offset: 0x00046CD6
		public Texture GetTexture(ProbeSettings.Mode targetMode)
		{
			switch (targetMode)
			{
			case ProbeSettings.Mode.Baked:
				return this.m_BakedTexture;
			case ProbeSettings.Mode.Realtime:
				return this.m_RealtimeTexture;
			case ProbeSettings.Mode.Custom:
				return this.m_CustomTexture;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		// Token: 0x0600077B RID: 1915 RVA: 0x00048B0C File Offset: 0x00046D0C
		public Texture SetTexture(ProbeSettings.Mode targetMode, Texture texture)
		{
			if (targetMode == ProbeSettings.Mode.Realtime && !(texture is RenderTexture))
			{
				throw new ArgumentException("'texture' must be a RenderTexture for the Realtime mode.");
			}
			switch (targetMode)
			{
			case ProbeSettings.Mode.Baked:
				this.m_BakedTexture = texture;
				return texture;
			case ProbeSettings.Mode.Realtime:
				return this.realtimeTexture = (RenderTexture)texture;
			case ProbeSettings.Mode.Custom:
				this.m_CustomTexture = texture;
				return texture;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		// Token: 0x0600077C RID: 1916 RVA: 0x00048B70 File Offset: 0x00046D70
		public Texture SetDepthTexture(ProbeSettings.Mode targetMode, Texture texture)
		{
			if (targetMode == ProbeSettings.Mode.Realtime && !(texture is RenderTexture))
			{
				throw new ArgumentException("'texture' must be a RenderTexture for the Realtime mode.");
			}
			switch (targetMode)
			{
			case ProbeSettings.Mode.Baked:
				this.m_BakedTexture = texture;
				return texture;
			case ProbeSettings.Mode.Realtime:
				return this.realtimeDepthTexture = (RenderTexture)texture;
			case ProbeSettings.Mode.Custom:
				this.m_CustomTexture = texture;
				return texture;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x0600077D RID: 1917 RVA: 0x00048BD3 File Offset: 0x00046DD3
		// (set) Token: 0x0600077E RID: 1918 RVA: 0x00048BDB File Offset: 0x00046DDB
		public HDProbe.RenderData bakedRenderData
		{
			get
			{
				return this.m_BakedRenderData;
			}
			set
			{
				this.m_BakedRenderData = value;
			}
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x0600077F RID: 1919 RVA: 0x00048BE4 File Offset: 0x00046DE4
		// (set) Token: 0x06000780 RID: 1920 RVA: 0x00048BEC File Offset: 0x00046DEC
		public HDProbe.RenderData customRenderData
		{
			get
			{
				return this.m_CustomRenderData;
			}
			set
			{
				this.m_CustomRenderData = value;
			}
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x06000781 RID: 1921 RVA: 0x00048BF5 File Offset: 0x00046DF5
		// (set) Token: 0x06000782 RID: 1922 RVA: 0x00048BFD File Offset: 0x00046DFD
		public HDProbe.RenderData realtimeRenderData
		{
			get
			{
				return this.m_RealtimeRenderData;
			}
			set
			{
				this.m_RealtimeRenderData = value;
			}
		}

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x06000783 RID: 1923 RVA: 0x00048C06 File Offset: 0x00046E06
		public HDProbe.RenderData renderData
		{
			get
			{
				return this.GetRenderData(this.mode);
			}
		}

		// Token: 0x06000784 RID: 1924 RVA: 0x00048C14 File Offset: 0x00046E14
		public HDProbe.RenderData GetRenderData(ProbeSettings.Mode targetMode)
		{
			switch (targetMode)
			{
			case ProbeSettings.Mode.Baked:
				return this.bakedRenderData;
			case ProbeSettings.Mode.Realtime:
				return this.realtimeRenderData;
			case ProbeSettings.Mode.Custom:
				return this.customRenderData;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		// Token: 0x06000785 RID: 1925 RVA: 0x00048C44 File Offset: 0x00046E44
		public void SetRenderData(ProbeSettings.Mode targetMode, HDProbe.RenderData renderData)
		{
			switch (targetMode)
			{
			case ProbeSettings.Mode.Baked:
				this.bakedRenderData = renderData;
				return;
			case ProbeSettings.Mode.Realtime:
				this.realtimeRenderData = renderData;
				return;
			case ProbeSettings.Mode.Custom:
				this.customRenderData = renderData;
				return;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x06000786 RID: 1926 RVA: 0x00048C77 File Offset: 0x00046E77
		// (set) Token: 0x06000787 RID: 1927 RVA: 0x00048C84 File Offset: 0x00046E84
		public ProbeSettings.ProbeType type
		{
			get
			{
				return this.m_ProbeSettings.type;
			}
			protected set
			{
				this.m_ProbeSettings.type = value;
			}
		}

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x06000788 RID: 1928 RVA: 0x00048C92 File Offset: 0x00046E92
		// (set) Token: 0x06000789 RID: 1929 RVA: 0x00048C9F File Offset: 0x00046E9F
		public ProbeSettings.Mode mode
		{
			get
			{
				return this.m_ProbeSettings.mode;
			}
			set
			{
				this.m_ProbeSettings.mode = value;
			}
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x0600078A RID: 1930 RVA: 0x00048CAD File Offset: 0x00046EAD
		// (set) Token: 0x0600078B RID: 1931 RVA: 0x00048CBA File Offset: 0x00046EBA
		public ProbeSettings.RealtimeMode realtimeMode
		{
			get
			{
				return this.m_ProbeSettings.realtimeMode;
			}
			set
			{
				this.m_ProbeSettings.realtimeMode = value;
			}
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x0600078C RID: 1932 RVA: 0x00048CC8 File Offset: 0x00046EC8
		// (set) Token: 0x0600078D RID: 1933 RVA: 0x00048CD5 File Offset: 0x00046ED5
		public bool timeSlicing
		{
			get
			{
				return this.m_ProbeSettings.timeSlicing;
			}
			set
			{
				this.m_ProbeSettings.timeSlicing = value;
			}
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x0600078E RID: 1934 RVA: 0x00048CE4 File Offset: 0x00046EE4
		public PlanarReflectionAtlasResolution resolution
		{
			get
			{
				HDRenderPipeline hdrenderPipeline = (HDRenderPipeline)RenderPipelineManager.currentPipeline;
				if (hdrenderPipeline == null)
				{
					return this.m_ProbeSettings.resolution;
				}
				return this.m_ProbeSettings.resolutionScalable.Value(hdrenderPipeline.asset.currentPlatformRenderPipelineSettings.planarReflectionResolution);
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x0600078F RID: 1935 RVA: 0x00048D2C File Offset: 0x00046F2C
		public CubeReflectionResolution cubeResolution
		{
			get
			{
				HDRenderPipeline hdrenderPipeline = (HDRenderPipeline)RenderPipelineManager.currentPipeline;
				if (hdrenderPipeline == null)
				{
					return CubeReflectionResolution.CubeReflectionResolution128;
				}
				return this.m_ProbeSettings.cubeResolution.Value(hdrenderPipeline.asset.currentPlatformRenderPipelineSettings.cubeReflectionResolution);
			}
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x06000790 RID: 1936 RVA: 0x00048D6D File Offset: 0x00046F6D
		// (set) Token: 0x06000791 RID: 1937 RVA: 0x00048D7F File Offset: 0x00046F7F
		public LightLayerEnum lightLayers
		{
			get
			{
				return this.m_ProbeSettings.lighting.lightLayer;
			}
			set
			{
				this.m_ProbeSettings.lighting.lightLayer = value;
			}
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x06000792 RID: 1938 RVA: 0x00048D92 File Offset: 0x00046F92
		public uint lightLayersAsUInt
		{
			get
			{
				if (this.lightLayers >= LightLayerEnum.Nothing)
				{
					return (uint)this.lightLayers;
				}
				return 255U;
			}
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x06000793 RID: 1939 RVA: 0x00048DA9 File Offset: 0x00046FA9
		// (set) Token: 0x06000794 RID: 1940 RVA: 0x00048DBB File Offset: 0x00046FBB
		public float multiplier
		{
			get
			{
				return this.m_ProbeSettings.lighting.multiplier;
			}
			set
			{
				this.m_ProbeSettings.lighting.multiplier = value;
			}
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x06000795 RID: 1941 RVA: 0x00048DCE File Offset: 0x00046FCE
		// (set) Token: 0x06000796 RID: 1942 RVA: 0x00048DE0 File Offset: 0x00046FE0
		public float weight
		{
			get
			{
				return this.m_ProbeSettings.lighting.weight;
			}
			set
			{
				this.m_ProbeSettings.lighting.weight = value;
			}
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x06000797 RID: 1943 RVA: 0x00048DF3 File Offset: 0x00046FF3
		// (set) Token: 0x06000798 RID: 1944 RVA: 0x00048E05 File Offset: 0x00047005
		public float fadeDistance
		{
			get
			{
				return this.m_ProbeSettings.lighting.fadeDistance;
			}
			set
			{
				this.m_ProbeSettings.lighting.fadeDistance = value;
			}
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x06000799 RID: 1945 RVA: 0x00048E18 File Offset: 0x00047018
		// (set) Token: 0x0600079A RID: 1946 RVA: 0x00048E2A File Offset: 0x0004702A
		public float rangeCompressionFactor
		{
			get
			{
				return this.m_ProbeSettings.lighting.rangeCompressionFactor;
			}
			set
			{
				this.m_ProbeSettings.lighting.rangeCompressionFactor = value;
			}
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x0600079B RID: 1947 RVA: 0x00048E3D File Offset: 0x0004703D
		// (set) Token: 0x0600079C RID: 1948 RVA: 0x00048E45 File Offset: 0x00047045
		public ReflectionProxyVolumeComponent proxyVolume
		{
			get
			{
				return this.m_ProxyVolume;
			}
			set
			{
				this.m_ProxyVolume = value;
			}
		}

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x0600079D RID: 1949 RVA: 0x00048E4E File Offset: 0x0004704E
		// (set) Token: 0x0600079E RID: 1950 RVA: 0x00048E60 File Offset: 0x00047060
		public bool useInfluenceVolumeAsProxyVolume
		{
			get
			{
				return this.m_ProbeSettings.proxySettings.useInfluenceVolumeAsProxyVolume;
			}
			internal set
			{
				this.m_ProbeSettings.proxySettings.useInfluenceVolumeAsProxyVolume = value;
			}
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x0600079F RID: 1951 RVA: 0x00048E74 File Offset: 0x00047074
		public bool isProjectionInfinite
		{
			get
			{
				return (this.m_ProxyVolume != null && this.m_ProxyVolume.proxyVolume.shape == ProxyShape.Infinite) || (this.m_ProxyVolume == null && !this.m_ProbeSettings.proxySettings.useInfluenceVolumeAsProxyVolume);
			}
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x060007A0 RID: 1952 RVA: 0x00048EC8 File Offset: 0x000470C8
		// (set) Token: 0x060007A1 RID: 1953 RVA: 0x00048EF7 File Offset: 0x000470F7
		public InfluenceVolume influenceVolume
		{
			get
			{
				InfluenceVolume result;
				if ((result = this.m_ProbeSettings.influence) == null)
				{
					result = (this.m_ProbeSettings.influence = new InfluenceVolume());
				}
				return result;
			}
			private set
			{
				this.m_ProbeSettings.influence = value;
			}
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x060007A2 RID: 1954 RVA: 0x00048F05 File Offset: 0x00047105
		public ref FrameSettings frameSettings
		{
			get
			{
				return ref this.m_ProbeSettings.cameraSettings.renderingPathCustomFrameSettings;
			}
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x060007A3 RID: 1955 RVA: 0x00048F17 File Offset: 0x00047117
		public ref FrameSettingsOverrideMask frameSettingsOverrideMask
		{
			get
			{
				return ref this.m_ProbeSettings.cameraSettings.renderingPathCustomFrameSettingsOverrideMask;
			}
		}

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x060007A4 RID: 1956 RVA: 0x00048F29 File Offset: 0x00047129
		public Vector3 proxyExtents
		{
			get
			{
				if (!(this.proxyVolume != null))
				{
					return this.influenceExtents;
				}
				return this.proxyVolume.proxyVolume.extents;
			}
		}

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x060007A5 RID: 1957 RVA: 0x00048F50 File Offset: 0x00047150
		public BoundingSphere boundingSphere
		{
			get
			{
				return this.influenceVolume.GetBoundingSphereAt(base.transform.position);
			}
		}

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x060007A6 RID: 1958 RVA: 0x00048F68 File Offset: 0x00047168
		public Bounds bounds
		{
			get
			{
				return this.influenceVolume.GetBoundsAt(base.transform.position);
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x060007A7 RID: 1959 RVA: 0x00048F80 File Offset: 0x00047180
		public ref ProbeSettings settingsRaw
		{
			get
			{
				return ref this.m_ProbeSettings;
			}
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x060007A8 RID: 1960 RVA: 0x00048F88 File Offset: 0x00047188
		public ProbeSettings settings
		{
			get
			{
				ProbeSettings probeSettings = this.m_ProbeSettings;
				ReflectionProxyVolumeComponent proxyVolume = this.m_ProxyVolume;
				probeSettings.proxy = ((proxyVolume != null) ? proxyVolume.proxyVolume : null);
				probeSettings.influence = (probeSettings.influence ?? new InfluenceVolume());
				return probeSettings;
			}
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x060007A9 RID: 1961 RVA: 0x00048FCC File Offset: 0x000471CC
		internal Matrix4x4 influenceToWorld
		{
			get
			{
				return Matrix4x4.TRS(base.transform.position, base.transform.rotation, Vector3.one);
			}
		}

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x060007AA RID: 1962 RVA: 0x00048FEE File Offset: 0x000471EE
		internal Vector3 influenceExtents
		{
			get
			{
				return this.influenceVolume.extents;
			}
		}

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x060007AB RID: 1963 RVA: 0x00048FFC File Offset: 0x000471FC
		internal Matrix4x4 proxyToWorld
		{
			get
			{
				if (!(this.proxyVolume != null))
				{
					return this.influenceToWorld;
				}
				return Matrix4x4.TRS(this.proxyVolume.transform.position, this.proxyVolume.transform.rotation, Vector3.one);
			}
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x060007AC RID: 1964 RVA: 0x00049048 File Offset: 0x00047248
		// (set) Token: 0x060007AD RID: 1965 RVA: 0x00049050 File Offset: 0x00047250
		internal bool wasRenderedAfterOnEnable { get; private set; }

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x060007AE RID: 1966 RVA: 0x00049059 File Offset: 0x00047259
		internal bool hasEverRendered
		{
			get
			{
				return this.m_RealtimeRenderCount > 0U;
			}
		}

		// Token: 0x060007AF RID: 1967 RVA: 0x00049064 File Offset: 0x00047264
		internal void SetIsRendered()
		{
			switch (this.realtimeMode)
			{
			case ProbeSettings.RealtimeMode.EveryFrame:
				this.EnqueueAllRenderSteps();
				return;
			case ProbeSettings.RealtimeMode.OnEnable:
				if (!this.wasRenderedAfterOnEnable)
				{
					this.EnqueueAllRenderSteps();
					this.wasRenderedAfterOnEnable = true;
					return;
				}
				break;
			case ProbeSettings.RealtimeMode.OnDemand:
				if (!this.m_WasRenderedSinceLastOnDemandRequest)
				{
					this.EnqueueAllRenderSteps();
					this.m_WasRenderedSinceLastOnDemandRequest = true;
				}
				break;
			default:
				return;
			}
		}

		// Token: 0x060007B0 RID: 1968 RVA: 0x000490BD File Offset: 0x000472BD
		public virtual void PrepareCulling()
		{
		}

		// Token: 0x060007B1 RID: 1969 RVA: 0x000490BF File Offset: 0x000472BF
		public void RequestRenderNextUpdate()
		{
			this.m_WasRenderedSinceLastOnDemandRequest = false;
		}

		// Token: 0x060007B2 RID: 1970 RVA: 0x000490C8 File Offset: 0x000472C8
		internal void TryUpdateLuminanceSHL2ForNormalization()
		{
		}

		// Token: 0x060007B3 RID: 1971 RVA: 0x000490CC File Offset: 0x000472CC
		internal bool GetSHForNormalization(out Vector4 outL0L1, out Vector4 outL2_1, out float outL2_2)
		{
			HDRenderPipeline hdrenderPipeline = (HDRenderPipeline)RenderPipelineManager.currentPipeline;
			if (!this.m_HasValidSHForNormalization || !hdrenderPipeline.asset.currentPlatformRenderPipelineSettings.supportProbeVolume)
			{
				outL0L1 = (outL2_1 = Vector4.zero);
				outL2_2 = 0f;
				return false;
			}
			if (this.m_SHForNormalization[0, 0] == 3.4028235E+38f)
			{
				outL0L1 = new Vector4(float.MaxValue, 0f, 0f, 0f);
				outL2_1 = Vector4.zero;
				outL2_2 = 0f;
				return true;
			}
			Vector3 vector = SphericalHarmonicsL2Utils.GetCoefficient(this.m_SHForNormalization, 0);
			Vector3 coefficient = SphericalHarmonicsL2Utils.GetCoefficient(this.m_SHForNormalization, 1);
			Vector3 coefficient2 = SphericalHarmonicsL2Utils.GetCoefficient(this.m_SHForNormalization, 2);
			Vector3 coefficient3 = SphericalHarmonicsL2Utils.GetCoefficient(this.m_SHForNormalization, 3);
			Vector3 coefficient4 = SphericalHarmonicsL2Utils.GetCoefficient(this.m_SHForNormalization, 4);
			Vector3 coefficient5 = SphericalHarmonicsL2Utils.GetCoefficient(this.m_SHForNormalization, 5);
			Vector3 vector2 = SphericalHarmonicsL2Utils.GetCoefficient(this.m_SHForNormalization, 6);
			Vector3 coefficient6 = SphericalHarmonicsL2Utils.GetCoefficient(this.m_SHForNormalization, 7);
			Vector3 coefficient7 = SphericalHarmonicsL2Utils.GetCoefficient(this.m_SHForNormalization, 8);
			if (hdrenderPipeline.asset.currentPlatformRenderPipelineSettings.probeVolumeSHBands == ProbeVolumeSHBands.SphericalHarmonicsL2)
			{
				vector -= vector2;
				vector2 *= 3f;
			}
			Color color = new Color(vector.x, vector.y, vector.z);
			outL0L1.x = ColorUtils.Luminance(color);
			color = new Color(coefficient.x, coefficient.y, coefficient.z);
			outL0L1.y = ColorUtils.Luminance(color);
			color = new Color(coefficient2.x, coefficient2.y, coefficient2.z);
			outL0L1.z = ColorUtils.Luminance(color);
			color = new Color(coefficient3.x, coefficient3.y, coefficient3.z);
			outL0L1.w = ColorUtils.Luminance(color);
			color = new Color(coefficient4.x, coefficient4.y, coefficient4.z);
			outL2_1.x = ColorUtils.Luminance(color);
			color = new Color(coefficient5.x, coefficient5.y, coefficient5.z);
			outL2_1.y = ColorUtils.Luminance(color);
			color = new Color(vector2.x, vector2.y, vector2.z);
			outL2_1.z = ColorUtils.Luminance(color);
			color = new Color(coefficient6.x, coefficient6.y, coefficient6.z);
			outL2_1.w = ColorUtils.Luminance(color);
			color = new Color(coefficient7.x, coefficient7.y, coefficient7.z);
			outL2_2 = ColorUtils.Luminance(color);
			return true;
		}

		// Token: 0x060007B4 RID: 1972 RVA: 0x00049378 File Offset: 0x00047578
		private void UpdateProbeName()
		{
			if (this.settings.type == ProbeSettings.ProbeType.ReflectionProbe)
			{
				for (int i = 0; i < 6; i++)
				{
					this.probeName[i] = string.Format("Reflection Probe RenderCamera ({0}: {1})", base.name, (CubemapFace)i);
				}
				return;
			}
			this.probeName[0] = "Planar Probe RenderCamera (" + base.name + ")";
		}

		// Token: 0x060007B5 RID: 1973 RVA: 0x000493DA File Offset: 0x000475DA
		private void DequeueSHRequest()
		{
		}

		// Token: 0x060007B6 RID: 1974 RVA: 0x000493DC File Offset: 0x000475DC
		private void SetOrReleaseCustomTextureReference()
		{
		}

		// Token: 0x060007B7 RID: 1975 RVA: 0x000493DE File Offset: 0x000475DE
		private void OnEnable()
		{
			this.wasRenderedAfterOnEnable = false;
			this.PrepareCulling();
			HDProbeSystem.RegisterProbe(this);
			this.UpdateProbeName();
		}

		// Token: 0x060007B8 RID: 1976 RVA: 0x000493F9 File Offset: 0x000475F9
		private void OnDisable()
		{
			HDProbeSystem.UnregisterProbe(this);
		}

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x060007B9 RID: 1977 RVA: 0x00049401 File Offset: 0x00047601
		// (set) Token: 0x060007BA RID: 1978 RVA: 0x00049409 File Offset: 0x00047609
		HDProbe.Version IVersionable<HDProbe.Version>.version
		{
			get
			{
				return this.m_HDProbeVersion;
			}
			set
			{
				this.m_HDProbeVersion = value;
			}
		}

		// Token: 0x04000769 RID: 1897
		[SerializeField]
		protected ProbeSettings m_ProbeSettings = ProbeSettings.NewDefault();

		// Token: 0x0400076A RID: 1898
		[SerializeField]
		private ProbeSettingsOverride m_ProbeSettingsOverride;

		// Token: 0x0400076B RID: 1899
		[SerializeField]
		private ReflectionProxyVolumeComponent m_ProxyVolume;

		// Token: 0x0400076C RID: 1900
		[SerializeField]
		private Texture m_BakedTexture;

		// Token: 0x0400076D RID: 1901
		[SerializeField]
		private Texture m_CustomTexture;

		// Token: 0x0400076E RID: 1902
		[SerializeField]
		private HDProbe.RenderData m_BakedRenderData;

		// Token: 0x0400076F RID: 1903
		[SerializeField]
		private HDProbe.RenderData m_CustomRenderData;

		// Token: 0x04000770 RID: 1904
		private RTHandle m_RealtimeTexture;

		// Token: 0x04000771 RID: 1905
		private RTHandle m_RealtimeDepthBuffer;

		// Token: 0x04000772 RID: 1906
		private HDProbe.RenderData m_RealtimeRenderData;

		// Token: 0x04000773 RID: 1907
		private bool m_WasRenderedSinceLastOnDemandRequest = true;

		// Token: 0x04000774 RID: 1908
		private ProbeRenderSteps m_RemainingRenderSteps;

		// Token: 0x04000775 RID: 1909
		private bool m_HasPendingRenderRequest;

		// Token: 0x04000776 RID: 1910
		private uint m_RealtimeRenderCount;

		// Token: 0x04000777 RID: 1911
		private int m_LastStepFrameCount = -1;

		// Token: 0x04000778 RID: 1912
		[SerializeField]
		private bool m_HasValidSHForNormalization;

		// Token: 0x04000779 RID: 1913
		[SerializeField]
		private SphericalHarmonicsL2 m_SHForNormalization;

		// Token: 0x0400077A RID: 1914
		[SerializeField]
		private Vector3 m_SHValidForCapturePosition;

		// Token: 0x0400077B RID: 1915
		[SerializeField]
		private Vector3 m_SHValidForSourcePosition;

		// Token: 0x0400077C RID: 1916
		internal string[] probeName = new string[6];

		// Token: 0x0400077D RID: 1917
		private float m_ProbeExposureValue = 1f;

		// Token: 0x04000780 RID: 1920
		protected static readonly MigrationDescription<HDProbe.Version, HDProbe> k_Migration = MigrationDescription.New<HDProbe.Version, HDProbe>(new MigrationStep<HDProbe.Version, HDProbe>[]
		{
			MigrationStep.New<HDProbe.Version, HDProbe>(HDProbe.Version.ProbeSettings, delegate(HDProbe p)
			{
				p.m_ProbeSettings.influence = new InfluenceVolume();
				if (p.m_ObsoleteInfluenceVolume != null)
				{
					p.m_ObsoleteInfluenceVolume.CopyTo(p.m_ProbeSettings.influence);
				}
				p.m_ProbeSettings.cameraSettings.m_ObsoleteFrameSettings = p.m_ObsoleteFrameSettings;
				p.m_ProbeSettings.lighting.multiplier = p.m_ObsoleteMultiplier;
				p.m_ProbeSettings.lighting.weight = p.m_ObsoleteWeight;
				p.m_ProbeSettings.lighting.lightLayer = p.m_ObsoleteLightLayers;
				p.m_ProbeSettings.mode = p.m_ObsoleteMode;
				p.m_ProbeSettings.cameraSettings.bufferClearing.clearColorMode = p.m_ObsoleteCaptureSettings.clearColorMode;
				p.m_ProbeSettings.cameraSettings.bufferClearing.backgroundColorHDR = p.m_ObsoleteCaptureSettings.backgroundColorHDR;
				p.m_ProbeSettings.cameraSettings.bufferClearing.clearDepth = p.m_ObsoleteCaptureSettings.clearDepth;
				p.m_ProbeSettings.cameraSettings.culling.cullingMask = p.m_ObsoleteCaptureSettings.cullingMask;
				p.m_ProbeSettings.cameraSettings.culling.useOcclusionCulling = p.m_ObsoleteCaptureSettings.useOcclusionCulling;
				p.m_ProbeSettings.cameraSettings.frustum.nearClipPlaneRaw = p.m_ObsoleteCaptureSettings.nearClipPlane;
				p.m_ProbeSettings.cameraSettings.frustum.farClipPlaneRaw = p.m_ObsoleteCaptureSettings.farClipPlane;
				p.m_ProbeSettings.cameraSettings.volumes.layerMask = p.m_ObsoleteCaptureSettings.volumeLayerMask;
				p.m_ProbeSettings.cameraSettings.volumes.anchorOverride = p.m_ObsoleteCaptureSettings.volumeAnchorOverride;
				p.m_ProbeSettings.cameraSettings.frustum.fieldOfView = p.m_ObsoleteCaptureSettings.fieldOfView;
				p.m_ProbeSettings.cameraSettings.m_ObsoleteRenderingPath = p.m_ObsoleteCaptureSettings.renderingPath;
			}),
			MigrationStep.New<HDProbe.Version, HDProbe>(HDProbe.Version.SeparatePassThrough, delegate(HDProbe p)
			{
				p.m_ProbeSettings.cameraSettings.customRenderingSettings = (p.m_ProbeSettings.cameraSettings.m_ObsoleteRenderingPath == 1);
			}),
			MigrationStep.New<HDProbe.Version, HDProbe>(HDProbe.Version.UpgradeFrameSettingsToStruct, delegate(HDProbe data)
			{
				if (data.m_ObsoleteFrameSettings != null)
				{
					FrameSettings.MigrateFromClassVersion(ref data.m_ProbeSettings.cameraSettings.m_ObsoleteFrameSettings, ref data.m_ProbeSettings.cameraSettings.renderingPathCustomFrameSettings, ref data.m_ProbeSettings.cameraSettings.renderingPathCustomFrameSettingsOverrideMask);
				}
			}),
			MigrationStep.New<HDProbe.Version, HDProbe>(HDProbe.Version.AddReflectionFrameSetting, delegate(HDProbe data)
			{
				FrameSettings.MigrateToNoReflectionSettings(ref data.m_ProbeSettings.cameraSettings.renderingPathCustomFrameSettings);
			}),
			MigrationStep.New<HDProbe.Version, HDProbe>(HDProbe.Version.AddFrameSettingDirectSpecularLighting, delegate(HDProbe data)
			{
				FrameSettings.MigrateToNoDirectSpecularLighting(ref data.m_ProbeSettings.cameraSettings.renderingPathCustomFrameSettings);
			}),
			MigrationStep.New<HDProbe.Version, HDProbe>(HDProbe.Version.UpdateMSAA, delegate(HDProbe data)
			{
				FrameSettings.MigrateMSAA(ref data.m_ProbeSettings.cameraSettings.renderingPathCustomFrameSettings, ref data.m_ProbeSettings.cameraSettings.renderingPathCustomFrameSettingsOverrideMask);
			})
		});

		// Token: 0x04000781 RID: 1921
		[SerializeField]
		private HDProbe.Version m_HDProbeVersion;

		// Token: 0x04000782 RID: 1922
		[SerializeField]
		[FormerlySerializedAs("m_InfiniteProjection")]
		[Obsolete("For Data Migration")]
		protected bool m_ObsoleteInfiniteProjection = true;

		// Token: 0x04000783 RID: 1923
		[SerializeField]
		[FormerlySerializedAs("m_InfluenceVolume")]
		[Obsolete("For Data Migration")]
		protected InfluenceVolume m_ObsoleteInfluenceVolume;

		// Token: 0x04000784 RID: 1924
		[SerializeField]
		[FormerlySerializedAs("m_FrameSettings")]
		[Obsolete("For Data Migration")]
		private ObsoleteFrameSettings m_ObsoleteFrameSettings;

		// Token: 0x04000785 RID: 1925
		[SerializeField]
		[FormerlySerializedAs("m_Multiplier")]
		[FormerlySerializedAs("dimmer")]
		[FormerlySerializedAs("m_Dimmer")]
		[FormerlySerializedAs("multiplier")]
		[Obsolete("For Data Migration")]
		protected float m_ObsoleteMultiplier = 1f;

		// Token: 0x04000786 RID: 1926
		[SerializeField]
		[FormerlySerializedAs("m_Weight")]
		[FormerlySerializedAs("weight")]
		[Obsolete("For Data Migration")]
		[Range(0f, 1f)]
		protected float m_ObsoleteWeight = 1f;

		// Token: 0x04000787 RID: 1927
		[SerializeField]
		[FormerlySerializedAs("m_Mode")]
		[Obsolete("For Data Migration")]
		protected ProbeSettings.Mode m_ObsoleteMode;

		// Token: 0x04000788 RID: 1928
		[SerializeField]
		[FormerlySerializedAs("lightLayers")]
		[Obsolete("For Data Migration")]
		private LightLayerEnum m_ObsoleteLightLayers = LightLayerEnum.LightLayerDefault;

		// Token: 0x04000789 RID: 1929
		[SerializeField]
		[FormerlySerializedAs("m_CaptureSettings")]
		[Obsolete("For Data Migration")]
		internal ObsoleteCaptureSettings m_ObsoleteCaptureSettings;

		// Token: 0x0200033D RID: 829
		[Serializable]
		public struct RenderData
		{
			// Token: 0x17000283 RID: 643
			// (get) Token: 0x0600129E RID: 4766 RVA: 0x0008F264 File Offset: 0x0008D464
			public Matrix4x4 worldToCameraRHS
			{
				get
				{
					return this.m_WorldToCameraRHS;
				}
			}

			// Token: 0x17000284 RID: 644
			// (get) Token: 0x0600129F RID: 4767 RVA: 0x0008F26C File Offset: 0x0008D46C
			public Matrix4x4 projectionMatrix
			{
				get
				{
					return this.m_ProjectionMatrix;
				}
			}

			// Token: 0x17000285 RID: 645
			// (get) Token: 0x060012A0 RID: 4768 RVA: 0x0008F274 File Offset: 0x0008D474
			public Vector3 capturePosition
			{
				get
				{
					return this.m_CapturePosition;
				}
			}

			// Token: 0x17000286 RID: 646
			// (get) Token: 0x060012A1 RID: 4769 RVA: 0x0008F27C File Offset: 0x0008D47C
			public Quaternion captureRotation
			{
				get
				{
					return this.m_CaptureRotation;
				}
			}

			// Token: 0x17000287 RID: 647
			// (get) Token: 0x060012A2 RID: 4770 RVA: 0x0008F284 File Offset: 0x0008D484
			public float fieldOfView
			{
				get
				{
					return this.m_FieldOfView;
				}
			}

			// Token: 0x17000288 RID: 648
			// (get) Token: 0x060012A3 RID: 4771 RVA: 0x0008F28C File Offset: 0x0008D48C
			public float aspect
			{
				get
				{
					return this.m_Aspect;
				}
			}

			// Token: 0x060012A4 RID: 4772 RVA: 0x0008F294 File Offset: 0x0008D494
			public RenderData(CameraSettings camera, CameraPositionSettings position)
			{
				this = new HDProbe.RenderData(position.GetUsedWorldToCameraMatrix(), camera.frustum.GetUsedProjectionMatrix(), position.position, position.rotation, camera.frustum.fieldOfView, camera.frustum.aspect);
			}

			// Token: 0x060012A5 RID: 4773 RVA: 0x0008F2D1 File Offset: 0x0008D4D1
			public RenderData(Matrix4x4 worldToCameraRHS, Matrix4x4 projectionMatrix, Vector3 capturePosition, Quaternion captureRotation, float fov, float aspect)
			{
				this.m_WorldToCameraRHS = worldToCameraRHS;
				this.m_ProjectionMatrix = projectionMatrix;
				this.m_CapturePosition = capturePosition;
				this.m_CaptureRotation = captureRotation;
				this.m_FieldOfView = fov;
				this.m_Aspect = aspect;
			}

			// Token: 0x0400231C RID: 8988
			[SerializeField]
			[FormerlySerializedAs("worldToCameraRHS")]
			private Matrix4x4 m_WorldToCameraRHS;

			// Token: 0x0400231D RID: 8989
			[SerializeField]
			[FormerlySerializedAs("projectionMatrix")]
			private Matrix4x4 m_ProjectionMatrix;

			// Token: 0x0400231E RID: 8990
			[SerializeField]
			[FormerlySerializedAs("capturePosition")]
			private Vector3 m_CapturePosition;

			// Token: 0x0400231F RID: 8991
			[SerializeField]
			private Quaternion m_CaptureRotation;

			// Token: 0x04002320 RID: 8992
			[SerializeField]
			private float m_FieldOfView;

			// Token: 0x04002321 RID: 8993
			[SerializeField]
			private float m_Aspect;
		}

		// Token: 0x0200033E RID: 830
		protected enum Version
		{
			// Token: 0x04002323 RID: 8995
			Initial,
			// Token: 0x04002324 RID: 8996
			ProbeSettings,
			// Token: 0x04002325 RID: 8997
			SeparatePassThrough,
			// Token: 0x04002326 RID: 8998
			UpgradeFrameSettingsToStruct,
			// Token: 0x04002327 RID: 8999
			AddFrameSettingSpecularLighting,
			// Token: 0x04002328 RID: 9000
			AddReflectionFrameSetting,
			// Token: 0x04002329 RID: 9001
			AddFrameSettingDirectSpecularLighting,
			// Token: 0x0400232A RID: 9002
			PlanarResolutionScalability,
			// Token: 0x0400232B RID: 9003
			UpdateMSAA
		}
	}
}
