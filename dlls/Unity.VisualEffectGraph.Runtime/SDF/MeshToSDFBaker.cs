using System;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;

namespace UnityEngine.VFX.SDF
{
	// Token: 0x02000020 RID: 32
	public class MeshToSDFBaker : IDisposable
	{
		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600007A RID: 122 RVA: 0x00003CF6 File Offset: 0x00001EF6
		public RenderTexture SdfTexture
		{
			get
			{
				return this.m_DistanceTexture;
			}
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00003D00 File Offset: 0x00001F00
		private static Mesh InitMeshFromList(List<Mesh> meshes, List<Matrix4x4> transforms)
		{
			int count = meshes.Count;
			if (count != transforms.Count)
			{
				throw new ArgumentException("The number of meshes must be the same as the number of transforms");
			}
			List<CombineInstance> list = new List<CombineInstance>();
			for (int i = 0; i < count; i++)
			{
				Mesh mesh = meshes[i];
				for (int j = 0; j < mesh.subMeshCount; j++)
				{
					list.Add(new CombineInstance
					{
						mesh = meshes[i],
						subMeshIndex = j,
						transform = transforms[i]
					});
				}
			}
			Mesh mesh2 = new Mesh();
			mesh2.indexFormat = IndexFormat.UInt32;
			mesh2.CombineMeshes(list.ToArray());
			return mesh2;
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00003DA4 File Offset: 0x00001FA4
		private void InitCommandBuffer()
		{
			if (this.m_Cmd == null)
			{
				this.m_Cmd = new CommandBuffer
				{
					name = "SDFBakingCommand"
				};
			}
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00003DC4 File Offset: 0x00001FC4
		private int GetTotalVoxelCount()
		{
			return this.m_Dimensions[0] * this.m_Dimensions[1] * this.m_Dimensions[2];
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00003DE0 File Offset: 0x00001FE0
		private void InitSizeBox()
		{
			this.m_MaxExtent = Mathf.Max(this.m_SizeBox.x, Mathf.Max(this.m_SizeBox.y, this.m_SizeBox.z));
			float num = 0f;
			if (this.m_MaxExtent == this.m_SizeBox.x)
			{
				this.m_Dimensions[0] = Mathf.Max(Mathf.RoundToInt((float)this.m_maxResolution * this.m_SizeBox.x / this.m_MaxExtent), 1);
				this.m_Dimensions[1] = Mathf.Max(Mathf.CeilToInt((float)this.m_maxResolution * this.m_SizeBox.y / this.m_MaxExtent), 1);
				this.m_Dimensions[2] = Mathf.Max(Mathf.CeilToInt((float)this.m_maxResolution * this.m_SizeBox.z / this.m_MaxExtent), 1);
				num = this.m_MaxExtent / (float)this.m_Dimensions[0];
			}
			else if (this.m_MaxExtent == this.m_SizeBox.y)
			{
				this.m_Dimensions[1] = Mathf.Max(Mathf.RoundToInt((float)this.m_maxResolution * this.m_SizeBox.y / this.m_MaxExtent), 1);
				this.m_Dimensions[0] = Mathf.Max(Mathf.CeilToInt((float)this.m_maxResolution * this.m_SizeBox.x / this.m_MaxExtent), 1);
				this.m_Dimensions[2] = Mathf.Max(Mathf.CeilToInt((float)this.m_maxResolution * this.m_SizeBox.z / this.m_MaxExtent), 1);
				num = this.m_MaxExtent / (float)this.m_Dimensions[1];
			}
			else if (this.m_MaxExtent == this.m_SizeBox.z)
			{
				this.m_Dimensions[2] = Mathf.Max(Mathf.RoundToInt((float)this.m_maxResolution * this.m_SizeBox.z / this.m_MaxExtent), 1);
				this.m_Dimensions[1] = Mathf.Max(Mathf.CeilToInt((float)this.m_maxResolution * this.m_SizeBox.y / this.m_MaxExtent), 1);
				this.m_Dimensions[0] = Mathf.Max(Mathf.CeilToInt((float)this.m_maxResolution * this.m_SizeBox.x / this.m_MaxExtent), 1);
				num = this.m_MaxExtent / (float)this.m_Dimensions[2];
			}
			if ((long)this.GetTotalVoxelCount() > (long)((ulong)MeshToSDFBaker.kMaxAbsoluteGridSize))
			{
				throw new ArgumentException(string.Format("The size of the voxel grid is too big (>2^{0}), reduce the resolution, or provide a thinner bounding box.", Mathf.Log(MeshToSDFBaker.kMaxAbsoluteGridSize, 2f)));
			}
			for (int i = 0; i < 3; i++)
			{
				this.m_SizeBox[i] = (float)this.m_Dimensions[i] * num;
			}
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00004090 File Offset: 0x00002290
		public Vector3Int GetGridSize()
		{
			return new Vector3Int(this.m_Dimensions[0], this.m_Dimensions[1], this.m_Dimensions[2]);
		}

		// Token: 0x06000080 RID: 128 RVA: 0x000040AF File Offset: 0x000022AF
		public Vector3 GetActualBoxSize()
		{
			return this.m_SizeBox;
		}

		// Token: 0x06000081 RID: 129 RVA: 0x000040B8 File Offset: 0x000022B8
		public MeshToSDFBaker(Vector3 sizeBox, Vector3 center, int maxRes, Mesh mesh, int signPassesCount = 1, float threshold = 0.5f, float sdfOffset = 0f, CommandBuffer cmd = null)
		{
			this.LoadRuntimeResources();
			this.m_Mesh = mesh;
			if (cmd != null)
			{
				this.m_Cmd = cmd;
				this.m_OwnsCommandBuffer = false;
			}
			this.SetParameters(sizeBox, center, maxRes, signPassesCount, threshold, sdfOffset);
			this.Init();
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00004144 File Offset: 0x00002344
		public MeshToSDFBaker(Vector3 sizeBox, Vector3 center, int maxRes, List<Mesh> meshes, List<Matrix4x4> transforms, int signPassesCount = 1, float threshold = 0.5f, float sdfOffset = 0f, CommandBuffer cmd = null) : this(sizeBox, center, maxRes, MeshToSDFBaker.InitMeshFromList(meshes, transforms), signPassesCount, threshold, sdfOffset, cmd)
		{
		}

		// Token: 0x06000083 RID: 131 RVA: 0x0000416C File Offset: 0x0000236C
		~MeshToSDFBaker()
		{
			if (!this.m_IsDisposed)
			{
				Debug.LogWarning("Dispose() should be called explicitly when an MeshToSDFBaker instance is finished being used.");
			}
		}

		// Token: 0x06000084 RID: 132 RVA: 0x000041A4 File Offset: 0x000023A4
		public void Reinit(Vector3 sizeBox, Vector3 center, int maxRes, Mesh mesh, int signPassesCount = 1, float threshold = 0.5f, float sdfOffset = 0f)
		{
			this.m_Mesh = mesh;
			this.SetParameters(sizeBox, center, maxRes, signPassesCount, threshold, sdfOffset);
			this.Init();
		}

		// Token: 0x06000085 RID: 133 RVA: 0x000041C3 File Offset: 0x000023C3
		public void Reinit(Vector3 sizeBox, Vector3 center, int maxRes, List<Mesh> meshes, List<Matrix4x4> transforms, int signPassesCount = 1, float threshold = 0.5f, float sdfOffset = 0f)
		{
			this.Reinit(sizeBox, center, maxRes, MeshToSDFBaker.InitMeshFromList(meshes, transforms), signPassesCount, threshold, sdfOffset);
		}

		// Token: 0x06000086 RID: 134 RVA: 0x000041E0 File Offset: 0x000023E0
		private void SetParameters(Vector3 sizeBox, Vector3 center, int maxRes, int signPassesCount, float threshold, float sdfOffset)
		{
			if (this.m_SignPassesCount >= 20)
			{
				throw new ArgumentException("The signPassCount argument should be smaller than 20.");
			}
			this.m_SignPassesCount = signPassesCount;
			this.m_InOutThreshold = threshold;
			this.m_SdfOffset = sdfOffset;
			this.m_Center = center;
			this.m_SizeBox = sizeBox;
			this.m_maxResolution = maxRes;
		}

		// Token: 0x06000087 RID: 135 RVA: 0x0000422F File Offset: 0x0000242F
		private void LoadRuntimeResources()
		{
			if (SystemInfo.graphicsDeviceType == GraphicsDeviceType.OpenGLES3)
			{
				Debug.LogWarning("MeshToSDFBaker compute shaders are not supported on OpenGLES3");
			}
			this.m_RuntimeResources = VFXRuntimeResources.runtimeResources;
			if (this.m_RuntimeResources == null)
			{
				throw new InvalidOperationException("VFX Runtime Resources could not be loaded.");
			}
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00004268 File Offset: 0x00002468
		private void InitTextures()
		{
			RenderTextureDescriptor rtDesc = new RenderTextureDescriptor
			{
				graphicsFormat = GraphicsFormat.R16G16B16A16_SFloat,
				dimension = TextureDimension.Tex3D,
				enableRandomWrite = true,
				width = this.m_Dimensions[0],
				height = this.m_Dimensions[1],
				volumeDepth = this.m_Dimensions[2],
				msaaSamples = 1
			};
			RenderTextureDescriptor rtDesc2 = new RenderTextureDescriptor
			{
				graphicsFormat = GraphicsFormat.R16_SFloat,
				dimension = TextureDimension.Tex3D,
				enableRandomWrite = true,
				width = this.m_Dimensions[0],
				height = this.m_Dimensions[1],
				volumeDepth = this.m_Dimensions[2],
				msaaSamples = 1
			};
			RenderTextureDescriptor rtDesc3 = new RenderTextureDescriptor
			{
				graphicsFormat = GraphicsFormat.R32_SFloat,
				dimension = TextureDimension.Tex3D,
				enableRandomWrite = true,
				width = this.m_Dimensions[0],
				height = this.m_Dimensions[1],
				volumeDepth = this.m_Dimensions[2],
				msaaSamples = 1
			};
			this.CreateRenderTextureIfNeeded(ref this.m_textureVoxel, rtDesc);
			this.CreateRenderTextureIfNeeded(ref this.m_textureVoxelBis, rtDesc);
			this.CreateRenderTextureIfNeeded(ref this.m_RayMap, rtDesc);
			this.CreateRenderTextureIfNeeded(ref this.m_SignMap, rtDesc3);
			this.CreateRenderTextureIfNeeded(ref this.m_SignMapBis, rtDesc3);
			this.CreateRenderTextureIfNeeded(ref this.m_DistanceTexture, rtDesc2);
			this.CreateGraphicsBufferIfNeeded(ref this.m_bufferVoxel, this.GetTotalVoxelCount(), 16);
			this.InitPrefixSumBuffers();
		}

		// Token: 0x06000089 RID: 137 RVA: 0x000043E8 File Offset: 0x000025E8
		private void Init()
		{
			this.m_Mesh.vertexBufferTarget |= GraphicsBuffer.Target.Raw;
			this.m_Mesh.indexBufferTarget |= GraphicsBuffer.Target.Raw;
			this.InitSizeBox();
			this.InitCommandBuffer();
			this.m_ThreadGroupSize = 512;
			this.m_computeShader = this.m_RuntimeResources.sdfRayMapCS;
			if (this.m_computeShader == null)
			{
				throw new InvalidOperationException("VFX Runtime Resources could not be loaded correctly.");
			}
			if (this.m_Kernels == null)
			{
				this.m_Kernels = new MeshToSDFBaker.Kernels(this.m_computeShader);
			}
			this.InitTextures();
			RenderTextureDescriptor rtDesc = default(RenderTextureDescriptor);
			rtDesc.width = this.m_Dimensions[0];
			rtDesc.height = this.m_Dimensions[1];
			rtDesc.graphicsFormat = GraphicsFormat.R8G8B8A8_SRGB;
			rtDesc.volumeDepth = 1;
			rtDesc.msaaSamples = 1;
			rtDesc.dimension = TextureDimension.Tex2D;
			if (this.m_RenderTextureViews == null)
			{
				this.m_RenderTextureViews = new RenderTexture[3];
			}
			for (int i = 0; i < 3; i++)
			{
				switch (i)
				{
				case 0:
					rtDesc.width = this.m_Dimensions[0];
					rtDesc.height = this.m_Dimensions[1];
					this.CreateRenderTextureIfNeeded(ref this.m_RenderTextureViews[i], rtDesc);
					break;
				case 1:
					rtDesc.width = this.m_Dimensions[2];
					rtDesc.height = this.m_Dimensions[0];
					this.CreateRenderTextureIfNeeded(ref this.m_RenderTextureViews[i], rtDesc);
					break;
				case 2:
					rtDesc.width = this.m_Dimensions[1];
					rtDesc.height = this.m_Dimensions[2];
					this.CreateRenderTextureIfNeeded(ref this.m_RenderTextureViews[i], rtDesc);
					break;
				}
			}
			if (this.m_Material == null || this.m_Material[0] == null || this.m_Material[1] == null || this.m_Material[2] == null)
			{
				this.m_Material = new Material[3];
				Shader sdfRayMapShader = this.m_RuntimeResources.sdfRayMapShader;
				if (sdfRayMapShader == null)
				{
					throw new InvalidOperationException("VFX Runtime Resources could not be loaded correctly.");
				}
				for (int j = 0; j < 3; j++)
				{
					this.m_Material[j] = new Material(sdfRayMapShader);
				}
			}
			if (this.m_WorldToClip == null)
			{
				this.m_WorldToClip = new Matrix4x4[3];
			}
			if (this.m_ProjMat == null)
			{
				this.m_ProjMat = new Matrix4x4[3];
			}
			if (this.m_ViewMat == null)
			{
				this.m_ViewMat = new Matrix4x4[3];
			}
			this.UpdateCameras();
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00004658 File Offset: 0x00002858
		private void UpdateCameras()
		{
			Vector3 pos = this.m_Center + Vector3.back * (this.m_SizeBox.z * 0.5f + 1f);
			Quaternion rot = Quaternion.identity;
			float num = 1f;
			float far = num + this.m_SizeBox.z;
			this.m_WorldToClip[0] = this.ComputeOrthographicWorldToClip(pos, rot, this.m_SizeBox.x, this.m_SizeBox.y, num, far, out this.m_ProjMat[0], out this.m_ViewMat[0]);
			pos = this.m_Center + Vector3.down * (this.m_SizeBox.y * 0.5f + 1f);
			rot = Quaternion.Euler(-90f, -90f, 0f);
			far = num + this.m_SizeBox.y;
			this.m_WorldToClip[1] = this.ComputeOrthographicWorldToClip(pos, rot, this.m_SizeBox.z, this.m_SizeBox.x, num, far, out this.m_ProjMat[1], out this.m_ViewMat[1]);
			pos = this.m_Center + Vector3.left * (this.m_SizeBox.x * 0.5f + 1f);
			rot = Quaternion.Euler(0f, 90f, 90f);
			far = num + this.m_SizeBox.x;
			this.m_WorldToClip[2] = this.ComputeOrthographicWorldToClip(pos, rot, this.m_SizeBox.y, this.m_SizeBox.z, num, far, out this.m_ProjMat[2], out this.m_ViewMat[2]);
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00004818 File Offset: 0x00002A18
		private Matrix4x4 ComputeOrthographicWorldToClip(Vector3 pos, Quaternion rot, float width, float height, float near, float far, out Matrix4x4 proj, out Matrix4x4 view)
		{
			proj = Matrix4x4.Ortho(-width / 2f, width / 2f, -height / 2f, height / 2f, near, far);
			proj = GL.GetGPUProjectionMatrix(proj, false);
			view = Matrix4x4.TRS(pos, rot, new Vector3(1f, 1f, -1f)).inverse;
			return proj * view;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x000048A6 File Offset: 0x00002AA6
		private int iDivUp(int a, int b)
		{
			if (a % b == 0)
			{
				return a / b;
			}
			return a / b + 1;
		}

		// Token: 0x0600008D RID: 141 RVA: 0x000048B8 File Offset: 0x00002AB8
		private Vector2Int GetThreadGroupsCount(int nbThreads, int threadCountPerGroup)
		{
			Vector2Int zero = Vector2Int.zero;
			int num = (nbThreads + threadCountPerGroup - 1) / threadCountPerGroup;
			zero.y = 1 + num / 65535;
			zero.x = num / zero.y;
			return zero;
		}

		// Token: 0x0600008E RID: 142 RVA: 0x000048F4 File Offset: 0x00002AF4
		private void PrefixSumCount()
		{
			int totalVoxelCount = this.GetTotalVoxelCount();
			this.m_Cmd.BeginSample("BakeSDF.PrefixSum");
			this.m_Cmd.SetComputeIntParam(this.m_computeShader, MeshToSDFBaker.ShaderProperties.numElem, totalVoxelCount);
			this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.inBucketSum, MeshToSDFBaker.ShaderProperties.inputBuffer, this.m_CounterBuffer);
			this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.inBucketSum, MeshToSDFBaker.ShaderProperties.resultBuffer, this.m_TmpBuffer);
			Vector2Int threadGroupsCount = this.GetThreadGroupsCount(totalVoxelCount, this.m_ThreadGroupSize);
			this.m_Cmd.SetComputeIntParam(this.m_computeShader, MeshToSDFBaker.ShaderProperties.dispatchWidth, threadGroupsCount.x);
			this.m_Cmd.DispatchCompute(this.m_computeShader, this.m_Kernels.inBucketSum, threadGroupsCount.x, threadGroupsCount.y, 1);
			int num = this.iDivUp(totalVoxelCount, this.m_ThreadGroupSize);
			if (num > this.m_ThreadGroupSize)
			{
				this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.toBlockSumBuffer, MeshToSDFBaker.ShaderProperties.inputCounter, this.m_CounterBuffer);
				this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.toBlockSumBuffer, MeshToSDFBaker.ShaderProperties.inputBuffer, this.m_TmpBuffer);
				this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.toBlockSumBuffer, MeshToSDFBaker.ShaderProperties.resultBuffer, this.m_SumBlocksBuffer);
				this.m_Cmd.DispatchCompute(this.m_computeShader, this.m_Kernels.toBlockSumBuffer, Mathf.CeilToInt((float)totalVoxelCount / (float)(this.m_ThreadGroupSize * this.m_ThreadGroupSize)), 1, 1);
				this.m_Cmd.SetComputeIntParam(this.m_computeShader, MeshToSDFBaker.ShaderProperties.numElem, num);
				this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.inBucketSum, MeshToSDFBaker.ShaderProperties.inputBuffer, this.m_SumBlocksBuffer);
				this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.inBucketSum, MeshToSDFBaker.ShaderProperties.resultBuffer, this.m_InSumBlocksBuffer);
				this.m_Cmd.DispatchCompute(this.m_computeShader, this.m_Kernels.inBucketSum, Mathf.CeilToInt((float)totalVoxelCount / (float)(this.m_ThreadGroupSize * this.m_ThreadGroupSize)), 1, 1);
				this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.blockSums, MeshToSDFBaker.ShaderProperties.inputCounter, this.m_SumBlocksBuffer);
				this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.blockSums, MeshToSDFBaker.ShaderProperties.inputBuffer, this.m_InSumBlocksBuffer);
				this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.blockSums, MeshToSDFBaker.ShaderProperties.resultBuffer, this.m_SumBlocksAdditional);
				this.m_Cmd.DispatchCompute(this.m_computeShader, this.m_Kernels.blockSums, Mathf.CeilToInt((float)totalVoxelCount / (float)(this.m_ThreadGroupSize * this.m_ThreadGroupSize * this.m_ThreadGroupSize)), 1, 1);
				this.m_Cmd.SetComputeIntParam(this.m_computeShader, MeshToSDFBaker.ShaderProperties.exclusive, 0);
				this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.finalSum, MeshToSDFBaker.ShaderProperties.inputBuffer, this.m_InSumBlocksBuffer);
				this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.finalSum, MeshToSDFBaker.ShaderProperties.auxBuffer, this.m_SumBlocksAdditional);
				this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.finalSum, MeshToSDFBaker.ShaderProperties.inputCounter, this.m_SumBlocksBuffer);
				this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.finalSum, MeshToSDFBaker.ShaderProperties.resultBuffer, this.m_AccumSumBlocks);
				this.m_Cmd.DispatchCompute(this.m_computeShader, this.m_Kernels.finalSum, Mathf.CeilToInt((float)totalVoxelCount / (float)(this.m_ThreadGroupSize * this.m_ThreadGroupSize)), 1, 1);
			}
			else
			{
				this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.blockSums, MeshToSDFBaker.ShaderProperties.inputCounter, this.m_CounterBuffer);
				this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.blockSums, MeshToSDFBaker.ShaderProperties.inputBuffer, this.m_TmpBuffer);
				this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.blockSums, MeshToSDFBaker.ShaderProperties.resultBuffer, this.m_AccumSumBlocks);
				this.m_Cmd.DispatchCompute(this.m_computeShader, this.m_Kernels.blockSums, Mathf.CeilToInt((float)totalVoxelCount / (float)(this.m_ThreadGroupSize * this.m_ThreadGroupSize)), 1, 1);
			}
			this.m_Cmd.SetComputeIntParam(this.m_computeShader, MeshToSDFBaker.ShaderProperties.numElem, totalVoxelCount);
			this.m_Cmd.SetComputeIntParam(this.m_computeShader, MeshToSDFBaker.ShaderProperties.exclusive, 0);
			this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.finalSum, MeshToSDFBaker.ShaderProperties.inputBuffer, this.m_TmpBuffer);
			this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.finalSum, MeshToSDFBaker.ShaderProperties.auxBuffer, this.m_AccumSumBlocks);
			this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.finalSum, MeshToSDFBaker.ShaderProperties.inputCounter, this.m_CounterBuffer);
			this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.finalSum, MeshToSDFBaker.ShaderProperties.resultBuffer, this.m_AccumCounterBuffer);
			this.m_Cmd.DispatchCompute(this.m_computeShader, this.m_Kernels.finalSum, threadGroupsCount.x, threadGroupsCount.y, 1);
			this.m_Cmd.EndSample("BakeSDF.PrefixSum");
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00004E7C File Offset: 0x0000307C
		private void SurfaceClosing()
		{
			this.m_Cmd.BeginSample("BakeSDF.SurfaceClosing");
			if (this.m_SignPassesCount == 0)
			{
				this.m_InOutThreshold *= 6f;
			}
			this.m_Cmd.SetComputeFloatParam(this.m_computeShader, MeshToSDFBaker.ShaderProperties.threshold, this.m_InOutThreshold);
			this.m_Cmd.SetComputeTextureParam(this.m_computeShader, this.m_Kernels.surfaceClosing, MeshToSDFBaker.ShaderProperties.signMap, this.GetSignMapPrincipal(this.m_SignPassesCount));
			this.m_Cmd.SetComputeTextureParam(this.m_computeShader, this.m_Kernels.surfaceClosing, MeshToSDFBaker.ShaderProperties.voxelsTexture, this.GetTextureVoxelPrincipal(0));
			this.m_Cmd.DispatchCompute(this.m_computeShader, this.m_Kernels.surfaceClosing, this.iDivUp(this.m_Dimensions[0], 4), this.iDivUp(this.m_Dimensions[1], 4), this.iDivUp(this.m_Dimensions[2], 4));
			this.m_Cmd.EndSample("BakeSDF.SurfaceClosing");
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00004F87 File Offset: 0x00003187
		private RenderTexture GetTextureVoxelPrincipal(int step)
		{
			if (step % 2 == 0)
			{
				return this.m_textureVoxel;
			}
			return this.m_textureVoxelBis;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00004F9B File Offset: 0x0000319B
		private RenderTexture GetTextureVoxelBis(int step)
		{
			if (step % 2 == 0)
			{
				return this.m_textureVoxelBis;
			}
			return this.m_textureVoxel;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00004FB0 File Offset: 0x000031B0
		private void JFA()
		{
			this.m_Cmd.BeginSample("BakeSDF.JFA");
			this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.toTextureNormalized, MeshToSDFBaker.ShaderProperties.voxelsBuffer, this.m_bufferVoxel);
			this.m_Cmd.SetComputeTextureParam(this.m_computeShader, this.m_Kernels.toTextureNormalized, MeshToSDFBaker.ShaderProperties.voxelsTexture, this.GetTextureVoxelPrincipal(0));
			this.m_Cmd.DispatchCompute(this.m_computeShader, this.m_Kernels.toTextureNormalized, Mathf.CeilToInt((float)this.m_Dimensions[0] / 4f), Mathf.CeilToInt((float)this.m_Dimensions[1] / 4f), Mathf.CeilToInt((float)this.m_Dimensions[2] / 4f));
			this.m_Cmd.SetComputeTextureParam(this.m_computeShader, this.m_Kernels.jfa, MeshToSDFBaker.ShaderProperties.voxelsTexture, this.GetTextureVoxelPrincipal(0), 0);
			this.m_Cmd.SetComputeTextureParam(this.m_computeShader, this.m_Kernels.jfa, MeshToSDFBaker.ShaderProperties.voxelsTmpTexture, this.GetTextureVoxelBis(0), 0);
			this.m_Cmd.SetComputeTextureParam(this.m_computeShader, this.m_Kernels.copyTextures, MeshToSDFBaker.ShaderProperties.voxelsTexture, this.GetTextureVoxelPrincipal(0), 0);
			this.m_Cmd.SetComputeTextureParam(this.m_computeShader, this.m_Kernels.copyTextures, MeshToSDFBaker.ShaderProperties.voxelsTmpTexture, this.GetTextureVoxelBis(0), 0);
			this.m_Cmd.SetComputeIntParam(this.m_computeShader, MeshToSDFBaker.ShaderProperties.offset, 1);
			this.m_Cmd.DispatchCompute(this.m_computeShader, this.m_Kernels.jfa, Mathf.CeilToInt((float)this.m_Dimensions[0] / 4f), Mathf.CeilToInt((float)this.m_Dimensions[1] / 4f), Mathf.CeilToInt((float)this.m_Dimensions[2] / 4f));
			this.m_Cmd.DispatchCompute(this.m_computeShader, this.m_Kernels.copyTextures, Mathf.CeilToInt((float)this.m_Dimensions[0] / 4f), Mathf.CeilToInt((float)this.m_Dimensions[1] / 4f), Mathf.CeilToInt((float)this.m_Dimensions[2] / 4f));
			this.m_nStepsJFA = Mathf.CeilToInt(Mathf.Log((float)this.m_maxResolution, 2f));
			for (int i = 1; i <= this.m_nStepsJFA; i++)
			{
				int val = Mathf.FloorToInt(Mathf.Pow(2f, (float)(this.m_nStepsJFA - i)) + 0.5f);
				this.m_Cmd.SetComputeIntParam(this.m_computeShader, MeshToSDFBaker.ShaderProperties.offset, val);
				this.m_Cmd.SetComputeTextureParam(this.m_computeShader, this.m_Kernels.jfa, MeshToSDFBaker.ShaderProperties.voxelsTexture, this.GetTextureVoxelPrincipal(i), 0);
				this.m_Cmd.SetComputeTextureParam(this.m_computeShader, this.m_Kernels.jfa, MeshToSDFBaker.ShaderProperties.voxelsTmpTexture, this.GetTextureVoxelBis(i), 0);
				this.m_Cmd.DispatchCompute(this.m_computeShader, this.m_Kernels.jfa, Mathf.CeilToInt((float)this.m_Dimensions[0] / 4f), Mathf.CeilToInt((float)this.m_Dimensions[1] / 4f), Mathf.CeilToInt((float)this.m_Dimensions[2] / 4f));
			}
			this.m_Cmd.EndSample("BakeSDF.JFA");
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00005328 File Offset: 0x00003528
		private void GenerateRayMap()
		{
			this.m_Cmd.BeginSample("BakeSDF.Raymap");
			this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.generateRayMapLocal, MeshToSDFBaker.ShaderProperties.accumCounter, this.m_AccumCounterBuffer);
			this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.generateRayMapLocal, MeshToSDFBaker.ShaderProperties.triangleIDs, this.m_TrianglesInVoxels);
			this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.generateRayMapLocal, MeshToSDFBaker.ShaderProperties.trianglesUV, this.m_TrianglesUV);
			this.m_Cmd.SetComputeTextureParam(this.m_computeShader, this.m_Kernels.generateRayMapLocal, MeshToSDFBaker.ShaderProperties.rayMap, this.m_RayMap);
			this.m_Cmd.BeginSample("BakeSDF.LocalRaymap");
			for (int i = 0; i < 8; i++)
			{
				this.m_OffsetRayMap[0] = (i & 1);
				this.m_OffsetRayMap[1] = (i & 2) >> 1;
				this.m_OffsetRayMap[2] = (i & 4) >> 2;
				this.m_Cmd.SetComputeIntParams(this.m_computeShader, MeshToSDFBaker.ShaderProperties.offsetRayMap, this.m_OffsetRayMap);
				this.m_Cmd.DispatchCompute(this.m_computeShader, this.m_Kernels.generateRayMapLocal, Mathf.CeilToInt((float)this.m_Dimensions[0] / 16f), Mathf.CeilToInt((float)this.m_Dimensions[1] / 16f), Mathf.CeilToInt((float)this.m_Dimensions[2] / 16f));
			}
			this.m_Cmd.EndSample("BakeSDF.LocalRaymap");
			this.m_Cmd.BeginSample("BakeSDF.GlobalRaymap");
			this.m_Cmd.SetComputeTextureParam(this.m_computeShader, this.m_Kernels.rayMapScanX, MeshToSDFBaker.ShaderProperties.rayMap, this.m_RayMap);
			this.m_Cmd.SetComputeTextureParam(this.m_computeShader, this.m_Kernels.rayMapScanY, MeshToSDFBaker.ShaderProperties.rayMap, this.m_RayMap);
			this.m_Cmd.SetComputeTextureParam(this.m_computeShader, this.m_Kernels.rayMapScanZ, MeshToSDFBaker.ShaderProperties.rayMap, this.m_RayMap);
			this.m_Cmd.DispatchCompute(this.m_computeShader, this.m_Kernels.rayMapScanX, 1, Mathf.CeilToInt((float)this.m_Dimensions[1] / 8f), Mathf.CeilToInt((float)this.m_Dimensions[2] / 8f));
			this.m_Cmd.DispatchCompute(this.m_computeShader, this.m_Kernels.rayMapScanY, Mathf.CeilToInt((float)this.m_Dimensions[0] / 8f), 1, Mathf.CeilToInt((float)this.m_Dimensions[2] / 8f));
			this.m_Cmd.DispatchCompute(this.m_computeShader, this.m_Kernels.rayMapScanZ, Mathf.CeilToInt((float)this.m_Dimensions[0] / 8f), Mathf.CeilToInt((float)this.m_Dimensions[1] / 8f), 1);
			this.m_Cmd.EndSample("BakeSDF.GlobalRaymap");
			this.m_Cmd.EndSample("BakeSDF.Raymap");
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00005634 File Offset: 0x00003834
		private RenderTexture GetSignMapPrincipal(int step)
		{
			if (step % 2 == 0)
			{
				return this.m_SignMap;
			}
			return this.m_SignMapBis;
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00005648 File Offset: 0x00003848
		private RenderTexture GetSignMapBis(int step)
		{
			if (step % 2 == 0)
			{
				return this.m_SignMapBis;
			}
			return this.m_SignMap;
		}

		// Token: 0x06000096 RID: 150 RVA: 0x0000565C File Offset: 0x0000385C
		private void SignPass()
		{
			this.m_Cmd.BeginSample("BakeSDF.SignPass");
			this.m_Cmd.SetComputeTextureParam(this.m_computeShader, this.m_Kernels.signPass6Rays, MeshToSDFBaker.ShaderProperties.rayMap, this.m_RayMap);
			this.m_Cmd.SetComputeTextureParam(this.m_computeShader, this.m_Kernels.signPass6Rays, MeshToSDFBaker.ShaderProperties.signMap, this.GetSignMapPrincipal(0));
			this.m_Cmd.DispatchCompute(this.m_computeShader, this.m_Kernels.signPass6Rays, Mathf.CeilToInt((float)this.m_Dimensions[0] / 4f), Mathf.CeilToInt((float)this.m_Dimensions[1] / 4f), Mathf.CeilToInt((float)this.m_Dimensions[2] / 4f));
			this.m_Cmd.SetComputeTextureParam(this.m_computeShader, this.m_Kernels.signPassNeighbors, MeshToSDFBaker.ShaderProperties.rayMap, this.m_RayMap);
			int num = 8;
			float num2 = 6f;
			this.m_Cmd.SetComputeFloatParam(this.m_computeShader, MeshToSDFBaker.ShaderProperties.normalizeFactor, num2);
			this.m_Cmd.SetComputeIntParam(this.m_computeShader, MeshToSDFBaker.ShaderProperties.numNeighbours, num);
			int signPassesCount = this.m_SignPassesCount;
			for (int i = 1; i <= signPassesCount; i++)
			{
				this.m_Cmd.SetComputeIntParam(this.m_computeShader, MeshToSDFBaker.ShaderProperties.passId, i);
				this.m_Cmd.SetComputeFloatParam(this.m_computeShader, MeshToSDFBaker.ShaderProperties.normalizeFactor, num2);
				this.m_Cmd.SetComputeTextureParam(this.m_computeShader, this.m_Kernels.signPassNeighbors, MeshToSDFBaker.ShaderProperties.signMap, this.GetSignMapPrincipal(i));
				this.m_Cmd.SetComputeTextureParam(this.m_computeShader, this.m_Kernels.signPassNeighbors, MeshToSDFBaker.ShaderProperties.signMapTmp, this.GetSignMapBis(i));
				this.m_Cmd.SetComputeIntParam(this.m_computeShader, MeshToSDFBaker.ShaderProperties.needNormalize, (i == signPassesCount) ? 1 : 0);
				this.m_Cmd.DispatchCompute(this.m_computeShader, this.m_Kernels.signPassNeighbors, Mathf.CeilToInt((float)this.m_Dimensions[0] / 4f), Mathf.CeilToInt((float)this.m_Dimensions[1] / 4f), Mathf.CeilToInt((float)this.m_Dimensions[2] / 4f));
				num2 += (float)(num * 6) * num2;
			}
			this.m_Cmd.EndSample("BakeSDF.SignPass");
		}

		// Token: 0x06000097 RID: 151 RVA: 0x000058BC File Offset: 0x00003ABC
		public void BakeSDF()
		{
			if (SystemInfo.graphicsDeviceType == GraphicsDeviceType.OpenGLES3)
			{
				throw new NotSupportedException("MeshToSDFBaker compute shaders are not supported on OpenGLES3");
			}
			this.m_Cmd.BeginSample("BakeSDF");
			this.UpdateCameras();
			this.m_Cmd.SetComputeIntParams(this.m_computeShader, MeshToSDFBaker.ShaderProperties.size, this.m_Dimensions);
			this.CreateGraphicsBufferIfNeeded(ref this.m_bufferVoxel, this.GetTotalVoxelCount(), 16);
			this.InitPrefixSumBuffers();
			this.InitMeshBuffers();
			int num = (int)Mathf.Pow((float)this.m_maxResolution, 2f) * (int)Mathf.Pow((float)this.nTriangles, 0.5f);
			num = (int)Mathf.Max((float)((long)this.nTriangles * 30L), (float)num);
			num = Mathf.Min(402653184, num);
			this.m_Cmd.SetComputeIntParam(this.m_computeShader, MeshToSDFBaker.ShaderProperties.upperBoundCount, num);
			this.ClearRenderTexturesAndBuffers();
			this.InitGeometryBuffers(num);
			this.BuildGeometry();
			this.FirstDraw();
			this.PrefixSumCount();
			this.SecondDraw();
			this.GenerateRayMap();
			this.SignPass();
			this.SurfaceClosing();
			this.JFA();
			this.PerformDistanceTransformWinding();
			this.m_Cmd.EndSample("BakeSDF");
			if (this.m_OwnsCommandBuffer)
			{
				this.m_Cmd.ClearRandomWriteTargets();
				Graphics.ExecuteCommandBuffer(this.m_Cmd);
				this.m_Cmd.Clear();
			}
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00005A0C File Offset: 0x00003C0C
		private void InitMeshBuffers()
		{
			if (this.m_Mesh.GetVertexAttributeFormat(VertexAttribute.Position) != VertexAttributeFormat.Float32)
			{
				throw new ArgumentException("The SDF Baker only supports the VertexAttributeFormat Float32 for the Position attribute.");
			}
			int vertexAttributeStream = this.m_Mesh.GetVertexAttributeStream(VertexAttribute.Position);
			this.m_VertexBufferOffset = this.m_Mesh.GetVertexAttributeOffset(VertexAttribute.Position);
			GraphicsBuffer verticesBuffer = this.m_VerticesBuffer;
			if (verticesBuffer != null)
			{
				verticesBuffer.Dispose();
			}
			GraphicsBuffer indicesBuffer = this.m_IndicesBuffer;
			if (indicesBuffer != null)
			{
				indicesBuffer.Dispose();
			}
			this.m_VerticesBuffer = this.m_Mesh.GetVertexBuffer(vertexAttributeStream);
			this.m_IndicesBuffer = this.m_Mesh.GetIndexBuffer();
			this.nTriangles = 0;
			for (int i = 0; i < this.m_Mesh.subMeshCount; i++)
			{
				this.nTriangles += this.m_Mesh.GetSubMesh(i).indexCount;
			}
			this.nTriangles /= 3;
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00005AE4 File Offset: 0x00003CE4
		private void FirstDraw()
		{
			this.m_Cmd.BeginSample("BakeSDF.FirstDraw");
			for (int i = 0; i < 3; i++)
			{
				this.m_Material[i].SetInt(MeshToSDFBaker.ShaderProperties.dimX, this.m_Dimensions[0]);
				this.m_Material[i].SetInt(MeshToSDFBaker.ShaderProperties.dimY, this.m_Dimensions[1]);
				this.m_Material[i].SetInt(MeshToSDFBaker.ShaderProperties.dimZ, this.m_Dimensions[2]);
				this.m_Material[i].SetInt(MeshToSDFBaker.ShaderProperties.currentAxis, i);
				this.m_Material[i].SetBuffer(MeshToSDFBaker.ShaderProperties.verticesBuffer, this.m_VerticesOutBuffer);
				this.m_Material[i].SetBuffer(MeshToSDFBaker.ShaderProperties.coordFlipBuffer, this.m_CoordFlipBuffer);
			}
			for (int j = 0; j < 3; j++)
			{
				this.m_Cmd.ClearRandomWriteTargets();
				this.m_Cmd.SetRenderTarget(this.m_RenderTextureViews[j]);
				this.m_Cmd.ClearRenderTarget(true, true, Color.black, 1f);
				this.m_Cmd.SetRandomWriteTarget(4 + MeshToSDFBaker.kNbActualRT, this.m_AabbBuffer, false);
				this.m_Cmd.SetRandomWriteTarget(1 + MeshToSDFBaker.kNbActualRT, this.m_bufferVoxel, false);
				this.m_Cmd.SetRandomWriteTarget(2 + MeshToSDFBaker.kNbActualRT, this.m_CounterBuffer, false);
				this.m_Cmd.SetViewProjectionMatrices(this.m_ViewMat[j], this.m_ProjMat[j]);
				this.m_Cmd.DrawProcedural(Matrix4x4.identity, this.m_Material[j], 0, MeshTopology.Triangles, this.nTriangles * 3);
			}
			this.m_Cmd.ClearRandomWriteTargets();
			this.m_Cmd.EndSample("BakeSDF.FirstDraw");
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00005C9C File Offset: 0x00003E9C
		private void SecondDraw()
		{
			this.m_Cmd.BeginSample("BakeSDF.SecondDraw");
			for (int i = 0; i < 3; i++)
			{
				this.m_Cmd.ClearRandomWriteTargets();
				this.m_Cmd.SetRenderTarget(this.m_RenderTextureViews[i]);
				this.m_Cmd.ClearRenderTarget(true, true, Color.black, 1f);
				this.m_Cmd.SetRandomWriteTarget(4 + MeshToSDFBaker.kNbActualRT, this.m_AabbBuffer, false);
				this.m_Cmd.SetRandomWriteTarget(3 + MeshToSDFBaker.kNbActualRT, this.m_TrianglesInVoxels, false);
				this.m_Cmd.SetRandomWriteTarget(2 + MeshToSDFBaker.kNbActualRT, this.m_AccumCounterBuffer, false);
				this.m_Cmd.SetViewProjectionMatrices(this.m_ViewMat[i], this.m_ProjMat[i]);
				this.m_Cmd.DrawProcedural(Matrix4x4.identity, this.m_Material[i], 1, MeshTopology.Triangles, this.nTriangles * 3);
			}
			this.m_Cmd.ClearRandomWriteTargets();
			this.m_Cmd.EndSample("BakeSDF.SecondDraw");
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00005DB0 File Offset: 0x00003FB0
		private void BuildGeometry()
		{
			this.m_Cmd.BeginSample("BakeSDF.FakeGeometryShader");
			Vector3 vector = this.m_Center - this.m_SizeBox * 0.5f;
			Vector3 vector2 = this.m_Center + this.m_SizeBox * 0.5f;
			for (int i = 0; i < 3; i++)
			{
				this.m_MinBoundsExtended[i] = vector[i];
				this.m_MaxBoundsExtended[i] = vector2[i];
			}
			this.m_Cmd.SetComputeFloatParams(this.m_computeShader, MeshToSDFBaker.ShaderProperties.minBoundsExtended, this.m_MinBoundsExtended);
			this.m_Cmd.SetComputeFloatParams(this.m_computeShader, MeshToSDFBaker.ShaderProperties.maxBoundsExtended, this.m_MaxBoundsExtended);
			this.m_Cmd.SetComputeFloatParam(this.m_computeShader, MeshToSDFBaker.ShaderProperties.maxExtent, this.m_MaxExtent);
			this.m_Cmd.SetComputeIntParam(this.m_computeShader, MeshToSDFBaker.ShaderProperties.nTriangles, this.nTriangles);
			this.m_Cmd.SetComputeIntParam(this.m_computeShader, MeshToSDFBaker.ShaderProperties.vertexPositionOffset, this.m_VertexBufferOffset);
			this.m_Cmd.SetComputeIntParam(this.m_computeShader, MeshToSDFBaker.ShaderProperties.vertexStride, this.m_VerticesBuffer.stride);
			this.m_Cmd.SetComputeIntParam(this.m_computeShader, MeshToSDFBaker.ShaderProperties.indexStride, this.m_IndicesBuffer.stride);
			this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.chooseDirectionTriangleOnly, MeshToSDFBaker.ShaderProperties.indicesBuffer, this.m_IndicesBuffer);
			this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.chooseDirectionTriangleOnly, MeshToSDFBaker.ShaderProperties.verticesBuffer, this.m_VerticesBuffer);
			this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.chooseDirectionTriangleOnly, MeshToSDFBaker.ShaderProperties.coordFlipBuffer, this.m_CoordFlipBuffer);
			this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.conservativeRasterization, MeshToSDFBaker.ShaderProperties.indicesBuffer, this.m_IndicesBuffer);
			this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.conservativeRasterization, MeshToSDFBaker.ShaderProperties.verticesBuffer, this.m_VerticesBuffer);
			this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.conservativeRasterization, MeshToSDFBaker.ShaderProperties.verticesOutBuffer, this.m_VerticesOutBuffer);
			this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.conservativeRasterization, MeshToSDFBaker.ShaderProperties.coordFlipBuffer, this.m_CoordFlipBuffer);
			this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.conservativeRasterization, MeshToSDFBaker.ShaderProperties.aabbBuffer, this.m_AabbBuffer);
			this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.generateTrianglesUV, MeshToSDFBaker.ShaderProperties.rw_trianglesUV, this.m_TrianglesUV);
			this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.generateTrianglesUV, MeshToSDFBaker.ShaderProperties.indicesBuffer, this.m_IndicesBuffer);
			this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.generateTrianglesUV, MeshToSDFBaker.ShaderProperties.verticesBuffer, this.m_VerticesBuffer);
			this.m_Cmd.DispatchCompute(this.m_computeShader, this.m_Kernels.generateTrianglesUV, Mathf.CeilToInt((float)this.nTriangles / 64f), 1, 1);
			this.m_Cmd.DispatchCompute(this.m_computeShader, this.m_Kernels.chooseDirectionTriangleOnly, Mathf.CeilToInt((float)this.nTriangles / 64f), 1, 1);
			for (int j = 0; j < 3; j++)
			{
				this.m_Cmd.SetComputeIntParam(this.m_computeShader, MeshToSDFBaker.ShaderProperties.currentAxis, j);
				this.m_Cmd.SetComputeMatrixParam(this.m_computeShader, MeshToSDFBaker.ShaderProperties.worldToClip, this.m_WorldToClip[j]);
				this.m_Cmd.DispatchCompute(this.m_computeShader, this.m_Kernels.conservativeRasterization, Mathf.CeilToInt((float)this.nTriangles / 64f), 1, 1);
			}
			this.m_Cmd.EndSample("BakeSDF.FakeGeometryShader");
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00006194 File Offset: 0x00004394
		private void InitGeometryBuffers(int upperBoundCount)
		{
			this.CreateGraphicsBufferIfNeeded(ref this.m_VerticesOutBuffer, 3 * this.nTriangles, 16);
			this.CreateGraphicsBufferIfNeeded(ref this.m_CoordFlipBuffer, this.nTriangles, 4);
			this.CreateGraphicsBufferIfNeeded(ref this.m_AabbBuffer, this.nTriangles, 16);
			this.CreateGraphicsBufferIfNeeded(ref this.m_TrianglesInVoxels, upperBoundCount, 4);
			this.CreateGraphicsBufferIfNeeded(ref this.m_TrianglesUV, this.nTriangles, 36);
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00006200 File Offset: 0x00004400
		private void InitPrefixSumBuffers()
		{
			this.CreateGraphicsBufferIfNeeded(ref this.m_CounterBuffer, this.GetTotalVoxelCount(), 4);
			this.CreateGraphicsBufferIfNeeded(ref this.m_AccumCounterBuffer, this.GetTotalVoxelCount(), 4);
			this.CreateGraphicsBufferIfNeeded(ref this.m_AccumSumBlocks, Mathf.CeilToInt((float)this.GetTotalVoxelCount() / (float)this.m_ThreadGroupSize), 4);
			this.CreateGraphicsBufferIfNeeded(ref this.m_SumBlocksBuffer, Mathf.CeilToInt((float)this.GetTotalVoxelCount() / (float)this.m_ThreadGroupSize), 4);
			this.CreateGraphicsBufferIfNeeded(ref this.m_InSumBlocksBuffer, Mathf.CeilToInt((float)this.GetTotalVoxelCount() / (float)this.m_ThreadGroupSize), 4);
			this.CreateGraphicsBufferIfNeeded(ref this.m_TmpBuffer, this.GetTotalVoxelCount(), 4);
			this.CreateGraphicsBufferIfNeeded(ref this.m_SumBlocksAdditional, Mathf.CeilToInt((float)this.GetTotalVoxelCount() / (float)(this.m_ThreadGroupSize * this.m_ThreadGroupSize)), 4);
		}

		// Token: 0x0600009E RID: 158 RVA: 0x000062D4 File Offset: 0x000044D4
		private void ClearRenderTexturesAndBuffers()
		{
			this.m_Cmd.BeginSample("BakeSDF.ClearTexturesAndBuffers");
			this.m_Cmd.SetComputeTextureParam(this.m_computeShader, this.m_Kernels.clearTexturesAndBuffers, MeshToSDFBaker.ShaderProperties.voxelsTexture, this.m_textureVoxel, 0);
			this.m_Cmd.SetComputeTextureParam(this.m_computeShader, this.m_Kernels.clearTexturesAndBuffers, MeshToSDFBaker.ShaderProperties.voxelsTmpTexture, this.m_textureVoxelBis, 0);
			this.m_Cmd.SetComputeTextureParam(this.m_computeShader, this.m_Kernels.clearTexturesAndBuffers, MeshToSDFBaker.ShaderProperties.rayMap, this.m_RayMap, 0);
			this.m_Cmd.SetComputeTextureParam(this.m_computeShader, this.m_Kernels.clearTexturesAndBuffers, MeshToSDFBaker.ShaderProperties.signMap, this.m_SignMap, 0);
			this.m_Cmd.SetComputeTextureParam(this.m_computeShader, this.m_Kernels.clearTexturesAndBuffers, MeshToSDFBaker.ShaderProperties.signMapTmp, this.m_SignMapBis);
			this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.clearTexturesAndBuffers, MeshToSDFBaker.ShaderProperties.voxelsBuffer, this.m_bufferVoxel);
			this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.clearTexturesAndBuffers, MeshToSDFBaker.ShaderProperties.counter, this.m_CounterBuffer);
			this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.clearTexturesAndBuffers, MeshToSDFBaker.ShaderProperties.accumCounter, this.m_AccumCounterBuffer);
			this.m_Cmd.DispatchCompute(this.m_computeShader, this.m_Kernels.clearTexturesAndBuffers, Mathf.CeilToInt((float)this.m_Dimensions[0] / 8f), Mathf.CeilToInt((float)this.m_Dimensions[1] / 8f), Mathf.CeilToInt((float)this.m_Dimensions[2] / 8f));
			this.m_Cmd.EndSample("BakeSDF.ClearTexturesAndBuffers");
		}

		// Token: 0x0600009F RID: 159 RVA: 0x000064B0 File Offset: 0x000046B0
		private void PerformDistanceTransformWinding()
		{
			this.m_Cmd.BeginSample("BakeSDF.DistanceTransform");
			this.m_Cmd.SetComputeFloatParam(this.m_computeShader, MeshToSDFBaker.ShaderProperties.threshold, this.m_InOutThreshold);
			this.m_Cmd.SetComputeFloatParam(this.m_computeShader, MeshToSDFBaker.ShaderProperties.sdfOffset, this.m_SdfOffset);
			this.m_Cmd.SetComputeTextureParam(this.m_computeShader, this.m_Kernels.distanceTransform, MeshToSDFBaker.ShaderProperties.voxelsTexture, this.GetTextureVoxelPrincipal(this.m_nStepsJFA + 1));
			this.m_Cmd.SetComputeTextureParam(this.m_computeShader, this.m_Kernels.distanceTransform, MeshToSDFBaker.ShaderProperties.distanceTexture, this.m_DistanceTexture);
			this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.distanceTransform, MeshToSDFBaker.ShaderProperties.accumCounter, this.m_AccumCounterBuffer);
			this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.distanceTransform, MeshToSDFBaker.ShaderProperties.triangleIDs, this.m_TrianglesInVoxels);
			this.m_Cmd.SetComputeBufferParam(this.m_computeShader, this.m_Kernels.distanceTransform, MeshToSDFBaker.ShaderProperties.trianglesUV, this.m_TrianglesUV);
			this.m_Cmd.SetComputeTextureParam(this.m_computeShader, this.m_Kernels.distanceTransform, MeshToSDFBaker.ShaderProperties.signMap, this.GetSignMapPrincipal(this.m_SignPassesCount));
			this.m_Cmd.DispatchCompute(this.m_computeShader, this.m_Kernels.distanceTransform, Mathf.CeilToInt((float)this.m_Dimensions[0] / 8f), Mathf.CeilToInt((float)this.m_Dimensions[1] / 8f), Mathf.CeilToInt((float)this.m_Dimensions[2] / 8f));
			this.m_Cmd.EndSample("BakeSDF.DistanceTransform");
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x00006674 File Offset: 0x00004874
		private RenderTexture RayMap
		{
			get
			{
				return this.m_RayMap;
			}
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x0000667C File Offset: 0x0000487C
		private void ReleaseBuffersAndTextures()
		{
			this.ReleaseRenderTexture(ref this.m_textureVoxel);
			this.ReleaseRenderTexture(ref this.m_textureVoxelBis);
			this.ReleaseRenderTexture(ref this.m_DistanceTexture);
			for (int i = 0; i < 3; i++)
			{
				this.ReleaseRenderTexture(ref this.m_RenderTextureViews[i]);
				Object.Destroy(this.m_Material[i]);
			}
			this.ReleaseRenderTexture(ref this.m_SignMap);
			this.ReleaseRenderTexture(ref this.m_SignMapBis);
			this.ReleaseRenderTexture(ref this.m_RayMap);
			this.ReleaseGraphicsBuffer(ref this.m_bufferVoxel);
			this.ReleaseGraphicsBuffer(ref this.m_TrianglesUV);
			this.ReleaseGraphicsBuffer(ref this.m_TrianglesInVoxels);
			this.ReleaseGraphicsBuffer(ref this.m_IndicesBuffer);
			this.ReleaseGraphicsBuffer(ref this.m_VerticesBuffer);
			this.ReleaseGraphicsBuffer(ref this.m_VerticesOutBuffer);
			this.ReleaseGraphicsBuffer(ref this.m_CoordFlipBuffer);
			this.ReleaseGraphicsBuffer(ref this.m_AabbBuffer);
			this.ReleaseGraphicsBuffer(ref this.m_TmpBuffer);
			this.ReleaseGraphicsBuffer(ref this.m_AccumSumBlocks);
			this.ReleaseGraphicsBuffer(ref this.m_SumBlocksBuffer);
			this.ReleaseGraphicsBuffer(ref this.m_InSumBlocksBuffer);
			this.ReleaseGraphicsBuffer(ref this.m_SumBlocksAdditional);
			this.ReleaseGraphicsBuffer(ref this.m_CounterBuffer);
			this.ReleaseGraphicsBuffer(ref this.m_AccumCounterBuffer);
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x000067B0 File Offset: 0x000049B0
		public void Dispose()
		{
			this.ReleaseBuffersAndTextures();
			GC.SuppressFinalize(this);
			this.m_IsDisposed = true;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x000067C5 File Offset: 0x000049C5
		private void CreateGraphicsBufferIfNeeded(ref GraphicsBuffer gb, int length, int stride)
		{
			if (gb != null && gb.count == length && gb.stride == stride)
			{
				return;
			}
			this.ReleaseGraphicsBuffer(ref gb);
			gb = new GraphicsBuffer(GraphicsBuffer.Target.Structured, length, stride);
			this.m_IsDisposed = false;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x000067F9 File Offset: 0x000049F9
		private void ReleaseGraphicsBuffer(ref GraphicsBuffer gb)
		{
			if (gb != null)
			{
				gb.Release();
			}
			gb = null;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0000680C File Offset: 0x00004A0C
		private void CreateRenderTextureIfNeeded(ref RenderTexture rt, RenderTextureDescriptor rtDesc)
		{
			if (rt != null && rt.width == rtDesc.width && rt.height == rtDesc.height && rt.volumeDepth == rtDesc.volumeDepth && rt.graphicsFormat == rtDesc.graphicsFormat)
			{
				return;
			}
			this.ReleaseRenderTexture(ref rt);
			rt = new RenderTexture(rtDesc);
			rt.hideFlags = HideFlags.DontSave;
			rt.Create();
			this.m_IsDisposed = false;
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x0000688B File Offset: 0x00004A8B
		private void ReleaseRenderTexture(ref RenderTexture rt)
		{
			if (rt != null)
			{
				rt.Release();
				Object.DestroyImmediate(rt);
			}
			rt = null;
		}

		// Token: 0x04000054 RID: 84
		private RenderTexture m_RayMap;

		// Token: 0x04000055 RID: 85
		private RenderTexture m_SignMap;

		// Token: 0x04000056 RID: 86
		private RenderTexture m_SignMapBis;

		// Token: 0x04000057 RID: 87
		private RenderTexture[] m_RenderTextureViews;

		// Token: 0x04000058 RID: 88
		private GraphicsBuffer m_CounterBuffer;

		// Token: 0x04000059 RID: 89
		private GraphicsBuffer m_AccumCounterBuffer;

		// Token: 0x0400005A RID: 90
		private GraphicsBuffer m_TrianglesInVoxels;

		// Token: 0x0400005B RID: 91
		private GraphicsBuffer m_TrianglesUV;

		// Token: 0x0400005C RID: 92
		private GraphicsBuffer m_TmpBuffer;

		// Token: 0x0400005D RID: 93
		private GraphicsBuffer m_AccumSumBlocks;

		// Token: 0x0400005E RID: 94
		private GraphicsBuffer m_SumBlocksBuffer;

		// Token: 0x0400005F RID: 95
		private GraphicsBuffer m_InSumBlocksBuffer;

		// Token: 0x04000060 RID: 96
		private GraphicsBuffer m_SumBlocksAdditional;

		// Token: 0x04000061 RID: 97
		private GraphicsBuffer m_IndicesBuffer;

		// Token: 0x04000062 RID: 98
		private GraphicsBuffer m_VerticesBuffer;

		// Token: 0x04000063 RID: 99
		private GraphicsBuffer m_VerticesOutBuffer;

		// Token: 0x04000064 RID: 100
		private GraphicsBuffer m_CoordFlipBuffer;

		// Token: 0x04000065 RID: 101
		private GraphicsBuffer m_AabbBuffer;

		// Token: 0x04000066 RID: 102
		private int m_VertexBufferOffset;

		// Token: 0x04000067 RID: 103
		private int m_ThreadGroupSize = 512;

		// Token: 0x04000068 RID: 104
		private int m_SignPassesCount;

		// Token: 0x04000069 RID: 105
		private float m_InOutThreshold;

		// Token: 0x0400006A RID: 106
		private Material[] m_Material;

		// Token: 0x0400006B RID: 107
		private Matrix4x4[] m_WorldToClip;

		// Token: 0x0400006C RID: 108
		private Matrix4x4[] m_ProjMat;

		// Token: 0x0400006D RID: 109
		private Matrix4x4[] m_ViewMat;

		// Token: 0x0400006E RID: 110
		private int m_nStepsJFA;

		// Token: 0x0400006F RID: 111
		private MeshToSDFBaker.Kernels m_Kernels;

		// Token: 0x04000070 RID: 112
		private Mesh m_Mesh;

		// Token: 0x04000071 RID: 113
		private RenderTexture m_textureVoxel;

		// Token: 0x04000072 RID: 114
		private RenderTexture m_textureVoxelBis;

		// Token: 0x04000073 RID: 115
		private RenderTexture m_DistanceTexture;

		// Token: 0x04000074 RID: 116
		private GraphicsBuffer m_bufferVoxel;

		// Token: 0x04000075 RID: 117
		private ComputeShader m_computeShader;

		// Token: 0x04000076 RID: 118
		private int m_maxResolution;

		// Token: 0x04000077 RID: 119
		private float m_MaxExtent;

		// Token: 0x04000078 RID: 120
		private float m_SdfOffset;

		// Token: 0x04000079 RID: 121
		private int nTriangles;

		// Token: 0x0400007A RID: 122
		private Vector3 m_SizeBox;

		// Token: 0x0400007B RID: 123
		private Vector3 m_Center;

		// Token: 0x0400007C RID: 124
		private CommandBuffer m_Cmd;

		// Token: 0x0400007D RID: 125
		private bool m_OwnsCommandBuffer = true;

		// Token: 0x0400007E RID: 126
		private bool m_IsDisposed;

		// Token: 0x0400007F RID: 127
		private int[] m_Dimensions = new int[3];

		// Token: 0x04000080 RID: 128
		private int[] m_OffsetRayMap = new int[3];

		// Token: 0x04000081 RID: 129
		private float[] m_MinBoundsExtended = new float[3];

		// Token: 0x04000082 RID: 130
		private float[] m_MaxBoundsExtended = new float[3];

		// Token: 0x04000083 RID: 131
		internal static uint kMaxRecommandedGridSize = 16777216U;

		// Token: 0x04000084 RID: 132
		internal static uint kMaxAbsoluteGridSize = 134217728U;

		// Token: 0x04000085 RID: 133
		private static int kNbActualRT = 0;

		// Token: 0x04000086 RID: 134
		internal VFXRuntimeResources m_RuntimeResources;

		// Token: 0x0200005E RID: 94
		private static class ShaderProperties
		{
			// Token: 0x0400018F RID: 399
			internal static int indicesBuffer = Shader.PropertyToID("indices");

			// Token: 0x04000190 RID: 400
			internal static int verticesBuffer = Shader.PropertyToID("vertices");

			// Token: 0x04000191 RID: 401
			internal static int vertexPositionOffset = Shader.PropertyToID("vertexPositionOffset");

			// Token: 0x04000192 RID: 402
			internal static int vertexStride = Shader.PropertyToID("vertexStride");

			// Token: 0x04000193 RID: 403
			internal static int indexStride = Shader.PropertyToID("indexStride");

			// Token: 0x04000194 RID: 404
			internal static int coordFlipBuffer = Shader.PropertyToID("coordFlip");

			// Token: 0x04000195 RID: 405
			internal static int verticesOutBuffer = Shader.PropertyToID("verticesOut");

			// Token: 0x04000196 RID: 406
			internal static int aabbBuffer = Shader.PropertyToID("aabb");

			// Token: 0x04000197 RID: 407
			internal static int worldToClip = Shader.PropertyToID("worldToClip");

			// Token: 0x04000198 RID: 408
			internal static int currentAxis = Shader.PropertyToID("currentAxis");

			// Token: 0x04000199 RID: 409
			internal static int voxelsBuffer = Shader.PropertyToID("voxelsBuffer");

			// Token: 0x0400019A RID: 410
			internal static int rw_trianglesUV = Shader.PropertyToID("rw_trianglesUV");

			// Token: 0x0400019B RID: 411
			internal static int trianglesUV = Shader.PropertyToID("trianglesUV");

			// Token: 0x0400019C RID: 412
			internal static int voxelsTexture = Shader.PropertyToID("voxels");

			// Token: 0x0400019D RID: 413
			internal static int voxelsTmpTexture = Shader.PropertyToID("voxelsTmp");

			// Token: 0x0400019E RID: 414
			internal static int rayMap = Shader.PropertyToID("rayMap");

			// Token: 0x0400019F RID: 415
			internal static int nTriangles = Shader.PropertyToID("nTriangles");

			// Token: 0x040001A0 RID: 416
			internal static int minBoundsExtended = Shader.PropertyToID("minBoundsExtended");

			// Token: 0x040001A1 RID: 417
			internal static int maxBoundsExtended = Shader.PropertyToID("maxBoundsExtended");

			// Token: 0x040001A2 RID: 418
			internal static int maxExtent = Shader.PropertyToID("maxExtent");

			// Token: 0x040001A3 RID: 419
			internal static int upperBoundCount = Shader.PropertyToID("upperBoundCount");

			// Token: 0x040001A4 RID: 420
			internal static int counter = Shader.PropertyToID("counter");

			// Token: 0x040001A5 RID: 421
			internal static int dimX = Shader.PropertyToID("dimX");

			// Token: 0x040001A6 RID: 422
			internal static int dimY = Shader.PropertyToID("dimY");

			// Token: 0x040001A7 RID: 423
			internal static int dimZ = Shader.PropertyToID("dimZ");

			// Token: 0x040001A8 RID: 424
			internal static int size = Shader.PropertyToID("size");

			// Token: 0x040001A9 RID: 425
			internal static int inputBuffer = Shader.PropertyToID("Input");

			// Token: 0x040001AA RID: 426
			internal static int inputCounter = Shader.PropertyToID("inputCounter");

			// Token: 0x040001AB RID: 427
			internal static int auxBuffer = Shader.PropertyToID("auxBuffer");

			// Token: 0x040001AC RID: 428
			internal static int resultBuffer = Shader.PropertyToID("Result");

			// Token: 0x040001AD RID: 429
			internal static int numElem = Shader.PropertyToID("numElem");

			// Token: 0x040001AE RID: 430
			internal static int exclusive = Shader.PropertyToID("exclusive");

			// Token: 0x040001AF RID: 431
			internal static int dispatchWidth = Shader.PropertyToID("dispatchWidth");

			// Token: 0x040001B0 RID: 432
			internal static int src = Shader.PropertyToID("src");

			// Token: 0x040001B1 RID: 433
			internal static int dest = Shader.PropertyToID("dest");

			// Token: 0x040001B2 RID: 434
			internal static int signMap = Shader.PropertyToID("signMap");

			// Token: 0x040001B3 RID: 435
			internal static int threshold = Shader.PropertyToID("threshold");

			// Token: 0x040001B4 RID: 436
			internal static int signMapTmp = Shader.PropertyToID("signMapTmp");

			// Token: 0x040001B5 RID: 437
			internal static int normalizeFactor = Shader.PropertyToID("normalizeFactor");

			// Token: 0x040001B6 RID: 438
			internal static int numNeighbours = Shader.PropertyToID("numNeighbours");

			// Token: 0x040001B7 RID: 439
			internal static int passId = Shader.PropertyToID("passId");

			// Token: 0x040001B8 RID: 440
			internal static int needNormalize = Shader.PropertyToID("needNormalize");

			// Token: 0x040001B9 RID: 441
			internal static int offset = Shader.PropertyToID("offset");

			// Token: 0x040001BA RID: 442
			internal static int offsetRayMap = Shader.PropertyToID("offsetRayMap");

			// Token: 0x040001BB RID: 443
			internal static int triangleIDs = Shader.PropertyToID("triangleIDs");

			// Token: 0x040001BC RID: 444
			internal static int accumCounter = Shader.PropertyToID("accumCounter");

			// Token: 0x040001BD RID: 445
			internal static int distanceTexture = Shader.PropertyToID("distanceTexture");

			// Token: 0x040001BE RID: 446
			internal static int sdfOffset = Shader.PropertyToID("sdfOffset");
		}

		// Token: 0x0200005F RID: 95
		internal class Kernels
		{
			// Token: 0x060001ED RID: 493 RVA: 0x00009C90 File Offset: 0x00007E90
			internal Kernels(ComputeShader computeShader)
			{
				this.inBucketSum = computeShader.FindKernel("InBucketSum");
				this.blockSums = computeShader.FindKernel("BlockSums");
				this.finalSum = computeShader.FindKernel("FinalSum");
				this.toTextureNormalized = computeShader.FindKernel("ToTextureNormalized");
				this.copyTextures = computeShader.FindKernel("CopyTextures");
				this.jfa = computeShader.FindKernel("JFA");
				this.distanceTransform = computeShader.FindKernel("DistanceTransform");
				this.copyBuffers = computeShader.FindKernel("CopyBuffers");
				this.generateRayMapLocal = computeShader.FindKernel("GenerateRayMapLocal");
				this.rayMapScanX = computeShader.FindKernel("RayMapScanX");
				this.rayMapScanY = computeShader.FindKernel("RayMapScanY");
				this.rayMapScanZ = computeShader.FindKernel("RayMapScanZ");
				this.signPass6Rays = computeShader.FindKernel("SignPass6Rays");
				this.signPassNeighbors = computeShader.FindKernel("SignPassNeighbors");
				this.toBlockSumBuffer = computeShader.FindKernel("ToBlockSumBuffer");
				this.clearTexturesAndBuffers = computeShader.FindKernel("ClearTexturesAndBuffers");
				this.copyToBuffer = computeShader.FindKernel("CopyToBuffer");
				this.generateTrianglesUV = computeShader.FindKernel("GenerateTrianglesUV");
				this.conservativeRasterization = computeShader.FindKernel("ConservativeRasterization");
				this.chooseDirectionTriangleOnly = computeShader.FindKernel("ChooseDirectionTriangleOnly");
				this.surfaceClosing = computeShader.FindKernel("SurfaceClosing");
			}

			// Token: 0x040001BF RID: 447
			internal int inBucketSum = -1;

			// Token: 0x040001C0 RID: 448
			internal int blockSums = -1;

			// Token: 0x040001C1 RID: 449
			internal int finalSum = -1;

			// Token: 0x040001C2 RID: 450
			internal int toTextureNormalized = -1;

			// Token: 0x040001C3 RID: 451
			internal int copyTextures = -1;

			// Token: 0x040001C4 RID: 452
			internal int jfa = -1;

			// Token: 0x040001C5 RID: 453
			internal int distanceTransform = -1;

			// Token: 0x040001C6 RID: 454
			internal int copyBuffers = -1;

			// Token: 0x040001C7 RID: 455
			internal int generateRayMapLocal = -1;

			// Token: 0x040001C8 RID: 456
			internal int rayMapScanX = -1;

			// Token: 0x040001C9 RID: 457
			internal int rayMapScanY = -1;

			// Token: 0x040001CA RID: 458
			internal int rayMapScanZ = -1;

			// Token: 0x040001CB RID: 459
			internal int signPass6Rays = -1;

			// Token: 0x040001CC RID: 460
			internal int signPassNeighbors = -1;

			// Token: 0x040001CD RID: 461
			internal int toBlockSumBuffer = -1;

			// Token: 0x040001CE RID: 462
			internal int clearTexturesAndBuffers = -1;

			// Token: 0x040001CF RID: 463
			internal int copyToBuffer = -1;

			// Token: 0x040001D0 RID: 464
			internal int generateTrianglesUV = -1;

			// Token: 0x040001D1 RID: 465
			internal int conservativeRasterization = -1;

			// Token: 0x040001D2 RID: 466
			internal int chooseDirectionTriangleOnly = -1;

			// Token: 0x040001D3 RID: 467
			internal int surfaceClosing = -1;
		}
	}
}
