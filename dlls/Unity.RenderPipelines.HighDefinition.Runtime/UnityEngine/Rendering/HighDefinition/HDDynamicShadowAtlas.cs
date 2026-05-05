using System;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering.RenderGraphModule;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000C4 RID: 196
	internal class HDDynamicShadowAtlas : HDShadowAtlas
	{
		// Token: 0x060008C5 RID: 2245 RVA: 0x0004DBA4 File Offset: 0x0004BDA4
		public HDDynamicShadowAtlas(HDShadowAtlas.HDShadowAtlasInitParameters atlaInitParams) : base(atlaInitParams)
		{
			this.m_SortedRequestsCache = new HDShadowResolutionRequest[Mathf.CeilToInt((float)atlaInitParams.maxShadowRequests)];
		}

		// Token: 0x060008C6 RID: 2246 RVA: 0x0004DBF0 File Offset: 0x0004BDF0
		internal void ReserveResolution(HDShadowResolutionRequest shadowRequest)
		{
			this.m_ShadowResolutionRequests.Add(shadowRequest);
		}

		// Token: 0x060008C7 RID: 2247 RVA: 0x0004DC00 File Offset: 0x0004BE00
		private void InsertionSort(HDShadowResolutionRequest[] array, int startIndex, int lastIndex)
		{
			for (int i = startIndex + 1; i < lastIndex; i++)
			{
				HDShadowResolutionRequest hdshadowResolutionRequest = array[i];
				int num = i - 1;
				while (num >= 0 && (hdshadowResolutionRequest.resolution.x > array[num].resolution.x || hdshadowResolutionRequest.resolution.y > array[num].resolution.y))
				{
					array[num + 1] = array[num];
					num--;
				}
				array[num + 1] = hdshadowResolutionRequest;
			}
		}

		// Token: 0x060008C8 RID: 2248 RVA: 0x0004DC70 File Offset: 0x0004BE70
		private bool AtlasLayout(bool allowResize, HDShadowResolutionRequest[] fullShadowList, int requestsCount)
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = (float)base.width;
			float num5 = (float)base.height;
			this.m_RcpScaleFactor = 1f;
			int i = 0;
			while (i < requestsCount)
			{
				HDShadowResolutionRequest hdshadowResolutionRequest = fullShadowList[i];
				Rect dynamicAtlasViewport = new Rect(Vector2.zero, hdshadowResolutionRequest.resolution);
				num3 = Mathf.Max(num3, dynamicAtlasViewport.height);
				if (num + dynamicAtlasViewport.width > num4)
				{
					num = 0f;
					num2 += num3;
					num3 = dynamicAtlasViewport.height;
				}
				if (num2 + num3 > num5)
				{
					if (allowResize)
					{
						this.LayoutResize();
						return true;
					}
					return false;
				}
				else
				{
					dynamicAtlasViewport.x = num;
					dynamicAtlasViewport.y = num2;
					hdshadowResolutionRequest.dynamicAtlasViewport = dynamicAtlasViewport;
					hdshadowResolutionRequest.resolution = dynamicAtlasViewport.size;
					num += dynamicAtlasViewport.width;
					i++;
				}
			}
			return true;
		}

		// Token: 0x060008C9 RID: 2249 RVA: 0x0004DD4C File Offset: 0x0004BF4C
		internal bool Layout(bool allowResize = true)
		{
			if (this.m_ShadowResolutionRequests != null)
			{
				int count = this.m_ShadowResolutionRequests.Count;
			}
			int i;
			for (i = 0; i < this.m_ShadowResolutionRequests.Count; i++)
			{
				this.m_SortedRequestsCache[i] = this.m_ShadowResolutionRequests[i];
			}
			this.InsertionSort(this.m_SortedRequestsCache, 0, i);
			return this.AtlasLayout(allowResize, this.m_SortedRequestsCache, i);
		}

		// Token: 0x060008CA RID: 2250 RVA: 0x0004DDB4 File Offset: 0x0004BFB4
		private void LayoutResize()
		{
			int i = 0;
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			while (i < this.m_ShadowResolutionRequests.Count)
			{
				float num5 = 0f;
				float num6 = num4;
				do
				{
					Rect dynamicAtlasViewport = new Rect(Vector2.zero, this.m_ShadowResolutionRequests[i].resolution);
					dynamicAtlasViewport.x = num4;
					dynamicAtlasViewport.y = num5;
					num5 += dynamicAtlasViewport.height;
					num2 = Mathf.Max(num2, num5);
					num6 = Mathf.Max(num6, num4 + dynamicAtlasViewport.width);
					this.m_ShadowResolutionRequests[i].dynamicAtlasViewport = dynamicAtlasViewport;
					i++;
				}
				while (num5 < num3 && i < this.m_ShadowResolutionRequests.Count);
				num3 = Mathf.Max(num3, num2);
				num4 = num6;
				if (i < this.m_ShadowResolutionRequests.Count)
				{
					float num7 = 0f;
					float num8 = num3;
					do
					{
						Rect dynamicAtlasViewport2 = new Rect(Vector2.zero, this.m_ShadowResolutionRequests[i].resolution);
						dynamicAtlasViewport2.x = num7;
						dynamicAtlasViewport2.y = num3;
						num7 += dynamicAtlasViewport2.width;
						num = Mathf.Max(num, num7);
						num8 = Mathf.Max(num8, num3 + dynamicAtlasViewport2.height);
						this.m_ShadowResolutionRequests[i].dynamicAtlasViewport = dynamicAtlasViewport2;
						i++;
					}
					while (num7 < num4 && i < this.m_ShadowResolutionRequests.Count);
					num4 = Mathf.Max(num4, num);
					num3 = num8;
				}
			}
			float num9 = Math.Max(num4, num3);
			Vector4 vector = new Vector4((float)base.width / num9, (float)base.height / num9, (float)base.width / num9, (float)base.height / num9);
			this.m_RcpScaleFactor = Mathf.Min(vector.x, vector.y);
			foreach (HDShadowResolutionRequest hdshadowResolutionRequest in this.m_ShadowResolutionRequests)
			{
				Vector4 vector2 = Vector4.Scale(new Vector4(hdshadowResolutionRequest.dynamicAtlasViewport.x, hdshadowResolutionRequest.dynamicAtlasViewport.y, hdshadowResolutionRequest.dynamicAtlasViewport.width, hdshadowResolutionRequest.dynamicAtlasViewport.height), vector);
				hdshadowResolutionRequest.dynamicAtlasViewport = new Rect(vector2.x, vector2.y, vector2.z, vector2.w);
				hdshadowResolutionRequest.resolution = hdshadowResolutionRequest.dynamicAtlasViewport.size;
			}
		}

		// Token: 0x060008CB RID: 2251 RVA: 0x0004E048 File Offset: 0x0004C248
		public void DisplayAtlas(RTHandle atlasTexture, CommandBuffer cmd, Material debugMaterial, Rect atlasViewport, float screenX, float screenY, float screenSizeX, float screenSizeY, float minValue, float maxValue, MaterialPropertyBlock mpb)
		{
			base.DisplayAtlas(atlasTexture, cmd, debugMaterial, atlasViewport, screenX, screenY, screenSizeX, screenSizeY, minValue, maxValue, mpb, this.m_RcpScaleFactor);
		}

		// Token: 0x060008CC RID: 2252 RVA: 0x0004E074 File Offset: 0x0004C274
		public void AddRequestToPendingBlitFromCache(HDShadowRequest request)
		{
			if (request.isMixedCached)
			{
				this.m_MixedRequestsPendingBlits.Add(request);
			}
		}

		// Token: 0x060008CD RID: 2253 RVA: 0x0004E08C File Offset: 0x0004C28C
		public void BlitCachedIntoAtlas(RenderGraph renderGraph, TextureHandle cachedAtlasTexture, Vector2Int cachedAtlasSize, Material blitMaterial, string passName, HDProfileId profileID)
		{
			if (this.m_MixedRequestsPendingBlits.Count > 0)
			{
				HDDynamicShadowAtlas.BlitCachedShadowPassData blitCachedShadowPassData;
				using (RenderGraphBuilder renderGraphBuilder = renderGraph.AddRenderPass<HDDynamicShadowAtlas.BlitCachedShadowPassData>(passName, out blitCachedShadowPassData, ProfilingSampler.Get<HDProfileId>(profileID)))
				{
					blitCachedShadowPassData.requestsWaitingBlits = this.m_MixedRequestsPendingBlits;
					blitCachedShadowPassData.blitMaterial = blitMaterial;
					blitCachedShadowPassData.cachedShadowAtlasSize = cachedAtlasSize;
					blitCachedShadowPassData.sourceCachedAtlas = renderGraphBuilder.ReadTexture(cachedAtlasTexture);
					HDDynamicShadowAtlas.BlitCachedShadowPassData blitCachedShadowPassData2 = blitCachedShadowPassData;
					TextureHandle shadowMapDepthTexture = base.GetShadowMapDepthTexture(renderGraph);
					blitCachedShadowPassData2.atlasTexture = renderGraphBuilder.WriteTexture(shadowMapDepthTexture);
					renderGraphBuilder.SetRenderFunc<HDDynamicShadowAtlas.BlitCachedShadowPassData>(delegate(HDDynamicShadowAtlas.BlitCachedShadowPassData data, RenderGraphContext ctx)
					{
						foreach (HDShadowRequest hdshadowRequest in data.requestsWaitingBlits)
						{
							MaterialPropertyBlock tempMaterialPropertyBlock = ctx.renderGraphPool.GetTempMaterialPropertyBlock();
							ctx.cmd.SetRenderTarget(data.atlasTexture);
							ctx.cmd.SetViewport(hdshadowRequest.dynamicAtlasViewport);
							Vector4 value = new Vector4(hdshadowRequest.cachedAtlasViewport.width / (float)data.cachedShadowAtlasSize.x, hdshadowRequest.cachedAtlasViewport.height / (float)data.cachedShadowAtlasSize.y, hdshadowRequest.cachedAtlasViewport.x / (float)data.cachedShadowAtlasSize.x, hdshadowRequest.cachedAtlasViewport.y / (float)data.cachedShadowAtlasSize.y);
							tempMaterialPropertyBlock.SetTexture(HDShaderIDs._CachedShadowmapAtlas, data.sourceCachedAtlas);
							tempMaterialPropertyBlock.SetVector(HDShaderIDs._BlitScaleBias, value);
							CoreUtils.DrawFullScreen(ctx.cmd, data.blitMaterial, tempMaterialPropertyBlock, 0);
						}
						data.requestsWaitingBlits.Clear();
					});
				}
			}
		}

		// Token: 0x060008CE RID: 2254 RVA: 0x0004E144 File Offset: 0x0004C344
		public override void Clear()
		{
			base.Clear();
			this.m_ShadowResolutionRequests.Clear();
			this.m_MixedRequestsPendingBlits.Clear();
		}

		// Token: 0x04000880 RID: 2176
		private readonly List<HDShadowResolutionRequest> m_ShadowResolutionRequests = new List<HDShadowResolutionRequest>();

		// Token: 0x04000881 RID: 2177
		private readonly List<HDShadowRequest> m_MixedRequestsPendingBlits = new List<HDShadowRequest>();

		// Token: 0x04000882 RID: 2178
		private float m_RcpScaleFactor = 1f;

		// Token: 0x04000883 RID: 2179
		private HDShadowResolutionRequest[] m_SortedRequestsCache;

		// Token: 0x0200034F RID: 847
		private class BlitCachedShadowPassData
		{
			// Token: 0x04002357 RID: 9047
			public List<HDShadowRequest> requestsWaitingBlits;

			// Token: 0x04002358 RID: 9048
			public Material blitMaterial;

			// Token: 0x04002359 RID: 9049
			public Vector2Int cachedShadowAtlasSize;

			// Token: 0x0400235A RID: 9050
			public TextureHandle sourceCachedAtlas;

			// Token: 0x0400235B RID: 9051
			public TextureHandle atlasTexture;
		}
	}
}
