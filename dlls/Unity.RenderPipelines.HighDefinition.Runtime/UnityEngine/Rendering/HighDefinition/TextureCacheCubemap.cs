using System;
using UnityEngine.Experimental.Rendering;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200002D RID: 45
	internal class TextureCacheCubemap : TextureCache
	{
		// Token: 0x0600007A RID: 122 RVA: 0x00004FEA File Offset: 0x000031EA
		public TextureCacheCubemap(string cacheName = "", int sliceSize = 1) : base(cacheName, sliceSize)
		{
			if (HDRenderPipeline.isReady)
			{
				this.m_BlitCubemapFaceMaterial = CoreUtils.CreateEngineMaterial(HDRenderPipelineGlobalSettings.instance.renderPipelineResources.shaders.blitCubeTextureFacePS);
			}
			this.m_BlitCubemapFaceProperties = new MaterialPropertyBlock();
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00005025 File Offset: 0x00003225
		public override bool IsCreated()
		{
			return this.m_Cache.IsCreated();
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00005034 File Offset: 0x00003234
		protected override bool TransferToSlice(CommandBuffer cmd, int sliceIndex, Texture[] textureArray)
		{
			if (!TextureCache.supportsCubemapArrayTextures)
			{
				return this.TransferToPanoCache(cmd, sliceIndex, textureArray);
			}
			if (textureArray == null || textureArray.Length == 0)
			{
				return false;
			}
			for (int i = 1; i < textureArray.Length; i++)
			{
				if (textureArray[i].width != textureArray[0].width || textureArray[i].height != textureArray[0].height)
				{
					Debug.LogWarning("All the sub-textures should have the same dimensions to be handled by the texture cache.");
					return false;
				}
			}
			bool flag = this.m_Cache.width != textureArray[0].width || this.m_Cache.height != textureArray[0].height;
			if (textureArray[0] is Cubemap)
			{
				flag |= (this.m_Cache.graphicsFormat != (textureArray[0] as Cubemap).graphicsFormat);
			}
			for (int j = 0; j < textureArray.Length; j++)
			{
				if (flag)
				{
					this.m_BlitCubemapFaceProperties.SetTexture(HDShaderIDs._InputTex, textureArray[j]);
					this.m_BlitCubemapFaceProperties.SetFloat(HDShaderIDs._LoD, 0f);
					for (int k = 0; k < 6; k++)
					{
						this.m_BlitCubemapFaceProperties.SetFloat(HDShaderIDs._FaceIndex, (float)k);
						CoreUtils.SetRenderTarget(cmd, this.m_Cache, ClearFlag.None, Color.black, 0, CubemapFace.Unknown, 6 * (this.m_SliceSize * sliceIndex + j) + k);
						CoreUtils.DrawFullScreen(cmd, this.m_BlitCubemapFaceMaterial, this.m_BlitCubemapFaceProperties, 0);
					}
				}
				else
				{
					for (int l = 0; l < 6; l++)
					{
						cmd.CopyTexture(textureArray[j], l, this.m_Cache, 6 * (this.m_SliceSize * sliceIndex + j) + l);
					}
				}
			}
			return true;
		}

		// Token: 0x0600007D RID: 125 RVA: 0x000051CB File Offset: 0x000033CB
		public override Texture GetTexCache()
		{
			if (TextureCache.supportsCubemapArrayTextures)
			{
				return this.m_Cache;
			}
			return this.m_CacheNoCubeArray;
		}

		// Token: 0x0600007E RID: 126 RVA: 0x000051E4 File Offset: 0x000033E4
		public bool AllocTextureArray(int numCubeMaps, int width, GraphicsFormat format, bool isMipMapped, Material cubeBlitMaterial)
		{
			bool result = base.AllocTextureArray(numCubeMaps);
			this.m_NumMipLevels = base.GetNumMips(width, width);
			if (!TextureCache.supportsCubemapArrayTextures)
			{
				this.m_CubeBlitMaterial = cubeBlitMaterial;
				int num = 4 * width;
				int num2 = 2 * width;
				this.m_CacheNoCubeArray = new Texture2DArray(num, num2, numCubeMaps, format, isMipMapped ? TextureCreationFlags.MipChain : TextureCreationFlags.None)
				{
					hideFlags = HideFlags.HideAndDontSave,
					wrapMode = TextureWrapMode.Repeat,
					wrapModeV = TextureWrapMode.Clamp,
					filterMode = FilterMode.Trilinear,
					anisoLevel = 0,
					name = CoreUtils.GetTextureAutoName(num, num2, format, TextureDimension.Tex2DArray, this.m_CacheName, false, numCubeMaps)
				};
				this.m_NumPanoMipLevels = (isMipMapped ? base.GetNumMips(num, num2) : 1);
				this.m_StagingRTs = new RenderTexture[this.m_NumPanoMipLevels];
				for (int i = 0; i < this.m_NumPanoMipLevels; i++)
				{
					this.m_StagingRTs[i] = new RenderTexture(Mathf.Max(1, num >> i), Mathf.Max(1, num2 >> i), 0, format)
					{
						hideFlags = HideFlags.HideAndDontSave
					};
					this.m_StagingRTs[i].name = CoreUtils.GetRenderTargetAutoName(Mathf.Max(1, num >> i), Mathf.Max(1, num2 >> i), 1, format, string.Format("PanaCache{0}", i), false, false, MSAASamples.None);
				}
				if (this.m_CubeBlitMaterial)
				{
					this.m_CubeMipLevelPropName = Shader.PropertyToID("_cubeMipLvl");
					this.m_cubeSrcTexPropName = Shader.PropertyToID("_srcCubeTexture");
				}
			}
			else
			{
				RenderTextureDescriptor desc = new RenderTextureDescriptor(width, width, format, 0)
				{
					dimension = TextureDimension.CubeArray,
					volumeDepth = numCubeMaps * 6,
					autoGenerateMips = false,
					useMipMap = isMipMapped,
					msaaSamples = 1
				};
				this.m_Cache = new RenderTexture(desc)
				{
					hideFlags = HideFlags.HideAndDontSave,
					wrapMode = TextureWrapMode.Clamp,
					filterMode = FilterMode.Trilinear,
					anisoLevel = 0,
					name = CoreUtils.GetTextureAutoName(width, width, format, desc.dimension, this.m_CacheName, isMipMapped, numCubeMaps)
				};
				this.ClearCache();
				this.m_Cache.Create();
			}
			return result;
		}

		// Token: 0x0600007F RID: 127 RVA: 0x000053F4 File Offset: 0x000035F4
		internal void ClearCache()
		{
			RenderTextureDescriptor descriptor = this.m_Cache.descriptor;
			int num = descriptor.useMipMap ? base.GetNumMips(descriptor.width, descriptor.height) : 1;
			for (int i = 0; i < num; i++)
			{
				Graphics.SetRenderTarget(this.m_Cache, i, CubemapFace.Unknown, -1);
				GL.Clear(false, true, Color.clear);
			}
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00005454 File Offset: 0x00003654
		public void Release()
		{
			if (this.m_CacheNoCubeArray)
			{
				CoreUtils.Destroy(this.m_CacheNoCubeArray);
				for (int i = 0; i < this.m_NumPanoMipLevels; i++)
				{
					this.m_StagingRTs[i].Release();
				}
				this.m_StagingRTs = null;
				CoreUtils.Destroy(this.m_CubeBlitMaterial);
			}
			CoreUtils.Destroy(this.m_BlitCubemapFaceMaterial);
			CoreUtils.Destroy(this.m_Cache);
		}

		// Token: 0x06000081 RID: 129 RVA: 0x000054C0 File Offset: 0x000036C0
		private bool TransferToPanoCache(CommandBuffer cmd, int sliceIndex, Texture[] textureArray)
		{
			for (int i = 0; i < textureArray.Length; i++)
			{
				this.m_CubeBlitMaterial.SetTexture(this.m_cubeSrcTexPropName, textureArray[i]);
				for (int j = 0; j < this.m_NumPanoMipLevels; j++)
				{
					this.m_CubeBlitMaterial.SetInt(this.m_CubeMipLevelPropName, Mathf.Min(this.m_NumMipLevels - 1, j));
					cmd.Blit(null, this.m_StagingRTs[j], this.m_CubeBlitMaterial, 0);
				}
				for (int k = 0; k < this.m_NumPanoMipLevels; k++)
				{
					cmd.CopyTexture(this.m_StagingRTs[k], 0, 0, this.m_CacheNoCubeArray, this.m_SliceSize * sliceIndex + i, k);
				}
			}
			return true;
		}

		// Token: 0x06000082 RID: 130 RVA: 0x0000557D File Offset: 0x0000377D
		internal static long GetApproxCacheSizeInByte(int nbElement, int resolution, int sliceSize)
		{
			return (long)((float)((long)nbElement * (long)resolution * (long)resolution * 6L * 2L * 4L) * 1.33f * (float)sliceSize);
		}

		// Token: 0x06000083 RID: 131 RVA: 0x0000559B File Offset: 0x0000379B
		internal static int GetMaxCacheSizeForWeightInByte(long weight, int resolution, int sliceSize)
		{
			return Mathf.Clamp(Mathf.FloorToInt((float)weight / ((float)((long)resolution * (long)resolution * 6L * 2L * 4L) * 1.33f * (float)sliceSize)), 1, 250);
		}

		// Token: 0x040000BF RID: 191
		private RenderTexture m_Cache;

		// Token: 0x040000C0 RID: 192
		private const int k_NbFace = 6;

		// Token: 0x040000C1 RID: 193
		private Texture2DArray m_CacheNoCubeArray;

		// Token: 0x040000C2 RID: 194
		private RenderTexture[] m_StagingRTs;

		// Token: 0x040000C3 RID: 195
		private int m_NumPanoMipLevels;

		// Token: 0x040000C4 RID: 196
		private Material m_CubeBlitMaterial;

		// Token: 0x040000C5 RID: 197
		private int m_CubeMipLevelPropName;

		// Token: 0x040000C6 RID: 198
		private int m_cubeSrcTexPropName;

		// Token: 0x040000C7 RID: 199
		private Material m_BlitCubemapFaceMaterial;

		// Token: 0x040000C8 RID: 200
		private MaterialPropertyBlock m_BlitCubemapFaceProperties;
	}
}
