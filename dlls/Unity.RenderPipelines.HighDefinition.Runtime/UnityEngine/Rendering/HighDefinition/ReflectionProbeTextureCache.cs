using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.Experimental.Rendering;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000AD RID: 173
	internal class ReflectionProbeTextureCache
	{
		// Token: 0x060007F0 RID: 2032 RVA: 0x00049DAC File Offset: 0x00047FAC
		public ReflectionProbeTextureCache(HDRenderPipelineRuntimeResources defaultResources, IBLFilterBSDF[] iblFiltersBSDF, int width, int height, GraphicsFormat format, bool decreaseResToFit, int lastValidCubeMip, int lastValidPlanarMip)
		{
			this.m_IBLFiltersBSDF = iblFiltersBSDF;
			this.m_AtlasWidth = width;
			this.m_AtlasHeight = height;
			this.m_AtlasFormat = format;
			this.m_AtlasMipCount = Mathf.FloorToInt(Mathf.Log((float)Math.Max(this.m_AtlasWidth, this.m_AtlasHeight), 2f)) + 1;
			this.m_AtlasSlicesCount = this.m_IBLFiltersBSDF.Length;
			this.m_AtlasTexture = RTHandles.Alloc(width, height, this.m_AtlasSlicesCount, DepthBits.None, format, FilterMode.Trilinear, TextureWrapMode.Clamp, TextureDimension.Tex2DArray, false, true, false, false, 1, 0f, MSAASamples.None, false, false, RenderTextureMemoryless.None, VRTextureUsage.None, "ReflectionProbeCacheTextureAtlas");
			this.m_Atlas = new Texture2DAtlasDynamic(width, height, 2048, this.m_AtlasTexture);
			this.m_CubeMipPadding = Mathf.Clamp(lastValidCubeMip, 0, 6);
			this.m_CubeTexelPadding = (1 << this.m_CubeMipPadding) * 2;
			this.m_PlanarMipPadding = Mathf.Clamp(lastValidPlanarMip, 0, 6);
			this.m_PlanarTexelPadding = (1 << this.m_PlanarMipPadding) * 2;
			this.m_DecreaseResToFit = decreaseResToFit;
			this.m_ConvertTextureMaterial = CoreUtils.CreateEngineMaterial(defaultResources.shaders.blitCubeTextureFacePS);
		}

		// Token: 0x060007F1 RID: 2033 RVA: 0x00049EE0 File Offset: 0x000480E0
		private static int GetTextureID(HDProbe probe)
		{
			int num;
			return ReflectionProbeTextureCache.GetTextureIDAndSize(probe, out num);
		}

		// Token: 0x060007F2 RID: 2034 RVA: 0x00049EF8 File Offset: 0x000480F8
		private static int GetTextureIDAndSize(HDProbe probe, out int textureSize)
		{
			textureSize = ReflectionProbeTextureCache.GetTextureSizeInAtlas(probe);
			int instanceID = probe.texture.GetInstanceID();
			return 31 * instanceID + textureSize;
		}

		// Token: 0x060007F3 RID: 2035 RVA: 0x00049F24 File Offset: 0x00048124
		private static int GetTextureSizeInAtlas(HDProbe probe)
		{
			int num = probe.texture.width;
			if (probe.type == ProbeSettings.ProbeType.ReflectionProbe)
			{
				num = Mathf.Min(num, (int)probe.cubeResolution);
				num = ReflectionProbeTextureCache.GetReflectionProbeSizeInAtlas(num);
			}
			return num;
		}

		// Token: 0x060007F4 RID: 2036 RVA: 0x00049F5A File Offset: 0x0004815A
		public static int GetReflectionProbeSizeInAtlas(int textureSize)
		{
			textureSize = Mathf.Max(textureSize, 32);
			if (textureSize < 512)
			{
				textureSize *= 4;
			}
			else
			{
				textureSize *= 2;
			}
			return textureSize;
		}

		// Token: 0x060007F5 RID: 2037 RVA: 0x00049F7C File Offset: 0x0004817C
		private static Vector2 GetTextureSizeWithoutPadding(int textureWidth, int textureHeight, int texelPadding)
		{
			float num = (float)Mathf.Max(textureWidth - texelPadding, 1);
			int num2 = Mathf.Max(textureHeight - texelPadding, 1);
			return new Vector2(num, (float)num2);
		}

		// Token: 0x060007F6 RID: 2038 RVA: 0x00049FA4 File Offset: 0x000481A4
		internal static long GetApproxCacheSizeInByte(int elementsCount, int width, int height, GraphicsFormat format)
		{
			return (long)((double)(elementsCount * width * height) * 1.33 * GraphicsFormatUtility.GetBlockSize(format));
		}

		// Token: 0x060007F7 RID: 2039 RVA: 0x00049FC0 File Offset: 0x000481C0
		private RenderTexture EnsureConvolvedPlanarReflectionTexture(int textureSize)
		{
			if (this.m_ConvolvedPlanarReflectionTexture == null || this.m_ConvolvedPlanarReflectionTexture.width < textureSize)
			{
				RenderTexture convolvedPlanarReflectionTexture = this.m_ConvolvedPlanarReflectionTexture;
				if (convolvedPlanarReflectionTexture != null)
				{
					convolvedPlanarReflectionTexture.Release();
				}
				this.m_ConvolvedPlanarReflectionTexture = new RenderTexture(textureSize, textureSize, 0, this.m_AtlasFormat);
				this.m_ConvolvedPlanarReflectionTexture.hideFlags = HideFlags.HideAndDontSave;
				this.m_ConvolvedPlanarReflectionTexture.dimension = TextureDimension.Tex2D;
				this.m_ConvolvedPlanarReflectionTexture.useMipMap = true;
				this.m_ConvolvedPlanarReflectionTexture.autoGenerateMips = false;
				this.m_ConvolvedPlanarReflectionTexture.filterMode = FilterMode.Point;
				this.m_ConvolvedPlanarReflectionTexture.name = CoreUtils.GetRenderTargetAutoName(textureSize, textureSize, 0, this.m_AtlasFormat, "ConvolvedPlanarReflectionTexture", true, false, MSAASamples.None);
				this.m_ConvolvedPlanarReflectionTexture.enableRandomWrite = true;
				this.m_ConvolvedPlanarReflectionTexture.Create();
			}
			return this.m_ConvolvedPlanarReflectionTexture;
		}

		// Token: 0x060007F8 RID: 2040 RVA: 0x0004A08D File Offset: 0x0004828D
		private void LogErrorNoMoreSpaceOnce()
		{
			if (!this.m_NoMoreSpaceErrorLogged)
			{
				this.m_NoMoreSpaceErrorLogged = true;
				Debug.LogError("No more space in Reflection Probe Atlas. To solve this issue, increase the size of the Reflection Probe Atlas in the HDRP settings.");
			}
		}

		// Token: 0x060007F9 RID: 2041 RVA: 0x0004A0A8 File Offset: 0x000482A8
		private bool NeedsUpdate(int textureId, uint textureHash, ref Vector4 scaleOffset)
		{
			bool result = false;
			ValueTuple<uint, uint> valueTuple;
			if (!this.m_Atlas.IsCached(out scaleOffset, textureId))
			{
				result = true;
			}
			else if (!this.m_TextureLRUAndHash.TryGetValue(textureId, out valueTuple) || valueTuple.Item2 != textureHash)
			{
				result = true;
			}
			this.m_TextureLRUAndHash[textureId] = new ValueTuple<uint, uint>(this.m_CurrentRender, textureHash);
			return result;
		}

		// Token: 0x060007FA RID: 2042 RVA: 0x0004A100 File Offset: 0x00048300
		private RenderTexture GetTempConvertedReflectionProbeTexture(Texture texture, int cubeSize)
		{
			if (this.m_TempConvertedReflectionProbeTexture == null || this.m_TmpTextureConvertedSize != cubeSize || this.m_TmpTextureConvertedFormat != this.m_AtlasFormat || this.m_TmpTextureConvertedFilterMode != texture.filterMode)
			{
				if (this.m_TempConvertedReflectionProbeTexture != null)
				{
					RenderTexture.ReleaseTemporary(this.m_TempConvertedReflectionProbeTexture);
				}
				RenderTexture temporary = RenderTexture.GetTemporary(cubeSize, cubeSize, 0, this.m_AtlasFormat);
				temporary.dimension = TextureDimension.Cube;
				temporary.filterMode = texture.filterMode;
				temporary.useMipMap = true;
				temporary.autoGenerateMips = false;
				temporary.name = CoreUtils.GetRenderTargetAutoName(cubeSize, cubeSize, 0, this.m_AtlasFormat, "ConvertedReflectionProbeTemp", true, false, MSAASamples.None);
				temporary.Create();
				this.m_TempConvertedReflectionProbeTexture = temporary;
				this.m_TmpTextureConvertedSize = cubeSize;
				this.m_TmpTextureConvertedFormat = this.m_AtlasFormat;
				this.m_TmpTextureConvertedFilterMode = texture.filterMode;
			}
			this.m_TempCubeTexturesLastFrameUsed = (int)this.m_CurrentRender;
			return this.m_TempConvertedReflectionProbeTexture;
		}

		// Token: 0x060007FB RID: 2043 RVA: 0x0004A1E8 File Offset: 0x000483E8
		private RenderTexture PrepareCubeReflectionProbeTexture(CommandBuffer cmd, Texture texture, int textureSize)
		{
			RenderTexture renderTexture = texture as RenderTexture;
			Cubemap cubemap = texture as Cubemap;
			using (new ProfilingScope(cmd, ProfilingSampler.Get<HDProfileId>(HDProfileId.ConvertReflectionProbe)))
			{
				int num = Math.Max(textureSize, (int)Mathf.Pow(2f, 6f));
				if (texture.graphicsFormat != this.m_AtlasFormat | (cubemap && cubemap.mipmapCount == 1) | (renderTexture && !renderTexture.useMipMap) | texture.width != num)
				{
					RenderTexture tempConvertedReflectionProbeTexture = this.GetTempConvertedReflectionProbeTexture(texture, num);
					this.m_ConvertTexturePropertyBlock.SetTexture(HDShaderIDs._InputTex, texture);
					this.m_ConvertTexturePropertyBlock.SetFloat(HDShaderIDs._LoD, 0f);
					for (int i = 0; i < 6; i++)
					{
						this.m_ConvertTexturePropertyBlock.SetFloat(HDShaderIDs._FaceIndex, (float)i);
						CoreUtils.SetRenderTarget(cmd, tempConvertedReflectionProbeTexture, ClearFlag.None, Color.black, 0, (CubemapFace)i, -1);
						CoreUtils.DrawFullScreen(cmd, this.m_ConvertTextureMaterial, this.m_ConvertTexturePropertyBlock, 0);
					}
					cmd.GenerateMips(tempConvertedReflectionProbeTexture);
					return tempConvertedReflectionProbeTexture;
				}
				if (renderTexture && !renderTexture.autoGenerateMips)
				{
					cmd.GenerateMips(renderTexture);
				}
			}
			return null;
		}

		// Token: 0x060007FC RID: 2044 RVA: 0x0004A348 File Offset: 0x00048548
		private RenderTexture GetTempConvolveReflectionProbeTexture(Texture texture)
		{
			if (this.m_TempConvolvedReflectionProbeTexture == null || this.m_TmpTextureConvolvedWidth != texture.width || this.m_TmpTextureConvolvedHeight != texture.height || this.m_TmpTextureConvolvedFormat != this.m_AtlasFormat || this.m_TmpTextureConvolvedFilterMode != texture.filterMode)
			{
				if (this.m_TempConvolvedReflectionProbeTexture != null)
				{
					RenderTexture.ReleaseTemporary(this.m_TempConvolvedReflectionProbeTexture);
				}
				RenderTexture temporary = RenderTexture.GetTemporary(texture.width, texture.height, 0, this.m_AtlasFormat);
				temporary.dimension = TextureDimension.Cube;
				temporary.filterMode = texture.filterMode;
				temporary.useMipMap = true;
				temporary.autoGenerateMips = false;
				temporary.anisoLevel = 0;
				temporary.name = "ConvolvedReflectionProbeTemp";
				temporary.Create();
				this.m_TempConvolvedReflectionProbeTexture = temporary;
				this.m_TmpTextureConvolvedWidth = texture.width;
				this.m_TmpTextureConvolvedHeight = texture.height;
				this.m_TmpConvolvedFilterMode = texture.filterMode;
				this.m_TmpTextureConvolvedFormat = this.m_AtlasFormat;
				this.m_TmpTextureConvolvedFilterMode = texture.filterMode;
			}
			this.m_TempCubeTexturesLastFrameUsed = (int)this.m_CurrentRender;
			return this.m_TempConvolvedReflectionProbeTexture;
		}

		// Token: 0x060007FD RID: 2045 RVA: 0x0004A460 File Offset: 0x00048660
		private RenderTexture ConvolveCubeReflectionProbeTexture(CommandBuffer cmd, Texture texture, IBLFilterBSDF filter)
		{
			RenderTexture tempConvolveReflectionProbeTexture = this.GetTempConvolveReflectionProbeTexture(texture);
			filter.FilterCubemap(cmd, texture, tempConvolveReflectionProbeTexture);
			return tempConvolveReflectionProbeTexture;
		}

		// Token: 0x060007FE RID: 2046 RVA: 0x0004A480 File Offset: 0x00048680
		private RenderTexture ConvolvePlanarReflectionProbeTexture(CommandBuffer cmd, Texture texture, ref IBLFilterBSDF.PlanarTextureFilteringParameters planarTextureFilteringParameters)
		{
			RenderTexture source = texture as RenderTexture;
			RenderTexture renderTexture = this.EnsureConvolvedPlanarReflectionTexture(texture.width);
			using (new ProfilingScope(cmd, ProfilingSampler.Get<HDProfileId>(HDProfileId.ConvolvePlanarReflectionProbe)))
			{
				((IBLFilterGGX)this.m_IBLFiltersBSDF[0]).FilterPlanarTexture(cmd, source, ref planarTextureFilteringParameters, renderTexture);
			}
			return renderTexture;
		}

		// Token: 0x060007FF RID: 2047 RVA: 0x0004A4E8 File Offset: 0x000486E8
		private void BlitTextureCube(CommandBuffer cmd, Vector4 scaleOffset, Texture texture, int arraySlice)
		{
			using (new ProfilingScope(cmd, ProfilingSampler.Get<HDProfileId>(HDProfileId.BlitTextureToReflectionProbeAtlas)))
			{
				int num = this.m_CubeTexelPadding;
				int textureWidth = Mathf.CeilToInt(scaleOffset.x * (float)this.m_AtlasWidth);
				int textureHeight = Mathf.CeilToInt(scaleOffset.y * (float)this.m_AtlasHeight);
				Vector2 textureSizeWithoutPadding = ReflectionProbeTextureCache.GetTextureSizeWithoutPadding(textureWidth, textureHeight, num);
				bool bilinear = texture.filterMode > FilterMode.Point;
				for (int i = 0; i < this.m_AtlasMipCount; i++)
				{
					if (i > this.m_CubeMipPadding)
					{
						num *= 2;
					}
					cmd.SetRenderTarget(this.m_AtlasTexture, i, CubemapFace.Unknown, arraySlice);
					Blitter.BlitCubeToOctahedral2DQuadWithPadding(cmd, texture, textureSizeWithoutPadding, scaleOffset, i, bilinear, num, null);
				}
			}
		}

		// Token: 0x06000800 RID: 2048 RVA: 0x0004A5B8 File Offset: 0x000487B8
		private void BlitTexture2D(CommandBuffer cmd, Vector4 scaleOffset, Vector4 sourceScaleOffset, Texture texture, int arraySlice)
		{
			using (new ProfilingScope(cmd, ProfilingSampler.Get<HDProfileId>(HDProfileId.BlitTextureToReflectionProbeAtlas)))
			{
				int planarTexelPadding = this.m_PlanarTexelPadding;
				int textureWidth = Mathf.CeilToInt(scaleOffset.x * (float)this.m_AtlasWidth);
				int textureHeight = Mathf.CeilToInt(scaleOffset.y * (float)this.m_AtlasHeight);
				Vector2 textureSizeWithoutPadding = ReflectionProbeTextureCache.GetTextureSizeWithoutPadding(textureWidth, textureHeight, planarTexelPadding);
				bool bilinear = texture.filterMode > FilterMode.Point;
				for (int i = 0; i < this.m_AtlasMipCount; i++)
				{
					cmd.SetRenderTarget(this.m_AtlasTexture, i, CubemapFace.Unknown, arraySlice);
					Blitter.BlitQuadWithPadding(cmd, texture, textureSizeWithoutPadding, sourceScaleOffset, scaleOffset, i, bilinear, planarTexelPadding);
				}
			}
		}

		// Token: 0x06000801 RID: 2049 RVA: 0x0004A674 File Offset: 0x00048874
		private bool RelayoutTextureAtlas()
		{
			List<ValueTuple<int, Vector4>> list;
			bool result;
			using (ListPool<ValueTuple<int, Vector4>>.Get(out list))
			{
				list.Capacity = this.m_TextureLRUAndHash.Count;
				foreach (KeyValuePair<int, ValueTuple<uint, uint>> keyValuePair in this.m_TextureLRUAndHash)
				{
					Vector4 item;
					if (this.m_Atlas.IsCached(out item, keyValuePair.Key))
					{
						list.Add(new ValueTuple<int, Vector4>(keyValuePair.Key, item));
					}
				}
				list.Sort(([TupleElementNames(new string[]
				{
					"textureId",
					"scaleOffset"
				})] ValueTuple<int, Vector4> a, [TupleElementNames(new string[]
				{
					"textureId",
					"scaleOffset"
				})] ValueTuple<int, Vector4> b) => b.Item2.x.CompareTo(a.Item2.x));
				this.m_Atlas.ResetAllocator();
				bool flag = true;
				foreach (ValueTuple<int, Vector4> valueTuple in list)
				{
					int width = Mathf.CeilToInt(valueTuple.Item2.x * (float)this.m_AtlasWidth);
					int height = Mathf.CeilToInt(valueTuple.Item2.y * (float)this.m_AtlasHeight);
					Vector4 vector;
					if (this.m_Atlas.EnsureTextureSlot(out result, out vector, valueTuple.Item1, width, height))
					{
						Vector2Int lhs = new Vector2Int(Mathf.FloorToInt(valueTuple.Item2.z * (float)this.m_AtlasWidth), Mathf.FloorToInt(valueTuple.Item2.w * (float)this.m_AtlasHeight));
						Vector2Int rhs = new Vector2Int(Mathf.FloorToInt(vector.z * (float)this.m_AtlasWidth), Mathf.FloorToInt(vector.w * (float)this.m_AtlasHeight));
						if (lhs != rhs)
						{
							ValueTuple<uint, uint> value = this.m_TextureLRUAndHash[valueTuple.Item1];
							value.Item2 = 0U;
							this.m_TextureLRUAndHash[valueTuple.Item1] = value;
						}
					}
					else
					{
						this.m_TextureLRUAndHash.Remove(valueTuple.Item1);
						flag = false;
					}
				}
				result = flag;
			}
			return result;
		}

		// Token: 0x06000802 RID: 2050 RVA: 0x0004A8C4 File Offset: 0x00048AC4
		private bool TryAllocateTexture(int textureId, int textureSize, ref Vector4 scaleOffset)
		{
			bool flag;
			if (this.m_Atlas.EnsureTextureSlot(out flag, out scaleOffset, textureId, textureSize, textureSize))
			{
				return true;
			}
			for (int i = this.m_TextureLRUSorted.Count - 1; i >= 0; i--)
			{
				ValueTuple<int, uint> valueTuple = this.m_TextureLRUSorted[i];
				if (this.m_CurrentRender - valueTuple.Item2 <= 1U)
				{
					break;
				}
				this.m_Atlas.ReleaseTextureSlot(valueTuple.Item1);
				this.m_TextureLRUAndHash.Remove(valueTuple.Item1);
				this.m_TextureLRUSorted.RemoveAt(i);
				if (this.m_Atlas.EnsureTextureSlot(out flag, out scaleOffset, textureId, textureSize, textureSize))
				{
					return true;
				}
			}
			if (this.m_DecreaseResToFit && this.m_Atlas.EnsureTextureSlot(out flag, out scaleOffset, textureId, textureSize / 2, textureSize / 2))
			{
				return true;
			}
			this.m_TextureLRUAndHash.Remove(textureId);
			return false;
		}

		// Token: 0x06000803 RID: 2051 RVA: 0x0004A990 File Offset: 0x00048B90
		private bool UpdateTexture(CommandBuffer cmd, HDProbe probe, ref Vector4 scaleOffset)
		{
			bool result;
			using (new ProfilingScope(cmd, ProfilingSampler.Get<HDProfileId>(HDProfileId.UpdateReflectionProbeAtlas)))
			{
				Texture texture = probe.texture;
				int textureSize;
				int textureIDAndSize = ReflectionProbeTextureCache.GetTextureIDAndSize(probe, out textureSize);
				if (!this.m_Atlas.IsCached(out scaleOffset, textureIDAndSize) && !this.TryAllocateTexture(textureIDAndSize, textureSize, ref scaleOffset))
				{
					result = false;
				}
				else
				{
					RenderTexture renderTexture = this.PrepareCubeReflectionProbeTexture(cmd, texture, textureSize);
					for (int i = 0; i < this.m_IBLFiltersBSDF.Length; i++)
					{
						RenderTexture texture2 = this.ConvolveCubeReflectionProbeTexture(cmd, renderTexture ? renderTexture : texture, this.m_IBLFiltersBSDF[i]);
						this.BlitTextureCube(cmd, scaleOffset, texture2, i);
					}
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06000804 RID: 2052 RVA: 0x0004AA54 File Offset: 0x00048C54
		private bool UpdateTexture(CommandBuffer cmd, HDProbe probe, ref IBLFilterBSDF.PlanarTextureFilteringParameters planarTextureFilteringParameters, ref Vector4 scaleOffset)
		{
			bool result;
			using (new ProfilingScope(cmd, ProfilingSampler.Get<HDProfileId>(HDProfileId.UpdateReflectionProbeAtlas)))
			{
				Texture texture = probe.texture;
				int textureSize;
				int textureIDAndSize = ReflectionProbeTextureCache.GetTextureIDAndSize(probe, out textureSize);
				if (!this.m_Atlas.IsCached(out scaleOffset, textureIDAndSize) && !this.TryAllocateTexture(textureIDAndSize, textureSize, ref scaleOffset))
				{
					result = false;
				}
				else
				{
					RenderTexture renderTexture = this.ConvolvePlanarReflectionProbeTexture(cmd, texture, ref planarTextureFilteringParameters);
					float num = (float)texture.width / (float)renderTexture.width;
					Vector4 sourceScaleOffset = new Vector4(num, num, 0f, 0f);
					this.BlitTexture2D(cmd, scaleOffset, sourceScaleOffset, renderTexture, 0);
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06000805 RID: 2053 RVA: 0x0004AB0C File Offset: 0x00048D0C
		public Vector4 GetTextureAtlasCubeData()
		{
			return new Vector4((float)this.m_CubeTexelPadding / (float)this.m_AtlasWidth, (float)this.m_CubeTexelPadding / (float)this.m_AtlasHeight, (float)this.m_CubeMipPadding, 0f);
		}

		// Token: 0x06000806 RID: 2054 RVA: 0x0004AB3D File Offset: 0x00048D3D
		public Vector4 GetTextureAtlasPlanarData()
		{
			return new Vector4((float)this.m_PlanarTexelPadding / (float)this.m_AtlasWidth, (float)this.m_PlanarTexelPadding / (float)this.m_AtlasHeight, 1f / (float)this.m_AtlasWidth, 1f / (float)this.m_AtlasHeight);
		}

		// Token: 0x06000807 RID: 2055 RVA: 0x0004AB7C File Offset: 0x00048D7C
		public Texture GetAtlasTexture()
		{
			return this.m_AtlasTexture;
		}

		// Token: 0x06000808 RID: 2056 RVA: 0x0004AB89 File Offset: 0x00048D89
		public int GetEnvSliceSize()
		{
			return this.m_AtlasSlicesCount;
		}

		// Token: 0x06000809 RID: 2057 RVA: 0x0004AB94 File Offset: 0x00048D94
		public void Release()
		{
			IBLFilterBSDF[] iblfiltersBSDF = this.m_IBLFiltersBSDF;
			for (int i = 0; i < iblfiltersBSDF.Length; i++)
			{
				iblfiltersBSDF[i].Cleanup();
			}
			this.m_IBLFiltersBSDF = null;
			this.m_AtlasTexture.Release();
			this.m_AtlasTexture = null;
			this.m_Atlas.Release();
			this.m_Atlas = null;
			this.m_TextureLRUAndHash = null;
			this.m_ConvertTextureMaterial = null;
			RenderTexture convolvedPlanarReflectionTexture = this.m_ConvolvedPlanarReflectionTexture;
			if (convolvedPlanarReflectionTexture != null)
			{
				convolvedPlanarReflectionTexture.Release();
			}
			if (this.m_TempConvertedReflectionProbeTexture != null)
			{
				RenderTexture.ReleaseTemporary(this.m_TempConvertedReflectionProbeTexture);
				this.m_TempConvertedReflectionProbeTexture = null;
			}
			if (this.m_TempConvolvedReflectionProbeTexture != null)
			{
				RenderTexture.ReleaseTemporary(this.m_TempConvolvedReflectionProbeTexture);
				this.m_TempConvolvedReflectionProbeTexture = null;
			}
		}

		// Token: 0x0600080A RID: 2058 RVA: 0x0004AC48 File Offset: 0x00048E48
		public Vector4 FetchCubeReflectionProbe(CommandBuffer cmd, HDProbe probe, out int fetchIndex)
		{
			Texture texture = probe.texture;
			int cubeFrameFetchIndex = this.m_CubeFrameFetchIndex;
			this.m_CubeFrameFetchIndex = cubeFrameFetchIndex + 1;
			fetchIndex = cubeFrameFetchIndex;
			Vector4 zero = Vector4.zero;
			int textureID = ReflectionProbeTextureCache.GetTextureID(probe);
			if (this.NeedsUpdate(textureID, probe.GetTextureHash(), ref zero) && !this.UpdateTexture(cmd, probe, ref zero))
			{
				this.LogErrorNoMoreSpaceOnce();
			}
			return zero;
		}

		// Token: 0x0600080B RID: 2059 RVA: 0x0004ACA0 File Offset: 0x00048EA0
		public Vector4 FetchPlanarReflectionProbe(CommandBuffer cmd, HDProbe probe, ref IBLFilterBSDF.PlanarTextureFilteringParameters planarTextureFilteringParameters, out int fetchIndex)
		{
			Texture texture = probe.texture;
			int planarFrameFetchIndex = this.m_PlanarFrameFetchIndex;
			this.m_PlanarFrameFetchIndex = planarFrameFetchIndex + 1;
			fetchIndex = planarFrameFetchIndex;
			Vector4 zero = Vector4.zero;
			int textureID = ReflectionProbeTextureCache.GetTextureID(probe);
			if (this.NeedsUpdate(textureID, probe.GetTextureHash(), ref zero) && !this.UpdateTexture(cmd, probe, ref planarTextureFilteringParameters, ref zero))
			{
				this.LogErrorNoMoreSpaceOnce();
			}
			return zero;
		}

		// Token: 0x0600080C RID: 2060 RVA: 0x0004ACFC File Offset: 0x00048EFC
		public void ReserveReflectionProbeSlot(HDProbe probe)
		{
			Texture texture = probe.texture;
			int textureSize;
			int textureIDAndSize = ReflectionProbeTextureCache.GetTextureIDAndSize(probe, out textureSize);
			Vector4 vector;
			if (!this.m_Atlas.IsCached(out vector, textureIDAndSize))
			{
				Vector4 zero = Vector4.zero;
				if (!this.TryAllocateTexture(textureIDAndSize, textureSize, ref zero) && this.RelayoutTextureAtlas())
				{
					this.TryAllocateTexture(textureIDAndSize, textureSize, ref zero);
				}
			}
		}

		// Token: 0x0600080D RID: 2061 RVA: 0x0004AD4E File Offset: 0x00048F4E
		public void NewFrame()
		{
			this.m_CubeFrameFetchIndex = 0;
			this.m_PlanarFrameFetchIndex = 0;
		}

		// Token: 0x0600080E RID: 2062 RVA: 0x0004AD60 File Offset: 0x00048F60
		public void NewRender()
		{
			this.m_NoMoreSpaceErrorLogged = false;
			this.m_CurrentRender += 1U;
			this.m_TextureLRUSorted.Clear();
			foreach (KeyValuePair<int, ValueTuple<uint, uint>> keyValuePair in this.m_TextureLRUAndHash)
			{
				this.m_TextureLRUSorted.Add(new ValueTuple<int, uint>(keyValuePair.Key, keyValuePair.Value.Item1));
			}
			this.m_TextureLRUSorted.Sort((ValueTuple<int, uint> a, ValueTuple<int, uint> b) => b.Item2.CompareTo(a.Item2));
		}

		// Token: 0x0600080F RID: 2063 RVA: 0x0004AE1C File Offset: 0x0004901C
		public void GarbageCollectTmpResources()
		{
			if (Math.Max((int)(this.m_CurrentRender - (uint)this.m_TempCubeTexturesLastFrameUsed), 0) <= 60)
			{
				return;
			}
			RenderTexture tempConvertedReflectionProbeTexture = this.m_TempConvertedReflectionProbeTexture;
			if (tempConvertedReflectionProbeTexture != null)
			{
				tempConvertedReflectionProbeTexture.Release();
			}
			RenderTexture tempConvolvedReflectionProbeTexture = this.m_TempConvolvedReflectionProbeTexture;
			if (tempConvolvedReflectionProbeTexture != null)
			{
				tempConvolvedReflectionProbeTexture.Release();
			}
			this.m_TempConvertedReflectionProbeTexture = null;
			this.m_TempConvolvedReflectionProbeTexture = null;
		}

		// Token: 0x06000810 RID: 2064 RVA: 0x0004AE71 File Offset: 0x00049071
		public void ClearAtlasAllocator()
		{
			this.m_Atlas.ResetAllocator();
			this.m_TextureLRUAndHash.Clear();
			this.m_TextureLRUSorted.Clear();
		}

		// Token: 0x06000811 RID: 2065 RVA: 0x0004AE94 File Offset: 0x00049094
		public void Clear(CommandBuffer cmd)
		{
			this.ClearAtlasAllocator();
			for (int i = 0; i < this.m_AtlasSlicesCount; i++)
			{
				for (int j = 0; j < this.m_AtlasMipCount; j++)
				{
					cmd.SetRenderTarget(this.m_AtlasTexture, j, CubemapFace.Unknown, i);
					Blitter.BlitQuad(cmd, Texture2D.blackTexture, new Vector4(1f, 1f, 0f, 0f), new Vector4(1f, 1f, 0f, 0f), j, true);
				}
			}
		}

		// Token: 0x040007A3 RID: 1955
		private IBLFilterBSDF[] m_IBLFiltersBSDF;

		// Token: 0x040007A4 RID: 1956
		private int m_AtlasWidth;

		// Token: 0x040007A5 RID: 1957
		private int m_AtlasHeight;

		// Token: 0x040007A6 RID: 1958
		private GraphicsFormat m_AtlasFormat;

		// Token: 0x040007A7 RID: 1959
		private int m_AtlasMipCount;

		// Token: 0x040007A8 RID: 1960
		private int m_AtlasSlicesCount;

		// Token: 0x040007A9 RID: 1961
		private RTHandle m_AtlasTexture;

		// Token: 0x040007AA RID: 1962
		private Texture2DAtlasDynamic m_Atlas;

		// Token: 0x040007AB RID: 1963
		private int m_CubeMipPadding;

		// Token: 0x040007AC RID: 1964
		private int m_CubeTexelPadding;

		// Token: 0x040007AD RID: 1965
		private int m_PlanarMipPadding;

		// Token: 0x040007AE RID: 1966
		private int m_PlanarTexelPadding;

		// Token: 0x040007AF RID: 1967
		private bool m_DecreaseResToFit;

		// Token: 0x040007B0 RID: 1968
		private int m_CubeFrameFetchIndex;

		// Token: 0x040007B1 RID: 1969
		private int m_PlanarFrameFetchIndex;

		// Token: 0x040007B2 RID: 1970
		private Dictionary<int, ValueTuple<uint, uint>> m_TextureLRUAndHash = new Dictionary<int, ValueTuple<uint, uint>>();

		// Token: 0x040007B3 RID: 1971
		private List<ValueTuple<int, uint>> m_TextureLRUSorted = new List<ValueTuple<int, uint>>();

		// Token: 0x040007B4 RID: 1972
		private Material m_ConvertTextureMaterial;

		// Token: 0x040007B5 RID: 1973
		private MaterialPropertyBlock m_ConvertTexturePropertyBlock = new MaterialPropertyBlock();

		// Token: 0x040007B6 RID: 1974
		private uint m_CurrentRender;

		// Token: 0x040007B7 RID: 1975
		private bool m_NoMoreSpaceErrorLogged;

		// Token: 0x040007B8 RID: 1976
		private RenderTexture m_ConvolvedPlanarReflectionTexture;

		// Token: 0x040007B9 RID: 1977
		private const int k_MaxFramesTmpUsage = 60;

		// Token: 0x040007BA RID: 1978
		private int m_TempCubeTexturesLastFrameUsed;

		// Token: 0x040007BB RID: 1979
		private int m_TmpTextureConvertedSize;

		// Token: 0x040007BC RID: 1980
		private int m_TmpTextureConvolvedWidth;

		// Token: 0x040007BD RID: 1981
		private int m_TmpTextureConvolvedHeight;

		// Token: 0x040007BE RID: 1982
		private FilterMode m_TmpConvolvedFilterMode;

		// Token: 0x040007BF RID: 1983
		private GraphicsFormat m_TmpTextureConvertedFormat;

		// Token: 0x040007C0 RID: 1984
		private GraphicsFormat m_TmpTextureConvolvedFormat;

		// Token: 0x040007C1 RID: 1985
		private FilterMode m_TmpTextureConvertedFilterMode;

		// Token: 0x040007C2 RID: 1986
		private FilterMode m_TmpTextureConvolvedFilterMode;

		// Token: 0x040007C3 RID: 1987
		private RenderTexture m_TempConvertedReflectionProbeTexture;

		// Token: 0x040007C4 RID: 1988
		private RenderTexture m_TempConvolvedReflectionProbeTexture;
	}
}
