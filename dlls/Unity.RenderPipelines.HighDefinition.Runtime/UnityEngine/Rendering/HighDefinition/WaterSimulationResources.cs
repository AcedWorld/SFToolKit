using System;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine.Experimental.Rendering;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200021A RID: 538
	internal class WaterSimulationResources
	{
		// Token: 0x06000FBF RID: 4031 RVA: 0x0007A1D0 File Offset: 0x000783D0
		public void AllocateSimulationBuffersGPU()
		{
			this.gpuBuffers = new WaterSimulationResourcesGPU();
			this.gpuBuffers.phillipsSpectrumBuffer = RTHandles.Alloc(this.simulationResolution, this.simulationResolution, this.maxNumBands, DepthBits.None, GraphicsFormat.R16G16_SFloat, FilterMode.Point, TextureWrapMode.Repeat, TextureDimension.Tex2DArray, true, false, true, false, 1, 0f, MSAASamples.None, false, false, RenderTextureMemoryless.None, VRTextureUsage.None, "");
			this.gpuBuffers.displacementBuffer = RTHandles.Alloc(this.simulationResolution, this.simulationResolution, this.maxNumBands, DepthBits.None, GraphicsFormat.R16G16B16A16_SFloat, FilterMode.Point, TextureWrapMode.Repeat, TextureDimension.Tex2DArray, true, false, true, false, 1, 0f, MSAASamples.None, false, false, RenderTextureMemoryless.None, VRTextureUsage.None, "");
			this.gpuBuffers.additionalDataBuffer = RTHandles.Alloc(this.simulationResolution, this.simulationResolution, this.maxNumBands, DepthBits.None, GraphicsFormat.R16G16B16A16_SFloat, FilterMode.Point, TextureWrapMode.Repeat, TextureDimension.Tex2DArray, true, true, false, false, 1, 0f, MSAASamples.None, false, false, RenderTextureMemoryless.None, VRTextureUsage.None, "");
		}

		// Token: 0x06000FC0 RID: 4032 RVA: 0x0007A29C File Offset: 0x0007849C
		public void ReleaseSimulationBuffersGPU()
		{
			if (this.gpuBuffers != null)
			{
				RTHandles.Release(this.gpuBuffers.additionalDataBuffer);
				RTHandles.Release(this.gpuBuffers.displacementBuffer);
				RTHandles.Release(this.gpuBuffers.phillipsSpectrumBuffer);
				RTHandles.Release(this.gpuBuffers.causticsBuffer);
				this.gpuBuffers = null;
			}
		}

		// Token: 0x06000FC1 RID: 4033 RVA: 0x0007A2F8 File Offset: 0x000784F8
		public void AllocateSimulationBuffersCPU()
		{
			this.cpuBuffers = new WaterSimulationResourcesCPU();
			this.cpuBuffers.h0BufferCPU = new NativeArray<float2>(this.simulationResolution * this.simulationResolution * this.maxNumBands, Allocator.Persistent, NativeArrayOptions.ClearMemory);
			this.cpuBuffers.displacementBufferCPU = new NativeArray<float4>(this.simulationResolution * this.simulationResolution * this.maxNumBands, Allocator.Persistent, NativeArrayOptions.ClearMemory);
		}

		// Token: 0x06000FC2 RID: 4034 RVA: 0x0007A35C File Offset: 0x0007855C
		public void ReleaseSimulationBuffersCPU()
		{
			if (this.cpuBuffers != null)
			{
				this.cpuBuffers.h0BufferCPU.Dispose();
				this.cpuBuffers.displacementBufferCPU.Dispose();
				this.cpuBuffers = null;
			}
		}

		// Token: 0x06000FC3 RID: 4035 RVA: 0x0007A38D File Offset: 0x0007858D
		public void InitializeSimulationResources(int simulationRes, int nbBands)
		{
			this.simulationResolution = simulationRes;
			this.maxNumBands = nbBands;
			this.m_Time = Time.realtimeSinceStartup;
		}

		// Token: 0x06000FC4 RID: 4036 RVA: 0x0007A3A8 File Offset: 0x000785A8
		public bool ValidResources(int simulationRes, int nbBands)
		{
			return simulationRes == this.simulationResolution && nbBands == this.maxNumBands && this.AllocatedTextures();
		}

		// Token: 0x06000FC5 RID: 4037 RVA: 0x0007A3C4 File Offset: 0x000785C4
		public bool AllocatedTextures()
		{
			return this.gpuBuffers != null;
		}

		// Token: 0x06000FC6 RID: 4038 RVA: 0x0007A3D0 File Offset: 0x000785D0
		public void CheckCausticsResources(bool used, int causticsResolution)
		{
			if (used)
			{
				bool flag = true;
				if (this.gpuBuffers.causticsBuffer != null)
				{
					flag = (this.gpuBuffers.causticsBuffer.rt.width != causticsResolution);
					if (flag)
					{
						RTHandles.Release(this.gpuBuffers.causticsBuffer);
					}
				}
				if (flag)
				{
					this.gpuBuffers.causticsBuffer = RTHandles.Alloc(causticsResolution, causticsResolution, 1, DepthBits.None, GraphicsFormat.R16_SFloat, FilterMode.Bilinear, TextureWrapMode.Repeat, TextureDimension.Tex2D, true, true, false, false, 1, 0f, MSAASamples.None, false, false, RenderTextureMemoryless.None, VRTextureUsage.None, "");
					return;
				}
			}
			else if (this.gpuBuffers.causticsBuffer != null)
			{
				RTHandles.Release(this.gpuBuffers.causticsBuffer);
				this.gpuBuffers.causticsBuffer = null;
			}
		}

		// Token: 0x06000FC7 RID: 4039 RVA: 0x0007A478 File Offset: 0x00078678
		public void Update(float timeMultiplier)
		{
			float num = Application.isPlaying ? Time.time : Time.realtimeSinceStartup;
			float num2 = num - this.m_Time;
			this.m_Time = num;
			this.deltaTime = num2 * timeMultiplier;
			this.simulationTime += this.deltaTime;
		}

		// Token: 0x06000FC8 RID: 4040 RVA: 0x0007A4C8 File Offset: 0x000786C8
		public void ReleaseSimulationResources()
		{
			this.ReleaseSimulationBuffersGPU();
			this.ReleaseSimulationBuffersCPU();
			this.spectrum.numActiveBands = 0;
			this.spectrum.patchSizes = Vector4.zero;
			this.spectrum.patchWindSpeed = Vector4.zero;
			this.spectrum.patchWindOrientation = Vector4.zero;
			this.spectrum.patchWindDirDampener = Vector4.zero;
			this.rendering.patchAmplitudeMultiplier = Vector4.zero;
			this.rendering.patchCurrentSpeed = Vector4.zero;
			this.rendering.patchCurrentOrientation = Vector4.zero;
			this.rendering.patchFadeStart = Vector4.zero;
			this.rendering.patchFadeDistance = Vector4.zero;
			this.rendering.patchFadeValue = Vector4.zero;
			this.simulationResolution = 0;
			this.maxNumBands = 0;
			this.simulationTime = 0f;
			this.deltaTime = 0f;
		}

		// Token: 0x04001856 RID: 6230
		private float m_Time;

		// Token: 0x04001857 RID: 6231
		public float simulationTime;

		// Token: 0x04001858 RID: 6232
		public float deltaTime;

		// Token: 0x04001859 RID: 6233
		public int simulationResolution;

		// Token: 0x0400185A RID: 6234
		public int maxNumBands;

		// Token: 0x0400185B RID: 6235
		public WaterSurfaceType surfaceType;

		// Token: 0x0400185C RID: 6236
		public WaterSpectrumParameters spectrum;

		// Token: 0x0400185D RID: 6237
		public WaterRenderingParameters rendering;

		// Token: 0x0400185E RID: 6238
		public WaterSimulationResourcesGPU gpuBuffers;

		// Token: 0x0400185F RID: 6239
		public WaterSimulationResourcesCPU cpuBuffers;
	}
}
