using System;
using Unity.Collections;
using UnityEngine.Experimental.Rendering;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001EE RID: 494
	internal class SkyRenderingContext
	{
		// Token: 0x1700024B RID: 587
		// (get) Token: 0x06000F08 RID: 3848 RVA: 0x00076DD3 File Offset: 0x00074FD3
		public SphericalHarmonicsL2 ambientProbe
		{
			get
			{
				return this.m_AmbientProbe;
			}
		}

		// Token: 0x1700024C RID: 588
		// (get) Token: 0x06000F09 RID: 3849 RVA: 0x00076DDB File Offset: 0x00074FDB
		// (set) Token: 0x06000F0A RID: 3850 RVA: 0x00076DE3 File Offset: 0x00074FE3
		public ComputeBuffer ambientProbeResult { get; private set; }

		// Token: 0x1700024D RID: 589
		// (get) Token: 0x06000F0B RID: 3851 RVA: 0x00076DEC File Offset: 0x00074FEC
		// (set) Token: 0x06000F0C RID: 3852 RVA: 0x00076DF4 File Offset: 0x00074FF4
		public ComputeBuffer diffuseAmbientProbeBuffer { get; private set; }

		// Token: 0x1700024E RID: 590
		// (get) Token: 0x06000F0D RID: 3853 RVA: 0x00076DFD File Offset: 0x00074FFD
		// (set) Token: 0x06000F0E RID: 3854 RVA: 0x00076E05 File Offset: 0x00075005
		public ComputeBuffer volumetricAmbientProbeBuffer { get; private set; }

		// Token: 0x1700024F RID: 591
		// (get) Token: 0x06000F0F RID: 3855 RVA: 0x00076E0E File Offset: 0x0007500E
		// (set) Token: 0x06000F10 RID: 3856 RVA: 0x00076E16 File Offset: 0x00075016
		public ComputeBuffer cloudAmbientProbeBuffer { get; private set; }

		// Token: 0x17000250 RID: 592
		// (get) Token: 0x06000F11 RID: 3857 RVA: 0x00076E1F File Offset: 0x0007501F
		// (set) Token: 0x06000F12 RID: 3858 RVA: 0x00076E27 File Offset: 0x00075027
		public RTHandle skyboxCubemapRT { get; private set; }

		// Token: 0x17000251 RID: 593
		// (get) Token: 0x06000F13 RID: 3859 RVA: 0x00076E30 File Offset: 0x00075030
		// (set) Token: 0x06000F14 RID: 3860 RVA: 0x00076E38 File Offset: 0x00075038
		public CubemapArray skyboxBSDFCubemapArray { get; private set; }

		// Token: 0x17000252 RID: 594
		// (get) Token: 0x06000F15 RID: 3861 RVA: 0x00076E41 File Offset: 0x00075041
		// (set) Token: 0x06000F16 RID: 3862 RVA: 0x00076E49 File Offset: 0x00075049
		public bool supportsConvolution { get; private set; }

		// Token: 0x06000F17 RID: 3863 RVA: 0x00076E54 File Offset: 0x00075054
		public SkyRenderingContext(int resolution, int bsdfCount, bool supportsConvolution, SphericalHarmonicsL2 ambientProbe, string name)
		{
			this.m_AmbientProbe = ambientProbe;
			this.supportsConvolution = supportsConvolution;
			this.ambientProbeResult = new ComputeBuffer(27, 4);
			this.volumetricAmbientProbeBuffer = new ComputeBuffer(7, 16);
			this.diffuseAmbientProbeBuffer = new ComputeBuffer(7, 16);
			this.cloudAmbientProbeBuffer = new ComputeBuffer(7, 16);
			this.skyboxCubemapRT = RTHandles.Alloc(resolution, resolution, 1, DepthBits.None, GraphicsFormat.R16G16B16A16_SFloat, FilterMode.Trilinear, TextureWrapMode.Repeat, TextureDimension.Cube, false, true, false, false, 1, 0f, MSAASamples.None, false, false, RenderTextureMemoryless.None, VRTextureUsage.None, name);
			if (supportsConvolution)
			{
				this.skyboxBSDFCubemapArray = new CubemapArray(resolution, bsdfCount, GraphicsFormat.R16G16B16A16_SFloat, TextureCreationFlags.MipChain)
				{
					hideFlags = HideFlags.HideAndDontSave,
					wrapMode = TextureWrapMode.Repeat,
					wrapModeV = TextureWrapMode.Clamp,
					filterMode = FilterMode.Trilinear,
					anisoLevel = 0,
					name = "SkyboxCubemapConvolution"
				};
			}
		}

		// Token: 0x06000F18 RID: 3864 RVA: 0x00076F15 File Offset: 0x00075115
		public void Reset()
		{
			this.ambientProbeIsReady = false;
		}

		// Token: 0x06000F19 RID: 3865 RVA: 0x00076F20 File Offset: 0x00075120
		public void Cleanup()
		{
			RTHandles.Release(this.skyboxCubemapRT);
			if (this.skyboxBSDFCubemapArray != null)
			{
				CoreUtils.Destroy(this.skyboxBSDFCubemapArray);
			}
			this.ambientProbeResult.Release();
			this.diffuseAmbientProbeBuffer.Release();
			this.volumetricAmbientProbeBuffer.Release();
			this.cloudAmbientProbeBuffer.Release();
		}

		// Token: 0x06000F1A RID: 3866 RVA: 0x00076F7D File Offset: 0x0007517D
		public void ClearAmbientProbe()
		{
			this.m_AmbientProbe = default(SphericalHarmonicsL2);
		}

		// Token: 0x06000F1B RID: 3867 RVA: 0x00076F8B File Offset: 0x0007518B
		public void UpdateAmbientProbe(in SphericalHarmonicsL2 probe)
		{
			this.m_AmbientProbe = probe;
		}

		// Token: 0x06000F1C RID: 3868 RVA: 0x00076F9C File Offset: 0x0007519C
		public void OnComputeAmbientProbeDone(AsyncGPUReadbackRequest request)
		{
			if (!request.hasError)
			{
				NativeArray<float> data = request.GetData<float>(0);
				for (int i = 0; i < 3; i++)
				{
					for (int j = 0; j < 9; j++)
					{
						this.m_AmbientProbe[i, j] = data[i * 9 + j];
					}
				}
				this.ambientProbeIsReady = true;
			}
		}

		// Token: 0x04001795 RID: 6037
		private SphericalHarmonicsL2 m_AmbientProbe;

		// Token: 0x0400179D RID: 6045
		internal bool ambientProbeIsReady;
	}
}
