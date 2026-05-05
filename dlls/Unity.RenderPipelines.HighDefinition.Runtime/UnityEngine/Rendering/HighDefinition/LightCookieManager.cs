using System;
using UnityEngine.Experimental.Rendering;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200007F RID: 127
	internal class LightCookieManager
	{
		// Token: 0x0600070C RID: 1804 RVA: 0x00046D84 File Offset: 0x00044F84
		public LightCookieManager(HDRenderPipelineAsset hdAsset, int maxCacheSize)
		{
			this.m_RenderPipelineAsset = hdAsset;
			HDRenderPipelineRuntimeResources renderPipelineResources = HDRenderPipelineGlobalSettings.instance.renderPipelineResources;
			GlobalLightLoopSettings lightLoopSettings = hdAsset.currentPlatformRenderPipelineSettings.lightLoopSettings;
			this.m_MaterialFilterAreaLights = CoreUtils.CreateEngineMaterial(renderPipelineResources.shaders.filterAreaLightCookiesPS);
			int cookieAtlasSize = (int)lightLoopSettings.cookieAtlasSize;
			this.cookieFormat = (GraphicsFormat)lightLoopSettings.cookieFormat;
			this.cookieAtlasLastValidMip = lightLoopSettings.cookieAtlasLastValidMip;
			this.m_CookieAtlas = new PowerOfTwoTextureAtlas(cookieAtlasSize, lightLoopSettings.cookieAtlasLastValidMip, this.cookieFormat, FilterMode.Point, "Cookie Atlas (Punctual Lights)", true);
		}

		// Token: 0x0600070D RID: 1805 RVA: 0x00046E14 File Offset: 0x00045014
		public void NewFrame()
		{
			this.m_CookieAtlas.ResetRequestedTexture();
			this.m_2DCookieAtlasNeedsLayouting = false;
			this.m_NoMoreSpace = false;
		}

		// Token: 0x0600070E RID: 1806 RVA: 0x00046E30 File Offset: 0x00045030
		public void Release()
		{
			CoreUtils.Destroy(this.m_MaterialFilterAreaLights);
			if (this.m_TempRenderTexture0 != null)
			{
				this.m_TempRenderTexture0.Release();
				this.m_TempRenderTexture0 = null;
			}
			if (this.m_TempRenderTexture1 != null)
			{
				this.m_TempRenderTexture1.Release();
				this.m_TempRenderTexture1 = null;
			}
			if (this.m_CookieAtlas != null)
			{
				this.m_CookieAtlas.Release();
				this.m_CookieAtlas = null;
			}
		}

		// Token: 0x0600070F RID: 1807 RVA: 0x00046EA4 File Offset: 0x000450A4
		private void ReserveTempTextureIfNeeded(CommandBuffer cmd, int mipMapCount)
		{
			if (this.m_TempRenderTexture0 == null)
			{
				int width = this.m_CookieAtlas.AtlasTexture.rt.width;
				int height = this.m_CookieAtlas.AtlasTexture.rt.height;
				string name = this.m_CookieAtlas.AtlasTexture.name;
				this.m_TempRenderTexture0 = new RenderTexture(width, height, 1, this.cookieFormat)
				{
					hideFlags = HideFlags.HideAndDontSave,
					useMipMap = true,
					autoGenerateMips = false,
					name = name + "TempAreaLightRT0"
				};
				for (int i = 0; i < mipMapCount; i++)
				{
					cmd.SetRenderTarget(this.m_TempRenderTexture0, i);
					cmd.ClearRenderTarget(false, true, Color.clear);
				}
				this.m_TempRenderTexture1 = new RenderTexture(width >> 1, height, 1, this.cookieFormat)
				{
					hideFlags = HideFlags.HideAndDontSave,
					useMipMap = true,
					autoGenerateMips = false,
					name = name + "TempAreaLightRT1"
				};
				for (int j = 0; j < mipMapCount - 1; j++)
				{
					cmd.SetRenderTarget(this.m_TempRenderTexture1, j);
					cmd.ClearRenderTarget(false, true, Color.clear);
				}
			}
		}

		// Token: 0x06000710 RID: 1808 RVA: 0x00046FD4 File Offset: 0x000451D4
		private Texture FilterAreaLightTexture(CommandBuffer cmd, Texture source, int finalWidth, int finalHeight)
		{
			if (this.m_MaterialFilterAreaLights == null)
			{
				Debug.LogError("FilterAreaLightTexture has an invalid shader. Can't filter area light cookie.");
				return null;
			}
			int num = this.m_CookieAtlas.AtlasTexture.rt.width;
			int num2 = this.m_CookieAtlas.AtlasTexture.rt.height;
			int num3 = finalWidth;
			int num4 = finalHeight;
			int num5 = 1 + Mathf.FloorToInt(Mathf.Log((float)Mathf.Max(source.width, source.height), 2f));
			this.ReserveTempTextureIfNeeded(cmd, num5);
			using (new ProfilingScope(cmd, ProfilingSampler.Get<HDProfileId>(HDProfileId.AreaLightCookieConvolution)))
			{
				int num6 = num;
				int num7 = num2;
				if (source.dimension == TextureDimension.Cube)
				{
					this.m_MPBFilterAreaLights.SetInt(LightCookieManager.s_sourceMipLevel, 0);
					this.m_MPBFilterAreaLights.SetTexture(LightCookieManager.s_texCubeSource, source);
					cmd.SetRenderTarget(this.m_TempRenderTexture0, 0);
					cmd.SetViewport(new Rect(0f, 0f, (float)num3, (float)num4));
					cmd.DrawProcedural(Matrix4x4.identity, this.m_MaterialFilterAreaLights, 3, MeshTopology.Triangles, 3, 1, this.m_MPBFilterAreaLights);
				}
				else
				{
					this.m_MPBFilterAreaLights.SetInt(LightCookieManager.s_sourceMipLevel, 0);
					this.m_MPBFilterAreaLights.SetTexture(LightCookieManager.s_texSource, source);
					int num8 = 1;
					cmd.SetRenderTarget(this.m_TempRenderTexture0, 0);
					cmd.SetViewport(new Rect(0f, 0f, (float)(num3 + num8), (float)(num4 + num8)));
					this.m_MPBFilterAreaLights.SetVector(LightCookieManager.s_sourceSize, new Vector4((float)num3, (float)num4, (float)(num3 + num8) / (float)num3, (float)(num4 + num8) / (float)num4));
					cmd.DrawProcedural(Matrix4x4.identity, this.m_MaterialFilterAreaLights, 0, MeshTopology.Triangles, 3, 1, this.m_MPBFilterAreaLights);
				}
				Vector4 zero = Vector4.zero;
				for (int i = 1; i < num5; i++)
				{
					zero.Set((float)num3 / (float)num * 1f, (float)num4 / (float)num2, 1f / (float)num, 1f / (float)num2);
					Vector4 value = new Vector4(0f, 0f, (float)num3 / (float)num, (float)num4 / (float)num2);
					num3 = Mathf.Max(1, num3 >> 1);
					num6 = Mathf.Max(1, num6 >> 1);
					this.m_MPBFilterAreaLights.SetTexture(LightCookieManager.s_texSource, this.m_TempRenderTexture0);
					this.m_MPBFilterAreaLights.SetInt(LightCookieManager.s_sourceMipLevel, i - 1);
					this.m_MPBFilterAreaLights.SetVector(LightCookieManager.s_sourceSize, zero);
					this.m_MPBFilterAreaLights.SetVector(LightCookieManager.s_uvLimits, value);
					cmd.SetRenderTarget(this.m_TempRenderTexture1, i - 1);
					cmd.SetViewport(new Rect(0f, 0f, (float)num3, (float)num4));
					cmd.DrawProcedural(Matrix4x4.identity, this.m_MaterialFilterAreaLights, 1, MeshTopology.Triangles, 3, 1, this.m_MPBFilterAreaLights);
					num = num6;
					zero.Set((float)num3 / (float)num, (float)num4 / (float)num2 * 1f, 1f / (float)num, 1f / (float)num2);
					Vector4 value2 = new Vector4(0f, 0f, (float)num3 / (float)num, (float)num4 / (float)num2);
					num4 = Mathf.Max(1, num4 >> 1);
					num7 = Mathf.Max(1, num7 >> 1);
					this.m_MPBFilterAreaLights.SetTexture(LightCookieManager.s_texSource, this.m_TempRenderTexture1);
					this.m_MPBFilterAreaLights.SetInt(LightCookieManager.s_sourceMipLevel, i - 1);
					this.m_MPBFilterAreaLights.SetVector(LightCookieManager.s_sourceSize, zero);
					this.m_MPBFilterAreaLights.SetVector(LightCookieManager.s_uvLimits, value2);
					cmd.SetRenderTarget(this.m_TempRenderTexture0, i);
					cmd.SetViewport(new Rect(0f, 0f, (float)num3, (float)num4));
					cmd.DrawProcedural(Matrix4x4.identity, this.m_MaterialFilterAreaLights, 2, MeshTopology.Triangles, 3, 1, this.m_MPBFilterAreaLights);
					num2 = num7;
				}
			}
			return this.m_TempRenderTexture0;
		}

		// Token: 0x06000711 RID: 1809 RVA: 0x000473B4 File Offset: 0x000455B4
		public void LayoutIfNeeded()
		{
			if (!this.m_2DCookieAtlasNeedsLayouting)
			{
				return;
			}
			if (!this.m_CookieAtlas.RelayoutEntries())
			{
				Debug.LogError("No more space in the 2D Cookie Texture Atlas. To solve this issue, increase the resolution of the cookie atlas in the HDRP settings.");
				this.m_NoMoreSpace = true;
			}
		}

		// Token: 0x06000712 RID: 1810 RVA: 0x000473E0 File Offset: 0x000455E0
		public Vector4 Fetch2DCookie(CommandBuffer cmd, Texture cookie, Texture ies)
		{
			int num = Mathf.Max(cookie.width, ies.height);
			int num2 = Mathf.Max(cookie.width, ies.height);
			if (num < 2 || num2 < 2)
			{
				return Vector4.zero;
			}
			Vector4 vector;
			if (!this.m_CookieAtlas.IsCached(out vector, this.m_CookieAtlas.GetTextureID(cookie, ies)) && !this.m_NoMoreSpace)
			{
				Debug.LogError(string.Format("Unity cannot fetch the 2D Light cookie texture: {0} because it is not on the cookie atlas. To resolve this, open your HDRP Asset and increase the resolution of the cookie atlas.", cookie));
			}
			if (this.m_CookieAtlas.NeedsUpdate(cookie, ies, false))
			{
				this.m_CookieAtlas.BlitTexture(cmd, vector, ies, new Vector4(1f, 1f, 0f, 0f), false, this.m_CookieAtlas.GetTextureID(cookie, ies));
				this.m_CookieAtlas.BlitTextureMultiply(cmd, vector, cookie, new Vector4(1f, 1f, 0f, 0f), false, this.m_CookieAtlas.GetTextureID(cookie, ies));
			}
			return vector;
		}

		// Token: 0x06000713 RID: 1811 RVA: 0x000474CC File Offset: 0x000456CC
		public Vector4 Fetch2DCookie(CommandBuffer cmd, Texture cookie)
		{
			if (cookie.width < 2 || cookie.height < 2)
			{
				return Vector4.zero;
			}
			Vector4 vector;
			if (!this.m_CookieAtlas.IsCached(out vector, this.m_CookieAtlas.GetTextureID(cookie)) && !this.m_NoMoreSpace)
			{
				Debug.LogError(string.Format("Unity cannot fetch the 2D Light cookie texture: {0} because it is not on the cookie atlas. To resolve this, open your HDRP Asset and increase the resolution of the cookie atlas.", cookie));
			}
			if (this.m_CookieAtlas.NeedsUpdate(cookie, false))
			{
				this.m_CookieAtlas.BlitTexture(cmd, vector, cookie, new Vector4(1f, 1f, 0f, 0f), false, -1);
			}
			return vector;
		}

		// Token: 0x06000714 RID: 1812 RVA: 0x00047560 File Offset: 0x00045760
		public Vector4 FetchAreaCookie(CommandBuffer cmd, Texture cookie)
		{
			if (cookie.width < 2 || cookie.height < 2)
			{
				return Vector4.zero;
			}
			Vector4 vector;
			if (!this.m_CookieAtlas.IsCached(out vector, cookie) && !this.m_NoMoreSpace)
			{
				Debug.LogError(string.Format("Area Light cookie texture {0} can't be fetched without having reserved. You can try to increase the cookie atlas resolution in the HDRP settings.", cookie));
			}
			int textureID = this.m_CookieAtlas.GetTextureID(cookie);
			if (this.m_CookieAtlas.NeedsUpdate(cookie, true))
			{
				Texture texture = this.FilterAreaLightTexture(cmd, cookie, cookie.width, cookie.height);
				Vector4 sourceScaleOffset = new Vector4(((float)cookie.width - 0.5f) / (float)this.atlasTexture.rt.width, ((float)cookie.height - 0.5f) / (float)this.atlasTexture.rt.height, 0f, 0f);
				this.m_CookieAtlas.BlitTexture(cmd, vector, texture, sourceScaleOffset, true, textureID);
			}
			return vector;
		}

		// Token: 0x06000715 RID: 1813 RVA: 0x00047640 File Offset: 0x00045840
		public Vector4 FetchAreaCookie(CommandBuffer cmd, Texture cookie, Texture ies)
		{
			int num = Mathf.Max(cookie.width, ies.height);
			int num2 = Mathf.Max(cookie.width, ies.height);
			if (num < 2 || num2 < 2)
			{
				return Vector4.zero;
			}
			int num3 = 2 * (int)Mathf.Max((float)cookie.width, (float)ies.width);
			Vector4 vector;
			if (!this.m_CookieAtlas.IsCached(out vector, cookie, ies) && !this.m_NoMoreSpace)
			{
				Debug.LogError(string.Format("Area Light cookie texture {0} & {1} can't be fetched without having reserved. You can try to increase the cookie atlas resolution in the HDRP settings.", cookie, ies));
			}
			if (this.m_CookieAtlas.NeedsUpdate(cookie, ies, true))
			{
				Vector4 sourceScaleOffset = new Vector4((float)num3 / (float)this.atlasTexture.rt.width, (float)num3 / (float)this.atlasTexture.rt.height, 0f, 0f);
				Texture texture = this.FilterAreaLightTexture(cmd, cookie, num3, num3);
				this.m_CookieAtlas.BlitOctahedralTexture(cmd, vector, texture, sourceScaleOffset, true, this.m_CookieAtlas.GetTextureID(cookie, ies));
				texture = this.FilterAreaLightTexture(cmd, ies, num3, num3);
				this.m_CookieAtlas.BlitOctahedralTextureMultiply(cmd, vector, texture, sourceScaleOffset, true, this.m_CookieAtlas.GetTextureID(cookie, ies));
			}
			return vector;
		}

		// Token: 0x06000716 RID: 1814 RVA: 0x00047760 File Offset: 0x00045960
		public void ReserveSpace(Texture cookieA, Texture cookieB)
		{
			if (cookieA == null || cookieB == null)
			{
				return;
			}
			int num = Mathf.Max(cookieA.width, cookieB.height);
			int num2 = Mathf.Max(cookieA.width, cookieB.height);
			if (num < 2 || num2 < 2)
			{
				return;
			}
			if (!this.m_CookieAtlas.ReserveSpace(cookieA, cookieB, num, num2))
			{
				this.m_2DCookieAtlasNeedsLayouting = true;
			}
		}

		// Token: 0x06000717 RID: 1815 RVA: 0x000477C5 File Offset: 0x000459C5
		public void ReserveSpace(Texture cookie)
		{
			if (cookie == null)
			{
				return;
			}
			if (cookie.width < 2 || cookie.height < 2)
			{
				return;
			}
			if (!this.m_CookieAtlas.ReserveSpace(cookie))
			{
				this.m_2DCookieAtlasNeedsLayouting = true;
			}
		}

		// Token: 0x06000718 RID: 1816 RVA: 0x000477FC File Offset: 0x000459FC
		public void ReserveSpaceCube(Texture cookie)
		{
			if (cookie == null)
			{
				return;
			}
			int num = 2 * cookie.width;
			if (num < 2)
			{
				return;
			}
			if (!this.m_CookieAtlas.ReserveSpace(cookie, num, num))
			{
				this.m_2DCookieAtlasNeedsLayouting = true;
			}
		}

		// Token: 0x06000719 RID: 1817 RVA: 0x00047838 File Offset: 0x00045A38
		public void ReserveSpaceCube(Texture cookieA, Texture cookieB)
		{
			if (cookieA == null && cookieB == null)
			{
				return;
			}
			int num = 2 * Mathf.Max(cookieA.width, cookieB.width);
			if (num < 2)
			{
				return;
			}
			if (!this.m_CookieAtlas.ReserveSpace(cookieA, cookieB, num, num))
			{
				this.m_2DCookieAtlasNeedsLayouting = true;
			}
		}

		// Token: 0x0600071A RID: 1818 RVA: 0x0004788C File Offset: 0x00045A8C
		public Vector4 FetchCubeCookie(CommandBuffer cmd, Texture cookie)
		{
			int num = 2 * cookie.width;
			if (num < 2)
			{
				return Vector4.zero;
			}
			Vector4 vector;
			if (!this.m_CookieAtlas.IsCached(out vector, cookie) && !this.m_NoMoreSpace)
			{
				Debug.LogError(string.Format("Unity cannot fetch the Cube cookie texture: {0} because it is not on the cookie atlas. To resolve this, open your HDRP Asset and increase the resolution of the cookie atlas.", cookie));
			}
			if (this.m_CookieAtlas.NeedsUpdate(cookie, true))
			{
				Vector4 sourceScaleOffset = new Vector4((float)num / (float)this.atlasTexture.rt.width, (float)num / (float)this.atlasTexture.rt.height, 0f, 0f);
				Texture texture = this.FilterAreaLightTexture(cmd, cookie, num, num);
				this.m_CookieAtlas.BlitOctahedralTexture(cmd, vector, texture, sourceScaleOffset, true, this.m_CookieAtlas.GetTextureID(cookie));
			}
			return vector;
		}

		// Token: 0x0600071B RID: 1819 RVA: 0x00047944 File Offset: 0x00045B44
		public Vector4 FetchCubeCookie(CommandBuffer cmd, Texture cookie, Texture ies)
		{
			int num = 2 * cookie.width;
			if (num < 2)
			{
				return Vector4.zero;
			}
			Vector4 vector;
			if (!this.m_CookieAtlas.IsCached(out vector, cookie, ies) && !this.m_NoMoreSpace)
			{
				Debug.LogError(string.Format("Unity cannot fetch the Cube cookie texture: {0} because it is not on the cookie atlas. To resolve this, open your HDRP Asset and increase the resolution of the cookie atlas.", cookie));
			}
			if (this.m_CookieAtlas.NeedsUpdate(cookie, ies, true))
			{
				Vector4 sourceScaleOffset = new Vector4((float)num / (float)this.atlasTexture.rt.width, (float)num / (float)this.atlasTexture.rt.height, 0f, 0f);
				Texture texture = this.FilterAreaLightTexture(cmd, cookie, num, num);
				this.m_CookieAtlas.BlitOctahedralTexture(cmd, vector, texture, sourceScaleOffset, true, this.m_CookieAtlas.GetTextureID(cookie, ies));
				texture = this.FilterAreaLightTexture(cmd, ies, num, num);
				this.m_CookieAtlas.BlitOctahedralTextureMultiply(cmd, vector, texture, sourceScaleOffset, true, this.m_CookieAtlas.GetTextureID(cookie, ies));
			}
			return vector;
		}

		// Token: 0x0600071C RID: 1820 RVA: 0x00047A2A File Offset: 0x00045C2A
		public void ResetAllocator()
		{
			this.m_CookieAtlas.ResetAllocator();
		}

		// Token: 0x0600071D RID: 1821 RVA: 0x00047A37 File Offset: 0x00045C37
		public void ClearAtlasTexture(CommandBuffer cmd)
		{
			this.m_CookieAtlas.ClearTarget(cmd);
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x0600071E RID: 1822 RVA: 0x00047A45 File Offset: 0x00045C45
		public RTHandle atlasTexture
		{
			get
			{
				return this.m_CookieAtlas.AtlasTexture;
			}
		}

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x0600071F RID: 1823 RVA: 0x00047A52 File Offset: 0x00045C52
		public PowerOfTwoTextureAtlas atlas
		{
			get
			{
				return this.m_CookieAtlas;
			}
		}

		// Token: 0x06000720 RID: 1824 RVA: 0x00047A5C File Offset: 0x00045C5C
		public Vector4 GetCookieAtlasSize()
		{
			return new Vector4((float)this.m_CookieAtlas.AtlasTexture.rt.width, (float)this.m_CookieAtlas.AtlasTexture.rt.height, 1f / (float)this.m_CookieAtlas.AtlasTexture.rt.width, 1f / (float)this.m_CookieAtlas.AtlasTexture.rt.height);
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x00047AD4 File Offset: 0x00045CD4
		public Vector4 GetCookieAtlasDatas()
		{
			float num = Mathf.Pow(2f, (float)this.m_CookieAtlas.mipPadding) * 2f;
			return new Vector4((float)this.m_CookieAtlas.AtlasTexture.rt.width, num / (float)this.m_CookieAtlas.AtlasTexture.rt.width, (float)this.cookieAtlasLastValidMip, 0f);
		}

		// Token: 0x0400060A RID: 1546
		private HDRenderPipelineAsset m_RenderPipelineAsset;

		// Token: 0x0400060B RID: 1547
		internal static readonly int s_texSource = Shader.PropertyToID("_SourceTexture");

		// Token: 0x0400060C RID: 1548
		internal static readonly int s_texCubeSource = Shader.PropertyToID("_SourceCubeTexture");

		// Token: 0x0400060D RID: 1549
		internal static readonly int s_sourceMipLevel = Shader.PropertyToID("_SourceMipLevel");

		// Token: 0x0400060E RID: 1550
		internal static readonly int s_sourceSize = Shader.PropertyToID("_SourceSize");

		// Token: 0x0400060F RID: 1551
		internal static readonly int s_uvLimits = Shader.PropertyToID("_UVLimits");

		// Token: 0x04000610 RID: 1552
		internal const int k_MinCookieSize = 2;

		// Token: 0x04000611 RID: 1553
		private readonly Material m_MaterialFilterAreaLights;

		// Token: 0x04000612 RID: 1554
		private MaterialPropertyBlock m_MPBFilterAreaLights = new MaterialPropertyBlock();

		// Token: 0x04000613 RID: 1555
		private RenderTexture m_TempRenderTexture0;

		// Token: 0x04000614 RID: 1556
		private RenderTexture m_TempRenderTexture1;

		// Token: 0x04000615 RID: 1557
		private PowerOfTwoTextureAtlas m_CookieAtlas;

		// Token: 0x04000616 RID: 1558
		private bool m_2DCookieAtlasNeedsLayouting;

		// Token: 0x04000617 RID: 1559
		private bool m_NoMoreSpace;

		// Token: 0x04000618 RID: 1560
		private readonly int cookieAtlasLastValidMip;

		// Token: 0x04000619 RID: 1561
		private readonly GraphicsFormat cookieFormat;
	}
}
